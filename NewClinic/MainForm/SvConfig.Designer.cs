
namespace NewClinic.MainForm
{
    partial class SvConfig
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
            this.txtservername = new System.Windows.Forms.TextBox();
            this.flpsv = new System.Windows.Forms.FlowLayoutPanel();
            this.svlist1 = new NewClinic.ControlSV.svlist();
            this.txtuserid = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btpass = new FontAwesome.Sharp.IconButton();
            this.btnadd = new FontAwesome.Sharp.IconButton();
            this.btnconec = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.flpsv.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtservername
            // 
            this.txtservername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtservername.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtservername.Location = new System.Drawing.Point(164, 97);
            this.txtservername.Name = "txtservername";
            this.txtservername.Size = new System.Drawing.Size(382, 34);
            this.txtservername.TabIndex = 1;
            // 
            // flpsv
            // 
            this.flpsv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpsv.AutoScroll = true;
            this.flpsv.Controls.Add(this.svlist1);
            this.flpsv.Location = new System.Drawing.Point(12, 247);
            this.flpsv.Name = "flpsv";
            this.flpsv.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.flpsv.Size = new System.Drawing.Size(742, 283);
            this.flpsv.TabIndex = 2;
            // 
            // svlist1
            // 
            this.svlist1.BackColor = System.Drawing.Color.Transparent;
            this.svlist1.Location = new System.Drawing.Point(18, 3);
            this.svlist1.MinimumSize = new System.Drawing.Size(692, 52);
            this.svlist1.Name = "svlist1";
            this.svlist1.Size = new System.Drawing.Size(692, 52);
            this.svlist1.TabIndex = 0;
            // 
            // txtuserid
            // 
            this.txtuserid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtuserid.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuserid.Location = new System.Drawing.Point(164, 148);
            this.txtuserid.Name = "txtuserid";
            this.txtuserid.Size = new System.Drawing.Size(382, 34);
            this.txtuserid.TabIndex = 1;
            // 
            // txtpass
            // 
            this.txtpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpass.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpass.Location = new System.Drawing.Point(164, 199);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(333, 34);
            this.txtpass.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(109)))));
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 45);
            this.panel1.TabIndex = 3;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.XmarkSquare;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(714, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(51, 45);
            this.iconButton1.TabIndex = 4;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            this.iconButton1.MouseEnter += new System.EventHandler(this.iconButton3_MouseEnter);
            this.iconButton1.MouseLeave += new System.EventHandler(this.iconButton3_MouseLeave);
            this.iconButton1.MouseHover += new System.EventHandler(this.iconButton3_MouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Config";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(77, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(49, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Server Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(74, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password:";
            // 
            // btpass
            // 
            this.btpass.BackColor = System.Drawing.Color.Transparent;
            this.btpass.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btpass.FlatAppearance.BorderSize = 0;
            this.btpass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btpass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btpass.ForeColor = System.Drawing.Color.Black;
            this.btpass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.btpass.IconColor = System.Drawing.Color.Black;
            this.btpass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btpass.IconSize = 30;
            this.btpass.Location = new System.Drawing.Point(503, 199);
            this.btpass.Name = "btpass";
            this.btpass.Size = new System.Drawing.Size(43, 34);
            this.btpass.TabIndex = 4;
            this.btpass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btpass.UseVisualStyleBackColor = false;
            this.btpass.Click += new System.EventHandler(this.btpass_Click);
            this.btpass.MouseEnter += new System.EventHandler(this.btpass_MouseEnter);
            this.btpass.MouseLeave += new System.EventHandler(this.btpass_MouseLeave);
            this.btpass.MouseHover += new System.EventHandler(this.btpass_MouseEnter);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(69)))), ((int)(((byte)(120)))));
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.IconChar = FontAwesome.Sharp.IconChar.SquarePlus;
            this.btnadd.IconColor = System.Drawing.Color.White;
            this.btnadd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnadd.IconSize = 25;
            this.btnadd.Location = new System.Drawing.Point(604, 192);
            this.btnadd.Name = "btnadd";
            this.btnadd.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnadd.Size = new System.Drawing.Size(112, 40);
            this.btnadd.TabIndex = 4;
            this.btnadd.Text = "Add";
            this.btnadd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnconec
            // 
            this.btnconec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(109)))), ((int)(((byte)(130)))));
            this.btnconec.FlatAppearance.BorderSize = 0;
            this.btnconec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconec.ForeColor = System.Drawing.Color.White;
            this.btnconec.IconChar = FontAwesome.Sharp.IconChar.Server;
            this.btnconec.IconColor = System.Drawing.Color.White;
            this.btnconec.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnconec.IconSize = 25;
            this.btnconec.Location = new System.Drawing.Point(604, 141);
            this.btnconec.Name = "btnconec";
            this.btnconec.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnconec.Size = new System.Drawing.Size(112, 40);
            this.btnconec.TabIndex = 4;
            this.btnconec.Text = "Connect";
            this.btnconec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnconec.UseVisualStyleBackColor = false;
            this.btnconec.Click += new System.EventHandler(this.btnconec_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.Firebrick;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 25;
            this.iconButton2.Location = new System.Drawing.Point(604, 95);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(112, 40);
            this.iconButton2.TabIndex = 4;
            this.iconButton2.Text = "Clear";
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // SvConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(765, 546);
            this.Controls.Add(this.btpass);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.btnconec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpsv);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtuserid);
            this.Controls.Add(this.txtservername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SvConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SvConfig";
            this.Load += new System.EventHandler(this.SvConfig_Load);
            this.flpsv.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtservername;
        private System.Windows.Forms.FlowLayoutPanel flpsv;
        private System.Windows.Forms.TextBox txtuserid;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnconec;
        private FontAwesome.Sharp.IconButton btnadd;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btpass;
        private ControlSV.svlist svlist1;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}