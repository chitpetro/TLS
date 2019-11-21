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
using DAL;
using BUS;

namespace GUI
{
    public partial class f_dspnhapvean : frm.frmmop
    {
        c_pnhapvean pn = new c_pnhapvean();
        t_history hs = new t_history();
        public f_dspnhapvean()
        {
            InitializeComponent();
        }

        protected override void searchall()
        {
            gd.DataSource = (from a in new KetNoiDBDataContext().SP_LayDsPNhapVean(Biencucbo.donvi, tungay.DateTime, denngay.DateTime, true) select a);
        }

        protected override void search(){
            gd.DataSource = (from a in new KetNoiDBDataContext().SP_LayDsPNhapVean(Biencucbo.donvi, tungay.DateTime, denngay.DateTime, false)select a);
        }
    }
}