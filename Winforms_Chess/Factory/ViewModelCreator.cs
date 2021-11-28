using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Chess.Game.Properties;
using System;

namespace Winforms_Chess
{
  public class ViewModelCreator
  {
    private static readonly Dictionary<Tuple<string, PiceType>, Bitmap> pieceResources = new()
    {
      { new Tuple<string, PiceType>("white", PiceType.ROOK), Resources.rook_white },
      { new Tuple<string, PiceType>("white", PiceType.PAWN), Resources.pawn_white },
      { new Tuple<string, PiceType>("white", PiceType.BISHOP), Resources.bishop_white },
      { new Tuple<string, PiceType>("white", PiceType.QUEEN), Resources.queen_white },
      { new Tuple<string, PiceType>("white", PiceType.KING), Resources.king_white },
      { new Tuple<string, PiceType>("white", PiceType.KNIGHT), Resources.knight_white },

      { new Tuple<string, PiceType>("black", PiceType.ROOK), Resources.rook_black },
      { new Tuple<string, PiceType>("black", PiceType.PAWN), Resources.pawn_black },
      { new Tuple<string, PiceType>("black", PiceType.BISHOP), Resources.bishop_black },
      { new Tuple<string, PiceType>("black", PiceType.QUEEN), Resources.queen_black },
      { new Tuple<string, PiceType>("black", PiceType.KING), Resources.king_black },
      { new Tuple<string, PiceType>("black", PiceType.KNIGHT), Resources.knight_black },
    };

    public static TileDrawModel[,] CreateChessBoardDrawModels(Coords[,] tiles)
    {
      var chessBoardPanels = new TileDrawModel[tiles.GetLength(0), tiles.GetLength(1)];

      for (var x = 0; x < tiles.GetLength(0); x++)
      {
        for (var y = 0; y < tiles.GetLength(1); y++)
        {
          chessBoardPanels[x, y] = new TileDrawModel
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

    public static Bitmap GetSinglePieceImage(Player player, PiceType pieceType)
    {
      var texture = GetBitmapForPiece(pieceType, player);
      texture.MakeTransparent();
      return texture;
    }


    public static List<PieceDrawModel> GeneratePieces(List<Piece> pieces)
    {
      var output = new List<PieceDrawModel>();

      pieces.ForEach(item =>
      {
        var texture = GetBitmapForPiece(item.PiceType, item.Owner);
        texture.MakeTransparent();

        output.Add(new PieceDrawModel()
        {
          BackColor = Color.Transparent,
          SizeMode = PictureBoxSizeMode.Zoom,
          Image = texture,
          Coord = item.Coord,
          Dock = DockStyle.Fill,
          Piece = item
        });
      });
      return output;
    }

    private static Bitmap GetBitmapForPiece(PiceType pieceType, Player player)
    {

      var pieceColor = player == Player.WHITE ? "white" : "black";
      var key = new Tuple<string, PiceType>(pieceColor, pieceType);

      if (pieceResources.ContainsKey(key))
        return pieceResources[key];

      throw new Exception($"Cant find the speciefied Texture for Piece {pieceType}");
    }
  }
}


