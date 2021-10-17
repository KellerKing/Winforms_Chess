using Chess.Produktlogic.Contracts;
using Chess.Produktlogic.MovesRules;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public class Move
  {
    public static List<Pice> Castle(List<Pice> pices, Coords king, Coords rook)
    {
      var selectedKing = pices.First(x => x.Coord.Equals(king));
      var selectedRook = pices.First(x => x.Coord.Equals(rook));

      if (Rulebook.CanCastelQueenSide(pices.Select(x => (Pice)x.Clone()).ToList(), (Pice)selectedKing.Clone()))
      {
        selectedKing.Coord = new(selectedKing.Coord.Rank, selectedKing.Coord.File - 2);
        selectedRook.Coord = new(selectedRook.Coord.Rank, selectedRook.Coord.File + 3);
        selectedKing.MoveCounter++;
        return pices;
      }
      if (Rulebook.CanCastleKingSide(pices.Select(x => (Pice)x.Clone()).ToList(), (Pice)selectedKing.Clone()))
      {
        selectedKing.Coord = selectedKing.Coord = new(selectedKing.Coord.Rank, selectedKing.Coord.File + 2);
        selectedRook.Coord = new(selectedRook.Coord.Rank, selectedRook.Coord.File - 2);
        selectedKing.MoveCounter++;
        return pices;
      }
      return pices;
    }

    public static List<Pice> CapturePice(List<Pice> pices, Coords oldPosition, Coords newPosition)
    {
      pices.Remove(pices.First(x => x.Coord.Equals(newPosition)));
      var selectedPice = pices.First(x => x.Coord.Equals(oldPosition));
      selectedPice.Coord = newPosition;
      selectedPice.MoveCounter++;
      return pices;
    }

    public static List<Pice> MakeNonCaptureMove(Coords oldPosition, Coords newPosition, List<Pice> pices)
    {
      var selectedPice = pices.First(x => x.Coord.Equals(oldPosition));

      var enPassant = PawnMoveRule.GetEnPassant(selectedPice, pices);

      if (enPassant?.NewPosition.Equals(newPosition) == true) pices.Remove(pices.First(x => x.Coord.Equals(enPassant.PiceToCapture)));
      selectedPice.Coord = newPosition;
      selectedPice.MoveCounter++;
      return pices;
    }


  }
}
