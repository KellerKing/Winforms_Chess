using System.Windows.Forms;

namespace Chess.Contracts.Menue
{
  public class ResultDto
  {
    public bool IsSingleplayer { get; set; }
    public bool IsPlayerStartingWhite { get; set; }
    public DialogResult DialogResult { get; set; }
  }
}
