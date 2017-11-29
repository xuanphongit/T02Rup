using System;
using System.Windows.Forms;

namespace T02_Source_Code.Presentation
{
    public partial class ThemTinhThanh : Form
    {
        public ThemTinhThanh()
        {
            InitializeComponent();
        }

        private void Them_TinhThanh_Load(object sender, EventArgs e)
        {
            Text = "Them_";

            textBox1.Enabled = false; button1.Text = "Cập nhật"; Text = "CapNhat_";
            
            Text += "PhuongXa";
        }
    }
}
