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
    public partial class UC_Discount : UserControl
    {
        private List<PromotionDTO> promotionList;
        public class PromotionView
        {
            public string Id { get; set; }
            public string Code { get; set; }
            public decimal DiscountValue { get; set; }
            public int DiscountType { get; set; }
            public string DiscountDisplay { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public UC_Discount()
        {
            InitializeComponent();
        }
        private void UC_Discount_Load(object sender, EventArgs e)
        {
            cmbDiscountType.Items.Clear();
            cmbDiscountType.Items.Add("Phần trăm (%)");
            cmbDiscountType.Items.Add("Giá cố định (VNĐ)");
            cmbDiscountType.SelectedIndex = 0;
            LoadPromotions();
        }
        void LoadPromotions()
        {
            promotionList = PromotionBUS.Instance.GetAllPromotions();

            var view = promotionList.Select(p => new PromotionView
            {
                Id = p.Id,
                Code = p.Code,
                DiscountValue = p.DiscountValue,
                DiscountType = p.DiscountType,
                DiscountDisplay = p.DiscountType == 0
                    ? $"{p.DiscountValue}%"
                    : $"{p.DiscountValue:N0} VNĐ",
                StartDate = p.StartDate,
                EndDate = p.EndDate
            }).ToList();

            dgvPromotions.AutoGenerateColumns = false;
            dgvPromotions.DataSource = view;
        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiscountName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khuyến mãi");
                return;
            }

            if (!decimal.TryParse(txtDiscountValue.Text, out decimal value) || value <= 0)
            {
                MessageBox.Show("Giá trị khuyến mãi không hợp lệ");
                return;
            }

            int discountType = cmbDiscountType.SelectedIndex; // 0: %, 1: VNĐ

            PromotionDTO newPromo = new PromotionDTO
            {
                Code = txtDiscountName.Text.Trim(),
                DiscountValue = value,
                DiscountType = discountType,
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value
            };

            if (PromotionBUS.Instance.AddPromotion(newPromo))
            {
                MessageBox.Show("Thêm khuyến mãi thành công");
                LoadPromotions();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Thêm khuyến mãi thất bại");
            }
        }

        private void btnDeleteDiscount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiscountId.Text))
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa");
                return;
            }

            var confirm = MessageBox.Show("Xác nhận xóa khuyến mãi này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (PromotionBUS.Instance.RemovePromotion(txtDiscountId.Text))
                {
                    MessageBox.Show("Xóa thành công");
                    LoadPromotions();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }
        
        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            var filtered = promotionList
                .Where(p =>
                    p.StartDate.Date <= toDate &&
                    p.EndDate.Date >= fromDate
                )
                .Select(p => new PromotionView
                {
                    Id = p.Id,
                    Code = p.Code,
                    DiscountValue = p.DiscountValue,
                    DiscountType = p.DiscountType,
                    DiscountDisplay = p.DiscountType == 0
                        ? $"{p.DiscountValue}%"
                        : $"{p.DiscountValue:N0} VNĐ",
                    StartDate = p.StartDate,
                    EndDate = p.EndDate
                })
                .ToList();

            dgvPromotions.DataSource = filtered;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim().ToLower();

            var filtered = promotionList
                .Where(p =>
                    p.Code.ToLower().Contains(keyword) ||
                    p.Id.ToLower().Contains(keyword))
                .Select(p => new PromotionView
                {
                    Id = p.Id,
                    Code = p.Code,
                    DiscountValue = p.DiscountValue,
                    DiscountType = p.DiscountType,
                    DiscountDisplay = p.DiscountType == 0
                        ? $"{p.DiscountValue}%"
                        : $"{p.DiscountValue:N0} VNĐ",
                    StartDate = p.StartDate,
                    EndDate = p.EndDate
                })
                .ToList();

            dgvPromotions.DataSource = filtered;
        }

        private void dgvDiscountList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPromotions.Rows[e.RowIndex];

            txtDiscountId.Text = row.Cells["Id"].Value?.ToString();
            txtDiscountName.Text = row.Cells["Code"].Value?.ToString();

            txtDiscountValue.Text = row.Cells["DiscountValue"].Value?.ToString();

            cmbDiscountType.SelectedIndex =
                    Convert.ToInt32(row.Cells["DiscountType"].Value);

            dtpStartDate.Value = Convert.ToDateTime(row.Cells["StartDate"].Value);
            dtpEndDate.Value = Convert.ToDateTime(row.Cells["EndDate"].Value);

        }
        void ClearInputs()
        {
            txtDiscountId.Clear();
            txtDiscountName.Clear();
            cmbDiscountType.SelectedIndex = 0;
            txtDiscountValue.Clear();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddDays(30);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        
    }
}
