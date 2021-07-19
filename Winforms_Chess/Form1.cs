using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winforms_Chess.Properties;

namespace Winforms_Chess
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

    public void ShowForm()
    {
      ShowDialog();
    }

    public void InitBoard(GameObjectDrawModel[,] board)
    {
      m_ChessBoardPanles = board;
      DrawBoard(m_ChessBoardPanles);
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
        x.BackgroundImage = Image.FromFile(x.PicturePath);
        //x.Paint += (sender, e) => e.Graphics.DrawImage(Image.FromFile(((GameObjectDrawModel)sender).PicturePath), 0,0);
      });
    }

    public void DrawPices(List<PiceDrawModel> piceDrawModels)
    {

      piceDrawModels.ForEach(x => m_ChessBoardPanles[x.Coords.Value.File, x.Coords.Value.Rank].Controls.Add(x));

      //var x = m_ChessBoardPanles[0, 1];
      //var p = new PictureBox();
      //p.BackColor = Color.Transparent;
      //var img = Resources.chess_piece_2_black_bishop;
      //img.MakeTransparent();
      //p.Size = x.Size;
      //p.Image = img;
      //p.SizeMode = PictureBoxSizeMode.Zoom;
      //x.Controls.Add(p);
      //p.Click += (sender, e) => MessageBox.Show("Test");
    }

  }
}
