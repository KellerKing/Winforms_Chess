using Chess.Produktlogic.Contracts;

namespace Chess.Game
{
  class Helper
  {
    public static Player GetEnemy(Player playerCurrent)
    {
      return playerCurrent == Player.WHITE ? Player.BLACK : Player.WHITE;
    }

    //TODO: Eigentlich eine Factory Methode
    public static Coords[,] CreateFelder(int maxX, int maxY)
    {
      var tiles = new Coords[maxX, maxY];

      for (var file = 0; file < maxX; file++)
      {
        for (var rank = 0; rank < maxY; rank++)
        {
          tiles[file, rank] = new(file, rank);
        }
      }
      return tiles;
    }
  }
}
