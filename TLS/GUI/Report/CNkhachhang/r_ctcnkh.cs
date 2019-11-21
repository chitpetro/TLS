using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class r_ctcnkh : DevExpress.XtraReports.UI.XtraReport
    {
        public r_ctcnkh()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this); 
            if (Biencucbo.tondau > 0)
            {
                string a = string.Format("{0:n2}", Biencucbo.tondau);
                txtnodau.Text = a;
                txtcodau.Text = "0";
            }
            else
            {
                string a = string.Format("{0:n2}", Biencucbo.tondau * (-1));
                txtnodau.Text = "0";
                txtcodau.NullValueText = a;/*(double.Parse((Biencucbo.tondau * (-1)).ToString())).ToString();*/
            }
            if (Biencucbo.toncuoi > 0)
            {
                string a = string.Format("{0:n2}", Biencucbo.toncuoi);
                txtnocuoi.Text = a;
                txtcocuoi.Text = "0";
            }
            else
            {
                string a = string.Format("{0:n2}", Biencucbo.toncuoi * (-1));
                txtnocuoi.Text = "0";
                txtcocuoi.NullValueText = a;
            }
            tran_rp.tran3(txtkho, txtdoituong, txttime, ngay2, xrPageInfo2);
        }
        private void xrTableCell29_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
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
                else if (e.Brick.Text.Contains("HDDV"))
                {
                    f_hddv2 frm = new f_hddv2();
                    Biencucbo.ma = e.Brick.Text;
                    frm.ShowDialog();
                }
            }
        }
        private void xrTableCell30_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
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
            }
        }
    }
}
