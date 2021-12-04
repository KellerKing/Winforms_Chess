using Chess.Produktlogic.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess.Game.PieceSelectForm
{
  public partial class PieceSelectForm : Form
  {

    private Dictionary<PictureBox, PiceType> m_PieceTypes;


    public Action<PiceType> PictureBoxClicked;

    public PieceSelectForm()
    {
      InitializeComponent();

      m_PieceTypes = new Dictionary<PictureBox, PiceType>
      {
        { pictureBoxBishop,PiceType.BISHOP },
        { pictureBoxKnight,PiceType.KNIGHT },
        { pictureBoxQueen,PiceType.QUEEN },
        { pictureBoxRook,PiceType.ROOK }
      };
    }


    public void DrawTargetPieces(Image piceDrawModelBishop, Image piceDrawModelKnight, Image piceDrawModelQueen, Image piceDrawModelRook)
    {
      pictureBoxBishop.Image = piceDrawModelBishop;
      pictureBoxKnight.Image = piceDrawModelKnight;
      pictureBoxQueen.Image = piceDrawModelQueen;
      pictureBoxRook.Image = piceDrawModelRook;
    }

    private void pictureBox_Click(object sender, EventArgs e)
    {
      var clickedBox = sender as PictureBox;

      PictureBoxClicked.Invoke(m_PieceTypes[clickedBox]);
    }
  }
}
