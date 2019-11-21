using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BUS
{
    public class t_history
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_tudong td = new t_tudong();

        public void add(string ma, string hoatdong)
        {
            td = new t_tudong();
            int so2;
            string check2 = "HS" + Biencucbo.donvi;
            var lst = (from b in new DAL.KetNoiDBDataContext().tudongs where b.maphieu == check2 select b);
            var lst2 = (from a in new DAL.KetNoiDBDataContext().tudongs select a).FirstOrDefault(t => t.maphieu == check2);
            if (lst.Count() == 0)
            {
                so2 = 1;

                td.themtudong(check2, 2,"HS", "History");
            }
            else
            {
                so2 = int.Parse(lst2.so.ToString());
                td.suatudong(check2, so2 + 1);
            }
            history hs = new history();
            hs.donvi = Biencucbo.donvi;
            hs.ma = ma;
            hs.hoatdong = hoatdong;
            hs.nguoi = Biencucbo.idnv.Trim() + "-" + Biencucbo.ten;
            hs.may = "Computer: " + Biencucbo.hostname + "/ IP: " + Biencucbo.IPaddress;
            hs.thoigian = DateTime.Now;

            hs.id = "HS" + Biencucbo.donvi.Trim() + "_" + so2.ToString();

            db.histories.InsertOnSubmit(hs);

            db.SubmitChanges();
        }
    }
}
