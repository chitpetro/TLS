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
using GUI.Properties;
using DevExpress.Utils.Win;
namespace GUI
{
    public partial class f_banhang : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_hoadon hd = new t_hoadon();
        t_cttk tk = new t_cttk();

        f_banhang2 bh = new f_banhang2();

        int check = 0;
        int mahang = 0;
        int check2 = 0;
        //double checkton = 0;
        //double checksoluong = 0;
        //double checkban = 0;
        //double checktonban = 0;
        //int checkstt = 0;
        public f_banhang()
        {
            InitializeComponent();

            gia.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            try
            {
                this.KeyPreview = true;
                //var ton = (from a in db.tonbans where a.iddv == Biencucbo.donvi select a);
                //if (ton == null) return;
                //var lst = (from a in db.r_giasps where a.iddv == Biencucbo.donvi select new { id = a.idsp, tensp = a.tensp, dvt = a.dvt });
                //if (lst == null) return;
                btnmasp.DataSource = (from a in new DAL.KetNoiDBDataContext().r_giasps where a.iddv == Biencucbo.donvi select new { id = a.idsp, tensp = a.tensp, dvt = a.dvt });
                rsearchTenSP.DataSource = btnmasp.DataSource;

            }
            catch
            {
            }
            rsearchtiente.DataSource = new DAL.KetNoiDBDataContext().tientebhs;
            txttiente.Properties.DataSource = new DAL.KetNoiDBDataContext().tientebhs;
            btnthue.DataSource = new DAL.KetNoiDBDataContext().thues;
            rsearchthuesuat.DataSource = btnthue.DataSource;
            //txtmavach.Properties.DataSource = new DAL.KetNoiDBDataContext().sanphams;
            btncongviec.DataSource = new DAL.KetNoiDBDataContext().congviecs;
            txtiddt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongbhs;
            //tran
            if (Biencucbo.ngonngu.ToString() == "Vietnam")
            {
                coldiengiai.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "Tổng cộng:")});
                gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "Tổng cộng:")});
                gridColumn35.Caption = "Mã Đối Tượng";
                gridColumn36.Caption = "Tên Đối Tượng ";
                gridColumn37.Caption = "Nhóm Đối Tượng";
                gridColumn38.Caption = "Loại Đối Tượng";
                gridColumn39.Caption = "Địa Chỉ";
                gridColumn53.Caption = "Tiền tệ";
                gridColumn54.Caption = "Tỷ giá";
                gridColumn55.Caption = "Ghi chú";
                //gridColumn59.Caption = "Mã Vạch";
                //gridColumn60.Caption = "Tên Sản Phẩm";
                //gridColumn61.Caption = "ĐVT";
                gridColumn41.Caption = "Mã công việc";
                gridColumn42.Caption = "Tên công việc";
                gridColumn43.Caption = "Nhóm công việc";
                gridColumn29.Caption = "Loại thuế";
                gridColumn30.Caption = "Tên thuế";
                gridColumn31.Caption = "Thuế suất";
                gridColumn27.Caption = "Mã Sản Phẩm";
                gridColumn28.Caption = "Tên Sản Phẩm";
                gridColumn32.Caption = "ĐVT";
                gridColumn33.Caption = "Loại Sản Phẩm";
            }
            else //lao
            {
                coldiengiai.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "ລວມທັງໝົດ:")});
                gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "ລວມທັງໝົດ:")});
                gridColumn35.Caption = "ລະຫັດ";
                gridColumn36.Caption = "ຊື່ເປົ້າໝາຍ";
                gridColumn37.Caption = "ກຸ່ມເປົ້າໝາຍ";
                gridColumn38.Caption = "ປະເພດເປົ້າໝາຍ";
                gridColumn39.Caption = "ທີ່ຢູ່";
                gridColumn53.Caption = "ເງິນຕາ";
                gridColumn54.Caption = "ອັດຕາ";
                gridColumn55.Caption = "ໝາຍເຫດ";
                //gridColumn59.Caption = "ລະຫັດ";
                //gridColumn60.Caption = "ຜະລິດຕະພັນ";
                //gridColumn61.Caption = "ຫົວໜ່ວຍຄິດໄລ່";
                gridColumn41.Caption = "ລະຫັດວຽກງານ";
                gridColumn42.Caption = "ຊື່ວຽກງານ";
                gridColumn43.Caption = "ກຸ່ມໜ້າວຽກ";
                gridColumn29.Caption = "ປະເພດຂອງອາກອນ";
                gridColumn30.Caption = "ຊື່ອາກອນ";
                gridColumn31.Caption = "ອາກອນ (%)";
                gridColumn27.Caption = "ລະຫັດຜະລິດຕະພັນ";
                gridColumn28.Caption = "ຊື່ຜະລິດຕະພັນ";
                gridColumn32.Caption = "ຫົວໜ່ວຍຄິດໄລ່";
                gridColumn33.Caption = "ປະເພດ";
            }
            //lay quyen
            //var quyen1 = db.PhanQuyen2s.FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "BanHang_TaoHoaDonBanHang");
            //btnhd.Enabled = (bool)quyen1.Xem;
            //var quyen2 = db.PhanQuyen2s.FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "BanHang_PhieuXuatKho");
            //btnpxk.Enabled = (bool)quyen2.Xem;
            //var quyen3 = db.PhanQuyen2s.FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "BanHang_ThanhToan");
            //btnthanhtoan.Enabled = (bool)quyen3.Xem;
            //var quyen4 = db.PhanQuyen2s.FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "BanHang_BaoCo");
            //btnbaoco.Enabled = (bool)quyen4.Xem;
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
            Biencucbo.hdbh = 2;
            txt1.Enabled = false;
            btnLuu.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnin.Enabled = true;
            btnreload.Enabled = false;
            txtdv.ReadOnly = true;
            txtid.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            txtidnv.ReadOnly = true;
            txtphongban.ReadOnly = true;
            // Enable
            txtghichu.ReadOnly = true;
            txtmavach.ReadOnly = true;

            txtngaylap.ReadOnly = true;
            txttiente.ReadOnly = true;
            txttygia.ReadOnly = true;
            txtiddt.ReadOnly = true;
            gridView1.OptionsBehavior.Editable = false;
            try
            {
                var lst = (from a in db.banhangs where a.iddv == Biencucbo.donvi select a.so).Max();
                var lst1 = (from b in db.banhangs where b.iddv == Biencucbo.donvi select b).FirstOrDefault(t => t.so == lst);
                if (lst1 == null) return;

                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                try
                {
                    var lstnv = (from a in db.accounts select a).Single(t => t.id == txtidnv.Text);
                    lbltennv.Text = lstnv.name;
                }
                catch
                {
                    lbltennv.Text = "";
                }
                txtdv.Text = lst1.iddv;
                txtngaylap.DateTime = DateTime.Parse(lst1.ngayban.ToString());
                txtiddt.Text = lst1.iddt;
                try
                {
                    var lst2 = (from a in db.doituongbhs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    txtdiachi.Text = lst2.diachi.ToString();
                }
                catch (Exception)
                {
                    lbltendt.Text = "";
                    txtdiachi.Text = "";
                }
                txtghichu.Text = lst1.ghichu;
                txtmavach.Text = "";
                txt1.Text = lst1.so.ToString();
                txttiente.Text = lst1.tiente;
                txttygia.Text = lst1.tygia.ToString();
                gcchitiet.DataSource = lst1.banhangcts;
            }
            catch
            {
            }
        }
        //Mở
        private void btnmo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db = new KetNoiDBDataContext();
            f_dsbanhang frm = new f_dsbanhang();
            frm.ShowDialog();
            if (Biencucbo.getID == 1)
            {
                //load hoa don
                try
                {
                    var lst = (from hd in db.banhangs select new { a = hd }).FirstOrDefault(x => x.a.id == Biencucbo.ma);
                    if (lst == null) return;
                    txtid.Text = lst.a.id;
                    txtidnv.Text = lst.a.idnv;
                    try
                    {
                        var lstnv = (from a in db.accounts select a).Single(t => t.id == txtidnv.Text);
                        lbltennv.Text = lstnv.name;
                    }
                    catch
                    {
                        lbltennv.Text = "";
                    }
                    txtdv.Text = lst.a.iddv;
                    txtngaylap.DateTime = DateTime.Parse(lst.a.ngayban.ToString());
                    txtiddt.Text = lst.a.iddt;
                    try
                    {
                        var lstdt = (from a in db.doituongbhs select a).Single(t => t.id == txtidnv.Text);
                        lbltennv.Text = lstdt.ten;
                        txtdiachi.Text = lstdt.diachi;
                    }
                    catch
                    {
                        lbltendt.Text = "";
                        txtdiachi.Text = "";
                    }
                    txtghichu.Text = lst.a.ghichu;
                    txtmavach.Text = "";
                    txttiente.Text = lst.a.tiente;
                    txttygia.Text = lst.a.tygia.ToString();
                    txt1.Text = lst.a.so.ToString();
                    gcchitiet.DataSource = lst.a.banhangcts;
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

        public void themmoi()
        {
            f_dvbanhang frm = new f_dvbanhang();
            frm.ShowDialog();
            try
            {
                var lstdv = (from a in db.donvis select a).Single(t => t.id == Biencucbo.donvi);
                lbltendv.Text = lstdv.tendonvi;
            }
            catch
            {
                return;
            }
            btnmasp.DataSource = (from a in new DAL.KetNoiDBDataContext().r_giasps where a.iddv == Biencucbo.donvi select new { id = a.idsp, tensp = a.tensp, dvt = a.dvt });
            rsearchTenSP.DataSource = btnmasp.DataSource;
            Biencucbo.hdbh = 0;
            txtid.DataBindings.Clear();
            txtid.Text = "YYYYY";
            check2 = 0;
            gcchitiet.DataSource = new DAL.KetNoiDBDataContext().View_banhangs;
            for (int i = 0; i <= gridView1.RowCount - 1; i++)
            {
                gridView1.DeleteRow(i);
            }
            //gridView1.AddNewRow();
            txtdv.Text = Biencucbo.donvi;
            txtngaylap.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtphongban.Text = Biencucbo.phongban;
            txtidnv.Text = Biencucbo.idnv.Trim();
            lbltennv.Text = Biencucbo.ten;
            //txtngaylap.Focus();
            lbltendt.Text = "";
            txtiddt.Text = "KH_01";
            try
            {
                var lst = (from a in db.doituongbhs select a).Single(t => t.id == txtiddt.Text);
                lbltendt.Text = lst.ten.ToString();
                txtdiachi.Text = lst.diachi.ToString();
            }
            catch (Exception)
            {
                //lbltendt.Text = "";
                //txtdiachi.Text = "";
            }
            txtghichu.Text = "";
            txtmavach.Text = "";
            txttiente.Text = "KIP";
            txttygia.Text = "1";
            txtmavach.Focus();
            txtmavach.SelectAll();
            //btn
            btnnew.Enabled = false;
            btnmo.Enabled = false;
            btnLuu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnin.Enabled = false;
            btnreload.Enabled = false;
            //enabled
            txtghichu.ReadOnly = false;
            txtmavach.ReadOnly = false;

            txtngaylap.ReadOnly = false;
            txtiddt.ReadOnly = false;
            txttiente.ReadOnly = false;
            txttygia.ReadOnly = true;
            gridView1.OptionsBehavior.Editable = true;


            if (Biencucbo.hdbh == 0)
            {
                bh.truyenxoaall();
                bh.truyendt(txtiddt.Text);
            }
            txtmavach.Focus();

        }
        private void btnnew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themmoi();
        }

        public void luu()
        {
            t_history hs = new t_history();
            t_tudong td = new t_tudong();

            chondoituongbh frm = new chondoituongbh();
            frm.ShowDialog();
            txtiddt.Properties.DataSource = new KetNoiDBDataContext().doituongbhs;
            txtiddt.Text = Biencucbo.doituong;
            bh.truyendt(txtiddt.Text);

            //double mua = 0;
            //double ban = 0;
            gridView1.UpdateCurrentRow();
            int check1 = 0;
            if (txtngaylap.Text == "" || txtiddt.Text == "" || txttiente.Text == "" || txttygia.Text == "")
            {
                Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                try
                {
                    for (int i = 0; i <= gridView1.RowCount - 1; i++)
                    {
                        //re-check
                        if (gridView1.GetRowCellValue(i, "soluong").ToString() == "" || gridView1.GetRowCellValue(i, "dongia").ToString() == "" || gridView1.GetRowCellValue(i, "chietkhau").ToString() == "")
                        {
                            check1 = 1;
                        }
                        else if (gridView1.GetRowCellValue(i, "idsanpham").ToString() == "")
                        {

                            check1 = 2;
                        }
                    }
                }
                catch (Exception)
                {
                }
                if (check1 == 1)
                {
                    Lotus.MsgBox.ShowErrorDialog("Thông tin chi tiết sản phẩm chưa đầy đủ - Vui Lòng Kiểm Tra Lại");
                }
                else if (check1 == 2)
                {
                    Lotus.MsgBox.ShowErrorDialog("Mã sản phẩm không được để trống - Vui Lòng Kiểm Tra Lại");
                }
                else
                {
                    if (Biencucbo.hdbh == 0)
                    {
                        db = new KetNoiDBDataContext();
                        try
                        {
                            string check = "BH" + Biencucbo.donvi.Trim().ToString();
                            var lst1 = (from s in db.tudongs where s.maphieu == check select new { so = s.so }).ToList();
                            if (lst1.Count == 0)
                            {
                                int so;
                                so = 2;
                                td.themtudong(check, so, "BH", "Phiếu Bán Hàng");
                                txtid.Text = check + "_000001";
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
                            hd.moibh(txtid.Text, txtngaylap.DateTime, txtiddt.Text, txtidnv.Text, txtdv.Text, txtghichu.Text, Convert.ToInt32(txt1.Text), txttiente.Text, double.Parse(txttygia.Text));
                            for (int i = 0; i <= gridView1.RowCount - 1; i++)
                            {
                                gridView1.SetRowCellValue(i, "idbanhang", txtid.Text);
                                gridView1.SetRowCellValue(i, "id", txtid.Text + i);
                                hd.moibhct(gridView1.GetRowCellValue(i, "idbanhang").ToString(), gridView1.GetRowCellValue(i, "idsanpham").ToString(), gridView1.GetRowCellValue(i, "diengiai").ToString(), double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString()), double.Parse(gridView1.GetRowCellValue(i, "dongia").ToString()), gridView1.GetRowCellValue(i, "loaithue").ToString(), double.Parse(gridView1.GetRowCellValue(i, "thue").ToString()), double.Parse(gridView1.GetRowCellValue(i, "chietkhau").ToString()), double.Parse(gridView1.GetRowCellValue(i, "thanhtien").ToString()), gridView1.GetRowCellValue(i, "id").ToString(), double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()));

                            }

                            btnmo.Enabled = true;
                            btnnew.Enabled = true;
                            btnLuu.Enabled = false;
                            btnsua.Enabled = true;
                            btnxoa.Enabled = true;
                            btnin.Enabled = true;
                            btnreload.Enabled = false;
                            //enabled
                            txtghichu.ReadOnly = true;
                            txtmavach.ReadOnly = true;

                            txtngaylap.ReadOnly = true;
                            txtiddt.ReadOnly = true;
                            txttiente.ReadOnly = true;
                            txttygia.ReadOnly = true;
                            gridView1.OptionsBehavior.Editable = false;
                            Biencucbo.hdbh = 2;
                            // History
                            hs.add(txtid.Text, "Thêm mới Bán hàng");
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
                            hd.suabh(txtid.Text, DateTime.Parse(txtngaylap.Text), txtiddt.Text, txtghichu.Text, int.Parse(txt1.Text), txttiente.Text, double.Parse(txttygia.Text));
                            //sua ct
                            LuuPhieu();

                            //btn
                            btnmo.Enabled = true;
                            btnnew.Enabled = true;
                            btnLuu.Enabled = false;
                            btnsua.Enabled = true;
                            btnxoa.Enabled = true;
                            btnin.Enabled = true;
                            btnreload.Enabled = false;
                            //enabled
                            txtghichu.ReadOnly = true;
                            txtmavach.ReadOnly = true;

                            txtngaylap.ReadOnly = true;
                            txtiddt.ReadOnly = true;
                            txttiente.ReadOnly = true;
                            txttygia.ReadOnly = true;
                            gridView1.OptionsBehavior.Editable = false;
                            Biencucbo.hdbh = 2;
                            hs.add(txtid.Text, "Sửa Bán Hàng");
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
            
                if (ks.check(txtngaylap.DateTime))
                    return;
           
            gridView1.PostEditor();
            luu();
            if (Biencucbo.hdbh == 0)
            {
                bh.truyenxoaall();
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
                var c1 = db.banhangs.Context.GetChangeSet();
                db.banhangcts.Context.SubmitChanges();
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
            if (ks.check(txtngaylap.DateTime))
                return;
            if (ks.check(txtngaylap.DateTime))
                return;
            if (txtid.Text == "") return;
            check2 = 0;
            var check1 = (from a in db.banhangs
                          join b in db.thutienbanhangs on a.id equals b.id
                          where a.id == txtid.Text
                          select b);
            if (check1.Count() != 0)
            {
                XtraMessageBox.Show("Không thể thao tác vì có sự liên kết - kiểm tra phiếu Thu: " + check1.FirstOrDefault().id);
                return;
            }
            var check = (from a in db.banhangs
                         join b in db.hoadons on a.id equals b.link
                         where a.id == txtid.Text
                         select b);
            if (check.Count() == 0)
            {
                try
                {
                    var lst = (from pn in db.banhangs select pn).Single(x => x.id == txtid.Text);
                    if (lst == null) return;
                    gcchitiet.DataSource = lst.banhangcts;
                    //enabled
                    txtghichu.ReadOnly = false;
                    txtmavach.ReadOnly = false;

                    txtngaylap.ReadOnly = false;
                    txtiddt.ReadOnly = false;
                    txttiente.ReadOnly = false;
                    txttygia.ReadOnly = true;
                    gridView1.OptionsBehavior.Editable = true;
                    Biencucbo.hdbh = 1;
                    txtghichu.Focus();
                    // btn
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
            else
            {
                XtraMessageBox.Show("Không thể thao tác vì có sự liên kết - kiểm tra phiếu " + check.FirstOrDefault().id);
            }
            //load 
        }
        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ks.check(txtngaylap.DateTime))
                return;
            tk.xoa(txtid.Text);
            var check1 = (from a in db.banhangs
                          join b in db.thutienbanhangs on a.id equals b.diengiai
                          where a.id == txtid.Text
                          select b);
            if (check1.Count() != 0)
            {
                XtraMessageBox.Show("Không thể thao tác vì có sự liên kết - kiểm tra phiếu Thu " + check1.FirstOrDefault().id);
                return;
            }
            var check = (from a in db.banhangs
                         join b in db.hoadons on a.id equals b.link
                         where a.id == txtid.Text
                         select b);
            if (check.Count() == 0)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Phiếu Bán Hàng " + txtid.Text + " không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    t_history hs = new t_history();
                    hs.add(txtid.Text, "Xóa Bán Hàng");
                    for (int i = gridView1.DataRowCount - 1; i >= 0; i--)
                    {
                        hd.xoabhct(gridView1.GetRowCellValue(i, "id").ToString());
                        gridView1.DeleteRow(i);
                    }
                    hd.xoabh(txtid.Text);
                    //btn
                    btnmo.Enabled = true;
                    btnnew.Enabled = true;
                    btnLuu.Enabled = false;
                    btnsua.Enabled = true;
                    btnxoa.Enabled = true;
                    btnin.Enabled = true;
                    btnreload.Enabled = false;
                    //enabled
                    txtghichu.ReadOnly = true;
                    txtmavach.ReadOnly = true;

                    txtngaylap.ReadOnly = true;
                    txtiddt.ReadOnly = true;
                    txttiente.ReadOnly = true;
                    txttygia.ReadOnly = true;
                    gridView1.OptionsBehavior.Editable = false;
                    txtdv.Text = "";
                    txtid.Text = "";
                    txtidnv.Text = "";
                    txtdv.Text = "";
                    txtngaylap.Text = "";
                    txtiddt.Text = "";
                    txtghichu.Text = "";
                    txtmavach.Text = "";
                    txt1.Text = "";
                    lbltendt.Text = "";
                    lbltennv.Text = "";
                    txttiente.Text = "";
                    txttygia.Text = "";
                }
            }
            else
            {
                XtraMessageBox.Show("Không thể thao tác vì có sự liên kết - kiểm tra phiếu " + check.FirstOrDefault().id);
            }
        }
        public static double _kip = 0, _usd = 0, _bath = 0, _vnd = 0;
        //public string laydv(string ab)
        //{
        //    string b = "";
        //    var lst = (from a in db.donvis select a).Single(t => t.id == ab);
        //    b = lst.tendonvi.ToString();
        //    return b;
        //}

        private void btnin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lst = (from a in db.r_pbanhangs
                       where a.id == txtid.Text
                       select new
                       {
                           a.id,
                           a.ngayban,
                           iddv = a.tendonvi,
                           iddt = a.ten,
                           a.idnv,
                           a.soluong,
                           a.dongia,
                           tensp = a.idsanpham,
                           a.chietkhau,
                           a.thanhtien,
                           pos = a.pos,

                       }).GroupBy(t => new { t.id, t.ngayban, t.iddv, t.idnv, t.dongia, t.iddt, t.tensp, t.pos }).Select(a => new
                       {
                           a.Key.id,
                           a.Key.ngayban,
                           a.Key.iddv,
                           a.Key.idnv,
                           a.Key.iddt,
                           soluong = a.Sum(t => t.soluong),
                           a.Key.dongia,
                           a.Key.tensp,
                           chietkhau = a.Sum(t => t.chietkhau),
                           thanhtien = a.Sum(t => t.thanhtien),
                           a.Key.pos,
                       });
            var snt = lst.ToList().Sum(t => t.thanhtien);

            double st = double.Parse(snt.Value.ToString());
            var list_tiente = (from a in db.tientebhs
                               select new data_tiente()
                               {
                                   tiente1 = a.tiente,
                                   tygia = a.tygia
                               }).ToList();
            for (int i = 0; i < list_tiente.Count(); i++)
            {
                var row1 = list_tiente.ElementAt(i) as data_tiente;
                if (row1.tiente1 == "KIP")
                    _kip = st / Convert.ToDouble(row1.tygia);
                if (row1.tiente1 == "USD")
                    _usd = st / Convert.ToDouble(row1.tygia);
                if (row1.tiente1 == "BATH")
                    _bath = st / Convert.ToDouble(row1.tygia);
                if (row1.tiente1 == "VND")
                    _vnd = st / Convert.ToDouble(row1.tygia);
            }


            //get all the screen width and heights 
            r_hoadon xtra = new r_hoadon();
            xtra.DataSource = lst;
            xtra.ShowPrintStatusDialog = false;
            xtra.ShowPrintMarginsWarning = false;
            xtra.ShowPreview();
        }
        private void btnload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdbh == 1)
            {
                db = new KetNoiDBDataContext();
                var lst = (from pn in db.banhangs select pn).FirstOrDefault(x => x.id == txtid.Text);
                if (lst == null) return;
                //db.Refresh(RefreshMode.OverwriteCurrentValues, db.hoadoncts);

                txtidnv.Text = lst.idnv;
                try
                {
                    var lstnv = (from a in db.accounts select a).Single(t => t.id == txtidnv.Text);
                    lbltennv.Text = lstnv.name;
                }
                catch
                {
                    lbltennv.Text = "";
                }
                txtdv.Text = lst.iddv;
                txtngaylap.DateTime = DateTime.Parse(lst.ngayban.ToString());
                txtiddt.Text = lst.iddt;
                txtghichu.Text = lst.ghichu;
                txtmavach.Text = "";
                txt1.Text = lst.so.ToString();
                txttiente.Text = lst.tiente;
                txttygia.Text = lst.tygia.ToString();
                //gcchitiet.DataSource = lst.banhangcts;
                gcchitiet.DataSource = lst.banhangcts;
                //btn
                btnnew.Enabled = true;
                btnsua.Enabled = true;
                btnLuu.Enabled = false;
                btnmo.Enabled = true;
                btnxoa.Enabled = true;
                btnin.Enabled = true;
                btnreload.Enabled = false;
                gridView1.OptionsBehavior.Editable = false;
            }
            else if (Biencucbo.hdbh == 0)
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
            }
            Biencucbo.hdbh = 2;
        }
        private void btnmasp_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                var lst = new DAL.KetNoiDBDataContext().r_giasps;
                string bc = gridView1.GetFocusedRowCellValue("idsanpham").ToString();
                var ab = (from a in lst where a.iddv == Biencucbo.donvi select a);
                var abc = (from a in lst where a.iddv == Biencucbo.donvi && a.idsp == gridView1.GetFocusedRowCellValue("idsanpham").ToString() select a);
                var lst2 = (from a in lst where a.iddv == Biencucbo.donvi select a).Single(t => t.idsp == gridView1.GetFocusedRowCellValue("idsanpham").ToString());
                //gridView1.SetFocusedRowCellValue("dongia", double.Parse(lst2.giaban.ToString()));
                //gridView1.SetFocusedRowCellValue("chietkhau", double.Parse(lst2.chietkhau.ToString()));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridView1.PostEditor();
            if (e.Column.FieldName == "idsanpham" || e.Column.FieldName == "soluong")
            {

                try
                {
                    if (Biencucbo.hdbh == 0)
                    {
                        bh.truyensuact(gridView1.GetFocusedRowCellValue("idsanpham").ToString(), double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString()), gridView1.FocusedRowHandle);

                    }
                }
                catch
                {

                }

            }
            if (e.Column.FieldName == "dongia")
            {
                int abc = gridView1.FocusedRowHandle;
                try
                {
                    var lst = (from a in db.r_giasps where a.iddv == Biencucbo.donvi select a).Single(t => t.idsp == gridView1.GetFocusedRowCellValue("idsanpham").ToString());
                    gridView1.SetFocusedRowCellValue("chietkhau", double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()) * lst.chietkhau / 100);
                    if (Biencucbo.hdbh == 0)
                    {
                        bh.truyensuact2(double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()), double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString()), gridView1.FocusedRowHandle);
                    }
                }
                catch
                {

                }
            }


            if (e.Column.FieldName == "soluong" || e.Column.FieldName == "dongia" || e.Column.FieldName == "chietkhau" || e.Column.FieldName == "loaithue" || e.Column.FieldName == "tygia")
            {
                try
                {
                    try
                    {
                        gridView1.SetFocusedRowCellValue("thue", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) * double.Parse(gridView1.GetFocusedRowCellValue("loaithue").ToString()) / 100);
                    }
                    catch
                    {
                        gridView1.SetFocusedRowCellValue("nguyente", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) + double.Parse(gridView1.GetFocusedRowCellValue("thue").ToString()));
                    }
                    finally
                    {
                        gridView1.SetFocusedRowCellValue("thue", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) * double.Parse(gridView1.GetFocusedRowCellValue("loaithue").ToString()) / 100);
                        gridView1.SetFocusedRowCellValue("nguyente", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) + double.Parse(gridView1.GetFocusedRowCellValue("thue").ToString()));
                    }
                }
                catch (Exception)
                {
                }
            }
            else if (e.Column.FieldName == "nguyente")
            {
                try
                {
                    gridView1.SetFocusedRowCellValue("thanhtien", (double.Parse(gridView1.GetFocusedRowCellValue("nguyente").ToString())) * (double.Parse(txttygia.Text)));
                }
                catch (Exception)
                {
                }
            }


        }


        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Biencucbo.hdbh != 2)
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
                    if (Biencucbo.hdbh == 2)
                        return;
                    try
                    {
                        gridView1.PostEditor();
                        luu();
                        Biencucbo.ma = txtid.Text;
                        Biencucbo.ngaynhap = txtngaylap.DateTime;
                        f_thutienbanhang frm = new f_thutienbanhang();
                        frm.ShowDialog();
                        var lst = (from a in db.r_pbanhangs
                                   where a.id == txtid.Text
                                   select new
                                   {
                                       a.id,
                                       a.ngayban,
                                       iddv = a.tendonvi,
                                       iddt = a.ten,
                                       a.idnv,
                                       a.soluong,
                                       a.dongia,
                                       tensp = a.idsanpham,
                                       a.chietkhau,
                                       a.thanhtien,
                                       pos = a.pos,

                                   }).GroupBy(t => new { t.id, t.ngayban,t.iddv, t.idnv, t.dongia, t.iddt, t.tensp, t.pos }).Select(a => new
                                   {
                                       a.Key.id,
                                       a.Key.ngayban,
                                       a.Key.iddv,
                                       a.Key.idnv,
                                       a.Key.iddt,
                                       soluong = a.Sum(t => t.soluong),
                                       a.Key.dongia,
                                       a.Key.tensp,
                                       chietkhau = a.Sum(t => t.chietkhau),
                                       thanhtien = a.Sum(t => t.thanhtien),
                                       a.Key.pos,
                                   });
                        var snt = lst.ToList().Sum(t => t.thanhtien);

                        double st = double.Parse(snt.Value.ToString());
                        var list_tiente = (from a in db.tientebhs
                                           select new data_tiente()
                                           {
                                               tiente1 = a.tiente,
                                               tygia = a.tygia
                                           }).ToList();
                        for (int i = 0; i < list_tiente.Count(); i++)
                        {
                            var row1 = list_tiente.ElementAt(i) as data_tiente;
                            if (row1.tiente1 == "KIP")
                                _kip = st / Convert.ToDouble(row1.tygia);
                            if (row1.tiente1 == "USD")
                                _usd = st / Convert.ToDouble(row1.tygia);
                            if (row1.tiente1 == "BATH")
                                _bath = st / Convert.ToDouble(row1.tygia);
                            if (row1.tiente1 == "VND")
                                _vnd = st / Convert.ToDouble(row1.tygia);
                        }


                        //get all the screen width and heights 
                        r_hoadon xtra = new r_hoadon();
                        xtra.DataSource = lst;
                        xtra.ShowPrintStatusDialog = false;
                        xtra.ShowPrintMarginsWarning = false;
                        xtra.Print();
                        xtra.Print();
                        xtra.Print();
                        if (Biencucbo.hdbh == 0)
                        {
                            bh.truyenxoaall();
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
        private void txtiddt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.doituongbhs select a).Single(t => t.id == txtiddt.Text);
                lbltendt.Text = lst.ten.ToString();
                txtdiachi.Text = lst.diachi.ToString();

                if (Biencucbo.hdbh == 0)
                {
                    bh.truyendt(txtiddt.Text);
                }
                txtmavach.Focus();

            }
            catch (Exception)
            {
            }
        }
        private void btnthue_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }
        //add new row
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (check2 == 1)
            {
                if (Biencucbo.hdbh == 1)
                {
                    var ct = gridView1.GetFocusedRow() as banhangct;
                    if (ct == null) return;
                    int i = 0, k = 0;
                    string a;
                    k = gridView1.DataRowCount;
                    a = txtid.Text + k;
                    for (i = 0; i <= gridView1.DataRowCount - 1;)
                    {
                        if (a == gridView1.GetRowCellValue(i, "id").ToString())
                        {
                            k = k + 1;
                            a = txtid.Text + k;
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    ct.idbanhang = txtid.Text;
                    ct.soluong = 1;
                    ct.idsanpham = txtmavach.Text;
                    //ct.chietkhau = 0;
                    ct.diengiai = "";
                    ct.loaithue = "";
                    ct.idcv = "";
                    ct.thue = 0;
                    ct.thanhtien = 0;
                    ct.id = a;
                    ct.loaithue = "VAT";
                    ct.tiente = "KIP";
                    ct.tygia = 1;
                    ct.nguyente = 0;

                }
                else
                {
                    if (Biencucbo.hdbh == 0)
                    {
                        bh.truyenthemct();
                    }
                    gridView1.SetFocusedRowCellValue("id", mahang.ToString());
                    mahang = mahang + 1;
                    gridView1.SetFocusedRowCellValue("diengiai", "");
                    gridView1.SetFocusedRowCellValue("idsanpham", txtmavach.Text);
                    gridView1.SetFocusedRowCellValue("soluong", Biencucbo.soluong);
                    gridView1.SetFocusedRowCellValue("dongia", Biencucbo.dongia);
                    gridView1.SetFocusedRowCellValue("thue", 0);
                    gridView1.SetFocusedRowCellValue("tygia", 1);
                    gridView1.SetFocusedRowCellValue("loaithue", "VAT");

                }
            }
            else
            {
                if (Biencucbo.hdbh == 1)
                {

                    var ct = gridView1.GetFocusedRow() as banhangct;
                    if (ct == null) return;
                    int i = 0, k = 0;
                    string a;
                    k = gridView1.DataRowCount;
                    a = txtid.Text + k;
                    for (i = 0; i <= gridView1.DataRowCount - 1;)
                    {
                        if (a == gridView1.GetRowCellValue(i, "id").ToString())
                        {
                            k = k + 1;
                            a = txtid.Text + k;
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    ct.idbanhang = txtid.Text;
                    ct.soluong = 1;
                    ct.idsanpham = "";
                    //ct.chietkhau = 0;
                    ct.diengiai = "";
                    ct.loaithue = "";
                    ct.idcv = "";
                    ct.thue = 0;
                    ct.thanhtien = 0;
                    ct.id = a;
                    ct.loaithue = "VAT";
                    ct.tiente = "KIP";
                    ct.tygia = 1;
                    ct.nguyente = 0;
                }
                else
                {
                    if (Biencucbo.hdbh == 0)
                    {
                        bh.truyenthemct();
                    }
                    gridView1.SetFocusedRowCellValue("diengiai", "");
                    gridView1.SetFocusedRowCellValue("id", mahang.ToString());
                    mahang = mahang + 1;
                    //gridView1.SetFocusedRowCellValue("idsanpham", "");
                    gridView1.SetFocusedRowCellValue("soluong", 1);
                    gridView1.SetFocusedRowCellValue("thue", 0);
                    gridView1.SetFocusedRowCellValue("tygia", 1);
                    gridView1.SetFocusedRowCellValue("loaithue", "VAT");

                }
            }
            gridView1.PostEditor();
            check2 = 0;
        }
        private void f_hd_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (Biencucbo.hdbh != 2)
            //{
            //    var a = Lotus.MsgBox.ShowYesNoCancelDialog("Phiếu Bán hàng này chưa được lưu - Bạn có muốn lưu Phiếu này trước khi thoát không?", "THÔNG BÁO");
            //    if (a == DialogResult.Yes)
            //    {
            //        luu();
            //    }
            //    else if (a == DialogResult.Cancel) e.Cancel = true;
            //}
            bh.Close();
        }
        private void rsearchtiente_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
            try
            {
                var lst = (from a in db.tientebhs select a).Single(t => t.tiente == gridView1.GetFocusedRowCellValue("tiente").ToString());
                if (lst == null) return;
                gridView1.SetFocusedRowCellValue("tygia", lst.tygia);
            }
            catch
            {
            }
        }
        private void btnIdSp_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }
        private void f_hd_Load(object sender, EventArgs e)
        {

            //Screen[] screens = Screen.AllScreens;



            bh.Show();

            //bh.Location = Screen.AllScreens[1].WorkingArea.Location;
            //WindowState = FormWindowState.Maximized;



            // no larger than screen size
            //this.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, (int)System.Windows.SystemParameters.PrimaryScreenHeight);
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Bán hàng").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            load();
        }
        private void btnthanhtoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdbh == 0 || Biencucbo.hdbh == 1)
                return;
            Biencucbo.thanhtoan = txtid.Text;
            Biencucbo.iddt = txtiddt.Text;
            f_hd_khach frm = new f_hd_khach();
            frm.ShowDialog();
        }
        private void txttiente_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.tientebhs select a).FirstOrDefault(t => t.tiente == txttiente.Text);
                txttygia.Text = lst.tygia.ToString();
                for (int i = 0; i <= gridView1.RowCount - 1; i++)
                {
                    try
                    {
                        gridView1.SetRowCellValue(i, "thanhtien", double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()) * double.Parse(txttygia.Text));
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        private void gia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            f_giasp form = new f_giasp();
            form.ShowDialog();
            var lst = new DAL.KetNoiDBDataContext().r_giasps;
            try
            {
                var lst2 = (from a in lst where a.iddv == Biencucbo.donvi select new { id = a.idsp, tensp = a.tensp, dvt = a.dvt });
                if (lst2 == null) return;
                btnmasp.DataSource = lst2;
                rsearchTenSP.DataSource = btnmasp.DataSource;

            }
            catch
            {
            }
        }
        private void txtsl_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtsl.Text != "")
            //    {
            //        if (check == 0)
            //        {
            //            return;
            //        }
            //        var lst = from a in db.r_giasps where a.idsp == txtmavach.Text select a;
            //        if (lst.Count() == 0)
            //            return;
            //        check2 = 1;
            //        gridView1.AddNewRow();
            //        gridView1.PostEditor();
            //        txtmavach.Text = "";
            //        txtsl.Text = "";
            //        txtmavach.Focus();
            //        check = 0;
            //    }
            //}
        }
        //btn phieu xuat kho
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdbh == 0 || Biencucbo.hdbh == 1)
                return;
            Biencucbo.thanhtoan = txtid.Text;
            Biencucbo.iddt = txtiddt.Text;
            f_pxuatbh frm = new f_pxuatbh();
            frm.ShowDialog();
        }
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdbh == 0 || Biencucbo.hdbh == 1)
                return;
            Biencucbo.thanhtoan = txtid.Text;
            f_pthu_tt2 frm = new f_pthu_tt2();
            frm.ShowDialog();
        }
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdbh == 0 || Biencucbo.hdbh == 1)
                return;
            Biencucbo.thanhtoan = txtid.Text;
            f_baocott2 frm = new f_baocott2();
            frm.ShowDialog();
        }
        private void btnchoose_Click(object sender, EventArgs e)
        {
            txtmavach.ReadOnly = false;
            txtmavach.Text = "";
            //txtsl.Focus();
        }
        private void txtmavach_KeyDown(object sender, KeyEventArgs e)



        {
            if (e.KeyCode == Keys.Enter)
            {
                string abc = txtmavach.Text;
                if (txtmavach.Text != "")
                {
                    try
                    {
                        var lst = (from a in db.sanphams where a.id == abc select a);
                        if (lst.Count() == 0)
                        {
                            MessageBox.Show("Sản phẩm này chưa được đưa vào danh mục-Vui lòng kiểm tra lại!", "Thông Báo");
                            txtmavach.Text = "";
                            return;
                        }
                        var lst2 = from a in db.r_giasps where a.idsp == txtmavach.Text && a.iddv == Biencucbo.donvi select a;
                        if (lst2.Count() == 0)
                        {
                            MessageBox.Show("Sản phẩm này chưa được quy định giá bán-Vui lòng kiểm tra lại!", "Thông Báo");
                            txtmavach.Text = "";
                            return;
                        }

                        var lst3 = (from a in db.r_giasps select a).Single(t => t.idsp == abc);
                        lbltensp.Text = lst3.tensp;
                        f_bhdongia frm = new f_bhdongia();
                        frm.ShowDialog();
                        check2 = 1;
                        gridView1.AddNewRow();
                        check2 = 0;
                        gridView1.PostEditor();
                        gridView1.UpdateCurrentRow();
                        txtmavach.Text = "";
                        lbltensp.Text = "";
                        txtmavach.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {

                    check = 0;
                }
            }
        }
        private void f_banhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Biencucbo.hdbh == 2)
                {
                    themmoi();
                }
            }

            if (e.KeyCode == Keys.F2)
            {
                if (Biencucbo.hdbh != 2)
                {
                    txtmavach.Focus();
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                if (Biencucbo.hdbh != 2)
                {
                    txtiddt.Focus();
                }
            }

            if (e.KeyCode == Keys.F4)
            {
                if (Biencucbo.hdbh == 2)
                    return;
                try
                {
                    gridView1.PostEditor();
                    luu();
                    Biencucbo.ma = txtid.Text;
                    Biencucbo.ngaynhap = txtngaylap.DateTime;
                    f_thutienbanhang frm = new f_thutienbanhang();
                    frm.ShowDialog();
                    var lst = (from a in db.r_pbanhangs
                               where a.id == txtid.Text
                               select new
                               {
                                   a.id,
                                   a.ngayban,
                                   iddv = a.tendonvi,
                                   a.idnv,
                                   iddt = a.ten,
                                   a.soluong,
                                   a.dongia,
                                   tensp = a.idsanpham,
                                   a.chietkhau,
                                   a.thanhtien,
                                   pos = a.pos,

                               }).GroupBy(t => new { t.id,t.ngayban, t.iddv, t.idnv, t.iddt, t.dongia, t.tensp, t.pos }).Select(a => new
                               {
                                   a.Key.id,
                                   a.Key.ngayban,
                                   a.Key.iddv,
                                   a.Key.idnv,
                                   a.Key.iddt,
                                   soluong = a.Sum(t => t.soluong),
                                   a.Key.dongia,
                                   a.Key.tensp,
                                   chietkhau = a.Sum(t => t.chietkhau),
                                   thanhtien = a.Sum(t => t.thanhtien),
                                   a.Key.pos,
                               });
                    var snt = lst.ToList().Sum(t => t.thanhtien);

                    double st = double.Parse(snt.Value.ToString());
                    var list_tiente = (from a in db.tientebhs
                                       select new data_tiente()
                                       {
                                           tiente1 = a.tiente,
                                           tygia = a.tygia
                                       }).ToList();
                    for (int i = 0; i < list_tiente.Count(); i++)
                    {
                        var row1 = list_tiente.ElementAt(i) as data_tiente;
                        if (row1.tiente1 == "KIP")
                            _kip = st / Convert.ToDouble(row1.tygia);
                        if (row1.tiente1 == "USD")
                            _usd = st / Convert.ToDouble(row1.tygia);
                        if (row1.tiente1 == "BATH")
                            _bath = st / Convert.ToDouble(row1.tygia);
                        if (row1.tiente1 == "VND")
                            _vnd = st / Convert.ToDouble(row1.tygia);
                    }


                    //get all the screen width and heights 
                    r_hoadon xtra = new r_hoadon();
                    xtra.DataSource = lst;
                    xtra.ShowPrintStatusDialog = false;
                    xtra.ShowPrintMarginsWarning = false;
                    xtra.Print();
                    xtra.Print();
                    xtra.Print();
                    if (Biencucbo.hdbh == 0)
                    {
                        bh.truyenxoaall();
                    }
                }
                catch
                {

                }

            }
            if (e.Control && e.KeyCode == Keys.P)
            {

            }
        }


        private void btnlui_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //previous
            if (Biencucbo.hdbh != 2)
                return;
            try
            {
                var so = (from pn in db.banhangs where pn.iddv == txtdv.Text && pn.so < int.Parse(txt1.Text) select pn.so).Max();
                var lst1 = (from pn in db.banhangs where pn.iddv == txtdv.Text select pn).FirstOrDefault(x => x.so == so);
                if (lst1 == null) return;

                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                try
                {
                    var lstnv = (from a in db.accounts select a).Single(t => t.id == txtidnv.Text);
                    lbltennv.Text = lstnv.name;
                }
                catch
                {
                    lbltennv.Text = "";
                }
                txtdv.Text = lst1.iddv;
                txtngaylap.DateTime = DateTime.Parse(lst1.ngayban.ToString());
                txtiddt.Text = lst1.iddt;
                try
                {
                    var lst2 = (from a in db.doituongbhs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    txtdiachi.Text = lst2.diachi.ToString();
                }
                catch (Exception)
                {
                }
                txtghichu.Text = lst1.ghichu;
                txtmavach.Text = "";
                txt1.Text = lst1.so.ToString();
                txttiente.Text = lst1.tiente;
                txttygia.Text = lst1.tygia.ToString();
                gcchitiet.DataSource = lst1.banhangcts;
            }
            catch
            {
            }
        }
        private void txttiente_Click(object sender, EventArgs e)
        {
        }
        private void txttiente_Popup(object sender, EventArgs e)
        {
            IPopupControl popupControl = sender as IPopupControl;
            SimpleButton button = new SimpleButton()
            {
                Image = Resources.icons8_Add_File_16,
                Text = "Edit",
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            };
            button.Click += new EventHandler(button_Click);
            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();
        }
        public void button_Click(object sender, EventArgs e)
        {
            f_tiente2 frm = new f_tiente2();
            frm.ShowDialog();
            txttiente.Properties.DataSource = new KetNoiDBDataContext().tientebhs;
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
            button.Click += new EventHandler(buttondt_Click);
            button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
            popupControl.PopupWindow.Controls.Add(button);
            button.BringToFront();
        }
        public void buttondt_Click(object sender, EventArgs e)
        {
            f_doituongbh frm = new f_doituongbh();
            frm.ShowDialog();
            txtiddt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongbhs;
        }
        private void btntien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // next	
            if (Biencucbo.hdbh != 2)
                return;
            try
            {
                var so = (from pn in db.banhangs where pn.iddv == txtdv.Text && pn.so > int.Parse(txt1.Text) select pn.so).Min();
                var lst1 = (from pn in db.banhangs where pn.iddv == txtdv.Text select pn).FirstOrDefault(x => x.so == so);
                if (lst1 == null) return;

                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                try
                {
                    var lstnv = (from a in db.accounts select a).Single(t => t.id == txtidnv.Text);
                    lbltennv.Text = lstnv.name;
                }
                catch
                {
                    lbltennv.Text = "";
                }
                txtdv.Text = lst1.iddv;
                txtngaylap.DateTime = DateTime.Parse(lst1.ngayban.ToString());
                txtiddt.Text = lst1.iddt;
                try
                {
                    var lst2 = (from a in db.doituongbhs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    txtdiachi.Text = lst2.diachi.ToString();
                }
                catch (Exception)
                {
                }
                txtghichu.Text = lst1.ghichu;
                txtmavach.Text = "";
                txt1.Text = lst1.so.ToString();
                txttiente.Text = lst1.tiente;
                txttygia.Text = lst1.tygia.ToString();
                gcchitiet.DataSource = lst1.banhangcts;
            }
            catch
            {
            }
        }
        private void btnlast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // last
            if (Biencucbo.hdbh != 2)
                return;
            try
            {
                var lsta = (from a in db.banhangs where a.iddv == txtdv.Text select a).Max(t => t.so);
                var lst1 = (from pn in db.banhangs where pn.iddv == txtdv.Text select pn).FirstOrDefault(x => x.so == lsta);
                if (lst1 == null) return;

                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                try
                {
                    var lstnv = (from a in db.accounts select a).Single(t => t.id == txtidnv.Text);
                    lbltennv.Text = lstnv.name;
                }
                catch
                {
                    lbltennv.Text = "";
                }
                txtdv.Text = lst1.iddv;
                txtngaylap.DateTime = DateTime.Parse(lst1.ngayban.ToString());
                txtiddt.Text = lst1.iddt;
                try
                {
                    var lst2 = (from a in db.doituongbhs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    txtdiachi.Text = lst2.diachi.ToString();
                }
                catch (Exception)
                {
                }
                txtghichu.Text = lst1.ghichu;
                txtmavach.Text = "";
                txt1.Text = lst1.so.ToString();
                txttiente.Text = lst1.tiente;
                txttygia.Text = lst1.tygia.ToString();
                gcchitiet.DataSource = lst1.banhangcts;
            }
            catch
            {
            }
        }
        private void btnfirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // first
            if (Biencucbo.hdbh != 2)
                return;
            try
            {
                var lsta = (from a in db.banhangs where a.iddv == txtdv.Text select a).Min(t => t.so);
                var lst1 = (from pn in db.banhangs where pn.iddv == txtdv.Text select pn).FirstOrDefault(x => x.so == lsta);
                if (lst1 == null) return;

                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                try
                {
                    var lstnv = (from a in db.accounts select a).Single(t => t.id == txtidnv.Text);
                    lbltennv.Text = lstnv.name;
                }
                catch
                {
                    lbltennv.Text = "";
                }
                txtdv.Text = lst1.iddv;
                txtngaylap.DateTime = DateTime.Parse(lst1.ngayban.ToString());
                txtiddt.Text = lst1.iddt;
                try
                {
                    var lst2 = (from a in db.doituongbhs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    txtdiachi.Text = lst2.diachi.ToString();
                }
                catch (Exception)
                {
                }
                txtghichu.Text = lst1.ghichu;
                txtmavach.Text = "";
                txt1.Text = lst1.so.ToString();
                txttiente.Text = lst1.tiente;
                txttygia.Text = lst1.tygia.ToString();
                gcchitiet.DataSource = lst1.banhangcts;
            }
            catch
            {
            }
        }
        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (Biencucbo.hdbh == 0)
            {
                bh.truyenxoact(gridView1.FocusedRowHandle);
            }
            if (Biencucbo.hdbh == 1)
            {
                try
                {
                    banhangct ct = (from c in db.banhangcts select c).Single(x => x.id == gridView1.GetFocusedRowCellValue("id").ToString());
                    db.banhangcts.DeleteOnSubmit(ct);
                }
                catch
                {
                }
            }

        }

        private void txtmavach_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gcchitiet_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem10_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnthutien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.ma = txtid.Text;
            Biencucbo.ngaynhap = txtngaylap.DateTime;
            Biencucbo.loai = txtdv.Text;
            f_thutienbanhang2 frm = new f_thutienbanhang2();
            frm.ShowDialog();
        }



        private void txtghichu_Leave(object sender, EventArgs e)
        {
            txtmavach.Focus();
        }
        private void txtngaylap_Leave(object sender, EventArgs e)
        {
            txtmavach.Focus();
        }
        private void txtiddt_Leave(object sender, EventArgs e)
        {
            txtmavach.Focus();
        }
    }
}
