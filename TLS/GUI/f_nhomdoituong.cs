using BUS;
using ControlLocalizer;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GUI
{
    public partial class f_nhomdoituong : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        t_nhomdoituong ndt = new t_nhomdoituong();
        public f_nhomdoituong()
        {
            InitializeComponent();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().nhomdoituongs;
        }
        private void btnThemNDT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdndt = 0;
            f_themnhomdoituong frm = new f_themnhomdoituong();
            frm.ShowDialog();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().nhomdoituongs;
        }
        // phân quyền 
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;
            if ((bool)q.Them == true)
            {
                btnThemNDT.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnThemNDT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if ((bool)q.Sua == true)
            {
                btnSuaNDT.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSuaNDT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if ((bool)q.Xoa == true)
            {
                btnXoaNDT.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnXoaNDT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        private void btnSuaNDT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdndt = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
            f_themnhomdoituong frm = new f_themnhomdoituong();
            frm.ShowDialog();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().nhomdoituongs;
        }
        private void btnXoaNDT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Lotus.MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa Nhóm đối tượng này không?") == DialogResult.Yes)
            {
                ndt.xoa(gridView1.GetFocusedRowCellValue("id").ToString());
            }
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().nhomdoituongs;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().nhomdoituongs;
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Biencucbo.hdndt = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
            f_themnhomdoituong frm = new f_themnhomdoituong();
            frm.ShowDialog();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().nhomdoituongs;
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
        private void f_nhomdoituong_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Nhóm Đối Tượng").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }
        private void btnin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            r_dm_nhomdt r = new r_dm_nhomdt();
            r.DataSource = new DAL.KetNoiDBDataContext().nhomdoituongs;
            r.ShowPreviewDialog();
        }
    }
}
