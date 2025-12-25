using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace OHIOCF.Controls
{
    public partial class UC_Sale1 : UserControl
    {
        private UC_SizeSelect sizeSelectControl;
        private Panel currentSelectedPanel;
        public UC_Sale1()
        {
            InitializeComponent();
            this.Click += UC_Sale1_Click;
        }

        private void pbProductPicture_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel == null)
                clickedPanel = (sender as PictureBox)?.Parent as Panel;
            if (clickedPanel == null) return;

            // Nếu click vào cùng panel đang hiển thị thì ẩn đi
            if (currentSelectedPanel == clickedPanel && sizeSelectControl?.Visible == true)
            {
                HideSizeSelect();
                return;
            }

            currentSelectedPanel = clickedPanel;

            // Tạo hoặc hiển thị UC_SizeSelect
            if (sizeSelectControl == null)
            {
                sizeSelectControl = new UC_SizeSelect();
                sizeSelectControl.Size = new Size(80, 180);
                sizeSelectControl.AutoSize = false;
                sizeSelectControl.Dock = DockStyle.None;
                sizeSelectControl.Anchor = AnchorStyles.None;

                // Đăng ký event khi chọn size
                sizeSelectControl.SizeSelected += SizeSelectControl_SizeSelected;

                this.Controls.Add(sizeSelectControl);
                sizeSelectControl.BringToFront();
            }

            Point panelLocationOnForm = this.PointToClient(
                clickedPanel.Parent.PointToScreen(clickedPanel.Location)
            );

            sizeSelectControl.Location = new Point(
                panelLocationOnForm.X + clickedPanel.Width,
                panelLocationOnForm.Y
            );

            sizeSelectControl.Visible = true;
        }

        private void SizeSelectControl_SizeSelected(object sender, string selectedSize)
        {
            HideSizeSelect();
        }

        private void HideSizeSelect()
        {
            if (sizeSelectControl != null)
            {
                sizeSelectControl.Visible = false;
                currentSelectedPanel = null;
            }
        }
        private void UC_Sale1_Click(object sender, EventArgs e)
        {
            HideSizeSelect();
        }
        private void btnCheckout_Click(object sender, EventArgs e)
        {
           
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
