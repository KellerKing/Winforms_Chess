namespace Chess.Game.Dto
{
  internal class Piece
  {
    public Piece(Konstanten.Player player)
    {
      Owner = player;
    }

    public Konstanten.Player Owner { get; init; }
    public Konstanten.PieceType PiceType { get; set; }
    public Coords Coord { get; set; }
    public int MoveCounter { get; set; }
    public bool IsLastMovedPieceFromPlayer { get; set; }
    public bool HasCastleKingSideRight { get; set; }
    public bool HasCastleQueenSideRight { get; set; }

  }
}
