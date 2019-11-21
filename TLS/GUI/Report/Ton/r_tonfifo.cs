using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class r_tonfifo : DevExpress.XtraReports.UI.XtraReport
    {
        public r_tonfifo()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran5( txtkho, txttime, ngay2, xrPageInfo2);
            if (Biencucbo.ngonngu.ToString() == "Lao")
            { 
                //change font
                XtraReport xtraReport = this;
                var list = xtraReport.AllControls<XRControl>();
                foreach (var c in list)
                {
                    if (c == xrTableCell20 || c == xrTableCell22 || c == xrTableCell24 || c == xrTableCell37 || c == xrTableCell39 || c == xrTableCell40 || c == xrTableCell36 || c == xrTableCell35 || c == xrTableCell33 || c == xrTableCell31 || c == xrTableCell29 || c == xrTableCell27 || c == xrTableCell26 || c == xrTableCell43 || c == xrTableCell45 || c == xrTableCell47 || c == xrTableCell49 || c == xrTableCell50)
                    {
                        c.Font = new System.Drawing.Font("Times New Roman", c.Font.Size, c.Font.Style);
                    }
                } 
            }
        }
    }
}
