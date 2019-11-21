using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_hopdong
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moihd(string id, DateTime ngaylap, DateTime ngaybd, DateTime ngaykt, string iddt, string idnv, string iddv, string pt, string ghichu, int so, double hantt, double dmcongno,string sohd, string tiente, double tygia,double dientich, int thoihan, string idlo, string datcoc1, string datcoc2)
        {
            hopdong hd = new hopdong();
            hd.id = id;
            hd.ngaylap = ngaylap;
            hd.ngaybatdau = ngaybd;
            hd.ngayketthuc = ngaykt;
            hd.iddt = iddt;
            hd.idnv = idnv;
            hd.iddv = iddv;
            hd.dientich = dientich;
            hd.pttt = pt;
            hd.idlo = idlo;
            hd.ghichu = ghichu;
            hd.hantt = hantt;
            hd.dmcongno = dmcongno;
            hd.sohd = sohd;
            hd.so = so;
            hd.tiente = tiente;
            hd.tygia = tygia;
            hd.thoihantt = thoihan;
            hd.datcoc1 = datcoc1;
            hd.datcoc2 = datcoc2;
            db.hopdongs.InsertOnSubmit(hd);
            db.SubmitChanges();

        }

        public void moihdct(string idhopdong, string diengiai, double soluong,double dongia, double thanhtien, string id, string loaithue, double thue, double ck, double nguyente, double datcoc)
        {
            hopdongct hdct = new hopdongct();
            hdct.idhopdong = idhopdong;
            
            hdct.diengiai = diengiai;
            hdct.soluong = soluong;
            
            hdct.thanhtien = thanhtien;
            hdct.dongia = dongia;
            hdct.id = id;
            hdct.loaithue = loaithue;
            hdct.thue = thue;
            hdct.nguyente = nguyente;
            hdct.chietkhau = ck;
            hdct.datcoc = datcoc;

            db.hopdongcts.InsertOnSubmit(hdct);
            db.SubmitChanges();
        }

        public void suahd(string id, DateTime ngaylap, DateTime ngaybd, DateTime ngaykt, string iddt, string idnv, string iddv, string pt, string ghichu, int so, double hantt, double dmcongno,string sohd, string tiente, double tygia, double dientich, int thoihan, string idlo, string datcoc1, string datcoc2)
        {
            hopdong hd = (from c in db.hopdongs select c).Single(x => x.id == id);
            
            hd.ngaylap = ngaylap;
            hd.ngaybatdau = ngaybd;
            hd.ngayketthuc = ngaykt;
            hd.iddt = iddt;
            hd.idnv = idnv;
            hd.iddv = iddv; 
            hd.pttt = pt;
            hd.idlo = idlo;
            hd.ghichu = ghichu; 
            hd.so = so;
            hd.dientich = dientich;
            hd.sohd = sohd;
            hd.hantt = hantt;
            hd.dmcongno = dmcongno;
            hd.tiente = tiente;
            hd.tygia = tygia;
            hd.datcoc1 = datcoc1;
            hd.datcoc2 = datcoc2;
            hd.thoihantt = thoihan;
            db.SubmitChanges();
        }
        public void suahdct(string idhopdong, string diengiai, double soluong, string vitri, double giathue, double thanhtien, double giadv, double datcoc, string id, string loaithue, double thue, double ck,double nguyente)
        {
            hopdongct hdct = (from c in db.hopdongcts select c).Single(x => x.id == id);

            hdct.idhopdong = idhopdong;
            
            hdct.diengiai = diengiai;
            hdct.soluong = soluong;
            hdct.dongia = giathue;
            hdct.thanhtien = thanhtien;
            hdct.giadv = giadv;
            hdct.datcoc = datcoc;
            
            hdct.loaithue = loaithue;
            hdct.thue = thue;
            hdct.chietkhau = ck;
            hdct.nguyente = nguyente;
            db.SubmitChanges();
        }

        public void xoahd(string id)
        {
            hopdong hd = (from c in db.hopdongs select c).Single(x => x.id == id);
            db.hopdongs.DeleteOnSubmit(hd);
            db.SubmitChanges();
        }
        public void xoact(string id)
        {
            hopdongct ct = (from c in db.hopdongcts select c).Single(x => x.id == id);
            db.hopdongcts.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }
    }
}
