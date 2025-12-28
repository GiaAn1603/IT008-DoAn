using OHIOCF.BUS;
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

namespace OHIOCF.Controls
{
    public partial class UC_Sale : UserControl
    {
        public event EventHandler<Type> LoadUserControlRequested;
        private CafeTableDTO currentSelectedTable;
        private CultureInfo culture = new CultureInfo("vi-VN");

        public UC_Sale()
        {
            InitializeComponent();
            this.Load += UC_Sale_Load;
        }

        private void btnAddNewOrder_Click(object sender, EventArgs e)
        {
            LoadUserControlRequested?.Invoke(this, typeof(UC_Sale1));
        }

        private void UC_Sale_Load(object sender, EventArgs e)
        {
            InitDataGridView();

            flpIndoorTables.Controls.Clear();
            flpOutdoorTables.Controls.Clear();

            LoadTableList();

            ClearTableInfo();
        }

        private void InitDataGridView()
        {
            DGVInvoiceSummary.AutoGenerateColumns = false;
            DGVInvoiceSummary.Columns.Clear();

            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.DataPropertyName = "colTenMon";
            colName.HeaderText = "Tên món";
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGVInvoiceSummary.Columns.Add(colName);

            DataGridViewTextBoxColumn colSize = new DataGridViewTextBoxColumn();
            colSize.DataPropertyName = "colSize";
            colSize.HeaderText = "Size";
            colSize.Width = 50;
            DGVInvoiceSummary.Columns.Add(colSize);

            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.DataPropertyName = "colDonGia";
            colPrice.HeaderText = "Đơn giá";
            colPrice.Width = 100;
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.FormatProvider = culture;
            DGVInvoiceSummary.Columns.Add(colPrice);

            DataGridViewTextBoxColumn colQty = new DataGridViewTextBoxColumn();
            colQty.DataPropertyName = "colSL";
            colQty.HeaderText = "SL";
            colQty.Width = 50;
            colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVInvoiceSummary.Columns.Add(colQty);
        }

        public void LoadTableList()
        {
            flpIndoorTables.Controls.Clear();
            flpOutdoorTables.Controls.Clear();

            List<CafeTableDTO> tableList = CafeTableBUS.Instance.GetAllTables();

            foreach (var table in tableList)
            {
                Panel pnl = new Panel();
                pnl.Width = 100;
                pnl.Height = 100;
                pnl.BorderStyle = BorderStyle.FixedSingle;
                pnl.Tag = table;
                pnl.Cursor = Cursors.Hand;

                if (table.Status == 1)
                {
                    pnl.BackColor = Color.ForestGreen;
                    pnl.ForeColor = Color.White;
                }
                else
                {
                    pnl.BackColor = Color.WhiteSmoke;
                    pnl.ForeColor = Color.Black;
                }

                Label lblName = new Label();
                lblName.Text = table.TableName;
                lblName.Dock = DockStyle.Fill;
                lblName.TextAlign = ContentAlignment.MiddleCenter;
                lblName.Height = 40;
                lblName.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblName.BackColor = Color.Transparent;
                lblName.Tag = table;


                pnl.Controls.Add(lblName);


                pnl.Click += PnlTable_Click;
                pnl.DoubleClick += PnlTable_DoubleClick;

                lblName.Click += PnlTable_Click;
                lblName.DoubleClick += PnlTable_DoubleClick;

                lblStatus.Click += PnlTable_Click;
                lblStatus.DoubleClick += PnlTable_DoubleClick;

                if (table.Area != null && table.Area.ToLower().Contains("ngoài"))
                {
                    flpOutdoorTables.Controls.Add(pnl);
                }
                else
                {
                    flpIndoorTables.Controls.Add(pnl);
                }
            }

            lblFreeable.Text = $"Tổng số bàn: {tableList.Count} | Trống: {tableList.FindAll(t => t.Status != 1).Count}";
        }

        private void PnlTable_Click(object sender, EventArgs e)
        {
            Control c = sender as Control;
            currentSelectedTable = c.Tag as CafeTableDTO;

            if (currentSelectedTable == null) return;

            lblCurrentTable.Text = currentSelectedTable.TableName;
            lblTableStatus.Text = currentSelectedTable.Status == 1 ? "Có khách" : "Trống";

            if (currentSelectedTable.Status == 1)
            {
                LoadOrderDetails(currentSelectedTable.Id);
            }
            else
            {
                DGVInvoiceSummary.DataSource = null;
                lblSubTotal.Text = "0 đ";
                lblDiscount.Text = "0 đ";
                lblTotal.Text = "0 đ";
            }
        }

        private void LoadOrderDetails(string tableId)
        {
            OrderDTO order = OrderBUS.Instance.GetUncheckOrderByTable(tableId);

            if (order != null && !string.IsNullOrEmpty(order.Id))
            {
                List<OrderDetailDTO> listBillInfo = OrderDetailBUS.Instance.GetDetails(order.Id);

                var displayList = new List<dynamic>();
                decimal subTotal = 0;

                foreach (var item in listBillInfo)
                {
                    var product = ProductBUS.Instance.GetProductById(item.ProductId);
                    string productName = product != null ? product.Name : "Món " + item.ProductId;

                    displayList.Add(new
                    {
                        colTenMon = productName,
                        colSize = item.ProductSizeId,
                        colDonGia = item.PriceAtTime,
                        colSL = item.Quantity
                    });

                    subTotal += (decimal)item.PriceAtTime * item.Quantity;
                }

                DGVInvoiceSummary.DataSource = displayList;

                decimal discountAmount = 0;

                if (!string.IsNullOrEmpty(order.PromotionId))
                {
                    PromotionDTO promo = PromotionBUS.Instance.GetPromotionById(order.PromotionId);
                    if (promo != null)
                    {
                        if (promo.DiscountType == 0) // %
                        {
                            discountAmount = subTotal * (promo.DiscountValue / 100);
                        }
                        else // Tiền mặt
                        {
                            discountAmount = promo.DiscountValue;
                        }
                    }
                }

                decimal finalTotal = subTotal - discountAmount;
                if (finalTotal < 0) finalTotal = 0;

                lblSubTotal.Text = subTotal.ToString("N0", culture) + " đ";
                lblDiscount.Text = discountAmount.ToString("N0", culture) + " đ";
                lblTotal.Text = finalTotal.ToString("N0", culture) + " đ";
            }
        }

        private void PnlTable_DoubleClick(object sender, EventArgs e)
        {
            Control c = sender as Control;
            CafeTableDTO table = c.Tag as CafeTableDTO;
            OpenSaleScreen(table);
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (currentSelectedTable != null)
            {
                OpenSaleScreen(currentSelectedTable);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bàn trước!");
            }
        }

        private void OpenSaleScreen(CafeTableDTO table)
        {
            if (this.Parent == null) return;

            UC_Sale1 ucSale1 = new UC_Sale1();
            ucSale1.SetCurrentTable(table);
            ucSale1.Tag = this;

            this.Parent.Controls.Add(ucSale1);
            ucSale1.Dock = DockStyle.Fill;
            ucSale1.BringToFront();

            this.Visible = false;
        }

        private void ClearTableInfo()
        {
            lblCurrentTable.Text = "...";
            lblTableStatus.Text = "...";
            lblSubTotal.Text = "0";
            lblTotal.Text = "0";
            DGVInvoiceSummary.DataSource = null;
        }

        public void RefreshData()
        {
            string selectedTableId = currentSelectedTable?.Id;

            LoadTableList();

            if (selectedTableId != null)
            {

                var allTables = CafeTableBUS.Instance.GetAllTables();
                var refreshedTable = allTables.FirstOrDefault(t => t.Id == selectedTableId);

                if (refreshedTable != null)
                {
                    currentSelectedTable = refreshedTable;
                    lblCurrentTable.Text = refreshedTable.TableName;
                    lblTableStatus.Text = refreshedTable.Status == 1 ? "Có khách" : "Trống";

                    if (refreshedTable.Status == 1)
                        LoadOrderDetails(refreshedTable.Id);
                    else
                    {
                        ClearTableInfo();
                        currentSelectedTable = null;
                    }
                }
            }
        }
    }
}
