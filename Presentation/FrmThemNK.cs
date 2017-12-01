using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using T02_Source_Code.Model;

namespace T02_Source_Code.Presentation
{
    public partial class FrmThemNk : Form
    {
        public FrmThemNk()
        {
            InitializeComponent();
        }

        private List<TinhThanh> DsTinh1 = DungChung.Db.TinhThanhs.ToList();
        private List<TinhThanh> DsTinh2 = DungChung.Db.TinhThanhs.ToList();
        private List<TinhThanh> DsTinh3 = DungChung.Db.TinhThanhs.ToList();

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
        private void button2_Click(object sender, EventArgs e)
        {
            ResetLoi();
            int countErrror=0;
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
            if (Cbohuyen3.Text.Equals("")||Cboxa3.Text.Equals(""))
            {
                lblQueQuan.Text = "Mời chọn quê quán";
                countErrror++;
            }
            if (Cbohuyen2.Text.Equals("") || Cboxa2.Text.Equals(""))
            {
                lblNoiThuongTruTruocKia.Text = "Mời chọn nơi thường trú";
                countErrror++;
            }
            if (CboHuyen1.Text.Equals("") || CboXa1.Text.Equals(""))
            {
                lblNoiLamViec.Text = "Mời chọn nơi làm việc";
                countErrror++;
            }
            if (countErrror==0)
            {
                NhanKhau nKhau=new NhanKhau();
                
                int a= int.Parse(DungChung.Db.NhanKhaus.Max(h => h.MaHoKhau))+1;
                nKhau.MaNhanKhau = a.ToString();
                
                nKhau.MaHoKhau = CboTenHoKhau.SelectedValue.ToString();
                nKhau.TenNhanKhau = txtHoTen.Text;
                if (!txtTenKhac.Text.Equals(""))
                {
                    nKhau.TenThuongGoi = txtTenKhac.Text;
                }
               
                if (CboGioiTinh.Text.Equals("Nam"))
                {
                    nKhau.GioiTinh = true;
                }
                else
                {
                    nKhau.GioiTinh = false;
                }
                nKhau.NgaySinh = DTPKNgaySinh.Value;
                nKhau.DanToc = CboDanToc.Text;
                nKhau.TonGiao = txtTonGiao.Text;
                nKhau.QueQuan = Cboxa3.SelectedValue.ToString();
                nKhau.CMND = txtCMND.Text;
                nKhau.NgheNghiep = txtNgheNghiep.Text;
                nKhau.NoiLamViec = CboXa1.SelectedValue.ToString();
                nKhau.NgayChuyenDen = DTPKChuyenDenNgay.Value;
                nKhau.NoiThuongTruTruocKhiChuyenDen = Cboxa2.SelectedValue.ToString();
                DungChung.Db.NhanKhaus.InsertOnSubmit(nKhau);
                


                var q = from s in DungChung.Db.HoKhaus
                    where s.MaHoKhau.Equals(nKhau.MaHoKhau)
                    select s;
                q.First().SoThanhVien++;
                DungChung.Db.SubmitChanges();
                MessageBox.Show("Thêm thành công!");

            }
        }
        List<View_1> Ds = new List<View_1>();
        private void FrmThemNK_Load(object sender, EventArgs e)
        {

            CboTinh1.DataSource = DsTinh1;
            CboTinh2.DataSource = DsTinh2;
            CboTinh3.DataSource = DsTinh3;
            CboTinh1.DisplayMember = "TenTinhThanh";
            CboTinh2.DisplayMember = "TenTinhThanh";
            CboTinh3.DisplayMember = "TenTinhThanh";
            CboTinh1.ValueMember = "MaTinhThanh";
            CboTinh2.ValueMember = "MaTinhThanh";
            CboTinh3.ValueMember = "MaTinhThanh";

            if (DungChung.MaTinh == null)
            {
               
                var p = from s in DungChung.Db.View_1s
                    select s;
                Ds = p.ToList();
            }
            else
            {
               
                var p = from s in DungChung.Db.View_1s
                    where s.MaTinhThanh.Equals(DungChung.MaTinh) 
                select s;
                Ds = p.ToList();
            }
            if (DungChung.MaHuyen != null)
            {
               
                
                var p = from s in DungChung.Db.View_1s
                        where s.MaQuanHuyen.Equals(DungChung.MaHuyen)
                        select s;
                Ds = p.ToList();
            }
            if (DungChung.MaXa != null)
            {
               
                var p = from s in DungChung.Db.View_1s
                        where s.MaPhuongXa.Equals(DungChung.MaXa)
                        select s;
                Ds = p.ToList();
            }
            CboTenHoKhau.DataSource = Ds;
            CboTenHoKhau.DisplayMember = "TenChuHo";
            CboTenHoKhau.ValueMember = "MaHoKhau";
            CboGioiTinh.Text = "Nam";
            CboDanToc.Text = "Kinh";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
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

        private void CboTinh1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q1 = from s in DungChung.Db.QuanHuyens
                    where s.MaTinhThanh.Equals(CboTinh1.SelectedValue.ToString())
                    select s;
            CboHuyen1.DataSource = q1.ToList();
            CboHuyen1.DisplayMember = "TenQuanHuyen";
            CboHuyen1.ValueMember = "MaQuanHuyen";
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

        private void Cbohuyen3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaQuanHuyen.Equals(Cbohuyen3.SelectedValue.ToString())
                    select s;
            Cboxa3.DataSource = q.ToList();
            Cboxa3.DisplayMember = "TenPhuongXa";
            Cboxa3.ValueMember = "MaPhuongXa";
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

        private void Cbohuyen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaQuanHuyen.Equals(Cbohuyen2.SelectedValue.ToString())
                    select s;
            Cboxa2.DataSource = q.ToList();
            Cboxa2.DisplayMember = "TenPhuongXa";
            Cboxa2.ValueMember = "MaPhuongXa";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Key = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên chủ hộ cần tìm", "Tìm tên", "");
            var q = from s in Ds
                where s.TenChuHo.Contains(Key)
                select s;
            CboTenHoKhau.DataSource = q.ToList();
            CboTenHoKhau.DisplayMember = "TenChuHo";
            CboTenHoKhau.ValueMember = "MaHoKhau";

        }
    }
}
