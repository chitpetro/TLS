using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class t_chucnang
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public void moi(string ma, string ten, string cha)
        {
            var cn = db.ChucNangs.FirstOrDefault(c => c.MaChucNang == ma);
            if (cn == null)
            {
                cn = new ChucNang();
                cn.MaChucNang = ma;
                cn.ChucNangCha = cha;
                cn.TenChucNang = ten;
                db.ChucNangs.InsertOnSubmit(cn);
                db.SubmitChanges();
            }
            else
            { 
                cn.TenChucNang = ten;
                cn.ChucNangCha = cha;
                db.SubmitChanges();
            } 
        } 
    }
}
