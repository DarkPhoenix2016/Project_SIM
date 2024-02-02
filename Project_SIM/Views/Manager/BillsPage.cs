using MaterialSkin.Controls;
using Project_SIM.Models;
using Project_SIM.Views.Customer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using static Project_SIM.Models.SimCustomer;
using BrightIdeasSoftware;


namespace Project_SIM.Views.Manager
{
    public partial class BillsPage : MaterialForm
    {

        SimBill SimBillClass;
        List<BillSummry> ListBills;

        public BillsPage()
        {
            InitializeComponent();
            SimBillClass = new SimBill();
        }

        private void BillsPage_Load(object sender, EventArgs e)
        {
            LoadBillData();
        }
        
        private void txtSearchWord_TextChanged(object sender, EventArgs e)
        {
            // If the text is empty, clear the ListView and reset the counter
            if (string.IsNullOrEmpty(txtSearchWord.Text.Trim()))
            {
                objListViewBills.Items.Clear();
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
                objListViewBills.Items.Clear();
            }
            else
            {
                LoadBillData(txtSearchWord.Text);
            }
        }

        private void LoadBillData()
        {
            // Retrieve customer bill summaries
            ListBills = SimBillClass.GetBillSummary();
            LoadBillDataObj();
        }

        private void LoadBillData(string billNumber)
        {
            ListBills = SimBillClass.GetBillSummary(billNumber);
            LoadBillDataObj();
        }

        private void LoadBillDataObj()
        {
            // Set aspect getters for each column to display the desired details

            NoCol.AspectGetter = (s) => (s as BillSummry)?.ID.ToString(); 
            colDate.AspectGetter = (s) => (s as BillSummry)?.TransactionDate.ToString("yyyy-MM-dd");
            colBillNumber.AspectGetter = (s) => (s as BillSummry)?.BillNumber;
            colNoLins.AspectGetter = (s) => (s as BillSummry)?.TotalLineCount.ToString();
            colSubTotal.AspectGetter = (s) => (s as BillSummry)?.Subtotal;
            colDiscount.AspectGetter = (s) =>(s as BillSummry)?.TotalDiscount;
            colTotal.AspectGetter = (s) => (s as BillSummry)?.TotalCost;

            // Button column set up for viewing the bill
            colViweBill.IsButton = true;
            colViweBill.ButtonSizing = OLVColumn.ButtonSizingMode.CellBounds;
            colViweBill.AspectGetter = (s) => "View";


            // Clear existing items and set new objects to the ListView
            objListViewBills.Items.Clear();
            objListViewBills.SetObjects(ListBills);

        }

        
        private void chckBoxShowGroups_CheckedChanged(object sender, EventArgs e)
        {
            if(chckBoxShowGroups.Checked == true)
            {
                objListViewBills.ShowGroups =   true;
            }

            if (chckBoxShowGroups.Checked == false)
            {
                objListViewBills.ShowGroups = false;
            }

        }

        private void objListViewBills_ButtonClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == colViweBill)
            {
                Console.WriteLine("Viwe Button event Got Triggerd.");
                try
                {
                    int clickedRow = e.RowIndex;  // Get the row index of the clicked button

                    Console.WriteLine($"Index of the Clicked Row: {clickedRow}");

                    if (clickedRow >= 0 && clickedRow < ListBills.Count)
                    {
                        // Access the underlying object associated with the clicked row
                        BillSummry selectedBill = e.Model as BillSummry;

                        if (selectedBill != null)
                        {
                            // Access the value of the first column in the clicked row
                            string valueOfFirstColumn = selectedBill.TransactionID.ToString();

                            // Use the value as needed
                            Console.WriteLine($"Value of the first column: {valueOfFirstColumn}");

                            // The rest of your code
                            string savedBillNumber = selectedBill.BillNumber.ToString();
                            string savedTransactionId = selectedBill.TransactionID.ToString();

                            BillRecord record = new BillRecord();
                            record.createdBillNumber = savedBillNumber;
                            record.createdtransactionID = Convert.ToInt32(savedTransactionId);
                            record.Show();



                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBillData();
        }
    }  

}
