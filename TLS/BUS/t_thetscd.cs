using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class t_thetscd
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void moiphieu(string id, string iddv, string kyhieu, string tents,
            string loaits, DateTime ngaysd, DateTime ngayngungkh, DateTime ngaythanhly,
            string tinhtrang, string iddt, string dvt, double sl, string ppkh,
            double sothangkh, string link, DateTime ngaymua, string diengiai,
            string tknguyengia, string tkkhauhao, string tkchiphi, string idcv, string idmuccp, int so)
        {
            tscodinh pt = new tscodinh();
            pt.id = id;
            pt.iddv = iddv;
            pt.kyhieu = kyhieu;
            pt.tents = tents;
            pt.loaits = loaits;
            pt.ngaysd = ngaysd;
            pt.ngayngungkh = ngayngungkh;
            pt.ngaythanhly = ngaythanhly;
            pt.tinhtrang = tinhtrang;
            pt.iddt = iddt;
            pt.dvt = dvt;
            pt.sl = sl;
            pt.ppkh = ppkh;
            pt.sothangkh = sothangkh;
            pt.link = link;
            pt.ngaymua = ngaymua;
            pt.diengiai = diengiai;
            pt.tknguyengia = tknguyengia;
            pt.tkkhauhao = tkkhauhao;
            pt.so = so;
            pt.tkchiphi = tkchiphi;
            pt.idcv = idcv;
            pt.idmuccp = idmuccp;

            db.tscodinhs.InsertOnSubmit(pt);
            db.tscodinhs.Context.SubmitChanges();

        }
        public void moict(string idts, string lydotg, string nguonvon, DateTime ngayhieuluc, DateTime ngayketthuc, double nguyengia, double khbandau, double gtclbd, double muckhthang, double khnamnay, double khluyke, double gtconlai, string id)
        {
            tscodinhct ct = new tscodinhct();
            ct.idts = idts;
            ct.id = id;
            ct.lydotg = lydotg;
            ct.nguonvon = nguonvon;
            ct.ngayhieuluc = ngayhieuluc;
            ct.ngaykethuc = ngayketthuc;
            ct.nguyengia = nguyengia;
            ct.khbandau = khbandau;
            ct.gtclbd = gtclbd;
            ct.muckhthang = muckhthang;
            ct.khnamnay = khnamnay;
            ct.khluyke = khluyke;
            ct.gtconlai = gtconlai;

            db.tscodinhcts.InsertOnSubmit(ct);
            db.tscodinhcts.Context.SubmitChanges();

        }

        public void suaphieu(string id, string iddv, string kyhieu, string tents,
            string loaits, DateTime ngaysd, DateTime ngayngungkh, DateTime ngaythanhly,
            string tinhtrang, string iddt, string dvt, double sl, string ppkh,
            double sothangkh, string link, DateTime ngaymua, string diengiai,
            string tknguyengia, string tkkhauhao, string tkchiphi, string idcv, string idmuccp)
        {
            tscodinh pt = (from c in db.tscodinhs select c).Single(x => x.id == id);


            pt.iddv = iddv;
            pt.kyhieu = kyhieu;
            pt.tents = tents;
            pt.loaits = loaits;
            pt.ngaysd = ngaysd;
            pt.ngayngungkh = ngayngungkh;
            pt.ngaythanhly = ngaythanhly;
            pt.tinhtrang = tinhtrang;
            pt.iddt = iddt;
            pt.dvt = dvt;
            pt.sl = sl;
            pt.ppkh = ppkh;
            pt.sothangkh = sothangkh;
            pt.link = link;
            pt.ngaymua = ngaymua;
            pt.diengiai = diengiai;
            pt.tknguyengia = tknguyengia;
            pt.tkkhauhao = tkkhauhao;
            pt.tkchiphi = tkchiphi;
            pt.idcv = idcv;
            pt.idmuccp = idmuccp;
            db.tscodinhs.Context.SubmitChanges();

        }

        public void xoapphieu(string id)
        {
            tscodinh pt = (from c in db.tscodinhs select c).Single(x => x.id == id);
            db.tscodinhs.DeleteOnSubmit(pt);
            db.tscodinhs.Context.SubmitChanges();
        }
        public void xoact(string id)
        {

            tscodinhct ct = (from c in db.tscodinhcts select c).Single(x => x.id == id);
            db.tscodinhcts.DeleteOnSubmit(ct);
            db.tscodinhcts.Context.SubmitChanges();
        }

        public void khauhao(string id, double? luykekh, double? giatricl)
        {

            tscodinhct ct = (from c in db.tscodinhcts select c).Single(x => x.idts == id);
            ct.khluyke = luykekh;
            ct.gtconlai = giatricl;

            db.tscodinhcts.Context.SubmitChanges();
        }


    }
}
