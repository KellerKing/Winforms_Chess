using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
  public static class Rulebook
  {

    public static List<Coords> GetLegalMovesForSelectedPice(List<Pice> board, Pice selectedPice)
    {
      return null;
    }

    private static bool IsKingInCheck(Player player, List<Pice> pices)
    {
      var king = pices.First(x => x.Owner == player && x.PiceType == PiceType.KING);
      var enemy = player == Player.BLACK ? Player.WHITE : Player.BLACK;

      return IsRookAttacking(enemy, pices, king) || IsPawnAttacking(enemy, pices, king) || 
        IsKnigtAttacking(enemy, pices, king) || IsBishopAttacking(enemy, pices, king) || 
        IsQueenAttacking(enemy, pices, king) || IsKingAttacking(enemy, pices, king);
    }
    //Rework mit Moves Klasse
    private static bool IsRookAttacking(Player enemy, List<Pice> pices, Pice king)
    {
      return pices.Any(x => x.Coord.File == king.Coord.File && x.Owner == enemy) || pices.Any(x => x.Coord.Rank == king.Coord.Rank && x.Owner == enemy);
    }

    private static bool IsPawnAttacking(Player enemy, List<Pice> pices, Pice king)
    {
      var pawns = pices.Where(x => x.Owner == enemy && x.PiceType == PiceType.PAWN);
      return pawns.Any(pawn => Move.GetMovesFor(pawn, pices).Contains(king.Coord));
    }

    private static bool IsKnigtAttacking(Player enemy, List<Pice> pices, Pice king)
    {
      var knights = pices.Where(x => x.Owner == enemy && x.PiceType == PiceType.KNIGHT);
      return knights.Any(knight => Move.GetMovesFor(knight, pices).Contains(king.Coord));
    }


    private static bool IsBishopAttacking(Player enemy, List<Pice> pices, Pice king)
    {
      var bishops = pices.Where(x => x.Owner == enemy && x.PiceType == PiceType.BISHOP);
      return bishops.Any(bishop => Move.GetMovesFor(bishop, pices).Contains(king.Coord));
    }

    private static bool IsQueenAttacking(Player enemy, List<Pice> pices, Pice king)
    {
      var queen = pices.FirstOrDefault(x => x.Owner == enemy && x.PiceType == PiceType.QUEEN);
      return Move.GetMovesFor(queen, pices).Contains(king.Coord);
    }

    private static bool IsKingAttacking(Player enemy, List<Pice> pices, Pice king)
    {
      var enemyKing = pices.FirstOrDefault(x => x.Owner == enemy && x.PiceType == PiceType.KING);
      return Move.GetMovesFor(enemyKing, pices).Contains(king.Coord);
    }
  }
}
