using System;
using System.Linq;
using T02_Source_Code.Bo;
using T02_Source_Code.Presentation;

namespace T02_Source_Code.Model
{
    public class DungChung
    {
        public static string HoTen,MaChucVu,MaNguoiDung,MaTinh,MaHuyen,MaXa;
        public static DataClasses1DataContext Db;
        public static TinhThanhBO ttBO = new TinhThanhBO();
        public static QuanHuyenBO qhBO = new QuanHuyenBO();
        public static PhuongXaBO pxBO = new PhuongXaBO();

        public static FrmMain frmMain = new FrmMain();


        public DungChung()
        {
            Db = new DataClasses1DataContext();
        }
    }
}
