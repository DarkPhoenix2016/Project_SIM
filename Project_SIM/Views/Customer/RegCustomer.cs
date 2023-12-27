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

            SimUser user = new SimUser();   

            if (string.IsNullOrEmpty(name)|| string.IsNullOrEmpty(username)|| string.IsNullOrEmpty(password)||string.IsNullOrEmpty(confirmPassword)|| string.IsNullOrEmpty(loyaltyNumber)|| string.IsNullOrEmpty(confirmLoyaltyNumber))
            {
                FormatMaker.ShowErrorMessageBox("Evey Feild is Madnotory");

            }else if (!(user.IsUsernameAvailable(username)))
            {
                FormatMaker.ShowErrorMessageBox("Username is alrady taken ");
                txtUsername.Text = "";
                txtUsername.Focus();
            }
            else if(password != confirmPassword)
            {
                FormatMaker.ShowErrorMessageBox("Passwords Do not Match!");
                txtPassword.Text = "";
                txtConfirmPassword.Text = ""; 
                txtPassword.Focus();

            }else if (loyaltyNumber != confirmLoyaltyNumber)
            {
                FormatMaker.ShowErrorMessageBox("Loyalty Number Do not Match!");
                txtLoyalty.Text = "";
                txtConfirmLoyaltyNumber.Text = "";
            }
            else if (customer.IsAvailable(loyaltyNumber)) 
            {
                FormatMaker.ShowErrorMessageBox("Loyalty Number Already Regitered!");
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
