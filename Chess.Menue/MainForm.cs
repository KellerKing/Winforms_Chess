using System;
using System.Windows.Forms;
using Winforms_Chess.Contracts;

namespace Chess.Menue
{
  public partial class MainForm : Form
  {
    public Action m_PlayPresed;

    public MainForm()
    {
      InitializeComponent();
     //btnPlay.Image = ViewModelCreator.GetProperPlayImage(btnPlay.Height);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      m_PlayPresed.Invoke();
    }

    private void PlayerCount_CheckedChanged(object sender, EventArgs e)
    {
      var state = ((RadioButton)sender) == rbSinglePlayer ? true : false;

      SetSizeChoosing(state);
    }

    public InputDto CollectSettings()
    {
      return new InputDto
      {
        PlayerSelected = rbPlayerWhite.Checked ? Produktlogic.Contracts.Player.WHITE : Produktlogic.Contracts.Player.BLACK,
        Singleplayer = rbSinglePlayer.Checked
      };
    }

    private void SetSizeChoosing(bool state)
    {
      groupBoxSideChoose.Enabled = state;
    }

    internal void ShowMessage(string winner)
    {
      MessageBox.Show($"{winner} has won!");
    }
  }
}
