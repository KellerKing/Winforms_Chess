using System;
using System.Windows.Forms;

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
      Application.EnableVisualStyles();
      var game = new Main();
      game.StartRoutine();

    }
  }
}
