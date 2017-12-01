using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T02_Source_Code.Model;

namespace T02_Source_Code.Bo
{
    public class PhuongXaBO
    {
        public PhuongXa get(string id)
        {
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaPhuongXa.Equals(id)
                    select s;
            if (q.Count() != 0)
            {
                return q.First();
            }
            return null;
        }
        public List<PhuongXa> getList(string maHuyen)
        {
            return (from s in DungChung.Db.PhuongXas where s.MaQuanHuyen.Equals(maHuyen) select s).ToList();
        }
        public void Delete(string id)
        {
            var t = DungChung.Db.PhuongXas.Single(p => p.MaPhuongXa.Equals(id));
            DungChung.Db.PhuongXas.DeleteOnSubmit(t);
            DungChung.Db.SubmitChanges();
        }

        public bool Exist(string id)
        {
            var q = from s in DungChung.Db.PhuongXas
                    where s.MaPhuongXa.Equals(id)
                    select s;
            return (q.Count() > 0);
        }
    }
}
