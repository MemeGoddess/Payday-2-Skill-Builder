using PD2STOB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PD2STOB
{
    public partial class PublishBuild : Form
    {
        public PublishBuild()
        {
            InitializeComponent();
        }
        public string Build = "", Creator = "";
        public Boolean DoneWork = false;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string temp = ";:'\".><,?[{]}\\|!@#$%^&*()-_=+`~";
            foreach (char c in temp)
            {
                if (e.KeyChar == c)
                {
                    e.Handled = true;
                }
            }
            Build = a.textBox.Text + e.KeyChar;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string temp = ";:'\".><,?[{]}\\|!@#$%^&*()-_=+`~";
            foreach (char c in temp)
            {
                if (e.KeyChar == c)
                {
                    e.Handled = true;
                }
            }
            Creator = b.textBox.Text + e.KeyChar;
        }
        BorderTextBox a;
        BorderTextBox b;
        private void PublishBuild_Load(object sender, EventArgs e)
        {
            a = new BorderTextBox(textBox1.Width, textBox1.Height);
            b = new BorderTextBox(textBox2.Width, textBox2.Height);
            Controls.Add(a);
            Controls.Add(b);
            a.Location = textBox1.Location;
            b.Location = textBox2.Location;
            a.textBox.KeyPress += textBox1_KeyPress;
            b.textBox.KeyPress += textBox2_KeyPress;
            textBox1.Dispose();
            textBox2.Dispose();
            BackColor = Color.FromArgb(55, 62, 84);
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderColor = Color.Black;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font(button3.Font.FontFamily, 9);
            label1.ForeColor = Color.FromArgb(200, 200, 200);
            label2.ForeColor = Color.FromArgb(200, 200, 200);
            label3.ForeColor = Color.FromArgb(200, 200, 200);
        }
        public Boolean Checked = false;
        string ImagePath = "";
        private void button3_Click(object sender, EventArgs e)
        {
            Button t = (Button)sender;
            t.NotifyDefault(false);
            if (Checked)
            {
                t.Text = "";
                Checked = false;
            }
            else
            {
                FolderBrowserDialog a = new FolderBrowserDialog();
                if (a.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ImagePath = a.SelectedPath;
                    t.Text = "✔";
                    Checked = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bit);
            Label l1 = new Label();
            Font font = new Font(l1.Font.FontFamily, 35);
            Boolean Big = false;
            int BuildSize = MeasureDisplayStringWidth(g, Build, font);
            int CreatorSize = MeasureDisplayStringWidth(g, Creator, font);
            if(BuildSize > 370)
            {
                MessageBox.Show("Build name is too big!");
                Big = true;
            }
            if (CreatorSize > 370)
            {
                MessageBox.Show("Creator name is too big!");
                Big = true;
            }
            if (a.textBox.Text == "" || b.textBox.Text == "")
            {
                MessageBox.Show("Build name required with Images ticked!");
            }
            else
            {
                if (!Big)
                {
                    Checked = true;
                    DoneWork = true;
                    Close();
                }
            }

        }

        static public int MeasureDisplayStringWidth(Graphics graphics, string text,
                                    Font font)
        {
            const int width = 32;

            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, 1,
                                                                        graphics);
            System.Drawing.SizeF size = graphics.MeasureString(text, font);
            System.Drawing.Graphics anagra = System.Drawing.Graphics.FromImage(bitmap);

            int measured_width = (int)size.Width;

            if (anagra != null)
            {
                anagra.Clear(Color.White);
                anagra.DrawString(text + "|", font, Brushes.Black,
                                   width - measured_width, -font.Height / 2);

                for (int i = width - 1; i >= 0; i--)
                {
                    measured_width--;
                    if (bitmap.GetPixel(i, 0).R != 255)    // found a non-white pixel ?
                        break;
                }
            }

            if (text == "can")
            {
                measured_width += 1;
            }
            return measured_width;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
