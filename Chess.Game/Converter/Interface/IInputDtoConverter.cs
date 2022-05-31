using Chess.Contracts.Game;

namespace Chess.Game.Converter.Interface
{
  internal interface IInputDtoConverter
  {
    Konstanten.Player GetStartingPlayer(InputDto inputDto);
  }
}
