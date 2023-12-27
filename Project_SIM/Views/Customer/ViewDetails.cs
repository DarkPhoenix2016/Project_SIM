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


namespace Project_SIM.Views.Customer
{
    public partial class ViewDetails : MaterialForm
    {

        public ViewDetails()
        {
            InitializeComponent();
            
        }

        public void setCustomerDetails(SimCustomer.Customer CustomerData)
        {
            txtLoyaltyNumber.Text = CustomerData.LoyaltyNumber;
            txtLoyaltyPoints.Text = CustomerData.LoyaltyPoints.ToString("0.00");
            txtName.Text = CustomerData.FullName;
            txtUsername.Text = CustomerData.Username;
            txtDateOfJoin.Text = CustomerData.DateOfJoin.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
