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
    public void CreateFenFromPices_StartPosition()
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

      var expected = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

      var result = FenMapper.CreateFenFromPices(test, Player.WHITE);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPices_SinglePiece()
    {
      var test = new List<Piece>
      {
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.A1,
          PieceType = PieceType.ROOK
        }
      };

      var expected = "8/8/8/8/8/8/8/R7";

      var result = FenMapper.CreateFenFromPices(test, Player.WHITE);

      Assert.AreEqual(expected, result);
    }

    [Test]
    public void CreateFenFromPices_LeereListe()
    {
      var test = new List<Piece>();

      var expected = "8/8/8/8/8/8/8/8";

      var result = FenMapper.CreateFenFromPices(test, Player.WHITE);

      Assert.AreEqual(expected, result);
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
