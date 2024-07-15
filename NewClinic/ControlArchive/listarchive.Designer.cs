
namespace NewClinic.ControlArchive
{
    partial class listarchive
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
            this.btnrestore = new FontAwesome.Sharp.IconButton();
            this.lblid = new System.Windows.Forms.Label();
            this.lbltype = new System.Windows.Forms.Label();
            this.lblage = new System.Windows.Forms.Label();
            this.lblgender = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 10;
            this.bunifuCards1.BottomSahddow = false;
            this.bunifuCards1.color = System.Drawing.Color.White;
            this.bunifuCards1.Controls.Add(this.btndel);
            this.bunifuCards1.Controls.Add(this.btnrestore);
            this.bunifuCards1.Controls.Add(this.lblid);
            this.bunifuCards1.Controls.Add(this.lbltype);
            this.bunifuCards1.Controls.Add(this.lblage);
            this.bunifuCards1.Controls.Add(this.lblgender);
            this.bunifuCards1.Controls.Add(this.lblname);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(5, 2);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(1435, 62);
            this.bunifuCards1.TabIndex = 0;
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.Color.Firebrick;
            this.btndel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndel.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndel.ForeColor = System.Drawing.Color.White;
            this.btndel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btndel.IconColor = System.Drawing.Color.Black;
            this.btndel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndel.Location = new System.Drawing.Point(1295, 14);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(102, 32);
            this.btndel.TabIndex = 28;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // btnrestore
            // 
            this.btnrestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(78)))), ((int)(((byte)(157)))));
            this.btnrestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrestore.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrestore.ForeColor = System.Drawing.Color.White;
            this.btnrestore.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnrestore.IconColor = System.Drawing.Color.Black;
            this.btnrestore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnrestore.Location = new System.Drawing.Point(1173, 14);
            this.btnrestore.Name = "btnrestore";
            this.btnrestore.Size = new System.Drawing.Size(102, 32);
            this.btnrestore.TabIndex = 28;
            this.btnrestore.Text = "Restore";
            this.btnrestore.UseVisualStyleBackColor = false;
            this.btnrestore.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // lblid
            // 
            this.lblid.AutoEllipsis = true;
            this.lblid.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid.ForeColor = System.Drawing.Color.Black;
            this.lblid.Location = new System.Drawing.Point(26, 33);
            this.lblid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(305, 22);
            this.lblid.TabIndex = 27;
            this.lblid.Text = "ID";
            // 
            // lbltype
            // 
            this.lbltype.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltype.ForeColor = System.Drawing.Color.Black;
            this.lbltype.Location = new System.Drawing.Point(876, 21);
            this.lbltype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(138, 22);
            this.lbltype.TabIndex = 27;
            this.lbltype.Text = "Patient Type";
            this.lbltype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblage
            // 
            this.lblage.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblage.ForeColor = System.Drawing.Color.Black;
            this.lblage.Location = new System.Drawing.Point(639, 21);
            this.lblage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblage.Name = "lblage";
            this.lblage.Size = new System.Drawing.Size(106, 22);
            this.lblage.TabIndex = 27;
            this.lblage.Text = "Age";
            this.lblage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblgender
            // 
            this.lblgender.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgender.ForeColor = System.Drawing.Color.Black;
            this.lblgender.Location = new System.Drawing.Point(421, 21);
            this.lblgender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(106, 22);
            this.lblgender.TabIndex = 27;
            this.lblgender.Text = "Gender";
            this.lblgender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblname
            // 
            this.lblname.AutoEllipsis = true;
            this.lblname.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.Black;
            this.lblname.Location = new System.Drawing.Point(26, 9);
            this.lblname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(370, 26);
            this.lblname.TabIndex = 27;
            this.lblname.Text = "Full Name";
            // 
            // listarchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuCards1);
            this.Name = "listarchive";
            this.Size = new System.Drawing.Size(1452, 65);
            this.Load += new System.EventHandler(this.listarchive_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public System.Windows.Forms.Label lblname;
        public System.Windows.Forms.Label lblid;
        public System.Windows.Forms.Label lblgender;
        public System.Windows.Forms.Label lbltype;
        public System.Windows.Forms.Label lblage;
        public FontAwesome.Sharp.IconButton btnrestore;
        public FontAwesome.Sharp.IconButton btndel;
    }
}
