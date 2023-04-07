using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateTiles();

            // Panel boyutunu ayarla
            panel1.Size = new Size(500, 500);

            // Form boyutunu ayarla
            this.Size = new Size(600, 600);

            // Paneli Form'un merkezine yerleştir
            panel1.Location = new Point(
                (this.ClientSize.Width - panel1.Width) / 2,
                (this.ClientSize.Height - panel1.Height) / 2);
        }
    }
}
