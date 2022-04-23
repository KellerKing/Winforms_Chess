using Chess.Game.Factory;

namespace Chess.Game.PieceSelectForm
{
  internal class Controller
  {
    private readonly Konstanten.Player m_PlayerCurrent;
    private Konstanten.PieceType m_SelectedPieceType;
    private readonly PieceSelectForm m_Form;

    internal Controller(Konstanten.Player playerCurrent)
    {
      m_PlayerCurrent = playerCurrent;
      m_Form = new PieceSelectForm();

      ConnectEvents();
      InitForm();
    }

    private void InitForm()
    {
      m_Form.DrawTargetPieces(ViewModelCreator.GetSinglePieceImage(m_PlayerCurrent, Konstanten.PieceType.BISHOP),
        ViewModelCreator.GetSinglePieceImage(m_PlayerCurrent, Konstanten.PieceType.KNIGHT),
        ViewModelCreator.GetSinglePieceImage(m_PlayerCurrent, Konstanten.PieceType.QUEEN),
        ViewModelCreator.GetSinglePieceImage(m_PlayerCurrent, Konstanten.PieceType.ROOK));
    }

    private void ConnectEvents()
    {
      m_Form.PictureBoxClicked += TargetPieceClicked;
    }

    private void TargetPieceClicked(Konstanten.PieceType pieceTypeTarget)
    {
      m_SelectedPieceType = pieceTypeTarget;
      m_Form.Dispose();
      m_Form.Close();
    }

    internal Konstanten.PieceType ShowDialog()
    {
      m_Form.ShowDialog();
      return m_SelectedPieceType;
    }
  }
}
