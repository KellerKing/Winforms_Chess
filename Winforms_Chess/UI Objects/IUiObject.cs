using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms_Chess.UI_Objects
{
  public interface IUiObject
  {
    public Coords Coord { get; set; }
  }
}
