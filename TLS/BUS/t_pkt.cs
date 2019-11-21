using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_pkt
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moiphieu(string id, DateTime ngaylap, string iddv, string idnv, string ghichu, int so, string tiente, double tygia)
        {
            pketoan pt = new pketoan();
            pt.id = id;
            pt.ngaylap = ngaylap;
            pt.iddv = iddv;
            pt.idnv = idnv;
            pt.ghichu = ghichu;
            pt.so = so;
            pt.tiente = tiente;
            pt.tygia = tygia;
            db.pketoans.InsertOnSubmit(pt);
            db.pketoans.Context.SubmitChanges();

        }
        public void moict(string idpkt, string id, string diengiai, string tk_no, string tk_co, string dt_no, string dt_co, double thanhtien, double nguyente, string idcv, string idmuccp)
        {
            pketoanct ct = new pketoanct();
            ct.idpkt = idpkt;
            ct.id = id;
            ct.diengiai = diengiai;
            ct.tk_no = tk_no;
            ct.tk_co = tk_co;
            ct.dt_no = dt_no;
            ct.dt_co = dt_co;
            ct.nguyente = nguyente;
            ct.thanhtien = thanhtien;
            ct.idmuccp = idmuccp;
            ct.idcv = idcv;
            db.pketoancts.InsertOnSubmit(ct);
            db.pketoancts.Context.SubmitChanges();

        }

        public void suaphieu(string id, DateTime ngaylap, string iddv, string idnv, string ghichu, int so, string tiente, double tygia)
        {
            pketoan pt = (from c in db.pketoans select c).Single(x => x.id == id);


            pt.ngaylap = ngaylap;
            pt.iddv = iddv;
            pt.idnv = idnv;
            pt.ghichu = ghichu;
            pt.so = so;
            pt.tiente = tiente;
            pt.tygia = tygia;

            db.pketoans.Context.SubmitChanges();

        }

        public void xoapphieu(string id)
        {
            pketoan pt = (from c in db.pketoans select c).Single(x => x.id == id);
            db.pketoans.DeleteOnSubmit(pt);
            db.pketoans.Context.SubmitChanges();
        }
        public void xoact(string id)
        {

            pketoanct ct = (from c in db.pketoancts select c).Single(x => x.id == id);
            db.pketoancts.DeleteOnSubmit(ct);
            db.pketoancts.Context.SubmitChanges();
        }
    }
}
