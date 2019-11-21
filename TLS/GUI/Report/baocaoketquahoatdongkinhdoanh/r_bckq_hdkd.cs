using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BUS;
namespace GUI.Report.baocaoketquahoatdongkinhdoanh
{
    public partial class r_bckq_hdkd : DevExpress.XtraReports.UI.XtraReport
    {
        public r_bckq_hdkd()
        {
            InitializeComponent();
            d01.Text = string.Format("{0:n2}", Candoi.d01);
            d02.Text = string.Format("{0:n2}", Candoi.d02);
            t10.Text = string.Format("{0:n2}", Candoi.d10);
            t11.Text = string.Format("{0:n2}", Candoi.d11);
            t20.Text = string.Format("{0:n2}", Candoi.d20);
            t21.Text = string.Format("{0:n2}", Candoi.d21);
            t22.Text = string.Format("{0:n2}", Candoi.d22);
            t23.Text = string.Format("{0:n2}", Candoi.d23);
            t25.Text = string.Format("{0:n2}", Candoi.d25);
            t26.Text = string.Format("{0:n2}", Candoi.d26);
            t30.Text = string.Format("{0:n2}", Candoi.d30);
            t31.Text = string.Format("{0:n2}", Candoi.d31);
            t32.Text = string.Format("{0:n2}", Candoi.d32);
            t40.Text = string.Format("{0:n2}", Candoi.d40);
            t50.Text = string.Format("{0:n2}", Candoi.d50);
            t51.Text = string.Format("{0:n2}", Candoi.d51);
            t52.Text = string.Format("{0:n2}", Candoi.d52);
            t60.Text = string.Format("{0:n2}", Candoi.d60);
            t70.Text = string.Format("{0:n2}", Candoi.d70);
            t71.Text = string.Format("{0:n2}", Candoi.d71);
            // năm nay
            c01.Text = string.Format("{0:n2}", Candoi.c01);
            c01.Text = string.Format("{0:n2}", Candoi.c01);
            n10.Text = string.Format("{0:n2}", Candoi.c10);
            n11.Text = string.Format("{0:n2}", Candoi.c11);
            n20.Text = string.Format("{0:n2}", Candoi.c20);
            n21.Text = string.Format("{0:n2}", Candoi.c21);
            n22.Text = string.Format("{0:n2}", Candoi.c22);
            n23.Text = string.Format("{0:n2}", Candoi.c23);
            n25.Text = string.Format("{0:n2}", Candoi.c25);
            n26.Text = string.Format("{0:n2}", Candoi.c26);
            n30.Text = string.Format("{0:n2}", Candoi.c30);
            n31.Text = string.Format("{0:n2}", Candoi.c31);
            n32.Text = string.Format("{0:n2}", Candoi.c32);
            n40.Text = string.Format("{0:n2}", Candoi.c40);
            n50.Text = string.Format("{0:n2}", Candoi.c50);
            n51.Text = string.Format("{0:n2}", Candoi.c51);
            n52.Text = string.Format("{0:n2}", Candoi.c52);
            n60.Text = string.Format("{0:n2}", Candoi.c60);
            n70.Text = string.Format("{0:n2}", Candoi.c70);
            n71.Text = string.Format("{0:n2}", Candoi.c71);
        }
    }
}
