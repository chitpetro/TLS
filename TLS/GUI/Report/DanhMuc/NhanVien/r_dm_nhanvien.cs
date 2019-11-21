﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
using BUS;
using System.Windows.Forms;
namespace GUI
{
    public partial class r_dm_nhanvien : DevExpress.XtraReports.UI.XtraReport
    {
        public r_dm_nhanvien()
        {
            InitializeComponent();
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
            tran_rp.tran_ngay(ngay2, xrPageInfo2);
            lbphongban.Text = "Phòng Ban : " + f_account.pb;
        }
    }
}
