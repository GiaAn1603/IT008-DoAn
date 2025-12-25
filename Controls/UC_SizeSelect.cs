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
    public partial class UC_SizeSelect : UserControl
    {
        public event EventHandler<string> SizeSelected;

        public UC_SizeSelect()
        {
            InitializeComponent();

            // Mặc định chọn size M
            rdoSizeM.Checked = true;
        }

        private void rdoSizeS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSizeS.Checked)
            {
                OnSizeSelected("S");
            }
        }

        private void rdoSizeM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSizeM.Checked)
            {
                OnSizeSelected("M");
            }
        }

        private void rdoSizeL_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSizeL.Checked)
            {
                OnSizeSelected("L");
            }
        }

        // Phương thức kích hoạt event
        protected virtual void OnSizeSelected(string size)
        {
            SizeSelected?.Invoke(this, size);
        }
    }
}
