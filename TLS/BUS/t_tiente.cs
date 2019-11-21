using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_tiente
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string ten, double tygia, string ghichu)
        {
            tiente tt = new tiente();
            tt.tiente1 = ten;
            tt.tygia = tygia;
            tt.ghichu = ghichu;

            db.tientes.InsertOnSubmit(tt);
            db.SubmitChanges();
        }
        public void sua(string ten, double tygia, string ghichu)
        {
            tiente tt = (from t in db.tientes select t).Single(a => a.tiente1 == ten);
            tt.tygia = tygia;
            tt.ghichu = ghichu;
            db.SubmitChanges();
        }

        public void xoa(string ten)
        {
            tiente tt = (from t in db.tientes select t).Single(a => a.tiente1 == ten);
            db.tientes.DeleteOnSubmit(tt);
            db.SubmitChanges();
        }
    }
}
