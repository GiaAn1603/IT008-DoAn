namespace OHIOCF.Controls
{
    partial class UC_Inventory
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
            this.xemTồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taohPhiếuNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửNhậpKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemTồnKhoToolStripMenuItem,
            this.taohPhiếuNhậpToolStripMenuItem,
            this.lịchSửNhậpKhoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1063, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xemTồnKhoToolStripMenuItem
            // 
            this.xemTồnKhoToolStripMenuItem.Name = "xemTồnKhoToolStripMenuItem";
            this.xemTồnKhoToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.xemTồnKhoToolStripMenuItem.Text = "Xem tồn kho";
            this.xemTồnKhoToolStripMenuItem.Click += new System.EventHandler(this.xemTồnKhoToolStripMenuItem_Click);
            // 
            // taohPhiếuNhậpToolStripMenuItem
            // 
            this.taohPhiếuNhậpToolStripMenuItem.Name = "taohPhiếuNhậpToolStripMenuItem";
            this.taohPhiếuNhậpToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.taohPhiếuNhậpToolStripMenuItem.Text = "Phiếu nhập kho";
            this.taohPhiếuNhậpToolStripMenuItem.Click += new System.EventHandler(this.tạoPhiếuNhậpToolStripMenuItem_Click);
            // 
            // lịchSửNhậpKhoToolStripMenuItem
            // 
            this.lịchSửNhậpKhoToolStripMenuItem.Name = "lịchSửNhậpKhoToolStripMenuItem";
            this.lịchSửNhậpKhoToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.lịchSửNhậpKhoToolStripMenuItem.Text = "Lịch sử nhập kho";
            this.lịchSửNhậpKhoToolStripMenuItem.Click += new System.EventHandler(this.lịchSửNhậpKhoToolStripMenuItem_Click);
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
            this.pnlContainer.TabIndex = 1;
            // 
            // UC_Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.menuStrip1);
            this.Name = "UC_Inventory";
            this.Size = new System.Drawing.Size(1063, 700);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xemTồnKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taohPhiếuNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửNhậpKhoToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel pnlContainer;
    }
}
