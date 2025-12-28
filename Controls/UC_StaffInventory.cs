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
    public partial class UC_StaffInventory : UserControl
    {
        private List<InventoryDTO> inventoryList;
        private List<IngredientDTO> ingredientList;
        private InventoryDTO selectedInventory;
        private IngredientDTO selectedIngredient;

        public class StaffInventoryView
        {
            public string colMaNVL { get; set; }
            public string colTenNVL { get; set; }
            public string colDVT { get; set; }
            public double colTon { get; set; }
            public double colMin { get; set; }
        }

        public UC_StaffInventory()
        {
            InitializeComponent();
            this.Load += UC_StaffInventory1_Load;
        }

        private void UC_StaffInventory1_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadUnitComboBox();
        }
        void LoadUnitComboBox()
        {
            cmbUnit.Items.Clear();
            cmbUnit.Items.AddRange(new string[] { "kg", "g", "lít", "ml", "cái", "gói", "hộp" });
        }

        void LoadData()
        {
            inventoryList = InventoryBUS.Instance.GetInventoryStatus();
            ingredientList = IngredientBUS.Instance.GetAll();

            var inventoryView = from inv in inventoryList
                                join ing in ingredientList on inv.IngredientId equals ing.Id
                                select new StaffInventoryView
                                {
                                    colMaNVL = inv.IngredientId,
                                    colTenNVL = ing.Name,
                                    colDVT = ing.Unit,
                                    colTon = inv.StockQuantity,
                                    colMin = inv.MinThreshold
                                };
            dgvStaffInventory.AutoGenerateColumns = false;
            dgvStaffInventory.DataSource = inventoryView.ToList();
            ClearInputs();
        }

        void ClearInputs()
        {
            txtNVLCode.Clear();
            txtNVLName.Clear();
            cmbUnit.SelectedIndex = -1;
            txtQuantity.Clear();
            selectedInventory = null;
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvStaffInventory.Rows[e.RowIndex];
            var inventoryView = row.DataBoundItem as StaffInventoryView;

            if (inventoryView != null)
            {
                // Tìm inventory và ingredient tương ứng
                selectedInventory = inventoryList.FirstOrDefault(i => i.IngredientId == inventoryView.colMaNVL);
                selectedIngredient = ingredientList.FirstOrDefault(i => i.Id == inventoryView.colMaNVL);

                txtNVLCode.Text = inventoryView.colMaNVL;
                txtNVLName.Text = inventoryView.colTenNVL;
                cmbUnit.Text = inventoryView.colDVT;
                txtQuantity.Text = inventoryView.colTon.ToString();
                txtMin.Text = inventoryView.colMin.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            // Tìm trong cả 2 list
            var filteredInventory = inventoryList.Where(inv =>
            {
                var ingredient = ingredientList.FirstOrDefault(ing => ing.Id == inv.IngredientId);
                return ingredient != null &&
                       (ingredient.Name.ToLower().Contains(keyword) ||
                        inv.IngredientId.ToLower().Contains(keyword));
            }).ToList();

            var inventoryView = from inv in filteredInventory
                                join ing in ingredientList on inv.IngredientId equals ing.Id
                                select new StaffInventoryView
                                {
                                    colMaNVL = inv.IngredientId,
                                    colTenNVL = ing.Name,
                                    colDVT = ing.Unit,
                                    colTon = inv.StockQuantity,
                                    colMin = inv.MinThreshold
                                };

            dgvStaffInventory.DataSource = null;
            dgvStaffInventory.DataSource = inventoryView.ToList();
        }
    }
}
