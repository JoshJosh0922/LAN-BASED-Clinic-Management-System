
namespace NewClinic.ControlDashboard
{
    partial class listuser
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
            this.lblname = new System.Windows.Forms.Label();
            this.picnurse = new WindowsFormsApp1.tao.jpicktureBoxcircle();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picnurse)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuCards1.BorderRadius = 10;
            this.bunifuCards1.BottomSahddow = false;
            this.bunifuCards1.color = System.Drawing.Color.Transparent;
            this.bunifuCards1.Controls.Add(this.lblname);
            this.bunifuCards1.Controls.Add(this.picnurse);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(3, 3);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(262, 63);
            this.bunifuCards1.TabIndex = 0;
            // 
            // lblname
            // 
            this.lblname.AutoEllipsis = true;
            this.lblname.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(72, 19);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(146, 23);
            this.lblname.TabIndex = 3;
            this.lblname.Text = "Name";
            // 
            // picnurse
            // 
            this.picnurse.BackColor = System.Drawing.Color.Transparent;
            this.picnurse.BackgroundImage = global::NewClinic.Properties.Resources.e7a5cf5c9e;
            this.picnurse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picnurse.Border = 2;
            this.picnurse.BorderCap = System.Drawing.Drawing2D.DashCap.Flat;
            this.picnurse.Borderstyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.picnurse.ColorBorder = System.Drawing.Color.Transparent;
            this.picnurse.ColorBorder2 = System.Drawing.Color.Transparent;
            this.picnurse.Gradiant = 50F;
            this.picnurse.Location = new System.Drawing.Point(5, 6);
            this.picnurse.Name = "picnurse";
            this.picnurse.Size = new System.Drawing.Size(50, 50);
            this.picnurse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picnurse.TabIndex = 2;
            this.picnurse.TabStop = false;
            // 
            // listuser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuCards1);
            this.MinimumSize = new System.Drawing.Size(268, 69);
            this.Name = "listuser";
            this.Size = new System.Drawing.Size(268, 69);
            this.bunifuCards1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picnurse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public System.Windows.Forms.Label lblname;
        private WindowsFormsApp1.tao.jpicktureBoxcircle picnurse;
    }
}
