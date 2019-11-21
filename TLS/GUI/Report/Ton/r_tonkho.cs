using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class r_tonkho : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tonkho()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran5( txtkho, txttime, ngay2, xrPageInfo2);
        }
    }
}
