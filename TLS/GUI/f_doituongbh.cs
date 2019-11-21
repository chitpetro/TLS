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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.UI;
namespace GUI
{
    public partial class f_doituongbh : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_doituongbh dt = new t_doituongbh();
        public f_doituongbh()
        {
            InitializeComponent();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().doituongbhs;
            gridView1.ClearGrouping();
            gridView1.Columns["loai"].GroupIndex = 1;
            gridView1.ExpandAllGroups();
            this.WindowState = FormWindowState.Maximized;
            //cboChon
            cboChon.EditValue = "--ALL--";
            RepositoryItemComboBox editor = cboChon.Edit as RepositoryItemComboBox;
            editor.Items.Clear();
            var lst = db.nhomdoituongs.Select(t => t.ten);
            editor.Items.Add("--ALL--");
            editor.Items.AddRange(lst.ToList());
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
        //btnThem
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hddtbh = 0;
            f_themdoituongbh frm = new f_themdoituongbh();
            frm.ShowDialog();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().doituongbhs;
            gridView1.ClearGrouping();
            gridView1.Columns["loai"].GroupIndex = 1;
            gridView1.ExpandAllGroups();
        }
        //btnSua
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Biencucbo.hddtbh = 1;
                Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                f_themdoituongbh frm = new f_themdoituongbh();
                frm.ShowDialog();
                gridControl1.DataSource = new DAL.KetNoiDBDataContext().doituongbhs;
                gridView1.ClearGrouping();
                gridView1.Columns["loai"].GroupIndex = 1;
                gridView1.ExpandAllGroups();
            }
            catch
            {
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.hddtbh = 1;
                Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                f_themdoituongbh frm = new f_themdoituongbh();
                frm.ShowDialog();
            }
            catch
            {
            }
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().doituongbhs;
            gridView1.ClearGrouping();
            gridView1.Columns["loai"].GroupIndex = 1;
            gridView1.ExpandAllGroups();
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
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Lotus.MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa Đối tượng này không?") == DialogResult.Yes)
            {
                dt.xoa(gridView1.GetFocusedRowCellValue("id").ToString());
            }
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().doituongbhs;
            gridView1.ClearGrouping();
            gridView1.Columns["loai"].GroupIndex = 1;
            gridView1.ExpandAllGroups();
        }
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().doituongbhs;
            gridView1.ClearGrouping();
            gridView1.Columns["loai"].GroupIndex = 1;
            gridView1.ExpandAllGroups();
        }
        private void f_doituong_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Đối Tượng").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }
        private void cboChon_EditValueChanged(object sender, EventArgs e)
        {
            if (cboChon.EditValue.ToString() == "--ALL--")
            {
                var lst = new DAL.KetNoiDBDataContext().doituongbhs;
                
                gridControl1.DataSource = lst;
                gridView1.ClearGrouping();
                gridView1.Columns["loai"].GroupIndex = 1;
                gridView1.ExpandAllGroups();
            }
            else
            {
                var lst = new DAL.KetNoiDBDataContext().doituongbhs.Where(t => t.nhom == cboChon.EditValue.ToString());
                gridControl1.DataSource = lst;
                gridView1.ClearGrouping();
                gridView1.Columns["loai"].GroupIndex = 1;
                gridView1.ExpandAllGroups();
            }
        }
        public static string nhom = "";
        private void btnin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cboChon.EditValue.ToString() == "--ALL--")
            {
                nhom = "Tất cả";
                var lst = new DAL.KetNoiDBDataContext().doituongbhs;
                
                r_dm_doituong r = new r_dm_doituong();
                r.DataSource = lst;
                r.ShowPreviewDialog();
            }
            else
            {
                nhom = cboChon.EditValue.ToString();
                var lst = new DAL.KetNoiDBDataContext().doituongbhs.Where(t => t.nhom == cboChon.EditValue.ToString());
                r_dm_doituong r = new r_dm_doituong();
                r.DataSource = lst;
                r.ShowPreviewDialog();
            }
        }
    }
}
