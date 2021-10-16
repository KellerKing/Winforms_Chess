using Chess.Produktlogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public static class Rulebook
  {

    public static bool IsLegalMove(List<Pice> positionsCurrent, Player currentPlayer)
    {
      return !IsKingInCheck(positionsCurrent, currentPlayer);
    }

    public static bool CanCastleKingSide(List<Pice> pices, Pice king)
    {
      if (king.MoveCounter != 0) return false;

      var kingSideRook = pices.FirstOrDefault(x => x.MoveCounter == 0 &&
        x.PiceType == PiceType.ROOK
        && x.Owner == king.Owner &&
        x.Coord.File > king.Coord.File);

      if (kingSideRook == null) return false;
      //if (IsKingInCheck(pices, king.Owner)) return false;
      if (IsCastleThroughCheck(pices, king, kingSideRook)) return false;

      return !IsPiceBlockingForCastle(pices, king, kingSideRook);

    }

    public static bool CanCastelQueenSide(List<Pice> pices, Pice king)
    {
      if (king.MoveCounter != 0) return false;

      var queenSideRook = pices.FirstOrDefault(x => x.MoveCounter == 0 &&
        x.PiceType == PiceType.ROOK
        && x.Owner == king.Owner &&
        x.Coord.File < king.Coord.File);

      if (queenSideRook == null) return false;
      //if (IsKingInCheck(pices, king.Owner)) return false;
      if(IsCastleThroughCheck(pices, king, queenSideRook)) return false;

      return !IsPiceBlockingForCastle(pices, king, queenSideRook);
    }

    private static bool IsCastleThroughCheck(List<Pice> pices, Pice king, Pice rook)
    {
      var minFile = Math.Min(king.Coord.File, rook.Coord.File);
      var maxFile = Math.Max(king.Coord.File, rook.Coord.File);

      return Enumerable.Range(minFile, maxFile).Any(x =>
      {
        king.Coord = new(king.Coord.Rank, x);
        return IsKingInCheck(pices, king);
      });
    }

    private static bool IsPiceBlockingForCastle(List<Pice> pices, Pice king, Pice rook)
    {
      var minFile = Math.Min(king.Coord.File, rook.Coord.File);
      var maxFile = Math.Max(king.Coord.File, rook.Coord.File);

      return pices.Any(x => x.Coord.Rank == king.Coord.Rank &&
        (x.Coord.File > minFile && x.Coord.File < maxFile));
    }

    private static bool IsKingInCheck(List<Pice> board, Player currentPlayer)
    {
      var currentKing = board.FirstOrDefault(x => x.Owner == currentPlayer && x.PiceType == PiceType.KING);

      return IsPiceAttacking(board, currentKing, PiceType.ROOK) || IsPiceAttacking(board, currentKing, PiceType.KNIGHT) ||
        IsPiceAttacking(board, currentKing, PiceType.BISHOP) || IsPiceAttacking(board, currentKing, PiceType.QUEEN) ||
        IsPiceAttacking(board, currentKing, PiceType.KING) || IsPiceAttacking(board, currentKing, PiceType.PAWN);
    }

    private static bool IsKingInCheck(List<Pice> board, Pice currentKing)
    {
      return IsPiceAttacking(board, currentKing, PiceType.ROOK) || IsPiceAttacking(board, currentKing, PiceType.KNIGHT) ||
        IsPiceAttacking(board, currentKing, PiceType.BISHOP) || IsPiceAttacking(board, currentKing, PiceType.QUEEN) ||
        IsPiceAttacking(board, currentKing, PiceType.KING) || IsPiceAttacking(board, currentKing, PiceType.PAWN);
    }



    private static bool IsPiceAttacking(List<Pice> board, Pice king, PiceType piceToCheck)
    {
      var enemyPices = board.Where(x => x.Owner != king.Owner && x.PiceType == piceToCheck).ToList();
      var possibleFelder = new List<Coords>();
      enemyPices.ForEach(x => possibleFelder.AddRange(PossibleMoveFactory.GetMovesFor(x, board, true)));
      return possibleFelder.Any(x => x.Equals(king.Coord));
    }
  }
}
