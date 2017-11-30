using System;
using System.Linq;
namespace T02_Source_Code.Model
{
    public class DungChung
    {
        public static string HoTen,MaChucVu,MaNguoiDung,MaTinh,MaHuyen,MaXa;
        public static DataClasses1DataContext Db;

        public DungChung()
        {
            Db = new DataClasses1DataContext();
        }
        //update dung hcung
       
    }
}
