namespace Project_SIM.Views.StoreKeeper
{
    partial class MainInventory
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
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.ListViewProductInventory = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recivedQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lotExpioryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lotLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtProductCode = new System.Windows.Forms.TextBox();
            this.TxtProductName = new System.Windows.Forms.TextBox();
            this.TxtBarcode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUnit1 = new System.Windows.Forms.Label();
            this.lblUnit4 = new System.Windows.Forms.Label();
            this.lblUnit3 = new System.Windows.Forms.Label();
            this.lblUnit2 = new System.Windows.Forms.Label();
            this.TxtStockLocation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtTotalCurrentStock = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TxtTotalRetuens = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TxtTotalSale = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtTotalStock = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtUnitOfMasure = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtUnitPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtExpiryDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtQunatity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find Product (Name / Code)";
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Location = new System.Drawing.Point(320, 64);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(441, 31);
            this.txtSearchWord.TabIndex = 1;
            this.txtSearchWord.TextChanged += new System.EventHandler(this.txtSearchWord_TextChanged);
            this.txtSearchWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchWord_KeyPress);
            // 
            // ListViewProductInventory
            // 
            this.ListViewProductInventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.productCode,
            this.productName,
            this.recivedQuantity,
            this.lotExpioryDate,
            this.lotLocation});
            this.ListViewProductInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewProductInventory.FullRowSelect = true;
            this.ListViewProductInventory.HideSelection = false;
            this.ListViewProductInventory.Location = new System.Drawing.Point(0, 0);
            this.ListViewProductInventory.MultiSelect = false;
            this.ListViewProductInventory.Name = "ListViewProductInventory";
            this.ListViewProductInventory.Size = new System.Drawing.Size(923, 759);
            this.ListViewProductInventory.TabIndex = 3;
            this.ListViewProductInventory.UseCompatibleStateImageBehavior = false;
            this.ListViewProductInventory.View = System.Windows.Forms.View.Details;
            this.ListViewProductInventory.SelectedIndexChanged += new System.EventHandler(this.ListViewProductInventory_SelectedIndexChanged);
            // 
            // No
            // 
            this.No.Text = "#";
            // 
            // productCode
            // 
            this.productCode.Text = "Code";
            this.productCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.productCode.Width = 78;
            // 
            // productName
            // 
            this.productName.Text = "Name";
            this.productName.Width = 104;
            // 
            // recivedQuantity
            // 
            this.recivedQuantity.Text = "Quantity";
            this.recivedQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.recivedQuantity.Width = 171;
            // 
            // lotExpioryDate
            // 
            this.lotExpioryDate.Text = "Ex.Date";
            this.lotExpioryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lotExpioryDate.Width = 178;
            // 
            // lotLocation
            // 
            this.lotLocation.Text = "Location";
            this.lotLocation.Width = 117;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Product Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Product Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Barcode";
            // 
            // TxtProductCode
            // 
            this.TxtProductCode.BackColor = System.Drawing.Color.White;
            this.TxtProductCode.ForeColor = System.Drawing.Color.Black;
            this.TxtProductCode.Location = new System.Drawing.Point(187, 53);
            this.TxtProductCode.Name = "TxtProductCode";
            this.TxtProductCode.ReadOnly = true;
            this.TxtProductCode.Size = new System.Drawing.Size(262, 31);
            this.TxtProductCode.TabIndex = 9;
            // 
            // TxtProductName
            // 
            this.TxtProductName.BackColor = System.Drawing.Color.White;
            this.TxtProductName.ForeColor = System.Drawing.Color.Black;
            this.TxtProductName.Location = new System.Drawing.Point(187, 94);
            this.TxtProductName.Name = "TxtProductName";
            this.TxtProductName.ReadOnly = true;
            this.TxtProductName.Size = new System.Drawing.Size(262, 31);
            this.TxtProductName.TabIndex = 10;
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.BackColor = System.Drawing.Color.White;
            this.TxtBarcode.ForeColor = System.Drawing.Color.Black;
            this.TxtBarcode.Location = new System.Drawing.Point(187, 135);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.ReadOnly = true;
            this.TxtBarcode.Size = new System.Drawing.Size(262, 31);
            this.TxtBarcode.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUnit1);
            this.panel1.Controls.Add(this.lblUnit4);
            this.panel1.Controls.Add(this.lblUnit3);
            this.panel1.Controls.Add(this.lblUnit2);
            this.panel1.Controls.Add(this.TxtStockLocation);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.TxtTotalCurrentStock);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.TxtTotalRetuens);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.TxtTotalSale);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.TxtTotalStock);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.TxtUnitOfMasure);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.TxtUnitPrice);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.TxtRemark);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TxtExpiryDate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.TxtQunatity);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TxtBarcode);
            this.panel1.Controls.Add(this.TxtProductName);
            this.panel1.Controls.Add(this.TxtProductCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 759);
            this.panel1.TabIndex = 14;
            // 
            // lblUnit1
            // 
            this.lblUnit1.AutoSize = true;
            this.lblUnit1.Location = new System.Drawing.Point(413, 545);
            this.lblUnit1.Name = "lblUnit1";
            this.lblUnit1.Size = new System.Drawing.Size(48, 28);
            this.lblUnit1.TabIndex = 37;
            this.lblUnit1.Text = "___";
            // 
            // lblUnit4
            // 
            this.lblUnit4.AutoSize = true;
            this.lblUnit4.Location = new System.Drawing.Point(414, 672);
            this.lblUnit4.Name = "lblUnit4";
            this.lblUnit4.Size = new System.Drawing.Size(48, 28);
            this.lblUnit4.TabIndex = 40;
            this.lblUnit4.Text = "___";
            // 
            // lblUnit3
            // 
            this.lblUnit3.AutoSize = true;
            this.lblUnit3.Location = new System.Drawing.Point(414, 630);
            this.lblUnit3.Name = "lblUnit3";
            this.lblUnit3.Size = new System.Drawing.Size(48, 28);
            this.lblUnit3.TabIndex = 39;
            this.lblUnit3.Text = "___";
            // 
            // lblUnit2
            // 
            this.lblUnit2.AutoSize = true;
            this.lblUnit2.Location = new System.Drawing.Point(413, 589);
            this.lblUnit2.Name = "lblUnit2";
            this.lblUnit2.Size = new System.Drawing.Size(48, 28);
            this.lblUnit2.TabIndex = 38;
            this.lblUnit2.Text = "___";
            // 
            // TxtStockLocation
            // 
            this.TxtStockLocation.BackColor = System.Drawing.Color.White;
            this.TxtStockLocation.ForeColor = System.Drawing.Color.Black;
            this.TxtStockLocation.Location = new System.Drawing.Point(187, 426);
            this.TxtStockLocation.Name = "TxtStockLocation";
            this.TxtStockLocation.ReadOnly = true;
            this.TxtStockLocation.Size = new System.Drawing.Size(262, 31);
            this.TxtStockLocation.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 426);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 28);
            this.label10.TabIndex = 35;
            this.label10.Text = "Stock Location";
            // 
            // TxtTotalCurrentStock
            // 
            this.TxtTotalCurrentStock.BackColor = System.Drawing.Color.White;
            this.TxtTotalCurrentStock.ForeColor = System.Drawing.Color.Black;
            this.TxtTotalCurrentStock.Location = new System.Drawing.Point(187, 669);
            this.TxtTotalCurrentStock.Name = "TxtTotalCurrentStock";
            this.TxtTotalCurrentStock.ReadOnly = true;
            this.TxtTotalCurrentStock.Size = new System.Drawing.Size(212, 31);
            this.TxtTotalCurrentStock.TabIndex = 34;
            this.TxtTotalCurrentStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 668);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(163, 28);
            this.label20.TabIndex = 33;
            this.label20.Text = "Total Current Stock";
            // 
            // TxtTotalRetuens
            // 
            this.TxtTotalRetuens.BackColor = System.Drawing.Color.White;
            this.TxtTotalRetuens.ForeColor = System.Drawing.Color.Black;
            this.TxtTotalRetuens.Location = new System.Drawing.Point(187, 627);
            this.TxtTotalRetuens.Name = "TxtTotalRetuens";
            this.TxtTotalRetuens.ReadOnly = true;
            this.TxtTotalRetuens.Size = new System.Drawing.Size(212, 31);
            this.TxtTotalRetuens.TabIndex = 32;
            this.TxtTotalRetuens.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 627);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 28);
            this.label19.TabIndex = 31;
            this.label19.Text = "Total Returns";
            // 
            // TxtTotalSale
            // 
            this.TxtTotalSale.BackColor = System.Drawing.Color.White;
            this.TxtTotalSale.ForeColor = System.Drawing.Color.Black;
            this.TxtTotalSale.Location = new System.Drawing.Point(187, 586);
            this.TxtTotalSale.Name = "TxtTotalSale";
            this.TxtTotalSale.ReadOnly = true;
            this.TxtTotalSale.Size = new System.Drawing.Size(212, 31);
            this.TxtTotalSale.TabIndex = 30;
            this.TxtTotalSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(15, 586);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(127, 28);
            this.label18.TabIndex = 29;
            this.label18.Text = "Total Releases";
            // 
            // TxtTotalStock
            // 
            this.TxtTotalStock.BackColor = System.Drawing.Color.White;
            this.TxtTotalStock.ForeColor = System.Drawing.Color.Black;
            this.TxtTotalStock.Location = new System.Drawing.Point(187, 545);
            this.TxtTotalStock.Name = "TxtTotalStock";
            this.TxtTotalStock.ReadOnly = true;
            this.TxtTotalStock.Size = new System.Drawing.Size(212, 31);
            this.TxtTotalStock.TabIndex = 28;
            this.TxtTotalStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 545);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(124, 28);
            this.label17.TabIndex = 27;
            this.label17.Text = "Total Stocked ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(15, 504);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(353, 28);
            this.label16.TabIndex = 26;
            this.label16.Text = "Selected Product Inverntory Summary";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(15, 258);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(253, 28);
            this.label15.TabIndex = 25;
            this.label15.Text = "Selected Inverntory Details";
            // 
            // TxtUnitOfMasure
            // 
            this.TxtUnitOfMasure.BackColor = System.Drawing.Color.White;
            this.TxtUnitOfMasure.ForeColor = System.Drawing.Color.Black;
            this.TxtUnitOfMasure.Location = new System.Drawing.Point(187, 217);
            this.TxtUnitOfMasure.Name = "TxtUnitOfMasure";
            this.TxtUnitOfMasure.ReadOnly = true;
            this.TxtUnitOfMasure.Size = new System.Drawing.Size(262, 31);
            this.TxtUnitOfMasure.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 217);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 28);
            this.label14.TabIndex = 23;
            this.label14.Text = "Unit of Masure";
            // 
            // TxtUnitPrice
            // 
            this.TxtUnitPrice.BackColor = System.Drawing.Color.White;
            this.TxtUnitPrice.ForeColor = System.Drawing.Color.Black;
            this.TxtUnitPrice.Location = new System.Drawing.Point(187, 176);
            this.TxtUnitPrice.Name = "TxtUnitPrice";
            this.TxtUnitPrice.ReadOnly = true;
            this.TxtUnitPrice.Size = new System.Drawing.Size(262, 31);
            this.TxtUnitPrice.TabIndex = 22;
            this.TxtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 28);
            this.label13.TabIndex = 21;
            this.label13.Text = "Unit Price";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(233, 28);
            this.label12.TabIndex = 20;
            this.label12.Text = "Selected Product Details";
            // 
            // TxtRemark
            // 
            this.TxtRemark.BackColor = System.Drawing.Color.White;
            this.TxtRemark.ForeColor = System.Drawing.Color.Black;
            this.TxtRemark.Location = new System.Drawing.Point(187, 385);
            this.TxtRemark.Name = "TxtRemark";
            this.TxtRemark.ReadOnly = true;
            this.TxtRemark.Size = new System.Drawing.Size(262, 31);
            this.TxtRemark.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 385);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 28);
            this.label8.TabIndex = 18;
            this.label8.Text = "Remark";
            // 
            // TxtExpiryDate
            // 
            this.TxtExpiryDate.BackColor = System.Drawing.Color.White;
            this.TxtExpiryDate.ForeColor = System.Drawing.Color.Black;
            this.TxtExpiryDate.Location = new System.Drawing.Point(187, 344);
            this.TxtExpiryDate.Name = "TxtExpiryDate";
            this.TxtExpiryDate.ReadOnly = true;
            this.TxtExpiryDate.Size = new System.Drawing.Size(262, 31);
            this.TxtExpiryDate.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 28);
            this.label7.TabIndex = 16;
            this.label7.Text = "Expiry Date";
            // 
            // TxtQunatity
            // 
            this.TxtQunatity.BackColor = System.Drawing.Color.White;
            this.TxtQunatity.ForeColor = System.Drawing.Color.Black;
            this.TxtQunatity.Location = new System.Drawing.Point(187, 303);
            this.TxtQunatity.Name = "TxtQunatity";
            this.TxtQunatity.ReadOnly = true;
            this.TxtQunatity.Size = new System.Drawing.Size(262, 31);
            this.TxtQunatity.TabIndex = 15;
            this.TxtQunatity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "Quantity";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 34);
            this.label9.TabIndex = 17;
            this.label9.Text = "Main Inverntory";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1388, 888);
            this.panel2.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 122);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1388, 759);
            this.panel4.TabIndex = 20;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ListViewProductInventory);
            this.splitContainer1.Size = new System.Drawing.Size(1388, 759);
            this.splitContainer1.SplitterDistance = 461;
            this.splitContainer1.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddStock);
            this.panel3.Controls.Add(this.txtSearchWord);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1388, 122);
            this.panel3.TabIndex = 19;
            // 
            // btnAddStock
            // 
            this.btnAddStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddStock.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStock.Location = new System.Drawing.Point(1250, 55);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(138, 40);
            this.btnAddStock.TabIndex = 18;
            this.btnAddStock.Text = "Add Stock";
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            // 
            // MainInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 894);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainInventory";
            this.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.Resize += new System.EventHandler(this.Inventory_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.ListView ListViewProductInventory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtProductCode;
        private System.Windows.Forms.TextBox TxtProductName;
        private System.Windows.Forms.TextBox TxtBarcode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader productCode;
        private System.Windows.Forms.ColumnHeader productName;
        private System.Windows.Forms.ColumnHeader recivedQuantity;
        private System.Windows.Forms.ColumnHeader lotExpioryDate;
        private System.Windows.Forms.ColumnHeader lotLocation;
        private System.Windows.Forms.TextBox TxtRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtExpiryDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtQunatity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtUnitPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtUnitOfMasure;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtTotalCurrentStock;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TxtTotalRetuens;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TxtTotalSale;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TxtTotalStock;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtStockLocation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblUnit4;
        private System.Windows.Forms.Label lblUnit3;
        private System.Windows.Forms.Label lblUnit2;
        private System.Windows.Forms.Label lblUnit1;
        private System.Windows.Forms.Button btnAddStock;
    }
}