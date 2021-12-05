using Chess.Produktlogic.Contracts;

namespace Chess.AI
{
  internal class Controller : IChessAIController
  {
    private readonly int m_SearchDepth;
    public Controller(int searchDepth)
    {
      m_SearchDepth = searchDepth;
    }

    public List<Piece> GetBestMove(List<Piece> pieces, Player playerCurrent)
    {
      var x = new Chess.Produktlogic.Controller();
      var rnd = new Random();
      var possibleMoves = new List<Coords>();
      do
      {
        var piecesPlayer = pieces.Where(p => p.Owner == playerCurrent).ToList();
        var moves = x.GetPossibleFelderForPiece(piecesPlayer[rnd.Next(piecesPlayer.Count)], pieces.ConvertAll(x => (Piece)x.Clone()).ToList());
        var moveSelected = x.GetMoveType(x.)
      } while (possibleMoves.Count > 0);
    }
  }
}
