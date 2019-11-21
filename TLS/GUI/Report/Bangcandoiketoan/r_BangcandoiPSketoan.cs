using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class r_BangcandoiPSketoan : DevExpress.XtraReports.UI.XtraReport
    {
        public r_BangcandoiPSketoan()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran1(txtdv, txttaikhoan, txttime, ngay2, xrPageInfo2);
            if (Biencucbo.ngonngu.ToString() == "Lao")
            {
                //change font
                XtraReport xtraReport = this;
                var list = xtraReport.AllControls<XRControl>();
                foreach (var c in list)
                {
                    if (c == xrTableCell22 || c == xrTableCell31 || c == xrTableCell29 || c == xrTableCell23 || c == xrTableCell32 || c == xrTableCell30 || c == xrTableCell24 || c == xrTableCell33 || c == xrTableCell36 || c == xrTableCell25 || c == xrTableCell34 || c == xrTableCell37 || c == xrTableCell27 || c == xrTableCell35 || c == xrTableCell38 || c == xrTableCell10 || c == xrTableCell20 || c == xrTableCell39)
                    {
                        c.Font = new System.Drawing.Font("Times New Roman", c.Font.Size, c.Font.Style);
                    }
                }
            }
        }
        private void xrTableCell28_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            //Biencucbo.thanhtoan = no.GetEffe
            f_pthu_tt frm = new f_pthu_tt();
            frm.ShowDialog();
        }
    }
}
