using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Linq;

namespace BUS
{
    public class t_tonsp
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string iddv, string idsp, double soluong, double dongia, int so, string idnv,double dongia2, DateTime ngay)
        {
            tonsp sp = new tonsp();
            sp.id = id;
            sp.iddv = iddv;
            sp.soluong = soluong;
            sp.dongia = dongia;
            sp.so = so;
            sp.ngay = ngay;
            sp.idsp = idsp;
            sp.idnv = idnv;
            sp.dongia2 = dongia2;
            db.tonsps.InsertOnSubmit(sp);
            db.tonsps.Context.SubmitChanges();
        }
       
       
        public void xoa(string idsp, string iddv, string idnv)
        {
            var lst = (from tb in db.tonsps where tb.iddv == iddv && tb.idnv == idnv && tb.idsp == idsp select tb);
            if (lst.Count() !=0)
            {
                db.tonsps.DeleteAllOnSubmit(lst);
                db.tonsps.Context.SubmitChanges();
            }
            
        }
        #region ton2
        public void moi2(string id, string iddv, string idsp, double soluong, double dongia, int so, string idnv, double dongia2, DateTime ngay)
        {
            tonsp2 sp = new tonsp2();
            sp.id = id;
            sp.iddv = iddv;
            sp.soluong = soluong;
            sp.dongia = dongia;
            sp.so = so;
            sp.idsp = idsp;
            sp.ngay = ngay;
            sp.idnv = idnv;
            sp.dongia2 = dongia2;
            db.tonsp2s.InsertOnSubmit(sp);
            db.tonsp2s.Context.SubmitChanges();
        }


        public void xoa2(string idsp, string iddv, string idnv)
        {
            var lst = (from tb in db.tonsp2s where tb.iddv == iddv && tb.idnv == idnv && tb.idsp == idsp select tb);
            if (lst.Count() !=0)
            {
                db.tonsp2s.DeleteAllOnSubmit(lst);
                db.tonsp2s.Context.SubmitChanges();
            }

        }
        #endregion
    }
}
