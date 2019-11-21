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
using DevExpress.XtraEditors;
namespace GUI
{
    public partial class f_dinhkhoan : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_dinhkhoan()
        {
            InitializeComponent();
            gridView1.ExpandAllGroups();
        }
        private void f_PN_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Định Khoản").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            try
            {
                var lst = from a in db.ct_tks
                          join b in db.sanphams on a.idsp equals b.id into k
                          from sp in k.DefaultIfEmpty()
                          where a.machungtu == Biencucbo.ma && a.PS != 0 && a.PS_nt!= 0
                          
                          select new
                          {
                              tk_no = a.tk_no,
                              tk_co = a.tk_co,
                              tiente = a.tiente,
                              tygia = a.tygia,
                              PS = a.PS,
                              tensp = sp.tensp == null ? "":sp.tensp,
                              PS_nt = a.PS_nt,
                              dt_no = a.dt_no,
                              dt_co = a.dt_co,
                              iddv = a.iddv,
                              idcv = a.idcv,
                          };
                gridControl1.DataSource = lst;
                gridView1.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
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
    }
}
