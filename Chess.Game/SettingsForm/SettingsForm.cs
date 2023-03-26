using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess.Game.SettingsForm
{
  internal partial class SettingsForm : Form
  {
    internal Action OnButtonAcceptClicked;

    public SettingsForm()
    {
      InitializeComponent();
    }

    internal void InitSettingsForm(InputDto inputDto)
    {
      SetStartLocation(inputDto.LocationStart);
      radioButtonHighlightOff.Checked = !inputDto.HighlightFelder;
      radioButtonHighlightOn.Checked  = inputDto.HighlightFelder;
    }

    private void SettingsForm_Paint(object sender, PaintEventArgs e)
    {
      var rect = this.ClientRectangle;
      rect.Inflate(-3, -3);
      ControlPaint.DrawBorder(e.Graphics, rect, Color.Black, ButtonBorderStyle.Solid);
    }

    internal ResultDto CollectSettings()
    {
      return new ResultDto
      {
        DialogResult = DialogResult == System.Windows.Forms.DialogResult.OK ? Game.SettingsForm.DialogResult.OK : Game.SettingsForm.DialogResult.Cancel,
        HighlightFelder = radioButtonHighlightOn.Checked
      };
    }

    private void buttonAccept_Click(object sender, EventArgs e)
    {
      DialogResult = System.Windows.Forms.DialogResult.OK;
      OnButtonAcceptClicked?.Invoke();
    }

    private void SetStartLocation(Point locationStart)
    {
      var screen = Screen.FromPoint(locationStart);
      var postionX = Math.Max(0, locationStart.X - Width);
      var postionY = Math.Max(0,locationStart.Y);

      postionY = Math.Min(postionY, screen.Bounds.Height - Height);

      this.Location = new Point(postionX, postionY);
    }
  }
}
