using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BUS
{
    public class c_dmvean
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them( double idve, string ghichu)
        {
            dmvean v = new dmvean();
            
            v.idve = idve;
            v.ghichu = ghichu;
            dbData.dmveans.InsertOnSubmit(v);
            dbData.SubmitChanges();
        }

        public void sua( double idve, string ghichu)
        {
            var v = (from a in dbData.dmveans select a).Single(t => t.idve == idve);
            v.ghichu = ghichu;
            dbData.SubmitChanges();
        }

        public void xoa(double idve)
        {
            var v = (from a in dbData.dmveans select a).Single(t => t.idve == idve);
            dbData.dmveans.DeleteOnSubmit(v);
            dbData.SubmitChanges();
        }
    }
}
