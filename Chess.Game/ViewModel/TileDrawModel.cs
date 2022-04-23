using System.Windows.Forms;

namespace Chess.Game.ViewModel
{
  public class TileDrawModel : Panel
  {
    public string PicturePath { get; set; }
    public Dto.Coords Coord { get; set; }
    public bool HighlightFeld { get; set; }
  }
}
