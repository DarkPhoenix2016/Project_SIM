namespace Project_SIM.Views.Customer
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
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
            this.listViewBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewBills.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBills.FullRowSelect = true;
            this.listViewBills.HideSelection = false;
            this.listViewBills.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewBills.Location = new System.Drawing.Point(0, 0);
            this.listViewBills.MultiSelect = false;
            this.listViewBills.Name = "listViewBills";
            this.listViewBills.Size = new System.Drawing.Size(988, 654);
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
            // BillsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 654);
            this.Controls.Add(this.listViewBills);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "BillsPage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "BillsPage";
            this.Load += new System.EventHandler(this.BillsPage_Load);
            this.Resize += new System.EventHandler(this.Screen_Resize);
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
    }
}