using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_dmlo
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, int tang, string ghichu)
        {
            dmlo tt = new dmlo();
            tt.id = id;
            tt.tang = tang;
            tt.ghichu = ghichu;

            db.dmlos.InsertOnSubmit(tt);
            db.SubmitChanges();
        }
        public void sua(string id, int tang, string ghichu)
        {
            dmlo tt = (from t in db.dmlos select t).Single(a => a.id == id);
            
            tt.id = id;
            tt.tang = tang;
            tt.ghichu = ghichu;
            db.SubmitChanges();
        }

        public void xoa(string id   )
        {
            dmlo tt = (from t in db.dmlos select t).Single(a => a.id == id);
            db.dmlos.DeleteOnSubmit(tt);
            db.SubmitChanges();
        }
    }
}
