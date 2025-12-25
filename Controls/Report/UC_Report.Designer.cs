namespace OHIOCF.Controls
{
    partial class UC_Report
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.báoCáoDoanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoBánHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoDoanhThuToolStripMenuItem,
            this.báoCáoBánHàngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1063, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // báoCáoDoanhThuToolStripMenuItem
            // 
            this.báoCáoDoanhThuToolStripMenuItem.Name = "báoCáoDoanhThuToolStripMenuItem";
            this.báoCáoDoanhThuToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.báoCáoDoanhThuToolStripMenuItem.Text = "Báo cáo doanh thu";
            this.báoCáoDoanhThuToolStripMenuItem.Click += new System.EventHandler(this.báoCáoDoanhThuToolStripMenuItem_Click);
            // 
            // báoCáoBánHàngToolStripMenuItem
            // 
            this.báoCáoBánHàngToolStripMenuItem.Name = "báoCáoBánHàngToolStripMenuItem";
            this.báoCáoBánHàngToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.báoCáoBánHàngToolStripMenuItem.Text = "Báo cáo bán hàng";
            this.báoCáoBánHàngToolStripMenuItem.Click += new System.EventHandler(this.báoCáoBánHàngToolStripMenuItem_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.ColumnCount = 1;
            this.pnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 24);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.RowCount = 1;
            this.pnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContainer.Size = new System.Drawing.Size(1063, 676);
            this.pnlContainer.TabIndex = 2;
            // 
            // UC_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.menuStrip1);
            this.Name = "UC_Report";
            this.Size = new System.Drawing.Size(1063, 700);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem báoCáoDoanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoBánHàngToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel pnlContainer;
    }
}
