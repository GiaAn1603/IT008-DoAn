using OHIOCF.BUS;
using OHIOCF.DTO;
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
        private List<ReportDTO> _reportList;
        private BindingSource reportSource = new BindingSource();

        public UC_Report()
        {
            InitializeComponent();
            this.Load += UC_Report_Load;
            dgvReport.AutoGenerateColumns = false;
            dgvReport.DataSource = reportSource;
        }

        private void UC_Report_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;
            LoadReport();
        }

        private void LoadReport()
        {
            DateTime from = dtpFromDate.Value.Date;
            DateTime to = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);  // Adjust để bao quát full ngày đến 23:59:59

            if (from > to)
            {
                MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _reportList = ReportBUS.Instance.GetRevenue(from, to);

                reportSource.DataSource = null;
                reportSource.DataSource = _reportList;
                reportSource.ResetBindings(false);

                UpdateTotal(_reportList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void UpdateTotal(List<ReportDTO> list)
        {
            lblTotal.Text = list.Sum(x => x.TotalAmount).ToString("N0");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchKeyword.Text.Trim().ToLower();
            var filtered = string.IsNullOrEmpty(keyword)
                ? _reportList
                : _reportList.Where(x =>
                       (x.CustomerName ?? "").ToLower().Contains(keyword) ||
                       (x.StaffName ?? "").ToLower().Contains(keyword)
                  ).ToList();
            reportSource.DataSource = null;
            reportSource.DataSource = filtered;
            reportSource.ResetBindings(false);
            UpdateTotal(filtered);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Implement export Excel tương tự UC_StaffList nếu cần
        }
    }
}