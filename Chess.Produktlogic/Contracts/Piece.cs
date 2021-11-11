namespace Chess.Produktlogic.Contracts
{
  public class Piece
  {
    public Piece(Player player)
    {
      Owner = player;
    }

    public Player Owner { get; init; }
    public PiceType PiceType { get; set; }
    public Coords Coord { get; set; }
    public int MoveCounter { get; set; }

    public object Clone()
    {
      return MemberwiseClone();
    }
  }
}
