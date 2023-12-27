using MaterialSkin.Controls;
using Project_SIM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml.Controls.Primitives;

namespace Project_SIM.Views.User
{
    public partial class ReturnScreen : MaterialForm
    {
        public SimUser.UserData loggedUserData;

        private SimBill billClass;
        private List<ReturnItem> billedList;
        private ReturnItem selectedItem;
        private int currentItem = 1;
        private double[] coloumRatios = { 0.05, 0.25, 0.40, 0.14, 0.14 };

        public ReturnScreen()
        {
            InitializeComponent();

            FormatMaker.SetupListViewColumns(listViewBilledItems, coloumRatios);

            billClass = new SimBill();

            lblLoggedUser.Text = string.Empty;
            txtSearchBill.Text = string.Empty;
        }

        private void ReturnScreen_Load(object sender, EventArgs e)
        {
            lblLoggedUser.Text = loggedUserData.FullName;

            txtSearchBill.Focus();

        }

        private void btnSearchBill_Click(object sender, EventArgs e)
        {
            LoadBillData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearBill_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            CreateReturnRecord();
        }
        private void txtNowReturningQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void listViewBilledItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItemData();
        }
        
        private void LoadBillData()
        {
            billedList = billClass.GetBilledItems(txtSearchBill.Text);
            if (billedList != null)
            {

                foreach (ReturnItem item in billedList)
                {
                    ListViewItem newItem = new ListViewItem(currentItem.ToString());
                    newItem.SubItems.Add(item.ProductCode);
                    newItem.SubItems.Add(item.ProductName);
                    newItem.SubItems.Add(item.BilledQuantity.ToString("0.000"));
                    newItem.SubItems.Add(item.ReturnedQuantity.ToString("0.000"));

                    listViewBilledItems.Items.Add(newItem);
                    currentItem++;
                }
                txtSearchBill.Enabled = false;
                btnSearchBill.Enabled = false;

                btnClearBill.Enabled = true;
                listViewBilledItems.Enabled = true;
                listViewBilledItems.Focus();
            }
            else
            {
                FormatMaker.ShowErrorMessageBox("Bill Number Not Found");
                txtSearchBill.Text = string.Empty;
                txtSearchBill.Focus();
            }
        }
        private void RefreshBillData()
        {
            currentItem = 1;
            listViewBilledItems.Items.Clear();
            billedList = billClass.GetBilledItems(txtSearchBill.Text);
            if (billedList != null)
            {

                foreach (ReturnItem item in billedList)
                {
                    ListViewItem newItem = new ListViewItem(currentItem.ToString());
                    newItem.SubItems.Add(item.ProductCode);
                    newItem.SubItems.Add(item.ProductName);
                    newItem.SubItems.Add(item.BilledQuantity.ToString("0.000"));
                    newItem.SubItems.Add(item.ReturnedQuantity.ToString("0.000"));

                    listViewBilledItems.Items.Add(newItem);
                    currentItem++;
                }
                txtSearchBill.Enabled = false;
                btnSearchBill.Enabled = false;

                btnClearBill.Enabled = true;
                listViewBilledItems.Enabled = true;
                listViewBilledItems.Focus();
            }
            else
            {
                FormatMaker.ShowErrorMessageBox("Bill Number Not Found");
                txtSearchBill.Text = string.Empty;
                txtSearchBill.Focus();
            }
        }

        private void LoadItemData()
        {

            if (listViewBilledItems.SelectedItems.Count > 0)
            {
                int selectedIndex = listViewBilledItems.SelectedIndices[0];

                selectedItem = billedList[selectedIndex];

                txtBillNumber.Text = selectedItem.BillNumber.ToString();
                txtSelecedProductCode.Text = selectedItem.ProductCode.ToString();
                txtSelecedProductName.Text = selectedItem.ProductName.ToString();
                txtBilledQuantity.Text= selectedItem.BilledQuantity.ToString();
                txtReturnedQunatity.Text=selectedItem.ReturnedQuantity.ToString();

                txtNowReturningQuantity.Text = string.Empty;
                txtReturnReason.Text = string.Empty;
                txtNowReturningQuantity.Enabled = true;
                txtReturnReason.Enabled = true;
                btnReturn.Enabled = true;

            }
            
        }

        private void ResetForm()
        {
            billedList = null;
            listViewBilledItems.Items.Clear();

            txtSearchBill.Enabled = true;
            btnSearchBill.Enabled = true;

            btnClearBill.Enabled = false;
            listViewBilledItems.Enabled = false;
            txtNowReturningQuantity.Enabled = false;
            txtReturnReason.Enabled = false;
            btnReturn.Enabled = false;

            txtBillNumber.Text = string.Empty;
            txtSelecedProductCode.Text = string.Empty;
            txtSelecedProductName.Text = string.Empty;
            txtBilledQuantity.Text = string.Empty;
            txtReturnedQunatity.Text = string.Empty;
            txtNowReturningQuantity.Text = string.Empty;
            txtReturnReason.Text = string.Empty;

            txtSearchBill.Text = string.Empty;
            txtSearchBill.Focus();

        }

        private void CreateReturnRecord()
        {
            string returningQuantity = txtNowReturningQuantity.Text.Trim();
            string reason = txtReturnReason.Text.Trim();

            if (!string.IsNullOrEmpty(returningQuantity)&& !string.IsNullOrEmpty(reason))
            {
                if (Convert.ToDouble(returningQuantity) <= ((Convert.ToDouble(txtBilledQuantity.Text.Trim()) - (Convert.ToDouble(txtReturnedQunatity.Text.Trim())))))
                {

                
                    selectedItem.ToReturnQuantity = Convert.ToDouble(returningQuantity);
                    selectedItem.Reason = reason;
                    bool result = billClass.CreateRetrunedItem(selectedItem, loggedUserData.UserID);
                    if (result)
                    {
                        DialogResult result_dialog = MessageBox.Show("Item Return Recored Succsfully. \nDo you want to continue?", "Item Returned", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result_dialog == DialogResult.No)
                        {
                            this.Close();
                        }
                        else
                        {
                            RefreshBillData();
                        }
                    
                    }

                }
                else
                {
                    FormatMaker.ShowErrorMessageBox($"Retrun Quantity canot exceed : {(Convert.ToDouble(txtBilledQuantity.Text.Trim()) - (Convert.ToDouble(txtReturnedQunatity.Text.Trim())))}");
                    txtNowReturningQuantity.Focus();
                }

            }
            else
            {
                FormatMaker.ShowErrorMessageBox("To return the Item Quantity and Reason is a Must.");
            }
            
            
        }

        
    }
}
