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
    public partial class f_themaccount : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_account ac = new t_account();
        t_tudong td = new t_tudong();
        public f_themaccount()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            var lst = from a in db.donvis select new { id = a.id, tendonvi = a.tendonvi };
            txtmadonvi.Properties.DataSource = lst;
            var items = db.phongbans.ToList();
            txtphongban.Properties.DataSource = items;
        }
        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdaccount == 0)
            {
                if (txtid.Text == "" || txtname.Text == "" || txtuname.Text == "" || txtpass.Text == "" || txtphongban.Text == "" || txtmadonvi.Text == "")
                {
                    Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
                }
                else
                {
                    //kiem tra ton tai
                    var tontai = (from t in db.accounts where t.id == txtid.Text || t.uname == txtuname.Text || t.name == txtname.Text select t).ToList();
                    if (tontai.Count == 1)
                    {
                        Lotus.MsgBox.ShowWarningDialog("Thông tin này đã tồn tại - Vui lòng kiểm tra lại!");
                    }
                    else
                    {
                        if (txtpass.Text != txtpass2.Text)
                        {
                            Lotus.MsgBox.ShowWarningDialog("Mật khẩu xác nhận không đúng - Vui lòng kiểm tra lại");
                            txtpass.Text = "";
                            txtpass2.Text = "";
                        }
                        else
                        {
                            ac.moi(txtid.Text, txtuname.Text, txtname.Text, txtpass.Text, txtphongban.Text, txtmadonvi.Text, ia.Checked);
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                var check = (from c in db.accounts select c).Single(t => t.id == txtid.Text);
                if (txtid.Text == "" || txtname.Text == "" || txtuname.Text == "" || txtphongban.Text == "" || txtmadonvi.Text == "")
                {
                    Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
                }
                else
                {
                    if (Biencucbo.phongban != "Admin")
                    {
                        if (txtpasscu.Text == "")
                        {
                            Lotus.MsgBox.ShowWarningDialog("Vui lòng xác nhận mật khẩu cũ trước khi lưu!");
                        }
                        else
                        {
                            if (check.pass.ToString() != txtpasscu.Text)
                            {
                                Lotus.MsgBox.ShowWarningDialog("Mật khẩu cũ xác nhận chưa đúng");
                                txtpasscu.Text = "";
                            }
                            else
                            {
                                if (txtpass.Text != txtpass2.Text)
                                {
                                    Lotus.MsgBox.ShowWarningDialog("Mật khẩu mới xác nhận không đúng - Vui lòng kiểm tra lại!");
                                    txtpass.Text = "";
                                    txtpass2.Text = "";
                                }
                                else
                                {
                                    //code
                                    if (txtpass.Text == "")
                                    {
                                        ac.sua(txtid.Text, txtuname.Text, txtname.Text, check.pass.ToString(), txtphongban.Text, txtmadonvi.Text, ia.Checked);
                                        this.Close();
                                    }
                                    else
                                    {
                                        ac.sua(txtid.Text, txtuname.Text, txtname.Text, txtpass.Text, txtphongban.Text, txtmadonvi.Text, ia.Checked);
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // admin
                        if (txtpass.Text != txtpass2.Text)
                        {
                            Lotus.MsgBox.ShowWarningDialog("Mật khẩu mới xác nhận không đúng - Vui lòng kiểm tra lại!");
                            txtpass.Text = "";
                            txtpass2.Text = "";
                        }
                        else
                        {
                            //code
                            if (txtpass.Text == "")
                            {
                                ac.sua(txtid.Text, txtuname.Text, txtname.Text, check.pass.ToString(), txtphongban.Text, txtmadonvi.Text, ia.Checked);
                                this.Close();
                            }
                            else
                            {
                                ac.sua(txtid.Text, txtuname.Text, txtname.Text, txtpass.Text, txtphongban.Text, txtmadonvi.Text, ia.Checked);
                                this.Close();
                            }
                        }
                    }
                }
            }
        }
        private void f_themaccount_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Tài Khoản").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            if (Biencucbo.hdaccount == 0)
            {
                string ma;
                string check;
                string check2;
                check2 = Biencucbo.soaccount.ToString();
                check = "NV" + Biencucbo.donvi.Trim();
                ma = check + check2;
                txtid.Text = ma;
                txtid.ReadOnly = true;
                ia.Checked = true;
                if (Biencucbo.phongban == "Admin")
                {
                    txtmadonvi.Enabled = true;
                }
                else
                {
                    txtmadonvi.Enabled = false;
                }
                txtmadonvi.Text = Biencucbo.donvi;
            }
            else
            {
                txtname.Enabled = false;
                txtphongban.Enabled = false;
                txtuname.Enabled = false;
                if (Biencucbo.phongban != "Admin")
                {
                    ia.Enabled = false;
                    txtmadonvi.Enabled = false;
                    txtphongban.Enabled = false;
                }
                else
                {
                    txtmadonvi.Enabled = true;
                    txtphongban.Enabled = true;
                }
                var thucthi = (from k in db.accounts select k).Single(t => t.id == Biencucbo.account);
                txtid.Text = thucthi.id;
                txtname.Text = thucthi.name;
                txtuname.Text = thucthi.uname;
                if (thucthi.IsActived == true)
                {
                    ia.Checked = true;
                }
                else
                {
                    ia.Checked = false;
                }
                txtphongban.Text = thucthi.phongban;
                txtmadonvi.Text = thucthi.madonvi;
                layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //layoutControlItem4.Text = "Mật khẩu mới";
            }
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}