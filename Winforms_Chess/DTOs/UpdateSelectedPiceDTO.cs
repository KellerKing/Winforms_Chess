using System.Collections.Generic;

namespace Winforms_Chess.DTOs
{
  public record UpdateSelectedPiceDTO
  {
    public Pice SelectedPice { get; init; }
    public List<Coords> PossibleFelder { get; init; }
  }
}
