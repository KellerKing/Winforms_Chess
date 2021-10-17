using Chess.Produktlogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Produktlogic.MovesRules
{
  public class MoveRulesHelper
  {
    public static bool CanTakeCoord(PiceBlockingReturn piceBlocking)
    {
      return piceBlocking != PiceBlockingReturn.OWN;
    }

    public static PiceBlockingReturn IsPiceBlocking(List<Pice> pices, Coords coordsToCheck, Player enemy)
    {
      if (pices.Any(x => x.Owner == enemy && x.Coord.Equals(coordsToCheck)))
        return PiceBlockingReturn.ENEMY;
      if (pices.Any(x => x.Owner != enemy && x.Coord.Equals(coordsToCheck)))
        return PiceBlockingReturn.OWN;

      return PiceBlockingReturn.NO;
    }
  }
}
