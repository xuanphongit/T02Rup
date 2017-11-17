using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rup
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
