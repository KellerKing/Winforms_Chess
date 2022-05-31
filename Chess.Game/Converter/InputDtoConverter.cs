using Chess.Contracts.Game;
using Chess.Game.Converter.Interface;

namespace Chess.Game.Converter
{
  internal class InputDtoConverter : IInputDtoConverter
  {
    public Konstanten.Player GetStartingPlayer(InputDto inputDto)
    {
      if (!inputDto.IsSingleplayer) return Konstanten.Player.WHITE;

      return inputDto.PlayerIsPlayingAs switch
      {
        Player.BLACK => Konstanten.Player.BLACK,
        Player.WHITE => Konstanten.Player.WHITE,
      };
    }
  }
}
