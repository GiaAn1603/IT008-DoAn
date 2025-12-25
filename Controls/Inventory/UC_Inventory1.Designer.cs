namespace OHIOCF.Controls.Inventory
{
    partial class UC_Inventory1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNVLName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.colMaNVL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNVL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNguongMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pbNVLImage = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtNVLCode = new System.Windows.Forms.TextBox();
            this.txtNVLName = new System.Windows.Forms.TextBox();
            this.lblNVLCode = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNVLImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNVLName
            // 
            this.lblNVLName.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblNVLName, 4);
            this.lblNVLName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNVLName.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblNVLName.Location = new System.Drawing.Point(3, 293);
            this.lblNVLName.Name = "lblNVLName";
            this.lblNVLName.Size = new System.Drawing.Size(132, 27);
            this.lblNVLName.TabIndex = 4;
            this.lblNVLName.Text = "Tên NVL";
            this.lblNVLName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblPrice, 4);
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(3, 401);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(132, 27);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Ngưỡng MIN";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvInventory
            // 
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNVL,
            this.colTenNVL,
            this.colDonVi,
            this.colTonKho,
            this.colNguongMin,
            this.colTrangThai});
            this.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventory.Location = new System.Drawing.Point(3, 46);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.Size = new System.Drawing.Size(698, 621);
            this.dgvInventory.TabIndex = 1;
            // 
            // colMaNVL
            // 
            this.colMaNVL.HeaderText = "Mã NVL";
            this.colMaNVL.Name = "colMaNVL";
            // 
            // colTenNVL
            // 
            this.colTenNVL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenNVL.HeaderText = "Tên nguyên vật liệu";
            this.colTenNVL.Name = "colTenNVL";
            // 
            // colDonVi
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDonVi.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDonVi.HeaderText = "Đơn vị tính";
            this.colDonVi.Name = "colDonVi";
            // 
            // colTonKho
            // 
            this.colTonKho.HeaderText = "Số lượng tồn";
            this.colTonKho.Name = "colTonKho";
            // 
            // colNguongMin
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNguongMin.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNguongMin.HeaderText = "Ngưỡng tối thiểu";
            this.colNguongMin.Name = "colNguongMin";
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dgvInventory, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.48415F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.51585F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(704, 670);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.64809F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.35192F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel4.Controls.Add(this.lblHeaderTitle, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(704, 43);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Bahnschrift Light", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(3, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(698, 43);
            this.lblHeaderTitle.TabIndex = 22;
            this.lblHeaderTitle.Text = "XEM TỒN KHO";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnSearch, 3);
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnSearch.Location = new System.Drawing.Point(39, 31);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // pbNVLImage
            // 
            this.pbNVLImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel2.SetColumnSpan(this.pbNVLImage, 4);
            this.pbNVLImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbNVLImage.Location = new System.Drawing.Point(108, 82);
            this.pbNVLImage.Name = "pbNVLImage";
            this.tableLayoutPanel2.SetRowSpan(this.pbNVLImage, 4);
            this.pbNVLImage.Size = new System.Drawing.Size(132, 102);
            this.pbNVLImage.TabIndex = 1;
            this.pbNVLImage.TabStop = false;
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
            this.btnUploadImage.Location = new System.Drawing.Point(141, 190);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(64, 27);
            this.btnUploadImage.TabIndex = 2;
            this.btnUploadImage.Text = "Nhập";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtSearch, 5);
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtSearch.Location = new System.Drawing.Point(138, 27);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(175, 27);
            this.txtSearch.TabIndex = 11;
            // 
            // txtNVLCode
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtNVLCode, 5);
            this.txtNVLCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNVLCode.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtNVLCode.Location = new System.Drawing.Point(138, 239);
            this.txtNVLCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtNVLCode.Name = "txtNVLCode";
            this.txtNVLCode.Size = new System.Drawing.Size(175, 27);
            this.txtNVLCode.TabIndex = 12;
            // 
            // txtNVLName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtNVLName, 5);
            this.txtNVLName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNVLName.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtNVLName.Location = new System.Drawing.Point(138, 293);
            this.txtNVLName.Margin = new System.Windows.Forms.Padding(0);
            this.txtNVLName.Name = "txtNVLName";
            this.txtNVLName.Size = new System.Drawing.Size(175, 27);
            this.txtNVLName.TabIndex = 13;
            // 
            // lblNVLCode
            // 
            this.lblNVLCode.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblNVLCode, 4);
            this.lblNVLCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNVLCode.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblNVLCode.Location = new System.Drawing.Point(3, 239);
            this.lblNVLCode.Name = "lblNVLCode";
            this.lblNVLCode.Size = new System.Drawing.Size(132, 27);
            this.lblNVLCode.TabIndex = 3;
            this.lblNVLCode.Text = "Mã NVL";
            this.lblNVLCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblUnit, 4);
            this.lblUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUnit.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblUnit.Location = new System.Drawing.Point(3, 347);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(132, 27);
            this.lblUnit.TabIndex = 5;
            this.lblUnit.Text = "Đơn vị tính";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblQuantity, 4);
            this.lblQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuantity.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.Location = new System.Drawing.Point(3, 455);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(132, 27);
            this.lblQuantity.TabIndex = 17;
            this.lblQuantity.Text = "Tồn kho";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtPrice, 5);
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtPrice.Location = new System.Drawing.Point(138, 401);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(175, 27);
            this.txtPrice.TabIndex = 14;
            // 
            // cmbUnit
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cmbUnit, 5);
            this.cmbUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbUnit.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(138, 347);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(0);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(175, 27);
            this.cmbUnit.TabIndex = 15;
            // 
            // txtQuantity
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtQuantity, 5);
            this.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantity.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtQuantity.Location = new System.Drawing.Point(138, 455);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(0);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(175, 27);
            this.txtQuantity.TabIndex = 18;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnAdd, 2);
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnAdd.Location = new System.Drawing.Point(38, 593);
            this.btnAdd.Name = "btnAdd";
            this.tableLayoutPanel2.SetRowSpan(this.btnAdd, 2);
            this.btnAdd.Size = new System.Drawing.Size(64, 46);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "THÊM MỚI";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnDelete, 2);
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnDelete.Location = new System.Drawing.Point(246, 593);
            this.btnDelete.Name = "btnDelete";
            this.tableLayoutPanel2.SetRowSpan(this.btnDelete, 2);
            this.btnDelete.Size = new System.Drawing.Size(64, 46);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "XÓA";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnUpdate, 2);
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnUpdate.Location = new System.Drawing.Point(141, 593);
            this.btnUpdate.Name = "btnUpdate";
            this.tableLayoutPanel2.SetRowSpan(this.btnUpdate, 2);
            this.btnUpdate.Size = new System.Drawing.Size(64, 46);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "CẬP NHẬT";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label6, 3);
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Light", 8F);
            this.label6.Location = new System.Drawing.Point(3, 79);
            this.label6.Name = "label6";
            this.tableLayoutPanel2.SetRowSpan(this.label6, 4);
            this.label6.Size = new System.Drawing.Size(99, 108);
            this.label6.TabIndex = 21;
            this.label6.Text = "combobox hiển thị tồn kho, mở combobox mở phiếu nhập kho, lịch sử nhập kho, định " +
    "mức nguyên liệu\r\n\r\n";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.87772F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.12228F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1063, 676);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel2.ColumnCount = 10;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.118694F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.118694F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.246052F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.685684F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.118694F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.118694F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.118694F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.118694F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.118694F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.118694F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.118694F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.pbNVLImage, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnUploadImage, 4, 7);
            this.tableLayoutPanel2.Controls.Add(this.txtSearch, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtNVLCode, 3, 9);
            this.tableLayoutPanel2.Controls.Add(this.txtNVLName, 3, 11);
            this.tableLayoutPanel2.Controls.Add(this.lblNVLCode, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.lblNVLName, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.lblUnit, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.lblPrice, 0, 15);
            this.tableLayoutPanel2.Controls.Add(this.lblQuantity, 0, 17);
            this.tableLayoutPanel2.Controls.Add(this.txtPrice, 3, 15);
            this.tableLayoutPanel2.Controls.Add(this.cmbUnit, 3, 13);
            this.tableLayoutPanel2.Controls.Add(this.txtQuantity, 3, 17);
            this.tableLayoutPanel2.Controls.Add(this.btnAdd, 1, 22);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 7, 22);
            this.tableLayoutPanel2.Controls.Add(this.btnUpdate, 4, 22);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(710, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 25;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.610951F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.170029F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.899136F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.881844F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.755043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.585014F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.763689F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.746398F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(353, 676);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // UC_Inventory1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_Inventory1";
            this.Size = new System.Drawing.Size(1063, 676);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNVLImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNVLName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pbNVLImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtNVLCode;
        private System.Windows.Forms.TextBox txtNVLName;
        private System.Windows.Forms.Label lblNVLCode;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNVL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNVL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNguongMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}
