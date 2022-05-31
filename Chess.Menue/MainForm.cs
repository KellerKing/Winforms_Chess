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
      var isSinglePlayer = ((RadioButton)sender) == rbSinglePlayer;

      ToggleStateGroupboxSideChoose(isSinglePlayer);
    }

    public bool IsSinglePlayer()
    {
      return rbSinglePlayer.Checked;
    }

    public bool IsPlayerWhite()
    {
      return rbPlayerWhite.Checked;
    }

    private void ToggleStateGroupboxSideChoose(bool state)
    {
      groupBoxSideChoose.Enabled = state;
    }
  }
}
