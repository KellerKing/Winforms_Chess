using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public class Controller : IChessLogicController
  {
    public List<Coords> GetPossibleFelderForPiece(Piece piceToCheck, List<Piece> boardPosition)
    {
      return PossibleMoveFactory.GetMovesFor(piceToCheck, boardPosition);
    }

    public UpdatePositionDto MakeCastleMove(List<Piece> pices, Coords clickedPice, Piece preselectedPice)
    {
      var newBoardPosition = Move.Castle(pices.Select(x => (Piece)x.Clone()).ToList(), preselectedPice.Coord, clickedPice);

      return new UpdatePositionDto
      {
        BoardPosition = newBoardPosition,
        PossibleFelder = new List<Coords>(),
        WasMoveLegal = !Rulebook.IsKingInCheck(newBoardPosition, preselectedPice.Owner),
      };
    }

    public UpdatePositionDto MakeCaptureMove(List<Piece> pices, Piece clickedPice, Piece preselectedPice)
    {
      var newBoardPosition = Move.CapturePice(pices.Select(x => (Piece)x.Clone()).ToList(), preselectedPice.Coord, clickedPice.Coord);
      
      return new UpdatePositionDto
      {
        BoardPosition = newBoardPosition,
        WasMoveLegal = !Rulebook.IsKingInCheck(newBoardPosition, preselectedPice.Owner),
        PossibleFelder = new List<Coords>(),
      };
    }

    public UpdatePositionDto MakeNonCaptureMove(List<Piece> pices, Coords clickedPice, Piece preselectedPice)
    {
      var newBoardPosition = Move.MakeNonCaptureMove(preselectedPice.Coord, clickedPice, pices.Select(x => (Piece)x.Clone()).ToList());

      return new UpdatePositionDto
      {
        BoardPosition = newBoardPosition,
        WasMoveLegal = !Rulebook.IsKingInCheck(newBoardPosition, preselectedPice.Owner),
        PossibleFelder = new List<Coords>(),
      };
    }

    public UpdatePositionDto MakeAutomaticMove(MoveType moveType, Coords oldPosition, Coords newPosition, List<Piece> pieces)
    {
      var newBoardPosition = Move.AutomaticMove(moveType, oldPosition, newPosition, pieces);

      return new UpdatePositionDto
      {
        BoardPosition = newBoardPosition,
        WasMoveLegal = !Rulebook.IsKingInCheck(newBoardPosition, pieces.First(x => x.Coord.Equals(oldPosition)).Owner),
        PossibleFelder = new List<Coords>(),
      };
    }

    public int GetScoring(List<Piece> pices, Player currentPlayer)
    {
      return ScoreCalculator.CalculateRelativeScore(pices, currentPlayer);
    }

    public GameOver IsGameOver(List<Piece> pices, Player currentPlayer)
    {
      return Rulebook.IsGameOver(pices, currentPlayer);
    }

    public MoveType GetMoveType(bool isPice, List<Coords> felderPossible, Coords coordsToCheck, List<Piece> pieces, Piece piecePreSelected, Player playerCurrent)
    {
      return Move.GetMoveType(isPice, felderPossible, coordsToCheck, pieces, piecePreSelected, playerCurrent);
    }

    public List<Piece> CreatePiecesFromFen(string fen)
    {
      //TODO: Maybe Check if Fen is valid
      return FenMapper.CreatePiecesFromFen(fen);
    }

    public string CreateFenFromPieces(List<Piece> pieces)
    {
     return FenMapper.CreateFenFromPices(pieces);
    }
  }
}
