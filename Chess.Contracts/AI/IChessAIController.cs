using System.Collections.Generic;

namespace Chess.Contracts.AI
{
  public interface IChessAIController
  {
    public List<Piece> GetBestMove(List<Piece> pieces, Player playerCurrent, int depth);
  }
}
