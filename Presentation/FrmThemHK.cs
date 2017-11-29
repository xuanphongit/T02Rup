using System;
using System.Windows.Forms;

namespace T02_Source_Code.Presentation
{
    public partial class FrmThemHk : Form
    {
        public FrmThemHk()
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
