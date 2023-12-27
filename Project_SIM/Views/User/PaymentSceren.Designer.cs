namespace Project_SIM.Views.User
{
    partial class PaymentSceren
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentSceren));
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewPayments = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentMethodID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTotalPaied = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalDeu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLoyaltyBalance = new System.Windows.Forms.TextBox();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPayAmount = new System.Windows.Forms.TextBox();
            this.txtChanage = new System.Windows.Forms.TextBox();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnCloseBill = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.chkBoxLoyaltyDiscount = new System.Windows.Forms.CheckBox();
            this.comBoxPayMethods = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblLoyaltyPointsEarnd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BackColor = System.Drawing.Color.White;
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.txtSubTotal.Location = new System.Drawing.Point(779, 74);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(244, 31);
            this.txtSubTotal.TabIndex = 3;
            this.txtSubTotal.TabStop = false;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(687, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sub Total";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.White;
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.txtDiscount.Location = new System.Drawing.Point(779, 125);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(244, 31);
            this.txtDiscount.TabIndex = 5;
            this.txtDiscount.TabStop = false;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(684, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Discounts";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTotal.Location = new System.Drawing.Point(779, 176);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(244, 31);
            this.txtTotal.TabIndex = 7;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(721, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total";
            // 
            // listViewPayments
            // 
            this.listViewPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.paymentMethodID,
            this.paymentMethod,
            this.amount});
            this.listViewPayments.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewPayments.FullRowSelect = true;
            this.listViewPayments.HideSelection = false;
            this.listViewPayments.Location = new System.Drawing.Point(14, 77);
            this.listViewPayments.Name = "listViewPayments";
            this.listViewPayments.Size = new System.Drawing.Size(618, 232);
            this.listViewPayments.TabIndex = 8;
            this.listViewPayments.UseCompatibleStateImageBehavior = false;
            this.listViewPayments.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#";
            // 
            // paymentMethodID
            // 
            this.paymentMethodID.Text = "ID";
            this.paymentMethodID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // paymentMethod
            // 
            this.paymentMethod.Text = "Payment Method";
            // 
            // amount
            // 
            this.amount.Text = "Amount";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPaied
            // 
            this.txtTotalPaied.BackColor = System.Drawing.Color.White;
            this.txtTotalPaied.Enabled = false;
            this.txtTotalPaied.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPaied.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtTotalPaied.Location = new System.Drawing.Point(779, 227);
            this.txtTotalPaied.Name = "txtTotalPaied";
            this.txtTotalPaied.ReadOnly = true;
            this.txtTotalPaied.Size = new System.Drawing.Size(244, 31);
            this.txtTotalPaied.TabIndex = 10;
            this.txtTotalPaied.TabStop = false;
            this.txtTotalPaied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(638, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total Payments";
            // 
            // txtTotalDeu
            // 
            this.txtTotalDeu.BackColor = System.Drawing.Color.White;
            this.txtTotalDeu.Enabled = false;
            this.txtTotalDeu.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDeu.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTotalDeu.Location = new System.Drawing.Point(779, 278);
            this.txtTotalDeu.Name = "txtTotalDeu";
            this.txtTotalDeu.ReadOnly = true;
            this.txtTotalDeu.Size = new System.Drawing.Size(244, 31);
            this.txtTotalDeu.TabIndex = 12;
            this.txtTotalDeu.TabStop = false;
            this.txtTotalDeu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(686, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "Total Deu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "Payment Method";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 416);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 28);
            this.label7.TabIndex = 15;
            this.label7.Text = "Loyalty Balance";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 471);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 28);
            this.label8.TabIndex = 16;
            this.label8.Text = "Card Number";
            // 
            // txtLoyaltyBalance
            // 
            this.txtLoyaltyBalance.BackColor = System.Drawing.Color.White;
            this.txtLoyaltyBalance.Enabled = false;
            this.txtLoyaltyBalance.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoyaltyBalance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLoyaltyBalance.Location = new System.Drawing.Point(163, 415);
            this.txtLoyaltyBalance.Name = "txtLoyaltyBalance";
            this.txtLoyaltyBalance.ReadOnly = true;
            this.txtLoyaltyBalance.Size = new System.Drawing.Size(244, 31);
            this.txtLoyaltyBalance.TabIndex = 3;
            this.txtLoyaltyBalance.TabStop = false;
            this.txtLoyaltyBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.BackColor = System.Drawing.Color.White;
            this.txtCardNumber.Enabled = false;
            this.txtCardNumber.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCardNumber.Location = new System.Drawing.Point(163, 470);
            this.txtCardNumber.MaxLength = 4;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.ReadOnly = true;
            this.txtCardNumber.Size = new System.Drawing.Size(244, 31);
            this.txtCardNumber.TabIndex = 4;
            this.txtCardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCardNumber.TextChanged += new System.EventHandler(this.txtCardNumber_TextChanged);
            this.txtCardNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNumber_KeyDown);
            this.txtCardNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardNumber_KeyPress);
            this.txtCardNumber.Leave += new System.EventHandler(this.txtCardNumber_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(505, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 28);
            this.label9.TabIndex = 19;
            this.label9.Text = "Amount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(502, 471);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 28);
            this.label10.TabIndex = 20;
            this.label10.Text = "Balance";
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.BackColor = System.Drawing.Color.White;
            this.txtPayAmount.Enabled = false;
            this.txtPayAmount.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayAmount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPayAmount.Location = new System.Drawing.Point(596, 416);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.ReadOnly = true;
            this.txtPayAmount.Size = new System.Drawing.Size(244, 31);
            this.txtPayAmount.TabIndex = 2;
            this.txtPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPayAmount_KeyDown);
            this.txtPayAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayAmount_KeyPress);
            // 
            // txtChanage
            // 
            this.txtChanage.BackColor = System.Drawing.Color.White;
            this.txtChanage.Enabled = false;
            this.txtChanage.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChanage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtChanage.Location = new System.Drawing.Point(596, 470);
            this.txtChanage.Name = "txtChanage";
            this.txtChanage.ReadOnly = true;
            this.txtChanage.Size = new System.Drawing.Size(244, 31);
            this.txtChanage.TabIndex = 22;
            this.txtChanage.TabStop = false;
            this.txtChanage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddPayment.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPayment.ForeColor = System.Drawing.Color.White;
            this.btnAddPayment.Location = new System.Drawing.Point(869, 389);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(154, 86);
            this.btnAddPayment.TabIndex = 23;
            this.btnAddPayment.Text = "Add Payment";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // btnCloseBill
            // 
            this.btnCloseBill.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCloseBill.Font = new System.Drawing.Font("Poppins", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseBill.ForeColor = System.Drawing.Color.White;
            this.btnCloseBill.Location = new System.Drawing.Point(869, 506);
            this.btnCloseBill.Name = "btnCloseBill";
            this.btnCloseBill.Size = new System.Drawing.Size(154, 86);
            this.btnCloseBill.TabIndex = 24;
            this.btnCloseBill.Text = "Close Bill";
            this.btnCloseBill.UseVisualStyleBackColor = false;
            this.btnCloseBill.Click += new System.EventHandler(this.btnCloseBill_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(103, 580);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 28);
            this.label11.TabIndex = 25;
            this.label11.Text = "User :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(60, 536);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 28);
            this.label12.TabIndex = 26;
            this.label12.Text = "Customer :";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.lblCustomer.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(163, 536);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(24, 28);
            this.lblCustomer.TabIndex = 27;
            this.lblCustomer.Text = "_";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.SystemColors.Control;
            this.lblUser.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(163, 580);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(24, 28);
            this.lblUser.TabIndex = 28;
            this.lblUser.Text = "_";
            // 
            // chkBoxLoyaltyDiscount
            // 
            this.chkBoxLoyaltyDiscount.AutoSize = true;
            this.chkBoxLoyaltyDiscount.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxLoyaltyDiscount.Location = new System.Drawing.Point(596, 358);
            this.chkBoxLoyaltyDiscount.Name = "chkBoxLoyaltyDiscount";
            this.chkBoxLoyaltyDiscount.Size = new System.Drawing.Size(160, 32);
            this.chkBoxLoyaltyDiscount.TabIndex = 3;
            this.chkBoxLoyaltyDiscount.Text = "Loaylty Discount";
            this.chkBoxLoyaltyDiscount.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chkBoxLoyaltyDiscount.UseVisualStyleBackColor = true;
            this.chkBoxLoyaltyDiscount.CheckedChanged += new System.EventHandler(this.chkBoxLoyaltyDiscount_CheckedChanged);
            // 
            // comBoxPayMethods
            // 
            this.comBoxPayMethods.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxPayMethods.FormattingEnabled = true;
            this.comBoxPayMethods.Location = new System.Drawing.Point(163, 354);
            this.comBoxPayMethods.Name = "comBoxPayMethods";
            this.comBoxPayMethods.Size = new System.Drawing.Size(244, 36);
            this.comBoxPayMethods.TabIndex = 2;
            this.comBoxPayMethods.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comBoxPayMethods_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(497, 522);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 28);
            this.label13.TabIndex = 29;
            this.label13.Text = "Change :";
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.BackColor = System.Drawing.SystemColors.Control;
            this.lblChange.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(589, 522);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(73, 42);
            this.lblChange.TabIndex = 30;
            this.lblChange.Text = "0.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(394, 578);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(186, 28);
            this.label14.TabIndex = 31;
            this.label14.Text = "Loyalty Points Earned :";
            // 
            // lblLoyaltyPointsEarnd
            // 
            this.lblLoyaltyPointsEarnd.AutoSize = true;
            this.lblLoyaltyPointsEarnd.BackColor = System.Drawing.SystemColors.Control;
            this.lblLoyaltyPointsEarnd.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoyaltyPointsEarnd.Location = new System.Drawing.Point(591, 578);
            this.lblLoyaltyPointsEarnd.Name = "lblLoyaltyPointsEarnd";
            this.lblLoyaltyPointsEarnd.Size = new System.Drawing.Size(47, 28);
            this.lblLoyaltyPointsEarnd.TabIndex = 32;
            this.lblLoyaltyPointsEarnd.Text = "0.00";
            // 
            // PaymentSceren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 641);
            this.Controls.Add(this.lblLoyaltyPointsEarnd);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comBoxPayMethods);
            this.Controls.Add(this.chkBoxLoyaltyDiscount);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCloseBill);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.txtChanage);
            this.Controls.Add(this.txtPayAmount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.txtLoyaltyBalance);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalDeu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalPaied);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listViewPayments);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1052, 641);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1052, 641);
            this.Name = "PaymentSceren";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.PaymentSceren_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PaymentSceren_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewPayments;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader paymentMethod;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.TextBox txtTotalPaied;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalDeu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLoyaltyBalance;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.TextBox txtChanage;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnCloseBill;
        private System.Windows.Forms.ColumnHeader paymentMethodID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.CheckBox chkBoxLoyaltyDiscount;
        private System.Windows.Forms.ComboBox comBoxPayMethods;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblLoyaltyPointsEarnd;
    }
}