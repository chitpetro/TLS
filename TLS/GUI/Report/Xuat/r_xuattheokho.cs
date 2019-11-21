using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class r_xuattheokho : DevExpress.XtraReports.UI.XtraReport
    {
        public r_xuattheokho()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            
            tran_rp.tran9(txtsp, txtkho, txtdoituong,/* txtcongviec, txtloaixuat,*/ txttime, ngay2, xrPageInfo2);
            if (Biencucbo.ngonngu.ToString() == "Lao")
            {
                //change font
                XtraReport xtraReport = this;
                var list = xtraReport.AllControls<XRControl>();
                foreach (var c in list)
                {
                    if (c == xrTableCell1 || c == xrTableCell2 || c == xrTableCell3 || c == xrTableCell4 || c == xrTableCell5 || c == xrTableCell17 || c == xrTableCell18 || c == xrTableCell19 || c == xrTableCell24 || c == xrTableCell26 || c == xrTableCell23 || c == xrTableCell39 || c == xrTableCell14 || c == xrTableCell35 || c == xrTableCell27 || c == xrTableCell28 || c == xrTableCell15 || c == xrTableCell30)
                    {
                        c.Font = new System.Drawing.Font("Times New Roman", c.Font.Size, c.Font.Style);
                    }
                }
            }
        }
        private void xrTableCell2_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            if (e.Brick.Text != "")
            {
                if (e.Brick.Text.Contains("PT"))
                {
                    f_pthu_txn frm = new f_pthu_txn();
                    Biencucbo.ma = e.Brick.Text;
                    frm.ShowDialog();
                }
                else if (e.Brick.Text.Contains("PC"))
                {
                    f_pchi_txn frm = new f_pchi_txn();
                    Biencucbo.ma = e.Brick.Text;
                    frm.ShowDialog();
                }
                else if (e.Brick.Text.Contains("BC"))
                {
                    f_baoco_txn frm = new f_baoco_txn();
                    Biencucbo.ma = e.Brick.Text;
                    frm.ShowDialog();
                }
                else if (e.Brick.Text.Contains("BN"))
                {
                    f_baono_txn frm = new f_baono_txn();
                    Biencucbo.ma = e.Brick.Text;
                    frm.ShowDialog();
                }
                else if (e.Brick.Text.Contains("KT"))
                {
                    f_pkt_txn frm = new f_pkt_txn();
                    Biencucbo.ma = e.Brick.Text;
                    frm.ShowDialog();
                }
                else if (e.Brick.Text.Contains("HD"))
                {
                    f_hd_txn frm = new f_hd_txn();
                    Biencucbo.ma = e.Brick.Text;
                    frm.ShowDialog();
                }
                else if (e.Brick.Text.Contains("PN"))
                {
                    f_pnhap_txn frm = new f_pnhap_txn();
                    Biencucbo.ma = e.Brick.Text;
                    frm.ShowDialog();
                }
                else if (e.Brick.Text.Contains("PX"))
                {
                    f_pxuat_txn frm = new f_pxuat_txn();
                    Biencucbo.ma = e.Brick.Text;
                    frm.ShowDialog();
                }
            }
        }
    }
}
