﻿using System.Windows.Forms;
using T02_Source_Code.Model;
using T02_Source_Code.Bo;
using System.Collections.Generic;
using System;
using T02_Source_Code.Presentation;

namespace T02_Source_Code
{
    public partial class FrmChinhSua : Form
    {
        public FrmChinhSua()
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

        NguoiDung nguoi;

       
        private void frmChinhSua_Load(object sender, System.EventArgs e)
        {
            nguoi = nguoiDungBO.getNguoiDungByID(FrmMain.idUser_Select_qlUser);

            getQuyenNguoiDangNhap();
            loadInfoUser(nguoi);           
            //Load cbb loại TK  
            loadCBBLTK();
            cbbLTK_SelectedIndexChanged_1(null, null);
            loadCBBQuyen();
            //load thông tin đơn vị vs chức vụ của tk
            try
            {
                cbbQuyen.SelectedValue = nguoi.MaChucVu;

                if (nguoi.MaTinhThanh == null)
                {
                    cbbLTK.SelectedValue = 1;
                }
                else if (nguoi.MaQuanHuyen == null)
                {
                    cbbLTK.SelectedValue = 2;
                    cbbTinh.SelectedValue = nguoi.MaTinhThanh;
                }
                else if (nguoi.MaPhuongXa == null)
                {
                    cbbLTK.SelectedValue = 3;
                    cbbTinh.SelectedValue = nguoi.MaTinhThanh;
                    cbbHuyen.SelectedValue = nguoi.MaQuanHuyen;
                }
                else
                {
                    cbbLTK.SelectedValue = 4;
                    cbbTinh.SelectedValue = nguoi.MaTinhThanh;
                    cbbHuyen.SelectedValue = nguoi.MaQuanHuyen;
                    cbbXa.SelectedValue = nguoi.MaPhuongXa;
                }
            }
            catch (Exception)
            {
            }
        }

        private void loadInfoUser(NguoiDung nguoi)
        {
            try
            {
            lblUser.Text = nguoi.MaNguoiDung;
            txtHoTen.Text = nguoi.TenNguoiDung;
            txtMK.Text = nguoi.MatKhau;
            txtNLMK.Text = nguoi.MatKhau;

            
                maTinh = nguoi.MaTinhThanh;
                maHuyen = nguoi.MaQuanHuyen;
                maXa = nguoi.MaPhuongXa;
            }
            catch (Exception)
            {
            }

        }

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
                maTinh = nguoi.MaTinhThanh;

                cbbTinh.Text = tinhThanhBO.get(maTinh).TenTinhThanh;
                cbbHuyen.Text = "";
                cbbXa.Text = "";
            }
            else if (quyen == 3)
            {
                cbbXa.Enabled = true;
                cbbTinh.Enabled = false;
                maTinh = nguoi.MaTinhThanh;

                cbbHuyen.Enabled = false;
                maHuyen = nguoi.MaQuanHuyen;

                cbbTinh.Text = tinhThanhBO.get(maTinh).TenTinhThanh;
                cbbHuyen.Text = quanHuyenBo.get(maHuyen).TenQuanHuyen;
                cbbXa.Text = "";
            }
            else
            {
                cbbXa.Enabled = false;
                maXa = nguoi.MaPhuongXa;
                cbbXa.Text = phuongXaBo.get(maXa).TenPhuongXa;

                cbbTinh.Enabled = false;
                maTinh = nguoi.MaTinhThanh;
                cbbTinh.Text = tinhThanhBO.get(maTinh).TenTinhThanh;

                cbbHuyen.Enabled = false;
                maHuyen = nguoi.MaQuanHuyen;
                cbbHuyen.Text = quanHuyenBo.get(maHuyen).TenQuanHuyen;
                cbbLTK.Enabled = false;
            }
        }
        private void setDefaultCheckLabel()
        {
            lblMK.Text = "";
            lblNhapLai.Text = "";
            lblHoTen.Text = "";
        }

        #endregion


        #region evenSelectedIndexChange

        bool checkload_LTK = false;
        private void cbbLTK_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            setDefaultCBB();
            
            if (checkload_LTK)
            {
                int select = Convert.ToInt32(cbbLTK.SelectedValue.ToString());

                maTinh = null;
                maHuyen = null;
                maXa = null;

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
                    {
                        loadCBBTinh();
                    }
                }
                else if (select == 3)
                {
                    cbbXa.Enabled = false;
                    if (quyen == 1)
                        loadCBBTinh();
                    else if (quyen == 2)
                    {
                        maTinh = nguoi.MaTinhThanh;
                        loadCBBHuyen(maTinh);
                    }
                        
                }
                else if (select == 4)
                {
                    if (quyen == 1)
                        loadCBBTinh();
                    else if (quyen == 2)
                    {
                        maTinh = nguoi.MaTinhThanh;
                        loadCBBHuyen(maTinh);
                    }
                    else if (quyen == 3)
                    {
                        maTinh = nguoi.MaTinhThanh;
                        maHuyen = nguoi.MaQuanHuyen;
                        loadCBBXA(maHuyen);
                    }
                }
            }
            try
            {
               cbbTinh_SelectedIndexChanged(null, null);
                cbbHuyen_SelectedIndexChanged(null, null);
                cbbXa_SelectedIndexChanged_1(null, null);
            }
            catch (Exception)
            {
            }
        }
        bool chkload_Huyen = false;
        private void cbbTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkload_Tinh && cbbTinh.Enabled == true)
            {
                maTinh = cbbTinh.SelectedValue.ToString();
                if (cbbHuyen.Enabled == true)
                    loadCBBHuyen(cbbTinh.SelectedValue.ToString());          
            }
            else if (quyen != 1)
                maTinh = nguoi.MaTinhThanh;
            else maTinh = null;
        }

        bool chkload_Tinh = false;
        private void cbbHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkload_Huyen && cbbHuyen.Enabled==true)
            {
                maHuyen = cbbHuyen.SelectedValue.ToString(); 
                if (cbbXa.Enabled == true)
                    loadCBBXA(cbbHuyen.SelectedValue.ToString());      
            }
            else if (quyen != 1 && quyen != 2)
                maHuyen = nguoi.MaQuanHuyen;
            else maHuyen = null;
        }

        bool chkLoad_Xa = false;
        private void cbbXa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (chkLoad_Xa && cbbXa.Enabled==true)
            {
                maXa = cbbXa.SelectedValue.ToString();
            }
            else if (quyen == 4)
                maXa = nguoi.MaPhuongXa;
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


        private bool checkTextBox()
        {
            bool chk = false;
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
            return chk;
        }

        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            setDefaultCheckLabel();

            if (checkTextBox())
                return;
            else
            {
                try
                {
                    nguoiDungBO.EditUser(lblUser.Text, maTinh, maHuyen, maXa, cbbQuyen.SelectedValue.ToString(), txtHoTen.Text, txtMK.Text);

                    MessageBox.Show("Thay đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception tt)
                {
                    MessageBox.Show(tt.Message);
                }

            }

        }

        private void btnDong_Click(object sender, System.EventArgs e)
        {
             this.Close();
        }
    }
}
