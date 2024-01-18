using Project_SIM.Models;
using System;
using System.Windows.Forms;

namespace Project_SIM.Views.Customer
{
    public partial class HomePage : Form
    {
        private SimCustomer simCustomerClass;
        private SimCustomer.Customer CustomerData;
        private SimCustomer.CustomerLastBillReport CustomerBillReport;


        public HomePage()
        {
            InitializeComponent();
            simCustomerClass = new SimCustomer();
            
        }

        public void SetCustomerData(SimCustomer.Customer customerData)
        {
            CustomerData = customerData;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            DateTime dateOfJoin = CustomerData.DateOfJoin;
            DateTime dateNow = DateTime.Now;
            CustomerBillReport = simCustomerClass.SelectCustomerLastBillSummary(CustomerData.CustomerID.ToString());

            lblFullName.Text += CustomerData.FullName;

            lblJoiningDate.Text = CustomerData.DateOfJoin.ToString("yyyy-MM-dd");
            lblBalanceDate.Text = dateNow.ToString("yyyy-MM-dd");
            lblLoyalPointBalance.Text = CustomerData.LoyaltyPoints.ToString("0.00");

            lblLastBillDate.Text = CustomerBillReport.LastBillDate.ToString("yyyy-MM-dd");
            lblLastBillNumber.Text ="Bill No: "+ CustomerBillReport.LastBillNumber;
            lblLastBillValue.Text = "Rs "+CustomerBillReport.LastBillTotalAmount.ToString();

            lblTotalBillsStartDate.Text = CustomerData.DateOfJoin.ToString("yyyy-MM-dd");
            lblTotalBills.Text = CustomerBillReport.BillCount.ToString();

            CalculateAge(dateOfJoin, dateNow,lblAgeAsCustomer);

        }

        public void CalculateAge(DateTime dateOfJoin, DateTime currentDate,Label textLable)
        {
            // Calculate the difference in years and months
            int years = currentDate.Year - dateOfJoin.Year;
            int months = currentDate.Month - dateOfJoin.Month;

            // Adjust the age if the birthday hasn't occurred yet in the current year
            if (currentDate.DayOfYear < dateOfJoin.DayOfYear)
            {
                years--;
                months += 12;
            }
            textLable.Text = $"{years} Years {months} Months";
        }


    }
}
