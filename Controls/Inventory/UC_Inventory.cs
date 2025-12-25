using OHIOCF.Controls.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OHIOCF.Controls
{
    public partial class UC_Inventory : UserControl
    {
        public UC_Inventory()
        {
            InitializeComponent();
            ShowControl(new UC_Inventory1());
        }

        private void ShowControl(Control control)
        {
            pnlContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(control);
        }

        private void xemTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_Inventory1());
        }

        private void tạoPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_StockReceipt());
        }

        private void lịchSửNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(new UC_ReceiptHistory());
        }
    }
       
}
