using System;
using Winforms_Chess.Game_Objects;

namespace Winforms_Chess
{
  public class Pice : IGameObject, ICloneable
  {

    public Pice(Player player)
    {
      Owner = player;
    }

    public Player Owner { get; init; }
    public PiceType PiceType { get; init; }
    public Coords Coord { get; set; }

    public object Clone()
    {
      return new Pice(this.Owner)
      {
        Coord = this.Coord,
        PiceType = this.PiceType
      };
    }
  }
}
