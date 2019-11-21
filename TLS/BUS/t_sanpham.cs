using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Linq;

namespace BUS
{
    public class t_sanpham
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moi(string id, string ten, string dvt, string loai, bool qlkho)
        {
            sanpham sp = new sanpham();
            sp.id = id;
            sp.tensp = ten;

            sp.dvt = dvt;
            sp.loai = loai;
            sp.qlkho = qlkho;
            db.sanphams.InsertOnSubmit(sp);
            db.SubmitChanges();
        }
        public void sua(string id, string ten, string dvt, string loai, bool qlkho)
        {
            sanpham sp = (from tb in db.sanphams select tb).Single(t => t.id == id);

            sp.tensp = ten;

            sp.dvt = dvt;
            sp.loai = loai;
            sp.qlkho = qlkho;
            db.SubmitChanges();
        }
        public void xoa(string id)
        {
            sanpham sp = (from tb in db.sanphams select tb).Single(t => t.id == id);
            db.sanphams.DeleteOnSubmit(sp);
            db.SubmitChanges();
        }
    }
}
