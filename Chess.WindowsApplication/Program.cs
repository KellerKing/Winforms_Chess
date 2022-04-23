using System;

namespace Chess.WindowsApplication
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      var game = new Main();
      
      game.StartRoutine();

    }
  }
}
