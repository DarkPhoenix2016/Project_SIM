using MaterialSkin.Controls;
using Project_SIM.Views.ReportView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SIM.Views.StoreKeeper
{
    public partial class Reports : MaterialForm
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void btnReportPayments_Click(object sender, EventArgs e)
        {
            BillTransactions billTransactions = new BillTransactions();
            billTransactions.Show();
        }
    }
}
