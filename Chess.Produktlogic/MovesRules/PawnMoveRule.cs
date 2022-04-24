using Chess.Contracts.Productlogic;
using Chess.Productlogic.Dto;
using Chess.Productlogic.Konstanten;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Productlogic.MovesRules
{
  static class PawnMoveRule
  {
    public static List<Coords> GetMovesForPawn(Piece pice, List<Piece> pices, Player enemy)
    {
      var felder = new List<Coords>();
      felder.AddRange(GetNormalForwardFelder(pice, pices, enemy));
   
      felder.Add(GetEnPassant(pice, pices).NewPosition);
      return felder.Where(x => MoveRulesHelper.IsPiceBlocking(pices, x, enemy) != PiceBlockingReturn.OWN).ToList().Where(x => (x.Rank >= 0 && x.Rank <= 7) && (x.File >= 0 && x.File <= 7)).ToList();
    }

    public static EnPassantItem GetEnPassant(Piece clickedPice, List<Piece> pices)
    {
      if (clickedPice.PieceType != PieceType.PAWN) return default;

      if (clickedPice.Owner == Player.WHITE && pices.Any(x => x.Owner == Player.BLACK && x.Coord.Rank == 4 && x.Coord.Rank == clickedPice.Coord.Rank && x.Coord.File == clickedPice.Coord.File + 1 && x.MoveCounter == 1 && x.PieceType == PieceType.PAWN))
      {
        return new EnPassantItem
        {
          NewPosition = new(clickedPice.Coord.Rank + 1, clickedPice.Coord.File + 1),
          PiceToCapture = new(clickedPice.Coord.Rank, clickedPice.Coord.File + 1)
        };
      }

      if (clickedPice.Owner == Player.WHITE && pices.Any(x => x.Owner == Player.BLACK && x.Coord.Rank == 4 && x.Coord.Rank == clickedPice.Coord.Rank && x.Coord.File == clickedPice.Coord.File - 1 && x.MoveCounter == 1 && x.PieceType == PieceType.PAWN))
      {
        return new EnPassantItem
        {
          NewPosition = new(clickedPice.Coord.Rank + 1, clickedPice.Coord.File - 1),
          PiceToCapture = new(clickedPice.Coord.Rank, clickedPice.Coord.File - 1)
        };
      }

      if (clickedPice.Owner == Player.BLACK && pices.Any(x => x.Owner == Player.WHITE && x.Coord.Rank == 3 && x.Coord.Rank == clickedPice.Coord.Rank && x.Coord.File == clickedPice.Coord.File + 1 && x.MoveCounter == 1 && x.PieceType == PieceType.PAWN))
      {
        return new EnPassantItem
        {
          NewPosition = new(clickedPice.Coord.Rank - 1, clickedPice.Coord.File + 1),
          PiceToCapture = new(clickedPice.Coord.Rank, clickedPice.Coord.File + 1)
        };
      }
      if (clickedPice.Owner == Player.BLACK && pices.Any(x => x.Owner == Player.WHITE && x.Coord.Rank == 3 && x.Coord.Rank == clickedPice.Coord.Rank && x.Coord.File == clickedPice.Coord.File - 1 && x.MoveCounter == 1 && x.PieceType == PieceType.PAWN))
      {
        return new EnPassantItem
        {
          NewPosition = new(clickedPice.Coord.Rank - 1, clickedPice.Coord.File - 1),
          PiceToCapture = new(clickedPice.Coord.Rank, clickedPice.Coord.File - 1)
        };
      }
      return new EnPassantItem();
    }



    private static List<Coords> GetNormalForwardFelder(Piece pice, List<Piece> pices, Player enemy)
    {
      if(enemy == Player.BLACK)
        return GetFelderForBlackEnemy(pice, pices);

      return GetFelderForWhiteEnemy(pice, pices);
    }


    private static List<Coords> GetFelderForWhiteEnemy(Piece pice, List<Piece> pices)
    {
      var felder = pices.Where(x => x.Owner == Player.WHITE && x.Coord.Rank == pice.Coord.Rank - 1 && (x.Coord.File - 1 == pice.Coord.File || x.Coord.File + 1 == pice.Coord.File))
                        .Select(x => x.Coord)
                        .ToList();
      
      if (MoveRulesHelper.IsPiceBlocking(pices, new(pice.Coord.Rank - 1, pice.Coord.File), Player.BLACK) == PiceBlockingReturn.NO)
        felder.Add(new Coords(pice.Coord.Rank - 1, pice.Coord.File));

      if (pice.Coord.Rank == 6 && MoveRulesHelper.IsPiceBlocking(pices, new(pice.Coord.Rank - 2, pice.Coord.File), Player.BLACK) == PiceBlockingReturn.NO)
          felder.Add(new Coords(pice.Coord.Rank - 2, pice.Coord.File));

      return felder;
    }

    private static List<Coords> GetFelderForBlackEnemy(Piece pice, List<Piece> pices)
    {
      var felder = pices.Where(x => x.Owner == Player.BLACK && x.Coord.Rank == pice.Coord.Rank + 1 && (x.Coord.File - 1 == pice.Coord.File || x.Coord.File + 1 == pice.Coord.File))
                        .Select(x => x.Coord)
                        .ToList();
      
      if (MoveRulesHelper.IsPiceBlocking(pices, new(pice.Coord.Rank + 1, pice.Coord.File), Player.BLACK) == PiceBlockingReturn.NO)
        felder.Add(new Coords(pice.Coord.Rank + 1, pice.Coord.File));
      
      if (pice.Coord.Rank == 1 && MoveRulesHelper.IsPiceBlocking(pices, new(pice.Coord.Rank + 2, pice.Coord.File), Player.BLACK) == PiceBlockingReturn.NO) 
        felder.Add(new Coords(pice.Coord.Rank + 2, pice.Coord.File));

      return felder;
    }
  }
}
