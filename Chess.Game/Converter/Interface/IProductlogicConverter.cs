using Chess.Contracts.Productlogic;
using System.Collections.Generic;

namespace Chess.Game.Converter.Interface
{
  internal interface IProductlogicConverter
  {
    IEnumerable<Dto.Piece> ConvertPieces(List<Piece> pieces);
    IEnumerable<Piece> ConvertPieces(List<Dto.Piece> pieces);
    Piece ConvertPiece(Dto.Piece pieces);
    IEnumerable<Dto.Coords> ConvertCoords(List<Coords> coords);
    IEnumerable<Coords> ConvertCoords(List<Dto.Coords> coords);
    Coords ConvertCoord(Dto.Coords coords);
    Dto.UpdatePositionDto ConvertUpdatePositionDto(UpdatePositionDto updatePositionDto);
    Konstanten.PieceType ConvertPieceType(Contracts.Productlogic.PieceType pieceType);
    Contracts.Productlogic.PieceType ConvertPieceType(Konstanten.PieceType pieceType);
    Konstanten.Player ConvertPlayer(Contracts.Productlogic.Player player);
    Contracts.Productlogic.Player ConvertPlayer(Konstanten.Player player);
    Konstanten.GameOverResult ConvertGameOverResult(Contracts.Productlogic.GameOverResult gameOverResult);
    Konstanten.MoveType ConvertMoveType(Contracts.Productlogic.MoveType moveType);
  }
}