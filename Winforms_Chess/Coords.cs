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
