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

namespace Project_SIM.Views.User
{
    public partial class ReturnScreen : MaterialForm
    {
        public SimUser.UserData loggedUserData;

        public ReturnScreen()
        {
            InitializeComponent();

            lblLoggedUser.Text = string.Empty;
            txtSearchBill.Text = string.Empty;
        }

        private void ReturnScreen_Load(object sender, EventArgs e)
        {
            lblLoggedUser.Text = loggedUserData.FullName;

            txtSearchBill.Focus();

        }
    }
}
