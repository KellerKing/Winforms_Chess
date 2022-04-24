using Chess.Contracts.Productlogic;
using Chess.Productlogic.Konstanten;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Productlogic.MovesRules
{
  static class BishopMoveRule
  {
    public static List<Coords> GetMovesForBishop(Piece pice, List<Piece> pices, Player enemy)
    {
      return GetDiagonals(pice, pices, enemy);
    }

    private static List<Coords> GetRightUpperDiagonals(int currentRank, int currentFile, List<Piece> pices, Player enemy)
    {
      var isPiceBlocking = PiceBlockingReturn.NO;
      var output = new List<Coords>();

      while (currentFile < 7 && currentRank < 7 && isPiceBlocking == PiceBlockingReturn.NO)
      {
        var coords = new Coords(++currentRank, ++currentFile);
        isPiceBlocking = MoveRulesHelper.IsPiceBlocking(pices, coords, enemy);

        if (MoveRulesHelper.CanTakeCoord(isPiceBlocking))
          output.Add(coords);
      }
      return output;
    }

    private static List<Coords> GetLeftLowerDiagonals(int currentRank, int currentFile, List<Piece> pices, Player enemy)
    {
      var isPiceBlocking = PiceBlockingReturn.NO;
      var output = new List<Coords>();

      while (currentFile > 0 && currentRank > 0 && isPiceBlocking == PiceBlockingReturn.NO)
      {
        var coords = new Coords(--currentRank, --currentFile);
        isPiceBlocking = MoveRulesHelper.IsPiceBlocking(pices, coords, enemy);

        if (MoveRulesHelper.CanTakeCoord(isPiceBlocking))
          output.Add(coords);
      }
      return output;
    }

    private static List<Coords> GetLeftUpperDiagonals(int currentRank, int currentFile, List<Piece> pices, Player enemy)
    {
      var isPiceBlocking = PiceBlockingReturn.NO;
      var output = new List<Coords>();

      while (currentFile > 0 && currentRank < 7 && isPiceBlocking == PiceBlockingReturn.NO)
      {
        var coords = new Coords(++currentRank, --currentFile);
        isPiceBlocking = MoveRulesHelper.IsPiceBlocking(pices, coords, enemy);

        if (MoveRulesHelper.CanTakeCoord(isPiceBlocking))
          output.Add(coords);
      }
      return output;
    }

    private static List<Coords> GetRightLowerDiagonals(int currentRank, int currentFile, List<Piece> pices, Player enemy)
    {
      var isPiceBlocking = PiceBlockingReturn.NO;
      var output = new List<Coords>();

      while (currentFile < 7 && currentRank > 0 && isPiceBlocking == PiceBlockingReturn.NO)
      {
        var coords = new Coords(--currentRank, ++currentFile);
        isPiceBlocking = MoveRulesHelper.IsPiceBlocking(pices, coords, enemy);

        if (MoveRulesHelper.CanTakeCoord(isPiceBlocking))
          output.Add(coords);
      }
      return output;
    }

    private static List<Coords> GetDiagonals(Piece pice, List<Piece> pices, Player enemy)
    {
      var currentFile = pice.Coord.File;
      var currentRank = pice.Coord.Rank;

      return new List<Coords>()
        .Concat(GetRightLowerDiagonals(currentRank, currentFile, pices, enemy))
        .Concat(GetRightUpperDiagonals(currentRank, currentFile, pices, enemy))
        .Concat(GetLeftLowerDiagonals(currentRank, currentFile, pices, enemy))
        .Concat(GetLeftUpperDiagonals(currentRank, currentFile, pices, enemy)).ToList();
    }
  }
}
