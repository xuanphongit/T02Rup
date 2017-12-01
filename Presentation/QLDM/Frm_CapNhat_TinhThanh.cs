using System;
using System.Windows.Forms;
using T02_Source_Code.Model;
using T02_Source_Code.Bo;
using System.Collections.Generic;
using System.Linq;

namespace T02_Source_Code.Presentation
{
    public partial class Frm_CapNhat_TinhThanh : Form
    {
        public string MaTinhThanh { get; set; }
        public string TenTinhThanh { get; set; }

        public Frm_CapNhat_TinhThanh()
        {
            InitializeComponent();
        }

        private void Frm_CapNhat_QuanHuyen_Load(object sender, EventArgs e)
        {
            ResetForm();

            txtMaTinhThanh.Text = MaTinhThanh;
            txtTenTinhThanh.Text = TenTinhThanh;
        }
        


        private void btnCapNhat_Click(object sender, EventArgs e)
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
            else
            {
                foreach(var x in DungChung.Db.TinhThanhs.Where(p => p.MaTinhThanh == MaTinhThanh))
                {
                    x.TenTinhThanh = txtTenTinhThanh.Text;
                }
                DungChung.Db.SubmitChanges();
                DungChung.frmMain.QLTinhThanh_Load();
                MessageBox.Show("Đã cập nhật tỉnh thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
