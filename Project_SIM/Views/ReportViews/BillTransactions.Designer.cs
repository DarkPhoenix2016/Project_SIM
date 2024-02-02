namespace Project_SIM.Views.ReportView
{
    partial class BillTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillTransactions));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comBoxPayMethods = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Project_SIM.Reports.trasactionReport_without_grouping.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 166);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1038, 879);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comBoxPayMethods);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dateFrom);
            this.panel1.Controls.Add(this.btnLoadReport);
            this.panel1.Controls.Add(this.dateTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 102);
            this.panel1.TabIndex = 1;
            // 
            // comBoxPayMethods
            // 
            this.comBoxPayMethods.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxPayMethods.FormattingEnabled = true;
            this.comBoxPayMethods.Location = new System.Drawing.Point(798, 16);
            this.comBoxPayMethods.Name = "comBoxPayMethods";
            this.comBoxPayMethods.Size = new System.Drawing.Size(223, 36);
            this.comBoxPayMethods.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(644, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 28);
            this.label6.TabIndex = 16;
            this.label6.Text = "Payment Method";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "dd-MM-yyyy";
            this.dateFrom.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(113, 19);
            this.dateFrom.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateFrom.Size = new System.Drawing.Size(213, 31);
            this.dateFrom.TabIndex = 5;
            this.dateFrom.Value = new System.DateTime(2024, 1, 20, 0, 0, 0, 0);
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.Location = new System.Drawing.Point(17, 56);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(180, 35);
            this.btnLoadReport.TabIndex = 4;
            this.btnLoadReport.Text = "Load Report";
            this.btnLoadReport.UseVisualStyleBackColor = true;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "dd-MM-yyyy";
            this.dateTo.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(411, 19);
            this.dateTo.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTo.Name = "dateTo";
            this.dateTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTo.Size = new System.Drawing.Size(213, 31);
            this.dateTo.TabIndex = 3;
            this.dateTo.Value = new System.DateTime(2024, 1, 20, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // BillTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 1100);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1047, 1030);
            this.Name = "BillTransactions";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 6, 6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill Transactions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BillRecord_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.ComboBox comBoxPayMethods;
        private System.Windows.Forms.Label label6;
    }
}