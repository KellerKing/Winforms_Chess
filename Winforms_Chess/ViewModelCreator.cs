using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
  public class ViewModelCreator
  {
    private const int tileSile = 100;

    public static GameObjectDrawModel[,] CreateChessBoardDrawModels(Tile[,] tiles, int windowWidth, int windowHeight)
    {
      var chessBoardPanels = new GameObjectDrawModel[tiles.GetLength(0), tiles.GetLength(1)];

      var startLeft = (windowWidth - tiles.GetLength(0) * tileSile) / 2;
      var startTop = (windowHeight - tiles.GetLength(1) * tileSile) / 2;

      for (var n = 0; n < tiles.GetLength(0); n++)
      {
        for (var m = 0; m < tiles.GetLength(1); m++)
        {
          var newPanel = new GameObjectDrawModel
          {
            Size = new Size(tileSile, tileSile),
            Location = new Point(startLeft + (tileSile * n), startTop + (tileSile * m)),
            PicturePath = (n + m) % 2 == 0 ? 
            @".\Assets\Board_Light.png" :
            @".\Assets\Board_Dark.png"
          };

          // add to our 2d array of panels for future use
          chessBoardPanels[n, m] = newPanel;
        }
      }
      return chessBoardPanels;
    }
  }

}
