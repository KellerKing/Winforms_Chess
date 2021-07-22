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
      m_mainForm.TileClicked += TileClicked;
    }

    public void PiceClicked(Coords? coords)
    {
      selectedPice = m_Board.Pices.First(x => x.Coord.Equals(coords));

    }

    public void TileClicked(Coords coords)
    {
      if (selectedPice == null) return;

      //var p = m_Board.Felder.Cast<Tile>().ToList().Where(x => x.Coords.Equals(coords)).First();
      var old = m_Board.Pices.Find(x => x.Coord.Equals(coords));
      selectedPice.Coord = coords;

      if (old != null)
      {
        m_Board.Pices.Remove(old);
      }
      m_mainForm.DrawPices(ViewModelCreator.GeneratePices(m_Board.Pices));


      Debug.Print($"rank:{coords.Rank} | file:{coords.File}");
    }

  }
}
