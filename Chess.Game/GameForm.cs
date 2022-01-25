using Chess.Game;
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
    private TileDrawModel[,] m_ChessBoardPanles;
    private List<PieceDrawModel> m_Pieces;
    private Player m_BottomPlayer;

    internal Action<Point> OnButtonSettingsClicked;
    public Action<Coords> GameObjectClickedAction;

    public GameForm()
    {
      InitializeComponent();
      this.Size = UiHelper.GetFormResolution(Screen.FromControl(this));
    }

    public void InitBoard(TileDrawModel[,] board, Player playerSelected)
    {
      m_ChessBoardPanles = board;
      m_BottomPlayer = playerSelected;
      DrawBoard(m_ChessBoardPanles, playerSelected);
      if (m_BottomPlayer == Player.BLACK) FlipScorePosition();
    }

    public void DrawBoard(TileDrawModel[,] board, Player playerSelected)
    {
      boardGrid.Controls.Clear();

      var sortedTiles = playerSelected == Player.BLACK ?
        board.Cast<TileDrawModel>().ToList().OrderBy(x => x.Coord.Rank).ToList() :
        board.Cast<TileDrawModel>().ToList().OrderByDescending(x => x.Coord.Rank).ToList();

      sortedTiles.ForEach(x =>
      {
        boardGrid.Controls.Add(x);
        x.Click += GameObjectClicked;
        x.BackgroundImage = Image.FromFile(x.PicturePath);
        board[x.Coord.File, x.Coord.Rank] = x;
      });

      m_ChessBoardPanles = board;
    }

    public void InitPieces(List<PieceDrawModel> pieceDrawModels)
    {
      m_Pieces = pieceDrawModels;

      m_ChessBoardPanles.Cast<TileDrawModel>().ToList().ForEach(x => x.Controls.Clear());
      m_Pieces.ForEach(x =>
      {
        m_ChessBoardPanles[x.Coord.File, x.Coord.Rank].Controls.Add(x);
        x.Click += GameObjectClicked;
      });
    }

    public void UpdatePieces(List<PieceDrawModel> pieceDrawModels)
    {
      var piecesToRemoveFromBoard = m_Pieces.Where(x => !pieceDrawModels.Any(y => y.Coord.Equals(x.Coord))).ToList();
      var piecesToRedraw = pieceDrawModels.Where(x => !m_Pieces.Any(y => y.Coord.Equals(x.Coord) && y.Piece.Owner == x.Piece.Owner && y.Piece.PiceType == x.Piece.PiceType)).ToList();

      piecesToRemoveFromBoard.ForEach(x => m_ChessBoardPanles[x.Coord.File, x.Coord.Rank].Controls.Clear());
      piecesToRedraw.ForEach(x =>
      {
        m_ChessBoardPanles[x.Coord.File, x.Coord.Rank].Controls.Clear();
        m_ChessBoardPanles[x.Coord.File, x.Coord.Rank].Controls.Add(x);
        x.Click += GameObjectClicked;
      });

      m_Pieces = pieceDrawModels;
    }

    public void SetScore(int white, int black)
    {
      if (white == black)
      {
        lblPointsBlack.Text = "";
        lblPointsWhite.Text = "";
      }
      else if (black < white)
      {
        lblPointsBlack.Text = "";
        lblPointsWhite.Text = white.ToString();
      }
      else
      {
        lblPointsBlack.Text = black.ToString();
        lblPointsWhite.Text = "";
      }
    }

    private void FlipScorePosition()
    {
      var coordsBlack = lblPointsBlack.Location;
      lblPointsBlack.Location = lblPointsWhite.Location;
      lblPointsWhite.Location = coordsBlack;
    }

    private void GameObjectClicked(object sender, EventArgs e)
    {
      GameObjectClickedAction.Invoke(((IUiObject)sender).Coord);
    }

    public void RemoveHighlightedFelder()
    {
      var row = m_ChessBoardPanles.GetLength(0);
      var col = m_ChessBoardPanles.GetLength(1);

      for (int i = 0; i < row * col; i++)
      {
        var panel = m_ChessBoardPanles[i / col, i % col];

        if (panel.HighlightFeld)
        {
          panel.HighlightFeld = false;
          panel.BackgroundImage.Dispose();
          panel.BackgroundImage = Image.FromFile(panel.PicturePath);
        }
      }
    }

    internal void ShowPossibleFelder(IEnumerable<Coords> felderPossible)
    {
      foreach (var item in felderPossible)
      {
        var panel = m_ChessBoardPanles[item.File, item.Rank];
        if (panel.HighlightFeld) continue;
        UiHelper.HighlightPanel(panel);
      }
    }


    private void ButtonFlipBoard_Click(object sender, EventArgs e)
    {
      m_BottomPlayer = Helper.GetEnemy(m_BottomPlayer);
      DrawBoard(m_ChessBoardPanles, m_BottomPlayer);
      FlipScorePosition();
    }

    private void GameForm_ResizeBegin(object sender, EventArgs e)
    {
      boardGrid.Visible = false;
      //var row = m_ChessBoardPanles.GetLength(0);
      //var col = m_ChessBoardPanles.GetLength(1);

      //for (int i = 0; i < row * col; i++)
      //{
      //  UiHelper.SetVisibleForPanel(m_ChessBoardPanles[i / col, i % col], false);
      //}
    }
    private void GameForm_ResizeEnd(object sender, EventArgs e)
    {
      boardGrid.Visible = true;
      //var row = m_ChessBoardPanles.GetLength(0);
      //var col = m_ChessBoardPanles.GetLength(1);

      //for (int i = 0; i < row * col; i++)
      //{
      //  UiHelper.SetVisibleForPanel(m_ChessBoardPanles[i / col, i % col], true);
      //}

    }

    private void ButtonSettingsClicked(object sender, EventArgs e)
    {
      var locationSender = PointToScreen(new Point(buttonSettings.Left + buttonSettings.Width, buttonSettings.Top + buttonSettings.Height));

      OnButtonSettingsClicked?.Invoke(locationSender);
    }
  }
}
