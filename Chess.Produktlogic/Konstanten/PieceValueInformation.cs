using System.Collections.Generic;

namespace Chess.Contracts.Productlogic
{
  public class PieceValueInformation
  {

    public static readonly Dictionary<PieceType, int> VALUES = new()
    {
      { PieceType.PAWN, 1 },
      { PieceType.BISHOP, 3 },
      { PieceType.KNIGHT, 3 },
      { PieceType.ROOK, 6 },
      { PieceType.QUEEN, 9 },
      { PieceType.KING, 100 },
    };
  }
}
