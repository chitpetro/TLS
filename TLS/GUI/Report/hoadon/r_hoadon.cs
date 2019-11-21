using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
using BUS;
namespace GUI
{
    public partial class r_hoadon : DevExpress.XtraReports.UI.XtraReport
    {
        public r_hoadon()
        {
            InitializeComponent();
            //LanguageHelper.Translate(this);

            s_kip.Text = string.Format("{0:#,#}", double.Parse(f_banhang._kip.ToString()));
            s_usd.Text = string.Format("{0:n2}", double.Parse(f_banhang._usd.ToString()));
            s_bath.Text = string.Format("{0:n2}", double.Parse(f_banhang._bath.ToString()));
            s_vnd.Text = string.Format("{0:n2}", double.Parse(f_banhang._vnd.ToString()));

           
        }

        private void r_hoadon_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
