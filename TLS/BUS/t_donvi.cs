using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_donvi
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string ten, string nhom, string dvql)
        {
            donvi dv = new donvi();
            dv.id = id;
            dv.tendonvi = ten;
            dv.nhomdonvi = nhom;
            dv.iddv = dvql;

            db.donvis.InsertOnSubmit(dv);
            db.SubmitChanges();
        }
        public void sua(string id, string ten, string nhom, string dvql)
        {
            donvi dv = (from d in db.donvis select d).Single(t => t.id == id);
            dv.tendonvi = ten;
            dv.nhomdonvi = nhom;
            dv.iddv = dvql;
            db.SubmitChanges();
        }

        public void xoa(string id)
        {
            donvi dv = (from d in db.donvis select d).Single(t => t.id == id);
            db.donvis.DeleteOnSubmit(dv);
            db.SubmitChanges();
        }
    }
}
