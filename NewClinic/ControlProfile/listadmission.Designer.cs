
namespace NewClinic.ControlProfile
{
    partial class listadmission
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
            this.lblid = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.lblattended = new System.Windows.Forms.Label();
            this.lblreason = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.bunifuCards3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards3
            // 
            this.bunifuCards3.BackColor = System.Drawing.Color.White;
            this.bunifuCards3.BorderRadius = 10;
            this.bunifuCards3.BottomSahddow = false;
            this.bunifuCards3.color = System.Drawing.Color.White;
            this.bunifuCards3.Controls.Add(this.lblid);
            this.bunifuCards3.Controls.Add(this.iconButton1);
            this.bunifuCards3.Controls.Add(this.lblattended);
            this.bunifuCards3.Controls.Add(this.lblreason);
            this.bunifuCards3.Controls.Add(this.lbltime);
            this.bunifuCards3.Controls.Add(this.lbldate);
            this.bunifuCards3.LeftSahddow = false;
            this.bunifuCards3.Location = new System.Drawing.Point(8, 6);
            this.bunifuCards3.Name = "bunifuCards3";
            this.bunifuCards3.RightSahddow = false;
            this.bunifuCards3.ShadowDepth = 20;
            this.bunifuCards3.Size = new System.Drawing.Size(1049, 67);
            this.bunifuCards3.TabIndex = 47;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid.Location = new System.Drawing.Point(104, 46);
            this.lblid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(17, 20);
            this.lblid.TabIndex = 24;
            this.lblid.Text = "0";
            this.lblid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblid.Visible = false;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(107)))));
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI Variable Display", 11.25F, System.Drawing.FontStyle.Bold);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(913, 13);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(4);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(109, 39);
            this.iconButton1.TabIndex = 23;
            this.iconButton1.Text = "View";
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // lblattended
            // 
            this.lblattended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblattended.AutoEllipsis = true;
            this.lblattended.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblattended.ForeColor = System.Drawing.Color.Black;
            this.lblattended.Location = new System.Drawing.Point(590, 19);
            this.lblattended.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblattended.Name = "lblattended";
            this.lblattended.Size = new System.Drawing.Size(280, 26);
            this.lblattended.TabIndex = 22;
            this.lblattended.Text = "Attended By";
            this.lblattended.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblreason
            // 
            this.lblreason.AutoEllipsis = true;
            this.lblreason.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreason.Location = new System.Drawing.Point(310, 19);
            this.lblreason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblreason.Name = "lblreason";
            this.lblreason.Size = new System.Drawing.Size(236, 25);
            this.lblreason.TabIndex = 21;
            this.lblreason.Text = "Reason";
            this.lblreason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.Location = new System.Drawing.Point(188, 21);
            this.lbltime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(57, 20);
            this.lbltime.TabIndex = 20;
            this.lbltime.Text = "Time In";
            this.lbltime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(26, 21);
            this.lbldate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(39, 20);
            this.lbldate.TabIndex = 19;
            this.lbldate.Text = "Date";
            this.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listadmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuCards3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "listadmission";
            this.Size = new System.Drawing.Size(1064, 78);
            this.Load += new System.EventHandler(this.listadmission_Load);
            this.bunifuCards3.ResumeLayout(false);
            this.bunifuCards3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards3;
        public System.Windows.Forms.Label lblid;
        public FontAwesome.Sharp.IconButton iconButton1;
        public System.Windows.Forms.Label lblattended;
        public System.Windows.Forms.Label lblreason;
        public System.Windows.Forms.Label lbltime;
        public System.Windows.Forms.Label lbldate;
    }
}
