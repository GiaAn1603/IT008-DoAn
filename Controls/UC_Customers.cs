using DocumentFormat.OpenXml.Office2010.ExcelAc;
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
    public partial class UC_Customers : UserControl
    {
        private List<CustomerDTO> customerList;
        private BindingSource customerSource = new BindingSource();

        public UC_Customers()
        {
            InitializeComponent();
            this.Load += UC_Customers_Load;

            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = customerSource;
        }

        private void UC_Customers_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }
        private void LoadCustomers()
        {
            customerList = CustomerBUS.Instance.GetAllCustomers();
            customerSource.DataSource = customerList;
        }

        void DisplayCustomers(List<CustomerDTO> list)
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = list;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                customerSource.DataSource = customerList;
                return;
            }

            var filtered = customerList.Where(c =>
                (!string.IsNullOrEmpty(c.FullName) &&
                 c.FullName.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(c.Phone) &&
                 c.Phone.Contains(keyword))
            ).ToList();

            customerSource.DataSource = filtered;
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            var filtered = customerList;

            DisplayCustomers(filtered);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var customer = new CustomerDTO
            {
                FullName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Points = 0,
                Rank = "Đồng"
            };

            if (CustomerBUS.Instance.AddCustomer(customer))
            {
                LoadCustomers();
                ClearInputs();
                MessageBox.Show("Đã thêm");
            }
            else
            {
                MessageBox.Show("SĐT đã tồn tại");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (customerSource.Current == null)
            {
                MessageBox.Show("Chọn khách hàng");
                return;
            }

            var customer = customerSource.Current as CustomerDTO;
            if (customer == null) return;

            if (MessageBox.Show("Xóa khách hàng?", "Xác nhận",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            if (CustomerBUS.Instance.RemoveCustomer(customer.Id))
            {
                LoadCustomers();
                ClearInputs();
                MessageBox.Show("Đã xóa");
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (customerSource.Current is CustomerDTO customer)
            {
                txtName.Text = customer.FullName ?? "";
                txtPhone.Text = customer.Phone ?? "";
            }
        }
        void ClearInputs()
        {
            txtName.Clear();
            txtPhone.Clear();
        }
        bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nhập tên khách hàng");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Nhập số điện thoại");
                return false;
            }

            return true;
        }

    }
}
