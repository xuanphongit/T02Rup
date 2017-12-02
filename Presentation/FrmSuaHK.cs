using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using T02_Source_Code.Model;

namespace T02_Source_Code.Presentation
{
    public partial class FrmSuaHk : Form
    {
        public FrmSuaHk()
        {
            InitializeComponent();
        }
        private bool _thayDoi = false;
        private int countError=0;

        private void button2_Click(object sender, EventArgs e)
        {
            lblSoDangKiThuongTru.Text = "";
            lblXa1.Text = "";
            if (txtSoDangKiThuongTru.Text.Equals(""))
            {
                lblSoDangKiThuongTru.Text = "Mời nhập số đăng kí thường trú";
                countError++;
            }
            else if (Regex.IsMatch(txtSoDangKiThuongTru.Text, @"\D"))
            {
                lblSoDangKiThuongTru.Text = "Không nhập chữ cái hoặc kí tự đặc biệt vào đây";
                countError++;
            }
            if (CboXa1.SelectedValue == null)
            {
                lblXa1.Text = "Mời chọn";
                countError++;
            }
            if (!_thayDoi)
            {
                if (countError==0)
                {
                    MessageBox.Show("Mời thay đổi ít nhất một thông tin");
                }
                countError++;
            }
            if (countError==0)
            {
                var q = from s in DungChung.Db.HoKhaus
                       where s.MaHoKhau.Equals(FrmMain.MaHoKhau)
                       select s;
                q.First().TenChuHo = CboHoTenChuHo.Text;
                q.First().NoiThuongTru = CboXa1.SelectedValue.ToString();
                q.First().SoDKThuongTru = int.Parse(txtSoDangKiThuongTru.Text);
                DungChung.Db.SubmitChanges();
                MessageBox.Show("Thay đổi thành công");
            }
        }

        private string _maTinh, _maHuyen;
        
        private void FrmSuaHK_Load(object sender, EventArgs e)
        {
            var q = from s in DungChung.Db.HoKhaus
                where s.MaHoKhau.Equals(FrmMain.MaHoKhau)
                select s;
            txtMaSo.Text = q.First().MaHoKhau;
            lblHoSoHoKhauSo.Text = q.First().HoSoHKSo.ToString();
            lblNgayCap.Text = q.First().NgayCap.ToString();
            var qq = from s in DungChung.Db.NguoiDungs
                where s.MaNguoiDung.Equals(q.First().NguoiCap)
                select s;
            lblNguoiCap.Text = qq.First().TenNguoiDung;
            lblNoiCap.Text = FrmMain.LayThongTinDiaDiem(q.First().NoiCap);
            var p = from s in DungChung.Db.NhanKhaus
                where s.MaHoKhau.Equals(FrmMain.MaHoKhau)
                select s;
            CboHoTenChuHo.DataSource = p.ToList();
            CboHoTenChuHo.DisplayMember = "TenNhanKhau";
            CboHoTenChuHo.ValueMember = "MaNhanKhau";
            if (DungChung.MaTinh!=null)
            {
                var q2 = from s in DungChung.Db.TinhThanhs
                        select s;
                CboTinh1.DataSource = q2.ToList();
                CboTinh1.DisplayMember = "TenTinhThanh";
                CboTinh1.ValueMember = "MaTinhThanh";
               
            }
            else
            {
                var q2 = from s in DungChung.Db.TinhThanhs
                        where s.MaTinhThanh.Equals(DungChung.MaTinh)
                        select s;
                CboTinh1.DataSource = q2.ToList();
                CboTinh1.DisplayMember = "TenTinhThanh";
                CboTinh1.ValueMember = "MaTinhThanh";
               
            }
            if (DungChung.MaHuyen!=null)
            {
                var q3 = from s in DungChung.Db.QuanHuyens
                         where s.MaQuanHuyen.Equals(DungChung.MaHuyen)
                         select s;
                CboHuyen1.DataSource = q3.ToList();
                CboHuyen1.DisplayMember = "TenQuanHuyen";
                CboHuyen1.ValueMember = "MaQuanHuyen";
                
            }
            if (DungChung.MaXa!=null)
            {
                var q4 = from s in DungChung.Db.PhuongXas
                         where s.MaPhuongXa.Equals(DungChung.MaXa)
                         select s;
                CboXa1.DataSource = q4.ToList();
                CboXa1.DisplayMember = "TenPhuongXa";
                CboXa1.ValueMember = "MaPhuongXa";
                
            }
            
        }

        
        private void CboHoTenChuHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _thayDoi = true;
        }

        private void CboHuyen1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _maHuyen = CboTinh1.SelectedValue.ToString();
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaQuanHuyen.Equals(_maHuyen)
                    select s;
            CboXa1.DataSource = q.ToList();
            CboXa1.DisplayMember = "TenPhuongXa";
            CboXa1.ValueMember = "MaPhuongXa";
            _thayDoi = true;

        }

        private void CboXa1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _thayDoi = true;
        }

        private void txtSoDangKiThuongTru_TextChanged(object sender, EventArgs e)
        {
            _thayDoi = true;
        }

        private void CboTinh1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _maTinh = CboTinh1.SelectedValue.ToString();
            var q = from s in DungChung.Db.QuanHuyens
                    where s.MaTinhThanh.Equals(_maTinh)
                    select s;
            CboHuyen1.DataSource = q.ToList();
            CboHuyen1.DisplayMember = "TenQuanHuyen";
            CboHuyen1.ValueMember = "MaQuanHuyen";
            _thayDoi = true;

        }
    }
}
