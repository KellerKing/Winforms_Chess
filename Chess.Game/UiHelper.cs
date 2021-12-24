using Chess.Game.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Winforms_Chess;

namespace Chess.Game
{
  internal class UiHelper
  {
    public static void HighlightPanel(TileDrawModel panel)
    {
      panel.HighlightFeld = true;
      var img = panel.BackgroundImage;
      var result = new Bitmap(img.Width, img.Height);
      var sizeHighlight = panel.Width / 1.5f;

      using (var g = Graphics.FromImage(result))
      {
        g.DrawImage(img, Point.Empty);
        g.DrawImage(Resources.field_possible, (img.Width / 2) - (sizeHighlight / 2), (img.Height / 2) - (sizeHighlight / 2), sizeHighlight, sizeHighlight);
        panel.BackgroundImage = result;
      }
      img.Dispose();
    }

    public static void SetVisibleForPanel(TileDrawModel panel, bool visible)
    {
      if (panel == null) return;

      foreach (var item in panel.Controls.OfType<PieceDrawModel>())
      {
        item.Visible = visible;
      }
    }

    public static Size GetFormResolution(Screen screenSize)
    {
      var newFormSize = Math.Min(screenSize.Bounds.Width, screenSize.Bounds.Height) * 0.65;
      return new Size((int)newFormSize, (int)newFormSize);
    }

  }
}
