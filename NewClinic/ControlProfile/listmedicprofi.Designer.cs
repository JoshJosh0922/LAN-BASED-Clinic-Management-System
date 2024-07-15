
namespace NewClinic.ControlProfile
{
    partial class listmedicprofi
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
            this.bunifuCards3 = new Bunifu.Framework.UI.BunifuCards();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblpersonid = new System.Windows.Forms.Label();
            this.lblno = new System.Windows.Forms.Label();
            this.btnview = new FontAwesome.Sharp.IconButton();
            this.bunifuCards3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards3
            // 
            this.bunifuCards3.BackColor = System.Drawing.Color.White;
            this.bunifuCards3.BorderRadius = 10;
            this.bunifuCards3.BottomSahddow = false;
            this.bunifuCards3.color = System.Drawing.Color.White;
            this.bunifuCards3.Controls.Add(this.lbldate);
            this.bunifuCards3.Controls.Add(this.lblpersonid);
            this.bunifuCards3.Controls.Add(this.lblno);
            this.bunifuCards3.Controls.Add(this.btnview);
            this.bunifuCards3.LeftSahddow = false;
            this.bunifuCards3.Location = new System.Drawing.Point(7, 5);
            this.bunifuCards3.Name = "bunifuCards3";
            this.bunifuCards3.RightSahddow = false;
            this.bunifuCards3.ShadowDepth = 20;
            this.bunifuCards3.Size = new System.Drawing.Size(1053, 56);
            this.bunifuCards3.TabIndex = 47;
            // 
            // lbldate
            // 
            this.lbldate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldate.AutoEllipsis = true;
            this.lbldate.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(414, 15);
            this.lbldate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(196, 25);
            this.lbldate.TabIndex = 16;
            this.lbldate.Text = "Date Created";
            this.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblpersonid
            // 
            this.lblpersonid.AutoEllipsis = true;
            this.lblpersonid.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpersonid.Location = new System.Drawing.Point(264, 17);
            this.lblpersonid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpersonid.Name = "lblpersonid";
            this.lblpersonid.Size = new System.Drawing.Size(64, 25);
            this.lblpersonid.TabIndex = 14;
            this.lblpersonid.Text = "id";
            this.lblpersonid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblpersonid.Visible = false;
            // 
            // lblno
            // 
            this.lblno.AutoEllipsis = true;
            this.lblno.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblno.Location = new System.Drawing.Point(39, 15);
            this.lblno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblno.Name = "lblno";
            this.lblno.Size = new System.Drawing.Size(196, 25);
            this.lblno.TabIndex = 15;
            this.lblno.Text = "No";
            this.lblno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnview
            // 
            this.btnview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(107)))));
            this.btnview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnview.FlatAppearance.BorderSize = 0;
            this.btnview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnview.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.ForeColor = System.Drawing.Color.White;
            this.btnview.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnview.IconColor = System.Drawing.Color.Black;
            this.btnview.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnview.IconSize = 30;
            this.btnview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnview.Location = new System.Drawing.Point(921, 10);
            this.btnview.Margin = new System.Windows.Forms.Padding(4);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(93, 36);
            this.btnview.TabIndex = 13;
            this.btnview.Text = "View";
            this.btnview.UseVisualStyleBackColor = false;
            this.btnview.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // listmedicprofi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuCards3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1067, 66);
            this.Name = "listmedicprofi";
            this.Size = new System.Drawing.Size(1067, 66);
            this.bunifuCards3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards3;
        public System.Windows.Forms.Label lbldate;
        public System.Windows.Forms.Label lblpersonid;
        public System.Windows.Forms.Label lblno;
        public FontAwesome.Sharp.IconButton btnview;
    }
}
