using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T02_Source_Code.Model;

namespace T02_Source_Code.Bo
{
    class TinhThanhBO
    {
        public TinhThanh get(string id)
        {
            var q = from s in DungChung.Db.TinhThanhs
                    where s.MaTinhThanh.Equals(id)
                    select s;
            if (q.Count() != 0)
            {
                return q.First();
            }
            return null;
        }
        public List<TinhThanh> getList()
        {
            return DungChung.Db.TinhThanhs.ToList();
        }
    }
}
