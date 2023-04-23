using System;
using System.Drawing;

namespace ChessGame.Taslar
{
    public enum PieceColor { White, Black }
    public enum ChessPieceType { Kale,Fil,At,Kral,Piyon,Vezir }

    public abstract class ChessPiece
    {
        public bool IsFirstMove { get; set; } = true;
        
        public bool IsSelected { get; set; } = false;
        public ChessPieceType Type { get;  }
        public PieceColor Color { get;  }
        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }
        public Image Image { get; set; }

        public ChessPiece(PieceColor color, ChessPieceType type, int row, int col)
        {
            this.Type = type;
            this.CurrentRow = row;
            this.CurrentColumn = col;
            this.Color = color;
            
            string imageName = @"C:\Users\srht4\Desktop\Satranc_Projesi\Chees_Game\ChessGame\Resources\"+color + "_" + type + ".png";
            try
            {
                this.Image = Image.FromFile(imageName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Image {imageName} could not be loaded. Exception message: {ex.Message}");
            }
        }
        
        public abstract bool CanMove(int row, int col, ChessBoard board);
    }
    
}