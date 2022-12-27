using Chess.Contracts.Productlogic;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Productlogic.Test
{
  [TestFixture]
  public class FenMapper_Tests
  {
    [Test]
    public void CreateFenFromPieces_Integration_StartPosition()
    {
      var test = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };

      var expected = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

      var result = FenMapper.CreateFenFromPices(test, Player.WHITE);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPieces_Integration_SchwarzIstDran()
    {
      var test = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1,
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F3,
          PieceType = PieceType.PAWN,
          MoveCounter = 1,
          IsLastMovedPieceFromPlayer = true,
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };

      var expected = "rnbqkbnr/pppp1ppp/8/4p3/4P3/5P2/PPPP2PP/RNBQKBNR b KQkq - 0 2";
      var result = FenMapper.CreateFenFromPices(test, Player.BLACK);
      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPieces_Integration_KeinerKannCastlen()
    {
      var test = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = false,
          HasCastleQueenSideRight = false,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 1,
          MovesSinceLastPawnOrCaptureMove = 1,
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1,
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F3,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E7,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = false,
          HasCastleQueenSideRight = false,
          MovesSinceLastPawnOrCaptureMove = 1,
          MoveCounter = 1,
          IsLastMovedPieceFromPlayer = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };

      var expected = "rnbq1bnr/ppppkppp/8/4p3/4P3/5P2/PPPP1KPP/RNBQ1BNR b - - 2 3";
      var result = FenMapper.CreateFenFromPices(test, Player.BLACK);
      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPieces_Integration_WeissKannCastlen()
    {
      var test = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 0,
          MovesSinceLastPawnOrCaptureMove = 0,
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1,
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F3,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E7,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = false,
          HasCastleQueenSideRight = false,
          MovesSinceLastPawnOrCaptureMove = 1,
          MoveCounter = 1,
          IsLastMovedPieceFromPlayer = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };

      var expected = "rnbq1bnr/ppppkppp/8/4p3/4P3/5P2/PPPP2PP/RNBQKBNR w KQ - 1 3";
      var result = FenMapper.CreateFenFromPices(test, Player.WHITE);
      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPieces_Integration_EnPassant()
    {
      var test = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 2
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1,
          IsLastMovedPieceFromPlayer = true
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F6,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };

      var expected = "rnbqkbnr/ppp1p1pp/5p2/3pP3/8/8/PPPP1PPP/RNBQKBNR w KQkq d6 0 3";

      var result = FenMapper.CreateFenFromPices(test, Player.WHITE);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPieces_Integration_10Halbzuege()
    {
      var test = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT,
          MovesSinceLastPawnOrCaptureMove = 4,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 0
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP,
          MovesSinceLastPawnOrCaptureMove = 3,
          MoveCounter = 0
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK,
          IsLastMovedPieceFromPlayer = true,
          MovesSinceLastPawnOrCaptureMove = 3,
          MoveCounter = 0
        }
      };

      var expected = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 10 1";

      var result = FenMapper.CreateFenFromPices(test, Player.WHITE);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPieces_Integration_6ZugnummerWeissIstDranGeradeZugzahl()
    {
      var test = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT,
          MovesSinceLastPawnOrCaptureMove = 4,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 4
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP,
          MovesSinceLastPawnOrCaptureMove = 3,
          MoveCounter = 3
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK,
          IsLastMovedPieceFromPlayer = true,
          MovesSinceLastPawnOrCaptureMove = 3,
          MoveCounter = 3
        }
      };

      var expected = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 10 6";

      var result = FenMapper.CreateFenFromPices(test, Player.WHITE);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPieces_Integration_6ZugnummerSchwarzIstDranUngeradeZugzahl()
    {
      var test = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT,
          MovesSinceLastPawnOrCaptureMove = 5,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 5
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP,
          MovesSinceLastPawnOrCaptureMove = 3,
          MoveCounter = 3
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK,
          IsLastMovedPieceFromPlayer = true,
          MovesSinceLastPawnOrCaptureMove = 3,
          MoveCounter = 3
        }
      };

      var expected = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR b KQkq - 11 6";

      var result = FenMapper.CreateFenFromPices(test, Player.BLACK);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPieces_Integration_SinglePiece()
    {
      var test = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        }
      };

      var expected = "8/8/8/8/8/8/8/R7 w - - 0 1";

      var result = FenMapper.CreateFenFromPices(test, Player.WHITE);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPieces_Integration_LeereListe()
    {
      var test = new List<Piece>();

      var expected = "8/8/8/8/8/8/8/8 b - - 0 1";

      var result = FenMapper.CreateFenFromPices(test, Player.BLACK);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPieces_Integration_Spielverlauf()
    {
      var startposition = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };
      var zug1 = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };
      var zug2 = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };
      var zug3 = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C4,
          PieceType = PieceType.BISHOP,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 1,
          MovesSinceLastPawnOrCaptureMove = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK,
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };
      var zug4 = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C4,
          PieceType = PieceType.BISHOP,
          MoveCounter = 1,
          MovesSinceLastPawnOrCaptureMove = 1,
          IsLastMovedPieceFromPlayer = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1,
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C5,
          PieceType = PieceType.BISHOP,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 1,
          MovesSinceLastPawnOrCaptureMove = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };
      var zug5 = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C4,
          PieceType = PieceType.BISHOP,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1,
          IsLastMovedPieceFromPlayer = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true

        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C5,
          PieceType = PieceType.BISHOP,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };
      var zug6 = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C4,
          PieceType = PieceType.BISHOP,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1,
          IsLastMovedPieceFromPlayer = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = false,
          HasCastleQueenSideRight = false,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 1,
          MovesSinceLastPawnOrCaptureMove = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C5,
          PieceType = PieceType.BISHOP,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };
      var zug7 = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C4,
          PieceType = PieceType.BISHOP,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G5,
          PieceType = PieceType.PAWN,
          MoveCounter = 2,
          IsLastMovedPieceFromPlayer = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = false,
          HasCastleQueenSideRight = false,
          MoveCounter = 1,
          IsLastMovedPieceFromPlayer = true,
          MovesSinceLastPawnOrCaptureMove = 0,
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C5,
          PieceType = PieceType.BISHOP,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };
      var zug8 = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C4,
          PieceType = PieceType.BISHOP,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G5,
          PieceType = PieceType.PAWN,
          MoveCounter = 2,
          IsLastMovedPieceFromPlayer = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F5,
          PieceType = PieceType.PAWN,
          IsLastMovedPieceFromPlayer = true,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = false,
          HasCastleQueenSideRight = false,
          MoveCounter = 1,
          IsLastMovedPieceFromPlayer = false,
          MovesSinceLastPawnOrCaptureMove = 0,
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C5,
          PieceType = PieceType.BISHOP,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };
      var zug9 = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = true,
          HasCastleQueenSideRight = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C4,
          PieceType = PieceType.BISHOP,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F6,
          PieceType = PieceType.PAWN,
          MoveCounter = 3,
          IsLastMovedPieceFromPlayer = true
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.KING,
          HasCastleKingSideRight = false,
          HasCastleQueenSideRight = false,
          MoveCounter = 2,
          IsLastMovedPieceFromPlayer = false,
          MovesSinceLastPawnOrCaptureMove = 0,
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C5,
          PieceType = PieceType.BISHOP,
          MoveCounter = 1
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };

      var expected = new List<string>
      {
        "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1",
        "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq - 0 1", //Bauer von Weiss
        "rnbqkbnr/pppp1ppp/8/4p3/4P3/8/PPPP1PPP/RNBQKBNR w KQkq - 0 2", //Bauer von Schwarz
        "rnbqkbnr/pppp1ppp/8/4p3/2B1P3/8/PPPP1PPP/RNBQK1NR b KQkq - 1 2", //Läufuer von Weiss auf C4
        "rnbqk1nr/pppp1ppp/8/2b1p3/2B1P3/8/PPPP1PPP/RNBQK1NR w KQkq - 2 3", //Läufer von Schwarz auf C5
        "rnbqk1nr/pppp1ppp/8/2b1p3/2B1P1P1/8/PPPP1P1P/RNBQK1NR b KQkq g3 0 3", //Bauer Weiss von G2 nach G4
        "rnbq1knr/pppp1ppp/8/2b1p3/2B1P1P1/8/PPPP1P1P/RNBQK1NR w KQ - 1 4", //König Schwarz von E8 nach F8
        "rnbq1knr/pppp1ppp/8/2b1p1P1/2B1P3/8/PPPP1P1P/RNBQK1NR b KQ - 0 4", // Bauer Weiss von G4 nach G5
        "rnbq1knr/pppp2pp/8/2b1ppP1/2B1P3/8/PPPP1P1P/RNBQK1NR w KQ f6 0 5", // Bauer Schwarz von F7 nach F5
        "rnbq1knr/pppp2pp/5P2/2b1p3/2B1P3/8/PPPP1P1P/RNBQK1NR b KQ - 0 5" // Bauer Weiss von G5 nach F6
      };

      var result = new List<string>
      {
        FenMapper.CreateFenFromPices(startposition, Player.WHITE),
        FenMapper.CreateFenFromPices(zug1, Player.BLACK),
        FenMapper.CreateFenFromPices(zug2, Player.WHITE),
        FenMapper.CreateFenFromPices(zug3, Player.BLACK),
        FenMapper.CreateFenFromPices(zug4, Player.WHITE),
        FenMapper.CreateFenFromPices(zug5, Player.BLACK),
        FenMapper.CreateFenFromPices(zug6, Player.WHITE),
        FenMapper.CreateFenFromPices(zug7, Player.BLACK),
        FenMapper.CreateFenFromPices(zug8, Player.WHITE),
        FenMapper.CreateFenFromPices(zug9, Player.BLACK),
      };

      for (int i = 0; i < expected.Count; i++)
      {
        Assert.AreEqual(expected[i], result[i], $"Zug: {i}");
      }
    }

    [Test]
    public void CreatePiecesFromFen_StartPosition()
    {
      var expected = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D1,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.KING
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G1,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.C2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.H2,
          PieceType = PieceType.PAWN
        },
        ///Ab hier beginnt Schwarz
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H7,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.A8,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D8,
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.KING
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F8,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G8,
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H8,
          PieceType = PieceType.ROOK
        }
      };

      var result = FenMapper.CreatePiecesFromFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");
      Assert.IsTrue(result.Count == expected.Count);

      result.ForEach(p => Assert.IsTrue(expected.Any(x => x.Coord.Equals(p.Coord) && x.Owner == p.Owner && x.PieceType == p.PieceType)));
    }

    [Test]
    public void CreatePiecesFromFen_RandomPosition()
    {
      var expected = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        },
      };

      var result = FenMapper.CreatePiecesFromFen("8/8/8/8/8/8/P2P1Pp1/R7");
      Assert.IsTrue(result.Count == expected.Count);

      result.ForEach(p => Assert.IsTrue(expected.Any(x => x.Coord.Equals(p.Coord) && x.Owner == p.Owner && x.PieceType == p.PieceType)));
    }

    [Test]
    public void CreatePiecesFromFen_EmptyString()
    {
      var expected = new List<Piece>();

      var result = FenMapper.CreatePiecesFromFen("");
      Assert.IsTrue(result.Count == expected.Count);
    }

    [Test]
    public void CreatePiecesFromFen_EmptyStringNoPieces()
    {
      var expected = new List<Piece>();

      var result = FenMapper.CreatePiecesFromFen("8/8/8/8/8/8/8/8/");
      Assert.IsTrue(result.Count == expected.Count);
    }


  }
}
