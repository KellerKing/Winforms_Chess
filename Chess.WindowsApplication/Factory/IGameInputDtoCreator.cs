using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.WindowsApplication.Factory
{
  public interface IGameInputDtoCreator
  {
    Chess.Contracts.Game.InputDto CreateInputDto(Dto.MenueResultDto menueResultDto);
  }
}
