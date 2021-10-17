using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic.MovesRules
{
  static class RookMoveRule
  {
    public static List<Coords> GetMovesForRook(Pice pice, List<Pice> pices, Player enemy)
    {
      var output = new List<Coords>();
      //Von Figur nach Rechts
      output.AddRange(GetMovesToRight(pice, pices, enemy));
      //Von Figur nach Links
      output.AddRange(GetMovesToLeft(pice, pices, enemy));
      //Von Figur nach Unten
      output.AddRange(GetMovesToBottom(pice, pices, enemy));
      //Von Figur nach Unten
      output.AddRange(GetMovesToTop(pice, pices, enemy));

      return output;
    }

    private static List<Coords> GetMovesToBottom(Pice pice, List<Pice> pices, Player enemy)
    {
      var currentFile = pice.Coord.File;
      var currentRank = pice.Coord.Rank;

      var output = new List<Coords>();
      var isPiceBlocking = PiceBlockingReturn.NO;

      while (currentRank > 0 && isPiceBlocking == PiceBlockingReturn.NO)
      {
        var coords = new Coords(--currentRank, currentFile);
        isPiceBlocking = MoveRulesHelper.IsPiceBlocking(pices, coords, enemy);

        if (MoveRulesHelper.CanTakeCoord(isPiceBlocking))
          output.Add(coords);
      }
      return output;
    }

    private static List<Coords> GetMovesToTop(Pice pice, List<Pice> pices, Player enemy)
    {
      var currentFile = pice.Coord.File;
      var currentRank = pice.Coord.Rank;

      var output = new List<Coords>();
      var isPiceBlocking = PiceBlockingReturn.NO;

      while (currentRank < 7 && isPiceBlocking == PiceBlockingReturn.NO)
      {
        var coords = new Coords(++currentRank, currentFile);
        isPiceBlocking = MoveRulesHelper.IsPiceBlocking(pices, coords, enemy);

        if (MoveRulesHelper.CanTakeCoord(isPiceBlocking))
          output.Add(coords);
      }
      return output;
    }


    private static List<Coords> GetMovesToLeft(Pice pice, List<Pice> pices, Player enemy)
    {
      var currentFile = pice.Coord.File;
      var currentRank = pice.Coord.Rank;

      var output = new List<Coords>();
      var isPiceBlocking = PiceBlockingReturn.NO;

      while (currentFile > 0 && isPiceBlocking == PiceBlockingReturn.NO)
      {
        var coords = new Coords(currentRank, --currentFile);
        isPiceBlocking = MoveRulesHelper.IsPiceBlocking(pices, coords, enemy);

        if (MoveRulesHelper.CanTakeCoord(isPiceBlocking))
          output.Add(coords);
      }
      return output;
    }

    private static List<Coords> GetMovesToRight(Pice pice, List<Pice> pices, Player enemy)
    {
      var currentFile = pice.Coord.File;
      var currentRank = pice.Coord.Rank;

      var output = new List<Coords>();
      var isPiceBlocking = PiceBlockingReturn.NO;

      while (currentFile < 7 && isPiceBlocking == PiceBlockingReturn.NO)
      {
        var coords = new Coords(currentRank, ++currentFile);
        isPiceBlocking = MoveRulesHelper.IsPiceBlocking(pices, coords, enemy);

        if (MoveRulesHelper.CanTakeCoord(isPiceBlocking))
          output.Add(coords);
      }
      return output;
    }


  }
}
