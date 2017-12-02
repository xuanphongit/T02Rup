using System.Windows.Forms;
using T02_Source_Code.Model;
using T02_Source_Code.Bo;
using System;
using System.Collections.Generic;

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
        TinhThanhBO tinhThanhBO = new TinhThanhBO();
        QuanHuyenBO quanHuyenBo = new QuanHuyenBO();
        PhuongXaBO phuongXaBo = new PhuongXaBO();

        Dictionary<int, string> dicLoaiTaiKhoan = null;

        int quyen;
        string maTinh = null;
        string maHuyen = null;
        string maXa = null;

        private void frmThemNguoiDung_Load(object sender, System.EventArgs e)
        {
            getQuyenNguoiDangNhap();
            setDefaultCBB();
            //Load cbb loại TK  
            loadCBBLTK();
            cbbLTK_SelectedIndexChanged(null, null);
            loadCBBQuyen();
        }

        #region get
        private void getQuyenNguoiDangNhap()
        {
            if (DungChung.MaTinh == null)
                quyen = 1;
            else if (DungChung.MaHuyen == null)
                quyen = 2;
            else if (DungChung.MaXa == null)
                quyen = 3;
            else
                quyen = 4;
        }
        #endregion


        #region setDefault
        private void setDefaultCBB()
        {
            if (quyen == 1)
            {
                cbbTinh.Enabled = true;
                cbbHuyen.Enabled = true;
                cbbXa.Enabled = true;

                cbbTinh.Text = "";
                cbbHuyen.Text = "";
                cbbXa.Text = "";
            }
            else if (quyen == 2)
            {
                cbbHuyen.Enabled = true;
                cbbXa.Enabled = true;

                cbbTinh.Enabled = false;
                maTinh = DungChung.MaTinh;
                cbbTinh.Text = tinhThanhBO.get(maTinh).TenTinhThanh;
                cbbHuyen.Text = "";
                cbbXa.Text = "";
            }
            else if (quyen == 3)
            {
                cbbXa.Enabled = true;
                cbbXa.Text = "";

                cbbTinh.Enabled = false;
                cbbHuyen.Enabled = false;

                maTinh = DungChung.MaTinh;
                cbbTinh.Text = tinhThanhBO.get(maTinh).TenTinhThanh;
                maHuyen = DungChung.MaHuyen;
                cbbHuyen.Text = quanHuyenBo.get(maHuyen).TenQuanHuyen;
            }
            else
            {
                cbbXa.Enabled = false;
                maXa = DungChung.MaXa;
                cbbXa.Text = phuongXaBo.get(maXa).TenPhuongXa;

                cbbTinh.Enabled = false;
                maTinh = DungChung.MaTinh;
                cbbTinh.Text = tinhThanhBO.get(maTinh).TenTinhThanh;

                cbbHuyen.Enabled = false;
                maHuyen = DungChung.MaHuyen;
                cbbHuyen.Text = quanHuyenBo.get(maHuyen).TenQuanHuyen;
                cbbLTK.Enabled = false;
            }
        }
        private void setDefaultCheckLabel()
        {
            lblTK.Text = "";
            lblMK.Text = "";
            lblNhapLai.Text = "";
            lblHoTen.Text = "";
        }

        #endregion



        #region even
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            setDefaultCheckLabel();

            if (checkTextBox())
                return;
            else
            {
                try
                {
                    bool kq = false;
                    kq = nguoiDungBO.AddUser(txtTK.Text, maTinh, maHuyen, maXa, cbbQuyen.SelectedValue.ToString(), txtHoTen.Text, txtMK.Text);

                    if (kq == true)
                        MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception tt)
                {
                    MessageBox.Show(tt.Message);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool checkload_LTK = false;
        private void cbbLTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDefaultCBB();

            if (checkload_LTK)
            {
                int select = Convert.ToInt32(cbbLTK.SelectedValue.ToString());


                if (select == 1)
                {
                    cbbTinh.Enabled = false;
                    cbbHuyen.Enabled = false;
                    cbbXa.Enabled = false;
                }
                else if (select == 2)
                {
                    cbbHuyen.Enabled = false;
                    cbbXa.Enabled = false;
                    if (quyen == 1)
                        loadCBBTinh();
                }
                else if (select == 3)
                {
                    cbbXa.Enabled = false;
                    if (quyen == 1)
                        loadCBBTinh();
                    else if (quyen == 2)
                        loadCBBHuyen(maTinh);
                }
                else if (select == 4)
                {
                    if (quyen == 1)
                        loadCBBTinh();
                    else if (quyen == 2)
                        loadCBBHuyen(maTinh);
                    else if (quyen == 3)
                        loadCBBXA(maHuyen);
                }
            }
            try
            {
                cbbTinh_SelectedIndexChanged_1(null, null);
                cbbHuyen_SelectedIndexChanged_1(null, null);
                cbbXa_SelectedIndexChanged(null, null);
            }
            catch (Exception)
            {
            }
        }

        bool chkload_Huyen = false;
        private void cbbHuyen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (chkload_Huyen && cbbHuyen.Enabled == true)
            {
                maHuyen = cbbHuyen.SelectedValue.ToString();
                if (cbbXa.Enabled == true)
                    loadCBBXA(cbbHuyen.SelectedValue.ToString());
            }
            else if (quyen != 1 && quyen != 2)
                maHuyen = DungChung.MaHuyen;
            else maHuyen = null;
        }

        bool chkload_Tinh = false;
        private void cbbTinh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (chkload_Tinh && cbbTinh.Enabled == true )
            {
                maTinh = cbbTinh.SelectedValue.ToString();
                if (cbbHuyen.Enabled == true)
                    loadCBBHuyen(cbbTinh.SelectedValue.ToString());
            }
            else if (quyen!=1)
                maTinh = DungChung.MaTinh;
            else maTinh = null;

        }

        bool chkLoad_Xa = false;
        private void cbbXa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkLoad_Xa && cbbXa.Enabled == true)
            {
                maXa = cbbXa.SelectedValue.ToString();
            }
            else if (quyen == 4)
                maXa = DungChung.MaXa;
            else maXa = null;

        }
        #endregion



        #region load ComBoxBOX
        private void loadCBBLTK()
        {
            if (quyen == 1)
            {
                dicLoaiTaiKhoan = new Dictionary<int, string>() {
                        {1,"ADmin" },
                        {2,"Tài khoản Tỉnh" },
                        {3,"Tài khoản Huyện" },
                        {4,"Tài khoản Xã" }
                };
            }
            else if (quyen == 2)
            {
                dicLoaiTaiKhoan = new Dictionary<int, string>() {
                        {2,"Tài khoản Tỉnh" },
                        {3,"Tài khoản Huyện" },
                        {4,"Tài khoản Xã" }
                };
            }
            else if (quyen == 3)
            {
                dicLoaiTaiKhoan = new Dictionary<int, string>() {
                       {3,"Tài khoản Huyện" },
                        {4,"Tài khoản Xã" }
                };
            }
            else
                dicLoaiTaiKhoan = new Dictionary<int, string>() { { 4, "Tài khoản Xã" } };

            cbbLTK.DataSource = new BindingSource(dicLoaiTaiKhoan, null);
            cbbLTK.DisplayMember = "Value";
            cbbLTK.ValueMember = "Key";

            checkload_LTK = true;
        }
        private void loadCBBQuyen()
        {
            cbbQuyen.DataSource = ChucVuBO.getList();
            cbbQuyen.DisplayMember = "TenChucVu";
            cbbQuyen.ValueMember = "MaChucVu";

        }
        private void loadCBBXA(string maHuyen)
        {
            cbbXa.DataSource = phuongXaBo.getList(maHuyen);
            cbbXa.DisplayMember = "TenPhuongXa";
            cbbXa.ValueMember = "MaPhuongXa";

            chkLoad_Xa = true;
        }

        private void loadCBBHuyen(string maTinh)
        {
            cbbHuyen.DataSource = quanHuyenBo.getList(maTinh);
            cbbHuyen.DisplayMember = "TenQuanHuyen";
            cbbHuyen.ValueMember = "MaQuanHuyen";
            chkload_Huyen = true;
        }

        private void loadCBBTinh()
        {
            cbbTinh.DataSource = tinhThanhBO.getList();
            cbbTinh.DisplayMember = "TenTinhThanh";
            cbbTinh.ValueMember = "MaTinhThanh";
            chkload_Tinh = true;
        }
        #endregion


        #region check
        private bool checkTextBox()
        {
            bool chk = false;
            if (txtTK.Text == "")
            {
                lblTK.Text = "Trường này không được trống";
                chk = true;
            }
            if (txtMK.Text == "")
            {
                lblMK.Text = "Trường này không được trống";
                chk = true;
            }
            if (txtNLMK.Text == "")
            {
                lblNhapLai.Text = "Trường này không được trống";
                chk = true;
            }
            if (txtNLMK.Text != "" && txtMK.Text != "" && !txtMK.Text.Equals(txtNLMK.Text))
            {
                lblNhapLai.Text = "Mật khẩu nhập lại không đúng";
                chk = true;
            }
            if (txtHoTen.Text == "")
            {
                lblHoTen.Text = "Trường này không được trống";
                chk = true;
            }

            if (nguoiDungBO.CheckID(txtTK.Text))
            {
                lblTK.Text = "Người dùng đã tồn tại";
                chk = true;
            }
            return chk;
        }
        #endregion   

    }
}
