using MaterialSkin.Controls;
using Project_SIM.Models;
using System;
using System.Windows;
using System.Windows.Forms;


namespace Project_SIM.Views.User
{
    public partial class RegUser : MaterialForm
    {
        SimUser SimUser;

        private string designation;
        private string name;
        private string username;
        private string password;
        private string confirmPassword;

        public RegUser()
        {
            InitializeComponent(); 
            KeyPreview = true;

            SimUser = new SimUser();
            SetDesignations();

        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();

            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            designation= comBoxDesignations.SelectedItem.ToString();
            name = txtName.Text.Trim();
            username = txtUsername.Text.Trim();
            password = txtPassword.Text.Trim(); 
            confirmPassword = txtConfirmPassword.Text.Trim();   

            SimUser user = new SimUser();   

            if (string.IsNullOrEmpty(designation) || string.IsNullOrEmpty(name)|| string.IsNullOrEmpty(username)|| string.IsNullOrEmpty(password)||string.IsNullOrEmpty(confirmPassword))
            {
                FormatMaker.ShowErrorMessageBox("Evey Feild is Madnotory");

            }else if (!(user.IsUsernameAvailable(username,designation)))
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

            }
            else
            {
                bool result = SimUser.Register(name, username,password, designation);

                if (result)
                {
                    System.Windows.Forms.MessageBox.Show("Registration Successful.","Successful",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    DialogResult = DialogResult.Yes;
                    Close();
                }
                else
                {
                    FormatMaker.ShowErrorMessageBox("Error!, Registration Unsuccessful.Please Try Again Later.");
                    DialogResult = DialogResult.No;
                    Close();
                }

            }
        }

        private void SetDesignations()
        {

            foreach (SimUser.Designation designation in SimUser.GetDesignations())
            {
                comBoxDesignations.Items.Add(designation.Title.ToString());
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
