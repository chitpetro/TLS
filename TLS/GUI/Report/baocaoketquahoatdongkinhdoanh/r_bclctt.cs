using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
namespace GUI.Report.baocaoketquahoatdongkinhdoanh
{
    public partial class r_bclctt : DevExpress.XtraReports.UI.XtraReport
    {
        public r_bclctt()
        {
            InitializeComponent();
            tt01.Text = string.Format("{0:n2}", Candoi.tt01);
            tt02.Text = string.Format("{0:n2}", Candoi.tt02);
            tt03.Text = string.Format("{0:n2}", Candoi.tt03);
            tt04.Text = string.Format("{0:n2}", Candoi.tt04);
            tt05.Text = string.Format("{0:n2}", Candoi.tt05);
            tt06.Text = string.Format("{0:n2}", Candoi.tt06);
            tt07.Text = string.Format("{0:n2}", Candoi.tt07);
            tt20.Text = string.Format("{0:n2}", Candoi.tt20);
            tt21.Text = string.Format("{0:n2}", Candoi.tt21);
            tt22.Text = string.Format("{0:n2}", Candoi.tt22);
            tt23.Text = string.Format("{0:n2}", Candoi.tt23);
            tt24.Text = string.Format("{0:n2}", Candoi.tt24);
            tt25.Text = string.Format("{0:n2}", Candoi.tt25);
            tt26.Text = string.Format("{0:n2}", Candoi.tt26);
            tt27.Text = string.Format("{0:n2}", Candoi.tt27);
            tt30.Text = string.Format("{0:n2}", Candoi.tt30);
            tt31.Text = string.Format("{0:n2}", Candoi.tt31);
            tt32.Text = string.Format("{0:n2}", Candoi.tt32);
            tt33.Text = string.Format("{0:n2}", Candoi.tt33);
            tt34.Text = string.Format("{0:n2}", Candoi.tt34);
            tt35.Text = string.Format("{0:n2}", Candoi.tt35);
            tt36.Text = string.Format("{0:n2}", Candoi.tt36);
            tt40.Text = string.Format("{0:n2}", Candoi.tt40);
            tt50.Text = string.Format("{0:n2}", Candoi.tt50);
            tt60.Text = string.Format("{0:n2}", Candoi.tt60);
            tt61.Text = string.Format("{0:n2}", Candoi.tt61);
            tt70.Text = string.Format("{0:n2}", Candoi.tt70);
            // năm nay
            tn01.Text = string.Format("{0:n2}", Candoi.tn01);
            tn02.Text = string.Format("{0:n2}", Candoi.tn02);
            tn03.Text = string.Format("{0:n2}", Candoi.tn03);
            tn04.Text = string.Format("{0:n2}", Candoi.tn04);
            tn05.Text = string.Format("{0:n2}", Candoi.tn05);
            tn06.Text = string.Format("{0:n2}", Candoi.tn06);
            tn07.Text = string.Format("{0:n2}", Candoi.tn07);
            tn20.Text = string.Format("{0:n2}", Candoi.tn20);
            tn21.Text = string.Format("{0:n2}", Candoi.tn21);
            tn22.Text = string.Format("{0:n2}", Candoi.tn22);
            tn23.Text = string.Format("{0:n2}", Candoi.tn23);
            tn24.Text = string.Format("{0:n2}", Candoi.tn24);
            tn25.Text = string.Format("{0:n2}", Candoi.tn25);
            tn26.Text = string.Format("{0:n2}", Candoi.tn26);
            tn27.Text = string.Format("{0:n2}", Candoi.tn27);
            tn30.Text = string.Format("{0:n2}", Candoi.tn30);
            tn31.Text = string.Format("{0:n2}", Candoi.tn31);
            tn32.Text = string.Format("{0:n2}", Candoi.tn32);
            tn33.Text = string.Format("{0:n2}", Candoi.tn33);
            tn34.Text = string.Format("{0:n2}", Candoi.tn34);
            tn35.Text = string.Format("{0:n2}", Candoi.tn35);
            tn36.Text = string.Format("{0:n2}", Candoi.tn36);
            tn40.Text = string.Format("{0:n2}", Candoi.tn40);
            tn50.Text = string.Format("{0:n2}", Candoi.tn50);
            tn60.Text = string.Format("{0:n2}", Candoi.tn60);
            tn61.Text = string.Format("{0:n2}", Candoi.tn61);
            tn70.Text = string.Format("{0:n2}", Candoi.tn70);
        }
    }
}
