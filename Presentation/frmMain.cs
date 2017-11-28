using System;
using System.Windows.Forms;
using T02_Source_Code.Model;
using T02_Source_Code.Presentation;

namespace T02_Source_Code
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void thayĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void lblTenNguoiDung_Click(object sender, EventArgs e)
        {
            FrmDoiMatKhau doiMatKhau=new FrmDoiMatKhau();
            Hide();
            doiMatKhau.ShowDialog();
            Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblTenNguoiDung.Text = "Xin Chào : "+DungChung.HoTen;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
