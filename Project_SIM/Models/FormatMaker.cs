using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SIM.Models
{
    public static class FormatMaker
    {
        public static void BlockOutTextFeild(TextBox Name)
        {
            Name.ReadOnly = true;
            Name.Cursor = Cursors.No;
        }

        public static void EnableTextFeild(TextBox Name)
        {
            Name.ReadOnly = false;
            Name.Cursor = Cursors.Arrow;
        }

        public static void SetupListViewColumns(ListView listView, double[] columnRatios)
        {
            // Calculate total width
            int totalWidth = listView.Width;

            // Adjust column widths based on ratios
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                listView.Columns[i].Width = (int)(totalWidth * columnRatios[i]);
            }
        }

        public static void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
