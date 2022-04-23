using Chess.Contracts.Menue;
using Chess.WindowsApplication.Dto;

namespace Chess.WindowsApplication.Factiry
{
  internal interface IMenueResultDtoCreator
  {
    MenueResultDto CreateMenueResultDto(ResultDto resultDto);
  }
}