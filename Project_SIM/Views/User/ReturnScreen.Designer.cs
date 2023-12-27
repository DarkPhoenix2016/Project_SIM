namespace Project_SIM.Views.User
{
    partial class ReturnScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchBill = new System.Windows.Forms.TextBox();
            this.btnSearchBill = new System.Windows.Forms.Button();
            this.listViewBilledItems = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.billedQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.returnedQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClearBill = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.txtSelecedProductCode = new System.Windows.Forms.TextBox();
            this.txtSelecedProductName = new System.Windows.Forms.TextBox();
            this.txtBilledQuantity = new System.Windows.Forms.TextBox();
            this.txtReturnedQunatity = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblLoggedUser = new System.Windows.Forms.Label();
            this.txtNowReturningQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtReturnReason = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill Number:";
            // 
            // txtSearchBill
            // 
            this.txtSearchBill.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBill.Location = new System.Drawing.Point(140, 128);
            this.txtSearchBill.Name = "txtSearchBill";
            this.txtSearchBill.Size = new System.Drawing.Size(318, 31);
            this.txtSearchBill.TabIndex = 1;
            // 
            // btnSearchBill
            // 
            this.btnSearchBill.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchBill.Location = new System.Drawing.Point(464, 126);
            this.btnSearchBill.Name = "btnSearchBill";
            this.btnSearchBill.Size = new System.Drawing.Size(145, 33);
            this.btnSearchBill.TabIndex = 2;
            this.btnSearchBill.Text = "Load Bill";
            this.btnSearchBill.UseVisualStyleBackColor = true;
            // 
            // listViewBilledItems
            // 
            this.listViewBilledItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.productCode,
            this.productName,
            this.billedQuantity,
            this.returnedQuantity});
            this.listViewBilledItems.Enabled = false;
            this.listViewBilledItems.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBilledItems.HideSelection = false;
            this.listViewBilledItems.Location = new System.Drawing.Point(23, 194);
            this.listViewBilledItems.Name = "listViewBilledItems";
            this.listViewBilledItems.Size = new System.Drawing.Size(586, 375);
            this.listViewBilledItems.TabIndex = 3;
            this.listViewBilledItems.UseCompatibleStateImageBehavior = false;
            this.listViewBilledItems.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#";
            // 
            // productCode
            // 
            this.productCode.Text = "Code";
            // 
            // productName
            // 
            this.productName.Text = "Name";
            // 
            // billedQuantity
            // 
            this.billedQuantity.Text = "Billed Quantity";
            // 
            // returnedQuantity
            // 
            this.returnedQuantity.Text = "ReturnedQuantity";
            // 
            // btnClearBill
            // 
            this.btnClearBill.Enabled = false;
            this.btnClearBill.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBill.Location = new System.Drawing.Point(615, 126);
            this.btnClearBill.Name = "btnClearBill";
            this.btnClearBill.Size = new System.Drawing.Size(145, 33);
            this.btnClearBill.TabIndex = 5;
            this.btnClearBill.Text = "Clear";
            this.btnClearBill.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(645, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bill Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(645, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seletced Product Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(645, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seletced Product Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(645, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Billed Quantity:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(645, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 28);
            this.label6.TabIndex = 10;
            this.label6.Text = "Returned Quantity:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 28);
            this.label7.TabIndex = 11;
            this.label7.Text = "Logged User:";
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Enabled = false;
            this.txtBillNumber.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNumber.Location = new System.Drawing.Point(895, 194);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(281, 31);
            this.txtBillNumber.TabIndex = 12;
            // 
            // txtSelecedProductCode
            // 
            this.txtSelecedProductCode.Enabled = false;
            this.txtSelecedProductCode.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelecedProductCode.Location = new System.Drawing.Point(895, 241);
            this.txtSelecedProductCode.Name = "txtSelecedProductCode";
            this.txtSelecedProductCode.Size = new System.Drawing.Size(281, 31);
            this.txtSelecedProductCode.TabIndex = 13;
            // 
            // txtSelecedProductName
            // 
            this.txtSelecedProductName.Enabled = false;
            this.txtSelecedProductName.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelecedProductName.Location = new System.Drawing.Point(895, 288);
            this.txtSelecedProductName.Name = "txtSelecedProductName";
            this.txtSelecedProductName.Size = new System.Drawing.Size(281, 31);
            this.txtSelecedProductName.TabIndex = 14;
            // 
            // txtBilledQuantity
            // 
            this.txtBilledQuantity.Enabled = false;
            this.txtBilledQuantity.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBilledQuantity.Location = new System.Drawing.Point(895, 335);
            this.txtBilledQuantity.Name = "txtBilledQuantity";
            this.txtBilledQuantity.Size = new System.Drawing.Size(281, 31);
            this.txtBilledQuantity.TabIndex = 15;
            // 
            // txtReturnedQunatity
            // 
            this.txtReturnedQunatity.AcceptsTab = true;
            this.txtReturnedQunatity.Enabled = false;
            this.txtReturnedQunatity.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnedQunatity.Location = new System.Drawing.Point(895, 382);
            this.txtReturnedQunatity.Name = "txtReturnedQunatity";
            this.txtReturnedQunatity.Size = new System.Drawing.Size(281, 31);
            this.txtReturnedQunatity.TabIndex = 16;
            // 
            // btnReturn
            // 
            this.btnReturn.Enabled = false;
            this.btnReturn.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(868, 536);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(145, 33);
            this.btnReturn.TabIndex = 17;
            this.btnReturn.Text = "Return ";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // lblLoggedUser
            // 
            this.lblLoggedUser.AutoSize = true;
            this.lblLoggedUser.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedUser.Location = new System.Drawing.Point(138, 78);
            this.lblLoggedUser.Name = "lblLoggedUser";
            this.lblLoggedUser.Size = new System.Drawing.Size(24, 28);
            this.lblLoggedUser.TabIndex = 18;
            this.lblLoggedUser.Text = "_";
            // 
            // txtNowReturningQuantity
            // 
            this.txtNowReturningQuantity.Enabled = false;
            this.txtNowReturningQuantity.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNowReturningQuantity.Location = new System.Drawing.Point(895, 429);
            this.txtNowReturningQuantity.Name = "txtNowReturningQuantity";
            this.txtNowReturningQuantity.Size = new System.Drawing.Size(281, 31);
            this.txtNowReturningQuantity.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(645, 434);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 28);
            this.label8.TabIndex = 19;
            this.label8.Text = "Returning Quantity:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1031, 536);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 33);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtReturnReason
            // 
            this.txtReturnReason.Enabled = false;
            this.txtReturnReason.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnReason.Location = new System.Drawing.Point(895, 476);
            this.txtReturnReason.Name = "txtReturnReason";
            this.txtReturnReason.Size = new System.Drawing.Size(281, 31);
            this.txtReturnReason.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(645, 482);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 28);
            this.label9.TabIndex = 22;
            this.label9.Text = "Returning Reason:";
            // 
            // ReturnScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.txtReturnReason);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtNowReturningQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblLoggedUser);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.txtReturnedQunatity);
            this.Controls.Add(this.txtBilledQuantity);
            this.Controls.Add(this.txtSelecedProductName);
            this.Controls.Add(this.txtSelecedProductCode);
            this.Controls.Add(this.txtBillNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClearBill);
            this.Controls.Add(this.listViewBilledItems);
            this.Controls.Add(this.btnSearchBill);
            this.Controls.Add(this.txtSearchBill);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "ReturnScreen";
            this.Text = "Return Item";
            this.Load += new System.EventHandler(this.ReturnScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchBill;
        private System.Windows.Forms.Button btnSearchBill;
        private System.Windows.Forms.ListView listViewBilledItems;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader productCode;
        private System.Windows.Forms.ColumnHeader billedQuantity;
        private System.Windows.Forms.ColumnHeader returnedQuantity;
        private System.Windows.Forms.ColumnHeader productName;
        private System.Windows.Forms.Button btnClearBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBillNumber;
        private System.Windows.Forms.TextBox txtSelecedProductCode;
        private System.Windows.Forms.TextBox txtSelecedProductName;
        private System.Windows.Forms.TextBox txtBilledQuantity;
        private System.Windows.Forms.TextBox txtReturnedQunatity;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblLoggedUser;
        private System.Windows.Forms.TextBox txtNowReturningQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtReturnReason;
        private System.Windows.Forms.Label label9;
    }
}