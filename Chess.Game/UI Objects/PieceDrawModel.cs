using Chess.Produktlogic.Contracts;
using System.Windows.Forms;
using Winforms_Chess.UI_Objects;

namespace Winforms_Chess
{
  public class PieceDrawModel : PictureBox , IUiObject
  {
    public Coords Coord { get; set; }
    public Piece Piece { get; init; }
  }
}
