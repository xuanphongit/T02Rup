using System;
using System.Collections.Generic;
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

        private string MaTinh, MaHuyen;
        private List<TinhThanh> _danhSachTinh;
        private List<QuanHuyen> _danhSachHuyen,_danhSachHuyen2;
        private List<PhuongXa> _danhSachXa,_danhSachXa2;
        private void ResetLoi()
        {
            lblHoTen.Text = "";
            lblHoSoHoKhauSo.Text = "";
            lblNgayCap.Text = "";
            lblNguoiCap.Text = "";
            lblNoiCap2.Text = "";
            lblNoiThuongTru2.Text = "";
            lblSoDangKiThuongTru.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            int countError = 0;
            ResetLoi();
            int HoKhauHoSoHKSo = int.Parse(txtHoSoHoKhauSo.Text);
            var q = from s in DungChung.Db.HoKhaus
                where s.HoSoHKSo == HoKhauHoSoHKSo
                select s;
            if (txtTenChuHo.Text.Equals(""))
            {
                lblHoTen.Text = ("Mời nhập họ tên!");
                countError++;
            }
            if (txtHoSoHoKhauSo.Text.Equals(""))
            {
                lblHoTen.Text = ("Mời nhập số Hồ sơ hộ khẩu!");
                countError++;
            }
            if (txtSoDangKiThuongTru.Text.Equals(""))
            {
                lblHoTen.Text = ("Mời nhập số đăng kí thường trú!");
                countError++;
            }
            if (!_themMa)
            {
                lblNguoiCap.Text = "Mời bấm thêm mã!";
                countError++;

            }
            if (q.Any())
            {
                lblHoSoHoKhauSo.Text = "Số hồ sơ hộ khẩu trùng!";
                countError++;
            }

            if (countError==0)
            {
               HoKhau hk=new HoKhau();
                hk.MaHoKhau = txtMaSoHoKhau.Text;
                hk.TenChuHo = txtTenChuHo.Text;
                hk.SoThanhVien = 1;
                hk.NoiThuongTru = CboXa1.SelectedValue.ToString();
                hk.NoiCap = Cboxa2.SelectedValue.ToString();
                hk.NgayCap=DateTime.Today;
                hk.NguoiCap = txtNguoiCap.Text;
                hk.HoSoHKSo = int.Parse(txtHoSoHoKhauSo.ToString());
                hk.SoDKThuongTru = int.Parse(txtSoDangKiThuongTru.ToString());
                DungChung.Db.HoKhaus.InsertOnSubmit(hk);
                DungChung.Db.SubmitChanges();
                MessageBox.Show("Thêm thành công");
            }
        }

        private void CboHuyen1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaHuyen = CboTinh1.SelectedValue.ToString();
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaQuanHuyen.Equals(MaHuyen)
                    select s;
            CboXa1.DataSource = q.ToList();
            CboXa1.DisplayMember = "TenPhuongXa";
            CboXa1.ValueMember = "MaPhuongXa";
        }

        private void CboTinh2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaTinh = CboTinh2.SelectedValue.ToString();
            var q = from s in DungChung.Db.QuanHuyens
                    where s.MaTinhThanh.Equals(MaTinh)
                    select s;
            Cbohuyen2.DataSource = q.ToList();
            Cbohuyen2.DisplayMember = "TenQuanHuyen";
            Cbohuyen2.ValueMember = "MaQuanHuyen";
        }

        private void Cbohuyen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaHuyen = Cbohuyen2.SelectedValue.ToString();
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaQuanHuyen.Equals(MaHuyen)
                    select s;
            Cboxa2.DataSource = q.ToList();
            Cboxa2.DisplayMember = "TenPhuongXa";
            Cboxa2.ValueMember = "MaPhuongXa";
        }

        private void FrmThemHK_Load(object sender, EventArgs e)
        {
            var q = from s in DungChung.Db.TinhThanhs
                select s;
            _danhSachTinh = q.ToList();
            CboTinh1.DataSource = _danhSachTinh;
            CboTinh1.DisplayMember = "TenTinhThanh";
            CboTinh1.ValueMember = "MaTinhThanh";
            CboTinh2.DataSource = _danhSachTinh;
            CboTinh2.DisplayMember = "TenTinhThanh";
            CboTinh2.ValueMember = "MaTinhThanh";
            txtNguoiCap.Text = DungChung.HoTen;
        }

        private void lblNguoiCap_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool _themMa = false;
        private void button1_Click(object sender, EventArgs e)
        {
            var max = DungChung.Db.HoKhaus.Max(hk => hk.MaHoKhau)+1;
            txtMaSoHoKhau.Text = max;
            _themMa = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaTinh = CboTinh1.SelectedValue.ToString();
            var q = from s in DungChung.Db.QuanHuyens
                where s.MaTinhThanh.Equals(MaTinh)
                select s;
            CboHuyen1.DataSource = q.ToList();
            CboHuyen1.DisplayMember = "TenQuanHuyen";
            CboHuyen1.ValueMember = "MaQuanHuyen";
        }
    }
}
