using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BUS;

namespace BUS
{
    class ta_skin
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        skin sk = new skin();
        public void sua(string skin)
        {
            skin sk = (from d in db.skins select d).Single(t => t.tenskin == skin);
            sk.tenskin = skin;
            db.SubmitChanges();
        }
    }
}
