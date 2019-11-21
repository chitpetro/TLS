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
using DevExpress.Utils.Win;
using GUI.Properties;
namespace GUI
{
    public partial class f_hopdong : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_hopdong hd = new t_hopdong();
        public f_hopdong()
        {
            InitializeComponent();
            // tinh so luong ton san pham
            txttygia.ReadOnly = true;
            btnthue.DataSource = new DAL.KetNoiDBDataContext().thues;
            rsearchthuesuat.DataSource = btnthue.DataSource;
            btncongviec.DataSource = new DAL.KetNoiDBDataContext().congviecs;
            txtiddt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongs;
            txttiente.Properties.DataSource = new DAL.KetNoiDBDataContext().tientes;
            txtidloabc.Properties.DataSource = new DAL.KetNoiDBDataContext().dmlos;
            sdatcoc1.Properties.DataSource = new DAL.KetNoiDBDataContext().pthus;
            sdatcoc2.Properties.DataSource = new DAL.KetNoiDBDataContext().pthus;
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
                gridColumn41.Caption = "Mã công việc";
                gridColumn42.Caption = "Tên công việc";
                gridColumn43.Caption = "Nhóm công việc";
                gridColumn29.Caption = "Loại thuế";
                gridColumn30.Caption = "Tên thuế";
                gridColumn31.Caption = "Thuế suất";
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
                gridColumn41.Caption = "ລະຫັດວຽກງານ";
                gridColumn42.Caption = "ຊື່ວຽກງານ";
                gridColumn43.Caption = "ກຸ່ມໜ້າວຽກ";
                gridColumn29.Caption = "ປະເພດຂອງອາກອນ";
                gridColumn30.Caption = "ຊື່ອາກອນ";
                gridColumn31.Caption = "ອາກອນ (%)";
            }
            //lay quyen
            var quyen1 = db.PhanQuyen2s.FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "HopDong_HoaDon");
            btnhoadon.Enabled = (bool)quyen1.Xem;
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
            Biencucbo.hdhdong = 2;
            txt1.Enabled = false;
            btnLuu.Enabled = false;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnin.Enabled = true;
            btnreload.Enabled = false;
            txtdv.ReadOnly = true;
            txtid.ReadOnly = true;
            txthanmuctt.ReadOnly = true;
            txtdmcongno.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            txtidnv.ReadOnly = true;
            txtphongban.ReadOnly = true;
            // Enable
            txtghichu.ReadOnly = true;
            txtidloabc.ReadOnly = true;
            txtthoihantt.ReadOnly = true;
            txtdientich.ReadOnly = true;
            txttiente.ReadOnly = true;
            txtsohd.ReadOnly = true;
            txthanmuctt.ReadOnly = true;
            txtdmcongno.ReadOnly = true;
            txtpt.Enabled = false;
            txtNgaylap.ReadOnly = true;
            txtngaybd.ReadOnly = true;
            txtngaykt.ReadOnly = true;
            txtiddt.ReadOnly = true;
            sdatcoc1.ReadOnly = true;
            sdatcoc2.ReadOnly = true;
            gridView1.OptionsBehavior.Editable = false;
            try
            {
                var lst = (from a in db.hopdongs where a.iddv == Biencucbo.donvi select a.so).Max();
                var lst1 = (from b in db.hopdongs where b.iddv == Biencucbo.donvi select b).FirstOrDefault(t => t.so == lst);
                if (lst1 == null) return;

                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                txtdv.Text = lst1.iddv;
                txtNgaylap.DateTime = DateTime.Parse(lst1.ngaylap.ToString());
                txtngaybd.DateTime = DateTime.Parse(lst1.ngaybatdau.ToString());
                txtngaykt.DateTime = DateTime.Parse(lst1.ngayketthuc.ToString());
                txtiddt.Text = lst1.iddt;
                try
                {
                    var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    txtdiachi.Text = lst2.diachi.ToString();
                }
                catch (Exception)
                {
                }
                sdatcoc1.Text = lst1.datcoc1;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc1.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });

                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc1.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc1.Text = "Lỗi";
                }
                sdatcoc2.Text = lst1.datcoc2;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc2.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });
                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc2.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc2.Text = "Lỗi";
                }
                txtghichu.Text = lst1.ghichu;
                txtidloabc.Text = lst1.idlo;
                try
                {
                    var lst2 = (from a in db.dmlos select a).Single(t => t.id == txtidloabc.Text);
                    lblidlo.Text = "Tầng: " + lst2.tang.ToString();
                }
                catch
                {
                }
                txtthoihantt.Text = lst1.thoihantt.ToString();
                txtdientich.Text = lst1.dientich.ToString();
                txttiente.Text = lst1.tiente.ToString();
                txttygia.Text = lst1.tygia.ToString();
                txtsohd.Text = lst1.sohd;
                txtdmcongno.Text = lst1.dmcongno.ToString();
                txthanmuctt.Text = lst1.hantt.ToString();
                txt1.Text = lst1.so.ToString();
                txtpt.Text = lst1.pttt;
                gcchitiet.DataSource = lst1.hopdongcts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Mở
        private void btnmo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db = new KetNoiDBDataContext();
            f_dsHopDong frm = new f_dsHopDong();
            frm.ShowDialog();
            if (Biencucbo.getID == 1)
            {
                //load hoa don
                try
                {
                    var lst = (from hd in db.hopdongs select new { a = hd }).FirstOrDefault(x => x.a.id == Biencucbo.ma);
                    if (lst == null) return;
                    txtid.Text = lst.a.id;
                    txtidnv.Text = lst.a.idnv;
                    txtdv.Text = lst.a.iddv;
                    txtNgaylap.DateTime = DateTime.Parse(lst.a.ngaylap.ToString());
                    txtngaybd.DateTime = DateTime.Parse(lst.a.ngaybatdau.ToString());
                    txtngaykt.DateTime = DateTime.Parse(lst.a.ngayketthuc.ToString());
                    txtiddt.Text = lst.a.iddt;
                    try
                    {
                        var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                        lbltendt.Text = lst2.ten;
                    }
                    catch
                    {
                        lbltendt.Text = "";
                    }
                    sdatcoc1.Text = lst.a.datcoc1;
                    try
                    {
                        var lst2 = (from a in db.r_pthus where a.id == sdatcoc1.Text select a).GroupBy(t => t.id).Select(c => new

                        {
                            datcoc = c.Sum(t => t.nguyente),
                        });

                        string ab = lst2.Sum(t => t.datcoc).ToString();
                        ldatcoc1.Text = string.Format("{0:n2}", ab);
                    }
                    catch
                    {
                        ldatcoc1.Text = "Lỗi";
                    }
                    sdatcoc2.Text = lst.a.datcoc2;
                    try
                    {
                        var lst2 = (from a in db.r_pthus where a.id == sdatcoc2.Text select a).GroupBy(t => t.id).Select(c => new

                        {
                            datcoc = c.Sum(t => t.nguyente),
                        });
                        string ab = lst2.Sum(t => t.datcoc).ToString();
                        ldatcoc2.Text = string.Format("{0:n2}", ab);
                    }
                    catch
                    {
                        ldatcoc2.Text = "Lỗi";
                    }
                    txtpt.Text = lst.a.pttt;
                    txtghichu.Text = lst.a.ghichu;
                    txtidloabc.Text = lst.a.idlo;
                    try
                    {
                        var lst2 = (from a in db.dmlos select a).Single(t => t.id == txtidloabc.Text);
                        lblidlo.Text = "Tầng: " + lst2.tang.ToString();
                    }
                    catch
                    {
                    }
                    txtthoihantt.Text = lst.a.thoihantt.ToString();
                    txtdientich.Text = lst.a.dientich.ToString();
                    txttiente.Text = lst.a.tiente.ToString();
                    txttygia.Text = lst.a.tygia.ToString();
                    txtsohd.Text = lst.a.sohd;
                    txtdmcongno.Text = lst.a.dmcongno.ToString();
                    txthanmuctt.Text = lst.a.hantt.ToString();
                    txt1.Text = lst.a.so.ToString();
                    gcchitiet.DataSource = lst.a.hopdongcts;
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
            Biencucbo.hdhdong = 0;
            txtid.DataBindings.Clear();
            txtid.Text = "YYYYY";
            gcchitiet.DataSource = new DAL.KetNoiDBDataContext().View_hopdongcts;//.r_hopdongs;
            for (int i = 0; i <= gridView1.RowCount - 1; i++)
            {
                gridView1.DeleteRow(i);
            }
            gridView1.AddNewRow();
            txtdv.Text = Biencucbo.donvi;
            txtNgaylap.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtngaybd.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtngaykt.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtphongban.Text = Biencucbo.phongban;
            txtidnv.Text = Biencucbo.idnv.Trim();
            lbltennv.Text = Biencucbo.ten;
            txtiddt.Text = "";
            lbltendt.Text = "";
            sdatcoc1.Text = "";
            ldatcoc1.Text = "";
            sdatcoc2.Text = "";
            ldatcoc2.Text = "";
            txtpt.Text = "";
            txtghichu.Text = "";
            txtidloabc.Text = "";
            lblidlo.Text = "";
            txtthoihantt.Text = "";
            txtdientich.Text = "";
            txttiente.Text = "KIP";
            txttygia.Text = "1";
            txtsohd.Text = "";
            txtdmcongno.Text = "";
            txthanmuctt.Text = "";
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
            txtidloabc.ReadOnly = false;
            txtthoihantt.ReadOnly = false;
            txtdientich.ReadOnly = false;
            txttiente.ReadOnly = false;
            txtsohd.ReadOnly = false;
            txthanmuctt.ReadOnly = false;
            txtdmcongno.ReadOnly = false;
            txtNgaylap.ReadOnly = false;
            txtngaybd.ReadOnly = false;
            txtngaykt.ReadOnly = false;
            txtpt.Enabled = true;
            txtiddt.ReadOnly = false;
            sdatcoc1.ReadOnly = false;
            sdatcoc2.ReadOnly = false;
            gridView1.OptionsBehavior.Editable = true;
        }
        //Lưu
        public void luu()
        {
            t_history hs = new t_history();
            t_tudong td = new t_tudong();
            gridView1.UpdateCurrentRow();
            int check1 = 0;
            if (txtNgaylap.Text == "" || txtngaybd.Text == "" || txtngaykt.Text == "" || txtpt.Text == "")
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
                        if (gridView1.GetRowCellDisplayText(i, "soluong").ToString() == "" || gridView1.GetRowCellDisplayText(i, "dongia").ToString() == "")
                        {
                            check1 = 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (check1 == 1)
                {
                    Lotus.MsgBox.ShowErrorDialog("Thông tin chi tiết sản phẩm chưa đầy đủ - Vui Lòng Kiểm Tra Lại");
                }
                else
                {
                    if (Biencucbo.hdhdong == 0)
                    {
                        db = new KetNoiDBDataContext();
                        try
                        {
                            string check = "HDCT" + Biencucbo.donvi.Trim().ToString();
                            var lst1 = (from s in db.tudongs where s.maphieu == check select new { so = s.so }).ToList();
                            if (lst1.Count == 0)
                            {
                                int so;
                                so = 2;
                                td.themtudong(check, so, "HDCT", "Hợp Đồng Cho Thuê Mặt Bằng");
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
                            hd.moihd(txtid.Text.Trim(), txtNgaylap.DateTime, txtngaybd.DateTime, txtngaykt.DateTime, txtiddt.Text, txtidnv.Text, txtdv.Text, txtpt.Text, txtghichu.Text, Convert.ToInt32(txt1.Text), double.Parse(txthanmuctt.Text), double.Parse(txtdmcongno.Text), txtsohd.Text, txttiente.Text, double.Parse(txttygia.Text), double.Parse(txtdientich.Text), int.Parse(txtthoihantt.Text), txtidloabc.Text,sdatcoc1.Text,sdatcoc2.Text);
                            for (int i = 0; i <= gridView1.RowCount - 1; i++)
                            {
                                gridView1.SetRowCellValue(i, "id", txtid.Text + i);
                                gridView1.SetRowCellValue(i, "idhopdong", txtid.Text);
                                hd.moihdct(gridView1.GetRowCellValue(i, "idhopdong").ToString(), gridView1.GetRowCellValue(i, "diengiai").ToString(), double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString()), double.Parse(gridView1.GetRowCellValue(i, "dongia").ToString()), double.Parse(gridView1.GetRowCellValue(i, "thanhtien").ToString()), gridView1.GetRowCellValue(i, "id").ToString(), gridView1.GetRowCellValue(i, "loaithue").ToString(), double.Parse(gridView1.GetRowCellValue(i, "thue").ToString()), double.Parse(gridView1.GetRowCellValue(i, "chietkhau").ToString()), double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()), double.Parse(gridView1.GetRowCellValue(i, "datcoc").ToString()));
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
                            txtghichu.ReadOnly = true;
                            txtidloabc.ReadOnly = true;
                            txtthoihantt.ReadOnly = true;
                            txtdientich.ReadOnly = true;
                            txttiente.ReadOnly = true;
                            txtsohd.ReadOnly = true;
                            txthanmuctt.ReadOnly = true;
                            txtdmcongno.ReadOnly = true;
                            txtNgaylap.ReadOnly = true;
                            txtngaybd.ReadOnly = true;
                            txtngaykt.ReadOnly = true;
                            txtpt.Enabled = false;
                            txtiddt.ReadOnly = true;
                            sdatcoc1.ReadOnly = true;
                            sdatcoc2.ReadOnly = true;
                            gridView1.OptionsBehavior.Editable = false;
                            Biencucbo.hdhdong = 2;
                            // History 
                            hs.add(txtid.Text, "Thêm mới Hợp đồng");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else //Sua HD
                    {
                        try
                        {
                            hd.suahd(txtid.Text.Trim(), txtNgaylap.DateTime, txtngaybd.DateTime, txtngaykt.DateTime, txtiddt.Text, txtidnv.Text, Biencucbo.donvi, txtpt.Text, txtghichu.Text, Convert.ToInt32(txt1.Text), double.Parse(txthanmuctt.Text), double.Parse(txtdmcongno.Text), txtsohd.Text, txttiente.Text, double.Parse(txttygia.Text), double.Parse(txtdientich.Text), int.Parse(txtthoihantt.Text), txtidloabc.Text,sdatcoc1.Text,sdatcoc2.Text);
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
                            txtidloabc.ReadOnly = true;
                            txtthoihantt.ReadOnly = true;
                            txtdientich.ReadOnly = true;
                            txttiente.ReadOnly = true;
                            txtsohd.ReadOnly = true;
                            txthanmuctt.ReadOnly = true;
                            txtdmcongno.ReadOnly = true;
                            txtNgaylap.ReadOnly = true;
                            txtngaybd.ReadOnly = true;
                            txtngaykt.ReadOnly = true;
                            txtpt.Enabled = false;
                            txtiddt.ReadOnly = true;
                            sdatcoc1.ReadOnly = true;
                            sdatcoc2.ReadOnly = true;
                            gridView1.OptionsBehavior.Editable = false;
                            Biencucbo.hdhdong = 2;
                            hs.add(txtid.Text, "Sửa Hợp đồng");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txthanmuctt.Text == "")
                txthanmuctt.Text = "0";
            if (txtdmcongno.Text == "")
                txtdmcongno.Text = "0";
            gridView1.PostEditor();
            luu();
        }
        bool LuuPhieu()
        {
            layoutControl1.Validate();
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            try
            {
                var c1 = db.hopdongs.Context.GetChangeSet();
                db.hopdongcts.Context.SubmitChanges();
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
            if (txtid.Text == "") return;
            var check = (from a in db.hopdongs
                         join b in db.hoadons on a.id equals b.link
                         where a.id == txtid.Text
                         select b);
            if (check.Count() == 0)
            {
                try
                {
                    var lst = (from pn in db.hopdongs select pn).FirstOrDefault(x => x.id == txtid.Text);
                    if (lst == null) return;
                    gcchitiet.DataSource = lst.hopdongcts;
                    //enabled
                    txtghichu.ReadOnly = false;
                    txtidloabc.ReadOnly = false;
                    txtthoihantt.ReadOnly = false;
                    txtdientich.ReadOnly = false;
                    txttiente.ReadOnly = false;
                    txtsohd.ReadOnly = false;
                    txthanmuctt.ReadOnly = false;
                    txtdmcongno.ReadOnly = false;
                    txtNgaylap.ReadOnly = false;
                    txtngaybd.ReadOnly = false;
                    txtngaykt.ReadOnly = false;
                    txtpt.Enabled = true;
                    txtiddt.ReadOnly = false;
                    sdatcoc1.ReadOnly = false;
                    sdatcoc2.ReadOnly = false;
                    gridView1.OptionsBehavior.Editable = true;
                    Biencucbo.hdhdong = 1;
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
                MessageBox.Show("Không thể thao tác vì có sự liên kết - kiểm tra phiếu " + check.FirstOrDefault().id);
            }
            //load
        }
        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "") return;
            var check = (from a in db.hopdongs
                         join b in db.hoadons on a.id equals b.link
                         where a.id == txtid.Text
                         select b);
            if (check.Count() == 0)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Hợp đồng " + txtid.Text + " không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    t_history hs = new t_history();
                    hs.add(txtid.Text, "Xóa Hợp đồng");
                    for (int i = gridView1.DataRowCount - 1; i >= 0; i--)
                    {
                        hd.xoact(gridView1.GetRowCellValue(i, "id").ToString());
                        gridView1.DeleteRow(i);
                    }
                    hd.xoahd(txtid.Text);
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
                    txtidloabc.ReadOnly = true;
                    txtthoihantt.ReadOnly = true;
                    txtdientich.ReadOnly = true;
                    txttiente.ReadOnly = true;
                    txtsohd.ReadOnly = true;
                    txthanmuctt.ReadOnly = true;
                    txtdmcongno.ReadOnly = true;
                    txtNgaylap.ReadOnly = true;
                    txtngaybd.ReadOnly = true;
                    txtngaykt.ReadOnly = true;
                    txtpt.Enabled = false;
                    txtiddt.ReadOnly = true;
                    sdatcoc1.ReadOnly = true;
                    sdatcoc2.ReadOnly = true;
                    gridView1.OptionsBehavior.Editable = false;
                    txtdv.Text = "";
                    txtid.Text = "";
                    txtidnv.Text = "";
                    txtdv.Text = "";
                    txtNgaylap.Text = "";
                    txtngaybd.Text = "";
                    txtngaykt.Text = "";
                    txtpt.Text = "";
                    txtiddt.Text = "";
                    lbltendt.Text = "";
                    sdatcoc1.Text = "";
                    ldatcoc1.Text = "";
                    sdatcoc2.Text = "";
                    ldatcoc2.Text = "";
                    txtghichu.Text = "";
                    txtidloabc.Text = "";
                    lblidlo.Text = "";
                    txtthoihantt.Text = "";
                    txtdientich.Text = "";
                    txttiente.Text = "KIP";
                    txttygia.Text = "1";
                    txtsohd.Text = "";
                    txtdmcongno.Text = "";
                    txthanmuctt.Text = "";
                    txt1.Text = "";
                    lbltendt.Text = "";
                    lbltennv.Text = "";
                }
                else
                {
                    MessageBox.Show("Không thể thao tác vì có sự liên kết - kiểm tra phiếu " + check.FirstOrDefault().id);
                }
            }
        }
        private void btnin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var lst = (from a in db.r_pxuats where a.id == txtid.Text select a);
            //r_pxuat xtra = new r_pxuat();
            //xtra.DataSource = lst;
            //xtra.ShowPreviewDialog();
        }
        private void btnload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdhdong == 1)
            {
                db = new KetNoiDBDataContext();
                var lst = (from pn in db.hopdongs select pn).FirstOrDefault(x => x.id == txtid.Text);
                if (lst == null) return;

                txtidnv.Text = lst.idnv;
                txtdv.Text = lst.iddv;
                txtNgaylap.DateTime = DateTime.Parse(lst.ngaylap.ToString());
                txtngaybd.DateTime = DateTime.Parse(lst.ngaybatdau.ToString());
                txtngaykt.DateTime = DateTime.Parse(lst.ngayketthuc.ToString());
                txtiddt.Text = lst.iddt;
                try
                {
                    var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten;
                }
                catch
                {

                }
                sdatcoc1.Text = lst.datcoc1;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc1.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });

                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc1.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc1.Text = "Lỗi";
                }
                sdatcoc2.Text = lst.datcoc2;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc2.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });
                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc2.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc2.Text = "Lỗi";
                }

                txtghichu.Text = lst.ghichu;
                txtidloabc.Text = lst.idlo;
                try
                {
                    var lst2 = (from a in db.dmlos select a).Single(t => t.id == txtidloabc.Text);
                    lblidlo.Text = "Tầng: " + lst2.tang.ToString();
                }
                catch
                {
                }
                txtthoihantt.Text = lst.thoihantt.ToString();
                txtdientich.Text = lst.dientich.ToString();
                txttiente.Text = lst.tiente.ToString();
                txttygia.Text = lst.tygia.ToString();
                txtsohd.Text = lst.sohd;
                txtdmcongno.Text = lst.dmcongno.ToString();
                txthanmuctt.Text = lst.hantt.ToString();
                txtpt.Text = lst.pttt;
                txt1.Text = lst.so.ToString();

                gcchitiet.DataSource = lst.hopdongcts;
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
            else if (Biencucbo.hdhdong == 0)
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
            Biencucbo.hdhdong = 2;
        }
        private void btnmasp_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    gridView1.PostEditor();
            //    var lst = new DAL.KetNoiDBDataContext().r_giasps;
            //    var lst2 = (from a in lst where a.iddv == Biencucbo.donvi select a).Single(t => t.idsp == gridView1.GetFocusedRowCellValue("idsanpham").ToString());
            //    gridView1.SetFocusedRowCellValue("dongia", double.Parse(lst2.giaban.ToString()));
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.ToString());
            //}
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridView1.PostEditor();
            if (e.Column.FieldName == "soluong" || e.Column.FieldName == "dongia" || e.Column.FieldName == "chietkhau" || e.Column.FieldName == "loaithue")
            {
                try
                {
                    try
                    {
                        gridView1.SetFocusedRowCellValue("thue", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) * double.Parse(gridView1.GetFocusedRowCellDisplayText("loaithue").ToString()) / 100);
                    }
                    catch
                    {
                        gridView1.SetFocusedRowCellValue("nguyente", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * double.Parse(txtdientich.Text) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) + double.Parse(gridView1.GetFocusedRowCellValue("thue").ToString()));
                    }
                    finally
                    {
                        gridView1.SetFocusedRowCellValue("thue", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) * double.Parse(gridView1.GetFocusedRowCellDisplayText("loaithue").ToString()) / 100);
                        gridView1.SetFocusedRowCellValue("nguyente", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * double.Parse(txtdientich.Text) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) + double.Parse(gridView1.GetFocusedRowCellValue("thue").ToString()));
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
            if (Biencucbo.hdhdong != 2)
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
        }
        private void txtiddt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                lbltendt.Text = lst.ten.ToString();
                txtdiachi.Text = lst.diachi.ToString();
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
            if (Biencucbo.hdhdong == 1)
            {
                var ct = gridView1.GetFocusedRow() as hopdongct;
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
                ct.idhopdong = txtid.Text;
                ct.dongia = 0;
                ct.chietkhau = 0;
                ct.datcoc = 0;
                ct.diengiai = "";
                ct.loaithue = "";
                ct.thue = 0;
                ct.thanhtien = 0;
                ct.id = a;
                ct.nguyente = 0;
            }
            else
            {
                gridView1.SetFocusedRowCellValue("diengiai", "");
                gridView1.SetFocusedRowCellValue("soluong", 0);
                gridView1.SetFocusedRowCellValue("dongia", 0);
                gridView1.SetFocusedRowCellValue("chietkhau", 0);
                gridView1.SetFocusedRowCellValue("thue", 0);
                gridView1.SetFocusedRowCellValue("datcoc", 0);
                gridView1.SetFocusedRowCellValue("loaithue", "");
            }
        }
        private void f_hd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Biencucbo.hdhdong != 2)
            {
                var a = Lotus.MsgBox.ShowYesNoCancelDialog("Hợp đồng này chưa được lưu - Bạn có muốn lưu Hợp đồng này trước khi thoát không?");
                if (a == DialogResult.Yes)
                {
                    luu();
                }
                else if (a == DialogResult.Cancel) e.Cancel = true;
            }
        }
        private void rsearchtiente_EditValueChanged(object sender, EventArgs e)
        {
            //gridView1.PostEditor();
            //try
            //{
            //    var lst = (from a in db.tientes select a).Single(t => t.tiente1 == gridView1.GetFocusedRowCellValue("tiente").ToString());
            //    if (lst == null) return;
            //    gridView1.SetFocusedRowCellValue("tygia", lst.tygia);
            //}
            //catch
            //{
            //}
        }
        private void btnIdSp_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }
        private void f_hd_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Hợp Đồng").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            load();
        }
        private void txttiente_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.tientes select a).FirstOrDefault(t => t.tiente1 == txttiente.Text);
                txttygia.Text = lst.tygia.ToString();
                for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
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
            //f_giasp form = new f_giasp();
            //form.ShowDialog();
            //var lst = new DAL.KetNoiDBDataContext().r_giasps;
            //try
            //{
            //    var lst2 = (from a in lst where a.iddv == Biencucbo.donvi select new { id = a.idsp, tensp = a.tensp, dvt = a.dvt });
            //    if (lst2 == null) return;
            //    btnmasp.DataSource = lst2;
            //    rsearchTenSP.DataSource = btnmasp.DataSource;
            //    btndvt.DataSource = btnmasp.DataSource;
            //}
            //catch
            //{
            //}
        }
        private void btnhoadon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdhdong == 0 || Biencucbo.hdhdong == 1)
                return;
            try
            {
                Biencucbo.dongia = double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()) * double.Parse(txtdientich.Text);
                Biencucbo.mahd = gridView1.GetFocusedRowCellValue("id").ToString();
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dữ liệu", "Thông Báo");
                return;
            }
            Biencucbo.hddv = 1;
            Biencucbo.hopdong = txtid.Text;
            Biencucbo.ma = txtid.Text;
            Biencucbo.iddt = txtiddt.Text;
            f_dshddv frm = new f_dshddv();
            frm.ShowDialog();
            Biencucbo.mahd = "";
            Biencucbo.dongia = 0;
        }
        private void btnfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdhdong == 0 || Biencucbo.hdhdong == 1)
                return;
            Biencucbo.hopdong = txtid.Text;
            f_themForm frm = new f_themForm();
            frm.ShowDialog();
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
            txttiente.Properties.DataSource = new KetNoiDBDataContext().tientes;
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
            f_doituong frm = new f_doituong();
            frm.ShowDialog();
            txtiddt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongs;
        }
        private void txtdientich_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    gridView1.SetRowCellValue(i, "nguyente", (((double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString())) * double.Parse(txtdientich.Text) * (double.Parse(gridView1.GetRowCellValue(i, "dongia").ToString()))) - ((double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString())) * (double.Parse(gridView1.GetRowCellValue(i, "chietkhau").ToString())))) + double.Parse(gridView1.GetRowCellValue(i, "thue").ToString()));
                    gridView1.SetRowCellValue(i, "thanhtien", (double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()) * double.Parse(txttygia.Text)));
                }
            }
            catch
            {
            }
        }
        private void btnprev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // next	
            if (Biencucbo.hdhdong != 2)
                return;
            try
            {
                var so = (from pn in db.hopdongs where pn.iddv == txtdv.Text && pn.so < int.Parse(txt1.Text) select pn.so).Max();
                var lst1 = (from pn in db.hopdongs where pn.iddv == txtdv.Text select pn).FirstOrDefault(x => x.so == so);
                if (lst1 == null) return;

                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                txtdv.Text = lst1.iddv;
                txtNgaylap.DateTime = DateTime.Parse(lst1.ngaylap.ToString());
                txtngaybd.DateTime = DateTime.Parse(lst1.ngaybatdau.ToString());
                txtngaykt.DateTime = DateTime.Parse(lst1.ngayketthuc.ToString());
                txtiddt.Text = lst1.iddt;
                try
                {
                    var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    txtdiachi.Text = lst2.diachi.ToString();
                }
                catch (Exception)
                {
                }
                sdatcoc1.Text = lst1.datcoc1;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc1.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });

                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc1.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc1.Text = "Lỗi";
                }
                sdatcoc2.Text = lst1.datcoc2;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc2.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });
                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc2.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc2.Text = "Lỗi";
                }
                txtghichu.Text = lst1.ghichu;
                txtidloabc.Text = lst1.idlo;
                try
                {
                    var lst2 = (from a in db.dmlos select a).Single(t => t.id == txtidloabc.Text);
                    lblidlo.Text = "Tầng: " + lst2.tang.ToString();
                }
                catch
                {
                }
                txtthoihantt.Text = lst1.thoihantt.ToString();
                txtdientich.Text = lst1.dientich.ToString();
                txttiente.Text = lst1.tiente.ToString();
                txttygia.Text = lst1.tygia.ToString();
                txtsohd.Text = lst1.sohd;
                txtdmcongno.Text = lst1.dmcongno.ToString();
                txthanmuctt.Text = lst1.hantt.ToString();
                txt1.Text = lst1.so.ToString();
                txtpt.Text = lst1.pttt;
                gcchitiet.DataSource = lst1.hopdongcts;
            }
            catch
            {
            }
        }
        private void btnnext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdhdong != 2)
                return;
            try
            {
                var so = (from pn in db.hopdongs where pn.iddv == txtdv.Text && pn.so > int.Parse(txt1.Text) select pn.so).Min();
                var lst1 = (from pn in db.hopdongs where pn.iddv == txtdv.Text select pn).FirstOrDefault(x => x.so == so);
                if (lst1 == null) return;

                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                txtdv.Text = lst1.iddv;
                txtNgaylap.DateTime = DateTime.Parse(lst1.ngaylap.ToString());
                txtngaybd.DateTime = DateTime.Parse(lst1.ngaybatdau.ToString());
                txtngaykt.DateTime = DateTime.Parse(lst1.ngayketthuc.ToString());
                txtiddt.Text = lst1.iddt;
                try
                {
                    var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    txtdiachi.Text = lst2.diachi.ToString();
                }
                catch (Exception)
                {
                }
                sdatcoc1.Text = lst1.datcoc1;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc1.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });

                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc1.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc1.Text = "Lỗi";
                }
                sdatcoc2.Text = lst1.datcoc2;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc2.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });
                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc2.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc2.Text = "Lỗi";
                }
                txtghichu.Text = lst1.ghichu;
                txtidloabc.Text = lst1.idlo;
                try
                {
                    var lst2 = (from a in db.dmlos select a).Single(t => t.id == txtidloabc.Text);
                    lblidlo.Text = "Tầng: " + lst2.tang.ToString();
                }
                catch
                {
                }
                txtthoihantt.Text = lst1.thoihantt.ToString();
                txtdientich.Text = lst1.dientich.ToString();
                txttiente.Text = lst1.tiente.ToString();
                txttygia.Text = lst1.tygia.ToString();
                txtsohd.Text = lst1.sohd;
                txtdmcongno.Text = lst1.dmcongno.ToString();
                txthanmuctt.Text = lst1.hantt.ToString();
                txt1.Text = lst1.so.ToString();
                txtpt.Text = lst1.pttt;
                gcchitiet.DataSource = lst1.hopdongcts;
            }
            catch
            {
            }
        }
        private void btnlast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdhdong != 2)
                return;
            try
            {
                var lst = (from pn in db.hopdongs where pn.iddv == txtdv.Text select pn).Max(x => x.so);
                var lst1 = (from pn in db.hopdongs where pn.iddv == txtdv.Text select pn).FirstOrDefault(x => x.so == lst);
                if (lst1 == null) return;

                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                txtdv.Text = lst1.iddv;
                txtNgaylap.DateTime = DateTime.Parse(lst1.ngaylap.ToString());
                txtngaybd.DateTime = DateTime.Parse(lst1.ngaybatdau.ToString());
                txtngaykt.DateTime = DateTime.Parse(lst1.ngayketthuc.ToString());
                txtiddt.Text = lst1.iddt;
                try
                {
                    var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    txtdiachi.Text = lst2.diachi.ToString();
                }
                catch (Exception)
                {
                }
                sdatcoc1.Text = lst1.datcoc1;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc1.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });

                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc1.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc1.Text = "Lỗi";
                }
                sdatcoc2.Text = lst1.datcoc2;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc2.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });
                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc2.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc2.Text = "Lỗi";
                }
                txtghichu.Text = lst1.ghichu;
                txtidloabc.Text = lst1.idlo;
                try
                {
                    var lst2 = (from a in db.dmlos select a).Single(t => t.id == txtidloabc.Text);
                    lblidlo.Text = "Tầng: " + lst2.tang.ToString();
                }
                catch
                {
                }
                txtthoihantt.Text = lst1.thoihantt.ToString();
                txtdientich.Text = lst1.dientich.ToString();
                txttiente.Text = lst1.tiente.ToString();
                txttygia.Text = lst1.tygia.ToString();
                txtsohd.Text = lst1.sohd;
                txtdmcongno.Text = lst1.dmcongno.ToString();
                txthanmuctt.Text = lst1.hantt.ToString();
                txt1.Text = lst1.so.ToString();
                txtpt.Text = lst1.pttt;
                gcchitiet.DataSource = lst1.hopdongcts;
            }
            catch
            {
            }
        }
        private void btnfirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdhdong != 2)
                return;
            try
            {
                var lst = (from pn in db.hopdongs where pn.iddv == txtdv.Text select pn).Min(x => x.so);
                var lst1 = (from pn in db.hopdongs where pn.iddv == txtdv.Text select pn).FirstOrDefault(x => x.so == lst);
                if (lst1 == null) return;

                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                txtdv.Text = lst1.iddv;
                txtNgaylap.DateTime = DateTime.Parse(lst1.ngaylap.ToString());
                txtngaybd.DateTime = DateTime.Parse(lst1.ngaybatdau.ToString());
                txtngaykt.DateTime = DateTime.Parse(lst1.ngayketthuc.ToString());
                txtiddt.Text = lst1.iddt;
                try
                {
                    var lst2 = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
                    lbltendt.Text = lst2.ten.ToString();
                    txtdiachi.Text = lst2.diachi.ToString();
                }
                catch (Exception)
                {
                }
                sdatcoc1.Text = lst1.datcoc1;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc1.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });

                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc1.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc1.Text = "Lỗi";
                }
                sdatcoc2.Text = lst1.datcoc2;
                try
                {
                    var lst2 = (from a in db.r_pthus where a.id == sdatcoc2.Text select a).GroupBy(t => t.id).Select(c => new

                    {
                        datcoc = c.Sum(t => t.nguyente),
                    });
                    string ab = lst2.Sum(t => t.datcoc).ToString();
                    ldatcoc2.Text = string.Format("{0:n2}", ab);
                }
                catch
                {
                    ldatcoc2.Text = "Lỗi";
                }
                txtghichu.Text = lst1.ghichu;
                txtidloabc.Text = lst1.idlo;
                try
                {
                    var lst2 = (from a in db.dmlos select a).Single(t => t.id == txtidloabc.Text);
                    lblidlo.Text = "Tầng: " + lst2.tang.ToString();
                }
                catch
                {
                }
                txtthoihantt.Text = lst1.thoihantt.ToString();
                txtdientich.Text = lst1.dientich.ToString();
                txttiente.Text = lst1.tiente.ToString();
                txttygia.Text = lst1.tygia.ToString();
                txtsohd.Text = lst1.sohd;
                txtdmcongno.Text = lst1.dmcongno.ToString();
                txthanmuctt.Text = lst1.hantt.ToString();
                txt1.Text = lst1.so.ToString();
                txtpt.Text = lst1.pttt;
                gcchitiet.DataSource = lst1.hopdongcts;
            }
            catch
            {
            }
        }
        private void txtidlo_QueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                IPopupControl popupControl = sender as IPopupControl;
                SimpleButton button = new SimpleButton()
                {
                    Image = Resources.icons8_Add_File_16,
                    Text = "Thêm mới",
                    BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
                };
                button.Click += new EventHandler(buttonsl_Click);
                button.Location = new Point(5, popupControl.PopupWindow.Height - button.Height - 5);
                popupControl.PopupWindow.Controls.Add(button);
                button.BringToFront();
            }
            catch
            {
            }
        }
        public void buttonsl_Click(object sender, EventArgs e)
        {
            f_dmlo frm = new f_dmlo();
            frm.ShowDialog();
            txtidloabc.Properties.DataSource = new DAL.KetNoiDBDataContext().dmlos;
        }
        private void txtidlo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst2 = (from a in db.dmlos select a).Single(t => t.id == txtidloabc.Text);
                lblidlo.Text = "Tầng: " + lst2.tang.ToString();
            }
            catch
            {
            }
        }
        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (Biencucbo.hdhdong == 1)
            {
                try
                {
                    hopdongct ct = (from c in db.hopdongcts select c).Single(x => x.id == gridView1.GetFocusedRowCellValue("id").ToString());
                    db.hopdongcts.DeleteOnSubmit(ct);
                }
                catch
                {
                }
            }
        }

        private void sdatcoc1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.r_pthus where a.id == sdatcoc1.Text select a).GroupBy(t => t.id).Select(c => new

                {
                    datcoc = c.Sum(t => t.nguyente),
                });

                string ab = lst.Sum(t => t.datcoc).ToString();
                ldatcoc1.Text = string.Format("{0:n2}", ab);
            }
            catch
            {
                ldatcoc1.Text = "Lỗi";
            }
        }

        private void sdatcoc2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.r_pthus where a.id == sdatcoc2.Text select a).GroupBy(t => t.id).Select(c => new

                {
                    datcoc = c.Sum(t => t.nguyente),
                });
                string ab = lst.Sum(t => t.datcoc).ToString();
                ldatcoc2.Text = string.Format("{0:n2}", ab);
            }
            catch
            {
                ldatcoc2.Text = "Lỗi";
            }
        }
    }
}

