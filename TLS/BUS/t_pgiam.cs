using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_pgiam
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moipg(string id, DateTime ngaynhap, string iddt, string iddv, string idnv, string ghichu, int so, string loainhap, string tiente, double tygia, bool giamgiatri, string idnvmhang, string link)
        {
            pgiam pn = new pgiam();
            pn.id = id;
            pn.ngaynhap = ngaynhap;
            pn.iddt = iddt;
            pn.iddv = iddv;
            pn.idnv = idnv;
            pn.ghichu = ghichu;
            pn.so = so;
            pn.link = link;

            pn.giamgiatri = giamgiatri;
            pn.idnvmhang = idnvmhang;
            pn.loainhap = loainhap;
            pn.tiente = tiente;
            pn.tygia = tygia;
            db.pgiams.InsertOnSubmit(pn);
            db.SubmitChanges();
        }
        public void moict(string idsp, string diengiai, double sl, double dongia, string idcv, string loaithue, double thue, double chietkhau, double thanhtien, string idpgiamgia, string id, string tiente, double tygia, double nguyente, double chiphi, double giavon)
        {
            pgiamct ct = new pgiamct();

            ct.idsanpham = idsp;
            ct.diengiai = diengiai;
            ct.soluong = sl;
            ct.dongia = dongia;
            ct.idcv = idcv;
            ct.loaithue = loaithue;
            ct.thue = thue;
            ct.chietkhau = chietkhau;
            ct.thanhtien = thanhtien;
            ct.idpgiamgia = idpgiamgia;
            ct.id = id;
            ct.tiente = tiente;
            ct.tygia = tygia;
            ct.nguyente = nguyente;
            ct.chiphi = chiphi;
            ct.giavon = giavon;
            db.pgiamcts.InsertOnSubmit(ct);
            db.SubmitChanges();
        }


        public void suapg(string id, DateTime ngaynhap, string iddt, string iddv, string idnv, string ghichu, int so, string loainhap, string tiente, double tygia, bool giamgiatri, string idnvmhang, string link)
        {
            pgiam pn = (from c in db.pgiams select c).Single(x => x.id == id);

            pn.ngaynhap = ngaynhap;
            pn.iddt = iddt;
            pn.iddv = iddv;
            pn.idnv = idnv;
            pn.ghichu = ghichu;
            pn.so = so;
            pn.link = link;
            pn.giamgiatri = giamgiatri;
            pn.idnvmhang = idnvmhang;
            pn.loainhap = loainhap;
            pn.tiente = tiente;
            pn.tygia = tygia;
            db.SubmitChanges();
        }
        //public void suact(string id, double chiphi, double giavon)
        //{
        //    pnhapct ct = (from c in db.pnhapcts select c).Single(x => x.id == id);
        //    ct.chiphi = chiphi;
        //    ct.giavon = giavon;

        //    db.SubmitChanges();
        //}

        public void xoapg(string id)
        {
            pgiam pn = (from c in db.pgiams select c).Single(x => x.id == id);
            db.pgiams.DeleteOnSubmit(pn);
            db.SubmitChanges();
        }
        public void xoact(string id)
        {
            pgiamct ct = (from c in db.pgiamcts select c).Single(x => x.id == id);
            db.pgiamcts.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }
    }
}
