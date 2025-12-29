namespace OHIOCF.Controls
{
    partial class UC_Products
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Products));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flpMenuItems = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpProduct = new System.Windows.Forms.TableLayoutPanel();
            this.pbProductPicture = new System.Windows.Forms.PictureBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.cmbFilterType = new System.Windows.Forms.TableLayoutPanel();
            this.tsCategory = new System.Windows.Forms.ToolStrip();
            this.tsbCoffee = new System.Windows.Forms.ToolStripButton();
            this.tsbTea = new System.Windows.Forms.ToolStripButton();
            this.tsbOther = new System.Windows.Forms.ToolStripButton();
            this.tsbAll = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.lblProductName2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblProductSize = new System.Windows.Forms.Label();
            this.cmbProductSize = new System.Windows.Forms.ComboBox();
            this.lblIngredientsList = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dgvIngredientsList = new System.Windows.Forms.DataGridView();
            this.colIngredientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIngredientQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIngredientUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIngredientQuantity = new System.Windows.Forms.TextBox();
            this.cmbIngredientName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbIngredientUnit = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flpMenuItems.SuspendLayout();
            this.tlpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductPicture)).BeginInit();
            this.cmbFilterType.SuspendLayout();
            this.tsCategory.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientsList)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.1063F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.8937F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1063, 700);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.flpMenuItems, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbFilterType, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.48415F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.51585F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(515, 694);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // flpMenuItems
            // 
            this.flpMenuItems.AutoScroll = true;
            this.flpMenuItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.flpMenuItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel3.SetColumnSpan(this.flpMenuItems, 20);
            this.flpMenuItems.Controls.Add(this.tlpProduct);
            this.flpMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenuItems.Location = new System.Drawing.Point(0, 45);
            this.flpMenuItems.Margin = new System.Windows.Forms.Padding(0);
            this.flpMenuItems.Name = "flpMenuItems";
            this.flpMenuItems.Size = new System.Drawing.Size(515, 649);
            this.flpMenuItems.TabIndex = 22;
            // 
            // tlpProduct
            // 
            this.tlpProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tlpProduct.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpProduct.ColumnCount = 2;
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.78355F));
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.21645F));
            this.tlpProduct.Controls.Add(this.pbProductPicture, 0, 0);
            this.tlpProduct.Controls.Add(this.lblProductName, 0, 1);
            this.tlpProduct.Controls.Add(this.lblProductPrice, 1, 1);
            this.tlpProduct.Location = new System.Drawing.Point(3, 3);
            this.tlpProduct.Name = "tlpProduct";
            this.tlpProduct.RowCount = 2;
            this.tlpProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.65363F));
            this.tlpProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.34637F));
            this.tlpProduct.Size = new System.Drawing.Size(230, 180);
            this.tlpProduct.TabIndex = 0;
            // 
            // pbProductPicture
            // 
            this.tlpProduct.SetColumnSpan(this.pbProductPicture, 2);
            this.pbProductPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProductPicture.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbProductPicture.ErrorImage")));
            this.pbProductPicture.Image = ((System.Drawing.Image)(resources.GetObject("pbProductPicture.Image")));
            this.pbProductPicture.Location = new System.Drawing.Point(1, 1);
            this.pbProductPicture.Margin = new System.Windows.Forms.Padding(0);
            this.pbProductPicture.Name = "pbProductPicture";
            this.pbProductPicture.Size = new System.Drawing.Size(228, 137);
            this.pbProductPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductPicture.TabIndex = 0;
            this.pbProductPicture.TabStop = false;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(4, 139);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(107, 40);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Tên món";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.Location = new System.Drawing.Point(118, 139);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(108, 40);
            this.lblProductPrice.TabIndex = 2;
            this.lblProductPrice.Text = "Giá";
            this.lblProductPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.ColumnCount = 1;
            this.cmbFilterType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.32951F));
            this.cmbFilterType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.67049F));
            this.cmbFilterType.Controls.Add(this.tsCategory, 0, 0);
            this.cmbFilterType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFilterType.Location = new System.Drawing.Point(3, 3);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.RowCount = 1;
            this.cmbFilterType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cmbFilterType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cmbFilterType.Size = new System.Drawing.Size(509, 39);
            this.cmbFilterType.TabIndex = 23;
            // 
            // tsCategory
            // 
            this.tsCategory.AutoSize = false;
            this.tsCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsCategory.Font = new System.Drawing.Font("Bahnschrift Light", 10F, System.Drawing.FontStyle.Bold);
            this.tsCategory.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsCategory.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsCategory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCoffee,
            this.tsbTea,
            this.tsbOther,
            this.tsbAll});
            this.tsCategory.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsCategory.Location = new System.Drawing.Point(0, 0);
            this.tsCategory.Name = "tsCategory";
            this.tsCategory.ShowItemToolTips = false;
            this.tsCategory.Size = new System.Drawing.Size(509, 39);
            this.tsCategory.TabIndex = 24;
            this.tsCategory.Text = "toolStrip1";
            this.tsCategory.Resize += new System.EventHandler(this.tsCategory_Resize);
            // 
            // tsbCoffee
            // 
            this.tsbCoffee.AutoSize = false;
            this.tsbCoffee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCoffee.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.tsbCoffee.Image = ((System.Drawing.Image)(resources.GetObject("tsbCoffee.Image")));
            this.tsbCoffee.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tsbCoffee.Margin = new System.Windows.Forms.Padding(0);
            this.tsbCoffee.Name = "tsbCoffee";
            this.tsbCoffee.Size = new System.Drawing.Size(90, 40);
            this.tsbCoffee.Tag = "Cà phê";
            this.tsbCoffee.Text = "Cà phê";
            this.tsbCoffee.Click += new System.EventHandler(this.tsbCoffee_Click);
            // 
            // tsbTea
            // 
            this.tsbTea.AutoSize = false;
            this.tsbTea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTea.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.tsbTea.Image = ((System.Drawing.Image)(resources.GetObject("tsbTea.Image")));
            this.tsbTea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTea.Margin = new System.Windows.Forms.Padding(0);
            this.tsbTea.Name = "tsbTea";
            this.tsbTea.Size = new System.Drawing.Size(90, 40);
            this.tsbTea.Tag = "Trà";
            this.tsbTea.Text = "Trà";
            this.tsbTea.Click += new System.EventHandler(this.tsbTea_Click);
            // 
            // tsbOther
            // 
            this.tsbOther.AutoSize = false;
            this.tsbOther.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOther.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.tsbOther.Image = ((System.Drawing.Image)(resources.GetObject("tsbOther.Image")));
            this.tsbOther.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOther.Margin = new System.Windows.Forms.Padding(0);
            this.tsbOther.Name = "tsbOther";
            this.tsbOther.Size = new System.Drawing.Size(90, 40);
            this.tsbOther.Tag = "Khác";
            this.tsbOther.Text = "Khác";
            this.tsbOther.Click += new System.EventHandler(this.tsbOther_Click);
            // 
            // tsbAll
            // 
            this.tsbAll.AutoSize = false;
            this.tsbAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAll.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.tsbAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbAll.Image")));
            this.tsbAll.ImageTransparentColor = System.Drawing.SystemColors.Menu;
            this.tsbAll.Margin = new System.Windows.Forms.Padding(0);
            this.tsbAll.Name = "tsbAll";
            this.tsbAll.Size = new System.Drawing.Size(90, 40);
            this.tsbAll.Text = "Tất cả";
            this.tsbAll.Click += new System.EventHandler(this.tsbAll_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 20;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9960161F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.428044F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.65314F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.01107F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.583026F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.980079F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9960161F));
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.pbProductImage, 7, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtSearch, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnUploadImage, 9, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblProductName2, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtProductName, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblCategory, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblProductSize, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.cmbProductSize, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.lblIngredientsList, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.lblPrice, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.txtPrice, 3, 8);
            this.tableLayoutPanel2.Controls.Add(this.dgvIngredientsList, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 2, 13);
            this.tableLayoutPanel2.Controls.Add(this.label1, 9, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtIngredientQuantity, 13, 7);
            this.tableLayoutPanel2.Controls.Add(this.cmbIngredientName, 13, 6);
            this.tableLayoutPanel2.Controls.Add(this.label2, 10, 6);
            this.tableLayoutPanel2.Controls.Add(this.label3, 10, 7);
            this.tableLayoutPanel2.Controls.Add(this.label4, 10, 8);
            this.tableLayoutPanel2.Controls.Add(this.btnAddIngredient, 16, 9);
            this.tableLayoutPanel2.Controls.Add(this.lblStatus, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.cmbIngredientUnit, 13, 8);
            this.tableLayoutPanel2.Controls.Add(this.cmbStatus, 3, 9);
            this.tableLayoutPanel2.Controls.Add(this.cmbCategory, 3, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(521, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 17;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.938073F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.233301F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.7797753F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.9332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.233301F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.233301F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.233301F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.233301F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.233301F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.233301F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.233301F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.8664F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.233301F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.7797753F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.88521F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.7797753F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.938073F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(542, 700);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnSearch, 3);
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnSearch.Location = new System.Drawing.Point(7, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(121, 25);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pbProductImage
            // 
            this.pbProductImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel2.SetColumnSpan(this.pbProductImage, 6);
            this.pbProductImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbProductImage.Location = new System.Drawing.Point(214, 50);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(154, 112);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductImage.TabIndex = 1;
            this.pbProductImage.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtSearch, 15);
            this.txtSearch.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtSearch.Location = new System.Drawing.Point(131, 14);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(1);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(401, 27);
            this.txtSearch.TabIndex = 11;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnUploadImage, 2);
            this.btnUploadImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUploadImage.FlatAppearance.BorderSize = 0;
            this.btnUploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUploadImage.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnUploadImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnUploadImage.Location = new System.Drawing.Point(268, 168);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(48, 23);
            this.btnUploadImage.TabIndex = 2;
            this.btnUploadImage.Text = "Nhập";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // lblProductName2
            // 
            this.lblProductName2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblProductName2, 2);
            this.lblProductName2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName2.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductName2.Location = new System.Drawing.Point(8, 194);
            this.lblProductName2.Name = "lblProductName2";
            this.lblProductName2.Size = new System.Drawing.Size(92, 29);
            this.lblProductName2.TabIndex = 4;
            this.lblProductName2.Text = "Tên món";
            this.lblProductName2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtProductName, 6);
            this.txtProductName.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtProductName.Location = new System.Drawing.Point(103, 197);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(162, 23);
            this.txtProductName.TabIndex = 13;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblCategory, 2);
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategory.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(8, 223);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(92, 29);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Loại";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductSize
            // 
            this.lblProductSize.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblProductSize, 2);
            this.lblProductSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductSize.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductSize.Location = new System.Drawing.Point(8, 252);
            this.lblProductSize.Name = "lblProductSize";
            this.lblProductSize.Size = new System.Drawing.Size(92, 29);
            this.lblProductSize.TabIndex = 24;
            this.lblProductSize.Text = "Size";
            this.lblProductSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProductSize
            // 
            this.cmbProductSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cmbProductSize, 6);
            this.cmbProductSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductSize.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.cmbProductSize.FormattingEnabled = true;
            this.cmbProductSize.Items.AddRange(new object[] {
            "S",
            "M",
            "L"});
            this.cmbProductSize.Location = new System.Drawing.Point(103, 255);
            this.cmbProductSize.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cmbProductSize.Name = "cmbProductSize";
            this.cmbProductSize.Size = new System.Drawing.Size(162, 27);
            this.cmbProductSize.TabIndex = 26;
            this.cmbProductSize.SelectedIndexChanged += new System.EventHandler(this.cmbProductSize_SelectedIndexChanged);
            // 
            // lblIngredientsList
            // 
            this.lblIngredientsList.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblIngredientsList, 5);
            this.lblIngredientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIngredientsList.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblIngredientsList.Location = new System.Drawing.Point(8, 339);
            this.lblIngredientsList.Name = "lblIngredientsList";
            this.lblIngredientsList.Size = new System.Drawing.Size(173, 29);
            this.lblIngredientsList.TabIndex = 25;
            this.lblIngredientsList.Text = "Danh sách NVL";
            this.lblIngredientsList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblPrice, 2);
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(8, 281);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(92, 29);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Giá";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtPrice, 6);
            this.txtPrice.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtPrice.Location = new System.Drawing.Point(103, 284);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtPrice.Multiline = true;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(162, 23);
            this.txtPrice.TabIndex = 28;
            // 
            // dgvIngredientsList
            // 
            this.dgvIngredientsList.BackgroundColor = System.Drawing.Color.White;
            this.dgvIngredientsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIngredientName,
            this.colIngredientQuantity,
            this.colIngredientUnit,
            this.IngredientId,
            this.colDelete});
            this.tableLayoutPanel2.SetColumnSpan(this.dgvIngredientsList, 18);
            this.dgvIngredientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngredientsList.Location = new System.Drawing.Point(5, 368);
            this.dgvIngredientsList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvIngredientsList.Name = "dgvIngredientsList";
            this.dgvIngredientsList.Size = new System.Drawing.Size(528, 237);
            this.dgvIngredientsList.TabIndex = 27;
            this.dgvIngredientsList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngredientsList_CellClick);
            // 
            // colIngredientName
            // 
            this.colIngredientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colIngredientName.DataPropertyName = "IngredientName";
            this.colIngredientName.HeaderText = "Tên NVL";
            this.colIngredientName.Name = "colIngredientName";
            this.colIngredientName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colIngredientQuantity
            // 
            this.colIngredientQuantity.DataPropertyName = "Quantity";
            this.colIngredientQuantity.HeaderText = "SL";
            this.colIngredientQuantity.Name = "colIngredientQuantity";
            this.colIngredientQuantity.Width = 40;
            // 
            // colIngredientUnit
            // 
            this.colIngredientUnit.DataPropertyName = "Unit";
            this.colIngredientUnit.HeaderText = "Đơn vị";
            this.colIngredientUnit.Name = "colIngredientUnit";
            this.colIngredientUnit.Width = 60;
            // 
            // IngredientId
            // 
            this.IngredientId.HeaderText = "Mã NVL";
            this.IngredientId.Name = "IngredientId";
            this.IngredientId.Visible = false;
            // 
            // colDelete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = "Xóa";
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDelete.Width = 40;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel6, 16);
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnUpdate, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(29, 634);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel2.SetRowSpan(this.tableLayoutPanel6, 3);
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(477, 44);
            this.tableLayoutPanel6.TabIndex = 32;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnDelete.Location = new System.Drawing.Point(323, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 34);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "XÓA";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnUpdate.Location = new System.Drawing.Point(164, 5);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(149, 34);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "CẬP NHẬT";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnAdd.Location = new System.Drawing.Point(5, 5);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(149, 34);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "THÊM";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 4);
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(268, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 40;
            this.label1.Text = "Thêm NVL:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIngredientQuantity
            // 
            this.txtIngredientQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtIngredientQuantity, 6);
            this.txtIngredientQuantity.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtIngredientQuantity.Location = new System.Drawing.Point(371, 255);
            this.txtIngredientQuantity.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtIngredientQuantity.Multiline = true;
            this.txtIngredientQuantity.Name = "txtIngredientQuantity";
            this.txtIngredientQuantity.Size = new System.Drawing.Size(162, 23);
            this.txtIngredientQuantity.TabIndex = 45;
            // 
            // cmbIngredientName
            // 
            this.cmbIngredientName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIngredientName.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel2.SetColumnSpan(this.cmbIngredientName, 6);
            this.cmbIngredientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngredientName.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.cmbIngredientName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbIngredientName.FormattingEnabled = true;
            this.cmbIngredientName.Location = new System.Drawing.Point(371, 226);
            this.cmbIngredientName.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cmbIngredientName.Name = "cmbIngredientName";
            this.cmbIngredientName.Size = new System.Drawing.Size(162, 27);
            this.cmbIngredientName.TabIndex = 44;
            this.cmbIngredientName.SelectedIndexChanged += new System.EventHandler(this.cmbIngredientName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 3);
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(295, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 29);
            this.label2.TabIndex = 41;
            this.label2.Text = "Tên NVL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label3, 3);
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(295, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 42;
            this.label3.Text = "SL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label4, 3);
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(295, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 43;
            this.label4.Text = "Đơn vị";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnAddIngredient, 3);
            this.btnAddIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddIngredient.FlatAppearance.BorderSize = 0;
            this.btnAddIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddIngredient.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddIngredient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnAddIngredient.Location = new System.Drawing.Point(462, 320);
            this.btnAddIngredient.Margin = new System.Windows.Forms.Padding(10);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.tableLayoutPanel2.SetRowSpan(this.btnAddIngredient, 2);
            this.btnAddIngredient.Size = new System.Drawing.Size(61, 38);
            this.btnAddIngredient.TabIndex = 29;
            this.btnAddIngredient.Text = "THÊM";
            this.btnAddIngredient.UseVisualStyleBackColor = false;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblStatus, 2);
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(8, 310);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(92, 29);
            this.lblStatus.TabIndex = 30;
            this.lblStatus.Text = "Trạng thái";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbIngredientUnit
            // 
            this.cmbIngredientUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cmbIngredientUnit, 6);
            this.cmbIngredientUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngredientUnit.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.cmbIngredientUnit.FormattingEnabled = true;
            this.cmbIngredientUnit.Items.AddRange(new object[] {
            "kg",
            "g",
            "lít",
            "ml"});
            this.cmbIngredientUnit.Location = new System.Drawing.Point(371, 284);
            this.cmbIngredientUnit.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cmbIngredientUnit.Name = "cmbIngredientUnit";
            this.cmbIngredientUnit.Size = new System.Drawing.Size(162, 27);
            this.cmbIngredientUnit.TabIndex = 31;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel2.SetColumnSpan(this.cmbStatus, 6);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.cmbStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Đang bán",
            "Ngưng bán"});
            this.cmbStatus.Location = new System.Drawing.Point(103, 313);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(162, 27);
            this.cmbStatus.TabIndex = 46;
            // 
            // cmbCategory
            // 
            this.cmbCategory.AllowDrop = true;
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel2.SetColumnSpan(this.cmbCategory, 6);
            this.cmbCategory.DisplayMember = "Name";
            this.cmbCategory.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.cmbCategory.ForeColor = System.Drawing.Color.Black;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(103, 226);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(162, 27);
            this.cmbCategory.TabIndex = 47;
            this.cmbCategory.ValueMember = "Id";
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // UC_Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_Products";
            this.Size = new System.Drawing.Size(1063, 700);
            this.Load += new System.EventHandler(this.UC_Products_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flpMenuItems.ResumeLayout(false);
            this.tlpProduct.ResumeLayout(false);
            this.tlpProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductPicture)).EndInit();
            this.cmbFilterType.ResumeLayout(false);
            this.tsCategory.ResumeLayout(false);
            this.tsCategory.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientsList)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Label lblProductName2;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flpMenuItems;
        private System.Windows.Forms.TableLayoutPanel tlpProduct;
        private System.Windows.Forms.PictureBox pbProductPicture;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label lblIngredientsList;
        private System.Windows.Forms.ComboBox cmbProductSize;
        private System.Windows.Forms.DataGridView dgvIngredientsList;
        private System.Windows.Forms.Label lblProductSize;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbIngredientUnit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIngredientQuantity;
        private System.Windows.Forms.ComboBox cmbIngredientName;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TableLayoutPanel cmbFilterType;
        private System.Windows.Forms.ToolStrip tsCategory;
        private System.Windows.Forms.ToolStripButton tsbCoffee;
        private System.Windows.Forms.ToolStripButton tsbTea;
        private System.Windows.Forms.ToolStripButton tsbOther;
        private System.Windows.Forms.ToolStripButton tsbAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngredientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngredientQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngredientUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientId;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}
