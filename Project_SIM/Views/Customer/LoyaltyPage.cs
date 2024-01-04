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

namespace Project_SIM.Views.Customer
{
    public partial class LoyaltyPage : Form
    {
        private int currentItem = 1;

        private SimCustomer simCustomerClass;
        private SimCustomer.Customer CustomerData;
        private List<LoyaltyPointTransaction> LoyaltyTransactions;


        public LoyaltyPage()
        {
            InitializeComponent();
            SetupListViewColumns();
            simCustomerClass = new SimCustomer();
        }
        private void LoyaltyPage_Load(object sender, EventArgs e)
        {
            LoadTransactinData();
        }
        private void LoyaltyPage_Resize(object sender, EventArgs e)
        {
            // Adjust column widths when the form is resized
            SetupListViewColumns();
        }
        public void SetCustomerData(SimCustomer.Customer customerData)
        {
            CustomerData = customerData;
        }

        private void SetupListViewColumns()
        {
            // Specify the ratios for each column
            double[] columnRatios = { 0.05,0.2,0.2,0.2,0.2};

            // Calculate total width
            int totalWidth = listViewLoyalty.Width;

            // Adjust column widths based on ratios
            for (int i = 0; i < listViewLoyalty.Columns.Count; i++)
            {
                listViewLoyalty.Columns[i].Width = (int)(totalWidth * columnRatios[i]);
            }
        }
        private void LoadTransactinData()
        {
            listViewLoyalty.Items.Clear();
            currentItem = 1; // Reset the counter when reloading data

            decimal currentBalance = 0;

            // Retrieve customer bill summaries
            List<LoyaltyPointTransaction> LoyaltyTransactions = simCustomerClass.LoyaltyPointTransactions(CustomerData.LoyaltyNumber.ToString());

            if (LoyaltyTransactions != null && LoyaltyTransactions.Count > 0)
            {
                // Iterate over the list and process each CustomerBillSummry object
                foreach (LoyaltyPointTransaction reocred in LoyaltyTransactions)
                {
                    ListViewItem newItem = new ListViewItem(currentItem.ToString());
                    newItem.SubItems.Add(reocred.TransactionDate.ToString("yyyy-MM-dd"));
                    newItem.SubItems.Add(reocred.State);
                    newItem.SubItems.Add(reocred.Amount.ToString("0.00"));
                    if (reocred.State == "Credit")
                    {
                        currentBalance += reocred.Amount;
                    }
                    if(reocred.State == "Debit")
                    {
                        currentBalance -= reocred.Amount;
                    }
                    newItem.SubItems.Add(currentBalance.ToString("0.00"));

                    listViewLoyalty.Items.Add(newItem);
                    currentItem++;
                }
            }
        }
        

        
    }
}
