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

    public Form1(int w, int h)
    {
      this.Width = w;
      this.Height = h;
      InitializeComponent();
    }

    public void ShowForm(GameObjectDrawModel[,] board)
    {
      m_ChessBoardPanles = board;
      DrawBoard(m_ChessBoardPanles);
      ShowDialog();
    }


    public int GetTopBarHeight()
    {
      return this.RectangleToScreen(this.ClientRectangle).Top - this.Top;
    }

    public void DrawBoard(GameObjectDrawModel[,] board)
    {
      GC.Collect();
      m_ChessBoardPanles.Cast<GameObjectDrawModel>().ToList().ForEach(x =>
      {
        Controls.Add(x);
        x.Paint += (sender, e) => e.Graphics.DrawImage(Image.FromFile(((GameObjectDrawModel)sender).PicturePath), new Point(0, 0));
      });
    }
  }
}
