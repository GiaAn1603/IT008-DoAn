using OHIOCF.BUS;
using OHIOCF.DAO;
using OHIOCF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace OHIOCF.Controls
{
    public partial class UC_Sale1 : UserControl
    {
        private CafeTableDTO currentTable;
        private List<ProductDTO> allProducts;
        private List<CategoryDTO> categoryList;
        private List<PromotionDTO> promotionList;

        private List<BillItem> currentBill = new List<BillItem>();
        private Dictionary<string, int> originalQuantities = new Dictionary<string, int>();

        private ProductDTO productWaitSize;
        private UC_SizeSelect sizeSelectControl;
        private Panel currentSelectedPanel;
        private CultureInfo culture = new CultureInfo("vi-VN");

        private string currentUserId = "admin";
        private bool isLoaded = false;

        public class BillItem
        {
            public string ProductId { get; set; }
            public string colTenMon { get; set; }
            public string colSize { get; set; }
            public int colSoLuong { get; set; }
            public decimal colDonGia { get; set; }
            public decimal ThanhTien => colSoLuong * colDonGia;
        }

        public UC_Sale1()
        {
            InitializeComponent();
            this.Load += UC_Sale1_Load;
            this.Click += UC_Sale1_Click;

            if (cmbDiscount != null)
                cmbDiscount.SelectedIndexChanged += cmbDiscount_SelectedIndexChanged;
        }

        private void UC_Sale1_Load(object sender, EventArgs e)
        {
            InitGrid();
            LoadCategories();
            LoadPromotions();
            LoadProducts();

            isLoaded = true;

            if (currentTable != null)
            {
                SetCurrentTable(currentTable);
            }
        }

        private void LoadPromotions()
        {
            var allPromos = PromotionBUS.Instance.GetAllPromotions();
            DateTime now = DateTime.Now;

            promotionList = allPromos.Where(p => p.StartDate <= now && p.EndDate >= now).ToList();

            PromotionDTO noPromo = new PromotionDTO
            {
                Id = "",
                Code = "Không áp dụng",
                DiscountValue = 0,
                DiscountType = 0
            };
            promotionList.Insert(0, noPromo);

            cmbDiscount.DataSource = promotionList;
            cmbDiscount.DisplayMember = "Code";
            cmbDiscount.ValueMember = "Id";
        }

        private void cmbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalDisplay();
        }

        private void UpdateTotalDisplay()
        {
            decimal subTotal = currentBill.Sum(x => x.ThanhTien);

            decimal discountAmount = 0;

            if (cmbDiscount.SelectedItem is PromotionDTO selectedPromo && !string.IsNullOrEmpty(selectedPromo.Id))
            {
                if (selectedPromo.DiscountType == 0) // 0 = Phần trăm (%)
                {
                    discountAmount = subTotal * (selectedPromo.DiscountValue / 100);
                }
                else // 1 = Tiền mặt (VNĐ)
                {
                    discountAmount = selectedPromo.DiscountValue;
                }
            }

            decimal finalTotal = subTotal - discountAmount;
            if (finalTotal < 0) finalTotal = 0;

            if (lblSubTotal != null) lblSubTotal.Text = subTotal.ToString("N0", culture) + " đ";
            if (lblDiscount != null) lblDiscount.Text = discountAmount.ToString("N0", culture) + " đ";

            if (label6 != null)
            {
                label6.Text = finalTotal.ToString("N0", culture) + " đ";
                label6.Tag = finalTotal;
            }
        }

        public void SetCurrentTable(CafeTableDTO table)
        {
            this.currentTable = table;

            if (!isLoaded) return;

            if (currentTable != null)
            {
                lblCurrentTable.Text = table.TableName;

                if (table.Status == 1)
                {
                    LoadExistingOrder(table.Id);
                }
                else
                {
                    currentBill.Clear();
                    originalQuantities.Clear();
                    if (cmbDiscount.Items.Count > 0) cmbDiscount.SelectedIndex = 0;
                    RefreshBillGrid();
                }
            }
        }

        private void LoadExistingOrder(string tableId)
        {
            currentBill.Clear();
            originalQuantities.Clear();

            OrderDTO order = OrderBUS.Instance.GetUncheckOrderByTable(tableId);

            if (order != null && !string.IsNullOrEmpty(order.Id))
            {
                if (!string.IsNullOrEmpty(order.PromotionId))
                {
                    PromotionDTO promo = PromotionBUS.Instance.GetPromotionById(order.PromotionId);

                    if (promo != null)
                    {
                        cmbDiscount.SelectedValue = promo.Id;
                    }
                }
                else
                {
                    if (cmbDiscount.Items.Count > 0) cmbDiscount.SelectedIndex = 0;
                }

                List<OrderDetailDTO> details = OrderDetailBUS.Instance.GetDetails(order.Id);
                foreach (var item in details)
                {
                    var product = ProductBUS.Instance.GetProductById(item.ProductId);
                    string pName = product != null ? product.Name : "Món " + item.ProductId;

                    currentBill.Add(new BillItem
                    {
                        ProductId = item.ProductId,
                        colTenMon = pName,
                        colSize = item.ProductSizeId,
                        colSoLuong = item.Quantity,
                        colDonGia = item.PriceAtTime
                    });

                    string key = $"{item.ProductId}_{item.ProductSizeId}";
                    if (originalQuantities.ContainsKey(key)) originalQuantities[key] += item.Quantity;
                    else originalQuantities.Add(key, item.Quantity);
                }
            }

            RefreshBillGrid();
        }

        private void InitGrid()
        {
            dgvOrderItems.AutoGenerateColumns = false;
            dgvOrderItems.Columns.Clear();
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "colTenMon", HeaderText = "Tên món", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "colSize", HeaderText = "Size", Width = 40 });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "colSoLuong", HeaderText = "SL", Width = 35 });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "colDonGia", HeaderText = "Đơn giá", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", FormatProvider = culture } });
            dgvOrderItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTien", HeaderText = "T.Tiền", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", FormatProvider = culture, Font = new Font("Segoe UI", 9, FontStyle.Bold) } });
            dgvOrderItems.RowHeadersVisible = false;
            dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItems.DefaultCellStyle.Font = new Font("Segoe UI", 9);
        }

        private void LoadCategories()
        {
            categoryList = CategoryBUS.Instance.GetAllCategories();
            SetupButton(tsbAll, "All");
            SetupButton(tsbCoffee, "Cà phê");
            SetupButton(tsbTea, "Trà");
            SetupButton(tsbCake, "Bánh");
            SetupButton(tsbOther, "Khác");
            tsType_Resize(null, null);
        }

        private void SetupButton(ToolStripButton btn, string catName)
        {
            if (btn == null) return;
            if (catName == "All") btn.Tag = "All";
            else
            {
                var cat = categoryList.FirstOrDefault(c => c.Name == catName);
                btn.Tag = cat != null ? cat.Id : "All";
            }
            btn.Click -= tsbCategory_Click;
            btn.Click += tsbCategory_Click;
        }

        private void tsbCategory_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null && btn.Tag != null) LoadProducts(btn.Tag.ToString());
        }

        private void LoadProducts(string categoryId = "All")
        {
            if (categoryId == "All") allProducts = ProductBUS.Instance.SearchProduct("");
            else allProducts = ProductBUS.Instance.GetProductsByCategory(categoryId);
            RenderMenu();
        }

        private void RenderMenu(string keyword = "")
        {
            flpMenuItems.Controls.Clear();
            flpMenuItems.SuspendLayout();

            var filtered = allProducts.Where(p => p.Name.ToLower().Contains(keyword.ToLower()) && p.IsAvailable).ToList();

            foreach (var prod in filtered)
            {
                var sizes = ProductSizeBUS.Instance.GetSizesByProduct(prod.Id);
                var defaultSize = sizes.FirstOrDefault(s => s.SizeName == "S") ?? sizes.FirstOrDefault();
                decimal price = prod.BasePrice + (defaultSize?.PriceAdjustment ?? 0);

                Panel pnl = new Panel { Size = new Size(140, 190), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Tag = prod };

                PictureBox pb = new PictureBox { Size = new Size(120, 120), Location = new Point(10, 10), SizeMode = PictureBoxSizeMode.Zoom, Tag = prod };
                try
                {
                    if (!string.IsNullOrEmpty(prod.Image)) pb.Image = Image.FromFile(prod.Image);
                    else pb.BackColor = Color.LightGray;
                }
                catch { pb.BackColor = Color.LightGray; }
                pb.Click += Product_Click;

                Label lblName = new Label { Text = prod.Name, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.DarkSlateGray, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(130, 40), Location = new Point(5, 135), Tag = prod };
                lblName.Click += Product_Click;

                Label lblPrice = new Label { Text = price.ToString("N0", culture) + " đ", Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.OrangeRed, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(130, 20), Location = new Point(5, 170), Tag = prod };
                lblPrice.Click += Product_Click;

                pnl.Controls.Add(pb); pnl.Controls.Add(lblName); pnl.Controls.Add(lblPrice);
                flpMenuItems.Controls.Add(pnl);
            }
            flpMenuItems.ResumeLayout();
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e) => RenderMenu(txtProductSearch.Text.Trim());

        private void Product_Click(object sender, EventArgs e)
        {
            Control c = sender as Control;
            ProductDTO prod = c.Tag as ProductDTO;
            Panel parent = c as Panel ?? c.Parent as Panel;
            ShowSizePopup(prod, parent);
        }

        private void ShowSizePopup(ProductDTO product, Panel anchor)
        {
            productWaitSize = product;
            if (currentSelectedPanel == anchor && sizeSelectControl != null && sizeSelectControl.Visible) { HideSizeSelect(); return; }
            currentSelectedPanel = anchor;

            if (sizeSelectControl == null)
            {
                sizeSelectControl = new UC_SizeSelect { Size = new Size(100, 180), AutoSize = false };
                sizeSelectControl.SizeSelected += (s, size) => { AddToBill(productWaitSize, size); HideSizeSelect(); };
                this.Controls.Add(sizeSelectControl);
                sizeSelectControl.BringToFront();
            }

            Point loc = this.PointToClient(anchor.Parent.PointToScreen(anchor.Location));
            int x = loc.X + anchor.Width;
            if (x + sizeSelectControl.Width > this.Width) x = loc.X - sizeSelectControl.Width;
            sizeSelectControl.Location = new Point(x, loc.Y);
            sizeSelectControl.Visible = true;
        }

        private void HideSizeSelect() { if (sizeSelectControl != null) sizeSelectControl.Visible = false; currentSelectedPanel = null; }
        private void UC_Sale1_Click(object sender, EventArgs e) => HideSizeSelect();

        private void AddToBill(ProductDTO product, string sizeName)
        {
            decimal price = product.BasePrice;
            var sizes = ProductSizeBUS.Instance.GetSizesByProduct(product.Id);
            var sObj = sizes.FirstOrDefault(s => s.SizeName == sizeName);
            if (sObj != null) price += sObj.PriceAdjustment;

            var existing = currentBill.FirstOrDefault(x => x.ProductId == product.Id && x.colSize == sizeName);
            if (existing != null) existing.colSoLuong++;
            else currentBill.Add(new BillItem { ProductId = product.Id, colTenMon = product.Name, colSize = sizeName, colSoLuong = 1, colDonGia = price });

            RefreshBillGrid();
        }

        private void RefreshBillGrid()
        {
            dgvOrderItems.DataSource = null;
            dgvOrderItems.DataSource = currentBill;
            UpdateTotalDisplay();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (currentTable == null) return;
            if (currentBill.Count == 0) return;

            try
            {
                string orderId = OrderBUS.Instance.CreateOrder(currentTable.Id.ToString(), currentUserId);
                if (string.IsNullOrEmpty(orderId)) return;

                foreach (var item in currentBill)
                {
                    string key = $"{item.ProductId}_{item.colSize}";
                    int oldQty = originalQuantities.ContainsKey(key) ? originalQuantities[key] : 0;
                    int newQty = item.colSoLuong;
                    int qtyToAdd = newQty - oldQty;

                    if (qtyToAdd > 0)
                    {
                        OrderDetailDTO newDetail = new OrderDetailDTO
                        {
                            Id = Guid.NewGuid().ToString(),
                            OrderId = orderId,
                            ProductId = item.ProductId,
                            ProductSizeId = item.colSize,
                            Quantity = qtyToAdd,
                            PriceAtTime = item.colDonGia
                        };
                        OrderDetailBUS.Instance.AddDishToOrder(newDetail);
                    }
                }

                string selectedPromoId = null;
                if (cmbDiscount.SelectedValue != null && cmbDiscount.SelectedValue.ToString() != "")
                {
                    selectedPromoId = cmbDiscount.SelectedValue.ToString();
                }

                decimal subTotal = currentBill.Sum(x => x.ThanhTien);

                decimal discountAmount = 0;
                if (cmbDiscount.SelectedItem is PromotionDTO selectedPromo && !string.IsNullOrEmpty(selectedPromoId))
                {
                    if (selectedPromo.DiscountType == 0) // %
                        discountAmount = subTotal * (selectedPromo.DiscountValue / 100);
                    else // Tiền mặt
                        discountAmount = selectedPromo.DiscountValue;
                }

                decimal finalTotal = subTotal - discountAmount;
                if (finalTotal < 0) finalTotal = 0;

                OrderBUS.Instance.UpdateOrderInfo(orderId, finalTotal, selectedPromoId);

                CafeTableBUS.Instance.SwitchStatus(currentTable.Id.ToString(), 1);
                MessageBox.Show("Đã lưu đơn và khuyến mãi!", "Thành công");
                ReturnToTableMap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (currentTable == null) return;

            OrderDTO order = OrderBUS.Instance.GetUncheckOrderByTable(currentTable.Id.ToString());
            if (order != null && !string.IsNullOrEmpty(order.Id))
            {
                decimal finalAmount = 0;
                if (label6.Tag != null)
                    finalAmount = Convert.ToDecimal(label6.Tag);
                else
                    finalAmount = currentBill.Sum(x => x.ThanhTien);

                string promotionId = null;
                if (cmbDiscount.SelectedValue != null && cmbDiscount.SelectedValue.ToString() != "")
                {
                    promotionId = cmbDiscount.SelectedValue.ToString();
                }

                if (MessageBox.Show($"Thanh toán cho bàn {currentTable.TableName}?\nTổng tiền cần trả: {finalAmount.ToString("N0", culture)} đ",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool success = OrderBUS.Instance.PayOrder(order.Id, finalAmount, null, promotionId);

                    if (success)
                    {
                        CafeTableBUS.Instance.SwitchStatus(currentTable.Id.ToString(), 0);

                        MessageBox.Show("Thanh toán thành công!", "Thông báo");
                        ReturnToTableMap();
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán thất bại!", "Lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bàn này chưa có hóa đơn để thanh toán!");
            }
        }

        private void ReturnToTableMap()
        {
            UC_Sale ucTableMap = this.Tag as UC_Sale;
            if (ucTableMap != null)
            {
                ucTableMap.Visible = true;
                ucTableMap.RefreshData();
                this.Parent.Controls.Remove(this);
            }
        }

        private void tsType_Resize(object sender, EventArgs e)
        {
            if (tsType == null) return;
            int c = tsType.Items.OfType<ToolStripButton>().Count();
            if (c > 0)
            {
                int w = (tsType.DisplayRectangle.Width - 5) / c;
                foreach (ToolStripItem i in tsType.Items) if (i is ToolStripButton b) { b.AutoSize = false; b.Width = w; }
            }
        }
    }
}
