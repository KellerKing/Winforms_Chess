using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public class Controller : IChessLogicController
  {
    public List<Coords> GetPossibleFelderForPice(Pice piceToCheck, List<Pice> boardPosition)
    {
      return PossibleMoveFactory.GetMovesFor(piceToCheck, boardPosition);
    }

    public UpdatePositionDto MakeCastleMove(List<Pice> pices, Coords clickedPice, Pice preselectedPice)
    {
      var newBoardPosition = Move.Castle(pices.Select(x => (Pice)x.Clone()).ToList(), preselectedPice.Coord, clickedPice);

      return new UpdatePositionDto
      {
        BoardPosition = newBoardPosition,
        PossibleFelder = new List<Coords>(),
        WasMoveLegal = Rulebook.IsLegalMove(newBoardPosition, preselectedPice.Owner),
      };
    }

    public UpdatePositionDto MakeCaptureMove(List<Pice> pices, Pice clickedPice, Pice preselectedPice)
    {
      var newBoardPosition = Move.CapturePice(pices.Select(x => (Pice)x.Clone()).ToList(), preselectedPice.Coord, clickedPice.Coord);
      
      return new UpdatePositionDto
      {
        BoardPosition = newBoardPosition,
        WasMoveLegal = Rulebook.IsLegalMove(newBoardPosition, preselectedPice.Owner),
        PossibleFelder = new List<Coords>(),
      };
    }

    public UpdatePositionDto MakeNonCaptureMove(List<Pice> pices, Coords clickedPice, Pice preselectedPice)
    {
      var newBoardPosition = Move.MakeNonCaptureMove(preselectedPice.Coord, clickedPice, pices.Select(x => (Pice)x.Clone()).ToList());

      return new UpdatePositionDto
      {
        BoardPosition = newBoardPosition,
        WasMoveLegal = Rulebook.IsLegalMove(newBoardPosition, preselectedPice.Owner),
        PossibleFelder = new List<Coords>(),
      };
    }

    public int GetScoring(List<Pice> pices, Player currentPlayer)
    {
      return ScoreCalculator.CalculateRelativeScore(pices, currentPlayer);
    }

    public bool IsGameOver(List<Pice> pices, Player currentPlayer)
    {
      var filteredPices = pices.Where(x => x.Owner == currentPlayer);
      foreach (var _ in filteredPices.Where(item => PossibleMoveFactory.GetMovesFor(item, pices, false).Count != 0).Select(item => new { }))
      {
        return false;
      }
      return true;
    }
  }
}
