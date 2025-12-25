using OHIOCF.BUS;
using OHIOCF.DAO;
using OHIOCF.DTO;
using OHIOCF.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OHIOCF
{
    public partial class Form1 : Form
    {
        private Size _baseSize;
        private Dictionary<Control, float> _initialFontSizes = new Dictionary<Control, float>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Resize += Form1_Resize;
            this.FormClosing += Form1_FormClosing;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsername.Text.Trim();
            string enteredPassword = txtPassword.Text;

            UserDTO user = UserBUS.Instance.Login(enteredUsername, enteredPassword);

            if (user != null)
            {
                RoleDTO role = RoleDAO.Instance.GetRoleById(user.RoleId);

                if (role != null)
                {
                    if (role.RoleName.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Xin chào Quản trị viên: {user.FullName}", "Thông báo");

                        formAdmin fAdmin = new formAdmin();
                        fAdmin.Show();
                        this.Hide();
                    }
                    else if (role.RoleName.Equals("Staff", StringComparison.OrdinalIgnoreCase) ||
                             role.RoleName.Equals("NhanVien", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Xin chào Nhân viên: {user.FullName}", "Thông báo");

                        formStaff fStaff = new formStaff();
                        fStaff.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản của bạn chưa được phân quyền hợp lệ.", "Lỗi quyền hạn");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin chức vụ (Role)!", "Lỗi dữ liệu");
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _baseSize = this.Size;
            CollectInitialFontSizes(this);
            ScaleFormComponents(this);
        }

        private void ScaleFormComponents(Control control)
        {
            if (_baseSize.Width == 0 || _baseSize.Height == 0) return;

            if (_initialFontSizes.TryGetValue(control, out float baseFontSize))
            {
                float scaleFactor = (float)this.Width / _baseSize.Width;
                float newFontSize = baseFontSize * scaleFactor;

                if (newFontSize > 4.0f)
                {
                    control.Font = new Font(control.Font.FontFamily, newFontSize, control.Font.Style);
                }
            }

            foreach (Control child in control.Controls)
            {
                ScaleFormComponents(child);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Normal)
            {
                ScaleFormComponents(this);
            }
        }

        private void CollectInitialFontSizes(Control control)
        {
            if (!_initialFontSizes.ContainsKey(control))
            {
                _initialFontSizes.Add(control, control.Font.Size);
            }

            foreach (Control child in control.Controls)
            {
                CollectInitialFontSizes(child);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát chương trình?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                e.Cancel = (result == DialogResult.No);

                if (!e.Cancel)
                {
                    Application.ExitThread();
                }
            }
        }
    }
}
