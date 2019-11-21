using BUS;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using ControlLocalizer;
namespace GUI
{
    public partial class f_tinhkhauhao : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_cttk tk = new t_cttk();
        t_thetscd kh = new t_thetscd();
        public f_tinhkhauhao()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
        }
        #region code cu
        #endregion
        private void f_PN_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Tính Khấu Hao").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            tungay.ReadOnly = true;
            denngay.ReadOnly = true;
            Biencucbo.getID = 0;
        }
        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
            string time = thoigian.Text;
            int chieudai = time.Length;
            string chu = time.Substring(0, 5);
            string so = "";
            DateTime ngay;
            if (thoigian.Text == "Tùy ý" || thoigian.Text == "ແລ້ວແຕ່")
            {
                tungay.ReadOnly = false;
                denngay.ReadOnly = false;
            }
            else
            {
                if (chu == "Tháng") //vietnam
                {
                    if (chieudai == 7)
                    {
                        so = time.Substring(6, 1);
                    }
                    else if (chieudai == 8)
                    {
                        so = time.Substring(6, 2);
                    }
                    ngay = new DateTime(DateTime.Now.Year, int.Parse(so), 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, int.Parse(so), DateTime.DaysInMonth(DateTime.Now.Year, int.Parse(so)));
                    denngay.DateTime = ngay;
                }
                if (chu == "ເດືອນ") //lao
                {
                    string time1 = thoigian.Text;
                    int chieudai2 = time1.Length;
                    if (chieudai2 == 7)
                    {
                        so = time1.Substring(6, 1);
                    }
                    else if (chieudai2 == 8)
                    {
                        so = time1.Substring(6, 2);
                    }
                    ngay = new DateTime(DateTime.Now.Year, int.Parse(so), 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, int.Parse(so), DateTime.DaysInMonth(DateTime.Now.Year, int.Parse(so)));
                    denngay.DateTime = ngay;
                }
                if (thoigian.Text == "Quý 1" || thoigian.Text == "ງວດ 1")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 4, DateTime.DaysInMonth(DateTime.Now.Year, 4));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "Quý 2" || thoigian.Text == "ງວດ 2")
                {
                    ngay = new DateTime(DateTime.Now.Year, 5, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 8, DateTime.DaysInMonth(DateTime.Now.Year, 8));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "Quý 3" || thoigian.Text == "ງວດ 3")
                {
                    ngay = new DateTime(DateTime.Now.Year, 9, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "6 Tháng Đầu" || thoigian.Text == "6 ເດືອນຕົ້ນປີ")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "6 Tháng Cuối" || thoigian.Text == "6 ເດືອນທ້າຍປີ")
                {
                    ngay = new DateTime(DateTime.Now.Year, 7, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "Cả Năm" || thoigian.Text == "ໝົດປີ")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.DateTime = ngay;
                }
                tungay.ReadOnly = true;
                denngay.ReadOnly = true;
            }
        }
        private void timkiem_Click(object sender, EventArgs e)
        {
            double? luyke = 0;
            double? conlai = 0;
            try
            {
                var lst = (from a in db.r_tscds
                           where a.gtconlai != 0 && a.tinhtrang == "Đang Sử Dụng"
                           select new tinhkhauhao()
                           {

                               id = a.id,
                               sothangkh = a.sothangkh,
                               nguyengia = a.nguyengia,
                               iddt = a.iddt,
                               tkchiphi = a.tkchiphi,
                               tkkhauhao = a.tkkhauhao,
                               ngayhieuluc = a.ngayhieuluc,
                               iddv = a.iddv,
                               muckhthang = a.muckhthang,
                               idcv = a.idcv,
                               idmuccp = a.idmuccp,
                               khluyke = a.khluyke,
                               gtconlai = a.gtconlai,
                               idts = a.idts,
                           }).ToList();

                var row = lst.Count();
                for (int i = 0; i < row; i++)
                {
                    var row1 = lst.ElementAt(i) as tinhkhauhao;
                    if (row1 == null) continue;
                    luyke = row1.khluyke;
                    conlai = row1.gtconlai;
                    var lst2 = from a in db.ct_tks
                               where a.machungtu == row1.id && a.loaichungtu == "KH"
                               select a;
                    //TimeSpan ts = denngay.DateTime - DateTime.Parse(row1.ngayhieuluc.ToString());
                    ////ts.
                    if (row1.ngayhieuluc.Value.AddMonths(1) <= denngay.DateTime)
                    {
                        if (lst2.Count() > 0)
                        {
                            var lst3 = from a in lst2 select a;
                            int so = int.Parse(lst2.Max(t => t.sochungtu).ToString());
                            int c = 0;
                            do
                            {
                                if (row1.ngayhieuluc.Value.AddMonths(so) <= denngay.DateTime)
                                {
                                    if (so > row1.sothangkh)
                                    {
                                        c = 1;
                                    }
                                    else
                                    {
                                        luyke = luyke + row1.muckhthang;
                                        conlai = conlai - row1.muckhthang;
                                        if (conlai < 0)
                                        {
                                            conlai = 0;
                                            luyke = row1.nguyengia;
                                        }
                                        so = so + 1;
                                        tk.moi(row1.id + "KH" + so.ToString(), row1.iddv, "KH", row1.id, row1.ngayhieuluc.Value.AddMonths(so), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), so, row1.iddt, row1.iddt, "Khấu Hao: " + row1.idts, row1.tkchiphi, row1.tkkhauhao, double.Parse(row1.muckhthang.ToString()), "KIP", 1, double.Parse(row1.muckhthang.ToString()), "", "", Biencucbo.idnv, "", row1.idcv, row1.idmuccp, "", "", 0.0);
                                        kh.khauhao(row1.id, luyke, conlai);

                                        c = 0;
                                    }
                                }
                                else
                                {
                                    c = 1;
                                }
                            } while (c == 0);
                        }
                        else
                        {
                            int so = 1;
                            int c = 0;
                            do
                            {
                                if (row1.ngayhieuluc.Value.AddMonths(so) <= denngay.DateTime)
                                {
                                    if (so > row1.sothangkh)
                                    {
                                        c = 1;
                                    }
                                    else
                                    {
                                        luyke = luyke + row1.muckhthang;
                                        conlai = conlai - row1.muckhthang;
                                        if (conlai < 0)
                                            conlai = 0;
                                        tk.moi(row1.id + "KH" + so.ToString(), row1.iddv, "KH", row1.id, row1.ngayhieuluc.Value.AddMonths(so), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), so, row1.iddt, row1.iddt, "Khấu Hao: " + row1.idts, row1.tkchiphi, row1.tkkhauhao, double.Parse(row1.muckhthang.ToString()), "KIP", 1, double.Parse(row1.muckhthang.ToString()), "", "", Biencucbo.idnv, "", row1.idcv, row1.idmuccp, "", "", 0.0);
                                        kh.khauhao(row1.id, luyke, conlai);
                                        so = so + 1;
                                        c = 0;
                                    }
                                }
                                else
                                {
                                    c = 1;
                                }
                            } while (c == 0);
                        }
                    }

                    // mới mua chưa được 1 tháng
                    else
                    {
                        if (denngay.DateTime > row1.ngayhieuluc)
                        {


                            if (lst2.Count() == 0)
                            {
                                {
                                    int so = 1;
                                    int thang = denngay.DateTime.Month;
                                    luyke = ((row1.muckhthang) / (DateTime.DaysInMonth(denngay.DateTime.Year, denngay.DateTime.Month))) * ((denngay.DateTime.Day - DateTime.Parse(row1.ngayhieuluc.ToString()).Day) + 1);
                                    conlai = conlai - luyke;
                                    if (luyke != 0)
                                    {
                                        tk.moi(row1.id + "KH" + so.ToString(), row1.iddv, "KH", row1.id, row1.ngayhieuluc.Value.AddMonths(so), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), so, row1.iddt, row1.iddt, "Khấu Hao: " + row1.idts, row1.tkchiphi, row1.tkkhauhao, double.Parse(row1.muckhthang.ToString()), "KIP", 1, double.Parse(row1.muckhthang.ToString()), "", "", Biencucbo.idnv, "", row1.idcv, row1.idmuccp, "", "", 0.0);
                                        kh.khauhao(row1.id, luyke, conlai);
                                    }
                                }
                            }
                            MessageBox.Show("Done!", "THÔNG BÁO");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
