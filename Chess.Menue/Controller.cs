using Winforms_Chess.Contracts;

namespace Chess.Menue
{
  class Controller
  {
    private readonly MainForm m_MainForm;
    private Winforms_Chess.Controller m_GameController;

    public Controller()
    {
      m_MainForm = new MainForm();
      ConnectEvents();
    }

    public void ShowGameMenue()
    {
      m_MainForm.ShowDialog();
    }

    private void ConnectEvents()
    {
      m_MainForm.m_PlayPresed += StartGame;
    }

    private void StartGame()
    {
      m_GameController = new(m_MainForm.CollectSettings());
      m_MainForm.Hide();
      HandleGameResult(m_GameController.ShowGame());
    }

    private void HandleGameResult(ResultDto resultDto)
    {
      m_MainForm.Show();

      if (resultDto.DialogResult == System.Windows.Forms.DialogResult.OK)
      {
        m_MainForm.ShowMessage(resultDto.Winner);
      }
    }
  }
}
