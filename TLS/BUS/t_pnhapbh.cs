using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_pnhapbh
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moipn(string id, DateTime ngaynhap, string iddv, string idnv, string ghichu, int so, string loainhap)
        {
            pnhap pn = new pnhap();
            pn.id = id;
            pn.ngaynhap = ngaynhap;

            pn.iddv = iddv;
            pn.idnv = idnv;
            pn.ghichu = ghichu;
            pn.so = so;
            pn.loainhap = loainhap;
            db.pnhaps.InsertOnSubmit(pn);
            db.SubmitChanges();
        }
        public void moict(string idsp, string diengiai, double sl, string idpnhap, string id)
        {
            pnhapct ct = new pnhapct();

            ct.idsanpham = idsp;
            ct.diengiai = diengiai;
            ct.soluong = sl;
            ct.idpnhap = idpnhap;
            ct.id = id;
            db.pnhapcts.InsertOnSubmit(ct);
            db.SubmitChanges();
        }


        public void suapn(string id, DateTime ngaynhap, string ghichu, int so, string loainhap)
        {
            pnhap pn = (from c in db.pnhaps select c).Single(x => x.id == id);

            pn.ngaynhap = ngaynhap;

            pn.ghichu = ghichu;
            pn.so = so;
            pn.loainhap = loainhap;
            db.SubmitChanges();
        }
       

        public void xoaPN(string id)
        {
            pnhap pn = (from c in db.pnhaps select c).Single(x => x.id == id);
            db.pnhaps.DeleteOnSubmit(pn);
            db.SubmitChanges();
        }
        public void xoact(string id)
        {
            pnhapct ct = (from c in db.pnhapcts select c).Single(x => x.id == id);
            db.pnhapcts.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }
    }
}
