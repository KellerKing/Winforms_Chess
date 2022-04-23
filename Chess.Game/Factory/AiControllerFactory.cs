using Chess.Contracts.AI;

namespace Chess.Game.Factory
{
  internal class AiControllerFactory
  {
    public static IChessAIController GetChessAIController(bool isSingelplayer) //TODO: Hier bekommt der später noch das InputDto
    {
      if (isSingelplayer) return new AI.Controller();
      return null;
    }
  }
}
