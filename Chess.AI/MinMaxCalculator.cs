using Chess.Produktlogic.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.AI
{
  public class MinMaxCalculator
  {
    private static readonly IChessLogicController m_LogicController = new Produktlogic.Controller();

    public static List<Piece> GetBestPosition(List<Piece> position, Player playerCurrent, int moveCounter, int depth)
    {
      var results = new List<Tuple<List<Piece>, int>>();

      var childPositions = GetAllChildPositions(position, playerCurrent);

      childPositions.ForEach(x => results.Add(new(x, PositionEvaluator.EvaluatePosition(x))));

      var start = Stopwatch.StartNew();

      //foreach (var child in childPositions)
      //{
      //  var score = GetMinMax(position, playerCurrent, int.MinValue, int.MaxValue, depth - 1).Result;
      //  results.Add(new(child, score));
      //}

      Parallel.ForEach(childPositions, async child =>
      {
        var score = await GetMinMax(position, playerCurrent, Int32.MinValue, Int32.MaxValue, depth - 1).ConfigureAwait(false);
        results.Add(new(child, score));
      });

      start.Stop();
      Debug.Print($"{start.ElapsedMilliseconds} ms");

      if(playerCurrent == Player.BLACK) 
        return results.First(x => x.Item2 == results.Min(x => x.Item2)).Item1;

      return results.First(x => x.Item2 == results.Max(x => x.Item2)).Item1;
    }


    private static async Task<int> GetMinMax(List<Piece> position, Player playerCurrent, int alpha, int beta, int depth)
    {
      var gameOverResult = m_LogicController.IsGameOver(position, playerCurrent);

      if (depth <= 0 || gameOverResult == GameOver.STATLEMENT) 
        return PositionEvaluator.EvaluatePosition(position);

      if (gameOverResult == GameOver.GAME_OVER)
        return playerCurrent == Player.WHITE ? int.MinValue : int.MaxValue;

      if (playerCurrent == Player.WHITE)
        return Max(position, alpha, beta, depth);

      return Min(position, alpha, beta, depth);
    }


    private static int Min(List<Piece> position, int alpha, int beta, int depth)
    {
      var minEval = int.MaxValue;

      foreach (var item in GetAllChildPositions(position, Player.WHITE))
      {
        var eval = GetMinMax(item, Player.WHITE, alpha, beta, depth-1).Result;
        minEval = Math.Min(minEval, eval);
        beta = Math.Min(beta, eval);

        if(beta <= alpha)
          break;
      }
      return minEval;
    }

    private static int Max(List<Piece> position, int alpha, int beta, int depth)
    {
      var maxEval = int.MinValue;

      foreach (var item in GetAllChildPositions(position, Player.WHITE))
      {
        var eval = GetMinMax(item, Player.BLACK, alpha, beta, depth - 1).Result;
        maxEval = Math.Max(maxEval, eval);
        alpha = Math.Max(alpha, eval);

        if (beta <= alpha)
          break;
      }
      return maxEval;
    }


    private static List<List<Piece>> GetEndpostionForSinglePiece(List<Piece> position, List<Coords> felderPossible, Piece pieceToMove)
    {
      var output = new List<List<Piece>>();

      foreach (var item in felderPossible)
      {
        var moveType = m_LogicController.GetMoveType(felderPossible, item, position.ConvertAll(x => (Piece)x.Clone()), pieceToMove, pieceToMove.Owner);
        var moveResult = m_LogicController.MakeAutomaticMove(moveType, pieceToMove.Coord, item, position.ConvertAll(x => (Piece)x.Clone()));

        if (!moveResult.WasMoveLegal) continue;

        output.Add(moveResult.BoardPosition);
      }
      return output;
    }

    private static List<List<Piece>> GetAllChildPositions(List<Piece> position, Player playerCurrent)
    {
      var output = new List<List<Piece>>();

      foreach (var item in position.Where(x => x.Owner == playerCurrent))
      {
        var felderPossible = m_LogicController.GetPossibleFelderForPiece(item, position);
        output.AddRange(GetEndpostionForSinglePiece(position, felderPossible, item));
      }
      return output.Where(x => x.Count != 0).ToList();
    }

  }
}
