using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public class ScoreCalculator
  {
    public static int CalculateScore(List<Pice> pices , Player currentPlayer, int startScore)
    {
      return startScore - pices.Where(x => x.Owner == currentPlayer)
        .Sum(x => PiceInformationHandler.GetPiceInformation(x.PiceType).Value);
    }
  }
}
