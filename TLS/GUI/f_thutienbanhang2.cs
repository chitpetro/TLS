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
    public partial class f_thutienbanhang2 : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_history hs = new t_history();
        public f_thutienbanhang2()
        {
            InitializeComponent();
            txttiente.Properties.DataSource = new DAL.KetNoiDBDataContext().tientebhs;


        }
        public void loaddata()
        {
            var ls = (from a in db.thutienbanhangs where a.id == Biencucbo.ma select a);
            if (ls.Count() == 0)
            {
                try
                {

                    txtdiengiai.ReadOnly = true;
                    txttientrant.ReadOnly = true;

                    txttientra.ReadOnly = true;
                    txtnguyente.ReadOnly = true;
                    txtthanhtien.ReadOnly = true;
                    txtdt.ReadOnly = true;
                    txttiennhannt.ReadOnly = false;
                    txttygia.ReadOnly = false;
                    txttiente.Text = "KIP";
                    txttygia.Text = "1";
                    var lst = (from a in new KetNoiDBDataContext().banhangs select a).Single(t => t.id == Biencucbo.ma);
                    txtdt.Text = lst.iddt;
                    try
                    {
                        var lst3 = (from a in db.doituongbhs select a).Single(t => t.id == txtdt.Text);
                        lbltendt.Text = lst3.ten;
                    }
                    catch
                    {

                    }
                    txtdiengiai.Text = "Thu Tiền Bán Hàng";
                    var lst2 = (from a in new KetNoiDBDataContext().banhangcts where a.idbanhang == Biencucbo.ma select a.thanhtien).Sum();
                    txtthanhtien.Text = lst2.ToString();
                    txtnguyente.Text = (lst2 / double.Parse(txttygia.Text)).ToString();
                    btnsave.Enabled = true;


                    btnxoa.Enabled = false;
                }
                catch
                {

                }
                Biencucbo.hdnq = 0;
            }
            else
            {
                var lst = (from a in new DAL.KetNoiDBDataContext().thutienbanhangs select a).Single(t => t.id == Biencucbo.ma);
                txttiente.Text = lst.tiente;
                txttygia.Text = lst.tygia.ToString();
                txttiennhannt.Text = lst.tiennhan.ToString();

                txttientra.Text = lst.tientra.ToString();
                txttientrant.Text = lst.tientrant.ToString();
                txtdiengiai.Text = lst.diengiai;
                txtdt.Text = lst.iddt;
                try
                {
                    var lst3 = (from a in db.doituongbhs select a).Single(t => t.id == txtdt.Text);
                    lbltendt.Text = lst3.ten;
                }
                catch
                {

                }
                txtnguyente.Text = lst.nguyente.ToString();
                txtthanhtien.Text = lst.thanhtien.ToString();
                txttiennhannt.ReadOnly = true;
                txttiennhannt.ReadOnly = true;
                txttientra.ReadOnly = true;
                txtdiengiai.ReadOnly = true;
                txtdt.ReadOnly = true;
                txttiente.ReadOnly = true;
                txttygia.ReadOnly = true;
                txttientrant.ReadOnly = true;
                txtnguyente.ReadOnly = true;
                txtthanhtien.ReadOnly = true;
                btnsave.Enabled = false;

                btnxoa.Enabled = true;
                Biencucbo.hdnq = 2;
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

                txtdt.ReadOnly = true;
                txttygia.ReadOnly = true;
                txtnguyente.ReadOnly = true;
                txtthanhtien.ReadOnly = true;

                btnsave.Enabled = false;

                btnxoa.Enabled = false;
                loaddata();

            }
            catch
            {

            }
        }

        // phân quyền 
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;

            if ((bool)q.Xoa == true)
            {
                btnxoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnxoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
                if (txttiennhannt.Text == "0.00" || txttiennhannt.Text == "")
                {
                    MessageBox.Show("ERROR");
                    return;
                }
                else if (double.Parse(txttiennhannt.Text) < double.Parse(txtnguyente.Text))
                {
                    MessageBox.Show("ERROR");
                    return;
                }
                if (Biencucbo.hdnq == 0)
                {
                    thutienbanhang tt = new thutienbanhang();
                    tt.id = Biencucbo.ma;
                    tt.diengiai = txtdiengiai.Text;
                    tt.iddt = txtdt.Text;
                    tt.idnv = Biencucbo.idnv;
                    tt.ngaytt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    var lst = (from a in db.banhangs select a).Single(t => t.id == Biencucbo.ma);
                    tt.dvch = lst.iddv;
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

                    hs.add(Biencucbo.ma, "Thu tiền Bán Hàng");
                    btnsave.Enabled = false;

                    btnxoa.Enabled = true;

                    txttiennhannt.ReadOnly = true;
                    txtdt.ReadOnly = true;
                    txtnguyente.ReadOnly = true;
                    txtthanhtien.ReadOnly = true;
                    txtdiengiai.ReadOnly = true;
                    txttiente.ReadOnly = true;
                    txttygia.ReadOnly = true;
                }
                else if (Biencucbo.hdnq == 1)
                {
                    thutienbanhang tt = (from a in db.thutienbanhangs select a).Single(t => t.id == Biencucbo.ma);

                    tt.diengiai = txtdiengiai.Text;
                    tt.iddt = txtdt.Text;
                    tt.tiente = txttiente.Text;
                    tt.tygia = double.Parse(txttygia.Text);
                    tt.nguyente = double.Parse(txtnguyente.Text);
                    tt.thanhtien = double.Parse(txtthanhtien.Text);
                    tt.tiennhan = double.Parse(txttiennhannt.Text);
                    tt.tientra = double.Parse(txttientra.Text);
                    tt.tientrant = double.Parse(txttientrant.Text);
                    db.thutienbanhangs.InsertOnSubmit(tt);
                    db.SubmitChanges();

                    hs.add(Biencucbo.ma, "Sủa Phiếu Thu tiền Bán Hàng");
                    btnsave.Enabled = false;

                    btnxoa.Enabled = true;
                    txttiennhannt.ReadOnly = true;
                    txtdt.ReadOnly = true;
                    txtnguyente.ReadOnly = true;
                    txtthanhtien.ReadOnly = true;
                    txtdiengiai.ReadOnly = true;
                    txttiente.ReadOnly = true;
                    txttygia.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnsave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ks.check(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)))
                return;
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
            if (e.KeyCode == Keys.F4)
            {
                luu();
            }
        }

        private void btnthemmoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdnq = 0;
            txttiennhannt.Text = "0";
            txtdt.Text = "";
            lbltendt.Text = "";
            txtnguyente.Text = "0";
            txtthanhtien.Text = "0";
            txtdiengiai.Text = "";
            txttiente.Text = "KIP";
            txttygia.Text = "1";
            //btn

            btnsave.Enabled = true;

            btnxoa.Enabled = false;


            //enabled


            txtdt.ReadOnly = false;
            txttiennhannt.ReadOnly = false;
            txtnguyente.ReadOnly = false;
            txtthanhtien.ReadOnly = true;
            txtdiengiai.ReadOnly = false;
            txttiente.ReadOnly = false;
            txttygia.ReadOnly = false;
        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            //try
            //{
            //    txttiennhannt.ReadOnly = false;
            //    txtdt.ReadOnly = true;
            //    txtnguyente.ReadOnly = true;
            //    txtthanhtien.ReadOnly = true;
            //    txtdiengiai.ReadOnly = false;
            //    txttiente.ReadOnly = false;
            //    txttygia.ReadOnly = true;
            //    Biencucbo.hdnq = 1;

            //    // btn

            //    btnsave.Enabled = true;


            //    btnxoa.Enabled = false;

            //    btnreload.Enabled = true;
            //}
            //catch
            //{
            //}
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(ks.check(DateTime.Parse((from a in db.thutienbanhangs select a).Single(t => t.id == Biencucbo.ma).ngaytt.ToString())))
            return;

            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Hoá đơn " + Biencucbo.ma + " không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                thutienbanhang tt = (from a in db.thutienbanhangs select a).Single(t => t.id == Biencucbo.ma);
                db.thutienbanhangs.DeleteOnSubmit(tt);
                db.SubmitChanges();
                hs.add(Biencucbo.ma, "Xóa Phiếu Thu Tiền");

                //btn


                btnsave.Enabled = false;

                btnxoa.Enabled = true;

                //enabled

                txttiennhannt.ReadOnly = true;
                txtdt.ReadOnly = true;
                txtnguyente.ReadOnly = true;
                txtthanhtien.ReadOnly = true;
                txtdiengiai.ReadOnly = true;
                txttiente.ReadOnly = true;
                txttygia.ReadOnly = true;
                //txtloaihd.Text = "";
                this.Close();
            }
        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdnq == 1)
            {
                db = new KetNoiDBDataContext();
                var lst = (from pn in db.thutienbanhangs select pn).FirstOrDefault(x => x.id == Biencucbo.ma);
                if (lst == null) return;
                txtdiengiai.Text = lst.diengiai;
                txtdt.Text = lst.iddt;
                try
                {
                    var lst1 = (from a in db.doituongbhs select a).Single(t => t.id == txtdt.Text);
                    lbltendt.Text = lst1.ten;
                }
                catch
                {

                }
                txttiente.Text = lst.tiente;
                txttygia.Text = lst.tygia.ToString();
                txtnguyente.Text = lst.nguyente.ToString();
                txtthanhtien.Text = lst.thanhtien.ToString();


                //btn


                btnsave.Enabled = false;

                btnxoa.Enabled = true;

            }
            else if (Biencucbo.hdnq == 0)
            {
                //load();
                loaddata();

                btnsave.Enabled = false;
                btnxoa.Enabled = true;

            }
            Biencucbo.hdnq = 2;
        }
    }
}