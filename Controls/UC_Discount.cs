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
        public UC_Discount()
        {
            InitializeComponent();
        }
        void LoadPromotions()
        {
            promotionList = PromotionBUS.Instance.GetAllPromotions();
            DisplayPromotions(promotionList);
        }
        private void UC_Discount_Load(object sender, EventArgs e)
        {
            LoadPromotions();
        }
        void DisplayPromotions(List<PromotionDTO> list)
        {
            dgvPromotions.Rows.Clear();

            foreach (var promo in list)
            {
                int idx = dgvPromotions.Rows.Add();
                var row = dgvPromotions.Rows[idx];

                row.Cells["colId"].Value = promo.Id;
                row.Cells["colname"].Value = promo.Code;
                row.Cells["colType"].Value = promo.DiscountType == 0 ? "%" : "VNĐ";
                row.Cells["colValue"].Value = promo.DiscountValue;
                row.Cells["colStartDate"].Value = promo.StartDate;
                row.Cells["colEndDate"].Value = promo.EndDate;

                DateTime now = DateTime.Now;
            }
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

            var filtered = promotionList.Where(p =>
                p.StartDate.Date >= fromDate && p.EndDate.Date <= toDate
            ).ToList();

            DisplayPromotions(filtered);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                DisplayPromotions(promotionList);
                return;
            }

            var filtered = promotionList.Where(p =>
                p.Code.ToLower().Contains(keyword)
            ).ToList();

            DisplayPromotions(filtered);
        }


        private void dgvDiscountList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPromotions.Rows[e.RowIndex];

            txtDiscountId.Text = row.Cells["colId"].Value?.ToString();
            txtDiscountName.Text = row.Cells["colName"].Value?.ToString();

            string type = row.Cells["colType"].Value?.ToString();
            cmbDiscountType.SelectedIndex = type == "%" ? 0 : 1;

            txtDiscountValue.Text = row.Cells["colValue"].Value?.ToString();
            if (DateTime.TryParse(row.Cells["colStartDate"].Value?.ToString(), out DateTime start))
                dtpStartDate.Value = start;

            if (DateTime.TryParse(row.Cells["colEndDate"].Value?.ToString(), out DateTime end))
                dtpEndDate.Value = end;

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
