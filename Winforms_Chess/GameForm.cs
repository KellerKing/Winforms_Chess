using Chess.Produktlogic.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winforms_Chess.UI_Objects;

namespace Winforms_Chess
{
  public partial class GameForm : Form
  {

    private GameObjectDrawModel[,] m_ChessBoardPanles;
    private List<PiceDrawModel> m_Pices;

    public Action<Coords, bool> GameObjectClickedAction;

    public GameForm()
    {
      InitializeComponent();
      SetStartSize();
    }

    public void ShowMeldung(string meldung)
    {
      MessageBox.Show(meldung);
    }

    public void InitBoard(GameObjectDrawModel[,] board)
    {
      m_ChessBoardPanles = board;
      DrawBoard(m_ChessBoardPanles);
    }

    public void DrawBoard(GameObjectDrawModel[,] board)
    {
      board.Cast<GameObjectDrawModel>().ToList().OrderByDescending(x => x.Coord.Rank).ToList().ForEach(x =>
      {
        boradGrid.Controls.Add(x);
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

    public void UpdatePices(List<PiceDrawModel> piceDrawModels)
    {
      ////DrawPices(piceDrawModels);
      ////return;
      var picesToRemoveFromBoard = m_Pices.Where(x => !piceDrawModels.Any(y => y.Coord.Equals(x.Coord))).ToList();
      var picesToRedraw = piceDrawModels.Where(x => !m_Pices.Any(y => y.Coord.Equals(x.Coord))).ToList();

      if (picesToRedraw.Count == 0)
      {
        DrawPices(piceDrawModels);
        return;
      }

      picesToRemoveFromBoard.ForEach(x => m_ChessBoardPanles[x.Coord.File, x.Coord.Rank].Controls.Clear());
      picesToRedraw.ForEach(x =>
      {
        m_ChessBoardPanles[x.Coord.File, x.Coord.Rank].Controls.Clear();
        m_ChessBoardPanles[x.Coord.File, x.Coord.Rank].Controls.Add(x);
        x.Click += GameObjectClicked;
      });

      m_Pices = piceDrawModels;
    }

    public void SetScore(int white, int black)
    {
      if(white == black)
      {
        lblPointsBlack.Text = "";
        lblPointsWhite.Text = "";
      }
      else if(black < white)
      {
        lblPointsBlack.Text = "";
        lblPointsWhite.Text = white.ToString();
      }
      else
      {
        lblPointsBlack.Text = black.ToString();
      }
    }

    private void SetStartSize()
    {
      var screenSize = Screen.FromControl(this);
      var newFormSize = Math.Min(screenSize.Bounds.Width, screenSize.Bounds.Height) * 0.5;
      this.Size = new((int)newFormSize, (int)newFormSize);
    }

    private void GameObjectClicked(object sender, EventArgs e)
    {
      var clickedObject = sender as IUiObject;
      GameObjectClickedAction.Invoke(clickedObject.Coord, sender is PiceDrawModel ? true : false);
    }
  }
}
