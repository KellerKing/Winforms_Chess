using Chess.Produktlogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public static class Rulebook
  {
    public static bool IsStatelement(List<Piece> pices, Player currentPlayer)
    {
      if (IsKingInCheck(pices, currentPlayer)) return false;

      foreach (var item in pices.Where(x => x.Owner == currentPlayer))
      {
        var felderPossible = PossibleMoveFactory.GetMovesFor(item, pices);
        if (CanDoLegalMove(pices.ConvertAll(x => (Piece)x.Clone()).ToList(), (Piece)item.Clone(), felderPossible)) return false;
      }
      return true;
    }

    public static bool HasPlayerLost(List<Piece> pices, Player currentPlayer)
    {
      if (!IsKingInCheck(pices, currentPlayer)) return false;

      foreach (var item in pices.Where(x => x.Owner == currentPlayer))
      {
        var felderPossible = PossibleMoveFactory.GetMovesFor(item, pices);
        if (CanDoLegalMove(pices.ConvertAll(x => (Piece)x.Clone()).ToList(),(Piece)item.Clone(), felderPossible)) return false;
      }
      return true;
    }

    public static bool CanCastleKingSide(List<Piece> pices, Piece king)
    {
      if (king.MoveCounter != 0) return false;

      var kingSideRook = pices.FirstOrDefault(x => x.MoveCounter == 0 &&
        x.PiceType == PiceType.ROOK
        && x.Owner == king.Owner &&
        x.Coord.File > king.Coord.File);

      if (kingSideRook == null || IsCastleThroughCheck(pices, king, kingSideRook)) return false;
      return !IsPiceBlockingForCastle(pices, king, kingSideRook);
    }

    public static bool CanCastelQueenSide(List<Piece> pices, Piece king)
    {
      if (king.MoveCounter != 0) return false;

      var queenSideRook = pices.FirstOrDefault(x => x.MoveCounter == 0 &&
        x.PiceType == PiceType.ROOK
        && x.Owner == king.Owner &&
        x.Coord.File < king.Coord.File);

      if (queenSideRook == null || IsCastleThroughCheck(pices, king, queenSideRook)) return false;
      return !IsPiceBlockingForCastle(pices, king, queenSideRook);
    }

    private static bool IsCastleThroughCheck(List<Piece> pices, Piece king, Piece rook)
    {
      var minFile = Math.Min(king.Coord.File, rook.Coord.File);
      var maxFile = Math.Max(king.Coord.File, rook.Coord.File);

      return Enumerable.Range(minFile, maxFile).Any(x =>
      {
        king.Coord = new(king.Coord.Rank, x);
        return IsKingInCheck(pices, king);
      });
    }

    private static bool IsPiceBlockingForCastle(List<Piece> pices, Piece king, Piece rook)
    {
      var minFile = Math.Min(king.Coord.File, rook.Coord.File);
      var maxFile = Math.Max(king.Coord.File, rook.Coord.File);

      return pices.Any(x => x.Coord.Rank == king.Coord.Rank &&
        (x.Coord.File > minFile && x.Coord.File < maxFile));
    }

    public static bool IsKingInCheck(List<Piece> board, Player currentPlayer)
    {
      var currentKing = board.FirstOrDefault(x => x.Owner == currentPlayer && x.PiceType == PiceType.KING);

      return IsPiceAttacking(board, currentKing, PiceType.ROOK) || IsPiceAttacking(board, currentKing, PiceType.KNIGHT) ||
        IsPiceAttacking(board, currentKing, PiceType.BISHOP) || IsPiceAttacking(board, currentKing, PiceType.QUEEN) ||
        IsPiceAttacking(board, currentKing, PiceType.KING) || IsPiceAttacking(board, currentKing, PiceType.PAWN);
    }

    public static bool IsKingInCheck(List<Piece> board, Piece currentKing)
    {
      return IsPiceAttacking(board, currentKing, PiceType.ROOK) || IsPiceAttacking(board, currentKing, PiceType.KNIGHT) ||
        IsPiceAttacking(board, currentKing, PiceType.BISHOP) || IsPiceAttacking(board, currentKing, PiceType.QUEEN) ||
        IsPiceAttacking(board, currentKing, PiceType.KING) || IsPiceAttacking(board, currentKing, PiceType.PAWN);
    }

    private static bool CanDoLegalMove(List<Piece> pieces, Piece piece, List<Coords> felderPossible)
    {
      foreach (var possibleFeld in felderPossible)
      {
        var movetype = Move.GetMoveType(pieces.Any(x => x.Coord.Equals(possibleFeld)), felderPossible, possibleFeld, pieces, piece, piece.Owner);
        if (!IsKingInCheck(Move.AutomaticMove(movetype, piece.Coord, possibleFeld, pieces.ConvertAll(x => (Piece)x.Clone()).ToList()), piece.Owner)) return true;
      }
      return false;
    }

    private static bool IsPiceAttacking(List<Piece> board, Piece king, PiceType piceToCheck)
    {
      var enemyPices = board.Where(x => x.Owner != king.Owner && x.PiceType == piceToCheck).ToList();
      var possibleFelder = new List<Coords>();
      enemyPices.ForEach(x => possibleFelder.AddRange(PossibleMoveFactory.GetMovesFor(x, board, true)));
      return possibleFelder.Any(x => x.Equals(king.Coord));
    }
  }
}
