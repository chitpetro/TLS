using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
using BUS;
namespace GUI
{
    public partial class r_pxuat : DevExpress.XtraReports.UI.XtraReport
    {
        public r_pxuat()
        {
            InitializeComponent(); 
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran_ngay(ngay2, xrPageInfo2);
        }
    }
}
