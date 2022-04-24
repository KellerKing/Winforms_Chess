using Chess.Contracts.Productlogic;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Productlogic
{
  public class ScoreCalculator
  {
    public static int CalculateRelativeScore(List<Piece> pices, Player currentPlayer)
    {
      if (pices == null) return 0;

      var scoreForPlayer = pices.Where(x => x.Owner == currentPlayer)
        .Sum(x => PieceInformation.VALUES[x.PieceType]);

      var scoreForEnemy = pices.Where(x => x.Owner != currentPlayer)
        .Sum(x => PieceInformation.VALUES[x.PieceType]);

      return scoreForPlayer - scoreForEnemy;
    }
  }
}
