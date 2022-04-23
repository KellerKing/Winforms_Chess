namespace Chess.Contracts.AI
{
  public struct Coordinates
  {
    public Coordinates(int rank, int file)
    {
      Rank = rank;
      File = file;
    }

    public int Rank { get; init; }
    public int File { get; init; }

  }
}
