namespace PD2STOB
{
    partial class SaveLoad
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
            this.a = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // a
            // 
            this.a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(62)))), ((int)(((byte)(84)))));
            this.a.FormattingEnabled = true;
            this.a.Location = new System.Drawing.Point(12, 12);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(120, 95);
            this.a.TabIndex = 0;
            // 
            // SaveLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.a);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SaveLoad";
            this.Text = "SaveLoad";
            this.Load += new System.EventHandler(this.SaveLoad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox a;
    }
}