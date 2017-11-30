using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T02_Source_Code.Model;

namespace T02_Source_Code.Bo
{
    class ChucVuBO
    {
        public List<ChucVu> getList()
        {
            return DungChung.Db.ChucVus.ToList();
        }
    }
}
