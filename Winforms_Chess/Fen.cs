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


    public static string CreateFenFromPices(List<Pice> pices, int rank, string fen = "")
    {
      if (rank == 0) return fen;

      var rankPices = pices.Where(x => x.Coord.Rank == rank).OrderBy(y => y.Coord.File).ToList();

      for (int i = 1; i < rankPices.Count - 1; i++)
      {
        if (rankPices[i-1].Coord.File == i)
        {
          fen += rankPices[i - 1].Owner == Player.BLACK ?
            Char.ToLower(fenMapping.First(x => x.Value == rankPices[i - 1].PiceType).Key) :
            fenMapping.First(x => x.Value == rankPices[i - 1].PiceType).Key;
          continue;
        }

        fen += (rankPices[i - 1].Coord.File - 1).ToString();

      }

      return CreateFenFromPices(pices, rank--, fen);
    }

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
