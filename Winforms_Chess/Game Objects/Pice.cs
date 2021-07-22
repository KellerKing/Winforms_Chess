using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
  public class Pice
  {

    public Pice(Player player)
    {
      Owner = player;
    }

    public Player Owner { get; init; }
    public PiceType PiceType { get; init; }
    public Coords Coord { get; set; }
  }
}
