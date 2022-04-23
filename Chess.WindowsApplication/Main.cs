using Chess.Contracts.Game;
using Chess.Contracts.Menue;
using Chess.WindowsApplication.Dto;
using Chess.WindowsApplication.Factiry;
using Chess.WindowsApplication.Factory;

namespace Chess.WindowsApplication
{
  internal class Main
  {
    private IMenueController m_MenueController;
    private IGameController m_GameController;

    private readonly IMenueResultDtoCreator m_MenueResultDtoCreator;
    private readonly IGameInputDtoCreator m_GameInputDtoCreator;
    public Main()
    {
      m_MenueController = new Menue.Controller();
      m_MenueResultDtoCreator = new MenueResultDtoCreator();
      m_GameInputDtoCreator = new GameInputDtoCreator();
    }

    private MenueResultDto ShowMenue()
    {
      var menueResult = m_MenueController.ShowDialog();
      return m_MenueResultDtoCreator.CreateMenueResultDto(menueResult);
    }

    private void ShowGame(MenueResultDto menueResult)
    {
      var inputDto = m_GameInputDtoCreator.CreateInputDto(menueResult);
      m_GameController = new Game.Controller(inputDto);
      var gameResult = m_GameController.ShowGame();
    }


    public void StartRoutine()
    {
      var menueResult = ShowMenue();

      if (menueResult.DialogResult != System.Windows.Forms.DialogResult.OK) return;
      
      ShowGame(menueResult);
    }
  }
}
