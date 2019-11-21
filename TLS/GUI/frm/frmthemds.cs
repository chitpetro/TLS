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

namespace GUI.frm
{
    public partial class frmthemds : DevExpress.XtraEditors.XtraForm
    {
        public frmthemds()
        {
            InitializeComponent();
        }

        protected virtual void luu()
        {
            
        }

        protected virtual void load()
        {
            
        }
        
        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            luu();
        }

        private void btnhuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmthemds_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}