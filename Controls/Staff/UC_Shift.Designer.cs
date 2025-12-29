namespace OHIOCF.Controls.Staff_Inventory
{
    partial class UC_Shift
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvScheduleData = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonday = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTuesday = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colWednesday = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colThursday = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFriday = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSaturday = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSunday = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduleData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Controls.Add(this.btnSave, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnExport, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblHeaderTitle, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1057, 44);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnSave.Location = new System.Drawing.Point(953, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 38);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "LƯU";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.btnExport.Location = new System.Drawing.Point(848, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 38);
            this.btnExport.TabIndex = 26;
            this.btnExport.Text = "XUẤT FILE";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(839, 44);
            this.lblHeaderTitle.TabIndex = 25;
            this.lblHeaderTitle.Text = "XẾP LỊCH LÀM";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tableLayoutPanel3.Controls.Add(this.dgvScheduleData, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.628242F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.37176F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1057, 670);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // dgvScheduleData
            // 
            this.dgvScheduleData.AllowUserToAddRows = false;
            this.dgvScheduleData.AllowUserToDeleteRows = false;
            this.dgvScheduleData.AllowUserToResizeColumns = false;
            this.dgvScheduleData.AllowUserToResizeRows = false;
            this.dgvScheduleData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bahnschrift Light", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScheduleData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScheduleData.ColumnHeadersHeight = 40;
            this.dgvScheduleData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCa,
            this.colMonday,
            this.colTuesday,
            this.colWednesday,
            this.colThursday,
            this.colFriday,
            this.colSaturday,
            this.colSunday});
            this.dgvScheduleData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScheduleData.EnableHeadersVisualStyles = false;
            this.dgvScheduleData.GridColor = System.Drawing.Color.Black;
            this.dgvScheduleData.Location = new System.Drawing.Point(3, 47);
            this.dgvScheduleData.Name = "dgvScheduleData";
            this.dgvScheduleData.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.dgvScheduleData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScheduleData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvScheduleData.Size = new System.Drawing.Size(1051, 620);
            this.dgvScheduleData.TabIndex = 1;
            this.dgvScheduleData.DefaultCellStyle.Font = new System.Drawing.Font(
                "Bahnschrift Light",
                12F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point
            );
            this.dgvScheduleData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(
                "Bahnschrift Light",
                12F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point
            );
            this.dgvScheduleData.ColumnHeadersDefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.dgvScheduleData.DefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvScheduleData.EnableHeadersVisualStyles = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.42918F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57081F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1063, 676);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // colCa
            // 
            this.colCa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCa.HeaderText = "Ca";
            this.colCa.Name = "colCa";
            this.colCa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMonday
            // 
            this.colMonday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMonday.HeaderText = "Thứ Hai";
            this.colMonday.Name = "colMonday";
            // 
            // colTuesday
            // 
            this.colTuesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTuesday.HeaderText = "Thứ Ba";
            this.colTuesday.Name = "colTuesday";
            // 
            // colWednesday
            // 
            this.colWednesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colWednesday.HeaderText = "Thứ Tư";
            this.colWednesday.Name = "colWednesday";
            // 
            // colThursday
            // 
            this.colThursday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colThursday.HeaderText = "Thứ Năm";
            this.colThursday.Name = "colThursday";
            // 
            // colFriday
            // 
            this.colFriday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFriday.HeaderText = "Thứ Sáu";
            this.colFriday.Name = "colFriday";
            // 
            // colSaturday
            // 
            this.colSaturday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSaturday.HeaderText = "Thứ Bảy";
            this.colSaturday.Name = "colSaturday";
            // 
            // colSunday
            // 
            this.colSunday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSunday.HeaderText = "Chủ Nhật";
            this.colSunday.Name = "colSunday";
            // 
            // UC_Shift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_Shift";
            this.Size = new System.Drawing.Size(1063, 676);
            this.Load += new System.EventHandler(this.UC_Shift_Load);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduleData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvScheduleData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCa;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMonday;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTuesday;
        private System.Windows.Forms.DataGridViewComboBoxColumn colWednesday;
        private System.Windows.Forms.DataGridViewComboBoxColumn colThursday;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFriday;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSaturday;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSunday;
    }
}
