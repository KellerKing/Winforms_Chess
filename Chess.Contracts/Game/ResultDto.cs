namespace Chess.Contracts.Game
{
  public class ResultDto
  {
    public string Winner { get; set; }
    public bool IsPatt { get; set; }
    public DialogResult DialogResult { get; set; }
  }
}
