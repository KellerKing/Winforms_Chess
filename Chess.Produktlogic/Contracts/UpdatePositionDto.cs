using System.Collections.Generic;

namespace Chess.Produktlogic.Contracts
{
  public record UpdatePositionDto
  {
    public List<Pice> BoardPosition { get; init; }
    public bool WasMoveLegal { get; init; }
    public List<Coords> PossibleFelder { get; set; }
  }
}
