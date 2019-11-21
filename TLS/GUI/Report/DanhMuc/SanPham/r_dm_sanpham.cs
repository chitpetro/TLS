using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
using BUS;
using System.Windows.Forms;
namespace GUI
{
    public partial class r_dm_sanpham : DevExpress.XtraReports.UI.XtraReport
    {
        public r_dm_sanpham()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran_ngay(ngay2, xrPageInfo2);
            //if (f_sanpham.qlkho == "Tất cả")
            //{
            //    lbqlkho.Text = "";
            //}
            //else
            //{
            //    lbqlkho.Text = "Quản Lý Kho : " + f_sanpham.qlkho;
            //}
        }
        private void xrTableCell7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (xrTableCell7.Text == "True")
            //    xrTableCell7.Text = "✓";
            //else
            //    xrTableCell7.Text = "";
        }
    }
}
