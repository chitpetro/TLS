using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_tientebh
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string ten, double tygia, string ghichu)
        {
            tientebh tt = new tientebh();
            tt.tiente = ten;
            tt.tygia = tygia;
            tt.ghichu = ghichu;

            db.tientebhs.InsertOnSubmit(tt);
            db.SubmitChanges();
        }
        public void sua(string ten, double tygia, string ghichu)
        {
            tientebh tt = (from t in db.tientebhs select t).Single(a => a.tiente == ten);
            tt.tygia = tygia;
            tt.ghichu = ghichu;
            db.SubmitChanges();
        }

        public void xoa(string ten)
        {
            tientebh tt = (from t in db.tientebhs select t).Single(a => a.tiente == ten);
            db.tientebhs.DeleteOnSubmit(tt);
            db.SubmitChanges();
        }
    }
}
