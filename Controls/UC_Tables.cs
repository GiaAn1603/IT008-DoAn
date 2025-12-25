using System;
using System.Drawing;
using System.Windows.Forms;

namespace OHIOCF.Controls
{
    public partial class UC_Tables : UserControl
    {
        private Button _currentActiveButton;
        private Color _defaultColor = Color.FromArgb(247, 242, 80); 
        private Color _selectedColor = Color.FromArgb(248, 215, 32);

        private void ActivateButton(object senderButton)
        {
            if (_currentActiveButton != null)
            {
                _currentActiveButton.BackColor = _defaultColor;
                _currentActiveButton.ForeColor = Color.Black;
                _currentActiveButton.Font = new Font(_currentActiveButton.Font, FontStyle.Bold);
            }

            Button clickedButton = (Button)senderButton;

            clickedButton.BackColor = _selectedColor;

            clickedButton.ForeColor = Color.FromArgb(30, 84, 48);
            clickedButton.Font = new Font(clickedButton.Font, FontStyle.Bold);
           
            _currentActiveButton = clickedButton;
        }
        public UC_Tables()
        {
            InitializeComponent();
            ActivateButton(btnAddTable);
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }
    }
}
