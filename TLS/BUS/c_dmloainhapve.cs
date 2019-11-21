using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_dmloainhapve
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string loainhap_VN, string loainhap_Lao, bool Pchi)
        {
            dmloainhapve ln = new dmloainhapve();
            ln.id = id;
            ln.loainhap_VN = loainhap_VN;
            ln.loainhap_Lao = loainhap_Lao;
            ln.PChi = Pchi;
            dbData.dmloainhapves.InsertOnSubmit(ln);
            dbData.SubmitChanges();
        }

        public void sua(string id, string loainhap_VN, string loainhap_Lao, bool Pchi)
        {
            var ln = (from a in dbData.dmloainhapves select a).Single(t => t.id == id);
            ln.loainhap_VN = loainhap_VN;
            ln.loainhap_Lao = loainhap_Lao;
            ln.PChi = Pchi;
            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            var ln = (from a in dbData.dmloainhapves select a).Single(t => t.id == id);
            dbData.dmloainhapves.DeleteOnSubmit(ln);
            dbData.SubmitChanges();
        }
    }
}
