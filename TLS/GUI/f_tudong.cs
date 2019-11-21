using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI
{
    public partial class f_tudong : DevExpress.XtraEditors.XtraForm
    {
        public f_tudong()
        {
            InitializeComponent();
            var lst = (from a in new DAL.KetNoiDBDataContext().tudongs where a.iddv == Biencucbo.donvi && a.ma != "HS" && a.ma !="FHD" select a);
            gcontrol.DataSource = lst;
            this.CenterToParent();
        }

        private void f_tudong_Load(object sender, EventArgs e)
        {

        }
        bool dble = false;
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Biencucbo.ma = gview.GetFocusedRowCellValue("maphieu").ToString();
                f_suatudong std = new f_suatudong();
                std.ShowDialog();
                var lst = (from a in new DAL.KetNoiDBDataContext().tudongs where a.iddv == Biencucbo.donvi && a.ma != "HS" && a.ma != "FHD" select a);
                gcontrol.DataSource = lst;
            }
            catch
            {

            }
        }

        private void gview_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            if (!gview.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gview); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gview); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void gview_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gview_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void gview_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (dble == true)
                {
                    Biencucbo.ma = gview.GetFocusedRowCellValue("maphieu").ToString();
                    f_suatudong std = new f_suatudong();
                    std.ShowDialog();
                    var lst = (from a in new DAL.KetNoiDBDataContext().tudongs where a.iddv == Biencucbo.donvi && a.ma != "HS" && a.ma != "FHD" select a);
                    gcontrol.DataSource = lst;
                }
            }
            catch
            {

            }
        }
    }
}