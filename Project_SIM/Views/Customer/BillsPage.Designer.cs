﻿namespace Project_SIM.Views.Customer
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
            this.listViewBills = new System.Windows.Forms.ListView();
            this.index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.billNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewBills
            // 
            this.listViewBills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.billNumber,
            this.itemCount,
            this.subTotal,
            this.total,
            this.paymentMethod});
            this.listViewBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewBills.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBills.HideSelection = false;
            this.listViewBills.Location = new System.Drawing.Point(0, 0);
            this.listViewBills.Name = "listViewBills";
            this.listViewBills.Size = new System.Drawing.Size(988, 654);
            this.listViewBills.TabIndex = 0;
            this.listViewBills.UseCompatibleStateImageBehavior = false;
            this.listViewBills.View = System.Windows.Forms.View.Details;
            // 
            // index
            // 
            this.index.Text = "#";
            // 
            // billNumber
            // 
            this.billNumber.Text = "Bill Number";
            this.billNumber.Width = 239;
            // 
            // itemCount
            // 
            this.itemCount.Text = "No. of Items";
            this.itemCount.Width = 170;
            // 
            // subTotal
            // 
            this.subTotal.Text = "Sub Total";
            this.subTotal.Width = 156;
            // 
            // total
            // 
            this.total.Text = "Total";
            this.total.Width = 117;
            // 
            // paymentMethod
            // 
            this.paymentMethod.Text = "Payment Method";
            this.paymentMethod.Width = 201;
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
        private System.Windows.Forms.ColumnHeader paymentMethod;
    }
}