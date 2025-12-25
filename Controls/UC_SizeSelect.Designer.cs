namespace OHIOCF.Controls
{
    partial class UC_SizeSelect
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoSizeS = new System.Windows.Forms.RadioButton();
            this.rdoSizeM = new System.Windows.Forms.RadioButton();
            this.rdoSizeL = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rdoSizeS, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdoSizeM, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rdoSizeL, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(81, 140);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rdoSizeS
            // 
            this.rdoSizeS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoSizeS.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.rdoSizeS.ForeColor = System.Drawing.Color.White;
            this.rdoSizeS.Location = new System.Drawing.Point(0, 0);
            this.rdoSizeS.Margin = new System.Windows.Forms.Padding(0);
            this.rdoSizeS.Name = "rdoSizeS";
            this.rdoSizeS.Size = new System.Drawing.Size(81, 46);
            this.rdoSizeS.TabIndex = 0;
            this.rdoSizeS.TabStop = true;
            this.rdoSizeS.Text = "S";
            this.rdoSizeS.UseVisualStyleBackColor = true;
            this.rdoSizeS.CheckedChanged += new System.EventHandler(this.rdoSizeS_CheckedChanged);
            // 
            // rdoSizeM
            // 
            this.rdoSizeM.AutoSize = true;
            this.rdoSizeM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoSizeM.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.rdoSizeM.ForeColor = System.Drawing.Color.White;
            this.rdoSizeM.Location = new System.Drawing.Point(0, 46);
            this.rdoSizeM.Margin = new System.Windows.Forms.Padding(0);
            this.rdoSizeM.Name = "rdoSizeM";
            this.rdoSizeM.Size = new System.Drawing.Size(81, 46);
            this.rdoSizeM.TabIndex = 1;
            this.rdoSizeM.TabStop = true;
            this.rdoSizeM.Text = "M";
            this.rdoSizeM.UseVisualStyleBackColor = true;
            this.rdoSizeM.CheckedChanged += new System.EventHandler(this.rdoSizeM_CheckedChanged);
            // 
            // rdoSizeL
            // 
            this.rdoSizeL.AutoSize = true;
            this.rdoSizeL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoSizeL.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Bold);
            this.rdoSizeL.ForeColor = System.Drawing.Color.White;
            this.rdoSizeL.Location = new System.Drawing.Point(0, 92);
            this.rdoSizeL.Margin = new System.Windows.Forms.Padding(0);
            this.rdoSizeL.Name = "rdoSizeL";
            this.rdoSizeL.Size = new System.Drawing.Size(81, 48);
            this.rdoSizeL.TabIndex = 2;
            this.rdoSizeL.TabStop = true;
            this.rdoSizeL.Text = "L";
            this.rdoSizeL.UseVisualStyleBackColor = true;
            this.rdoSizeL.CheckedChanged += new System.EventHandler(this.rdoSizeL_CheckedChanged);
            // 
            // UC_SizeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(92)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_SizeSelect";
            this.Size = new System.Drawing.Size(81, 140);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rdoSizeS;
        private System.Windows.Forms.RadioButton rdoSizeM;
        private System.Windows.Forms.RadioButton rdoSizeL;
    }
}
