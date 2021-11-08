using System.Windows.Forms;
using Winforms_Chess.Contracts;

namespace Winforms_Chess
{
  public class ResultDtoFactory
  {
    public static ResultDto GetResultDto(string winner, DialogResult dialogResult = DialogResult.Cancel)
    {
      return new ResultDto
      {
        Winner = winner,
        DialogResult = dialogResult
      };
    }
  }
}
