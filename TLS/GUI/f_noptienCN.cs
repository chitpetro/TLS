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
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using System.Data.Linq;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
namespace GUI
{
    public partial class f_noptienCN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_pchi pchi = new t_pchi();
        //form
        public f_noptienCN()
        {
            InitializeComponent();
            rsearchtiente1.DataSource = new DAL.KetNoiDBDataContext().tientes;
            txttiente.Properties.DataSource = new DAL.KetNoiDBDataContext().tientes;
            btnmuccp.DataSource = new DAL.KetNoiDBDataContext().muccps;
            btncongviec1.DataSource = new DAL.KetNoiDBDataContext().congviecs;
            txtiddt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongs;
            try
            {
                var lst = from a in db.pnhaps
                          join b in db.pnhapcts on a.id equals b.idpnhap into g
                          join c in db.doituongs on a.iddt equals c.id
                          join d in db.donvis on a.iddv equals d.id
                          where Biencucbo.donvi == a.iddv || Biencucbo.donvi == d.iddv
                          select new
                          {
                              mahd = a.id,
                              ngayhd = a.ngaynhap,
                              noidung = a.ghichu,
                              doituong = c.ten,
                              iddv = a.iddv,
                              tongtien = g.Sum(t => t.thanhtien)
                          };
                txtsopn.Properties.DataSource = lst;
            }
            catch
            {
            }
            var lst0 = from a in db.dmpchis where a.danhmuc == "Nộp Tiền Chi Nhánh - ມອບເງິນໃຫ້ສາຂາ" select a;
            txtloaichi.Properties.DataSource = lst0;
            if (Biencucbo.ngonngu.ToString() == "Vietnam")
            {
                coldiengiai.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "Tổng cộng:")});
                gridColumn48.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "Tổng cộng:")});
                gridColumn27.Caption = "Số Hóa đơn";
                gridColumn28.Caption = "Ngày lập";
                gridColumn29.Caption = "Nội dung";
                gridColumn30.Caption = "Đối tượng";
                gridColumn31.Caption = "Tổng tiền (KIP)";
                gridColumn47.Caption = "Mã đơn vị";
                gridColumn79.Caption = "Danh mục";
                gridColumn80.Caption = "Danh mục";
                gridColumn76.Caption = "Tiền tệ";
                gridColumn77.Caption = "Tỷ giá";
                gridColumn78.Caption = "Ghi chú";
                gridColumn43.Caption = "Mã công việc";
                gridColumn44.Caption = "Tên công việc";
                gridColumn46.Caption = "Nhóm công việc";
                gridColumn41.Caption = "Mục chi phí";
                gridColumn42.Caption = "Tên chi phí";
            }
            else
            {
                coldiengiai.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "ລວມທັງໝົດ:")});
                gridColumn48.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "ລວມທັງໝົດ:")});
                gridColumn27.Caption = "ລະຫັດໃບບິນ";
                gridColumn28.Caption = "ວັນທີ່";
                gridColumn29.Caption = "ເນື້ອໃນ";
                gridColumn30.Caption = "ເປົ້າໝາຍ";
                gridColumn31.Caption = "ລວມເປັນເງິນ (ກີບ)";
                gridColumn47.Caption = "ລະຫັດຫົວໜ່ວຍ";
                gridColumn79.Caption = "ລາຍການ";
                gridColumn80.Caption = "ລາຍການ";
                gridColumn76.Caption = "ເງິນຕາ";
                gridColumn77.Caption = "ອັດຕາ";
                gridColumn78.Caption = "ໝາຍເຫດ";
                gridColumn43.Caption = "ລະຫັດຂອງວຽກງານ";
                gridColumn44.Caption = "ຊື່ວຽກງານ";
                gridColumn46.Caption = "ກຸ່ມໜ້າວຽກ";
                gridColumn41.Caption = "ບັນຊີລາຍຈ່າຍ";
                gridColumn42.Caption = "ຊື່ລາຍຈ່າຍ";
            }
        }
        //load
        public void load()
        {
            db = new KetNoiDBDataContext();
            Biencucbo.hdpc = 2;
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
            txtngaynhap.ReadOnly = true;
            txtiddt.ReadOnly = true;
            txtsopn.ReadOnly = true;
            txttiente.ReadOnly = true;
            txttk.ReadOnly = true;
            txtloaichi.ReadOnly = true;
            txttygia.ReadOnly = true;
            gridView1.OptionsBehavior.Editable = false;
            try
            {
                var lst = (from a in db.pchis where a.iddv == Biencucbo.donvi && a.dv == "TM" select a.so).Max();
                var lst1 = (from b in db.pchis where b.iddv == Biencucbo.donvi select b).FirstOrDefault(t => t.so == lst);
                if (lst1 == null) return;
                gcchitiet.DataSource = lst1.pchicts;
                txtid.Text = lst1.id;
                txtidnv.Text = lst1.idnv;
                txtdv.Text = lst1.iddv;
                txtngaynhap.DateTime = DateTime.Parse(lst1.ngaychi.ToString());
                txtiddt.Text = lst1.iddt;
                txtghichu.Text = lst1.ghichu;
                txt1.Text = lst1.so.ToString();
                txttiente.Text = lst1.tiente;
               
                txtloaichi.Text = lst1.loaichi;
                txttygia.Text = lst1.tygia.ToString();
                txtsopn.Text = lst1.link;
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
        // Mở
        private void btnmo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db = new KetNoiDBDataContext();
            Biencucbo.tien = "TM";
            f_dsNopTien frm = new f_dsNopTien();
            frm.ShowDialog();
            if (Biencucbo.getID == 1)
            { 
                try
                {
                    var lst = (from pn in db.pchis select new { a = pn }).FirstOrDefault(x => x.a.id == Biencucbo.ma);
                    if (lst == null) return;
                    txtid.Text = lst.a.id;
                    txtidnv.Text = lst.a.idnv;
                    txtdv.Text = lst.a.iddv;
                    txtngaynhap.DateTime = DateTime.Parse(lst.a.ngaychi.ToString());
                    txtiddt.Text = lst.a.iddt;
                    txttiente.Text = lst.a.tiente;
                 
                    txtloaichi.Text = lst.a.loaichi;
                    txttygia.Text = lst.a.tygia.ToString();
                    txtghichu.Text = lst.a.ghichu;
                    txt1.Text = lst.a.so.ToString();
                    txtsopn.Text = lst.a.link;
                    gcchitiet.DataSource = lst.a.pchicts;
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
        //Thêm
        private void btnnew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdpc = 0;
            txtid.DataBindings.Clear();
            txtid.Text = "YYYYY";
            gcchitiet.DataSource = new DAL.KetNoiDBDataContext().View_pchis;
            for (int i = 0; i <= gridView1.RowCount - 1; i++)
            {
                gridView1.DeleteRow(i);
            }
            gridView1.AddNewRow();
            txtdv.Text = Biencucbo.donvi;
            txtngaynhap.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            txtphongban.Text = Biencucbo.phongban;
            txtidnv.Text = Biencucbo.idnv.Trim();
            lbltennv.Text = Biencucbo.ten;
            txtngaynhap.Focus();
            txtiddt.Text = "";
            lbltendt.Text = "";
            txtsopn.Text = "";
            txtghichu.Text = "";
            txttiente.Text = "KIP";
            txtloaichi.Text = "Nộp Tiền Chi Nhánh - ມອບເງິນໃຫ້ສາຂາ";
            txttygia.Text = "1";
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
            txtngaynhap.ReadOnly = false;
            txtiddt.ReadOnly = false;
            txtsopn.ReadOnly = false;
            txttiente.ReadOnly = false;
          
            txtloaichi.ReadOnly = false;
            gridView1.OptionsBehavior.Editable = true;
        }
        //Lưu
        public void luu()
        {
            t_history hs = new t_history();
            t_tudong td = new t_tudong();
            t_cttk tk = new t_cttk();
            gridView1.UpdateCurrentRow();
            if (txtngaynhap.Text == "" || txtiddt.Text == "" || txtloaichi.Text == "" || txttygia.Text == "" || txtloaichi.Text == "" )
            {
                Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hdpc == 0)
                {
                    db = new KetNoiDBDataContext();
                    try
                    {
                        string check = "PC" + Biencucbo.donvi.Trim().ToString();
                        var lst1 = (from s in db.tudongs where s.maphieu == check select new { so = s.so }).ToList();
                        if (lst1.Count == 0)
                        {
                            int so;
                            so = 2;
                            td.themtudong(check, so, "PC", "Phiếu Chi Tiền Mặt");
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
                        //pchi.moiphieu(txtid.Text, txtngaynhap.DateTime, txtiddt.Text, txtdv.Text, txtidnv.Text, txtghichu.Text, Convert.ToInt32(txt1.Text), txtsopn.Text, txtloaichi.Text, txttiente.Text, double.Parse(txttygia.Text), "TM");
                        for (int i = 0; i <= gridView1.RowCount - 1; i++)
                        {
                            gridView1.SetRowCellValue(i, "idchi", txtid.Text);
                            gridView1.SetRowCellValue(i, "id", txtid.Text + i);
                            //pchi.moict(gridView1.GetRowCellValue(i, "diengiai").ToString(), gridView1.GetRowCellValue(i, "idcv").ToString(), gridView1.GetRowCellValue(i, "idmuccp").ToString(), double.Parse(gridView1.GetRowCellValue(i, "sotien").ToString()), gridView1.GetRowCellValue(i, "idchi").ToString(), gridView1.GetRowCellValue(i, "id").ToString(), gridView1.GetRowCellValue(i, "tiente").ToString(), double.Parse(gridView1.GetRowCellValue(i, "tygia").ToString()), double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()));
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
                        txtngaynhap.ReadOnly = true;
                        txtiddt.ReadOnly = true;
                        txttiente.ReadOnly = true;
                        txttk.ReadOnly = true;
                        txtloaichi.ReadOnly = true;
                        txtsopn.ReadOnly = true;
                        gridView1.OptionsBehavior.Editable = false;
                        Biencucbo.hdpc = 2;
                        // History
                        hs.add(txtid.Text, "Thêm mới chứng từ - ເພີ່ມເອກະສານໃໝ່");
                    }
                    catch (Exception ex)
                    {
                        Lotus.MsgBox.ShowErrorDialog(ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        //pchi.suaphieu(txtid.Text, DateTime.Parse(txtngaynhap.Text), txtiddt.Text, txtghichu.Text, int.Parse(txt1.Text), txtsopn.Text, txtloaichi.Text, txttiente.Text, double.Parse(txttygia.Text));
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
                        txtngaynhap.ReadOnly = true;
                        txtiddt.ReadOnly = true;
                        txtsopn.ReadOnly = true;
                        txttiente.ReadOnly = true;
                        txttk.ReadOnly = true;
                        txtloaichi.ReadOnly = true;
                        gridView1.OptionsBehavior.Editable = false;
                        Biencucbo.hdpc = 2;
                        hs.add(txtid.Text, "Sửa chứng từ - ດັດແກ້ເອກະສານ");
                    }
                    catch (Exception ex)
                    {
                        Lotus.MsgBox.ShowErrorDialog(ex.ToString());
                    }
                }
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.PostEditor();
            luu();
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
                db.pchicts.Context.SubmitChanges(); 
            }
            catch (Exception ex)
            {
                Lotus.MsgBox.ShowErrorDialog(ex.Message);
                return false;
            }
            return true;
        }
        //Sửa
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "")
            {
                return;
            }
            //load 
            try
            {
                var lst = (from pn in db.pchis select pn).FirstOrDefault(x => x.id == txtid.Text);
                if (lst == null) return;
                gcchitiet.DataSource = lst.pchicts;
                //enabled
                txtghichu.ReadOnly = false;
                txtngaynhap.ReadOnly = false;
                txtiddt.ReadOnly = false;
                txtsopn.ReadOnly = false;
                txttiente.ReadOnly = false;
                txttk.ReadOnly = true;
                txtloaichi.ReadOnly = false;
                gridView1.OptionsBehavior.Editable = true;
                Biencucbo.hdpc = 1;
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
        //Xóa
        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "")
            {
                return;
            }
            if (XtraMessageBox.Show("Bạn có chắc chắn muốn xóa Phiếu " + txtid.Text + " không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                t_history hs = new t_history();
                hs.add(txtid.Text, "Xóa chứng từ - ລົບເອກະສານ");
                try
                {
                    for (int i = gridView1.DataRowCount - 1; i >= 0; i--)
                    {
                        pchi.xoact(gridView1.GetRowCellValue(i, "id").ToString());
                        gridView1.DeleteRow(i);
                    }
                    pchi.xoapphieu(txtid.Text);
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
                    txtngaynhap.ReadOnly = true;
                    txtiddt.ReadOnly = true;
                    txtsopn.ReadOnly = true;
                    txttiente.ReadOnly = true;
                    txttk.ReadOnly = true;
                    txtloaichi.ReadOnly = true;
                    gridView1.OptionsBehavior.Editable = false;
                    txtdv.Text = "";
                    txtid.Text = "";
                    txtidnv.Text = "";
                    txtdv.Text = "";
                    txtngaynhap.Text = "";
                    txtiddt.Text = "";
                    txtghichu.Text = "";
                    txt1.Text = "";
                    txtsopn.Text = "";
                    lbltendt.Text = "";
                    lbltennv.Text = "";
                    txttiente.Text = "";
                    txttk.Text = "";
                    txtloaichi.Text = "";
                    txttygia.Text = "";
                }
                catch
                {
                }
            }
        }
        //In
        //reload
        private void btnload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.hdpc == 1)
            {
                db = new KetNoiDBDataContext();
                var lst = (from pn in db.pchis select pn).FirstOrDefault(x => x.id == txtid.Text);
                if (lst == null) return;
                txtidnv.Text = lst.idnv;
                txtdv.Text = lst.iddv;
                txtngaynhap.DateTime = DateTime.Parse(lst.ngaychi.ToString());
                txtiddt.Text = lst.iddt;
                txtghichu.Text = lst.ghichu;
                txt1.Text = lst.so.ToString();
                txtsopn.Text = lst.link;
                gcchitiet.DataSource = lst.pchicts;
                //readonly
                txtghichu.ReadOnly = true;
                txtngaynhap.ReadOnly = true;
                txttiente.ReadOnly = true;
                txttk.ReadOnly = true;
                txtloaichi.ReadOnly = true;
                txttygia.ReadOnly = true;
                txtiddt.ReadOnly = true;
                txtsopn.ReadOnly = true;
                //gcchitiet.Enabled = false;
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
            else if (Biencucbo.hdpc == 0)
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
            Biencucbo.hdpc = 2;
        }
        // thay đổi
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridView1.PostEditor();
            if (e.Column.FieldName == "nguyente")
            {
                try
                {
                    gridView1.SetFocusedRowCellValue("sotien", (double.Parse(gridView1.GetFocusedRowCellValue("nguyente").ToString())) * (double.Parse(txttygia.Text)));
                }
                catch (Exception)
                {
                }
            }
        }
        //Phím Tắt
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Biencucbo.hdpc == 2)
                return;
            if (e.KeyCode == Keys.Insert)
            {
                gridView1.AddNewRow();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (Biencucbo.hdpc == 1)
                {
                    pchict ct = (from c in db.pchicts select c).Single(x => x.id == gridView1.GetFocusedRowCellValue("id").ToString());
                    db.pchicts.DeleteOnSubmit(ct);
                }
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
        }
        //đối tượng
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
        //Dòng mới
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (Biencucbo.hdpc == 1)
            {
                var ct = gridView1.GetFocusedRow() as pchict;
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
                ct.idchi = txtid.Text;
                ct.diengiai = "";
                ct.idmuccp = "";
                ct.idcv = "";
                ct.sotien = 0;
                ct.id = a;
                ct.tiente = "KIP";
                ct.tygia = 1;
                ct.nguyente = 0;
            }
            else
            {
                gridView1.SetFocusedRowCellValue("diengiai", "");
                gridView1.SetFocusedRowCellValue("tygia", 1);
                gridView1.SetFocusedRowCellValue("idmuccp", "");
                gridView1.SetFocusedRowCellValue("tiente", "KIP");
                gridView1.SetFocusedRowCellValue("idcv", "");
                gridView1.SetFocusedRowCellValue("nguyente", 0);
            }
        }
        //Xóa dòng
        private void btnin_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var lst = (from a in db.r_pchis where a.id == txtid.Text select a);
                r_pchi xtra = new r_pchi();
                xtra.DataSource = lst;
                xtra.ShowPreviewDialog();
            }
            catch
            {
            }
        }
        //đóng form
        private void f_pnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Biencucbo.hdpc != 2)
            {
                var a = Lotus.MsgBox.ShowYesNoCancelDialog("Phiếu này chưa được lưu - Bạn có muốn lưu Phiếu này trước khi thoát không?");
                if (a == DialogResult.Yes)
                {
                    luu();
                }
                else if (a == DialogResult.Cancel) e.Cancel = true;
            }
        }
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void btnmuccp_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }
        private void rsearchtiente1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                var lst = (from a in db.tientes select a).Single(t => t.tiente1 == gridView1.GetFocusedRowCellValue("tiente").ToString());
                if (lst == null) return;
                gridView1.SetFocusedRowCellValue("tygia", lst.tygia);
                gridView1.SetFocusedRowCellValue("sotien", int.Parse(gridView1.GetFocusedRowCellValue("nguyente").ToString()) * int.Parse(txttygia.Text));
            }
            catch
            {
            }
        }
        private void f_pchi_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Nộp Tiền Cho Chi Nhánh").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            load();
        }
        private void txttiente_EditValueChanged(object sender, EventArgs e)
        {
            if (txttiente.Text != "")
            {
                var lst = (from a in db.tientes select a).FirstOrDefault(t => t.tiente1 == txttiente.Text);
                txttygia.Text = lst.tygia.ToString();
                for (int i = 0; i <= gridView1.RowCount - 1; i++)
                {
                    try
                    {
                        gridView1.SetRowCellValue(i, "sotien", double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()) * double.Parse(txttygia.Text));
                    }
                    catch
                    {
                    }
                }
            } 
        }
        //private void txttk_EditValueChanged(object sender, EventArgs e)
        //{
        //    var lst = (from a in db.dmtks select a).Single(t => t.matk == txttk.Text);
        //    lbltk.Text = lst.tentk;
        //}
    }
}
