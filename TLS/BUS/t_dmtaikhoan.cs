using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Linq;

namespace BUS
{
    public class t_dmtaikhoan
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string matk, string tentk, string matk_jp, string tentk_jp, string tentk_khac, string idsp, string loaitk, int captk, bool tk_th, string tkme,
            string tiente, string kieusodu, bool doituong, bool chiphi, bool congviec, bool soluong, bool vat, bool thanhtoancongno, bool nganhang, bool tkcuahang,
            bool hanghoa, bool sanpham, bool loaikhoan, string sotk_nh, string nganhang_nh, string ma_nh, bool active)
        {
            dmtk dt = new dmtk();
            dt.matk = matk;
            dt.tentk = tentk;
            dt.matk_jp = matk_jp;
            dt.tentk_jp = tentk_khac;
            dt.tentk_khac = tentk_khac;
            dt.idsp = idsp;
            dt.loaitk = loaitk;
            dt.captk = captk;
            dt.tk_th = tk_th;
            dt.tkme = tkme;
            dt.tiente = tiente;
            dt.kieusodu = kieusodu;
            dt.doituong = doituong;
            dt.chiphi = chiphi;
            dt.congviec = congviec;
            dt.soluong = soluong;
            dt.vat = vat;
            dt.thanhtoancongno = thanhtoancongno;
            dt.nganhang = nganhang;
            dt.tkcuahang = tkcuahang;
            dt.hanghoa = hanghoa;
            dt.sanpham = sanpham;
            dt.loaikhoan = loaikhoan;
            dt.sotk_nh = sotk_nh;
            dt.nganhang_nh = nganhang_nh;
            dt.ma_nh = ma_nh;
            dt.active = active;
            db.dmtks.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string matk, string tentk, string matk_jp, string tentk_jp, string tentk_khac, string idsp, string loaitk, int captk, bool tk_th, string tkme,
            string tiente, string kieusodu, bool doituong, bool chiphi, bool congviec, bool soluong, bool vat, bool thanhtoancongno, bool nganhang, bool tkcuahang,
            bool hanghoa, bool sanpham, bool loaikhoan, string sotk_nh, string nganhang_nh, string ma_nh, bool active)
        {
            dmtk dt = (from d in db.dmtks select d).Single(t => t.matk == matk);
            dt.matk = matk;
            dt.tentk = tentk;
            dt.matk_jp = matk_jp;
            dt.tentk_jp = tentk_khac;
            dt.tentk_khac = tentk_khac;
            dt.idsp = idsp;
            dt.loaitk = loaitk;
            dt.captk = captk;
            dt.tk_th = tk_th;
            dt.tkme = tkme;
            dt.tiente = tiente;
            dt.kieusodu = kieusodu;
            dt.doituong = doituong;
            dt.chiphi = chiphi;
            dt.congviec = congviec;
            dt.soluong = soluong;
            dt.vat = vat;
            dt.thanhtoancongno = thanhtoancongno;
            dt.nganhang = nganhang;
            dt.tkcuahang = tkcuahang;
            dt.hanghoa = hanghoa;
            dt.sanpham = sanpham;
            dt.loaikhoan = loaikhoan;
            dt.sotk_nh = sotk_nh;
            dt.nganhang_nh = nganhang_nh;
            dt.ma_nh = ma_nh;
            dt.active = active;
            db.SubmitChanges();
        }
        public void xoa(string matk)
        {
            dmtk dt = (from d in db.dmtks select d).Single(t => t.matk == matk);
            db.dmtks.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}
