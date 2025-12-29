using OHIOCF.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OHIOCF.Forms
{
    public partial class formStaff : Form
    {
        private Button _currentActiveButton;
        private Color _defaultColor = Color.FromArgb(248, 215, 32);
        private Color _selectedColor = Color.FromArgb(247, 242, 80);

        public formStaff()
        {
            InitializeComponent();
        }

        private void ActivateButton(object senderButton)
        {
            if (_currentActiveButton != null)
            {
                _currentActiveButton.BackColor = _defaultColor;
                _currentActiveButton.ForeColor = Color.Black;
                _currentActiveButton.Font = new Font(_currentActiveButton.Font, FontStyle.Regular);
            }
            Button clickedButton = (Button)senderButton;
            clickedButton.BackColor = _selectedColor;
            clickedButton.ForeColor = Color.FromArgb(30, 84, 48);
            clickedButton.Font = new Font(clickedButton.Font, FontStyle.Bold);
            _currentActiveButton = clickedButton;
        }

        private void formStaff_Load(object sender, EventArgs e)
        {
            LoadUserControl(typeof(UC_Dashboard));

            if (Form1.loggedInUser != null)
            {
                lblUsername.Text = Form1.loggedInUser.Username;
            }
        }

        private void LoadUserControl(Type ucType)
        {
            panel3.Controls.Clear();
            UserControl uc = (UserControl)Activator.CreateInstance(ucType);
            uc.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(typeof(UC_Dashboard));
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 formLogin = new Form1();
                this.Close();
                formLogin.Show();
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(typeof(UC_Customers));
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(typeof(UC_StaffInventory));
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(typeof(UC_Sale));
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(typeof(UC_StaffClockIn));
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(typeof(UC_StaffDiscount));
        }

        private void formStaff_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát chương trình?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                e.Cancel = (result == DialogResult.No);
            }
        }
    }
}
