using System.Collections.Generic;
using System.Linq;

namespace Winforms_Chess
{
  public class Controller
  {
    private readonly Form1 m_mainForm;
    private Board m_Board = Board.GetInstance();
    private Player m_CurrentPlayer = Player.WHITE;
    private Pice m_SelectedPice;
    private List<Coords> m_PossibleFelder = new List<Coords>();

    private const int formWidth = 1000;
    private const int formHeight = 1000;

    public Controller()
    {
      m_mainForm = new Form1(formWidth, formHeight);
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

    public void GameObjectClicked(Coords coords, bool isPice)
    {

      var moveResultDTO = MoveController.MakeMove(isPice, new List<Pice>(m_Board.Pices), coords, m_CurrentPlayer, new List<Coords>(m_PossibleFelder), m_SelectedPice == null ? null : (Pice)m_SelectedPice.Clone());

      if (!moveResultDTO.WasMoveLegal) return;

      if (moveResultDTO.WasFullMove)
      {
        m_mainForm.DrawPices(ViewModelCreator.GeneratePices(moveResultDTO.BoardPosition));
        m_CurrentPlayer = m_CurrentPlayer == Player.WHITE ? Player.BLACK : Player.WHITE;
      }
        
       
      m_SelectedPice = moveResultDTO.SelectedPice;
      m_PossibleFelder = moveResultDTO.PossibleFelder;
      m_Board.Pices = moveResultDTO.BoardPosition;

      



      //if (isPice)
      //{
      //  var clickedPice = (Pice)m_Board.Pices.First(x => x.Coord.Equals(coords)).Clone();

      //  if (clickedPice.Owner == m_CurrentPlayer)
      //  {
      //    UpdatePossibleFelderAndSelectedPice(clickedPice);
      //    return;
      //  }
      //  else if (m_PossibleFelder.Any(x => x.Equals(m_SelectedPice.Coord)))
      //  {
      //    //Das Definitiv auslagern : Ist ein Spielzug: Spieler wird geschlagen
      //    m_SelectedPice.Coord = clickedPice.Coord;
      //    m_Board.Pices.Remove(clickedPice);
      //  }
      //}
      //else if (m_SelectedPice != null && m_PossibleFelder.Any(x => x.Equals(coords)))
      //{
      //  //Ist ein Spielzug: Vorher wurde eine Figur gewählt und dann ein Feld
      //  m_SelectedPice.Coord = coords;
      //  m_SelectedPice = null;
      //}
    }
  }

}
