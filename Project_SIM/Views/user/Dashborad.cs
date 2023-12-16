using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using Project_SIM.Models;
using Project_SIM.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZXing;

namespace Project_SIM.Views.user
{
    public partial class Dashborad : MaterialForm
    {
        private SqlConnectionClass sqlConnection;
        private BarcodeReader barcodeReader;
        private List<BillItem> bill;
        private int currentItem = 1;
        private string ProductCode_Edit;

        private int editPosition=-1;
        private Customer.RegCustomer RegForm;
        private Customer.ViewDetails ViewCusDataForm;


        public Dashborad()
        {
            InitializeComponent();
            sqlConnection = new SqlConnectionClass();
            // Initialize the barcode reader
            barcodeReader = new BarcodeReader();
            SetupListViewColumns();
            bill = new List<BillItem>(); // Initialize the bill list
            txtBoxBarcode.Focus();

        }



        private void Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBoxBarcode.Text))
                {
                
                    RetrieveData();
                }
                else
                {
                    MessageBox.Show("Barcode or Item Code can not be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (!(Convert.ToDouble(txtBoxQuantity.Text)==0)) {

                        if(editPosition > -1)
                        {
                            CalculateItemTotal(editPosition);
                            AddToBill(editPosition);
                        }
                        else
                        {
                            CalculateItemTotal();
                            AddToBill();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Quantity can not be Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBoxQuantity.Text = "";
                        txtBoxQuantity.Focus();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Quantity can not be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            BlockOutTextFeild(txtBoxUnitPrice);
                            txtBoxQuantity.Focus();
                            EnableTextFeild(txtBoxQuantity);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            txtBoxUnitPrice.Text = bill[currentItem - 1].UnitPrice.ToString("0.00");
                            BlockOutTextFeild(txtBoxUnitPrice);
                            txtBoxQuantity.Focus();
                            EnableTextFeild(txtBoxQuantity);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unit Price can not be Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBoxUnitPrice.Text = "";
                        txtBoxUnitPrice.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Unit Price can not be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                EditUnitPrice_Imideate();
                e.Handled = true; // Prevent beep sound
            }
            else if (e.KeyCode == Keys.F2)
            {
                EditQuntity();
                e.Handled = true;
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
            }else if(e.KeyCode == Keys.Delete)
            {
                RemoveItemFromBill();
            }
        }
        private void Barcode_Enter(object sender, EventArgs e)
        {
            txtBoxBarcode.Focus();
            txtBoxBarcode.Text = "";
        }
        private void SimUserScreen_Resize(object sender, EventArgs e)
        {
            // Adjust column widths when the form is resized
            SetupListViewColumns();
        }
        private void BtnEditPrice(object sender, EventArgs e)
        {
            EditUnitPrice_Imideate();
        }
        private void BtnEditQuantity_Click(object sender, EventArgs e)
        {
            EditQuntity();
        }
        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            RemoveItemFromBill();
        }
        private void btnRegCustomer_Click(object sender, EventArgs e)
        {
            RegForm = new Customer.RegCustomer();
            RegForm.ShowDialog();
        }
        private void btnViewCustomer_Click(object sender, EventArgs e)
        {
            ViewCusDataForm = new Customer.ViewDetails();
            ViewCusDataForm.ShowDialog();
        }

        private void RetrieveData()
        {
            string barcode = txtBoxBarcode.Text.Trim();

            if (!string.IsNullOrEmpty(barcode))
            {
                string query = $"SELECT * FROM products WHERE Barcode = '{barcode}' OR ProductCode ='{barcode}'";
                using (MySqlDataReader reader = sqlConnection.ExecuteQuery(query))
                {
                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            BillItem currentBillItem = new BillItem(); // Move inside the loop

                            double unitPrice = Convert.ToDouble(reader["Price"]);

                            currentBillItem.Number = currentItem;
                            currentBillItem.ProductID = Convert.ToInt32(reader["ProductID"]);
                            currentBillItem.ProductCode = reader["ProductCode"].ToString();
                            currentBillItem.ProductName = reader["Name"].ToString();
                            currentBillItem.UnitPrice = unitPrice;

                            txtBoxBarcode.Text = currentBillItem.ProductName;
                            bill.Add(currentBillItem);

                            txtBoxUnitPrice.Text = currentBillItem.UnitPrice.ToString("0.00");
                            txtBoxQuantity.Focus();
                            EnableTextFeild(txtBoxQuantity);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Product Not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBoxBarcode.Focus();
                        txtBoxBarcode.Text = string.Empty;
                    }
                }
                sqlConnection.CloseConnection();
            }
        }

        private void RetrieveData(String ProductCode)
        {
            string barcode = ProductCode.Trim();
            BlockOutTextFeild(txtBoxBarcode);

            if (!string.IsNullOrEmpty(barcode))

            {
                string query = $"SELECT * FROM products WHERE Barcode = '{barcode}' OR ProductCode ='{barcode}'";
                using (MySqlDataReader reader = sqlConnection.ExecuteQuery(query))
                {
                    if (reader != null && reader.HasRows)
                    {
                        // Declare currentBillItem outside the loop
                        BillItem currentBillItem = new BillItem();

                        while (reader.Read())
                        {
                            double unitPrice = Convert.ToDouble(reader["Price"]);

                            // Set values for the currentBillItem inside the loop
                            currentBillItem.Number = editPosition+1;
                            currentBillItem.ProductID = Convert.ToInt32(reader["ProductID"]);
                            currentBillItem.ProductCode = reader["ProductCode"].ToString();
                            currentBillItem.ProductName = reader["Name"].ToString();
                            currentBillItem.UnitPrice = unitPrice;

                            txtBoxBarcode.Text = reader["Name"].ToString();
                            // Add the currentBillItem to the bill list
                            bill.Insert(editPosition, currentBillItem);

                            // Set the unit price in the textbox and set focus
                            txtBoxUnitPrice.Text = currentBillItem.UnitPrice.ToString("0.00");
                            txtBoxQuantity.Focus();
                            EnableTextFeild(txtBoxQuantity);



                        }
                    }
                    
                }
                sqlConnection.CloseConnection();
            }


        }

        private void AddToBill()
        {
            ListViewItem newItem = new ListViewItem(currentItem.ToString());

            newItem.SubItems.Add(bill[currentItem - 1].ProductCode);
            newItem.SubItems.Add(bill[currentItem - 1].ProductName);
            newItem.SubItems.Add(bill[currentItem - 1].UnitPrice.ToString("0.00"));
            newItem.SubItems.Add(bill[currentItem - 1].Quantity.ToString("0.000"));
            newItem.SubItems.Add(bill[currentItem - 1].Price.ToString("0.00"));
            listViewBill.Items.Add(newItem);

            // Clear the textboxes for the next entry
            txtBoxBarcode.Text = string.Empty;
            txtBoxUnitPrice.Text = string.Empty;
            txtBoxQuantity.Text = string.Empty;

            // Increment the counter for the next item
            currentItem++;

            // Set focus back to textBoxBarcode
            BlockOutTextFeild(txtBoxQuantity);
            txtBoxBarcode.Focus();

            UpdateSubTotal();
            UpdateTotal();
        }
        private void AddToBill(int ItemIndex)
        {
            listViewBill.Items[ItemIndex].SubItems[0].Text = bill[ItemIndex].Number.ToString();
            listViewBill.Items[ItemIndex].SubItems[1].Text = bill[ItemIndex].ProductCode.ToString();
            listViewBill.Items[ItemIndex].SubItems[2].Text = bill[ItemIndex].ProductName.ToString();
            listViewBill.Items[ItemIndex].SubItems[3].Text = bill[ItemIndex].UnitPrice.ToString("0.00");
            listViewBill.Items[ItemIndex].SubItems[4].Text = bill[ItemIndex].Quantity.ToString("0.000");
            listViewBill.Items[ItemIndex].SubItems[5].Text = bill[ItemIndex].Price.ToString("0.00");

            // Clear the textboxes for the next entry
            txtBoxBarcode.Text = string.Empty;
            txtBoxUnitPrice.Text = string.Empty;
            txtBoxQuantity.Text = string.Empty;

            // Set focus back to textBoxBarcode
            BlockOutTextFeild(txtBoxQuantity);
            txtBoxBarcode.Focus();
            EnableTextFeild(txtBoxBarcode);

            UpdateSubTotal();
            UpdateTotal();

            editPosition = -1;

        }
        private void RemoveItemFromBill()
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
                        listViewBill.Items.RemoveAt(selectedIndex-1);
                        // Remove the item from the structure
                        bill.RemoveAt(selectedIndex-1);
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


        private void UpdateSubTotal()
        {
            double subTotal = 0;

            foreach (ListViewItem item in listViewBill.Items)
            {
                if (double.TryParse(item.SubItems[5].Text, out double amount))
                {
                    subTotal += amount;
                }
            }

            txtBoxSubTotal.Text = subTotal.ToString("0.00");
        }
        private void UpdateTotal()
        {
            double subTotal = Convert.ToDouble(txtBoxSubTotal.Text);
            //can add other discoust or any logic
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
                        ProductCode_Edit = bill[selectedIndex - 1].ProductCode;

                        // Remove the item from the structure
                        bill.RemoveAt(selectedIndex - 1);
                        editPosition = selectedIndex - 1;

                        UpdateSubTotal();
                        UpdateTotal();

                        RetrieveData(ProductCode_Edit);
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
                BlockOutTextFeild(txtBoxQuantity);
                txtBoxUnitPrice.Focus();
                EnableTextFeild(txtBoxUnitPrice);

            }
            else
            {
                MessageBox.Show("Please enter Item code or Scan Barcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxBarcode.Focus();
            }
            

        }

        private void BlockOutTextFeild(TextBox Name)
        {
            Name.ReadOnly = true;
            txtBoxQuantity.Cursor = Cursors.No;
        }
        private void EnableTextFeild(TextBox Name)
        {
            Name.ReadOnly = false;
            txtBoxQuantity.Cursor = Cursors.Arrow;
        }
        private void SetupListViewColumns()
        {
            // Specify the ratios for each column
            double[] columnRatios = { 0.05, 0.1, 0.4, 0.1, 0.1, 0.25 };

            // Calculate total width
            int totalWidth = listViewBill.Width;

            // Adjust column widths based on ratios
            for (int i = 0; i < listViewBill.Columns.Count; i++)
            {
                listViewBill.Columns[i].Width = (int)(totalWidth * columnRatios[i]);
            }
        }

        

        

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

        }

        private void btnViewInventory_Click(object sender, EventArgs e)
        {

        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {

        }
    }

    public class BillItem
    {
        public int Number { get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
    }

}


