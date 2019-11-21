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
using DevExpress.XtraGrid.Views.Grid;
using ControlLocalizer;
using DevExpress.XtraReports.UI;
namespace GUI
{
    public partial class f_tientebh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        t_tientebh tt = new t_tientebh(); 
        public f_tientebh()
        {
            InitializeComponent(); 
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().tientebhs; 
        }
 
        // phân quyền 
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;
            if ((bool)q.Them == true)
            {
                btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if ((bool)q.Sua == true)
            {
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if ((bool)q.Xoa == true)
            {
                btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        #region STT
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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
        #endregion
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().tientebhs;
        }
 
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdttbh = 0;
            f_themtientebh frm = new f_themtientebh();
            frm.ShowDialog();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().tientebhs;
        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdttbh = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("tiente").ToString();
            f_themtientebh frm = new f_themtientebh();
            frm.ShowDialog();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().tientebhs;
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Lotus.MsgBox.ShowYesNoDialog("Bạn có chắc chắn muốn xóa Tiền tệ này không?") == System.Windows.Forms.DialogResult.Yes)
            {
                tt.xoa(gridView1.GetFocusedRowCellValue("tiente").ToString());
            }
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().tientebhs;
        }
        private void f_tiente_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Tiền Tệ").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }
        private void btnin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            r_dm_tiente r = new r_dm_tiente();
            r.DataSource = new DAL.KetNoiDBDataContext().tientebhs;
            r.ShowPreviewDialog();
        }
    }
} 
