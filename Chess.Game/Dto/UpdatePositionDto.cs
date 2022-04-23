using System.Collections.Generic;

namespace Chess.Game.Dto
{
  internal class UpdatePositionDto
  {
    public List<Dto.Piece> BoardPosition { get; init; }
    public bool WasMoveLegal { get; init; }
    public List<Dto.Coords> PossibleFelder { get; set; }

  }
}
