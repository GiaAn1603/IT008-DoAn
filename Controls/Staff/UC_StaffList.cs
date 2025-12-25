using OHIOCF.BUS;
using OHIOCF.DAO;
using OHIOCF.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OHIOCF.Controls.Staff_Inventory
{
    public partial class UC_StaffList : UserControl
    {
        BindingSource userList = new BindingSource();

        public UC_StaffList()
        {
            InitializeComponent();
            this.Load += UC_StaffList_Load;
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
            dgvStaffData.AutoGenerateColumns = false;
            userList.DataSource = UserBUS.Instance.GetListUser();

            if (dgvStaffData.Columns["Username"] != null) dgvStaffData.Columns["Username"].HeaderText = "Tài khoản";
            if (dgvStaffData.Columns["FullName"] != null) dgvStaffData.Columns["FullName"].HeaderText = "Họ tên";
            if (dgvStaffData.Columns["IsActive"] != null) dgvStaffData.Columns["IsActive"].HeaderText = "Trạng thái";

            if (dgvStaffData.Columns["Password"] != null) dgvStaffData.Columns["Password"].HeaderText = "Mật khẩu (Mã hóa)";

            if (dgvStaffData.Columns["Id"] != null) dgvStaffData.Columns["Id"].HeaderText = "Mã NV";
            if (dgvStaffData.Columns["RoleId"] != null) dgvStaffData.Columns["RoleId"].HeaderText = "Mã Vai trò";
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
            if (dgvStaffData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }

            string id = dgvStaffData.CurrentRow.Cells["Id"].Value.ToString();

            UserDTO user = new UserDTO()
            {
                Id = id,
                Username = txtUsername.Text,
                FullName = txtFullname.Text,
                RoleId = cmbRole.SelectedValue.ToString(),
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

                if (row.Cells["RoleId"].Value != null)
                    cmbRole.SelectedValue = row.Cells["RoleId"].Value.ToString();

                if (row.Cells["IsActive"].Value != null)
                {
                    bool isActive;
                    if (bool.TryParse(row.Cells["IsActive"].Value.ToString(), out isActive))
                        cmbStatus.SelectedValue = isActive;
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
