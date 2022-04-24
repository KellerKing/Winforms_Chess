using Chess.Contracts.Productlogic;
using Chess.Productlogic.Factory;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace Chess.Productlogic.Test
{
  [TestFixture]
  public class PossibleMoveFactory_Tests
  {
    [Test]
    [TestCase]
    public void GetMovesFor_TestKnight_CenterPosition2Possibles()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = new Coords(4, 4),
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK) //Rechts oben --> geht nicht
        {
          Coord = new Coords(6, 5),
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE) //Links unten --> geht
        {
          Coord = new Coords(2, 3),
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE) //Links oben --> geht
        {
          Coord = new Coords(6, 3),
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.BLACK) // Rechts unten --> geht nicht
        {
          Coord = new Coords(2, 5),
          PieceType = PieceType.QUEEN
        }
      };
      var expected = new List<Coords>()
      {
        new Coords(2,3),
        new Coords(6,3),
        Feldbezeichnung.C6,
        Feldbezeichnung.G6,
        Feldbezeichnung.G4,
        Feldbezeichnung.C4,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      foreach (var item in expected)
      {
        Assert.Contains(item, result);
      }
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestKnight_CenterPositionNoBlockingPicesAllEnemies()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = new Coords(4, 4),
          PieceType = PieceType.KNIGHT
        },
        new Piece(Player.WHITE) //Rechts oben --> geht
        {
          Coord = new Coords(6, 5),
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE) //Links unten --> geht
        {
          Coord = new Coords(2, 3),
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE) //Links oben --> geht
        {
          Coord = new Coords(6, 3),
          PieceType = PieceType.KNIGHT
        },
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.C6,
        Feldbezeichnung.G6,
        Feldbezeichnung.G4,
        Feldbezeichnung.C4,
        Feldbezeichnung.F3,
        Feldbezeichnung.D3,
        Feldbezeichnung.F7,
        Feldbezeichnung.D7,
      }.OrderBy(x => x.File).ToList();
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup).OrderBy(x => x.File).ToList();
      foreach (var item in expected)
      {
        Assert.Contains(item, result);
      }
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestKnight_H1PositionNoBlockingPices()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = new Coords(0, 7),
          PieceType = PieceType.KNIGHT
        }
      };
      var expected = new List<Coords>()
      {
        new Coords(2,6),
        new Coords(1,5)
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      foreach (var item in expected)
      {
        Assert.Contains(item, result);
      }
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestQueen_E5AllPositionsArePossible()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = new Coords(4, 4),
          PieceType = PieceType.QUEEN
        }
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.F5,
        Feldbezeichnung.E4,
        Feldbezeichnung.D5,
        Feldbezeichnung.E6,
        Feldbezeichnung.F4,
        Feldbezeichnung.G3,
        Feldbezeichnung.H2,
        Feldbezeichnung.D4,
        Feldbezeichnung.C3,
        Feldbezeichnung.B2,
        Feldbezeichnung.A1,
        Feldbezeichnung.D6,
        Feldbezeichnung.C7,
        Feldbezeichnung.B8,
        Feldbezeichnung.F6,
        Feldbezeichnung.G7,
        Feldbezeichnung.H8,
        Feldbezeichnung.G5,
        Feldbezeichnung.H5,
        Feldbezeichnung.C5,
        Feldbezeichnung.B5,
        Feldbezeichnung.A5,
        Feldbezeichnung.E7,
        Feldbezeichnung.E8,
        Feldbezeichnung.E3,
        Feldbezeichnung.E2,
        Feldbezeichnung.E1,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestQueen_E5ArroundingIsBlockingDiagonalsAreEnemys()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = new Coords(4, 4),
          PieceType = PieceType.QUEEN
        },
        new Piece(Player.BLACK) //Pice to Block
        {
         Coord =  new Coords(5,3),
          PieceType = PieceType.PAWN
        },
         new Piece(Player.BLACK) //Pice to Block
        {
          Coord = new Coords(5,4),
          PieceType = PieceType.PAWN
        },
         new Piece(Player.BLACK) //Pice to Block
        {
          Coord = new Coords(4,5),
          PieceType = PieceType.PAWN
        },
         new Piece(Player.BLACK) //Pice to Block
        {
          Coord = new Coords(3,4),
          PieceType = PieceType.PAWN
        },
         new Piece(Player.WHITE) //Enemy --> geht, aber weiter geht die Diagonale nicht (nach links unten)
        {
          Coord = new Coords(3,3),
          PieceType = PieceType.PAWN
        },
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.D4,
        Feldbezeichnung.D5,
        Feldbezeichnung.C5,
        Feldbezeichnung.B5,
        Feldbezeichnung.A5,
        Feldbezeichnung.F6,
        Feldbezeichnung.G7,
        Feldbezeichnung.H8,
        Feldbezeichnung.F4,
        Feldbezeichnung.G3,
        Feldbezeichnung.H2,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestQueen_H1()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.QUEEN
        }
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.H2,
        Feldbezeichnung.H3,
        Feldbezeichnung.H4,
        Feldbezeichnung.H5,
        Feldbezeichnung.H6,
        Feldbezeichnung.H7,
        Feldbezeichnung.H8,
        Feldbezeichnung.G1,
        Feldbezeichnung.F1,
        Feldbezeichnung.E1,
        Feldbezeichnung.D1,
        Feldbezeichnung.C1,
        Feldbezeichnung.B1,
        Feldbezeichnung.A1,
        Feldbezeichnung.G2,
        Feldbezeichnung.F3,
        Feldbezeichnung.E4,
        Feldbezeichnung.D5,
        Feldbezeichnung.C6,
        Feldbezeichnung.B7,
        Feldbezeichnung.A8,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestKing_E5AllPossible()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = new Coords(4, 4),
          PieceType = PieceType.KING
        }
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.E6,
        Feldbezeichnung.F6,
        Feldbezeichnung.F5,
        Feldbezeichnung.F4,
        Feldbezeichnung.E4,
        Feldbezeichnung.D4,
        Feldbezeichnung.D5,
        Feldbezeichnung.D6,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestKing_E5EnemysOnDiagonalsAn1OwnPawnOnBottom()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = new Coords(4, 4),
          PieceType = PieceType.KING
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D6,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F6,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F4,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D4,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.E6,
        Feldbezeichnung.F6,
        Feldbezeichnung.F5,
        Feldbezeichnung.F4,
        Feldbezeichnung.D4,
        Feldbezeichnung.D5,
        Feldbezeichnung.D6,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestKing_H1NoOtherPices()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.KING
        },
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.G1,
        Feldbezeichnung.G2,
        Feldbezeichnung.H2
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_E5EnemysOnF6D6AndOwnPawnOnE6_AsWhite()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN
        },
         new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E6,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F6,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D6,
          PieceType = PieceType.PAWN
        },
      };
      var expected = new List<Coords>()
      {
       Feldbezeichnung.F6,
       Feldbezeichnung.D6
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_E5EnemysOnF6OwnOnD6_AsWhite()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN
        },
         new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.D6,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.F6,
          PieceType = PieceType.PAWN
        },
      };
      var expected = new List<Coords>()
      {
       Feldbezeichnung.E6,
       Feldbezeichnung.D6,
       Feldbezeichnung.F6
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_E5_AsWhite()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>()
      {
       Feldbezeichnung.E6
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_E8_AsWhite()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.E8,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>();
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_B2_AsWhite_CanForward2Fields()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>
      {
        Feldbezeichnung.B3,
        Feldbezeichnung.B4
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_B2_AsWhite_1EnemyInFront()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.B2,
          PieceType = PieceType.PAWN
        },
         new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.B4,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>
      {
        Feldbezeichnung.B3,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_G7_AsBlack_CanForward2Fields()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>
      {
        Feldbezeichnung.G6,
        Feldbezeichnung.G5
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_G7_AsBlack_1EnemyInFront()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = Feldbezeichnung.G7,
          PieceType = PieceType.PAWN
        },
         new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.G5,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>
      {
        Feldbezeichnung.G6,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_E5EnemysOnF4D4AndOnE4_AsBlack()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN
        },
         new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F4,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D4,
          PieceType = PieceType.PAWN
        },
      };
      var expected = new List<Coords>()
      {
       Feldbezeichnung.F4,
       Feldbezeichnung.D4
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_E5EnemysOnF4OwnOnD4_AsBlack()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN
        },
         new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F4,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.D4,
          PieceType = PieceType.PAWN
        },
      };
      var expected = new List<Coords>()
      {
       Feldbezeichnung.E4,
       Feldbezeichnung.D4,
       Feldbezeichnung.F4
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_E5_AsBlack()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>()
      {
       Feldbezeichnung.E4
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_E1_AsBlack()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.BLACK) //Pice to test
        {
          Coord = Feldbezeichnung.E1,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>()
      {
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_EnPassantPossible()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.B5,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C5,
          PieceType = PieceType.PAWN,
          MoveCounter = 1
        }
      };
      var expected = new List<Coords>
      {
        Feldbezeichnung.C6,
        Feldbezeichnung.B6
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestPawn_EnPassantNotPossibleEnemyHasMovedTwice()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.B5,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.C5,
          PieceType = PieceType.PAWN,
          MoveCounter = 2
        }
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.B6
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestBishop_G2()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.BISHOP
        }
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.H1,
        Feldbezeichnung.F1,
        Feldbezeichnung.H3,
        Feldbezeichnung.F3,
        Feldbezeichnung.E4,
        Feldbezeichnung.D5,
        Feldbezeichnung.C6,
        Feldbezeichnung.B7,
        Feldbezeichnung.A8,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestBishop_G2_OwnE4EnemyH3()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.G2,
          PieceType = PieceType.BISHOP
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.E4,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H3,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.H1,
        Feldbezeichnung.F1,
        Feldbezeichnung.H3,
        Feldbezeichnung.F3,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestRook_H1_OwnF1EnemyH3()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.H1,
          PieceType = PieceType.ROOK
        },
        new Piece(Player.WHITE)
        {
          Coord = Feldbezeichnung.F1,
          PieceType = PieceType.PAWN
        },
        new Piece(Player.BLACK)
        {
          Coord = Feldbezeichnung.H3,
          PieceType = PieceType.PAWN
        }
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.H2,
        Feldbezeichnung.G1,
        Feldbezeichnung.H3,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
    [Test]
    [TestCase]
    public void GetMovesFor_TestRook_E5_NoOtherPices()
    {
      var boardSetup = new List<Piece>()
      {
        new Piece(Player.WHITE) //Pice to test
        {
          Coord = Feldbezeichnung.E5,
          PieceType = PieceType.ROOK
        },
      };
      var expected = new List<Coords>()
      {
        Feldbezeichnung.F5,
        Feldbezeichnung.G5,
        Feldbezeichnung.H5,
        Feldbezeichnung.D5,
        Feldbezeichnung.C5,
        Feldbezeichnung.B5,
        Feldbezeichnung.A5,
        Feldbezeichnung.E4,
        Feldbezeichnung.E3,
        Feldbezeichnung.E2,
        Feldbezeichnung.E1,
        Feldbezeichnung.E6,
        Feldbezeichnung.E7,
        Feldbezeichnung.E8,
      };
      var result = PossibleMoveFactory.GetMovesFor(boardSetup.First(), boardSetup);
      CollectionAssert.AreEquivalent(result, expected);
    }
  }
}
