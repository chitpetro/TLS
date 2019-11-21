using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_pxuatvean
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, DateTime ngayxuat, int so, string loaixuat, string diengiai, string iddt,
            string idnv, string iddv)
        {
            pxuatvean px = new pxuatvean();
            px.key = key;
            px.id = id;
            px.ngayxuat = ngayxuat;
            px.so = so;
            px.loaixuat = loaixuat;
            px.diengiai = diengiai;
            px.iddt = iddt;
            px.idnv = idnv;
            px.iddv = iddv;
            dbData.pxuatveans.InsertOnSubmit(px);
            dbData.SubmitChanges();
        }

        public void sua(string key, DateTime ngayxuat, string loaixuat, string diengiai, string iddt)
        {
            var px = (from a in dbData.pxuatveans select a).Single(t => t.key == key);

            px.ngayxuat = ngayxuat;
            px.loaixuat = loaixuat;
            px.diengiai = diengiai;
            px.iddt = iddt;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var px = (from a in dbData.pxuatveans select a).Single(t => t.key == key);
            dbData.pxuatveans.DeleteOnSubmit(px);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var px = (from a in dbData.pxuatveancts select a).Single(t => t.key == key);
            dbData.pxuatveancts.DeleteOnSubmit(px);
            dbData.SubmitChanges();
        }
    }
}
