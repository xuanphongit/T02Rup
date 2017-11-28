using System;
using System.Windows.Forms;

namespace T02_Source_Code
{
    public partial class FrmSuaHK : Form
    {
        public FrmSuaHK()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng nhập các thông tin bắt buộc (*)");
        }

        private void FrmSuaHK_Load(object sender, EventArgs e)
        {

        }
    }
}
