using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
using BUS;
namespace GUI
{
    public partial class r_pchi : DevExpress.XtraReports.UI.XtraReport
    {
        thuviendocso bangchu = new thuviendocso();
        public r_pchi()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            //tran_rp.tran_ngay(ngay2, xrPageInfo2);
            ngay2.Text = "Ngày " + Biencucbo.ngaynhap.Day + " Tháng " + Biencucbo.ngaynhap.Month + " Năm " + Biencucbo.ngaynhap.Year;
            bangchutygia.Text = "+ Tỷ giá ngoại tệ (vàng bạc, đá quý): " + string.Format("{0:n3}", Biencucbo.tygiabc) + ".";
            txttkno.Text = Biencucbo.tkno;
            txttkco.Text = Biencucbo.tkco;
            txtdiachi.Text = Biencucbo.diachi;
        }
        private void stt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bangchunt.Text = "Đã nhận đủ số tiền (viết bằng chữ): " + bangchu.docso(long.Parse(stt.Text)).ToString() + " (" + Biencucbo.tientebc + ").";
            }
            catch
            {
            }
        }
        private void snt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bangchutt.Text = "+ Số tiền quy đổi (KIP): " + bangchu.docso(long.Parse(snt.Text)).ToString() + ".";
            }
            catch
            {
            }
        }
    }
}
