
namespace Inventory_final
{
    partial class ListAddProduct
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnDec = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboBatch = new System.Windows.Forms.ComboBox();
            this.cboProd = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.expiry = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInc
            // 
            this.btnInc.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnInc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInc.ForeColor = System.Drawing.Color.White;
            this.btnInc.Location = new System.Drawing.Point(189, 251);
            this.btnInc.Name = "btnInc";
            this.btnInc.Size = new System.Drawing.Size(60, 29);
            this.btnInc.TabIndex = 56;
            this.btnInc.Text = "+";
            this.btnInc.UseVisualStyleBackColor = false;
            this.btnInc.Click += new System.EventHandler(this.btnInc_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 55;
            this.label5.Text = "Stocks:";
            // 
            // txtStock
            // 
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtStock.Location = new System.Drawing.Point(106, 251);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(77, 29);
            this.txtStock.TabIndex = 54;
            this.txtStock.Text = "1";
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDec
            // 
            this.btnDec.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDec.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDec.ForeColor = System.Drawing.Color.White;
            this.btnDec.Location = new System.Drawing.Point(40, 251);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(60, 29);
            this.btnDec.TabIndex = 53;
            this.btnDec.Text = "-";
            this.btnDec.UseVisualStyleBackColor = false;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(40, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 29);
            this.btnCancel.TabIndex = 52;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(149, 308);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 29);
            this.btnAdd.TabIndex = 51;
            this.btnAdd.Text = "SAVE";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboBatch
            // 
            this.cboBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboBatch.FormattingEnabled = true;
            this.cboBatch.Location = new System.Drawing.Point(40, 115);
            this.cboBatch.Name = "cboBatch";
            this.cboBatch.Size = new System.Drawing.Size(208, 29);
            this.cboBatch.TabIndex = 50;
            // 
            // cboProd
            // 
            this.cboProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboProd.FormattingEnabled = true;
            this.cboProd.Location = new System.Drawing.Point(40, 52);
            this.cboProd.Name = "cboProd";
            this.cboProd.Size = new System.Drawing.Size(208, 29);
            this.cboProd.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 48;
            this.label4.Text = "Expiration Date:";
            // 
            // expiry
            // 
            this.expiry.CustomFormat = "MMMM dd, yyy";
            this.expiry.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.expiry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expiry.Location = new System.Drawing.Point(40, 186);
            this.expiry.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.expiry.Name = "expiry";
            this.expiry.ShowCheckBox = true;
            this.expiry.Size = new System.Drawing.Size(208, 29);
            this.expiry.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 44;
            this.label2.Text = "Batch Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Product Name:";
            // 
            // ListAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 395);
            this.Controls.Add(this.btnInc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.btnDec);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboBatch);
            this.Controls.Add(this.cboProd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.expiry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ListAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListAddProduct";
            this.Load += new System.EventHandler(this.ListAddProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnDec;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboBatch;
        private System.Windows.Forms.ComboBox cboProd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker expiry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}