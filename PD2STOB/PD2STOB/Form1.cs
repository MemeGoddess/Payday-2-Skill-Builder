using PD2STOB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PD2STOB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Trees
        SubTree a1, b1, c1, d1, e1, f1, g1, h1, i1, j1, k1, l1, m1, n1, o1;



        PictureBox Basic = new PictureBox();
        PictureBox Ace = new PictureBox();
        Label label2 = new Label();
        Label label3 = new Label();
        Size SubSize = new Size(1190, 700);
        TabPanel c;
        private void Form1_Load(object sender, EventArgs e)
        {
            PreInfamy = "4";
            this.MaximizeBox = false;
            label1.Text = "Skill Points left: 104";
            Panel Mastermind = new Panel();
            Panel Enforcer = new Panel();
            Panel Technician = new Panel();
            Panel Ghost = new Panel();
            Panel Fugitive = new Panel();

            Mastermind.Size = SubSize;
            Enforcer.Size = SubSize;
            Technician.Size = SubSize;
            Ghost.Size = SubSize;
            Fugitive.Size = SubSize;
            c = new TabPanel(Mastermind, Enforcer, Technician, Ghost, Fugitive, label4);
            a1 = new SubTree("Medic", label1, label2, label3, Mastermind, c, 1);
            b1 = new SubTree("Controller", label1, label2, label3, Mastermind, c, 1);
            c1 = new SubTree("Sharpshooter", label1, label2, label3, Mastermind, c, 1);

            d1 = new SubTree("Shotgunner", label1, label2, label3, Enforcer, c, 2);
            e1 = new SubTree("Armorer", label1, label2, label3, Enforcer, c, 2);
            f1 = new SubTree("Ammunition Specialist", label1, label2, label3, Enforcer, c, 2);

            g1 = new SubTree("Engineer", label1, label2, label3, Technician, c, 3);
            h1 = new SubTree("Breacher", label1, label2, label3, Technician, c, 3);
            i1 = new SubTree("Oppressor", label1, label2, label3, Technician, c, 3);

            j1 = new SubTree("Covert Ops", label1, label2, label3, Ghost, c, 4);
            k1 = new SubTree("Commando", label1, label2, label3, Ghost, c, 4);
            l1 = new SubTree("Silent Killer", label1, label2, label3, Ghost, c, 4);

            m1 = new SubTree("Gunslinger", label1, label2, label3, Fugitive, c, 5);
            n1 = new SubTree("Relentless", label1, label2, label3, Fugitive, c, 5);
            o1 = new SubTree("Brawler", label1, label2, label3, Fugitive, c, 5);

            //a b c d e f g h i j k l m n o p q r s t u v w x y s

            Localization(a1);
            Localization(b1);
            Localization(c1);

            Localization(d1);
            Localization(e1);
            Localization(f1);

            Localization(g1);
            Localization(h1);
            Localization(i1);

            Localization(j1);
            Localization(k1);
            Localization(l1);

            Localization(m1);
            Localization(n1);
            Localization(o1);

            Point Tree1 = new Point(0, 25);
            Point Tree2 = new Point(a1.Size.Width + 10, 25);
            Point Tree3 = new Point((a1.Size.Width + 10) * 2, 25);

            a1.Location = Tree1;
            b1.Location = Tree2;
            c1.Location = Tree3;

            d1.Location = Tree1;
            e1.Location = Tree2;
            f1.Location = Tree3;

            g1.Location = Tree1;
            h1.Location = Tree2;
            i1.Location = Tree3;

            j1.Location = Tree1;
            k1.Location = Tree2;
            l1.Location = Tree3;

            m1.Location = Tree1;
            n1.Location = Tree2;
            o1.Location = Tree3;

            Mastermind.Controls.Add(a1);
            Mastermind.Controls.Add(b1);
            Mastermind.Controls.Add(c1);

            Enforcer.Controls.Add(d1);
            Enforcer.Controls.Add(e1);
            Enforcer.Controls.Add(f1);

            Technician.Controls.Add(g1);
            Technician.Controls.Add(h1);
            Technician.Controls.Add(i1);

            Ghost.Controls.Add(j1);
            Ghost.Controls.Add(k1);
            Ghost.Controls.Add(l1);

            Fugitive.Controls.Add(m1);
            Fugitive.Controls.Add(n1);
            Fugitive.Controls.Add(o1);

            BackColor = Color.FromArgb(55, 62, 84);

            Controls.Add(c);
            c.a.Text = "Mastermind - 0";
            c.b.Text = "Enforcer - 0";
            c.c.Text = "Technician - 0";
            c.d.Text = "Ghost - 0";
            c.e.Text = "Fugitive - 0";
            label2.Text = "Basic Description";
            label3.Text = "Ace Description";
            label3.Paint += label3_Paint;
            label3.Refresh();

            label2.Paint += label2_Paint;
            label2.Refresh();
            

            label2.Location = new Point(2, 229);
            label3.Location = new Point(2, 456);


            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);

            Basic.Location = new Point(1, 229);
            Ace.Location = new Point(1, 456 - 66);
            Basic.Size = new Size(180, 210 - 52);
            Ace.Size = new Size(180, 210 - 55);

            panel1.Controls.Add(Basic);
            panel1.Controls.Add(Ace);

            Button Clear = new Button();
            Clear.Location = new Point(0, 203);
            panel1.Controls.Add(Clear);
            Clear.Click += Clear_Click;
            Clear.FlatStyle = FlatStyle.Flat;
            Clear.FlatAppearance.BorderColor = Color.Black;
            Clear.ForeColor = Color.FromArgb(200, 200, 200);
            Clear.Text = "Clear all";
            Clear.Size = new Size(90, Clear.Size.Height);

            ClearCurrent = new Button();
            ClearCurrent.Location = new Point(94, 203);
            ClearCurrent.Size = new Size(90, Clear.Size.Height);
            panel1.Controls.Add(ClearCurrent);
            ClearCurrent.Click += ClearCurrent_Click;
            ClearCurrent.FlatStyle = FlatStyle.Flat;
            ClearCurrent.FlatAppearance.BorderColor = Color.Black;
            ClearCurrent.ForeColor = Color.FromArgb(200, 200, 200);
            ClearCurrent.Text = "Clear current";
            
            ClearCurrent.NotifyDefault(false);

            Button Up = new Button();
            Up.Location = new Point(0, 75);
            Up.Size = new Size(25, 20);
            panel1.Controls.Add(Up);
            Up.FlatStyle = FlatStyle.Flat;
            Up.FlatAppearance.BorderColor = Color.Black;
            Up.Text = "˄"; //˅
            Up.Click += Up_Click;

            Button Down = new Button();
            Down.Location = new Point(0, 110);
            Down.Size = new Size(25, 20);
            panel1.Controls.Add(Down);
            Down.FlatStyle = FlatStyle.Flat;
            Down.FlatAppearance.BorderColor = Color.Black;
            Down.Text = "˅";
            Down.Click += Down_Click;

            Label LevelLabel = new Label();
            LevelLabel.Location = new Point(25, 96);
            LevelLabel.AutoSize = false;
            LevelLabel.Size = new Size(50, 13);
            panel1.Controls.Add(LevelLabel);
            LevelLabel.Text = "Level";
            LevelLabel.ForeColor = Color.FromArgb(200, 200, 200);

            Label InfamyLabel = new Label();
            InfamyLabel.Location = new Point(25, 153);
            InfamyLabel.AutoSize = false;
            InfamyLabel.Size = new Size(70, 13);
            panel1.Controls.Add(InfamyLabel);
            InfamyLabel.Text = "Infamy Points";
            InfamyLabel.ForeColor = Color.FromArgb(200, 200, 200);

            level = new TextBox();
            level.Location = new Point(0, 96);
            panel1.Controls.Add(level);
            level.BackColor = Color.FromArgb(BackColor.R + 10, BackColor.G + 10, BackColor.B + 10);
            level.BorderStyle = BorderStyle.None;
            level.Size = new Size(25, level.Size.Height);
            level.Text = "100";
            level.TextAlign = HorizontalAlignment.Center;
            level.TextChanged += level_TextChanged;

            Button UpInfamy = new Button();
            UpInfamy.Location = new Point(0, 132);
            UpInfamy.Size = new Size(25, 20);
            panel1.Controls.Add(UpInfamy);
            UpInfamy.FlatStyle = FlatStyle.Flat;
            UpInfamy.FlatAppearance.BorderColor = Color.Black;
            UpInfamy.Text = "˄"; //˅
            UpInfamy.Click += UpInfamy_Click;

            Button DownInfamy = new Button();
            DownInfamy.Location = new Point(0, 167);
            DownInfamy.Size = new Size(25, 20);
            panel1.Controls.Add(DownInfamy);
            DownInfamy.FlatStyle = FlatStyle.Flat;
            DownInfamy.FlatAppearance.BorderColor = Color.Black;
            DownInfamy.Text = "˅";
            DownInfamy.Click += DownInfamy_Click;

            infamy = new TextBox();
            infamy.Location = new Point(0, 153);
            panel1.Controls.Add(infamy);
            infamy.BackColor = Color.FromArgb(BackColor.R + 10, BackColor.G + 10, BackColor.B + 10);
            infamy.BorderStyle = BorderStyle.None;
            infamy.Size = new Size(25, level.Size.Height);
            infamy.Text = "4";
            infamy.TextAlign = HorizontalAlignment.Center;
            infamy.TextChanged += infamy_TextChanged;

            Button Save = new Button();
            Save.Location = new Point(110, 73);
            panel1.Controls.Add(Save);
            Save.FlatStyle = FlatStyle.Flat;
            Save.Size = new Size(70, 24);
            Save.Text = "Save";
            Save.FlatAppearance.BorderColor = Color.Black;
            Save.Click += Save_Click;

            Button Load = new Button();
            Load.Location = new Point(110, 99);
            panel1.Controls.Add(Load);
            Load.FlatStyle = FlatStyle.Flat;
            Load.Size = new Size(70, 24);
            Load.Text = "Load";
            Load.FlatAppearance.BorderColor = Color.Black;
            Load.Click += Load_Click;

            Button Delete = new Button();
            Delete.Location = new Point(110, 125);
            panel1.Controls.Add(Delete);
            Delete.FlatStyle = FlatStyle.Flat;
            Delete.Size = new Size(70, 24);
            Delete.Text = "Delete";
            Delete.FlatAppearance.BorderColor = Color.Black;
            Delete.Click += Delete_Click;

            Button Export = new Button();
            Export.Location = new Point(110, 151);
            panel1.Controls.Add(Export);
            Export.FlatStyle = FlatStyle.Flat;
            Export.Size = new Size(70, 24);
            Export.Text = "Export";
            Export.FlatAppearance.BorderColor = Color.Black;
            Export.Click += Export_Click;

            Button Import = new Button();
            Import.Location = new Point(110, 177);
            panel1.Controls.Add(Import);
            Import.FlatStyle = FlatStyle.Flat;
            Import.Size = new Size(70, 24);
            Import.Text = "Import";
            Import.FlatAppearance.BorderColor = Color.Black;
            Import.Click += Import_Click;

            Button Publish = new Button();
            Publish.Location = new Point(110, 47);
            panel1.Controls.Add(Publish);
            Publish.FlatStyle = FlatStyle.Flat;
            Publish.Size = new Size(70, 24);
            Publish.Text = "Publish";
            Publish.FlatAppearance.BorderColor = Color.Black;
            Publish.Click += Publish_Click;

        }
        PublishBuild Pub;
        void Publish_Click(object sender, EventArgs e)
        {
            Enabled = false;
            Pub = new PublishBuild();
            Pub.FormClosed += Pub_FormClosed;
            Pub.Show();
        }

        void Pub_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enabled = true;
            if (Pub.DoneWork)
            {
                string SaveString = "";
                for (int i = 1; i < 16; i++)
                {
                    SubTree b = TreeByNum(i);

                    SaveString += "" + b.t1aS + b.t2aS + b.t2bS + b.t3aS + b.t3bS + b.t4aS;
                    if (i != 15)
                    {
                        SaveString += "-";
                    }
                }
                int[] Extra = new int[3];
                Extra[0] = Convert.ToInt32(label1.Text.Substring(label1.Text.IndexOf(":") + 2));
                Extra[1] = Convert.ToInt32(level.Text);
                Extra[2] = Convert.ToInt32(infamy.Text);
                try
                {
                    Clipboard.SetText(SaveString + ":" + Extra[0] + ":" + Extra[1] + ":" + Extra[2]);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
                if (Directory.Exists(Pub.Build))
                {
                    if (File.Exists(Pub.Build + "\\Code.txt"))
                    {
                        File.Delete(Pub.Build + "\\Code.txt");
                    }
                    if (File.Exists(Pub.Build + "\\Mastermind.png"))
                    {
                        File.Delete(Pub.Build + "\\Mastermind.png");
                    }
                    if (File.Exists(Pub.Build + "\\Enforcer.png"))
                    {
                        File.Delete(Pub.Build + "\\Enforcer.png");
                    }
                    if (File.Exists(Pub.Build + "\\Technician.png"))
                    {
                        File.Delete(Pub.Build + "\\Technician.png");
                    }
                    if (File.Exists(Pub.Build + "\\Ghost.png"))
                    {
                        File.Delete(Pub.Build + "\\Ghost.png");
                    }
                    if (File.Exists(Pub.Build + "\\Fugitive.png"))
                    {
                        File.Delete(Pub.Build + "\\Fugitive.png");
                    }
                }
                try
                {
                    Directory.CreateDirectory(Pub.Build);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message + "   " + Pub.Build + "   \n" + e1.StackTrace);
                }
                File.WriteAllText(Pub.Build + "\\Code.txt", SaveString + ":" + Extra[0] + ":" + Extra[1] + ":" + Extra[2]);
                Label L1 = new Label();
                Font font = L1.Font;
                
                for (int i = 1; i < 6; i++)
                {
                    int FirstSub = i * 3 - 2;
                    int SecondSub = i * 3 - 1;
                    int ThirdSub = i * 3;

                    Bitmap Img = global::PD2STOB.Properties.Resources.template;
                    string Title = "";
                    using (Graphics g = Graphics.FromImage(Img))
                    {
                        switch (i)
                        {
                            case 1:
                                Title = "Mastermind";
                                break;
                            case 2:
                                Title = "Enforcer";
                                break;
                            case 3:
                                Title = "Technician";
                                break;
                            case 4:
                                Title = "Ghost";
                                break;
                            case 5:
                                Title = "Fugitive";
                                break;
                        }
                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        g.DrawString(Pub.Build, new Font(font.FontFamily, 35), new SolidBrush(Color.FromArgb(200, 200, 200)), 367, 59, stringFormat);
                        g.DrawString(Title, new Font(font.FontFamily, 68), new SolidBrush(Color.FromArgb(200, 200, 200)), 963, 57, stringFormat);
                        g.DrawString(Pub.Creator, new Font(font.FontFamily, 35), new SolidBrush(Color.FromArgb(200, 200, 200)), 1550, 59, stringFormat);
                        //Subtrees
                        g.DrawString("Goddess Payday 2 Skill Tree Overhaul Builder", new Font(font.FontFamily, 18), new SolidBrush(Color.FromArgb(200, 200, 200)), 1700, 20, stringFormat);
                        g.DrawString(TreeByNum(FirstSub).TreeName, new Font(font.FontFamily, 50), new SolidBrush(Color.FromArgb(200, 200, 200)), 364, 134, stringFormat);
                        g.DrawString(TreeByNum(SecondSub).TreeName, new Font(font.FontFamily, 50), new SolidBrush(Color.FromArgb(200, 200, 200)), 965, 134, stringFormat);
                        if (TreeByNum(ThirdSub).TreeName == "Ammunition Specialist")
                        {
                            g.DrawString(TreeByNum(ThirdSub).TreeName, new Font(font.FontFamily, 50), new SolidBrush(Color.FromArgb(200, 200, 200)), 1548, 134, stringFormat);
                        }
                        else
                        {
                            g.DrawString(TreeByNum(ThirdSub).TreeName, new Font(font.FontFamily, 50), new SolidBrush(Color.FromArgb(200, 200, 200)), 1548, 134, stringFormat);
                        }
                        double Base = (842 - 30) / 4;
                        int Glow = 122;
                        int Nor = 108;
                        int Si = 0;
                        //Tier 1
                        Bitmap First = new Bitmap(Unlocked(1), new Size(128, 128));
                        int Remove = 0;
                        Color co = Color.FromArgb(200, 200, 200);
                        Color co1 = Color.FromArgb(105, 119, 130);
                        Color co2 = Color.FromArgb(56, 128, 178);
                        Color co3 = Color.White;
                        switch (TreeByNum(FirstSub).t1aS)
                        {
                            case 0:
                                First = new Bitmap(Locked(1, TreeByNum(FirstSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                First = new Bitmap(Unlocked(1), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                First = new Bitmap(Basic1(1), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                First = new Bitmap(Ace1(1), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(First, 313 - Remove, 864 - Remove, Si, Si);
                        g.DrawString(TreeByNum(FirstSub).t1aN, new Font(font.FontFamily, 25), new SolidBrush(co), (313 - Remove) + (Si / 2), (864 - Remove) + Si + 13, stringFormat);

                        //Tier 2 A
                        Bitmap SecondA = new Bitmap(Locked(2, TreeByNum(FirstSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(FirstSub).t2aS)
                        {
                            case 0:
                                SecondA = new Bitmap(Locked(2, TreeByNum(FirstSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                SecondA = new Bitmap(Unlocked(2), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                SecondA = new Bitmap(Basic1(2), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                SecondA = new Bitmap(Ace1(2), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(SecondA, 205 - Remove, 648 - Remove, Si, Si);
                        g.DrawString(TreeByNum(FirstSub).t2aN, new Font(font.FontFamily, 25), new SolidBrush(co), (205 - Remove) + (Si / 2), (648 - Remove) + Si + 13, stringFormat);

                        //Tier 2 B
                        Bitmap SecondB = new Bitmap(Locked(2, TreeByNum(FirstSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(FirstSub).t2bS)
                        {
                            case 0:
                                SecondB = new Bitmap(Locked(2, TreeByNum(FirstSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                SecondB = new Bitmap(Unlocked(2), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                SecondB = new Bitmap(Basic1(2), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                SecondB = new Bitmap(Ace1(2), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(SecondB, 420 - Remove, 648 - Remove, Si, Si);
                        g.DrawString(TreeByNum(FirstSub).t2bN, new Font(font.FontFamily, 25), new SolidBrush(co), (420 - Remove) + (Si / 2), (648 - Remove) + Si + 13, stringFormat);

                        //Tier 3 A
                        Bitmap ThirdA = new Bitmap(Locked(3, TreeByNum(FirstSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(FirstSub).t3aS)
                        {
                            case 0:
                                ThirdA = new Bitmap(Locked(3, TreeByNum(FirstSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                ThirdA = new Bitmap(Unlocked(3), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                ThirdA = new Bitmap(Basic1(3), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                ThirdA = new Bitmap(Ace1(3), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(ThirdA, 205 - Remove, 432 - Remove, Si, Si);
                        g.DrawString(TreeByNum(FirstSub).t3aN, new Font(font.FontFamily, 25), new SolidBrush(co), (205 - Remove) + (Si / 2), (432 - Remove) + Si + 13, stringFormat);

                        //Tier 3 B
                        Bitmap ThirdB = new Bitmap(Locked(3, TreeByNum(FirstSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(FirstSub).t3bS)
                        {
                            case 0:
                                ThirdB = new Bitmap(Locked(3, TreeByNum(FirstSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                ThirdB = new Bitmap(Unlocked(3), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                ThirdB = new Bitmap(Basic1(3), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                ThirdB = new Bitmap(Ace1(3), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(ThirdB, 420 - Remove, 432 - Remove, Si, Si);
                        g.DrawString(TreeByNum(FirstSub).t3bN, new Font(font.FontFamily, 25), new SolidBrush(co), (420 - Remove) + (Si / 2), (432 - Remove) + Si + 13, stringFormat);

                        //Tier 4 A
                        Bitmap FourthA = new Bitmap(Locked(4, TreeByNum(FirstSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(FirstSub).t4aS)
                        {
                            case 0:
                                FourthA = new Bitmap(Locked(4, TreeByNum(FirstSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                FourthA = new Bitmap(Unlocked(4), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                FourthA = new Bitmap(Basic1(4), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                FourthA = new Bitmap(Ace1(4), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(FourthA, 313 - Remove, 216 - Remove, Si, Si);
                        g.DrawString(TreeByNum(FirstSub).t4aN, new Font(font.FontFamily, 25), new SolidBrush(co), (313 - Remove) + (Si / 2), (216 - Remove) + Si + 13, stringFormat);

                        //2nd Tree
                        //Tier 1
                        Bitmap BFirst = new Bitmap(Unlocked(1), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(SecondSub).t1aS)
                        {
                            case 0:
                                BFirst = new Bitmap(Locked(1, TreeByNum(SecondSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                BFirst = new Bitmap(Unlocked(1), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                BFirst = new Bitmap(Basic1(1), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                BFirst = new Bitmap(Ace1(1), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(BFirst, 904 - Remove, 864 - Remove, Si, Si); //313
                        g.DrawString(TreeByNum(SecondSub).t1aN, new Font(font.FontFamily, 25), new SolidBrush(co), (904 - Remove) + (Si / 2), (864 - Remove) + Si + 13, stringFormat);

                        //Tier 2 A
                        Bitmap BSecondA = new Bitmap(Locked(2, TreeByNum(SecondSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(SecondSub).t2aS)
                        {
                            case 0:
                                BSecondA = new Bitmap(Locked(2, TreeByNum(SecondSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                BSecondA = new Bitmap(Unlocked(2), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                BSecondA = new Bitmap(Basic1(2), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                BSecondA = new Bitmap(Ace1(2), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(BSecondA, 797 - Remove, 648 - Remove, Si, Si);
                        if (TreeByNum(SecondSub).t2aN == "Combat Engineering")
                        {
                            string[] words = TreeByNum(SecondSub).t2aN.Split(' ');
                            g.DrawString(words[0] + "\n" + words[1], new Font(font.FontFamily, 25), new SolidBrush(co), (797 - Remove) + (Si / 2), (648 - Remove) + Si + 26, stringFormat);
                        }
                        else
                        {
                            g.DrawString(TreeByNum(SecondSub).t2aN, new Font(font.FontFamily, 25), new SolidBrush(co), (797 - Remove) + (Si / 2), (648 - Remove) + Si + 13, stringFormat);
                        }

                        //Tier 2 B
                        Bitmap BSecondB = new Bitmap(Locked(2, TreeByNum(SecondSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(SecondSub).t2bS)
                        {
                            case 0:
                                BSecondB = new Bitmap(Locked(2, TreeByNum(SecondSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                BSecondB = new Bitmap(Unlocked(2), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                BSecondB = new Bitmap(Basic1(2), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                BSecondB = new Bitmap(Ace1(2), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(BSecondB, 1012 - Remove, 648 - Remove, Si, Si);
                        g.DrawString(TreeByNum(SecondSub).t2bN, new Font(font.FontFamily, 25), new SolidBrush(co), (1012 - Remove) + (Si / 2), (648 - Remove) + Si + 13, stringFormat);

                        //Tier 3 A
                        Bitmap BThirdA = new Bitmap(Locked(3, TreeByNum(SecondSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(SecondSub).t3aS)
                        {
                            case 0:
                                BThirdA = new Bitmap(Locked(3, TreeByNum(SecondSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                BThirdA = new Bitmap(Unlocked(3), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                BThirdA = new Bitmap(Basic1(3), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                BThirdA = new Bitmap(Ace1(3), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(BThirdA, 797 - Remove, 432 - Remove, Si, Si);
                        if (TreeByNum(SecondSub).t3aN == "Stockholm Syndrome")
                        {
                            g.DrawString("Stockholm", new Font(font.FontFamily, 25), new SolidBrush(co), (797 - Remove) + (Si / 2), (432 - Remove) + Si + 13, stringFormat);
                        }
                        else
                        {
                            g.DrawString(TreeByNum(SecondSub).t3aN, new Font(font.FontFamily, 25), new SolidBrush(co), (797 - Remove) + (Si / 2), (432 - Remove) + Si + 13, stringFormat);
                        }

                        //Tier 3 B
                        Bitmap BThirdB = new Bitmap(Locked(3, TreeByNum(SecondSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(SecondSub).t3bS)
                        {
                            case 0:
                                BThirdB = new Bitmap(Locked(3, TreeByNum(SecondSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                BThirdB = new Bitmap(Unlocked(3), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                BThirdB = new Bitmap(Basic1(3), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                BThirdB = new Bitmap(Ace1(3), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(BThirdB, 1012 - Remove, 432 - Remove, Si, Si);
                        g.DrawString(TreeByNum(SecondSub).t3bN, new Font(font.FontFamily, 25), new SolidBrush(co), (1012 - Remove) + (Si / 2), (432 - Remove) + Si + 13, stringFormat);

                        //Tier 4 A
                        Bitmap BFourthA = new Bitmap(Locked(4, TreeByNum(SecondSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(SecondSub).t4aS)
                        {
                            case 0:
                                BFourthA = new Bitmap(Locked(4, TreeByNum(SecondSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                BFourthA = new Bitmap(Unlocked(4), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                BFourthA = new Bitmap(Basic1(4), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                BFourthA = new Bitmap(Ace1(4), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(BFourthA, 904 - Remove, 216 - Remove, Si, Si);
                        g.DrawString(TreeByNum(SecondSub).t4aN, new Font(font.FontFamily, 25), new SolidBrush(co), (904 - Remove) + (Si / 2), (216 - Remove) + Si + 13, stringFormat);

                        //3rd Tree
                        //Tier 1
                        Bitmap CFirst = new Bitmap(Unlocked(1), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(ThirdSub).t1aS)
                        {
                            case 0:
                                CFirst = new Bitmap(Locked(1, TreeByNum(ThirdSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                CFirst = new Bitmap(Unlocked(1), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                CFirst = new Bitmap(Basic1(1), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                CFirst = new Bitmap(Ace1(1), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(CFirst, 1495 - Remove, 864 - Remove, Si, Si); //313
                        g.DrawString(TreeByNum(ThirdSub).t1aN, new Font(font.FontFamily, 25), new SolidBrush(co), (1495 - Remove) + (Si / 2), (864 - Remove) + Si + 13, stringFormat);

                        //Tier 2 A
                        Bitmap CSecondA = new Bitmap(Locked(2, TreeByNum(ThirdSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(ThirdSub).t2aS)
                        {
                            case 0:
                                CSecondA = new Bitmap(Locked(2, TreeByNum(ThirdSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                CSecondA = new Bitmap(Unlocked(2), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                CSecondA = new Bitmap(Basic1(2), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                CSecondA = new Bitmap(Ace1(2), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(CSecondA, 1389 - Remove, 648 - Remove, Si, Si);
                        g.DrawString(TreeByNum(ThirdSub).t2aN, new Font(font.FontFamily, 25), new SolidBrush(co), (1389 - Remove) + (Si / 2), (648 - Remove) + Si + 13, stringFormat);

                        //Tier 2 B
                        Bitmap CSecondB = new Bitmap(Locked(2, TreeByNum(ThirdSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(ThirdSub).t2bS)
                        {
                            case 0:
                                CSecondB = new Bitmap(Locked(2, TreeByNum(ThirdSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                CSecondB = new Bitmap(Unlocked(2), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                CSecondB = new Bitmap(Basic1(2), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                CSecondB = new Bitmap(Ace1(2), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(CSecondB, 1604 - Remove, 648 - Remove, Si, Si);
                        g.DrawString(TreeByNum(ThirdSub).t2bN, new Font(font.FontFamily, 25), new SolidBrush(co), (1604 - Remove) + (Si / 2), (648 - Remove) + Si + 13, stringFormat);

                        //Tier 3 A
                        Bitmap CThirdA = new Bitmap(Locked(3, TreeByNum(ThirdSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(ThirdSub).t3aS)
                        {
                            case 0:
                                CThirdA = new Bitmap(Locked(3, TreeByNum(ThirdSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                CThirdA = new Bitmap(Unlocked(3), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                CThirdA = new Bitmap(Basic1(3), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                CThirdA = new Bitmap(Ace1(3), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(CThirdA, 1389 - Remove, 432 - Remove, Si, Si);
                        g.DrawString(TreeByNum(ThirdSub).t3aN, new Font(font.FontFamily, 25), new SolidBrush(co), (1389 - Remove) + (Si / 2), (432 - Remove) + Si + 13, stringFormat);

                        //Tier 3 B
                        Bitmap CThirdB = new Bitmap(Locked(3, TreeByNum(ThirdSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(ThirdSub).t3bS)
                        {
                            case 0:
                                CThirdB = new Bitmap(Locked(3, TreeByNum(ThirdSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                CThirdB = new Bitmap(Unlocked(3), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                CThirdB = new Bitmap(Basic1(3), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                CThirdB = new Bitmap(Ace1(3), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(CThirdB, 1604 - Remove, 432 - Remove, Si, Si);
                        g.DrawString(TreeByNum(ThirdSub).t3bN, new Font(font.FontFamily, 25), new SolidBrush(co), (1604 - Remove) + (Si / 2), (432 - Remove) + Si + 13, stringFormat);

                        //Tier 4 A
                        Bitmap CFourthA = new Bitmap(Locked(4, TreeByNum(ThirdSub)), new Size(128, 128));
                        Remove = 0;
                        switch (TreeByNum(ThirdSub).t4aS)
                        {
                            case 0:
                                CFourthA = new Bitmap(Locked(4, TreeByNum(ThirdSub)), new Size(128, 128));
                                Si = Nor;
                                co = co1;
                                break;
                            case 1:
                                CFourthA = new Bitmap(Unlocked(4), new Size(128, 128));
                                Si = Nor;
                                co = co2;
                                break;
                            case 2:
                                CFourthA = new Bitmap(Basic1(4), new Size(128, 128));
                                Si = Nor;
                                co = co3;
                                break;
                            case 3:
                                CFourthA = new Bitmap(Ace1(4), new Size(128, 128));
                                Si = Glow;
                                Remove = 7;
                                co = co3;
                                break;
                        }
                        g.DrawImage(CFourthA, 1495 - Remove, 216 - Remove, Si, Si);
                        g.DrawString(TreeByNum(ThirdSub).t4aN, new Font(font.FontFamily, 25), new SolidBrush(co), (1495 - Remove) + (Si / 2), (216 - Remove) + Si + 13, stringFormat);
                    }
                    Img.Save(Pub.Build + "\\" + Title + ".png", ImageFormat.Png);

                    //205, 432

                }
            }
        }

        public Bitmap Unlocked(int Tier)
        {
            Bitmap bit = new Bitmap(64, 64);
            Graphics g = Graphics.FromImage(bit);
            Pen pen = new Pen(new SolidBrush(Color.FromArgb(56, 128, 178)), 3);
            g.DrawLine(pen, 0, 0, 63, 0);
            g.DrawLine(pen, 0, 0, 0, 63);
            g.DrawLine(pen, 63, 0, 63, 63);
            g.DrawLine(pen, 64, 63, 0, 63);
            Label l1 = new Label();
            l1.Font = new Font(l1.Font.FontFamily, 50);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(Tier.ToString(), l1.Font, new SolidBrush(Color.FromArgb(56, 128, 178)), 2, -5);
            l1.Font = new Font(l1.Font.FontFamily, 9);
            int Basic = 0;
            int Ace = 0;
            int Require = 0;
            switch (Tier)
            {
                case 1:
                    Basic = 1;
                    Ace = 3;
                    Require = 0;
                    break;
                case 2:
                    Basic = 2;
                    Ace = 4;
                    Require = 4;
                    break;
                case 3:
                    Basic = 3;
                    Ace = 5;
                    Require = 10;
                    break;
                case 4:
                    Basic = 4;
                    Ace = 6;
                    Require = 18;
                    break;
            }
            g.DrawString(Basic.ToString(), l1.Font, new SolidBrush(Color.FromArgb(56, 128, 178)), 0, 48);
            g.DrawString(Ace.ToString(), l1.Font, new SolidBrush(Color.FromArgb(56, 128, 178)), 53, 48);
            g.DrawString("0", l1.Font, new SolidBrush(Color.FromArgb(56, 128, 178)), 1, 0);
            return bit;
        }

        public Bitmap Locked(int Tier, SubTree a2)
        {
            Bitmap bit = new Bitmap(64, 64);
            Graphics g = Graphics.FromImage(bit);
            Pen pen = new Pen(new SolidBrush(Color.FromArgb(105, 119, 130)), 3);
            g.DrawLine(pen, 0, 0, 63, 0);
            g.DrawLine(pen, 0, 0, 0, 63);
            g.DrawLine(pen, 63, 0, 63, 63);
            g.DrawLine(pen, 64, 63, 0, 63);
            Label l1 = new Label();
            l1.Font = new Font(l1.Font.FontFamily, 50);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(Tier.ToString(), l1.Font, new SolidBrush(Color.FromArgb(105, 119, 130)), 2, -5);
            l1.Font = new Font(l1.Font.FontFamily, 9);
            int Basic = 0;
            int Ace = 0;
            int Require = 0;
            switch (Tier)
            {
                case 1:
                    Basic = 1;
                    Ace = 3;
                    Require = 0;
                    break;
                case 2:
                    Basic = 2;
                    Ace = 4;
                    Require = 4;
                    break;
                case 3:
                    Basic = 3;
                    Ace = 5;
                    Require = 10;
                    break;
                case 4:
                    Basic = 4;
                    Ace = 6;
                    Require = 18;
                    break;
            }
            g.DrawString(Basic.ToString(), l1.Font, new SolidBrush(Color.FromArgb(105, 119, 130)), 0, 48);
            g.DrawString(Ace.ToString(), l1.Font, new SolidBrush(Color.FromArgb(105, 119, 130)), 53, 48);
            g.DrawString((Require - a2.TotalPoints()).ToString(), l1.Font, new SolidBrush(Color.FromArgb(105, 119, 130)), 1, 0);
            return bit;
        }
        public Bitmap Ace1(int Tier)
        {
            Bitmap bit = Basic1(Tier);
            Bitmap bit2 = new Bitmap(76, 76);
            Graphics g = Graphics.FromImage(bit2);
            g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, 76, 76);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(80, Color.White)), 1, 1, 74, 74);
            g.FillRectangle(new SolidBrush(Color.FromArgb(120, Color.White)), 2, 2, 72, 72);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(160, Color.White)), 3, 3, 70, 70);
            g.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.White)), 4, 4, 68, 68);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(240, Color.White)), 5, 5, 66, 66);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, Color.White)), 6, 6, 64, 64);
            g.FillRectangle(new SolidBrush(Color.FromArgb(55, 62, 84)), 6, 6, 64, 64);
            g.SetClip(new Rectangle(6, 6, 64, 64));
            g.Clear(Color.Transparent);
            g.SetClip(new Rectangle(0, 0, 76, 76));
            g.DrawImage(bit, 6, 6);
            return bit2;
        }

        public Bitmap Basic1(int Tier)
        {
            Bitmap bit = new Bitmap(64, 64);
            Graphics g = Graphics.FromImage(bit);
            Pen pen = new Pen(new SolidBrush(Color.White), 3);
            g.DrawLine(pen, 0, 0, 63, 0);
            g.DrawLine(pen, 0, 0, 0, 63);
            g.DrawLine(pen, 63, 0, 63, 63);
            g.DrawLine(pen, 64, 63, 0, 63);
            Label l1 = new Label();
            l1.Font = new Font(l1.Font.FontFamily, 50);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(Tier.ToString(), l1.Font, new SolidBrush(Color.White), 2, -5);
            l1.Font = new Font(l1.Font.FontFamily, 9);
            int Basic = 0;
            int Ace = 0;
            int Require = 0;
            switch (Tier)
            {
                case 1:
                    Basic = 1;
                    Ace = 3;
                    Require = 0;
                    break;
                case 2:
                    Basic = 2;
                    Ace = 4;
                    Require = 4;
                    break;
                case 3:
                    Basic = 3;
                    Ace = 5;
                    Require = 10;
                    break;
                case 4:
                    Basic = 4;
                    Ace = 6;
                    Require = 18;
                    break;
            }
            g.DrawString(Basic.ToString(), l1.Font, new SolidBrush(Color.White), 0, 48);
            g.DrawString(Ace.ToString(), l1.Font, new SolidBrush(Color.White), 53, 48);
            g.DrawString("0", l1.Font, new SolidBrush(Color.White), 1, 0);
            return bit;
        }
        void Import_Click(object sender, EventArgs e)
        {
            Button t = (Button)sender;
            t.NotifyDefault(false);
            string s = Clipboard.GetText();
            if (s != "" && s != null)
            {
                Boolean Format = false;
                var r = new Regex(@"^\d{6}-\d{6}-\d{6}-\d{6}-\d{6}-\d{6}-\d{6}-\d{6}-\d{6}-\d{6}-\d{6}-\d{6}-\d{6}-\d{6}-\d{6}");
                if (r.IsMatch(s))
                {
                    int Count = 0;
                    foreach (char a in s)
                    {
                        if (a == ':')
                        {
                            Count++;
                        }
                    }
                    if (Count == 3)
                    {
                        string[] FirstSplit = s.Split(':');
                        string[] DataSplit = FirstSplit[0].Split('-');
                        int count = 1;
                        int PointsUsed = 0;
                        foreach (string b in DataSplit)
                        {
                            SubTree c = TreeByNum(count);
                            int[] d = GetIntArray(Convert.ToInt32(b));
                            c.t1aS = d[0];
                            c.t2aS = d[1];
                            c.t2bS = d[2];
                            c.t3aS = d[3];
                            c.t3bS = d[4];
                            c.t4aS = d[5];
                            c.DoUnlocks();
                            count++;
                            PointsUsed += Convert.ToInt32(c.l11.Text.Substring(c.l11.Text.IndexOf("-") + 2));
                        }
                        try
                        {
                            Convert.ToInt32(FirstSplit[2]);
                            level.Text = FirstSplit[2];
                        }catch(Exception e1){
                            level.Text = "100";
                        }

                        try
                        {
                            Convert.ToInt32(FirstSplit[3]);
                            infamy.Text = FirstSplit[3];
                        }catch(Exception e1){
                            level.Text = "4";
                        }
                        label1.Text = "Skill Points left: " + ((Convert.ToInt32(level.Text) + Convert.ToInt32(infamy.Text)) - PointsUsed);
                    }
                    else
                    {
                        MessageBox.Show("Invalid format");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid format");
                }
            }
            int AllPoints = 0;
            
        }

        void Export_Click(object sender, EventArgs e)
        {
            Button t = (Button)sender;
            t.NotifyDefault(false);
            string SaveString = "";
            for (int i = 1; i < 16; i++)
            {
                SubTree b = TreeByNum(i);

                SaveString += "" + b.t1aS + b.t2aS + b.t2bS + b.t3aS + b.t3bS + b.t4aS;
                if (i != 15)
                {
                    SaveString += "-";
                }
            }
            int[] Extra = new int[3];
            Extra[0] = Convert.ToInt32(label1.Text.Substring(label1.Text.IndexOf(":") + 2));
            Extra[1] = Convert.ToInt32(level.Text);
            Extra[2] = Convert.ToInt32(infamy.Text);
            Clipboard.SetText(SaveString + ":" + Extra[0] + ":" + Extra[1] + ":" + Extra[2]);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Enabled = false;
            Button t = (Button)sender;
            t.NotifyDefault(false);
            int[] Extra = new int[3];
            Extra[0] = Convert.ToInt32(label1.Text.Substring(label1.Text.IndexOf(":") + 2));
            Extra[1] = Convert.ToInt32(level.Text);
            Extra[2] = Convert.ToInt32(infamy.Text);
            a = new SaveLoad(3, "", Extra);
            a.Show();
            a.FormClosed += a_FormClosed3;
        }

        void a_FormClosed3(object sender, FormClosedEventArgs e)
        {
            Enabled = true;
        }

        void Load_Click(object sender, EventArgs e)
        {
            Enabled = false;
            Button t = (Button)sender;
            t.NotifyDefault(false);
            int[] Extra = new int[3];
            Extra[0] = Convert.ToInt32(label1.Text.Substring(label1.Text.IndexOf(":") + 2));
            Extra[1] = Convert.ToInt32(level.Text);
            Extra[2] = Convert.ToInt32(infamy.Text);
            a = new SaveLoad(2, "", Extra);
            a.Show();
            a.FormClosed += a_FormClosed2;
        }

        void a_FormClosed2(object sender, FormClosedEventArgs e)
        {
            Enabled = true;
            if (a.DoneWork)
            {
                string[] DataSplit = a.Data[0].Split('-');
                int count = 1;
                foreach (string b in DataSplit)
                {
                    SubTree c = TreeByNum(count);
                    int[] d = GetIntArray(Convert.ToInt32(b));
                    c.t1aS = d[0];
                    c.t2aS = d[1];
                    c.t2bS = d[2];
                    c.t3aS = d[3];
                    c.t3bS = d[4];
                    c.t4aS = d[5];
                    c.DoUnlocks();
                    count++;
                }
                level.Text = a.Data[2];
                infamy.Text = a.Data[3];
                label1.Text = "Skill Points left: " + a.Data[1];
            }
        }

        int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
        SaveLoad a;
        void Save_Click(object sender, EventArgs e)
        {
            Enabled = false;
            Button t = (Button)sender;
            t.NotifyDefault(false);
            string SaveString = "";
            for (int i = 1; i < 16; i++)
            {
                SubTree b = TreeByNum(i);
                
                SaveString += "" +  b.t1aS + b.t2aS + b.t2bS + b.t3aS + b.t3bS + b.t4aS;
                if (i != 15)
                {
                    SaveString += "-";
                }
            }
            int[] Extra = new int[3];
            Extra[0] = Convert.ToInt32(label1.Text.Substring(label1.Text.IndexOf(":") + 2));
            Extra[1] = Convert.ToInt32(level.Text);
            Extra[2] = Convert.ToInt32(infamy.Text);
            a = new SaveLoad(1, SaveString, Extra);
            a.Show();
            a.FormClosed += a_FormClosed;
            
        }
        public SubTree TreeByNum(int Num)
        {
            switch (Num)
            {
                case 1:
                    return a1;
                    break;
                case 2:
                    return b1;
                    break;
                case 3:
                    return c1;
                    break;
                case 4:
                    return d1;
                    break;
                case 5:
                    return e1;
                    break;
                case 6:
                    return f1;
                    break;
                case 7:
                    return g1;
                    break;
                case 8:
                    return h1;
                    break;
                case 9:
                    return i1;
                    break;
                case 10:
                    return j1;
                    break;
                case 11:
                    return k1;
                    break;
                case 12:
                    return l1;
                    break;
                case 13:
                    return m1;
                    break;
                case 14:
                    return n1;
                    break;
                case 15:
                    return o1;
                    break;
            }
            return a1;
        }
        void a_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enabled = true;
        }

        void UpInfamy_Click(object sender, EventArgs e)
        {
            if (InfamyPoints != 4)
            {
                InfamyPoints++;
                infamy.Text = InfamyPoints.ToString();
            }
            Button t = (Button)sender;
            t.NotifyDefault(false);
        }

        void DownInfamy_Click(object sender, EventArgs e)
        {
            if (InfamyPoints > 0)
            {
                Boolean Fixed = false;
                int PointsToAdd = 0;
                foreach (Panel a in c.Controls.OfType<Panel>())
                {
                    foreach (SubTree b in a.Controls.OfType<SubTree>())
                    {
                        switch (b.t1aS)
                        {
                            case 2:
                                PointsToAdd += 1;
                                break;
                            case 3:
                                PointsToAdd += 4;
                                break;
                        }
                        switch (b.t2aS)
                        {
                            case 2:
                                PointsToAdd += 2;
                                break;
                            case 3:
                                PointsToAdd += 6;
                                break;
                        }
                        switch (b.t2bS)
                        {
                            case 2:
                                PointsToAdd += 2;
                                break;
                            case 3:
                                PointsToAdd += 6;
                                break;
                        }
                        switch (b.t3aS)
                        {
                            case 2:
                                PointsToAdd += 3;
                                break;
                            case 3:
                                PointsToAdd += 8;
                                break;
                        }
                        switch (b.t3bS)
                        {
                            case 2:
                                PointsToAdd += 3;
                                break;
                            case 3:
                                PointsToAdd += 8;
                                break;
                        }
                        switch (b.t4aS)
                        {
                            case 2:
                                PointsToAdd += 4;
                                break;
                            case 3:
                                PointsToAdd += 10;
                                break;
                        }
                    }
                }
                InfamyPoints--;
                int LowestLevel = PointsToAdd - InfamyPoints;
                if (LowestLevel < 0) { LowestLevel = 0; }
                int Level = Convert.ToInt32(level.Text);
                int PointsLeft = Convert.ToInt32(label1.Text.Substring(label1.Text.IndexOf(":") + 2));
                if (Level >= LowestLevel)
                {
                    infamy.Text = InfamyPoints.ToString();
                    PointsLeft--;
                    label1.Text = "Skill Points left: " + PointsLeft;
                }
            }
            Button t = (Button)sender;
            t.NotifyDefault(false);
        }
        string PreInfamy = "";
        void infamy_TextChanged(object sender, EventArgs e)
        {
            if (infamy.Text == "")
            {
                infamy.Text = "0";
                infamy.SelectionStart = level.Text.Length;
            }
            if (infamy.Text == "00")
            {
                infamy.Text = "0";
                infamy.SelectionStart = level.Text.Length;
            }
            try
            {
                if (Convert.ToInt32(infamy.Text) > 4)
                {
                    infamy.Text = "4";
                    infamy.SelectionStart = infamy.Text.Length;
                }
            }
            catch (Exception e1)
            {
                infamy.Text = PreInfamy;
                infamy.SelectionStart = infamy.Text.Length;
            }
            try
            {
                Convert.ToInt32(infamy.Text);
                PreInfamy = infamy.Text;
                int PointsToAdd = 0;
                foreach (Panel a in c.Controls.OfType<Panel>())
                {
                    foreach (SubTree b in a.Controls.OfType<SubTree>())
                    {
                        switch (b.t1aS)
                        {
                            case 2:
                                PointsToAdd += 1;
                                break;
                            case 3:
                                PointsToAdd += 4;
                                break;
                        }
                        switch (b.t2aS)
                        {
                            case 2:
                                PointsToAdd += 2;
                                break;
                            case 3:
                                PointsToAdd += 6;
                                break;
                        }
                        switch (b.t2bS)
                        {
                            case 2:
                                PointsToAdd += 2;
                                break;
                            case 3:
                                PointsToAdd += 6;
                                break;
                        }
                        switch (b.t3aS)
                        {
                            case 2:
                                PointsToAdd += 3;
                                break;
                            case 3:
                                PointsToAdd += 8;
                                break;
                        }
                        switch (b.t3bS)
                        {
                            case 2:
                                PointsToAdd += 3;
                                break;
                            case 3:
                                PointsToAdd += 8;
                                break;
                        }
                        switch (b.t4aS)
                        {
                            case 2:
                                PointsToAdd += 4;
                                break;
                            case 3:
                                PointsToAdd += 10;
                                break;
                        }
                    }
                }
                InfamyPoints = Convert.ToInt32(infamy.Text);
                label1.Text = "Skill Points left: " + (Convert.ToInt32(level.Text) + (InfamyPoints - PointsToAdd));
            }
            catch (Exception e1)
            {
                InfamyPoints = 0;
                infamy.Text = "0";
            }
        }
        int InfamyPoints = 4;
        void level_TextChanged(object sender, EventArgs e)
        {
            if (level.Text == "")
            {
                level.Text = "0";
                level.SelectionStart = level.Text.Length;
            }
            if (level.Text == "00")
            {
                level.Text = "0";
                level.SelectionStart = level.Text.Length;
            }
            try
            {
                if (Convert.ToInt32(level.Text) > 100)
                {
                    level.Text = "100";
                    level.SelectionStart = level.Text.Length;
                }
            }
            catch (Exception e1) 
            {
                level.Text = PreLevel;
                level.SelectionStart = level.Text.Length;
            }
            try
            {
                Convert.ToInt32(level.Text);
                PreLevel = level.Text;
                int PointsToAdd = 0;
                foreach (Panel a in c.Controls.OfType<Panel>())
                {
                    foreach (SubTree b in a.Controls.OfType<SubTree>())
                    {
                        switch (b.t1aS)
                        {
                            case 2:
                                PointsToAdd += 1;
                                break;
                            case 3:
                                PointsToAdd += 4;
                                break;
                        }
                        switch (b.t2aS)
                        {
                            case 2:
                                PointsToAdd += 2;
                                break;
                            case 3:
                                PointsToAdd += 6;
                                break;
                        }
                        switch (b.t2bS)
                        {
                            case 2:
                                PointsToAdd += 2;
                                break;
                            case 3:
                                PointsToAdd += 6;
                                break;
                        }
                        switch (b.t3aS)
                        {
                            case 2:
                                PointsToAdd += 3;
                                break;
                            case 3:
                                PointsToAdd += 8;
                                break;
                        }
                        switch (b.t3bS)
                        {
                            case 2:
                                PointsToAdd += 3;
                                break;
                            case 3:
                                PointsToAdd += 8;
                                break;
                        }
                        switch (b.t4aS)
                        {
                            case 2:
                                PointsToAdd += 4;
                                break;
                            case 3:
                                PointsToAdd += 10;
                                break;
                        }
                    }
                }
                label1.Text = "Skill Points left: " + (Convert.ToInt32(level.Text) + (InfamyPoints - PointsToAdd));
            }
            catch (Exception e1)
            {
                if (level.Text == "")
                {
                    level.Text = "0";
                    level.SelectionStart = level.Text.Length;
                }
                else
                {
                    level.Text = PreLevel;
                    level.SelectionStart = level.Text.Length;
                }
            }
        }

        string PreLevel = "";

        void Down_Click(object sender, EventArgs e)
        {
            
            Boolean Fixed = false;
            int PointsToAdd = 0;
            Button t = (Button)sender;
            t.NotifyDefault(false);
            foreach (Panel a in c.Controls.OfType<Panel>())
            {
                foreach (SubTree b in a.Controls.OfType<SubTree>())
                {
                    switch (b.t1aS)
                    {
                        case 2:
                            PointsToAdd += 1;
                            break;
                        case 3:
                            PointsToAdd += 4;
                            break;
                    }
                    switch (b.t2aS)
                    {
                        case 2:
                            PointsToAdd += 2;
                            break;
                        case 3:
                            PointsToAdd += 6;
                            break;
                    }
                    switch (b.t2bS)
                    {
                        case 2:
                            PointsToAdd += 2;
                            break;
                        case 3:
                            PointsToAdd += 6;
                            break;
                    }
                    switch (b.t3aS)
                    {
                        case 2:
                            PointsToAdd += 3;
                            break;
                        case 3:
                            PointsToAdd += 8;
                            break;
                    }
                    switch (b.t3bS)
                    {
                        case 2:
                            PointsToAdd += 3;
                            break;
                        case 3:
                            PointsToAdd += 8;
                            break;
                    }
                    switch (b.t4aS)
                    {
                        case 2:
                            PointsToAdd += 4;
                            break;
                        case 3:
                            PointsToAdd += 10;
                            break;
                    }
                }
            }
            int LowestLevel = PointsToAdd - InfamyPoints;
            if (LowestLevel < 0) { LowestLevel = 0; }
            int Level = Convert.ToInt32(level.Text);
            int PointsLeft = Convert.ToInt32(label1.Text.Substring(label1.Text.IndexOf(":") + 2));
            if (Level - 1 >= LowestLevel)
            {
                level.Text = Level - 1 + "";
                PointsLeft--;
                label1.Text = "Skill Points left: " + PointsLeft;
            }

        }
        TextBox level, infamy;
        void Up_Click(object sender, EventArgs e)
        {
            Button t = (Button)sender;
            t.NotifyDefault(false);
            int Level = Convert.ToInt32(level.Text);
            int PointsLeft = Convert.ToInt32(label1.Text.Substring(label1.Text.IndexOf(":") + 2));
            if (Level != 100)
            {
                Level++;
                level.Text = Level + "";
                PointsLeft++;
                label1.Text = "Skill Points left: " + PointsLeft;
            }
        }
        Button ClearCurrent;
        void ClearCurrent_Click(object sender, EventArgs e)
        {
            int PointsToAdd = 0;
            foreach(Button a in c.Controls.OfType<Button>())
            {
                if (a.Text.Contains("-"))
                {
                    a.Text = a.Text.Substring(0, a.Text.IndexOf("-") - 1) + " - 0";
                }
            }
            foreach (Panel a in c.Controls.OfType<Panel>())
            {
                if (a.Visible)
                {
                    foreach (SubTree b in a.Controls.OfType<SubTree>())
                    {
                        switch (b.t1aS)
                        {
                            case 2:
                                PointsToAdd += 1;
                                break;
                            case 3:
                                PointsToAdd += 4;
                                break;
                        }
                        switch (b.t2aS)
                        {
                            case 2:
                                PointsToAdd += 2;
                                break;
                            case 3:
                                PointsToAdd += 6;
                                break;
                        }
                        switch (b.t2bS)
                        {
                            case 2:
                                PointsToAdd += 2;
                                break;
                            case 3:
                                PointsToAdd += 6;
                                break;
                        }
                        switch (b.t3aS)
                        {
                            case 2:
                                PointsToAdd += 3;
                                break;
                            case 3:
                                PointsToAdd += 8;
                                break;
                        }
                        switch (b.t3bS)
                        {
                            case 2:
                                PointsToAdd += 3;
                                break;
                            case 3:
                                PointsToAdd += 8;
                                break;
                        }
                        switch (b.t4aS)
                        {
                            case 2:
                                PointsToAdd += 4;
                                break;
                            case 3:
                                PointsToAdd += 10;
                                break;
                        }
                        b.Reset();
                        b.Focus();
                    }
                }
            }
            Button t = (Button)sender;
            t.NotifyDefault(false);
            int PointsLeft = Convert.ToInt32(label1.Text.Substring(label1.Text.IndexOf(":") + 2));
            label1.Text = "Skill Points left: " + (PointsLeft + PointsToAdd);
        }

        void Clear_Click(object sender, EventArgs e)
        {
            foreach (Panel a in c.Controls.OfType<Panel>())
            {
                foreach (SubTree b in a.Controls.OfType<SubTree>())
                {
                    b.Reset();
                    b.Focus();
                }
            }
            label1.Text = "Skill Points left: " + (Convert.ToInt32(level.Text) + 4);
            Button t = (Button)sender;
            t.NotifyDefault(false);
        }

        void label2_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bit = new Bitmap(185, 230);
            Graphics g = Graphics.FromImage(bit);
            Label l1 = (Label)sender;
            SolidBrush Normal = new SolidBrush(Color.FromArgb(200, 200, 200));
            SolidBrush BlueBrush = new SolidBrush(Color.FromArgb(45, 144, 199));
            float x = 0;
            float y = 0;
            string[] Words = l1.Text.Split(' ');
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            foreach (string b in Words)
            {
                string c = b;
                Boolean Blue = false;
                if (c.Any(j => char.IsDigit(j)))
                {
                    Blue = true;
                }
                if (x + MeasureDisplayStringWidth(g, c, l1.Font) >= 180)
                {
                    x = 0;
                    y++;
                }
                if (!Blue)
                {
                    g.DrawString(c, l1.Font, Normal, x, y * 13 + 3);
                }
                else
                {
                    g.DrawString(c, l1.Font, BlueBrush, x, y * 13 + 3);
                }

                x += MeasureDisplayStringWidth(g, c, l1.Font);
                if (c.Length == 1)
                {
                    x += 2;
                }
            }
            Basic.Image = bit;
            label2.Visible = false;
        }

        void label3_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bit = new Bitmap(185, 230);
            Graphics g = Graphics.FromImage(bit);
            Label l1 = (Label)sender;
            SolidBrush Normal = new SolidBrush(Color.FromArgb(200, 200, 200));
            SolidBrush BlueBrush = new SolidBrush(Color.FromArgb(45, 144, 199));
            float x = 0;
            float y = 0;
            string[] Words = l1.Text.Split(' ');
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            foreach (string b in Words)
            {
                string c = b;
                Boolean Blue = false;
                if (c.Any(j => char.IsDigit(j)))
                {
                    Blue = true;
                }
                if (x + MeasureDisplayStringWidth(g, c, l1.Font) >= 180)
                {
                    x = 0;
                    y++;
                }
                if (!Blue)
                {
                    g.DrawString(c, l1.Font, Normal, x, y * 13 + 3);
                }
                else
                {
                    g.DrawString(c, l1.Font, BlueBrush, x, y * 13 + 3);
                }

                x += MeasureDisplayStringWidth(g, c, l1.Font);
                if (c.Length == 1)
                {
                    x += 2;
                }
            }
            Ace.Image = bit;
            label3.Visible = false;
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
        public void Localization(SubTree a)
        {
            switch (a.TreeName)
            {
                case "Medic":
                    a.t1aN = "Combat Medic";
                    a.t1aB = "After you have revived a crew member, you receive a 25% damage bonus for 10 seconds.";
                    a.t1aA = "Reviving a crew member gives them 30% more health.";

                    a.t2aN = "Quick Fix";
                    a.t2aB = "Decreases your first aid kit and doctor bag deploy time by 50%.";
                    a.t2aA = "Crew members that use your first aid kits or doctor bags take 20% less damage for 10 seconds.";
                    
                    a.t2bN = "Pain Killers";
                    a.t2bB = "Crew members you revive take 30% less damage for 5 seconds";
                    a.t2bA = "The damage reduction is increased by an additional 20%";
                    
                    a.t3aN = "Uppers";
                    a.t3aB = "Adds 7 more first aid kits to your inventory.";
                    a.t3aA = "Adds 3 more first aid kits to your inventory. Your deployed first aid kits will be automatically used if a player would go down within a 15 meter radius of the first aid kit. Only 70% of the effect is triggered";
                    
                    a.t3bN = "Combat Doctor";
                    a.t3bB = "You can now place 2 doctor bags instead of just one.";
                    a.t3bA = "Your doctor bags have 2 more charges.";
                    
                    a.t4aN = "Inspire";
                    a.t4aB = "You revive crew members 50% faster. Shouting at your teammates will increase their movement speed by 20% for 30 seconds.";
                    a.t4aA = "There is a 75% chance that you can revive crew members at a distance by shouting at them.";
                    break;

                case "Controller":
                    a.t1aN = "Cable Guy";
                    a.t1aB = "You can cable tie hostages 75% faster.";
                    a.t1aA = "Increases your supply of cable ties by 4.";
                    
                    a.t2aN = "Endurance";
                    a.t2aB = "Increases your stamina by 150% and your crew's stamina by 50%. Civilians are intimidated by the noise you make and remain intimidated 50% longer.";
                    a.t2aA = "You can reload your weapon while sprinting.";
                    
                    a.t2bN = "Joker";
                    a.t2bB = "You can convert a non-special enemy to fight on your side. This can not be done during stealth and the enemy must have surrendered in order for you to convert it. You can only convert one enemy at a time.";
                    a.t2bA = "The converted enemy gains 55% more heath and deals 45% more damage. The time to convert an enemy is reduced by 65%. The power and range of your intimidation ia increased by 50%";
                    
                    a.t3aN = "Stockholm Syndrome";
                    a.t3aB = "Nearby untied civilians will revive you when you call on them. Your hostages will not flee when they have been rescued by law enforcers.";
                    a.t3aA = "Civilians reviving you have a 0% chance of giving you ammo. Whenever you get into custody, your hostages wil trade themselves for your safe return. This effect CAN occur during assaults.";
                    
                    a.t3bN = "Partner in Crime";
                    a.t3bB = "Having a converted enemy increases your movement speed by 10%. Your converted enemy takes an additional 40% less damage.";
                    a.t3bA = "Having a converted enemy increases your health by 30%. Your converted enemy takes an additonal 60% less damage.";
                    
                    a.t4aN = "Hostage Taker";
                    a.t4aB = "Having at least one hostage or converted law enforcer makes you regenerate 1.5% health every 5 seconds.";
                    a.t4aA = "Having at least one hostage or converted law enforcer makes you regenerate 4.5% health every 5 seconds.";
                    break;
                case "Sharpshooter":
                    a.t1aN = "Stable Shot";
                    a.t1aB = "You gain 8 weapon stability.";
                    a.t1aA = "You gain 8 weapon accuracy while standing still.";
                    
                    a.t2aN = "Rifleman";
                    a.t2aB = "Your snap to zoom is 100% faster with all weapons.";
                    a.t2aA = "Your weapon zoom level is increased by 25% with all weapons.";
                    
                    a.t2bN = "Marksman";
                    a.t2bB = "You gain 8 weapon accuracy with all SMG, Assault Rifle and Snipers fired in single shot.";
                    a.t2bA = "You gain a 20% accuracy bonus while aiming down sights with all SMG, Assault rifle and Snipers fired in single shot.";
                    
                    a.t3aN = "Spotter";
                    a.t3aB = "Enemies you mark take 15% more damage.";
                    a.t3aA = "Enemies you mark take an additonal 0% damage when further than 0 meters.";
                    
                    a.t3bN = "Aggressive Reload";
                    a.t3bB = "Killing an enemy by a headshot with the last bullet in the magazine will reduce your reload time by 30% for 2 seconds. Can only be triggered by SMG, Assault rifle and Snipers fired in single shot.";
                    a.t3bA = "Any killing headshot will reduce your reload time by 50% for 2 seconds. Can only be triggered by SMG, Assault Rifle and Snipers fired in single shot.";
                    
                    a.t4aN = "Ammo Efficiency";
                    a.t4aB = "Hitting 6 headshots in a row will refund 1 bullet to your used weapon. Can only be triggered by SMG, Assault rifle and Snipers fired in single shot.";
                    a.t4aA = "Hitting 3 headshots in a row will refund 1 bullet for your used weapon. Can only be triggered by SMG, Assault rifle and Snipers fired in single shot.";
                    break;
                case "Shotgunner":
                    a.t1aN = "Underdog";
                    a.t1aB = "When you are surrounded by 3 enemies or more, you receive a 10% damage bonus.";
                    a.t1aA = "When you are surrounded by 3 enemies or more, you receive 10% less damage from enemies.";
                    
                    a.t2aN = "Shotgun CQB";
                    a.t2aB = "You reload shotguns 25% faster.";
                    a.t2aA = "You reload shotguns 25% faster again. You gain a 125% increased steel sight speed when using shotguns";
                    
                    a.t2bN = "Shotgun Impact";
                    a.t2bB = "Your weapon stability with all shotguns is increased by 8.";
                    a.t2bA = "You deal 35% more damage with shotguns.";
                    
                    a.t3aN = "Far Away";
                    a.t3aB = "Your accuracy bonus while aiming down the sights with shotguns is increased by 40%.";
                    a.t3aA = "You gain a 35% increased effective range with shotguns when aiming down sights.";
                    
                    a.t3bN = "Close By";
                    a.t3bB = "You can now hip-fire with your shotgun while sprinting.";
                    a.t3bA = "Your rate of fire is increased by 35% while firing from the hip with single shot shotguns. Your shotguns with magazines have their magazine sizes increased by 15 shells.";
                    
                    a.t4aN = "Overkill";
                    a.t4aB = "When you kill an enemy with a shotgun or the portable sawm you receive a 75% damage increase for 10 seconds.";
                    a.t4aA = "The damage bonus now applies to all weapons. Skill must still be activated using a shotgun or the portable saw.";
                    break;
                case "Armorer":
                    a.t1aN = "Oppressor";
                    a.t1aB = "Your weapons are 75% more effective at threatening enemies.";
                    a.t1aA = "Reduces the visual effect duration of flashbangs by 75%";
                    
                    a.t2aN = "Die Hard";
                    a.t2aB = "You can use your primary weapon in bleedout.";
                    a.t2aA = "Your armor recovers 15% faster.";
                    
                    a.t2bN = "Transporter";
                    a.t2bB = "You can throw bags 50% further.";
                    a.t2bA = "You can now carry 2 bags at once.";
                    
                    a.t3aN = "Bulletproof";
                    a.t3aB = "The recovery rate of you and your crew is increased by 25%";
                    a.t3aA = "Improves your armor so you can absorb 35% more damage.";
                    
                    a.t3bN = "Bullseye";
                    a.t3bB = "You regenerate 10 armor for each successful headshot. This effect cannot occur more than once every 2 seconds";
                    a.t3bA = "You regenerate an additional 20 armor for each successful headshot.";
                    
                    a.t4aN = "Iron Man";
                    a.t4aB = "When you melee or shoot shield enemies there's a chance that they get knocked over by the sheer force. The chance depends on the damage of the used weapon.";
                    a.t4aA = "You gain the ability to wear ICTV (Improved Combined Tactical Vest).";
                    break;
                case "Ammunition Specialist":
                    a.t1aN = "Stable Shot";
                    a.t1aB = "You gain a 50% increased ammo box pick up range.";
                    a.t1aA = "Every 10th enemy you kill will drop an extra ammo box.";
                    
                    a.t2aN = "Bullet Storm";
                    a.t2aB = "Directly after you deploy an ammo bag, you can fire your weapon for 0 seconds without depleting any ammunition.";
                    a.t2aA = "You can fire 15 seconds longer without depleting your ammunition.";
                    
                    a.t2bN = "Portable Saw";
                    a.t2bB = "Unlocks the portable saw for you to use as a secondary weapon.";
                    a.t2bA = "You gain 1 extra saw blade for the portable saw.";
                    
                    a.t3aN = "Ammunition Specialist";
                    a.t3aB = "You can now place 2 ammo bags instead of just one.";
                    a.t3aA = "Each amo bag contains additional 200% ammunition.";
                    
                    a.t3bN = "Carbon Blade";
                    a.t3bB = "You replace your saw blades with carbo blades, increasing your saw efficiency by 40% and reducing the wear down of the blades on enemies by 50%.";
                    a.t3bA = "You can now saw through shield enemies with your portable saw. When killing an enemy with the saw, you have a 0% chance to cause nearby enemies to panic. Panic will make enemies go into short bursts of uncontrollable fear.";
                    
                    a.t4aN = "Fully Loaded";
                    a.t4aB = "Your total ammo capacity is increased by 25%.";
                    //a.t4aA = "Increases the amount of ammo you gain from ammo boxes by 75%. You also gain a 0% base chance to get a throwable from an ammo box. The base chance is increased by 0% for each ammo box you pick up that does not contain a throwable. When a throwable has been found, the chance is reset to it's base value. Note: Does not work with custom shotgun ammo and does not stack with the perk deck skill \"Walk-in Closet\"";
                    a.t4aA = "Increases ammo from ammo boxes by 75%. Gain a 0% base chance to get a throwable from an ammo box, base chanced is increased for each ammo box that does not contain a throwable. Chance is reset when a throwable is found. Note: Does not work with custom shotgun ammo and doesn't stack with \"Walk-in Closet\"";
                    break;
                case "Engineer":
                    a.t1aN = "Defence Up";
                    a.t1aB = "Your sentry guns cost 25% less ammo to deploy.";
                    a.t1aA = "Your sentry guns gain a protective shield.";
                    
                    a.t2aN = "Sentry Targeting Package";
                    a.t2aB = "Your sentry guns gain a 100% increase in accuracy.";
                    a.t2aA = "Your sentry guns rotation speed is increased by 150%. Your sentry guns also have 50% more ammunition.";
                    
                    a.t2bN = "Eco Sentry";
                    a.t2bB = "Your sentry guns cost 25% less ammunition to deploy.";
                    a.t2bA = "Your sentry guns gain 150% increased health.";
                    
                    a.t3aN = "Engineering";
                    a.t3aB = "You can now select a less noisy version of the sentry guns, making them much less likely to be targeted by enemies.";
                    a.t3aA = "You can now toggle AP rounds on your sentry guns, lowering the rate of fire and ammunition count, but increasing damage and allowing it to pierce through enemies and shields.";
                    
                    a.t3bN = "Jack of all Trades";
                    a.t3bB = "Your deploy and interact with all deployables 50% faster.";
                    a.t3bA = "You can now equip a second deployable to bring with you. The second deployable has 50% less uses.";
                    
                    a.t4aN = "Tower Defence";
                    a.t4aB = "You can now carry 2 extra sentry guns.";
                    a.t4aA = "You can now carry an additional 2 extra sentry guns.";
                    break;
                case "Breacher":
                    a.t1aN = "Hardware Expert";
                    a.t1aB = "You fix drills and saws 25% faster. Drills are silent, civilians and guards have to see the drills in order to get alerted. Give you the ability to toggle sensor mode on the trip mines.";
                    a.t1aA = "Gives your drills and saws a 10% chance to automatically restart after breaking.";
                    
                    a.t2aN = "Combat Engineering";
                    a.t2aB = "The radius of trip mine explosion is increased by 30%";
                    a.t2aA = "Your trip mines deal 50% more damage.";
                    
                    a.t2bN = "Drill Sawgeant";
                    a.t2bB = "Your drill and saw efficency is increased by 15%";
                    a.t2bA = "Further increases your drill and saw efficency by 15%";
                    
                    a.t3aN = "More Firepower";
                    a.t3aB = "You gain 1 more shaped charge and 4 more trip mines.";
                    a.t3aA = "You gain 2 more shaped charges and 7 more trip mines";
                    
                    a.t3bN = "Kick Starter";
                    a.t3bB = "Your drills and saws gain an additional 20% chance to automatically restart after breaking.";
                    a.t3bA = "You gain the ability to restart a drill by hitting it with a melee attack. You get 1 chance for each time it breaks with a 50% success rate.";
                    
                    a.t4aN = "Fire Trap";
                    a.t4aB = "The duration of the trip mine fire effect is increased by 0 and the radius of the fire effect is increased by 0.";
                    a.t4aA = "Your trip mines now spread fire around the area of detonation for 0 seconds in a 0 radius.";
                    break;
                case "Oppressor":
                    a.t1aN = "Steady Grip";
                    a.t1aB = "You gain 8 weapon accuracy.";
                    a.t1aA = "You gain a decreased stability penalty when shooting while moving";
                    
                    a.t2aN = "Heavy Impact";
                    a.t2aB = "Your shots have a 25% chance to knock down enemies.";
                    a.t2aA = "Your shows now have a 50% chance to knock down enemies";
                    
                    a.t2bN = "Fire Control";
                    a.t2bB = "You gain 8 weapon stability";
                    a.t2bA = "You gain 12 weapon accuracy while firing from the hip.";
                    
                    a.t3aN = "Shock and Awe";
                    a.t3aB = "You can now hip-fire with your weapons while sprinting.";
                    a.t3aA = "Killing 0 enemies with SMG, LMG and Rifles fired in automatic mode will reduce your next reload time by up to 60%. This bonus is reduced by 1% for each bullet above 20 in total magazine size, down to a minimum of 20% reload time reduction.";
                    
                    a.t3bN = "Fast Fire";
                    a.t3bB = "Your SMG, LMG and Rifles fired in automatic mode gain 15 more bullets in the magazine. This does not affect the Shock and Awe ace skill.";
                    a.t3bA = "You gain the ability to pierce body armor";
                    
                    a.t4aN = "Body Expertise";
                    a.t4aB = "15% of the enemy's headshot multiplier is applied to the enemy's body with SMG, LMG and Rifles fired in automatic mode.";
                    a.t4aA = "50% of the enemy's headshot multiplier is applied to the enemy's body with SMG, LMG and Rifles fired in automatic mode.";
                    break;
                case "Covert Ops":
                    a.t1aN = "Defence Up";
                    a.t1aB = "You gain the ability to automatically mark enemies within a 10 meter radius around you while standing still for 3.5 seconds while in stealth.";
                    a.t1aA = "You can pick up items while in casing mode. You also gain 30% more value to loose items and cash that you pick up.";
                    
                    a.t2aN = "Cleaner";
                    a.t2aB = "You gain access to all insider assets. Cleaning costs after killing a civilian is reduced by 75%.";
                    a.t2aA = "You gain 1 additional body bag in your inventory and you gain the ability to carry 1 more body bag in addition to the gained body bag.";
                    
                    a.t2bN = "Chameleon";
                    a.t2bB = "You gain a 25% increased concealment while in casing mode. You can also mark enemies while in casing mode.";
                    a.t2bA = "You gain the ability to loop 1 camera for 20 seconds, temporarily disabling it from detecting you and your crew.";
                    
                    a.t3aN = "Undertaker";
                    a.t3aB = "You gain the ability to place 2 body bag cases.";
                    a.t3aA = "You lockpick 50% faster. You also gain the ability to lockpick safes.";
                    
                    a.t3bN = "ECM Overdrive";
                    a.t3bB = "Your ECM jammer and feedback duration is increased by 25%.";
                    a.t3bA = "Your ECM jammer can now also be used to open certain electronic doors.";
                    
                    a.t4aN = "ECM Specialist";
                    a.t4aB = "You can now place 2 ECM jammers instead of just one.";
                    a.t4aA = "The ECM jammer duration is increased by 25% and the ECM feedback duration lasts 25% longer. Pagers are delayed by the ECM Jammer.";
                    break;
                case "Commando":
                    a.t1aN = "Duck and Cover";
                    a.t1aB = "Your stamina starts regenerating 25% earlier and 25% faster. You also sprint 25% faster.";
                    a.t1aA = "You have a 25% increased chance to dodge when sprinting. You gain 15% to dodge when crouching or ziplining.";

                    a.t2aN = "Evasion";
                    a.t2aB = "You gain 10% additional movement speed and 20% climbing speed.";
                    a.t2aA = "You gain the ability to sprint in any direction. Your fall damage is also reduced by 75% and you only take armor damage from falling from non fatal heights.";

                    a.t2bN = "Thick Skin";
                    a.t2bB = "Increases your melee weapon's concealment by 2.";
                    a.t2bA = "Increases all your ballistic vests' concealment by 4.";

                    a.t3aN = "Sneaky Bastard";
                    a.t3aB = "You gain a 1% dodge chance for every 3 points of concealment under 35 up to a maximum of 10%.";
                    a.t3aA = "You gain a 1% dodge chance for every 1 point of concealment under 35 up to a maximum of 10%.";

                    a.t3bN = "Shockproof";
                    a.t3bB = "The taser's shock attack has a 30% chance to backfire when targeted at you, causing the taser to be knocked back.";
                    a.t3bA = "When tased, you are able to free yourself from the taser by pressing [Interact] within 2 seconds of getting tased.";

                    a.t4aN = "Low Blow";
                    a.t4aB = "You gain a 3% critical hit chance for every 3 points of concealment under 35 up to a maximum of 30%.";
                    a.t4aA = "You gain a 3% critical hit chance for every 1 point of concealment under 35 up to a maximum of 30%.";
                    break;
                case "Silent Killer":
                    a.t1aN = "Camouflage";
                    a.t1aB = "You are 15% less likely to be targeted by enemies when you are close to one of your crew members.";
                    a.t1aA = "You are now 30% less likely to be targeted by enemies when you are close to one of your crew members.";
                    
                    a.t2aN = "Optic Illusions";
                    a.t2aB = "You gain 1 concealment for each silenced weapon you have equipped.";
                    a.t2aA = "Reduces the concealment penalty of silencers by 2.";
                    
                    a.t2bN = "The Professional";
                    a.t2bB = "You gain a 50% increase to weapon stability and 100% zoom increase with silenced weapons.";
                    a.t2bA = "You gain a 50% increase to weapon accuracy with silenced weapons.";
                    
                    a.t3aN = "Dire Need";
                    a.t3aB = "When your armor is depleted, the first shot on any enemies will cause those enemies to stagger. This effect ends when your armor regenerates";
                    a.t3aA = "This effect persists for 6 seconds after your armor has regenerated.";
                    
                    a.t3bN = "Subsonic Rounds";
                    a.t3bB = "You deal 15% more damage with all silenced weapons.";
                    a.t3bA = "You deal an additional 15% more damage with all silenced weapons.";
                    
                    a.t4aN = "Unseen Strike";
                    a.t4aB = "If you do not lose any armor or health for 2 seconds, you gain 35% critical hit chance for 4 seconds.";
                    a.t4aA = "The critical hit chance duration is increased to 12 seconds.";
                    break;
                case "Gunslinger":
                    a.t1aN = "Fast Draw";
                    a.t1aB = "Decreases the time it takes to equip and un-equip pistols by 80%.";
                    a.t1aA = "You gain a 10% increased weapon accuracy with pistols.";
                    
                    a.t2aN = "Dance Instructor";
                    a.t2aB = "Your pistol magazine sizes are increased by 15 bullets.";
                    a.t2aA = "You gain a 100% incrased rate of fire with pistols.";
                    
                    a.t2bN = "Expert Handling";
                    a.t2bB = "Each successful pistol hits gives you a 10% increased weapon accuracy bonus for 10 seconds can stack 4 times.";
                    a.t2bA = "You reload pistols 50% faster.";
                    
                    a.t3aN = "Gun Play";
                    a.t3aB = "You deal 5 additional damage with pistols.";
                    a.t3aA = "You now deal 10 additional damage with pistols.";
                    
                    a.t3bN = "Akimbo";
                    a.t3bB = "Akimbo weapons give 24 weapon stability.";
                    a.t3bA = "Akimbo weapons gain an additional 8 weapon stability and have a 50% increased total ammo capacity.";
                    
                    a.t4aN = "Trigger Happy";
                    a.t4aB = "Each successful pistol hit grants a 10% damage boost for 6 seconds and can stack 4 times.";
                    a.t4aA = "Incrases the damage boost duraction to 20.";
                    break;
                case "Relentless":
                    a.t1aN = "Nine Lives";
                    a.t1aB = "You gain a 50% increased to bleedout health.";
                    a.t1aA = "You gan the ability to get downed 1 more time before going into custody.";
                    
                    a.t2aN = "Running from Death";
                    a.t2aB = "You reload and swap weapons 80% faster after getting up for 10 seconds.";
                    a.t2aA = "You move 30% faster for 10 seconds after getting up.";
                    
                    a.t2bN = "Up you go";
                    a.t2bB = "You take 30% less damage after getting up for 10 seconds";
                    a.t2bA = "You regain 15% of your maximum health when getting up.";
                    
                    a.t3aN = "Swan Song";
                    a.t3aB = "When getting downed, you gain the ability to keep on fighting for 3 seconds with a 60% movement penalty before going down.";
                    a.t3aA = "You no longer need to reload and can fight for an additional 6 seconds when Swan Song activates.";
                    
                    a.t3bN = "Feign Death";
                    a.t3bB = "When you get downed, you have a 25% chance to instantly get revived.";
                    a.t3bA = "The chance to instantly get revived is increased by an additional 50%.";
                    
                    a.t4aN = "Messiah";
                    a.t4aB = "While in bleedout, you are instantly revived if you kill an enemy. You have only 1 charge.";
                    a.t4aA = "Your Messiah charge is replenished whenever you use a Doctor Bag";
                    break;
                case "Brawler":
                    a.t1aN = "Martial Arts";
                    a.t1aB = "Because of training, you take 50% less damage from all melee attacks.";
                    a.t1aA = "You are 50% more likely to knock down enemies with a melee strike.";
                    
                    a.t2aN = "Frenzy";
                    a.t2aB = "You start at and cannot heal about 30% of your maximum health. You also take 40% less damage.";
                    a.t2aA = "Health damage taken is now reduced by 60%";
                    
                    a.t2bN = "Pumping Iron";
                    a.t2bB = "Your melee attacks against against non-special enemies do 50% more damage.";
                    a.t2bA = "Your melee attacks against speacial enemies do 50% more damage.";
                    
                    a.t3aN = "Bloodthirst";
                    a.t3aB = "Every kill you get will increase your next melee attack damage by 50%, up to a maximum of 200%. This effect gets reset when striking an enemy with a melee attack.";
                    a.t3aA = "Whenever you kill an enemy with a melee attack, you will gain a 50% increase in reload for 0 seconds.";
                    
                    a.t3bN = "Counter Strike";
                    a.t3bB = "When charging your melee weapon you will counter attack enemies that try to strike you, knocking them down. The knockdown does not deal any damage.";
                    a.t3bA = "You gain the ability to counter attack Cloakers.";
                    
                    a.t4aN = "Berzerker";
                    a.t4aB = "The lower your health, the more damage you do. When your health is below 50%, you will do up to 250% more melee and saw damage.";
                    a.t4aA = "The lower your health, the more damage you do. When your health is below 50%, you will do up to 100% more damage with ranged weapons as well.";
                    break;
            }
            a.AddNames();

            /*
                    a.t1aN = "";
                    a.t1aB = "";
                    a.t1aA = "";
                    
                    a.t2aN = "";
                    a.t2aB = "";
                    a.t2aA = "";
                    
                    a.t2bN = "";
                    a.t2bB = "";
                    a.t2bA = "";
                    
                    a.t3aN = "";
                    a.t3aB = "";
                    a.t3aA = "";
                    
                    a.t3bN = "";
                    a.t3bB = "";
                    a.t3bA = "";
                    
                    a.t4aN = "";
                    a.t4aB = "";
                    a.t4aA = "";
            */
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(new SolidBrush(Color.Black));
            g.DrawLine(pen, 0, 227, 184, 227);
            g.DrawLine(pen, 0, 227, 0, 678 - 133);
            g.DrawLine(pen, 184, 227, 184, 678 - 133);
            g.DrawLine(pen, 0, 678 - 133, 185 - 1, 678 - 133);
            g.DrawLine(pen, 0, 454 - 66, 185 - 1, 454 - 66);
            //511
            //227
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            ClearCurrent.NotifyDefault(false);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("steam://url/SteamIDPage/76561198043274258");

        }
    }

    public class TabPanel : Panel
    {
        public Button a = new Button();
        public Button b = new Button();
        public Button c = new Button();
        public Button d = new Button();
        public Button e = new Button();
        Panel show;
        Panel a1, b1, c1, d1, e1;
        Label Title;
        public TabPanel(Panel a2, Panel b2, Panel c2, Panel d2, Panel e2, Label title)
        {
            Size = new Size(1190, 700);
            Title = title;
            a1 = a2;
            b1 = b2;
            c1 = c2;
            d1 = d2;
            e1 = e2;
            Controls.Add(a);
            Controls.Add(b);
            Controls.Add(c);
            Controls.Add(d);
            Controls.Add(e);

            Controls.Add(a1);
            Controls.Add(b1);
            Controls.Add(c1);
            Controls.Add(d1);
            Controls.Add(e1);

            BackColor = Color.FromArgb(55, 62, 84);

            foreach (Button button in Controls.OfType<Button>())
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.Black;
                button.ForeColor = Color.FromArgb(200, 200, 200);
            }
            Size ButtonSize = new Size(100, a.Size.Height);
            a.Location = new Point(0, 0);
            b.Location = new Point(ButtonSize.Width * 1, 0);
            c.Location = new Point(ButtonSize.Width * 2, 0);
            d.Location = new Point(ButtonSize.Width * 3, 0);
            e.Location = new Point(ButtonSize.Width * 4, 0);
            a.Size = ButtonSize;
            b.Size = ButtonSize;
            c.Size = ButtonSize;
            d.Size = ButtonSize;
            e.Size = ButtonSize;

            a.Click += a_Click;
            b.Click += b_Click;
            c.Click += c_Click;
            d.Click += d_Click;
            e.Click += e_Click;
            Title.Text = "Mastermind";
        }
        void a_Click(object sender, EventArgs e)
        {
            a.NotifyDefault(false);
            Title.Text = "Mastermind";
            a1.Visible = true;
            b1.Visible = false;
            c1.Visible = false;
            d1.Visible = false;
            e1.Visible = false;
        }

        void b_Click(object sender, EventArgs e)
        {
            b.NotifyDefault(false);
            Title.Text = "Enforcer";
            b1.Visible = true;
            a1.Visible = false;
            c1.Visible = false;
            d1.Visible = false;
            e1.Visible = false;
        }

        void c_Click(object sender, EventArgs e)
        {
            c.NotifyDefault(false);
            Title.Text = "Technician";
            c1.Visible = true;
            a1.Visible = false;
            b1.Visible = false;
            d1.Visible = false;
            e1.Visible = false;
        }

        void d_Click(object sender, EventArgs e)
        {
            d.NotifyDefault(false);
            Title.Text = "Ghost";
            d1.Visible = true;
            a1.Visible = false;
            b1.Visible = false;
            c1.Visible = false;
            e1.Visible = false;
        }

        void e_Click(object sender, EventArgs e)
        {
            Button t = (Button)sender;
            t.NotifyDefault(false);
            Title.Text = "Fugitive";
            e1.Visible = true;
            a1.Visible = false;
            b1.Visible = false;
            c1.Visible = false;
            d1.Visible = false;
        }
    }
    public class SubTree : Panel
    {
        public string TreeName;
        public int t1aS = 1, t2aS = 0, t2bS = 0, t3aS = 0, t3bS = 0, t4aS = 0, totalPoints = 0;
        PictureBox t1a = new PictureBox();

        PictureBox t2a = new PictureBox();
        PictureBox t2b = new PictureBox();

        PictureBox t3a = new PictureBox();
        PictureBox t3b = new PictureBox();

        PictureBox t4a = new PictureBox();
        Label L2, L3, L4;
        public string t1aB, t1aA, t2aB, t2aA, t2bB, t2bA, t3aB, t3aA, t3bB, t3bA, t4aB, t4aA, t1aN, t2aN, t2bN, t3aN, t3bN, t4aN;
        public Label l11;
        double Base;
        Panel P;
        TabPanel TP;
        int ID;
        public SubTree(string treename, Label l2, Label l3, Label l4, Panel p, TabPanel tp, int id)
        {
            P = p;
            TP = tp;
            ID = id;
            TreeName = treename;
            L2 = l2;
            L3 = l3;
            L4 = l4;
            Size = new Size(300, 520);
            Paint += SubTree_Paint;
            l11 = new Label();
            Controls.Add(l11);
            l11.Location = new Point(0, 0);
            l11.AutoSize = false;
            l11.Size = new Size(Size.Width, 50);
            l11.TextAlign = ContentAlignment.BottomCenter;
            l11.Font = new Font(l11.Font.FontFamily, 15);
            l11.Text = treename + " - 0";
            l11.ForeColor = Color.FromArgb(230, 230, 230);
            BackColor = Color.FromArgb(55, 62, 84);
            Base = (Size.Height - 30) / 4;
            

            Controls.Add(t1a);
            Controls.Add(t2a);
            Controls.Add(t2b);
            Controls.Add(t3a);
            Controls.Add(t3b);
            Controls.Add(t4a);

            t1a.SizeMode = PictureBoxSizeMode.CenterImage;
            t1a.Size = new Size(76, 76);
            t1a.Location = new Point(Size.Width / 2 - 38, (int)(Base * 4) - 70);
            if (t1aS != 0)
            {
                t1a.Image = Locked(1);
            }
            t1a.Click += t1a_Click;
            t1a.DoubleClick += t1a_DoubleClick;
            t1a.MouseEnter += t1a_MouseEnter;

            t2a.SizeMode = PictureBoxSizeMode.CenterImage;
            t2a.Size = new Size(76, 76);
            t2a.Location = new Point(Size.Width / 4 - 38, (int)(Base * 3) - 70);
            if (t2aS != 0)
            {
                t2a.Image = Locked(2);
            }
            t2a.Click += t2a_Click;
            t2a.DoubleClick += t2a_DoubleClick;
            t2a.MouseEnter += t2a_MouseEnter;

            t2b.SizeMode = PictureBoxSizeMode.CenterImage;
            t2b.Size = new Size(76, 76);
            t2b.Location = new Point(Size.Width - 116, (int)(Base * 3) - 70);
            if (t2bS != 0)
            {
                t2b.Image = Locked(2);
            }
            t2b.Click += t2b_Click;
            t2b.DoubleClick += t2b_DoubleClick;
            t2b.MouseEnter += t2b_MouseEnter;

            t3a.SizeMode = PictureBoxSizeMode.CenterImage;
            t3a.Size = new Size(76, 76);
            t3a.Location = new Point(Size.Width / 4 - 38, (int)(Base * 2) - 70);
            if (t3aS != 0)
            {
                t3a.Image = Locked(3);
            }
            t3a.Click += t3a_Click;
            t3a.DoubleClick += t3a_DoubleClick;
            t3a.MouseEnter += t3a_MouseEnter;

            t3b.SizeMode = PictureBoxSizeMode.CenterImage;
            t3b.Size = new Size(76, 76);
            t3b.Location = new Point(Size.Width - 116, (int)(Base * 2) - 70);
            if (t3bS != 0)
            {
                t3b.Image = Locked(3);
            }
            t3b.Click += t3b_Click;
            t3b.DoubleClick += t3b_DoubleClick;
            t3b.MouseEnter += t3b_MouseEnter;

            t4a.SizeMode = PictureBoxSizeMode.CenterImage;
            t4a.Size = new Size(76, 76);
            t4a.Location = new Point(Size.Width / 2 - 38, (int)(Base * 1) - 70);
            if (t4aS != 0)
            {
                t4a.Image = Locked(4);
            }
            t4a.Click += t4a_Click;
            t4a.DoubleClick += t4a_DoubleClick;
            t4a.MouseEnter += t4a_MouseEnter;

            DoUnlocks();
            
            
        }

        public Image ImageFromState(int State, int Tier)
        {
            switch (State)
            {
                case 0:
                    return Locked(Tier);
                    break;
                case 1:
                    return Unlocked(Tier);
                    break;
                case 2:
                    return Basic(Tier);
                    break;
                case 3:
                    return Ace(Tier);
                    break;
            }
            return Locked(Tier);
        }
        public void Reset()
        {
            t1aS = 1;
            t2aS = 0;
            t2bS = 0;
            t3aS = 0;
            t3bS = 0;
            t4aS = 0;
            t1a.Image = Unlocked(1);
            t2a.Image = Locked(2);
            t2b.Image = Locked(2);
            t3a.Image = Locked(3);
            t3b.Image = Locked(3);
            t4a.Image = Locked(4);
            N1a.ForeColor = unlocked;
            N2a.ForeColor = locked;
            N2b.ForeColor = locked;
            N3a.ForeColor = locked;
            N3b.ForeColor = locked;
            N4a.ForeColor = locked;
            l11.Text = TreeName + " - " + TotalPoints();
            try
            {
                if (ID == 1)
                {
                    TP.a.Text = "Mastermind - 0";
                }
                else if (ID == 2)
                {
                    TP.b.Text = "Enforcer - 0";
                }
                else if (ID == 3)
                {
                    TP.c.Text = "Technician - 0";
                }
                else if (ID == 4)
                {
                    TP.d.Text = "Ghost - 0";
                }
                else if (ID == 5)
                {
                    TP.e.Text = "Fugitive - 0";
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }
        Color unlocked = Color.FromArgb(56, 128, 178);
        Color locked = Color.FromArgb(105, 119, 130);
        Color white = Color.White;
        Label N1a = new Label();
        Label N2a = new Label();
        Label N2b = new Label();
        Label N3a = new Label();
        Label N3b = new Label();
        Label N4a = new Label();
        Label T2aB = new Label();
        public void AddNames()
        {
            
            N1a.Font = new Font(N1a.Font.FontFamily, 12);
            N1a.Text = t1aN;
            Controls.Add(N1a);
            N1a.AutoSize = false;
            N1a.Location = new Point(Size.Width / 2 - 75, (int)(Base * 4) + 5);
            N1a.Size = new Size(150, 20);
            N1a.TextAlign = ContentAlignment.BottomCenter;
            N1a.ForeColor = unlocked;

            
            N2a.Font = new Font(N2a.Font.FontFamily, 12);
            N2a.Text = t2aN;
            Controls.Add(N2a);
            N2a.AutoSize = false;
            N2a.Location = new Point(Size.Width / 4 - 75, (int)(Base * 3) + 5);
            N2a.Size = new Size((Size.Width - 90) / 2, 20);
            N2a.Location = new Point(N2a.Location.X + (N2a.Size.Width / 4) - 5, N2a.Location.Y);
            N2a.TextAlign = ContentAlignment.BottomCenter;
            N2a.ForeColor = locked;

            
            N2b.Font = new Font(N2b.Font.FontFamily, 12);
            N2b.Text = t2bN;
            Controls.Add(N2b);
            N2b.AutoSize = false;
            N2b.Location = new Point(Size.Width - (78 + 75), (int)(Base * 3) + 5);
            N2b.Size = new Size(150, 20);
            N2b.TextAlign = ContentAlignment.BottomCenter;
            N2b.ForeColor = locked;

            
            N3a.Font = new Font(N3a.Font.FontFamily, 12);
            N3a.Text = t3aN;
            Controls.Add(N3a);
            N3a.AutoSize = false;
            N3a.Location = new Point(Size.Width / 4 - 75, (int)(Base * 2) + 5);
            N3a.Size = new Size((Size.Width - 90) / 2, 20);
            N3a.Location = new Point(N3a.Location.X + (N3a.Size.Width / 4) - 5, N3a.Location.Y);
            N3a.TextAlign = ContentAlignment.BottomCenter;
            N3a.ForeColor = locked;

            
            N3b.Font = new Font(N3b.Font.FontFamily, 12);
            N3b.Text = t3bN;
            Controls.Add(N3b);
            N3b.AutoSize = false;
            N3b.Location = new Point(Size.Width - (78 + 75), (int)(Base * 2) + 5);
            N3b.Size = new Size(150, 20);
            N3b.TextAlign = ContentAlignment.BottomCenter;
            N3b.ForeColor = locked;

            
            N4a.Font = new Font(N4a.Font.FontFamily, 12);
            N4a.Text = t4aN;
            Controls.Add(N4a);
            N4a.AutoSize = false;
            N4a.Location = new Point(Size.Width / 2 - 75, (int)(Base * 1) + 5);
            N4a.Size = new Size(150, 20);
            N4a.TextAlign = ContentAlignment.BottomCenter;
            N4a.ForeColor = locked;

            DoUnlocks();
        }

        void t4a_MouseEnter(object sender, EventArgs e)
        {
            L3.Visible = true;
            L3.Text = t4aB;
            L3.Refresh();
            L4.Visible = true;
            L4.Text = t4aA;
            L4.Refresh();
        }

        void t3b_MouseEnter(object sender, EventArgs e)
        {
            L3.Visible = true;
            L3.Text = t3bB;
            L3.Refresh();
            L4.Visible = true;
            L4.Text = t3bA;
            L4.Refresh();
        }

        void t2b_MouseEnter(object sender, EventArgs e)
        {
            L3.Visible = true;
            L3.Text = t2bB;
            L3.Refresh();
            L4.Visible = true;
            L4.Text = t2bA;
            L4.Refresh();
        }

        void t3a_MouseEnter(object sender, EventArgs e)
        {
            L3.Visible = true;
            L3.Text = t3aB;
            L3.Refresh();
            L4.Visible = true;
            L4.Text = t3aA;
            L4.Refresh();
        }

        void t2a_MouseEnter(object sender, EventArgs e)
        {
            L3.Visible = true;
            L3.Text = t2aB;
            L3.Refresh();
            L4.Visible = true;
            L4.Text = t2aA;
            L4.Refresh();
        }

        void t1a_MouseEnter(object sender, EventArgs e)
        {
            L3.Visible = true;
            L3.Text = t1aB;
            L3.Refresh();
            L4.Visible = true;
            L4.Text = t1aA;
            L4.Refresh();
            //t1a.Focus();
        }

        void t4a_DoubleClick(object sender, EventArgs e)
        {
            t4a_Click(sender, e);
        }

        void t4a_Click(object sender, EventArgs e)
        {
            t4a.Focus();
            int PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
            MouseEventArgs me = (MouseEventArgs)e;
            switch (me.Button)
            {
                case MouseButtons.Left:
                    switch (t4aS)
                    {
                        case 2:
                            if (PointsLeft >= 6)
                            {
                                t4aS = 3;
                                totalPoints += 6;
                                t4a.Image = Ace(4);
                                N4a.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 6);
                            }
                            break;
                        case 1:
                            if (PointsLeft >= 4)
                            {
                                t4aS = 2;
                                totalPoints += 4;
                                t4a.Image = Basic(4);
                                N4a.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 4);
                            }
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (t4aS)
                    {
                        case 2:
                            t4aS = 1;
                            totalPoints -= 2;
                            t4a.Image = Unlocked(4);
                            N4a.ForeColor = unlocked;
                            L2.Text = "Skill Points left: " + (PointsLeft + 4);
                            break;
                        case 3:
                            t4aS = 2;
                            totalPoints -= 4;
                            t4a.Image = Basic(4);
                            N4a.ForeColor = white;
                            L2.Text = "Skill Points left: " + (PointsLeft + 6);
                            break;
                    }
                    break;

            }
            DoUnlocks();
        }

        void t3b_DoubleClick(object sender, EventArgs e)
        {
            t3b_Click(sender, e);
        }

        void t3b_Click(object sender, EventArgs e)
        {
            t3b.Focus();
            int PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
            MouseEventArgs me = (MouseEventArgs)e;
            switch (me.Button)
            {
                case MouseButtons.Left:
                    switch (t3bS)
                    {
                        case 2:
                            if (PointsLeft >= 5)
                            {
                                t3bS = 3;
                                totalPoints += 5;
                                t3b.Image = Ace(3);
                                N3b.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 5);
                            }
                            break;
                        case 1:
                            if (PointsLeft >= 3)
                            {
                                t3bS = 2;
                                totalPoints += 3;
                                t3b.Image = Basic(3);
                                N3b.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 3);
                            }
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (t3bS)
                    {
                        case 2:
                            t3bS = 1;
                            totalPoints -= 3;
                            t3b.Image = Unlocked(3);
                            N3b.ForeColor = unlocked;
                            L2.Text = "Skill Points left: " + (PointsLeft + 3);
                            break;
                        case 3:
                            t3bS = 2;
                            totalPoints -= 5;
                            t3b.Image = Basic(3);
                            N3b.ForeColor = white;
                            L2.Text = "Skill Points left: " + (PointsLeft + 5);
                            break;
                    }
                    break;

            }
            DoUnlocks();
        }

        void t3a_DoubleClick(object sender, EventArgs e)
        {
            t3a_Click(sender, e);
        }

        void t3a_Click(object sender, EventArgs e)
        {
            t3a.Focus();
            int PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
            MouseEventArgs me = (MouseEventArgs)e;
            switch (me.Button)
            {
                case MouseButtons.Left:
                    switch (t3aS)
                    {
                        case 2:
                            if (PointsLeft >= 5)
                            {
                                t3aS = 3;
                                totalPoints += 5;
                                t3a.Image = Ace(3);
                                N3a.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 5);
                            }
                            break;
                        case 1:
                            if (PointsLeft >= 3)
                            {
                                t3aS = 2;
                                totalPoints += 3;
                                t3a.Image = Basic(3);
                                N3a.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 3);
                            }
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (t3aS)
                    {
                        case 2:
                            t3aS = 1;
                            totalPoints -= 3;
                            t3a.Image = Unlocked(3);
                            N3a.ForeColor = unlocked;
                            L2.Text = "Skill Points left: " + (PointsLeft + 3);
                            break;
                        case 3:
                            t3aS = 2;
                            totalPoints -= 5;
                            t3a.Image = Basic(3);
                            N3a.ForeColor = white;
                            L2.Text = "Skill Points left: " + (PointsLeft + 5);
                            break;
                    }
                    break;

            }
            DoUnlocks();
        }

        void t2b_DoubleClick(object sender, EventArgs e)
        {
            t2b_Click(sender, e);
        }

        void t2b_Click(object sender, EventArgs e)
        {
            t2b.Focus();
            int PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
            MouseEventArgs me = (MouseEventArgs)e;
            switch (me.Button)
            {
                case MouseButtons.Left:
                    switch (t2bS)
                    {
                        case 2:
                            if (PointsLeft >= 4)
                            {
                                t2bS = 3;
                                totalPoints += 4;
                                t2b.Image = Ace(2);
                                N2b.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 4);
                            }
                            break;
                        case 1:
                            if (PointsLeft >= 2)
                            {
                                t2bS = 2;
                                totalPoints += 2;
                                t2b.Image = Basic(2);
                                N2b.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 2);
                            }
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (t2bS)
                    {
                        case 2:
                            t2bS = 1;
                            totalPoints -= 2;
                            t2b.Image = Unlocked(2);
                            N2b.ForeColor = unlocked;
                            L2.Text = "Skill Points left: " + (PointsLeft + 2);
                            break;
                        case 3:
                            t2bS = 2;
                            totalPoints -= 4;
                            t2b.Image = Basic(2);
                            N2b.ForeColor = white;
                            L2.Text = "Skill Points left: " + (PointsLeft + 4);
                            break;
                    }
                    break;

            }
            DoUnlocks();
        }

        void t2a_DoubleClick(object sender, EventArgs e)
        {
            t2a_Click(sender, e);
        }

        void t2a_Click(object sender, EventArgs e)
        {
            t2a.Focus();
            int PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
            MouseEventArgs me = (MouseEventArgs)e;
            switch (me.Button)
            {
                case MouseButtons.Left:
                    switch (t2aS)
                    {
                        case 2:
                            if (PointsLeft >= 4)
                            {
                                t2aS = 3;
                                totalPoints += 4;
                                t2a.Image = Ace(2);
                                N2a.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 4);
                            }
                            break;
                        case 1:
                            if (PointsLeft >= 2)
                            {
                                t2aS = 2;
                                totalPoints += 2;
                                t2a.Image = Basic(2);
                                N2a.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 2);
                            }
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (t2aS)
                    {
                        case 2:
                            t2aS = 1;
                            totalPoints -= 2;
                            t2a.Image = Unlocked(2);
                            N2a.ForeColor = unlocked;
                            L2.Text = "Skill Points left: " + (PointsLeft + 2);
                            break;
                        case 3:
                            t2aS = 2;
                            totalPoints -= 4;
                            t2a.Image = Basic(2);
                            N2a.ForeColor = white;
                            L2.Text = "Skill Points left: " + (PointsLeft + 4);
                            break;
                    }
                    break;

            }
            DoUnlocks();
        }

        void t1a_DoubleClick(object sender, EventArgs e)
        {
            t1a_Click(sender, e);
        }

        public void DoUnlocks()
        {
            int newTotal = 0;
            //Tier 1
            if (newTotal >= 0)
            {
                if (t1aS == 0)
                {
                    t1aS = 1;
                    t1a.Image = Unlocked(1);
                    N1a.ForeColor = unlocked;
                }
            }
            //Tier 2
            switch (t1aS)
            {
                case 2:
                    newTotal += 1;
                    break;
                case 3:
                    newTotal += 4;
                    break;
            }
            
            if (newTotal >= 4)
            {
                if (t2aS == 0)
                {
                    t2aS = 1;
                    N2a.ForeColor = unlocked;
                    t2a.Image = Unlocked(2);
                }
                if (t2bS == 0)
                {
                    t2bS = 1;
                    N2b.ForeColor = unlocked;
                    t2b.Image = Unlocked(2);
                }
            }
            else
            {
                int PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                switch (t2bS)
                {
                    case 1:
                        t2bS = 0;
                        t2b.Image = Locked(2);
                        N2b.ForeColor = locked;
                        break;
                    case 2:
                        t2bS = 0;
                        PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                        L2.Text = "Skill Points left: " + (PointsLeft + 2);
                        N2b.ForeColor = locked;
                        t2b.Image = Locked(2);
                        break;
                    case 3:
                        t2bS = 0;
                        PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                        L2.Text = "Skill Points left: " + (PointsLeft + 6);
                        N2b.ForeColor = locked;
                        t2b.Image = Locked(2);
                        break;
                }
                
                switch (t2aS)
                {
                    case 1:
                        t2aS = 0;
                        t2a.Image = Locked(2);
                        N2a.ForeColor = locked;
                        break;
                    case 2:
                        t2aS = 0;
                        PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                        L2.Text = "Skill Points left: " + (PointsLeft + 2);
                        N2a.ForeColor = locked;
                        t2a.Image = Locked(2);
                        break;
                    case 3:
                        t2aS = 0;
                        PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                        L2.Text = "Skill Points left: " + (PointsLeft + 6);
                        N2a.ForeColor = locked;
                        t2a.Image = Locked(2);
                        break;
                }
            }
            //Tier 3
            switch (t2aS)
            {
                case 2:
                    newTotal += 2;
                    break;
                case 3:
                    newTotal += 6;
                    break;
            }
            switch (t2bS)
            {
                case 2:
                    newTotal += 2;
                    break;
                case 3:
                    newTotal += 6;
                    break;
            }

            if (newTotal >= 10)
            {
                if (t3aS == 0)
                {
                    t3aS = 1;
                    N3a.ForeColor = unlocked;
                    t3a.Image = Unlocked(3);
                }
                if (t3bS == 0)
                {
                    t3bS = 1;
                    N3b.ForeColor = unlocked;
                    t3b.Image = Unlocked(3);
                }
            }
            else
            {
                int PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                switch (t3bS)
                {
                    case 1:
                        t3bS = 0;
                        N3b.ForeColor = locked;
                        t3b.Image = Locked(3);
                        break;
                    case 2:
                        t3bS = 0;
                        PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                        L2.Text = "Skill Points left: " + (PointsLeft + 3);
                        N3b.ForeColor = locked;
                        t3b.Image = Locked(3);
                        break;
                    case 3:
                        t3bS = 0;
                        PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                        L2.Text = "Skill Points left: " + (PointsLeft + 8);
                        N3b.ForeColor = locked;
                        t3b.Image = Locked(3);
                        break;
                }

                switch (t3aS)
                {
                    case 1:
                        t3aS = 0;
                        N3a.ForeColor = locked;
                        t3a.Image = Locked(3);
                        break;
                    case 2:
                        t3aS = 0;
                        PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                        L2.Text = "Skill Points left: " + (PointsLeft + 3);
                        N3a.ForeColor = locked;
                        t3a.Image = Locked(3);
                        break;
                    case 3:
                        t3aS = 0;
                        PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                        L2.Text = "Skill Points left: " + (PointsLeft + 8);
                        N3a.ForeColor = locked;
                        t3a.Image = Locked(3);
                        break;
                }
            }
            //Tier 4
            switch (t3aS)
            {
                case 2:
                    newTotal += 3;
                    break;
                case 3:
                    newTotal += 8;
                    break;
            }
            switch (t3bS)
            {
                case 2:
                    newTotal += 3;
                    break;
                case 3:
                    newTotal += 8;
                    break;
            }
            if (newTotal >= 18)
            {
                if (t4aS == 0)
                {
                    t4aS = 1;
                    N4a.ForeColor = unlocked;
                    t4a.Image = Unlocked(4);
                }
            }
            else
            {
                int PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                switch (t4aS)
                {
                    case 1:
                        t4aS = 0;
                        N4a.ForeColor = locked;
                        t4a.Image = Locked(4);
                        break;
                    case 2:
                        t4aS = 0;
                        PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                        L2.Text = "Skill Points left: " + (PointsLeft + 4);
                        N4a.ForeColor = locked;
                        t4a.Image = Locked(4);
                        break;
                    case 3:
                        t4aS = 0;
                        PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
                        L2.Text = "Skill Points left: " + (PointsLeft + 10);
                        N4a.ForeColor = locked;
                        t4a.Image = Locked(4);
                        break;
                }
            }
            t1a.Image = ImageFromState(t1aS, 1);
            N1a.ForeColor = LabelByState(t1aS);
            t2a.Image = ImageFromState(t2aS, 2);
            N2a.ForeColor = LabelByState(t2aS);
            t2b.Image = ImageFromState(t2bS, 2);
            N2b.ForeColor = LabelByState(t2bS);
            t3a.Image = ImageFromState(t3aS, 3);
            N3a.ForeColor = LabelByState(t3aS);
            t3b.Image = ImageFromState(t3bS, 3);
            N3b.ForeColor = LabelByState(t3bS);
            t4a.Image = ImageFromState(t4aS, 4);
            N4a.ForeColor = LabelByState(t4aS);

            l11.Text = TreeName + " - " + TotalPoints();
            int AllPoints = 0;
            foreach (SubTree c in P.Controls.OfType<SubTree>())
            {
                AllPoints += Convert.ToInt32(c.l11.Text.Substring(c.l11.Text.IndexOf("-") + 2));
            }
            try
            {
                if (ID == 1)
                {
                    TP.a.Text = "Mastermind - " + AllPoints;
                }
                else if (ID == 2)
                {
                    TP.b.Text = "Enforcer - " + AllPoints;
                }
                else if (ID == 3)
                {
                    TP.c.Text = "Technician - " + AllPoints;
                }
                else if (ID == 4)
                {
                    TP.d.Text = "Ghost - " + AllPoints;
                }
                else if (ID == 5)
                {
                    TP.e.Text = "Fugitive - " + AllPoints;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        public Color LabelByState(int State)
        {
            switch (State)
            {
                case 0:
                    return locked;
                    break;
                case 1:
                    return unlocked;
                    break;
                case 2:
                    return white;
                    break;
                case 3:
                    return white;
                    break;
            }
            return locked;
        }

        void t1a_Click(object sender, EventArgs e)
        {
            t1a.Focus();
            int PointsLeft = Convert.ToInt32(L2.Text.Substring(L2.Text.IndexOf(":") + 2));
            MouseEventArgs me = (MouseEventArgs) e;
            switch (me.Button)
            {
                case MouseButtons.Left:
                    switch (t1aS)
                    {
                        case 2:
                            if (PointsLeft >= 3)
                            {
                                t1aS = 3;
                                totalPoints += 3;
                                t1a.Image = Ace(1);
                                N1a.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 3);
                            }
                            break;
                        case 1:
                            if (PointsLeft >= 1)
                            {
                                t1aS = 2;
                                totalPoints += 1;
                                t1a.Image = Basic(1);
                                N1a.ForeColor = white;
                                L2.Text = "Skill Points left: " + (PointsLeft - 1);
                            }
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (t1aS)
                    {
                        case 2:
                            t1aS = 1;
                            totalPoints -= 1;
                            t1a.Image = Unlocked(1);
                            N1a.ForeColor = unlocked;
                            L2.Text = "Skill Points left: " + (PointsLeft + 1);
                            break;
                        case 3:
                            t1aS = 2;
                            totalPoints -= 3;
                            t1a.Image = Basic(1);
                            N1a.ForeColor = white;
                            L2.Text = "Skill Points left: " + (PointsLeft + 3);
                            break;
                    }
                    break;

            }
            DoUnlocks();
        }

        void SubTree_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Gray, 0, 50, Size.Width - 1, 50);
            g.DrawLine(Pens.Gray, 0, 50, 0, Size.Height - 1);
            g.DrawLine(Pens.Gray, 0, Size.Height - 1, Size.Width - 1, Size.Height - 1);
            g.DrawLine(Pens.Gray, Size.Width - 1, 50, Size.Width - 1, Size.Height - 1);
        }

        public Bitmap Ace(int Tier)
        {
            Bitmap bit = Basic(Tier);
            Bitmap bit2 = new Bitmap(76, 76);
            Graphics g = Graphics.FromImage(bit2);
            g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, 76, 76);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(80, Color.White)), 1, 1, 74, 74);
            g.FillRectangle(new SolidBrush(Color.FromArgb(120, Color.White)), 2, 2, 72, 72);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(160, Color.White)), 3, 3, 70, 70);
            g.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.White)), 4, 4, 68, 68);
            //g.FillRectangle(new SolidBrush(Color.FromArgb(240, Color.White)), 5, 5, 66, 66);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, Color.White)), 6, 6, 64, 64);
            g.FillRectangle(new SolidBrush(Color.FromArgb(55, 62, 84)), 6, 6, 64, 64);
            g.DrawImage(bit, 6, 6);
            return bit2;
        }

        public Bitmap Locked(int Tier)
        {
            Bitmap bit = new Bitmap(64, 64);
            Graphics g = Graphics.FromImage(bit);
            Pen pen = new Pen(new SolidBrush(Color.FromArgb(105, 119, 130)), 3);
            g.DrawLine(pen, 0, 0, 63, 0);
            g.DrawLine(pen, 0, 0, 0, 63);
            g.DrawLine(pen, 63, 0, 63, 63);
            g.DrawLine(pen, 64, 63, 0, 63);
            Label l1 = new Label();
            l1.Font = new Font(l1.Font.FontFamily, 50);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(Tier.ToString(), l1.Font, new SolidBrush(Color.FromArgb(105, 119, 130)), 2, -5);
            l1.Font = new Font(l1.Font.FontFamily, 9);
            int Basic = 0;
            int Ace = 0;
            int Require = 0;
            switch (Tier)
            {
                case 1:
                    Basic = 1;
                    Ace = 3;
                    Require = 0;
                    break;
                case 2:
                    Basic = 2;
                    Ace = 4;
                    Require = 4;
                    break;
                case 3:
                    Basic = 3;
                    Ace = 5;
                    Require = 10;
                    break;
                case 4:
                    Basic = 4;
                    Ace = 6;
                    Require = 18;
                    break;
            }
            g.DrawString(Basic.ToString(), l1.Font, new SolidBrush(Color.FromArgb(105, 119, 130)), 0, 48);
            g.DrawString(Ace.ToString(), l1.Font, new SolidBrush(Color.FromArgb(105, 119, 130)), 53, 48);
            g.DrawString((Require - TotalPoints()).ToString(), l1.Font, new SolidBrush(Color.FromArgb(105, 119, 130)), 1, 0);
            return bit;
        }


        public int TotalPoints()
        {
            int newTotal = 0;
            switch (t1aS)
            {
                case 2:
                    newTotal += 1;
                    break;
                case 3:
                    newTotal += 4;
                    break;
            }
            switch (t2aS)
            {
                case 2:
                    newTotal += 2;
                    break;
                case 3:
                    newTotal += 6;
                    break;
            }
            switch (t2bS)
            {
                case 2:
                    newTotal += 2;
                    break;
                case 3:
                    newTotal += 6;
                    break;
            }
            switch (t3aS)
            {
                case 2:
                    newTotal += 3;
                    break;
                case 3:
                    newTotal += 8;
                    break;
            }
            switch (t3bS)
            {
                case 2:
                    newTotal += 3;
                    break;
                case 3:
                    newTotal += 8;
                    break;
            }
            switch (t4aS)
            {
                case 2:
                    newTotal += 4;
                    break;
                case 3:
                    newTotal += 10;
                    break;
            }
            return newTotal;
        }
        public Bitmap Unlocked(int Tier)
        {
            Bitmap bit = new Bitmap(64, 64);
            Graphics g = Graphics.FromImage(bit);
            Pen pen = new Pen(new SolidBrush(Color.FromArgb(56, 128, 178)), 3);
            g.DrawLine(pen, 0, 0, 63, 0);
            g.DrawLine(pen, 0, 0, 0, 63);
            g.DrawLine(pen, 63, 0, 63, 63);
            g.DrawLine(pen, 64, 63, 0, 63);
            Label l1 = new Label();
            l1.Font = new Font(l1.Font.FontFamily, 50);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(Tier.ToString(), l1.Font, new SolidBrush(Color.FromArgb(56, 128, 178)), 2, -5);
            l1.Font = new Font(l1.Font.FontFamily, 9);
            int Basic = 0;
            int Ace = 0;
            int Require = 0;
            switch (Tier)
            {
                case 1:
                    Basic = 1;
                    Ace = 3;
                    Require = 0;
                    break;
                case 2:
                    Basic = 2;
                    Ace = 4;
                    Require = 4;
                    break;
                case 3:
                    Basic = 3;
                    Ace = 5;
                    Require = 10;
                    break;
                case 4:
                    Basic = 4;
                    Ace = 6;
                    Require = 18;
                    break;
            }
            g.DrawString(Basic.ToString(), l1.Font, new SolidBrush(Color.FromArgb(56, 128, 178)), 0, 48);
            g.DrawString(Ace.ToString(), l1.Font, new SolidBrush(Color.FromArgb(56, 128, 178)), 53, 48);
            g.DrawString("0", l1.Font, new SolidBrush(Color.FromArgb(56, 128, 178)), 1, 0);
            return bit;
        }

        public Bitmap Basic(int Tier)
        {
            Bitmap bit = new Bitmap(64, 64);
            Graphics g = Graphics.FromImage(bit);
            Pen pen = new Pen(new SolidBrush(Color.White), 3);
            g.DrawLine(pen, 0, 0, 63, 0);
            g.DrawLine(pen, 0, 0, 0, 63);
            g.DrawLine(pen, 63, 0, 63, 63);
            g.DrawLine(pen, 64, 63, 0, 63);
            Label l1 = new Label();
            l1.Font = new Font(l1.Font.FontFamily, 50);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(Tier.ToString(), l1.Font, new SolidBrush(Color.White), 2, -5);
            l1.Font = new Font(l1.Font.FontFamily, 9);
            int Basic = 0;
            int Ace = 0;
            int Require = 0;
            switch (Tier)
            {
                case 1:
                    Basic = 1;
                    Ace = 3;
                    Require = 0;
                    break;
                case 2:
                    Basic = 2;
                    Ace = 4;
                    Require = 4;
                    break;
                case 3:
                    Basic = 3;
                    Ace = 5;
                    Require = 10;
                    break;
                case 4:
                    Basic = 4;
                    Ace = 6;
                    Require = 18;
                    break;
            }
            g.DrawString(Basic.ToString(), l1.Font, new SolidBrush(Color.White), 0, 48);
            g.DrawString(Ace.ToString(), l1.Font, new SolidBrush(Color.White), 53, 48);
            g.DrawString("0", l1.Font, new SolidBrush(Color.White), 1, 0);
            return bit;
        }

        
    }
}
