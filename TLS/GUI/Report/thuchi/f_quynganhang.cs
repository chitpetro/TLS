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
using DevExpress.XtraReports.UI;
using BUS;
using ControlLocalizer;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
namespace GUI.Report.Nhap
{
    public partial class f_quynganhang : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick1 = false;
        Boolean doubleclick2 = false;
        public f_quynganhang()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
        }
        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "SỔ QUỸ NGÂN HÀNG").ToString();
            changeFont.Translate(this);
            //translate text
            labelControl1.Text = LanguageHelper.TranslateMsgString(".reportKhoangThoiGian", "Khoảng Thời Gian").ToString();
            labelControl2.Text = LanguageHelper.TranslateMsgString(".reportTuNgay", "Từ Ngày").ToString();
            labelControl3.Text = LanguageHelper.TranslateMsgString(".reportDenNgay", "Đến Ngày").ToString();
            labelControl6.Text = LanguageHelper.TranslateMsgString(".reportDanhMuc", "Danh Mục").ToString();
            tungay.ReadOnly = true;
            denngay.ReadOnly = true;
            danhmuc.Text = "Đơn vị - ຫົວໜ່ວຍ";
            rTime.SetTime2(thoigian);
            try
            {
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a;
                    nhan.DataSource = lst;
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_quynganhang",
                                    MaTim = LayMaTim(a)
                                });
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                    for (int j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                                   where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                                   select a;
                        lst2 = lst3.ToList();
                    };
                    nguon.DataSource = lst2;
                }
                else
                {
                    gridView1.DeleteSelectedRows();
                }
            }
            catch
            {
            }
        }
        private void thoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTime.thoigian_change3(thoigian, tungay, denngay);
        }
        private void danhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
            {
                try
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_quynganhang",
                                    MaTim = LayMaTim(a)
                                });
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                    for (int j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                                   where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                                   select a;
                        lst2 = lst3.ToList();
                    };
                    nguon.DataSource = lst2;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            if (danhmuc.Text == "Tài Khoản")
            {
                try
                {
                    var list = (from a in db.dmtks
                                where a.active == true && a.loaitk == "TIỀN GỬI NGÂN HÀNG"
                                select new
                                {
                                    id = a.matk,
                                    name = a.tentk,
                                    key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_quynganhang",
                                });
                    nguon.DataSource = list;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    for (int j = 0; j < gridView2.DataRowCount; j++)
                    {
                        if (gridView2.GetRowCellValue(j, "loai").ToString() == "Đơn vị - ຫົວໜ່ວຍ")
                        {
                            Lotus.MsgBox.ShowWarningDialog("Chỉ chọn 1 trường đơn vị duy nhất");
                            return;
                        }
                    };
                    dk_rp dk = new dk_rp();
                    dk.id = gridView1.GetFocusedRowCellValue("id").ToString();
                    dk.name = gridView1.GetFocusedRowCellValue("name").ToString();
                    dk.key = gridView1.GetFocusedRowCellValue("key").ToString();
                    dk.form = "f_quynganhang";
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a;
                    nhan.DataSource = lst;
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_quynganhang",
                                    MaTim = LayMaTim(a)
                                });
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                    for (int j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                                   where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                                   select a;
                        lst2 = lst3.ToList();
                    };
                    nguon.DataSource = lst2;
                }
                //else
                //{
                //    gridView1.DeleteSelectedRows();
                //}
            }
            catch
            {
            }
            if (danhmuc.Text == "Tài Khoản")
            {
                try
                {
                    dk_rp dk = new dk_rp();
                    dk.id = gridView1.GetFocusedRowCellValue("id").ToString();
                    dk.name = gridView1.GetFocusedRowCellValue("name").ToString();
                    dk.key = gridView1.GetFocusedRowCellValue("key").ToString();
                    dk.form = "f_quynganhang";
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a;
                    nhan.DataSource = lst2;
                    var lst = (from a in db.dmtks where a.active == true && a.loaitk == "TIỀN GỬI NGÂN HÀNG" select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_quynganhang" });
                    nguon.DataSource = lst;
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            doubleclick1 = false;
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (doubleclick1 == true)
            {
                try
                {
                    if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                    {
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView2.GetRowCellValue(j, "loai").ToString() == "Đơn vị - ຫົວໜ່ວຍ")
                            {
                                Lotus.MsgBox.ShowWarningDialog("Chỉ chọn 1 trường đơn vị duy nhất");
                                return;
                            }
                        };
                        dk_rp dk = new dk_rp();
                        dk.id = gridView1.GetFocusedRowCellValue("id").ToString();
                        dk.name = gridView1.GetFocusedRowCellValue("name").ToString();
                        dk.key = gridView1.GetFocusedRowCellValue("key").ToString();
                        dk.form = "f_quynganhang";
                        dk.loai = danhmuc.Text;
                        dk.user = Biencucbo.idnv;
                        db.dk_rps.InsertOnSubmit(dk);
                        db.SubmitChanges();
                        var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a;
                        nhan.DataSource = lst;
                        var list = (from a in db.donvis
                                    select new
                                    {
                                        id = a.id,
                                        name = a.tendonvi,
                                        key = a.id + danhmuc.Text + Biencucbo.idnv + "f_quynganhang",
                                        MaTim = LayMaTim(a)
                                    });
                        var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            var lst3 = from a in lst2
                                       where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                                       select a;
                            lst2 = lst3.ToList();
                        };
                        nguon.DataSource = lst2;
                    }
                    //else
                    //{
                    //    gridView1.DeleteSelectedRows();
                    //}
                }
                catch
                {
                }
                if (danhmuc.Text == "Tài Khoản")
                {
                    try
                    {
                        dk_rp dk = new dk_rp();
                        dk.id = gridView1.GetFocusedRowCellValue("id").ToString();
                        dk.name = gridView1.GetFocusedRowCellValue("name").ToString();
                        dk.key = gridView1.GetFocusedRowCellValue("key").ToString();
                        dk.form = "f_quynganhang";
                        dk.loai = danhmuc.Text;
                        dk.user = Biencucbo.idnv;
                        db.dk_rps.InsertOnSubmit(dk);
                        db.SubmitChanges();
                        var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a;
                        nhan.DataSource = lst2;
                        var lst = (from a in db.dmtks where a.active == true && a.loaitk == "TIỀN GỬI NGÂN HÀNG" select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_quynganhang" });
                        nguon.DataSource = lst;
                        for (int i = gridView1.RowCount - 1; i >= 0; i--)
                        {
                            for (int j = 0; j < gridView2.DataRowCount; j++)
                            {
                                if (gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
                                {
                                    gridView1.DeleteRow(i);
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick1 = true;
        }
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            doubleclick2 = true;
        }
        private void gridView2_Click(object sender, EventArgs e)
        {
            doubleclick2 = false;
        }
        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (doubleclick2 == true)
            {
                try
                {
                    dk_rp dk = new dk_rp();
                    var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                    db.dk_rps.DeleteOnSubmit(lst);
                    db.SubmitChanges();
                    var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a;
                    nhan.DataSource = lst2;
                }
                catch
                {
                }
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    try
                    {
                        var list = (from a in db.donvis
                                    select new
                                    {
                                        id = a.id,
                                        name = a.tendonvi,
                                        key = a.id + danhmuc.Text + Biencucbo.idnv + "f_quynganhang",
                                        MaTim = LayMaTim(a)
                                    });
                        var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            var lst3 = from a in lst2
                                       where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                                       select a;
                            lst2 = lst3.ToList();
                        };
                        nguon.DataSource = lst2;
                    }
                    catch
                    {
                    }
                }
                if (danhmuc.Text == "Tài Khoản")
                {
                    try
                    {
                        var lst = (from a in db.dmtks where a.active == true && a.loaitk == "TIỀN GỬI NGÂN HÀNG" select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_quynganhang" });
                        nguon.DataSource = lst;
                        for (int i = gridView1.RowCount - 1; i >= 0; i--)
                        {
                            for (int j = 0; j < gridView2.DataRowCount; j++)
                            {
                                if (gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
                                {
                                    gridView1.DeleteRow(i);
                                    break;
                                }
                            }
                        };
                    }
                    catch
                    {
                    }
                }
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                dk_rp dk = new dk_rp();
                var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                db.dk_rps.DeleteOnSubmit(lst);
                db.SubmitChanges();
                var lst2 = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a);
                nhan.DataSource = lst2;
            }
            catch
            {
            }
            if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
            {
                try
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_quynganhang",
                                    MaTim = LayMaTim(a)
                                });
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                    for (int j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                                   where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                                   select a;
                        lst2 = lst3.ToList();
                    };
                    nguon.DataSource = lst2;
                }
                catch
                {
                }
            }
            if (danhmuc.Text == "Tài Khoản")
            {
                try
                {
                    var lst = (from a in db.dmtks where a.active == true && a.loaitk == "TIỀN GỬI NGÂN HÀNG" select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_quynganhang" });
                    nguon.DataSource = lst;
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    };
                }
                catch
                {
                }
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    dk_rp dk = new dk_rp();
                    dk.id = gridView1.GetRowCellValue(i, "id").ToString();
                    dk.name = gridView1.GetRowCellValue(i, "name").ToString();
                    dk.key = gridView1.GetRowCellValue(i, "key").ToString();
                    dk.form = "f_quynganhang";
                    dk.user = Biencucbo.idnv;
                    dk.loai = danhmuc.Text;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a;
                    nhan.DataSource = lst;
                }
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_quynganhang",
                                    MaTim = LayMaTim(a)
                                });
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                    for (int j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                                   where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                                   select a;
                        lst2 = lst3.ToList();
                    };
                    nguon.DataSource = lst2;
                }
                if (danhmuc.Text == "Tài Khoản")
                {
                    try
                    {
                        var lst = (from a in db.dmtks where a.active == true && a.loaitk == "TIỀN GỬI NGÂN HÀNG" select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_quynganhang" });
                        nguon.DataSource = lst;
                        for (int i = gridView1.RowCount - 1; i >= 0; i--)
                        {
                            for (int j = 0; j < gridView2.DataRowCount; j++)
                            {
                                if (gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
                                {
                                    gridView1.DeleteRow(i);
                                    break;
                                }
                            }
                        };
                    }
                    catch
                    {
                    }
                }
                else
                {
                    for (int i = gridView1.RowCount; i > 0; i--)
                    {
                        gridView1.DeleteSelectedRows();
                    }
                }
            }
            catch
            {
            }
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_quynganhang" select a);
                db.dk_rps.DeleteAllOnSubmit(lst);
                db.SubmitChanges();
                nhan.DataSource = lst;
            }
            catch
            {
            }
            if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
            {
                try
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_quynganhang",
                                    MaTim = LayMaTim(a)
                                });
                    var lst2 = list.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                    for (int j = 0; j < gridView2.DataRowCount; j++)
                    {
                        var lst3 = from a in lst2
                                   where a.key != gridView2.GetRowCellValue(j, "key").ToString()
                                   select a;
                        lst2 = lst3.ToList();
                    };
                    nguon.DataSource = lst2;
                }
                catch
                {
                }
            }
            if (danhmuc.Text == "Tài Khoản")
            {
                try
                {
                    var lst = (from a in db.dmtks where a.active == true && a.loaitk == "TIỀN GỬI NGÂN HÀNG" select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_quynganhang" });
                    nguon.DataSource = lst;
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
                            {
                                gridView1.DeleteRow(i);
                                break;
                            }
                        }
                    };
                }
                catch
                {
                }
            }
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);
            try
            {
                Biencucbo.loai = "";
                Biencucbo.doituong = "";
                Biencucbo.congviec = "";
                Biencucbo.muccp = "";
                Biencucbo.kho = "";
                int check = 0;
                int check1 = 0;
                int check2 = 0;
                int check3 = 0;
                int check4 = 0;
                int check5 = 0;
                for (int i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Đơn vị - ຫົວໜ່ວຍ")
                    {
                        check++;
                        Biencucbo.kho = Biencucbo.kho + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
                    }
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Tài Khoản")
                    {
                        check5++;
                        Biencucbo.taikhoan = Biencucbo.taikhoan + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
                    }
                }
                if (check == 0)
                {
                    Lotus.MsgBox.ShowWarningDialog("Cần phải chọn 1 trường dữ liệu bắt buộc: Đơn vị");
                    return;
                }
                if (check5 == 0)
                {
                    Lotus.MsgBox.ShowWarningDialog("Cần phải chọn 1 trường dữ liệu bắt buộc: Tài Khoản");
                    return;
                }
                else
                {
                    if (Biencucbo.ngonngu.ToString() == "Vietnam")
                    {
                        if (check1 == 0)
                        {
                            Biencucbo.loai = "Tất cả";
                        }
                        if (check2 == 0)
                        {
                            Biencucbo.doituong = "Tất cả";
                        }
                        if (check3 == 0)
                        {
                            Biencucbo.congviec = "Tất cả";
                        }
                        if (check4 == 0)
                        {
                            Biencucbo.muccp = "Tất cả";
                        }
                        if (thoigian.Text == "Tùy ý")
                        {
                            Biencucbo.time = "Từ ngày: " + tungay.Text + " Đến ngày: " + denngay.Text;
                        }
                        else if (thoigian.Text == "Cả Năm")
                        {
                            Biencucbo.time = thoigian.Text + " " + DateTime.Now.Year;
                        }
                        else
                        {
                            Biencucbo.time = thoigian.Text + ", năm " + DateTime.Now.Year;
                        }
                    }
                    else
                    {
                        if (check1 == 0)
                        {
                            Biencucbo.loai = "ທັງໝົດ";
                        }
                        if (check2 == 0)
                        {
                            Biencucbo.doituong = "ທັງໝົດ";
                        }
                        if (check3 == 0)
                        {
                            Biencucbo.congviec = "ທັງໝົດ";
                        }
                        if (check4 == 0)
                        {
                            Biencucbo.muccp = "ທັງໝົດ";
                        }
                        if (thoigian.Text == "ແລ້ວແຕ່")
                        {
                            Biencucbo.time = "ແຕ່: " + tungay.Text + " ເຖິງ: " + denngay.Text;
                        }
                        else if (thoigian.Text == "ໝົດປີ")
                        {
                            Biencucbo.time = thoigian.Text + " " + DateTime.Now.Year;
                        }
                        else
                        {
                            Biencucbo.time = thoigian.Text + ", ປີ " + DateTime.Now.Year;
                        }
                    }
                    if (tsntqd.IsOn)
                    {
                        var tk1 = from b in db.dmtks where b.matk == "0" select b;
                        for (int i = 0; i < gridView2.DataRowCount; i++)
                        {
                            if (gridView2.GetRowCellValue(i, "loai").ToString() == "Tài Khoản")
                            {
                                string ma = gridView2.GetRowCellValue(i, "id").ToString();
                                var tk2 = (from a in db.dmtks
                                           where a.active == true
                                           select a
                                       ).Where(t => t.matk.StartsWith(ma));
                                tk1 = tk1.Union(tk2);
                            }
                        }
                        var tk = tk1;
                        var lst = (from a in db.ct_tks
                                   join b in tk on a.tk_co equals b.matk
                                   where a.ngaychungtu < tungay.DateTime
                                   select a);
                        var lst3 = (from a in lst
                                    join b in db.dk_rps on a.iddv equals b.id
                                    where a.ngaychungtu < tungay.DateTime
                                    && b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_quynganhang"
                                    select a.PS).Sum();
                        lst = (from a in db.ct_tks
                               join b in tk on a.tk_no equals b.matk
                               where a.ngaychungtu < tungay.DateTime
                               select a);
                        var lst4 = (from a in lst
                                    join b in db.dk_rps on a.iddv equals b.id
                                    where a.ngaychungtu < tungay.DateTime
                                    && b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_quynganhang"
                                    select a.PS).Sum();
                        if (lst3 == null)
                        {
                            lst3 = 0;
                        }
                        if (lst4 == null)
                        {
                            lst4 = 0;
                        }
                        Biencucbo.tondau = double.Parse(lst4.ToString()) - double.Parse(lst3.ToString());
                        lst = (from a in db.ct_tks
                               join b in tk on a.tk_co equals b.matk
                               where a.ngaychungtu <= denngay.DateTime
                               select a);
                        var lst5 = (from a in lst
                                    join b in db.dk_rps on a.iddv equals b.id
                                    where a.ngaychungtu <= denngay.DateTime
                                    && b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_quynganhang"
                                    select a.PS).Sum();
                        lst = (from a in db.ct_tks
                               join b in tk on a.tk_no equals b.matk
                               where a.ngaychungtu <= denngay.DateTime
                               select a);
                        var lst6 = (from a in lst
                                    join b in db.dk_rps on a.iddv equals b.id
                                    where a.ngaychungtu <= denngay.DateTime
                                    && b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_quynganhang"
                                    select a.PS).Sum();
                        if (lst5 == null)
                        {
                            lst5 = 0;
                        }
                        if (lst6 == null)
                        {
                            lst6 = 0;
                        }
                        Biencucbo.toncuoi = double.Parse(lst6.ToString()) - double.Parse(lst5.ToString());
                        var lst2 = (from a in db.ct_tks
                                    join b in tk on a.tk_co equals b.matk
                                    where a.ngaychungtu >= tungay.DateTime && a.ngaychungtu <= denngay.DateTime
                                    select new
                                    {
                                        idthu = "",
                                        idchi = a.machungtu,
                                        a.iddv,
                                        ngay = a.ngaychungtu,
                                        diengiai = a.diengiai,
                                        taikhoan = a.tk_co,
                                        a.tiente,
                                        sotien = a.PS,
                                        thanhtien = a.PS - a.PS,
                                    }).Concat(from a in db.ct_tks
                                              join b in tk on a.tk_no equals b.matk
                                              where a.ngaychungtu >= tungay.DateTime && a.ngaychungtu <= denngay.DateTime
                                              select new
                                              {
                                                  idthu = a.machungtu,
                                                  idchi = "",
                                                  a.iddv,
                                                  ngay = a.ngaychungtu,
                                                  diengiai = a.diengiai,
                                                  taikhoan = a.tk_no,
                                                  a.tiente,
                                                  sotien = a.PS - a.PS,
                                                  thanhtien = a.PS,
                                              }).OrderBy(t => t.ngay);
                        Biencucbo.tondau2 = Biencucbo.tondau;
                        key = 1;
                        var lst7 = (from a in lst2
                                    join b in db.dk_rps on a.iddv equals b.id
                                    where b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_quynganhang"
                                    orderby a.idchi ascending
                                    orderby a.ngay ascending
                                    select new
                                    {
                                        idthu = a.idthu,
                                        idchi = a.idchi,
                                        ngaythu = a.ngay,
                                        diengiai = a.diengiai,
                                        sotien = a.sotien,
                                        thanhtien = a.thanhtien,
                                        tondau = Biencucbo.tondau,
                                        toncuoi = Biencucbo.toncuoi,
                                        tondau2 = timton(a.ngay),
                                        stt = stt(a.ngay),
                                    });
                        for (int i = 0; i <= gridView2.DataRowCount - 1; i++)
                        {
                            if (gridView2.GetRowCellValue(i, "loai").ToString() == "Tài Khoản")
                            {
                                var abc = (from a in db.dmtks select a).Single(t => t.matk == gridView2.GetRowCellValue(i, "id").ToString());
                                Biencucbo.tiente = abc.tiente;
                            }
                        }
                        Biencucbo.nt = 1;
                        Biencucbo.title = "SỔ QUỸ NGÂN HÀNG";
                        r_sothuchi xtra = new r_sothuchi();
                        xtra.DataSource = lst7;
                        ReportPrintTool rpt = new ReportPrintTool(xtra);
                        rpt.PreviewForm.MdiParent = Application.OpenForms[0];
                        rpt.PreviewForm.Text = "BÁO CÁO SỔ QUỸ NGÂN HÀNG";
                        rpt.ShowPreview();
                    }
                    else
                    {
                        var tk1 = from b in db.dmtks where b.matk == "0" select b;
                        for (int i = 0; i < gridView2.DataRowCount; i++)
                        {
                            if (gridView2.GetRowCellValue(i, "loai").ToString() == "Tài Khoản")
                            {
                                string ma = gridView2.GetRowCellValue(i, "id").ToString();
                                var tk2 = (from a in db.dmtks
                                           where a.active == true
                                           select a
                                       ).Where(t => t.matk.StartsWith(ma));
                                tk1 = tk1.Union(tk2);
                            }
                        }
                        var tk = tk1;
                        var lst = (from a in db.ct_tks
                                   join b in tk on a.tk_co equals b.matk
                                   where a.ngaychungtu < tungay.DateTime
                                   select a);
                        var lst3 = (from a in lst
                                    join b in db.dk_rps on a.iddv equals b.id
                                    where a.ngaychungtu < tungay.DateTime
                                    && b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_quynganhang"
                                    select a.PS_nt).Sum();
                        lst = (from a in db.ct_tks
                               join b in tk on a.tk_no equals b.matk
                               where a.ngaychungtu < tungay.DateTime
                               select a);
                        var lst4 = (from a in lst
                                    join b in db.dk_rps on a.iddv equals b.id
                                    where a.ngaychungtu < tungay.DateTime
                                    && b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_quynganhang"
                                    select a.PS_nt).Sum();
                        if (lst3 == null)
                        {
                            lst3 = 0;
                        }
                        if (lst4 == null)
                        {
                            lst4 = 0;
                        }
                        Biencucbo.tondau = double.Parse(lst4.ToString()) - double.Parse(lst3.ToString());
                        lst = (from a in db.ct_tks
                               join b in tk on a.tk_co equals b.matk
                               where a.ngaychungtu <= denngay.DateTime
                               select a);
                        var lst5 = (from a in lst
                                    join b in db.dk_rps on a.iddv equals b.id
                                    where a.ngaychungtu <= denngay.DateTime
                                    && b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_quynganhang"
                                    select a.PS_nt).Sum();
                        lst = (from a in db.ct_tks
                               join b in tk on a.tk_no equals b.matk
                               where a.ngaychungtu <= denngay.DateTime
                               select a);
                        var lst6 = (from a in lst
                                    join b in db.dk_rps on a.iddv equals b.id
                                    where a.ngaychungtu <= denngay.DateTime
                                    && b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_quynganhang"
                                    select a.PS_nt).Sum();
                        if (lst5 == null)
                        {
                            lst5 = 0;
                        }
                        if (lst6 == null)
                        {
                            lst6 = 0;
                        }
                        Biencucbo.toncuoi = double.Parse(lst6.ToString()) - double.Parse(lst5.ToString());
                        var lst2 = (from a in db.ct_tks
                                    join b in tk on a.tk_co equals b.matk
                                    where a.ngaychungtu >= tungay.DateTime && a.ngaychungtu <= denngay.DateTime
                                    select new
                                    {
                                        idthu = "",
                                        idchi = a.machungtu,
                                        a.iddv,
                                        ngay = a.ngaychungtu,
                                        diengiai = a.diengiai,
                                        taikhoan = a.tk_co,
                                        a.tiente,
                                        sotien = a.PS_nt,
                                        thanhtien = a.PS_nt - a.PS_nt,
                                    }).Concat(from a in db.ct_tks
                                              join b in tk on a.tk_no equals b.matk
                                              where a.ngaychungtu >= tungay.DateTime && a.ngaychungtu <= denngay.DateTime
                                              select new
                                              {
                                                  idthu = a.machungtu,
                                                  idchi = "",
                                                  a.iddv,
                                                  ngay = a.ngaychungtu,
                                                  diengiai = a.diengiai,
                                                  taikhoan = a.tk_no,
                                                  a.tiente,
                                                  sotien = a.PS_nt - a.PS_nt,
                                                  thanhtien = a.PS_nt,
                                              }).OrderBy(t => t.ngay);
                        Biencucbo.tondau2 = Biencucbo.tondau;
                        key = 1;
                        var lst7 = (from a in lst2
                                    join b in db.dk_rps on a.iddv equals b.id
                                    where b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_quynganhang"
                                    orderby a.idchi ascending
                                    orderby a.ngay ascending
                                    select new
                                    {
                                        idthu = a.idthu,
                                        idchi = a.idchi,
                                        ngaythu = a.ngay,
                                        diengiai = a.diengiai,
                                        sotien = a.sotien,
                                        thanhtien = a.thanhtien,
                                        tondau = Biencucbo.tondau,
                                        toncuoi = Biencucbo.toncuoi,
                                        tondau2 = timton(a.ngay),
                                        stt = stt(a.ngay),
                                    });
                        for (int i = 0; i <= gridView2.DataRowCount - 1; i++)
                        {
                            if (gridView2.GetRowCellValue(i, "loai").ToString() == "Tài Khoản")
                            {
                                var abc = (from a in db.dmtks select a).Single(t => t.matk == gridView2.GetRowCellValue(i, "id").ToString());
                                Biencucbo.tiente = abc.tiente;
                            }
                        }
                        Biencucbo.nt = 1;
                        Biencucbo.title = "SỔ QUỸ NGÂN HÀNG";
                        r_sothuchi xtra = new r_sothuchi();
                        xtra.DataSource = lst7;
                        xtra.ShowPreviewDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SplashScreenManager.CloseForm(false);
        }
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
        private double? timton(DateTime? a)
        {
            double? b = 0;
            b = Biencucbo.tondau2;
            Biencucbo.tondau2 = 0;
            return b;
        }
        public int key = 1;
        private int stt(DateTime? a)
        {
            int b = 0;
            b = key;
            key++;
            return b;
        }
    }
}
