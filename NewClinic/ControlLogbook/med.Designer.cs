
namespace NewClinic.ControlLogbook
{
    partial class med
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
            this.lblmed = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.lblid = new System.Windows.Forms.Label();
            this.lblamount = new System.Windows.Forms.Label();
            this.lblmedid = new System.Windows.Forms.Label();
            this.lblbatch = new System.Windows.Forms.Label();
            this.lblstock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblmed
            // 
            this.lblmed.AutoEllipsis = true;
            this.lblmed.BackColor = System.Drawing.SystemColors.Control;
            this.lblmed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblmed.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmed.Location = new System.Drawing.Point(55, 0);
            this.lblmed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmed.Name = "lblmed";
            this.lblmed.Size = new System.Drawing.Size(185, 36);
            this.lblmed.TabIndex = 2;
            this.lblmed.Text = "Medicine";
            this.lblmed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.SystemColors.Control;
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.iconButton1.IconColor = System.Drawing.Color.Firebrick;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton1.IconSize = 25;
            this.iconButton1.Location = new System.Drawing.Point(203, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(37, 36);
            this.iconButton1.TabIndex = 3;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            this.iconButton1.MouseEnter += new System.EventHandler(this.iconButton1_MouseEnter);
            this.iconButton1.MouseLeave += new System.EventHandler(this.iconButton1_MouseLeave);
            this.iconButton1.MouseHover += new System.EventHandler(this.iconButton1_MouseEnter);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(151, 11);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(19, 17);
            this.lblid.TabIndex = 4;
            this.lblid.Text = "id";
            this.lblid.Visible = false;
            // 
            // lblamount
            // 
            this.lblamount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblamount.Location = new System.Drawing.Point(0, 0);
            this.lblamount.Name = "lblamount";
            this.lblamount.Size = new System.Drawing.Size(55, 36);
            this.lblamount.TabIndex = 4;
            this.lblamount.Text = "amount";
            this.lblamount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblmedid
            // 
            this.lblmedid.AutoSize = true;
            this.lblmedid.Location = new System.Drawing.Point(3, 17);
            this.lblmedid.Name = "lblmedid";
            this.lblmedid.Size = new System.Drawing.Size(46, 17);
            this.lblmedid.TabIndex = 4;
            this.lblmedid.Text = "medid";
            this.lblmedid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblmedid.Visible = false;
            // 
            // lblbatch
            // 
            this.lblbatch.AutoSize = true;
            this.lblbatch.Location = new System.Drawing.Point(151, 0);
            this.lblbatch.Name = "lblbatch";
            this.lblbatch.Size = new System.Drawing.Size(43, 17);
            this.lblbatch.TabIndex = 4;
            this.lblbatch.Text = "batch";
            this.lblbatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbatch.Visible = false;
            // 
            // lblstock
            // 
            this.lblstock.AutoSize = true;
            this.lblstock.Location = new System.Drawing.Point(142, 17);
            this.lblstock.Name = "lblstock";
            this.lblstock.Size = new System.Drawing.Size(41, 17);
            this.lblstock.TabIndex = 4;
            this.lblstock.Text = "stock";
            this.lblstock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblstock.Visible = false;
            // 
            // med
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblbatch);
            this.Controls.Add(this.lblmedid);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.lblstock);
            this.Controls.Add(this.lblmed);
            this.Controls.Add(this.lblamount);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "med";
            this.Size = new System.Drawing.Size(240, 36);
            this.Load += new System.EventHandler(this.med_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblmed;
        private FontAwesome.Sharp.IconButton iconButton1;
        public System.Windows.Forms.Label lblid;
        public System.Windows.Forms.Label lblamount;
        public System.Windows.Forms.Label lblmedid;
        public System.Windows.Forms.Label lblbatch;
        public System.Windows.Forms.Label lblstock;
    }
}
