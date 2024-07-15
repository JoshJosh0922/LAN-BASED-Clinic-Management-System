
namespace NewClinic.ControlDashboard
{
    partial class listdeseases
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
            this.lbltype = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblcount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbltype
            // 
            this.lbltype.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltype.Location = new System.Drawing.Point(373, 9);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(145, 23);
            this.lbltype.TabIndex = 0;
            this.lbltype.Text = "label1";
            this.lbltype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblname
            // 
            this.lblname.AutoEllipsis = true;
            this.lblname.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(117, 9);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(237, 23);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "label2";
            this.lblname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblcount
            // 
            this.lblcount.AutoEllipsis = true;
            this.lblcount.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcount.Location = new System.Drawing.Point(14, 9);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(79, 23);
            this.lblcount.TabIndex = 2;
            this.lblcount.Text = "label3";
            this.lblcount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listdeseases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblcount);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.lbltype);
            this.MinimumSize = new System.Drawing.Size(492, 40);
            this.Name = "listdeseases";
            this.Size = new System.Drawing.Size(536, 41);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbltype;
        public System.Windows.Forms.Label lblname;
        public System.Windows.Forms.Label lblcount;
    }
}
