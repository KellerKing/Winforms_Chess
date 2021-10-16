using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic.MovesRules
{
  public static class KnightMoveRule
  {
    public static List<Coords> GetMovesForKnight(Pice pice, List<Pice> pices, Player enemy)
    {
      return new List<Coords>()
      {
        new Coords(pice.Coord.Rank - 2, pice.Coord.File - 1),
        new Coords(pice.Coord.Rank - 2, pice.Coord.File + 1),
        new Coords(pice.Coord.Rank + 2, pice.Coord.File - 1),
        new Coords(pice.Coord.Rank + 2, pice.Coord.File + 1),

        new Coords(pice.Coord.Rank - 1, pice.Coord.File - 2),
        new Coords(pice.Coord.Rank - 1, pice.Coord.File + 2),
        new Coords(pice.Coord.Rank + 1, pice.Coord.File - 2),
        new Coords(pice.Coord.Rank + 1, pice.Coord.File + 2),
      }
      .Where(x => (x.Rank >= 0 && x.Rank <= 7) && (x.File >= 0 && x.File <= 7) 
            && MoveRulesHelper.IsPiceBlocking(pices, x, enemy) != PiceBlockingReturn.OWN)
      .ToList();
    }
  }
}
