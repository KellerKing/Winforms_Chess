using Chess.Game.Contracts;
using Chess.Produktlogic.Contracts;
using System.Windows.Forms;

namespace Chess.Game.Factory
{
  public class ResultDtoFactory
  {
    public static ResultDto GetResultDto(string winner, GameOver gameOverResult, DialogResult dialogResult = DialogResult.Cancel)
    {
      return new ResultDto
      {
        Winner = winner,
        DialogResult = dialogResult,
        IsPatt = gameOverResult == GameOver.STATLEMENT
      };
    }
  }
}
