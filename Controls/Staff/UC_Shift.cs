using OHIOCF.BUS;
using OHIOCF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;


namespace OHIOCF.Controls.Staff_Inventory
{
    public partial class UC_Shift : UserControl
    {
        private List<UserDTO> userList;
        private DateTime currentMonday;

        public UC_Shift()
        {
            InitializeComponent();
            this.Load += UC_Shift_Load;
            dgvScheduleData.Resize += dgvScheduleData_Resize;
        }

        private void UC_Shift_Load(object sender, EventArgs e)
        {
            LoadData();

            this.BeginInvoke(new Action(() =>
            {
                FitRowsToGrid();
            }));
        }

        void LoadData()
        {
            // Lấy thứ 2 đầu tuần từ BUS
            currentMonday = ScheduleBUS.Instance.GetMondayOfWeek(DateTime.Now);

            SetupFixedCaColumn();
            LoadUserList();
            LoadScheduleData();
        }

        void SetupFixedCaColumn()
        {
            if (dgvScheduleData.Rows.Count < 6)
            {
                dgvScheduleData.Rows.Clear();
                dgvScheduleData.Rows.Add(6);
            }

            dgvScheduleData.Rows[0].Cells[0].Value = "Sáng (5h-12h)";
            dgvScheduleData.Rows[2].Cells[0].Value = "Chiều (12h-17h)";
            dgvScheduleData.Rows[4].Cells[0].Value = "Tối (17h-22h)";
        }

        private void FitRowsToGrid()
        {
            if (dgvScheduleData.Rows.Count == 0) return;

            int headerHeight = dgvScheduleData.ColumnHeadersHeight;
            int totalHeight = dgvScheduleData.ClientSize.Height;
            int rowHeight = (totalHeight - headerHeight) / dgvScheduleData.Rows.Count;

            foreach (DataGridViewRow row in dgvScheduleData.Rows)
                row.Height = rowHeight;

        }

        private void dgvScheduleData_Resize(object sender, EventArgs e)
        {
            FitRowsToGrid();
        }

        void LoadUserList()
        {
            userList = UserBUS.Instance.GetListUser();

            for (int i = 1; i < dgvScheduleData.Columns.Count; i++)
            {
                if (dgvScheduleData.Columns[i] is DataGridViewComboBoxColumn comboCol)
                {
                    comboCol.DataSource = null;
                    comboCol.DataSource = userList;
                    comboCol.DisplayMember = "FullName";
                    comboCol.ValueMember = "Id";

                    comboCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    comboCol.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        void LoadScheduleData()
        {
            // Clear grid
            foreach (DataGridViewRow row in dgvScheduleData.Rows)
            {
                for (int col = 1; col < dgvScheduleData.Columns.Count; col++)
                {
                    row.Cells[col].Value = null;
                }
            }

            // Gọi BUS lấy lịch đã được nhóm sẵn
            var groupedSchedules = ScheduleBUS.Instance.GetWeekSchedulesGrouped(currentMonday);

            // Hiển thị lên grid
            for (int dayIndex = 0; dayIndex < 7; dayIndex++)
            {
                DateTime date = currentMonday.AddDays(dayIndex);
                int colIndex = dayIndex + 1;

                if (!groupedSchedules.ContainsKey(date)) continue;

                var daySchedules = groupedSchedules[date];

                // Duyệt qua 3 ca (sáng, chiều, tối)
                for (int shift = 0; shift < 3; shift++)
                {
                    if (!daySchedules.ContainsKey(shift)) continue;

                    var shiftSchedules = daySchedules[shift];
                    int baseRow = shift * 2;

                    // Hiển thị tối đa 2 nhân viên mỗi ca
                    for (int i = 0; i < Math.Min(2, shiftSchedules.Count); i++)
                    {
                        var schedule = shiftSchedules[i];
                        var user = userList.FirstOrDefault(u => u.Id == schedule.UserId);

                        if (user != null)
                        {
                            dgvScheduleData.Rows[baseRow + i]
                                .Cells[colIndex].Value = user.Id;
                        }

                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Xác nhận
                var result = MessageBox.Show(
                    "Lưu lịch?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                // Đọc lịch từ grid và tạo danh sách ScheduleDTO
                List<ScheduleDTO> newSchedules = new List<ScheduleDTO>();

                for (int row = 0; row < dgvScheduleData.Rows.Count; row++)
                {
                    // Xác định ca (0, 1, 2)
                    int shiftIndex = row / 2;

                    for (int col = 1; col < dgvScheduleData.Columns.Count; col++)
                    {
                        var cellValue = dgvScheduleData.Rows[row].Cells[col].Value;
                        if (cellValue == null) continue;

                        string userId = cellValue.ToString();
                        var user = userList.FirstOrDefault(u => u.Id == userId);
                        if (user == null) continue;

                        // Xác định ngày (thứ 2 = col 1, thứ 3 = col 2,...)
                        int dayIndex = col - 1;
                        DateTime scheduleDate = currentMonday.AddDays(dayIndex);

                        // Lấy thời gian ca từ BUS
                        var (startTime, endTime) = ScheduleBUS.Instance.GetShiftTime(scheduleDate, shiftIndex);

                        newSchedules.Add(new ScheduleDTO
                        {
                            UserId = user.Id,
                            StartTime = startTime,
                            EndTime = endTime,
                            Note = ""
                        });
                    }
                }

                // lưu
                var (successCount, failCount, errors) = ScheduleBUS.Instance.SaveWeekSchedules(
                    currentMonday,
                    newSchedules);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu lịch: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

    }
}