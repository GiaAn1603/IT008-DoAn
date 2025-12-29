using OHIOCF.BUS;
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
    }
}
