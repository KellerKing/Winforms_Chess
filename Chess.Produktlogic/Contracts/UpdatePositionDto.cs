using System.Collections.Generic;

namespace Chess.Produktlogic.Contracts
{
  public record UpdatePositionDto
  {
    public List<Piece> BoardPosition { get; init; }
    public bool WasMoveLegal { get; init; }
    public List<Coords> PossibleFelder { get; set; }
  }
}
