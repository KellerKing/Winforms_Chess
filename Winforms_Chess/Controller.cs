using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
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
      m_mainForm.ShowForm(ViewModelCreator.CreateChessBoardDrawModels(m_Board.Felder, formWidth, formHeight - topHeight)); 
    }

  }
}
