using System.Collections.Generic;
using System.Linq;
using Winforms_Chess.DTOs;

namespace Winforms_Chess
{
  public static class MoveController
  {

    public static UpdatePositionDTO MakeMove(bool isPice, List<Pice> pices, Coords clickedCoords, Player currentPlayer, List<Coords> possibleFelder, Pice preselectedPice)
    {
      if (isPice)
      {
        var clickedPice = pices.FirstOrDefault(x => x.Coord.Equals(clickedCoords));

        if (clickedPice.Owner == currentPlayer)
        {
          possibleFelder = Move.GetMovesFor(clickedPice, pices);

          return new UpdatePositionDTO
          {
            BoardPosition = pices,
            PossibleFelder = possibleFelder,
            SelectedPice = clickedPice,
            WasMoveLegal = true
          };
        }

        else if (possibleFelder.Any(x => x.Equals(clickedCoords)))
        {
          var newBoardPosition = CapturePice(pices.Select(x => (Pice)x.Clone()).ToList(), preselectedPice.Coord, clickedCoords);

          return new UpdatePositionDTO
          {
            BoardPosition = newBoardPosition,
            SelectedPice = null,
            PossibleFelder = new List<Coords>(),
            WasFullMove = true,
            WasMoveLegal = Rulebook.IsLegalMove(newBoardPosition, currentPlayer)
          };
        }
      }

      else if (preselectedPice != null && possibleFelder.Any(x => x.Equals(clickedCoords)))
      {
        var newBoardPosition = MakeNonCaptureMove(preselectedPice.Coord, clickedCoords, pices.Select(x => (Pice)x.Clone()).ToList());

        return new UpdatePositionDTO
        {
          BoardPosition = newBoardPosition,
          WasMoveLegal = Rulebook.IsLegalMove(newBoardPosition, currentPlayer),
          WasFullMove = true,
          PossibleFelder = new List<Coords>(),
          SelectedPice = null
        };
        //Ist ein Spielzug: Vorher wurde eine Figur gewählt und dann ein Feld
      }

      return new UpdatePositionDTO();
    }

    private static List<Pice> CapturePice(List<Pice> pices, Coords oldPosition, Coords newPosition)
    {
      pices.Remove(pices.First(x => x.Coord.Equals(newPosition)));
      var selectedPice = pices.First(x => x.Coord.Equals(oldPosition));
      selectedPice.Coord = newPosition;
      selectedPice.MoveCounter++;
      return pices;
    }

    private static List<Pice> MakeNonCaptureMove(Coords oldPosition, Coords newPosition, List<Pice> pices)
    {
      var selectedPice = pices.First(x => x.Coord.Equals(oldPosition));

      var enPassant = Rulebook.GetEnPassant(selectedPice, pices);

      if (enPassant.NewPosition.Equals(newPosition)) pices.Remove(pices.First(x => x.Coord.Equals(enPassant.PiceToCapture)));
      selectedPice.Coord = newPosition;
      selectedPice.MoveCounter++;
      return pices;
    }
  }
}
