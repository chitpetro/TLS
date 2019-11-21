 using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class t_pmua
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moipm(string id, DateTime ngaynhap, string iddt, string iddv, string idnv, string ghichu, int so, string loainhap, string tiente, double tygia)
        {
            pmuahang pn = new pmuahang();
            pn.id = id;
            pn.ngaynhap = ngaynhap;
            pn.iddt = iddt;
            pn.iddv = iddv;
            pn.idnv = idnv;
            pn.ghichu = ghichu;
            pn.so = so;
            pn.loainhap = loainhap;
            pn.tiente = tiente;
            pn.tygia = tygia;
            db.pmuahangs.InsertOnSubmit(pn);
            db.SubmitChanges();
        }
        public void moict(string idsp, string diengiai, double sl, double dongia, string idcv, string loaithue, double thue, double chietkhau, double thanhtien, string idpnhap, string id, string tiente, double tygia, double nguyente)
        {
            pmuahangct ct = new pmuahangct();

            ct.idsanpham = idsp;
            ct.diengiai = diengiai;
            ct.soluong = sl;
            ct.dongia = dongia;
            ct.idcv = idcv;
            ct.loaithue = loaithue;
            ct.thue = thue;
            ct.chietkhau = chietkhau;
            ct.thanhtien = thanhtien;
            ct.idpmuahang = idpnhap;
            ct.id = id;
            ct.tiente = tiente;
            ct.tygia = tygia;
            ct.nguyente = nguyente;
            db.pmuahangcts.InsertOnSubmit(ct);
            db.SubmitChanges();
        }


        public void suapm(string id, DateTime ngaynhap, string iddt, string ghichu, int so, string loainhap, string tiente, double tygia)
        {
            pmuahang pn = (from c in db.pmuahangs select c).Single(x => x.id == id);

            pn.ngaynhap = ngaynhap;
            pn.iddt = iddt;
            pn.ghichu = ghichu;
            pn.so = so;
            pn.tiente = tiente;
            pn.tygia = tygia;
            pn.loainhap = loainhap;
            db.SubmitChanges();
        }
        public void suact(string idsp, string diengiai, double sl, double dongia, string idcv, string loaithue, double thue, double chietkhau, double thanhtien, string idpnhap, string id, string tiente, double tygia, double nguyente)
        {
            pmuahangct ct = (from c in db.pmuahangcts select c).Single(x => x.id == id);

            ct.idsanpham = idsp;
            ct.diengiai = diengiai;
            ct.soluong = sl;
            ct.dongia = dongia;
            ct.idcv = idcv;
            ct.loaithue = loaithue;
            ct.thue = thue;
            ct.chietkhau = chietkhau;
            ct.thanhtien = thanhtien;
            ct.tiente = tiente;
            ct.tygia = tygia;
            ct.nguyente = nguyente;
            //ct.idpnhap = idpnhap;
            //ct.id = id;

            db.SubmitChanges();
        }

        public void xoaPN(string id)
        {
            pmuahang pn = (from c in db.pmuahangs select c).Single(x => x.id == id);
            db.pmuahangs.DeleteOnSubmit(pn);
            db.SubmitChanges();
        }
        public void xoact(string id)
        {
            pmuahangct ct = (from c in db.pmuahangcts select c).Single(x => x.id == id);
            db.pmuahangcts.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }
    }
}
