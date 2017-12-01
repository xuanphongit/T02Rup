using System;
using System.Linq;
using System.Windows.Forms;
using T02_Source_Code.Model;

namespace T02_Source_Code.Presentation
{
    public partial class FrmDoiMatKhau : Form
    {
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            ResetLoi();
            int countError = 0;
            if (txtMatKhauCu.Text.Equals(""))
            {
                lblMatKhauCu.Text = "Mời nhập mật khẩu cũ!";
                countError++;
            }
            if (txtMatKhauMoi.Text.Equals(""))
            {
                lblMatKhauMoi.Text = "Mời nhập mật khẩu mới!";
                countError++;
            }
            if (txtNhapLaiMatKhau.Text.Equals(""))
            {
                lblNhapLaiMatKhau.Text = "Mời nhập lại mật khẩu mới!";
                countError++;
            }
            if (!txtMatKhauMoi.Text.Equals(txtNhapLaiMatKhau.Text))
            {
                lblNhapLaiMatKhau.Text = "Mật khẩu không trùng khớp !";
                countError++;
            }
            if (txtMatKhauCu.Text.Equals(txtMatKhauMoi.Text))
            {
                lblMatKhauMoi.Text = "Mật khẩu mới phải khác mật khẩu cũ!";
                countError++;
            }
            if (countError==0)
            {
                var q = from s in DungChung.Db.NguoiDungs
                        where s.MaNguoiDung.Equals(DungChung.MaNguoiDung)
                        select s;
                if (q.Any())
                {
                    q.First().MatKhau = txtMatKhauMoi.Text;
                    DungChung.Db.SubmitChanges();
                    MessageBox.Show("Thay đổi thành công !");
                    Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ sai!");
                    ResetLoi();
                    ResetThongTin();}
                
            }
      
        }
        private void ResetLoi()
        {
            lblMatKhauMoi.Text = "*";
            lblMatKhauCu.Text = "*";
            lblNhapLaiMatKhau.Text = "*";
        }

        private void ResetThongTin()
        {
            txtMatKhauMoi.Text = "";
         
            txtMatKhauCu.Text = "";
            txtMatKhauCu.Focus();
            txtNhapLaiMatKhau.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMatKhauCu_TextChanged(object sender, EventArgs e)
        {
            ResetLoi();
        }
    }
}
