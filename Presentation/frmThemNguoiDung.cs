using System.Windows.Forms;
using T02_Source_Code.Model;
using T02_Source_Code.Bo;
using System;
using System.Collections.Generic;
//using System.Collections.Generic;

namespace T02_Source_Code.Presentation
{
    public partial class FrmThemNguoiDung : Form
    {
        public FrmThemNguoiDung()
        {
            InitializeComponent();
        }
        ChucVuBO ChucVuBO = new ChucVuBO();
        NguoiDungBO nguoiDungBO = new NguoiDungBO();

        Dictionary<int, string> dicLoaiTaiKhoan = null;

        private void frmThemNguoiDung_Load(object sender, System.EventArgs e)
        {

            //Load cbb loại TK  
            loadCBBLTK();

        }

        #region setDefault
        private void setDefaultCBB()
        {
            cbbQuyen.Enabled = true;
            cbbLTK.Enabled = true;
            cbbTinh.Enabled = true;
            cbbHuyen.Enabled = true;
            cbbXa.Enabled = true;
        }
        private void setDefaultCheckLabel()
        {
            lblTK.Text = "";
            lblMK.Text = "";
            lblNhapLai.Text = "";
            lblHoTen.Text = "";
        }

        #endregion



        #region evenSelectedIndexChange
        private void cbbLTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = Convert.ToInt32(cbbLTK.SelectedValue.ToString());
            setDefaultCBB();
            //Load cbb quyền
            if (select == 1)
            {
                //nếu là tài khoản admin thì k được chọn quyền
                cbbQuyen.Enabled = false;
                //
                cbbTinh.Enabled = false;
                cbbHuyen.Enabled = false;
                cbbXa.Enabled = false;
                return;
            }
            else if (select == 2)
            {
                loadCBBTinh();
                cbbHuyen.Enabled = false;
                cbbXa.Enabled = false;
            }
            else if (select == 3)
            {
                cbbTinh.Text = new TinhThanhBO().get(DungChung.MaTinh).TenTinhThanh;
                cbbTinh.Enabled = false;

                loadCBBHuyen(DungChung.MaTinh);
                cbbXa.Enabled = false;
            }
            else
            {
                cbbTinh.Text = new TinhThanhBO().get(DungChung.MaTinh).TenTinhThanh;
                cbbTinh.Enabled = false;

                cbbHuyen.Text = new QuanHuyenBO().get(DungChung.MaHuyen).TenQuanHuyen;
                cbbHuyen.Enabled = false;

                loadCBBXA(DungChung.MaHuyen);
            }
            loadCBBQuyen();
        }
  
        private void cbbHuyen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbXa.Enabled == true)
            {
                loadCBBXA(cbbHuyen.SelectedValue.ToString());
            }
        }

        private void cbbTinh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbHuyen.Enabled == true)
            {
                loadCBBHuyen(cbbTinh.SelectedValue.ToString());
            }
        }

      


        #endregion



        #region load ComBoxBOX
        private void loadCBBLTK()
        {
            if (DungChung.MaTinh == null )
            {
                dicLoaiTaiKhoan = new Dictionary<int, string>() {
                        {1,"ADmin" },
                        {2,"Tài khoản Tỉnh" },
                        {3,"Tài khoản Huyện" },
                        {4,"Tài khoản Xã" }
                };
            }
            else if (DungChung.MaHuyen == null)
            {
                dicLoaiTaiKhoan = new Dictionary<int, string>() {
                        {2,"Tài khoản Tỉnh" },
                        {3,"Tài khoản Huyện" },
                        {4,"Tài khoản Xã" }
                };
            }
            else if (DungChung.MaXa == null)
            {
                dicLoaiTaiKhoan = new Dictionary<int, string>() {
                       {3,"Tài khoản Huyện" },
                        {4,"Tài khoản Xã" }
                };
            }
            else
            {
                dicLoaiTaiKhoan = new Dictionary<int, string>() { { 4, "Tài khoản Xã" } };

            }

            cbbLTK.DataSource = new BindingSource(dicLoaiTaiKhoan, null);
            cbbLTK.DisplayMember = "Value";
            cbbLTK.ValueMember = "Key";
        }
        private void loadCBBQuyen()
        {
            cbbQuyen.DataSource = ChucVuBO.getList();
            cbbQuyen.DisplayMember = "TenChucVu";
            cbbQuyen.ValueMember = "MaChucVu";
        }
        private void loadCBBXA(string maHuyen)
        {
            cbbHuyen.DataSource = new PhuongXaBO().getList(maHuyen);
            cbbHuyen.DisplayMember = "TenPhuongXa";
            cbbHuyen.ValueMember = "MaPhuongXa";
        }

        private void loadCBBHuyen(string maTinh)
        {
            cbbHuyen.DataSource = new QuanHuyenBO().getList(maTinh);
            cbbHuyen.DisplayMember = "TenQuanHuyen";
            cbbHuyen.ValueMember = "MaQuanHuyen";
        }

        private void loadCBBTinh()
        {
            cbbTinh.DataSource = new TinhThanhBO().getList();
            cbbTinh.DisplayMember = "TenTinhThanh";
            cbbTinh.ValueMember = "MaTinhThanh";
        }
        #endregion
       

        private void checkEmptyTextBox()
        {
            if (txtTK.Text=="")
            {
                lblTK.Text = "Trường này không được trống";
            }
            if (txtMK.Text=="")
            {
                lblMK.Text = "Trường này không được trống";
            }
            if (txtNLMK.Text=="")
            {
                lblNhapLai.Text = "Trường này không được trống";
            }
            if (txtHoTen.Text=="")
            {
                lblHoTen.Text = "Trường này không được trống";
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            checkEmptyTextBox();


            if (!txtMK.Text.Equals(txtNLMK.Text))
            {
                lblNhapLai.Text = "Mật khẩu nhập lại không đúng";
                return;
            }
            if (nguoiDungBO.CheckID(txtTK.Text))
            {
                lblTK.Text = "Người dùng đã tồn tại";
                return;
            }
            else
            {
                try
                {
                    int select = Convert.ToInt32(cbbLTK.SelectedValue.ToString());
                    bool kq = false;
                    if (select == 1)
                        kq = nguoiDungBO.AddUser(txtTK.Text, null, null, null, "AD", txtHoTen.Text, txtMK.Text);
                    else if (select == 2)
                        kq = nguoiDungBO.AddUser(txtTK.Text, cbbTinh.SelectedValue.ToString(), null, null, cbbQuyen.SelectedValue.ToString(), txtHoTen.Text, txtMK.Text);
                    else if (select == 3)
                        kq = nguoiDungBO.AddUser(txtTK.Text, DungChung.MaTinh, cbbHuyen.SelectedValue.ToString(), null, cbbQuyen.SelectedValue.ToString(), txtHoTen.Text, txtMK.Text);
                    else if (select == 4)
                        kq = nguoiDungBO.AddUser(txtTK.Text, DungChung.MaTinh, DungChung.MaHuyen, cbbXa.SelectedValue.ToString(), cbbQuyen.SelectedValue.ToString(), txtHoTen.Text, txtMK.Text);
                    if (kq == true)
                        MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception tt) 
                {
                    MessageBox.Show(tt.Message);                 
                }
                
            }

            setDefaultCheckLabel();
        }
    }
}
