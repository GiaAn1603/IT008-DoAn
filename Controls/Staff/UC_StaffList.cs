using OHIOCF.BUS;
using OHIOCF.DAO;
using OHIOCF.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace OHIOCF.Controls.Staff_Inventory
{
    public partial class UC_StaffList : UserControl
    {
        BindingSource userList = new BindingSource();

        public UC_StaffList()
        {
            InitializeComponent();
            this.Load += UC_StaffList_Load;
            dgvStaffData.AutoGenerateColumns = false;
            dgvStaffData.DataSource = userList;
        }

        private void UC_StaffList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            LoadRoleIntoCombobox();
            LoadStatusIntoCombobox();
            LoadListUser();
        }

        void LoadListUser()
        {
            userList.DataSource = UserBUS.Instance.GetListUser();
        }

        void LoadRoleIntoCombobox()
        {
            cmbRole.DataSource = RoleDAO.Instance.GetListRole();
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "Id";
        }

        void LoadStatusIntoCombobox()
        {
            var statusList = new List<dynamic> {
                new { Value = true, Name = "Hoạt động" },
                new { Value = false, Name = "Ngưng hoạt động" }
            };

            cmbStatus.DataSource = statusList;
            cmbStatus.DisplayMember = "Name";
            cmbStatus.ValueMember = "Value";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập Tài khoản và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserDTO newUser = new UserDTO()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                FullName = txtFullname.Text,
                RoleId = cmbRole.SelectedValue.ToString(),
                IsActive = (bool)cmbStatus.SelectedValue
            };

            if (UserBUS.Instance.InsertUser(newUser))
            {
                MessageBox.Show("Thêm thành công!");
                LoadListUser();
                btnClear_Click(null, null);
            }
            else
            {
                MessageBox.Show("Thất bại! Tên tài khoản có thể đã tồn tại.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = dgvStaffData.CurrentRow.Cells["Id"].Value.ToString();

            UserDTO user = new UserDTO()
            {
                Id = id,
                Username = txtUsername.Text,
                FullName = txtFullname.Text,
                RoleName = cmbRole.SelectedValue.ToString(),
                IsActive = (bool)cmbStatus.SelectedValue
            };

            if (!string.IsNullOrEmpty(txtPassword.Text))
                user.Password = txtPassword.Text;
            else
                user.Password = null;

            if (UserBUS.Instance.UpdateUser(user))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadListUser();
                btnClear_Click(null, null);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStaffData.CurrentRow == null) return;

            string id = dgvStaffData.CurrentRow.Cells["Id"].Value.ToString();
            string name = dgvStaffData.CurrentRow.Cells["Username"].Value?.ToString() ?? "N/A";

            if (MessageBox.Show($"Bạn chắc muốn xóa [{name}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (UserBUS.Instance.DeleteUser("", id))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadListUser();
                    btnClear_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Không thể xóa!");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullname.Text = "";
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            txtUsername.Focus();
        }

        private void dgvStaffData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStaffData.CurrentRow != null && !dgvStaffData.CurrentRow.IsNewRow)
            {
                var row = dgvStaffData.CurrentRow;

                txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
                txtFullname.Text = row.Cells["FullName"].Value?.ToString() ?? "";
                txtPassword.Text = row.Cells["Password"].Value?.ToString() ?? "";

                if (row.Cells["RoleName"].Value != null)
                    cmbRole.SelectedValue = row.Cells["RoleName"].Value.ToString();

                if (row.Cells["IsActive"].Value != null)
                {
                    bool isActive;
                    if (bool.TryParse(row.Cells["IsActive"].Value.ToString(), out isActive))
                        cmbStatus.SelectedValue = isActive;
                }
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvStaffData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Mở hộp thoại chọn nơi lưu file
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "Xuất danh sách nhân viên";
                saveDialog.FileName = $"DanhSachNhanVien_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Nhân viên");

                        // tiêu đề cột
                        for (int i = 0; i < dgvStaffData.Columns.Count; i++)
                        {
                            // Bỏ qua cột ẩn
                            if (!dgvStaffData.Columns[i].Visible) continue;

                            worksheet.Cell(1, i + 1).Value = dgvStaffData.Columns[i].HeaderText;
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                            worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                        }

                        // Thêm dữ liệu
                        int excelRow = 2;
                        foreach (DataGridViewRow row in dgvStaffData.Rows)
                        {
                            if (row.IsNewRow) continue;

                            int excelCol = 1;
                            for (int i = 0; i < dgvStaffData.Columns.Count; i++)
                            {
                                if (!dgvStaffData.Columns[i].Visible) continue;

                                var cellValue = row.Cells[i].Value?.ToString() ?? "";

                                if (dgvStaffData.Columns[i].DataPropertyName == "IsActive")
                                {
                                    bool isActive;
                                    if (bool.TryParse(cellValue, out isActive))
                                    {
                                        cellValue = isActive ? "Hoạt động" : "Ngưng hoạt động";
                                    }
                                }

                                worksheet.Cell(excelRow, excelCol).Value = cellValue;
                                excelCol++;
                            }
                            excelRow++;
                        }

                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveDialog.FileName);
                    }


                    if (MessageBox.Show("Xuất file thành công, bạn có muốn mở file vừa xuất?", "Xác nhận",
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
    }
}
