using Chess.Produktlogic.Contracts;

namespace Winforms_Chess.Contracts
{
  public class InputDto
  {
    public bool Singleplayer { get; set; }
    public Player PlayerSelected { get; set; }
  }
}
