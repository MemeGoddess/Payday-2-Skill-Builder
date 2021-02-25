using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PD2STOB
{
    public partial class SaveLoad : Form
    {
        int Way;
        BorderTextBox d;
        string SaveString = "";
        int[] Extra;
        public SaveLoad(int SaveLoad, string Savestring, int[] extra)
        {
            SaveString = Savestring;
            InitializeComponent();
            Extra = extra;
            Way = SaveLoad;
            if (Way == 1)
            {
                Text = "Save";

            }
            else if (Way == 2)
            {
                Text = "Load";
            }
            else if (Way == 3)
            {
                Text = "Delete";
            }
            a.Location = new Point(5, 5);
            Controls.Add(a);
            BackColor = Color.FromArgb(55, 62, 84);
            CenterToScreen();
            a.Size = new Size(Size.Width - 26, Size.Height - 100);
            a.BackColor = Color.FromArgb(43, 49, 66);
            a.ForeColor = Color.FromArgb(200, 200, 200);
            a.BorderStyle = BorderStyle.None;
            
            string SaveLoc = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Goddess/Saves");
            Button b = new Button();
            b.Location = new Point(5, Size.Height - 70);
            Controls.Add(b);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = Color.Black;
            b.Click += b_Click;
            if (Way == 1)
            {
                b.Text = "Save";
            }
            else if(Way == 2)
            {
                b.Text = "Load";
            }
            else if (Way == 3)
            {
                b.Text = "Delete";
            }
            a.DrawMode = DrawMode.OwnerDrawFixed;
            a.DrawItem += a_DrawItem;
            if (Directory.Exists(SaveLoc))
            {
                foreach (string c in Directory.GetFiles(SaveLoc))
                {
                    string add = c.Substring(c.LastIndexOf(@"\") + 1);
                    a.Items.Add(add.Substring(0, add.IndexOf(".")));
                }
            }
            d = new BorderTextBox(Size.Width - 26, 20);
            Controls.Add(d);
            d.Location = new Point(5, Size.Height - 95);
            d.BackColor = Color.FromArgb(43, 49, 66);
            d.textBox.Focus();
            a.SelectedIndexChanged += a_SelectedIndexChanged;
            if (a.Items.Count > 15)
            {
                int counter = a.Items.Count - 15;
                for (int i = 1; i <= counter; i++)
                {
                    b.Location = new Point(b.Location.X, b.Location.Y + 13);
                    Size = new Size(Size.Width, Size.Height + 13);
                    d.Location = new Point(d.Location.X, d.Location.Y + 13);
                }
                a.Size = new Size(Size.Width - 26, Size.Height - 100);
            }
        }
        public Boolean DoneWork = false;
        void a_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -1)
            {
                e.DrawBackground();
                Graphics g = e.Graphics;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                              new SolidBrush(Color.FromArgb(56, 128, 178)) : new SolidBrush(e.BackColor);
                g.FillRectangle(brush, e.Bounds);
                e.Graphics.DrawString(a.Items[e.Index].ToString(), e.Font,
                         new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }

        void a_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (a.SelectedItem != null)
            {
                d.textBox.Text = a.SelectedItem.ToString();
            }
            else
            {
                d.textBox.Text = "";
            }
        }
        public string[] Data = new string[10];
        void b_Click(object sender, EventArgs e)
        {
            if (Way == 1)
            {
                string SaveLoc = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Goddess/Saves");
                if (!Directory.Exists(SaveLoc))
                {
                    Directory.CreateDirectory(SaveLoc);
                }
                Button t = (Button)sender;
                t.NotifyDefault(false);
                if (File.Exists(SaveLoc + "/" + d.textBox.Text + ".save"))
                {
                    if (MessageBox.Show("Overwrite?", "Save exists!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        File.Delete(SaveLoc + "/" + d.textBox.Text);
                        File.WriteAllText(SaveLoc + "/" + d.textBox.Text + ".save", SaveString + ":" + Extra[0] + ":" + Extra[1] + ":" + Extra[2]);
                        DoneWork = true;
                        Close();
                    }

                }
                else
                {
                    File.WriteAllText(SaveLoc + "/" + d.textBox.Text + ".save", SaveString + ":" + Extra[0] + ":" + Extra[1] + ":" + Extra[2]);
                    DoneWork = true;
                    Close();
                }
            }
            else if(Way == 2)
            {
                string SaveLoc = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Goddess/Saves");
                if (File.Exists(SaveLoc + "/" + d.textBox.Text + ".save"))
                {
                    string[] Lines = File.ReadAllLines(SaveLoc + "/" + d.textBox.Text + ".save");
                    if (Lines.Length > 1)
                    {
                        Data[0] = Lines[0];
                        Data[1] = Lines[2];
                        Data[2] = Lines[4];
                        Data[3] = Lines[6];
                        DoneWork = true;
                        Close();
                    }
                    else
                    {
                        string[] Split = Lines[0].Split(':');
                        Data[0] = Split[0];
                        Data[1] = Split[1];
                        Data[2] = Split[2];
                        Data[3] = Split[3];
                        DoneWork = true;
                        Close();
                    }
                }
            }
            else if (Way == 3)
            {
                string SaveLoc = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Goddess/Saves");
                if (d.textBox.Text != "" && File.Exists(SaveLoc + "/" + d.textBox.Text + ".save"))
                {
                    File.Delete(SaveLoc + "/" + d.textBox.Text + ".save");
                    DoneWork = true;
                    Close();
                }
            }
            
        }

        private void SaveLoad_Load(object sender, EventArgs e)
        {
            
        }
    }
}
