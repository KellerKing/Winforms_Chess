using Chess.Produktlogic.Constants;
using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Produktlogic
{
  public class PiceInformationHandler
  {

    private static readonly List<PiceInformation> m_PiceInformation = new List<PiceInformation>
    {
      new PiceInformation { FenSymbol = 'P', Value = 1, PiceType = PiceType.PAWN },
      new PiceInformation { FenSymbol = 'B', Value = 3, PiceType = PiceType.BISHOP},
      new PiceInformation { FenSymbol = 'N', Value = 3, PiceType = PiceType.KNIGHT},
      new PiceInformation { FenSymbol = 'R', Value = 5, PiceType = PiceType.ROOK},
      new PiceInformation { FenSymbol = 'Q', Value = 9, PiceType = PiceType.QUEEN},
      new PiceInformation { FenSymbol = 'K', Value = int.MaxValue, PiceType = PiceType.KING},
    };

    public static PiceInformation GetPiceInformation(char symbol)
    {
      var piceSelected = m_PiceInformation.FirstOrDefault(x => char.ToUpperInvariant(symbol) == x.FenSymbol);
      return CopyPiceInformation(piceSelected);
    }

    public static PiceInformation GetPiceInformation(PiceType piceType)
    {
      var piceSelected = m_PiceInformation.FirstOrDefault(x => x.PiceType == piceType);
      return CopyPiceInformation(piceSelected);

    }

    private static PiceInformation CopyPiceInformation(PiceInformation pice)
    {
      if (pice == null) return null;

      return new PiceInformation
      {
        FenSymbol = pice.FenSymbol,
        PiceType = pice.PiceType,
        Value = pice.Value
      };
    }
  }
}
