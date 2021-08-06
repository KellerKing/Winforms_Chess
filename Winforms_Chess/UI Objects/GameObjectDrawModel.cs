using System.Windows.Forms;
using Winforms_Chess.UI_Objects;

namespace Winforms_Chess
{
  public class GameObjectDrawModel : Panel, IUiObject
  {
    public string PicturePath { get; set; }
    public Coords Coord { get; set; }
  }
}
