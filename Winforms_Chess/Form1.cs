using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Winforms_Chess
{
  public partial class Form1 : Form
  {

    private GameObjectDrawModel[,] m_ChessBoardPanles;
    private List<PiceDrawModel> m_Pices;


    public Action<Coords?> PiceClicked;
    public Action<Coords> TileClicked;

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
        x.Click += Tile_Clicked;
        x.BackgroundImage = Image.FromFile(x.PicturePath);
        //x.Paint += (sender, e) => e.Graphics.DrawImage(Image.FromFile(((GameObjectDrawModel)sender).PicturePath), 0,0);
      });
    }

    private void Tile_Clicked(object sender, EventArgs e)
    {
      TileClicked.Invoke(((GameObjectDrawModel)sender).Coords);
    }

    public void DrawPices(List<PiceDrawModel> piceDrawModels)
    {
      m_Pices = piceDrawModels;
      m_ChessBoardPanles.Cast<GameObjectDrawModel>().ToList().ForEach(x => x.Controls.Clear());
      m_Pices.ForEach(x =>
      {
         m_ChessBoardPanles[x.Coords.Value.File, x.Coords.Value.Rank].Controls.Add(x);
        x.Click += Pice_Clicked;
      });
    }

    private void Pice_Clicked(object sender, EventArgs e)
    {
      var pice = sender as PiceDrawModel;
      PiceClicked.Invoke(pice.Coords);
    }
  }
}
