using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public class ChessBoard : Form
    {
        private int tileSize = 60;
        private const int ROWS = 8;
        private const int COLUMNS = 8;
        private Button[,] buttons = new Button[ROWS, COLUMNS];
        private Label[] columnLabels = new Label[COLUMNS];
        private Label[] rowLabels = new Label[ROWS];
        private Panel panel1 = new Panel();

        public ChessBoard()
        {
            InitializeComponent();


            // Tahta butonlarının oluşturulması
            for (int i = 0; i < COLUMNS; i++)
            {
                for (int j = 0; j < ROWS; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(tileSize, tileSize);
                    if ((i + j) % 2 == 0) // Karelerin siyah ve beyaz olmasını sağlamak için
                        button.BackColor = System.Drawing.Color.Black;
                    else
                        button.BackColor = System.Drawing.Color.White;
                    panel1.Controls.Add(button);
                    button.Location = new Point(j * tileSize, i * tileSize);
                }
            }

            // satir etiketlerinin oluşturulması
            for (int i = 0; i < COLUMNS; i++)
            {
                columnLabels[i] = new Label();
                columnLabels[i].Text = ((char)(65 + i)).ToString();
                columnLabels[i].Text = (i + 1).ToString();
                columnLabels[i].Size = new Size(20, 20);
                columnLabels[i].Location = new Point((i * tileSize) + tileSize + 100, 110);
                columnLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                columnLabels[i].Font = new Font("Arial", 12, FontStyle.Bold);
                columnLabels[i].Text = ((char)(65 + i)).ToString();
                this.Controls.Add(columnLabels[i]);
            }


            // Sütun etiketlerinin oluşturulması
            for (int i = 0; i < ROWS; i++)
            {
                rowLabels[i] = new Label();
                rowLabels[i].Text = (ROWS - i).ToString();
                rowLabels[i].Size = new Size(20, 20);
                rowLabels[i].Location = new Point(100, (i * tileSize) + tileSize + 100);
                rowLabels[i].TextAlign = ContentAlignment.MiddleCenter;
                rowLabels[i].Font = new Font("Arial", 12, FontStyle.Bold);
                this.Controls.Add(rowLabels[i]);
            }


            // Panelin boyutunu ayarla
            panel1.Size = new Size(tileSize * 9, tileSize * 9);

            // Panelin konumunu ayarla
            panel1.Location = new Point((this.Width - panel1.Width) / 2, (this.Height - panel1.Height) / 2);

            this.Load += new System.EventHandler(this.ChessBoard_Load);
        }

        private void ChessBoard_Load(object sender, EventArgs e)
        {
            // Panelin Form üzerine eklenmesi
            this.Controls.Add(panel1);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ChessBoard
            // 
            this.ClientSize = new System.Drawing.Size(800,800);
            this.Name = "ChessBoard";
            this.ResumeLayout(false);

        }
    }
}
