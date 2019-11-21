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
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
namespace GUI
{
    public partial class f_dsnoptienquy : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick = false;
        public f_dsnoptienquy()
        {
            InitializeComponent();
            if (Biencucbo.ngonngu.ToString() == "Vietnam")
            {
                colid.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "id", "Tổng cộng:")});
            }
            else //Lao
            {
                colid.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "id", "ລວມທັງໝົດ:")});
            }
            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
        }
        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));

            var lst = from a in db.nopquys
                      join d in db.donvis on a.dvnop equals d.id
                      where
                      a.ngaynop >= tungay && a.ngaynop <= denngay 
                      select new
                      {
                          id = a.id,
                          ngaythu = a.ngaynop,
                          iddt = a.iddt,
                          idnv = a.idnv,
                          iddv = a.dvnop,
                          ghichu = a.diengiai,
                          thanhtien = a.thanhtien,
                          tiente = a.tiente,
                          nguyente = a.nguyente,
                          MaTim = LayMaTim(d)
                      };
            var lst2 = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.dvTen + "."));
            gridControl1.DataSource = lst2;

            SplashScreenManager.CloseForm();
        }
        #region code cu
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
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Phiếu Nộp Tiền ").ToString();
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
        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            doubleclick = true;
        }
        private void gridView1_CustomDrawRowIndicator_1(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
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
        public string tennv(string nv)
        {
            string b = "";
            try
            {
                var lst = (from a in db.accounts where a.id == nv select a).Single(t => t.id == nv);
                b = lst.name;
            }
            catch
            {

            }
            return b;
        }
        public string tendv(string dv)
        {
            string b = "";
            try
            {
                var lst = (from a in db.donvis where a.id == dv select a).Single(t => t.id == dv);
                b = lst.tendonvi;
            }
            catch
            {

            }
            return b;
        }
        public string tendt(string dt)
        {
            string b = "";
            try
            {
                var lst = (from a in db.doituongbhs where a.id == dt select a).Single(t => t.id == dt);
                b = lst.ten;
            }
            catch
            {

            }
            return b;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("id").ToString() != "")
                {
                    var lst = (from a in new KetNoiDBDataContext().nopquys
                               where a.id == gridView1.GetFocusedRowCellValue("id").ToString()
                               select new
                               {
                                   ngaythu = a.ngaynop,
                                   name = tennv(a.idnv),
                                   a.id,
                                   tendonvi = tendv(a.dvnop),
                                   a.iddt,
                                   ten = tendt(a.iddt),
                                   a.tiente,
                                   a.tygia,
                                   ghichu = a.diengiai,
                                   a.nguyente,
                                   a.thanhtien,

                               });
                    Biencucbo.tientebc = gridView1.GetFocusedRowCellValue("tiente").ToString();
                    Biencucbo.ngaynhap = DateTime.Parse(gridView1.GetFocusedRowCellValue("ngaythu").ToString());
                    Biencucbo.tondau = double.Parse(gridView1.GetFocusedRowCellValue("nguyente").ToString());
                    Biencucbo.toncuoi = double.Parse(gridView1.GetFocusedRowCellValue("thanhtien").ToString());
                    r_noptien xtra = new r_noptien();
                    xtra.DataSource = lst;
                    xtra.ShowPreview();
                }

            }
            catch
            {

            }
        }
    }
}
