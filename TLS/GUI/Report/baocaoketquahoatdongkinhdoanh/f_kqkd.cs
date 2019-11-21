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
using GUI.Report.baocaoketquahoatdongkinhdoanh;
using DevExpress.XtraSplashScreen;
namespace GUI.Report.Nhap
{
    public partial class f_kqkd : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick1 = false;
        Boolean doubleclick2 = false;
        public f_kqkd()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
        }
        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Báo Cáo Kết Quả Hoạt Động Kinh Doanh").ToString();
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
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_kqkd" select a;
                nhan.DataSource = lst;
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_kqkd",
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
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_kqkd",
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
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dk_rp dk = new dk_rp();
                dk.id = gridView1.GetFocusedRowCellValue("id").ToString();
                dk.name = gridView1.GetFocusedRowCellValue("name").ToString();
                dk.key = gridView1.GetFocusedRowCellValue("key").ToString();
                dk.form = "f_kqkd";
                dk.loai = danhmuc.Text;
                dk.user = Biencucbo.idnv;
                db.dk_rps.InsertOnSubmit(dk);
                db.SubmitChanges();
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_kqkd" select a;
                nhan.DataSource = lst;
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_kqkd",
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
                    dk_rp dk = new dk_rp();
                    dk.id = gridView1.GetFocusedRowCellValue("id").ToString();
                    dk.name = gridView1.GetFocusedRowCellValue("name").ToString();
                    dk.key = gridView1.GetFocusedRowCellValue("key").ToString();
                    dk.form = "f_kqkd";
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_kqkd" select a;
                    nhan.DataSource = lst;
                    if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                    {
                        var list = (from a in db.donvis
                                    select new
                                    {
                                        id = a.id,
                                        name = a.tendonvi,
                                        key = a.id + danhmuc.Text + Biencucbo.idnv + "f_kqkd",
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
                    var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_kqkd" select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                    db.dk_rps.DeleteOnSubmit(lst);
                    db.SubmitChanges();
                    var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_kqkd" select a;
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
                                        key = a.id + danhmuc.Text + Biencucbo.idnv + "f_kqkd",
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
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                dk_rp dk = new dk_rp();
                var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_kqkd" select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                db.dk_rps.DeleteOnSubmit(lst);
                db.SubmitChanges();
                var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_kqkd" select a;
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
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_kqkd",
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
                    dk.form = "f_kqkd";
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_kqkd" select a;
                    nhan.DataSource = lst;
                }
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_kqkd",
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
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_kqkd" select a;
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
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_kqkd",
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
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(SplashScreen2), true, true, false);
            try
            {
                Biencucbo.kho = "";
                int check = 0;
                Candoi.d01 = 0;
                Candoi.d02 = 0;
                Candoi.d10 = 0;
                Candoi.d11 = 0;
                Candoi.d20 = 0;
                Candoi.d21 = 0;
                Candoi.d22 = 0;
                Candoi.d23 = 0;
                Candoi.d25 = 0;
                Candoi.d26 = 0;
                Candoi.d30 = 0;
                Candoi.d31 = 0;
                Candoi.d32 = 0;
                Candoi.d40 = 0;
                Candoi.d50 = 0;
                Candoi.d51 = 0;
                Candoi.d52 = 0;
                Candoi.d60 = 0;
                Candoi.d70 = 0;
                Candoi.d71 = 0;
                Candoi.c01 = 0;
                Candoi.c02 = 0;
                Candoi.c10 = 0;
                Candoi.c11 = 0;
                Candoi.c20 = 0;
                Candoi.c21 = 0;
                Candoi.c22 = 0;
                Candoi.c23 = 0;
                Candoi.c25 = 0;
                Candoi.c26 = 0;
                Candoi.c30 = 0;
                Candoi.c31 = 0;
                Candoi.c32 = 0;
                Candoi.c40 = 0;
                Candoi.c50 = 0;
                Candoi.c51 = 0;
                Candoi.c52 = 0;
                Candoi.c60 = 0;
                Candoi.c70 = 0;
                Candoi.c71 = 0;
                for (int i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Đơn vị - ຫົວໜ່ວຍ")
                    {
                        check++;
                        Biencucbo.kho = Biencucbo.kho + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
                    }
                }
                if (Biencucbo.ngonngu.ToString() == "Vietnam")
                {
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
                int tinhthang = new tinhthoigian(tungay.DateTime, denngay.DateTime).Months + 1;
                DateTime tungay2 = tungay.DateTime.AddMonths(-tinhthang);
                var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_kqkd" && a.loai == "Đơn vị - ຫົວໜ່ວຍ" select a);
                var lst3 = (from a in db.ct_tks
                            select a);
                if (check != 0)
                {
                    lst3 = (from a in db.ct_tks
                            join b in lst on a.iddv equals b.id
                            select a);
                }
                var lst1 = (from a in lst3
                            select new
                            {
                                tk_no = catchuoi(a.tk_no),
                                tk_co = catchuoi(a.tk_co),
                                a.ngaychungtu,
                                a.PS,
                                tk_noc2 = tkc2(a.tk_no),
                                tk_coc2 = tkc2(a.tk_co),
                            }).ToList();
                #region 01
                //d
                var lst2 = (from a in lst1
                            where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_no == "511"
                            select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d01 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d01 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_no == "511"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c01 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c01 = 0;
                }
                #endregion
                #region 02
                //d
                lst2 = (from a in lst1
                        where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_no == "511" && a.tk_co == "521"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d02 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d02 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_no == "511" && a.tk_co == "521"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c02 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c02 = 0;
                }
                #endregion
                Candoi.d10 = Candoi.d01 - Candoi.d02;
                Candoi.c10 = Candoi.c01 - Candoi.c02;
                #region 11
                //d
                lst2 = (from a in lst1
                        where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_co == "632"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d11 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d11 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_co == "632"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c11 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c11 = 0;
                }
                #endregion
                Candoi.d20 = Candoi.d10 - Candoi.d11;
                Candoi.c20 = Candoi.c10 - Candoi.c11;
                #region 21
                //d
                lst2 = (from a in lst1
                        where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_no == "515" && a.tk_co == "911"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d21 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d21 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_no == "515" && a.tk_co == "911"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c21 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c21 = 0;
                }
                #endregion
                #region 22
                //d
                lst2 = (from a in lst1
                        where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_no == "911" && a.tk_co == "635"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d22 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d22 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_no == "911" && a.tk_co == "635"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c22 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c22 = 0;
                }
                #endregion
                #region 25
                //d
                lst2 = (from a in lst1
                        where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_no == "911" && a.tk_co == "641"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d25 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d25 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_no == "911" && a.tk_co == "641"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c25 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c25 = 0;
                }
                #endregion
                #region 26
                //d
                lst2 = (from a in lst1
                        where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_no == "911" && a.tk_co == "642"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d26 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d26 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_no == "911" && a.tk_co == "642"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c26 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c26 = 0;
                }
                #endregion
                Candoi.d30 = Candoi.d20 + (Candoi.d21 - Candoi.d22) - Candoi.d25 - Candoi.d26;
                Candoi.c30 = Candoi.c20 + (Candoi.c21 - Candoi.c22) - Candoi.c25 - Candoi.c26;
                #region 31
                //d
                lst2 = (from a in lst1
                        where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_no == "711" && a.tk_co == "911"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d31 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d31 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_no == "711" && a.tk_co == "911"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c31 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c31 = 0;
                }
                #endregion
                #region 32
                //d
                lst2 = (from a in lst1
                        where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_no == "911" && a.tk_co == "811"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d32 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d32 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_no == "911" && a.tk_co == "811"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c32 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c32 = 0;
                }
                #endregion
                Candoi.d40 = Candoi.d31 - Candoi.d32;
                Candoi.c40 = Candoi.c31 - Candoi.c32;
                Candoi.d50 = Candoi.d30 + Candoi.d40;
                Candoi.c50 = Candoi.c30 + Candoi.c40;
                #region 51
                //d
                lst2 = (from a in lst1
                        where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_no == "911" && a.tk_coc2 == "8211"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d51 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d51 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_no == "911" && a.tk_coc2 == "8211"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c51 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c51 = 0;
                }
                #endregion
                #region 52
                //d
                lst2 = (from a in lst1
                        where a.ngaychungtu >= tungay2.Date && a.ngaychungtu < tungay.DateTime && a.tk_no == "911" && a.tk_coc2 == "8212"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.d52 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.d52 = 0;
                }
                //c
                lst2 = (from a in lst1
                        where a.ngaychungtu > tungay.DateTime && a.ngaychungtu <= denngay.DateTime && a.tk_no == "911" && a.tk_coc2 == "8212"
                        select a);
                if (lst2.Count() != 0)
                {
                    Candoi.c52 = double.Parse(lst2.Sum(t => t.PS).ToString());
                }
                else
                {
                    Candoi.c52 = 0;
                }
                #endregion
                Candoi.d60 = Candoi.d50 - Candoi.d51 - Candoi.d52;
                Candoi.c60 = Candoi.c50 - Candoi.c51 - Candoi.c52;
                r_bckq_hdkd xtra = new r_bckq_hdkd();
                //xtra.DataSource = lst6;
                ReportPrintTool rpt = new ReportPrintTool(xtra);
                rpt.PreviewForm.MdiParent = Application.OpenForms[0];
                rpt.ShowPreview();
                //Biencucbo.title = "BẢNG KÊ PHIẾU THU TIỀN MẶT";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SplashScreenManager.CloseForm(false);
        }
        string catchuoi(string a)
        {
            string b;
            b = a.Substring(0, 3);
            return b;
        }
        string tkc2(string a)
        {
            string b;
            if (a.Length >= 4)
            {
                b = a.Substring(0, 4);
                return b;
            }
            else
            {
                b = a.Substring(0, 3);
                return b;
            }
        }
    }
}
