namespace Project_SIM.Views.Manager
{
    partial class BillsPage
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.objListViewBills = new BrightIdeasSoftware.ObjectListView();
            this.NoCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colBillNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colNoLins = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSubTotal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colDiscount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTotal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colViweBill = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chckBoxShowGroups = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListViewBills)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.txtSearchWord);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1260, 92);
            this.panel3.TabIndex = 20;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1154, 46);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 37);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchWord.Location = new System.Drawing.Point(200, 52);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(382, 31);
            this.txtSearchWord.TabIndex = 1;
            this.txtSearchWord.TextChanged += new System.EventHandler(this.txtSearchWord_TextChanged);
            this.txtSearchWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchWord_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 34);
            this.label9.TabIndex = 17;
            this.label9.Text = "Sale Bill Records";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find Bill (Bill Number)";
            // 
            // objListViewBills
            // 
            this.objListViewBills.AllColumns.Add(this.NoCol);
            this.objListViewBills.AllColumns.Add(this.colDate);
            this.objListViewBills.AllColumns.Add(this.colBillNumber);
            this.objListViewBills.AllColumns.Add(this.colNoLins);
            this.objListViewBills.AllColumns.Add(this.colSubTotal);
            this.objListViewBills.AllColumns.Add(this.colDiscount);
            this.objListViewBills.AllColumns.Add(this.colTotal);
            this.objListViewBills.AllColumns.Add(this.colViweBill);
            this.objListViewBills.CellEditUseWholeCell = false;
            this.objListViewBills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NoCol,
            this.colDate,
            this.colBillNumber,
            this.colNoLins,
            this.colSubTotal,
            this.colDiscount,
            this.colTotal,
            this.colViweBill});
            this.objListViewBills.Cursor = System.Windows.Forms.Cursors.Default;
            this.objListViewBills.Dock = System.Windows.Forms.DockStyle.Top;
            this.objListViewBills.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objListViewBills.FullRowSelect = true;
            this.objListViewBills.HideSelection = false;
            this.objListViewBills.Location = new System.Drawing.Point(3, 127);
            this.objListViewBills.Name = "objListViewBills";
            this.objListViewBills.ShowGroups = false;
            this.objListViewBills.Size = new System.Drawing.Size(1260, 660);
            this.objListViewBills.TabIndex = 21;
            this.objListViewBills.UseCompatibleStateImageBehavior = false;
            this.objListViewBills.View = System.Windows.Forms.View.Details;
            this.objListViewBills.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.objListViewBills_ButtonClick);
            // 
            // NoCol
            // 
            this.NoCol.Groupable = false;
            this.NoCol.Text = "#";
            this.NoCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colDate
            // 
            this.colDate.FillsFreeSpace = true;
            this.colDate.Text = "Date";
            // 
            // colBillNumber
            // 
            this.colBillNumber.FillsFreeSpace = true;
            this.colBillNumber.Groupable = false;
            this.colBillNumber.Text = "Bill Number";
            // 
            // colNoLins
            // 
            this.colNoLins.Groupable = false;
            this.colNoLins.Sortable = false;
            this.colNoLins.Text = "Lines";
            this.colNoLins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNoLins.UseFiltering = false;
            // 
            // colSubTotal
            // 
            this.colSubTotal.FillsFreeSpace = true;
            this.colSubTotal.Groupable = false;
            this.colSubTotal.Sortable = false;
            this.colSubTotal.Text = "Sub Total (Rs)";
            this.colSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSubTotal.UseFiltering = false;
            // 
            // colDiscount
            // 
            this.colDiscount.FillsFreeSpace = true;
            this.colDiscount.Groupable = false;
            this.colDiscount.Sortable = false;
            this.colDiscount.Text = "Discount (Rs)";
            this.colDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDiscount.UseFiltering = false;
            // 
            // colTotal
            // 
            this.colTotal.FillsFreeSpace = true;
            this.colTotal.Groupable = false;
            this.colTotal.Sortable = false;
            this.colTotal.Text = "Total (Rs)";
            this.colTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotal.UseFiltering = false;
            // 
            // colViweBill
            // 
            this.colViweBill.ButtonPadding = new System.Drawing.Size(10, 5);
            this.colViweBill.ButtonSize = new System.Drawing.Size(100, 50);
            this.colViweBill.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.colViweBill.FillsFreeSpace = true;
            this.colViweBill.Groupable = false;
            this.colViweBill.IsButton = true;
            this.colViweBill.Sortable = false;
            this.colViweBill.Text = "";
            this.colViweBill.UseFiltering = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chckBoxShowGroups);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 92);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 35);
            this.panel1.TabIndex = 21;
            // 
            // chckBoxShowGroups
            // 
            this.chckBoxShowGroups.AutoSize = true;
            this.chckBoxShowGroups.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckBoxShowGroups.Location = new System.Drawing.Point(133, 7);
            this.chckBoxShowGroups.Margin = new System.Windows.Forms.Padding(0);
            this.chckBoxShowGroups.Name = "chckBoxShowGroups";
            this.chckBoxShowGroups.Padding = new System.Windows.Forms.Padding(5);
            this.chckBoxShowGroups.Size = new System.Drawing.Size(25, 24);
            this.chckBoxShowGroups.TabIndex = 1;
            this.chckBoxShowGroups.UseVisualStyleBackColor = true;
            this.chckBoxShowGroups.CheckedChanged += new System.EventHandler(this.chckBoxShowGroups_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Show Groups";
            // 
            // BillsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 802);
            this.Controls.Add(this.objListViewBills);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.MaximizeBox = false;
            this.Name = "BillsPage";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "BillsPage";
            this.Load += new System.EventHandler(this.BillsPage_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListViewBills)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.ObjectListView objListViewBills;
        private BrightIdeasSoftware.OLVColumn NoCol;
        private BrightIdeasSoftware.OLVColumn colDate;
        private BrightIdeasSoftware.OLVColumn colBillNumber;
        private BrightIdeasSoftware.OLVColumn colNoLins;
        private BrightIdeasSoftware.OLVColumn colSubTotal;
        private BrightIdeasSoftware.OLVColumn colDiscount;
        private BrightIdeasSoftware.OLVColumn colTotal;
        private BrightIdeasSoftware.OLVColumn colViweBill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chckBoxShowGroups;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
    }
}