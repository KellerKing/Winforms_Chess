using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Contracts.Game
{
  public class InputDto
  {
    public bool IsSingleplayer { get; set; }
    public Player StartingPlayer { get; set; }

  }
}
