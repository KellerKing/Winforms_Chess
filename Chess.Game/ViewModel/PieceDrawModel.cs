using System.Windows.Forms;

namespace Chess.Game.ViewModel
{
  internal class PieceDrawModel : PictureBox
  {
    public Dto.Coords Coord { get; set; }
    public Dto.Piece Piece { get; init; }
  }
}
