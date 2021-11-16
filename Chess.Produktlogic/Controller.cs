using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public class Controller : IChessLogicController
  {
    public List<Coords> GetPossibleFelderForPice(Piece piceToCheck, List<Piece> boardPosition)
    {
      return PossibleMoveFactory.GetMovesFor(piceToCheck, boardPosition);
    }

    public UpdatePositionDto MakeCastleMove(List<Piece> pices, Coords clickedPice, Piece preselectedPice)
    {
      var newBoardPosition = Move.Castle(pices.Select(x => (Piece)x.Clone()).ToList(), preselectedPice.Coord, clickedPice);

      return new UpdatePositionDto
      {
        BoardPosition = newBoardPosition,
        PossibleFelder = new List<Coords>(),
        WasMoveLegal = Rulebook.IsLegalMove(newBoardPosition, preselectedPice.Owner),
      };
    }

    public UpdatePositionDto MakeCaptureMove(List<Piece> pices, Piece clickedPice, Piece preselectedPice)
    {
      var newBoardPosition = Move.CapturePice(pices.Select(x => (Piece)x.Clone()).ToList(), preselectedPice.Coord, clickedPice.Coord);
      
      return new UpdatePositionDto
      {
        BoardPosition = newBoardPosition,
        WasMoveLegal = Rulebook.IsLegalMove(newBoardPosition, preselectedPice.Owner),
        PossibleFelder = new List<Coords>(),
      };
    }

    public UpdatePositionDto MakeNonCaptureMove(List<Piece> pices, Coords clickedPice, Piece preselectedPice)
    {
      var newBoardPosition = Move.MakeNonCaptureMove(preselectedPice.Coord, clickedPice, pices.Select(x => (Piece)x.Clone()).ToList());

      return new UpdatePositionDto
      {
        BoardPosition = newBoardPosition,
        WasMoveLegal = Rulebook.IsLegalMove(newBoardPosition, preselectedPice.Owner),
        PossibleFelder = new List<Coords>(),
      };
    }

    public int GetScoring(List<Piece> pices, Player currentPlayer)
    {
      return ScoreCalculator.CalculateRelativeScore(pices, currentPlayer);
    }

    public GameOver IsGameOver(List<Piece> pices, Player currentPlayer)
    {
      if (Rulebook.HasPlayerLost(pices, currentPlayer)) return GameOver.GAME_OVER;
      else if (Rulebook.IsStatelement(pices, currentPlayer)) return GameOver.STATLEMENT;
      return GameOver.NO;
    }

    public MoveType GetMoveType(bool isPice, List<Coords> felderPossible, Coords coordsToCheck, List<Piece> pieces, Piece piecePreSelected, Player playerCurrent)
    {
      return Move.GetMoveType(isPice, felderPossible, coordsToCheck, pieces, piecePreSelected, playerCurrent);
    }
  }
}
