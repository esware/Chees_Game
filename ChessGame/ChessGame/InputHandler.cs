using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ChessGame.Taslar;

namespace ChessGame
{
    public class InputHandler
    {
        private ChessBoard board;
        private ChessPiece selectedPiece;
        bool isSelectedPiece = false;
        
        public InputHandler(ChessBoard board)
        {
            selectedPiece = null;
            this.board = board;
        }
        public void Tile_Click(object sender, EventArgs e)
{
    Button button = (Button)sender;
    Tuple<int, int> position = (Tuple<int,int>)button.Tag;

    // Eğer daha önce seçtiğimiz taşı seçmiş isek seçim kaldırılır
    if (isSelectedPiece && selectedPiece != null)
    {
        selectedPiece.IsSelected = false;
        isSelectedPiece = false;
    }

    // Eğer seçilmiş bir taş yok ise, tıklanan hücredeki taşı seçeriz
    if (selectedPiece == null)
    {
        ChessPiece piece = board.GetPieceAtPosition(position.Item1, position.Item2);
        if (piece != null)
        {
            selectedPiece = piece;
            selectedPiece.IsSelected = true;
        }
    }
    else // Eğer seçilmiş bir taş var ise, tıklanan hücreye gidip gidemeyeceğini kontrol ederiz
    {
        if (selectedPiece.CanMove(position.Item1, position.Item2, board))
        {
            bool isCaptureMove = false;
            if (board.GetPieceAtPosition(position.Item1, position.Item2) != null)
            {
                isCaptureMove = true;
            }

            // Taşı hareket ettiririz
            board.MovePiece(selectedPiece.CurrentRow, selectedPiece.CurrentColumn, position.Item1, position.Item2);
            if (selectedPiece.Type == ChessPieceType.Piyon)
            {
                selectedPiece.IsFirstMove = false;
            }

            // Eğer taş yeme hareketi ise, taşı yedikten sonra seçimi kaldırırız
            if (isCaptureMove)
            {
                selectedPiece = null;
                isSelectedPiece = false;
            }
            else
            {
                // Aksi halde seçimi devam ettiririz
                selectedPiece.CurrentRow = position.Item1;
                selectedPiece.CurrentColumn = position.Item2;
            }

            board.UpdateBoard();
        }
        else if (board.GetPieceAtPosition(position.Item1, position.Item2) != null &&
                 board.GetPieceAtPosition(position.Item1, position.Item2).Color == selectedPiece.Color)
        {
            // Eğer tıklanan hücrede kendi taşımız varsa, seçimi bu taşa kaydırırız
            selectedPiece.IsSelected = false;
            selectedPiece = board.GetPieceAtPosition(position.Item1, position.Item2);
            selectedPiece.IsSelected = true;
        }
        else
        { 
            // MessageBox.Show("Geçersiz hamle!");
        }
    }
}



    }

}