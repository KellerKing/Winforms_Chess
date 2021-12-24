using System;

namespace Chess.Game.SettingsForm
{
  internal class Controller
  {
    private readonly InputDto m_InputDto;
    private ResultDto m_ResultDto = new ResultDto();

    private SettingsForm m_SettingsForm;

    public Controller(InputDto input)
    {
      m_InputDto = input;
      m_SettingsForm = new SettingsForm();
      ConnectEvents();
    }

    private void ConnectEvents()
    {
      m_SettingsForm.OnButtonAcceptClicked += OnButtonAcceptClicked;
    }

    public ResultDto ShowDialog()
    {
      m_SettingsForm.InitSettingsForm(m_InputDto);
      m_SettingsForm.ShowDialog();
      m_SettingsForm.Dispose();
      return m_ResultDto;
    }

    private void OnButtonAcceptClicked()
    {
      m_ResultDto = m_SettingsForm.CollectSettings();
      m_SettingsForm?.Dispose();
    }

  }
}
