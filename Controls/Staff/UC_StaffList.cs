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
            if (e.RowIndex < 0) return;

            var row = dgvStaffData.Rows[e.RowIndex];

            txtUsername.Text = row.Cells["Username"].Value?.ToString();
            txtFullname.Text = row.Cells["FullName"].Value?.ToString();
            txtPassword.Clear();

            if (row.Cells["RoleId"].Value != null)
                cmbRole.SelectedValue = row.Cells["RoleId"].Value.ToString();

            if (row.Cells["IsActive"].Value != null &&
                bool.TryParse(row.Cells["IsActive"].Value.ToString(), out bool active))
            {
                cmbStatus.SelectedValue = active;
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {

        }

        

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

    }
}
