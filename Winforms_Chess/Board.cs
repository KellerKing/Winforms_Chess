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
      var rowName = 1;
      var colName = 'a';


      for (int i = 0; i < x; i++)
      {
        for (int j = 0; j < y; j++)
        {
          Felder[i, j] = new Tile()
          {
            Number = $"{colName++}{rowName}"
          };
        }
        rowName++;
        colName = 'a';
      }
    }

    public List<Pice> CreatePosition(string fenString)
    {
      return Fen.GetPices(fenString);
    }


  }
}
