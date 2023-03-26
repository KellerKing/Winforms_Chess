using Chess.Contracts.Game;
using Chess.Game.Connector;
using Chess.Game.Converter;
using Chess.Game.Converter.Interface;
using Chess.Game.Factory;
using Chess.Game.Konstanten;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.Game
{
  public class Controller : IGameController
  {
    private readonly GameForm m_mainForm;
    private ResultDto m_ResultDto = new();
    private Konstanten.Player m_CurrentPlayer;
    private Dto.Piece m_SelectedPiece;
    private List<Dto.Coords> m_PossibleFelder = new();
    
    private readonly ProduktlogicConnector m_LogicConnector;
    private readonly AiConnector m_AiConnector;
    private readonly IInputDtoConverter m_InputDtoConverter;


    private List<Dto.Piece> m_BoardPosition;
    private readonly Dto.Coords[,] m_Felder;

    private List<string> m_Moves = new()
    {
      //"6rr/3k4/8/8/8/8/8/3K4",
      "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR"
    };

    public Controller(InputDto inputDto)
    {
      m_InputDtoConverter = new InputDtoConverter();
      m_mainForm = new GameForm();
      m_LogicConnector = new ProduktlogicConnector(new Productlogic.Controller());
      m_CurrentPlayer = m_InputDtoConverter.GetStartingPlayer(inputDto);
      m_AiConnector = new AiConnector(AiControllerFactory.GetChessAIController(inputDto.IsSingleplayer));
      m_Felder = Helper.CreateFelder(8, 8);
      
      ConnectEvents();
      InitGameComponents(m_CurrentPlayer);

      if (inputDto.IsSingleplayer && inputDto.PlayerIsPlayingAs == Contracts.Game.Player.BLACK) MakeEnemyMoveAsync();
    }

    public ResultDto ShowGame()
    {
      UpdateScores();
      m_mainForm.ShowDialog();
      return m_ResultDto;
    }

    private void InitGameComponents(Konstanten.Player startingPlayer)
    {
      m_BoardPosition = m_LogicConnector.CreatePiecesFromFen(m_Moves[0]);
      var piecesToDraw = ViewModelCreator.GeneratePieces(m_BoardPosition);
      var felderToDraw = ViewModelCreator.CreateChessBoardDrawModels(m_Felder);
      m_mainForm.InitBoard(felderToDraw, startingPlayer);
      m_mainForm.InitPieces(piecesToDraw);
    }

    private void ConnectEvents()
    {
      m_mainForm.GameObjectClickedAction += GameObjectClicked;
      m_mainForm.OnButtonSettingsClicked += OnButtonSettingsClicked;
    }

    private void ValidiereZug(Dto.UpdatePositionDto moveResult)
    {
      if (!moveResult.WasMoveLegal) return;

      m_CurrentPlayer = Helper.GetEnemy(m_CurrentPlayer);
      m_Moves.Add(m_LogicConnector.CreateFenFromPieces(m_BoardPosition, m_CurrentPlayer));
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
      m_mainForm.SetWaitCursor();
      var postion = await Task.Run(() => m_AiConnector.GetBestMove(m_BoardPosition, m_CurrentPlayer, 4));
      m_mainForm.UpdatePieces(ViewModelCreator.GeneratePieces(postion));
      m_BoardPosition = postion;
      m_CurrentPlayer = Helper.GetEnemy(m_CurrentPlayer);
      UpdateScores();
      HandlePlayerLossOrDoNothing();
      m_mainForm.SetDefaultCursor();
    }

    private void HandlePlayerLossOrDoNothing()
    {
      var gameOverResult = m_LogicConnector.IsGameOver(m_BoardPosition, m_CurrentPlayer);
      
      if (gameOverResult == GameOverResult.NO) return;

      m_ResultDto = ResultDtoFactory.GetResultDto(Helper.GetEnemy(m_CurrentPlayer).ToString(), gameOverResult, DialogResult.OK);
      m_mainForm.Dispose();
      m_mainForm.Close();
    }

    private void UpdateScores()
    {
      var scoreBlack = m_LogicConnector.GetScoring(m_BoardPosition, Konstanten.Player.BLACK);
      var scoreWhite = m_LogicConnector.GetScoring(m_BoardPosition, Konstanten.Player.WHITE);
      m_mainForm.SetScore(scoreWhite, scoreBlack);
    }

    private void SelectPieceToMove(Dto.Coords coords)
    {
      m_SelectedPiece = m_BoardPosition.First(x => x.Coord.Equals(coords));
      m_PossibleFelder = m_LogicConnector.GetPossibleFelderForPiece(m_SelectedPiece, m_BoardPosition);

      if (!Settings.ShowHighlightedFelder) return;
      m_mainForm.RemoveHighlightedFelder();
      m_mainForm.ShowPossibleFelder(m_PossibleFelder, ViewModelCreator.GetBitmapForHighligthFields());
    }

    private Dto.UpdatePositionDto ConvertPawn(Dto.Coords clickedCoords)
    {
      var ctr = new PieceSelectForm.Controller(m_CurrentPlayer);
      var newPiece = ctr.ShowDialog();
      var moveResult = m_LogicConnector.MakeNonCaptureMove(m_BoardPosition, clickedCoords, m_SelectedPiece);
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

      if (result.DialogResult != SettingsForm.DialogResult.OK) return;
      UpdateSettings(result);
    }

    private void UpdateSettings(SettingsForm.ResultDto result)
    {
      if (!result.HighlightFelder) m_mainForm.RemoveHighlightedFelder();
      else m_mainForm.ShowPossibleFelder(m_PossibleFelder, ViewModelCreator.GetBitmapForHighligthFields());
      
      Settings.ShowHighlightedFelder = result.HighlightFelder; 
    }

    private void GameObjectClicked(Dto.Coords coordsClicked)
    {
      Dto.UpdatePositionDto moveResult = null;
      var moveType = m_LogicConnector.GetMoveType(m_PossibleFelder, coordsClicked, m_BoardPosition, m_SelectedPiece, m_CurrentPlayer);

      switch (moveType)
      {
        case Konstanten.MoveType.CASTLE:
          moveResult = m_LogicConnector.MakeCastleMove(m_BoardPosition, coordsClicked, m_SelectedPiece);
          break;
        case Konstanten.MoveType.CAPUTRE:
          var clickedPiece = m_BoardPosition.First(x => x.Coord.Equals(coordsClicked));
          moveResult = m_LogicConnector.MakeCaptureMove(m_BoardPosition, clickedPiece, m_SelectedPiece);
          break;
        case Konstanten.MoveType.FORWARD:
          moveResult = m_LogicConnector.MakeNonCaptureMove(m_BoardPosition, coordsClicked, m_SelectedPiece);
          break;
        case Konstanten.MoveType.PIECE_SELECT:
          if (m_BoardPosition.First(x => x.Coord.Equals(coordsClicked)) == m_SelectedPiece) return;
          SelectPieceToMove(coordsClicked);
          return;
        case Konstanten.MoveType.NONE:
          return;
        case Konstanten.MoveType.CONVERT_PAWN:
          moveResult = ConvertPawn(coordsClicked);
          break;
      }
      ValidiereZug(moveResult);

      if (m_AiConnector.HasAiController()) MakeEnemyMoveAsync();
    }
  }
}
