using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class r_chitiettaikhoannt : DevExpress.XtraReports.UI.XtraReport
    {
        public r_chitiettaikhoannt()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
             
            string a = string.Format("{0:n2}", Biencucbo.tondau);
            string b = string.Format("{0:n2}", Biencucbo.toncuoi);
            if (Biencucbo.kieusodu == "DEB")
            {
              
                txtnodauno.Text = a;
                txtnocuoino.Text = b;
               
            }
            else if (Biencucbo.kieusodu == "CRD")
            {
                txtnodauco.Text = a;
                txtnocuoico.Text = b;
            }
            else if (Biencucbo.kieusodu == "DEBCRD")
            {
                if (Biencucbo.tondau > 0)
                {
                    txtnodauno.Text = a;
                }
                else if (Biencucbo.tondau < 0)
                {
                    a = string.Format("{0:n2}", Biencucbo.tondau * (-1));
                    txtnodauco.Text = a;
                }
                if (Biencucbo.toncuoi > 0)
                {
                    txtnocuoino.Text = b;
                }
                else if (Biencucbo.toncuoi < 0)
                {
                    b = string.Format("{0:n2}", Biencucbo.toncuoi * (-1));
                    txtnocuoico.Text = b;
                }
            }
            txttiente.Text = Biencucbo.tientebc;
            tran_rp.tran11(txtdv, txttaikhoan, txtdoituong, txtcongviec, txtmuccp, txttime, ngay2, xrPageInfo2);
        }
        private void xrTableCell28_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
        {
            //Biencucbo.thanhtoan = no.GetEffe
            f_pthu_tt frm = new f_pthu_tt();
            frm.ShowDialog();
        }
        private void no_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
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
                else if (e.Brick.Text.Contains("HDDV"))
                {
                    f_hddv2 frm = new f_hddv2();
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
        private void co_PreviewDoubleClick(object sender, PreviewMouseEventArgs e)
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
                else if (e.Brick.Text.Contains("HDDV"))
                {
                    f_hddv2 frm = new f_hddv2();
                    Biencucbo.ma = e.Brick.Text;
                    frm.ShowDialog();
                }
            }
        }
    }
}
