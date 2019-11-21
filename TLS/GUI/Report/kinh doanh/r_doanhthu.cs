using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class r_doanhthu : DevExpress.XtraReports.UI.XtraReport
    {
        public r_doanhthu()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran2(txtkho, txttime, ngay2, xrPageInfo2);
            if (Biencucbo.ngonngu.ToString() == "Lao")
            {
                //change font                
                XtraReport xtraReport = this;
                var list = xtraReport.AllControls<XRControl>();
                foreach (var c in list)
                {
                    if (c == xrTableCell1 || c == xrTableCell2 || c == xrTableCell3 || c == xrTableCell4 || c == xrTableCell5 || c == xrTableCell14 || c == xrTableCell15 || c == xrTableCell21 || c == xrTableCell33 || c == xrTableCell26 || c == xrTableCell25 || c == xrTableCell27 || c == xrTableCell28 /*|| c == xrTableCell36*/ || c == xrTableCell22 || c == xrTableCell24 || c == xrTableCell39 || c == xrTableCell19 || c == xrTableCell18 || c == xrTableCell35)
                    {
                        c.Font = new System.Drawing.Font("Times New Roman", c.Font.Size, c.Font.Style);
                    }
                }
            }
        }
    }
}
