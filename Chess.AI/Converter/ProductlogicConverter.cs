using Chess.AI.Converter.Interface;
using Chess.Contracts.AI;
using Chess.Contracts.Productlogic;
using System.Collections.Generic;
using System.Linq;

namespace Chess.AI.Converter
{
  internal class ProductlogicConverter : IProductlogicConverter
  {
    public Coords ConvertCoordinate(Coordinates targetCoords)
    {
      return new Coords(targetCoords.Rank, targetCoords.File);
    }

    public Coordinates ConvertCoordinate(Coords targetCoords)
    {
      return new Coordinates(targetCoords.Rank, targetCoords.File);
    }

    public IEnumerable<Coords> ConvertCoordinates(List<Coordinates> coordinates)
    {
      return coordinates.Select(x => new Coords(x.Rank, x.File));
    }

    public IEnumerable<Coordinates> ConvertCoordinates(List<Coords> coordinates)
    {
      return coordinates.Select(x => new Coordinates(x.Rank, x.File));
    }

    public Konstanten.GameOverResult ConvertGameOverResult(Contracts.Productlogic.GameOverResult gameOverResult)
    {
      return gameOverResult switch
      {
        Contracts.Productlogic.GameOverResult.GAME_OVER => Konstanten.GameOverResult.GAME_OVER,
        Contracts.Productlogic.GameOverResult.NO => Konstanten.GameOverResult.NO,
        Contracts.Productlogic.GameOverResult.STATLEMENT => Konstanten.GameOverResult.STATLEMENT,
        _ => throw new System.Exception($"GameOverResult {gameOverResult} is unknown"),
      };
    }

    public Konstanten.MoveType ConvertMoveType(Contracts.Productlogic.MoveType moveType)
    {
      return moveType switch
      {
        MoveType.CASTLE => Konstanten.MoveType.CASTLE,
        MoveType.CAPUTRE => Konstanten.MoveType.CAPUTRE,
        MoveType.FORWARD => Konstanten.MoveType.FORWARD,
        MoveType.PIECE_SELECT => Konstanten.MoveType.PIECE_SELECT,
        MoveType.NONE => Konstanten.MoveType.NONE,
        MoveType.CONVERT_PAWN => Konstanten.MoveType.CONVERT_PAWN,
        _ => throw new System.Exception($"Movetype {moveType} is unknown"),
      };
    }

    public Contracts.Productlogic.MoveType ConvertMoveType(Konstanten.MoveType moveType)
    {
      return moveType switch
      {
        Konstanten.MoveType.CASTLE => Contracts.Productlogic.MoveType.CASTLE,
        Konstanten.MoveType.CAPUTRE => Contracts.Productlogic.MoveType.CAPUTRE,
        Konstanten.MoveType.FORWARD => Contracts.Productlogic.MoveType.FORWARD,
        Konstanten.MoveType.PIECE_SELECT => Contracts.Productlogic.MoveType.PIECE_SELECT,
        Konstanten.MoveType.NONE => Contracts.Productlogic.MoveType.NONE,
        Konstanten.MoveType.CONVERT_PAWN => Contracts.Productlogic.MoveType.CONVERT_PAWN,
        _ => throw new System.Exception($"Movetype {moveType} is unknown"),
      };
    }

    public Contracts.Productlogic.Piece ConvertPiece(Contracts.AI.Piece pieceToMove)
    {
      return new Contracts.Productlogic.Piece(ConvertPlayer(pieceToMove.Owner))
      {
        Coord = ConvertCoordinate(pieceToMove.Coord),
        MoveCounter = pieceToMove.MoveCounter,
        PieceType = ConvertPieceType(pieceToMove.PiceType)
      };
    }

    public Contracts.AI.Piece ConvertPiece(Contracts.Productlogic.Piece pieceToMove)
    {
      return new Contracts.AI.Piece(ConvertPlayer(pieceToMove.Owner))
      {
        Coord = ConvertCoordinate(pieceToMove.Coord),
        MoveCounter = pieceToMove.MoveCounter,
        PiceType = ConvertPieceType(pieceToMove.PieceType)
      };
    }

    public IEnumerable<Contracts.Productlogic.Piece> ConvertPieces(List<Contracts.AI.Piece> currentPosition)
    {
      foreach (var piece in currentPosition)
      {
        yield return ConvertPiece(piece);
      }
    }

    public IEnumerable<Contracts.AI.Piece> ConvertPieces(List<Contracts.Productlogic.Piece> currentPosition)
    {
      foreach (var piece in currentPosition)
      {
        yield return ConvertPiece(piece);
      }
    }

    public Contracts.AI.PieceType ConvertPieceType(Contracts.Productlogic.PieceType pieceType)
    {
      return pieceType switch
      {
        Contracts.Productlogic.PieceType.PAWN => Contracts.AI.PieceType.PAWN,
        Contracts.Productlogic.PieceType.BISHOP => Contracts.AI.PieceType.BISHOP,
        Contracts.Productlogic.PieceType.KNIGHT => Contracts.AI.PieceType.KNIGHT,
        Contracts.Productlogic.PieceType.ROOK => Contracts.AI.PieceType.ROOK,
        Contracts.Productlogic.PieceType.QUEEN => Contracts.AI.PieceType.QUEEN,
        Contracts.Productlogic.PieceType.KING => Contracts.AI.PieceType.KING,
        _ => throw new System.Exception($"PieceType {pieceType} is unknown")
      };
    }

    public Contracts.Productlogic.PieceType ConvertPieceType(Contracts.AI.PieceType pieceType)
    {
      return pieceType switch
      {
        Contracts.AI.PieceType.PAWN  => Contracts.Productlogic.PieceType.PAWN,
        Contracts.AI.PieceType.BISHOP => Contracts.Productlogic.PieceType.BISHOP,
        Contracts.AI.PieceType.KNIGHT => Contracts.Productlogic.PieceType.KNIGHT,
        Contracts.AI.PieceType.ROOK => Contracts.Productlogic.PieceType.ROOK,
        Contracts.AI.PieceType.QUEEN => Contracts.Productlogic.PieceType.QUEEN,
        Contracts.AI.PieceType.KING => Contracts.Productlogic.PieceType.KING,
        _ => throw new System.Exception($"PieceType {pieceType} is unknown")
      };

    }

    public Contracts.Productlogic.Player ConvertPlayer(Contracts.AI.Player player)
    {
      return player switch
      {
        Contracts.AI.Player.WHITE => Contracts.Productlogic.Player.WHITE,
        Contracts.AI.Player.BLACK => Contracts.Productlogic.Player.BLACK,
        _ => throw new System.Exception($"Player {player} is unknown")
      };
    }

    public Contracts.AI.Player ConvertPlayer(Contracts.Productlogic.Player player)
    {
      return player switch
      {
        Contracts.Productlogic.Player.WHITE => Contracts.AI.Player.WHITE,
        Contracts.Productlogic.Player.BLACK => Contracts.AI.Player.BLACK,
        _ => throw new System.Exception($"Player {player} is unknown")
      };

    }

    public Dto.UpdatePositionDto ConvertUpdatePositionDto(Contracts.Productlogic.UpdatePositionDto updatePositionDto)
    {
      return new Dto.UpdatePositionDto
      {
        BoardPosition = ConvertPieces(updatePositionDto.BoardPosition).ToList(),
        WasLegalMove = updatePositionDto.WasMoveLegal
      };
    }
  }
}