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
    public partial class UC_StaffClockIn : UserControl
    {
        private string currentUserId;
        private List<UserDTO> userList;
        private DateTime currentMonday;
        private List<AuditLogDTO> GetTodayLogs()
        {
            return AuditLogBUS.Instance.GetAllLogs()
                .Where(l => l.UserId == currentUserId
                         && l.LogTime.Date == DateTime.Today
                         && (l.Action == "ClockIn" || l.Action == "ClockOut"))
                .OrderBy(l => l.LogTime)
                .ToList();
        }

        public UC_StaffClockIn()
        {
            InitializeComponent();
            this.Load += UC_StaffClockIn_Load;
            dgvWeekSchedule.Resize += dgvWeekSchedule_Resize;
        }

        private void UC_StaffClockIn_Load(object sender, EventArgs e)
        {
            currentUserId = Form1.loggedInUser.Id;
            timerClock.Start();
            UpdateClockTime();
            LoadData();
            LoadTodayClockStatus();
            this.BeginInvoke(new Action(() =>
            {
                FitRowsToGrid();
            }));
            dgvWeekSchedule.EnableHeadersVisualStyles = false;
            dgvWeekSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvWeekSchedule.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

        }
        private void LoadData()
        {
            currentMonday = ScheduleBUS.Instance.GetMondayOfWeek(DateTime.Now);

            SetupFixedCaColumn();
            LoadUserList();
            LoadScheduleData();
        }

        private void LoadUserList()
        {
            userList = UserBUS.Instance.GetListUser();
        }
        

        void SetupFixedCaColumn()
        {
            if (dgvWeekSchedule.Rows.Count < 6)
            {
                dgvWeekSchedule.Rows.Clear();
                dgvWeekSchedule.Rows.Add(6);
            }

            dgvWeekSchedule.Rows[0].Cells[0].Value = "Sáng (5h-12h)";
            dgvWeekSchedule.Rows[2].Cells[0].Value = "Chiều (12h-17h)";
            dgvWeekSchedule.Rows[4].Cells[0].Value = "Tối (17h-22h)";
        }

        private void ClearGridCells()
        {
            foreach (DataGridViewRow row in dgvWeekSchedule.Rows)
                for (int col = 1; col < dgvWeekSchedule.Columns.Count; col++)
                    row.Cells[col].Value = null;
        }
        void LoadScheduleData()
        {
            ClearGridCells();

            var groupedSchedules =
                ScheduleBUS.Instance.GetWeekSchedulesGrouped(currentMonday);

            for (int dayIndex = 0; dayIndex < 7; dayIndex++)
            {
                DateTime date = currentMonday.AddDays(dayIndex);
                int colIndex = dayIndex + 1;

                if (!groupedSchedules.ContainsKey(date)) continue;

                var daySchedules = groupedSchedules[date];

                for (int shift = 0; shift < 3; shift++)
                {
                    if (!daySchedules.ContainsKey(shift)) continue;

                    int baseRow = shift * 2;
                    var shiftSchedules = daySchedules[shift];

                    for (int i = 0; i < Math.Min(2, shiftSchedules.Count); i++)
                    {
                        var schedule = shiftSchedules[i];
                        var user = userList.FirstOrDefault(u => u.Id == schedule.UserId);

                        if (user != null)
                        {
                            dgvWeekSchedule
                                .Rows[baseRow + i]
                                .Cells[colIndex]
                                .Value = user.FullName;
                        }
                    }
                }
            }
        }
        private void LoadTodayClockStatus()
        {
            var today = DateTime.Today;

            var logs = AuditLogBUS.Instance.GetAllLogs()
                .Where(l => l.UserId == currentUserId
                         && (l.Action == "ClockIn" || l.Action == "ClockOut")
                         && l.LogTime.Date == today)
                .OrderByDescending(l => l.LogTime)
                .ToList();

            if (!logs.Any())
            {
                // CHƯA CHẤM CÔNG
                lblStatus.Text = "Chưa chấm công";
                lblStatus.ForeColor = Color.Gray;
                lblLastActionTime.Text = "Chưa có dữ liệu chấm công hôm nay";
                return;
            }

            var lastLog = logs.First();

            if (lastLog.Action == "ClockIn")
            {
                lblStatus.Text = "Đã chấm công";
                lblStatus.ForeColor = Color.Green;
                lblLastActionTime.Text =
                    $"Lần gần nhất: Chấm công lúc {lastLog.LogTime:HH:mm} ngày {lastLog.LogTime:dd/MM/yyyy}";
            }
            else if (lastLog.Action == "ClockOut")
            {
                lblStatus.Text = "Đã kết thúc ca";
                lblStatus.ForeColor = Color.Red;
                lblLastActionTime.Text =
                    $"Lần gần nhất: Kết thúc ca lúc {lastLog.LogTime:HH:mm} ngày {lastLog.LogTime:dd/MM/yyyy}";
            }
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            var todayLogs = GetTodayLogs();

            bool hasClockIn = todayLogs.Any(l => l.Action == "ClockIn");
            bool hasClockOut = todayLogs.Any(l => l.Action == "ClockOut");

            if (!hasClockIn)
            {
                MessageBox.Show(
                    "Bạn chưa chấm công hôm nay.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (hasClockOut)
            {
                MessageBox.Show(
                    "Bạn đã kết thúc ca hôm nay rồi.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            AuditLogBUS.Instance.ClockOut(currentUserId);

            DateTime now = DateTime.Now;
            lblStatus.Text = "Đã kết thúc ca";
            lblStatus.ForeColor = Color.Red;
            lblLastActionTime.Text =
                $"Lần gần nhất: Kết thúc ca lúc {now:HH:mm} ngày {now:dd/MM/yyyy}";
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            var todayLogs = GetTodayLogs();

            // Đã clock in rồi
            if (todayLogs.Any(l => l.Action == "ClockIn"))
            {
                MessageBox.Show(
                    "Bạn đã chấm công hôm nay rồi.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            AuditLogBUS.Instance.ClockIn(currentUserId);

            DateTime now = DateTime.Now;
            lblStatus.Text = "Đã chấm công";
            lblStatus.ForeColor = Color.Green;
            lblLastActionTime.Text =
                $"Lần gần nhất: Chấm công lúc {now:HH:mm} ngày {now:dd/MM/yyyy}";
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            UpdateClockTime();
        }
        private void UpdateClockTime()
        {
            lblCurrentTime.Text = DateTime.Now.ToString("hh:mm tt"); // hh: 12h, HH: 24h, tt: AM/PM

            lblCurrentDate.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
        }
        private void FitRowsToGrid()
        {
            if (dgvWeekSchedule.Rows.Count == 0) return;

            int headerHeight = dgvWeekSchedule.ColumnHeadersHeight;
            int totalHeight = dgvWeekSchedule.ClientSize.Height;
            int rowHeight = (totalHeight - headerHeight) / dgvWeekSchedule.Rows.Count;

            foreach (DataGridViewRow row in dgvWeekSchedule.Rows)
                row.Height = rowHeight;
        }

        private void dgvWeekSchedule_Resize(object sender, EventArgs e)
        {
            FitRowsToGrid();
        }
    }
}
