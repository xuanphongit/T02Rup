using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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

        private string _maTinh, _maHuyen;

        private void ResetLoi()
        {
            lblHoTen.Text = "";
            lblHoSoHoKhauSo.Text = "";
            lblXa1.Text = "";
            lblThongBao.Text = "";
            lblThongBao.ForeColor=Color.Red;
            lblXa2.Text = "";
            lblSoDangKiThuongTru.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            int countError = 0, hoSoHoKhauSo=0;
            ResetLoi();
            
           
            if (txtTenChuHo.Text.Equals(""))
            {
                lblThongBao.Text = "Vui lòng nhập các thông tin bắt buộc";
                lblHoTen.Text = "*";
             
                countError++;
            }
            else
            {
                String hoTen = txtTenChuHo.Text.Trim();
                String output= Regex.Replace(hoTen, "\\s+", "");

                bool match = Regex.IsMatch(output, "\\W");
                bool match2 = Regex.IsMatch(output, @"\d");
                if (match2 || match)
                {
                    lblHoTen.Text = "Không nhập các kí tự số,các kí tự đặc biệt";
                    countError++;
                }
            }
           
            if (txtHoSoHoKhauSo.Text.Equals(""))
            {
                lblThongBao.Text = "Vui lòng nhập các thông tin bắt buộc";
                countError++;
                lblHoSoHoKhauSo.Text = "";
            }
            else if (Regex.IsMatch(txtHoSoHoKhauSo.Text, @"\D"))
            {
                lblHoSoHoKhauSo.Text = "Không nhập chữ cái hoặc kí tự đặc biệt vào đây";
                countError++;
            }
            else
            {
                hoSoHoKhauSo = int.Parse(txtHoSoHoKhauSo.Text);
                var q = from s in DungChung.Db.HoKhaus
                        where s.HoSoHKSo == hoSoHoKhauSo
                        select s;
                if (q.Any())
                {
                    lblHoSoHoKhauSo.Text = "Số hồ sơ hộ khẩu trùng!";
                    countError++;
                }
            }
                
            
            if (txtSoDangKiThuongTru.Text.Equals(""))
            {
                lblThongBao.Text = "Vui lòng nhập các thông tin bắt buộc";
                countError++;
                lblSoDangKiThuongTru.Text = "";
            }
            else if(Regex.IsMatch(txtSoDangKiThuongTru.Text,@"\D"))
            {
                lblSoDangKiThuongTru.Text = "Không nhập chữ cái hoặc kí tự đặc biệt vào đây";
                countError++;
            }

            if (CboXa1.SelectedValue==null)
            {
                lblThongBao.Text = "Vui lòng nhập các thông tin bắt buộc";
                countError++;
                
            }
            if (Cboxa2.SelectedValue==null)
            {
                lblThongBao.Text = "Vui lòng nhập các thông tin bắt buộc";
                countError++;
            }
            if (countError==0)
            {
                
                HoKhau hk=new HoKhau();
                int a = int.Parse(DungChung.Db.HoKhaus.Max(h => h.MaHoKhau)) + 1;
                hk.MaHoKhau = a.ToString();
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
                FrmMain._danhSachHoKhau.Add(hk);
                MessageBox.Show("Thêm thành công");
            }
        }

        private void CboHuyen1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
                _maHuyen = CboHuyen1.SelectedValue.ToString();
                var q = from s in DungChung.Db.PhuongXas
                        where s.MaQuanHuyen.Equals(_maHuyen)
                        select s;
                CboXa1.DataSource = q.ToList();
                CboXa1.DisplayMember = "TenPhuongXa";
                CboXa1.ValueMember = "MaPhuongXa";
            
            
        }

        private void CboTinh2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _maTinh = CboTinh2.SelectedValue.ToString();
            var q = from s in DungChung.Db.QuanHuyens
                    where s.MaTinhThanh.Equals(_maTinh)
                    select s;
            Cbohuyen2.DataSource = q.ToList();
            Cbohuyen2.DisplayMember = "TenQuanHuyen";
            Cbohuyen2.ValueMember = "MaQuanHuyen";
        }

        private void Cbohuyen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _maHuyen = Cbohuyen2.SelectedValue.ToString();
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaQuanHuyen.Equals(_maHuyen)
                    select s;
            Cboxa2.DataSource = q.ToList();
            Cboxa2.DisplayMember = "TenPhuongXa";
            Cboxa2.ValueMember = "MaPhuongXa";
        }

        private void FrmThemHK_Load(object sender, EventArgs e)
        {

            if (DungChung.MaTinh==null)
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
            if (DungChung.MaHuyen!=null)
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
            if (DungChung.MaXa!=null)
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

        private void CboXa1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            
                _maTinh = CboTinh1.SelectedValue.ToString();
                var q = from s in DungChung.Db.QuanHuyens
                        where s.MaTinhThanh.Equals(_maTinh)
                        select s;
                CboHuyen1.DataSource = q.ToList();
                CboHuyen1.DisplayMember = "TenQuanHuyen";
                CboHuyen1.ValueMember = "MaQuanHuyen";
            
           
        }
    }
}
