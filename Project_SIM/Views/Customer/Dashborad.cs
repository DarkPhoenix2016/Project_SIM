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
    public partial class Dashborad : MaterialForm
    {
        HomePage Home;
        BillsPage Bills;
        LoyaltyPage Loyalty;
        ProfilePage Profile;
        SettingsPage Settings;

        public Dashborad()
        {
            InitializeComponent();
            Home = new HomePage();
            Home.FormClosed += Home_Formclosed;
            Home.MdiParent = this;
            Home.Dock = DockStyle.Fill;
            Home.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (Home == null)
            {
                Home = new HomePage();
                Home.FormClosed += Home_Formclosed;
                Home.MdiParent = this;
                Home.Dock = DockStyle.Fill;
                Home.Show();
            }
            else
            {
                Home.Activate();
            }
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            if (Bills == null)
            {
                Bills = new BillsPage();
                Bills.FormClosed += Bills_Formclosed;
                Bills.MdiParent = this;
                Bills.Dock = DockStyle.Fill;
                Bills.Show();
            }
            else
            {
                Bills.Activate();
            }
        }

        private void btnLoyalty_Click(object sender, EventArgs e)
        {
            if (Loyalty == null)
            {
                Loyalty = new LoyaltyPage();
                Loyalty.FormClosed += Loyalty_Formclosed;
                Loyalty.MdiParent = this;
                Loyalty.Dock = DockStyle.Fill;
                Loyalty.Show();
            }
            else
            {
                Loyalty.Activate();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (Profile == null)
            {
                Profile = new ProfilePage();
                Profile.FormClosed += Profile_Formclosed;
                Profile.MdiParent = this;
                Profile.Dock = DockStyle.Fill;
                Profile.Show();
            }
            else
            {
                Profile.Activate();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (Settings == null)
            {
                Settings = new SettingsPage();
                Settings.FormClosed += Settings_Formclosed;
                Settings.MdiParent = this;
                Settings.Dock = DockStyle.Fill;
                Settings.Show();
            }
            else
            {
                Settings.Activate();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
        private void Home_Formclosed(object sender, FormClosedEventArgs e)
        {
            Home = null;
        }
        private void Bills_Formclosed(object sender, FormClosedEventArgs e)
        {
            Bills = null;
        }
        private void Loyalty_Formclosed(object sender, FormClosedEventArgs e)
        {
            Loyalty = null;
        }
        private void Profile_Formclosed(object sender, FormClosedEventArgs e)
        {
            Profile = null;
        }
        private void Settings_Formclosed(object sender, FormClosedEventArgs e)
        {
            Settings = null;
        }

  
    }
}
