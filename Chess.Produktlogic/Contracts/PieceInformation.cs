using System.Collections.Generic;

namespace Chess.Produktlogic.Contracts
{
  public class PieceInformation
  {

    public static readonly Dictionary<PiceType, int> VALUES = new()
    {
      { PiceType.PAWN, 1 },
      { PiceType.BISHOP, 3 },
      { PiceType.KNIGHT, 3 },
      { PiceType.ROOK, 6 },
      { PiceType.QUEEN, 9 },
      { PiceType.KING, 0 },
    };
  }
}
