using Chess.Produktlogic.Contracts;
using System.Windows.Forms;
using Winforms_Chess.UI_Objects;

namespace Winforms_Chess
{
  public class TileDrawModel : Panel, IUiObject
  {
    public string PicturePath { get; set; }
    public Coords Coord { get; set; }

    public bool HighlightFeld { get; set; }
  }
}
