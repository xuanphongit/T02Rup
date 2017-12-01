using System;
using System.Windows.Forms;
using T02_Source_Code.Model;
using T02_Source_Code.Bo;

namespace T02_Source_Code.Presentation
{
    public partial class Frm_Them_TinhThanh : Form
    {
        public Frm_Them_TinhThanh()
        {
            InitializeComponent();
        }

        private void Frm_Them_TinhThanh_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetForm();
            //Nếu độ dài lớn hơn 10 thì chỉ lấy 10 ký tự đầu tiên
            if (txtMaTinhThanh.Text.Length > 10) txtMaTinhThanh.Text = txtMaTinhThanh.Text.Substring(0, 10);

            if (txtMaTinhThanh.Text.Equals(""))
            {
                lbl_MaPhuongXa.Text = "Vui lòng nhập mã tỉnh thành!";
                return;
            }
            else if (txtTenTinhThanh.Text.Equals(""))
            {
                lbl_TenPhuongXa.Text = "Vui lòng nhập tên tỉnh thành!";
                return;
            }
            else if (DungChung.ttBO.Exist(txtMaTinhThanh.Text))
            {
                lbl_MaPhuongXa.Text = "Mã tỉnh thành đã tồn tại!";
                return;
            }
            else
            {
                TinhThanh tt = new TinhThanh();
                tt.MaTinhThanh = txtMaTinhThanh.Text;
                tt.TenTinhThanh = txtTenTinhThanh.Text;
                DungChung.Db.TinhThanhs.InsertOnSubmit(tt);
                DungChung.Db.SubmitChanges();
                DungChung.frmMain.QLTinhThanh_Load();
                MessageBox.Show("Đã thêm tỉnh thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ResetForm()
        {
            lbl_MaPhuongXa.Text = "";
            lbl_TenPhuongXa.Text = "";
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
