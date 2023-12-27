using MaterialSkin.Controls;
using Project_SIM.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Project_SIM.Models.SimCustomer;
using Windows.System;

namespace Project_SIM.Views.User
{
    public partial class PaymentSceren : MaterialForm
    {
        public decimal subTotal;
        public SimUser.UserData loggedUserData;
        public SimCustomer.Customer customerData;
        public List<BillItem> bill;

        
        private decimal total = 0;
        private decimal discount = 0;
        private decimal deuAmount = 0;
        private decimal totalPaidAmount = 0;
        private decimal totalChange = 0;

        private int loyaltyPresentage = 0;
        private decimal earnedLoyaltyPoints=0;
        private bool isLoyaltyDiscount = false;
        private double[] coloumRatios = { 0.05,0.05,0.3,0.4 };
        private int currentItem = 1;

        private SimBill billClass;
        private List<PaymentMethod> paymentMethods;
        private List<Payments> payments;
        public PaymentSceren()
        {
            InitializeComponent();
            billClass = new SimBill();
            paymentMethods = billClass.GetPaymentMethods();
            payments = new List<Payments>();

            FormatMaker.SetupListViewColumns(listViewPayments, coloumRatios);
            txtSubTotal.Text = subTotal.ToString("0.00");
            txtDiscount.Text = discount.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
            chkBoxLoyaltyDiscount.Checked = false;
            SetPaymentMethods();
            SetLoyaltyPresentage();

        }

        private void PaymentSceren_Load(object sender, EventArgs e)
        {
            SetData();
            lblCustomer.Text = customerData.FullName;
            lblUser.Text = loggedUserData.FullName;
            if (customerData.CustomerID != 1)
            {
                txtLoyaltyBalance.Text = customerData.LoyaltyPoints.ToString("0.00");
                CalLoyaltyPoints();
                lblLoyaltyPointsEarnd.Text = earnedLoyaltyPoints.ToString("0.00");
            }
            else
            {
                txtLoyaltyBalance.Text = "0.00";
            }

        }
        

        private void PaymentSceren_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void txtPayAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddPayment.Focus();
            }
        }
        private void txtCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPayAmount.Focus();
            }
        }
        private void comBoxPayMethods_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnableDetailsFeild(comBoxPayMethods.SelectedItem.ToString());
            }
        }
        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, backspace, and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtPayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, backspace, and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void txtCardNumber_Leave(object sender, EventArgs e)
        {
            if (txtCardNumber.Text.Length != 4)
            {
                FormatMaker.ShowErrorMessageBox("Please enter exactly 4 characters in the card number.");
                txtCardNumber.Focus();
            }
        }
        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNumber.Text.Length == 4)
            {
                txtPayAmount.Focus();
            }
        }
        private void chkBoxLoyaltyDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxLoyaltyDiscount.Checked)
            {
                isLoyaltyDiscount = true;
                SetData(true);
            }
            else
            {
                isLoyaltyDiscount = false;
                SetData(false);
            }


        }
        

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            bool result = true;
            chkBoxLoyaltyDiscount.Enabled = false;

            if (comBoxPayMethods.SelectedItem.ToString() == "Loyalty Points")
            {
                result = LoyaltyPayment();
            }
            if (comBoxPayMethods.SelectedItem.ToString() == "Card")
            {
                result = CardPayment();
            }

            if (result)
            {
                AddPayment();
                AddToListView();
            }

        }
        private void btnCloseBill_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Create Transaction
                bool result_transaction = billClass.CreateTransaction(loggedUserData.UserID.ToString(), customerData.CustomerID.ToString(), total, discount, totalPaidAmount, totalChange);

                // Step 2: Create Transaction Payments
                bool result_payments = billClass.CreateTransactionPayments(payments, customerData.LoyaltyNumber);


                // Step 3: Create Transaction Details
                bool result_transactionDetails = billClass.CreateTransactionDetails(bill);

                bool result_loyaltyPoints = true;

                if (customerData.CustomerID != 1) {
                    result_loyaltyPoints = billClass.AddLoyalyaltyPoints(customerData.LoyaltyNumber, earnedLoyaltyPoints.ToString("0.00"));
                }

                // If all steps are successful, get the created bill number and transaction ID
                if (result_transaction && result_payments && result_transactionDetails && result_loyaltyPoints)
                {
                    string savedBillNumber = billClass.GetCreatedBillNumber();
                    string savedTransactionId = billClass.GetInsertedTransactionId();

                    // Optionally, inform the user about the overall success
                    MessageBox.Show($"Bill closed successfully!\nBill Number: {savedBillNumber}\nTransaction ID: {savedTransactionId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Some steps failed. Bill closure unsuccessful.");
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                FormatMaker.ShowErrorMessageBox($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SetLoyaltyPresentage(int presentage = 10)
        {
            loyaltyPresentage = presentage;
        }
        private void CalLoyaltyPoints()
        {
            earnedLoyaltyPoints = (total * loyaltyPresentage) / 1000;
        }
        private bool LoyaltyPayment()
        {
            if (customerData.LoyaltyPoints == 0)
            {
                FormatMaker.ShowErrorMessageBox("Balance is not Enough for the payments");
                comBoxPayMethods.Focus();
                return false;
            }
            if (Decimal.Parse(customerData.LoyaltyPoints.ToString()) < Decimal.Parse(txtPayAmount.Text.ToString()))
            {
                FormatMaker.ShowErrorMessageBox($"Maximum Payment can be done is :{customerData.LoyaltyPoints.ToString("0.00")}");
                txtPayAmount.Focus();
                return false;
            }

            return true;

        }
        
        private bool CardPayment()
        {
            if (Decimal.Parse(txtPayAmount.Text) > deuAmount)
            {
                FormatMaker.ShowErrorMessageBox("Can Not Pay more than Deu Amount from Card Payment");
                txtPayAmount.Focus();
                return false;
            }
            return true;
        }
        
        private void AddPayment()
        {
            decimal amountpaid = Decimal.Parse(txtPayAmount.Text);
            SetDeuAmount(amountpaid);
            string selectedPaymentMethod = comBoxPayMethods.SelectedItem.ToString();
            int paymentMethodId = 0;

            foreach (PaymentMethod paymentMethod in paymentMethods)
            {
                if (paymentMethod.Name == selectedPaymentMethod)
                {
                    paymentMethodId = paymentMethod.ID;
                    break;
                }
            }
            Payments payment = new Payments
            {
                PaymentMethodID = paymentMethodId,
                PaidAmount = amountpaid.ToString("0.00"),
                Remark = selectedPaymentMethod.ToString() + " " + txtCardNumber.Text,
            };
            payments.Add(payment);

        }
        private void SetDeuAmount(decimal paidAmount = 0)
        {
            discount = 0;
            if (isLoyaltyDiscount)
            {
                discount = (subTotal * loyaltyPresentage) / 100;
            }

            total = subTotal - discount;
            totalPaidAmount += paidAmount;
            deuAmount = total - totalPaidAmount;

            txtChanage.Text = 0.ToString("0.00");

            if (deuAmount > 0)
            {
                btnCloseBill.Enabled = false;
            }

            if (deuAmount <= 0)
            {
                totalChange = (deuAmount * -1);
                txtChanage.Text = totalChange.ToString("0.00");
                lblChange.Text = totalChange.ToString("0.00");
                deuAmount = 0;
            }
            if (deuAmount == 0)
            {
                btnAddPayment.Enabled = false;
                comBoxPayMethods.Enabled = false;
                btnCloseBill.Enabled = true;
                btnCloseBill.Focus();
            }
            
            

        }
        private void SetData(bool manualDiscount=false)
        {   if (manualDiscount)
            {
                if (customerData.CustomerID != 1)
                {
                    chkBoxLoyaltyDiscount.Checked = true;
                    isLoyaltyDiscount = true;
                    txtLoyaltyBalance.Text = customerData.LoyaltyPoints.ToString("0.00");
                    CalLoyaltyPoints();
                    lblLoyaltyPointsEarnd.Text = earnedLoyaltyPoints.ToString("0.00");
                }
            }
            
            SetDeuAmount();
            txtSubTotal.Text = subTotal.ToString("0.00");
            txtDiscount.Text = discount.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
            txtTotalDeu.Text = deuAmount.ToString("0.00");
            txtTotalPaied.Text = totalPaidAmount.ToString("0.00");
        }
        private void UpdateData()
        {
            txtSubTotal.Text = subTotal.ToString("0.00");
            txtDiscount.Text = discount.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
            txtTotalDeu.Text = deuAmount.ToString("0.00");
            txtTotalPaied.Text = totalPaidAmount.ToString("0.00");
        }
        private void SetPaymentMethods()
        {
            foreach (PaymentMethod paymentMethod in paymentMethods)
            {
                comBoxPayMethods.Items.Add(paymentMethod.Name.ToString());
            }
        }
        private void EnableDetailsFeild(string choosenPaymentMethod)
        {
            if (choosenPaymentMethod == "Cash")
            {
                txtPayAmount.ReadOnly = false;
                txtPayAmount.Enabled = true;

                txtCardNumber.ReadOnly = true;
                txtCardNumber.Enabled = false;

                txtPayAmount.Focus();
            }
            if (choosenPaymentMethod == "Card")
            {
                txtPayAmount.ReadOnly = false;
                txtPayAmount.Enabled = true;
                txtCardNumber.ReadOnly = false;
                txtCardNumber.Enabled = true;
                txtCardNumber.Focus();
            }
            if (choosenPaymentMethod == "Loyalty Points")
            {
                if (customerData.CustomerID != 1)
                {
                    txtPayAmount.ReadOnly = false;
                    txtPayAmount.Enabled = true;

                    txtCardNumber.ReadOnly = true;
                    txtCardNumber.Enabled = false;

                    txtPayAmount.Focus();

                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Can not pay with Loyalty points for this Customer");
                    comBoxPayMethods.Focus();
                }

            }
        }
        private void AddToListView()
        {
            ListViewItem newItem = new ListViewItem(currentItem.ToString());

            newItem.SubItems.Add(payments[currentItem-1].PaymentMethodID.ToString());
            newItem.SubItems.Add(payments[currentItem - 1].Remark);
            newItem.SubItems.Add(payments[currentItem - 1].PaidAmount);
            listViewPayments.Items.Add(newItem);

            comBoxPayMethods.Focus();
            // Increment the counter for the next item
            currentItem++;
            UpdateData();

            txtPayAmount.ReadOnly = true;
            txtPayAmount.Enabled = false;
            txtPayAmount.Text = string.Empty;

            txtCardNumber.ReadOnly = true;
            txtCardNumber.Enabled = false;
            txtCardNumber.Text = string.Empty;
        }

        
    }
}
