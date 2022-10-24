using Chess.Game.Properties;
using Chess.Game.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess.Game.Factory
{
  public class ViewModelCreator
  {
    private static readonly Dictionary<Tuple<string, Konstanten.PieceType>, Bitmap> pieceResources = new()
    {
      { new Tuple<string, Konstanten.PieceType>("white", Konstanten.PieceType.ROOK), Resources.rook_white },
      { new Tuple<string, Konstanten.PieceType>("white", Konstanten.PieceType.PAWN), Resources.pawn_white },
      { new Tuple<string, Konstanten.PieceType>("white", Konstanten.PieceType.BISHOP), Resources.bishop_white },
      { new Tuple<string, Konstanten.PieceType>("white", Konstanten.PieceType.QUEEN), Resources.queen_white },
      { new Tuple<string, Konstanten.PieceType>("white", Konstanten.PieceType.KING), Resources.king_white },
      { new Tuple<string, Konstanten.PieceType>("white", Konstanten.PieceType.KNIGHT), Resources.knight_white },

      { new Tuple<string, Konstanten.PieceType>("black", Konstanten.PieceType.ROOK), Resources.rook_black },
      { new Tuple<string, Konstanten.PieceType>("black", Konstanten.PieceType.PAWN), Resources.pawn_black },
      { new Tuple<string, Konstanten.PieceType>("black", Konstanten.PieceType.BISHOP), Resources.bishop_black },
      { new Tuple<string, Konstanten.PieceType>("black", Konstanten.PieceType.QUEEN), Resources.queen_black },
      { new Tuple<string, Konstanten.PieceType>("black", Konstanten.PieceType.KING), Resources.king_black },
      { new Tuple<string, Konstanten.PieceType>("black", Konstanten.PieceType.KNIGHT), Resources.knight_black },
    };

    internal static TileDrawModel[,] CreateChessBoardDrawModels(Dto.Coords[,] tiles)
    {
      var chessBoardPanels = new TileDrawModel[tiles.GetLength(0), tiles.GetLength(1)];

      for (var x = 0; x < tiles.GetLength(0); x++)
      {
        for (var y = 0; y < tiles.GetLength(1); y++)
        {
          chessBoardPanels[x, y] = new TileDrawModel
          {
            BackgroundImageLayout = ImageLayout.Stretch,
            Coord = new(y, x),
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            PicturePath = (x + y) % 2 != 0 ?
            @".\Assets\Board_Light.png" :
            @".\Assets\Board_Dark.png"
          };
        }
      }
      return chessBoardPanels;
    }


    internal static Bitmap GetBitmapForHighligthFields()
    {
      return Resources.field_possible;
    }

    internal static Bitmap GetSinglePieceImage(Konstanten.Player player, Konstanten.PieceType pieceType)
    {
      var texture = GetBitmapForPiece(pieceType, player);
      texture.MakeTransparent();
      return texture;
    }

    internal static List<PieceDrawModel> GeneratePieces(List<Dto.Piece> pieces)
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

    private static Bitmap GetBitmapForPiece(Konstanten.PieceType pieceType, Konstanten.Player player)
    {
      var pieceColor = player == Konstanten.Player.WHITE ? "white" : "black";
      var key = new Tuple<string, Konstanten.PieceType>(pieceColor, pieceType);

      if (pieceResources.ContainsKey(key))
        return pieceResources[key];

      throw new Exception($"Cant find the speciefied Texture for Piece {pieceType}");
    }
  }
}
