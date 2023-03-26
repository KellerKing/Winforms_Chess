using Chess.Contracts.Menue;
using Chess.WindowsApplication.Dto;

namespace Chess.WindowsApplication.Factiry
{
  internal class MenueResultDtoCreator : IMenueResultDtoCreator
  {
    public MenueResultDto CreateMenueResultDto(ResultDto resultDto)
    {
      var windowsDialogResult = resultDto.DialogResult == DialogResult.OK ? System.Windows.Forms.DialogResult.OK : System.Windows.Forms.DialogResult.Cancel;
      return new MenueResultDto
      {
        DialogResult = windowsDialogResult,
        IsPlayerStartingWhite = resultDto.IsPlayerWhite,
        IsSingleplayer = resultDto.IsSingleplayer
      };
    }
  }
}
