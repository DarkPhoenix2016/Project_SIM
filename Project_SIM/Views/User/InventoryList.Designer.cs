namespace Project_SIM.Views.User
{
    partial class InventoryList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryList));
            this.listViewProductList = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewProductList
            // 
            this.listViewProductList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.productCode,
            this.productName,
            this.productPrice,
            this.productUnit});
            this.listViewProductList.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewProductList.FullRowSelect = true;
            this.listViewProductList.HideSelection = false;
            this.listViewProductList.Location = new System.Drawing.Point(6, 67);
            this.listViewProductList.MultiSelect = false;
            this.listViewProductList.Name = "listViewProductList";
            this.listViewProductList.Size = new System.Drawing.Size(1364, 560);
            this.listViewProductList.TabIndex = 0;
            this.listViewProductList.UseCompatibleStateImageBehavior = false;
            this.listViewProductList.View = System.Windows.Forms.View.Details;
            this.listViewProductList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewProductList_KeyDown);
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
            // productPrice
            // 
            this.productPrice.Text = "Unit Price";
            // 
            // productUnit
            // 
            this.productUnit.Text = "Units";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 660);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Code or Name";
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchWord.Location = new System.Drawing.Point(232, 659);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(517, 31);
            this.txtSearchWord.TabIndex = 0;
            this.txtSearchWord.TextChanged += new System.EventHandler(this.txtSearchWord_TextChanged);
            this.txtSearchWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchWord_KeyPress);
            // 
            // InventoryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 753);
            this.Controls.Add(this.txtSearchWord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewProductList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryList";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product List";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewProductList;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader productCode;
        private System.Windows.Forms.ColumnHeader productName;
        private System.Windows.Forms.ColumnHeader productPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.ColumnHeader productUnit;
    }
}