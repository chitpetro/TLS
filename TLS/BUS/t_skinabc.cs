using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Linq;

namespace BUS
{
    public class t_skinabc
    {

        KetNoiDBDataContext db = new KetNoiDBDataContext();
        skin sk = new skin();
        public void sua(string skin)
        {
            skin sk = (from a in db.skins select a).Single(t => t.trangthai == true);
            sk.tenskin = skin;
            db.SubmitChanges();
        }
    }
}
