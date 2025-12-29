using DocumentFormat.OpenXml.VariantTypes;
using OHIOCF.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OHIOCF.Controls.Staff
{
    public partial class UC_AdminClockIn : UserControl
    {
        public class ClockInViewModel
        {
            public string UserId { get; set; }
            public string FullName { get; set; }
            public DateTime? ClockInTime { get; set; }
            public DateTime? ClockOutTime { get; set; }
        }


        public UC_AdminClockIn()
        {
            InitializeComponent();
            this.Load += UC_Admin_ClockIn_Load;
        }

        private void UC_Admin_ClockIn_Load(object sender, EventArgs e)
        {
            DateTime monday = GetMondayOfCurrentWeek();
            DateTime sunday = GetSundayOfCurrentWeek();
            dtpFromDate.Value = monday;
            dtpToDate.Value = sunday;

            LoadClockInData(monday, sunday);

        }
        private void LoadClockInData(DateTime fromDate, DateTime toDate)
        {
            fromDate = fromDate.Date;
            toDate = toDate.Date.AddDays(1).AddTicks(-1);

            var logs = AuditLogBUS.Instance.GetAllLogs();
            var users = UserBUS.Instance.GetListUser();

            var clockLogs = logs
                .Where(l => (l.Action == "ClockIn" || l.Action == "ClockOut")
                         && l.LogTime >= fromDate
                         && l.LogTime <= toDate)
                .OrderBy(l => l.LogTime)
                .ToList();

            var result = new List<ClockInViewModel>();

            foreach (var group in clockLogs.GroupBy(l => new { l.UserId, Day = l.LogTime.Date }))
            {
                var user = users.FirstOrDefault(u => u.Id == group.Key.UserId);

                var clockIn = group
                    .Where(l => l.Action == "ClockIn")
                    .OrderBy(l => l.LogTime)
                    .FirstOrDefault();

                if (clockIn == null)
                    continue; // không có clockin thì bỏ

                var clockOut = group
                    .Where(l => l.Action == "ClockOut")
                    .OrderByDescending(l => l.LogTime)
                    .FirstOrDefault();

                result.Add(new ClockInViewModel
                {
                    UserId = group.Key.UserId,
                    FullName = user?.FullName,
                    ClockInTime = clockIn.LogTime,
                    ClockOutTime = clockOut?.LogTime // NULL nếu chưa clockout
                });
            }

        }

        private DateTime GetMondayOfCurrentWeek()
        {
            DateTime today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            return today.AddDays(-diff);
        }

        private DateTime GetSundayOfCurrentWeek()
        {
            return GetMondayOfCurrentWeek().AddDays(6);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
            {
                MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc",
                    "Lỗi lọc",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            LoadClockInData(dtpFromDate.Value, dtpToDate.Value);
        }
    }
}
