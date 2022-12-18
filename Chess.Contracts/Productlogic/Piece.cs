namespace Chess.Contracts.Productlogic
{
  public class Piece
  {
    public Piece(Player player)
    {
      Owner = player;
    }

    public Player Owner { get; init; }
    public PieceType PieceType { get; set; }
    public Coords Coord { get; set; }
    public int MoveCounter { get; set; }
    public bool IsLastMovedPieceFromPlayer { get; set; }
    public bool HasCastleKingSideRight { get; set; }
    public bool HasCastleQueenSideRight { get; set; }

    public object Clone()
    {
      return MemberwiseClone();
    }
  }
}
