using Chess.Contracts.Productlogic;
using Chess.Productlogic.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Productlogic
{
  public static class Rulebook
  {
    public static GameOverResult IsGameOver(List<Piece> pices, Player currentPlayer)
    {
      var isKingInCheck = IsKingInCheck(pices, currentPlayer);

      if (isKingInCheck && HasPlayerLost(pices, currentPlayer)) return GameOverResult.GAME_OVER;

      if (!isKingInCheck && IsStatelement(pices, currentPlayer)) return GameOverResult.STATLEMENT;

      return GameOverResult.NO;
    }

    public static bool CanCastleKingSide(List<Piece> pices, Piece king)
    {
      if (king.MoveCounter != 0) return false;

      var kingSideRook = pices.FirstOrDefault(x => x.MoveCounter == 0 &&
        x.PieceType == PieceType.ROOK
        && x.Owner == king.Owner &&
        x.Coord.File == 7 && 
        x.Coord.Rank == king.Coord.Rank);

      if (kingSideRook == null || IsCastleThroughCheck(pices, king, kingSideRook)) return false;
      return !IsPiceBlockingForCastle(pices, king, kingSideRook);
    }

    public static bool CanCastelQueenSide(List<Piece> pices, Piece king)
    {
      if (king.MoveCounter != 0) return false;

      var queenSideRook = pices.FirstOrDefault(x => x.MoveCounter == 0 &&
        x.PieceType == PieceType.ROOK
        && x.Owner == king.Owner &&
        x.Coord.File == 0 &&
        x.Coord.Rank == king.Coord.Rank);

      if (queenSideRook == null || IsCastleThroughCheck(pices, king, queenSideRook)) return false;
      return !IsPiceBlockingForCastle(pices, king, queenSideRook);
    }

    private static bool IsStatelement(List<Piece> pices, Player currentPlayer)
    {
      foreach (var item in pices.Where(x => x.Owner == currentPlayer))
      {
        var felderPossible = PossibleMoveFactory.GetMovesFor(item, pices);
        if (CanDoLegalMove(pices.ConvertAll(x => (Piece)x.Clone()).ToList(), (Piece)item.Clone(), felderPossible)) return false;
      }
      return true;
    }

    private static bool HasPlayerLost(List<Piece> pices, Player currentPlayer)
    {
      foreach (var item in pices.Where(x => x.Owner == currentPlayer))
      {
        var felderPossible = PossibleMoveFactory.GetMovesFor(item, pices);
        if (CanDoLegalMove(pices.ConvertAll(x => (Piece)x.Clone()).ToList(), (Piece)item.Clone(), felderPossible)) return false;
      }
      return true;
    }

    private static bool IsCastleThroughCheck(List<Piece> pieces, Piece king, Piece rook)
    {
      var minFile = Math.Min(king.Coord.File, rook.Coord.File);
      var maxFile = Math.Max(king.Coord.File, rook.Coord.File);
      var copyList = pieces.ConvertAll(x => (Piece)x.Clone()).ToList();
      var copyKing = copyList.First(x => x.Coord.Equals(king.Coord));

      return Enumerable.Range(minFile, maxFile).Any(x =>
      {
        copyKing.Coord = new(king.Coord.Rank, x);
        return IsKingInCheck(copyList, king);
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
      var currentKing = board.FirstOrDefault(x => x.Owner == currentPlayer && x.PieceType == PieceType.KING);

      return IsPiceAttacking(board, currentKing, PieceType.ROOK) || IsPiceAttacking(board, currentKing, PieceType.KNIGHT) ||
        IsPiceAttacking(board, currentKing, PieceType.BISHOP) || IsPiceAttacking(board, currentKing, PieceType.QUEEN) ||
        IsPiceAttacking(board, currentKing, PieceType.KING) || IsPiceAttacking(board, currentKing, PieceType.PAWN);
    }

    public static bool IsKingInCheck(List<Piece> board, Piece currentKing)
    {
      return IsPiceAttacking(board, currentKing, PieceType.ROOK) || IsPiceAttacking(board, currentKing, PieceType.KNIGHT) ||
        IsPiceAttacking(board, currentKing, PieceType.BISHOP) || IsPiceAttacking(board, currentKing, PieceType.QUEEN) ||
        IsPiceAttacking(board, currentKing, PieceType.KING) || IsPiceAttacking(board, currentKing, PieceType.PAWN);
    }

    private static bool CanDoLegalMove(List<Piece> pieces, Piece pieceToMove, List<Coords> felderPossible)
    {
      foreach (var possibleFeld in felderPossible)
      {
        var movetype = Move.GetMoveType(felderPossible, possibleFeld, pieces, pieceToMove, pieceToMove.Owner);
        if (!IsKingInCheck(Move.AutomaticMove(movetype, pieceToMove.Coord, possibleFeld, pieces.ConvertAll(x => (Piece)x.Clone()).ToList()), pieceToMove.Owner)) return true;
      }
      return false;
    }

    private static bool IsPiceAttacking(List<Piece> board, Piece king, PieceType piceToCheck)
    {
      var enemyPices = board.Where(x => x.Owner != king.Owner && x.PieceType == piceToCheck).ToList();
      var possibleFelder = new List<Coords>();
      enemyPices.ForEach(x => possibleFelder.AddRange(PossibleMoveFactory.GetMovesFor(x, board, true)));
      return possibleFelder.Any(x => x.Equals(king.Coord));
    }
  }
}
