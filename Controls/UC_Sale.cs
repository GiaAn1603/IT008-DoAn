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
    public partial class UC_Sale : UserControl
    {
        public event EventHandler<Type> LoadUserControlRequested;
        public UC_Sale()
        {
            InitializeComponent();
        }

        private void btnAddNewOrder_Click(object sender, EventArgs e)
        {
            LoadUserControlRequested?.Invoke(this, typeof(UC_Sale1));
        }

        
    }
}
