using System;
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
using DevExpress.XtraEditors;
using System.Data.Linq;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
namespace GUI
{
    public partial class f_thets : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_thetscd hd = new t_thetscd();
        t_cttk tk = new t_cttk();
        public f_thets()
        {
            InitializeComponent();
            // tinh so luong ton san pham
            rsearchtiente.DataSource = new DAL.KetNoiDBDataContext().tientes;
            txtidcv.Properties.DataSource = new DAL.KetNoiDBDataContext().congviecs;
            txtidmuccp.Properties.DataSource = new DAL.KetNoiDBDataContext().muccps;
            btncongviec.DataSource = new DAL.KetNoiDBDataContext().congviecs;
            txtiddt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongs;
            txttkkh.Properties.DataSource = from a in db.dmtks where a.active == true select a;
            txttkcp.Properties.DataSource = from a in db.dmtks where a.active == true select a;
            txttkng.Properties.DataSource = from a in db.dmtks where a.active == true select a;
            btnlydotg.DataSource = new DAL.KetNoiDBDataContext().lydotgs;
            btnnguonvon.DataSource = new DAL.KetNoiDBDataContext().nguonvons;
            txtloaits.Properties.DataSource = new DAL.KetNoiDBDataContext().loaits;
           
            if (Biencucbo.ngonngu.ToString() == "Vietnam")
            {
                gridColumn35.Caption = "Mã Đối Tượng";
                gridColumn36.Caption = "Tên Đối Tượng ";
                gridColumn37.Caption = "Nhóm Đối Tượng";
                gridColumn38.Caption = "Loại Đối Tượng";
                gridColumn39.Caption = "Địa Chỉ";
                gridColumn53.Caption = "Mã công việc";
                gridColumn54.Caption = "Tên công việc";
                gridColumn55.Caption = "Mục Chi Phí";
                gridColumn58.Caption = "Tên Mục Chi Phí";
            }
            else //lao
            {
                gridColumn35.Caption = "ລະຫັດ";
                gridColumn36.Caption = "ຊື່ເປົ້າໝາຍ";
                gridColumn37.Caption = "ກຸ່ມເປົ້າໝາຍ";
                gridColumn38.Caption = "ປະເພດເປົ້າໝາຍ";
                gridColumn39.Caption = "ທີ່ຢູ່";
                gridColumn53.Caption = "ລະຫັດວຽກງານ";
                gridColumn54.Caption = "ຊື່ວຽກງານ";
                gridColumn55.Caption = "ລາຍການຄ່າໃຊ້ຈ່າຍ";
                gridColumn58.Caption = "ຊື່ຄ່າໃຊ້ຈ່າຍ";
            }
        }
        // phân quyền 
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var q = Biencucbo.QuyenDangChon;
            if (q == null) return;
            if ((bool)q.Them == true)
            {
                btnnew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnnew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
        //load
        public void load()
        {
            db = new KetNoiDBDataContext();
            Biencucbo.hdts = 2;
            txt1.Enabled = false;
            btnLuu.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnin.Enabled = true;
            btnreload.Enabled = false;
            //readonly
            txtid.ReadOnly = true;
            txtdv.ReadOnly = true;
            txtngaysudung.ReadOnly = true;
            txtngaymua.ReadOnly = true;
            txtiddt.ReadOnly = true;
            txtkhts.ReadOnly = true;
            txtkhts.ReadOnly = true;
            txttents.ReadOnly = true;
            txtloaits.ReadOnly = true;
            txtttsd.ReadOnly = true;
            txtiddt.ReadOnly = true;
            txtngayhetkhauhao.ReadOnly = true;
            txtngaythanhly.ReadOnly = true;
            txtdvt.ReadOnly = true;
            txtppkhauhao.ReadOnly = true;
            txtsokh.ReadOnly = true;
            txtsl.ReadOnly = true;
            txtlink.ReadOnly = true;
            txtngaymua.ReadOnly = true;
            txtidcv.ReadOnly = true;
            txtidmuccp.ReadOnly = true;
            txttkng.ReadOnly = true;
            txttkcp.ReadOnly = true;
            txttkkh.ReadOnly = true;
            txtghichu.ReadOnly = true;
            //txtloaihd.ReadOnly = true;
            gridView1.OptionsBehavior.Editable = false;
            try
            {
                var lst = (from a in db.tscodinhs where a.iddv == Biencucbo.donvi select a.id).Max();
                var lst1 = (from b in db.tscodinhs where b.iddv == Biencucbo.donvi select b).FirstOrDefault(t => t.id == lst);
                if (lst1 == null) return;
                txtid.Text = lst1.id;
                txt1.Text = lst1.so.ToString();
                txtdv.Text = lst1.iddv;
                txtngaysudung.DateTime = DateTime.Parse(lst1.ngaysd.ToString());
                txtngaymua.DateTime = DateTime.Parse(lst1.ngaymua.ToString());
                txtiddt.Text = lst1.iddt;
                txtkhts.Text = lst1.kyhieu;
                txttents.Text = lst1.tents;
                txtloaits.Text = lst1.loaits;
                txtttsd.Text = lst1.tinhtrang;
                txtngayhetkhauhao.DateTime = DateTime.Parse(lst1.ngayngungkh.ToString());
                txtngaythanhly.DateTime = DateTime.Parse(lst1.ngaythanhly.ToString());
                txtdvt.Text = lst1.dvt;
                txtppkhauhao.Text = lst1.ppkh;
                txtsokh.Text = lst1.sothangkh.ToString();
                txtsl.Text = lst1.sl.ToString();
                txtlink.Text = lst1.link;
                txtngaymua.DateTime = DateTime.Parse(lst1.ngaymua.ToString());
                txtidcv.Text = lst1.idcv;
                txtidmuccp.Text = lst1.idmuccp;
                txttkng.Text = lst1.tknguyengia;
                txttkcp.Text = lst1.tkchiphi;
                txttkkh.Text = lst1.tkkhauhao;
                txtghichu.Text = lst1.diengiai;
                gcchitiet.DataSource = lst1.tscodinhcts;
                try
                {
                    var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    var lst3 = (from a in db.loaits select a).Single(t => t.id == txtloaits.Text);
                    lbltenloaits.Text = lst3.loaits;
                }
                catch (Exception)
                {
                }
            }
            catch
            {
            }
        }
        //Mở
        private void btnmo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db = new KetNoiDBDataContext();
            Biencucbo.checkts = 1;
            f_dsthets frm = new f_dsthets();
            frm.ShowDialog();
            if (Biencucbo.getID == 1)
            {
                //load hoa don
                try
                {
                    var lst1 = (from hd in db.tscodinhs select new { a = hd }).FirstOrDefault(x => x.a.id == Biencucbo.ma);
                    if (lst1 == null) return;
                    txtdv.Text = lst1.a.iddv;
                    txtngaysudung.DateTime = DateTime.Parse(lst1.a.ngaysd.ToString());
                    txtngaymua.DateTime = DateTime.Parse(lst1.a.ngaymua.ToString());
                    txtiddt.Text = lst1.a.iddt;
                    txtkhts.Text = lst1.a.kyhieu;
                    txttents.Text = lst1.a.tents;
                    txtloaits.Text = lst1.a.loaits;
                    txtttsd.Text = lst1.a.tinhtrang;
                    txtngayhetkhauhao.DateTime = DateTime.Parse(lst1.a.ngayngungkh.ToString());
                    txtngaythanhly.DateTime = DateTime.Parse(lst1.a.ngaythanhly.ToString());
                    txtdvt.Text = lst1.a.dvt;
                    txtppkhauhao.Text = lst1.a.ppkh;
                    txtsokh.Text = lst1.a.sothangkh.ToString();
                    txtsl.Text = lst1.a.sl.ToString();
                    txtlink.Text = lst1.a.link;
                    txtngaymua.DateTime = DateTime.Parse(lst1.a.ngaymua.ToString());
                    txtidcv.Text = lst1.a.idcv;
                    txtidmuccp.Text = lst1.a.idmuccp;
                    txttkng.Text = lst1.a.tknguyengia;
                    txttkcp.Text = lst1.a.tkchiphi;
                    txttkkh.Text = lst1.a.tkkhauhao;
                    txtghichu.Text = lst1.a.diengiai;
                    gcchitiet.DataSource = lst1.a.tscodinhcts;
                    try
                    {
                        var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                        lbltendt.Text = lst2.ten.ToString();
                        var lst3 = (from a in db.loaits select a).Single(t => t.id == txtloaits.Text);
                        lbltenloaits.Text = lst3.loaits;
                    }
                    catch (Exception)
                    {
                    }
                    //btn
                    btnnew.Enabled = true;
                    btnsua.Enabled = true;
                    btnLuu.Enabled = false;
                    btnmo.Enabled = true;
                    btnxoa.Enabled = true;
                    btnin.Enabled = true;
                    btnreload.Enabled = false;
                }
                catch
                {
                }
            }
        }
        //Add new
        private void btnnew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdts = 0;
            txtid.DataBindings.Clear();
            txtid.Text = "YYYYY";
            gcchitiet.DataSource = new DAL.KetNoiDBDataContext().View_tscds;
            for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
            {
                gridView1.DeleteRow(i);
            }
            gridView1.AddNewRow();
            txtdv.Text = Biencucbo.donvi;
            txtngaysudung.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtngaymua.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtiddt.Text = "";
            lbltendt.Text = "";
            txtkhts.Text = "";
            txtkhts.Text = "";
            txttents.Text = "";
            txtloaits.Text = "";
            txtttsd.Text = "";
            txtiddt.Text = "";
            lbltenloaits.Text = "";
            lbltendt.Text = "";
            txtngayhetkhauhao.Text = "";
            txtngaythanhly.Text = "";
            txtdvt.Text = "";
            txtppkhauhao.Text = "Theo Tháng";
            txtsokh.Text = "1";
            txtsl.Text = "1";
            txtlink.Text = "";
            txtngaymua.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtidcv.Text = "";
            txtidmuccp.Text = "";
            txttkng.Text = "";
            txttkcp.Text = "";
            txttkkh.Text = "";
            txtghichu.Text = "";
            //btn
            btnnew.Enabled = false;
            btnmo.Enabled = false;
            btnLuu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnin.Enabled = false;
            btnreload.Enabled = false;
            //enabled
            txtngaysudung.ReadOnly = false;
            txtngaymua.ReadOnly = false;
            txtiddt.ReadOnly = false;
            txtkhts.ReadOnly = false;
            txtkhts.ReadOnly = false;
            txttents.ReadOnly = false;
            txtloaits.ReadOnly = false;
            txtttsd.ReadOnly = false;
            txtiddt.ReadOnly = false;
            txtngayhetkhauhao.ReadOnly = false;
            txtngaythanhly.ReadOnly = false;
            txtdvt.ReadOnly = false;
            txtppkhauhao.ReadOnly = false;
            txtsokh.ReadOnly = false;
            txtsl.ReadOnly = false;
            txtlink.ReadOnly = false;
            txtngaymua.ReadOnly = false;
            txtidcv.ReadOnly = false;
            txtidmuccp.ReadOnly = false;
            txttkng.ReadOnly = false;
            txttkcp.ReadOnly = false;
            txttkkh.ReadOnly = false;
            txtghichu.ReadOnly = false;
            gridView1.OptionsBehavior.Editable = true;
        }
        //Lưu
        public void luu()
        {
            t_history hs = new t_history();
            t_tudong td = new t_tudong();
            gridView1.UpdateCurrentRow();
            int check1 = 0;
            if (txtngaysudung.Text == "" || txtiddt.Text == "" | txtkhts.Text == "" || txttents.Text == "" || txtloaits.Text == "" || txtttsd.Text == "" || txtppkhauhao.Text == "" || txtsl.Text == "" || txtdvt.Text == "" || txtsokh.Text == "" || txtsokh.Text == "0" || txttkcp.Text == "" || txttkkh.Text == "" || txttkng.Text == "")
            {
                Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                try
                {
                    for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
                    {
                        //re-check
                        if (gridView1.GetRowCellValue(i, "lydotg").ToString() == "" || gridView1.GetRowCellValue(i, "nguonvon").ToString() == "" || gridView1.GetRowCellValue(i, "ngayhieuluc").ToString() == "" || gridView1.GetRowCellValue(i, "ngaykethuc").ToString() == "" || gridView1.GetRowCellValue(i, "nguyengia").ToString() == "0" | gridView1.GetRowCellValue(i, "khbandau").ToString() == "")
                        {
                            check1 = 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }
                if (check1 == 1)
                {
                    Lotus.MsgBox.ShowErrorDialog("Thông tin chi tiết chưa đầy đủ - Vui Lòng Kiểm Tra Lại");
                }
                else
                {
                    if (Biencucbo.hdts == 0)
                    {
                        db = new KetNoiDBDataContext();
                        try
                        {
                            string check = "TS" + Biencucbo.donvi.Trim().ToString(); ;
                            var lst1 = (from s in db.tudongs where s.maphieu == check select new { so = s.so }).ToList();
                            if (lst1.Count == 0)
                            {
                                int so;
                                so = 2;
                                td.themtudong(check, so,"TS","Thẻ Tài Sản");
                                txtid.Text = "000001";
                                txt1.Text = "1";
                            }
                            else
                            {
                                int k;
                                txt1.DataBindings.Clear();
                                txt1.DataBindings.Add("text", lst1, "so");
                                k = 0;
                                k = Convert.ToInt32(txt1.Text);
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
                            hd.moiphieu(txtid.Text, txtdv.Text, txtkhts.Text, txttents.Text, txtloaits.Text, txtngaysudung.DateTime, txtngayhetkhauhao.DateTime, txtngaythanhly.DateTime, txtttsd.Text, txtiddt.Text,
                                txtdvt.Text, double.Parse(txtsl.Text), txtppkhauhao.Text, double.Parse(txtsokh.Text), txtlink.Text, txtngaymua.DateTime, txtghichu.Text, txttkng.Text, txttkkh.Text, txttkcp.Text, txtidcv.Text, txtidmuccp.Text, int.Parse(txt1.Text));
                            for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
                            {
                                gridView1.SetRowCellValue(i, "idts", txtid.Text);
                                gridView1.SetRowCellValue(i, "id", txtid.Text + i);
                                hd.moict(gridView1.GetRowCellValue(i, "idts").ToString(), gridView1.GetRowCellValue(i, "lydotg").ToString(), gridView1.GetRowCellValue(i, "nguonvon").ToString(), DateTime.Parse(gridView1.GetRowCellValue(i, "ngayhieuluc").ToString()), DateTime.Parse(gridView1.GetRowCellValue(i, "ngaykethuc").ToString()), double.Parse(gridView1.GetRowCellValue(i, "nguyengia").ToString()), double.Parse(gridView1.GetRowCellValue(i, "khbandau").ToString()), double.Parse(gridView1.GetRowCellValue(i, "gtclbd").ToString()), double.Parse(gridView1.GetRowCellValue(i, "muckhthang").ToString()), double.Parse(gridView1.GetRowCellValue(i, "khnamnay").ToString()), double.Parse(gridView1.GetRowCellValue(i, "khluyke").ToString()), double.Parse(gridView1.GetRowCellValue(i, "gtconlai").ToString()), gridView1.GetRowCellValue(i, "id").ToString());
                                tk.moi(txtid.Text + i + "1", txtdv.Text, "TS", txtid.Text, txtngaysudung.DateTime, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), Convert.ToInt32(txt1.Text), txtiddt.Text, txtiddt.Text, txtghichu.Text, txttkkh.Text, txttkng.Text, double.Parse(gridView1.GetRowCellValue(i, "nguyengia").ToString()), "KIP", 1, double.Parse(gridView1.GetRowCellValue(i, "nguyengia").ToString()), "", "", "", "Thẻ Tài Sản" /*txtloaihd.Text*/, txtidcv.Text, txtidmuccp.Text, lbltendt.Text, txtghichu.Text, 0.0);
                            }
                            //btn
                            btnmo.Enabled = true;
                            btnnew.Enabled = true;
                            btnLuu.Enabled = false;
                            btnsua.Enabled = true;
                            btnxoa.Enabled = true;
                            btnin.Enabled = true;
                            btnreload.Enabled = false;
                            //enabled
                            txtid.ReadOnly = true;
                            txtdv.ReadOnly = true;
                            txtngaysudung.ReadOnly = true;
                            txtngaymua.ReadOnly = true;
                            txtiddt.ReadOnly = true;
                            txtkhts.ReadOnly = true;
                            txtkhts.ReadOnly = true;
                            txttents.ReadOnly = true;
                            txtloaits.ReadOnly = true;
                            txtttsd.ReadOnly = true;
                            txtiddt.ReadOnly = true;
                            txtngayhetkhauhao.ReadOnly = true;
                            txtngaythanhly.ReadOnly = true;
                            txtdvt.ReadOnly = true;
                            txtppkhauhao.ReadOnly = true;
                            txtsokh.ReadOnly = true;
                            txtsl.ReadOnly = true;
                            txtlink.ReadOnly = true;
                            txtngaymua.ReadOnly = true;
                            txtidcv.ReadOnly = true;
                            txtidmuccp.ReadOnly = true;
                            txttkng.ReadOnly = true;
                            txttkcp.ReadOnly = true;
                            txttkkh.ReadOnly = true;
                            txtghichu.ReadOnly = true;
                            gridView1.OptionsBehavior.Editable = false;
                            Biencucbo.hdts = 2;
                            // History
                            hs.add(txtid.Text, "Thêm mới Thẻ TS");
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            hd.suaphieu(txtid.Text, txtdv.Text, txtkhts.Text, txttents.Text, txtloaits.Text, txtngaysudung.DateTime, txtngayhetkhauhao.DateTime, txtngaythanhly.DateTime, txtttsd.Text, txtiddt.Text,
                                txtdvt.Text, double.Parse(txtsl.Text), txtppkhauhao.Text, double.Parse(txtsokh.Text), txtlink.Text, txtngaymua.DateTime, txtghichu.Text, txttkng.Text, txttkkh.Text, txttkcp.Text, txtidcv.Text, txtidmuccp.Text);
                            //sua ct
                            LuuPhieu();
                            tk.xoa(txtid.Text);
                            for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
                            {
                                gridView1.SetRowCellValue(i, "idts", txtid.Text);
                                gridView1.SetRowCellValue(i, "id", txtid.Text + i);
                                tk.moi(txtid.Text + i + "1", txtdv.Text, "TS", txtid.Text, txtngaysudung.DateTime, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), Convert.ToInt32(txt1.Text), txtiddt.Text, txtiddt.Text, txtghichu.Text, txttkkh.Text, txttkng.Text, double.Parse(gridView1.GetRowCellValue(i, "nguyengia").ToString()), "KIP", 1, double.Parse(gridView1.GetRowCellValue(i, "nguyengia").ToString()), "", "", "", "Thẻ Tài Sản" /*txtloaihd.Text*/, txtidcv.Text, txtidmuccp.Text, lbltendt.Text, txtghichu.Text, 0.0);
                            }
                            //btn
                            btnmo.Enabled = true;
                            btnnew.Enabled = true;
                            btnLuu.Enabled = false;
                            btnsua.Enabled = true;
                            btnxoa.Enabled = true;
                            btnin.Enabled = true;
                            btnreload.Enabled = false;
                            //enabled
                            txtid.ReadOnly = true;
                            txtdv.ReadOnly = true;
                            txtngaysudung.ReadOnly = true;
                            txtngaymua.ReadOnly = true;
                            txtiddt.ReadOnly = true;
                            txtkhts.ReadOnly = true;
                            txtkhts.ReadOnly = true;
                            txttents.ReadOnly = true;
                            txtloaits.ReadOnly = true;
                            txtttsd.ReadOnly = true;
                            txtiddt.ReadOnly = true;
                            txtngayhetkhauhao.ReadOnly = true;
                            txtngaythanhly.ReadOnly = true;
                            txtdvt.ReadOnly = true;
                            txtppkhauhao.ReadOnly = true;
                            txtsokh.ReadOnly = true;
                            txtsl.ReadOnly = true;
                            txtlink.ReadOnly = true;
                            txtngaymua.ReadOnly = true;
                            txtidcv.ReadOnly = true;
                            txtidmuccp.ReadOnly = true;
                            txttkng.ReadOnly = true;
                            txttkcp.ReadOnly = true;
                            txttkkh.ReadOnly = true;
                            txtghichu.ReadOnly = true;
                            gridView1.OptionsBehavior.Editable = false;
                            Biencucbo.hdts = 2;
                            hs.add(txtid.Text, "Sửa Thẻ Tài Sản");
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                gridView1.UpdateCurrentRow();
                luu();
            }
            catch
            {
            }
        }
        bool LuuPhieu()
        {
            // kiem tra truoc khi luu
            layoutControl1.Validate();
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            // if(kiem tra rang buoc)
            //  return false;
            try
            {
                db.tscodinhcts.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "")
            {
                return;
            }
            //load 
            try
            {
                var lst1 = (from hd in db.tscodinhs select new { a = hd }).Single(x => x.a.id == txtid.Text);
                if (lst1 == null) return;
                txtid.ReadOnly = false;
                txtdv.ReadOnly = false;
                txtngaysudung.ReadOnly = false;
                txtngaymua.ReadOnly = false;
                txtiddt.ReadOnly = false;
                txtkhts.ReadOnly = false;
                txtkhts.ReadOnly = false;
                txttents.ReadOnly = false;
                txtloaits.ReadOnly = false;
                txtttsd.ReadOnly = false;
                txtiddt.ReadOnly = false;
                txtngayhetkhauhao.ReadOnly = false;
                txtngaythanhly.ReadOnly = false;
                txtdvt.ReadOnly = false;
                txtppkhauhao.ReadOnly = false;
                txtsokh.ReadOnly = false;
                txtsl.ReadOnly = false;
                txtlink.ReadOnly = false;
                txtngaymua.ReadOnly = false;
                txtidcv.ReadOnly = false;
                txtidmuccp.ReadOnly = false;
                txttkng.ReadOnly = false;
                txttkcp.ReadOnly = false;
                txttkkh.ReadOnly = false;
                txtghichu.ReadOnly = false;
                gcchitiet.DataSource = lst1.a.tscodinhcts;
                gridView1.OptionsBehavior.Editable = true;
                Biencucbo.hdts = 1;
                btnsua.Enabled = false;
                btnLuu.Enabled = true;
                btnmo.Enabled = false;
                btnnew.Enabled = false;
                btnxoa.Enabled = false;
                btnin.Enabled = false;
                btnreload.Enabled = true;
            }
            catch
            {
            }
        }
        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "") return;
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Thẻ tài sản " + txtid.Text + " này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                t_history hs = new t_history();
                for (int i = gridView1.DataRowCount - 1; i >= 0; i--)
                {
                    hd.xoact(gridView1.GetRowCellValue(i, "id").ToString());
                    gridView1.DeleteRow(i);
                }
                hd.xoapphieu(txtid.Text);
                hs.add(txtid.Text, "Xóa Thẻ Tài Sản");
                tk.xoa(txtid.Text);
                //btn
                btnmo.Enabled = true;
                btnnew.Enabled = true;
                btnLuu.Enabled = false;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                btnin.Enabled = true;
                btnreload.Enabled = false;
                //enabled
                txtid.ReadOnly = true;
                txtdv.ReadOnly = true;
                txtngaysudung.ReadOnly = true;
                txtngaymua.ReadOnly = true;
                txtiddt.ReadOnly = true;
                txtkhts.ReadOnly = true;
                txtkhts.ReadOnly = true;
                txttents.ReadOnly = true;
                txtloaits.ReadOnly = true;
                txtttsd.ReadOnly = true;
                txtiddt.ReadOnly = true;
                txtngayhetkhauhao.ReadOnly = true;
                txtngaythanhly.ReadOnly = true;
                txtdvt.ReadOnly = true;
                txtppkhauhao.ReadOnly = true;
                txtsokh.ReadOnly = true;
                txtsl.ReadOnly = true;
                txtlink.ReadOnly = true;
                txtngaymua.ReadOnly = true;
                txtidcv.ReadOnly = true;
                txtidmuccp.ReadOnly = true;
                txttkng.ReadOnly = true;
                txttkcp.ReadOnly = true;
                txttkkh.ReadOnly = true;
                txtghichu.ReadOnly = true;
                gridView1.OptionsBehavior.Editable = false;
                txtiddt.Text = "";
                lbltendt.Text = "";
                txtkhts.Text = "";
                txtkhts.Text = "";
                txttents.Text = "";
                txtloaits.Text = "";
                txtttsd.Text = "";
                txtiddt.Text = "";
                lbltenloaits.Text = "";
                lbltendt.Text = "";
                txtngayhetkhauhao.Text = "";
                txtngaythanhly.Text = "";
                txtdvt.Text = "";
                txtppkhauhao.Text = "";
                txtsokh.Text = "";
                txtsl.Text = "";
                txtlink.Text = "";
                txtngaymua.Text = "";
                txtidcv.Text = "";
                txtidmuccp.Text = "";
                txttkng.Text = "";
                txttkcp.Text = "";
                txttkkh.Text = "";
                txtghichu.Text = "";
            }
        }
        private void btnload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load();
            btnnew.Enabled = true;
            btnsua.Enabled = true;
            btnLuu.Enabled = false;
            btnmo.Enabled = true;
            btnxoa.Enabled = true;
            btnin.Enabled = true;
            btnreload.Enabled = false;
            gridView1.OptionsBehavior.Editable = false;
            Biencucbo.hdts = 2;
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridView1.PostEditor();
            if (e.Column.FieldName == "nguyengia" || e.Column.FieldName == "khbandau")
            {
                try
                {
                    try
                    {
                        gridView1.SetFocusedRowCellValue("gtclbd", double.Parse(gridView1.GetFocusedRowCellValue("nguyengia").ToString()) - double.Parse(gridView1.GetFocusedRowCellValue("khbandau").ToString()));
                        gridView1.SetFocusedRowCellValue("gtconlai", double.Parse(gridView1.GetFocusedRowCellValue("gtclbd").ToString()) - double.Parse(gridView1.GetFocusedRowCellValue("khluyke").ToString()));
                        gridView1.SetFocusedRowCellValue("muckhthang", double.Parse(gridView1.GetFocusedRowCellValue("gtclbd").ToString()) / double.Parse(txtsokh.Text));
                    }
                    catch
                    {
                        gridView1.SetFocusedRowCellValue("gtclbd", double.Parse(gridView1.GetFocusedRowCellValue("nguyengia").ToString()) - double.Parse(gridView1.GetFocusedRowCellValue("khbandau").ToString()));
                        gridView1.SetFocusedRowCellValue("gtconlai", double.Parse(gridView1.GetFocusedRowCellValue("gtclbd").ToString()) - double.Parse(gridView1.GetFocusedRowCellValue("khluyke").ToString()));
                        gridView1.SetFocusedRowCellValue("muckhthang", double.Parse(gridView1.GetFocusedRowCellValue("gtclbd").ToString()) / double.Parse(txtsokh.Text));
                    }
                    finally
                    {
                        gridView1.SetFocusedRowCellValue("gtclbd", double.Parse(gridView1.GetFocusedRowCellValue("nguyengia").ToString()) - double.Parse(gridView1.GetFocusedRowCellValue("khbandau").ToString()));
                        gridView1.SetFocusedRowCellValue("gtconlai", double.Parse(gridView1.GetFocusedRowCellValue("gtclbd").ToString()) - double.Parse(gridView1.GetFocusedRowCellValue("khluyke").ToString()));
                        gridView1.SetFocusedRowCellValue("muckhthang", double.Parse(gridView1.GetFocusedRowCellValue("gtclbd").ToString()) / double.Parse(txtsokh.Text));
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (Biencucbo.hdts != 2)
            //{
            //    if (e.KeyCode == Keys.Insert)
            //    {
            //        gridView1.AddNewRow();
            //    }
            //    else if (e.KeyCode == Keys.Delete)
            //    {
            //        if (Biencucbo.hdts == 1)
            //        {
            //            try
            //            {
            //                hoadonct ct = (from c in db.hoadoncts select c).Single(x => x.id == gridView1.GetFocusedRowCellValue("id").ToString());
            //                db.hoadoncts.DeleteOnSubmit(ct);
            //            }
            //            catch
            //            {
            //            }
            //        }
            //        gridView1.DeleteRow(gridView1.FocusedRowHandle);
            //    }
            //}
            //else
            //{
            //    if (e.KeyCode == Keys.F4)
            //    {
            //        Biencucbo.ma = txtid.Text;
            //        f_dinhkhoan frm = new f_dinhkhoan();
            //        frm.ShowDialog();
            //    }
            //}
        }
        private void txtiddt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                lbltendt.Text = lst.ten.ToString();
            }
            catch (Exception)
            {
            }
        }
        //add new row
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue("lydotg", "");
            gridView1.SetFocusedRowCellValue("idts", txtid.Text);
            gridView1.SetFocusedRowCellValue("nguonvon", "");
            gridView1.SetFocusedRowCellValue("ngayhieuluc", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            gridView1.SetFocusedRowCellValue("ngaykethuc", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
            gridView1.SetFocusedRowCellValue("nguyengia", 0);
            gridView1.SetFocusedRowCellValue("khbandau", 0);
            gridView1.SetFocusedRowCellValue("gtclbd", 0);
            gridView1.SetFocusedRowCellValue("muckhthang", 0);
            gridView1.SetFocusedRowCellValue("khnamnay", 0);
            gridView1.SetFocusedRowCellValue("khluyke", 0);
            gridView1.SetFocusedRowCellValue("gtconlai", 0);
        }
        private void f_hd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Biencucbo.hdts != 2)
            {
                var a = Lotus.MsgBox.ShowYesNoCancelDialog("Hoá đơn này chưa được lưu - Bạn có muốn lưu Hoá đơn này trước khi thoát không?", "THÔNG BÁO");
                if (a == DialogResult.Yes)
                {
                    luu();
                }
                else if (a == DialogResult.Cancel) e.Cancel = true;
            }
        }
        private void f_hd_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thẻ Tài Sản").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            load();
        }
        private void txtloaits_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.loaits select a).Single(t => t.id == txtloaits.Text);
                lbltenloaits.Text = lst.loaits;
            }
            catch
            {
            }
        }
        private void txtsokh_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView1.SetFocusedRowCellValue("muckhthang", double.Parse(gridView1.GetFocusedRowCellValue("gtclbd").ToString()) / double.Parse(txtsokh.Text));
            }
            catch
            {
            }
        }
        private void gcchitiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (Biencucbo.hdts != 2)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    gridView1.AddNewRow();
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);
                }
            }
            else
            {
                if (e.KeyCode == Keys.F4)
                {
                    Biencucbo.ma = txtid.Text;
                    f_dinhkhoan frm = new f_dinhkhoan();
                    frm.ShowDialog();
                }
            }
        }
    }
}
