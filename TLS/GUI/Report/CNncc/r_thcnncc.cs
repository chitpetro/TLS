using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class r_thcnncc : DevExpress.XtraReports.UI.XtraReport
    {
        public r_thcnncc()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran3(txtkho, txtdoituong, txttime, ngay2, xrPageInfo2);
        }
    }
}
