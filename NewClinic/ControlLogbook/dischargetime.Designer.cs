
namespace NewClinic.ControlLogbook
{
    partial class dischargetime
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconcan = new FontAwesome.Sharp.IconButton();
            this.cbtime = new System.Windows.Forms.CheckBox();
            this.iconok = new FontAwesome.Sharp.IconButton();
            this.txtout = new System.Windows.Forms.TextBox();
            this.txtdate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(107)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 52);
            this.panel1.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 27);
            this.label3.TabIndex = 24;
            this.label3.Text = "Clinic System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.iconcan);
            this.panel2.Controls.Add(this.cbtime);
            this.panel2.Controls.Add(this.iconok);
            this.panel2.Controls.Add(this.txtout);
            this.panel2.Controls.Add(this.txtdate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(444, 320);
            this.panel2.TabIndex = 33;
            // 
            // iconcan
            // 
            this.iconcan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconcan.BackColor = System.Drawing.Color.Firebrick;
            this.iconcan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconcan.FlatAppearance.BorderSize = 0;
            this.iconcan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconcan.ForeColor = System.Drawing.Color.White;
            this.iconcan.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconcan.IconColor = System.Drawing.Color.Black;
            this.iconcan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconcan.Location = new System.Drawing.Point(314, 263);
            this.iconcan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconcan.Name = "iconcan";
            this.iconcan.Size = new System.Drawing.Size(100, 39);
            this.iconcan.TabIndex = 37;
            this.iconcan.Text = "Cancel";
            this.iconcan.UseVisualStyleBackColor = false;
            this.iconcan.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // cbtime
            // 
            this.cbtime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbtime.AutoSize = true;
            this.cbtime.Checked = true;
            this.cbtime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbtime.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtime.Location = new System.Drawing.Point(140, 210);
            this.cbtime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbtime.Name = "cbtime";
            this.cbtime.Size = new System.Drawing.Size(232, 26);
            this.cbtime.TabIndex = 36;
            this.cbtime.Text = "Use Current Date and Time";
            this.cbtime.UseVisualStyleBackColor = true;
            this.cbtime.CheckedChanged += new System.EventHandler(this.cbtime_CheckedChanged);
            // 
            // iconok
            // 
            this.iconok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(107)))));
            this.iconok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconok.FlatAppearance.BorderSize = 0;
            this.iconok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconok.ForeColor = System.Drawing.Color.White;
            this.iconok.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconok.IconColor = System.Drawing.Color.Black;
            this.iconok.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconok.Location = new System.Drawing.Point(206, 263);
            this.iconok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iconok.Name = "iconok";
            this.iconok.Size = new System.Drawing.Size(100, 39);
            this.iconok.TabIndex = 35;
            this.iconok.Text = "Ok";
            this.iconok.UseVisualStyleBackColor = false;
            this.iconok.Click += new System.EventHandler(this.iconok_Click);
            // 
            // txtout
            // 
            this.txtout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtout.Enabled = false;
            this.txtout.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtout.Location = new System.Drawing.Point(134, 162);
            this.txtout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtout.Name = "txtout";
            this.txtout.Size = new System.Drawing.Size(247, 34);
            this.txtout.TabIndex = 33;
            // 
            // txtdate
            // 
            this.txtdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdate.Enabled = false;
            this.txtdate.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdate.Location = new System.Drawing.Point(134, 111);
            this.txtdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(247, 34);
            this.txtdate.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "Time Out:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 22);
            this.label1.TabIndex = 31;
            this.label1.Text = "Date:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dischargetime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 320);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "dischargetime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dischargetime";
            this.Load += new System.EventHandler(this.dischargetime_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbtime;
        public FontAwesome.Sharp.IconButton iconok;
        private System.Windows.Forms.TextBox txtout;
        private System.Windows.Forms.TextBox txtdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        public FontAwesome.Sharp.IconButton iconcan;
    }
}