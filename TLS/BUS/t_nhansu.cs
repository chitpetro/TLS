using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Linq;

namespace BUS
{
    public class t_nhansu
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moins(string id, string hovaten, DateTime ngaysinh, string quequan, string quoctich, string cmnd, DateTime ngaycapcmnd, string passport, DateTime ngayhethanpp, string idphong, string chucvu, byte[] hinhanh, DateTime ngayvaolam, string sohdld, string sodienthoai, string ghichu, string gioitinh, string email, string tinhtrang, DateTime ngaythuviec)
        {
            nhansu ns = new nhansu();
            ns.id = id;
            ns.hovaten = hovaten;
            ns.ngaysinh = ngaysinh;
            ns.quequan = quequan;
            ns.quoctich = quoctich;
            ns.cmnd = cmnd;
            ns.ngaycapcmnd = ngaycapcmnd;
            ns.passport = passport;
            ns.ngayhethanpp = ngayhethanpp;
            ns.idphong = idphong;
            ns.chucvu = chucvu;
            ns.hinhanh = hinhanh;
            ns.sodienthoai = sodienthoai;
            ns.ghichu = ghichu;
            ns.gioitinh = gioitinh;
            ns.email = email;
            ns.tinhtrang = tinhtrang;
            ns.ngaythuviec = ngaythuviec;
            ns.ngayvaolam = ngayvaolam;
            ns.sohdld = sohdld;
            db.nhansus.InsertOnSubmit(ns);
            db.SubmitChanges();

        }

        public void moifile(string id, string idns, string name, Binary data,  string type, string size)
        {
            filenhansu ns = new filenhansu();
            ns.id = id;
            ns.idns = idns;
            ns.name = name;
            ns.data = data;
            ns.type = type;
            ns.size = size;
            db.filenhansus.InsertOnSubmit(ns);
            db.SubmitChanges();
        }

        public void suans(string id, string hovaten, DateTime ngaysinh, string quequan, string quoctich, string cmnd, DateTime ngaycapcmnd, string passport, DateTime ngayhethanpp, string idphong, string chucvu, byte[] hinhanh, DateTime ngayvaolam, string sohdld, string sodienthoai, string ghichu, string gioitinh, string email, string tinhtrang, DateTime ngaythuviec)
        {
            nhansu ns = (from c in db.nhansus select c).Single(x => x.id == id);

            ns.hovaten = hovaten;
            ns.ngaysinh = ngaysinh;
            ns.quequan = quequan;
            ns.quoctich = quoctich;
            ns.cmnd = cmnd;
            ns.ngaycapcmnd = ngaycapcmnd;
            ns.passport = passport;
            ns.ngayhethanpp = ngayhethanpp;
            ns.idphong = idphong;
            ns.chucvu = chucvu;
            ns.hinhanh = hinhanh;
            ns.sodienthoai = sodienthoai;
            ns.ghichu = ghichu;
            ns.gioitinh = gioitinh;
            ns.email = email;
            ns.tinhtrang = tinhtrang;
            ns.ngaythuviec = ngaythuviec;
            ns.ngayvaolam = ngayvaolam;
            ns.sohdld = sohdld;
            db.SubmitChanges();
        }

        public void xoans(string id)
        {
            nhansu ns = (from c in db.nhansus select c).Single(x => x.id == id);
            db.nhansus.DeleteOnSubmit(ns);
            db.SubmitChanges();
        }
    }
}
