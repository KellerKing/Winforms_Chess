using System;
using System.Collections.Generic;
using System.Linq;
using Winforms_Chess.DTOs;

namespace Winforms_Chess
{
  public static class Rulebook
  {

    public static bool IsLegalMove(List<Pice> positionsCurrent, Player currentPlayer)
    {
      return !IsKingInCheck(positionsCurrent, currentPlayer);
    }

    public static bool IsEnPassant(Pice selectedPice, Coords coordsToCheck, List<Pice> pices)
    {
      if (selectedPice.PiceType != PiceType.PAWN) return false;

      var enemyPice = pices.Find(x => x.Coord.Equals(coordsToCheck));

      if (enemyPice == null) return false;

      if (enemyPice.Owner == Player.BLACK && enemyPice.MoveCounter == 1 && enemyPice.Coord.Rank == 4)
      {
        return true;
      }
      else if (enemyPice.MoveCounter == 1 && enemyPice.Coord.Rank == 3)
      {
        return true;
      }

      return false;
    }

    public static EnPassantItem GetEnPassant(Pice clickedPice, List<Pice> pices)
    {
      if (clickedPice.PiceType != PiceType.PAWN) return default;

      if (clickedPice.Owner == Player.WHITE && pices.Any(x => x.Owner == Player.BLACK && x.Coord.Rank == 4 && x.Coord.Rank == clickedPice.Coord.Rank && x.Coord.File == clickedPice.Coord.File + 1 && x.MoveCounter == 1 && x.PiceType == PiceType.PAWN))
      {
        return new EnPassantItem
        {
          NewPosition = new(clickedPice.Coord.Rank + 1, clickedPice.Coord.File + 1),
          PiceToCapture = new(clickedPice.Coord.Rank, clickedPice.Coord.File + 1)
        };
      }

      if (clickedPice.Owner == Player.WHITE && pices.Any(x => x.Owner == Player.BLACK && x.Coord.Rank == 4 && x.Coord.Rank == clickedPice.Coord.Rank && x.Coord.File == clickedPice.Coord.File - 1 && x.MoveCounter == 1 && x.PiceType == PiceType.PAWN))
      {
        return new EnPassantItem
        {
          NewPosition = new(clickedPice.Coord.Rank + 1, clickedPice.Coord.File - 1),
          PiceToCapture = new(clickedPice.Coord.Rank, clickedPice.Coord.File - 1)
        };
      }

      if (pices.Any(x => x.Owner == Player.WHITE && x.Coord.Rank == clickedPice.Coord.Rank && x.Coord.Rank == 3 && x.Coord.File == clickedPice.Coord.File + 1 && x.MoveCounter == 1 && x.PiceType == PiceType.PAWN))
      {
        return new EnPassantItem
        {
          NewPosition = new(clickedPice.Coord.Rank - 1, clickedPice.Coord.File + 1),
          PiceToCapture = new(clickedPice.Coord.Rank, clickedPice.Coord.File + 1)
        };
      }
      if (pices.Any(x => x.Owner == Player.WHITE && x.Coord.Rank == clickedPice.Coord.Rank && x.Coord.Rank == 3 && x.Coord.File == clickedPice.Coord.File - 1 && x.MoveCounter == 1 && x.PiceType == PiceType.PAWN))
      {
        return new EnPassantItem
        {
          NewPosition = new(clickedPice.Coord.Rank - 1, clickedPice.Coord.File - 1),
          PiceToCapture = new(clickedPice.Coord.Rank, clickedPice.Coord.File - 1)
        };
      }
      return new EnPassantItem();
    }

    private static bool IsKingInCheck(List<Pice> board, Player currentPlayer)
    {
      var currentKing = board.FirstOrDefault(x => x.Owner == currentPlayer && x.PiceType == PiceType.KING);

      return IsPiceAttacking(board, currentKing, PiceType.ROOK) || IsPiceAttacking(board, currentKing, PiceType.KNIGHT) ||
        IsPiceAttacking(board, currentKing, PiceType.BISHOP) || IsPiceAttacking(board, currentKing, PiceType.QUEEN) ||
        IsPiceAttacking(board, currentKing, PiceType.KING) || IsPiceAttacking(board, currentKing, PiceType.PAWN);
    }

    private static bool IsPiceAttacking(List<Pice> board, Pice king, PiceType piceToCheck)
    {
      var enemyPices = board.Where(x => x.Owner != king.Owner && x.PiceType == piceToCheck).ToList();
      var possibleFelder = new List<Coords>();
      enemyPices.ForEach(x => possibleFelder.AddRange(Move.GetMovesFor(x, board)));
      return possibleFelder.Any(x => x.Equals(king.Coord));

      //return CheckCheck(board, enemyPices, king.Owner);

    }
  }
}
