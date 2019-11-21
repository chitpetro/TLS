using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
using BUS;
using DAL;
using GUI.Properties;
using System.Windows.Forms;

namespace GUI
{
    public partial class r_nhapquy : DevExpress.XtraReports.UI.XtraReport
    {
        thuviendocso bangchu = new thuviendocso();
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public r_nhapquy()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            ngay2.Text = "Ngày " + Biencucbo.ngaynhap.Day + " Tháng " + Biencucbo.ngaynhap.Month + " Năm " + Biencucbo.ngaynhap.Year;
            //bangchutygia.Text = "+ Tỷ giá ngoại tệ (vàng bạc, đá quý): " + string.Format("{0:n3}", Biencucbo.tygiabc) + ".";
            //tran_rp.tran_ngay(ngay2, xrPageInfo2);
            string a = string.Format("{0:n2}", Biencucbo.tondau);
            txtnt.Text = a;
            a = string.Format("{0:n2}", Biencucbo.toncuoi);
            txttt.Text = a;
            bangchutt.Text = "+ Số tiền quy đổi (KIP): " + bangchu.docso(long.Parse(Biencucbo.toncuoi.ToString())).ToString() + ".";
            bangchunt.Text = "+ Đã nhận đủ số tiền (viết bằng chữ): " + bangchu.docso(long.Parse(Biencucbo.tondau.ToString())).ToString() + " (" + Biencucbo.tientebc + ").";
            pic.Image = Resources.logoTLS;
            //pic.SizeMode = PictureBoxSizeMode.StretchImage;
        }



        private void txttt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void txtnt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
