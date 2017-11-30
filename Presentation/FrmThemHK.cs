using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using T02_Source_Code.Model;

namespace T02_Source_Code.Presentation
{
    public partial class FrmThemHk : Form
    {
        public FrmThemHk()
        {
            InitializeComponent();
        }

        private string MaTinh, MaHuyen,MaXa;
        private List<TinhThanh> _danhSachTinh;
        private List<QuanHuyen> _danhSachHuyen,_danhSachHuyen2;
        private List<PhuongXa> _danhSachXa,_danhSachXa2;
        private void ResetLoi()
        {
            lblHoTen.Text = "";
            lblHoSoHoKhauSo.Text = "";
          
            lblMaSO.Text = "";
            lblNoiCap2.Text = "";
            lblNoiThuongTru2.Text = "";
            lblSoDangKiThuongTru.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            int countError = 0, HoSoHoKhauSo=0;
            ResetLoi();
            
           
            if (txtTenChuHo.Text.Equals(""))
            {
                lblHoTen.Text = ("Mời nhập họ tên!");
                countError++;
            }
            else
            {
                String HoTen = txtTenChuHo.Text;
                bool Match = Regex.IsMatch(HoTen, "\\W");
                bool Match2 = Regex.IsMatch(HoTen, @"\d");
                if (!Match||!Match2)
                {
                    lblHoTen.Text = "Không nhập các kí tự số,các kí tự đặc biệt";
                    countError++;
                }
            }
           
            if (txtHoSoHoKhauSo.Text.Equals(""))
            {
                lblHoSoHoKhauSo.Text = ("Mời nhập số Hồ sơ hộ khẩu!");
                countError++;
            }
            else
            {
                HoSoHoKhauSo = int.Parse(txtHoSoHoKhauSo.Text);
            }
            if (txtSoDangKiThuongTru.Text.Equals(""))
            {
                lblSoDangKiThuongTru.Text = ("Mời nhập số đăng kí thường trú!");
                countError++;
            }
            if (!_themMa)
            {
                lblMaSO.Text = "Mời bấm thêm mã!";
                countError++;

            }
            var q = from s in DungChung.Db.HoKhaus
                    where s.HoSoHKSo == HoSoHoKhauSo
                    select s;
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
                hk.NguoiCap = DungChung.MaNguoiDung;
                hk.MaPhuongXa= CboXa1.SelectedValue.ToString();
                hk.HoSoHKSo = int.Parse(txtHoSoHoKhauSo.Text);
                hk.SoDKThuongTru = int.Parse(txtSoDangKiThuongTru.Text);
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

            if (DungChung.MaTinh.IsEmpty())
            {
                var q = from s in DungChung.Db.TinhThanhs
                    select s;
                CboTinh1.DataSource = q.ToList();
                CboTinh1.DisplayMember = "TenTinhThanh";
                CboTinh1.ValueMember = "MaTinhThanh";
                CboTinh2.DataSource = q.ToList();
                CboTinh2.DisplayMember = "TenTinhThanh";
                CboTinh2.ValueMember = "MaTinhThanh";
            }
            else
            {
                var q = from s in DungChung.Db.TinhThanhs
                        where s.MaTinhThanh.Equals(DungChung.MaTinh)
                        select s;
                CboTinh1.DataSource = q.ToList();
                CboTinh1.DisplayMember = "TenTinhThanh";
                CboTinh1.ValueMember = "MaTinhThanh";
                CboTinh2.DataSource = q.ToList();
                CboTinh2.DisplayMember = "TenTinhThanh";
                CboTinh2.ValueMember = "MaTinhThanh";
            }
            if (!DungChung.MaHuyen.IsEmpty())
            {
                var q2 = from s in DungChung.Db.QuanHuyens
                    where s.MaQuanHuyen.Equals(DungChung.MaHuyen)
                    select s;
                CboHuyen1.DataSource = q2.ToList();
                CboHuyen1.DisplayMember = "TenQuanHuyen";
                CboHuyen1.ValueMember = "MaQuanHuyen";
                Cbohuyen2.DataSource = q2.ToList();
                Cbohuyen2.DisplayMember = "TenQuanHuyen";
                Cbohuyen2.ValueMember = "MaQuanHuyen";
            }
            if (!DungChung.MaXa.IsEmpty())
            {
                var q3 = from s in DungChung.Db.PhuongXas
                    where s.MaPhuongXa.Equals(DungChung.MaXa)
                    select s;
                CboXa1.DataSource = q3.ToList();
                CboXa1.DisplayMember = "TenPhuongXa";
                CboXa1.ValueMember = "MaPhuongXa";
                Cboxa2.DataSource = q3.ToList();
                Cboxa2.DisplayMember = "TenPhuongXa";
                Cboxa2.ValueMember = "MaPhuongXa";
            }
            txtNguoiCap.Text = DungChung.HoTen;
        }

        private void lblNguoiCap_Click(object sender, EventArgs e)
        {

        }

        private void CboXa1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool _themMa = false;
        private void button1_Click(object sender, EventArgs e)
        {
            int max = int.Parse(DungChung.Db.HoKhaus.Max(hk => hk.MaHoKhau))+1;
            txtMaSoHoKhau.Text = max.ToString();
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
