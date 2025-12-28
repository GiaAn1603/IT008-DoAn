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
        public UC_StaffClockIn() : this(null)
        {
        }

        public UC_StaffClockIn(string userId = null)
        {
            InitializeComponent();
            currentUserId = userId;

            this.Load += UC_StaffClockIn_Load;
            dgvWeekSchedule.Resize += dgvWeekSchedule_Resize;
        }

        private void UC_StaffClockIn_Load(object sender, EventArgs e)
        {
            timerClock.Start();
            UpdateClockTime();
            LoadData();
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

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblLastActionTime.Text = $"Lần gần nhất: Kết thúc ca lúc {now:HH:mm} ngày {now:dd/MM/yyyy}";
            lblStatus.Text = "Đã kết thúc ca";
            lblStatus.ForeColor = Color.Red;
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblLastActionTime.Text = $"Lần gần nhất: Chấm công lúc {now:HH:mm} ngày {now:dd/MM/yyyy}";
            lblStatus.Text = "Đã chấm công";
            lblStatus.ForeColor = Color.Green;
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
