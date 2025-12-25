namespace OHIOCF.Controls.Staff_Inventory
{
    partial class UC_StaffStockReceipt
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
            this.lblNote = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblReceiptCode = new System.Windows.Forms.Label();
            this.txtReceiptCode = new System.Windows.Forms.TextBox();
            this.lblReceiptDate = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.nvl_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nvl_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblNote, 4);
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNote.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblNote.Location = new System.Drawing.Point(3, 239);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(133, 27);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "Ghi chú";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnSearch.Size = new System.Drawing.Size(96, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtSearch, 5);
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtSearch.Location = new System.Drawing.Point(139, 27);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(175, 27);
            this.txtSearch.TabIndex = 11;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblUser, 4);
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(3, 79);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(133, 27);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Người tạo phiếu";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReceiptCode
            // 
            this.lblReceiptCode.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblReceiptCode, 4);
            this.lblReceiptCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiptCode.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblReceiptCode.Location = new System.Drawing.Point(3, 133);
            this.lblReceiptCode.Name = "lblReceiptCode";
            this.lblReceiptCode.Size = new System.Drawing.Size(133, 27);
            this.lblReceiptCode.TabIndex = 4;
            this.lblReceiptCode.Text = "Mã phiếu";
            this.lblReceiptCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReceiptCode
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtReceiptCode, 5);
            this.txtReceiptCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceiptCode.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtReceiptCode.Location = new System.Drawing.Point(139, 133);
            this.txtReceiptCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtReceiptCode.Name = "txtReceiptCode";
            this.txtReceiptCode.Size = new System.Drawing.Size(175, 27);
            this.txtReceiptCode.TabIndex = 12;
            // 
            // lblReceiptDate
            // 
            this.lblReceiptDate.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblReceiptDate, 4);
            this.lblReceiptDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiptDate.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblReceiptDate.Location = new System.Drawing.Point(3, 187);
            this.lblReceiptDate.Name = "lblReceiptDate";
            this.lblReceiptDate.Size = new System.Drawing.Size(133, 33);
            this.lblReceiptDate.TabIndex = 5;
            this.lblReceiptDate.Text = "Ngày tạo";
            this.lblReceiptDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNote
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtNote, 5);
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtNote.Location = new System.Drawing.Point(139, 239);
            this.txtNote.Margin = new System.Windows.Forms.Padding(0);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(175, 27);
            this.txtNote.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnSave, 2);
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnSave.Location = new System.Drawing.Point(38, 593);
            this.btnSave.Name = "btnSave";
            this.tableLayoutPanel2.SetRowSpan(this.btnSave, 2);
            this.btnSave.Size = new System.Drawing.Size(65, 46);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "LƯU";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // cmbUser
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cmbUser, 5);
            this.cmbUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbUser.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(139, 79);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(0);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(175, 27);
            this.cmbUser.TabIndex = 15;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblPrice, 4);
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(3, 293);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(133, 27);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "Giá";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtPrice, 5);
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtPrice.Location = new System.Drawing.Point(139, 293);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(175, 27);
            this.txtPrice.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.dateTimePicker1, 5);
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker1.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.dateTimePicker1.Location = new System.Drawing.Point(142, 190);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(169, 27);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.Controls.Add(this.btnAdd, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblHeaderTitle, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(704, 43);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnAdd.Location = new System.Drawing.Point(636, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 37);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "PHIẾU MỚI";
            this.btnAdd.UseVisualStyleBackColor = false;
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(627, 43);
            this.lblHeaderTitle.TabIndex = 23;
            this.lblHeaderTitle.Text = "PHIẾU NHẬP KHO";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnDelete.Location = new System.Drawing.Point(142, 593);
            this.btnDelete.Name = "btnDelete";
            this.tableLayoutPanel2.SetRowSpan(this.btnDelete, 2);
            this.btnDelete.Size = new System.Drawing.Size(64, 46);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "XÓA";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.64809F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.35192F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(704, 43);
            this.tableLayoutPanel4.TabIndex = 2;
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(707, 670);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // dgvInventory
            // 
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nvl_name,
            this.nvl_code,
            this.quantity,
            this.unit,
            this.Price});
            this.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventory.Location = new System.Drawing.Point(3, 46);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.Size = new System.Drawing.Size(701, 621);
            this.dgvInventory.TabIndex = 1;
            // 
            // nvl_name
            // 
            this.nvl_name.HeaderText = "Tên NVL";
            this.nvl_name.Name = "nvl_name";
            // 
            // nvl_code
            // 
            this.nvl_code.HeaderText = "Mã NVL";
            this.nvl_code.Name = "nvl_code";
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Số lượng";
            this.quantity.Name = "quantity";
            // 
            // unit
            // 
            this.unit.HeaderText = "Đơn vị";
            this.unit.Name = "unit";
            // 
            // Price
            // 
            this.Price.HeaderText = "Đơn giá";
            this.Price.Name = "Price";
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 676);
            this.tableLayoutPanel1.TabIndex = 5;
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
            this.tableLayoutPanel2.Controls.Add(this.txtSearch, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 1, 22);
            this.tableLayoutPanel2.Controls.Add(this.lblUser, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cmbUser, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblReceiptCode, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtReceiptCode, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblReceiptDate, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.txtNote, 4, 9);
            this.tableLayoutPanel2.Controls.Add(this.lblNote, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.lblPrice, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.txtPrice, 4, 11);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker1, 4, 7);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 4, 22);
            this.tableLayoutPanel2.Controls.Add(this.btnUpdate, 7, 22);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(713, 0);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(354, 676);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnUpdate, 2);
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnUpdate.Location = new System.Drawing.Point(247, 593);
            this.btnUpdate.Name = "btnUpdate";
            this.tableLayoutPanel2.SetRowSpan(this.btnUpdate, 2);
            this.btnUpdate.Size = new System.Drawing.Size(64, 46);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "GỬI";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // UC_StaffStockReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_StaffStockReceipt";
            this.Size = new System.Drawing.Size(1067, 676);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblReceiptCode;
        private System.Windows.Forms.TextBox txtReceiptCode;
        private System.Windows.Forms.Label lblReceiptDate;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nvl_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn nvl_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}
