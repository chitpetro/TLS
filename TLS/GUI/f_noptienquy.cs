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
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class f_noptienquy : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_history hs = new t_history();
        public f_noptienquy()
        {
            InitializeComponent();
            txttiente.Properties.DataSource = new DAL.KetNoiDBDataContext().tientebhs;
            txtdt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongbhs;

        }
        public void loaddata()
        {
            try
            {

                db = new KetNoiDBDataContext();
                Biencucbo.hdntq = 2;
                btnmo.Enabled = true;
                btnthem.Enabled = true;
                btnsave.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                btnreload.Enabled = false;
                txtid.ReadOnly = true;
                txtngay.ReadOnly = true;
                txtdt.ReadOnly = true;
                txtnguyente.ReadOnly = true;
                txtthanhtien.ReadOnly = true;
                txtdiengiai.ReadOnly = true;
                txttiente.ReadOnly = true;
                txttygia.ReadOnly = true;


                //txtloaihd.ReadOnly = true;

                try
                {
                    var lst1 = (from a in db.nopquys where a.dvnop == Biencucbo.donvi  select a.so).Max();
                    var lst = (from b in db.nopquys where b.dvnop == Biencucbo.donvi  select b).FirstOrDefault(t => t.so == lst1);
                    if (lst == null) return;
                    txt1 = int.Parse(lst.so.ToString());
                    txtid.Text = lst.id;
                    txtngay.Text = DateTime.Parse(lst.ngaynop.ToString()).ToShortDateString();
                    txtdiengiai.Text = lst.diengiai;
                    txtdt.Text = lst.iddt;
                    try
                    {
                        var lst12 = (from a in db.doituongbhs select a).Single(t => t.id == txtdt.Text);
                        lbltendt.Text = lst12.ten;
                    }
                    catch
                    {

                    }
                    txttiente.Text = lst.tiente;
                    txttygia.Text = lst.tygia.ToString();
                    txtnguyente.Text = lst.nguyente.ToString();
                    txtthanhtien.Text = lst.thanhtien.ToString();
                }
                catch
                {

                }
            }
            catch
            {

            }
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;
            if ((bool)q.Them == true)
            {
                btnthem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnthem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if ((bool)q.Sua == true)
            {
                btnsua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnsua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if ((bool)q.Xoa == true)
            {
                btnxoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnxoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        private void f_thutienbanhang_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Nộp Tiền Cho Trung Tâm").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            try
            {
                loaddata();

                txtid.ReadOnly = true;
            }
            catch
            {

            }
        }

        private void txttiente_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                var lst = (from a in db.tientebhs select a).Single(t => t.tiente == txttiente.Text);
                txttygia.Text = lst.tygia.ToString();
                if (txtnguyente.Text != "")
                {
                    txtthanhtien.Text = (double.Parse(txtnguyente.Text) * double.Parse(txttygia.Text)).ToString();
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
            
        }



        int txt1 = 0;

        public void luu()
        {
            t_tudong td = new t_tudong();
            try
            {
                if (txtngay.Text == "" || txtdt.Text == "" || txttiente.Text == "" || txttygia.Text == "")
                {
                    Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
                }
                else
                {
                    if (Biencucbo.hdntq == 0)
                    {
                        db = new KetNoiDBDataContext();
                        try
                        {
                            string check = "NTQ" + Biencucbo.donvi.Trim().ToString();
                            var lst1 = (from s in db.tudongs where s.maphieu == check select new { so = s.so }).ToList();
                            if (lst1.Count == 0)
                            {
                                int so;
                                so = 2;
                                td.themtudong(check, so, "NTQ", "Nộp Tiền Quỹ");
                                txtid.Text = check + "_000001";
                                txt1 = 1;
                            }
                            else
                            {
                                int k;

                                txt1 = int.Parse(lst1.Max(t=>t.so).ToString());
                                k = 0;
                                k = txt1;
                                string so0 = "";
                                if (k < 10)
                                {
                                    so0 = "00000";
                                }
                                else if (k >= 10 & k < 100)
                                {
                                    so0 = "0000";
                                }
                                else if (k >= 100 & k < 1000)
                                {
                                    so0 = "000";
                                }
                                else if (k >= 1000 & k < 10000)
                                {
                                    so0 = "00";
                                }
                                else if (k >= 10000 & k < 100000)
                                {
                                    so0 = "0";
                                }
                                else if (k >= 100000)
                                {
                                    so0 = "";
                                }
                                txtid.Text = check + "_" + so0 + k;
                                k = k + 1;
                                td.suatudong(check, k);
                            }
                            nopquy tt = new nopquy();
                            tt.id = txtid.Text;
                            tt.so = txt1;
                            tt.idnv = Biencucbo.idnv;
                            tt.diengiai = txtdiengiai.Text;
                            tt.iddt = txtdt.Text;
                            tt.ngaynop = txtngay.DateTime;
                            tt.dvnop = Biencucbo.dvTen;
                            tt.tiente = txttiente.Text;
                            tt.tygia = double.Parse(txttygia.Text);
                            tt.nguyente = double.Parse(txtnguyente.Text);
                            tt.thanhtien = double.Parse(txtthanhtien.Text);
                            tt.loai = "Nộp Tiền";
                            db.nopquys.InsertOnSubmit(tt);
                            db.SubmitChanges();
                            Biencucbo.hdntq = 2;
                            hs.add(txtid.Text, "Thêm Phiếu Nộp Tiền Quỹ");

                            btnmo.Enabled = true;
                            btnthem.Enabled = true;
                            btnsave.Enabled = false;
                            btnsua.Enabled = true;
                            btnxoa.Enabled = true;
                            btnreload.Enabled = false;
                            txtngay.ReadOnly = true;
                            txtdt.ReadOnly = true;
                            txtnguyente.ReadOnly = true;
                            txtthanhtien.ReadOnly = true;
                            txtdiengiai.ReadOnly = true;
                            txttiente.ReadOnly = true;
                            txttygia.ReadOnly = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }


                    }
                    else
                    {
                        try
                        {
                            nopquy tt = (from a in db.nopquys select a).Single(t => t.id == txtid.Text);

                            tt.diengiai = txtdiengiai.Text;
                            tt.iddt = txtdt.Text;
                            tt.ngaynop = txtngay.DateTime;
                            tt.dvnop = Biencucbo.dvTen;
                            tt.tiente = txttiente.Text;
                            tt.tygia = double.Parse(txttygia.Text);
                            tt.nguyente = double.Parse(txtnguyente.Text);
                            tt.thanhtien = double.Parse(txtthanhtien.Text);
                            db.SubmitChanges();
                            Biencucbo.hdntq = 2;




                            //btn
                            btnmo.Enabled = true;
                            btnthem.Enabled = true;
                            btnsave.Enabled = false;
                            btnsua.Enabled = true;
                            btnxoa.Enabled = true;
                            btnreload.Enabled = false;
                            //enabled
                            txtngay.ReadOnly = true;
                            txtdt.ReadOnly = true;
                            txtnguyente.ReadOnly = true;
                            txtthanhtien.ReadOnly = true;
                            txtdiengiai.ReadOnly = true;
                            txttiente.ReadOnly = true;
                            txttygia.ReadOnly = true;

                            hs.add(txtid.Text, "Sửa Phiếu Nộp Tiền Quỹ");
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void btnsave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (ks.check(txtngay.DateTime))
                    return;
                luu();
            }
            catch
            {
            }

        }

        private void f_thutienbanhang_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    luu();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void txttiennhannt_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F4)
            //{
            //    luu();
            //}
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdntq = 0;
            txtid.DataBindings.Clear();
            txtid.Text = "YYYYY";
            txtngay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtdt.Text = "";
            lbltendt.Text = "";
            txtnguyente.Text = "0";
            txtthanhtien.Text = "0";
            txtdiengiai.Text = "";
            txttiente.Text = "KIP";
            txttygia.Text = "1";
            //btn
            btnthem.Enabled = false;
            btnmo.Enabled = false;
            btnsave.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnreload.Enabled = true;


            //enabled

            txtngay.ReadOnly = false;
            txtdt.ReadOnly = false;

            txtnguyente.ReadOnly = false;
            txtthanhtien.ReadOnly = true;
            txtdiengiai.ReadOnly = false;
            txttiente.ReadOnly = false;
            txttygia.ReadOnly = true;
        }

        private void btnmo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db = new KetNoiDBDataContext();
            f_dsnoptienquy frm = new f_dsnoptienquy();
            frm.ShowDialog();
            if (Biencucbo.getID == 1)
            {
                //load hoa don
                try
                {
                    var lst = (from hd in db.nopquys select hd).FirstOrDefault(x => x.id == Biencucbo.ma);
                    if (lst == null) return;
                    txtid.Text = lst.id;
                    txtngay.Text = DateTime.Parse(lst.ngaynop.ToString()).ToShortDateString();
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
                    btnthem.Enabled = true;
                    btnsua.Enabled = true;
                    btnsave.Enabled = false;
                    btnmo.Enabled = true;
                    btnxoa.Enabled = true;
                    btnreload.Enabled = false;
                }
                catch
                {
                }
            }

        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "") return;
            if (ks.check(txtngay.DateTime))
                return;
            try
            {
                txtngay.ReadOnly = false;
                txtdt.ReadOnly = false;
                txtnguyente.ReadOnly = false;
                txtthanhtien.ReadOnly = true;
                txtdiengiai.ReadOnly = false;
                txttiente.ReadOnly = false;
                txttygia.ReadOnly = true;
                Biencucbo.hdntq = 1;

                // btn
                btnsua.Enabled = false;
                btnsave.Enabled = true;
                btnmo.Enabled = false;
                btnthem.Enabled = false;
                btnxoa.Enabled = false;

                btnreload.Enabled = true;
            }
            catch
            {
            }
        }

        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "") return;
            if (ks.check(txtngay.DateTime))
                return;
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Hoá đơn " + txtid.Text + " không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                nopquy tt = (from a in db.nopquys select a).Single(t => t.id == txtid.Text);
                db.nopquys.DeleteOnSubmit(tt);
                db.SubmitChanges();
                hs.add(txtid.Text, "Xóa Phiếu Nộp Tiền Quỹ");

                //btn
                btnmo.Enabled = true;
                btnthem.Enabled = true;
                btnsave.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;

                btnreload.Enabled = false;
                //enabled

                txtngay.ReadOnly = true;
                txtdt.ReadOnly = true;
                txtnguyente.ReadOnly = true;
                txtthanhtien.ReadOnly = true;
                txtdiengiai.ReadOnly = true;
                txttiente.ReadOnly = true;
                txttygia.ReadOnly = true;
                //txtloaihd.Text = "";
                txtid.Text = "";
                txtngay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                txtdt.Text = "";
                lbltendt.Text = "";
                txtnguyente.Text = "0";
                txtthanhtien.Text = "0";
                txtdiengiai.Text = "";
                txttiente.Text = "KIP";
                txttygia.Text = "1";

            }

        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdntq == 1)
            {
                db = new KetNoiDBDataContext();
                var lst = (from pn in db.nopquys select pn).FirstOrDefault(x => x.id == txtid.Text);
                if (lst == null) return;
                txtid.Text = lst.id;
                txtngay.Text = DateTime.Parse(lst.ngaynop.ToString()).ToShortDateString();
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
                btnthem.Enabled = true;
                btnsua.Enabled = true;
                btnsave.Enabled = false;
                btnmo.Enabled = true;
                btnxoa.Enabled = true;
                btnreload.Enabled = false;

            }
            else if (Biencucbo.hdntq == 0)
            {
                //load();
                loaddata();
                btnthem.Enabled = true;
                btnsua.Enabled = true;
                btnsave.Enabled = false;
                btnmo.Enabled = true;
                btnxoa.Enabled = true;
                btnreload.Enabled = false;

            }
            Biencucbo.hdntq = 2;
        }

        private void txtdt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.doituongbhs select a).Single(t => t.id == txtdt.Text);
                lbltendt.Text = lst.ten;
            }
            catch
            {

            }
        }

        private void txtnguyente_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtnguyente.Text != "")
                {
                    txtthanhtien.Text = (double.Parse(txtnguyente.Text) * double.Parse(txttygia.Text)).ToString();
                }
            }
            catch
            {

            }
        }
        public string tennv (string nv)
        {
            string b = "";
            try
            {
                var lst = (from a in db.accounts where a.id == nv select a).Single(t => t.id == nv);
                b = lst.name;
            }
            catch
            {

            }
            return b;
        }
        public string tendv(string dv)
        {
            string b = "";
            try
            {
                var lst = (from a in db.donvis where a.id == dv select a).Single(t => t.id == dv);
                b = lst.tendonvi;
            }
            catch
            {

            }
            return b;
        }
        public string tendt(string dt)
        {
            string b = "";
            try
            {
                var lst = (from a in db.doituongbhs where a.id == dt select a).Single(t => t.id == dt);
                b = lst.ten;
            }
            catch
            {

            }
            return b;
        }
        private void btnin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (txtid.Text != "")
                {
                    var lst = (from a in new KetNoiDBDataContext().nopquys
                               where a.id == txtid.Text 
                               select new
                               {
                                   ngaythu = a.ngaynop,
                                   name = tennv(a.idnv),
                                   a.id,
                                   tendonvi = tendv(a.dvnop),
                                   a.iddt,
                                   ten = tendt(a.iddt),
                                   a.tiente,
                                   a.tygia,
                                   ghichu = a.diengiai,
                                   a.nguyente,
                                   a.thanhtien,

                               });
                    Biencucbo.tientebc = txttiente.Text;
                    Biencucbo.ngaynhap = txtngay.DateTime;
                    Biencucbo.tondau = double.Parse(txtnguyente.Text);
                    Biencucbo.toncuoi = double.Parse(txtthanhtien.Text);
                    r_noptien xtra = new r_noptien();
                    xtra.DataSource = lst;
                    xtra.ShowPreviewDialog();
                }

            }
            catch
            {

            }
        }
    }
}
