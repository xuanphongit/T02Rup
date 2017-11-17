using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rup
{
    public partial class FrmThemNK : Form
    {
        public FrmThemNK()
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
          //  MessageBox.Show("Số CMND không hợp lệ, vui lòng nhập lại");
           // MessageBox.Show("Ngày chuyển đến không hợp lệ, vui lòng nhập lại, ví dụ 05/15/2016");
            MessageBox.Show("Vui lòng nhập các thông tin bắt buộc (*)");
            MessageBox.Show("Thêm thành công");
        }
    }
}
