using OHIOCF.BUS;
using OHIOCF.DAO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OHIOCF.Controls
{
    public partial class UC_Tables : UserControl
    {
        
        private void UC_Tables_Load(object sender, EventArgs e)
        {
            LoadListTable();
        }
        public UC_Tables()
        {
            InitializeComponent();
        }
        private void LoadListTable()
        {
            var tables = CafeTableBUS.Instance.GetAllTables();

            flpIndoorTables.Controls.Clear();
            flpOutdoorTables.Controls.Clear();

            foreach (var table in tables)
            {
                Button btn = new Button
                {
                    Width = 110,
                    Height = 110,
                    Text = table.TableName,
                    Tag = table.Id,
                    BackColor = Color.DarkGreen,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    Margin = new Padding(15)
                };

                btn.Click += (s, args) =>
                {
                    btn.BackColor = btn.BackColor == Color.DarkGreen
                        ? Color.LightBlue
                        : Color.DarkGreen;
                };

                if (table.Area == "Bên trong")
                    flpIndoorTables.Controls.Add(btn);
                else
                    flpOutdoorTables.Controls.Add(btn);
            }
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string area = rdoIndoor.Checked ? "Bên trong" : "Bên ngoài";
            string name = txtTableNumber.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Nhập tên bàn.");
                return;
            }

            if (CafeTableBUS.Instance.AddTable(name, area))
            {
                txtTableNumber.Clear();
                LoadListTable();
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            var selected = new List<string>();

            foreach (Control c in flpIndoorTables.Controls)
                if (c is Button btn && btn.BackColor == Color.LightBlue)
                    selected.Add(btn.Tag.ToString());

            foreach (Control c in flpOutdoorTables.Controls)
                if (c is Button btn && btn.BackColor == Color.LightBlue)
                    selected.Add(btn.Tag.ToString());

            if (selected.Count == 0)
            {
                MessageBox.Show("Chọn bàn cần xóa.");
                return;
            }

            if (MessageBox.Show($"Xóa {selected.Count} bàn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var id in selected)
                    CafeTableBUS.Instance.RemoveTable(id);

                LoadListTable();
            }
        }

    }
}
