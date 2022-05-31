using Chess.Contracts.Game;
using Chess.WindowsApplication.Dto;

namespace Chess.WindowsApplication.Factory
{
  public class GameInputDtoCreator : IGameInputDtoCreator
  {
    public InputDto CreateInputDto(MenueResultDto menueResultDto)
    {
      return new InputDto
      {
        IsSingleplayer = menueResultDto.IsSingleplayer,
        PlayerIsPlayingAs = GetStartingPlayer(menueResultDto),
      };
    }

    private Player GetStartingPlayer(MenueResultDto menueResultDto)
    {
      if (!menueResultDto.IsSingleplayer)
        return Player.WHITE;

      return menueResultDto.IsPlayerStartingWhite ? Player.WHITE : Player.BLACK;
    }
  }
}
