using System;
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

        }

        void LoadRoleIntoCombobox()
        {

        }

        void LoadStatusIntoCombobox()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
