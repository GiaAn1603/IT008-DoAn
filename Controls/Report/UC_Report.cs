using OHIOCF.Controls.Inventory;
using OHIOCF.Controls.Report;
using OHIOCF.Controls.Staff_Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OHIOCF.Controls
{
    public partial class UC_Report : UserControl
    {
        public UC_Report()
        {
            InitializeComponent();
            ShowControl(new UC_RevenueReport());
        }
        private void ShowControl(Control control)
        {
            pnlContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(control);
        }
        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_RevenueReport());
        }
        

        private void báoCáoBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_SalesReport());
        }
    }
}
