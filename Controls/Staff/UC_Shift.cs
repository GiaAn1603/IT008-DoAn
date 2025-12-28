using ClosedXML.Excel;
using OHIOCF.BUS;
using OHIOCF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
        }

        void LoadData()
        {
            // Lấy thứ 2 đầu tuần từ BUS
            currentMonday = ScheduleBUS.Instance.GetMondayOfWeek(DateTime.Now);

            SetupFixedCaColumn();
            LoadUserList();
            LoadScheduleData();
            FitRowsToGrid();
        }

        void SetupFixedCaColumn()
        {
            dgvScheduleData.Rows.Clear();
            dgvScheduleData.Rows.Add(6);

            dgvScheduleData.Rows[0].Cells[0].Value = "Sáng (5h-12h)";
            dgvScheduleData.Rows[2].Cells[0].Value = "Chiều (12h-17h)";
            dgvScheduleData.Rows[4].Cells[0].Value = "Tối (17h-22h)";

            foreach (DataGridViewRow row in dgvScheduleData.Rows)
            {
                row.DefaultCellStyle = dgvScheduleData.DefaultCellStyle;
            }
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
            // Gọi BUS để lấy danh sách nhân viên
            userList = UserBUS.Instance.GetListUser();
            var names = userList.Select(u => u.FullName).ToList();

            // Bind vào ComboBox columns
            for (int i = 1; i < dgvScheduleData.Columns.Count; i++)
            {
                if (dgvScheduleData.Columns[i] is DataGridViewComboBoxColumn comboCol)
                {
                    comboCol.DataSource = null;
                    comboCol.ValueType = typeof(string);
                    comboCol.DataSource = names;
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
                            dgvScheduleData.Rows[baseRow + i].Cells[colIndex].Value = user.FullName;
                        }
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvScheduleData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "Xuất lịch làm việc";
                saveDialog.FileName = $"LichLamViec_{currentMonday:yyyyMMdd}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Lịch làm việc");

                        // Tiêu đề
                        worksheet.Cell(1, 1).Value = $"LỊCH LÀM VIỆC TUẦN {currentMonday:dd/MM/yyyy} - {currentMonday.AddDays(6):dd/MM/yyyy}";
                        worksheet.Range(1, 1, 1, dgvScheduleData.Columns.Count).Merge();
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Font.FontSize = 14;
                        worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // Tiêu đề cột (row 2)
                        for (int i = 0; i < dgvScheduleData.Columns.Count; i++)
                        {
                            if (!dgvScheduleData.Columns[i].Visible) continue;

                            worksheet.Cell(2, i + 1).Value = dgvScheduleData.Columns[i].HeaderText;
                            worksheet.Cell(2, i + 1).Style.Font.Bold = true;
                            worksheet.Cell(2, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                            worksheet.Cell(2, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }

                        // Dữ liệu (từ row 3)
                        int excelRow = 3;
                        foreach (DataGridViewRow row in dgvScheduleData.Rows)
                        {
                            if (row.IsNewRow) continue;

                            for (int i = 0; i < dgvScheduleData.Columns.Count; i++)
                            {
                                if (!dgvScheduleData.Columns[i].Visible) continue;

                                var cellValue = row.Cells[i].Value?.ToString() ?? "";
                                worksheet.Cell(excelRow, i + 1).Value = cellValue;
                            }
                            excelRow++;
                        }

                        // Merge cells cho các ca
                        worksheet.Range(3, 1, 4, 1).Merge(); // Ca sáng
                        worksheet.Range(5, 1, 6, 1).Merge(); // Ca chiều
                        worksheet.Range(7, 1, 8, 1).Merge(); // Ca tối

                        // Format
                        worksheet.Columns().AdjustToContents();
                        worksheet.Range(2, 1, excelRow - 1, dgvScheduleData.Columns.Count)
                            .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        worksheet.Range(2, 1, excelRow - 1, dgvScheduleData.Columns.Count)
                            .Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                        // Border
                        worksheet.Range(2, 1, excelRow - 1, dgvScheduleData.Columns.Count)
                            .Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Range(2, 1, excelRow - 1, dgvScheduleData.Columns.Count)
                            .Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        workbook.SaveAs(saveDialog.FileName);
                    }

                    if (MessageBox.Show("Xuất file thành công! Bạn có muốn mở file?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        var cellValue = dgvScheduleData.Rows[row].Cells[col].Value?.ToString();
                        if (string.IsNullOrEmpty(cellValue)) continue;

                        // Tìm user
                        var user = userList.FirstOrDefault(u => u.FullName == cellValue);
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
    }
}