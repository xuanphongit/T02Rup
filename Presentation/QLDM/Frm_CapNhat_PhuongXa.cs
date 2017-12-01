using System;
using System.Windows.Forms;
using T02_Source_Code.Model;
using T02_Source_Code.Bo;
using System.Collections.Generic;
using System.Linq;

namespace T02_Source_Code.Presentation
{
    public partial class Frm_CapNhat_PhuongXa : Form
    {
        public string MaPhuongXa { get; set; }
        public string TenPhuongXa { get; set; }
        public string MaTinhThanh { get; set; }
        public string MaQuanHuyen { get; set; }

        public Frm_CapNhat_PhuongXa()
        {
            InitializeComponent();
        }

        private void Frm_CapNhat_PhuongXa_Load(object sender, EventArgs e)
        {
            ResetForm();
            TinhThanh_Load();

            txtMaPhuongXa.Text = MaPhuongXa;
            txtTenPhuongXa.Text = TenPhuongXa;

            comboBox_TenTinhThanh.SelectedValue = MaTinhThanh;
            comboBox_TenQuanHuyen.SelectedValue = MaQuanHuyen;
        }

        private void TinhThanh_Load()
        {
            comboBox_TenTinhThanh.DataSource = DungChung.ttBO.getList();
            comboBox_TenTinhThanh.DisplayMember = "TenTinhThanh";
            comboBox_TenTinhThanh.ValueMember = "MaTinhThanh";

            QuanHuyen_Load();
        }

        private void comboBox_TenTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuanHuyen_Load();
        }

        private void QuanHuyen_Load()
        {
            if (comboBox_TenTinhThanh.Items.Count > 0)
            {
                comboBox_TenQuanHuyen.DataSource = DungChung.qhBO.getList(comboBox_TenTinhThanh.SelectedValue.ToString());
                comboBox_TenQuanHuyen.DisplayMember = "TenQuanHuyen";
                comboBox_TenQuanHuyen.ValueMember = "MaQuanHuyen";
            }
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ResetForm();
            //Nếu độ dài lớn hơn 10 thì chỉ lấy 10 ký tự đầu tiên
            if (txtMaPhuongXa.Text.Length > 10) txtMaPhuongXa.Text = txtMaPhuongXa.Text.Substring(0, 10);

            if (txtMaPhuongXa.Text.Equals(""))
            {
                lbl_MaPhuongXa.Text = "Vui lòng nhập mã phường xã!";
                return;
            }
            else if (txtTenPhuongXa.Text.Equals(""))
            {
                lbl_TenPhuongXa.Text = "Vui lòng nhập tên phường xã!";
                return;
            }
            else if (comboBox_TenTinhThanh.SelectedValue.ToString().Equals(""))
            {
                lbl_TenTinhThanh.Text = "Vui lòng chọn tên tỉnh thành!";
                return;
            }
            else if (comboBox_TenQuanHuyen.SelectedValue.ToString().Equals(""))
            {
                lbl_TenQuanHuyen.Text = "Vui lòng chọn tên quận huyện!";
                return;
            }
            else
            {
                foreach(var x in DungChung.Db.PhuongXas.Where(p => p.MaPhuongXa == MaPhuongXa))
                {
                    x.TenPhuongXa = txtTenPhuongXa.Text;
                    x.QuanHuyen = DungChung.Db.QuanHuyens.Single(p => p.MaQuanHuyen == comboBox_TenQuanHuyen.SelectedValue.ToString());
                }
                DungChung.Db.SubmitChanges();
                DungChung.frmMain.QLPhuongXa_Load();
                MessageBox.Show("Đã cập nhật phường xã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ResetForm()
        {
            lbl_MaPhuongXa.Text = "";
            lbl_TenPhuongXa.Text = "";
            lbl_TenTinhThanh.Text = "";
            lbl_TenQuanHuyen.Text = "";
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
