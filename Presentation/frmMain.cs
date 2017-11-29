using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using T02_Source_Code.Model;

namespace T02_Source_Code.Presentation
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private List<HoKhau> _danhSachHoKhau = DungChung.Db.HoKhaus.ToList();
        private List<NhanKhau> _danhSachNhanKhau = DungChung.Db.NhanKhaus.ToList();

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

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmThemHk frmThemHk=new FrmThemHk();
            frmThemHk.ShowDialog();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmTachHk frmTachHk=new FrmTachHk();
            frmTachHk.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSuaHK frmSuaHk=new FrmSuaHK();
            frmSuaHk.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmThemNk frmThemNk=new FrmThemNk();
            frmThemNk.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmSuaNk frmSuaNk=new FrmSuaNk();
            frmSuaNk.ShowDialog();
        }
    }
}
