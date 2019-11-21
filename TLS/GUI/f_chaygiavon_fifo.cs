using BUS;
using DevExpress.XtraGrid.Views.Grid;
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
using ControlLocalizer;
using DevExpress.XtraSplashScreen;
namespace GUI
{
    public partial class f_chaygiavon_fifo : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick = false;
        t_cttk tk = new t_cttk();
        t_hoadon xk = new t_hoadon();
        double mua = 0;
        double ban = 0;
        double nguyente = 0;
        double thanhtien = 0;
        double dongia3 = 0;
        double dongia2 = 0;
        t_tonsp ton = new t_tonsp();
        public f_chaygiavon_fifo()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
            //lay quyen
            var quyen1 = db.PhanQuyen2s.FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "ChayGiaVon");
            btnchay.Enabled = (bool)quyen1.Xem;
        }
        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));
            try
            {
                var lst = from a in db.r_pxuatkhos
                          join d in db.donvis on a.iddv equals d.id
                          where
                          a.ngaylap >= tungay && a.ngaylap <= denngay && a.iddv == Biencucbo.donvi
                          select new
                          {
                              id = a.id,
                              ngayhd = a.ngaylap,
                              iddt = a.iddt,
                              idnv = a.idnv,
                              iddv = a.iddv,
                              idcv = a.idcv,
                              ten = a.ten,
                              noidung = a.diengiai,
                              dv = a.dv,
                              link = a.link,
                              ghichu = a.ghichu,
                              loaixuat = a.loaixuat,
                              idsanpham = a.idsanpham,
                              soluong = a.soluong,
                              thanhtien = a.thanhtien,
                              tiente = a.tiente,
                              nguyente = a.nguyente,
                              a.thue,
                              a.chietkhau,
                              a.so,
                              a.tygia,
                              id2 = a.id2,
                              a.dongia,
                          };
                var lst2 = lst.ToList();
                gridControl1.DataSource = lst2;
            }
            catch (Exception ex)
            {
                Lotus.MsgBox.ShowErrorDialog(ex.ToString());
            }
            SplashScreenManager.CloseForm();
        }
        #region code cu
        private string LayMaTim(donvi d)
        {
            string s = "." + d.id + "." + d.iddv + ".";
            var find = db.donvis.FirstOrDefault(t => t.id == d.iddv);
            if (find != null)
            {
                string iddv = find.iddv;
                if (d.id != find.iddv)
                {
                    if (!s.Contains(iddv))
                        s += iddv + ".";
                }
                while (iddv != find.id)
                {
                    if (!s.Contains(find.id))
                        s += find.id + ".";
                    find = db.donvis.FirstOrDefault(t => t.id == find.iddv);
                }
            }
            return s;
        }
        #endregion
        private void f_PN_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Chạy Giá Vốn").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            tungay.ReadOnly = true;
            denngay.ReadOnly = true;
            Biencucbo.getID = 0;
        }
        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
            changeTime.thoigian_change3(thoigian, tungay, denngay);
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }
        private void timkiem_Click(object sender, EventArgs e)
        {
            loaddata(DateTime.Parse(tungay.Text), DateTime.Parse(denngay.Text));
        }
        private void gridView1_CustomDrawRowIndicator_1(object sender, RowIndicatorCustomDrawEventArgs e)
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
        private void gridView1_Click(object sender, EventArgs e)
        {
            doubleclick = false;
        }
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (doubleclick == true)
            {
                Biencucbo.getID = 1;
                Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                this.Close();
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
        }
        private void btnchay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.Columns["ngayhd"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            for (int j = 0; j < gridView1.DataRowCount; j++)
            {
                try
                {
                    var tmua = (from a in db.r_pnhaps where a.ngaynhap <= DateTime.Parse(gridView1.GetRowCellValue(j, "ngayhd").ToString()) && a.iddv == Biencucbo.donvi && a.idsanpham == gridView1.GetRowCellValue(j, "idsanpham").ToString() /*orderby a.so descending*/ select a);
                    if (tmua.ToList().Count == 0)
                    {
                        mua = 0;
                    }
                    else
                    {
                        mua = double.Parse(tmua.Sum(t => t.soluong).ToString());
                    }
                    var tban = (from a in db.r_pxuatkhos where a.ngaylap <= DateTime.Parse(gridView1.GetRowCellValue(j, "ngayhd").ToString()) && a.so < int.Parse(gridView1.GetRowCellValue(j, "so").ToString()) && a.iddv == Biencucbo.donvi && a.idsanpham == gridView1.GetRowCellValue(j, "idsanpham").ToString() /*orderby a.so descending*/ select a);
                    if (tban.ToList().Count == 0)
                    {
                        ban = 0;
                    }
                    else
                    {
                        ban = double.Parse(tban.Sum(t => t.soluong).ToString());
                    }
                    Biencucbo.tonxuat = mua - ban;
                    Biencucbo.tonxuat2 = Biencucbo.tonxuat;
                    //if (Biencucbo.tonxuat <= dongia3)
                    //    dongia3 = Biencucbo.tonxuat;
                    if (mua - (ban + double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString())) < 0)
                    {
                        Lotus.MsgBox.ShowWarningDialog("Số lượng hàng tồn kho không đủ, không thể tiếp tục chạy giá vốn  - Vui lòng kiểm tra lại!");
                        return;
                    }
                    else
                    {
                        var lst = (from a in db.ct_tks
                                   where (a.tk_no == "1561" || a.tk_no == "1562") && a.ngaychungtu <= DateTime.Parse(gridView1.GetRowCellValue(j, "ngayhd").ToString()) && a.iddv == Biencucbo.donvi && a.idsp == gridView1.GetRowCellValue(j, "idsanpham").ToString() && a.loaichungtu != "PX"
                                   orderby a.sochungtu descending
                                   select new
                                   {
                                       idsanpham = a.idsp,
                                       soluong = a.soluong != 0 ? a.soluong : 0,
                                       //dongia = (a.PS != 0 ? a.PS : 0),
                                       dongia = (a.PS) / (a.soluong),
                                       dongia2 = a.tk_no == "1562" ? a.PS / a.soluong : 0,
                                       so = a.sochungtu,
                                       ngay = a.ngaychungtu,
                                   }).GroupBy(t=> new { t.idsanpham, t.soluong, t.so, t.ngay }).Select(t=> new {t.Key.idsanpham,t.Key.ngay,t.Key.so,t.Key.soluong,dongia = t.Sum(y=>y.dongia) , dongia2 = t.Sum(y=>y.dongia2) });
                        gridControl2.DataSource = lst;
                        gridView2.Columns["ngay"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                        ton.xoa(gridView1.GetRowCellValue(j, "idsanpham").ToString(), Biencucbo.donvi, Biencucbo.idnv);
                        for (int i = 0; i < gridView2.DataRowCount; i++)
                        {
                            string a = "";
                            if (Biencucbo.tonxuat >= double.Parse(gridView2.GetRowCellValue(i, "soluong").ToString()))
                            {
                                a = gridView1.GetRowCellValue(j, "idsanpham").ToString() + Biencucbo.donvi + Biencucbo.idnv + i;
                                ton.moi(a, Biencucbo.donvi, gridView1.GetRowCellValue(j, "idsanpham").ToString(), double.Parse(gridView2.GetRowCellValue(i, "soluong").ToString()), double.Parse(gridView2.GetRowCellValue(i, "dongia").ToString()), int.Parse(gridView2.GetRowCellValue(i, "so").ToString()), Biencucbo.idnv, double.Parse(gridView2.GetRowCellValue(i, "dongia2").ToString()), DateTime.Parse(gridView2.GetRowCellValue(i, "ngay").ToString()));
                                Biencucbo.tonxuat = Biencucbo.tonxuat - double.Parse(gridView2.GetRowCellValue(i, "soluong").ToString());
                            }
                            else
                            {
                                if (Biencucbo.tonxuat != 0)
                                {
                                    a = gridView1.GetRowCellValue(j, "idsanpham").ToString() + Biencucbo.donvi + Biencucbo.idnv + i;
                                    ton.moi(a, Biencucbo.donvi, gridView1.GetRowCellValue(j, "idsanpham").ToString(), double.Parse(Biencucbo.tonxuat.ToString()), double.Parse(gridView2.GetRowCellValue(i, "dongia").ToString()), int.Parse(gridView2.GetRowCellValue(i, "so").ToString()), Biencucbo.idnv, double.Parse(gridView2.GetRowCellValue(i, "dongia2").ToString()), DateTime.Parse(gridView2.GetRowCellValue(i, "ngay").ToString()));
                                    Biencucbo.tonxuat = 0;
                                }
                            }
                        }
                        //db = new KetNoiDBDataContext();
                        var lst2 = (from a in new DAL.KetNoiDBDataContext().tonsps
                                    where a.idsp == gridView1.GetRowCellValue(j, "idsanpham").ToString() && a.iddv == Biencucbo.donvi && a.idnv == Biencucbo.idnv
                                    orderby a.so ascending
                                    select new
                                    {
                                        idsanpham = a.idsp,
                                        a.soluong,
                                        a.dongia,
                                        a.so,
                                        a.dongia2,
                                        a.ngay
                                    });
                        gridControl2.DataSource = lst2;
                        gridView2.Columns["ngay"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        ton.xoa2(gridView1.GetRowCellValue(j, "idsanpham").ToString(), Biencucbo.donvi, Biencucbo.idnv);
                        Biencucbo.tonxuat = double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString());
                        for (int i = 0; i < gridView2.DataRowCount; i++)
                        {
                            string a = "";
                            if (Biencucbo.tonxuat >= double.Parse(gridView2.GetRowCellValue(i, "soluong").ToString()))
                            {
                                a = gridView1.GetRowCellValue(j, "idsanpham").ToString() + Biencucbo.donvi + Biencucbo.idnv + i;
                                ton.moi2(a, Biencucbo.donvi, gridView1.GetRowCellValue(j, "idsanpham").ToString(), double.Parse(gridView2.GetRowCellValue(i, "soluong").ToString()), double.Parse(gridView2.GetRowCellValue(i, "dongia").ToString()), int.Parse(gridView2.GetRowCellValue(i, "so").ToString()), Biencucbo.idnv, double.Parse(gridView2.GetRowCellValue(i, "dongia2").ToString()), DateTime.Parse(gridView2.GetRowCellValue(i, "ngay").ToString()));
                                Biencucbo.tonxuat = Biencucbo.tonxuat - double.Parse(gridView2.GetRowCellValue(i, "soluong").ToString());
                            }
                            else
                            {
                                if (Biencucbo.tonxuat != 0)
                                {
                                    a = gridView1.GetRowCellValue(j, "idsanpham").ToString() + Biencucbo.donvi + Biencucbo.idnv + i;
                                    ton.moi2(a, Biencucbo.donvi, gridView1.GetRowCellValue(j, "idsanpham").ToString(), double.Parse(Biencucbo.tonxuat.ToString()), double.Parse(gridView2.GetRowCellValue(i, "dongia").ToString()), int.Parse(gridView2.GetRowCellValue(i, "so").ToString()), Biencucbo.idnv, double.Parse(gridView2.GetRowCellValue(i, "dongia2").ToString()), DateTime.Parse(gridView2.GetRowCellValue(i, "ngay").ToString()));
                                    Biencucbo.tonxuat = 0;
                                }
                            }
                        }
                        //db = new KetNoiDBDataContext();
                        var lst3 = (from a in new DAL.KetNoiDBDataContext().tonsp2s
                                    where a.idsp == gridView1.GetRowCellValue(j, "idsanpham").ToString() && a.iddv == Biencucbo.donvi && a.idnv == Biencucbo.idnv
                                    select new
                                    {
                                        thanhtien = a.soluong * a.dongia,
                                        thanhtien2 = a.soluong * a.dongia2,
                                    });
                        //var lst4 = (from a in db.tonsp2s
                        //            where a.idsp == gridView1.GetRowCellValue(j, "idsanpham").ToString() && a.iddv == Biencucbo.donvi && a.idnv == Biencucbo.idnv
                        //            select new
                        //            {
                        //                thanhtien = a.soluong * a.dongia,
                        //                thanhtien2 = a.soluong * a.dongia2,
                        //            });
                        dongia3 = double.Parse(lst3.Sum(t => t.thanhtien).ToString()) / double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString());
                        dongia2 = double.Parse(lst3.Sum(t => t.thanhtien2).ToString()) / double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString());
                        nguyente = (((double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString()) * dongia3) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetRowCellValue(j, "chietkhau").ToString())))) + double.Parse(gridView1.GetRowCellValue(j, "thue").ToString()));
                        thanhtien = nguyente * double.Parse(gridView1.GetRowCellValue(j, "tygia").ToString());
                        xk.suaxkct(dongia3, nguyente, gridView1.GetRowCellValue(j, "id2").ToString(), thanhtien);
                        //tk.chaygiavon(gridView1.GetRowCellValue(j, "id2").ToString(), thanhtien, nguyente);
                        // định khoản
                        tk.xoa(gridView1.GetRowCellValue(j, "id").ToString());
                        dongia3 = dongia3 - dongia2;
                        nguyente = (((double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString()) * dongia3) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetRowCellValue(j, "chietkhau").ToString())))));
                        thanhtien = nguyente * double.Parse(gridView1.GetRowCellValue(j, "tygia").ToString());
                        if (gridView1.GetRowCellValue(j, "loaixuat").ToString() == "Xuất bán - ຈ່າຍອອກຂາຍ")
                        {
                            tk.moi(gridView1.GetRowCellValue(j, "id2").ToString() + "1", gridView1.GetRowCellValue(j, "iddv").ToString(), "PX", gridView1.GetRowCellValue(j, "id").ToString(), DateTime.Parse(gridView1.GetRowCellValue(j, "ngayhd").ToString()), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), int.Parse(gridView1.GetRowCellValue(j, "so").ToString()), gridView1.GetRowCellValue(j, "iddt").ToString(), gridView1.GetRowCellValue(j, "iddv").ToString(), gridView1.GetRowCellValue(j, "noidung").ToString(), "632", "1561", thanhtien, gridView1.GetRowCellValue(j, "tiente").ToString(), double.Parse(gridView1.GetRowCellValue(j, "tygia").ToString()), nguyente, gridView1.GetRowCellValue(j, "idsanpham").ToString(), "", Biencucbo.idnv, gridView1.GetRowCellValue(j, "loaixuat").ToString(), gridView1.GetRowCellValue(j, "idcv").ToString(), "", gridView1.GetRowCellValue(j, "ten").ToString(), gridView1.GetRowCellValue(j, "ghichu").ToString(), double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString()));
                        }
                        else if (gridView1.GetRowCellValue(j, "loaixuat").ToString() == "Điều chuyển nội bộ - ເຄື່ອນຍ້າຍພາຍໃນ")
                        {
                            tk.moi(gridView1.GetRowCellValue(j, "id2").ToString() + "1", gridView1.GetRowCellValue(j, "iddv").ToString(), "PX", gridView1.GetRowCellValue(j, "id").ToString(), DateTime.Parse(gridView1.GetRowCellValue(j, "ngayhd").ToString()), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), int.Parse(gridView1.GetRowCellValue(j, "so").ToString()), gridView1.GetRowCellValue(j, "iddt").ToString(), gridView1.GetRowCellValue(j, "iddv").ToString(), gridView1.GetRowCellValue(j, "noidung").ToString(), "1561", "1561", thanhtien, gridView1.GetRowCellValue(j, "tiente").ToString(), double.Parse(gridView1.GetRowCellValue(j, "tygia").ToString()), nguyente, gridView1.GetRowCellValue(j, "idsanpham").ToString(), "", Biencucbo.idnv, gridView1.GetRowCellValue(j, "loaixuat").ToString(), gridView1.GetRowCellValue(j, "idcv").ToString(), "", gridView1.GetRowCellValue(j, "ten").ToString(), gridView1.GetRowCellValue(j, "ghichu").ToString(), double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString()));
                        }
                        else if (gridView1.GetRowCellValue(j, "loaixuat").ToString() == "Xuất dùng - ຈ່າຍອອກໃຊ້")
                        {
                            //tk.moi(txtid.Text + i + "1", txtdv.Text, "PX", txtid.Text, txtngaylap.DateTime, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), Convert.ToInt32(txt1.Text), txtiddt.Text, txtdv.Text, gridView1.GetRowCellValue(i, "diengiai").ToString(), "642", "1561", (double.Parse(gridView1.GetRowCellValue(i, "thanhtien").ToString())), txttiente.Text, double.Parse(txttygia.Text), double.Parse(gridView1.GetRowCellValue(i, "nguyente").ToString()), gridView1.GetRowCellValue(i, "idsanpham").ToString(), gridView1.GetRowCellValue(i, "id").ToString(), txtidnv.Text, txtloaihd.Text, gridView1.GetRowCellValue(i, "idcv").ToString(), "", lbltendt.Text, txtghichu.Text, double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString()));
                            tk.moi(gridView1.GetRowCellValue(j, "id2").ToString() + "2", gridView1.GetRowCellValue(j, "iddv").ToString(), "PX", gridView1.GetRowCellValue(j, "id").ToString(), DateTime.Parse(gridView1.GetRowCellValue(j, "ngayhd").ToString()), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), int.Parse(gridView1.GetRowCellValue(j, "so").ToString()), gridView1.GetRowCellValue(j, "iddt").ToString(), gridView1.GetRowCellValue(j, "iddv").ToString(), gridView1.GetRowCellValue(j, "noidung").ToString(), "641", "1561", thanhtien, gridView1.GetRowCellValue(j, "tiente").ToString(), double.Parse(gridView1.GetRowCellValue(j, "tygia").ToString()), nguyente, gridView1.GetRowCellValue(j, "idsanpham").ToString(), "", Biencucbo.idnv, gridView1.GetRowCellValue(j, "loaixuat").ToString(), gridView1.GetRowCellValue(j, "idcv").ToString(), "", gridView1.GetRowCellValue(j, "ten").ToString(), gridView1.GetRowCellValue(j, "ghichu").ToString(), double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString()));
                        }
                        else if (gridView1.GetRowCellValue(j, "loaixuat").ToString() == "Xuất hao hụt - ຈ່າຍບົກແຫ້ງລະເຫີຍອາຍ")
                        {
                            tk.moi(gridView1.GetRowCellValue(j, "id2").ToString() + "1", gridView1.GetRowCellValue(j, "iddv").ToString(), "PX", gridView1.GetRowCellValue(j, "id").ToString(), DateTime.Parse(gridView1.GetRowCellValue(j, "ngayhd").ToString()), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), int.Parse(gridView1.GetRowCellValue(j, "so").ToString()), gridView1.GetRowCellValue(j, "iddt").ToString(), gridView1.GetRowCellValue(j, "iddv").ToString(), gridView1.GetRowCellValue(j, "noidung").ToString(), "1388", "1561", thanhtien, gridView1.GetRowCellValue(j, "tiente").ToString(), double.Parse(gridView1.GetRowCellValue(j, "tygia").ToString()), nguyente, gridView1.GetRowCellValue(j, "idsanpham").ToString(), "", Biencucbo.idnv, gridView1.GetRowCellValue(j, "loaixuat").ToString(), gridView1.GetRowCellValue(j, "idcv").ToString(), "", gridView1.GetRowCellValue(j, "ten").ToString(), gridView1.GetRowCellValue(j, "ghichu").ToString(), double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString()));
                        }
                        nguyente = (((double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString()) * dongia2) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetRowCellValue(j, "chietkhau").ToString())))) /*+ double.Parse(gridView1.GetRowCellValue(j, "thue").ToString())*/);
                        thanhtien = nguyente * double.Parse(gridView1.GetRowCellValue(j, "tygia").ToString());
                        tk.moi(gridView1.GetRowCellValue(j, "id2").ToString() + "3", gridView1.GetRowCellValue(j, "iddv").ToString(), "CGV", gridView1.GetRowCellValue(j, "id").ToString(), DateTime.Parse(gridView1.GetRowCellValue(j, "ngayhd").ToString()), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), int.Parse(gridView1.GetRowCellValue(j, "so").ToString()), gridView1.GetRowCellValue(j, "iddt").ToString(), gridView1.GetRowCellValue(j, "iddv").ToString(), gridView1.GetRowCellValue(j, "noidung").ToString(), "632", "1562", thanhtien, gridView1.GetRowCellValue(j, "tiente").ToString(), double.Parse(gridView1.GetRowCellValue(j, "tygia").ToString()), nguyente, gridView1.GetRowCellValue(j, "idsanpham").ToString(), "", Biencucbo.idnv, gridView1.GetRowCellValue(j, "loaixuat").ToString(), gridView1.GetRowCellValue(j, "idcv").ToString(), "", gridView1.GetRowCellValue(j, "ten").ToString(), gridView1.GetRowCellValue(j, "ghichu").ToString(), double.Parse(gridView1.GetRowCellValue(j, "soluong").ToString()));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            MessageBox.Show("Done!", "THÔNG BÁO");
            loaddata(tungay.DateTime, denngay.DateTime);
        }
    }
}
