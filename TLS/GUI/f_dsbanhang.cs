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
using DevExpress.XtraSplashScreen;
namespace GUI
{
    public partial class f_dsbanhang : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick = false;
        public f_dsbanhang()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
        }
        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));
            try
            {
                var lst = from a in db.r_pbanhangs

                          where
                          a.ngayban >= tungay && a.ngayban <= denngay && a.iddv == Biencucbo.donvi
                          select new
                          {
                              id = a.id,
                              ngayhd = a.ngayban,
                              iddt = a.iddt,
                              idnv = a.idnv,
                              iddv = a.iddv,
                              ten = a.ten,
                              tensp = a.tensp,
                              noidung = a.diengiai,
                              dv = a.dv,
                              link = a.link,
                              ghichu = a.ghichu,
                              thutien = checktt(a.id),
                              idsanpham = a.idsanpham,
                              soluong = a.soluong,
                              thanhtien = a.thanhtien,
                              tiente = a.tiente,
                              nguyente = a.nguyente,

                          };
                gridControl1.DataSource = lst;
            }
            catch (Exception ex)
            {
                Lotus.MsgBox.ShowErrorDialog(ex.ToString());
            }
            SplashScreenManager.CloseForm();
        }
        #region code cu
        private bool checktt(string id)
        {
            var lst = (from a in db.thutienbanhangs where a.id == id select a).ToList();
            if (lst.Count() == 0)
                return false;
            else
                return true;
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
        #endregion

        private void f_PN_Load(object sender, EventArgs e)
        {

            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.WindowState = FormWindowState.Maximized;
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Phiếu Bán Hàng").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            tungay.ReadOnly = true;
            denngay.ReadOnly = true;

            Biencucbo.getID = 0;
        }

        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
            changeTime.thoigian_change3(thoigian, tungay, denngay);
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }
        private void timkiem_Click(object sender, EventArgs e)
        {
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            doubleclick = false;
        }
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (doubleclick == true)
            {
                Biencucbo.getID = 1;
                Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                this.Close();
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
        }
    }
}
