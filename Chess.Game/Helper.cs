using Chess.Contracts.Game;
using Chess.Game.Dto;

namespace Chess.Game
{
  class Helper
  {
    public static Konstanten.Player GetEnemy(Konstanten.Player playerCurrent)
    {
      return playerCurrent == Konstanten.Player.WHITE ? Konstanten.Player.BLACK : Konstanten.Player.WHITE;
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
