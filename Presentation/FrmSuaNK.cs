using System;
using System.Windows.Forms;

namespace T02_Source_Code
{
    public partial class FrmSuaNK : Form
    {
        public FrmSuaNK()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            // MessageBox.Show("Không nhập các ký tự đặc biệt ở mục mã số hộ khẩu");
          // MessageBox.Show("Mã số hộ khẩu không có, vui lòng nhập lại");
            // MessageBox.Show("Không nhập các ký tự đặc biệt ở mục họ và tên");
            // MessageBox.Show("Không nhập các ký tự đặc biệt ở mục tên khác");
            //MessageBox.Show("Ngày sinh không hợp lệ, vui lòng nhập lại, ví dụ 05/15/2016");
             // MessageBox.Show("Số CMND không hợp lệ, vui lòng nhập lại");
            MessageBox.Show("Ngày chuyển đến không hợp lệ, vui lòng nhập lại, ví dụ 05/15/2016");
           // MessageBox.Show("Vui lòng nhập các thông tin bắt buộc (*)");
           // MessageBox.Show("Chỉnh sửa thành công");
        }

        private void FrmSuaNK_Load(object sender, EventArgs e)
        {

        }
    }
}
