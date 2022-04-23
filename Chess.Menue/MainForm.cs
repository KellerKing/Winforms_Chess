using System;
using System.Windows.Forms;

namespace Chess.Menue
{
  public partial class MainForm : Form
  {
    public Action OnStartGame;

    public MainForm()
    {
      InitializeComponent();
    }

    private void OnBtnPlay_Click(object sender, EventArgs e)
    {
      OnStartGame.Invoke();
    }

    private void PlayerCount_CheckedChanged(object sender, EventArgs e)
    {
      var state = ((RadioButton)sender) == rbSinglePlayer ? true : false;

      SetSizeChoosing(state);
    }

    public bool IsSinglePlayer()
    {
      return rbSinglePlayer.Checked;
    }

    public bool IsSinglePlayerOnWhiteSide()
    {
      return rbPlayerWhite.Checked;
    }

    private void SetSizeChoosing(bool state)
    {
      groupBoxSideChoose.Enabled = state;
    }
  }
}
