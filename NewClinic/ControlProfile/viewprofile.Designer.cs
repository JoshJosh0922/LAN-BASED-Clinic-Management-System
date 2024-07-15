
namespace NewClinic.ControlProfile
{
    partial class viewprofile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.btndel = new FontAwesome.Sharp.IconButton();
            this.btnedit = new FontAwesome.Sharp.IconButton();
            this.lbltype = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.btnview = new FontAwesome.Sharp.IconButton();
            this.lblage = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblgender = new System.Windows.Forms.Label();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 20;
            this.bunifuCards1.BottomSahddow = false;
            this.bunifuCards1.color = System.Drawing.Color.Transparent;
            this.bunifuCards1.Controls.Add(this.btndel);
            this.bunifuCards1.Controls.Add(this.btnedit);
            this.bunifuCards1.Controls.Add(this.lbltype);
            this.bunifuCards1.Controls.Add(this.lblid);
            this.bunifuCards1.Controls.Add(this.btnview);
            this.bunifuCards1.Controls.Add(this.lblage);
            this.bunifuCards1.Controls.Add(this.lblname);
            this.bunifuCards1.Controls.Add(this.lblgender);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(7, 4);
            this.bunifuCards1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(1421, 71);
            this.bunifuCards1.TabIndex = 1;
            this.bunifuCards1.Paint += new System.Windows.Forms.PaintEventHandler(this.bunifuCards1_Paint);
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.Color.Firebrick;
            this.btndel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndel.FlatAppearance.BorderSize = 0;
            this.btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndel.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndel.ForeColor = System.Drawing.Color.White;
            this.btndel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btndel.IconColor = System.Drawing.Color.Black;
            this.btndel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndel.Location = new System.Drawing.Point(1299, 19);
            this.btndel.Margin = new System.Windows.Forms.Padding(4);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(100, 34);
            this.btndel.TabIndex = 29;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(157)))));
            this.btnedit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnedit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(107)))));
            this.btnedit.FlatAppearance.BorderSize = 0;
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.White;
            this.btnedit.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnedit.IconColor = System.Drawing.Color.Black;
            this.btnedit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnedit.Location = new System.Drawing.Point(1191, 19);
            this.btnedit.Margin = new System.Windows.Forms.Padding(4);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(100, 34);
            this.btnedit.TabIndex = 28;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // lbltype
            // 
            this.lbltype.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltype.ForeColor = System.Drawing.Color.Black;
            this.lbltype.Location = new System.Drawing.Point(784, 22);
            this.lbltype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(249, 26);
            this.lbltype.TabIndex = 27;
            this.lbltype.Text = "Community Types";
            this.lbltype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid.ForeColor = System.Drawing.Color.Black;
            this.lblid.Location = new System.Drawing.Point(43, 39);
            this.lblid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(26, 22);
            this.lblid.TabIndex = 20;
            this.lblid.Text = "ID\r\n";
            // 
            // btnview
            // 
            this.btnview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(107)))));
            this.btnview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnview.FlatAppearance.BorderSize = 0;
            this.btnview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnview.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.ForeColor = System.Drawing.Color.White;
            this.btnview.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnview.IconColor = System.Drawing.Color.Black;
            this.btnview.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnview.Location = new System.Drawing.Point(1083, 19);
            this.btnview.Margin = new System.Windows.Forms.Padding(4);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(100, 34);
            this.btnview.TabIndex = 19;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = false;
            this.btnview.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // lblage
            // 
            this.lblage.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblage.ForeColor = System.Drawing.Color.Black;
            this.lblage.Location = new System.Drawing.Point(564, 22);
            this.lblage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblage.Name = "lblage";
            this.lblage.Size = new System.Drawing.Size(174, 26);
            this.lblage.TabIndex = 16;
            this.lblage.Text = "Age";
            this.lblage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblname
            // 
            this.lblname.AutoEllipsis = true;
            this.lblname.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.Black;
            this.lblname.Location = new System.Drawing.Point(43, 12);
            this.lblname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(299, 26);
            this.lblname.TabIndex = 17;
            this.lblname.Text = "Full Name\r\n";
            // 
            // lblgender
            // 
            this.lblgender.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgender.ForeColor = System.Drawing.Color.Black;
            this.lblgender.Location = new System.Drawing.Point(372, 23);
            this.lblgender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(149, 26);
            this.lblgender.TabIndex = 18;
            this.lblgender.Text = "Gender";
            this.lblgender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // viewprofile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuCards1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1169, 68);
            this.Name = "viewprofile";
            this.Size = new System.Drawing.Size(1435, 79);
            this.Load += new System.EventHandler(this.viewprofile_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public System.Windows.Forms.Label lbltype;
        public System.Windows.Forms.Label lblid;
        public FontAwesome.Sharp.IconButton btnview;
        public System.Windows.Forms.Label lblage;
        public System.Windows.Forms.Label lblname;
        public System.Windows.Forms.Label lblgender;
        public FontAwesome.Sharp.IconButton btndel;
        public FontAwesome.Sharp.IconButton btnedit;
    }
}
