using System.Windows.Forms;

namespace Winforms_Chess.Contracts
{
  public class ResultDto
  {
    public string Winner { get; set; }
    public bool IsPatt { get; set; }
    public DialogResult DialogResult { get; set; }
  }
}
