
namespace Inventory_final
{
    partial class Form1
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
            this.btnList = new System.Windows.Forms.Button();
            this.btnBatch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCat = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlPages
            // 
            this.pnlPages.BackColor = System.Drawing.Color.White;
            this.pnlPages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPages.Location = new System.Drawing.Point(0, 76);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(1214, 673);
            this.pnlPages.TabIndex = 0;
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.White;
            this.btnList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnList.FlatAppearance.BorderSize = 0;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnList.ForeColor = System.Drawing.Color.Blue;
            this.btnList.Location = new System.Drawing.Point(12, 12);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(154, 60);
            this.btnList.TabIndex = 1;
            this.btnList.Text = "Inventory List";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnBatch
            // 
            this.btnBatch.BackColor = System.Drawing.Color.White;
            this.btnBatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatch.FlatAppearance.BorderSize = 0;
            this.btnBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBatch.Location = new System.Drawing.Point(172, 12);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(154, 60);
            this.btnBatch.TabIndex = 2;
            this.btnBatch.Text = "Batch";
            this.btnBatch.UseVisualStyleBackColor = false;
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 3);
            this.panel1.TabIndex = 3;
            // 
            // btnCat
            // 
            this.btnCat.BackColor = System.Drawing.Color.White;
            this.btnCat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCat.FlatAppearance.BorderSize = 0;
            this.btnCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCat.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCat.ForeColor = System.Drawing.Color.Black;
            this.btnCat.Location = new System.Drawing.Point(332, 12);
            this.btnCat.Name = "btnCat";
            this.btnCat.Size = new System.Drawing.Size(154, 60);
            this.btnCat.TabIndex = 4;
            this.btnCat.Text = "Others";
            this.btnCat.UseVisualStyleBackColor = false;
            this.btnCat.Click += new System.EventHandler(this.btnCat_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.Color.White;
            this.btnArchive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnArchive.ForeColor = System.Drawing.Color.Black;
            this.btnArchive.Location = new System.Drawing.Point(492, 12);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(154, 60);
            this.btnArchive.TabIndex = 5;
            this.btnArchive.Text = "Archive";
            this.btnArchive.UseVisualStyleBackColor = false;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1214, 749);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlPages);
            this.Controls.Add(this.btnBatch);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnCat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel pnlPages;
        internal System.Windows.Forms.Button btnList;
        internal System.Windows.Forms.Button btnBatch;
        internal System.Windows.Forms.Button btnCat;
        internal System.Windows.Forms.Button btnArchive;
    }
}

