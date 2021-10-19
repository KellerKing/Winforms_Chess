using Chess.Produktlogic.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Winforms_Chess.UI_Objects;

namespace Winforms_Chess
{
  public partial class GameForm : Form
  {

    private GameObjectDrawModel[,] m_ChessBoardPanles;
    private List<PiceDrawModel> m_Pices;

    public Action<Coords, bool> GameObjectClickedAction;

    public GameForm(int w, int h)
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
      board.Cast<GameObjectDrawModel>().ToList().OrderByDescending(x => x.Coord.Rank).ToList().ForEach(x =>
      {
        tableLayoutPanel1.Controls.Add(x);
        x.Click += GameObjectClicked;
        x.BackgroundImage = Image.FromFile(x.PicturePath);
      });
    }

    public void DrawPices(List<PiceDrawModel> piceDrawModels)
    {
      m_Pices = piceDrawModels;
      m_ChessBoardPanles.Cast<GameObjectDrawModel>().ToList().ForEach(x => x.Controls.Clear());
      m_Pices.ForEach(x =>
      {
        m_ChessBoardPanles[x.Coord.File, x.Coord.Rank].Controls.Add(x);
        x.Click += GameObjectClicked;
      });
    }

    private void GameObjectClicked(object sender, EventArgs e)
    {
      var clickedObject = sender as IUiObject;
      GameObjectClickedAction.Invoke(clickedObject.Coord, sender is PiceDrawModel ? true : false);
    }
  }
}
