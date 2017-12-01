using System;
using System.Windows.Forms;
using T02_Source_Code.Model;
using T02_Source_Code.Bo;
using System.Collections.Generic;
using System.Linq;

namespace T02_Source_Code.Presentation
{
    public partial class Frm_CapNhat_QuanHuyen : Form
    {
        public string MaQuanHuyen { get; set; }
        public string TenQuanHuyen { get; set; }
        public string MaTinhThanh { get; set; }

        public Frm_CapNhat_QuanHuyen()
        {
            InitializeComponent();
        }

        private void Frm_CapNhat_QuanHuyen_Load(object sender, EventArgs e)
        {
            ResetForm();
            TinhThanh_Load();

            txtMaQuanHuyen.Text = MaQuanHuyen;
            txtTenQuanHuyen.Text = TenQuanHuyen;
            comboBox_TenTinhThanh.SelectedValue = MaTinhThanh;
        }

        private void TinhThanh_Load()
        {
            comboBox_TenTinhThanh.DataSource = DungChung.ttBO.getList();
            comboBox_TenTinhThanh.DisplayMember = "TenTinhThanh";
            comboBox_TenTinhThanh.ValueMember = "MaTinhThanh";

        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ResetForm();
            //Nếu độ dài lớn hơn 10 thì chỉ lấy 10 ký tự đầu tiên
            if (txtMaQuanHuyen.Text.Length > 10) txtMaQuanHuyen.Text = txtMaQuanHuyen.Text.Substring(0, 10);

            if (txtMaQuanHuyen.Text.Equals(""))
            {
                lbl_MaPhuongXa.Text = "Vui lòng nhập mã quận huyện!";
                return;
            }
            else if (txtTenQuanHuyen.Text.Equals(""))
            {
                lbl_TenPhuongXa.Text = "Vui lòng nhập tên quận huyện!";
                return;
            }
            else if (comboBox_TenTinhThanh.SelectedValue.ToString().Equals(""))
            {
                lbl_TenTinhThanh.Text = "Vui lòng chọn tên tỉnh thành!";
                return;
            }
            else
            {
                foreach(var x in DungChung.Db.QuanHuyens.Where(p => p.MaQuanHuyen == MaQuanHuyen))
                {
                    x.TenQuanHuyen = txtTenQuanHuyen.Text;
                    x.TinhThanh = DungChung.Db.TinhThanhs.Single(p => p.MaTinhThanh == comboBox_TenTinhThanh.SelectedValue.ToString());
                }
                DungChung.Db.SubmitChanges();
                DungChung.frmMain.QLQuanHuyen_Load();
                MessageBox.Show("Đã cập nhật quận huyện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ResetForm()
        {
            lbl_MaPhuongXa.Text = "";
            lbl_TenPhuongXa.Text = "";
            lbl_TenTinhThanh.Text = "";
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
