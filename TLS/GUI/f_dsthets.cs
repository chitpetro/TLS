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
namespace GUI
{
    public partial class f_dsthets : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick = false;
        public f_dsthets()
        {
            InitializeComponent();
        }
        public void loaddata()
        {
            try
            {
                var lst = from a in db.r_tscds
                          join d in db.donvis on a.iddv equals d.id
                          select new
                          {
                              a.id,
                              a.iddv,
                              a.kyhieu,
                              a.tents,
                              a.loaits,
                              a.ngaysd,
                              a.ngayngungkh,
                              a.ngaythanhly,
                              a.tinhtrang,
                              a.iddt,
                              a.dvt,
                              a.sl,
                              a.ppkh,
                              a.namsx,
                              a.nuocsx,
                              a.sothangkh,
                              a.link,
                              a.ngaymua,
                              a.diengiai,
                              a.tknguyengia,
                              a.tkkhauhao,
                              a.tkchiphi,
                              a.idmuccp,
                              a.idcv,
                              a.idts,
                              a.lydotg,
                              a.nguonvon,
                              a.muckhthang,
                              a.ngayhieuluc,
                              a.ngaykethuc,
                              a.nguyengia,
                              a.khbandau,
                              a.gtclbd,
                              a.khnamnay,
                              a.khluyke,
                              a.gtconlai,
                              MaTim = LayMaTim(d),
                          };
                var lst2 = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                gridControl1.DataSource = lst2;
            }
            catch (Exception ex)
            {
                Lotus.MsgBox.ShowErrorDialog(ex.ToString());
            }
        }
        private void f_PN_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Tài Sản Cố Định").ToString();
            changeFont.Translate(this);
            loaddata();
        }
        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
        }
        private void timkiem_Click(object sender, EventArgs e)
        {
            loaddata();
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
                Biencucbo.hdts = 2;
                Biencucbo.getID = 1;
                Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                if (Biencucbo.checkts == 1)
                {
                    this.Close();
                }
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
        }
        private void btnin_Click(object sender, EventArgs e)
        {
            var lst = from a in db.r_tscds
                      join d in db.donvis on a.iddv equals d.id
                      select new
                      {
                          a.id,
                          a.iddv,
                          a.kyhieu,
                          a.tents,
                          a.loaits,
                          a.ngaysd,
                          a.ngayngungkh,
                          a.ngaythanhly,
                          a.tinhtrang,
                          a.iddt,
                          a.dvt,
                          a.sl,
                          a.ppkh,
                          a.namsx,
                          a.nuocsx,
                          a.sothangkh,
                          a.link,
                          a.ngaymua,
                          a.diengiai,
                          a.tknguyengia,
                          a.tkkhauhao,
                          a.tkchiphi,
                          a.idmuccp,
                          a.idcv,
                          a.idts,
                          a.lydotg,
                          a.nguonvon,
                          a.muckhthang,
                          a.ngayhieuluc,
                          a.ngaykethuc,
                          a.nguyengia,
                          a.khbandau,
                          a.gtclbd,
                          a.khnamnay,
                          a.khluyke,
                          a.gtconlai,
                          MaTim = LayMaTim(d),
                      };
            var lst2 = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
            r_dm_thets r = new r_dm_thets();
            r.DataSource = lst2;
            r.ShowPreviewDialog();
        }
    }
}
