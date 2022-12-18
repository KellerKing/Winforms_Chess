namespace Chess.Contracts.AI
{
  public class Piece
  {
    public Piece(Player player)
    {
      Owner = player;
    }

    public Player Owner { get; init; }
    public PieceType PiceType { get; set; }
    public Coordinates Coord { get; set; }
    public int MoveCounter { get; set; }
    public bool IsLastMovedPieceFromPlayer { get; set; }
    public bool HasCastleKingSideRight { get; set; }
    public bool HasCastleQueenSideRight { get; set; }
  }
}
