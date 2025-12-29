using System.IO;
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
        private List<ProductDTO> allProducts = new List<ProductDTO>();
        private List<CategoryDTO> categoryList = new List<CategoryDTO>();
        private List<PromotionDTO> promotionList = new List<PromotionDTO>();
        private List<BillItem> currentBill = new List<BillItem>();
        private Dictionary<string, int> originalQuantities = new Dictionary<string, int>();
        private List<CustomerDTO> allCustomers = new List<CustomerDTO>();
        private CafeTableDTO currentTable;
        private ProductDTO productWaitSize;
        private UC_SizeSelect sizeSelectControl;
        private Panel currentSelectedPanel;
        private CultureInfo culture = new CultureInfo("vi-VN");
        private string currentUserId = "admin";
        private bool isLoaded = false;
        private CustomerDTO currentCustomer;
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
            dgvOrderItems.AutoGenerateColumns = false;
            dgvOrderItems.CellEndEdit += dgvOrderItems_CellEndEdit;
            dgvOrderItems.DataError += dgvOrderItems_DataError;
            dgvOrderItems.CurrentCell = null;
        }
        private void UC_Sale1_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadPromotions();
            LoadProducts();
            LoadCustomers();
            isLoaded = true;
            if (currentTable != null)
            {
                SetCurrentTable(currentTable);
            }
        }

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
                    LoadExistingOrder(table.Id); // ← Gọi hàm này
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
                if (!string.IsNullOrEmpty(order.CustomerId))
                {
                    currentCustomer = CustomerBUS.Instance.GetCustomerById(order.CustomerId);
                    if (currentCustomer != null)
                    {
                        cmbCustomerPhone.Text = currentCustomer.Phone;
                        txtCustomerName.Text = currentCustomer.FullName;
                        lblRank.Text = currentCustomer.Rank;
                    }
                }
                else
                {
                    // Không có khách hàng -> reset form
                    currentCustomer = null;
                    cmbCustomerPhone.SelectedIndex = -1;
                    cmbCustomerPhone.Text = "";
                    txtCustomerName.Clear();
                    lblRank.Text = "Đồng";
                }
                // Load promotion
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
                // Load order details
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
                    string key = $"{item.ProductId}*{item.ProductSizeId}";
                    if (originalQuantities.ContainsKey(key)) originalQuantities[key] += item.Quantity;
                    else originalQuantities.Add(key, item.Quantity);
                }
            }
            RefreshBillGrid();
        }
        private void LoadCategories()
        {
            categoryList = CategoryBUS.Instance.GetAllCategories();
            SetupButton(tsbAll, "All");
            SetupButton(tsbCoffee, "Cà Phê");
            SetupButton(tsbTea, "Trà");
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
            var filtered = allProducts
            .Where(p => p.IsAvailable &&
            p.Name.ToLower().Contains(keyword.ToLower()))
            .ToList();
            foreach (var product in filtered)
            {
                var tlp = CreateProductPanel(product);
                flpMenuItems.Controls.Add(tlp);
            }
            flpMenuItems.ResumeLayout();
        }
        private TableLayoutPanel CreateProductPanel(ProductDTO product)
        {
            TableLayoutPanel tlp = new TableLayoutPanel
            {
                Tag = product,
                Size = tlpProduct.Size,
                BackColor = tlpProduct.BackColor,
                CellBorderStyle = tlpProduct.CellBorderStyle,
                ColumnCount = tlpProduct.ColumnCount,
                RowCount = tlpProduct.RowCount,
                Margin = tlpProduct.Margin
            };
            foreach (ColumnStyle cs in tlpProduct.ColumnStyles)
                tlp.ColumnStyles.Add(new ColumnStyle(cs.SizeType, cs.Width));
            foreach (RowStyle rs in tlpProduct.RowStyles)
                tlp.RowStyles.Add(new RowStyle(rs.SizeType, rs.Height));
            // ===== IMAGE =====
            PictureBox pb = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Tag = product
            };
            try
            {
                if (!string.IsNullOrEmpty(product.Image) && File.Exists(product.Image))
                    pb.Image = Image.FromFile(product.Image);
                else
                    pb.BackColor = Color.LightGray;
            }
            catch
            {
                pb.BackColor = Color.LightGray;
            }
            pb.Click += Product_Click;
            tlp.Controls.Add(pb, 0, 0);
            tlp.SetColumnSpan(pb, 2);
            // ===== NAME =====
            Label lblName = new Label
            {
                Text = product.Name,
                Dock = DockStyle.Fill,
                Font = lblProductName.Font,
                TextAlign = lblProductName.TextAlign,
                Tag = product
            };
            lblName.Click += Product_Click;
            tlp.Controls.Add(lblName, 0, 1);
            // ===== PRICE =====
            var sizes = ProductSizeBUS.Instance.GetSizesByProduct(product.Id);
            var defaultSize = sizes.FirstOrDefault(s => s.SizeName == "S") ?? sizes.FirstOrDefault();
            decimal price = product.BasePrice + (defaultSize?.PriceAdjustment ?? 0);
            Label lblPrice = new Label
            {
                Text = price.ToString("N0", culture) + " đ",
                Dock = DockStyle.Fill,
                Font = lblProductPrice.Font,
                TextAlign = lblProductPrice.TextAlign,
                Tag = product
            };
            lblPrice.Click += Product_Click;
            tlp.Controls.Add(lblPrice, 1, 1);
            tlp.Click += Product_Click;
            return tlp;
        }
        private void Product_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            ProductDTO product = ctrl.Tag as ProductDTO;
            if (product == null) return;
            ShowSizePopup(product, ctrl.Parent as Panel ?? ctrl.Parent as TableLayoutPanel);
        }
        private void txtProductSearch_TextChanged(object sender, EventArgs e) => RenderMenu(txtProductSearch.Text.Trim());
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
            dgvOrderItems.CellEndEdit -= dgvOrderItems_CellEndEdit;
            dgvOrderItems.DataError -= dgvOrderItems_DataError;

            dgvOrderItems.DataSource = null;

            dgvOrderItems.DataSource = currentBill;

            if (currentBill.Count == 0)
            {
                dgvOrderItems.ClearSelection();
                dgvOrderItems.CurrentCell = null;
                dgvOrderItems.RowsDefaultCellStyle.SelectionBackColor = dgvOrderItems.BackgroundColor;
                dgvOrderItems.RowsDefaultCellStyle.SelectionForeColor = dgvOrderItems.ForeColor;
            }
            dgvOrderItems.CellEndEdit += dgvOrderItems_CellEndEdit;
            dgvOrderItems.DataError += dgvOrderItems_DataError;

            UpdateTotalDisplay();
        }
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (currentTable == null) return;
            if (currentBill.Count == 0) return;
            try
            {
                string orderId = OrderBUS.Instance.CreateOrder(
                currentTable.Id.ToString(),
                currentUserId
                );
                if (string.IsNullOrEmpty(orderId)) return;
                foreach (var item in currentBill)
                {
                    string key = $"{item.ProductId}*{item.colSize}";
                    int oldQty = originalQuantities.ContainsKey(key) ? originalQuantities[key] : 0;
                    int newQty = item.colSoLuong;
                    int qtyToAdd = newQty - oldQty;
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
                    }
                }
                string promoId = cmbDiscount.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(promoId)) promoId = null;
                decimal subTotal = currentBill.Sum(x => x.ThanhTien);
                decimal discount = 0;
                if (cmbDiscount.SelectedItem is PromotionDTO promo && promoId != null)
                {
                    discount = promo.DiscountType == 0
                    ? subTotal * promo.DiscountValue / 100
                    : promo.DiscountValue;
                }
                decimal finalTotal = Math.Max(0, subTotal - discount);
                string customerId = currentCustomer?.Id;
                OrderBUS.Instance.UpdateOrderInfo(
                orderId,
                finalTotal,
                promoId,
                customerId
                );
                if (currentTable.Id != "0")
                    CafeTableBUS.Instance.SwitchStatus(currentTable.Id, 1);
                MessageBox.Show("Đã lưu đơn!", "Thành công");
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

            if (currentBill.Count == 0)
            {
                MessageBox.Show("Chưa có món nào trong đơn hàng!", "Thông báo");
                return;
            }

            OrderDTO order = OrderBUS.Instance.GetUncheckOrderByTable(currentTable.Id.ToString());

            if (order == null || string.IsNullOrEmpty(order.Id))
            {
                if (currentTable.Id == "0")
                {
                    try
                    {
                        string newOrderId = OrderBUS.Instance.CreateOrder(
                            currentTable.Id.ToString(),
                            currentUserId
                        );

                        if (string.IsNullOrEmpty(newOrderId))
                        {
                            MessageBox.Show("Không thể tạo đơn hàng!", "Lỗi");
                            return;
                        }

                        foreach (var item in currentBill)
                        {
                            OrderDetailBUS.Instance.AddDishToOrder(new OrderDetailDTO
                            {
                                Id = Guid.NewGuid().ToString(),
                                OrderId = newOrderId,
                                ProductId = item.ProductId,
                                ProductSizeId = item.colSize,
                                Quantity = item.colSoLuong,
                                PriceAtTime = item.colDonGia
                            });
                        }

                        string promoId = cmbDiscount.SelectedValue?.ToString();
                        if (string.IsNullOrEmpty(promoId)) promoId = null;

                        decimal subTotal = currentBill.Sum(x => x.ThanhTien);
                        decimal discount = 0;
                        if (cmbDiscount.SelectedItem is PromotionDTO promo && promoId != null)
                        {
                            discount = promo.DiscountType == 0
                                ? subTotal * promo.DiscountValue / 100
                                : promo.DiscountValue;
                        }
                        decimal finalTotal = Math.Max(0, subTotal - discount);

                        string customerId = currentCustomer?.Id;
                        OrderBUS.Instance.UpdateOrderInfo(newOrderId, finalTotal, promoId, customerId);

                        order = OrderBUS.Instance.GetUncheckOrderByTable(currentTable.Id.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tạo đơn: " + ex.Message, "Lỗi");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Bàn này chưa có hóa đơn!\nVui lòng nhấn 'Lưu đơn' trước khi thanh toán.", "Thông báo");
                    return;
                }
            }
            if (order == null || string.IsNullOrEmpty(order.Id))
            {
                MessageBox.Show("Không thể tìm thấy đơn hàng!", "Lỗi");
                return;
            }

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

            bool needConfirm = currentTable.Id != "0";
            bool doPay = true;

            if (needConfirm)
            {
                doPay = MessageBox.Show(
                    $"Thanh toán cho bàn {currentTable.TableName}?\nTổng tiền: {finalAmount.ToString("N0", culture)} đ",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.Yes;
            }

            if (doPay)
            {
                string phone = cmbCustomerPhone.Text.Trim();
                string customerId = null;

                if (!string.IsNullOrEmpty(phone))
                {
                    if (currentCustomer == null)
                    {
                        CustomerDTO newCustomer = new CustomerDTO
                        {
                            Id = Guid.NewGuid().ToString(),
                            FullName = txtCustomerName.Text.Trim(),
                            Phone = phone,
                            Points = 0,
                            Rank = "Đồng"
                        };
                        CustomerBUS.Instance.AddCustomer(newCustomer);
                        currentCustomer = newCustomer;
                    }
                    customerId = currentCustomer.Id;
                }

                bool success = OrderBUS.Instance.PayOrder(order.Id, finalAmount, customerId, promotionId);

                if (success)
                {
                    if (currentTable.Id != "0")
                    {
                        CafeTableBUS.Instance.SwitchStatus(currentTable.Id, 0);
                    }

                    MessageBox.Show("Thanh toán thành công!", "Thông báo");
                    ReturnToTableMap();
                    
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại!", "Lỗi");
                }
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
        }
        private void cmbCustomerPhone_TextChanged(object sender, EventArgs e)
        {
            string phone = cmbCustomerPhone.Text.Trim();
            if (phone.Length < 3)
            {
                txtCustomerName.Clear();
                lblRank.Text = "Đồng";
                currentCustomer = null;
                return;
            }
            var customer = CustomerBUS.Instance.FindCustomerByPhone(phone);
            if (customer != null)
            {
                currentCustomer = customer;
                txtCustomerName.Text = customer.FullName;
                lblRank.Text = customer.Rank;
            }
            else
            {
                currentCustomer = null;
                lblRank.Text = "Đồng";
            }
        }

        private void dgvOrderItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void dgvOrderItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Bảo vệ: nếu click header hoặc không có dòng
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (currentBill.Count <= e.RowIndex) return; // tránh lỗi index out of range

            var column = dgvOrderItems.Columns[e.ColumnIndex];
            if (column.HeaderText == "SL" || column.DataPropertyName == "colSoLuong")
            {
                var cellValue = dgvOrderItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (int.TryParse(cellValue?.ToString(), out int qty))
                {
                    if (qty <= 0)
                    {
                        MessageBox.Show("Số lượng ≤ 0 → món sẽ bị xóa khỏi đơn hàng.", "Thông báo");
                        currentBill.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        currentBill[e.RowIndex].colSoLuong = qty;
                    }
                }
                else
                {
                    dgvOrderItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = currentBill[e.RowIndex].colSoLuong;
                    return;
                }

                RefreshBillGrid();
            }
        }
    }
}