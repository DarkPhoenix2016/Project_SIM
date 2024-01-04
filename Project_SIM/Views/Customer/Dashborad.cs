﻿using MaterialSkin.Controls;
using MySqlX.XDevAPI;
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
    public partial class Dashborad : MaterialForm
    {
        private string sessionID = string.Empty;
        private UserInfo currentUser;
        private SimUser simUserClass;
        private SimUser.UserData loggedUserData;
        private SimCustomer simCustomerClass;
        private SimCustomer.Customer CustomerData;
        private bool isClosing = false;



        HomePage Home;
        BillsPage Bills;
        LoyaltyPage Loyalty;
        ProfilePage Profile;
        SettingsPage Settings;

        public Dashborad()
        {
            InitializeComponent();
            simCustomerClass = new SimCustomer();
            simUserClass = new SimUser();
        }

        public void SetSession(string session)
        {
            sessionID = session.Trim();
            Console.WriteLine(session);
            currentUser = SessionManager.GetUserInfo(sessionID);
            loggedUserData = simUserClass.Select(currentUser.Username.ToString());
            CustomerData = simCustomerClass.Select(loggedUserData.UserID.ToString());

        }
        private void HandleLogout()
        {
            // Prompt the user with a yes/no question
            DialogResult result = MessageBox.Show("Are you sure you want to Logout?", "Confirm log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // If the user clicks "Yes," end the session
                SessionManager.EndSession(sessionID);

                // Close the current form (Dashboard) and open the login screen
                OpenScreen openScreen = new OpenScreen();
                openScreen.Show();
                isClosing = true;
                this.Close();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (Home == null)
            {
                Home = new HomePage();
                Home.SetCustomerData(CustomerData);
                Home.FormClosed += Home_Formclosed;
                Home.MdiParent = this;
                Home.Dock = DockStyle.Fill;
                Home.Show();
            }
            else
            {
                Home.Activate();


                if (Bills != null)
                {
                    Bills.Close();
                }
                if (Loyalty != null)
                {
                    Loyalty.Close();
                }
                if (Profile != null)
                {
                    Profile.Close();
                }
                if (Settings != null)
                {
                    Settings.Close();
                }


            }
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            if (Bills == null)
            {
                Bills = new BillsPage();
                Bills.SetCustomerData(CustomerData);
                Bills.FormClosed += Bills_Formclosed;
                Bills.MdiParent = this;
                Bills.Dock = DockStyle.Fill;
                Bills.Show();
            }
            else
            {
                Bills.Activate();

                if (Home != null)
                {
                    Home.Close();
                }

                if (Loyalty != null)
                {
                    Loyalty.Close();
                }
                if (Profile != null)
                {
                    Profile.Close();
                }
                if (Settings != null)
                {
                    Settings.Close();
                }
            }
        }

        private void btnLoyalty_Click(object sender, EventArgs e)
        {
            if (Loyalty == null)
            {
                Loyalty = new LoyaltyPage();
                Loyalty.SetCustomerData(CustomerData);
                Loyalty.FormClosed += Loyalty_Formclosed;
                Loyalty.MdiParent = this;
                Loyalty.Dock = DockStyle.Fill;
                Loyalty.Show();
            }
            else
            {
                Loyalty.Activate();

                if (Home != null)
                {
                    Home.Close();
                }
                if (Bills != null)
                {
                    Bills.Close();
                }

                if (Profile != null)
                {
                    Profile.Close();
                }
                if (Settings != null)
                {
                    Settings.Close();
                }
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

                if (Home != null)
                {
                    Home.Close();
                }
                if (Bills != null)
                {
                    Bills.Close();
                }
                if (Loyalty != null)
                {
                    Loyalty.Close();
                }
                if (Settings != null)
                {
                    Settings.Close();
                }
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

                if (Home != null)
                {
                    Home.Close();
                }
                if (Bills != null)
                {
                    Bills.Close();
                }
                if (Loyalty != null)
                {
                    Loyalty.Close();
                }
                if (Profile != null)
                {
                    Profile.Close();
                }

            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Call the common method to handle session ending and application closing
            HandleLogout();
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

        private void Dashborad_Load(object sender, EventArgs e)
        {
            Home = new HomePage();
            Home.SetCustomerData(CustomerData);
            Home.FormClosed += Home_Formclosed;
            Home.MdiParent = this;
            Home.Dock = DockStyle.Fill;
            Home.Show();

        }
        private void Dashborad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                // Handle other closing scenarios, e.g., logout button
                DialogResult result = MessageBox.Show("Are you sure you want to Exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // If the user confirms logout, close the dashboard form
                    isClosing = true;
                    e.Cancel = false;
                    // The X button was clicked, close the entire application
                    Application.Exit();
                }
                else
                {
                    // If the user cancels logout, prevent the dashboard form from closing
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        
    }
}
