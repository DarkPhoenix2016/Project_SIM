namespace Project_SIM.Views.StoreKeeper
{
    partial class Dashborad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashborad));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnMasterInventory = new System.Windows.Forms.Button();
            this.btnStoreInventory = new System.Windows.Forms.Button();
            this.btnStockTrans = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoSize = true;
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.panel2);
            this.pnlMenu.Controls.Add(this.label3);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.label1);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(3, 64);
            this.pnlMenu.MinimumSize = new System.Drawing.Size(310, 687);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(310, 693);
            this.pnlMenu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btnProfile);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnReports);
            this.panel2.Controls.Add(this.btnMasterInventory);
            this.panel2.Controls.Add(this.btnStoreInventory);
            this.panel2.Controls.Add(this.btnStockTrans);
            this.panel2.Controls.Add(this.btnProducts);
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 571);
            this.panel2.TabIndex = 2;
            // 
            // btnProfile
            // 
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnProfile.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.Image = global::Project_SIM.Properties.Resources.user__1_;
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(0, 475);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnProfile.Size = new System.Drawing.Size(310, 48);
            this.btnProfile.TabIndex = 15;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Image = global::Project_SIM.Properties.Resources.sign_out;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 523);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(310, 48);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReports
            // 
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Image = global::Project_SIM.Properties.Resources.dashboard;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 270);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(310, 54);
            this.btnReports.TabIndex = 16;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click_1);
            // 
            // btnMasterInventory
            // 
            this.btnMasterInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMasterInventory.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterInventory.Image = global::Project_SIM.Properties.Resources.box;
            this.btnMasterInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasterInventory.Location = new System.Drawing.Point(0, 216);
            this.btnMasterInventory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnMasterInventory.Name = "btnMasterInventory";
            this.btnMasterInventory.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMasterInventory.Size = new System.Drawing.Size(310, 54);
            this.btnMasterInventory.TabIndex = 11;
            this.btnMasterInventory.Text = "Master Inventory";
            this.btnMasterInventory.UseVisualStyleBackColor = true;
            this.btnMasterInventory.Click += new System.EventHandler(this.btnMasterInventory_Click);
            // 
            // btnStoreInventory
            // 
            this.btnStoreInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStoreInventory.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoreInventory.Image = global::Project_SIM.Properties.Resources.inventory_2;
            this.btnStoreInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStoreInventory.Location = new System.Drawing.Point(0, 162);
            this.btnStoreInventory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnStoreInventory.Name = "btnStoreInventory";
            this.btnStoreInventory.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnStoreInventory.Size = new System.Drawing.Size(310, 54);
            this.btnStoreInventory.TabIndex = 10;
            this.btnStoreInventory.Text = "Store Inventory";
            this.btnStoreInventory.UseVisualStyleBackColor = true;
            this.btnStoreInventory.Click += new System.EventHandler(this.btnStoreInventory_Click);
            // 
            // btnStockTrans
            // 
            this.btnStockTrans.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockTrans.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockTrans.Image = global::Project_SIM.Properties.Resources.bill;
            this.btnStockTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockTrans.Location = new System.Drawing.Point(0, 108);
            this.btnStockTrans.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnStockTrans.Name = "btnStockTrans";
            this.btnStockTrans.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnStockTrans.Size = new System.Drawing.Size(310, 54);
            this.btnStockTrans.TabIndex = 17;
            this.btnStockTrans.Text = "Stock Transactions";
            this.btnStockTrans.UseVisualStyleBackColor = true;
            this.btnStockTrans.Click += new System.EventHandler(this.btnStockTrans_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.Image = global::Project_SIM.Properties.Resources.product;
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(0, 54);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnProducts.Size = new System.Drawing.Size(310, 54);
            this.btnProducts.TabIndex = 13;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Image = global::Project_SIM.Properties.Resources.home_1;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(310, 54);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 44);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Poppins Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your Sale and Inverntory Manger";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project SIM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dashborad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1260, 760);
            this.Controls.Add(this.pnlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1260, 760);
            this.Name = "Dashborad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Store Keeper Dashborad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashborad_FormClosing);
            this.Load += new System.EventHandler(this.Dashborad_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStoreInventory;
        private System.Windows.Forms.Button btnMasterInventory;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnStockTrans;
    }
}