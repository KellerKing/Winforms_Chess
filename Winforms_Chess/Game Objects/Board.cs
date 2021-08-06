using System.Collections.Generic;

namespace Winforms_Chess
{
  public class Board
  {
    public Tile[,] Felder { get; init; }

    public List<Pice> Pices { get; set; }

    public List<string> Moves { get; set; } = new List<string>()
    {
      "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
    };


    private static Board Instance;






    public static Board GetInstance()
    {
      if (Instance == null) Instance = new Board();
      return Instance;
    }

    public Board()
    {
      Felder = new Tile[8, 8];
      CreateFelder(8, 8);
    }

    private void CreateFelder(int x, int y)
    {

      for (int file = 0; file < x; file++)
      {
        for (int rank = 0; rank < y; rank++)
        {
          Felder[file, rank] = new Tile()
          {
            Coord = new Coords(file, rank)
          };
        }
      }
    }

    public List<Pice> CreatePosition(string fenString)
    {
      Pices = Fen.GetPices(fenString);
      return new List<Pice>(Pices);
    }


  }
}
