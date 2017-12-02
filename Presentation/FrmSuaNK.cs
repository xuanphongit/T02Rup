﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using T02_Source_Code.Model;

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
        private List<PhuongXa> DsXa1 = DungChung.Db.PhuongXas.ToList();
        private List<PhuongXa> DsXa2 = DungChung.Db.PhuongXas.ToList();
        private List<PhuongXa> DsXa3 = DungChung.Db.PhuongXas.ToList();
        private List<QuanHuyen> DsHuyen1 = DungChung.Db.QuanHuyens.ToList();
        private List<QuanHuyen> DsHuyen2 = DungChung.Db.QuanHuyens.ToList();
        private List<QuanHuyen> DsHuyen3 = DungChung.Db.QuanHuyens.ToList();
        private void button2_Click(object sender, EventArgs e)
        {

          
        }
        

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
        private NhanKhau nk;
        List<TinhQuanHuyen> _ds = new List<TinhQuanHuyen>();
        List<HoKhau> _danhSachHoKhau = new List<HoKhau>();
        private void FrmSuaNK_Load(object sender, EventArgs e)
        {
            var pp = from s in DungChung.Db.NhanKhaus
                where s.MaNhanKhau.Equals(FrmMain.MaNhanKhau)
                select s;
            nk=pp.First();
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


            if (DungChung.MaTinh == null)
            {
                var q = from s in DungChung.Db.TinhQuanHuyens
                        select s;
                _ds = q.ToList();
                _danhSachHoKhau = DungChung.Db.HoKhaus.ToList();
            }
            else
            {
                if (DungChung.MaTinh != null)
                {
                    var q = from s in DungChung.Db.TinhQuanHuyens
                            where s.MaTinhThanh.Equals(DungChung.MaTinh)
                            select s;
                    _ds = q.ToList();
                }
                if (DungChung.MaHuyen != null)
                {
                    var q = from s in DungChung.Db.TinhQuanHuyens
                            where s.MaQuanHuyen.Equals(DungChung.MaHuyen)
                            select s;
                    _ds = q.ToList();
                }
                if (DungChung.MaXa != null)
                {
                    var q = from s in DungChung.Db.TinhQuanHuyens
                            where s.MaPhuongXa.Equals(DungChung.MaXa)
                            select s;
                    _ds = q.ToList();
                }
                foreach (TinhQuanHuyen xa in _ds)
                {
                    var p = from s in DungChung.Db.HoKhaus
                            where s.MaPhuongXa.Equals(xa.MaPhuongXa)
                            select s;
                    foreach (HoKhau hoKhau in p.ToList())
                    {
                        _danhSachHoKhau.Add(hoKhau);
                    }

                }


            }
            CboTenHoKhau.DataSource = _danhSachHoKhau;
            CboTenHoKhau.DisplayMember = "TenChuHo";
            CboTenHoKhau.ValueMember = "MaHoKhau";
            Cboxa3.SelectedValue = nk.QueQuan;
            Cboxa2.SelectedValue = nk.NoiThuongTruTruocKhiChuyenDen;
            CboXa1.SelectedValue = nk.NoiLamViec;
            var q1 = from s in DungChung.Db.TinhQuanHuyens
                where s.MaPhuongXa.Equals(nk.QueQuan)
                select s;
            Cbohuyen3.SelectedValue = q1.First().MaQuanHuyen;
            CboTinh3.SelectedValue = q1.First().MaTinhThanh;
            var q2 = from s in DungChung.Db.TinhQuanHuyens
                     where s.MaPhuongXa.Equals(nk.NoiThuongTruTruocKhiChuyenDen)
                     select s;
            Cbohuyen2.SelectedValue = q2.First().MaQuanHuyen;
            CboTinh2.SelectedValue = q2.First().MaTinhThanh;
            var q3 = from s in DungChung.Db.TinhQuanHuyens
                     where s.MaPhuongXa.Equals(nk.NoiLamViec)
                     select s;
            CboHuyen1.SelectedValue = q1.First().MaQuanHuyen;
            CboTinh1.SelectedValue = q1.First().MaTinhThanh;
            if (nk.GioiTinh.Value.Equals("1"))
            {
                CboGioiTinh.Text = "Nam";
            }
            else
            {
                CboGioiTinh.Text = "Nữ";
            }
            CboDanToc.Text = nk.DanToc;
            txtHoTen.Text = nk.TenNhanKhau;
            txtTenKhac.Text = nk.TenThuongGoi;
            txtCMND.Text = nk.CMND;
            txtNgheNghiep.Text = nk.NgheNghiep;
            txtTonGiao.Text = nk.TonGiao;
            if (nk.NgaySinh != null) DTPKNgaySinh.Value = nk.NgaySinh.Value;
            if (nk.NgayChuyenDen != null) DTPKChuyenDenNgay.Value = nk.NgayChuyenDen.Value;

        }

        private void CboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CboTinh3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q3 = from s in DungChung.Db.QuanHuyens
                     where s.MaTinhThanh.Equals(CboTinh3.SelectedValue.ToString())
                     select s;
            Cbohuyen3.DataSource = q3.ToList();
            Cbohuyen3.DisplayMember = "TenQuanHuyen";
            Cbohuyen3.ValueMember = "MaQuanHuyen";
        }

        private void Cbohuyen3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaQuanHuyen.Equals(Cbohuyen3.SelectedValue.ToString())
                    select s;
            Cboxa3.DataSource = q.ToList();
            Cboxa3.DisplayMember = "TenPhuongXa";
            Cboxa3.ValueMember = "MaPhuongXa";
        }

        private void CboTinh1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q1 = from s in DungChung.Db.QuanHuyens
                     where s.MaTinhThanh.Equals(CboTinh1.SelectedValue.ToString())
                     select s;
            CboHuyen1.DataSource = q1.ToList();
            CboHuyen1.DisplayMember = "TenQuanHuyen";
            CboHuyen1.ValueMember = "MaQuanHuyen";
        }

        private void CboHuyen1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaQuanHuyen.Equals(CboHuyen1.SelectedValue.ToString())
                    select s;
            CboXa1.DataSource = q.ToList();
            CboXa1.DisplayMember = "TenPhuongXa";
            CboXa1.ValueMember = "MaPhuongXa";
        }

        private void CboTinh2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q2 = from s in DungChung.Db.QuanHuyens
                     where s.MaTinhThanh.Equals(CboTinh2.SelectedValue.ToString())
                     select s;
            Cbohuyen2.DataSource = q2.ToList();
            Cbohuyen2.DisplayMember = "TenQuanHuyen";
            Cbohuyen2.ValueMember = "MaQuanHuyen";
        }

        private void Cbohuyen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaQuanHuyen.Equals(Cbohuyen2.SelectedValue.ToString())
                    select s;
            Cboxa2.DataSource = q.ToList();
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
            if (countErrror==0)
            {
                

                
                nk.TenNhanKhau = txtHoTen.Text;
                if (!txtTenKhac.Text.Equals(""))
                {
                    nk.TenThuongGoi = txtTenKhac.Text;
                }

                if (CboGioiTinh.Text.Equals("Nam"))
                {
                    nk.GioiTinh = true;
                }
                else
                {
                    nk.GioiTinh = false;
                }
                nk.NgaySinh = DTPKNgaySinh.Value;
                nk.DanToc = CboDanToc.Text;
                nk.TonGiao = txtTonGiao.Text;
                nk.QueQuan = Cboxa3.SelectedValue.ToString();
                nk.CMND = txtCMND.Text;
                nk.NgheNghiep = txtNgheNghiep.Text;
                nk.NoiLamViec = CboXa1.SelectedValue.ToString();
                nk.NgayChuyenDen = DTPKChuyenDenNgay.Value;
                nk.NoiThuongTruTruocKhiChuyenDen = Cboxa2.SelectedValue.ToString();
                if (CboTenHoKhau.SelectedValue != null)
                {
                    if (!nk.MaHoKhau.Equals(CboTenHoKhau.SelectedValue.ToString()))
                    {
                        var q = from s in DungChung.Db.HoKhaus
                                where s.MaHoKhau.Equals(nk.MaHoKhau)
                                select s;
                        q.First().SoThanhVien--;
                        nk.MaHoKhau = CboTenHoKhau.SelectedValue.ToString();

                        var q2 = from s in DungChung.Db.HoKhaus
                                 where s.MaHoKhau.Equals(nk.MaHoKhau)
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
    }
    
}
