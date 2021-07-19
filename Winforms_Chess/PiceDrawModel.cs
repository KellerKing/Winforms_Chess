using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms_Chess
{
  public class PiceDrawModel : PictureBox
  {
    public Coords? Coords { get; set; }
  }
}
