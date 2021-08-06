using System.Collections.Generic;

namespace Winforms_Chess.DTOs
{
  public record UpdatePositionDTO
  {
    public List<Pice> BoardPosition { get; init; }
    public bool WasMoveLegal { get; init; }
    public bool WasFullMove { get; set; }
    public Pice SelectedPice { get; init; }
    public List<Coords> PossibleFelder { get; set; }
  }
}
