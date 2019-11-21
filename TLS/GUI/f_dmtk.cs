using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using ControlLocalizer;
using DevExpress.XtraReports.UI;
namespace GUI
{
    public partial class f_dmtk : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        t_dmtaikhoan dmtk = new t_dmtaikhoan();
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_dmtk()
        {
            InitializeComponent();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().dmtks;
            cboChon.EditValue = "--ALL--";
        }
        public void load_form()
        {
            this.WindowState = FormWindowState.Maximized;
            f_themdmtk frm = new f_themdmtk();
            frm.ShowDialog();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().dmtks;
        }
        // phân quyền  
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;
            if ((bool)q.Them == true)
            {
                btnthem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnthem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if ((bool)q.Sua == true)
            {
                btnsua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnsua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if ((bool)q.Xoa == true)
            {
                btnxoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnxoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Biencucbo.hddmtk = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("matk").ToString();
            load_form();
        }
        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hddmtk = 0;
            load_form();
        }
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hddmtk = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("matk").ToString();
            load_form();
        }
        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Lotus.MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa Danh mục Tài khoản này không?") == DialogResult.Yes)
            {
                dmtk.xoa(gridView1.GetFocusedRowCellValue("matk").ToString());
            }
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().dmtks;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().dmtks;
        }
        private void f_dmtk_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Mục Tài Khoản").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }
        private void cboChon_EditValueChanged(object sender, EventArgs e)
        {
            if (cboChon.EditValue.ToString() == "--ALL--")
            {
                gridControl1.DataSource = new DAL.KetNoiDBDataContext().dmtks;
            }
            else if (cboChon.EditValue.ToString() == "ACTIVED")
            {
                gridControl1.DataSource = new DAL.KetNoiDBDataContext().dmtks.Where(t => t.active == true);
            }
            else
            {
                gridControl1.DataSource = new DAL.KetNoiDBDataContext().dmtks.Where(t => t.active == false);
            }
        }
        public string laytkcap1(string a)
        {
            string b = "";
            string c = "";
            try
            {
                b = a.Substring(0, 3);
                var lst = (from ab in db.dmtks select ab).Single(t => t.matk == b);
                c = lst.tentk;
            }
            catch
            {
                c = "";
            }
            return c;
        }
        private void btnin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lst2 = (from c in db.dmtks
                        select
                        new
                        {
                            tkcap1 = c.matk.Substring(0, 3),
                            tentkcap1 = laytkcap1(c.matk),
                            c.matk,
                            c.tentk,
                            c.matk_jp,
                            c.tentk_jp,
                            c.loaikhoan,
                            c.captk,
                            c.tiente,
                            active2 = c.active == true ? "✓" : "",
                            c.active,
                            kieusodu = c.kieusodu == "DEB" ? "Kiểu Dư Nợ" : c.kieusodu == "CRD" ? "Kiểu Dư Có" : "Kiểu Lưỡng Tính",
                        });
            if (cboChon.EditValue.ToString() == "--ALL--")
            {
                r_dm_taikhoan r = new r_dm_taikhoan();
                r.DataSource = lst2;
                r.ShowPreviewDialog();
            }
            else if (cboChon.EditValue.ToString() == "ACTIVED")
            {
                r_dm_taikhoan r = new r_dm_taikhoan();
                r.DataSource = lst2.Where(t => t.active == true);
                r.ShowPreviewDialog();
            }
            else
            {
                r_dm_taikhoan r = new r_dm_taikhoan();
                r.DataSource = lst2.Where(t => t.active == false);
                r.ShowPreviewDialog();
            }
        }
    }
}
