using Chess.Contracts.Menue;

namespace Chess.Menue
{
  internal static class ResultDtoFactory
  {
    public static ResultDto CreateResultDto(DialogResult dialogResult, bool isSingleplayer, bool isWhiteSide)
    {
      return new ResultDto
      {
        IsPlayerWhite = isWhiteSide,
        IsSingleplayer = isSingleplayer,
        DialogResult = dialogResult
      };
    }
  }
}
