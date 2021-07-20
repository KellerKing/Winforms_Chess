using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
  public class Controller
  {
    private Form1 m_mainForm;
    private Board m_Board = Board.GetInstance();

    private Pice selectedPice;

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
      m_mainForm.PiceClicked += PiceClicked;
    }

    public void PiceClicked(Coords? coords)
    {
      selectedPice = m_Board.Pices.First(x => x.Coord.Equals(coords));

    }

  }
}
