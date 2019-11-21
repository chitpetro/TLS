using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace GUI.frm
{
    public partial class frmds : XtraForm
    {
        private bool dble = false;
        public frmds()
        {
            InitializeComponent();
        }

       
        protected virtual bool them()
        {
            return false;
        }
        protected virtual bool sua()
        {
            return false;
        }
        protected virtual bool xoa()
        {
            return false;
        }
        protected virtual bool saochep()
        {
            return false;
        }

        protected virtual void load()
        {
            
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(them())
                load();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;

            if ((bool) q.Them)
            {
                btnthem.Visibility = BarItemVisibility.Always;
                btnsaochep.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnthem.Visibility = BarItemVisibility.Never;
                btnsaochep.Visibility = BarItemVisibility.Never;
            }
            if ((bool) q.Sua)
            {
                btnsua.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnsua.Visibility = BarItemVisibility.Never;
            }
            if ((bool) q.Xoa)
            {
                btnxoa.Visibility = BarItemVisibility.Always;
            }
            else
            {
                btnxoa.Visibility = BarItemVisibility.Never;
            }
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(sua())
                load();
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (xoa())
                    load();
            }
        }

        private void btnprint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gv.ShowRibbonPrintPreview();

        }

        private void btnxls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "output.xls";
            gd.ExportToXls(path);
            Process.Start(path);
        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load();
        }

        private void btnsaochep_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (saochep())
                load();
        }

        private void frmds_Load(object sender, EventArgs e)
        {
            load();
        }

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }

        private void gv_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void gv_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (dble)
            {
                if(sua())
                    load();
            }
        }
    }

}