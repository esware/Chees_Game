
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(50, 50);
                    if ((i + j) % 2 == 0) // Karelerin siyah ve beyaz olmasını sağlamak için
                        button.BackColor = Color.Black;
                    else
                        button.BackColor = Color.White;
                    panel1.Controls.Add(button);
                    button.Location = new Point(j * 50, i * 50);
                }
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(11, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 535);
            this.panel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CreateTiles()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(60, 60);
                    if ((i + j) % 2 == 0) // Karelerin siyah ve beyaz olmasını sağlamak için
                        button.BackColor = Color.Black;
                    else
                        button.BackColor = Color.White;
                    panel1.Controls.Add(button);
                    // Butonların konumunu ayarla
                    button.Location = new Point(j * button.Width, i * button.Height);
                    // Panel'e butonu ekle
                    panel1.Controls.Add(button);
                }
            }
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
    }
}

