using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using Project_SIM.Models;
using Project_SIM.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using ZXing;
using static Project_SIM.Models.SimProduct;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Project_SIM.Views.User
{
    public partial class Dashborad : MaterialForm
    {
        private BarcodeReader barcodeReader;

        private int currentItem = 1;
        private string productCodeEdit = string.Empty;
        private int editPosition = -1;
        private double[] coloumRatios = { 0.05, 0.10, 0.30, 0.10, 0.10,0.10, 0.24 };
        private string sessionID = string.Empty;
        private bool isClosing = false;
        public static string SelectedItemFromInvetory;

        private Customer.RegCustomer regForm;
        private Customer.ViewDetails viewCusDataForm;
        private InventoryList inverntoryList;
        private PaymentSceren payScreen;
        private ReturnScreen returnScreen;
        
        private UserInfo currentUser;
        private SimUser simUserClass;
        private SimUser.UserData loggedUserData;
        private SimCustomer simCustomerClass;
        private SimCustomer.Customer CustomerData;
        private SimProduct simProduct = new SimProduct();
        private List<BillItem> bill;
        


        public Dashborad()
        {
            InitializeComponent();

            regForm = new Customer.RegCustomer();
            simCustomerClass = new SimCustomer();
            simUserClass = new SimUser();
            

            barcodeReader = new BarcodeReader(); // Initialize the barcode reader

            FormatMaker.SetupListViewColumns(listViewBill, coloumRatios);
            txtBoxBarcode.Focus();

            bill = new List<BillItem>();

            loyaltyName.Text = string.Empty;
            loyaltyPointBalance.Text = string.Empty;

            CustomerData = simCustomerClass.Select("0000000000");

            lblCurrentCustomer.Text = CustomerData.FullName.ToString();


        }


        public void SetSession(string session)
        {
            sessionID = session.Trim();
            currentUser = SessionManager.GetUserInfo(sessionID);
            loggedUserData = simUserClass.Select(currentUser.Username.ToString(), currentUser.Designation.ToString());
            lblFullName.Text = loggedUserData.FullName + "(" + loggedUserData.Username + ")";

            if(currentUser.Designation == "Manager")
            {
                btnManagerDashborad.Visible = true;
            }
            else
            {
                btnManagerDashborad.Visible = false;
            }

        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                EditUnitPrice_Imideate(); 
            }
            else if (e.KeyCode == Keys.F2)
            {
                ClearOutCurrentBillData();
            }
            else if (e.KeyCode == Keys.F3)
            {
                EditQuntity();
            }
            else if (e.KeyCode == Keys.F6)
            {
                txtBoxLoyalty.Enabled = true;
                txtBoxLoyalty.ReadOnly = false;
                txtBoxLoyalty.Focus();
            }
            else if (e.KeyCode == Keys.F7)
            {
                RegisterNewCustomer();
            }
            else if (e.KeyCode == Keys.F8)
            {
                ViewCustomerData();
            }
            else if (e.KeyCode == Keys.F9)
            {
                LoadInventoryData();
            }
            else if (e.KeyCode == Keys.F10)
            {
                LoadReturnItem();
            }
            else if (e.KeyCode == Keys.F11)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.TopMost = true;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.TopMost = false;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                }
            }
            else if((e.KeyCode == Keys.F12))
            {
                LoadPayment();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                RemoveItemListView();
            }else
            {
                e.Handled = true;
            }
        }

        private void SimUserScreen_Resize(object sender, EventArgs e)
        {
            // Adjust column widths when the form is resized

            FormatMaker.SetupListViewColumns(listViewBill, coloumRatios);
        }

        private void Dashborad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                // Handle other closing scenarios, e.g., logout button
                DialogResult result = MessageBox.Show("Are you sure you want to Exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // If the user confirms logout, close the dashboard form
                    isClosing = true;
                    e.Cancel = false;
                    // The X button was clicked, close the entire application
                    Application.Exit();
                }
                else
                {
                    // If the user cancels logout, prevent the dashboard form from closing
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Call the common method to handle session ending and application closing
            HandleLogout();
        }

        private void HandleLogout()
        {
            // Prompt the user with a yes/no question
            DialogResult result = MessageBox.Show("Are you sure you want to Logout?", "Confirm log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // If the user clicks "Yes," end the session
                SessionManager.EndSession(sessionID);

                // Close the current form (Dashboard) and open the login screen
                OpenScreen openScreen = new OpenScreen();
                openScreen.Show();
                isClosing = true;
                this.Close();
            }
        }

        private void Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBoxBarcode.Text))
                {
                    AddToBill();
                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Barcode or Item Code cannot be empty");
                    txtBoxBarcode.Focus();
                }
            }
        }
        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBoxQuantity.Text))
                {
                    if (!(Convert.ToDouble(txtBoxQuantity.Text) == 0))
                    {

                        if (editPosition > -1)
                        {
                            CalculateItemTotal(editPosition);
                            AddToListView(editPosition);
                        }
                        else
                        {
                            CalculateItemTotal();
                            AddToListView();
                        }

                    }
                    else
                    {
                        FormatMaker.ShowErrorMessageBox("Quantity can not be Zero");
                        txtBoxQuantity.Text = "";
                        txtBoxQuantity.Focus();
                    }

                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Quantity can not be Empty");
                    txtBoxQuantity.Focus();
                }
            }

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
        private void UnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBoxUnitPrice.Text))
                {
                    if (!(Convert.ToDouble(txtBoxUnitPrice.Text) == 0))
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to change the unit Price?", "Unit Price Change", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            bill[currentItem - 1].UnitPrice = Convert.ToDouble(txtBoxUnitPrice.Text);
                            FormatMaker.BlockOutTextFeild(txtBoxUnitPrice);
                            txtBoxQuantity.Focus();
                            FormatMaker.EnableTextFeild(txtBoxQuantity);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            txtBoxUnitPrice.Text = bill[currentItem - 1].UnitPrice.ToString("0.00");
                            FormatMaker.BlockOutTextFeild(txtBoxUnitPrice);
                            txtBoxQuantity.Focus();
                            FormatMaker.EnableTextFeild(txtBoxQuantity);
                        }
                    }
                    else
                    {
                        FormatMaker.ShowErrorMessageBox("Unit Price can not be Zero");
                        txtBoxUnitPrice.Text = "";
                        txtBoxUnitPrice.Focus();
                    }

                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Unit Price can not be Empty");
                    txtBoxUnitPrice.Text = "";
                    txtBoxUnitPrice.Focus();
                }
            }

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
        private void LoyaltyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // When Press Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBoxLoyalty.Text))
                {
                    LoadCustomerData(txtBoxLoyalty.Text.Trim());
                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Loyalty Numebr can not be Empty");
                    txtBoxLoyalty.Focus();
                }
            }
            // Allow only numbers, backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


        }


        private void Barcode_Enter(object sender, EventArgs e)
        {
            txtBoxBarcode.Focus();
            txtBoxBarcode.Text = "";
        }


        private void BtnEditPrice_Click(object sender, EventArgs e)
        {
            EditUnitPrice_Imideate();
        }
        private void BtnEditQuantity_Click(object sender, EventArgs e)
        {
            EditQuntity();
        }
        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            RemoveItemListView();
        }
        private void BtnReturnItem_Click(object sender, EventArgs e)
        {
            LoadReturnItem();
        }

        private void BtnRegCustomer_Click(object sender, EventArgs e)
        {
            RegisterNewCustomer();
        }
        private void BtnViewCustomer_Click(object sender, EventArgs e)
        {
            ViewCustomerData();
        }
        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            txtBoxLoyalty.Enabled = true;
            txtBoxLoyalty.ReadOnly = false;
            txtBoxLoyalty.Focus();
        }
        private void BtnViewInventory_Click(object sender, EventArgs e)
        {
            LoadInventoryData();
        }
        private void BtnPayment_Click(object sender, EventArgs e)
        {
            LoadPayment();
        }

        private void AddToBill()
        {
            string barcode = txtBoxBarcode.Text.Trim();

            if (string.IsNullOrEmpty(barcode))
            {
                FormatMaker.ShowErrorMessageBox("Barcode cannot be empty");
                txtBoxBarcode.Focus();
                return;
            }

            SimProductData productData = simProduct.GetProductByCodeOrBarcode(barcode);

            if (productData != null)
            {
                BillItem currentBillItem = new BillItem()
                {
                    Number = currentItem,
                    ProductID = productData.ProductID,
                    ProductCode = productData.ProductCode,
                    ProductName = productData.Name,
                    UnitPrice = Convert.ToDouble(productData.Price),
                    Unit = productData.Unit
                };

                txtBoxBarcode.Text = currentBillItem.ProductName;
                bill.Add(currentBillItem);

                txtBoxUnitPrice.Text = currentBillItem.UnitPrice.ToString("0.00");
                txtBoxQuantity.Focus();
                FormatMaker.EnableTextFeild(txtBoxQuantity);
            }
            else
            {
                FormatMaker.ShowErrorMessageBox("Product not found");
                txtBoxBarcode.Focus();
                txtBoxBarcode.Text = string.Empty;
            }
        }
        private void AddToBill(String ProductCode)
        {
            string barcode = ProductCode.Trim();
            FormatMaker.BlockOutTextFeild(txtBoxBarcode);

            if (!string.IsNullOrEmpty(barcode))
            {
                SimProductData productData = simProduct.GetProductByCodeOrBarcode(barcode);

                if (productData != null)
                {

                    // Declare currentBillItem outside the loop
                    BillItem currentBillItem = new BillItem();

                    currentBillItem.Number = editPosition + 1;
                    currentBillItem.ProductID = productData.ProductID;
                    currentBillItem.ProductCode = productData.ProductCode;
                    currentBillItem.ProductName = productData.Name;
                    currentBillItem.UnitPrice = Convert.ToDouble(productData.Price);
                    currentBillItem.Unit = productData.Unit;

                    txtBoxBarcode.Text = currentBillItem.ProductName;
                    // Add the currentBillItem to the bill list
                    bill.Insert(editPosition, currentBillItem);

                    // Set the unit price in the textbox and set focus
                    txtBoxUnitPrice.Text = currentBillItem.UnitPrice.ToString("0.00");
                    txtBoxQuantity.Focus();
                    FormatMaker.EnableTextFeild(txtBoxQuantity);

                }
            }


        }

        private void AddToListView()
        {
            ListViewItem newItem = new ListViewItem(currentItem.ToString());

            newItem.SubItems.Add(bill[currentItem - 1].ProductCode);
            newItem.SubItems.Add(bill[currentItem - 1].ProductName);
            newItem.SubItems.Add(bill[currentItem - 1].UnitPrice.ToString("0.00"));
            newItem.SubItems.Add(bill[currentItem - 1].Quantity.ToString("0.000"));
            newItem.SubItems.Add(bill[currentItem - 1].Unit);
            newItem.SubItems.Add(bill[currentItem - 1].Price.ToString("0.00"));
            listViewBill.Items.Add(newItem);

            // Clear the textboxes for the next entry
            txtBoxBarcode.Text = string.Empty;
            txtBoxUnitPrice.Text = string.Empty;
            txtBoxQuantity.Text = string.Empty;

            // Increment the counter for the next item
            currentItem++;

            // Set focus back to textBoxBarcode
            FormatMaker.BlockOutTextFeild(txtBoxQuantity);
            txtBoxBarcode.Focus();

            UpdateSubTotal();
            UpdateTotal();
        }
        private void AddToListView(int ItemIndex)
        {
            listViewBill.Items[ItemIndex].SubItems[0].Text = bill[ItemIndex].Number.ToString();
            listViewBill.Items[ItemIndex].SubItems[1].Text = bill[ItemIndex].ProductCode.ToString();
            listViewBill.Items[ItemIndex].SubItems[2].Text = bill[ItemIndex].ProductName.ToString();
            listViewBill.Items[ItemIndex].SubItems[3].Text = bill[ItemIndex].UnitPrice.ToString("0.00");
            listViewBill.Items[ItemIndex].SubItems[4].Text = bill[ItemIndex].Quantity.ToString("0.000");
            listViewBill.Items[ItemIndex].SubItems[5].Text = bill[ItemIndex].Unit;
            listViewBill.Items[ItemIndex].SubItems[6].Text = bill[ItemIndex].Price.ToString("0.00");

            // Clear the textboxes for the next entry
            txtBoxBarcode.Text = string.Empty;
            txtBoxUnitPrice.Text = string.Empty;
            txtBoxQuantity.Text = string.Empty;

            // Set focus back to textBoxBarcode
            FormatMaker.BlockOutTextFeild(txtBoxQuantity);
            txtBoxBarcode.Focus();
            FormatMaker.EnableTextFeild(txtBoxBarcode);

            UpdateSubTotal();
            UpdateTotal();

            editPosition = -1;

        }

        private void RemoveItemListView()
        {
            if (!(listViewBill.Items.Count <= 0))
            {
                if ((listViewBill.SelectedItems.Count > 0))
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Delete the Selcted Item?", "Item Delete", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Item selected, retrieve index
                        int selectedIndex = Convert.ToInt32(listViewBill.SelectedItems[0].Text);
                        // Remove the item from the ListView
                        listViewBill.Items.RemoveAt(selectedIndex - 1);
                        // Remove the item from the structure
                        bill.RemoveAt(selectedIndex - 1);
                        currentItem--;

                        UpdateSubTotal();
                        UpdateTotal();

                        // Reorder bill items and update ListView
                        ReorderBillItems();
                    }

                }
                else
                {
                    // No item selected, show dialog
                    FormatMaker.ShowErrorMessageBox("Please select an item from the list.");
                    listViewBill.Items[0].Selected = true;
                    listViewBill.SelectedItems[0].Focused = true;

                }
            }
            else
            {
                FormatMaker.ShowErrorMessageBox("Please Add at least one Item to the Bill");
                txtBoxBarcode.Focus();
            }
        }



        private void UpdateSubTotal()
        {
            double subTotal = 0;

            foreach (ListViewItem item in listViewBill.Items)
            {
                if (double.TryParse(item.SubItems[6].Text, out double amount))
                {
                    subTotal += amount;
                }
            }

            txtBoxSubTotal.Text = subTotal.ToString("0.00");
        }
        private void UpdateTotal()
        {
            double subTotal = Convert.ToDouble(txtBoxSubTotal.Text);

            txtBoxTotal.Text = subTotal.ToString("0.00");
        }
        private void ReorderBillItems()
        {
            for (int i = 1; i <= bill.Count; i++)
            {
                bill[i - 1].Number = i;
                listViewBill.Items[i - 1].SubItems[0].Text = i.ToString();
            }
        }

        private void CalculateItemTotal()
        {
            double quantity = Convert.ToDouble(txtBoxQuantity.Text);
            bill[currentItem - 1].Quantity = quantity;
            bill[currentItem - 1].Price = bill[currentItem - 1].UnitPrice * quantity;

        }
        private void CalculateItemTotal(int Index)
        {
            double quantity = Convert.ToDouble(txtBoxQuantity.Text);
            bill[Index].Quantity = quantity;
            bill[Index].Price = bill[Index].UnitPrice * quantity;

        }

        private void EditQuntity()
        {
            if (!(listViewBill.Items.Count <= 0))
            {
                if ((listViewBill.SelectedItems.Count > 0))
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to change the Quantity?", "Quantity Change", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Item selected, retrieve index
                        int selectedIndex = Convert.ToInt32(listViewBill.SelectedItems[0].Text);
                        productCodeEdit = bill[selectedIndex - 1].ProductCode;

                        // Remove the item from the structure
                        bill.RemoveAt(selectedIndex - 1);
                        editPosition = selectedIndex - 1;

                        UpdateSubTotal();
                        UpdateTotal();

                        AddToBill(productCodeEdit);
                    }


                }
                else
                {
                    // No item selected, show dialog
                    MessageBox.Show("Please select an item from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listViewBill.Items[0].Selected = true;
                    listViewBill.SelectedItems[0].Focused = true;


                }

            }
            else
            {
                MessageBox.Show("Please Add at least one Item to the Bill", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxBarcode.Focus();
            }

        }
        private void EditUnitPrice_Imideate()
        {
            if (!String.IsNullOrEmpty(txtBoxUnitPrice.Text))
            {
                FormatMaker.BlockOutTextFeild(txtBoxQuantity);
                txtBoxUnitPrice.Focus();
                FormatMaker.EnableTextFeild(txtBoxUnitPrice);

            }
            else
            {
                MessageBox.Show("Please enter Item code or Scan Barcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxBarcode.Focus();
            }


        }


        private void RegisterNewCustomer()
        {
            regForm = new Customer.RegCustomer();
            regForm.ShowDialog();
        }
        private void ViewCustomerData()
        {
            viewCusDataForm = new Customer.ViewDetails();
            viewCusDataForm.setCustomerDetails(CustomerData);
            viewCusDataForm.ShowDialog();
        }
        private void LoadCustomerData(string LoyaltyNumber)
        {
            bool avalibility = simCustomerClass.IsAvailable(LoyaltyNumber);

            if (avalibility)
            {
                CustomerData = simCustomerClass.Select(LoyaltyNumber);
                txtBoxLoyalty.ReadOnly = true;
                txtBoxLoyalty.Enabled = false;
                loyaltyName.Text = CustomerData.FullName;
                lblCurrentCustomer.Text = CustomerData.FullName.ToString();
                loyaltyPointBalance.Text = CustomerData.LoyaltyPoints.ToString("0.00");
                txtBoxBarcode.Focus();
                btnViewCustomer.Enabled = true;

                if ("0000000000"== LoyaltyNumber)
                {
                    btnViewCustomer.Enabled = false;
                }

            }
            else
            {
                FormatMaker.ShowErrorMessageBox("Loyalty Numebr Not Found, Please Check Again");
                txtBoxLoyalty.Text = string.Empty;
                txtBoxLoyalty.Focus();
            }
        }


        private void LoadInventoryData()
        {
            inverntoryList = new InventoryList();
            DialogResult inventoryResult= inverntoryList.ShowDialog();
            if(inventoryResult == DialogResult.OK)
            {
                txtBoxBarcode.Text = SelectedItemFromInvetory;
                txtBoxBarcode.Focus();

            }
        }

        private void LoadPayment()
        {
            payScreen = new PaymentSceren();

            payScreen.subTotal = Decimal.Parse(txtBoxTotal.Text);

            payScreen.loggedUserData = loggedUserData;
            payScreen.customerData = CustomerData;
            payScreen.bill = bill;


            // Show the dialog and get the result
            DialogResult dialogResult = payScreen.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                // Access the variable from the dialog
                string createdBillNumber = payScreen.createdBillNumber;
                int createdtransactionID = payScreen.createdtransactionID;

                ClearOutCurrentBillData();
            }
        }


        private void ClearOutCurrentBillData()
        {
            bill=new List<BillItem>();

            currentItem = 1;
            productCodeEdit = string.Empty;
            editPosition = -1;

            listViewBill.Items.Clear();
            UpdateSubTotal();
            UpdateTotal();

            loyaltyName.Text = string.Empty;
            txtBoxLoyalty.Text= string.Empty;
            loyaltyPointBalance.Text = string.Empty;

            CustomerData = simCustomerClass.Select("0000000000");
            lblCurrentCustomer.Text = CustomerData.FullName.ToString();

            txtBoxBarcode.Focus();
        }
        
        private void LoadReturnItem()
        {
            returnScreen = new ReturnScreen();

            returnScreen.loggedUserData = loggedUserData;

            returnScreen.ShowDialog();
        }

        private void btnCancelBill_Click(object sender, EventArgs e)
        {
            ClearOutCurrentBillData();
        }

        private void btnManagerDashborad_Click(object sender, EventArgs e)
        {
            Manager.Dashborad dashborad = new Manager.Dashborad();
            dashborad.SetSession(sessionID);
            dashborad.Show();
            isClosing = true;
            this.Close();
        }
    }



}