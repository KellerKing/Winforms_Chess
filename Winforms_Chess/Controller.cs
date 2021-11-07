using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;
using Winforms_Chess.Contracts;

namespace Winforms_Chess
{
  public class Controller
  {
    private readonly GameForm m_mainForm;
    private Board m_Board = Board.GetInstance();
    private Player m_CurrentPlayer = Player.WHITE;
    private Piece m_SelectedPice;
    private List<Coords> m_PossibleFelder = new List<Coords>();
    private readonly IChessLogicController m_LogicController;

    public Controller(InputDto inputDto)
    {
      m_mainForm = new GameForm();
      m_LogicController = new Chess.Produktlogic.Controller();
      ConnectEvents();
    }

    public ResultDto ShowGame()
    {
      InitGameComponents();
      m_mainForm.ShowDialog();
      return new ResultDto();
    }

    private void InitGameComponents()
    {
      var picesToDraw = ViewModelCreator.GeneratePices(m_Board.CreatePosition(m_Board.Moves.First()));
      var felderToDraw = ViewModelCreator.CreateChessBoardDrawModels(m_Board.Felder);
      m_mainForm.InitBoard(felderToDraw);
      m_mainForm.DrawPices(picesToDraw);
    }

    private void ConnectEvents()
    {
      m_mainForm.GameObjectClickedAction += GameObjectClicked;
    }

    private void ValidiereZug(UpdatePositionDto moveResult)
    {
      if (!moveResult.WasMoveLegal) return;

      m_CurrentPlayer = m_CurrentPlayer == Player.WHITE ? Player.BLACK : Player.WHITE;
      m_PossibleFelder = moveResult.PossibleFelder;
      m_Board.Pices = moveResult.BoardPosition;
      m_mainForm.UpdatePices(ViewModelCreator.GeneratePices(moveResult.BoardPosition));
      UpdateScores();
      HandlePlayerLoss();
    }

    private void HandlePlayerLoss()
    {
      if (m_LogicController.IsGameOver(m_Board.Pices, m_CurrentPlayer))
      {
       
      }
    }

    private void UpdateScores()
    {
      var scoreBlack = m_LogicController.GetScoring(m_Board.Pices, Player.BLACK);
      var scoreWhite = m_LogicController.GetScoring(m_Board.Pices, Player.WHITE);
      m_mainForm.SetScore(scoreWhite, scoreBlack);
    }

    private void SelectPieceToMove(Coords coords)
    {
      m_SelectedPice = m_Board.Pices.First(x => x.Coord.Equals(coords));
      m_PossibleFelder = m_LogicController.GetPossibleFelderForPice(m_SelectedPice, m_Board.Pices);
    }

    private void GameObjectClicked(Coords coords, bool isPice)
    {
      UpdatePositionDto moveResult = null;

      switch (m_LogicController.GetMoveType(isPice, m_PossibleFelder, coords, m_Board.Pices, m_SelectedPice, m_CurrentPlayer))
      {
        case MoveType.CASTLE:
          moveResult = m_LogicController.MakeCastleMove(m_Board.Pices, coords, m_SelectedPice);
          break;
        case MoveType.CAPUTRE:
          var clickedPice = m_Board.Pices.First(x => x.Coord.Equals(coords));
          moveResult = m_LogicController.MakeCaptureMove(m_Board.Pices, clickedPice, m_SelectedPice);
          break;
        case MoveType.FORWARD:
          moveResult = m_LogicController.MakeNonCaptureMove(m_Board.Pices, coords, m_SelectedPice);
          break;
        case MoveType.PIECE_SELECT:
          SelectPieceToMove(coords);
          return;
        case MoveType.NONE:
          return;
      }
      ValidiereZug(moveResult);
    }
  }
}
