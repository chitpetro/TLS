using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;
using ControlLocalizer;

namespace GUI
{
    public partial class f_thutienbanhang : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_history hs = new t_history();
        public f_thutienbanhang()
        {
            InitializeComponent();
            txttiente.Properties.DataSource = new DAL.KetNoiDBDataContext().tientebhs;
            

        }
        public void loaddata()
        {
            try
            {
                txtdiengiai.ReadOnly = true;
                txttientrant.ReadOnly = true;
                txttientra.ReadOnly = true;
                txtnguyente.ReadOnly = true;
                txtthanhtien.ReadOnly = true;
                txtdt.ReadOnly = true;
                txttiente.Text = "KIP";
                txttygia.Text = "1";
                var lst = (from a in new KetNoiDBDataContext().banhangs select a).Single(t => t.id == Biencucbo.ma);
                txtdt.Text = lst.iddt;
                try
                {
                    var lstdt = (from a in db.doituongbhs select a).Single(t => t.id == txtdt.Text);
                    lbltendt.Text = lstdt.ten;
                }
                catch
                {
                    lbltendt.Text = "";
                }
                txtdiengiai.Text = "Thu Tiền Bán Hàng";
                var lst2 = (from a in new KetNoiDBDataContext().banhangcts where a.idbanhang == Biencucbo.ma select a.thanhtien).Sum();
                txtthanhtien.Text = lst2.ToString();
                txtnguyente.Text = (lst2 / double.Parse(txttygia.Text)).ToString();
            }
            catch
            {

            }
        }


        private void f_thutienbanhang_Load(object sender, EventArgs e)
        {
            try
            {
                this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                LanguageHelper.Translate(this);
                LanguageHelper.Translate(barManager1);
                this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thu Tiền Bán Hàng").ToString();
                changeFont.Translate(this);
                changeFont.Translate(barManager1);

                loaddata();
                txtdt.ReadOnly = true;
                txtnguyente.ReadOnly = true;
                txtthanhtien.ReadOnly = true;
            }
            catch
            {

            }
        }

        private void txttiente_EditValueChanged(object sender, EventArgs e)
        {
            txttiennhannt.Focus();
            try
            {
                var lst = (from a in db.tientebhs select a).Single(t => t.tiente == txttiente.Text);
                txttygia.Text = lst.tygia.ToString();
                if (txtthanhtien.Text != "")
                {
                    txtnguyente.Text = (double.Parse(txtthanhtien.Text) / double.Parse(txttygia.Text)).ToString();
                }
            }
            catch
            {
                txttiente.Text = "KIP";
                txttygia.Text = "1";
            }
        }

        private void txtthanhtien_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtthanhtien.Text != "")
                {
                    txtnguyente.Text = (double.Parse(txtthanhtien.Text) / double.Parse(txttygia.Text)).ToString();
                }
            }
            catch
            {

            }
        }

       

        private void txttiennhannt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txttientrant.Text = (double.Parse(txttiennhannt.Text) - double.Parse(txtnguyente.Text)).ToString();
                txttientra.Text = (double.Parse(txttientrant.Text) * double.Parse(txttygia.Text)).ToString();
            }
            catch
            {

            }
        }

        public void luu()
        {
            try
            {
                if(txttiennhannt.Text == "0.00" || txttiennhannt.Text == "")
                {
                    MessageBox.Show("ERROR");
                    return;
                }
                else if (double.Parse(txttiennhannt.Text) <  double.Parse(txtnguyente.Text))
                {
                    MessageBox.Show("ERROR");
                    return;
                }

                thutienbanhang tt = new thutienbanhang();
                tt.id = Biencucbo.ma;
                tt.diengiai = txtdiengiai.Text;
                tt.iddt = txtdt.Text;
                tt.idnv = Biencucbo.idnv;
                tt.ngaytt = Biencucbo.ngaynhap;
                tt.dvch = Biencucbo.donvi;
                tt.dvtt = Biencucbo.dvTen;
                tt.tiente = txttiente.Text;
                tt.tygia = double.Parse(txttygia.Text);
                tt.nguyente = double.Parse(txtnguyente.Text);
                tt.thanhtien = double.Parse(txtthanhtien.Text);
                tt.tiennhan = double.Parse(txttiennhannt.Text);
                tt.tientra = double.Parse(txttientra.Text);
                tt.tientrant = double.Parse(txttientrant.Text);

                db.thutienbanhangs.InsertOnSubmit(tt);
                db.SubmitChanges();
                this.Close();
                hs.add(Biencucbo.ma, "Thu tiền Bán Hàng");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnsave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            luu();
        }

        private void f_thutienbanhang_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                luu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txttiennhannt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F4 || e.KeyCode == Keys.Enter)
            {
                luu();
            }
        }
    }
}