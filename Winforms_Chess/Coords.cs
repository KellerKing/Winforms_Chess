using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess
{
  public readonly struct Coords
  {
    public Coords(int rank, int file)
    {
      Rank = rank;
      File = file;
    }

    public int Rank { get; init; }
    public int File { get; init; }
  }
}
