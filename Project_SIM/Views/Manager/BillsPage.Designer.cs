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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "1",
            "gdsg",
            "sgs",
            "sgd",
            "sgg",
            "sgdg",
            "sgd"}, -1);
            this.listViewBills = new System.Windows.Forms.ListView();
            this.index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.billNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.distcount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewBills
            // 
            this.listViewBills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.date,
            this.billNumber,
            this.itemCount,
            this.subTotal,
            this.distcount,
            this.total});
            this.listViewBills.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewBills.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBills.FullRowSelect = true;
            this.listViewBills.HideSelection = false;
            this.listViewBills.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listViewBills.Location = new System.Drawing.Point(3, 122);
            this.listViewBills.MultiSelect = false;
            this.listViewBills.Name = "listViewBills";
            this.listViewBills.Size = new System.Drawing.Size(1260, 626);
            this.listViewBills.TabIndex = 0;
            this.listViewBills.UseCompatibleStateImageBehavior = false;
            this.listViewBills.View = System.Windows.Forms.View.Details;
            this.listViewBills.ItemActivate += new System.EventHandler(this.listViewBills_ItemActivate);
            // 
            // index
            // 
            this.index.Text = "#";
            // 
            // date
            // 
            this.date.Text = "Date";
            // 
            // billNumber
            // 
            this.billNumber.Text = "Bill Number";
            this.billNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.billNumber.Width = 239;
            // 
            // itemCount
            // 
            this.itemCount.Text = "No. of Lines";
            this.itemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.itemCount.Width = 170;
            // 
            // subTotal
            // 
            this.subTotal.Text = "Sub Total";
            this.subTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subTotal.Width = 156;
            // 
            // distcount
            // 
            this.distcount.Text = "Discount";
            this.distcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.distcount.Width = 134;
            // 
            // total
            // 
            this.total.Text = "Total";
            this.total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.total.Width = 117;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSearchWord);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1260, 122);
            this.panel3.TabIndex = 20;
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchWord.Location = new System.Drawing.Point(200, 64);
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
            this.label9.Location = new System.Drawing.Point(14, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 34);
            this.label9.TabIndex = 17;
            this.label9.Text = "Sale Bill Records";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find Bill (Bill Number)";
            // 
            // BillsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 802);
            this.Controls.Add(this.listViewBills);
            this.Controls.Add(this.panel3);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.MaximizeBox = false;
            this.Name = "BillsPage";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "BillsPage";
            this.Load += new System.EventHandler(this.BillsPage_Load);
            this.Resize += new System.EventHandler(this.Screen_Resize);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewBills;
        private System.Windows.Forms.ColumnHeader index;
        private System.Windows.Forms.ColumnHeader billNumber;
        private System.Windows.Forms.ColumnHeader itemCount;
        private System.Windows.Forms.ColumnHeader subTotal;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader distcount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
    }
}