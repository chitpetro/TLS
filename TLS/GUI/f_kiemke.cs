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
namespace GUI
{
    public partial class f_kiemke : Form
    {
        t_gia sp = new t_gia();
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_kiemke()
        {
            InitializeComponent();
     
            var lst = new DAL.KetNoiDBDataContext().r_giasps;
            try
            {
                var lst2 = (from a in lst where a.iddv == Biencucbo.donvi select a);
                gridControl1.DataSource = lst2;
            }
            catch
            { 
            } 
        }
        // phân quyền 
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;
             
            if ((bool)q.Sua == true)
            {
                btnsua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnsua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            } 
        }
 
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //Biencucbo.hdkk = 1;
            //try
            //{
            //    Biencucbo.ma = gridView1.GetFocusedRowCellValue("idsp").ToString();
            //    f_themkiemke frm = new f_themkiemke();
            //    frm.ShowDialog();
            //    var lst = new DAL.KetNoiDBDataContext().r_giasps;
            //    var lst2 = (from a in lst where a.iddv == Biencucbo.donvi select a);
            //    gridControl1.DataSource = lst2;
            //}
            //catch
            //{
            //}
        }
        
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            Biencucbo.hdkk = 1;
              
            try
            {
                Biencucbo.ma = gridView1.GetFocusedRowCellValue("idsp").ToString();
                f_themkiemke frm = new f_themkiemke();
                frm.ShowDialog();
                var lst = new DAL.KetNoiDBDataContext().r_giasps;
                var lst2 = (from a in lst where a.iddv == Biencucbo.donvi select a);
                gridControl1.DataSource = lst2;
            }
            catch
            { 
            } 
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
            var lst = new DAL.KetNoiDBDataContext().r_giasps;
            try
            {
                var lst2 = (from a in lst where a.iddv == Biencucbo.donvi select a);
                gridControl1.DataSource = lst2;
            }
            catch
            { 
            } 
        }
        private void f_giasp_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Kiểm Kê").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }
    }
}

