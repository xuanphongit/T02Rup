using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using T02_Source_Code.Model;
using T02_Source_Code.Bo;
namespace T02_Source_Code.Presentation
{
    public partial class FrmSuaNk : Form
    {
        public FrmSuaNk()
        {
            InitializeComponent();
        }

        private List<TinhThanh> DsTinh1 = DungChung.Db.TinhThanhs.ToList();
        private List<TinhThanh> DsTinh2 = DungChung.Db.TinhThanhs.ToList();
        private List<TinhThanh> DsTinh3 = DungChung.Db.TinhThanhs.ToList();
        private List<PhuongXa> DsXa1;
        private List<PhuongXa> DsXa2;
        private List<PhuongXa> DsXa3;
        private List<QuanHuyen> DsHuyen1;
        private List<QuanHuyen> DsHuyen2;
        private List<QuanHuyen> DsHuyen3;
        PhuongXaBO bo = new PhuongXaBO();
        PhuongXa xa3, xa2, xa1;
        QuanHuyenBO huyenBo = new QuanHuyenBO();
        QuanHuyen huyen3, huyen2, huyen1;
        private void ResetLoi()
        {
            lblCMND.Text = "";
            lblNgheNghiep.Text = "";
            lblHoTen.Text = "";
            lblTonGiao.Text = "";
            lblQueQuan.Text = "";
            lblNoiThuongTruTruocKia.Text = "";
            lblNoiLamViec.Text = "";
        }
        private NhanKhau _nk;


        private void FrmSuaNK_Load(object sender, EventArgs e)
        {

           
            var pp = from s in FrmMain._danhSachNhanKhau
                     where s.MaNhanKhau.Equals(FrmMain.MaNhanKhau)
                     select s;
            _nk = pp.First();

            
            
            xa3 = bo.get(_nk.QueQuan);
            xa2 = bo.get(_nk.NoiThuongTruTruocKhiChuyenDen);
            xa1 = bo.get(_nk.NoiLamViec);
            DsXa3 = bo.getList(xa3.MaQuanHuyen);
            DsXa2 = bo.getList(xa2.MaQuanHuyen);
            DsXa1 = bo.getList(xa1.MaQuanHuyen);
           
           
            huyen3 = huyenBo.get(xa3.MaQuanHuyen);
            huyen2 = huyenBo.get(xa2.MaQuanHuyen);
            huyen1 = huyenBo.get(xa1.MaQuanHuyen);


            DsHuyen3 = huyenBo.getList(huyen3.MaTinhThanh);
            DsHuyen2 = huyenBo.getList(huyen2.MaTinhThanh);
            DsHuyen1 = huyenBo.getList(huyen1.MaTinhThanh);



            CboTinh1.DataSource = DsTinh1;
            CboTinh2.DataSource = DsTinh2;
            CboTinh3.DataSource = DsTinh3;
            CboTinh1.DisplayMember = "TenTinhThanh";
            CboTinh2.DisplayMember = "TenTinhThanh";
            CboTinh3.DisplayMember = "TenTinhThanh";
            CboTinh1.ValueMember = "MaTinhThanh";
            CboTinh2.ValueMember = "MaTinhThanh";
            CboTinh3.ValueMember = "MaTinhThanh";


            Cboxa3.DataSource = DsXa3;
            Cboxa2.DataSource = DsXa2;
            CboXa1.DataSource = DsXa1;
            Cboxa3.DisplayMember = "TenPhuongXa";
            Cboxa2.DisplayMember = "TenPhuongXa";
            CboXa1.DisplayMember = "TenPhuongXa";
            Cboxa3.ValueMember = "MaPhuongXa";
            Cboxa2.ValueMember = "MaPhuongXa";
            CboXa1.ValueMember = "MaPhuongXa";


            CboHuyen1.DataSource = DsHuyen1;
            Cbohuyen2.DataSource = DsHuyen2;
            Cbohuyen3.DataSource = DsHuyen3;
            CboHuyen1.DisplayMember = "TenQuanHuyen";
            Cbohuyen2.DisplayMember = "TenQuanHuyen";
            Cbohuyen3.DisplayMember = "TenQuanHuyen";
            CboHuyen1.ValueMember = "MaQuanHuyen";
            Cbohuyen2.ValueMember = "MaQuanHuyen";
            Cbohuyen3.ValueMember = "MaQuanHuyen";



            CboTenHoKhau.DataSource = FrmMain._danhSachHoKhau;
            CboTenHoKhau.DisplayMember = "TenChuHo";
            CboTenHoKhau.ValueMember = "MaHoKhau";
            Cboxa3.SelectedValue = _nk.QueQuan;
            Cboxa2.SelectedValue = _nk.NoiThuongTruTruocKhiChuyenDen;
            CboXa1.SelectedValue = _nk.NoiLamViec;
            CboHuyen1.SelectedValue = huyen1.MaQuanHuyen;
            Cbohuyen2.SelectedValue = huyen2.MaQuanHuyen;
            Cbohuyen3.SelectedValue = huyen3.MaQuanHuyen;
            var q1 = from s in DsXa3
                     where s.MaPhuongXa.Equals(_nk.QueQuan)
                     select s;

            var q2 = from s in DsXa2
                     where s.MaPhuongXa.Equals(_nk.NoiThuongTruTruocKhiChuyenDen)
                     select s;

            var q3 = from s in DsXa1
                     where s.MaPhuongXa.Equals(_nk.NoiLamViec)
                     select s;

            if (_nk.GioiTinh != null && _nk.GioiTinh.Value.Equals("1"))
            {
                CboGioiTinh.Text = "Nam";
            }
            else
            {
                CboGioiTinh.Text = "Nữ";
            }
            CboDanToc.Text = _nk.DanToc;
            txtHoTen.Text = _nk.TenNhanKhau;
            txtTenKhac.Text = _nk.TenThuongGoi;
            txtCMND.Text = _nk.CMND;
            txtNgheNghiep.Text = _nk.NgheNghiep;
            txtTonGiao.Text = _nk.TonGiao;
            if (_nk.NgaySinh != null) DTPKNgaySinh.Value = _nk.NgaySinh.Value;
            if (_nk.NgayChuyenDen != null) DTPKChuyenDenNgay.Value = _nk.NgayChuyenDen.Value;

        }

        private void CboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CboTinh3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cbohuyen3.DataSource = huyenBo.getList(CboTinh3.SelectedValue.ToString()) ;
                    
            Cbohuyen3.DisplayMember = "TenQuanHuyen";
            Cbohuyen3.ValueMember = "MaQuanHuyen";
        }

        private void Cbohuyen3_SelectedIndexChanged(object sender, EventArgs e)
        {

            Cboxa3.DataSource = bo.getList(Cbohuyen3.SelectedValue.ToString());
            Cboxa3.DisplayMember = "TenPhuongXa";
            Cboxa3.ValueMember = "MaPhuongXa";
        }

        private void CboTinh1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CboHuyen1.DataSource = huyenBo.getList(CboTinh1.SelectedValue.ToString());
            CboHuyen1.DisplayMember = "TenQuanHuyen";
            CboHuyen1.ValueMember = "MaQuanHuyen";
        }

        private void CboHuyen1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CboXa1.DataSource = bo.getList(CboHuyen1.SelectedValue.ToString());
            CboXa1.DisplayMember = "TenPhuongXa";
            CboXa1.ValueMember = "MaPhuongXa";
        }

        private void CboTinh2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cbohuyen2.DataSource = huyenBo.getList(CboTinh2.SelectedValue.ToString());
            Cbohuyen2.DisplayMember = "TenQuanHuyen";
            Cbohuyen2.ValueMember = "MaQuanHuyen";
        }

        private void Cbohuyen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cboxa2.DataSource = bo.getList(Cbohuyen2.SelectedValue.ToString());
            Cboxa2.DisplayMember = "TenPhuongXa";
            Cboxa2.ValueMember = "MaPhuongXa";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ResetLoi();
            int countErrror = 0;
            if (txtCMND.Text.Equals(""))
            {
                lblCMND.Text = "Vui lòng nhập số CMND";
                countErrror++;

            }
            else
            {
                try
                {
                    int a = int.Parse(txtCMND.Text);
                }
                catch (Exception exception)
                {
                    lblCMND.Text = "Số CMND không hợp lệ vui lòng nhập lại";
                    countErrror++;
                }

            }
            if (txtNgheNghiep.Text.Equals(""))
            {
                lblNgheNghiep.Text = "Vui lòng nhập nghề nghiệp";
                countErrror++;
            }
            if (txtHoTen.Text.Equals(""))
            {
                lblHoTen.Text = "Vui lòng nhập họ tên";
            }
            if (txtTonGiao.Text.Equals(""))
            {
                lblTonGiao.Text = "Mời nhập tôn giáo";
                countErrror++;
            }
            if (countErrror == 0)
            {



                _nk.TenNhanKhau = txtHoTen.Text;
                if (!txtTenKhac.Text.Equals(""))
                {
                    _nk.TenThuongGoi = txtTenKhac.Text;
                }

                if (CboGioiTinh.Text.Equals("Nam"))
                {
                    _nk.GioiTinh = true;
                }
                else
                {
                    _nk.GioiTinh = false;
                }
                _nk.NgaySinh = DTPKNgaySinh.Value;
                _nk.DanToc = CboDanToc.Text;
                _nk.TonGiao = txtTonGiao.Text;
                _nk.QueQuan = Cboxa3.SelectedValue.ToString();
                _nk.CMND = txtCMND.Text;
                _nk.NgheNghiep = txtNgheNghiep.Text;
                _nk.NoiLamViec = CboXa1.SelectedValue.ToString();
                _nk.NgayChuyenDen = DTPKChuyenDenNgay.Value;
                _nk.NoiThuongTruTruocKhiChuyenDen = Cboxa2.SelectedValue.ToString();
                if (CboTenHoKhau.SelectedValue != null)
                {
                    if (!_nk.MaHoKhau.Equals(CboTenHoKhau.SelectedValue.ToString()))
                    {
                        var q = from s in DungChung.Db.HoKhaus
                                where s.MaHoKhau.Equals(_nk.MaHoKhau)
                                select s;
                        q.First().SoThanhVien--;
                        _nk.MaHoKhau = CboTenHoKhau.SelectedValue.ToString();

                        var q2 = from s in DungChung.Db.HoKhaus
                                 where s.MaHoKhau.Equals(_nk.MaHoKhau)
                                 select s;
                        q.First().SoThanhVien++;
                    }
                }

                DungChung.Db.SubmitChanges();

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cboxa3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
