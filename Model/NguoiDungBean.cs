using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T02_Source_Code.Model
{
    class NguoiDungBean
    {
        public NguoiDungBean(string id, string idTinh, string idHuyen, string idXa, string idChucVu, string name, string pass)
        {
            this.id = id;
            this.idTinh = idTinh;
            this.idHuyen = idHuyen;
            this.idXa = idXa;
            this.idChucVu = idChucVu;
            this.name = name;
            this.pass = pass;
        }

        public string id { get; set; }
        public string idTinh { get; set; }
        public string idHuyen { get; set; }
        public string idXa { get; set; }
        public string idChucVu { get; set; }
        public string name { get; set; }
        public string pass { get; set; }
    }
}
