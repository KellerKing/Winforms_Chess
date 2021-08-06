using System.Collections.Generic;
using System.Linq;
using Winforms_Chess.DTOs;

namespace Winforms_Chess
{
  public static class MoveController
  {

    public static UpdatePositionDTO MakeMove(bool isPice, List<Pice> pices, Coords coords, Player currentPlayer, List<Coords> possibleFelder, Pice preselectedPice)
    {
      if (isPice)
      {
        var clickedPice = (Pice)pices.First(x => x.Coord.Equals(coords)).Clone();

        if (clickedPice.Owner == currentPlayer)
        {
          var result = UpdatePossibleFelderAndSelectedPice(clickedPice, pices);

          return new UpdatePositionDTO()
          {
            BoardPosition = pices,
            PossibleFelder = result.PossibleFelder,
            SelectedPice = result.SelectedPice,
            WasMoveLegal = true
          };

        }
        else if (possibleFelder.Any(x => x.Equals(preselectedPice.Coord)))
        {
          return new UpdatePositionDTO()
          {
            BoardPosition = CapturePice(pices, preselectedPice, coords),
            SelectedPice = null,
            PossibleFelder = new List<Coords>(),
            WasFullMove = true,
            WasMoveLegal = true
          }; //TODO: Vielleicht noch WasCaptureMove oder So. Aber generell bin ich mit dem Ablauf nicht ganz zufrieden. Ich glaub da könnte man gut was vereifnachen. Auch das mit den 2 Bools ist eher so suboptimal. Zumal der 1. Fall ja technisch kein Move ist
        }
      }

      else if (preselectedPice != null && possibleFelder.Any(x => x.Equals(coords)))
      {
        return new UpdatePositionDTO()
        {
          BoardPosition = MakeNonCaptureMove(preselectedPice, coords, pices),
          WasMoveLegal = true,
          WasFullMove = true,
          PossibleFelder = new List<Coords>(),
          SelectedPice = null
        };
        
        //Ist ein Spielzug: Vorher wurde eine Figur gewählt und dann ein Feld
      }

      return new UpdatePositionDTO();
    }

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
      selectedPice.Coord = newPosition;
      return pices;
    }

    private static List<Pice> MakeNonCaptureMove(Pice selectedPice, Coords newPosition, List<Pice> pices)
    {
      selectedPice.Coord = newPosition;
      return pices;
    }
  }
}
