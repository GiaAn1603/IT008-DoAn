namespace OHIOCF.Controls
{
    partial class UC_Staff
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
            System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem xếpCaLàmToolStripMenuItem;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pnlContainer = new System.Windows.Forms.TableLayoutPanel();
            quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            xếpCaLàmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            quảnLýNhânViênToolStripMenuItem,
            xếpCaLàmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1063, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            quảnLýNhânViênToolStripMenuItem.AutoSize = false;
            quảnLýNhânViênToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            quảnLýNhânViênToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            quảnLýNhânViênToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            quảnLýNhânViênToolStripMenuItem.Margin = new System.Windows.Forms.Padding(4);
            quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            quảnLýNhânViênToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(150, 23);
            quảnLýNhânViênToolStripMenuItem.Text = "Quản lý nhân viên";
            quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // xếpCaLàmToolStripMenuItem
            // 
            xếpCaLàmToolStripMenuItem.AutoSize = false;
            xếpCaLàmToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            xếpCaLàmToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            xếpCaLàmToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            xếpCaLàmToolStripMenuItem.Margin = new System.Windows.Forms.Padding(4);
            xếpCaLàmToolStripMenuItem.Name = "xếpCaLàmToolStripMenuItem";
            xếpCaLàmToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            xếpCaLàmToolStripMenuItem.Size = new System.Drawing.Size(111, 23);
            xếpCaLàmToolStripMenuItem.Text = "Xếp ca làm";
            xếpCaLàmToolStripMenuItem.Click += new System.EventHandler(this.xếpCaLàmToolStripMenuItem_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.ColumnCount = 1;
            this.pnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 35);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.RowCount = 1;
            this.pnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlContainer.Size = new System.Drawing.Size(1063, 665);
            this.pnlContainer.TabIndex = 2;
            // 
            // UC_Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.menuStrip1);
            this.Name = "UC_Staff";
            this.Size = new System.Drawing.Size(1063, 700);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel pnlContainer;
    }
}
