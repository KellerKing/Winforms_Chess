using Chess.AI.Converter;
using Chess.AI.Converter.Interface;
using Chess.AI.Dto;
using Chess.Contracts.AI;
using System.Collections.Generic;
using System.Linq;

namespace Chess.AI.Connector
{
  internal class ProductlogicConnector
  {
    private readonly Contracts.Productlogic.IChessLogicController m_ProductlogicController;
    private readonly IProductlogicConverter m_ProductlogicConverter;
    public ProductlogicConnector(Contracts.Productlogic.IChessLogicController chessLogicController)
    {
      m_ProductlogicController = chessLogicController;
      m_ProductlogicConverter = new ProductlogicConverter();
    }

    public Konstanten.MoveType GetMoveType(List<Coordinates> possibleFelder, Coordinates targetCoords, List<Piece> currentPosition, Piece pieceToMove, Player player)
    {
      var convertedFelder = m_ProductlogicConverter.ConvertCoordinates(possibleFelder).ToList();
      var convertedTargetCoords = m_ProductlogicConverter.ConvertCoordinate(targetCoords);
      var convertedPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();
      var convertedPieceToMove = m_ProductlogicConverter.ConvertPiece(pieceToMove);
      var playerConverted = m_ProductlogicConverter.ConvertPlayer(player);

      var movetype = m_ProductlogicController.GetMoveType(convertedFelder, convertedTargetCoords, convertedPosition, convertedPieceToMove, playerConverted);

      return m_ProductlogicConverter.ConvertMoveType(movetype);
    }

    public UpdatePositionDto MakeAutomaticMove(Konstanten.MoveType moveType, Coordinates pieceToMoveOldPosition, Coordinates pieceToMoveNewPosition, List<Piece> currentPosition)
    {
      var convertedMovetype = m_ProductlogicConverter.ConvertMoveType(moveType);
      var convertedPieceToMoveOldPosition = m_ProductlogicConverter.ConvertCoordinate(pieceToMoveOldPosition);
      var convertedPieceToMoveNewPosition = m_ProductlogicConverter.ConvertCoordinate(pieceToMoveNewPosition);
      var convertedPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();

      var updatePositionDto = m_ProductlogicController.MakeAutomaticMove(convertedMovetype, convertedPieceToMoveOldPosition, convertedPieceToMoveNewPosition, convertedPosition);

      return m_ProductlogicConverter.ConvertUpdatePositionDto(updatePositionDto);
    }

    public List<Coordinates> GetPossibleFelderForPiece(Piece pieceToCheck, List<Piece> currentPosition)
    {
      var convertedCurrentPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();
      var convertedPieceToCheck = m_ProductlogicConverter.ConvertPiece(pieceToCheck);

      var possibleFelder = m_ProductlogicController.GetPossibleFelderForPiece(convertedPieceToCheck, convertedCurrentPosition);
      
      return m_ProductlogicConverter.ConvertCoordinates(possibleFelder).ToList();
    }

    public Konstanten.GameOverResult IsGameOver(List<Piece> currentPosition, Player playerToCheck)
    {
      var convertedCurrentPosition = m_ProductlogicConverter.ConvertPieces(currentPosition).ToList();
      var convertedPlayer = m_ProductlogicConverter.ConvertPlayer(playerToCheck);

      var gameOverResult = m_ProductlogicController.IsGameOver(convertedCurrentPosition, convertedPlayer);

      return m_ProductlogicConverter.ConvertGameOverResult(gameOverResult);
    }
  }
}
