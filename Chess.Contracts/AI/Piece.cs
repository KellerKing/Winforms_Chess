using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Contracts.AI
{
  public class Piece
  {
    public Piece(Player player)
    {
      Owner = player;
    }

    public Player Owner { get; init; }
    public PieceType PiceType { get; set; }
    public Coordinates Coord { get; set; }
    public int MoveCounter { get; set; }
  }
}
