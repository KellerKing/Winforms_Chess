using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
  public class Board
  {
    public Tile[,] Felder { get; init; }

    private static Board Instance;



    public static Board GetInstance()
    {
      if (Instance == null) Instance = new Board();
      return Instance;
    }

    public Board()
    {
      Felder = new Tile[8, 8];
      createTiles(8, 8);
    }

    private void createTiles(int x, int y)
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


  }
}
