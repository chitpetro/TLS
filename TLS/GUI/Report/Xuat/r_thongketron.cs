using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
using BUS;
namespace GUI.Report.Xuat
{
    public partial class r_thongketron : DevExpress.XtraReports.UI.XtraReport
    {
        public r_thongketron(object source)
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Biểu đồ cột").ToString();
            changeFont.Translate(this);
            chartControl1.Series["Series 1"].DataSource = source;
            txtdonvi.Text = f_thongketong.tendv;
            txttime.Text =  Biencucbo.tungay.ToShortDateString() + " - " + Biencucbo.denngay.ToShortDateString();
        } 
    }
}
