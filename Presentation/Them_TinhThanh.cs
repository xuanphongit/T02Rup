using System;
using System.Windows.Forms;

namespace T02_Source_Code
{
    public partial class Them_TinhThanh : Form
    {
        public Them_TinhThanh()
        {
            InitializeComponent();
        }

        private void Them_TinhThanh_Load(object sender, EventArgs e)
        {
            this.Text = "Them_";

            textBox1.Enabled = false; button1.Text = "Cập nhật"; this.Text = "CapNhat_";
            
            this.Text += "PhuongXa";
        }
    }
}
