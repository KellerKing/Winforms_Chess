using Chess.Contracts.AI;

namespace Chess.AI
{
  internal class Helper
  {
    public static Piece ClonePiece(Piece piece)
    {
      return new Piece(piece.Owner)
      {
        Coord = piece.Coord,
        MoveCounter = piece.MoveCounter,
        PiceType = piece.PiceType
      };
    }
  }
}
