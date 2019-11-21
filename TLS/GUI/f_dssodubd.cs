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
    public partial class f_dssodubd : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        t_dmtaikhoan dmtk = new t_dmtaikhoan();
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick = false;
        public f_dssodubd()
        {
            InitializeComponent();
         
        }
        public void load_form()
        {
            this.WindowState = FormWindowState.Maximized;
            f_themdmtk frm = new f_themdmtk();
            frm.ShowDialog();
            gridControl1.DataSource = new DAL.KetNoiDBDataContext().dmtks;
        }
        // phân quyền  
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
        public string lay(string ab)
        {
            string b = "";
            var lst = (from a in new DAL.KetNoiDBDataContext().dmtks select a).Single(t => t.matk == ab);
            if (lst.tkme == "" || lst.tkme == null)
                b = ab;
            else
                b = lst.tkme;
            return b;
        }
        private void f_dssodubd_Load(object sender, EventArgs e)
        {
            var lst = (from a in db.r_sodubandaus
                       //where a.active == true
                       select new
                       {
                           a.matk,
                           a.tentk,
                           tkme = lay(a.matk),
                           psno = a.psno == null ? 0 : a.psno,
                           psco = a.psco == null ? 0 : a.psco,
                       });
            gridControl1.DataSource = lst;
            gridView1.ClearGrouping();
            gridView1.Columns["tkme"].GroupIndex = 1;
            gridView1.ExpandAllGroups();
        }
        private void gridView1_StartGrouping(object sender, EventArgs e)
        {
            gridView1.Columns["tkme"].GroupIndex = 1;
            gridView1.ExpandAllGroups();
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            doubleclick = false;
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
        }
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (doubleclick == true)
            {
                try
                {
                    Biencucbo.matk = gridView1.GetFocusedRowCellValue("matk").ToString();
                    Biencucbo.info = "Tài khoản: " + gridView1.GetFocusedRowCellValue("matk").ToString() + "-" + "Tài khoản: " + gridView1.GetFocusedRowCellValue("tentk").ToString();
                    f_sodubd frm = new f_sodubd();
                    frm.ShowDialog();
                    var lst = (from a in new DAL.KetNoiDBDataContext().r_sodubandaus
                               
                               select new
                               {
                                   a.matk,
                                   a.tentk,
                                   tkme = lay(a.matk),
                                   psno = a.psno == null ? 0 : a.psno,
                                   psco = a.psco == null ? 0 : a.psco,
                               });
                    gridControl1.DataSource = lst;
                    gridView1.ClearGrouping();
                    gridView1.Columns["tkme"].GroupIndex = 1;
                    gridView1.ExpandAllGroups();
                }
                catch
                {
                }
                
            }
        }
        private void btnshow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ExpandAllGroups();
        }
    }
}
