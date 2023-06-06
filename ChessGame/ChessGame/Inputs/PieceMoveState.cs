using System;
using System.Windows.Forms;
using ChessGame.Taslar;

namespace ChessGame.Inputs
{
    public class PieceMoveState:BaseState
    {
        private ChessBoard board;
        private InputHandler _inputHandler;

        public PieceMoveState(InputHandler inputHandler) : base(inputHandler)
        {
            _inputHandler = inputHandler;
            board = _inputHandler.board;
        }
        public override void Enter()
        {
            
        }

        public override void Update(Tuple<int, int> position, Player currentPlayer)
        {
            if (_inputHandler.board.IsKingInCheck(_inputHandler.selectedPiece.Color))
            {
                if (board.CanMoveInCheck(_inputHandler.selectedPiece, board,position.Item1,position.Item2))
                {
                    // eger oynayacagimiz hamle sah durumundan kurtaricaksa oynamaya izin ver
                    MovePiece(position);
                }
                else
                {
                    _inputHandler.ResetSelection();
                }
            }
            else
            {
                if (!board.CanMoveInCheck(_inputHandler.selectedPiece, board,position.Item1,position.Item2))
                {
                    // eger oynayacagimiz hamle sah durumuna sebep oluyorsa oynamaya izin verme 
                    _inputHandler.ResetSelection();
                }
                else
                {
                    MovePiece(position);
                }
            }
        }

        public override void Exit()
        {
            _inputHandler.selectedPiece = null;
        }
        
        private void MovePiece(Tuple<int, int> position)
        {
            if (_inputHandler.selectedPiece.CanMove(position.Item1, position.Item2, board))
            {
                var color = _inputHandler.currentPlayer.Color == PieceColor.White ? PieceColor.Black : PieceColor.White;
                board.MovePiece(_inputHandler.selectedPiece.CurrentRow, _inputHandler.selectedPiece.CurrentColumn, position.Item1, position.Item2);
                if (_inputHandler.selectedPiece.Type == ChessPieceType.Piyon)
                {
                    _inputHandler.selectedPiece.IsFirstMove = false;
                }
                board.UpdateBoard();
                
                if (board.IsKingInCheck(color))
                {
                    if (_inputHandler.board.IsCheckmate(color))
                    {
                        var renk = _inputHandler.currentPlayer.Color == PieceColor.White ? "Beyaz" : "Siyah";
                        MessageBox.Show("Sah Mat " + renk + " Kazandi");
                    }
                    else
                    {
                        string winner = (board.GameManager.GetCurrentPlayer().Color == PieceColor.White) ? "Beyaz" : "Siyah";
                        MessageBox.Show($"{winner} Şah çekti!");
                    }
                }
                board.GameManager.ChangeTurn();
                _inputHandler.ResetSelection();
                
            }
            else
            {
                _inputHandler.ResetSelection();
            }
        }
        
    }
}