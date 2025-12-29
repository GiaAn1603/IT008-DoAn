using OHIOCF.BUS;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace OHIOCF.Controls
{
    public partial class UC_Dashboard : UserControl
    {
        private readonly CultureInfo culture = new CultureInfo("vi-VN");

        public UC_Dashboard()
        {
            InitializeComponent();
            this.Load += UC_Dashboard_Load;
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
            LoadBackground();

        }

        private void LoadDashboardData()
        {
            int staffCount = UserBUS.Instance.GetStaffCount();
            lblStaffCount.Text = staffCount.ToString();

            int invoiceCount = OrderBUS.Instance.GetInvoiceCount();
            lblInvoiceCount.Text = invoiceCount.ToString();

            decimal totalRevenue = OrderBUS.Instance.GetTotalRevenue();
            lblTotalRevenueValue.Text = totalRevenue.ToString("N0", culture) + " đ";

            decimal dailyRevenue = OrderBUS.Instance.GetTodayRevenue();
            lblDailyRevenueValue.Text = dailyRevenue.ToString("N0", culture) + " đ";
        }

        private void btnChangeBackground_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh nền";
                ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = ofd.FileName;

                    pbBackground.Image = Image.FromFile(imagePath);
                    pbBackground.SizeMode = PictureBoxSizeMode.StretchImage;

                    Properties.Settings.Default.BackgroundPath = imagePath;
                    Properties.Settings.Default.Save();
                }
            }
        }
        private void LoadBackground()
        {
            string path = Properties.Settings.Default.BackgroundPath;

            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                pbBackground.Image = Image.FromFile(path);
                pbBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
