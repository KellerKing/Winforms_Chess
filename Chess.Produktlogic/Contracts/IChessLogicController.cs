using System.Collections.Generic;

namespace Chess.Produktlogic.Contracts
{
  public interface IChessLogicController
  {
    public List<Piece> CreatePiecesFromFen(string fen);
    public string CreateFenFromPieces(List<Piece> pieces);

    List<Coords> GetPossibleFelderForPiece(Piece piceToCheck, List<Piece> boardPosition);

    List<Coords> FilterFelderForLegalMoves(List<Piece> boardPosition, List<Coords> felderPossible, Piece pieceToMove);

    UpdatePositionDto MakeCaptureMove(List<Piece> pieces, Piece clickedPice, Piece preselectedPice);
    UpdatePositionDto MakeNonCaptureMove(List<Piece> pieces, Coords clickedPice, Piece preselectedPice);
    UpdatePositionDto MakeCastleMove(List<Piece> pieces, Coords clickedPice, Piece preselectedPice);
    UpdatePositionDto MakeAutomaticMove(MoveType moveType, Coords oldPosition, Coords newPosition, List<Piece> pices);
    int GetScoring(List<Piece> pieces, Player currentPlayer);
    GameOver IsGameOver(List<Piece> pieces, Player currentPlayer);
    MoveType GetMoveType(List<Coords> felderPossible, Coords coordsToCheck, List<Piece> pieces, Piece piecePreSelected, Player playerCurrent);
  }
}
