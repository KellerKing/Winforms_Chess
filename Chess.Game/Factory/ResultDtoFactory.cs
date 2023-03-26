using Chess.Contracts.Game;

namespace Chess.Game.Factory
{
  public class ResultDtoFactory
  {
    public static ResultDto GetResultDto(string winner, Konstanten.GameOverResult gameOverResult, DialogResult dialogResult = DialogResult.Cancel)
    {
      return new ResultDto
      {
        Winner = winner,
        DialogResult = dialogResult,
        IsPatt = gameOverResult == Konstanten.GameOverResult.STATLEMENT
      };
    }
  }
}
