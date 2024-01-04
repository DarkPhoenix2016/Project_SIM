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
using static Project_SIM.Models.SimCustomer;
using static Project_SIM.Models.SimProduct;

namespace Project_SIM.Views.Customer
{
    public partial class BillsPage : Form
    {
        private int currentItem = 1;

        private SimCustomer simCustomerClass;
        private SimCustomer.Customer CustomerData;
        private SimCustomer.CustomerLastBillReport CustomerBillReport;
        private List<CustomerAllBillSummry> customerBillSummries;

        public BillsPage()
        {
            InitializeComponent();
            SetupListViewColumns();
            simCustomerClass = new SimCustomer();
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
            double[] columnRatios = { 0.05, 0.15, 0.15,0.15,0.15, 0.15, 0.15};

            // Calculate total width
            int totalWidth = listViewBills.Width;

            // Adjust column widths based on ratios
            for (int i = 0; i < listViewBills.Columns.Count; i++)
            {
                listViewBills.Columns[i].Width = (int)(totalWidth * columnRatios[i]);
            }
        }

        public void SetCustomerData(SimCustomer.Customer customerData)
        {
            CustomerData = customerData;
        }

        private void LoadBillData()
        {
            listViewBills.Items.Clear();
            currentItem = 1; // Reset the counter when reloading data

            // Retrieve customer bill summaries
            List<CustomerAllBillSummry> customerBillSummries = simCustomerClass.SelectCustomerAllBillSummary(CustomerData.CustomerID.ToString());

            if (customerBillSummries != null && customerBillSummries.Count > 0)
            {
                // Iterate over the list and process each CustomerBillSummry object
                foreach (CustomerAllBillSummry billSummary in customerBillSummries)
                {
                    ListViewItem newItem = new ListViewItem(currentItem.ToString());
                    newItem.SubItems.Add(billSummary.TransactionDate.ToString("yyyy-MM-dd"));
                    newItem.SubItems.Add(billSummary.BillNumber);
                    newItem.SubItems.Add(billSummary.TotalLineCount.ToString());
                    newItem.SubItems.Add("Rs "+(Convert.ToDecimal(billSummary.TotalDiscount)+ Convert.ToDecimal(billSummary.TotalAmount)).ToString("0.00"));
                    newItem.SubItems.Add("Rs " + billSummary.TotalDiscount);
                    newItem.SubItems.Add("Rs " + billSummary.TotalAmount);

                    listViewBills.Items.Add(newItem);
                    currentItem++;
                }
            }
        }

    }


}
