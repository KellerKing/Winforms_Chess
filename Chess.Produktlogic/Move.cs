using Chess.Produktlogic.Contracts;
using Chess.Produktlogic.MovesRules;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public class Move
  {
    public static MoveType GetMoveType(List<Coords> felderPossible, Coords coordsToCheck, List<Piece> pieces, Piece piecePreSelected, Player playerCurrent)
    {
      var isPieceClicked = pieces.Any(x => x.Coord.Equals(coordsToCheck));

      if (!isPieceClicked && piecePreSelected != null && felderPossible.Contains(coordsToCheck) && (coordsToCheck.Rank == 0 || coordsToCheck.Rank == 7) && piecePreSelected.PiceType == PiceType.PAWN)
        return MoveType.CONVERT_PAWN;

      if (isPieceClicked && piecePreSelected?.PiceType == PiceType.KING && pieces.Find(x => x.Owner == playerCurrent && x.Coord.Equals(coordsToCheck))?.PiceType == PiceType.ROOK)
        return MoveType.CASTLE;

      if (isPieceClicked && pieces.Any(x => x.Owner == playerCurrent && x.Coord.Equals(coordsToCheck)))
        return MoveType.PIECE_SELECT;

      if (!isPieceClicked && piecePreSelected != null && felderPossible.Contains(coordsToCheck))
        return MoveType.FORWARD;

      if (isPieceClicked && piecePreSelected != null && felderPossible.Contains(coordsToCheck))
        return MoveType.CAPUTRE;

      return MoveType.NONE;
    }

    public static List<Piece> AutomaticMove(MoveType moveType, Coords oldPosition, Coords newPosition, List<Piece> pices)
    {
      if (moveType == MoveType.CASTLE)
        return Castle(pices, oldPosition, newPosition);
      if (moveType == MoveType.CAPUTRE)
        return CapturePice(pices, oldPosition, newPosition);
      if (moveType == MoveType.FORWARD)
        return MakeNonCaptureMove(oldPosition, newPosition, pices);

      return new List<Piece>();
    }

    public static List<Piece> Castle(List<Piece> pices, Coords king, Coords rook)
    {
      var selectedKing = pices.First(x => x.Coord.Equals(king));
      var selectedRook = pices.First(x => x.Coord.Equals(rook));

      if (Rulebook.CanCastelQueenSide(pices.Select(x => (Piece)x.Clone()).ToList(), (Piece)selectedKing.Clone()))
      {
        selectedKing.Coord = new(selectedKing.Coord.Rank, selectedKing.Coord.File - 2);
        selectedRook.Coord = new(selectedRook.Coord.Rank, selectedRook.Coord.File + 3);
        selectedKing.MoveCounter++;
        return pices;
      }
      if (Rulebook.CanCastleKingSide(pices.Select(x => (Piece)x.Clone()).ToList(), (Piece)selectedKing.Clone()))
      {
        selectedKing.Coord = selectedKing.Coord = new(selectedKing.Coord.Rank, selectedKing.Coord.File + 2);
        selectedRook.Coord = new(selectedRook.Coord.Rank, selectedRook.Coord.File - 2);
        selectedKing.MoveCounter++;
        return pices;
      }
      return pices;
    }

    public static List<Piece> CapturePice(List<Piece> pices, Coords oldPosition, Coords newPosition)
    {
      pices.Remove(pices.First(x => x.Coord.Equals(newPosition)));
      var selectedPice = pices.First(x => x.Coord.Equals(oldPosition));
      selectedPice.Coord = newPosition;
      selectedPice.MoveCounter++;
      return pices;
    }

    public static List<Piece> MakeNonCaptureMove(Coords oldPosition, Coords newPosition, List<Piece> pices)
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
