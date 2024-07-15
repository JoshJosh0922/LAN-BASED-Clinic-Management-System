
namespace NewClinic.ControlDashboard
{
    partial class listview
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
            this.lbldate = new System.Windows.Forms.Label();
            this.lblreason = new System.Windows.Forms.Label();
            this.lblin = new System.Windows.Forms.Label();
            this.lblout = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards1.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuCards1.BorderRadius = 10;
            this.bunifuCards1.BottomSahddow = false;
            this.bunifuCards1.color = System.Drawing.SystemColors.Control;
            this.bunifuCards1.Controls.Add(this.lbldate);
            this.bunifuCards1.Controls.Add(this.lblreason);
            this.bunifuCards1.Controls.Add(this.lblin);
            this.bunifuCards1.Controls.Add(this.lblout);
            this.bunifuCards1.Controls.Add(this.lblname);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(5, 4);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(1017, 49);
            this.bunifuCards1.TabIndex = 7;
            // 
            // lbldate
            // 
            this.lbldate.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(30, 14);
            this.lbldate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(97, 18);
            this.lbldate.TabIndex = 11;
            this.lbldate.Text = "Date in";
            this.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblreason
            // 
            this.lblreason.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreason.Location = new System.Drawing.Point(414, 14);
            this.lblreason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblreason.Name = "lblreason";
            this.lblreason.Size = new System.Drawing.Size(269, 18);
            this.lblreason.TabIndex = 10;
            this.lblreason.Text = "Reason";
            this.lblreason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblin
            // 
            this.lblin.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblin.Location = new System.Drawing.Point(713, 16);
            this.lblin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblin.Name = "lblin";
            this.lblin.Size = new System.Drawing.Size(122, 18);
            this.lblin.TabIndex = 9;
            this.lblin.Text = "Timein";
            this.lblin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblout
            // 
            this.lblout.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblout.Location = new System.Drawing.Point(856, 14);
            this.lblout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblout.Name = "lblout";
            this.lblout.Size = new System.Drawing.Size(129, 18);
            this.lblout.TabIndex = 8;
            this.lblout.Text = "Timeout";
            this.lblout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblname
            // 
            this.lblname.AutoEllipsis = true;
            this.lblname.Font = new System.Drawing.Font("Segoe UI Variable Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(135, 14);
            this.lblname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(257, 20);
            this.lblname.TabIndex = 7;
            this.lblname.Text = "lblname";
            this.lblname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuCards1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(877, 58);
            this.Name = "listview";
            this.Size = new System.Drawing.Size(1029, 58);
            this.bunifuCards1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public System.Windows.Forms.Label lbldate;
        public System.Windows.Forms.Label lblreason;
        public System.Windows.Forms.Label lblin;
        public System.Windows.Forms.Label lblout;
        public System.Windows.Forms.Label lblname;
    }
}
