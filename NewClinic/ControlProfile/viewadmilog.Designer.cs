
namespace NewClinic.ControlProfile
{
    partial class viewadmilog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewadmilog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.paper = new System.Windows.Forms.Panel();
            this.profile1 = new NewClinic.ControlProfile.profile();
            this.flp2 = new System.Windows.Forms.FlowLayoutPanel();
            this.admision1 = new NewClinic.ControlProfile.admision();
            this.admision2 = new NewClinic.ControlProfile.admision();
            this.admision3 = new NewClinic.ControlProfile.admision();
            this.admision4 = new NewClinic.ControlProfile.admision();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbshow = new System.Windows.Forms.CheckBox();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.admision5 = new NewClinic.ControlProfile.admision();
            this.panel1.SuspendLayout();
            this.flp.SuspendLayout();
            this.paper.SuspendLayout();
            this.flp2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(108)))));
            this.panel1.Controls.Add(this.iconButton4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1265, 46);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
            // 
            // iconButton4
            // 
            this.iconButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton4.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.XmarkSquare;
            this.iconButton4.IconColor = System.Drawing.Color.White;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.IconSize = 30;
            this.iconButton4.Location = new System.Drawing.Point(1225, 0);
            this.iconButton4.Margin = new System.Windows.Forms.Padding(4);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(40, 46);
            this.iconButton4.TabIndex = 3;
            this.iconButton4.UseVisualStyleBackColor = true;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            this.iconButton4.MouseEnter += new System.EventHandler(this.iconButton4_MouseHover);
            this.iconButton4.MouseLeave += new System.EventHandler(this.iconButton4_MouseLeave);
            this.iconButton4.MouseHover += new System.EventHandler(this.iconButton4_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Patient Record";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
            // 
            // flp
            // 
            this.flp.AutoScroll = true;
            this.flp.Controls.Add(this.paper);
            this.flp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flp.Location = new System.Drawing.Point(0, 36);
            this.flp.Name = "flp";
            this.flp.Padding = new System.Windows.Forms.Padding(160, 0, 0, 0);
            this.flp.Size = new System.Drawing.Size(1265, 697);
            this.flp.TabIndex = 1;
            // 
            // paper
            // 
            this.paper.BackColor = System.Drawing.Color.White;
            this.paper.Controls.Add(this.profile1);
            this.paper.Controls.Add(this.flp2);
            this.paper.Location = new System.Drawing.Point(163, 3);
            this.paper.Name = "paper";
            this.paper.Size = new System.Drawing.Size(1021, 1583);
            this.paper.TabIndex = 0;
            // 
            // profile1
            // 
            this.profile1.BackColor = System.Drawing.Color.White;
            this.profile1.Location = new System.Drawing.Point(61, 3);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(887, 409);
            this.profile1.TabIndex = 99;
            // 
            // flp2
            // 
            this.flp2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp2.AutoScroll = true;
            this.flp2.Controls.Add(this.admision1);
            this.flp2.Controls.Add(this.admision2);
            this.flp2.Controls.Add(this.admision3);
            this.flp2.Controls.Add(this.admision4);
            this.flp2.Controls.Add(this.admision5);
            this.flp2.Location = new System.Drawing.Point(6, 416);
            this.flp2.Name = "flp2";
            this.flp2.Size = new System.Drawing.Size(1009, 1164);
            this.flp2.TabIndex = 98;
            // 
            // admision1
            // 
            this.admision1.BackColor = System.Drawing.Color.White;
            this.admision1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.admision1.Location = new System.Drawing.Point(3, 3);
            this.admision1.Name = "admision1";
            this.admision1.Size = new System.Drawing.Size(491, 579);
            this.admision1.TabIndex = 0;
            // 
            // admision2
            // 
            this.admision2.BackColor = System.Drawing.Color.White;
            this.admision2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.admision2.Location = new System.Drawing.Point(500, 3);
            this.admision2.Name = "admision2";
            this.admision2.Size = new System.Drawing.Size(491, 579);
            this.admision2.TabIndex = 1;
            // 
            // admision3
            // 
            this.admision3.BackColor = System.Drawing.Color.White;
            this.admision3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.admision3.Location = new System.Drawing.Point(3, 588);
            this.admision3.Name = "admision3";
            this.admision3.Size = new System.Drawing.Size(491, 579);
            this.admision3.TabIndex = 2;
            // 
            // admision4
            // 
            this.admision4.BackColor = System.Drawing.Color.White;
            this.admision4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.admision4.Location = new System.Drawing.Point(500, 588);
            this.admision4.Name = "admision4";
            this.admision4.Size = new System.Drawing.Size(491, 579);
            this.admision4.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbshow);
            this.panel2.Controls.Add(this.iconButton2);
            this.panel2.Controls.Add(this.iconButton1);
            this.panel2.Controls.Add(this.flp);
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1265, 733);
            this.panel2.TabIndex = 2;
            // 
            // cbshow
            // 
            this.cbshow.AutoSize = true;
            this.cbshow.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbshow.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbshow.Location = new System.Drawing.Point(769, 0);
            this.cbshow.Name = "cbshow";
            this.cbshow.Size = new System.Drawing.Size(212, 36);
            this.cbshow.TabIndex = 4;
            this.cbshow.Text = "Show All Admission Record";
            this.cbshow.UseVisualStyleBackColor = true;
            this.cbshow.CheckedChanged += new System.EventHandler(this.cbshow_CheckedChanged);
            // 
            // iconButton2
            // 
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconButton2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(981, 0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(145, 36);
            this.iconButton2.TabIndex = 3;
            this.iconButton2.Text = "Print Preview";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click_1);
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(1126, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(139, 36);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.Text = "Export to PDF";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click_1);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // admision5
            // 
            this.admision5.BackColor = System.Drawing.Color.White;
            this.admision5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.admision5.Location = new System.Drawing.Point(3, 1173);
            this.admision5.Name = "admision5";
            this.admision5.Size = new System.Drawing.Size(491, 579);
            this.admision5.TabIndex = 4;
            // 
            // viewadmilog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1265, 779);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewadmilog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "viewadmilog";
            this.Load += new System.EventHandler(this.viewadmilog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flp.ResumeLayout(false);
            this.paper.ResumeLayout(false);
            this.flp2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel paper;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.FlowLayoutPanel flp2;
        private profile profile1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private admision admision1;
        private admision admision2;
        private admision admision3;
        private admision admision4;
        private System.Windows.Forms.CheckBox cbshow;
        private admision admision5;
    }
}