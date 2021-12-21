using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic.MovesRules
{
  public class MoveRulesHelper
  {
    public static bool CanTakeCoord(PiceBlockingReturn piceBlocking)
    {
      return piceBlocking != PiceBlockingReturn.OWN;
    }

    public static PiceBlockingReturn IsPiceBlocking(List<Piece> pices, Coords coordsToCheck, Player enemy)
    {
      if (pices.Any(x => x.Owner == enemy && x.Coord.Equals(coordsToCheck)))
        return PiceBlockingReturn.ENEMY;
      if (pices.Any(x => x.Owner != enemy && x.Coord.Equals(coordsToCheck)))
        return PiceBlockingReturn.OWN;

      return PiceBlockingReturn.NO;
    }

    public static IEnumerable<Coords> FilterFelderForLegalMoves(List<Piece> position, List<Coords> felderPossible, Piece pieceToMove)
    {
      foreach (var item in felderPossible)
      {
        var moveType = Move.GetMoveType(felderPossible, item, position, pieceToMove, pieceToMove.Owner);
        var moveResult = Move.AutomaticMove(moveType, pieceToMove.Coord, item, position);

        if (Rulebook.IsKingInCheck(moveResult, pieceToMove.Owner)) continue;

        yield return item;
      }
    }
  }
}
