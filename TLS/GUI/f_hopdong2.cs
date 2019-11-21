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
    public partial class f_hopdong2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_hopdong hd = new t_hopdong();
        public f_hopdong2()
        {
            InitializeComponent();
            // tinh so luong ton san pham
            //try
            //{
            //    var lst = (from a in db.r_giasps where a.iddv == Biencucbo.donvi select new { id = a.idsp, tensp = a.tensp, dvt = a.dvt });
            //    if (lst == null) return;
            //    btnmasp.DataSource = lst;
            //    rsearchTenSP.DataSource = btnmasp.DataSource;
            //    btndvt.DataSource = btnmasp.DataSource;
            //}
            //catch
            //{
            //}
            //txttygia.ReadOnly = true;
            //btnthue.DataSource = new DAL.KetNoiDBDataContext().thues;
            //rsearchthuesuat.DataSource = btnthue.DataSource;
            //btncongviec.DataSource = new DAL.KetNoiDBDataContext().congviecs;
            //txtiddt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongs;
            //txttiente2.Properties.DataSource = new DAL.KetNoiDBDataContext().tientes;
            //lay quyen
            var quyen1 = db.PhanQuyen2s.FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "HopDong2_HoaDon");
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
            //txtdv.ReadOnly = true;
            //txtid.ReadOnly = true;
            //txthanmuctt.ReadOnly = true;
            //txtdmcongno.ReadOnly = true;
            //txtdiachi.ReadOnly = true;
            //txtidnv.ReadOnly = true;
            //txtphongban.ReadOnly = true;
            //// Enable
            //txtghichu.ReadOnly = true;
            //txttiente.ReadOnly = true;
            //txtsohd.ReadOnly = true;
            //txthanmuctt.ReadOnly = true;
            //txtdmcongno.ReadOnly = true;
            //txtpt.Enabled = false;
            //txtNgaylap.ReadOnly = true;
            //txtngaybd.ReadOnly = true;
            //txtngaykt.ReadOnly = true;
            //txtiddt.ReadOnly = true;
            //gridView1.OptionsBehavior.Editable = false;
            //try
            //{
            //    var lst = (from a in db.hopdongs where a.iddv == Biencucbo.donvi select a.so).Max();
            //    var lst1 = (from b in db.hopdongs where b.iddv == Biencucbo.donvi select b).FirstOrDefault(t => t.so == lst);
            //    if (lst1 == null) return;
            //    gcchitiet.DataSource = lst1.hopdongcts;
            //    txtid.Text = lst1.id;
            //    txtidnv.Text = lst1.idnv;
            //    txtdv.Text = lst1.iddv;
            //    txtNgaylap.DateTime = DateTime.Parse(lst1.ngaylap.ToString());
            //    txtngaybd.DateTime = DateTime.Parse(lst1.ngaybatdau.ToString());
            //    txtngaykt.DateTime = DateTime.Parse(lst1.ngayketthuc.ToString());
            //    txtiddt.Text = lst1.iddt;
            //    txtghichu.Text = lst1.ghichu;
            //    txttiente2.Text = lst1.tiente.ToString();
            //    txttygia2.Text = lst1.tygia.ToString();
            //    txtsohd.Text = lst1.sohd;
            //    txtdmcongno.Text = lst1.dmcongno.ToString();
            //    txthanmuctt.Text = lst1.hantt.ToString();
            //    txt1.Text = lst1.so.ToString();
            //    txtpt.Text = lst1.pttt;
            //}
            //catch
            //{
            //}
        }
        //Mở
        private void btnmo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //db = new KetNoiDBDataContext();
            //f_dsHopDong frm = new f_dsHopDong();
            //frm.ShowDialog();
            //if (Biencucbo.getID == 1)
            //{
            //    //load hoa don
            //    try
            //    {
            //        var lst = (from hd in db.hopdongs select new { a = hd }).FirstOrDefault(x => x.a.id == Biencucbo.ma);
            //        if (lst == null) return;
            //        txtid.Text = lst.a.id;
            //        txtidnv.Text = lst.a.idnv;
            //        txtdv.Text = lst.a.iddv;
            //        txtNgaylap.DateTime = DateTime.Parse(lst.a.ngaylap.ToString());
            //        txtngaybd.DateTime = DateTime.Parse(lst.a.ngaybatdau.ToString());
            //        txtngaykt.DateTime = DateTime.Parse(lst.a.ngayketthuc.ToString());
            //        txtiddt.Text = lst.a.iddt;
            //        txtpt.Text = lst.a.pttt;
            //        txtghichu.Text = lst.a.ghichu;
            //        txttiente2.Text = lst.a.tiente.ToString();
            //        txttygia2.Text = lst.a.tygia.ToString();
            //        txtsohd.Text = lst.a.sohd;
            //        txtdmcongno.Text = lst.a.dmcongno.ToString();
            //        txthanmuctt.Text = lst.a.hantt.ToString();
            //        txt1.Text = lst.a.so.ToString();
            //        gcchitiet.DataSource = lst.a.hopdongcts;
            //        //btn
            //        btnnew.Enabled = true;
            //        btnsua.Enabled = true;
            //        btnLuu.Enabled = false;
            //        btnmo.Enabled = true;
            //        btnxoa.Enabled = true;
            //        btnin.Enabled = true;
            //        btnreload.Enabled = false;
            //    }
            //    catch
            //    {
            //    }
            //}
        }
        //Add new
        private void btnnew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Biencucbo.hdhdong = 0;
            //txtid.DataBindings.Clear();
            //txtid.Text = "YYYYY";
            //gcchitiet.DataSource = new DAL.KetNoiDBDataContext().View_hoadoncts;//.r_hopdongs;
            //for (int i = 0; i <= gridView1.RowCount - 1; i++)
            //{
            //    gridView1.DeleteRow(i);
            //}
            //gridView1.AddNewRow();
            //txtdv.Text = Biencucbo.donvi;
            //txtNgaylap.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //txtngaybd.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //txtngaykt.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //txtphongban.Text = Biencucbo.phongban;
            //txtidnv.Text = Biencucbo.idnv.Trim();
            //lbltennv.Text = Biencucbo.ten;
            //txtiddt.Text = "";
            //lbltendt.Text = "";
            //txtpt.Text = "";
            //txtghichu.Text = "";
            //txttiente2.Text = "";
            //txttygia2.Text = "";
            //txtsohd.Text = "";
            //txtdmcongno.Text = "";
            //txthanmuctt.Text = "";
            ////btn
            //btnnew.Enabled = false;
            //btnmo.Enabled = false;
            //btnLuu.Enabled = true;
            //btnsua.Enabled = false;
            //btnxoa.Enabled = false;
            //btnin.Enabled = false;
            //btnreload.Enabled = false;
            ////enabled
            //txtghichu.ReadOnly = false;
            //txttiente.ReadOnly = false;
            //txtsohd.ReadOnly = false;
            //txthanmuctt.ReadOnly = false;
            //txtdmcongno.ReadOnly = false;
            //txtNgaylap.ReadOnly = false;
            //txtngaybd.ReadOnly = false;
            //txtngaykt.ReadOnly = false;
            //txtpt.Enabled = true;
            //txtiddt.ReadOnly = false;
            //gridView1.OptionsBehavior.Editable = true;
        }
        //Lưu
        public void luu()
        {
            //t_history hs = new t_history();
            //t_tudong td = new t_tudong();
            //gridView1.UpdateCurrentRow();
            //int check1 = 0;
            //if (txtNgaylap.Text == "" || txtngaybd.Text == "" || txtngaykt.Text == "" || txtpt.Text == "")
            //{
            //    Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            //}
            //else
            //{
            //    try
            //    {
            //        for (int i = 0; i <= gridView1.RowCount - 1; i++)
            //        {
            //            //re-check
            //            if (gridView1.GetRowCellDisplayText(i, "soluong").ToString() == "" || gridView1.GetRowCellDisplayText(i, "dongia").ToString() == "")
            //            {
            //                check1 = 1;
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //    if (check1 == 1)
            //    {
            //        Lotus.MsgBox.ShowErrorDialog("Thông tin chi tiết sản phẩm chưa đầy đủ - Vui Lòng Kiểm Tra Lại");
            //    }
            //    else
            //    {
            //        if (Biencucbo.hdhdong == 0)
            //        {
            //            db = new KetNoiDBDataContext();
            //            try
            //            {
            //                string check = "HDCT" + Biencucbo.donvi.Trim().ToString();
            //                var lst1 = (from s in db.tudongs where s.maphieu == check select new { so = s.so }).ToList();
            //                if (lst1.Count == 0)
            //                {
            //                    int so;
            //                    so = 2;
            //                    td.themtudong(check, so);
            //                    txtid.Text = check + "_000001";
            //                    txt1.Text = "1";
            //                }
            //                else
            //                {
            //                    int k;
            //                    txt1.DataBindings.Clear();
            //                    txt1.DataBindings.Add("text", lst1, "so");
            //                    k = 0;
            //                    k = Convert.ToInt32(txt1.Text);
            //                    string so0 = "";
            //                    if (k < 10)
            //                    {
            //                        so0 = "00000";
            //                    }
            //                    else if (k >= 10 & k < 100)
            //                    {
            //                        so0 = "0000";
            //                    }
            //                    else if (k >= 100 & k < 1000)
            //                    {
            //                        so0 = "000";
            //                    }
            //                    else if (k >= 1000 & k < 10000)
            //                    {
            //                        so0 = "00";
            //                    }
            //                    else if (k >= 10000 & k < 100000)
            //                    {
            //                        so0 = "0";
            //                    }
            //                    else if (k >= 100000)
            //                    {
            //                        so0 = "";
            //                    }
            //                    txtid.Text = check + "_" + so0 + k;
            //                    k = k + 1;
            //                    td.suatudong(check, k);
            //                }
            //                hd.moihd(txtid.Text.Trim(), txtNgaylap.DateTime, txtngaybd.DateTime, txtngaykt.DateTime, txtiddt.Text, txtidnv.Text, txtdv.Text, txtpt.Text, txtghichu.Text, Convert.ToInt32(txt1.Text), double.Parse(txthanmuctt.Text), double.Parse(txtdmcongno.Text), txtsohd.Text, double.Parse(txttiente2.Text), double.Parse(txttygia2.Text));
            //                for (int i = 0; i <= gridView1.RowCount - 1; i++)
            //                {
            //                    gridView1.SetRowCellValue(i, "id", txtid.Text);
            //                    gridView1.SetRowCellValue(i, "idhopdong", txtid.Text);
            //                    hd.moihdct(gridView1.GetRowCellValue(i, "id").ToString(), gridView1.GetRowCellValue(i, "diengiai").ToString(), double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString()), "", double.Parse(gridView1.GetRowCellValue(i, "dongia").ToString()), double.Parse(gridView1.GetRowCellValue(i, "thanhtien").ToString()), double.Parse(0.ToString()), double.Parse(0.ToString()), gridView1.GetRowCellValue(i, "id").ToString(), gridView1.GetRowCellValue(i, "loaithue").ToString(), double.Parse(gridView1.GetRowCellValue(i, "thue").ToString()), double.Parse(gridView1.GetRowCellValue(i, "chietkhau").ToString()), double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()));
            //                }
            //                //btn
            //                btnmo.Enabled = true;
            //                btnnew.Enabled = true;
            //                btnLuu.Enabled = false;
            //                btnsua.Enabled = true;
            //                btnxoa.Enabled = true;
            //                btnin.Enabled = true;
            //                btnreload.Enabled = false;
            //                //enabled
            //                txtghichu.ReadOnly = true;
            //                txttiente.ReadOnly = true;
            //                txtsohd.ReadOnly = true;
            //                txthanmuctt.ReadOnly = true;
            //                txtdmcongno.ReadOnly = true;
            //                txtNgaylap.ReadOnly = true;
            //                txtngaybd.ReadOnly = true;
            //                txtngaykt.ReadOnly = true;
            //                txtpt.Enabled = false;
            //                txtiddt.ReadOnly = true;
            //                gridView1.OptionsBehavior.Editable = false;
            //                Biencucbo.hdhdong = 2;
            //                // History 
            //                hs.add(txtid.Text, "Thêm mới Hợp đồng");
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message);
            //            }
            //        }
            //        else //Sua HD
            //        {
            //            try
            //            {
            //                hd.suahd(txtid.Text.Trim(), txtNgaylap.DateTime, txtngaybd.DateTime, txtngaykt.DateTime, txtiddt.Text, txtidnv.Text, txtdv.Text, txtpt.Text, txtghichu.Text, Convert.ToInt32(txt1.Text), double.Parse(txthanmuctt.Text), double.Parse(txtdmcongno.Text), txtsohd.Text, double.Parse(txttiente2.Text), double.Parse(txttygia2.Text));
            //                //sua ct
            //                LuuPhieu();
            //                //btn
            //                btnmo.Enabled = true;
            //                btnnew.Enabled = true;
            //                btnLuu.Enabled = false;
            //                btnsua.Enabled = true;
            //                btnxoa.Enabled = true;
            //                btnin.Enabled = true;
            //                btnreload.Enabled = false;
            //                //enabled
            //                txtghichu.ReadOnly = true;
            //                txttiente.ReadOnly = true;
            //                txtsohd.ReadOnly = true;
            //                txthanmuctt.ReadOnly = true;
            //                txtdmcongno.ReadOnly = true;
            //                txtNgaylap.ReadOnly = true;
            //                txtngaybd.ReadOnly = true;
            //                txtngaykt.ReadOnly = true;
            //                txtpt.Enabled = false;
            //                txtiddt.ReadOnly = true;
            //                gridView1.OptionsBehavior.Editable = false;
            //                Biencucbo.hdhdong = 2;
            //                hs.add(txtid.Text, "Sửa Hợp đồng");
            //            }
            //            catch(Exception ex)
            //            {
            //                MessageBox.Show(ex.ToString());
            //            }
            //        }
            //    }
            //}
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (txthanmuctt.Text == "")
            //    txthanmuctt.Text = "0";
            //if (txtdmcongno.Text == "")
            //    txtdmcongno.Text = "0";
            //gridView1.PostEditor();
            //luu();
        }
        bool LuuPhieu()
        {
            //// kiem tra truoc khi luu
            //layoutControl1.Validate();
            //gridView1.CloseEditor();
            //gridView1.UpdateCurrentRow();
            //try
            //{
            //    db.hopdongcts.Context.SubmitChanges();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message);
            //    return false;
            //}
            return true;
        }
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (txtid.Text == "") return;
            ////var check = (from a in db.hoadons
            ////             join b in db.pthus on a.id equals b.link
            ////             where a.id == txtid.Text
            ////             select b);
            ////var check = from a in db.hopdongs where a.id == txtid.Text select a;
            ////if (check.Count() == 0)
            ////{
            //try
            //{
            //    var lst = (from pn in db.hopdongs select pn).FirstOrDefault(x => x.id == txtid.Text);
            //    if (lst == null) return;
            //    gcchitiet.DataSource = lst.hopdongcts;
            //    //enabled
            //    txtghichu.ReadOnly = false;
            //    txttiente.ReadOnly = false;
            //    txtsohd.ReadOnly = false;
            //    txthanmuctt.ReadOnly = false;
            //    txtdmcongno.ReadOnly = false;
            //    txtNgaylap.ReadOnly = false;
            //    txtngaybd.ReadOnly = false;
            //    txtngaykt.ReadOnly = false;
            //    txtpt.Enabled = true;
            //    txtiddt.ReadOnly = false;
            //    gridView1.OptionsBehavior.Editable = true;
            //    Biencucbo.hdhdong = 1;
            //    txtghichu.Focus();
            //    // btn
            //    btnsua.Enabled = false;
            //    btnLuu.Enabled = true;
            //    btnmo.Enabled = false;
            //    btnnew.Enabled = false;
            //    btnxoa.Enabled = false;
            //    btnin.Enabled = false;
            //    btnreload.Enabled = true;
            //}
            //catch
            //{
            //}
            ////}
            ////else
            ////{
            ////    MessageBox.Show("Không thể thao tác vì có sự liên kết - kiểm tra phiếu " + check.FirstOrDefault().id);
            ////}
            ////load 
        }
        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (txtid.Text == "") return;
            ////var check = (from a in db.hoadons
            ////             join b in db.pthus on a.id equals b.link
            ////             where a.id == txtid.Text
            ////             select b);
            ////var check = from a in db.hopdongs where a.id == txtid.Text select a;
            ////if (check.Count() == 0)
            ////{
            //if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Hợp đồng " + txtid.Text + " không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    t_history hs = new t_history();
            //    hs.add(txtid.Text, "Xóa Hợp đồng");
            //    for (int i = gridView1.DataRowCount - 1; i >= 0; i--)
            //    {
            //        hd.xoact(gridView1.GetRowCellValue(i, "id").ToString());
            //        gridView1.DeleteRow(i);
            //    }
            //    hd.xoahd(txtid.Text);
            //    //btn
            //    btnmo.Enabled = true;
            //    btnnew.Enabled = true;
            //    btnLuu.Enabled = false;
            //    btnsua.Enabled = true;
            //    btnxoa.Enabled = true;
            //    btnin.Enabled = true;
            //    btnreload.Enabled = false;
            //    //enabled
            //    txtghichu.ReadOnly = true;
            //    txttiente.ReadOnly = true;
            //    txtsohd.ReadOnly = true;
            //    txthanmuctt.ReadOnly = true;
            //    txtdmcongno.ReadOnly = true;
            //    txtNgaylap.ReadOnly = true;
            //    txtngaybd.ReadOnly = true;
            //    txtngaykt.ReadOnly = true;
            //    txtpt.Enabled = false;
            //    txtiddt.ReadOnly = true;
            //    gridView1.OptionsBehavior.Editable = false;
            //    txtdv.Text = "";
            //    txtid.Text = "";
            //    txtidnv.Text = "";
            //    txtdv.Text = "";
            //    txtNgaylap.Text = "";
            //    txtngaybd.Text = "";
            //    txtngaykt.Text = "";
            //    txtpt.Text = "";
            //    txtiddt.Text = "";
            //    txtghichu.Text = "";
            //    txttiente2.Text = "";
            //    txttygia2.Text = "";
            //    txtsohd.Text = "";
            //    txtdmcongno.Text = "";
            //    txthanmuctt.Text = "";
            //    txt1.Text = "";
            //    lbltendt.Text = "";
            //    lbltennv.Text = "";
            //}
            ////}
            ////else
            ////{
            ////    MessageBox.Show("Không thể thao tác vì có sự liên kết - kiểm tra phiếu " + check.FirstOrDefault().id);
            ////}
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
            //if (Biencucbo.hdhdong == 1)
            //{
            //    db = new KetNoiDBDataContext();
            //    var lst = (from pn in db.hopdongs select pn).FirstOrDefault(x => x.id == txtid.Text);
            //    if (lst == null) return;
            //    gcchitiet.DataSource = lst.hopdongcts;
            //    txtidnv.Text = lst.idnv;
            //    txtdv.Text = lst.iddv;
            //    txtNgaylap.DateTime = DateTime.Parse(lst.ngaylap.ToString());
            //    txtngaybd.DateTime = DateTime.Parse(lst.ngaybatdau.ToString());
            //    txtngaykt.DateTime = DateTime.Parse(lst.ngayketthuc.ToString());
            //    txtiddt.Text = lst.iddt;
            //    txtghichu.Text = lst.ghichu;
            //    txttiente2.Text = lst.tiente.ToString();
            //    txttygia2.Text = lst.tygia.ToString();
            //    txtsohd.Text = lst.sohd;
            //    txtdmcongno.Text = lst.dmcongno.ToString();
            //    txthanmuctt.Text = lst.hantt.ToString();
            //    txtpt.Text = lst.pttt;
            //    txt1.Text = lst.so.ToString();
            //    gcchitiet.DataSource = lst.hopdongcts;
            //    //btn
            //    btnnew.Enabled = true;
            //    btnsua.Enabled = true;
            //    btnLuu.Enabled = false;
            //    btnmo.Enabled = true;
            //    btnxoa.Enabled = true;
            //    btnin.Enabled = true;
            //    btnreload.Enabled = false;
            //    gridView1.OptionsBehavior.Editable = false;
            //}
            //else if (Biencucbo.hdhdong == 0)
            //{
            //    load();
            //    btnnew.Enabled = true;
            //    btnsua.Enabled = true;
            //    btnLuu.Enabled = false;
            //    btnmo.Enabled = true;
            //    btnxoa.Enabled = true;
            //    btnin.Enabled = true;
            //    btnreload.Enabled = false;
            //    gridView1.OptionsBehavior.Editable = false;
            //}
            //Biencucbo.hdhdong = 2;
        }
        private void btnmasp_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    gridView1.PostEditor();
            //    var lst = new DAL.KetNoiDBDataContext().r_giasps;
            //    var lst2 = (from a in lst where a.iddv == Biencucbo.donvi select a).Single(t => t.idsp == gridView1.GetFocusedRowCellValue("idsanpham").ToString());
            //    gridView1.SetFocusedRowCellValue("dongia", float.Parse(lst2.giaban.ToString()));
            //}
            //catch
            //{
            //}
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //gridView1.PostEditor();
            //if (e.Column.FieldName == "soluong" || e.Column.FieldName == "dongia" || e.Column.FieldName == "chietkhau" || e.Column.FieldName == "loaithue")
            //{
            //    try
            //    {
            //        try
            //        {
            //            gridView1.SetFocusedRowCellValue("thue", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) * double.Parse(gridView1.GetFocusedRowCellDisplayText("loaithue").ToString()) / 100);
            //        }
            //        catch
            //        {
            //            gridView1.SetFocusedRowCellValue("nguyente", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) + double.Parse(gridView1.GetFocusedRowCellValue("thue").ToString()));
            //        }
            //        finally
            //        {
            //            gridView1.SetFocusedRowCellValue("thue", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) * double.Parse(gridView1.GetFocusedRowCellDisplayText("loaithue").ToString()) / 100);
            //            gridView1.SetFocusedRowCellValue("nguyente", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) + double.Parse(gridView1.GetFocusedRowCellValue("thue").ToString()));
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //else if (e.Column.FieldName == "nguyente")
            //{
            //    try
            //    {
            //        gridView1.SetFocusedRowCellValue("thanhtien", (double.Parse(gridView1.GetFocusedRowCellValue("nguyente").ToString())) * (double.Parse(txttygia2.Text)));
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
        }
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (Biencucbo.hdhdong != 2)
            //{
            //    if (e.KeyCode == Keys.Insert)
            //    {
            //        gridView1.AddNewRow();
            //    }
            //    else if (e.KeyCode == Keys.Delete)
            //    {
            //        if (Biencucbo.hdhdong == 1)
            //        {
            //            try
            //            {
            //                hopdongct ct = (from c in db.hopdongcts select c).Single(x => x.id == gridView1.GetFocusedRowCellValue("id").ToString());
            //                db.hopdongcts.DeleteOnSubmit(ct);
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
            //try
            //{
            //    var lst = (from a in db.doituongs select a).Single(t => t.id == txtiddt.Text);
            //    lbltendt.Text = lst.ten.ToString();
            //    txtdiachi.Text = lst.diachi.ToString();
            //}
            //catch (Exception)
            //{
            //}
        }
        private void btnthue_EditValueChanged(object sender, EventArgs e)
        {
            //gridView1.PostEditor();
        }
        //add new row
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //if (Biencucbo.hdhdong == 1)
            //{
            //    var ct = gridView1.GetFocusedRow() as hopdongct;
            //    if (ct == null) return;
            //    int i = 0, k = 0;
            //    string a;
            //    k = gridView1.DataRowCount;
            //    a = txtid.Text + k;
            //    for (i = 0; i <= gridView1.DataRowCount - 1;)
            //    {
            //        if (a == gridView1.GetRowCellValue(i, "id").ToString())
            //        {
            //            k = k + 1;
            //            a = txtid.Text + k;
            //            i = 0;
            //        }
            //        else
            //        {
            //            i++;
            //        }
            //    }
            //    ct.idhopdong = txtid.Text;
            //    ct.dongia = 0;
            //    ct.chietkhau = 0;
            //    ct.diengiai = "";
            //    ct.loaithue = "";
            //    ct.thue = 0;
            //    ct.thanhtien = 0;
            //    ct.id = a;
            //    ct.nguyente = 0;
            //}
            //else
            //{
            //    gridView1.SetFocusedRowCellValue("diengiai", "");
            //    gridView1.SetFocusedRowCellValue("soluong", 0);
            //    gridView1.SetFocusedRowCellValue("dongia", 0);
            //    gridView1.SetFocusedRowCellValue("chietkhau", 0);
            //    gridView1.SetFocusedRowCellValue("thue", 0);
            //    gridView1.SetFocusedRowCellValue("loaithue", "");
            //    gridView1.SetFocusedRowCellValue("idcv", "");
            //}
        }
        private void f_hd_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (Biencucbo.hdhdong != 2)
            //{
            //    var a = Lotus.MsgBox.ShowYesNoCancelDialog("Hợp đồng này chưa được lưu - Bạn có muốn lưu Hợp đồng này trước khi thoát không?");
            //    if (a == DialogResult.Yes)
            //    {
            //        luu();
            //    }
            //    else if (a == DialogResult.Cancel) e.Cancel = true;
            //}
        }
        private void btnIdSp_EditValueChanged(object sender, EventArgs e)
        {
            //gridView1.PostEditor();
        }
        private void f_hd_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Hợp Đồng 2").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
             
            load();
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
        private void txtpt_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var lst = (from a in db.httts select a).Single(t => t.id == txtpt.Text);
            //    txtpt.Text = lst.ten.ToString();
            //}
            //catch (Exception)
            //{
            //}
        }
        private void btnhoadon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (Biencucbo.hdhdong == 0 || Biencucbo.hdhdong == 1)
            //    return;
            //Biencucbo.hopdong = txtid.Text;
            //Biencucbo.iddt = txtiddt.Text;
            //f_dshddv frm = new f_dshddv();
            //frm.ShowDialog();
        }
        private void txttiente_EditValueChanged(object sender, EventArgs e)
        {
        }
        private void txttiente2_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var lst = (from a in db.tientes select a).FirstOrDefault(t => t.tiente1 == txttiente2.Text);
            //    txttygia2.Text = lst.tygia.ToString();
            //    for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
            //    {
            //        try
            //        {
            //            gridView1.SetRowCellValue(i, "thanhtien", double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()) * double.Parse(txttygia2.Text));
            //        }
            //        catch
            //        {
            //        }
            //    }
            //}
            //catch
            //{
            //}
        }
    }
}
