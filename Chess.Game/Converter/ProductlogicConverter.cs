using System.Collections.Generic;
using System.Linq;
using Chess.Contracts.Productlogic;
using Chess.Game.Converter.Interface;

namespace Chess.Game.Converter
{
  internal class ProductlogicConverter : IProductlogicConverter
  {
    public IEnumerable<Dto.Piece> ConvertPieces(List<Piece> pieces)
    {
      foreach (var piece in pieces)
      {
        yield return new Dto.Piece(ConvertPlayer(piece.Owner))
        {
          Coord = new(piece.Coord.Rank, piece.Coord.File),
          MoveCounter = piece.MoveCounter,
          PiceType = ConvertPieceType(piece.PieceType)
        };
      }
    }

    public IEnumerable<Piece> ConvertPieces(List<Dto.Piece> pieces)
    {
      foreach (var piece in pieces)
      {
        yield return new Piece(ConvertPlayer(piece.Owner))
        {
          Coord = new(piece.Coord.Rank, piece.Coord.File),
          MoveCounter = piece.MoveCounter,
          PieceType = ConvertPieceType(piece.PiceType)
        };
      }
    }

    public Piece ConvertPiece(Dto.Piece piece)
    {

      if(piece == null) return null;

      return new Piece(ConvertPlayer(piece.Owner))
      {
        Coord = new(piece.Coord.Rank, piece.Coord.File),
        MoveCounter = piece.MoveCounter,
        PieceType = ConvertPieceType(piece.PiceType)
      };
    }

    public IEnumerable<Dto.Coords> ConvertCoords(List<Coords> coords)
    {
      foreach (var cord in coords)
      {
        yield return new Dto.Coords(cord.Rank, cord.File);
      }
    }

    public IEnumerable<Coords> ConvertCoords(List<Dto.Coords> coords)
    {
      foreach (var cord in coords)
      {
        yield return new Coords(cord.Rank, cord.File);
      }
    }

    public Coords ConvertCoord(Dto.Coords coords)
    {
      return new(coords.Rank, coords.File);
    }

    public Dto.UpdatePositionDto ConvertUpdatePositionDto(UpdatePositionDto updatePositionDto)
    {
      return new Dto.UpdatePositionDto
      {
        BoardPosition = ConvertPieces(updatePositionDto.BoardPosition).ToList(),
        PossibleFelder = ConvertCoords(updatePositionDto.PossibleFelder).ToList(),
        WasMoveLegal = updatePositionDto.WasMoveLegal
      };
    }


    public Konstanten.PieceType ConvertPieceType(Contracts.Productlogic.PieceType pieceType)
    {
      return pieceType switch
      {
        PieceType.PAWN => Konstanten.PieceType.PAWN,
        PieceType.BISHOP => Konstanten.PieceType.BISHOP,
        PieceType.KNIGHT => Konstanten.PieceType.KNIGHT,
        PieceType.ROOK => Konstanten.PieceType.ROOK,
        PieceType.QUEEN => Konstanten.PieceType.QUEEN,
        PieceType.KING => Konstanten.PieceType.KING,
        _ => throw new System.Exception($"Cannot Convert PieceType From Chess.Contracts.Productlogic to Chess.Game.Konstanten. PieceType was {pieceType}"),
      };
    }

    public Contracts.Productlogic.PieceType ConvertPieceType(Konstanten.PieceType pieceType)
    {
      return pieceType switch
      {
        Konstanten.PieceType.PAWN => Contracts.Productlogic.PieceType.PAWN,
        Konstanten.PieceType.BISHOP => Contracts.Productlogic.PieceType.BISHOP,
        Konstanten.PieceType.KNIGHT => Contracts.Productlogic.PieceType.KNIGHT,
        Konstanten.PieceType.ROOK => Contracts.Productlogic.PieceType.ROOK,
        Konstanten.PieceType.QUEEN => Contracts.Productlogic.PieceType.QUEEN,
        Konstanten.PieceType.KING => Contracts.Productlogic.PieceType.KING,
        _ => throw new System.Exception($"Cannot Convert PieceType From Chess.Contracts.Productlogic to Chess.Game.Konstanten. PieceType was {pieceType}"),
      };
    }

    public Konstanten.Player ConvertPlayer(Contracts.Productlogic.Player player)
    {
      return player switch
      {
        Contracts.Productlogic.Player.BLACK => Konstanten.Player.BLACK,
        Contracts.Productlogic.Player.WHITE => Konstanten.Player.WHITE,
        _ => throw new System.Exception($"This Player is unknown: {player}"),
      };

    }

    public Player ConvertPlayer(Konstanten.Player player)
    {
      return player switch
      {
        Konstanten.Player.BLACK => Contracts.Productlogic.Player.BLACK,
        Konstanten.Player.WHITE => Contracts.Productlogic.Player.WHITE,
        _ => throw new System.Exception($"This Player is unknown: {player}"),
      };
    }

      public Konstanten.GameOverResult ConvertGameOverResult(GameOverResult gameOverResult)
      {
      return gameOverResult switch
      {
        GameOverResult.GAME_OVER => Konstanten.GameOverResult.GAME_OVER,
        GameOverResult.NO => Konstanten.GameOverResult.NO,
        GameOverResult.STATLEMENT => Konstanten.GameOverResult.STATLEMENT,
        _ => throw new System.Exception($"This GameOverResult is unknown: {gameOverResult}"),
      };
    }

    public Konstanten.MoveType ConvertMoveType(MoveType moveType)
    {
      return moveType switch
      {
        MoveType.CONVERT_PAWN => Konstanten.MoveType.CONVERT_PAWN,
        MoveType.PIECE_SELECT => Konstanten.MoveType.PIECE_SELECT,
        MoveType.CASTLE => Konstanten.MoveType.CASTLE,
        MoveType.FORWARD => Konstanten.MoveType.FORWARD,
        MoveType.NONE => Konstanten.MoveType.NONE,
        MoveType.CAPUTRE => Konstanten.MoveType.CAPUTRE,
        _ => throw new System.Exception($"This MoveType is unknown: {moveType}"),
      };
    }
  }
}
