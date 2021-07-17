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

    public Controller()
    {
      m_mainForm = new Form1(ViewModelCreator.CreateChessBoardDrawModels(m_Board.Felder));
    }

    public void ShowDialog()
    {
      m_mainForm.ShowDialog();
    }





  }
}
