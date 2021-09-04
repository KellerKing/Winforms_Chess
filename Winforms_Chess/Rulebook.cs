using System.Collections.Generic;
using System.Linq;

namespace Winforms_Chess
{
  public static class Rulebook
  {

    public static bool IsLegalMove(List<Pice> board, Player currentPlayer)
    {
      return !IsKingInCheck(board, currentPlayer);
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
