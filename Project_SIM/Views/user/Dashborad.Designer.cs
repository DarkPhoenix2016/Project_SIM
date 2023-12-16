namespace Project_SIM.Views.user
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
            this.listViewBill = new System.Windows.Forms.ListView();
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.btnReturnItem = new System.Windows.Forms.Button();
            this.btnViewInventory = new System.Windows.Forms.Button();
            this.btnViewCustomer = new System.Windows.Forms.Button();
            this.btnRegCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnEditQuantity = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBoxBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxUnitPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBoxSubTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxTotal = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewBill
            // 
            this.listViewBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.number,
            this.itemCode,
            this.name,
            this.price,
            this.quantity,
            this.amount});
            this.listViewBill.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBill.FullRowSelect = true;
            this.listViewBill.HideSelection = false;
            this.listViewBill.Location = new System.Drawing.Point(11, 144);
            this.listViewBill.MinimumSize = new System.Drawing.Size(853, 433);
            this.listViewBill.Name = "listViewBill";
            this.listViewBill.Size = new System.Drawing.Size(853, 433);
            this.listViewBill.TabIndex = 0;
            this.listViewBill.UseCompatibleStateImageBehavior = false;
            this.listViewBill.View = System.Windows.Forms.View.Details;
            // 
            // number
            // 
            this.number.Text = "#";
            this.number.Width = 50;
            // 
            // itemCode
            // 
            this.itemCode.Text = "Code";
            this.itemCode.Width = 200;
            // 
            // name
            // 
            this.name.Text = "Item";
            this.name.Width = 48;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.price.Width = 200;
            // 
            // quantity
            // 
            this.quantity.Text = "Quantity";
            this.quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.quantity.Width = 200;
            // 
            // amount
            // 
            this.amount.Text = "Amount";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount.Width = 156;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.materialDivider2);
            this.panel1.Controls.Add(this.materialDivider1);
            this.panel1.Controls.Add(this.btnReturnItem);
            this.panel1.Controls.Add(this.btnViewInventory);
            this.panel1.Controls.Add(this.btnViewCustomer);
            this.panel1.Controls.Add(this.btnRegCustomer);
            this.panel1.Controls.Add(this.btnAddCustomer);
            this.panel1.Controls.Add(this.btnDeleteItem);
            this.panel1.Controls.Add(this.btnEditQuantity);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(880, 144);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 433);
            this.panel1.TabIndex = 1;
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(5, 215);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(370, 5);
            this.materialDivider2.TabIndex = 8;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(3, 102);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(370, 5);
            this.materialDivider1.TabIndex = 7;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // btnReturnItem
            // 
            this.btnReturnItem.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnItem.Location = new System.Drawing.Point(129, 226);
            this.btnReturnItem.Name = "btnReturnItem";
            this.btnReturnItem.Size = new System.Drawing.Size(120, 96);
            this.btnReturnItem.TabIndex = 11;
            this.btnReturnItem.Text = "Return Item";
            this.btnReturnItem.UseVisualStyleBackColor = true;
            this.btnReturnItem.Click += new System.EventHandler(this.btnReturnItem_Click);
            // 
            // btnViewInventory
            // 
            this.btnViewInventory.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInventory.Location = new System.Drawing.Point(3, 226);
            this.btnViewInventory.Name = "btnViewInventory";
            this.btnViewInventory.Size = new System.Drawing.Size(120, 96);
            this.btnViewInventory.TabIndex = 10;
            this.btnViewInventory.Text = "View Inventory";
            this.btnViewInventory.UseVisualStyleBackColor = true;
            this.btnViewInventory.Click += new System.EventHandler(this.btnViewInventory_Click);
            // 
            // btnViewCustomer
            // 
            this.btnViewCustomer.Enabled = false;
            this.btnViewCustomer.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCustomer.Location = new System.Drawing.Point(255, 113);
            this.btnViewCustomer.Name = "btnViewCustomer";
            this.btnViewCustomer.Size = new System.Drawing.Size(120, 96);
            this.btnViewCustomer.TabIndex = 9;
            this.btnViewCustomer.Text = "View Customer";
            this.btnViewCustomer.UseVisualStyleBackColor = true;
            this.btnViewCustomer.Click += new System.EventHandler(this.btnViewCustomer_Click);
            // 
            // btnRegCustomer
            // 
            this.btnRegCustomer.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegCustomer.Location = new System.Drawing.Point(129, 113);
            this.btnRegCustomer.Name = "btnRegCustomer";
            this.btnRegCustomer.Size = new System.Drawing.Size(120, 96);
            this.btnRegCustomer.TabIndex = 8;
            this.btnRegCustomer.Text = "New Customer";
            this.btnRegCustomer.Click += new System.EventHandler(this.btnRegCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.Location = new System.Drawing.Point(3, 113);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(120, 96);
            this.btnAddCustomer.TabIndex = 7;
            this.btnAddCustomer.Text = "Loyalty Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.Location = new System.Drawing.Point(255, 0);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(120, 96);
            this.btnDeleteItem.TabIndex = 6;
            this.btnDeleteItem.Text = "Delete Item (Del)";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.BtnDeleteItem_Click);
            // 
            // btnEditQuantity
            // 
            this.btnEditQuantity.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditQuantity.Location = new System.Drawing.Point(129, 0);
            this.btnEditQuantity.Name = "btnEditQuantity";
            this.btnEditQuantity.Size = new System.Drawing.Size(120, 96);
            this.btnEditQuantity.TabIndex = 5;
            this.btnEditQuantity.Text = "Edit Quantity (F2)";
            this.btnEditQuantity.UseVisualStyleBackColor = true;
            this.btnEditQuantity.Click += new System.EventHandler(this.BtnEditQuantity_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 96);
            this.button1.TabIndex = 4;
            this.button1.Text = "Edit Price (F1)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnEditPrice);
            // 
            // txtBoxBarcode
            // 
            this.txtBoxBarcode.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBarcode.Location = new System.Drawing.Point(60, 91);
            this.txtBoxBarcode.Name = "txtBoxBarcode";
            this.txtBoxBarcode.Size = new System.Drawing.Size(311, 31);
            this.txtBoxBarcode.TabIndex = 1;
            this.txtBoxBarcode.Text = "Scan Barcode or Item Code";
            this.txtBoxBarcode.Click += new System.EventHandler(this.Barcode_Enter);
            this.txtBoxBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Barcode_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(377, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Unit Price";
            // 
            // txtBoxUnitPrice
            // 
            this.txtBoxUnitPrice.BackColor = System.Drawing.Color.White;
            this.txtBoxUnitPrice.Cursor = System.Windows.Forms.Cursors.No;
            this.txtBoxUnitPrice.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUnitPrice.Location = new System.Drawing.Point(469, 91);
            this.txtBoxUnitPrice.Name = "txtBoxUnitPrice";
            this.txtBoxUnitPrice.ReadOnly = true;
            this.txtBoxUnitPrice.Size = new System.Drawing.Size(167, 31);
            this.txtBoxUnitPrice.TabIndex = 2;
            this.txtBoxUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBoxUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UnitPrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(642, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Quantity";
            // 
            // txtBoxQuantity
            // 
            this.txtBoxQuantity.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtBoxQuantity.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxQuantity.Location = new System.Drawing.Point(729, 91);
            this.txtBoxQuantity.Name = "txtBoxQuantity";
            this.txtBoxQuantity.ReadOnly = true;
            this.txtBoxQuantity.Size = new System.Drawing.Size(139, 31);
            this.txtBoxQuantity.TabIndex = 3;
            this.txtBoxQuantity.UseWaitCursor = true;
            this.txtBoxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Quantity_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Loyalty Number";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox4.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(159, 14);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(265, 31);
            this.textBox4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Customer Name";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(159, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "F Name L Name";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 28);
            this.label7.TabIndex = 12;
            this.label7.Text = "Point Balance";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(159, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 34);
            this.label8.TabIndex = 13;
            this.label8.Text = "0";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtBoxSubTotal);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Location = new System.Drawing.Point(10, 589);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 141);
            this.panel2.TabIndex = 14;
            // 
            // txtBoxSubTotal
            // 
            this.txtBoxSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSubTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.txtBoxSubTotal.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSubTotal.Location = new System.Drawing.Point(588, 14);
            this.txtBoxSubTotal.Name = "txtBoxSubTotal";
            this.txtBoxSubTotal.ReadOnly = true;
            this.txtBoxSubTotal.Size = new System.Drawing.Size(252, 31);
            this.txtBoxSubTotal.TabIndex = 15;
            this.txtBoxSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(494, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 28);
            this.label10.TabIndex = 14;
            this.label10.Text = "Sub Total";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(1168, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 48);
            this.label9.TabIndex = 14;
            this.label9.Text = "Total";
            // 
            // txtBoxTotal
            // 
            this.txtBoxTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtBoxTotal.Cursor = System.Windows.Forms.Cursors.No;
            this.txtBoxTotal.Font = new System.Drawing.Font("Poppins", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtBoxTotal.Location = new System.Drawing.Point(880, 84);
            this.txtBoxTotal.Name = "txtBoxTotal";
            this.txtBoxTotal.ReadOnly = true;
            this.txtBoxTotal.Size = new System.Drawing.Size(282, 47);
            this.txtBoxTotal.TabIndex = 15;
            this.txtBoxTotal.Text = "0.00";
            this.txtBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.AutoSize = true;
            this.button9.BackColor = System.Drawing.Color.Green;
            this.button9.Font = new System.Drawing.Font("Poppins SemiBold", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(880, 589);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(375, 141);
            this.button9.TabIndex = 12;
            this.button9.Text = "Pay";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // Dashborad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 760);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.txtBoxTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxUnitPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxBarcode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewBill);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1260, 760);
            this.Name = "Dashborad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.ResizeEnd += new System.EventHandler(this.SimUserScreen_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.Resize += new System.EventHandler(this.SimUserScreen_Resize);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewBill;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader quantity;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnEditQuantity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBoxBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxUnitPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxTotal;
        private System.Windows.Forms.Button btnViewCustomer;
        private System.Windows.Forms.Button btnRegCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnReturnItem;
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button button9;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.TextBox txtBoxSubTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader itemCode;
    }
}