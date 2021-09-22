namespace Winforms_Chess.DTOs
{
  public class EnPassantItem
  {
    public Coords NewPosition { get; set; } = new(-1, -1);
    public Coords PiceToCapture { get; set; }
  }
}
