using Chess.Contracts.AI;
using Chess.Game.Converter;
using Chess.Game.Converter.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Game.Connector
{
  internal class AiConnector
  {
    private readonly IAiConverter m_AiConverter;
    private readonly IChessAIController m_AiController;

    public AiConnector(IChessAIController aiController)
    {
      m_AiConverter = new AiConverter();
      m_AiController = aiController;
    }

    public List<Dto.Piece> GetBestMove(List<Dto.Piece> currentPosistion, Konstanten.Player player, int depth)
    {
      var convertedCurrentPosition = m_AiConverter.ConvertPieces(currentPosistion).ToList();
      var convertedPlayer = m_AiConverter.ConvertPlayer(player);

      var bestMove = m_AiController.GetBestMove(convertedCurrentPosition, convertedPlayer, depth);

      return m_AiConverter.ConvertPieces(bestMove).ToList();
    }

    public bool HasAiController()
    {
      return m_AiController != null;
    }
  }
}
