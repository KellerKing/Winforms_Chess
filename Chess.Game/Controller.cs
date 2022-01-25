using Chess.Game.Contracts;
using Chess.Game.Factory;
using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winforms_Chess;

namespace Chess.Game
{
  public class Controller
  {
    private readonly GameForm m_mainForm;
    private readonly InputDto m_InputDto;
    private ResultDto m_ResultDto = new();
    private Player m_CurrentPlayer = Player.WHITE;
    private Piece m_SelectedPiece;
    private List<Coords> m_PossibleFelder = new();
    private readonly IChessLogicController m_LogicController;
    private readonly Chess.AI.Controller m_ChessAiController;
    private List<Piece> m_BoardPosition;
    private readonly Coords[,] m_Felder;

    private List<string> m_Moves = new()
    {
      //"6rr/3k4/8/8/8/8/8/3K4",
      "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR"
    };

    public Controller(InputDto inputDto)
    {
      m_mainForm = new GameForm();
      m_LogicController = new Produktlogic.Controller();
      m_ChessAiController = inputDto.Singleplayer ? new AI.Controller() : null;
      m_Felder = Helper.CreateFelder(8, 8);
      ConnectEvents();
      InitGameComponents(inputDto.Singleplayer ? inputDto.PlayerSelected : Player.WHITE);
      m_InputDto = inputDto;
    }

    public ResultDto ShowGame()
    {
      UpdateScores();
      m_mainForm.ShowDialog();
      return m_ResultDto;
    }

    private void InitGameComponents(Player playerCurrent)
    {
      m_BoardPosition = m_LogicController.CreatePiecesFromFen(m_Moves[0]);
      var piecesToDraw = ViewModelCreator.GeneratePieces(m_BoardPosition);
      var felderToDraw = ViewModelCreator.CreateChessBoardDrawModels(m_Felder);
      m_mainForm.InitBoard(felderToDraw, playerCurrent);
      m_mainForm.InitPieces(piecesToDraw);
    }

    private void ConnectEvents()
    {
      m_mainForm.GameObjectClickedAction += GameObjectClicked;
      m_mainForm.OnButtonSettingsClicked += OnButtonSettingsClicked;
    }

    private void ValidiereZug(UpdatePositionDto moveResult)
    {
      if (!moveResult.WasMoveLegal) return;

      m_CurrentPlayer = Helper.GetEnemy(m_CurrentPlayer);
      m_SelectedPiece = null;
      m_PossibleFelder = moveResult.PossibleFelder;
      m_BoardPosition = moveResult.BoardPosition;
      m_mainForm.UpdatePieces(ViewModelCreator.GeneratePieces(moveResult.BoardPosition));
      m_mainForm.RemoveHighlightedFelder();
      UpdateScores();
      HandlePlayerLossOrDoNothing();
    }

    private async Task MakeEnemyMoveAsync()
    {
      var postion = await Task.Run(() => m_ChessAiController.GetBestMove(m_BoardPosition, m_CurrentPlayer, 4));
      m_mainForm.UpdatePieces(ViewModelCreator.GeneratePieces(postion));
      m_BoardPosition = postion;
      m_CurrentPlayer = Helper.GetEnemy(m_CurrentPlayer);
      UpdateScores();
      HandlePlayerLossOrDoNothing();
    }

    private void HandlePlayerLossOrDoNothing()
    {
      var gameOverResult = m_LogicController.IsGameOver(m_BoardPosition, m_CurrentPlayer);
      if (gameOverResult == GameOver.NO) return;

      m_ResultDto = ResultDtoFactory.GetResultDto(Helper.GetEnemy(m_CurrentPlayer).ToString(), gameOverResult, System.Windows.Forms.DialogResult.OK);
      m_mainForm.Dispose();
      m_mainForm.Close();
    }

    private void UpdateScores()
    {
      var scoreBlack = m_LogicController.GetScoring(m_BoardPosition, Player.BLACK);
      var scoreWhite = m_LogicController.GetScoring(m_BoardPosition, Player.WHITE);
      m_mainForm.SetScore(scoreWhite, scoreBlack);
    }

    private void SelectPieceToMove(Coords coords)
    {
      m_SelectedPiece = m_BoardPosition.First(x => x.Coord.Equals(coords));
      m_PossibleFelder = m_LogicController.GetPossibleFelderForPiece(m_SelectedPiece, m_BoardPosition);

      if (!Settings.ShowHighlightedFelder) return;
      m_mainForm.RemoveHighlightedFelder();
      m_mainForm.ShowPossibleFelder(m_PossibleFelder);
    }

    private UpdatePositionDto ConvertPawn(Coords clickedCoords)
    {
      var ctr = new PieceSelectForm.Controller(m_CurrentPlayer);
      var newPiece = ctr.ShowDialog();
      var moveResult = m_LogicController.MakeNonCaptureMove(m_BoardPosition, clickedCoords, m_SelectedPiece);
      moveResult.BoardPosition.First(x => x.Coord.Equals(clickedCoords)).PiceType = newPiece;
      return moveResult;
    }

    private void OnButtonSettingsClicked(Point locationStart)
    {
      var ctr = new SettingsForm.Controller(new SettingsForm.InputDto
      {
        LocationStart = locationStart,
        HighlightFelder = Settings.ShowHighlightedFelder
      });
      var result = ctr.ShowDialog();

      if (result.DialogResult != DialogResult.OK) return;
      UpdateSettings(result);
    }

    private void UpdateSettings(SettingsForm.ResultDto result)
    {
      if (!result.HighlightFelder) m_mainForm.RemoveHighlightedFelder();
      else m_mainForm.ShowPossibleFelder(m_PossibleFelder);
      Settings.ShowHighlightedFelder = result.HighlightFelder;
    
    }

    private void GameObjectClicked(Coords coordsClicked)
    {
      UpdatePositionDto moveResult = null;

      switch (m_LogicController.GetMoveType(m_PossibleFelder, coordsClicked, m_BoardPosition, m_SelectedPiece, m_CurrentPlayer))
      {
        case MoveType.CASTLE:
          moveResult = m_LogicController.MakeCastleMove(m_BoardPosition, coordsClicked, m_SelectedPiece);
          break;
        case MoveType.CAPUTRE:
          var clickedPiece = m_BoardPosition.First(x => x.Coord.Equals(coordsClicked));
          moveResult = m_LogicController.MakeCaptureMove(m_BoardPosition, clickedPiece, m_SelectedPiece);
          break;
        case MoveType.FORWARD:
          moveResult = m_LogicController.MakeNonCaptureMove(m_BoardPosition, coordsClicked, m_SelectedPiece);
          break;
        case MoveType.PIECE_SELECT:
          if (m_BoardPosition.First(x => x.Coord.Equals(coordsClicked)) == m_SelectedPiece) return;
          SelectPieceToMove(coordsClicked);
          return;
        case MoveType.NONE:
          return;
        case MoveType.CONVERT_PAWN:
          moveResult = ConvertPawn(coordsClicked);
          break;
      }
      ValidiereZug(moveResult);

      if (m_ChessAiController != null) MakeEnemyMoveAsync();
    }
  }
}
