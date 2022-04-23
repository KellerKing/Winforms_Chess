using Chess.Contracts.AI;
using System.Collections.Generic;

namespace Chess.AI
{
  public class Controller : IChessAIController
  {
    private int m_MoveCounter;
    private int m_difficulty;

    private List<List<Piece>> m_PreCalculatedPositions;

    public Controller(int difficulty)
    {
      m_PreCalculatedPositions = new List<List<Piece>>();
      m_difficulty = difficulty;
    }

    public Controller()
    {

    }

    public List<Piece> GetBestMove(List<Piece> pieces, Player playerCurrent, int depth)
    {
      return MinMaxCalculator.GetBestPosition(pieces, playerCurrent, m_MoveCounter, depth);
    }
  }
}
