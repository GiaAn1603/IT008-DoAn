using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OHIOCF.BUS;
using OHIOCF.DTO;

namespace OHIOCF.Controls
{
    public partial class UC_Products : UserControl
    {
        private string currentProductId = null;
        private string currentProductSizeId = null;
        private string currentImagePath = null;

        private List<CategoryDTO> categoryList;
        private List<IngredientDTO> ingredientList;
        private CultureInfo culture = new CultureInfo("vi-VN");

        public UC_Products()
        {
            InitializeComponent();
        }

        private void UC_Products_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            LoadCategories();
            LoadIngredients();
            LoadProducts("All");
        }

        private void InitDataGridView()
        {
            dgvIngredientsList.AutoGenerateColumns = false;
            dgvIngredientsList.AllowUserToAddRows = false;
        }

        // load data
        private void LoadCategories()
        {
            categoryList = CategoryBUS.Instance.GetAllCategories();
            cmbCategory.DataSource = categoryList;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        private void LoadIngredients()
        {
            ingredientList = IngredientBUS.Instance.GetAll();
            cmbIngredientName.DataSource = ingredientList;
            cmbIngredientName.DisplayMember = "Name";
            cmbIngredientName.ValueMember = "Id";
        }

        // category button
        private void tsbCoffee_Click(object sender, EventArgs e)
        {
            LoadProducts("Cà Phê");
        }

        private void tsbTea_Click(object sender, EventArgs e)
        {
            LoadProducts("Trà");
        }

        private void tsbOther_Click(object sender, EventArgs e)
        {
            LoadProducts("Khác");
        }

        private void tsbAll_Click(object sender, EventArgs e)
        {
            LoadProducts("All");
        }

        private void tsCategory_Resize(object sender, EventArgs e)
        {
            int count = tsCategory.Items.OfType<ToolStripButton>().Count();
            if (count > 0)
            {
                int width = (tsCategory.DisplayRectangle.Width - 5) / count;
                foreach (ToolStripItem item in tsCategory.Items)
                {
                    if (item is ToolStripButton btn)
                    {
                        btn.AutoSize = false;
                        btn.Width = width;
                    }
                }
            }
        }

        // products
        private void LoadProducts(string categoryFilter)
        {
            List<ProductDTO> products;

            if (categoryFilter == "All")
            {
                products = ProductBUS.Instance.SearchProduct("");
            }
            else
            {
                // Map tên category sang ID
                var cat = categoryList.FirstOrDefault(c => c.Name == categoryFilter);
                string categoryId = cat != null ? cat.Id : null;

                if (categoryId != null)
                    products = ProductBUS.Instance.GetProductsByCategory(categoryId);
                else
                    products = new List<ProductDTO>();
            }

            RenderMenuItems(products);
        }

        private void RenderMenuItems(List<ProductDTO> products)
        {
            flpMenuItems.Controls.Clear();
            flpMenuItems.SuspendLayout();

            foreach (var product in products)
            {
                var panel = CreateProductPanel(product);
                flpMenuItems.Controls.Add(panel);
            }

            flpMenuItems.ResumeLayout();
        }

        private TableLayoutPanel CreateProductPanel(ProductDTO product)
        {
            TableLayoutPanel tlp = new TableLayoutPanel
            {
                Tag = product
            };

            // Copy style từ tlpProduct trong Designer
            tlp.Size = tlpProduct.Size;
            tlp.BackColor = tlpProduct.BackColor;
            tlp.CellBorderStyle = tlpProduct.CellBorderStyle;
            tlp.ColumnCount = tlpProduct.ColumnCount;
            tlp.RowCount = tlpProduct.RowCount;

            foreach (ColumnStyle cs in tlpProduct.ColumnStyles)
                tlp.ColumnStyles.Add(new ColumnStyle(cs.SizeType, cs.Width));

            foreach (RowStyle rs in tlpProduct.RowStyles)
                tlp.RowStyles.Add(new RowStyle(rs.SizeType, rs.Height));

            // PictureBox
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

            pb.Click += ProductPanel_Click;
            tlp.Controls.Add(pb, 0, 0);
            tlp.SetColumnSpan(pb, 2);

            // Label Name (copy từ lblProductName)
            Label lblName = new Label
            {
                Text = product.Name,
                Dock = DockStyle.Fill,
                Font = lblProductName.Font,
                TextAlign = lblProductName.TextAlign,
                Tag = product
            };
            lblName.Click += ProductPanel_Click;
            tlp.Controls.Add(lblName, 0, 1);

            // Label Price (copy từ lblProductPrice)
            decimal displayPrice = ProductBUS.Instance.GetDisplayPrice(product.Id);
            Label lblPrice = new Label
            {
                Text = displayPrice.ToString("N0", culture) + " đ",
                Dock = DockStyle.Fill,
                Font = lblProductPrice.Font,
                TextAlign = lblProductPrice.TextAlign,
                Tag = product
            };
            lblPrice.Click += ProductPanel_Click;
            tlp.Controls.Add(lblPrice, 1, 1);

            tlp.Click += ProductPanel_Click;

            return tlp;
        }

        private void ProductPanel_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            ProductDTO product = ctrl.Tag as ProductDTO;

            if (product == null) return;

            // Tìm size ưu tiên: M → S → L
            var sizes = ProductSizeBUS.Instance.GetSizesByProduct(product.Id);
            ProductSizeDTO prioritySize = sizes.FirstOrDefault(s => s.SizeName == "M")
                ?? sizes.FirstOrDefault(s => s.SizeName == "S")
                ?? sizes.FirstOrDefault(s => s.SizeName == "L");

            LoadProductToForm(product, prioritySize?.Id);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var products = ProductBUS.Instance.SearchProduct(keyword);
            RenderMenuItems(products);
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = ofd.FileName;
                    pbProductImage.Image = Image.FromFile(currentImagePath);
                }
            }
        }

        public class IngredientViewModel
        {
            public string IngredientId { get; set; }
            public string IngredientName { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
        }

        private void LoadRecipeToGrid(string productSizeId)
        {
            if (string.IsNullOrEmpty(productSizeId))
            {
                dgvIngredientsList.DataSource = null;
                return;
            }

            var recipe = ProductIngredientBUS.Instance.GetRecipe(productSizeId);
            var viewModels = new List<IngredientViewModel>();

            foreach (var item in recipe)
            {
                var ingredient = ingredientList.FirstOrDefault(i => i.Id == item.IngredientId);
                if (ingredient != null)
                {
                    viewModels.Add(new IngredientViewModel
                    {
                        IngredientId = ingredient.Id,
                        IngredientName = ingredient.Name,
                        Quantity = item.RequiredQuantity,
                        Unit = ingredient.Unit
                    });
                }
            }

            dgvIngredientsList.DataSource = viewModels;
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (cmbIngredientName.SelectedValue == null) return;
            if (string.IsNullOrWhiteSpace(txtIngredientQuantity.Text)) return;
            if (cmbIngredientUnit.SelectedItem == null) return;

            double quantity;
            if (!double.TryParse(txtIngredientQuantity.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ");
                return;
            }

            string ingredientId = cmbIngredientName.SelectedValue.ToString();
            var ingredient = ingredientList.FirstOrDefault(i => i.Id == ingredientId);

            var currentList = (dgvIngredientsList.DataSource as List<IngredientViewModel>) ?? new List<IngredientViewModel>();

            // Check trùng
            if (currentList.Any(x => x.IngredientId == ingredientId))
            {
                MessageBox.Show("Nguyên liệu đã có trong danh sách");
                return;
            }

            currentList.Add(new IngredientViewModel
            {
                IngredientId = ingredientId,
                IngredientName = ingredient.Name,
                Quantity = quantity,
                Unit = cmbIngredientUnit.SelectedItem.ToString()
            });

            dgvIngredientsList.DataSource = null;
            dgvIngredientsList.DataSource = currentList;

            txtIngredientQuantity.Clear();
        }

        private void dgvIngredientsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvIngredientsList.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var currentList = dgvIngredientsList.DataSource as List<IngredientViewModel>;
                if (currentList != null)
                {
                    currentList.RemoveAt(e.RowIndex);
                    dgvIngredientsList.DataSource = null;
                    dgvIngredientsList.DataSource = currentList;
                }
            }
        }

        private void cmbIngredientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIngredientName.SelectedValue == null) return;
            var ingredient = ingredientList.FirstOrDefault(i => i.Id == cmbIngredientName.SelectedValue.ToString());
            if (ingredient != null)
            {
                cmbIngredientUnit.SelectedItem = ingredient.Unit;
            }
        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbProductSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentProductId == null) return;
            if (cmbProductSize.SelectedItem == null) return;

            string sizeName = cmbProductSize.SelectedItem.ToString();
            var sizes = ProductSizeBUS.Instance.GetSizesByProduct(currentProductId);
            var selectedSize = sizes.FirstOrDefault(s => s.SizeName == sizeName);

            if (selectedSize != null)
            {
                currentProductSizeId = selectedSize.Id;
                decimal price = ProductBUS.Instance.GetProductById(currentProductId).BasePrice + selectedSize.PriceAdjustment;
                txtPrice.Text = price.ToString();
                LoadRecipeToGrid(selectedSize.Id);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Nhập tên món");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Chọn hoặc nhập danh mục");
                return;
            }

            if (cmbProductSize.SelectedItem == null)
            {
                MessageBox.Show("Chọn size");
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("Giá không hợp lệ");
                return;
            }

            var ingredientList = dgvIngredientsList.DataSource as List<IngredientViewModel>;
            if (ingredientList == null || ingredientList.Count == 0)
            {
                MessageBox.Show("Thêm ít nhất 1 nguyên liệu");
                return;
            }

            string sizeName = cmbProductSize.SelectedItem.ToString();
            string inputName = txtProductName.Text.Trim();

            // THÊM MÓN HAY THÊM SIZE
            bool isAddingNewProduct = true;
            ProductDTO oldProduct = null;

            if (currentProductId != null)
            {
                oldProduct = ProductBUS.Instance.GetProductById(currentProductId);

                if (oldProduct != null &&
                    oldProduct.Name.Trim().Equals(inputName, StringComparison.OrdinalIgnoreCase))
                {
                    isAddingNewProduct = false; // cùng tên → thêm size
                }
            }

            //LẤY / TẠO CATEGORY
            string categoryId = CategoryBUS.Instance.NormalizeAndGetOrCreate(cmbCategory.Text);

            //THÊM MÓN MỚI
            if (isAddingNewProduct)
            {
                // Món mới BẮT BUỘC bắt đầu từ size S
                if (sizeName != "S")
                {
                    MessageBox.Show("Món mới phải bắt đầu từ size S");
                    return;
                }

                // Không cho trùng tên món
                if (ProductBUS.Instance.ExistsByName(inputName))
                {
                    MessageBox.Show("Tên món đã tồn tại");
                    return;
                }

                // Lưu ảnh
                string imagePath = "";
                if (!string.IsNullOrEmpty(currentImagePath))
                {
                    // SỬA DÒNG NÀY: Đổi "Images" thành "assets"
                    string folder = Path.Combine(Application.StartupPath, "assets");

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    // Tạo tên file ngẫu nhiên để không bị trùng
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(currentImagePath);
                    string destPath = Path.Combine(folder, fileName);

                    // Copy ảnh từ máy vào thư mục assets
                    File.Copy(currentImagePath, destPath, true);

                    // Lưu đường dẫn tuyệt đối để dễ load (hoặc bạn có thể lưu relative path "assets/tenfile.jpg")
                    imagePath = destPath;
                }

                // INSERT Product
                string productId = Guid.NewGuid().ToString();
                ProductDTO product = new ProductDTO
                {
                    Id = productId,
                    CategoryId = categoryId,
                    Name = inputName,
                    BasePrice = price,
                    Image = imagePath,
                    IsAvailable = cmbStatus.SelectedIndex == 0
                };

                if (!ProductBUS.Instance.AddProduct(product))
                {
                    MessageBox.Show("Lỗi thêm món");
                    return;
                }

                currentProductId = productId;

                // INSERT ProductSize (S)
                string sizeId = Guid.NewGuid().ToString();
                ProductSizeDTO size = new ProductSizeDTO
                {
                    Id = sizeId,
                    ProductId = productId,
                    SizeName = "S",
                    PriceAdjustment = 0
                };

                ProductSizeBUS.Instance.AddSize(size);
                currentProductSizeId = sizeId;

                // INSERT ProductIngredient
                foreach (var item in ingredientList)
                {
                    ProductIngredientDTO pi = new ProductIngredientDTO
                    {
                        ProductSizeId = sizeId,
                        IngredientId = item.IngredientId,
                        RequiredQuantity = item.Quantity
                    };
                    ProductIngredientBUS.Instance.AddIngredientToRecipe(pi);
                }

                MessageBox.Show("Thêm món mới thành công");
            }
            //THÊM SIZE
            else
            {
                if (sizeName == "S")
                {
                    MessageBox.Show("Size S đã tồn tại cho món này");
                    return;
                }

                var sizes = ProductSizeBUS.Instance.GetSizesByProduct(currentProductId);
                if (sizes.Any(s => s.SizeName == sizeName))
                {
                    MessageBox.Show("Size này đã tồn tại");
                    return;
                }

                decimal priceAdjustment = price - oldProduct.BasePrice;

                string sizeId = Guid.NewGuid().ToString();
                ProductSizeDTO size = new ProductSizeDTO
                {
                    Id = sizeId,
                    ProductId = currentProductId,
                    SizeName = sizeName,
                    PriceAdjustment = priceAdjustment
                };

                ProductSizeBUS.Instance.AddSize(size);
                currentProductSizeId = sizeId;

                foreach (var item in ingredientList)
                {
                    ProductIngredientDTO pi = new ProductIngredientDTO
                    {
                        ProductSizeId = sizeId,
                        IngredientId = item.IngredientId,
                        RequiredQuantity = item.Quantity
                    };
                    ProductIngredientBUS.Instance.AddIngredientToRecipe(pi);
                }

                MessageBox.Show("Thêm size thành công");
            }

            LoadProducts("All");
            LoadCategories();
        }


        // update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentProductId == null || currentProductSizeId == null)
            {
                MessageBox.Show("Chọn món để cập nhật");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Nhập tên món");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Chọn hoặc nhập danh mục");
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("Giá không hợp lệ");
                return;
            }

            var ingredientList = dgvIngredientsList.DataSource as List<IngredientViewModel>;
            if (ingredientList == null || ingredientList.Count == 0)
            {
                MessageBox.Show("Thêm ít nhất 1 nguyên liệu");
                return;
            }

            // LẤY / TẠO CATEGORY (KHÔNG DÙNG SelectedValue)
            string categoryId = CategoryBUS.Instance
                .NormalizeAndGetOrCreate(cmbCategory.Text);

            // Lưu ảnh mới (nếu có)
            string imagePath = currentImagePath;
            var oldProduct = ProductBUS.Instance.GetProductById(currentProductId);

            // Nếu người dùng có chọn ảnh mới (khác ảnh cũ)
            if (!string.IsNullOrEmpty(currentImagePath) && currentImagePath != oldProduct.Image)
            {
                // SỬA DÒNG NÀY: Đổi "Images" thành "assets"
                string folder = Path.Combine(Application.StartupPath, "assets");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(currentImagePath);
                string destPath = Path.Combine(folder, fileName);

                File.Copy(currentImagePath, destPath, true);
                imagePath = destPath;
            }
            else
            {
                imagePath = oldProduct.Image; // Giữ nguyên ảnh cũ
            }

            // UPDATE Product
            ProductDTO product = new ProductDTO
            {
                Id = currentProductId,
                CategoryId = categoryId,
                Name = txtProductName.Text.Trim(),
                BasePrice = oldProduct.BasePrice, // KHÔNG đổi base price
                Image = imagePath,
                IsAvailable = cmbStatus.SelectedIndex == 0
            };

            ProductBUS.Instance.EditProduct(product);

            // UPDATE ProductSize
            var currentSize = ProductSizeBUS.Instance
                .GetSizesByProduct(currentProductId)
                .FirstOrDefault(s => s.Id == currentProductSizeId);

            if (currentSize != null)
            {
                decimal priceAdjustment = price - oldProduct.BasePrice;
                currentSize.PriceAdjustment = priceAdjustment;
                ProductSizeBUS.Instance.EditSize(currentSize);
            }

            // DELETE old ProductIngredient
            var oldRecipe = ProductIngredientBUS.Instance
                .GetRecipe(currentProductSizeId);

            foreach (var item in oldRecipe)
            {
                ProductIngredientBUS.Instance.RemoveIngredientFromRecipe(item.Id);
            }

            // INSERT new ProductIngredient
            foreach (var item in ingredientList)
            {
                ProductIngredientDTO pi = new ProductIngredientDTO
                {
                    ProductSizeId = currentProductSizeId,
                    IngredientId = item.IngredientId,
                    RequiredQuantity = item.Quantity
                };
                ProductIngredientBUS.Instance.AddIngredientToRecipe(pi);
            }

            MessageBox.Show("Cập nhật thành công");

            LoadProducts("All");

            // REFRESH category list (phòng trường hợp vừa tạo category mới)
            string catText = cmbCategory.Text;
            LoadCategories();
            cmbCategory.Text = catText;
        }


        // delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentProductId == null)
            {
                MessageBox.Show("Chọn món để xóa");
                return;
            }

            if (MessageBox.Show("Xóa món này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ProductBUS.Instance.DeleteProductComplete(currentProductId))
                {
                    MessageBox.Show("Xóa thành công");
                    ResetForm();
                    LoadProducts("All");
                }
                else
                {
                    MessageBox.Show("Lỗi xóa món");
                }
            }
        }

        private void ResetForm()
        {
            currentProductId = null;
            currentProductSizeId = null;
            currentImagePath = null;

            txtProductName.Clear();
            txtPrice.Clear();
            pbProductImage.Image = null;
            cmbCategory.SelectedIndex = -1;
            cmbProductSize.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0;
            dgvIngredientsList.DataSource = null;
        }

        private void LoadProductToForm(ProductDTO product, string prioritySizeId)
        {
            currentProductId = product.Id;
            currentProductSizeId = prioritySizeId;
            currentImagePath = product.Image;

            txtProductName.Text = product.Name;

            try
            {
                if (!string.IsNullOrEmpty(product.Image) && File.Exists(product.Image))
                    pbProductImage.Image = Image.FromFile(product.Image);
                else
                    pbProductImage.Image = null;
            }
            catch
            {
                pbProductImage.Image = null;
            }

            // Set category
            var cat = categoryList.FirstOrDefault(c => c.Id == product.CategoryId);
            if (cat != null)
                cmbCategory.Text = cat.Name;

            cmbStatus.SelectedIndex = product.IsAvailable ? 0 : 1;

            // Load size
            if (!string.IsNullOrEmpty(prioritySizeId))
            {
                var size = ProductSizeBUS.Instance.GetSizesByProduct(product.Id)
                    .FirstOrDefault(s => s.Id == prioritySizeId);

                if (size != null)
                {
                    cmbProductSize.SelectedItem = size.SizeName;
                    decimal price = product.BasePrice + size.PriceAdjustment;
                    txtPrice.Text = price.ToString();
                    LoadRecipeToGrid(size.Id);
                }
            }
        }
    }
    
}