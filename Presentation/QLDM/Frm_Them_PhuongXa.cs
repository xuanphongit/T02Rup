using System;
using System.Windows.Forms;
using T02_Source_Code.Model;
using T02_Source_Code.Bo;

namespace T02_Source_Code.Presentation
{
    public partial class Frm_Them_PhuongXa : Form
    {
        public Frm_Them_PhuongXa()
        {
            InitializeComponent();
        }

        private void Frm_Them_PhuongXa_Load(object sender, EventArgs e)
        {
            ResetForm();
            TinhThanh_Load();
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


        private void btnThem_Click(object sender, EventArgs e)
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
            else if (DungChung.pxBO.Exist(txtMaPhuongXa.Text))
            {
                lbl_MaPhuongXa.Text = "Mã phường xã đã tồn tại!";
                return;
            }
            else
            {
                PhuongXa px = new PhuongXa();
                px.MaPhuongXa = txtMaPhuongXa.Text;
                px.TenPhuongXa = txtTenPhuongXa.Text;
                px.MaQuanHuyen = comboBox_TenQuanHuyen.SelectedValue.ToString();
                DungChung.Db.PhuongXas.InsertOnSubmit(px);
                DungChung.Db.SubmitChanges();
                DungChung.frmMain.QLPhuongXa_Load();
                MessageBox.Show("Đã thêm phường xã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
