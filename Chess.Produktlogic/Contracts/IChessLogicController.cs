using System.Collections.Generic;

namespace Chess.Produktlogic.Contracts
{
  public interface IChessLogicController
  {
    List<Coords> GetPossibleFelderForPice(Pice piceToCheck, List<Pice> boardPosition);
    UpdatePositionDto MakeCaptureMove(List<Pice> pices, Pice clickedPice, Pice preselectedPice);
    UpdatePositionDto MakeNonCaptureMove(List<Pice> pices, Coords clickedPice, Pice preselectedPice);
    UpdatePositionDto MakeCastleMove(List<Pice> pices, Coords clickedPice, Pice preselectedPice);
    int GetScoring(List<Pice> pices, Player currentPlayer, int startScore);
    bool IsGameOver(List<Pice> pices, Player currentPlayer);
  }
}
