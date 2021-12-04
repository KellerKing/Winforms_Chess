using System.Windows.Forms;

namespace Chess.Game.Contracts
{
  public class ResultDto
  {
    public string Winner { get; set; }
    public bool IsPatt { get; set; }
    public DialogResult DialogResult { get; set; }
  }
}
