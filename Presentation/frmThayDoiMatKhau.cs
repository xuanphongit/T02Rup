using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RUP
{
    public partial class frmThayDoiMatKhau : Form
    {
        Bo.DangNhapBo dangnhapbo = new Bo.DangNhapBo();
        public frmThayDoiMatKhau()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            resetLoi();
            int demloi = 0;
           
            if (String.IsNullOrEmpty(txtMatKhauCu.Text))
            {
                txtLoiMatKhauCu.Text="Mời nhập mật khẩu cũ !";
                demloi++;
            }
            if (String.IsNullOrEmpty(txtMatKhauMoi.Text))
            {
                txtLoiMatKhauMoi.Text = "Mời nhập mật khẩu mới";
                demloi++;
            }
            if (String.Compare(txtMatKhauMoi.Text, txtNhapLaiMatKhau.Text, false) != 0)
            {
                txtLoiMatKhauMoiNhapLai.Text = "Mật khẩu không khớp";
                demloi++;
            }
            if (String.IsNullOrEmpty(txtNhapLaiMatKhau.Text))       
            {
                txtLoiMatKhauMoiNhapLai.Text = "Mời nhập lại mật khẩu";
                demloi++;
            }
           

            bool ktraMkCu = dangnhapbo.kTraDangNhap(frmLogin.TenTaiKhoan, txtMatKhauCu.Text);
            if (ktraMkCu&&demloi==0)
            {
                //bool kTra = dangnhapbo.DangKi(txtMatKhauMoi.Text, txtNhapLaiMatKhau.Text);
                bool kTra = dangnhapbo.DoiMatKhau(frmLogin.TenTaiKhoan, txtMatKhauMoi.Text);
                if (kTra)
                {
                    MessageBox.Show("Thành công");

                }
                else
                {
                    MessageBox.Show("Thất bại");
                }

            }
            else if (demloi!=0)
            {       
                //Nhap Lai
            }
            else
            {
                MessageBox.Show("Sai Mật Khẩu");
            }

        }

        private void frmThayDoiMatKhau_Load(object sender, EventArgs e)
        {
           
            reset();
            resetLoi();



        }
        private void reset()
        {
            txtMatKhauMoi.Text = "";
            txtNhapLaiMatKhau.Text = "";
            txtMatKhauCu.Text = "";
            
        }
        private void resetLoi()
        {
            txtLoiMatKhauCu.Text = "";
            txtLoiMatKhauMoi.Text = "";
            txtLoiMatKhauMoiNhapLai.Text = "";
            txtLoiMatKhauCu.ForeColor = Color.Red;
            txtLoiMatKhauMoi.ForeColor = Color.Red;
            txtLoiMatKhauMoiNhapLai.ForeColor = Color.Red;
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
