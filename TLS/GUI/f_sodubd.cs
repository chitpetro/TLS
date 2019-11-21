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
    public partial class f_sodubd : Form
    {
        t_sodubandau sodu = new t_sodubandau();
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick = false;
        public f_sodubd()
        {
            InitializeComponent();
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
        private void load()
        {
            var lst = (from a in db.r_setsodubandaus
                       where a.matk == Biencucbo.matk
                       select new
                       {
                           a.matk,
                           a.id,
                           a.iddv,
                           iddt = a.iddt + "-" + a.ten,
                           a.ten,
                           a.tiente,
                           a.tygia,
                           a.psno_nt,
                           a.psco_nt,
                           psno = a.psno == null ? 0 : a.psno,
                           psco = a.psco == null ? 0 : a.psco,
                       }).ToList();
            gridControl1.DataSource = lst;
        }
        private void f_dssodubd_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btn_info.Caption = Biencucbo.info;
            load();
        }
        private void gridView1_StartGrouping(object sender, EventArgs e)
        {
        }
        private void btn_grtiente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ClearGrouping();
            gridView1.Columns["tiente"].GroupIndex = 1;
            gridView1.ExpandAllGroups();
        }
        private void btn_grdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ClearGrouping();
            gridView1.Columns["iddt"].GroupIndex = 1;
            gridView1.ExpandAllGroups();
        }
        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdsdbd = 0;
            if (Biencucbo.matk == "156")
                return;
            else if (Biencucbo.matk.Substring(0, 3) == "156" || Biencucbo.matk == "632")
            {
                f_themsodubandau_156 frm = new f_themsodubandau_156();
                frm.ShowDialog();
            }
            else
            {
                f_themsodubandau frm = new f_themsodubandau();
                frm.ShowDialog();
            }
            load();
        }
        private void sua()
        {
            try
            {
                Biencucbo.hdsdbd = 1;
                Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                if (Biencucbo.matk == "156")
                    return;
                else if (Biencucbo.matk.Substring(0, 3) == "156" || Biencucbo.matk == "632")
                {
                    f_themsodubandau_156 frm = new f_themsodubandau_156();
                    frm.ShowDialog();
                }
                else
                {
                    f_themsodubandau frm = new f_themsodubandau();
                    frm.ShowDialog();
                }
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sua();
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
                sua();
            }
        }
        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sodu.xoa(gridView1.GetFocusedRowCellValue("id").ToString());
            load();
            
        }
    }
}
