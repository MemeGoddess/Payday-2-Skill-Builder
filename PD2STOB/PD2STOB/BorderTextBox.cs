using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PD2STOB
{
    public partial class BorderTextBox : UserControl
    {
        private string text;
        public string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public TextBox textBox = new TextBox();
        public BorderTextBox(int Width, int Height)
        {
            
            this.Paint += new PaintEventHandler(UserControl1_Paint);
            this.Resize += new EventHandler(UserControl1_Resize);
            Size = new Size(Width, Height);
            textBox.BorderStyle = BorderStyle.None;
            this.Controls.Add(textBox);
            textBox.BackColor = Color.FromArgb(43, 49, 66);
            textBox.ForeColor = Color.FromArgb(200, 200, 200);
            textBox.Focus();
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            textBox.Size = new Size(this.Width - 2, this.Height - 2);
            Size = new Size(Size.Width, 15);
            textBox.Location = new Point(1, 1);

        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(56, 128, 178), ButtonBorderStyle.Solid);

        }
    }
}