using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlLocalizer
{
    public static class changeTime
    {
        public static LanguageEnum Language
        {
            get { return LanguageHelper.Language; }
        }

        public static void thoigian_change3(ComboBoxEdit thoigian, DateEdit tungay, DateEdit denngay)
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
    }
}