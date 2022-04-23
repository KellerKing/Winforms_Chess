using Chess.AI.Dto;
using Chess.AI.Konstanten;
using Chess.Contracts.AI;
using System.Collections.Generic;

namespace Chess.AI.Converter.Interface
{
  internal interface IProductlogicConverter
  {
    IEnumerable<Contracts.Productlogic.Coords> ConvertCoordinates(List<Coordinates> possibleFelder);
    Contracts.Productlogic.Coords ConvertCoordinate(Coordinates targetCoords);
    Coordinates ConvertCoordinate(Contracts.Productlogic.Coords targetCoords);
    IEnumerable<Contracts.Productlogic.Piece> ConvertPieces(List<Piece> currentPosition);
    IEnumerable<Piece> ConvertPieces(List<Contracts.Productlogic.Piece> currentPosition);
    Contracts.Productlogic.Piece ConvertPiece(Piece pieceToMove);
    Piece ConvertPiece(Contracts.Productlogic.Piece pieceToMove);
    Contracts.Productlogic.Player ConvertPlayer(Player player);
    MoveType ConvertMoveType(Contracts.Productlogic.MoveType movetype);
    Contracts.Productlogic.MoveType ConvertMoveType(MoveType moveType);
    UpdatePositionDto ConvertUpdatePositionDto(Contracts.Productlogic.UpdatePositionDto updatePositionDto);
    IEnumerable<Coordinates> ConvertCoordinates(List<Contracts.Productlogic.Coords> possibleFelder);
    Chess.Contracts.AI.PieceType ConvertPieceType(Chess.Contracts.Productlogic.PieceType pieceType);
    Chess.Contracts.Productlogic.PieceType ConvertPieceType(Chess.Contracts.AI.PieceType pieceType);
    Chess.Contracts.AI.Player ConvertPlayer(Chess.Contracts.Productlogic.Player player);
    Konstanten.GameOverResult ConvertGameOverResult(Chess.Contracts.Productlogic.GameOverResult gameOverResult);
  }
}
