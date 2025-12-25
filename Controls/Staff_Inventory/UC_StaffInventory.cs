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
    public partial class UC_StaffInventory : UserControl
    {
        public UC_StaffInventory()
        {
            InitializeComponent();
            ShowControl(new UC_StaffInventory1());
        }
        private void ShowControl(Control control)
        {
            pnlContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(control);
        }
        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_StaffInventory1());
        }

        private void phiếuNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_StaffStockReceipt());
        }

    }
}
