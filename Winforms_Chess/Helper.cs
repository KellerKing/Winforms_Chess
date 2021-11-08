using Chess.Produktlogic.Contracts;

namespace Winforms_Chess
{
  class Helper
  {
    public static Player GetEnemy(Player playerCurrent)
    {
      return playerCurrent == Player.WHITE ? Player.BLACK : Player.WHITE;
    }
  }
}
