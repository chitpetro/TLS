using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_dmloaixuatve
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string loaixuat_VN, string loaixuat_Lao, bool Pthu)
        {
            dmloaixuatve lx = new dmloaixuatve();
            lx.id = id;
            lx.loaixuat_VN = loaixuat_VN;
            lx.loaixuat_Lao = loaixuat_Lao;
            lx.PThu = Pthu;
            dbData.dmloaixuatves.InsertOnSubmit(lx);
            dbData.SubmitChanges();
        }

        public void sua(string id, string loaixuat_VN, string loaixuat_Lao, bool Pthu)
        {
            var lx = (from a in dbData.dmloaixuatves select a).Single(t => t.id == id);
            lx.loaixuat_VN = loaixuat_VN;
            lx.loaixuat_Lao = loaixuat_Lao;
            lx.PThu = Pthu;

            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            var lx = (from a in dbData.dmloaixuatves select a).Single(t => t.id == id);
            dbData.dmloaixuatves.DeleteOnSubmit(lx);
            dbData.SubmitChanges();
        }
    }
}
