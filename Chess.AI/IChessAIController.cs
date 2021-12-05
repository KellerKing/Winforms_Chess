using Chess.Produktlogic.Contracts;

namespace Chess.AI
{
  public interface IChessAIController
  {
    public List<Piece> GetBestMove(List<Piece> pieces, Player playerCurrent);
  }
}
