using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;
using ControlLocalizer;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraReports.UI;

namespace GUI.Report.Xuat
{
    public partial class f_thongketron : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public f_thongketron()
        {
            InitializeComponent();

            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);

            var lst = from d in db.donvis
                      where d.nhomdonvi == "POS" || d.id == "00"
                      select new
                      {
                          d.id,
                          d.tendonvi,
                          d.iddv,
                          MaTim = LayMaTim(d),
                      };

            txtdonvi.Properties.DataSource = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.dvTen + ".")).ToList();
        }
        private string LayMaTim(donvi d)
        {
            string s = "." + d.id + "." + d.iddv + ".";
            var find = db.donvis.Single(t => t.id == d.iddv);
            if (find != null)
            {
                string iddv = find.iddv;
                if (d.id != find.iddv)
                {
                    if (!s.Contains(iddv))
                        s += iddv + ".";
                }
                while (iddv != find.id)
                {
                    if (!s.Contains(find.id))
                        s += find.id + ".";
                    find = db.donvis.FirstOrDefault(t => t.id == find.iddv);
                }
            }
            return s;
        }

        private void f_thongke_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.WindowState = FormWindowState.Maximized;
            LanguageHelper.Translate(this);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thống kê tổng").ToString();

            changeFont.Translate(this);

            //tran
            if (Biencucbo.ngonngu.ToString() == "Vietnam")
            {
                gridColumn1.Caption = "ID";
                gridColumn2.Caption = "Tên Đơn Vị";
                gridColumn3.Caption = "Đơn Vị Quản Lý";
            }
            else
            {
                gridColumn1.Caption = "ລະຫັດຫົວໜ່ວຍ";
                gridColumn2.Caption = "ຊີ່ຫົວໜ່ວຍ";
                gridColumn3.Caption = "ຫົວໜ່ວຍຄຸ້ມຄອງ";
            }

            tungay.ReadOnly = true;
            denngay.ReadOnly = true;
        }
        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);
            try
            {
                //reset db
                db.CommandTimeout = 0;

                var items = (from a in db.r_pbanhangs
                             join d in db.donvis on a.iddv equals d.id
                             where
                             a.ngayban >= tungay && a.ngayban <= denngay
                             select new
                             {
                                 id = a.id,
                                 iddv = a.iddv + "-" + a.tendonvi + " (%)",
                                 ngayhd = a.ngayban,
                                 thanhtien = a.thanhtien,
                                 MaTim = LayMaTim(d)
                             });


                var lst2 = items.ToList().Where(t => t.MaTim.Contains("." + txtdonvi.Text + "."));
                tongtien = double.Parse(lst2.Sum(t => t.thanhtien).ToString());
                var lst = (from a in lst2
                           select new
                           {
                               a.id,
                               a.iddv,
                               a.ngayhd,
                               tt = a.thanhtien,
                               thanhtien = ( a.thanhtien / tongtien)*100,
                               a.MaTim,
                           });

                chartControl1.Series["Series 1"].DataSource = lst;

                Biencucbo.tungay = tungay;
                Biencucbo.denngay = denngay;
            }
            catch (Exception ex)
            {
                Lotus.MsgBox.ShowErrorDialog(ex.ToString());
            }
            SplashScreenManager.CloseForm(false);
        }
        double tongtien = 0;
        public int laypt( double? thanhtien)
        {
            int b = 0;


            return b;
        }
        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
            changeTime.thoigian_change3(thoigian, tungay, denngay);
            if (Biencucbo.gtime == 1)
            {
                loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
            }
        }

        private void btnxem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var items = from a in db.r_pbanhangs
                        join d in db.donvis on a.iddv equals d.id
                        where
                        a.ngayban >= tungay.DateTime && a.ngayban <= denngay.DateTime
                        select new
                        {
                            id = a.id,
                            iddv = a.iddv + "-" + a.tendonvi + " (%)",
                            ngayhd = a.ngayban,
                            thanhtien = a.thanhtien,
                            MaTim = LayMaTim(d)
                        };
            var lst2 = items.ToList().Where(t => t.MaTim.Contains("." + txtdonvi.Text + "."));
            tongtien = double.Parse(lst2.Sum(t => t.thanhtien).ToString());
            var lst = (from a in lst2
                       select new
                       {
                           a.id,
                           a.iddv,
                           a.ngayhd,
                           tt = a.thanhtien,
                           thanhtien = (a.thanhtien / tongtien) * 100,
                           a.MaTim,
                       });

            r_thongketron report = new r_thongketron(lst);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }

        public static string madv, tendv;
        public static DateTime n1, n2;
        private void txtdonvi_EditValueChanged(object sender, EventArgs e)
        {
            var lst = (from a in db.donvis
                       where a.id == txtdonvi.Text
                       select new data_thongke()
                       {
                           tendonvi = a.tendonvi
                       }).ToList();

            var row1 = lst.ElementAt(0) as data_thongke;

            madv = txtdonvi.Text;
            tendv = row1.tendonvi;
        }
    }
}