﻿using Chess.Contracts.Menue;

namespace Chess.Menue
{
  public class Controller : IMenueController
  {
    private readonly MainForm m_MainForm;

    public Controller()
    {
      m_MainForm = new MainForm();
      ConnectEvents();
    }

    public ResultDto ShowDialog()
    {
      m_MainForm.ShowDialog();
      var dialogResult = m_MainForm.DialogResult == System.Windows.Forms.DialogResult.OK ? DialogResult.OK : DialogResult.Cancel;
      var result = ResultDtoFactory.CreateResultDto(dialogResult, m_MainForm.IsSinglePlayer(), m_MainForm.IsPlayerWhite());
      m_MainForm.Dispose();

      return result;
    }

    private void ConnectEvents()
    {
      m_MainForm.OnStartGame += StartGame;
    }

    private void StartGame()
    {
      m_MainForm.Close();
    }
  }
}
