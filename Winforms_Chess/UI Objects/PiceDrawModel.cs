using Chess.Produktlogic.Contracts;
using System.Windows.Forms;
using Winforms_Chess.UI_Objects;

namespace Winforms_Chess
{
  public class PiceDrawModel : PictureBox , IUiObject
  {
    public Coords Coord { get; set; }
  }
}
