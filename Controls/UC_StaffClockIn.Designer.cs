namespace OHIOCF.Controls
{
    partial class UC_StaffClockIn
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvWeeklySchedule = new System.Windows.Forms.DataGridView();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioVao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioRa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongGio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblScheduleTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClockIn = new System.Windows.Forms.Button();
            this.btnClockOut = new System.Windows.Forms.Button();
            this.lblLastActionTime = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeeklySchedule)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvWeeklySchedule
            // 
            this.dgvWeeklySchedule.BackgroundColor = System.Drawing.Color.White;
            this.dgvWeeklySchedule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvWeeklySchedule.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvWeeklySchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNgay,
            this.colThu,
            this.colCa,
            this.colGioVao,
            this.colGioRa,
            this.colTongGio,
            this.colGhiChu});
            this.tableLayoutPanel4.SetColumnSpan(this.dgvWeeklySchedule, 3);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWeeklySchedule.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWeeklySchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWeeklySchedule.GridColor = System.Drawing.Color.Beige;
            this.dgvWeeklySchedule.Location = new System.Drawing.Point(3, 3);
            this.dgvWeeklySchedule.Name = "dgvWeeklySchedule";
            this.dgvWeeklySchedule.Size = new System.Drawing.Size(709, 582);
            this.dgvWeeklySchedule.TabIndex = 1;
            // 
            // colNgay
            // 
            this.colNgay.Frozen = true;
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.Name = "colNgay";
            // 
            // colThu
            // 
            this.colThu.Frozen = true;
            this.colThu.HeaderText = "Thứ";
            this.colThu.Name = "colThu";
            // 
            // colCa
            // 
            this.colCa.HeaderText = "Ca";
            this.colCa.Name = "colCa";
            // 
            // colGioVao
            // 
            this.colGioVao.HeaderText = "Giờ vào";
            this.colGioVao.Name = "colGioVao";
            // 
            // colGioRa
            // 
            this.colGioRa.HeaderText = "Giờ ra";
            this.colGioRa.Name = "colGioRa";
            // 
            // colTongGio
            // 
            this.colTongGio.HeaderText = "Tổng giờ";
            this.colTongGio.Name = "colTongGio";
            // 
            // colGhiChu
            // 
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
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
            this.tableLayoutPanel3.Controls.Add(this.lblScheduleTitle, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.628242F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.37176F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(721, 694);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // lblScheduleTitle
            // 
            this.lblScheduleTitle.AutoSize = true;
            this.lblScheduleTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.lblScheduleTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScheduleTitle.Font = new System.Drawing.Font("Bahnschrift Light", 20F, System.Drawing.FontStyle.Bold);
            this.lblScheduleTitle.ForeColor = System.Drawing.Color.White;
            this.lblScheduleTitle.Location = new System.Drawing.Point(3, 0);
            this.lblScheduleTitle.Name = "lblScheduleTitle";
            this.lblScheduleTitle.Size = new System.Drawing.Size(715, 46);
            this.lblScheduleTitle.TabIndex = 2;
            this.lblScheduleTitle.Text = "Lịch làm việc tuần này";
            this.lblScheduleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.68586F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.31414F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel4.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.dgvWeeklySchedule, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.58878F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.411215F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(715, 642);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(349, 597);
            this.label5.Margin = new System.Windows.Forms.Padding(9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 36);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số giờ làm việc tuần này";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(579, 597);
            this.label6.Margin = new System.Windows.Forms.Padding(9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 36);
            this.label6.TabIndex = 1;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(48)))));
            this.button2.Location = new System.Drawing.Point(69, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 37);
            this.button2.TabIndex = 12;
            this.button2.Text = "CHẤM CÔNG";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(48)))));
            this.button4.Location = new System.Drawing.Point(36, 595);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 35);
            this.button4.TabIndex = 14;
            this.button4.Text = "XÓA";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.42918F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57081F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1063, 700);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.Controls.Add(this.lblCurrentDate, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblCurrentTime, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblStatusTitle, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.lblStatus, 3, 8);
            this.tableLayoutPanel2.Controls.Add(this.btnClockIn, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.btnClockOut, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.lblLastActionTime, 1, 16);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(727, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 20;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(336, 700);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblCurrentDate, 5);
            this.lblCurrentDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentDate.Font = new System.Drawing.Font("Bahnschrift Light", 15F);
            this.lblCurrentDate.Location = new System.Drawing.Point(51, 210);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(234, 35);
            this.lblCurrentDate.TabIndex = 1;
            this.lblCurrentDate.Text = "Date";
            this.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblCurrentTime, 5);
            this.lblCurrentTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentTime.Font = new System.Drawing.Font("Bahnschrift Light", 46F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTime.Location = new System.Drawing.Point(51, 140);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.tableLayoutPanel2.SetRowSpan(this.lblCurrentTime, 2);
            this.lblCurrentTime.Size = new System.Drawing.Size(234, 70);
            this.lblCurrentTime.TabIndex = 0;
            this.lblCurrentTime.Text = "Time";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblStatusTitle, 2);
            this.lblStatusTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusTitle.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.lblStatusTitle.ForeColor = System.Drawing.Color.Black;
            this.lblStatusTitle.Location = new System.Drawing.Point(51, 280);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(90, 35);
            this.lblStatusTitle.TabIndex = 2;
            this.lblStatusTitle.Text = "Tình trạng:";
            this.lblStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblStatus, 3);
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(147, 280);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(138, 35);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Đã chấm công";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClockIn
            // 
            this.btnClockIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.tableLayoutPanel2.SetColumnSpan(this.btnClockIn, 5);
            this.btnClockIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClockIn.FlatAppearance.BorderSize = 0;
            this.btnClockIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClockIn.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.btnClockIn.Location = new System.Drawing.Point(48, 350);
            this.btnClockIn.Margin = new System.Windows.Forms.Padding(0);
            this.btnClockIn.Name = "btnClockIn";
            this.tableLayoutPanel2.SetRowSpan(this.btnClockIn, 2);
            this.btnClockIn.Size = new System.Drawing.Size(240, 70);
            this.btnClockIn.TabIndex = 4;
            this.btnClockIn.Text = "CHẤM CÔNG";
            this.btnClockIn.UseVisualStyleBackColor = false;
            this.btnClockIn.Click += new System.EventHandler(this.btnClockIn_Click);
            // 
            // btnClockOut
            // 
            this.btnClockOut.BackColor = System.Drawing.Color.Red;
            this.tableLayoutPanel2.SetColumnSpan(this.btnClockOut, 5);
            this.btnClockOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClockOut.FlatAppearance.BorderSize = 0;
            this.btnClockOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClockOut.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.btnClockOut.ForeColor = System.Drawing.Color.White;
            this.btnClockOut.Location = new System.Drawing.Point(48, 455);
            this.btnClockOut.Margin = new System.Windows.Forms.Padding(0);
            this.btnClockOut.Name = "btnClockOut";
            this.tableLayoutPanel2.SetRowSpan(this.btnClockOut, 2);
            this.btnClockOut.Size = new System.Drawing.Size(240, 70);
            this.btnClockOut.TabIndex = 5;
            this.btnClockOut.Text = "KẾT THÚC CA";
            this.btnClockOut.UseVisualStyleBackColor = false;
            this.btnClockOut.Click += new System.EventHandler(this.btnClockOut_Click);
            // 
            // lblLastActionTime
            // 
            this.lblLastActionTime.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblLastActionTime, 5);
            this.lblLastActionTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastActionTime.Location = new System.Drawing.Point(51, 560);
            this.lblLastActionTime.Name = "lblLastActionTime";
            this.lblLastActionTime.Size = new System.Drawing.Size(234, 35);
            this.lblLastActionTime.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(242)))), ((int)(((byte)(80)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(48)))));
            this.button5.Location = new System.Drawing.Point(168, 595);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 35);
            this.button5.TabIndex = 16;
            this.button5.Text = "XÓA TRỐNG";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(36, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 49);
            this.label2.TabIndex = 18;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(102, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 49);
            this.label3.TabIndex = 19;
            this.label3.Text = "label3";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(84)))), ((int)(((byte)(48)))));
            this.button3.Location = new System.Drawing.Point(69, 447);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 37);
            this.button3.TabIndex = 15;
            this.button3.Text = "KẾT THÚC CA LÀM";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 26);
            this.label1.TabIndex = 20;
            this.label1.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 26);
            this.label4.TabIndex = 21;
            this.label4.Text = "label4";
            // 
            // UC_StaffClockIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_StaffClockIn";
            this.Size = new System.Drawing.Size(1063, 700);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeeklySchedule)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWeeklySchedule;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblScheduleTitle;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClockIn;
        private System.Windows.Forms.Button btnClockOut;
        private System.Windows.Forms.Label lblLastActionTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioVao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioRa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongGio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
    }
}
