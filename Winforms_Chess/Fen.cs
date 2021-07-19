using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
  public class Fen
  {

    private static readonly Dictionary<char, PiceType> fenMapping = new Dictionary<char, PiceType>()
    {
      { 'K', PiceType.KING },

      { 'R', PiceType.ROOK },

      { 'B', PiceType.BISHOP },

      { 'N', PiceType.KNIGHT },

      { 'P', PiceType.PAWN },

      { 'Q', PiceType.QUEEN },

    };

    public static List<Pice> GetPices(string fen)
    {
      //rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
      var splitted = fen.Split(" ");
      var ranks = splitted[0].Split("/");
      var currentRank = 7;
      var currentFile = 0;

      var output = new List<Pice>();

      for (int i = 0; i < ranks.Length; i++)
      {
        var rank = ranks[i];

        for (int j = 0; j < rank.Length; j++)
        {
          if (Char.IsDigit(rank[j]))
          {
            currentFile += Convert.ToInt32(rank[j]);
            continue;
          }

          output.Add(new Pice(Char.IsUpper(rank[j]) ? Player.WHITE : Player.BLACK)
          {
            PiceType = fenMapping[Char.ToUpper(rank[j])],
            Coord = new Coords(currentRank, currentFile)
          });

           currentFile++; 
        }
        currentFile = 0;
        currentRank--;
      }
      return output;
    }


  }
}
