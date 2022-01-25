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

      using (var g = Graphics.FromImage(result))
      {
        g.FillRectangle(Brushes.LightBlue, new Rectangle(0, 0, img.Width, img.Height));
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
