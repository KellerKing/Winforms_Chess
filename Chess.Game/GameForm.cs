using Chess.Game.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Chess.Game
{
  internal partial class GameForm : Form
  {
    private TileDrawModel[,] m_ChessBoardPanles;
    private List<PieceDrawModel> m_Pieces;
    private Konstanten.Player m_BottomPlayer;

    internal Action<Point> OnButtonSettingsClicked;
    internal Action<Dto.Coords> GameObjectClickedAction;

    internal GameForm()
    {
      InitializeComponent();
      this.Size = UiHelper.GetFormResolution(Screen.FromControl(this));
    }

    internal void InitBoard(TileDrawModel[,] board, Konstanten.Player playerSelected)
    {
      m_ChessBoardPanles = board;
      m_BottomPlayer = playerSelected;
      DrawBoard(m_ChessBoardPanles, playerSelected);
      if (m_BottomPlayer == Konstanten.Player.BLACK) FlipScorePosition();
    }

    internal void DrawBoard(TileDrawModel[,] board, Konstanten.Player playerSelected)
    {
      boardGrid.Controls.Clear();

      var sortedTiles = playerSelected == Konstanten.Player.BLACK ?
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

    internal void InitPieces(List<PieceDrawModel> pieceDrawModels)
    {
      m_Pieces = pieceDrawModels;

      m_ChessBoardPanles.Cast<TileDrawModel>().ToList().ForEach(x => x.Controls.Clear());
      m_Pieces.ForEach(x =>
      {
        m_ChessBoardPanles[x.Coord.File, x.Coord.Rank].Controls.Add(x);
        x.Click += GameObjectClicked;
      });
    }

    internal void UpdatePieces(List<PieceDrawModel> pieceDrawModels)
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

    internal void SetDefaultCursor()
    {
      Cursor = Cursors.Default;
    }

    internal void SetWaitCursor()
    {
      Cursor = Cursors.WaitCursor;
    }

    private void FlipScorePosition()
    {
      var coordsBlack = lblPointsBlack.Location;
      lblPointsBlack.Location = lblPointsWhite.Location;
      lblPointsWhite.Location = coordsBlack;
    }

    private void GameObjectClicked(object sender, EventArgs e)
    {
      if (sender is PieceDrawModel pieceDrawModel)
        GameObjectClickedAction.Invoke(pieceDrawModel.Coord);

      else if (sender is TileDrawModel tileDrawModel)
        GameObjectClickedAction.Invoke(tileDrawModel.Coord);
    }

    internal void RemoveHighlightedFelder()
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

    internal void ShowPossibleFelder(IEnumerable<Dto.Coords> felderPossible)
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
