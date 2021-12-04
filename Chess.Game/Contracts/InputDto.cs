using Chess.Produktlogic.Contracts;

namespace Chess.Game.Contracts
{
  public class InputDto
  {
    public bool Singleplayer { get; set; }
    public Player PlayerSelected { get; set; }
  }
}
