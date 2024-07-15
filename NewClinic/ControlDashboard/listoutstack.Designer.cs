
namespace NewClinic.ControlDashboard
{
    partial class listoutstack
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
            this.lblcount = new System.Windows.Forms.Label();
            this.lbldexp = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblcode = new System.Windows.Forms.Label();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuCards1.BorderRadius = 10;
            this.bunifuCards1.BottomSahddow = false;
            this.bunifuCards1.color = System.Drawing.SystemColors.Control;
            this.bunifuCards1.Controls.Add(this.lblcount);
            this.bunifuCards1.Controls.Add(this.lbldexp);
            this.bunifuCards1.Controls.Add(this.lblname);
            this.bunifuCards1.Controls.Add(this.lblcode);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(3, 3);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(414, 43);
            this.bunifuCards1.TabIndex = 0;
            // 
            // lblcount
            // 
            this.lblcount.AutoEllipsis = true;
            this.lblcount.Font = new System.Drawing.Font("Segoe UI Variable Display", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcount.Location = new System.Drawing.Point(335, 13);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(71, 17);
            this.lblcount.TabIndex = 3;
            this.lblcount.Text = "label2";
            this.lblcount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbldexp
            // 
            this.lbldexp.AutoEllipsis = true;
            this.lbldexp.Font = new System.Drawing.Font("Segoe UI Variable Display", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldexp.Location = new System.Drawing.Point(214, 13);
            this.lbldexp.Name = "lbldexp";
            this.lbldexp.Size = new System.Drawing.Size(111, 17);
            this.lbldexp.TabIndex = 4;
            this.lbldexp.Text = "label2";
            this.lbldexp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblname
            // 
            this.lblname.AutoEllipsis = true;
            this.lblname.Font = new System.Drawing.Font("Segoe UI Variable Display", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(100, 10);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(106, 23);
            this.lblname.TabIndex = 5;
            this.lblname.Text = "label2";
            this.lblname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblcode
            // 
            this.lblcode.AutoEllipsis = true;
            this.lblcode.Font = new System.Drawing.Font("Segoe UI Variable Display", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcode.Location = new System.Drawing.Point(0, 10);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(84, 23);
            this.lblcode.TabIndex = 2;
            this.lblcode.Text = "label1";
            this.lblcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listoutstack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuCards1);
            this.MinimumSize = new System.Drawing.Size(420, 49);
            this.Name = "listoutstack";
            this.Size = new System.Drawing.Size(420, 49);
            this.Load += new System.EventHandler(this.listoutstack_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public System.Windows.Forms.Label lblcount;
        public System.Windows.Forms.Label lbldexp;
        public System.Windows.Forms.Label lblname;
        public System.Windows.Forms.Label lblcode;
    }
}
