namespace Chess.Contracts.Productlogic
{
  public class Piece
  {
    public Piece(Player player)
    {
      Owner = player;
    }

    public Player Owner { get; init; }
    public PieceType PiceType { get; set; }
    public Coords Coord { get; set; }
    public int MoveCounter { get; set; }

    public object Clone()
    {
      return MemberwiseClone();
    }
  }
}
