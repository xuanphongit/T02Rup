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

        private IQueryable<HoKhau> _danhSachHoKhau;
        private IQueryable<NhanKhau> _danhSachNhanKhau;

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

        private bool _finished = false;
        public static string _maHoKhau, _maNhanKhau;
        private void button8_Click_1(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemHoKhauNhanKhau.Text.ToLower();
            _danhSachHoKhau = from s in DungChung.Db.HoKhaus
                where s.TenChuHo.ToLower().Contains(tuKhoa)
                select s;
            _danhSachNhanKhau = from s in DungChung.Db.NhanKhaus
                where s.TenNhanKhau.ToLower().Contains(tuKhoa) || s.TenThuongGoi.ToLower().Contains(tuKhoa)
                select s;
            LstHoKhau.DataSource = _danhSachHoKhau;
            LstHoKhau.DisplayMember = "TenChuHo";
            LstHoKhau.ValueMember = "MaHoKhau";

            LstNhanKhau.DataSource = _danhSachNhanKhau;
            LstNhanKhau.DisplayMember = "TenNhanKhau";
            LstNhanKhau.ValueMember = "MaNhanKhau";
            _finished = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmThemHk frmThemHk=new FrmThemHk();
            frmThemHk.ShowDialog();

        }

        private void ResetKhungThongTin()
        {
            txtMaSo.Text = "";
            txtHoTen.Text = "";
            txtTenThuongGoi.Text = "";
            txtGioiTinh_SoThanhVien.Text = "";
            txtNgaySinh.Text = "";
            txtDanToc_NoiCap.Text = "";
            txtTonGiaoNgayCap.Text = "";
            txtQueQuan_NoiThuongTru.Text = "";
            txtCMND.Text = "";
            txtNgheNghiep_HoSoHoKhauSo.Text = "";
            txtNoiLamViec_NguoiCap.Text = "";
            txtTenThuongGoi.Text = "";
            txtNgayChuyenDen.Text = "";
            txtNoiThuongTruTruocKhiChuyenDen_SoDKThuongTru.Text = "";
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetKhungThongTin();
            _maHoKhau = LstHoKhau.SelectedValue.ToString();
            var q = from hoKhau in _danhSachHoKhau
                where hoKhau.MaHoKhau.Equals(_maHoKhau)
                select hoKhau;
            txtMaSo.Text = q.First().MaHoKhau;
            txtHoTen.Text = q.First().TenChuHo;
            txtGioiTinh_SoThanhVien.Text = q.First().SoThanhVien.ToString();
            txtQueQuan_NoiThuongTru.Text = q.First().NoiThuongTru;
            txtDanToc_NoiCap.Text = q.First().NoiCap;
            txtTonGiaoNgayCap.Text = q.First().NgayCap.ToString();
            txtNoiLamViec_NguoiCap.Text = q.First().NguoiCap;
            txtNgheNghiep_HoSoHoKhauSo.Text = q.First().HoSoHKSo.ToString();
            txtNoiThuongTruTruocKhiChuyenDen_SoDKThuongTru.Text = q.First().SoDKThuongTru.ToString();


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

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void txtHoTen_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
