using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
  public  class c_pnhapvean
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

      public void them(string key, string id, DateTime ngaynhap, int so, string loainhap, string diengiai, string iddt,
          string idnv, string iddv)
      {
          pnhapvean pn = new pnhapvean();
          pn.key = key;
          pn.id = id;
          pn.ngaynhap = ngaynhap;
          pn.so = so;
          pn.loainhap = loainhap;
          pn.diengiai = diengiai;
          pn.iddt = iddt;
          pn.idnv = idnv;
          pn.iddv = iddv;
            dbData.pnhapveans.InsertOnSubmit(pn);
            dbData.SubmitChanges();
      }
        public void sua(string key,  DateTime ngaynhap,  string loainhap, string diengiai, string iddt)
        {
            var pn = (from a in dbData.pnhapveans select a).Single(t => t.key == key);
          pn.ngaynhap = ngaynhap;
         pn.loainhap = loainhap;
            pn.diengiai = diengiai;
            pn.iddt = iddt;
         dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var pn = (from a in dbData.pnhapveans select a).Single(t => t.key == key);
            dbData.pnhapveans.DeleteOnSubmit(pn);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var pn = (from a in dbData.pnhapveancts select a).Single(t => t.key == key);
            dbData.pnhapveancts.DeleteOnSubmit(pn);
            dbData.SubmitChanges();
        }
    }
}
