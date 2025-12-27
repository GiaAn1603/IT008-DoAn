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
    public partial class UC_StaffDiscount : UserControl
    {
        private List<PromotionDTO> promotionList;
        public UC_StaffDiscount()
        {
            InitializeComponent();
        }
        private void UC_StaffDiscount_Load(object sender, EventArgs e)
        {
            LoadPromotions();
        }
        void LoadPromotions()
        {
            promotionList = PromotionBUS.Instance.GetAllPromotions();
            DisplayPromotions(promotionList);
        }
        void DisplayPromotions(List<PromotionDTO> list)
        {
            dgvPromotions.Rows.Clear();

            foreach (var promo in list)
            {
                int idx = dgvPromotions.Rows.Add();
                var row = dgvPromotions.Rows[idx];

                row.Cells["colId"].Value = promo.Id;
                row.Cells["colName"].Value = promo.Code;
                row.Cells["colValue"].Value = promo.DiscountValue;
                string type = promo.DiscountType == 0
                    ? $"{promo.DiscountType}%"
                    : $"{promo.DiscountType:N0} VNĐ";
                row.Cells["colType"].Value = type;
                row.Cells["colStartDate"].Value = promo.StartDate;
                row.Cells["colEndDate"].Value = promo.EndDate;

            }
        }
        private void lblSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                DisplayPromotions(promotionList);
                return;
            }

            var filtered = promotionList.Where(p =>
                p.Code.ToLower().Contains(keyword) ||
                p.Id.ToLower().Contains(keyword)
            ).ToList();

            DisplayPromotions(filtered);
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

        
    }
}
