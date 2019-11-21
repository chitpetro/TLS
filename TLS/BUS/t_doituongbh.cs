using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_doituongbh
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string ten, string nhom, string loai, string diachi, string msthue, string dienthoai, string email, string fax, string dd, string taikhoan, string nganhang, string manv, string madv)
        {
            doituongbh dt = new doituongbh();
            dt.id = id;
            dt.ten = ten;
            dt.nhom = nhom;
            dt.loai = loai;
            dt.diachi = diachi;
            dt.msthue = msthue;
            dt.dienthoai = dienthoai;
            dt.email = email;
            dt.fax = fax;
            dt.dd = dd;
            dt.taikhoan = taikhoan;
            dt.nganhang = nganhang;
            dt.manv = manv;
            dt.madv = madv;
            db.doituongbhs.InsertOnSubmit(dt);
            db.SubmitChanges();

        }
        public void sua(string id, string ten, string nhom, string loai, string diachi, string msthue, string dienthoai, string email, string fax, string dd, string taikhoan, string nganhang, string manv, string madv)
        {
            doituongbh dt = (from d in db.doituongbhs select d).Single(t => t.id == id);
            dt.ten = ten;
            dt.nhom = nhom;
            dt.loai = loai;
            dt.diachi = diachi;
            dt.msthue = msthue;
            dt.dienthoai = dienthoai;
            dt.email = email;
            dt.fax = fax;
            dt.dd = dd;
            dt.taikhoan = taikhoan;
            dt.nganhang = nganhang;
            dt.manv = manv;
            dt.madv = madv;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            doituongbh dt = (from d in db.doituongbhs select d).Single(t => t.id == id);
            db.doituongbhs.DeleteOnSubmit(dt);
            db.SubmitChanges();
        }
    }
}