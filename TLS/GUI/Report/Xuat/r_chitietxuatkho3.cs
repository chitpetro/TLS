using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
using DevExpress.Mvvm.POCO;

namespace GUI
{
    public partial class r_chitietxuatkho3 : DevExpress.XtraReports.UI.XtraReport
    {
        public r_chitietxuatkho3()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran9(txtsp, txtkho, txtdoituong, txttime, ngay2, xrPageInfo2);
            if (Biencucbo.ngonngu.ToString() == "Lao")
            { 
                //change font
                XtraReport xtraReport = this;
                var list = xtraReport.AllControls<XRControl>();
                
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

        private int _stt = 0;
        private int _stt1 = 0;
        private void stt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1 = 0;
            _stt ++;
            stt.Text = _stt.ToString();
        }

       

        private void stt1_BeforePrint_1(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _stt1 ++;
            stt1.Text = stt.Text + "." + _stt1;
        }
    }
}
