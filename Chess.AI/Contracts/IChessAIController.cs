using Chess.Produktlogic.Contracts;
using System.Collections.Generic;

namespace Chess.AI.Contracts
{
  public interface IChessAIController
  {
    public List<Piece> GetBestMove(List<Piece> pieces, Player playerCurrent, int depth);
  }
}
