using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public class ScoreCalculator
  {
    public static int CalculateRelativeScore(List<Pice> pices, Player currentPlayer)
    {
      if (pices == null) return 0;

      var scoreForPlayer = pices.Where(x => x.Owner == currentPlayer)
        .Sum(x => PiceInformationHandler.GetPiceInformation(x.PiceType).Value);

      var scoreForEnemy = pices.Where(x => x.Owner != currentPlayer)
        .Sum(x => PiceInformationHandler.GetPiceInformation(x.PiceType).Value);

      return scoreForPlayer - scoreForEnemy;
    }
  }
}
