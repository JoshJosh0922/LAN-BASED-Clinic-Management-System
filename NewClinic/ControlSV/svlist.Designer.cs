
namespace NewClinic.ControlSV
{
    partial class svlist
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
            this.btnselect = new FontAwesome.Sharp.IconButton();
            this.lblsvid = new System.Windows.Forms.Label();
            this.lblsvname = new System.Windows.Forms.Label();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = false;
            this.bunifuCards1.color = System.Drawing.Color.White;
            this.bunifuCards1.Controls.Add(this.btndel);
            this.bunifuCards1.Controls.Add(this.btnselect);
            this.bunifuCards1.Controls.Add(this.lblsvid);
            this.bunifuCards1.Controls.Add(this.lblsvname);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(2, 2);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(682, 47);
            this.bunifuCards1.TabIndex = 0;
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.Color.Firebrick;
            this.btndel.FlatAppearance.BorderSize = 0;
            this.btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndel.ForeColor = System.Drawing.Color.White;
            this.btndel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btndel.IconColor = System.Drawing.Color.Black;
            this.btndel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndel.Location = new System.Drawing.Point(596, 8);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(75, 32);
            this.btndel.TabIndex = 2;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnselect
            // 
            this.btnselect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(105)))));
            this.btnselect.FlatAppearance.BorderSize = 0;
            this.btnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnselect.ForeColor = System.Drawing.Color.White;
            this.btnselect.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnselect.IconColor = System.Drawing.Color.Black;
            this.btnselect.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnselect.Location = new System.Drawing.Point(517, 8);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 32);
            this.btnselect.TabIndex = 2;
            this.btnselect.Text = "Select";
            this.btnselect.UseVisualStyleBackColor = false;
            this.btnselect.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // lblsvid
            // 
            this.lblsvid.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsvid.Location = new System.Drawing.Point(298, 12);
            this.lblsvid.Name = "lblsvid";
            this.lblsvid.Size = new System.Drawing.Size(186, 22);
            this.lblsvid.TabIndex = 1;
            this.lblsvid.Text = "asaas";
            this.lblsvid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsvname
            // 
            this.lblsvname.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsvname.Location = new System.Drawing.Point(13, 12);
            this.lblsvname.Name = "lblsvname";
            this.lblsvname.Size = new System.Drawing.Size(256, 22);
            this.lblsvname.TabIndex = 1;
            this.lblsvname.Text = "asaas";
            this.lblsvname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // svlist
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuCards1);
            this.MinimumSize = new System.Drawing.Size(692, 52);
            this.Name = "svlist";
            this.Size = new System.Drawing.Size(692, 52);
            this.bunifuCards1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public System.Windows.Forms.Label lblsvname;
        public System.Windows.Forms.Label lblsvid;
        public FontAwesome.Sharp.IconButton btnselect;
        public FontAwesome.Sharp.IconButton btndel;
    }
}
