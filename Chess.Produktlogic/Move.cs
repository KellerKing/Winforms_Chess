using Chess.Contracts.Productlogic;
using Chess.Productlogic.MovesRules;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Productlogic
{
  public class Move
  {
    public static MoveType GetMoveType(List<Coords> felderPossible, Coords coordsToCheck, List<Piece> pieces, Piece piecePreSelected, Player playerCurrent)
    {
      var isPieceClicked = pieces.Any(x => x.Coord.Equals(coordsToCheck));

      if (!isPieceClicked && piecePreSelected != null && felderPossible.Contains(coordsToCheck) && (coordsToCheck.Rank == 0 || coordsToCheck.Rank == 7) && piecePreSelected.PieceType == PieceType.PAWN)
        return MoveType.CONVERT_PAWN;

      if (isPieceClicked && piecePreSelected?.PieceType == PieceType.KING && pieces.Find(x => x.Owner == playerCurrent && x.Coord.Equals(coordsToCheck))?.PieceType == PieceType.ROOK)
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
      //TODO: Hier ab ich noch das Problem, dass nur das Castlerecht verhindert wird wenn ich Castle. Sonst nicht.
      //Vielleicht etwas logik aus CanCastle..Side rausziehen. Genau das würde ich brauchen. Oder ein Helper!

      //TODO: Bei einem Capture Move muss der Movecounter auf eine andere Figur übetragen werden, die im besten Fall schon einen Zug gemacht hat. Sonst stimmt hinterher der Fen nicht mehr.
      if (Rulebook.CanCastelQueenSide(pices.ConvertAll(x => (Piece)x.Clone()), (Piece)selectedKing.Clone()))
      {
        selectedKing.Coord = new(selectedKing.Coord.Rank, selectedKing.Coord.File - 2);
        selectedRook.Coord = new(selectedRook.Coord.Rank, selectedRook.Coord.File + 3);
        selectedKing.MoveCounter++;
        selectedKing.MovesSinceLastPawnOrCaptureMove++;
        selectedKing.HasCastleQueenSideRight  = false;
        selectedKing.HasCastleKingSideRight  = false;
                
        return UpdateLastMovedPiece(pices, selectedKing).ToList();
      }
      if (Rulebook.CanCastleKingSide(pices.ConvertAll(x => (Piece)x.Clone()), (Piece)selectedKing.Clone()))
      {
        selectedKing.Coord = selectedKing.Coord = new(selectedKing.Coord.Rank, selectedKing.Coord.File + 2);
        selectedRook.Coord = new(selectedRook.Coord.Rank, selectedRook.Coord.File - 2);
        selectedKing.MoveCounter++;
        selectedKing.MovesSinceLastPawnOrCaptureMove++;
        selectedKing.HasCastleQueenSideRight  = false;
        selectedKing.HasCastleKingSideRight  = false;

        return UpdateLastMovedPiece(pices, selectedKing).ToList();
      }
      return pices;
    }

    public static List<Piece> CapturePice(List<Piece> pices, Coords oldPosition, Coords newPosition)
    {
      pices.Remove(pices.First(x => x.Coord.Equals(newPosition)));
      var selectedPice = pices.First(x => x.Coord.Equals(oldPosition));
      selectedPice.Coord = newPosition;
      selectedPice.MoveCounter++;
      pices.ForEach(x => x.MovesSinceLastPawnOrCaptureMove = 0);

      return UpdateLastMovedPiece(pices, selectedPice).ToList();
    }

    public static List<Piece> MakeNonCaptureMove(Coords oldPosition, Coords newPosition, List<Piece> pices)
    {
      var selectedPice = pices.First(x => x.Coord.Equals(oldPosition));

      var enPassant = PawnMoveRule.GetEnPassant(selectedPice, pices);

      if (enPassant?.NewPosition.Equals(newPosition) == true) pices.Remove(pices.First(x => x.Coord.Equals(enPassant.PiceToCapture)));
      selectedPice.Coord = newPosition;
      selectedPice.MoveCounter++;

      if (selectedPice.PieceType == PieceType.PAWN) pices.ForEach(x => x.MovesSinceLastPawnOrCaptureMove = 0);
      else selectedPice.MovesSinceLastPawnOrCaptureMove++;

      return UpdateLastMovedPiece(pices, selectedPice).ToList();
    }

    private static IEnumerable<Piece> UpdateLastMovedPiece(IEnumerable<Piece> pieces, Piece movedPiece) //TODO: Ganz und gar nicht sauber aber fürs erste reichts
    {
      var result = pieces
          .Where(x => x.Owner == movedPiece.Owner)
          .Select(x => x.IsLastMovedPieceFromPlayer = false)
          .ToList();

      movedPiece.IsLastMovedPieceFromPlayer = true;

      if (movedPiece.PieceType == PieceType.KING)
      {
        movedPiece.HasCastleKingSideRight = false;
        movedPiece.HasCastleQueenSideRight = false;
      }

      if (movedPiece.PieceType != PieceType.ROOK) return pieces;

      return pieces;
    }
  }
}
