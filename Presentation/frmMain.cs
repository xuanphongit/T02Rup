using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using T02_Source_Code.Model;
using T02_Source_Code.Bo;

namespace T02_Source_Code.Presentation
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private List<HoKhau> _danhSachHoKhau;
        private List<NhanKhau> _danhSachNhanKhau;
        private List<TinhThanh> _danhsachTinhThanh;
        private List<QuanHuyen> _danhsachQuanHuyen;
        private List<PhuongXa> _danhsachPhuongXa;
        NguoiDungBO qluser = new NguoiDungBO();
        TinhThanhBO tinhThanhBo = new TinhThanhBO();
        QuanHuyenBO quanHuyenBO = new QuanHuyenBO();
        PhuongXaBO phuongXaBo = new PhuongXaBO();


        FrmThemNguoiDung frmAddUser = null;
        FrmChinhSua frmEditUser = null;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblTenNguoiDung.Text = "Xin Chào : " + DungChung.HoTen;
            ResetKhungThongTin();
            QLDanhMuc_Load();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    dataGVDSUser.DataSource = null;
                    dataGVDSUser.DataSource = qluser.search(qluser.getListUser(DungChung.MaNguoiDung), "");
                    break;
                default:
                    break;
            }
        }

        #region QlNhanKhauHoKhau
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
            FrmDoiMatKhau doiMatKhau = new FrmDoiMatKhau();
            Hide();
            doiMatKhau.ShowDialog();
            Show();
        }


        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool _finished = false;
        public static string MaHoKhau, MaNhanKhau;
        private void button8_Click_1(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemHoKhauNhanKhau.Text.ToLower();
            var q = from s in DungChung.Db.HoKhaus
                    where s.TenChuHo.ToLower().Contains(tuKhoa)
                    select s;
            var p = from s in DungChung.Db.NhanKhaus
                    where s.TenNhanKhau.ToLower().Contains(tuKhoa) || s.TenThuongGoi.ToLower().Contains(tuKhoa)
                    select s;
            _danhSachHoKhau = q.ToList();
            _danhSachNhanKhau = p.ToList();
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
            FrmThemHk frmThemHk = new FrmThemHk();
            frmThemHk.ShowDialog();
            ReloadThongTin();

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

            if (_finished)
            {
                ResetKhungThongTin();
                MaHoKhau = LstHoKhau.SelectedValue.ToString();
                var q = from hoKhau in _danhSachHoKhau
                        where hoKhau.MaHoKhau.Equals(MaHoKhau)
                        select hoKhau;
                txtMaSo.Text = "Mã số :     " + q.First().MaHoKhau;
                txtHoTen.Text = "Họ tên:     " + q.First().TenChuHo;
                txtGioiTinh_SoThanhVien.Text = "Số thành viên:     " + q.First().SoThanhVien;
                txtQueQuan_NoiThuongTru.Text = "Nơi thường trú:     " + LayThongTinDiaDiem(q.First().NoiThuongTru);
                txtDanToc_NoiCap.Text = "Nơi cấp:     " + LayThongTinDiaDiem(q.First().NoiCap);
                txtTonGiaoNgayCap.Text = "Ngày cấp:     " + q.First().NgayCap.Value.Day + "/" + q.First().NgayCap.Value.Month + "/" + q.First().NgayCap.Value.Year;
                txtNoiLamViec_NguoiCap.Text = "Người cấp:     " + q.First().NguoiCap;
                txtNgheNghiep_HoSoHoKhauSo.Text = "Hồ sơ hộ khẩu số:     " + q.First().HoSoHKSo;
                txtNoiThuongTruTruocKhiChuyenDen_SoDKThuongTru.Text = "Số đăng kí thường trú:     " + q.First().SoDKThuongTru;

            }


        }
        public static string LayThongTinDiaDiem(string maXa)
        {

            var q = from s in DungChung.Db.PhuongXas
                    where s.MaPhuongXa.Equals(maXa)
                    select s;
            string maHuyen = q.First().MaQuanHuyen;

            var q2 = from s in DungChung.Db.QuanHuyens
                     where s.MaQuanHuyen.Equals(maHuyen)
                     select s;
            string maTinh = q2.First().MaTinhThanh;

            var q3 = from s in DungChung.Db.TinhThanhs
                     where s.MaTinhThanh.Equals(maTinh)
                     select s;
            return string.Concat(q.First().TenPhuongXa, " - ", q2.First().TenQuanHuyen, " - ", q3.First().TenTinhThanh);
        }
        private void LstNhanKhau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_finished)
            {
                ResetKhungThongTin();
                MaNhanKhau = LstNhanKhau.SelectedValue.ToString();
                var q = from nhanKhau in _danhSachNhanKhau
                        where nhanKhau.MaNhanKhau.Equals(MaNhanKhau)
                        select nhanKhau;
                txtMaSo.Text = "Mã số:      " + q.First().MaNhanKhau;
                txtHoTen.Text = "Họ tên     " + q.First().TenNhanKhau;
                txtTenThuongGoi.Text = "Tên thường gọi:     " + q.First().TenThuongGoi;
                txtGioiTinh_SoThanhVien.Text = "Giới tính:     " + q.First().GioiTinh;
                txtNgaySinh.Text = "Ngày sinh:     " + q.First().NgaySinh;
                txtDanToc_NoiCap.Text = "Nơi cấp:     " + q.First().DanToc;
                txtTonGiaoNgayCap.Text = "Tôn giáo:     " + q.First().TonGiao;
                txtQueQuan_NoiThuongTru.Text = "Quê quán:     " + LayThongTinDiaDiem(q.First().QueQuan);
                txtCMND.Text = "CMND:     " + q.First().CMND;
                txtNgheNghiep_HoSoHoKhauSo.Text = "Nghề nghiệp:     " + q.First().NgheNghiep;
                txtNoiLamViec_NguoiCap.Text = "Nơi làm việc:     " + LayThongTinDiaDiem(q.First().NoiLamViec);
                txtNgayChuyenDen.Text = "Ngày chuyển đến:     " + q.First().NgayChuyenDen;
                txtNoiThuongTruTruocKhiChuyenDen_SoDKThuongTru.Text = "Nơi thường trú trước khi chuyển đến:   " + LayThongTinDiaDiem(q.First().NoiThuongTruTruocKhiChuyenDen);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MaNhanKhau==null)
            {
                MessageBox.Show("Mời chọn nhân khẩu trước");
            }
            else
            {
                FrmTachHk frmTachHk = new FrmTachHk();
                frmTachHk.ShowDialog();
                ReloadThongTin();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MaHoKhau == null)
            {
                MessageBox.Show("Mời chọn hộ khẩu");
            }
            else
            {
                FrmSuaHk frmSuaHk = new FrmSuaHk();
                frmSuaHk.ShowDialog();
                ReloadThongTin();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (MaHoKhau==null)
            {
                MessageBox.Show("Mời chọn hộ khẩu trước");
            }
            else
            {
                DialogResult a = MessageBox.Show("Bạn muốn chắc chắn xóa không?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.Yes)
                {

                    HoKhau hk = DungChung.Db.HoKhaus.Single(p => p.MaHoKhau.Equals(LstHoKhau.SelectedValue.ToString()));
                    _danhSachHoKhau.Remove(hk);
                    LstHoKhau.DataSource = null;
                    LstHoKhau.DataSource = _danhSachHoKhau;
                    LstHoKhau.DisplayMember = "TenChuHo";
                    LstHoKhau.ValueMember = "MaHoKhau";
                    DungChung.Db.HoKhaus.DeleteOnSubmit(hk);
                    DungChung.Db.SubmitChanges();
                    ReloadThongTin();

                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            FrmThemNk frmThemNk = new FrmThemNk();
            frmThemNk.ShowDialog();
            ReloadThongTin();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MaNhanKhau==null)
            {
                MessageBox.Show("Mời chọn nhân khẩu trước");
            }
            else
            {
                FrmSuaNk frmSuaNk = new FrmSuaNk();
                frmSuaNk.ShowDialog();
                ReloadThongTin();
            }
            
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void txtHoTen_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (MaNhanKhau==null)
            {
                MessageBox.Show("Mời chọn nhân khẩu trước");
            }
            else
            {
                DialogResult a = MessageBox.Show("Bạn muốn chắc chắn xóa không?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (a == DialogResult.Yes)
                {
                    NhanKhau nk = DungChung.Db.NhanKhaus.Single(p => p.MaNhanKhau.Equals(LstNhanKhau.SelectedValue.ToString()));
                    _danhSachNhanKhau.Remove(nk);
                    LstNhanKhau.DataSource = null;
                    LstNhanKhau.DataSource = _danhSachNhanKhau;
                    LstNhanKhau.DisplayMember = "TenNhanKhau";
                    LstNhanKhau.ValueMember = "MaNhanKhau";
                    DungChung.Db.NhanKhaus.DeleteOnSubmit(nk);
                    DungChung.Db.SubmitChanges();
                    ReloadThongTin();
                }
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ReloadThongTin()
        {
            _danhSachHoKhau = DungChung.Db.HoKhaus.ToList();
            _danhSachNhanKhau = DungChung.Db.NhanKhaus.ToList();
            LstHoKhau.DataSource = _danhSachHoKhau;
            LstHoKhau.DisplayMember = "TenChuHo";
            LstHoKhau.ValueMember = "MaHoKhau";

            LstNhanKhau.DataSource = _danhSachNhanKhau;
            LstNhanKhau.DisplayMember = "TenNhanKhau";
            LstNhanKhau.ValueMember = "MaNhanKhau";
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            
            ReloadThongTin();
            MaHoKhau = _danhSachHoKhau.First().MaHoKhau;
            MaNhanKhau = _danhSachNhanKhau.First().MaNhanKhau;

        }
        #endregion

        #region QLUser

        public static string idUser_Select_qlUser = null;

        private void btnThemUser_Click(object sender, EventArgs e)
        {

            frmAddUser = new FrmThemNguoiDung();
            frmAddUser.ShowDialog();
            dataGVDSUser.DataSource = null;
            dataGVDSUser.DataSource = qluser.search(qluser.getListUser(DungChung.MaNguoiDung), "");
        }

        private void btnChinhSuaUser_Click(object sender, EventArgs e)
        {
            if (idUser_Select_qlUser != null)
            {
                try
                {
                    frmEditUser = new FrmChinhSua();
                    frmEditUser.ShowDialog();
                    dataGVDSUser.DataSource = null;
                    dataGVDSUser.DataSource = qluser.search(qluser.getListUser(DungChung.MaNguoiDung), "");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else
                MessageBox.Show("Bạn chưa chọn người dùng cần thao tác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
        private void btnXoaUser_Click(object sender, EventArgs e)
        {
            if (idUser_Select_qlUser != null)
            {
                try
                {
                    qluser.DeleteUser(idUser_Select_qlUser);
                    MessageBox.Show("Đã xóa!");
                    dataGVDSUser.DataSource = qluser.search(qluser.getListUser(DungChung.MaNguoiDung), txtTKUser.Text);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else
             MessageBox.Show("Bạn chưa chọn người dùng cần thao tác!", "Thông báo!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void tabQluser_Click(object sender, EventArgs e)
        {
            dataGVDSUser.DataSource = null;
            dataGVDSUser.DataSource = qluser.search(qluser.getListUser(DungChung.MaNguoiDung), "");
            idUser_Select_qlUser = null;
        }

        private void dataGVDSUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;

                idUser_Select_qlUser = dataGVDSUser[0, r].Value.ToString();

                lblTaiKhoan_user.Text = "Tài khoản: " + idUser_Select_qlUser;
                lblHoTen_user.Text = "Họ tên: " + dataGVDSUser[1, r].Value.ToString();
                lblChucVu_user.Text = "Chức vụ: " + dataGVDSUser[2, r].Value.ToString();


                string dv = "";
                NguoiDung nguoi = qluser.getNguoiDungByID(dataGVDSUser[0, r].Value.ToString());

                if (nguoi.MaTinhThanh == null)
                    dv = "Cao nhất";
                else if (nguoi.MaQuanHuyen == null)
                    dv = tinhThanhBo.get(nguoi.MaTinhThanh).TenTinhThanh;
                else if (nguoi.MaPhuongXa == null)
                    dv = tinhThanhBo.get(nguoi.MaTinhThanh).TenTinhThanh + " - " + quanHuyenBO.get(nguoi.MaQuanHuyen).TenQuanHuyen;
                else
                    dv = tinhThanhBo.get(nguoi.MaTinhThanh).TenTinhThanh + " - " + quanHuyenBO.get(nguoi.MaQuanHuyen).TenQuanHuyen + " - " + phuongXaBo.get(nguoi.MaPhuongXa).TenPhuongXa;
                lblDonVi_user.Text = "Đơn vị: " + dv;

            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            try
            {
                List<infoNguoiDungBean> ds = null;
                ds = qluser.search(qluser.getListUser(DungChung.MaNguoiDung), txtTKUser.Text);
                dataGVDSUser.DataSource = null;

                if (ds == null || ds.Count() == 0)
                    MessageBox.Show("Không tìm thấy!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    dataGVDSUser.DataSource = ds;
            }
            catch (Exception)
            {
                //  throw;
            }
        }

        #endregion

        #region Quản lý danh mục
        private void comboBox_qlqh_tenTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            QLQuanHuyen_Load();
        }

        public void QLDanhMuc_Load()
        {
            QLTinhThanh_Load();
        }

        public void QLTinhThanh_Load()
        {
            _danhsachTinhThanh = DungChung.ttBO.getList();

            comboBox_qlqh_tenTinhThanh.DataSource = _danhsachTinhThanh;
            comboBox_qlqh_tenTinhThanh.DisplayMember = "TenTinhThanh";
            comboBox_qlqh_tenTinhThanh.ValueMember = "MaTinhThanh";
            comboBox_qlpx_tenTinhThanh.DataSource = _danhsachTinhThanh;
            comboBox_qlpx_tenTinhThanh.DisplayMember = "TenTinhThanh";
            comboBox_qlpx_tenTinhThanh.ValueMember = "MaTinhThanh";
            dataGridView_dsTinhThanh.DataSource = _danhsachTinhThanh;

            QLQuanHuyen_Load();
        }

        public void QLQuanHuyen_Load()
        {
            if(comboBox_qlqh_tenTinhThanh.Items.Count > 0)
            {
                _danhsachQuanHuyen = DungChung.qhBO.getList(comboBox_qlqh_tenTinhThanh.SelectedValue.ToString());
                
                comboBox_qlpx_tenQuanHuyen.DataSource = _danhsachQuanHuyen;

                comboBox_qlpx_tenQuanHuyen.DisplayMember = "TenQuanHuyen";
                comboBox_qlpx_tenQuanHuyen.ValueMember = "MaQuanHuyen";

                dataGridView_dsQuanHuyen.DataSource = _danhsachQuanHuyen;
                QLPhuongXa_Load();
            }
        }

        public void QLPhuongXa_Load()
        {
            if(comboBox_qlpx_tenQuanHuyen.Items.Count > 0)
            {
                _danhsachPhuongXa = DungChung.pxBO.getList(comboBox_qlpx_tenQuanHuyen.SelectedValue.ToString());

                dataGridView_dsPhuongXa.DataSource = _danhsachPhuongXa;
            }
        }

        private void comboBox_qlpx_tenQuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            QLPhuongXa_Load();
        }

        private void btn_qltt_Xoa_Click(object sender, EventArgs e)
        {
            int row = dataGridView_dsTinhThanh.CurrentRow.Index;
            if (dataGridView_dsTinhThanh["MaTinhThanh", row].Value != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DungChung.ttBO.Delete(dataGridView_dsTinhThanh["MaTinhThanh", row].Value.ToString());
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QLTinhThanh_Load();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tỉnh thành muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_qlqh_Xoa_Click(object sender, EventArgs e)
        {
            int row = dataGridView_dsQuanHuyen.CurrentRow.Index;
            if (dataGridView_dsQuanHuyen["MaQuanHuyen", row].Value != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string mqh = dataGridView_dsQuanHuyen["MaQuanHuyen", row].Value.ToString();
                    DungChung.qhBO.Delete(mqh);
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QLQuanHuyen_Load();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn quận huyện muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_qlpx_Xoa_Click(object sender, EventArgs e)
        {
            int row = dataGridView_dsPhuongXa.CurrentRow.Index;
            if (dataGridView_dsPhuongXa["MaPhuongXa", row].Value != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DungChung.pxBO.Delete(dataGridView_dsPhuongXa["MaPhuongXa", row].Value.ToString());
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QLPhuongXa_Load();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phường xã muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_qltt_CapNhat_Click(object sender, EventArgs e)
        {
            int row = dataGridView_dsTinhThanh.CurrentRow.Index;
            if (dataGridView_dsTinhThanh["MaTinhThanh", row].Value != null)
            {
                Frm_CapNhat_TinhThanh frmCapNhatTinhThanh = new Frm_CapNhat_TinhThanh();
                frmCapNhatTinhThanh.MaTinhThanh = dataGridView_dsTinhThanh["MaTinhThanh", row].Value.ToString();
                frmCapNhatTinhThanh.TenTinhThanh = dataGridView_dsTinhThanh["TenTinhThanh", row].Value.ToString();
                frmCapNhatTinhThanh.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tỉnh thành muốn cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_qlqh_CapNhat_Click(object sender, EventArgs e)
        {
            int row = dataGridView_dsQuanHuyen.CurrentRow.Index;
            if (dataGridView_dsQuanHuyen["MaQuanHuyen", row].Value != null)
            {
                Frm_CapNhat_QuanHuyen frmCapNhatQuanHuyen = new Frm_CapNhat_QuanHuyen();
                frmCapNhatQuanHuyen.MaQuanHuyen = dataGridView_dsQuanHuyen["MaQuanHuyen", row].Value.ToString();
                frmCapNhatQuanHuyen.TenQuanHuyen = dataGridView_dsQuanHuyen["TenQuanHuyen", row].Value.ToString();
                frmCapNhatQuanHuyen.MaTinhThanh = comboBox_qlqh_tenTinhThanh.SelectedValue.ToString();
                frmCapNhatQuanHuyen.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn quận huyện muốn cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_qlpx_CapNhat_Click(object sender, EventArgs e)
        {
            int row = dataGridView_dsPhuongXa.CurrentRow.Index;
            if (dataGridView_dsPhuongXa["MaPhuongXa", row].Value != null)
            {
                Frm_CapNhat_PhuongXa frmCapNhatPhuongXa = new Frm_CapNhat_PhuongXa();
                frmCapNhatPhuongXa.MaPhuongXa = dataGridView_dsPhuongXa["MaPhuongXa", row].Value.ToString();
                frmCapNhatPhuongXa.TenPhuongXa = dataGridView_dsPhuongXa["TenPhuongXa", row].Value.ToString();
                frmCapNhatPhuongXa.MaTinhThanh = comboBox_qlpx_tenTinhThanh.SelectedValue.ToString();
                frmCapNhatPhuongXa.MaQuanHuyen = comboBox_qlpx_tenQuanHuyen.SelectedValue.ToString();
                frmCapNhatPhuongXa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phường xã muốn cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_qltt_Them_Click(object sender, EventArgs e)
        {
            Frm_Them_TinhThanh frmThemTinhThanh = new Frm_Them_TinhThanh();
            frmThemTinhThanh.ShowDialog();
        }
        private void btn_qlqh_Them_Click(object sender, EventArgs e)
        {
            Frm_Them_QuanHuyen frmThemQuanHuyen = new Frm_Them_QuanHuyen();
            frmThemQuanHuyen.ShowDialog();
        }

        

        private void btn_qlpx_Them_Click(object sender, EventArgs e)
        {
            Frm_Them_PhuongXa frmThemPhuongXa = new Frm_Them_PhuongXa();
            frmThemPhuongXa.ShowDialog();
        }

        #endregion
    }
}
