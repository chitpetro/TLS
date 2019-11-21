using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_pthu
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moipthu(string id, DateTime ngaythu, string iddt, string iddv, string idnv, string ghichu, int so, string link, string tiente, double tygia, string loaithu, string tk,string dv)
        {
            pthu pt = new pthu();
            pt.id = id;
            pt.ngaythu = ngaythu;
            pt.iddt = iddt;
            pt.iddv = iddv;
            pt.tiente = tiente;
            pt.tygia = tygia;
            pt.idnv = idnv;
            pt.ghichu = ghichu;
            pt.so = so;
            pt.loaithu = loaithu;
            pt.link = link;
            pt.tk = tk;
            pt.dv = dv;
            db.pthus.InsertOnSubmit(pt);
            db.SubmitChanges();

        }
        public void moict(string diengiai, string idcv, string idmuccp, double thanhtien, string idthu, string id, string tiente, double tygia, double nguyente, string tk)
        {
            pthuct ct = new pthuct();



            ct.diengiai = diengiai;

            ct.idcv = idcv;
            ct.idmuccp = idmuccp;

            ct.thanhtien = thanhtien;
            ct.idthu = idthu;
            ct.id = id;
            ct.tiente = tiente;
            ct.tygia = tygia;
            ct.nguyente = nguyente;
            ct.tkco = tk;
            
            db.pthucts.InsertOnSubmit(ct);
            db.SubmitChanges();

        }

        public void suapt(string id, DateTime ngaythu, string iddt, string ghichu, int so, string link, string tiente, double tygia, string loaithu, string tk)
        {
            pthu pn = (from c in db.pthus select c).Single(x => x.id == id);

            pn.ngaythu = ngaythu;
            pn.iddt = iddt;
            pn.ghichu = ghichu;
            pn.so = so;
            pn.tiente = tiente;
            pn.tygia = tygia;
            pn.link = link;
            pn.tk = tk;
            pn.loaithu = loaithu;
            db.SubmitChanges();
        }

        public void xoapthu(string id)
        {
            pthu pt = (from c in db.pthus select c).Single(x => x.id == id);
            db.pthus.DeleteOnSubmit(pt);
            db.SubmitChanges();
        }
        public void xoact(string id)
        {
            pthuct ct = (from c in db.pthucts select c).Single(x => x.id == id);
            db.pthucts.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }
    }
}
