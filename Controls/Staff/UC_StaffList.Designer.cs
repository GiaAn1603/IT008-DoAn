namespace OHIOCF.Controls.Staff_Inventory
{
    partial class UC_StaffList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_StaffList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblPasswordTitle = new System.Windows.Forms.Label();
            this.lblRoleTitle = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblUsernameTitle = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pbStaffImage = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvStaffData = new System.Windows.Forms.DataGridView();
            this.staff_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbStaffImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffData)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPasswordTitle
            // 
            this.lblPasswordTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPasswordTitle.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblPasswordTitle, 4);
            this.lblPasswordTitle.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblPasswordTitle.ForeColor = System.Drawing.Color.Black;
            this.lblPasswordTitle.Location = new System.Drawing.Point(3, 312);
            this.lblPasswordTitle.Name = "lblPasswordTitle";
            this.lblPasswordTitle.Size = new System.Drawing.Size(130, 19);
            this.lblPasswordTitle.TabIndex = 4;
            this.lblPasswordTitle.Text = "Mật khẩu";
            this.lblPasswordTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRoleTitle
            // 
            this.lblRoleTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoleTitle.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblRoleTitle, 4);
            this.lblRoleTitle.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblRoleTitle.ForeColor = System.Drawing.Color.Black;
            this.lblRoleTitle.Location = new System.Drawing.Point(3, 358);
            this.lblRoleTitle.Name = "lblRoleTitle";
            this.lblRoleTitle.Size = new System.Drawing.Size(130, 19);
            this.lblRoleTitle.TabIndex = 10;
            this.lblRoleTitle.Text = "Vai trò";
            this.lblRoleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusTitle.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblStatusTitle, 4);
            this.lblStatusTitle.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatusTitle.ForeColor = System.Drawing.Color.Black;
            this.lblStatusTitle.Location = new System.Drawing.Point(3, 404);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(130, 19);
            this.lblStatusTitle.TabIndex = 11;
            this.lblStatusTitle.Text = "Trạng thái";
            this.lblStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnAdd, 3);
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(48)))));
            this.btnAdd.Location = new System.Drawing.Point(47, 464);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 37);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "THÊM";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnDelete, 3);
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(48)))));
            this.btnDelete.Location = new System.Drawing.Point(47, 532);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 37);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "XÓA";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // lblUsernameTitle
            // 
            this.lblUsernameTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsernameTitle.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblUsernameTitle, 4);
            this.lblUsernameTitle.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.lblUsernameTitle.ForeColor = System.Drawing.Color.Black;
            this.lblUsernameTitle.Location = new System.Drawing.Point(3, 266);
            this.lblUsernameTitle.Name = "lblUsernameTitle";
            this.lblUsernameTitle.Size = new System.Drawing.Size(130, 19);
            this.lblUsernameTitle.TabIndex = 2;
            this.lblUsernameTitle.Text = "Tên tài khoản";
            this.lblUsernameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtUsername, 5);
            this.txtUsername.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtUsername.Location = new System.Drawing.Point(136, 262);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(0);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(182, 27);
            this.txtUsername.TabIndex = 17;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtPassword, 5);
            this.txtPassword.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtPassword.Location = new System.Drawing.Point(136, 308);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(182, 27);
            this.txtPassword.TabIndex = 18;
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cmbRole, 5);
            this.cmbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(136, 354);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(0);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(182, 28);
            this.cmbRole.TabIndex = 21;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cmbStatus, 5);
            this.cmbStatus.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(136, 400);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(0);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(182, 27);
            this.cmbStatus.TabIndex = 20;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnClear, 3);
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(48)))));
            this.btnClear.Location = new System.Drawing.Point(186, 532);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 37);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "XÓA TRỐNG";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnUpdate, 3);
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(48)))));
            this.btnUpdate.Location = new System.Drawing.Point(186, 464);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 37);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "CẬP NHẬT";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // pbStaffImage
            // 
            this.pbStaffImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel2.SetColumnSpan(this.pbStaffImage, 4);
            this.pbStaffImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbStaffImage.Image = ((System.Drawing.Image)(resources.GetObject("pbStaffImage.Image")));
            this.pbStaffImage.Location = new System.Drawing.Point(99, 46);
            this.pbStaffImage.Margin = new System.Windows.Forms.Padding(0);
            this.pbStaffImage.Name = "pbStaffImage";
            this.tableLayoutPanel2.SetRowSpan(this.pbStaffImage, 2);
            this.pbStaffImage.Size = new System.Drawing.Size(132, 138);
            this.pbStaffImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStaffImage.TabIndex = 0;
            this.pbStaffImage.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnUploadImage, 2);
            this.btnUploadImage.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUploadImage.FlatAppearance.BorderSize = 0;
            this.btnUploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadImage.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnUploadImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(48)))));
            this.btnUploadImage.Location = new System.Drawing.Point(139, 193);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(56, 28);
            this.btnUploadImage.TabIndex = 5;
            this.btnUploadImage.Text = "NHẬP";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.42918F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57081F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1063, 676);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel2.ColumnCount = 10;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.09524F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.547619F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.0119F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.9881F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.464286F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.36905F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.869048F));
            this.tableLayoutPanel2.Controls.Add(this.lblPasswordTitle, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblRoleTitle, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.lblStatusTitle, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.btnAdd, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.lblUsernameTitle, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtUsername, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtPassword, 4, 6);
            this.tableLayoutPanel2.Controls.Add(this.cmbRole, 4, 7);
            this.tableLayoutPanel2.Controls.Add(this.cmbStatus, 4, 8);
            this.tableLayoutPanel2.Controls.Add(this.btnClear, 5, 12);
            this.tableLayoutPanel2.Controls.Add(this.btnUpdate, 5, 10);
            this.tableLayoutPanel2.Controls.Add(this.pbStaffImage, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnUploadImage, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(727, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 14;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.896552F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.34483F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.34483F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.896552F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.448276F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.896552F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.896552F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.896552F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.896552F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.448276F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.896552F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.448276F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.428571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.71429F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(336, 676);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label5, 3);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 46);
            this.label5.Name = "label5";
            this.tableLayoutPanel2.SetRowSpan(this.label5, 2);
            this.label5.Size = new System.Drawing.Size(93, 138);
            this.label5.TabIndex = 22;
            this.label5.Text = "Combobox mặc định danh sách nv, mở combobox để xếp ca (tuần)  \r\n";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.dgvStaffData, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.628242F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.37176F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(721, 670);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // dgvStaffData
            // 
            this.dgvStaffData.BackgroundColor = System.Drawing.Color.White;
            this.dgvStaffData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStaffData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvStaffData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.staff_code,
            this.staff_fullname,
            this.role,
            this.staff_username,
            this.staff_password,
            this.date,
            this.status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStaffData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStaffData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaffData.GridColor = System.Drawing.Color.Beige;
            this.dgvStaffData.Location = new System.Drawing.Point(3, 47);
            this.dgvStaffData.Name = "dgvStaffData";
            this.dgvStaffData.Size = new System.Drawing.Size(715, 620);
            this.dgvStaffData.TabIndex = 1;
            // 
            // staff_code
            // 
            this.staff_code.HeaderText = "Mã nhân viên";
            this.staff_code.Name = "staff_code";
            // 
            // staff_fullname
            // 
            this.staff_fullname.HeaderText = "Họ và tên";
            this.staff_fullname.Name = "staff_fullname";
            // 
            // role
            // 
            this.role.HeaderText = "Vai trò";
            this.role.Name = "role";
            // 
            // staff_username
            // 
            this.staff_username.HeaderText = "Tên tài khoản";
            this.staff_username.Name = "staff_username";
            // 
            // staff_password
            // 
            this.staff_password.HeaderText = "Mật khẩu";
            this.staff_password.Name = "staff_password";
            // 
            // date
            // 
            this.date.HeaderText = "Ngày tạo";
            this.date.Name = "date";
            // 
            // status
            // 
            this.status.HeaderText = "Trạng thái";
            this.status.Name = "status";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblHeaderTitle, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(721, 44);
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(570, 44);
            this.lblHeaderTitle.TabIndex = 25;
            this.lblHeaderTitle.Text = "DANH SÁCH NHÂN VIÊN";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.button1.Location = new System.Drawing.Point(579, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 38);
            this.button1.TabIndex = 26;
            this.button1.Text = "XUẤT FILE";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.button2.Location = new System.Drawing.Point(651, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 38);
            this.button2.TabIndex = 27;
            this.button2.Text = "LƯU";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // UC_StaffList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_StaffList";
            this.Size = new System.Drawing.Size(1063, 676);
            ((System.ComponentModel.ISupportInitialize)(this.pbStaffImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffData)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPasswordTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblRoleTitle;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblUsernameTitle;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox pbStaffImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvStaffData;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn role;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_password;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
