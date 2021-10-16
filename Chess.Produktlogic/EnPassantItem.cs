using Chess.Produktlogic.Contracts;

namespace Chess.Produktlogic
{
  public class EnPassantItem
  {
    public Coords NewPosition { get; set; } = new(-1, -1);
    public Coords PiceToCapture { get; set; }
  }
}
