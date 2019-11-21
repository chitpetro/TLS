﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class f_themtientebh : Form
    { 
        t_tientebh   tt = new t_tientebh();
       
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_themtientebh()
        {
            InitializeComponent();
        }
 
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTienTe.Text == "" || txtTyGia.Text == "" )
            {
                Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hdttbh == 0)
                {
                    var Lst = (from l in db.tientebhs where l.tiente == txtTienTe.Text select l).ToList();
                    if (Lst.Count == 1)
                    {
                        Lotus.MsgBox.ShowWarningDialog("Đơn vị Tiền tệ này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        
                        tt.moi(txtTienTe.Text.Trim(), double.Parse(txtTyGia.Text),txtGhiChu.Text);
                        this.Close();
                    }
                }
                //sua
                else
                {
                    tt.sua(txtTienTe.Text,double.Parse(txtTyGia.Text), txtGhiChu.Text);
                    this.Close();
                }
            }
        }
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void f_themtiente_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Tiền Tệ").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            if (Biencucbo.hdttbh == 1)
            {
                txtTienTe.Enabled = false;
                var Lst = (from tt in db.tientebhs where tt.tiente == Biencucbo.ma select tt).ToList();
                txtTienTe.DataBindings.Clear();
                txtTyGia.DataBindings.Clear(); 
                txtGhiChu.DataBindings.Clear();
                txtTienTe.DataBindings.Add("text", Lst, "tiente");
                txtTienTe.Text.Trim();
                txtTyGia.DataBindings.Add("text", Lst, "tygia".Trim());
                txtGhiChu.DataBindings.Add("text", Lst, "ghichu".Trim());
            }
        }
    }
}
