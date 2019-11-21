using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
namespace GUI.Report.Xuat
{
    public partial class r_thongke : DevExpress.XtraReports.UI.XtraReport
    {
        public r_thongke(object source)
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Biểu đồ đường").ToString();
            changeFont.Translate(this);
            chartControl1.Series["Series 1"].DataSource = source;
            txtdonvi.Text = f_thongke.tendv;
            txttime.Text = f_thongke.n1.ToShortDateString() + " - " + f_thongke.n2.ToShortDateString();
        }
    }
}
