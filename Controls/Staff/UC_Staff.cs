using OHIOCF.Controls.Staff;
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
    public partial class UC_Staff : UserControl
    {
        public UC_Staff()
        {
            InitializeComponent();
            ShowControl(new UC_StaffList());
        }

        private void ShowControl(Control control)
        {
            pnlContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(control);
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_StaffList());
        }

        private void xếpCaLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_Shift());
        }

        private void quảnLýĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_AdminClockIn());
        }
    }
}
