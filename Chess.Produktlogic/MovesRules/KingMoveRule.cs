using Chess.Produktlogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic.MovesRules
{
  static class KingMoveRule
  {
    public static List<Coords> GetMovesForKing(Piece pice, List<Piece> pices, Player enemy, bool IsCheckingForEnemy)
    {
      var output = new List<Coords>();

      if (!IsCheckingForEnemy && Rulebook.CanCastelQueenSide(pices.Select(x => (Piece)x.Clone()).ToList(), (Piece)pice.Clone()))
        output.Add(GetCastleRook(pice, pices, "Queenside"));

      else if (!IsCheckingForEnemy && Rulebook.CanCastleKingSide(pices.Select(x => (Piece)x.Clone()).ToList(), (Piece)pice.Clone()))
        output.Add(GetCastleRook(pice, pices, "Kingside"));

      output.AddRange(new List<Coords>()
      {
        new Coords(pice.Coord.Rank + 1, pice.Coord.File - 1),
        new Coords(pice.Coord.Rank + 1, pice.Coord.File),
        new Coords(pice.Coord.Rank + 1, pice.Coord.File + 1),

        new Coords(pice.Coord.Rank, pice.Coord.File + 1),
        new Coords(pice.Coord.Rank - 1, pice.Coord.File + 1),
        new Coords(pice.Coord.Rank - 1, pice.Coord.File),

        new Coords(pice.Coord.Rank, pice.Coord.File - 1),
        new Coords(pice.Coord.Rank - 1, pice.Coord.File - 1),

      }.Where(x => MoveRulesHelper.IsPiceBlocking(pices, x, enemy) != PiceBlockingReturn.OWN).ToList());
      return output.Where(x => (x.Rank >= 0 && x.Rank <= 7) && (x.File >= 0 && x.File <= 7)).ToList();
    }

    private static Coords GetCastleRook(Piece king, List<Piece> pices, string side)
    {
      return pices.FirstOrDefault(x => x.PiceType == PiceType.ROOK &&
          x.Owner == king.Owner &&
          side.ToUpper().Contains("KING") ?
          x.Coord.File > king.Coord.File : 
          x.Coord.File < king.Coord.File).Coord;
    }

    public static bool CanCastleKingSide(List<Piece> pices, Piece king)
    {
      if (king.MoveCounter != 0) return false;

      var kingSideRook = pices.FirstOrDefault(x => x.MoveCounter == 0 &&
        x.PiceType == PiceType.ROOK
        && x.Owner == king.Owner &&
        x.Coord.File == 7);

      if (kingSideRook == null) return false;
      if (IsCastleThroughCheck(pices, king, kingSideRook)) return false;

      return !IsPiceBlockingForCastle(pices, king, kingSideRook);
    }

    public static bool CanCastelQueenSide(List<Piece> pices, Piece king)
    {
      if (king.MoveCounter != 0) return false;

      var queenSideRook = pices.FirstOrDefault(x => x.MoveCounter == 0 &&
        x.PiceType == PiceType.ROOK
        && x.Owner == king.Owner &&
        x.Coord.File < king.Coord.File);

      if (queenSideRook == null) return false;
      //if (IsKingInCheck(pices, king.Owner)) return false;
      if (IsCastleThroughCheck(pices, king, queenSideRook)) return false;

      return !IsPiceBlockingForCastle(pices, king, queenSideRook);
    }

    private static bool IsCastleThroughCheck(List<Piece> pices, Piece king, Piece rook)
    {
      var minFile = Math.Min(king.Coord.File, rook.Coord.File);
      var maxFile = Math.Max(king.Coord.File, rook.Coord.File);

      return Enumerable.Range(minFile, maxFile).Any(x =>
      {
        king.Coord = new(king.Coord.Rank, x);
        return !Rulebook.IsKingInCheck(pices, king.Owner);
      });
    }

    private static bool IsPiceBlockingForCastle(List<Piece> pices, Piece king, Piece rook)
    {
      var minFile = Math.Min(king.Coord.File, rook.Coord.File);
      var maxFile = Math.Max(king.Coord.File, rook.Coord.File);

      return pices.Any(x => x.Coord.Rank == king.Coord.Rank &&
        (x.Coord.File > minFile && x.Coord.File < maxFile));
    }

  }
}
