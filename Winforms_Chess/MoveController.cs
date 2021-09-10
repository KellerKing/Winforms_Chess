using System;
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
          var possibleFields = Move.GetMovesFor(clickedPice, pices);
          
          return new UpdatePositionDTO()
          {
            BoardPosition = pices,
            PossibleFelder = possibleFields,
            SelectedPice = clickedPice,
            WasMoveLegal = true
          };

        }
        else if (possibleFelder.Any(x => x.Equals(clickedCoords)))
        {
          var newBoardPosition = CapturePice(pices.Select(x => (Pice)x.Clone()).ToList(), preselectedPice, clickedCoords);

          return new UpdatePositionDTO()
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
        var newBoardPosition = MakeNonCaptureMove(preselectedPice, clickedCoords, pices.Select(x => (Pice)x.Clone()).ToList());
        
        return new UpdatePositionDTO()
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
    //TODO: Die kann raus
    private static UpdateSelectedPiceDTO UpdatePossibleFelderAndSelectedPice(Pice clickedPice, List<Pice> pices)
    {
      return new UpdateSelectedPiceDTO()
      {
        SelectedPice = clickedPice,
        PossibleFelder = Move.GetMovesFor(clickedPice, pices)
      };
    }

    private static List<Pice> CapturePice(List<Pice> pices, Pice selectedPice, Coords newPosition)
    {
      pices.Remove(pices.First(x => x.Coord.Equals(newPosition)));
      pices.First(x => x.Coord.Equals(selectedPice.Coord)).Coord = newPosition;
      return pices;
    }

    private static List<Pice> MakeNonCaptureMove(Pice selectedPice, Coords newPosition, List<Pice> pices)
    {
      pices.First(x => x.Coord.Equals(selectedPice.Coord)).Coord = newPosition;
      return pices;
    }
  }
}
