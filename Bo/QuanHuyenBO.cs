using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T02_Source_Code.Model;

namespace T02_Source_Code.Bo
{
    public class QuanHuyenBO
    {
        public QuanHuyen get(string id)
        {
            var q = from s in DungChung.Db.QuanHuyens
                    where s.MaQuanHuyen.Equals(id)
                    select s;
            if (q.Count()!=0)
            {
                return q.First();
            }
            return null;
        }
        public List<QuanHuyen> getList(string maTinh)
        {
            return (from s in DungChung.Db.QuanHuyens where s.MaTinhThanh.Equals(maTinh) select s).ToList();
        }
        public void Delete(string id)
        {
            var t = DungChung.Db.QuanHuyens.Single(p => p.MaQuanHuyen.Equals(id));
            DungChung.Db.QuanHuyens.DeleteOnSubmit(t);
            DungChung.Db.SubmitChanges();
        }

        public bool Exist(string id)
        {
            var q = from s in DungChung.Db.QuanHuyens
                    where s.MaQuanHuyen.Equals(id)
                    select s;
            return (q.Count() > 0);
        }
    }
}
