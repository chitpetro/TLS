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

namespace GUI.foodcourt
{
    public partial class f_dspxuatvean : frm.frmmop
    {
        c_pxuatvean px = new c_pxuatvean();
        t_history hs = new t_history();
        public f_dspxuatvean()
        {
            InitializeComponent();
        }

        protected override void search()
        {
            gd.DataSource = new  KetNoiDBDataContext().LayDsVeAn(Biencucbo.donvi,tungay.DateTime,denngay.DateTime,false);
        }

        protected override void searchall()
        {
            gd.DataSource = new KetNoiDBDataContext().LayDsVeAn(Biencucbo.donvi, tungay.DateTime, denngay.DateTime, true);
        }
    }
}