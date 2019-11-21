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
    public partial class f_thongkeduong : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_thongkeduong()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
            var lst = from d in db.donvis
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
            var find = db.donvis.FirstOrDefault(t => t.id == d.iddv);
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
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thống kê").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
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
        public static string madv,tendv;
        public static DateTime n1, n2;
        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));
            try
            {
                var items = from a in db.r_pbanhangs
                            join d in db.donvis on a.iddv equals d.id
                            where
                            a.ngayban >= tungay && a.ngayban <= denngay
                            select new
                            {
                                id = a.id,
                                iddv = a.iddv + "-" + a.tendonvi,
                                ngayhd = a.ngayban,
                                thanhtien = a.thanhtien,
                                MaTim = LayMaTim(d)
                            };
                var lst = items.ToList().Where(t => t.MaTim.Contains("." + txtdonvi.Text + "."));
                chartControl1.Series["Series 1"].DataSource = lst;
                n1 = tungay;
                n2 = denngay;
            }
            catch (Exception ex)
            {
                Lotus.MsgBox.ShowErrorDialog(ex.ToString());
            }
            SplashScreenManager.CloseForm();
        }
        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
            changeTime.thoigian_change3(thoigian, tungay, denngay);
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }
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
        private void btnxem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var items = from a in db.r_pbanhangs
                        join d in db.donvis on a.iddv equals d.id
                        where
                        a.ngayban >= tungay.DateTime && a.ngayban <= denngay.DateTime
                        select new
                        {
                            id = a.id,
                            iddv = a.iddv,
                            tendonvi = a.tendonvi,
                            ngayhd = a.ngayban,
                            thanhtien = a.thanhtien,
                            MaTim = LayMaTim(d)
                        };
            var lst = items.ToList().Where(t => t.MaTim.Contains("." + txtdonvi.Text + "."));
            r_thongke report = new r_thongke(lst);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }
    }
}
