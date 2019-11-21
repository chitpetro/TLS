using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraEditors;

namespace GUI.foodcourt
{
    public partial class f_dmvean : frm.frmds
    {
        c_dmvean  v = new c_dmvean();
        t_history hs = new t_history();
        public f_dmvean()
        {
            InitializeComponent();
        }

        #region override

        protected override bool them()
        {
            Biencucbo.hdong = 1;
            var frm = new foodcourt.f_themdmvean();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool sua()
        {
            Biencucbo.hdong = 2;
            Biencucbo.key = gv.GetFocusedRowCellValue("idve").ToString();
            var frm = new foodcourt.f_themdmvean();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool saochep()
        {
            Biencucbo.hdong = 3;
            Biencucbo.key = gv.GetFocusedRowCellValue("idve").ToString();
            var frm = new foodcourt.f_themdmvean();
            if (frm.ShowDialog() == DialogResult.OK)
                return true;
            return false;
        }

        protected override bool xoa()
        {
            try
            {
                v.xoa(double.Parse(gv.GetFocusedRowCellValue("idve").ToString()));
                hs.add(gv.GetFocusedRowCellValue("idve").ToString(), "Xóa Danh Mục Vé Ăn");
                custom.mes_done();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override void load()
        {
            gd.DataSource = new KetNoiDBDataContext().dmveans;
        }


        #endregion  
    }
}