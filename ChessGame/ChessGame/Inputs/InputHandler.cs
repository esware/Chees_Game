using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ChessGame.Inputs;
using ChessGame.Taslar;

namespace ChessGame
{
    public class InputHandler
    {
        private static BaseState currentState;
        public ChessPiece selectedPiece;
        public Button button;
        public Player currentPlayer;
        public ChessBoard board;

        public InputHandler(ChessBoard board)
        {
            selectedPiece = null;
            this.board = board;
            currentState = new PieceSelectionState(this);
        }
        
        public void HandleInput(object sender, EventArgs e)
        {
            this.button = (Button)sender;
            //ChessPiece piece = (ChessPiece)button.Tag;
            Tuple<int, int> position = (Tuple<int, int>)button.Tag;
            currentPlayer = board.GameManager.GetCurrentPlayer();
            currentState.Update(position,currentPlayer);
            
            
        }
        
        public void ShowProperties(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button _button = (Button)sender;
               // ChessPiece touchedPiece = (ChessPiece)_button.Tag;
        
                // Özellikleri görüntülemek için iletişim kutusu oluşturma
                string message = //$"Piece Type: {touchedPiece.Type}\n" +
                    $"Piece location: {button.Tag}\n";
                                 //$"Piece CurrentCol: {touchedPiece.CurrentColumn}\n" +
                                 //"Piece Color: {touchedPiece.Color}\n";

                MessageBox.Show(message, "Piece Properties");
            }
        }


        public void ChangeState(BaseState newState)
        {
             currentState.Exit();
             currentState = newState;
             currentState.Enter();
        }

        public void ResetSelection()
        {
            selectedPiece = null;
            ChangeState(new PieceSelectionState(this));
        }
    }
}
