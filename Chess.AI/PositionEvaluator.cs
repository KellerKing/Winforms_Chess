using Chess.Produktlogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.AI
{
  internal class PositionEvaluator
  {
    public static int EvaluatePosition(List<Piece> childPosition)
    {
      var materialScore = CalculateMaterialScore(childPosition);
      var positionalScore = CalculatePositionalScore(childPosition);

      return positionalScore.Item1 + materialScore.Item1 - (positionalScore.Item2 + materialScore.Item2);
    }

    private static Tuple<int, int> CalculatePositionalScore(List<Piece> childPosition)
    {
      return new(0, 0);
      var materialScoreWhite = 0;
      var materialScoreBlack = 0;

      var valueCenter = 10000;

      var coordCenter = new List<Coords>
      {
        new(3,3),
        new(3,4),
        new(4,3),
        new(4,4),
      };
      var valueExtendedCenter = 5;
      var valueBorder = -5;

      materialScoreBlack += childPosition.Where(x => x.Owner == Player.BLACK && coordCenter.Contains(x.Coord)).Count() * valueCenter;
      materialScoreWhite += childPosition.Where(x => x.Owner == Player.WHITE && coordCenter.Contains(x.Coord)).Count() * valueCenter;

      return new(materialScoreWhite, materialScoreBlack);
    }

    private static Tuple<int, int> CalculateMaterialScore(List<Piece> childPosition)
    {
      return new(childPosition.Where(x => x.Owner == Player.WHITE).Sum(p => PieceInformation.VALUES[p.PiceType] * 100),
        childPosition.Where(x => x.Owner == Player.BLACK).Sum(p => PieceInformation.VALUES[p.PiceType] * 100));
    }
  }
}
