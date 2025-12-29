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
        public class PromotionView
        {
            public string Id { get; set; }
            public string Code { get; set; }
            public decimal DiscountValue { get; set; }
            public string DiscountType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

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

            var view = promotionList.Select(p => new PromotionView
            {
                Id = p.Id,
                Code = p.Code,
                DiscountValue = p.DiscountValue,
                DiscountType = p.DiscountType == 0
                    ? $"{p.DiscountValue}%"
                    : $"{p.DiscountValue:N0} VNĐ",
                StartDate = p.StartDate,
                EndDate = p.EndDate
            }).ToList();

            dgvPromotions.AutoGenerateColumns = false;
            dgvPromotions.DataSource = view;
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            var filtered = promotionList
                .Where(p =>
                    p.Code.ToLower().Contains(keyword) ||
                    p.Id.ToLower().Contains(keyword))
                .Select(p => new PromotionView
                {
                    Id = p.Id,
                    Code = p.Code,
                    DiscountValue = p.DiscountValue,
                    DiscountType = p.DiscountType == 0
                        ? $"{p.DiscountValue}%"
                        : $"{p.DiscountValue:N0} VNĐ",
                    StartDate = p.StartDate,
                    EndDate = p.EndDate
                })
                .ToList();

            dgvPromotions.DataSource = filtered;
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
                    DiscountType = p.DiscountType == 0
                        ? $"{p.DiscountValue}%"
                        : $"{p.DiscountValue:N0} VNĐ",
                    StartDate = p.StartDate,
                    EndDate = p.EndDate
                })
                .ToList();

            dgvPromotions.DataSource = filtered;
        }



    }
}
