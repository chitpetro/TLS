using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_hoadon
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        // Mới
        #region Hóa Đơn
        public void moihd(string id, DateTime ngayhd, string iddt, string idnv, string iddv, string ghichu, int so, string loaixuat, string tiente, double tygia, string vat)
        {
            hoadon hd = new hoadon();
            hd.id = id;
            hd.ngayhd = ngayhd;
            hd.iddt = iddt;
            hd.idnv = idnv;
            hd.iddv = iddv;
            hd.iddt = iddt;
            hd.ghichu = ghichu;
            hd.tiente = tiente;
            hd.tygia = tygia;
            hd.so = so;
            hd.soVAT = vat;

            hd.loaixuat = loaixuat;

            db.hoadons.InsertOnSubmit(hd);
            db.SubmitChanges();
        }
        public void moihd2(string id, DateTime ngayhd, string iddt, string idnv, string iddv, string ghichu, int so, string loaixuat, string tiente, double tygia, string link, string dv, string vat)
        {
            hoadon hd = new hoadon();
            hd.id = id;
            hd.ngayhd = ngayhd;
            hd.iddt = iddt;
            hd.idnv = idnv;
            hd.iddv = iddv;
            hd.iddt = iddt;
            hd.ghichu = ghichu;
            hd.tiente = tiente;
            hd.tygia = tygia;
            hd.so = so;
            hd.loaixuat = loaixuat;
            hd.link = link;
            hd.dv = dv;
            hd.soVAT = vat;
            db.hoadons.InsertOnSubmit(hd);
            db.SubmitChanges();
        }

        public void moihdct(string idhhoadon, string idsanpham, string diengiai, double soluong, double dongia, string idcv, string loaithue, double thue, double chietkhau, double thanhtien, string id, string tiente, double tygia, double nguyente, double thuesuat)
        {
            hoadonct hdct = new hoadonct();
            hdct.idhoadon = idhhoadon;
            hdct.idsanpham = idsanpham;
            hdct.diengiai = diengiai;
            hdct.soluong = soluong;
            hdct.dongia = dongia;
            hdct.idcv = idcv;
            hdct.loaithue = loaithue;
            hdct.thue = thue;
            hdct.chietkhau = chietkhau;
            hdct.thanhtien = thanhtien;
            hdct.id = id;
            hdct.tiente = tiente;
            hdct.tygia = tygia;
            hdct.nguyente = nguyente;
            hdct.thuesuat = thuesuat;
            db.hoadoncts.InsertOnSubmit(hdct);
            db.SubmitChanges();
        }

        public void suahd(string id, DateTime ngaylap, string iddt, string ghichu, int so, string loaixuat, string tiente, double tygia, string vat)
        {
            hoadon hd = (from c in db.hoadons select c).Single(x => x.id == id);

            hd.ngayhd = ngaylap;
            hd.iddt = iddt;
            hd.ghichu = ghichu;
            hd.so = so;
            hd.tiente = tiente;
            hd.tygia = tygia;
            hd.loaixuat = loaixuat;
            hd.soVAT = vat;
            db.SubmitChanges();
        }
        public void suahd2(string id, DateTime ngaylap, string iddt, string ghichu, int so, string tiente, double tygia, string vat)
        {
            hoadon hd = (from c in db.hoadons select c).Single(x => x.id == id);

            hd.ngayhd = ngaylap;
            hd.iddt = iddt;
            hd.ghichu = ghichu;
            hd.so = so;
            hd.tiente = tiente;
            hd.tygia = tygia;
         
            hd.soVAT = vat;
            db.SubmitChanges();
        }
        //public void suahdct(string idhoadon, string idsp, string diengiai, double sl, double dongia, string idcv, string loaithue, double thue, double chietkhau, double thanhtien, string id, string tiente, double tygia, double nguyente)
        //{
        //    hoadonct ct = (from c in db.hoadoncts select c).Single(x => x.id == id);

        //    ct.idhoadon = idhoadon;
        //    ct.idsanpham = idsp;
        //    ct.diengiai = diengiai;
        //    ct.soluong = sl;
        //    ct.dongia = dongia;
        //    ct.idcv = idcv;
        //    ct.loaithue = loaithue;
        //    ct.thue = thue;
        //    ct.chietkhau = chietkhau;
        //    ct.thanhtien = thanhtien;
        //    ct.tiente = tiente;
        //    ct.tygia = tygia;
        //    ct.nguyente = nguyente;

        //    db.SubmitChanges();
        //}

        public void xoahd(string id)
        {
            hoadon hd = (from c in db.hoadons select c).Single(x => x.id == id);
            db.hoadons.DeleteOnSubmit(hd);
            db.SubmitChanges();
        }
        public void xoact(string id)
        {
            hoadonct ct = (from c in db.hoadoncts select c).Single(x => x.id == id);
            db.hoadoncts.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }
        #endregion

        #region Bán Hàng

        public void moibh(string id, DateTime ngayban, string iddt, string idnv, string iddv, string ghichu, int so, string tiente, double tygia)
        {
            banhang hd = new banhang();
            hd.id = id;
            hd.ngayban = ngayban;
            hd.iddt = iddt;
            hd.idnv = idnv;
            hd.iddv = iddv;
            hd.dv = Biencucbo.dvTen;
            hd.iddt = iddt;
            hd.ghichu = ghichu;
            hd.tiente = tiente;
            hd.tygia = tygia;
            hd.so = so;


            db.banhangs.InsertOnSubmit(hd);
            db.SubmitChanges();
        }
        //public void moihd2(string id, DateTime ngayhd, string iddt, string idnv, string iddv, string ghichu, int so, string loaixuat, string tiente, double tygia, string link, string dv, string vat)
        //{
        //    hoadon hd = new hoadon();
        //    hd.id = id;
        //    hd.ngayhd = ngayhd;
        //    hd.iddt = iddt;
        //    hd.idnv = idnv;
        //    hd.iddv = iddv;
        //    hd.iddt = iddt;
        //    hd.ghichu = ghichu;
        //    hd.tiente = tiente;
        //    hd.tygia = tygia;
        //    hd.so = so;
        //    hd.loaixuat = loaixuat;
        //    hd.link = link;
        //    hd.dv = dv;
        //    hd.soVAT = vat;
        //    db.hoadons.InsertOnSubmit(hd);
        //    db.SubmitChanges();
        //}

        public void moibhct(string idbanhang, string idsanpham, string diengiai, double soluong, double dongia,  string loaithue, double thue, double chietkhau, double thanhtien, string id, double nguyente)
        {
            banhangct hdct = new banhangct();
            hdct.idbanhang = idbanhang;
            hdct.idsanpham = idsanpham;
            hdct.diengiai = diengiai;
            hdct.soluong = soluong;
            hdct.dongia = dongia;
          
            hdct.loaithue = loaithue;
            hdct.thue = thue;
            hdct.chietkhau = chietkhau;
            hdct.thanhtien = thanhtien;
            hdct.id = id;

            hdct.nguyente = nguyente;

            db.banhangcts.InsertOnSubmit(hdct);
            db.SubmitChanges();
        }

        public void suabh(string id, DateTime ngayban, string iddt, string ghichu, int so, string tiente, double tygia)
        {
            banhang hd = (from c in db.banhangs select c).Single(x => x.id == id);

            hd.ngayban = ngayban;
            hd.iddt = iddt;
            hd.ghichu = ghichu;
            hd.so = so;
            hd.tiente = tiente;
            hd.tygia = tygia;

            db.SubmitChanges();
        }
        public void suabhct(string idbanhang, string idsp, string diengiai, double sl, double dongia, string idcv, string loaithue, double thue, double chietkhau, double thanhtien, string id, double nguyente)
        {
            banhangct ct = (from c in db.banhangcts select c).Single(x => x.id == id);

            ct.idbanhang = idbanhang;
            ct.idsanpham = idsp;
            ct.diengiai = diengiai;
            ct.soluong = sl;
            ct.dongia = dongia;
            ct.idcv = idcv;
            ct.loaithue = loaithue;
            ct.thue = thue;
            ct.chietkhau = chietkhau;
            ct.thanhtien = thanhtien;
            ct.nguyente = nguyente;

            db.SubmitChanges();
        }

        public void xoabh(string id)
        {
            banhang hd = (from c in db.banhangs select c).Single(x => x.id == id);
            db.banhangs.DeleteOnSubmit(hd);
            db.SubmitChanges();
        }
        public void xoabhct(string id)
        {
            banhangct ct = (from c in db.banhangcts select c).Single(x => x.id == id);
            db.banhangcts.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }

        #endregion

        #region Xuất Kho

        public void moixk(string id, DateTime ngaylap, string iddt, string idnv, string iddv, string ghichu, int so,string loai, string tiente, double tygia, string banhang)
        {
            pxuat hd = new pxuat();
            hd.id = id;
            hd.ngaylap = ngaylap;
            hd.iddt = iddt;
            hd.idnv = idnv;
            hd.iddv = iddv;
            hd.iddt = iddt;
            hd.ghichu = ghichu;
            hd.tiente = tiente;
            hd.tygia = tygia;
            hd.loaixuat = loai;
            hd.link = banhang;
            hd.so = so;


            db.pxuats.InsertOnSubmit(hd);
            db.SubmitChanges();
        }
        //public void moihd2(string id, DateTime ngayhd, string iddt, string idnv, string iddv, string ghichu, int so, string loaixuat, string tiente, double tygia, string link, string dv, string vat)
        //{
        //    hoadon hd = new hoadon();
        //    hd.id = id;
        //    hd.ngayhd = ngayhd;
        //    hd.iddt = iddt;
        //    hd.idnv = idnv;
        //    hd.iddv = iddv;
        //    hd.iddt = iddt;
        //    hd.ghichu = ghichu;
        //    hd.tiente = tiente;
        //    hd.tygia = tygia;
        //    hd.so = so;
        //    hd.loaixuat = loaixuat;
        //    hd.link = link;
        //    hd.dv = dv;
        //    hd.soVAT = vat;
        //    db.hoadons.InsertOnSubmit(hd);
        //    db.SubmitChanges();
        //}

        public void moixkct(string idpxuat, string idsanpham, string diengiai, double soluong, double dongia, string loaithue, double thue, double chietkhau, double thanhtien, string id, double nguyente, string idcv)
        {
            pxuatct hdct = new pxuatct();
            hdct.idpxuat = idpxuat;
            hdct.idsanpham = idsanpham;
            hdct.diengiai = diengiai;
            hdct.soluong = soluong;
            hdct.dongia = dongia;
            hdct.idcv = idcv;
            hdct.loaithue = loaithue;
            hdct.thue = thue;
            hdct.chietkhau = chietkhau;
            hdct.thanhtien = thanhtien;
            hdct.id = id;

            hdct.nguyente = nguyente;

            db.pxuatcts.InsertOnSubmit(hdct);
            db.SubmitChanges();
        }

        public void suaxk(string id, DateTime ngaylap, string iddt, string ghichu, int so,string loai, string tiente, double tygia,string banhang)
        {
            pxuat hd = (from c in db.pxuats select c).Single(x => x.id == id);

            hd.ngaylap = ngaylap;
            hd.iddt = iddt;
            hd.ghichu = ghichu;
            hd.so = so;
            hd.tiente = tiente;
            hd.tygia = tygia;
            hd.loaixuat = loai;
            hd.link = banhang;
            db.SubmitChanges();
        }
        public void suaxkct(double dongia, double thanhtien, string id, double nguyente)
        {
            pxuatct ct = (from c in db.pxuatcts select c).Single(x => x.id == id);

           
            ct.dongia = dongia;
            
            ct.thanhtien = thanhtien;
            ct.nguyente = nguyente;

            db.SubmitChanges();
        }

        public void xoaxk(string id)
        {
            pxuat hd = (from c in db.pxuats select c).Single(x => x.id == id);
            db.pxuats.DeleteOnSubmit(hd);
            db.SubmitChanges();
        }
        public void xoaxkct(string id)
        {
            pxuatct ct = (from c in db.pxuatcts select c).Single(x => x.id == id);
            db.pxuatcts.DeleteOnSubmit(ct);
            db.SubmitChanges();
        }

        #endregion
    }


}
