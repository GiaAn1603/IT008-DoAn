using OHIOCF.BUS;
using OHIOCF.DAO;
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
    public partial class UC_Inventory : UserControl
    {
        private List<InventoryDTO> inventoryList;
        private List<IngredientDTO> ingredientList;
        private InventoryDTO selectedInventory;
        private IngredientDTO selectedIngredient;
        public class InventoryView
        {
            public string IngredientId { get; set; }
            public string IngredientName { get; set; }
            public string Unit { get; set; }
            public double StockQuantity { get; set; }
            public double MinThreshold { get; set; }
        }

        public UC_Inventory()
        {
            InitializeComponent();
            this.Load += UC_Inventory1_Load;
        }

        private void UC_Inventory1_Load(object sender, EventArgs e)
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
                                select new InventoryView
                                {
                                    IngredientId = inv.IngredientId,
                                    IngredientName = ing.Name,
                                    Unit = ing.Unit,
                                    StockQuantity = inv.StockQuantity,
                                    MinThreshold = inv.MinThreshold
                                };
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.DataSource = inventoryView.ToList();
            ClearInputs();
        }
        void ClearInputs()
        {
            txtIngredientId.Clear();
            txtIngredientName.Clear();
            cmbUnit.SelectedIndex = -1;
            txtStockQuantity.Clear();
            selectedInventory = null;
        }
        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvInventory.Rows[e.RowIndex];
            var inventoryView = row.DataBoundItem as InventoryView;

            if (inventoryView != null)
            {
                // Tìm inventory và ingredient tương ứng
                selectedInventory = inventoryList.FirstOrDefault(i => i.IngredientId == inventoryView.IngredientId);
                selectedIngredient = ingredientList.FirstOrDefault(i => i.Id == inventoryView.IngredientId);

                txtIngredientId.Text = inventoryView.IngredientId;
                txtIngredientName.Text = inventoryView.IngredientName;
                cmbUnit.Text = inventoryView.Unit;
                txtStockQuantity.Text = inventoryView.StockQuantity.ToString();
                txtMinThreshold.Text = inventoryView.MinThreshold.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtStockQuantity.Text, out double newQuantity) || newQuantity < 0)
                return;

            if (!double.TryParse(txtMinThreshold.Text, out double min))
                return;

            if (selectedInventory == null) return;

            double currentStock = selectedInventory.StockQuantity;
            double difference = newQuantity - currentStock;

            IngredientBUS.Instance.EditIngredient(new IngredientDTO
            {
                Id = txtIngredientId.Text,
                Name = txtIngredientName.Text.Trim(),
                Unit = cmbUnit.Text
            });

            bool success = difference >= 0
                ? InventoryBUS.Instance.ImportStock(txtIngredientId.Text, difference, min)
                : InventoryBUS.Instance.DeductStock(txtIngredientId.Text, Math.Abs(difference), min);

            if (success)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedInventory == null) return;

            InventoryBUS.Instance.DeductStock(
                selectedInventory.IngredientId,
                selectedInventory.StockQuantity
            );

            IngredientBUS.Instance.RemoveIngredient(selectedInventory.IngredientId);

            LoadData();
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
                                select new InventoryView
                                {
                                    IngredientId = inv.IngredientId,
                                    IngredientName = ing.Name,
                                    Unit = ing.Unit,
                                    StockQuantity = inv.StockQuantity,
                                    MinThreshold = inv.MinThreshold
                                };

            dgvInventory.DataSource = null;
            dgvInventory.DataSource = inventoryView.ToList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = txtIngredientName.Text.Trim();
            string unit = cmbUnit.Text.Trim();
            string quantityText = txtStockQuantity.Text.Trim();
            string minText = txtMinThreshold.Text.Trim();


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(unit) ||
                !double.TryParse(quantityText, out double quantity) || quantity < 0 ||
                !double.TryParse(minText, out double minThreshold) || minThreshold < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin nguyên liệu.");
                return;
            }

            IngredientDTO newIngredient = new IngredientDTO
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Unit = unit
            };

            if (InventoryBUS.Instance.InitStock(newIngredient, quantity, minThreshold))
            {
                MessageBox.Show("Thêm nguyên liệu và tạo kho thành công!");
                LoadData();

                ClearInputs();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm mới.");
            }
        }
    }
}
