using MaterialSkin.Controls;
using Project_SIM.Models;
using Project_SIM.Views.Customer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using static Project_SIM.Models.SimCustomer;


namespace Project_SIM.Views.Manager
{
    public partial class BillsPage : MaterialForm
    {
        private int currentItem = 1;
        private int lastSelectedIndex = -1;
        SimBill SimBillClass;
        List<BillSummry> ListBills;

        public BillsPage()
        {
            InitializeComponent();
            SetupListViewColumns();
            SimBillClass = new SimBill();
        }
        private void Screen_Resize(object sender, EventArgs e)
        {
            // Adjust column widths when the form is resized
            SetupListViewColumns();
        }

        private void BillsPage_Load(object sender, EventArgs e)
        {
            LoadBillData();
        }
        private void SetupListViewColumns()
        {
            // Specify the ratios for each column
            double[] columnRatios = { 0.05, 0.15, 0.15, 0.15, 0.15, 0.15, 0.15 };

            // Calculate total width
            int totalWidth = listViewBills.Width;

            // Adjust column widths based on ratios
            for (int i = 0; i < listViewBills.Columns.Count; i++)
            {
                listViewBills.Columns[i].Width = (int)(totalWidth * columnRatios[i]);
            }
        }
        private void txtSearchWord_TextChanged(object sender, EventArgs e)
        {
            // If the text is empty, clear the ListView and reset the counter
            if (string.IsNullOrEmpty(txtSearchWord.Text.Trim()))
            {
                listViewBills.Items.Clear();
                currentItem = 1; // Reset the counter when clearing the ListView
            }
            else
            {
                LoadBillData(txtSearchWord.Text);
            }
        }

        private void txtSearchWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the text is empty, clear the ListView and reset the counter
            if (string.IsNullOrEmpty(txtSearchWord.Text.Trim()))
            {
                listViewBills.Items.Clear();
                currentItem = 1; // Reset the counter when clearing the ListView
            }
            else
            {
                LoadBillData(txtSearchWord.Text);
            }
        }

        private void LoadBillData()
        {
            listViewBills.Items.Clear();
            currentItem = 1; // Reset the counter when reloading data

            // Retrieve customer bill summaries
            ListBills = SimBillClass.GetBillSummary();

            if (ListBills != null && ListBills.Count > 0)
            {
                // Iterate over the list and process each CustomerBillSummry object
                foreach (BillSummry billSummary in ListBills)
                {
                    ListViewItem newItem = new ListViewItem(currentItem.ToString());
                    newItem.SubItems.Add(billSummary.TransactionDate.ToString("yyyy-MM-dd"));
                    newItem.SubItems.Add(billSummary.BillNumber);
                    newItem.SubItems.Add(billSummary.TotalLineCount.ToString());
                    newItem.SubItems.Add("Rs " + (Convert.ToDecimal(billSummary.TotalDiscount) + Convert.ToDecimal(billSummary.TotalAmount)).ToString("0.00"));
                    newItem.SubItems.Add("Rs " + billSummary.TotalDiscount);
                    newItem.SubItems.Add("Rs " + billSummary.TotalAmount);

                    listViewBills.Items.Add(newItem);
                    currentItem++;
                }
            }
        }

        private void LoadBillData(string billNumber)
        {
            listViewBills.Items.Clear();
            currentItem = 1; // Reset the counter when reloading data

            // Retrieve customer bill summaries
            ListBills = SimBillClass.GetBillSummary(billNumber);

            if (ListBills != null && ListBills.Count > 0)
            {
                // Iterate over the list and process each CustomerBillSummry object
                foreach (BillSummry billSummary in ListBills)
                {
                    ListViewItem newItem = new ListViewItem(currentItem.ToString());
                    newItem.SubItems.Add(billSummary.TransactionDate.ToString("yyyy-MM-dd"));
                    newItem.SubItems.Add(billSummary.BillNumber);
                    newItem.SubItems.Add(billSummary.TotalLineCount.ToString());
                    newItem.SubItems.Add("Rs " + (Convert.ToDecimal(billSummary.TotalDiscount) + Convert.ToDecimal(billSummary.TotalAmount)).ToString("0.00"));
                    newItem.SubItems.Add("Rs " + billSummary.TotalDiscount);
                    newItem.SubItems.Add("Rs " + billSummary.TotalAmount);

                    listViewBills.Items.Add(newItem);
                    currentItem++;
                }
            }
        }

        private void listViewBills_ItemActivate(object sender, EventArgs e)
        {
            int selectedIndex = listViewBills.SelectedIndices[0];

            // Check if the selected item is the same as the last selected item
            if (selectedIndex == lastSelectedIndex)
            {
                selectedIndex = listViewBills.SelectedIndices[0];

                BillSummry selectedBill = ListBills[selectedIndex];

                string savedBillNumber = selectedBill.BillNumber.ToString();
                string savedTransactionId = selectedBill.TransactionID.ToString();

                BillRecord record = new BillRecord();
                record.createdBillNumber = savedBillNumber;
                record.createdtransactionID = Convert.ToInt32(savedTransactionId);
                record.ShowDialog();
            }

            // Update the last selected index
            lastSelectedIndex = selectedIndex;

        }

    }  

}
