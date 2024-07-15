
namespace NewClinic.ControlLogbook
{
    partial class insertmed
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
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtstocks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmessur = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtype = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbmed = new System.Windows.Forms.ComboBox();
            this.btnInc = new FontAwesome.Sharp.IconButton();
            this.btnDec = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // txtamount
            // 
            this.txtamount.BackColor = System.Drawing.Color.White;
            this.txtamount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtamount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtamount.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtamount.Location = new System.Drawing.Point(82, 238);
            this.txtamount.Name = "txtamount";
            this.txtamount.ReadOnly = true;
            this.txtamount.Size = new System.Drawing.Size(85, 31);
            this.txtamount.TabIndex = 66;
            this.txtamount.Text = "0";
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtamount.TextChanged += new System.EventHandler(this.txtamount_TextChanged);
            this.txtamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbp_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 22);
            this.label7.TabIndex = 63;
            this.label7.Text = "Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(259, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "Stocks:";
            // 
            // txtstocks
            // 
            this.txtstocks.BackColor = System.Drawing.Color.White;
            this.txtstocks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtstocks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtstocks.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstocks.Location = new System.Drawing.Point(265, 141);
            this.txtstocks.Margin = new System.Windows.Forms.Padding(4);
            this.txtstocks.Name = "txtstocks";
            this.txtstocks.ReadOnly = true;
            this.txtstocks.Size = new System.Drawing.Size(198, 29);
            this.txtstocks.TabIndex = 60;
            this.txtstocks.Text = "0";
            this.txtstocks.TextChanged += new System.EventHandler(this.txtstocks_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(259, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 20);
            this.label4.TabIndex = 59;
            this.label4.Text = "Strength (Measurement):";
            // 
            // txtmessur
            // 
            this.txtmessur.BackColor = System.Drawing.Color.White;
            this.txtmessur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmessur.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmessur.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmessur.Location = new System.Drawing.Point(265, 44);
            this.txtmessur.Margin = new System.Windows.Forms.Padding(4);
            this.txtmessur.Name = "txtmessur";
            this.txtmessur.ReadOnly = true;
            this.txtmessur.Size = new System.Drawing.Size(198, 29);
            this.txtmessur.TabIndex = 58;
            this.txtmessur.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Type of Medicine:";
            // 
            // txtype
            // 
            this.txtype.BackColor = System.Drawing.Color.White;
            this.txtype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtype.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtype.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtype.Location = new System.Drawing.Point(21, 143);
            this.txtype.Margin = new System.Windows.Forms.Padding(4);
            this.txtype.Name = "txtype";
            this.txtype.ReadOnly = true;
            this.txtype.Size = new System.Drawing.Size(206, 29);
            this.txtype.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Medicine Name:";
            // 
            // cbmed
            // 
            this.cbmed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmed.Font = new System.Drawing.Font("Segoe UI Variable Display", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmed.FormattingEnabled = true;
            this.cbmed.Items.AddRange(new object[] {
            "Benzonatate",
            "Mucinex",
            "Benadryl",
            "Tessalon Perles"});
            this.cbmed.Location = new System.Drawing.Point(21, 45);
            this.cbmed.Margin = new System.Windows.Forms.Padding(4);
            this.cbmed.Name = "cbmed";
            this.cbmed.Size = new System.Drawing.Size(206, 29);
            this.cbmed.TabIndex = 54;
            this.cbmed.SelectionChangeCommitted += new System.EventHandler(this.cbmed_SelectionChangeCommitted);
            // 
            // btnInc
            // 
            this.btnInc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(108)))));
            this.btnInc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInc.Enabled = false;
            this.btnInc.FlatAppearance.BorderSize = 0;
            this.btnInc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInc.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnInc.IconColor = System.Drawing.Color.White;
            this.btnInc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInc.IconSize = 25;
            this.btnInc.Location = new System.Drawing.Point(173, 238);
            this.btnInc.Name = "btnInc";
            this.btnInc.Size = new System.Drawing.Size(54, 31);
            this.btnInc.TabIndex = 64;
            this.btnInc.UseVisualStyleBackColor = false;
            this.btnInc.Click += new System.EventHandler(this.btnInc_Click);
            // 
            // btnDec
            // 
            this.btnDec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(108)))));
            this.btnDec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDec.Enabled = false;
            this.btnDec.FlatAppearance.BorderSize = 0;
            this.btnDec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDec.IconChar = FontAwesome.Sharp.IconChar.CircleMinus;
            this.btnDec.IconColor = System.Drawing.Color.White;
            this.btnDec.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDec.IconSize = 25;
            this.btnDec.Location = new System.Drawing.Point(19, 238);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(54, 31);
            this.btnDec.TabIndex = 65;
            this.btnDec.UseVisualStyleBackColor = false;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI Variable Display", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.iconButton1.IconColor = System.Drawing.Color.Firebrick;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton1.IconSize = 30;
            this.iconButton1.Location = new System.Drawing.Point(424, 223);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(39, 46);
            this.iconButton1.TabIndex = 67;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Visible = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click_1);
            this.iconButton1.MouseEnter += new System.EventHandler(this.iconButton1_MouseEnter);
            this.iconButton1.MouseLeave += new System.EventHandler(this.iconButton1_MouseLeave);
            this.iconButton1.MouseHover += new System.EventHandler(this.iconButton1_MouseEnter);
            // 
            // insertmed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.btnInc);
            this.Controls.Add(this.btnDec);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtstocks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtmessur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtype);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbmed);
            this.MinimumSize = new System.Drawing.Size(485, 288);
            this.Name = "insertmed";
            this.Size = new System.Drawing.Size(485, 288);
            this.Load += new System.EventHandler(this.insertmed_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtamount;
        private FontAwesome.Sharp.IconButton btnInc;
        private FontAwesome.Sharp.IconButton btnDec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
        public System.Windows.Forms.TextBox txtstocks;
        public System.Windows.Forms.TextBox txtmessur;
        public System.Windows.Forms.TextBox txtype;
        public System.Windows.Forms.ComboBox cbmed;
    }
}
