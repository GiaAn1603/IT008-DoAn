using DocumentFormat.OpenXml.Drawing.Diagrams;
using OHIOCF.BUS;
using OHIOCF.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OHIOCF.Controls
{
    public partial class UC_Products : UserControl
    {
        private List<ProductDTO> productList;
        private List<CategoryDTO> categoryList;
        private List<IngredientDTO> ingredientList;
        private ProductDTO selectedProduct;
        private string selectedSize = "S";

        public UC_Products()
        {
            InitializeComponent();
        }

        private void UC_Products_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadIngredients();
            LoadProducts();
        }

        void LoadCategories()
        {
            categoryList = CategoryBUS.Instance.GetAllCategories();
            cmbCategory.DataSource = null;

            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
            cmbCategory.DataSource = categoryList;
            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }
            
        }


        void LoadIngredients()
        {
            ingredientList = IngredientBUS.Instance.GetAll();
            cmbIngredientName.DataSource = ingredientList;
            cmbIngredientName.DisplayMember = "Name";
            cmbIngredientName.ValueMember = "Id";
            if (cmbIngredientName.Items.Count > 0)
            {
                cmbIngredientName.SelectedIndex = 0;
            }
        }
        void LoadProducts(string categoryId = null)
        {
            productList = string.IsNullOrEmpty(categoryId)
                ? ProductBUS.Instance.GetProductsByCategory("All")
                : ProductBUS.Instance.GetProductsByCategory(categoryId);
            DisplayProducts(productList);
        }

        void DisplayProducts(List<ProductDTO> products)
        {
            flpMenuItems.Controls.Clear();

            foreach (var product in products)
            {
                var sizes = ProductSizeBUS.Instance.GetSizesByProduct(product.Id);
                var defaultSize = sizes.FirstOrDefault(s => s.SizeName == "S") ?? sizes.FirstOrDefault();
                if (defaultSize == null) continue;

                decimal displayPrice = product.BasePrice + defaultSize.PriceAdjustment;

                TableLayoutPanel tlp = new TableLayoutPanel
                {
                    Width = 200,
                    Height = 250,
                    RowCount = 3,
                    ColumnCount = 1,
                    Tag = product,
                    Cursor = Cursors.Hand
                };

                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

                Label lblName = new Label
                {
                    Text = product.Name,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Tag = product
                };
                lblName.Click += tlpProduct_Click;
                tlp.Controls.Add(lblName, 0, 1);

                Label lblPrice = new Label
                {
                    Text = $"{displayPrice:N0} VNĐ",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F),
                    Tag = product
                };
                lblPrice.Click += tlpProduct_Click;
                tlp.Controls.Add(lblPrice, 0, 2);

                tlp.Click += tlpProduct_Click;
                flpMenuItems.Controls.Add(tlp);
            }
        }
        void tlpProduct_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            selectedProduct = ctrl.Tag as ProductDTO;
            if (selectedProduct == null) return;

            txtProductName.Text = selectedProduct.Name;
            cmbCategory.SelectedValue = selectedProduct.CategoryId;
            cmbStatus.SelectedIndex = selectedProduct.IsAvailable ? 0 : 1;
            cmbProductSize.SelectedIndex = 0;
            selectedSize = "S";
            LoadSizeData(selectedProduct.Id, selectedSize);
        }

        void LoadSizeData(string productId, string sizeName)
        {
            var sizes = ProductSizeBUS.Instance.GetSizesByProduct(productId);
            var size = sizes.FirstOrDefault(s => s.SizeName == sizeName);

            if (size != null)
            {
                var product = productList.FirstOrDefault(p => p.Id == productId);
                txtPrice.Text = (product.BasePrice + size.PriceAdjustment).ToString("N0");

                var ingredients = ProductIngredientBUS.Instance.GetRecipe(size.Id);
                dgvIngredientsList.Rows.Clear();

                foreach (var ing in ingredients)
                {
                    var ingredientInfo = ingredientList.FirstOrDefault(i => i.Id == ing.IngredientId);
                    if (ingredientInfo != null)
                        dgvIngredientsList.Rows.Add(ingredientInfo.Name, ing.RequiredQuantity, ingredientInfo.Unit, "Xóa");
                }
            }
            else
            {
                txtPrice.Clear();
                dgvIngredientsList.Rows.Clear();
            }
        }
        private void cmbProductSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedProduct != null)
            {
                selectedSize = cmbProductSize.Text;
                LoadSizeData(selectedProduct.Id, selectedSize);
            }
        }


        private void cmbIngredientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIngredientName.SelectedValue != null)
            {
                var ingredient = ingredientList.FirstOrDefault(i => i.Id == cmbIngredientName.SelectedValue.ToString());
                if (ingredient != null)
                    cmbIngredientUnit.Text = ingredient.Unit;
            }
        }
        

        //btn
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) || !decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal price))
                return;

            ProductDTO newProduct = new ProductDTO
            {
                Name = txtProductName.Text.Trim(),
                CategoryId = cmbCategory.SelectedValue?.ToString(),
                BasePrice = price,
                IsAvailable = cmbStatus.SelectedIndex == 0
            };

            if (ProductBUS.Instance.AddProduct(newProduct))
            {
                var createdProduct = ProductBUS.Instance.SearchProduct(newProduct.Name).FirstOrDefault();
                if (createdProduct != null)
                {
                    ProductSizeDTO newSize = new ProductSizeDTO
                    {
                        ProductId = createdProduct.Id,
                        SizeName = selectedSize,
                        PriceAdjustment = 0
                    };

                    if (ProductSizeBUS.Instance.AddSize(newSize))
                    {
                        var createdSize = ProductSizeBUS.Instance.GetSizesByProduct(createdProduct.Id)
                            .FirstOrDefault(s => s.SizeName == selectedSize);

                        if (createdSize != null)
                        {
                            foreach (DataGridViewRow row in dgvIngredientsList.Rows)
                            {
                                if (row.IsNewRow) continue;

                                var ingredient = ingredientList.FirstOrDefault(i => i.Name == row.Cells["colIngredientName"].Value?.ToString());
                                if (ingredient != null)
                                {
                                    ProductIngredientBUS.Instance.AddIngredientToRecipe(new ProductIngredientDTO
                                    {
                                        ProductSizeId = createdSize.Id,
                                        IngredientId = ingredient.Id,
                                        RequiredQuantity = Convert.ToDouble(row.Cells["colIngredientQuantity"].Value)
                                    });
                                }
                            }
                        }
                    }
                }
                LoadProducts();
                ClearForm();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null || !decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal price))
                return;

            selectedProduct.Name = txtProductName.Text.Trim();
            selectedProduct.CategoryId = cmbCategory.SelectedValue?.ToString();
            selectedProduct.IsAvailable = cmbStatus.SelectedIndex == 0;

            if (ProductBUS.Instance.EditProduct(selectedProduct))
            {
                var size = ProductSizeBUS.Instance.GetSizesByProduct(selectedProduct.Id)
                    .FirstOrDefault(s => s.SizeName == selectedSize);

                if (size != null)
                {
                    foreach (var ing in ProductIngredientBUS.Instance.GetRecipe(size.Id))
                        ProductIngredientBUS.Instance.RemoveIngredientFromRecipe(ing.Id);

                    foreach (DataGridViewRow row in dgvIngredientsList.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var ingredient = ingredientList.FirstOrDefault(i => i.Name == row.Cells["colIngredientName"].Value?.ToString());
                        if (ingredient != null)
                        {
                            ProductIngredientBUS.Instance.AddIngredientToRecipe(new ProductIngredientDTO
                            {
                                ProductSizeId = size.Id,
                                IngredientId = ingredient.Id,
                                RequiredQuantity = Convert.ToDouble(row.Cells["colIngredientQuantity"].Value)
                            });
                        }
                    }
                }
                LoadProducts();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProduct != null && MessageBox.Show("Xóa món?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ProductBUS.Instance.RemoveProduct(selectedProduct.Id))
                {
                    LoadProducts();
                    ClearForm();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayProducts(string.IsNullOrEmpty(txtSearch.Text.Trim())
                ? productList
                : ProductBUS.Instance.SearchProduct(txtSearch.Text.Trim()));
        }

        //toolstrip
        private void tsbCoffee_Click(object sender, EventArgs e) =>
            LoadProducts(categoryList.FirstOrDefault(c => c.Name == "Cà phê")?.Id);

        private void tsbTea_Click(object sender, EventArgs e) =>
            LoadProducts(categoryList.FirstOrDefault(c => c.Name == "Trà")?.Id);

        private void tsbCake_Click(object sender, EventArgs e) =>
            LoadProducts(categoryList.FirstOrDefault(c => c.Name == "Bánh")?.Id);

        private void tsbOther_Click(object sender, EventArgs e) =>
            LoadProducts(categoryList.FirstOrDefault(c => c.Name == "Khác")?.Id);

        private void tsbAll_Click(object sender, EventArgs e) => LoadProducts();

        private void ClearForm()
        {
            txtProductName.Clear();
            txtPrice.Clear();
            cmbCategory.SelectedIndex = 0;
            cmbProductSize.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            dgvIngredientsList.Rows.Clear();
            selectedProduct = null;
        }

        private void tsCategory_Resize(object sender, EventArgs e)
        {
            int buttonCount = 0;
            foreach (ToolStripItem item in tsCategory.Items)
            {
                if (item is ToolStripButton) buttonCount++;
            }

            if (buttonCount > 0)
            {
                int totalWidth = tsCategory.DisplayRectangle.Width - 2;
                int eachWidth = totalWidth / buttonCount;

                foreach (ToolStripItem item in tsCategory.Items)
                {
                    if (item is ToolStripButton btn)
                    {
                        btn.AutoSize = false;
                        btn.Width = eachWidth;
                        btn.TextAlign = ContentAlignment.MiddleCenter;
                    }
                }
            }
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (cmbIngredientName.SelectedValue == null || !double.TryParse(txtIngredientQuantity.Text, out double qty) || qty <= 0)
                return;

            var ingredient = ingredientList.FirstOrDefault(i => i.Id == cmbIngredientName.SelectedValue.ToString());

            for (int i = 0; i < dgvIngredientsList.Rows.Count; i++)
            {
                if (dgvIngredientsList.Rows[i].Cells["colIngredientName"].Value?.ToString() == ingredient.Name)
                {
                    dgvIngredientsList.Rows[i].Cells["colIngredientQuantity"].Value = qty;
                    return;
                }
            }

            dgvIngredientsList.Rows.Add(ingredient.Name, qty, ingredient.Unit, "Xóa");
        }

        private void dgvIngredientsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvIngredientsList.Columns["colDelete"].Index)
            {
                dgvIngredientsList.Rows.RemoveAt(e.RowIndex);
                return;
            }

            var row = dgvIngredientsList.Rows[e.RowIndex];
            var ingredient = ingredientList.FirstOrDefault(i => i.Name == row.Cells["colIngredientName"].Value?.ToString());
            if (ingredient != null)
            {
                cmbIngredientName.SelectedValue = ingredient.Id;
                txtIngredientQuantity.Text = row.Cells["colIngredientQuantity"].Value?.ToString();
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedValue != null && cmbCategory.Focused)
            {
                string selectedCategoryId = cmbCategory.SelectedValue.ToString();
                LoadProducts(selectedCategoryId);
                txtPrice.Clear();
                dgvIngredientsList.Rows.Clear();
            }
        }

    }
}