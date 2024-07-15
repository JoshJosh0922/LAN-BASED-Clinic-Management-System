
namespace NewClinic.ControlFile
{
    partial class addfileform
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
            this.bunifuCards5 = new Bunifu.Framework.UI.BunifuCards();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.iconButton9 = new FontAwesome.Sharp.IconButton();
            this.btclear = new FontAwesome.Sharp.IconButton();
            this.flpfile = new System.Windows.Forms.FlowLayoutPanel();
            this.addfile1 = new NewClinic.ControlFile.addfile();
            this.label2 = new System.Windows.Forms.Label();
            this.btsave = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.bunifuCards5.SuspendLayout();
            this.flpfile.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards5
            // 
            this.bunifuCards5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(107)))));
            this.bunifuCards5.BorderRadius = 15;
            this.bunifuCards5.BottomSahddow = false;
            this.bunifuCards5.color = System.Drawing.Color.Transparent;
            this.bunifuCards5.Controls.Add(this.label5);
            this.bunifuCards5.Controls.Add(this.label4);
            this.bunifuCards5.LeftSahddow = false;
            this.bunifuCards5.Location = new System.Drawing.Point(26, 137);
            this.bunifuCards5.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuCards5.Name = "bunifuCards5";
            this.bunifuCards5.RightSahddow = false;
            this.bunifuCards5.ShadowDepth = 20;
            this.bunifuCards5.Size = new System.Drawing.Size(896, 68);
            this.bunifuCards5.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(63, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "File Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(628, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "File Size";
            // 
            // iconButton9
            // 
            this.iconButton9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(107)))));
            this.iconButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton9.FlatAppearance.BorderSize = 0;
            this.iconButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton9.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton9.ForeColor = System.Drawing.Color.White;
            this.iconButton9.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton9.IconColor = System.Drawing.Color.Black;
            this.iconButton9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton9.Location = new System.Drawing.Point(660, 90);
            this.iconButton9.Margin = new System.Windows.Forms.Padding(4);
            this.iconButton9.Name = "iconButton9";
            this.iconButton9.Size = new System.Drawing.Size(115, 38);
            this.iconButton9.TabIndex = 76;
            this.iconButton9.Text = "Upload";
            this.iconButton9.UseVisualStyleBackColor = false;
            this.iconButton9.Click += new System.EventHandler(this.iconButton9_Click);
            // 
            // btclear
            // 
            this.btclear.BackColor = System.Drawing.Color.Firebrick;
            this.btclear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btclear.FlatAppearance.BorderSize = 0;
            this.btclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btclear.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btclear.ForeColor = System.Drawing.Color.White;
            this.btclear.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btclear.IconColor = System.Drawing.Color.Black;
            this.btclear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btclear.Location = new System.Drawing.Point(783, 90);
            this.btclear.Margin = new System.Windows.Forms.Padding(4);
            this.btclear.Name = "btclear";
            this.btclear.Size = new System.Drawing.Size(139, 38);
            this.btclear.TabIndex = 75;
            this.btclear.Text = "Clear All File";
            this.btclear.UseVisualStyleBackColor = false;
            this.btclear.Click += new System.EventHandler(this.btclear_Click);
            // 
            // flpfile
            // 
            this.flpfile.AutoScroll = true;
            this.flpfile.BackColor = System.Drawing.Color.White;
            this.flpfile.Controls.Add(this.addfile1);
            this.flpfile.Location = new System.Drawing.Point(26, 212);
            this.flpfile.Margin = new System.Windows.Forms.Padding(4);
            this.flpfile.Name = "flpfile";
            this.flpfile.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.flpfile.Size = new System.Drawing.Size(896, 400);
            this.flpfile.TabIndex = 74;
            // 
            // addfile1
            // 
            this.addfile1.BackColor = System.Drawing.Color.Transparent;
            this.addfile1.Location = new System.Drawing.Point(36, 5);
            this.addfile1.Margin = new System.Windows.Forms.Padding(5);
            this.addfile1.Name = "addfile1";
            this.addfile1.Size = new System.Drawing.Size(827, 74);
            this.addfile1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 46);
            this.label2.TabIndex = 73;
            this.label2.Text = "Upload File";
            // 
            // btsave
            // 
            this.btsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(107)))));
            this.btsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btsave.FlatAppearance.BorderSize = 0;
            this.btsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btsave.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsave.ForeColor = System.Drawing.Color.White;
            this.btsave.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btsave.IconColor = System.Drawing.Color.Black;
            this.btsave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btsave.Location = new System.Drawing.Point(807, 631);
            this.btsave.Margin = new System.Windows.Forms.Padding(4);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(115, 38);
            this.btsave.TabIndex = 78;
            this.btsave.Text = "Save";
            this.btsave.UseVisualStyleBackColor = false;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(57)))), ((int)(((byte)(108)))));
            this.panel1.Controls.Add(this.iconButton3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 45);
            this.panel1.TabIndex = 79;
            // 
            // iconButton3
            // 
            this.iconButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.XmarkSquare;
            this.iconButton3.IconColor = System.Drawing.Color.White;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 30;
            this.iconButton3.Location = new System.Drawing.Point(890, 0);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(4);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(59, 45);
            this.iconButton3.TabIndex = 2;
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            this.iconButton3.MouseEnter += new System.EventHandler(this.iconButton3_MouseEnter);
            this.iconButton3.MouseLeave += new System.EventHandler(this.iconButton3_MouseLeave);
            this.iconButton3.MouseHover += new System.EventHandler(this.iconButton3_MouseEnter);
            // 
            // addfileform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(949, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuCards5);
            this.Controls.Add(this.iconButton9);
            this.Controls.Add(this.btclear);
            this.Controls.Add(this.flpfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btsave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addfileform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addfileform";
            this.Load += new System.EventHandler(this.addfileform_Load);
            this.bunifuCards5.ResumeLayout(false);
            this.bunifuCards5.PerformLayout();
            this.flpfile.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton iconButton9;
        private FontAwesome.Sharp.IconButton btclear;
        private System.Windows.Forms.FlowLayoutPanel flpfile;
        private addfile addfile1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btsave;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton3;
    }
}