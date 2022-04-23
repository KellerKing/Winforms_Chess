using Chess.Game.Converter;
using Chess.Game.Converter.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Game.Connector
{
  internal class ProduktlogicConnector
  {
    private readonly Contracts.Productlogic.IChessLogicController m_ProductlogicController;
    private readonly IProductlogicConverter m_ProductlogicConverter;
    public ProduktlogicConnector(Contracts.Productlogic.IChessLogicController chessLogicController)
    {
      m_ProductlogicController = chessLogicController;
      m_ProductlogicConverter = new ProductlogicConverter();
    }

    internal List<Dto.Piece> CreatePiecesFromFen(string fen)
    {
      var pieces = m_ProductlogicController.CreatePiecesFromFen(fen);

      return m_ProductlogicConverter.ConvertPieces(pieces).ToList();
    }

    internal Konstanten.GameOverResult IsGameOver(List<Dto.Piece> currentPosition, Konstanten.Player playerToCheck)
    {
      var convertedPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();
      var convertedPlayer = m_ProductlogicConverter.ConvertPlayer(playerToCheck);
      var isGameOverResult = m_ProductlogicController.IsGameOver(convertedPosition, convertedPlayer);

      return m_ProductlogicConverter.ConvertGameOverResult(isGameOverResult);
    }

    internal int GetScoring(List<Dto.Piece> currentPosition, Konstanten.Player playerToCheck)
    {
      var convertedPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();
      var convertedPlayer = m_ProductlogicConverter.ConvertPlayer(playerToCheck);

      return m_ProductlogicController.GetScoring(convertedPosition, convertedPlayer);
    }

    internal List<Dto.Coords> GetPossibleFelderForPiece(Dto.Piece pieceToCheck, List<Dto.Piece> currentPosition)
    {
      var convertedPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();
      var convertedPiece = m_ProductlogicConverter.ConvertPiece(pieceToCheck);
      var possibleFelder =  m_ProductlogicController.GetPossibleFelderForPiece(convertedPiece, convertedPosition);

      return m_ProductlogicConverter.ConvertCoords(possibleFelder).ToList();
    }

    internal Dto.UpdatePositionDto MakeNonCaptureMove(List<Dto.Piece> currentPosition, Dto.Coords targetPieceCoords, Dto.Piece pieceToMove)
    {
      var convertedCurrentPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();
      var convertedTargetPieceCoords = m_ProductlogicConverter.ConvertCoord(targetPieceCoords);
      var convertedPieceToMove = m_ProductlogicConverter.ConvertPiece(pieceToMove);

      var moveResult = m_ProductlogicController.MakeNonCaptureMove(convertedCurrentPosition, convertedTargetPieceCoords, convertedPieceToMove);

      return m_ProductlogicConverter.ConvertUpdatePositionDto(moveResult);
    }

    internal Dto.UpdatePositionDto MakeCaptureMove(List<Dto.Piece> currentPosition, Dto.Piece targetPiece, Dto.Piece pieceToMove)
    {
      var convertedCurrentPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();
      var convertedTargetPiece = m_ProductlogicConverter.ConvertPiece(targetPiece);
      var convertedPieceToMove = m_ProductlogicConverter.ConvertPiece(pieceToMove);

      var moveResult = m_ProductlogicController.MakeCaptureMove(convertedCurrentPosition, convertedTargetPiece, convertedPieceToMove);

      return m_ProductlogicConverter.ConvertUpdatePositionDto(moveResult);
    }

    internal Dto.UpdatePositionDto MakeCastleMove(List<Dto.Piece> currentPosition, Dto.Coords targetPieceCoords, Dto.Piece pieceToMove)
    {
      var convertedCurrentPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();
      var convertedTargetPieceCoords = m_ProductlogicConverter.ConvertCoord(targetPieceCoords);
      var convertedPieceToMove = m_ProductlogicConverter.ConvertPiece(pieceToMove);

      var moveResult = m_ProductlogicController.MakeCastleMove(convertedCurrentPosition, convertedTargetPieceCoords, convertedPieceToMove);

      return m_ProductlogicConverter.ConvertUpdatePositionDto(moveResult);
    }

    internal Konstanten.MoveType GetMoveType(List<Dto.Coords> possibleFelder, Dto.Coords coordsToCheck, List<Dto.Piece> currentPosition, Dto.Piece pieceToMove, Konstanten.Player currentPlayer)
    {
      var convertedCurrentPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();
      var convertedPossibleFelder = m_ProductlogicConverter.ConvertCoords(possibleFelder).ToList();
      var convertedCoordsToCheck = m_ProductlogicConverter.ConvertCoord(coordsToCheck);
      var convertedPieceToMove = m_ProductlogicConverter.ConvertPiece(pieceToMove);
      var convertedCurrentPlayer = m_ProductlogicConverter.ConvertPlayer(currentPlayer);

      var movetype = m_ProductlogicController.GetMoveType(convertedPossibleFelder, convertedCoordsToCheck, convertedCurrentPosition, convertedPieceToMove, convertedCurrentPlayer);

      return m_ProductlogicConverter.ConvertMoveType(movetype);
    }
  }
}
