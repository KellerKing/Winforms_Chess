using Chess.Produktlogic.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Winforms_Chess.PieceSelectForm
{
  public class Controller
  {
    private readonly Player m_PlayerCurrent;
    private PiceType m_SelectedPieceType;
    private readonly PieceSelectForm m_Form;

    public Controller(Player playerCurrent)
    {
      m_PlayerCurrent = playerCurrent;
      m_Form = new PieceSelectForm();

      ConnectEvents();
      InitForm();
    }

    private void InitForm()
    {
      m_Form.DrawTargetPieces(ViewModelCreator.GetSinglePieceImage(m_PlayerCurrent, PiceType.BISHOP),
        ViewModelCreator.GetSinglePieceImage(m_PlayerCurrent, PiceType.KNIGHT), 
        ViewModelCreator.GetSinglePieceImage(m_PlayerCurrent, PiceType.QUEEN), 
        ViewModelCreator.GetSinglePieceImage(m_PlayerCurrent, PiceType.ROOK));
    }

    private void ConnectEvents()
    {
      m_Form.PictureBoxClicked += TargetPieceClicked;
    }

    private void TargetPieceClicked(PiceType pieceTypeTarget)
    {
      m_SelectedPieceType = pieceTypeTarget;
      m_Form.Dispose();
      m_Form.Close();
    }

    public PiceType ShowDialog()
    {
      m_Form.ShowDialog();
      return m_SelectedPieceType;
    }
  }
}
