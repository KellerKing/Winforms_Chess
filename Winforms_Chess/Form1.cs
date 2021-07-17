using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
  public partial class Form1 : Form
  {

    private GameObjectDrawModel[,] m_ChessBoardPanles;

    public Form1(GameObjectDrawModel[,] board)
    {
      InitializeComponent();
      DrawBoard(board);
    }


    public void DrawBoard(GameObjectDrawModel[,] board)
    {
      GC.Collect();
      m_ChessBoardPanles = board;
      m_ChessBoardPanles.Cast<GameObjectDrawModel>().ToList().ForEach(x =>
      {
        Controls.Add(x);
        x.Paint += (sender, e) => e.Graphics.DrawImage(Image.FromFile(((GameObjectDrawModel)sender).PicturePath), new Point(0, 0));
      });
    }
  }
}
