using Chess.Produktlogic.Contracts;
using Chess.Produktlogic.MovesRules;
using System.Collections.Generic;

namespace Chess.Produktlogic
{
  public static class PossibleMoveFactory
  {
    public static List<Coords> GetMovesFor(Piece pice, List<Piece> pices, bool IsCheckingForEnemy = false)
    {
      var enemy = pice.Owner == Player.BLACK ? Player.WHITE : Player.BLACK;

      var possibleMoves = pice.PiceType switch
      {
        PiceType.KNIGHT => KnightMoveRule.GetMovesForKnight(pice, pices, enemy),
        PiceType.QUEEN => QueenMoveRule.GetMovesForQueen(pice, pices, enemy),
        PiceType.ROOK => RookMoveRule.GetMovesForRook(pice, pices, enemy),
        PiceType.BISHOP => BishopMoveRule.GetMovesForBishop(pice, pices, enemy),
        PiceType.PAWN => PawnMoveRule.GetMovesForPawn(pice, pices, enemy),
        PiceType.KING => KingMoveRule.GetMovesForKing(pice, pices, enemy, IsCheckingForEnemy),
        _ => new List<Coords>(),
      };
      return possibleMoves;
    }
  }
}