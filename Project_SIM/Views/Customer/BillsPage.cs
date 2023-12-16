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
    public partial class BillsPage : Form
    {
        public BillsPage()
        {
            InitializeComponent();
            SetupListViewColumns();
        }
        private void Screen_Resize(object sender, EventArgs e)
        {
            // Adjust column widths when the form is resized
            SetupListViewColumns();
        }

        private void SetupListViewColumns()
        {
            // Specify the ratios for each column
            double[] columnRatios = { 0.05, 0.2, 0.1, 0.2, 0.2, 0.25 };

            // Calculate total width
            int totalWidth = listViewBills.Width;

            // Adjust column widths based on ratios
            for (int i = 0; i < listViewBills.Columns.Count; i++)
            {
                listViewBills.Columns[i].Width = (int)(totalWidth * columnRatios[i]);
            }
        }
       
    }

    
}
