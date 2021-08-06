using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winforms_Chess.Properties;

namespace Winforms_Chess
{
  public class ViewModelCreator
  {
    private const int tileSile = 100;

    public static GameObjectDrawModel[,] CreateChessBoardDrawModels(Tile[,] tiles, int windowWidth, int windowHeight)
    {
      var chessBoardPanels = new GameObjectDrawModel[tiles.GetLength(0), tiles.GetLength(1)];

      var startLeft = (windowWidth - tiles.GetLength(0) * tileSile) / 2;
      //var startTopa = (windowHeight - tiles.GetLength(1) * tileSile) / 2;
      var startTop = windowHeight - tileSile -((windowHeight - tiles.GetLength(1) * tileSile) / 2);


      for (var x = 0; x < tiles.GetLength(0); x++)
      {
        for (var y = 0; y < tiles.GetLength(1); y++)
        {
          var newPanel = new GameObjectDrawModel
          {
            Size = new Size(tileSile, tileSile),
            Location = new Point(startLeft + (tileSile * x), startTop - (tileSile * y)),
            Coord = new Coords(y, x),
            PicturePath = (x + y) % 2 != 0 ? 
            @".\Assets\Board_Light.png" :
            @".\Assets\Board_Dark.png"
          };

          chessBoardPanels[x, y] = newPanel;
        }
      }
      return chessBoardPanels;
    }


    public static List<PiceDrawModel> GeneratePices(List<Pice> pices)
    {
      var output = new List<PiceDrawModel>();

      pices.ForEach(x =>
      {
        Bitmap img;

        if (x.Owner == Player.WHITE)
        {
          img = x.PiceType switch
          {
            PiceType.BISHOP => Resources.chess_piece_2_white_bishop,
            PiceType.PAWN => Resources.chess_piece_2_white_pawn,
            PiceType.ROOK => Resources.chess_piece_2_white_rook,
            PiceType.QUEEN => Resources.chess_piece_2_white_queen,
            PiceType.KING => Resources.chess_piece_2_white_king,
            PiceType.KNIGHT => Resources.chess_piece_2_white_knight
          };
        }
        else
        {
          img = x.PiceType switch
          {
            PiceType.BISHOP => Resources.chess_piece_2_black_bishop,
            PiceType.PAWN => Resources.chess_piece_2_black_pawn,
            PiceType.ROOK => Resources.chess_piece_2_black_rook,
            PiceType.QUEEN => Resources.chess_piece_2_black_queen,
            PiceType.KING => Resources.chess_piece_2_black_king,
            PiceType.KNIGHT => Resources.chess_piece_2_black_knight
          };

        }
        img.MakeTransparent();

        output.Add(new PiceDrawModel()
        {
          BackColor = Color.Transparent,
          SizeMode = PictureBoxSizeMode.Zoom,
          Image = img,
          Coord = x.Coord,
          Size = new Size(tileSile, tileSile)
          
        });
      });
      return output;
    }
  }

}
