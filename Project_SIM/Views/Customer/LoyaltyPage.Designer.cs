namespace Project_SIM.Views.Customer
{
    partial class LoyaltyPage
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
            this.listViewLoyalty = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.runningBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewLoyalty
            // 
            this.listViewLoyalty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.date,
            this.state,
            this.amount,
            this.runningBalance});
            this.listViewLoyalty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLoyalty.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewLoyalty.FullRowSelect = true;
            this.listViewLoyalty.HideSelection = false;
            this.listViewLoyalty.Location = new System.Drawing.Point(0, 0);
            this.listViewLoyalty.Name = "listViewLoyalty";
            this.listViewLoyalty.Size = new System.Drawing.Size(800, 450);
            this.listViewLoyalty.TabIndex = 0;
            this.listViewLoyalty.UseCompatibleStateImageBehavior = false;
            this.listViewLoyalty.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#";
            // 
            // date
            // 
            this.date.Text = "Date";
            // 
            // state
            // 
            this.state.Text = "State";
            this.state.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // amount
            // 
            this.amount.Text = "Amount";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // runningBalance
            // 
            this.runningBalance.Text = "Balance";
            this.runningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LoyaltyPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewLoyalty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoyaltyPage";
            this.Text = "LoyaltyPage";
            this.Load += new System.EventHandler(this.LoyaltyPage_Load);
            this.Resize += new System.EventHandler(this.LoyaltyPage_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewLoyalty;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader state;
        private System.Windows.Forms.ColumnHeader runningBalance;
    }
}