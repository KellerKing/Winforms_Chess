using System;
using System.Collections.Generic;
using System.Linq;
using Winforms_Chess.Enums;

namespace Winforms_Chess
{
  public static class Move
  {
    public static List<Coords> GetMovesFor(Pice pice, List<Pice> pices)
    {
      return pice.PiceType switch
      {
        PiceType.KNIGHT => GetMovesForKnight(pice, pices),
        PiceType.QUEEN => GetMovesForQueen(pice, pices),
        PiceType.ROOK => GetMovesForRook(pice, pices),
        PiceType.BISHOP => GetMovesForBishop(pice, pices),
        PiceType.PAWN => GetMovesForPawn(pice, pices),
        PiceType.KING => GetMovesForKing(pice, pices),
        _ => throw new NotImplementedException(),
      };
    }


    private static List<Coords> GetMovesForKnight(Pice pice, List<Pice> pices)
    {
      var enemy = pice.Owner == Player.BLACK ? Player.WHITE : Player.BLACK;
      return new List<Coords>()
      {
        new Coords(pice.Coord.Rank - 2, pice.Coord.File - 1),
        new Coords(pice.Coord.Rank - 2, pice.Coord.File + 1),
        new Coords(pice.Coord.Rank + 2, pice.Coord.File - 1),
        new Coords(pice.Coord.Rank + 2, pice.Coord.File + 1),

        new Coords(pice.Coord.Rank - 1, pice.Coord.File - 2),
        new Coords(pice.Coord.Rank - 1, pice.Coord.File + 2),
        new Coords(pice.Coord.Rank + 1, pice.Coord.File - 2),
        new Coords(pice.Coord.Rank + 1, pice.Coord.File + 2),
      }
      .Where(x => (x.Rank >= 0 && x.Rank <= 7) && (x.File >= 0 && x.File <= 7)).ToList().Where(y => IsPiceBlocking(pices, y, enemy) != PiceBlockingReturn.OWN ).ToList();
    }

    private static List<Coords> GetMovesForKing(Pice pice, List<Pice> pices)
    {
      var enemy = pice.Owner == Player.BLACK ? Player.WHITE : Player.BLACK;

      return new List<Coords>()
      {
        new Coords(pice.Coord.Rank + 1, pice.Coord.File - 1),
        new Coords(pice.Coord.Rank + 1, pice.Coord.File),
        new Coords(pice.Coord.Rank + 1, pice.Coord.File + 1),

        new Coords(pice.Coord.Rank, pice.Coord.File + 1),
        new Coords(pice.Coord.Rank - 1, pice.Coord.File + 1),
        new Coords(pice.Coord.Rank - 1, pice.Coord.File),

        new Coords(pice.Coord.Rank, pice.Coord.File - 1),
        new Coords(pice.Coord.Rank - 1, pice.Coord.File - 1),

      }.Where(x => IsPiceBlocking(pices, x, enemy) != PiceBlockingReturn.OWN).ToList().Where(x => (x.Rank >= 0 && x.Rank <= 7) && (x.File >= 0 && x.File <= 7)).ToList();
    }


    private static List<Coords> GetMovesForPawn(Pice pice, List<Pice> pices)
    {
      var enemy = pice.Owner == Player.BLACK ? Player.WHITE : Player.BLACK;
      var felder = new List<Coords>();
      var possibleEnemys = new List<Pice>();

      if (enemy == Player.BLACK)
      {
        possibleEnemys = pices.Where(x => x.Owner == enemy && x.Coord.Rank == pice.Coord.Rank + 1 && (x.Coord.File - 1 == pice.Coord.File || x.Coord.File + 1 == pice.Coord.File)).ToList();
        felder.Add(new Coords(pice.Coord.Rank + 1, pice.Coord.File));
        if(pice.Coord.Rank == 1) felder.Add(new Coords(pice.Coord.Rank + 2, pice.Coord.File));
      }
      else
      {
        possibleEnemys = pices.Where(x => x.Owner == enemy && x.Coord.Rank == pice.Coord.Rank - 1 && (x.Coord.File - 1 == pice.Coord.File || x.Coord.File + 1 == pice.Coord.File)).ToList();
        felder.Add(new Coords(pice.Coord.Rank - 1, pice.Coord.File));
        if (pice.Coord.Rank == 6) felder.Add(new Coords(pice.Coord.Rank - 2, pice.Coord.File));
      }
      if(felder.Count > 0)
        felder.Remove(felder.FirstOrDefault(x => IsPiceBlocking(pices, x, enemy) != PiceBlockingReturn.NO));
      
      possibleEnemys.ForEach(x => felder.Add(x.Coord));
      felder.Add(Rulebook.GetEnPassant(pice, pices).NewPosition);
      return felder.Where(x => IsPiceBlocking(pices, x, enemy) != PiceBlockingReturn.OWN).ToList().Where(x => (x.Rank >= 0 && x.Rank <= 7) && (x.File >= 0 && x.File <= 7)).ToList();
    }

    private static List<Coords> GetMovesForBishop(Pice pice, List<Pice> pices)
    {
      var enemy = pice.Owner == Player.BLACK ? Player.WHITE : Player.BLACK;

      return GetDiagonals(pice, pices).Where(x => (x.Rank >= 0 && x.Rank <= 7) && (x.File >= 0 && x.File <= 7)).ToList();
    }

    private static List<Coords> GetMovesForRook(Pice pice, List<Pice> pices)
    {
      var enemy = pice.Owner == Player.BLACK ? Player.WHITE : Player.BLACK;
      var maxFile = 7;
      var maxRank = 7;

      var currentFile = pice.Coord.File;
      var currentRank = pice.Coord.Rank;

      var output = new List<Coords>();

      //Von Figur nach Rechts
      while (currentFile <= maxFile)
      {
        var coords = new Coords(currentRank, ++currentFile);
        var blocking = IsPiceBlocking(pices, coords, enemy);
        if (blocking == PiceBlockingReturn.ENEMY)
        {
          output.Add(coords);
          break;
        }
        else if (blocking == PiceBlockingReturn.OWN) break;
        else output.Add(coords);
      }

      currentFile = pice.Coord.File;

      //Von Figur nach Links
      while (currentFile >= 0)
      {
        var coords = new Coords(currentRank, --currentFile);
        var blocking = IsPiceBlocking(pices, coords, enemy);
        if (blocking == PiceBlockingReturn.ENEMY)
        {
          output.Add(coords);
          break;
        }
        else if (blocking == PiceBlockingReturn.OWN) break;
        else output.Add(coords);
      }


      //Von Figur nach Unten
      while (currentRank >= 0)
      {
        var coords = new Coords(--currentRank, pice.Coord.File);
        var blocking = IsPiceBlocking(pices, coords, enemy);
        if (blocking == PiceBlockingReturn.ENEMY)
        {
          output.Add(coords);
          break;
        }
        else if (blocking == PiceBlockingReturn.OWN) break;
        else output.Add(coords);
      }

      currentRank = pice.Coord.Rank;

      //Von Figur nach Unten
      while (currentRank <= maxRank)
      {
        var coords = new Coords(++currentRank, pice.Coord.File);
        var blocking = IsPiceBlocking(pices, coords, enemy);
        if (blocking == PiceBlockingReturn.ENEMY)
        {
          output.Add(coords);
          break;
        }
        else if (blocking == PiceBlockingReturn.OWN) break;
        else output.Add(coords);
      }

      return output.Where(x => (x.Rank >= 0 && x.Rank <= 7) && (x.File >= 0 && x.File <= 7)).ToList();
    }

    private static List<Coords> GetMovesForQueen(Pice pice, List<Pice> pices)
    {

      var tiles = new List<Coords>();
      tiles.AddRange(GetDiagonals(pice, pices));
      tiles.AddRange(GetMovesForRook(pice, pices));

      return tiles.Where(x => (x.Rank >= 0 && x.Rank <= 7) && (x.File >= 0 && x.File <= 7)).ToList();

    }

    private static PiceBlockingReturn IsPiceBlocking(List<Pice> pices, Coords coordsToCheck, Player enemy)
    {
      if (pices.Any(x => x.Owner == enemy && x.Coord.Equals(coordsToCheck))) return PiceBlockingReturn.ENEMY;
      else if (pices.Any(x => x.Owner != enemy && x.Coord.Equals(coordsToCheck))) return PiceBlockingReturn.OWN;

      return PiceBlockingReturn.NO;
    }

    //TODO: Implementieren
    private static List<Coords> FilterOutOfBoardPices(List<Coords> pices)
    {
      return pices.Where(x => (x.Rank >= 0 && x.Rank <= 7) && (x.File >= 0 && x.File <= 7)).ToList();
    }

    private static List<Coords> GetDiagonals(Pice pice, List<Pice> pices)
    {
      var enemy = pice.Owner == Player.BLACK ? Player.WHITE : Player.BLACK;
      var maxFile = 7;
      var maxRank = 7;

      var currentFile = pice.Coord.File;
      var currentRank = pice.Coord.Rank;

      var output = new List<Coords>();

      //Von Figur nach Rechts oben
      while (currentFile <= maxFile || currentRank <= maxRank)
      {
        var coords = new Coords(++currentRank, ++currentFile);
        var blocking = IsPiceBlocking(pices, coords, enemy);

        if (blocking == PiceBlockingReturn.ENEMY)
        {
          output.Add(coords);
          break;
        }
        else if (blocking == PiceBlockingReturn.OWN) break;
        else output.Add(coords);
      }

      currentFile = pice.Coord.File;
      currentRank = pice.Coord.Rank;

      //Von Figur nach Links unten
      while (currentFile >= 0 || currentRank >= 0)
      {
        var coords = new Coords(--currentRank, --currentFile);
        var blocking = IsPiceBlocking(pices, coords, enemy);
        if (blocking == PiceBlockingReturn.ENEMY)
        {
          output.Add(coords);
          break;
        }
        else if (blocking == PiceBlockingReturn.OWN) break;
        else output.Add(coords);
      }

      currentFile = pice.Coord.File;
      currentRank = pice.Coord.Rank;


      //Von Figur nach Links oben
      while (currentFile >= 0 || currentRank <= maxRank)
      {
        var coords = new Coords(++currentRank, --currentFile);
        var blocking = IsPiceBlocking(pices, coords, enemy);
        if (blocking == PiceBlockingReturn.ENEMY)
        {
          output.Add(coords);
          break;
        }
        else if (blocking == PiceBlockingReturn.OWN) break;
        else output.Add(coords);
      }

      currentFile = pice.Coord.File;
      currentRank = pice.Coord.Rank;

      //Von Figur nach Rechts unten
      while (currentFile <= maxFile || currentRank >= 0)
      {
        var coords = new Coords(--currentRank, ++currentFile);
        var blocking = IsPiceBlocking(pices, coords, enemy);
        if (blocking == PiceBlockingReturn.ENEMY)
        {
          output.Add(coords);
          break;
        }
        else if (blocking == PiceBlockingReturn.OWN) break;
        else output.Add(coords);
      }


      return output;

    }

  }
}
