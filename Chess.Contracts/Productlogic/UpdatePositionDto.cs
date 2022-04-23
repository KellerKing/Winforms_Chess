using System.Collections.Generic;

namespace Chess.Contracts.Productlogic
{
  public record UpdatePositionDto
  {
    public List<Piece> BoardPosition { get; init; }
    public bool WasMoveLegal { get; init; }
    public List<Coords> PossibleFelder { get; set; }
  }
}
