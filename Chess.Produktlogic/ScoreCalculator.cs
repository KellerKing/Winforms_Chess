using Chess.Contracts.Productlogic;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public class ScoreCalculator
  {
    public static int CalculateRelativeScore(List<Piece> pices, Player currentPlayer)
    {
      if (pices == null) return 0;

      var scoreForPlayer = pices.Where(x => x.Owner == currentPlayer)
        .Sum(x => PieceValueInformation.VALUES[x.PiceType]);

      var scoreForEnemy = pices.Where(x => x.Owner != currentPlayer)
        .Sum(x => PieceValueInformation.VALUES[x.PiceType]);

      return scoreForPlayer - scoreForEnemy;
    }
  }
}
