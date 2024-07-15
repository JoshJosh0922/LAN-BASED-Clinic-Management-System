
namespace inventory
{
    partial class Inventory
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
            this.pnlPages = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnList = new FontAwesome.Sharp.IconButton();
            this.btnBatch = new FontAwesome.Sharp.IconButton();
            this.btnCat = new FontAwesome.Sharp.IconButton();
            this.btnArchive = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPages
            // 
            this.pnlPages.BackColor = System.Drawing.Color.White;
            this.pnlPages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPages.Location = new System.Drawing.Point(0, 60);
            this.pnlPages.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(1520, 822);
            this.pnlPages.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBatch, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCat, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnArchive, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(581, 56);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(109)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 5);
            this.panel1.TabIndex = 8;
            // 
            // btnList
            // 
            this.btnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnList.FlatAppearance.BorderSize = 0;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(108)))));
            this.btnList.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnList.IconColor = System.Drawing.Color.Black;
            this.btnList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnList.Location = new System.Drawing.Point(0, 0);
            this.btnList.Margin = new System.Windows.Forms.Padding(0);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(145, 51);
            this.btnList.TabIndex = 9;
            this.btnList.Text = "Inventory List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnBatch
            // 
            this.btnBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBatch.FlatAppearance.BorderSize = 0;
            this.btnBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatch.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatch.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnBatch.IconColor = System.Drawing.Color.Black;
            this.btnBatch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBatch.Location = new System.Drawing.Point(145, 0);
            this.btnBatch.Margin = new System.Windows.Forms.Padding(0);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(145, 51);
            this.btnBatch.TabIndex = 9;
            this.btnBatch.Text = "Batch";
            this.btnBatch.UseVisualStyleBackColor = true;
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // btnCat
            // 
            this.btnCat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCat.FlatAppearance.BorderSize = 0;
            this.btnCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCat.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCat.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCat.IconColor = System.Drawing.Color.Black;
            this.btnCat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCat.Location = new System.Drawing.Point(290, 0);
            this.btnCat.Margin = new System.Windows.Forms.Padding(0);
            this.btnCat.Name = "btnCat";
            this.btnCat.Size = new System.Drawing.Size(145, 51);
            this.btnCat.TabIndex = 9;
            this.btnCat.Text = "Others";
            this.btnCat.UseVisualStyleBackColor = true;
            this.btnCat.Click += new System.EventHandler(this.btnCat_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchive.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnArchive.IconColor = System.Drawing.Color.Black;
            this.btnArchive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnArchive.Location = new System.Drawing.Point(435, 0);
            this.btnArchive.Margin = new System.Windows.Forms.Padding(0);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(146, 51);
            this.btnArchive.TabIndex = 9;
            this.btnArchive.Text = "Archive";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 882);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlPages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventory";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlPages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        public FontAwesome.Sharp.IconButton btnList;
        public FontAwesome.Sharp.IconButton btnBatch;
        public FontAwesome.Sharp.IconButton btnCat;
        public FontAwesome.Sharp.IconButton btnArchive;
    }
}

