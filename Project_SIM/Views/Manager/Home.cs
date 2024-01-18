using MaterialSkin.Controls;
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

namespace Project_SIM.Views.Manager
{
    public partial class Home : MaterialForm
    {
        
        private string sessionID;
        private UserInfo currentUser;
        
        private SimUser.UserData loggedUserData;

        private SimUser UserClass;
        private SimManager ManagerClass;
        private SimStore StoreClass;

        public Home()
        {
            InitializeComponent();
            ManagerClass = new SimManager();
            UserClass = new SimUser();
            StoreClass = new SimStore();
            sessionID = string.Empty;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadDashboradData();

            LblFullname.Text = loggedUserData.FullName;
            LblAcessLevel.Text += loggedUserData.AccessLevel;
        }


        private void LoadDashboradData()
        {
            //Today Date
            DateTime today = DateTime.Now;

            //Age Of the Shop 
            StoreDetails storeDetails = new StoreDetails();
            storeDetails = StoreClass.GetFirstStore();
            LblDateShopAge.Text += storeDetails.StoreStartDate.ToString("dd-MM-yyyy");
            LblShopAge.Text = StoreClass.CalculateAge(); ;

            //Total Customers
            LblDateTotalCustomers.Text += today.ToString("dd-MM-yyyy");
            LblTotalCustomers.Text = ManagerClass.GetTotalCustomers().ToString();

            //Total Products
            LblDateTotalProducts.Text += today.ToString("dd-MM-yyyy");
            LblTotalProducts.Text = ManagerClass.GetTotalProducts().ToString();

            //Total Purcheses
            LblDateTotalPercheses.Text += today.ToString("dd-MM-yyyy");
            LblTotalPurcheses.Text = ManagerClass.GetTotalTransactions().ToString();

            //Total Billed Value card
            LblDateTotalAmount.Text += today.ToString("dd-MM-yyyy");
            LblTotalBilledAmount.Text += ManagerClass.GetTotalAmountBilled().ToString();



        }

        public void SetSession(string session)
        {
            sessionID = session.Trim();
            Console.WriteLine("Session Id Set  in Home As " + session);
            currentUser = SessionManager.GetUserInfo(sessionID);
            loggedUserData = UserClass.Select(currentUser.Username.ToString());

        }

    }
}
