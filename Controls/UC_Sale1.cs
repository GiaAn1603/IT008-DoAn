using System;
using System.Collections.Generic;
using System.ComponentModel; // Cần thêm cái này cho BindingList
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OHIOCF.BUS;
using OHIOCF.DTO;

namespace OHIOCF.Controls
{
    public partial class UC_Sale1 : UserControl
    {
        // Dữ liệu đệm
        private List<ProductDTO> allProducts = new List<ProductDTO>();
        private List<CategoryDTO> categoryList = new List<CategoryDTO>();
        private List<PromotionDTO> promotionList = new List<PromotionDTO>();
        private List<CustomerDTO> allCustomers = new List<CustomerDTO>();

        // Dữ liệu hóa đơn (Dùng BindingList để tự động cập nhật UI, tránh Crash)
        private BindingList<BillItem> currentBill = new BindingList<BillItem>();
        private BindingSource billBindingSource = new BindingSource();

        private Dictionary<string, int> originalQuantities = new Dictionary<string, int>();

        // Biến trạng thái
        private CafeTableDTO currentTable;
        private ProductDTO productWaitSize;
        private UC_SizeSelect sizeSelectControl;
        private Panel currentSelectedPanel;
        private CultureInfo culture = new CultureInfo("vi-VN");
        private string currentUserId = "admin";
        private bool isLoaded = false;
        private CustomerDTO currentCustomer;

        // Class hiển thị lên GridView
        public class BillItem : INotifyPropertyChanged
        {
            public string ProductId { get; set; }
            public string colTenMon { get; set; }

            // QUAN TRỌNG: colSize lưu GUID để trừ kho, SizeNameDisplay để hiện lên lưới
            public string colSize { get; set; }
            public string SizeNameDisplay { get; set; }

            private int _colSoLuong;
            public int colSoLuong
            {
                get { return _colSoLuong; }
                set { _colSoLuong = value; OnPropertyChanged("colSoLuong"); OnPropertyChanged("ThanhTien"); }
            }

            public decimal colDonGia { get; set; }

            public decimal ThanhTien => colSoLuong * colDonGia;

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public UC_Sale1()
        {
            InitializeComponent();
            dgvOrderItems.AutoGenerateColumns = false;

            // Cấu hình BindingSource 1 lần duy nhất
            billBindingSource.DataSource = currentBill;
            dgvOrderItems.DataSource = billBindingSource;

            this.Load += UC_Sale1_Load;
            this.Click += UC_Sale1_Click;

            if (cmbDiscount != null)
                cmbDiscount.SelectedIndexChanged += cmbDiscount_SelectedIndexChanged;

            // Đăng ký sự kiện sửa lưới
            dgvOrderItems.CellEndEdit += dgvOrderItems_CellEndEdit;
            dgvOrderItems.DataError += dgvOrderItems_DataError;
        }

        private void UC_Sale1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCategories();
                LoadPromotions();
                LoadProducts();
                LoadCustomers();
                isLoaded = true;

                // [QUAN TRỌNG] Mở khóa cột Số lượng bằng code để chắc chắn sửa được
                if (dgvOrderItems.Columns["colSoLuong"] != null) dgvOrderItems.Columns["colSoLuong"].ReadOnly = false;
                if (dgvOrderItems.Columns["SL"] != null) dgvOrderItems.Columns["SL"].ReadOnly = false;

                if (currentTable != null)
                {
                    SetCurrentTable(currentTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // --- 1. CÁC HÀM LOAD DỮ LIỆU --- (Giữ nguyên logic cũ nhưng gọn hơn)
        private void LoadCustomers()
        {
            allCustomers = CustomerBUS.Instance.GetAllCustomers();
            AutoCompleteStringCollection phoneSource = new AutoCompleteStringCollection();
            phoneSource.AddRange(allCustomers.Select(c => c.Phone).ToArray());

            cmbCustomerPhone.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCustomerPhone.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbCustomerPhone.AutoCompleteCustomSource = phoneSource;
            cmbCustomerPhone.DataSource = allCustomers;
            cmbCustomerPhone.DisplayMember = "Phone";
            cmbCustomerPhone.ValueMember = "Id";
            cmbCustomerPhone.SelectedIndex = -1;
        }

        private void LoadPromotions()
        {
            var allPromos = PromotionBUS.Instance.GetAllPromotions();
            DateTime now = DateTime.Now;
            promotionList = allPromos.Where(p => p.StartDate <= now && p.EndDate >= now).ToList();
            promotionList.Insert(0, new PromotionDTO { Id = "", Code = "Không áp dụng", DiscountValue = 0 });

            cmbDiscount.DataSource = promotionList;
            cmbDiscount.DisplayMember = "Code";
            cmbDiscount.ValueMember = "Id";
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

        private void LoadProducts(string categoryId = "All")
        {
            if (categoryId == "All") allProducts = ProductBUS.Instance.SearchProduct("");
            else allProducts = ProductBUS.Instance.GetProductsByCategory(categoryId);
            RenderMenu();
        }

        // --- 2. GIAO DIỆN CHỌN MÓN --- 
        private void SetupButton(ToolStripButton btn, string catName)
        {
            if (btn == null) return;
            if (catName == "All") btn.Tag = "All";
            else
            {
                var cat = categoryList.FirstOrDefault(c => c.Name.ToLower().Contains(catName.ToLower()));
                btn.Tag = cat != null ? cat.Id : "All";
            }
            btn.Click -= tsbCategory_Click;
            btn.Click += tsbCategory_Click;
        }

        private void tsbCategory_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton btn && btn.Tag != null) LoadProducts(btn.Tag.ToString());
        }

        private void RenderMenu(string keyword = "")
        {
            flpMenuItems.Controls.Clear();
            flpMenuItems.SuspendLayout();
            var filtered = allProducts.Where(p => p.IsAvailable && p.Name.ToLower().Contains(keyword.ToLower())).ToList();

            foreach (var product in filtered)
            {
                flpMenuItems.Controls.Add(CreateProductPanel(product));
            }
            flpMenuItems.ResumeLayout();
        }

        private TableLayoutPanel CreateProductPanel(ProductDTO product)
        {
            TableLayoutPanel tlp = new TableLayoutPanel
            {
                Tag = product,
                Size = new Size(130, 160),
                BackColor = Color.White,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                ColumnCount = 1,
                RowCount = 2
            };

            if (tlpProduct != null) { tlp.Size = tlpProduct.Size; tlp.BackColor = tlpProduct.BackColor; tlp.Margin = tlpProduct.Margin; }

            PictureBox pb = new PictureBox { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, Tag = product, BackColor = Color.Transparent };
            try { pb.Image = (!string.IsNullOrEmpty(product.Image) && File.Exists(product.Image)) ? Image.FromFile(product.Image) : null; } catch { }
            pb.Click += Product_Click;

            Panel pnlInfo = new Panel { Dock = DockStyle.Fill, Tag = product };
            Label lblName = new Label { Text = product.Name, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Arial", 9, FontStyle.Bold), Height = 40, Tag = product };
            Label lblPrice = new Label { Text = product.BasePrice.ToString("N0", culture) + " đ", Dock = DockStyle.Bottom, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red, Tag = product };

            pnlInfo.Controls.Add(lblName); pnlInfo.Controls.Add(lblPrice);
            pnlInfo.Click += Product_Click; lblName.Click += Product_Click; lblPrice.Click += Product_Click;

            tlp.Controls.Add(pb, 0, 0); tlp.Controls.Add(pnlInfo, 0, 1);
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 70F)); tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            return tlp;
        }

        private void Product_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            ProductDTO product = ctrl.Tag as ProductDTO;
            if (product != null) ShowSizePopup(product, ctrl.Parent as Panel ?? ctrl.Parent as TableLayoutPanel);
        }

        // --- 3. XỬ LÝ CHỌN SIZE & THÊM VÀO LIST (Đã tối ưu) ---
        private void ShowSizePopup(ProductDTO product, Panel anchor)
        {
            productWaitSize = product;
            if (currentSelectedPanel == anchor && sizeSelectControl != null && sizeSelectControl.Visible) { HideSizeSelect(); return; }
            currentSelectedPanel = anchor;

            if (sizeSelectControl == null)
            {
                sizeSelectControl = new UC_SizeSelect { Size = new Size(100, 180), AutoSize = false };
                sizeSelectControl.SizeSelected += (s, sizeName) => { AddToBill(productWaitSize, sizeName); HideSizeSelect(); };
                this.Controls.Add(sizeSelectControl);
                sizeSelectControl.BringToFront();
            }

            Point loc = (anchor != null && anchor.Parent != null) ? this.PointToClient(anchor.Parent.PointToScreen(anchor.Location)) : Cursor.Position;
            int x = loc.X + (anchor?.Width ?? 0);
            if (x + sizeSelectControl.Width > this.Width) x = loc.X - sizeSelectControl.Width;
            sizeSelectControl.Location = new Point(x, loc.Y);
            sizeSelectControl.Visible = true;
        }

        private void HideSizeSelect() { if (sizeSelectControl != null) sizeSelectControl.Visible = false; currentSelectedPanel = null; }
        private void UC_Sale1_Click(object sender, EventArgs e) => HideSizeSelect();

        // [QUAN TRỌNG] Thêm món không Crash
        private void AddToBill(ProductDTO product, string sizeName)
        {
            decimal price = product.BasePrice;
            var sizes = ProductSizeBUS.Instance.GetSizesByProduct(product.Id);
            var sObj = sizes.FirstOrDefault(s => s.SizeName == sizeName);
            string realSizeId = sObj != null ? sObj.Id : "";
            if (sObj != null) price += sObj.PriceAdjustment;

            var existing = currentBill.FirstOrDefault(x => x.ProductId == product.Id && x.colSize == realSizeId);

            if (existing != null)
            {
                existing.colSoLuong++; // Tự động cập nhật UI nhờ INotifyPropertyChanged
            }
            else
            {
                currentBill.Add(new BillItem
                {
                    ProductId = product.Id,
                    colTenMon = product.Name,
                    colSize = realSizeId,
                    SizeNameDisplay = sizeName,
                    colSoLuong = 1,
                    colDonGia = price
                });
            }
            UpdateTotalDisplay(); // Chỉ cần tính lại tổng tiền
        }

        // --- 4. XỬ LÝ SỬA SỐ LƯỢNG & XÓA TRÊN LƯỚI ---
        private void dgvOrderItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra an toàn
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (currentBill.Count <= e.RowIndex) return;

            // 2. Lấy giá trị ô vừa sửa
            var cellValue = dgvOrderItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            // 3. Kiểm tra xem có phải đang sửa cột Số lượng không?
            // (Logic: Nếu giá trị nhập vào là số nguyên thì coi như đang sửa số lượng)
            if (int.TryParse(cellValue?.ToString(), out int newQty))
            {
                // Đây đúng là cột số lượng rồi!
                if (newQty <= 0)
                {
                    // Nếu nhập <= 0 thì xóa món
                    currentBill.RemoveAt(e.RowIndex);
                }
                else
                {
                    // Cập nhật số lượng vào danh sách
                    currentBill[e.RowIndex].colSoLuong = newQty;
                }

                // 4. TÍNH LẠI TỔNG TIỀN NGAY LẬP TỨC
                UpdateTotalDisplay();

                // 5. Vẽ lại lưới để cột Thành tiền nhảy số mới
                dgvOrderItems.Refresh();
            }
        }

        private void dgvOrderItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true; // Chặn lỗi hiển thị mặc định
        }

        // --- 5. TÍNH TIỀN ---
        private void UpdateTotalDisplay()
        {
            decimal subTotal = currentBill.Sum(x => x.ThanhTien);
            decimal discountAmount = 0;
            if (cmbDiscount.SelectedItem is PromotionDTO selectedPromo && !string.IsNullOrEmpty(selectedPromo.Id))
            {
                discountAmount = (selectedPromo.DiscountType == 0) ? subTotal * (selectedPromo.DiscountValue / 100) : selectedPromo.DiscountValue;
            }
            decimal finalTotal = subTotal - discountAmount;
            if (finalTotal < 0) finalTotal = 0;

            if (lblSubTotal != null) lblSubTotal.Text = subTotal.ToString("N0", culture) + " đ";
            if (lblDiscount != null) lblDiscount.Text = discountAmount.ToString("N0", culture) + " đ";
            if (label6 != null) { label6.Text = finalTotal.ToString("N0", culture) + " đ"; label6.Tag = finalTotal; }
        }
        private void cmbDiscount_SelectedIndexChanged(object sender, EventArgs e) => UpdateTotalDisplay();

        // --- 6. QUẢN LÝ BÀN ---
        public void SetCurrentTable(CafeTableDTO table)
        {
            this.currentTable = table;
            if (!isLoaded) return;
            if (currentTable != null)
            {
                lblCurrentTable.Text = table.TableName;
                if (table.Status == 1) LoadExistingOrder(table.Id);
                else
                {
                    currentBill.Clear();
                    originalQuantities.Clear();
                    currentCustomer = null;
                    if (cmbDiscount.Items.Count > 0) cmbDiscount.SelectedIndex = 0;
                    cmbCustomerPhone.SelectedIndex = -1; txtCustomerName.Clear(); lblRank.Text = "Đồng";
                    UpdateTotalDisplay();
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
                if (!string.IsNullOrEmpty(order.CustomerId))
                {
                    var allCust = CustomerBUS.Instance.GetAllCustomers();
                    currentCustomer = allCust.FirstOrDefault(c => c.Id == order.CustomerId);
                    if (currentCustomer != null) { cmbCustomerPhone.Text = currentCustomer.Phone; txtCustomerName.Text = currentCustomer.FullName; lblRank.Text = currentCustomer.Rank; }
                }
                if (!string.IsNullOrEmpty(order.PromotionId)) cmbDiscount.SelectedValue = order.PromotionId;

                List<OrderDetailDTO> details = OrderDetailBUS.Instance.GetDetails(order.Id);
                foreach (var item in details)
                {
                    var product = ProductBUS.Instance.SearchProduct("").FirstOrDefault(p => p.Id == item.ProductId);
                    var sizes = ProductSizeBUS.Instance.GetSizesByProduct(item.ProductId);
                    var sObj = sizes.FirstOrDefault(s => s.Id == item.ProductSizeId);

                    currentBill.Add(new BillItem
                    {
                        ProductId = item.ProductId,
                        colTenMon = product != null ? product.Name : "?",
                        colSize = item.ProductSizeId,
                        SizeNameDisplay = sObj != null ? sObj.SizeName : "?",
                        colSoLuong = item.Quantity,
                        colDonGia = item.PriceAtTime
                    });

                    string key = $"{item.ProductId}*{item.ProductSizeId}";
                    if (originalQuantities.ContainsKey(key)) originalQuantities[key] += item.Quantity; else originalQuantities.Add(key, item.Quantity);
                }
            }
            UpdateTotalDisplay();
        }

        // --- 7. LƯU & THANH TOÁN ---
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (currentTable == null || currentBill.Count == 0) return;
            try
            {
                string orderId = OrderBUS.Instance.CreateOrder(currentTable.Id, currentUserId);
                if (string.IsNullOrEmpty(orderId)) return;

                foreach (var item in currentBill)
                {
                    string key = $"{item.ProductId}*{item.colSize}";
                    int oldQty = originalQuantities.ContainsKey(key) ? originalQuantities[key] : 0;
                    int qtyToAdd = item.colSoLuong - oldQty;

                    if (qtyToAdd > 0)
                    {
                        OrderDetailBUS.Instance.AddDishToOrder(new OrderDetailDTO
                        {
                            Id = Guid.NewGuid().ToString(),
                            OrderId = orderId,
                            ProductId = item.ProductId,
                            ProductSizeId = item.colSize,
                            Quantity = qtyToAdd,
                            PriceAtTime = item.colDonGia
                        });
                        if (originalQuantities.ContainsKey(key)) originalQuantities[key] = item.colSoLuong; else originalQuantities.Add(key, item.colSoLuong);
                    }
                }
                string promoId = cmbDiscount.SelectedValue?.ToString(); if (string.IsNullOrEmpty(promoId)) promoId = null;
                decimal finalTotal = (label6.Tag != null) ? Convert.ToDecimal(label6.Tag) : 0;
                OrderBUS.Instance.UpdateOrderInfo(orderId, finalTotal, promoId, currentCustomer?.Id);

                if (currentTable.Id != "0") CafeTableBUS.Instance.SwitchStatus(currentTable.Id, 1);
                MessageBox.Show("Đã lưu đơn!", "Thành công");
                ReturnToTableMap();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu đơn: " + ex.Message); }
        }

        private void TruKhoNguyenLieu(BindingList<BillItem> items)
        {
            foreach (var item in items)
            {
                List<ProductIngredientDTO> recipe = ProductIngredientBUS.Instance.GetRecipe(item.colSize);
                foreach (var ing in recipe)
                {
                    double totalDeduct = ing.RequiredQuantity * item.colSoLuong;
                    InventoryBUS.Instance.DeductStock(ing.IngredientId, totalDeduct);
                }
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (currentTable == null) return;
            OrderDTO order = OrderBUS.Instance.GetUncheckOrderByTable(currentTable.Id.ToString());
            if (order == null || string.IsNullOrEmpty(order.Id)) { btnCheckout_Click(null, null); order = OrderBUS.Instance.GetUncheckOrderByTable(currentTable.Id.ToString()); }

            if (order != null && !string.IsNullOrEmpty(order.Id))
            {
                decimal finalAmount = (label6.Tag != null) ? Convert.ToDecimal(label6.Tag) : 0;
                string phone = cmbCustomerPhone.Text.Trim();
                if (!string.IsNullOrEmpty(phone) && currentCustomer == null)
                {
                    CustomerDTO newCustomer = new CustomerDTO { Id = Guid.NewGuid().ToString(), FullName = txtCustomerName.Text.Trim(), Phone = phone, Points = 0, Rank = "Đồng" };
                    if (CustomerBUS.Instance.AddCustomer(newCustomer)) { currentCustomer = newCustomer; }
                }

                if (MessageBox.Show($"Thanh toán bàn {currentTable.TableName}?\nTổng: {finalAmount:N0} đ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (OrderBUS.Instance.PayOrder(order.Id, finalAmount, currentCustomer?.Id, cmbDiscount.SelectedValue?.ToString()))
                    {
                        try { TruKhoNguyenLieu(currentBill); } catch { }
                        if (currentTable.Id != "0") CafeTableBUS.Instance.SwitchStatus(currentTable.Id, 0);
                        MessageBox.Show("Thanh toán thành công!", "Thông báo");
                        ReturnToTableMap();
                    }
                    else MessageBox.Show("Thanh toán thất bại!", "Lỗi");
                }
            }
        }

        private void ReturnToTableMap()
        {
            if (this.Parent == null) return;
            Control ucTableMap = null;
            if (this.Tag is Control tagControl) ucTableMap = tagControl;
            else
            {
                foreach (Control c in this.Parent.Controls) { if (c.GetType().Name == "UC_Sale") { ucTableMap = c; break; } }
            }
            if (ucTableMap != null) { ucTableMap.Visible = true; try { dynamic map = ucTableMap; map.LoadTableStatus(); } catch { } }
            this.Parent.Controls.Remove(this); this.Dispose();
        }

        // Các hàm phụ khác
        private void tsType_Resize(object sender, EventArgs e)
        {
            if (tsType == null) return;
            int c = tsType.Items.OfType<ToolStripButton>().Count();
            if (c > 0) { int w = (tsType.DisplayRectangle.Width - 5) / c; foreach (ToolStripItem i in tsType.Items) if (i is ToolStripButton b) { b.AutoSize = false; b.Width = w; } }
        }

        private void cmbCustomerPhone_TextChanged(object sender, EventArgs e)
        {
            string phone = cmbCustomerPhone.Text.Trim();
            if (phone.Length < 3) { txtCustomerName.Clear(); lblRank.Text = "Đồng"; currentCustomer = null; return; }
            var allCust = CustomerBUS.Instance.GetAllCustomers();
            var customer = allCust.FirstOrDefault(c => c.Phone == phone);
            if (customer != null) { currentCustomer = customer; txtCustomerName.Text = customer.FullName; lblRank.Text = customer.Rank; }
            else { currentCustomer = null; lblRank.Text = "Đồng"; }
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e) => RenderMenu(txtProductSearch.Text.Trim());
        private void btnSearch_Click(object sender, EventArgs e) { }
    }
}
