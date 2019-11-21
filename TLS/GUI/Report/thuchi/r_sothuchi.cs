using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class r_sothuchi : DevExpress.XtraReports.UI.XtraReport
    {
        public r_sothuchi()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            txttaikhoan.Text = "(" + Biencucbo.tiente + ")";
            string a = string.Format("{0:n2}", Biencucbo.tondau);
            if (Biencucbo.nt == 1)
            {
                txttondau.Text = a + " " + Biencucbo.tiente;
            }
            else
            {
                txttondau.Text = a;
            }
            string b = string.Format("{0:n2}", Biencucbo.toncuoi);
            if (Biencucbo.nt == 1)
            {
                txttoncuoi.Text = b + " " + Biencucbo.tiente;
            }
            else
            {
                txttoncuoi.Text = b;
            }
            tran_rp.tran2(txtkho, txttime, ngay2, xrPageInfo2);
            txttitle.Text = Biencucbo.title;
            if (Biencucbo.ngonngu.ToString() == "Lao")
            {
                //change font
                XtraReport xtraReport = this;
                var list = xtraReport.AllControls<XRControl>();
                foreach (var c in list)
                {
                    if (c == xrTableCell19 || c == xrTableCell20 || c == txtthu || c == txtchi || c == xrTableCell24 || c == xrTableCell25 || c == xrTableCell26 || c == xrTableCell28)
                    {
                        c.Font = new System.Drawing.Font("Times New Roman", c.Font.Size, c.Font.Style);
                    }
                }
                txttitle.Text = Biencucbo.title;
            }
        }
        private void xrTableCell21_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
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
            }
        }
        private void txtchi_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
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
            }
        }
    }
}
