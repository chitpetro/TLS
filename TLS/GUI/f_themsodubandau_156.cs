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
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using GUI.Properties;
namespace GUI
{
    public partial class f_themsodubandau_156 : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_sodubandau sd = new t_sodubandau();
        t_tudong td = new t_tudong();
        public f_themsodubandau_156()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            var lst = from a in db.donvis select new { id = a.id, tendonvi = a.tendonvi };
            txtmadonvi.Properties.DataSource = lst;
            txttiente.Properties.DataSource = new DAL.KetNoiDBDataContext().tientes;
            txtiddt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongs;
            txtmasp.Properties.DataSource = new DAL.KetNoiDBDataContext().sanphams;
        }
        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (txtmadonvi.Text == "" || txttiente.Text == "" || txtiddt.Text == "")
                {
                    MessageBox.Show("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại", "THÔNG BÁO");
                }
                else
                {
                    if (Biencucbo.hdsdbd == 0)
                    {
                        string a = Biencucbo.matk + txtiddt.Text + Biencucbo.idnv + DateTime.Now;
                        sd.moi(a, Biencucbo.matk, txtiddt.Text, txtmadonvi.Text, double.Parse(txtpsno_nt.Text), double.Parse(txtpsco_nt.Text), txttiente.Text, double.Parse(txttygia.Text), double.Parse(txtpsno.Text), double.Parse(txtpsco.Text),double.Parse(txtsoluong.Text),txtmasp.Text);
                        MessageBox.Show("Done!");
                        this.Close();
                    }
                    else if (Biencucbo.hdsdbd == 1)
                    {
                        string a = Biencucbo.matk + txtiddt.Text + Biencucbo.idnv + DateTime.Now;
                        sd.sua(Biencucbo.ma, txtiddt.Text, txtmadonvi.Text, double.Parse(txtpsno_nt.Text), double.Parse(txtpsco_nt.Text), txttiente.Text, double.Parse(txttygia.Text), double.Parse(txtpsno.Text), double.Parse(txtpsco.Text), double.Parse(txtsoluong.Text), txtmasp.Text);
                        MessageBox.Show("Done!");
                        this.Close();
                    }
                    Biencucbo.hdsdbd = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void txtiddt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in new DAL.KetNoiDBDataContext().doituongs select a).Single(t => t.id == txtiddt.Text);
                lbltendt.Text = lst.ten;
            }
            catch
            {
                lbltendt.Text = "";
            }
        }
        private void txtiddt_Popup(object sender, EventArgs e)
        {
            IPopupControl popupControl = sender as IPopupControl;
            SimpleButton button = new SimpleButton()
            {
                Image = Resources.icons8_Add_File_16,
                Text = "Thêm mới",
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            };
            button.Click += new EventHandler(button_Click);
            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();
        }
        public void button_Click(object sender, EventArgs e)
        {
            f_doituong frm = new f_doituong();
            frm.ShowDialog();
            txtiddt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongs;
        }
        private void f_themsodubandau_Load(object sender, EventArgs e)
        {
            try
            {
                if (Biencucbo.hdsdbd == 1)
                {
                    var lst = (from a in new DAL.KetNoiDBDataContext().sodubandaus select a).Single(t => t.id == Biencucbo.ma);
                    txtmadonvi.Text = lst.iddv;
                    txtiddt.Text = lst.iddt;
                    var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten;
                    txttiente.Text = lst.tiente;
                    txttygia.Text = lst.tygia.ToString();
                    txtpsno_nt.Text = lst.psno_nt.ToString();
                    txtpsno.Text = lst.psno.ToString();
                    txtpsco_nt.Text = lst.psco_nt.ToString();
                    txtpsco.Text = lst.psco.ToString();
                    txtmasp.Text = lst.idsp;
                    try
                    {
                        var lst3 = (from a in new DAL.KetNoiDBDataContext().sanphams select a).Single(t => t.id == txtmasp.Text);
                        lbltensp.Text = lst3.tensp;
                    }
                    catch
                    {
                        lbltensp.Text = "";
                    }
                    txtsoluong.Text = lst.soluong.ToString();
                }
                if(Biencucbo.matk != "1561")
                {
                    txtsoluong.ReadOnly = true;
                }
            }
            catch
            {
            }
        }
        private void txtpsno_nt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtpsno.Text = (double.Parse(txtpsno_nt.Text) * double.Parse(txttygia.Text)).ToString();
            }
            catch
            {
            }
        }
        private void txtpsco_nt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtpsco.Text = (double.Parse(txtpsco_nt.Text) * double.Parse(txttygia.Text)).ToString();
            }
            catch
            {
            }
        }
        private void txttygia_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtpsno.Text = (double.Parse(txtpsno_nt.Text) * double.Parse(txttygia.Text)).ToString();
                txtpsco.Text = (double.Parse(txtpsco_nt.Text) * double.Parse(txttygia.Text)).ToString();
            }
            catch
            {
            }
        }
        private void txttiente_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in new DAL.KetNoiDBDataContext().tientes select a).Single(t => t.tiente1 == txttiente.Text);
                txttygia.Text = lst.tygia.ToString();
            }
            catch
            {
            }
        }
        private void txtmasp_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in new DAL.KetNoiDBDataContext().sanphams select a).Single(t => t.id == txtmasp.Text);
                lbltensp.Text = lst.tensp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                lbltensp.Text = "";
            }
        }
    }
}
