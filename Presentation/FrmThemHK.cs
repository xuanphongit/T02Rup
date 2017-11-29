using System;
using System.Linq;
using System.Windows.Forms;
using T02_Source_Code.Model;

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

        private void button1_Click(object sender, EventArgs e)
        {
            var Max = DungChung.Db.HoKhaus.Max(hk => hk.MaHoKhau)+1;
            txtMaSoHoKhau.Text = Max;

        }
    }
}
