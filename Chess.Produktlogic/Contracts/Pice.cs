namespace Chess.Produktlogic.Contracts
{
  public class Pice
  {
    public Pice(Player player)
    {
      Owner = player;
    }

    public Player Owner { get; init; }
    public PiceType PiceType { get; init; }
    public Coords Coord { get; set; }
    public int MoveCounter { get; set; }

    public object Clone()
    {
      return MemberwiseClone();
    }
  }
}
