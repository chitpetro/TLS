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
    public partial class r_dm_taikhoan : DevExpress.XtraReports.UI.XtraReport
    {
        public r_dm_taikhoan()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran_ngay(ngay2, xrPageInfo2);
        }
        string matk = string.Empty;
        int index = 0;
        private void xrTableCell28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if(lbMaTK.Text!=matk)
            {
                matk = lbMaTK.Text;
                index++;
            }
            xrTableCell28.Text = index.ToString();
        }
    }
}
