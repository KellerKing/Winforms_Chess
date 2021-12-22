using Chess.Game;
using Chess.Game.Properties;
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
    public Action<Coords> GameObjectClickedAction;

    public GameForm()
    {
      InitializeComponent();
      SetFormResolution();
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

    private void SetFormResolution()
    {
      var screenSize = Screen.FromControl(this);
      var newFormSize = Math.Min(screenSize.Bounds.Width, screenSize.Bounds.Height) * 0.65;
      this.Size = new((int)newFormSize, (int)newFormSize);
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
        HighlightPanel(panel);
      }
    }

    private void HighlightPanel(TileDrawModel panel)
    {
      panel.HighlightFeld = true;
      var img = panel.BackgroundImage;
      var result = new Bitmap(img.Width, img.Height);
      var sizeHighlight = panel.Width / 1.5f;

      using (var g = Graphics.FromImage(result))
      {
        g.DrawImage(img, Point.Empty);
        g.DrawImage(Resources.field_possible, (img.Width/2) - (sizeHighlight/2), (img.Height/2) - (sizeHighlight / 2), sizeHighlight, sizeHighlight);
        panel.BackgroundImage = result;
      }
      img.Dispose();
    }

    private void ButtonFlipBoard_Click(object sender, EventArgs e)
    {
      m_BottomPlayer = Helper.GetEnemy(m_BottomPlayer);
      DrawBoard(m_ChessBoardPanles, m_BottomPlayer);
      FlipScorePosition();
    }
  }
}
