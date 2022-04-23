using Chess.Contracts.AI;
using Chess.Game.Dto;
using System.Collections.Generic;

namespace Chess.Game.Converter.Interface
{
  internal interface IAiConverter
  {
    IEnumerable<Contracts.AI.Piece> ConvertPieces(List<Dto.Piece> currentPosistion);
    Contracts.AI.Piece ConvertPiece(Dto.Piece currentPosistion);
    Contracts.AI.Player ConvertPlayer(Konstanten.Player player);
    Konstanten.Player ConvertPlayer(Contracts.AI.Player player);
    IEnumerable<Dto.Piece> ConvertPieces(List<Contracts.AI.Piece> currentPosition);
    Dto.Piece ConvertPiece(Contracts.AI.Piece currentPosition);
    Konstanten.PieceType ConvertPieceType(Contracts.AI.PieceType piceType);
    Contracts.AI.PieceType ConvertPieceType(Konstanten.PieceType piceType);
    Coords ConvertCoord(Coordinates coord);
    Coordinates ConvertCoord(Coords coord);
  }
}
