using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
   public class t_pchi
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moiphieu(string id, DateTime ngaychi, string iddt, string iddv, string idnv, string ghichu, int so, string link, string loaichi, string tiente, double tygia, string tk, string dv)
        {
            pchi pt = new pchi();
            pt.id = id;
            pt.ngaychi = ngaychi;
            pt.iddt = iddt;
            pt.iddv = iddv;
            pt.idnv = idnv;
            pt.loaichi = loaichi;
            pt.ghichu = ghichu;
            pt.so = so;
            pt.tiente = tiente;
            pt.tygia = tygia;
            pt.link = link;
            pt.tk = tk;
            pt.dv = dv;
            
            db.pchis.InsertOnSubmit(pt);
            db.pchis.Context.SubmitChanges();

        }
        public void moict(string diengiai, string idcv, string idmuccp, double thanhtien, string idchi, string id, string tiente, double tygia, double nguyente, string tk)
        {
            pchict ct = new pchict();
            ct.diengiai = diengiai;
            ct.idcv = idcv;
            ct.idmuccp = idmuccp;
            ct.sotien = thanhtien;
            ct.idchi = idchi;
            ct.id = id;
            ct.tiente = tiente;
            ct.tygia = tygia;
            ct.tkno = tk;
            ct.nguyente = nguyente;
            db.pchicts.InsertOnSubmit(ct);
            db.pchicts.Context.SubmitChanges();

        }

        public void suaphieu(string id, DateTime ngaychi, string iddt, string ghichu, int so, string link, string loaichi, string tiente, double tygia, string tk)
        {
            pchi pn = (from c in db.pchis select c).Single(x => x.id == id);

            pn.ngaychi = ngaychi;
            pn.iddt = iddt;
            pn.ghichu = ghichu;
            pn.so = so;
            pn.tiente = tiente;
            pn.tygia = tygia;
            pn.loaichi = loaichi;
            pn.tk = tk;
            pn.link = link;
            db.pchis.Context.SubmitChanges();

        }

        public void xoapphieu(string id)
        {
            pchi pt = (from c in db.pchis select c).Single(x => x.id == id);
            db.pchis.DeleteOnSubmit(pt);
            db.pchis.Context.SubmitChanges();
        }
        public void xoact(string id)
        {

            pchict ct = (from c in db.pchicts select c).Single(x => x.id == id);
            db.pchicts.DeleteOnSubmit(ct);
            db.pchicts.Context.SubmitChanges();
        }
    }
}
