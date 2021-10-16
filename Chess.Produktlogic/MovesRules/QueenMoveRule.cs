using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic.MovesRules
{
  public static class QueenMoveRule
  {
    public static List<Coords> GetMovesForQueen(Pice pice, List<Pice> pices, Player enemy)
    {
      return new List<Coords>()
        .Concat(RookMoveRule.GetMovesForRook(pice, pices, enemy))
        .Concat(BishopMoveRule.GetMovesForBishop(pice, pices, enemy)).ToList();
    }
  }
}
