using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
using BUS;
using System.Windows.Forms;
namespace GUI
{
    public partial class r_dm_donvi : DevExpress.XtraReports.UI.XtraReport
    {
        public r_dm_donvi()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran_ngay(ngay2, xrPageInfo2);
            lbnhom.Text = "Nhóm Đơn Vị : " + f_donvi.nhomdv;
        }
    }
}
