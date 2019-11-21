using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_cttk
    {

        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string iddv, string loaichungtu, string machungtu, DateTime ngaychungtu, DateTime ngaylchungtu, int sochungtu, string dt_no, string dt_co, string diengiai,
           string tk_no, string tk_co, double ps, string tiente, double tygia, double ps_nt, string idsp, string id2, string idnv,
           string loai, string idcv, string idmuccp, string tendt, string ghichu,double soluong)
        {
            ct_tk dt = new ct_tk();
            dt.id = id;
            dt.iddv = iddv;
            dt.loaichungtu = loaichungtu;
            dt.ngaychungtu = ngaychungtu;
            dt.ngaylchungtu = ngaylchungtu;
            dt.machungtu = machungtu;
            dt.sochungtu = sochungtu;
            dt.dt_no = dt_no;
            dt.dt_co = dt_co;
            dt.diengiai = diengiai;
            dt.tk_no = tk_no;
            dt.tk_co = tk_co;
            dt.PS = ps;
            dt.tiente = tiente;
            dt.tygia = tygia;
            dt.PS_nt = ps_nt;
            dt.idsp = idsp;
            dt.id2 = id2;
            dt.idnv = idnv;
            dt.loai = loai;
            dt.idcv = idcv;
            dt.idmuccp = idmuccp;
            dt.tendt = tendt;
            dt.ghichu = ghichu;
            dt.soluong = soluong;
            db.ct_tks.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string id, string kc)
        {
            ct_tk dt = (from d in db.ct_tks select d).Single(t => t.id == id);
            dt.kc = kc;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            var dt = (from d in db.ct_tks where d.machungtu == id select d);
            db.ct_tks.DeleteAllOnSubmit(dt);

            db.SubmitChanges();
        }
        public void xoa2(string id)
        {
            try
            {
                var dt = (from d in db.ct_tks where d.id == id select d);
                db.ct_tks.DeleteAllOnSubmit(dt);

                db.SubmitChanges();
            }
            catch
            {

            }
        }
        public void xoa3(string id,string loai)
        {
            try
            {
                var dt = (from d in db.ct_tks where d.id == id && d.loaichungtu != loai select d);
                db.ct_tks.DeleteAllOnSubmit(dt);

                db.SubmitChanges();
            }
            catch
            {

            }
        }

        public void chaygiavon(string id2, double ps, double ps_nt)
        {
            ct_tk dt = (from c in db.ct_tks select c).Single(x => x.id2 == id2);

            dt.PS = ps;
            dt.PS_nt = ps_nt;

            db.SubmitChanges();

        }
    }
}
