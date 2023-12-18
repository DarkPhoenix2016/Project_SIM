using MaterialSkin.Controls;
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
    public partial class RegCustomer : MaterialForm
    {
        Models.SimCustomer customer = new Models.SimCustomer();

        private string name;
        private string username;
        private string password;
        private string confirmPassword;
        private string loyaltyNumber;
        private string confirmLoyaltyNumber;

        public RegCustomer()
        {
            InitializeComponent();
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            name = txtName.Text.Trim();
            username = txtUsername.Text.Trim();
            password = txtPassword.Text.Trim(); 
            confirmPassword = txtConfirmPassword.Text.Trim();   
            loyaltyNumber = txtLoyalty.Text.Trim();
            confirmLoyaltyNumber= txtConfirmLoyaltyNumber.Text.Trim();
            if (string.IsNullOrEmpty(name)|| string.IsNullOrEmpty(username)|| string.IsNullOrEmpty(password)||string.IsNullOrEmpty(confirmPassword)|| string.IsNullOrEmpty(loyaltyNumber)|| string.IsNullOrEmpty(confirmLoyaltyNumber))
            {
                MessageBox.Show("Evey Feild is Madnotory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(password != confirmPassword)
            {
                MessageBox.Show("Passwords Do not Match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConfirmPassword.Text = ""; 

            }else if (loyaltyNumber != confirmLoyaltyNumber)
            {
                MessageBox.Show("Loyalty Number Do not Match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoyalty.Text = "";
                txtConfirmLoyaltyNumber.Text = "";
            }
            else
            {
                customer.Register(name, username,loyaltyNumber,password);
                this.Close();
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
