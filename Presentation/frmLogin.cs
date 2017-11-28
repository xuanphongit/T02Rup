using System;
using System.Windows.Forms;
using System.Linq;
using T02_Source_Code.Model;

namespace T02_Source_Code.Presentation
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
           
            
            lblMa.Text = "*";
            lblMatKhau.Text = "*";
        }

        private void ResetInfo()
        {
            txtID.Text = "";
            txtPassword.Text = "";
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Reset();
            int countError = 0;
            if (txtID.Text.Equals(""))
            {
                countError++;
                lblMa.Text = "Mời nhập mã !";
            }
            if (txtPassword.Text.Equals(""))
            {
                countError++;
                lblMatKhau.Text = "Mời nhập mật khẩu !";
            }
            if (countError==0)
            {
                DungChung dungChung = new DungChung();
                var q = from s in DungChung.Db.NguoiDungs
                        where s.MaNguoiDung.Equals(txtID.Text) && s.MatKhau.Equals(txtPassword.Text)
                        select s;
                if (q.Any())
                {
                    DungChung.HoTen = q.First().TenNguoiDung;
                    DungChung.MaChucVu = q.First().MaChucVu;
                    DungChung.MaNguoiDung = q.First().MaNguoiDung;
                    FrmMain frmMain = new FrmMain();
                    Hide();
                    frmMain.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Mời kiểm tra lại !");
                    ResetInfo();}
            }
           

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();}
    }
}
