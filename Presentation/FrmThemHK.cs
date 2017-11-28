using System;
using System.Windows.Forms;

namespace T02_Source_Code
{
    public partial class FrmThemHK : Form
    {
        public FrmThemHK()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Số hồ sơ hộ khẩu bị trùng. Vui lòng nhập lại");
        }

        private void FrmThemHK_Load(object sender, EventArgs e)
        {

        }
    }
}
