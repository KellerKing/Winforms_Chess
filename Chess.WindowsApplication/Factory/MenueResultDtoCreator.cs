using Chess.Contracts.Menue;
using Chess.WindowsApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.WindowsApplication.Factiry
{
  internal class MenueResultDtoCreator : IMenueResultDtoCreator
  {
    public MenueResultDto CreateMenueResultDto(ResultDto resultDto)
    {
      return new MenueResultDto
      {
        DialogResult = resultDto.DialogResult,
        IsPlayerStartingWhite = resultDto.IsPlayerStartingWhite,
        IsSingleplayer = resultDto.IsSingleplayer
      };
    }
  }
}
