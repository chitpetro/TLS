using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_sodubandau
    {

        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string matk, string iddt, string iddv, double psno_nt, double psco_nt, string tiente, double tygia, double psno, double psco , double soluong, string idsp)
        {
            sodubandau dt = new sodubandau();
            dt.id = id;
            dt.iddv = iddv;
            dt.matk = matk;
            dt.iddt = iddt;
            dt.psno_nt = psno_nt;
            dt.psco_nt = psco_nt;
            dt.tiente = tiente;
            dt.tygia = tygia;
            dt.psno = psno;
            dt.psco = psco;
            dt.soluong = soluong;
            dt.idsp = idsp;
            db.sodubandaus.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string id,  string iddt, string iddv, double psno_nt, double psco_nt, string tiente, double tygia, double psno, double psco, double soluong, string idsp)
        {
            sodubandau dt = (from d in db.sodubandaus select d).Single(t => t.id == id);
            dt.iddv = iddv;
       
            dt.iddt = iddt;
            dt.psno_nt = psno_nt;
            dt.psco_nt = psco_nt;
            dt.tiente = tiente;
            dt.tygia = tygia;
            dt.psno = psno;
            dt.psco = psco;
            dt.soluong = soluong;
            dt.idsp = idsp;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            var dt = (from d in db.sodubandaus where d.id == id select d);
            db.sodubandaus.DeleteAllOnSubmit(dt);

            db.SubmitChanges();
        }
       
    }
}
