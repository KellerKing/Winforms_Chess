using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Winforms_Chess.Properties;

namespace Winforms_Chess
{
  public class ViewModelCreator
  {
    private const int tileSile = 100;

    public static GameObjectDrawModel[,] CreateChessBoardDrawModels(Tile[,] tiles)
    {
      var chessBoardPanels = new GameObjectDrawModel[tiles.GetLength(0), tiles.GetLength(1)];

      for (var x = 0; x < tiles.GetLength(0); x++)
      {
        for (var y = 0; y < tiles.GetLength(1); y++)
        {
          chessBoardPanels[x, y] = new GameObjectDrawModel
          {
            BackgroundImageLayout = ImageLayout.Stretch,
            Coord = new Coords(y, x),
            Dock = DockStyle.Fill,
            PicturePath = (x + y) % 2 != 0 ?
            @".\Assets\Board_Light.png" :
            @".\Assets\Board_Dark.png"
          };
        }
      }
      return chessBoardPanels;
    }


    public static List<PiceDrawModel> GeneratePices(List<Pice> pices)
    {
      var output = new List<PiceDrawModel>();

      pices.ForEach(x =>
      {
        Bitmap img = x.Owner switch
        {
          Player.WHITE => x.PiceType switch
          {
            PiceType.BISHOP => Resources.chess_piece_2_white_bishop,
            PiceType.PAWN => Resources.pawn_white,
            PiceType.ROOK => Resources.rook_white,
            PiceType.QUEEN => Resources.chess_piece_2_white_queen,
            PiceType.KING => Resources.chess_piece_2_white_king,
            PiceType.KNIGHT => Resources.chess_piece_2_white_knight
          },
          _ => x.PiceType switch
          {
            PiceType.BISHOP => Resources.chess_piece_2_black_bishop,
            PiceType.PAWN => Resources.pawn_black,
            PiceType.ROOK => Resources.rook_black,
            PiceType.QUEEN => Resources.chess_piece_2_black_queen,
            PiceType.KING => Resources.chess_piece_2_black_king,
            PiceType.KNIGHT => Resources.chess_piece_2_black_knight
          },
        };
        img.MakeTransparent();

        output.Add(new PiceDrawModel()
        {
          BackColor = Color.Transparent,
          SizeMode = PictureBoxSizeMode.Zoom,
          Image = img,
          Coord = x.Coord,
          Dock = DockStyle.Fill,
          Size = new Size(tileSile, tileSile)
        });
      });
      return output;
    }
  }

}
