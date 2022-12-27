using Chess.Contracts.AI;
using Chess.Game.Converter.Interface;
using Chess.Game.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Game.Converter
{
  internal class AiConverter : IAiConverter
  {
    public Coords ConvertCoord(Coordinates coord)
    {
      return new Coords(coord.Rank, coord.File);
    }

    public Coordinates ConvertCoord(Coords coord)
    {
      return new Coordinates(coord.Rank, coord.File);
    }

    public Contracts.AI.Piece ConvertPiece(Dto.Piece currentPosistion)
    {
      return new Contracts.AI.Piece(ConvertPlayer(currentPosistion.Owner))
      {
        Coord = ConvertCoord(currentPosistion.Coord),
        PiceType = ConvertPieceType(currentPosistion.PiceType),
        MoveCounter = currentPosistion.MoveCounter,
        HasCastleKingSideRight = currentPosistion.HasCastleKingSideRight,
        HasCastleQueenSideRight = currentPosistion.HasCastleQueenSideRight,
        IsLastMovedPieceFromPlayer = currentPosistion.IsLastMovedPieceFromPlayer,
        MovesSinceLastPawnOrCaptureMove = currentPosistion.MovesSinceLastPawnOrCaptureMove
      };
    }

    public Dto.Piece ConvertPiece(Contracts.AI.Piece currentPosition)
    {
      return new Dto.Piece(ConvertPlayer(currentPosition.Owner))
      {
        Coord = ConvertCoord(currentPosition.Coord),
        PiceType = ConvertPieceType(currentPosition.PiceType),
        MoveCounter = currentPosition.MoveCounter,
        HasCastleKingSideRight = currentPosition.HasCastleKingSideRight,
        HasCastleQueenSideRight = currentPosition.HasCastleQueenSideRight,
        IsLastMovedPieceFromPlayer = currentPosition.IsLastMovedPieceFromPlayer,
        MovesSinceLastPawnOrCaptureMove = currentPosition.MovesSinceLastPawnOrCaptureMove
      };
    }

    public IEnumerable<Contracts.AI.Piece> ConvertPieces(List<Dto.Piece> currentPosistion)
    {
      return currentPosistion.Select(x => ConvertPiece(x));
    }

    public IEnumerable<Dto.Piece> ConvertPieces(List<Contracts.AI.Piece> currentPosition)
    {
      return currentPosition.Select(x => ConvertPiece(x));
    }

    public Konstanten.PieceType ConvertPieceType(Contracts.AI.PieceType pieceType)
    {
      return pieceType switch
      {
        PieceType.PAWN => Konstanten.PieceType.PAWN,
        PieceType.BISHOP => Konstanten.PieceType.BISHOP,
        PieceType.KNIGHT => Konstanten.PieceType.KNIGHT,
        PieceType.ROOK => Konstanten.PieceType.ROOK,
        PieceType.QUEEN => Konstanten.PieceType.QUEEN,
        PieceType.KING => Konstanten.PieceType.KING,
        _ => throw new Exception($"Contracts.AI.PieceType {pieceType} is unknown")
      };
    }

    public Contracts.AI.PieceType ConvertPieceType(Konstanten.PieceType pieceType)
    {
      return pieceType switch
      {
        Konstanten.PieceType.PAWN => Contracts.AI.PieceType.PAWN,
        Konstanten.PieceType.BISHOP => Contracts.AI.PieceType.BISHOP,
        Konstanten.PieceType.KNIGHT => Contracts.AI.PieceType.KNIGHT,
        Konstanten.PieceType.ROOK => Contracts.AI.PieceType.ROOK,
        Konstanten.PieceType.QUEEN => Contracts.AI.PieceType.QUEEN,
        Konstanten.PieceType.KING => Contracts.AI.PieceType.KING,
        _ => throw new Exception($"Konstanten.PieceType {pieceType} is unknown")
      };
    }

    public Contracts.AI.Player ConvertPlayer(Konstanten.Player player)
    {
      return player switch
      {
        Konstanten.Player.WHITE => Contracts.AI.Player.WHITE,
        Konstanten.Player.BLACK => Contracts.AI.Player.BLACK,
        _ => throw new System.Exception($"Konstanten.Player {player} is unknown")
      };

    }

    public Konstanten.Player ConvertPlayer(Contracts.AI.Player player)
    {
      return player switch
      {
        Contracts.AI.Player.WHITE => Konstanten.Player.WHITE,
        Contracts.AI.Player.BLACK => Konstanten.Player.BLACK,
        _ => throw new System.Exception($"Contracts.AI.Player {player} is unknown")
      };
    }
  }
}
