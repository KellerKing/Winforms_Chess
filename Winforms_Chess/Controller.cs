using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
  public class Controller
  {
    private Form1 m_mainForm;
    private Board m_Board = Board.GetInstance();

    private const int formWidth = 1000;
    private const int formHeight = 1000;

    public Controller()
    {
      m_mainForm = new Form1(formWidth, formHeight);
      var topHeight = m_mainForm.GetTopBarHeight();

      var picesToDraw =  ViewModelCreator.GeneratePices(m_Board.CreatePosition(m_Board.Moves.First()));
      var felderToDraw = ViewModelCreator.CreateChessBoardDrawModels(m_Board.Felder, formWidth, formHeight - topHeight);

      m_mainForm.InitBoard(felderToDraw);
      m_mainForm.DrawPices(picesToDraw);

      m_mainForm.ShowForm();
      
    }

  }
}
