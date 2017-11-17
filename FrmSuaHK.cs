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
    public partial class FrmSuaHK : Form
    {
        public FrmSuaHK()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng nhập các thông tin bắt buộc (*)");
        }
    }
}
