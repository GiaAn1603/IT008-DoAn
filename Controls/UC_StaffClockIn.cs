using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OHIOCF.Controls
{
    public partial class UC_StaffClockIn : UserControl
    {
        public UC_StaffClockIn()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        
            private void timerClock_Tick(object sender, EventArgs e)
        {
            // Mỗi 1000ms (1 giây), hàm này được gọi
            UpdateClockTime();
        }
       
        private void UC_StaffClockIn_Load(object sender, EventArgs e)
        {
            if (!timerClock.Enabled)
            {
                timerClock.Start();
            }

            UpdateClockTime();
        }

        // Hàm cập nhật đồng hồ
        private void UpdateClockTime()
        {
            // Cập nhật giờ (HH:MM AM/PM)
            lblCurrentTime.Text = DateTime.Now.ToString("hh:mm tt"); // hh: 12h, HH: 24h, tt: AM/PM

            // Cập nhật ngày tháng (Thứ, DD/MM/YYYY)
            lblCurrentDate.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
        }

        

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblLastActionTime.Text= $"Lần gần nhất: Kết thúc ca lúc {now:HH:mm} ngày {now:dd/MM/yyyy}";
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblLastActionTime.Text = $"Lần gần nhất: Chấm công lúc {now:HH:mm} ngày {now:dd/MM/yyyy}";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
