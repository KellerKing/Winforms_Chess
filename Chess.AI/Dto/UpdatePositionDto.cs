using Chess.Contracts.AI;
using System.Collections.Generic;

namespace Chess.AI.Dto
{
  internal class UpdatePositionDto
  {
    public bool WasLegalMove { get; set; }
    public List<Piece> BoardPosition { get; set; }
  }
}
