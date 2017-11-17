using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rup
{
    public class TinhThanh
    {
        private string _maTinhThanh;

        private string _tenTinhThanh;

        public string TenTinhThanh
        {
            get { return _tenTinhThanh; }
            set { _tenTinhThanh = value; }
        }

        public string MaTinhThanh
        {
            get { return _maTinhThanh; }
            set { _maTinhThanh = value; }
        }
    }
}
