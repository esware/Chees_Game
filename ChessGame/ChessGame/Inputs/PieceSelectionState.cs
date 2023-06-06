using System;
using System.Drawing;
using System.Windows.Forms;
using ChessGame.Taslar;

namespace ChessGame.Inputs
{
    public class PieceSelectionState:BaseState
    {
        private InputHandler _inputHandler;

        public PieceSelectionState(InputHandler inputHandler) : base(inputHandler)
        {
            _inputHandler = inputHandler;
        }
        public override void Enter()
        {
            
        }

        public override void Update(Tuple<int, int> position, Player currentPlayer)
        {
            SelectPiece(position,currentPlayer);
        }

        public override void Exit()
        {
        }
        
        
        private void SelectPiece(Tuple<int, int> position, Player currentPlayer)
        {
            ChessPiece piece = _inputHandler.board.GetPieceAtPosition(position.Item1, position.Item2);
            if (piece != null && piece.Color == currentPlayer.Color)
            {
                _inputHandler.selectedPiece = piece;
                _inputHandler.button.BackColor = Color.Bisque;
                
                _inputHandler.ChangeState(new PieceMoveState(_inputHandler));
            }
            else
            {
                _inputHandler.ResetSelection();
            }
        }
    }
}