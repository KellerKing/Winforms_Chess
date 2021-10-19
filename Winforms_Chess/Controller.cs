using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Winforms_Chess
{
  public class Controller
  {
    private readonly GameForm m_mainForm;
    private Board m_Board = Board.GetInstance();
    private Player m_CurrentPlayer = Player.WHITE;
    private Pice m_SelectedPice;
    private List<Coords> m_PossibleFelder = new List<Coords>();
    private IChessLogicController m_LogicController;

    private const int formWidth = 1000;
    private const int formHeight = 1000;

    public Controller()
    {
      m_mainForm = new GameForm(formWidth, formHeight);
      m_LogicController = new Chess.Produktlogic.Controller();
      ConnectEvents();
      InitGameComponents();

      m_mainForm.ShowForm();

    }

    private void InitGameComponents()
    {
      var topHeight = m_mainForm.GetTopBarHeight();
      var picesToDraw = ViewModelCreator.GeneratePices(m_Board.CreatePosition(m_Board.Moves.First()));
      var felderToDraw = ViewModelCreator.CreateChessBoardDrawModels(m_Board.Felder, formWidth, formHeight - topHeight);
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
      m_mainForm.DrawPices(ViewModelCreator.GeneratePices(moveResult.BoardPosition));
    }

    public void GameObjectClicked(Coords coords, bool isPice)
    {
      //Castle
      if(isPice && m_SelectedPice?.PiceType == PiceType.KING && m_Board.Pices.FirstOrDefault(x => x.Owner == m_CurrentPlayer && x.Coord.Equals(coords))?.PiceType == PiceType.ROOK)
      {
        var moveResult = m_LogicController.MakeCastleMove(m_Board.Pices, coords, m_SelectedPice);
        ValidiereZug(moveResult);
        return;
      }

      //Wenn ich meine Figur anklicke um die möglichen Felder zu laden
      if (isPice && m_Board.Pices.Any(x => x.Owner == m_CurrentPlayer && x.Coord.Equals(coords)))
      {
        m_SelectedPice = m_Board.Pices.First(x => x.Coord.Equals(coords));
        m_PossibleFelder = m_LogicController.GetPossibleFelderForPice(m_SelectedPice, m_Board.Pices);
        return;
      }

      //Wenn ich meine Figur gewählt habe, und jetzt auf mein Zielfeld klicke
      if(!isPice && m_SelectedPice != null && m_PossibleFelder.Contains(coords))
      {
        var moveResult = m_LogicController.MakeNonCaptureMove(m_Board.Pices, coords, m_SelectedPice);
        ValidiereZug(moveResult);
        return;
      }

      //Wenn ich meine Figur gewählt habe, und jetzt auf einen Gegner Klicke
      if (isPice && m_SelectedPice != null && m_PossibleFelder.Contains(coords))
      {
        var clickedPice = m_Board.Pices.First(x => x.Coord.Equals(coords));
        var moveResult = m_LogicController.MakeCaptureMove(m_Board.Pices, clickedPice, m_SelectedPice);
        ValidiereZug(moveResult);
      }
    }
  }
}
