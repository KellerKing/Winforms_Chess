using Chess.Contracts.Productlogic;
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
        PieceType.KNIGHT => KnightMoveRule.GetMovesForKnight(pice, pices, enemy),
        PieceType.QUEEN => QueenMoveRule.GetMovesForQueen(pice, pices, enemy),
        PieceType.ROOK => RookMoveRule.GetMovesForRook(pice, pices, enemy),
        PieceType.BISHOP => BishopMoveRule.GetMovesForBishop(pice, pices, enemy),
        PieceType.PAWN => PawnMoveRule.GetMovesForPawn(pice, pices, enemy),
        PieceType.KING => KingMoveRule.GetMovesForKing(pice, pices, enemy, IsCheckingForEnemy),
        _ => new List<Coords>(),
      };
      return possibleMoves;
    }
  }
}