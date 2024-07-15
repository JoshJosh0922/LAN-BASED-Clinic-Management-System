
namespace NewClinic.ControlAdmission
{
    partial class smalladmission
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
            this.lblid = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.lblattended = new System.Windows.Forms.Label();
            this.lblreason = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 25;
            this.bunifuCards1.BottomSahddow = false;
            this.bunifuCards1.color = System.Drawing.Color.Transparent;
            this.bunifuCards1.Controls.Add(this.lblid);
            this.bunifuCards1.Controls.Add(this.iconButton1);
            this.bunifuCards1.Controls.Add(this.lblattended);
            this.bunifuCards1.Controls.Add(this.lblreason);
            this.bunifuCards1.Controls.Add(this.lbltime);
            this.bunifuCards1.Controls.Add(this.lbldate);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(4, 5);
            this.bunifuCards1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(1093, 68);
            this.bunifuCards1.TabIndex = 1;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblid.Location = new System.Drawing.Point(181, 28);
            this.lblid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(19, 23);
            this.lblid.TabIndex = 11;
            this.lblid.Text = "0";
            this.lblid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblid.Visible = false;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(107)))));
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI Variable Display", 11.25F, System.Drawing.FontStyle.Bold);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(955, 16);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(4);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(109, 38);
            this.iconButton1.TabIndex = 10;
            this.iconButton1.Text = "View";
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // lblattended
            // 
            this.lblattended.AutoEllipsis = true;
            this.lblattended.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblattended.ForeColor = System.Drawing.Color.Black;
            this.lblattended.Location = new System.Drawing.Point(653, 22);
            this.lblattended.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblattended.Name = "lblattended";
            this.lblattended.Size = new System.Drawing.Size(280, 26);
            this.lblattended.TabIndex = 9;
            this.lblattended.Text = "Attended By";
            this.lblattended.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblreason
            // 
            this.lblreason.AutoEllipsis = true;
            this.lblreason.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblreason.Location = new System.Drawing.Point(396, 22);
            this.lblreason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblreason.Name = "lblreason";
            this.lblreason.Size = new System.Drawing.Size(236, 25);
            this.lblreason.TabIndex = 8;
            this.lblreason.Text = "Reason";
            this.lblreason.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbltime.Location = new System.Drawing.Point(271, 21);
            this.lbltime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(67, 23);
            this.lbltime.TabIndex = 7;
            this.lbltime.Text = "Time In";
            this.lbltime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbldate.Location = new System.Drawing.Point(73, 21);
            this.lbldate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(46, 23);
            this.lbldate.TabIndex = 6;
            this.lbldate.Text = "Date";
            this.lbldate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // smalladmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuCards1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "smalladmission";
            this.Size = new System.Drawing.Size(1101, 78);
            this.Load += new System.EventHandler(this.smalladmission_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public System.Windows.Forms.Label lblid;
        public FontAwesome.Sharp.IconButton iconButton1;
        public System.Windows.Forms.Label lblattended;
        public System.Windows.Forms.Label lblreason;
        public System.Windows.Forms.Label lbltime;
        public System.Windows.Forms.Label lbldate;
    }
}
