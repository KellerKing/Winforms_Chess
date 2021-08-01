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


  public class CoordsFile
  {
    public static readonly int A = 1;
    public static readonly int B = 2;
    public static readonly int C = 3;
    public static readonly int D = 4;
    public static readonly int E = 5;
    public static readonly int F = 6;
    public static readonly int G = 7;
    public static readonly int H = 8;
  }
}
