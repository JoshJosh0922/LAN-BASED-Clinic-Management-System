
namespace NewClinic.MainForm
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.label1 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pdate = new System.Windows.Forms.Panel();
            this.cbdate = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.preport = new System.Windows.Forms.Panel();
            this.cbfor = new System.Windows.Forms.CheckBox();
            this.flptype = new System.Windows.Forms.FlowLayoutPanel();
            this.cbgs = new System.Windows.Forms.CheckBox();
            this.cbjh = new System.Windows.Forms.CheckBox();
            this.cbsh = new System.Windows.Forms.CheckBox();
            this.cbc = new System.Windows.Forms.CheckBox();
            this.cbe = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.psearch = new System.Windows.Forms.Panel();
            this.cbsearch = new System.Windows.Forms.CheckBox();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.psort = new System.Windows.Forms.Panel();
            this.cbsortby = new System.Windows.Forms.CheckBox();
            this.cbsort = new System.Windows.Forms.ComboBox();
            this.dtgridview = new System.Windows.Forms.DataGridView();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.cbattended = new System.Windows.Forms.TextBox();
            this.rbadmission = new System.Windows.Forms.RadioButton();
            this.rbinventory = new System.Windows.Forms.RadioButton();
            this.rblog = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.pselect = new System.Windows.Forms.Panel();
            this.rboh = new System.Windows.Forms.CheckBox();
            this.cbselect = new System.Windows.Forms.CheckBox();
            this.rbcs = new System.Windows.Forms.CheckBox();
            this.rboos = new System.Windows.Forms.CheckBox();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.enddate = new WindowsFormsApp1.NewFolder1.JDateTimePicker();
            this.startdate = new WindowsFormsApp1.NewFolder1.JDateTimePicker();
            this.pdate.SuspendLayout();
            this.preport.SuspendLayout();
            this.flptype.SuspendLayout();
            this.psearch.SuspendLayout();
            this.psort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridview)).BeginInit();
            this.pselect.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Name:";
            // 
            // txtname
            // 
            this.txtname.BackColor = System.Drawing.Color.White;
            this.txtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtname.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(34, 33);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(287, 31);
            this.txtname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Prepared By:";
            // 
            // pdate
            // 
            this.pdate.BackColor = System.Drawing.Color.Transparent;
            this.pdate.Controls.Add(this.cbdate);
            this.pdate.Controls.Add(this.enddate);
            this.pdate.Controls.Add(this.startdate);
            this.pdate.Controls.Add(this.label9);
            this.pdate.Controls.Add(this.label6);
            this.pdate.Controls.Add(this.label3);
            this.pdate.Location = new System.Drawing.Point(34, 177);
            this.pdate.Name = "pdate";
            this.pdate.Size = new System.Drawing.Size(674, 52);
            this.pdate.TabIndex = 6;
            // 
            // cbdate
            // 
            this.cbdate.AutoSize = true;
            this.cbdate.BackColor = System.Drawing.Color.Transparent;
            this.cbdate.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F);
            this.cbdate.Location = new System.Drawing.Point(23, 14);
            this.cbdate.Name = "cbdate";
            this.cbdate.Size = new System.Drawing.Size(71, 26);
            this.cbdate.TabIndex = 8;
            this.cbdate.Text = "Date:";
            this.cbdate.UseVisualStyleBackColor = false;
            this.cbdate.CheckedChanged += new System.EventHandler(this.cbdate_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(379, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 22);
            this.label9.TabIndex = 5;
            this.label9.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(427, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "End:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(153, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Start:";
            // 
            // preport
            // 
            this.preport.BackColor = System.Drawing.Color.Transparent;
            this.preport.Controls.Add(this.cbfor);
            this.preport.Controls.Add(this.flptype);
            this.preport.Location = new System.Drawing.Point(722, 115);
            this.preport.Name = "preport";
            this.preport.Size = new System.Drawing.Size(671, 56);
            this.preport.TabIndex = 6;
            // 
            // cbfor
            // 
            this.cbfor.AutoSize = true;
            this.cbfor.BackColor = System.Drawing.Color.Transparent;
            this.cbfor.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F);
            this.cbfor.Location = new System.Drawing.Point(32, 13);
            this.cbfor.Name = "cbfor";
            this.cbfor.Size = new System.Drawing.Size(115, 26);
            this.cbfor.TabIndex = 8;
            this.cbfor.Text = "Report For:";
            this.cbfor.UseVisualStyleBackColor = false;
            this.cbfor.CheckedChanged += new System.EventHandler(this.cbfor_CheckedChanged);
            // 
            // flptype
            // 
            this.flptype.AutoScroll = true;
            this.flptype.Controls.Add(this.cbgs);
            this.flptype.Controls.Add(this.cbjh);
            this.flptype.Controls.Add(this.cbsh);
            this.flptype.Controls.Add(this.cbc);
            this.flptype.Controls.Add(this.cbe);
            this.flptype.Dock = System.Windows.Forms.DockStyle.Right;
            this.flptype.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flptype.Location = new System.Drawing.Point(199, 0);
            this.flptype.Name = "flptype";
            this.flptype.Size = new System.Drawing.Size(472, 56);
            this.flptype.TabIndex = 8;
            // 
            // cbgs
            // 
            this.cbgs.AutoCheck = false;
            this.cbgs.AutoSize = true;
            this.cbgs.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbgs.Location = new System.Drawing.Point(3, 3);
            this.cbgs.Name = "cbgs";
            this.cbgs.Size = new System.Drawing.Size(132, 26);
            this.cbgs.TabIndex = 0;
            this.cbgs.Text = "Grade School";
            this.cbgs.UseVisualStyleBackColor = true;
            // 
            // cbjh
            // 
            this.cbjh.AutoCheck = false;
            this.cbjh.AutoSize = true;
            this.cbjh.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbjh.Location = new System.Drawing.Point(141, 3);
            this.cbjh.Name = "cbjh";
            this.cbjh.Size = new System.Drawing.Size(116, 26);
            this.cbjh.TabIndex = 0;
            this.cbjh.Text = "Junior High";
            this.cbjh.UseVisualStyleBackColor = true;
            // 
            // cbsh
            // 
            this.cbsh.AutoCheck = false;
            this.cbsh.AutoSize = true;
            this.cbsh.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsh.Location = new System.Drawing.Point(263, 3);
            this.cbsh.Name = "cbsh";
            this.cbsh.Size = new System.Drawing.Size(118, 26);
            this.cbsh.TabIndex = 0;
            this.cbsh.Text = "Senior High";
            this.cbsh.UseVisualStyleBackColor = true;
            // 
            // cbc
            // 
            this.cbc.AutoCheck = false;
            this.cbc.AutoSize = true;
            this.cbc.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbc.Location = new System.Drawing.Point(387, 3);
            this.cbc.Name = "cbc";
            this.cbc.Size = new System.Drawing.Size(90, 26);
            this.cbc.TabIndex = 0;
            this.cbc.Text = "College";
            this.cbc.UseVisualStyleBackColor = true;
            // 
            // cbe
            // 
            this.cbe.AutoCheck = false;
            this.cbe.AutoSize = true;
            this.cbe.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbe.Location = new System.Drawing.Point(483, 3);
            this.cbe.Name = "cbe";
            this.cbe.Size = new System.Drawing.Size(105, 26);
            this.cbe.TabIndex = 0;
            this.cbe.Text = "Employee";
            this.cbe.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Filter";
            // 
            // psearch
            // 
            this.psearch.BackColor = System.Drawing.Color.Transparent;
            this.psearch.Controls.Add(this.cbsearch);
            this.psearch.Controls.Add(this.txtsearch);
            this.psearch.Location = new System.Drawing.Point(34, 115);
            this.psearch.Name = "psearch";
            this.psearch.Size = new System.Drawing.Size(674, 56);
            this.psearch.TabIndex = 6;
            // 
            // cbsearch
            // 
            this.cbsearch.AutoSize = true;
            this.cbsearch.BackColor = System.Drawing.Color.Transparent;
            this.cbsearch.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F);
            this.cbsearch.Location = new System.Drawing.Point(23, 15);
            this.cbsearch.Name = "cbsearch";
            this.cbsearch.Size = new System.Drawing.Size(86, 26);
            this.cbsearch.TabIndex = 8;
            this.cbsearch.Text = "Search:";
            this.cbsearch.UseVisualStyleBackColor = false;
            this.cbsearch.CheckedChanged += new System.EventHandler(this.cbsearch_CheckedChanged);
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsearch.Enabled = false;
            this.txtsearch.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(172, 10);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(455, 34);
            this.txtsearch.TabIndex = 1;
            // 
            // psort
            // 
            this.psort.BackColor = System.Drawing.Color.Transparent;
            this.psort.Controls.Add(this.cbsortby);
            this.psort.Controls.Add(this.cbsort);
            this.psort.Location = new System.Drawing.Point(722, 177);
            this.psort.Name = "psort";
            this.psort.Size = new System.Drawing.Size(551, 52);
            this.psort.TabIndex = 6;
            // 
            // cbsortby
            // 
            this.cbsortby.AutoSize = true;
            this.cbsortby.BackColor = System.Drawing.Color.Transparent;
            this.cbsortby.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F);
            this.cbsortby.Location = new System.Drawing.Point(32, 15);
            this.cbsortby.Name = "cbsortby";
            this.cbsortby.Size = new System.Drawing.Size(90, 26);
            this.cbsortby.TabIndex = 8;
            this.cbsortby.Text = "Sort By:";
            this.cbsortby.UseVisualStyleBackColor = false;
            this.cbsortby.CheckedChanged += new System.EventHandler(this.cbsortby_CheckedChanged);
            // 
            // cbsort
            // 
            this.cbsort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbsort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsort.Enabled = false;
            this.cbsort.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsort.FormattingEnabled = true;
            this.cbsort.Location = new System.Drawing.Point(184, 12);
            this.cbsort.Name = "cbsort";
            this.cbsort.Size = new System.Drawing.Size(349, 35);
            this.cbsort.TabIndex = 2;
            // 
            // dtgridview
            // 
            this.dtgridview.AllowUserToAddRows = false;
            this.dtgridview.AllowUserToDeleteRows = false;
            this.dtgridview.AllowUserToResizeColumns = false;
            this.dtgridview.AllowUserToResizeRows = false;
            this.dtgridview.BackgroundColor = System.Drawing.Color.White;
            this.dtgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridview.Location = new System.Drawing.Point(12, 244);
            this.dtgridview.Name = "dtgridview";
            this.dtgridview.ReadOnly = true;
            this.dtgridview.RowHeadersVisible = false;
            this.dtgridview.RowHeadersWidth = 51;
            this.dtgridview.RowTemplate.Height = 24;
            this.dtgridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgridview.Size = new System.Drawing.Size(1496, 626);
            this.dtgridview.TabIndex = 7;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // cbattended
            // 
            this.cbattended.BackColor = System.Drawing.Color.White;
            this.cbattended.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbattended.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbattended.Location = new System.Drawing.Point(337, 33);
            this.cbattended.Name = "cbattended";
            this.cbattended.ReadOnly = true;
            this.cbattended.Size = new System.Drawing.Size(230, 34);
            this.cbattended.TabIndex = 1;
            // 
            // rbadmission
            // 
            this.rbadmission.AutoSize = true;
            this.rbadmission.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbadmission.Location = new System.Drawing.Point(590, 37);
            this.rbadmission.Name = "rbadmission";
            this.rbadmission.Size = new System.Drawing.Size(158, 26);
            this.rbadmission.TabIndex = 8;
            this.rbadmission.TabStop = true;
            this.rbadmission.Text = "List of Admission";
            this.rbadmission.UseVisualStyleBackColor = true;
            this.rbadmission.CheckedChanged += new System.EventHandler(this.rbadmission_CheckedChanged);
            // 
            // rbinventory
            // 
            this.rbinventory.AutoSize = true;
            this.rbinventory.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbinventory.Location = new System.Drawing.Point(754, 36);
            this.rbinventory.Name = "rbinventory";
            this.rbinventory.Size = new System.Drawing.Size(101, 26);
            this.rbinventory.TabIndex = 8;
            this.rbinventory.TabStop = true;
            this.rbinventory.Text = "Inventory";
            this.rbinventory.UseVisualStyleBackColor = true;
            this.rbinventory.Visible = false;
            this.rbinventory.CheckedChanged += new System.EventHandler(this.rbinventory_CheckedChanged);
            // 
            // rblog
            // 
            this.rblog.AutoSize = true;
            this.rblog.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rblog.Location = new System.Drawing.Point(869, 36);
            this.rblog.Name = "rblog";
            this.rblog.Size = new System.Drawing.Size(154, 26);
            this.rblog.TabIndex = 8;
            this.rblog.TabStop = true;
            this.rblog.Text = "List of Logbooks";
            this.rblog.UseVisualStyleBackColor = true;
            this.rblog.CheckedChanged += new System.EventHandler(this.rblog_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(586, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Report for:";
            // 
            // pselect
            // 
            this.pselect.BackColor = System.Drawing.Color.Transparent;
            this.pselect.Controls.Add(this.rboh);
            this.pselect.Controls.Add(this.cbselect);
            this.pselect.Controls.Add(this.rbcs);
            this.pselect.Controls.Add(this.rboos);
            this.pselect.Location = new System.Drawing.Point(702, 295);
            this.pselect.Name = "pselect";
            this.pselect.Size = new System.Drawing.Size(617, 56);
            this.pselect.TabIndex = 6;
            this.pselect.Visible = false;
            // 
            // rboh
            // 
            this.rboh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rboh.AutoSize = true;
            this.rboh.Enabled = false;
            this.rboh.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F);
            this.rboh.Location = new System.Drawing.Point(453, 15);
            this.rboh.Name = "rboh";
            this.rboh.Size = new System.Drawing.Size(97, 26);
            this.rboh.TabIndex = 9;
            this.rboh.Text = "On Hand";
            this.rboh.UseVisualStyleBackColor = true;
            // 
            // cbselect
            // 
            this.cbselect.AutoSize = true;
            this.cbselect.BackColor = System.Drawing.Color.Transparent;
            this.cbselect.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F);
            this.cbselect.Location = new System.Drawing.Point(18, 15);
            this.cbselect.Name = "cbselect";
            this.cbselect.Size = new System.Drawing.Size(105, 26);
            this.cbselect.TabIndex = 8;
            this.cbselect.Text = "Select by:";
            this.cbselect.UseVisualStyleBackColor = false;
            this.cbselect.CheckedChanged += new System.EventHandler(this.rbselect_CheckedChanged);
            // 
            // rbcs
            // 
            this.rbcs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbcs.AutoSize = true;
            this.rbcs.Enabled = false;
            this.rbcs.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F);
            this.rbcs.Location = new System.Drawing.Point(309, 15);
            this.rbcs.Name = "rbcs";
            this.rbcs.Size = new System.Drawing.Size(130, 26);
            this.rbcs.TabIndex = 9;
            this.rbcs.Text = "Critical Stock";
            this.rbcs.UseVisualStyleBackColor = true;
            // 
            // rboos
            // 
            this.rboos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rboos.AutoSize = true;
            this.rboos.Enabled = false;
            this.rboos.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F);
            this.rboos.Location = new System.Drawing.Point(176, 15);
            this.rboos.Name = "rboos";
            this.rboos.Size = new System.Drawing.Size(124, 26);
            this.rboos.TabIndex = 9;
            this.rboos.Text = "Out of Stock";
            this.rboos.UseVisualStyleBackColor = true;
            // 
            // iconButton4
            // 
            this.iconButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(105)))));
            this.iconButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.Font = new System.Drawing.Font("Segoe UI Variable Display", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton4.ForeColor = System.Drawing.Color.White;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton4.IconColor = System.Drawing.Color.Black;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.Location = new System.Drawing.Point(1304, 183);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(94, 46);
            this.iconButton4.TabIndex = 3;
            this.iconButton4.Text = "Go";
            this.iconButton4.UseVisualStyleBackColor = false;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // iconButton5
            // 
            this.iconButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(105)))));
            this.iconButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton5.ForeColor = System.Drawing.Color.White;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.iconButton5.IconColor = System.Drawing.Color.White;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.iconButton5.IconSize = 23;
            this.iconButton5.Location = new System.Drawing.Point(1368, 20);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton5.Size = new System.Drawing.Size(136, 38);
            this.iconButton5.TabIndex = 3;
            this.iconButton5.Text = "Export PDF";
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton5.UseVisualStyleBackColor = false;
            this.iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(105)))));
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 23;
            this.iconButton1.Location = new System.Drawing.Point(1228, 20);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton1.Size = new System.Drawing.Size(136, 38);
            this.iconButton1.TabIndex = 3;
            this.iconButton1.Text = "Preview";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(105)))));
            this.iconButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("Segoe UI Variable Display", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.Color.White;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton3.IconColor = System.Drawing.Color.Black;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.Location = new System.Drawing.Point(1409, 65);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(95, 38);
            this.iconButton3.TabIndex = 3;
            this.iconButton3.Text = "Export PDF";
            this.iconButton3.UseVisualStyleBackColor = false;
            this.iconButton3.Visible = false;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.Firebrick;
            this.iconButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton2.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 23;
            this.iconButton2.Location = new System.Drawing.Point(1088, 20);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton2.Size = new System.Drawing.Size(136, 38);
            this.iconButton2.TabIndex = 3;
            this.iconButton2.Text = "Reset";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // enddate
            // 
            this.enddate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.enddate.BorderColor = System.Drawing.Color.Transparent;
            this.enddate.BorderSize = 2;
            this.enddate.CustomFormat = "MMMM dd, yyyy";
            this.enddate.Enabled = false;
            this.enddate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.enddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.enddate.Location = new System.Drawing.Point(470, 9);
            this.enddate.MinimumSize = new System.Drawing.Size(4, 35);
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(157, 35);
            this.enddate.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.enddate.TabIndex = 7;
            this.enddate.TextColor = System.Drawing.Color.White;
            // 
            // startdate
            // 
            this.startdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startdate.BorderColor = System.Drawing.Color.Transparent;
            this.startdate.BorderSize = 2;
            this.startdate.CustomFormat = "MMMM dd, yyyy";
            this.startdate.Enabled = false;
            this.startdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.startdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startdate.Location = new System.Drawing.Point(207, 9);
            this.startdate.MinimumSize = new System.Drawing.Size(4, 35);
            this.startdate.Name = "startdate";
            this.startdate.Size = new System.Drawing.Size(157, 35);
            this.startdate.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.startdate.TabIndex = 7;
            this.startdate.TextColor = System.Drawing.Color.White;
            // 
            // Report
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1520, 882);
            this.Controls.Add(this.pselect);
            this.Controls.Add(this.rblog);
            this.Controls.Add(this.rbinventory);
            this.Controls.Add(this.rbadmission);
            this.Controls.Add(this.preport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.psearch);
            this.Controls.Add(this.psort);
            this.Controls.Add(this.pdate);
            this.Controls.Add(this.iconButton4);
            this.Controls.Add(this.iconButton5);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.iconButton3);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.cbattended);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgridview);
            this.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.pdate.ResumeLayout(false);
            this.pdate.PerformLayout();
            this.preport.ResumeLayout(false);
            this.preport.PerformLayout();
            this.flptype.ResumeLayout(false);
            this.flptype.PerformLayout();
            this.psearch.ResumeLayout(false);
            this.psearch.PerformLayout();
            this.psort.ResumeLayout(false);
            this.psort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridview)).EndInit();
            this.pselect.ResumeLayout(false);
            this.pselect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Panel pdate;
        private System.Windows.Forms.Panel preport;
        private System.Windows.Forms.FlowLayoutPanel flptype;
        private System.Windows.Forms.CheckBox cbe;
        private System.Windows.Forms.CheckBox cbc;
        private System.Windows.Forms.CheckBox cbsh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbgs;
        private System.Windows.Forms.CheckBox cbjh;
        private WindowsFormsApp1.NewFolder1.JDateTimePicker startdate;
        private WindowsFormsApp1.NewFolder1.JDateTimePicker enddate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel psearch;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Panel psort;
        private System.Windows.Forms.ComboBox cbsort;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
        private System.Windows.Forms.DataGridView dtgridview;
        private System.Windows.Forms.CheckBox cbsearch;
        private System.Windows.Forms.CheckBox cbdate;
        private System.Windows.Forms.CheckBox cbfor;
        private System.Windows.Forms.CheckBox cbsortby;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private FontAwesome.Sharp.IconButton iconButton5;
        private System.Windows.Forms.TextBox cbattended;
        private System.Windows.Forms.RadioButton rbadmission;
        private System.Windows.Forms.RadioButton rbinventory;
        private System.Windows.Forms.RadioButton rblog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pselect;
        private System.Windows.Forms.CheckBox cbselect;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.CheckBox rboh;
        private System.Windows.Forms.CheckBox rbcs;
        private System.Windows.Forms.CheckBox rboos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}