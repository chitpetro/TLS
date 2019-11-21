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
using GUI.Report.Bangcandoiketoan;
using DevExpress.XtraSplashScreen;
namespace GUI.Report.Nhap
{
    public partial class f_baocaolctt2 : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick1 = false;
        Boolean doubleclick2 = false;
        public f_baocaolctt2()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
        }
        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Bảng Cân Đối Kế Toán").ToString();
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
            var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
            db.dk_rps.DeleteAllOnSubmit(lst);
            db.SubmitChanges();
            nhan.DataSource = lst;
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
                                    key = a.id + danhmuc.Text + Biencucbo.idnv,
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
                dk.loai = danhmuc.Text;
                dk.user = Biencucbo.idnv;
                db.dk_rps.InsertOnSubmit(dk);
                db.SubmitChanges();
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                nhan.DataSource = lst;
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv,
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
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                    nhan.DataSource = lst;
                    if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                    {
                        var list = (from a in db.donvis
                                    select new
                                    {
                                        id = a.id,
                                        name = a.tendonvi,
                                        key = a.id + danhmuc.Text + Biencucbo.idnv,
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
                    var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                    db.dk_rps.DeleteOnSubmit(lst);
                    db.SubmitChanges();
                    var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
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
                                        key = a.id + danhmuc.Text + Biencucbo.idnv,
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
                var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                db.dk_rps.DeleteOnSubmit(lst);
                db.SubmitChanges();
                var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
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
                                    key = a.id + danhmuc.Text + Biencucbo.idnv,
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
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                    nhan.DataSource = lst;
                }
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv,
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
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
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
                                    key = a.id + danhmuc.Text + Biencucbo.idnv,
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
                Biencucbo.loai = "";
                Biencucbo.doituong = "";
                Biencucbo.congviec = "";
                Biencucbo.taikhoan = "";
                Biencucbo.muccp = "";
                Biencucbo.kho = "";
                int check = 0;
                // Năm nay
                Candoi.tn01 = 0;
                Candoi.tn02 = 0;
                Candoi.tn03 = 0;
                Candoi.tn04 = 0;
                Candoi.tn05 = 0;
                Candoi.tn06 = 0;
                Candoi.tn07 = 0;
                Candoi.tn20 = 0;
                Candoi.tn21 = 0;
                Candoi.tn22 = 0;
                Candoi.tn23 = 0;
                Candoi.tn24 = 0;
                Candoi.tn25 = 0;
                Candoi.tn26 = 0;
                Candoi.tn27 = 0;
                Candoi.tn30 = 0;
                Candoi.tn31 = 0;
                Candoi.tn32 = 0;
                Candoi.tn33 = 0;
                Candoi.tn34 = 0;
                Candoi.tn35 = 0;
                Candoi.tn36 = 0;
                Candoi.tn40 = 0;
                Candoi.tn50 = 0;
                Candoi.tn60 = 0;
                Candoi.tn61 = 0;
                Candoi.tn70 = 0;
                // Năm trước
                Candoi.tt01 = 0;
                Candoi.tt02 = 0;
                Candoi.tt03 = 0;
                Candoi.tt04 = 0;
                Candoi.tt05 = 0;
                Candoi.tt06 = 0;
                Candoi.tt07 = 0;
                Candoi.tt20 = 0;
                Candoi.tt21 = 0;
                Candoi.tt22 = 0;
                Candoi.tt23 = 0;
                Candoi.tt24 = 0;
                Candoi.tt25 = 0;
                Candoi.tt26 = 0;
                Candoi.tt27 = 0;
                Candoi.tt30 = 0;
                Candoi.tt31 = 0;
                Candoi.tt32 = 0;
                Candoi.tt33 = 0;
                Candoi.tt34 = 0;
                Candoi.tt35 = 0;
                Candoi.tt36 = 0;
                Candoi.tt40 = 0;
                Candoi.tt50 = 0;
                Candoi.tt60 = 0;
                Candoi.tt61 = 0;
                Candoi.tt70 = 0;
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
                // năm trước
                //int tinhthang = new tinhthoigian(tungay.DateTime, denngay.DateTime).Months + 1;
                DateTime tungay2 = tungay.DateTime.AddMonths(-1);
                var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv select a);
                var lst1 = (from a in db.ct_tks
                            select a);
                if (check != 0)
                {
                    lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.loai == "Đơn vị - ຫົວໜ່ວຍ" select a);
                    lst1 = (from a in db.ct_tks
                            join b in lst on a.iddv equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ"
                            select a);
                }
                var tk = from b in db.dmtks select b;
                var lst2 = (from a in lst1
                            join b in tk on a.tk_no equals b.matk
                            where a.ngaychungtu < tungay2
                            select new
                            {
                                a.ngaychungtu,
                                id = a.machungtu,
                                a.ghichu,
                                a.diengiai,
                                taikhoan = a.tk_no,
                                a.idcv,
                                a.idmuccp,
                                a.iddv,
                                iddt = a.dt_no,
                                psno = a.PS,
                                psco = a.PS - a.PS,
                            }).Concat(from a in lst1
                                      join b in tk on a.tk_co equals b.matk
                                      where a.ngaychungtu < tungay2 /*&& a.ngaychungtu <= denngay.DateTime*/
                                      select new
                                      {
                                          a.ngaychungtu,
                                          id = a.machungtu,
                                          a.ghichu,
                                          a.diengiai,
                                          taikhoan = a.tk_co,
                                          a.idcv,
                                          a.idmuccp,
                                          a.iddv,
                                          iddt = a.dt_co,
                                          psno = a.PS - a.PS,
                                          psco = a.PS,
                                      }).OrderBy(t => t.ngaychungtu);
                var lst3a = (from a in lst2
                             join b in db.dmtks on a.taikhoan equals b.matk into k
                             from b in k.DefaultIfEmpty()
                                 //where b.kieusodu != "DEBCRD"
                             group a by new
                             {
                                 b.kieusodu,
                                 a.taikhoan,
                                 b.tentk,
                                 //a.iddt,
                             }
                                             into g
                             select new
                             {
                                 g.Key.kieusodu,
                                 taikhoan = g.Key.taikhoan,
                                 //iddt = g.Key.iddt,
                                 tentk = g.Key.tentk,
                                 psno = g.Sum(t => t.psno),
                                 psco = g.Sum(t => t.psco),
                             });
                var lst4a = from a in lst3a
                            select new
                            {
                                a.taikhoan,
                                a.tentk,
                                no = a.kieusodu == "CRD" ? (a.psco - a.psno < 0 ? a.psno - a.psco : 0) : (a.psno - a.psco > 0 ? a.psno - a.psco : 0),
                                co = a.kieusodu == "CRD" ? (a.psco - a.psno > 0 ? a.psco - a.psno : 0) : (a.psno - a.psco < 0 ? a.psco - a.psno : 0),
                            };
                var tknt = from a in lst4a
                           group a by new
                           {
                               a.taikhoan,
                               a.tentk,
                           } into g
                           select new
                           {
                               g.Key.taikhoan,
                               g.Key.tentk,
                               psno = g.Sum(t => t.no),
                               psco = g.Sum(t => t.co),
                           };
                lst2 = (from a in lst1
                        join b in tk on a.tk_no equals b.matk
                        where a.ngaychungtu <= tungay.DateTime /*&& a.ngaychungtu <= denngay.DateTime*/
                        select new
                        {
                            a.ngaychungtu,
                            id = a.machungtu,
                            a.ghichu,
                            a.diengiai,
                            taikhoan = a.tk_no,
                            a.idcv,
                            a.idmuccp,
                            a.iddv,
                            iddt = a.dt_no,
                            psno = a.PS,
                            psco = a.PS - a.PS,
                        }).Concat(from a in lst1
                                  join b in tk on a.tk_co equals b.matk
                                  where a.ngaychungtu <= tungay.DateTime /*&& a.ngaychungtu <= denngay.DateTime*/
                                  select new
                                  {
                                      a.ngaychungtu,
                                      id = a.machungtu,
                                      a.ghichu,
                                      a.diengiai,
                                      taikhoan = a.tk_co,
                                      a.idcv,
                                      a.idmuccp,
                                      a.iddv,
                                      iddt = a.dt_co,
                                      psno = a.PS - a.PS,
                                      psco = a.PS,
                                  }).OrderBy(t => t.ngaychungtu);
                lst3a = (from a in lst2
                         join b in tk on a.taikhoan equals b.matk into k
                         from b in k.DefaultIfEmpty()
                             //where b.kieusodu != "DEBCRD"
                         group a by new
                         {
                             b.kieusodu,
                             a.taikhoan,
                             b.tentk,
                             //a.iddt,
                         }
                                              into g
                         select new
                         {
                             g.Key.kieusodu,
                             taikhoan = g.Key.taikhoan,
                             //iddt = g.Key.iddt,
                             tentk = g.Key.tentk,
                             psno = g.Sum(t => t.psno),
                             psco = g.Sum(t => t.psco),
                         });
                lst4a = from a in lst3a
                        select new
                        {
                            a.taikhoan,
                            a.tentk,
                            no = a.kieusodu == "CRD" ? (a.psco - a.psno < 0 ? a.psno - a.psco : 0) : (a.psno - a.psco > 0 ? a.psno - a.psco : 0),
                            co = a.kieusodu == "CRD" ? (a.psco - a.psno > 0 ? a.psco - a.psno : 0) : (a.psno - a.psco < 0 ? a.psco - a.psno : 0),
                        };
                var tknn = from a in lst4a
                           group a by new
                           {
                               a.taikhoan,
                               a.tentk,
                           } into g
                           select new
                           {
                               g.Key.taikhoan,
                               g.Key.tentk,
                               psno = g.Sum(t => t.no),
                               psco = g.Sum(t => t.co),
                           };
                var tktong = (from a in db.dmtks
                              join b in tknt on a.matk equals b.taikhoan into g
                              join d in tknn on a.matk equals d.taikhoan into k
                              from namtruoc in g.DefaultIfEmpty()
                              from namnay in k.DefaultIfEmpty()
                              where namtruoc.psno != 0 || namtruoc.psco != 0 || namnay.psno != 0 || namnay.psco != 0
                              select new
                              {
                                  a.matk,
                                  a.tentk,
                                  tkgoc = catchuoi(a.matk),
                                  tkcap2 = tkc2(a.matk),
                                  tkcap3 = tkc3(a.matk),
                                  psno_nt = namtruoc.psno,
                                  psco_nt = namtruoc.psco,
                                  psno_nn = namnay.psno,
                                  psco_nn = namnay.psco,
                              }).ToList();
                var lstps = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.loai == "Đơn vị - ຫົວໜ່ວຍ" select a);
                
                var ps = (from a in lst1
                          where a.ngaychungtu >= tungay2 && a.ngaychungtu< tungay.DateTime
                          select new
                          {
                              tk_no = catchuoi(a.tk_no),
                              tk_co = catchuoi(a.tk_co),
                              a.ngaychungtu,
                              a.PS,
                              tk_noc2 = tkc2(a.tk_no),
                              tk_coc2 = tkc2(a.tk_co),
                          }).ToList();
                // Năm trước
                //01
                var gt = (from a in ps
                          where (a.tk_no == "111" && a.tk_co == "511") || (a.tk_no == "111" && a.tk_coc2 == "3331") || (a.tk_no == "111" && a.tk_co == "131") || (a.tk_no == "111" && a.tk_co == "515") || (a.tk_no == "111" && a.tk_co == "121")
            || (a.tk_no == "112" && a.tk_co == "511") || (a.tk_no == "112" && a.tk_coc2 == "3331") || (a.tk_no == "112" && a.tk_co == "131") || (a.tk_no == "112" && a.tk_co == "515") || (a.tk_no == "112" && a.tk_co == "121")
                          select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt01 = 0;
                }
                else
                {
                    Candoi.tt01 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //02
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "331") || (a.tk_co == "111" && a.tk_no == "151") || (a.tk_co == "111" && a.tk_no == "152") || (a.tk_co == "111" && a.tk_no == "153") || (a.tk_co == "111" && a.tk_no == "154") || (a.tk_co == "111" && a.tk_no == "155") || (a.tk_co == "111" && a.tk_no == "156") || (a.tk_co == "111" && a.tk_no == "157")
        || (a.tk_co == "112" && a.tk_no == "331") || (a.tk_co == "112" && a.tk_no == "151") || (a.tk_co == "112" && a.tk_no == "152") || (a.tk_co == "112" && a.tk_no == "153") || (a.tk_co == "112" && a.tk_no == "154") || (a.tk_co == "112" && a.tk_no == "155") || (a.tk_co == "112" && a.tk_no == "156") || (a.tk_co == "112" && a.tk_no == "157")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt02 = 0;
                }
                else
                {
                    Candoi.tt02 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //03
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "334") || (a.tk_co == "112" && a.tk_no == "334")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt03 = 0;
                }
                else
                {
                    Candoi.tt03 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //04
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "635") || (a.tk_co == "112" && a.tk_no == "635") || (a.tk_co == "113" && a.tk_no == "635")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt04 = 0;
                }
                else
                {
                    Candoi.tt04 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //05
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_noc2 == "3334") || (a.tk_co == "112" && a.tk_noc2 == "3334") || (a.tk_co == "113" && a.tk_noc2 == "3334")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt04 = 0;
                }
                else
                {
                    Candoi.tt04 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //06
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "711") || (a.tk_no == "111" && a.tk_co == "133") || (a.tk_no == "111" && a.tk_co == "141") || (a.tk_no == "111" && a.tk_co == "244")
        || (a.tk_no == "112" && a.tk_co == "711") || (a.tk_no == "112" && a.tk_co == "133") || (a.tk_no == "112" && a.tk_co == "141") || (a.tk_no == "112" && a.tk_co == "244")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt06 = 0;
                }
                else
                {
                    Candoi.tt06 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //07
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "811") || (a.tk_co == "111" && a.tk_no == "161") || (a.tk_co == "111" && a.tk_no == "244") || (a.tk_co == "111" && a.tk_no == "333") || (a.tk_co == "111" && a.tk_no == "338") || (a.tk_co == "111" && a.tk_no == "344") || (a.tk_co == "111" && a.tk_no == "352") || (a.tk_co == "111" && a.tk_no == "353") || (a.tk_co == "111" && a.tk_no == "356")
                      || (a.tk_co == "112" && a.tk_no == "811") || (a.tk_co == "112" && a.tk_no == "161") || (a.tk_co == "112" && a.tk_no == "244") || (a.tk_co == "112" && a.tk_no == "333") || (a.tk_co == "112" && a.tk_no == "338") || (a.tk_co == "112" && a.tk_no == "344") || (a.tk_co == "112" && a.tk_no == "352") || (a.tk_co == "112" && a.tk_no == "353") || (a.tk_co == "112" && a.tk_no == "356")
                      || (a.tk_co == "113" && a.tk_no == "811") || (a.tk_co == "113" && a.tk_no == "161") || (a.tk_co == "113" && a.tk_no == "244") || (a.tk_co == "113" && a.tk_no == "333") || (a.tk_co == "113" && a.tk_no == "338") || (a.tk_co == "113" && a.tk_no == "344") || (a.tk_co == "113" && a.tk_no == "352") || (a.tk_co == "113" && a.tk_no == "353") || (a.tk_co == "113" && a.tk_no == "356")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt07 = 0;
                }
                else
                {
                    Candoi.tt07 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //20
                Candoi.tt20 = Candoi.tt01 + Candoi.tt02 + Candoi.tt03 + Candoi.tt04 + Candoi.tt05 + Candoi.tt06 + Candoi.tt07;
                //21
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "211") || (a.tk_co == "111" && a.tk_no == "213") || (a.tk_co == "111" && a.tk_no == "217") || (a.tk_co == "111" && a.tk_no == "241")
                      || (a.tk_co == "112" && a.tk_no == "211") || (a.tk_co == "112" && a.tk_no == "213") || (a.tk_co == "112" && a.tk_no == "217") || (a.tk_co == "112" && a.tk_no == "241")
                      || (a.tk_co == "113" && a.tk_no == "211") || (a.tk_co == "113" && a.tk_no == "213") || (a.tk_co == "113" && a.tk_no == "217") || (a.tk_co == "113" && a.tk_no == "241")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt21 = 0;
                }
                else
                {
                    Candoi.tt21 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //22
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "711") || (a.tk_no == "111" && a.tk_coc2 == "5117") || (a.tk_no == "111" && a.tk_co == "131")
                      || (a.tk_no == "112" && a.tk_co == "711") || (a.tk_no == "112" && a.tk_coc2 == "5117") || (a.tk_no == "112" && a.tk_co == "131")
                      || (a.tk_no == "113" && a.tk_co == "711") || (a.tk_no == "113" && a.tk_coc2 == "5117") || (a.tk_no == "113" && a.tk_co == "131")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt22 = 0;
                }
                else
                {
                    Candoi.tt22 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "632") || (a.tk_co == "111" && a.tk_no == "811")
                      || (a.tk_co == "112" && a.tk_no == "632") || (a.tk_co == "112" && a.tk_no == "811")
                      || (a.tk_co == "113" && a.tk_no == "632") || (a.tk_co == "113" && a.tk_no == "811")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt22 = Candoi.tt22 + 0;
                }
                else
                {
                    Candoi.tt22 = Candoi.tt22 - double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //23
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "128") || (a.tk_co == "111" && a.tk_no == "171")
                      || (a.tk_co == "112" && a.tk_no == "128") || (a.tk_co == "112" && a.tk_no == "171")
                      || (a.tk_co == "113" && a.tk_no == "128") || (a.tk_co == "113" && a.tk_no == "171")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt23 = 0;
                }
                else
                {
                    Candoi.tt23 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //24
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "128") || (a.tk_no == "111" && a.tk_co == "171")
                      || (a.tk_no == "112" && a.tk_co == "128") || (a.tk_no == "112" && a.tk_co == "171")
                      || (a.tk_no == "113" && a.tk_co == "128") || (a.tk_no == "113" && a.tk_co == "171")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt24 = 0;
                }
                else
                {
                    Candoi.tt24 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //25
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "221") || (a.tk_co == "111" && a.tk_no == "222") || (a.tk_co == "111" && a.tk_noc2 == "2281")
                      || (a.tk_co == "112" && a.tk_no == "221") || (a.tk_co == "112" && a.tk_no == "222") || (a.tk_co == "112" && a.tk_noc2 == "2281")
                      || (a.tk_co == "113" && a.tk_no == "221") || (a.tk_co == "113" && a.tk_no == "222") || (a.tk_co == "113" && a.tk_noc2 == "2281")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt25 = 0;
                }
                else
                {
                    Candoi.tt25 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //26 
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "221") || (a.tk_no == "111" && a.tk_co == "222") || (a.tk_no == "111" && a.tk_coc2 == "2281")
                      || (a.tk_no == "112" && a.tk_co == "221") || (a.tk_no == "112" && a.tk_co == "222") || (a.tk_no == "112" && a.tk_coc2 == "2281")
                      || (a.tk_no == "113" && a.tk_co == "221") || (a.tk_no == "113" && a.tk_co == "222") || (a.tk_no == "113" && a.tk_coc2 == "2281")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt26 = 0;
                }
                else
                {
                    Candoi.tt26 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //27
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "421") || (a.tk_no == "112" && a.tk_co == "421") || (a.tk_no == "113" && a.tk_co == "421")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt27 = 0;
                }
                else
                {
                    Candoi.tt27 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                Candoi.tt30 = Candoi.tt21 + Candoi.tt22 + Candoi.tt23 + Candoi.tt24 + Candoi.tt25 + Candoi.tt26 + Candoi.tt27;
                //31
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "411") || (a.tk_no == "112" && a.tk_co == "411") || (a.tk_no == "113" && a.tk_co == "411")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt31 = 0;
                }
                else
                {
                    Candoi.tt31 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //32
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "411") || (a.tk_co == "111" && a.tk_no == "419")
                      || (a.tk_co == "112" && a.tk_no == "411") || (a.tk_co == "112" && a.tk_no == "419")
                      || (a.tk_co == "113" && a.tk_no == "411") || (a.tk_co == "113" && a.tk_no == "419")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt32 = 0;
                }
                else
                {
                    Candoi.tt32 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //33
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "171") || (a.tk_no == "111" && a.tk_coc2 == "3411") || (a.tk_no == "111" && a.tk_coc2 == "3431") || (a.tk_no == "111" && a.tk_coc2 == "3432")
                      || (a.tk_no == "112" && a.tk_co == "171") || (a.tk_no == "112" && a.tk_coc2 == "3411") || (a.tk_no == "112" && a.tk_coc2 == "3431") || (a.tk_no == "112" && a.tk_coc2 == "3432")
                      || (a.tk_no == "113" && a.tk_co == "171") || (a.tk_no == "113" && a.tk_coc2 == "3411") || (a.tk_no == "113" && a.tk_coc2 == "3431") || (a.tk_no == "113" && a.tk_coc2 == "3432")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt33 = 0;
                }
                else
                {
                    Candoi.tt33 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //34
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "171") || (a.tk_co == "111" && a.tk_noc2 == "3411") || (a.tk_co == "111" && a.tk_noc2 == "3431") || (a.tk_co == "111" && a.tk_noc2 == "3432")
                      || (a.tk_co == "112" && a.tk_no == "171") || (a.tk_co == "112" && a.tk_noc2 == "3411") || (a.tk_co == "112" && a.tk_noc2 == "3431") || (a.tk_co == "112" && a.tk_noc2 == "3432")
                      || (a.tk_co == "113" && a.tk_no == "171") || (a.tk_co == "113" && a.tk_noc2 == "3411") || (a.tk_co == "113" && a.tk_noc2 == "3431") || (a.tk_co == "113" && a.tk_noc2 == "3432")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt34 = 0;
                }
                else
                {
                    Candoi.tt34 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //35
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_noc2 == "3412")
                      || (a.tk_co == "112" && a.tk_noc2 == "3412")
                      || (a.tk_co == "113" && a.tk_noc2 == "3412")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt35 = 0;
                }
                else
                {
                    Candoi.tt35 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //36
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "421")
                      || (a.tk_co == "112" && a.tk_no == "421")
                      || (a.tk_co == "113" && a.tk_no == "421")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt36 = 0;
                }
                else
                {
                    Candoi.tt36 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                Candoi.tt40 = Candoi.tt31 + Candoi.tt32 + Candoi.tt33 + Candoi.tt34 + Candoi.tt35 + Candoi.tt36;
                Candoi.tt50 = Candoi.tt20 + Candoi.tt30 + Candoi.tt40;
                //60
                var gt2 = (from a in tktong
                           where a.tkgoc == "111" || a.tkgoc == "112" || a.tkgoc == "113" || a.tkcap3 == "12811" || a.tkcap3 == "12881"
                           select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt60 = 0;
                }
                else
                {
                    Candoi.tt60 = double.Parse(gt2.Sum(t => t.psno_nt).ToString());
                }
                //61
                gt2 = (from a in tktong
                       where a.tkgoc == "111" || a.tkgoc == "112" || a.tkgoc == "113" /*|| a.tkcap3 == "12811" || a.tkcap3 == "12881"*/
                       select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt61 = 0;
                }
                else
                {
                    Candoi.tt61 = double.Parse(gt2.Sum(t => t.psno_nn).ToString());
                }
                gt2 = (from a in tktong
                       where a.tkcap2 == "4131"
                       select a);
                if (gt.Count() == 0)
                {
                    Candoi.tt61 = Candoi.tt61 + 0;
                }
                else
                {
                    Candoi.tt61 = Candoi.tt61 - double.Parse(gt2.Sum(t => t.psco_nn).ToString());
                }
                Candoi.tt70 = Candoi.tt50 + Candoi.tt60 + Candoi.tt61;
                // NĂM NAY
                lst2 = (from a in lst1
                        join b in tk on a.tk_no equals b.matk
                        where a.ngaychungtu < tungay.DateTime
                        select new
                        {
                            a.ngaychungtu,
                            id = a.machungtu,
                            a.ghichu,
                            a.diengiai,
                            taikhoan = a.tk_no,
                            a.idcv,
                            a.idmuccp,
                            a.iddv,
                            iddt = a.dt_no,
                            psno = a.PS,
                            psco = a.PS - a.PS,
                        }).Concat(from a in lst1
                                  join b in tk on a.tk_co equals b.matk
                                  where a.ngaychungtu < tungay.DateTime /*&& a.ngaychungtu <= denngay.DateTime*/
                                  select new
                                  {
                                      a.ngaychungtu,
                                      id = a.machungtu,
                                      a.ghichu,
                                      a.diengiai,
                                      taikhoan = a.tk_co,
                                      a.idcv,
                                      a.idmuccp,
                                      a.iddv,
                                      iddt = a.dt_co,
                                      psno = a.PS - a.PS,
                                      psco = a.PS,
                                  }).OrderBy(t => t.ngaychungtu);
                lst3a = (from a in lst2
                         join b in db.dmtks on a.taikhoan equals b.matk into k
                         from b in k.DefaultIfEmpty()
                             //where b.kieusodu != "DEBCRD"
                         group a by new
                         {
                             b.kieusodu,
                             a.taikhoan,
                             b.tentk,
                         }
                                              into g
                         select new
                         {
                             g.Key.kieusodu,
                             taikhoan = g.Key.taikhoan,
                             tentk = g.Key.tentk,
                             psno = g.Sum(t => t.psno),
                             psco = g.Sum(t => t.psco),
                         });
                lst4a = from a in lst3a
                        select new
                        {
                            a.taikhoan,
                            a.tentk,
                            no = a.kieusodu == "CRD" ? (a.psco - a.psno < 0 ? a.psno - a.psco : 0) : (a.psno - a.psco > 0 ? a.psno - a.psco : 0),
                            co = a.kieusodu == "CRD" ? (a.psco - a.psno > 0 ? a.psco - a.psno : 0) : (a.psno - a.psco < 0 ? a.psco - a.psno : 0),
                        };
                tknt = from a in lst4a
                       group a by new
                       {
                           a.taikhoan,
                           a.tentk,
                       } into g
                       select new
                       {
                           g.Key.taikhoan,
                           g.Key.tentk,
                           psno = g.Sum(t => t.no),
                           psco = g.Sum(t => t.co),
                       };
                lst2 = (from a in lst1
                        join b in tk on a.tk_no equals b.matk
                        where a.ngaychungtu <= denngay.DateTime /*&& a.ngaychungtu <= denngay.DateTime*/
                        select new
                        {
                            a.ngaychungtu,
                            id = a.machungtu,
                            a.ghichu,
                            a.diengiai,
                            taikhoan = a.tk_no,
                            a.idcv,
                            a.idmuccp,
                            a.iddv,
                            iddt = a.dt_no,
                            psno = a.PS,
                            psco = a.PS - a.PS,
                        }).Concat(from a in lst1
                                  join b in tk on a.tk_co equals b.matk
                                  where a.ngaychungtu <= denngay.DateTime /*&& a.ngaychungtu <= denngay.DateTime*/
                                  select new
                                  {
                                      a.ngaychungtu,
                                      id = a.machungtu,
                                      a.ghichu,
                                      a.diengiai,
                                      taikhoan = a.tk_co,
                                      a.idcv,
                                      a.idmuccp,
                                      a.iddv,
                                      iddt = a.dt_co,
                                      psno = a.PS - a.PS,
                                      psco = a.PS,
                                  }).OrderBy(t => t.ngaychungtu);
                lst3a = (from a in lst2
                         join b in tk on a.taikhoan equals b.matk into k
                         from b in k.DefaultIfEmpty()
                             //where b.kieusodu != "DEBCRD"
                         group a by new
                         {
                             b.kieusodu,
                             a.taikhoan,
                             b.tentk,
                             //a.iddt,
                         }
                                              into g
                         select new
                         {
                             g.Key.kieusodu,
                             taikhoan = g.Key.taikhoan,
                             //iddt = g.Key.iddt,
                             tentk = g.Key.tentk,
                             psno = g.Sum(t => t.psno),
                             psco = g.Sum(t => t.psco),
                         });
                lst4a = from a in lst3a
                        select new
                        {
                            a.taikhoan,
                            a.tentk,
                            no = a.kieusodu == "CRD" ? (a.psco - a.psno < 0 ? a.psno - a.psco : 0) : (a.psno - a.psco > 0 ? a.psno - a.psco : 0),
                            co = a.kieusodu == "CRD" ? (a.psco - a.psno > 0 ? a.psco - a.psno : 0) : (a.psno - a.psco < 0 ? a.psco - a.psno : 0),
                        };
                tknn = from a in lst4a
                       group a by new
                       {
                           a.taikhoan,
                           a.tentk,
                       } into g
                       select new
                       {
                           g.Key.taikhoan,
                           g.Key.tentk,
                           psno = g.Sum(t => t.no),
                           psco = g.Sum(t => t.co),
                       };
                tktong = (from a in db.dmtks
                          join b in tknt on a.matk equals b.taikhoan into g
                          join d in tknn on a.matk equals d.taikhoan into k
                          from namtruoc in g.DefaultIfEmpty()
                          from namnay in k.DefaultIfEmpty()
                          where namtruoc.psno != 0 || namtruoc.psco != 0 || namnay.psno != 0 || namnay.psco != 0
                          select new
                          {
                              a.matk,
                              a.tentk,
                              tkgoc = catchuoi(a.matk),
                              tkcap2 = tkc2(a.matk),
                              tkcap3 = tkc3(a.matk),
                              psno_nt = namtruoc.psno,
                              psco_nt = namtruoc.psco,
                              psno_nn = namnay.psno,
                              psco_nn = namnay.psco,
                          }).ToList();
                
                ps = (from a in lst1
                      where a.ngaychungtu >= tungay.DateTime && a.ngaychungtu <= denngay.DateTime
                      select new
                      {
                          tk_no = catchuoi(a.tk_no),
                          tk_co = catchuoi(a.tk_co),
                          a.ngaychungtu,
                          a.PS,
                          tk_noc2 = tkc2(a.tk_no),
                          tk_coc2 = tkc2(a.tk_co),
                      }).ToList();
        
                //01
                gt = (from a in ps
                          where (a.tk_no == "111" && a.tk_co == "511") || (a.tk_no == "111" && a.tk_coc2 == "3331") || (a.tk_no == "111" && a.tk_co == "131") || (a.tk_no == "111" && a.tk_co == "515") || (a.tk_no == "111" && a.tk_co == "121")
            || (a.tk_no == "112" && a.tk_co == "511") || (a.tk_no == "112" && a.tk_coc2 == "3331") || (a.tk_no == "112" && a.tk_co == "131") || (a.tk_no == "112" && a.tk_co == "515") || (a.tk_no == "112" && a.tk_co == "121")
                          select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn01 = 0;
                }
                else
                {
                    Candoi.tn01 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //02
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "331") || (a.tk_co == "111" && a.tk_no == "151") || (a.tk_co == "111" && a.tk_no == "152") || (a.tk_co == "111" && a.tk_no == "153") || (a.tk_co == "111" && a.tk_no == "154") || (a.tk_co == "111" && a.tk_no == "155") || (a.tk_co == "111" && a.tk_no == "156") || (a.tk_co == "111" && a.tk_no == "157")
        || (a.tk_co == "112" && a.tk_no == "331") || (a.tk_co == "112" && a.tk_no == "151") || (a.tk_co == "112" && a.tk_no == "152") || (a.tk_co == "112" && a.tk_no == "153") || (a.tk_co == "112" && a.tk_no == "154") || (a.tk_co == "112" && a.tk_no == "155") || (a.tk_co == "112" && a.tk_no == "156") || (a.tk_co == "112" && a.tk_no == "157")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn02 = 0;
                }
                else
                {
                    Candoi.tn02 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //03
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "334") || (a.tk_co == "112" && a.tk_no == "334")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn03 = 0;
                }
                else
                {
                    Candoi.tn03 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //04
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "635") || (a.tk_co == "112" && a.tk_no == "635") || (a.tk_co == "113" && a.tk_no == "635")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn04 = 0;
                }
                else
                {
                    Candoi.tn04 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //05
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_noc2 == "3334") || (a.tk_co == "112" && a.tk_noc2 == "3334") || (a.tk_co == "113" && a.tk_noc2 == "3334")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn04 = 0;
                }
                else
                {
                    Candoi.tn04 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //06
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "711") || (a.tk_no == "111" && a.tk_co == "133") || (a.tk_no == "111" && a.tk_co == "141") || (a.tk_no == "111" && a.tk_co == "244")
        || (a.tk_no == "112" && a.tk_co == "711") || (a.tk_no == "112" && a.tk_co == "133") || (a.tk_no == "112" && a.tk_co == "141") || (a.tk_no == "112" && a.tk_co == "244")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn06 = 0;
                }
                else
                {
                    Candoi.tn06 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //07
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "811") || (a.tk_co == "111" && a.tk_no == "161") || (a.tk_co == "111" && a.tk_no == "244") || (a.tk_co == "111" && a.tk_no == "333") || (a.tk_co == "111" && a.tk_no == "338") || (a.tk_co == "111" && a.tk_no == "344") || (a.tk_co == "111" && a.tk_no == "352") || (a.tk_co == "111" && a.tk_no == "353") || (a.tk_co == "111" && a.tk_no == "356")
                      || (a.tk_co == "112" && a.tk_no == "811") || (a.tk_co == "112" && a.tk_no == "161") || (a.tk_co == "112" && a.tk_no == "244") || (a.tk_co == "112" && a.tk_no == "333") || (a.tk_co == "112" && a.tk_no == "338") || (a.tk_co == "112" && a.tk_no == "344") || (a.tk_co == "112" && a.tk_no == "352") || (a.tk_co == "112" && a.tk_no == "353") || (a.tk_co == "112" && a.tk_no == "356")
                      || (a.tk_co == "113" && a.tk_no == "811") || (a.tk_co == "113" && a.tk_no == "161") || (a.tk_co == "113" && a.tk_no == "244") || (a.tk_co == "113" && a.tk_no == "333") || (a.tk_co == "113" && a.tk_no == "338") || (a.tk_co == "113" && a.tk_no == "344") || (a.tk_co == "113" && a.tk_no == "352") || (a.tk_co == "113" && a.tk_no == "353") || (a.tk_co == "113" && a.tk_no == "356")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn07 = 0;
                }
                else
                {
                    Candoi.tn07 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //20
                Candoi.tn20 = Candoi.tn01 + Candoi.tn02 + Candoi.tn03 + Candoi.tn04 + Candoi.tn05 + Candoi.tn06 + Candoi.tn07;
                //21
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "211") || (a.tk_co == "111" && a.tk_no == "213") || (a.tk_co == "111" && a.tk_no == "217") || (a.tk_co == "111" && a.tk_no == "241")
                      || (a.tk_co == "112" && a.tk_no == "211") || (a.tk_co == "112" && a.tk_no == "213") || (a.tk_co == "112" && a.tk_no == "217") || (a.tk_co == "112" && a.tk_no == "241")
                      || (a.tk_co == "113" && a.tk_no == "211") || (a.tk_co == "113" && a.tk_no == "213") || (a.tk_co == "113" && a.tk_no == "217") || (a.tk_co == "113" && a.tk_no == "241")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn21 = 0;
                }
                else
                {
                    Candoi.tn21 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //22
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "711") || (a.tk_no == "111" && a.tk_coc2 == "5117") || (a.tk_no == "111" && a.tk_co == "131")
                      || (a.tk_no == "112" && a.tk_co == "711") || (a.tk_no == "112" && a.tk_coc2 == "5117") || (a.tk_no == "112" && a.tk_co == "131")
                      || (a.tk_no == "113" && a.tk_co == "711") || (a.tk_no == "113" && a.tk_coc2 == "5117") || (a.tk_no == "113" && a.tk_co == "131")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn22 = 0;
                }
                else
                {
                    Candoi.tn22 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "632") || (a.tk_co == "111" && a.tk_no == "811")
                      || (a.tk_co == "112" && a.tk_no == "632") || (a.tk_co == "112" && a.tk_no == "811")
                      || (a.tk_co == "113" && a.tk_no == "632") || (a.tk_co == "113" && a.tk_no == "811")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn22 = Candoi.tn22 + 0;
                }
                else
                {
                    Candoi.tn22 = Candoi.tn22 - double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //23
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "128") || (a.tk_co == "111" && a.tk_no == "171")
                      || (a.tk_co == "112" && a.tk_no == "128") || (a.tk_co == "112" && a.tk_no == "171")
                      || (a.tk_co == "113" && a.tk_no == "128") || (a.tk_co == "113" && a.tk_no == "171")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn23 = 0;
                }
                else
                {
                    Candoi.tn23 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //24
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "128") || (a.tk_no == "111" && a.tk_co == "171")
                      || (a.tk_no == "112" && a.tk_co == "128") || (a.tk_no == "112" && a.tk_co == "171")
                      || (a.tk_no == "113" && a.tk_co == "128") || (a.tk_no == "113" && a.tk_co == "171")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn24 = 0;
                }
                else
                {
                    Candoi.tn24 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //25
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "221") || (a.tk_co == "111" && a.tk_no == "222") || (a.tk_co == "111" && a.tk_noc2 == "2281")
                      || (a.tk_co == "112" && a.tk_no == "221") || (a.tk_co == "112" && a.tk_no == "222") || (a.tk_co == "112" && a.tk_noc2 == "2281")
                      || (a.tk_co == "113" && a.tk_no == "221") || (a.tk_co == "113" && a.tk_no == "222") || (a.tk_co == "113" && a.tk_noc2 == "2281")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn25 = 0;
                }
                else
                {
                    Candoi.tn25 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //26 
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "221") || (a.tk_no == "111" && a.tk_co == "222") || (a.tk_no == "111" && a.tk_coc2 == "2281")
                      || (a.tk_no == "112" && a.tk_co == "221") || (a.tk_no == "112" && a.tk_co == "222") || (a.tk_no == "112" && a.tk_coc2 == "2281")
                      || (a.tk_no == "113" && a.tk_co == "221") || (a.tk_no == "113" && a.tk_co == "222") || (a.tk_no == "113" && a.tk_coc2 == "2281")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn26 = 0;
                }
                else
                {
                    Candoi.tn26 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //27
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "515") || (a.tk_no == "112" && a.tk_co == "515") || (a.tk_no == "113" && a.tk_co == "515")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn27 = 0;
                }
                else
                {
                    Candoi.tn27 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                Candoi.tn30 = Candoi.tn21 + Candoi.tn22 + Candoi.tn23 + Candoi.tn24 + Candoi.tn25 + Candoi.tn26 + Candoi.tn27;
                //31
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "411") || (a.tk_no == "112" && a.tk_co == "411") || (a.tk_no == "113" && a.tk_co == "411")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn31 = 0;
                }
                else
                {
                    Candoi.tn31 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //32
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "411") || (a.tk_co == "111" && a.tk_no == "419")
                      || (a.tk_co == "112" && a.tk_no == "411") || (a.tk_co == "112" && a.tk_no == "419")
                      || (a.tk_co == "113" && a.tk_no == "411") || (a.tk_co == "113" && a.tk_no == "419")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn32 = 0;
                }
                else
                {
                    Candoi.tn32 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //33
                gt = (from a in ps
                      where (a.tk_no == "111" && a.tk_co == "171") || (a.tk_no == "111" && a.tk_coc2 == "3411") || (a.tk_no == "111" && a.tk_coc2 == "3431") || (a.tk_no == "111" && a.tk_coc2 == "3432")
                      || (a.tk_no == "112" && a.tk_co == "171") || (a.tk_no == "112" && a.tk_coc2 == "3411") || (a.tk_no == "112" && a.tk_coc2 == "3431") || (a.tk_no == "112" && a.tk_coc2 == "3432")
                      || (a.tk_no == "113" && a.tk_co == "171") || (a.tk_no == "113" && a.tk_coc2 == "3411") || (a.tk_no == "113" && a.tk_coc2 == "3431") || (a.tk_no == "113" && a.tk_coc2 == "3432")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn33 = 0;
                }
                else
                {
                    Candoi.tn33 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //34
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "171") || (a.tk_co == "111" && a.tk_noc2 == "3411") || (a.tk_co == "111" && a.tk_noc2 == "3431") || (a.tk_co == "111" && a.tk_noc2 == "3432")
                      || (a.tk_co == "112" && a.tk_no == "171") || (a.tk_co == "112" && a.tk_noc2 == "3411") || (a.tk_co == "112" && a.tk_noc2 == "3431") || (a.tk_co == "112" && a.tk_noc2 == "3432")
                      || (a.tk_co == "113" && a.tk_no == "171") || (a.tk_co == "113" && a.tk_noc2 == "3411") || (a.tk_co == "113" && a.tk_noc2 == "3431") || (a.tk_co == "113" && a.tk_noc2 == "3432")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn34 = 0;
                }
                else
                {
                    Candoi.tn34 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //35
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_noc2 == "3412")
                      || (a.tk_co == "112" && a.tk_noc2 == "3412")
                      || (a.tk_co == "113" && a.tk_noc2 == "3412")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn35 = 0;
                }
                else
                {
                    Candoi.tn35 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                //36
                gt = (from a in ps
                      where (a.tk_co == "111" && a.tk_no == "421")
                      || (a.tk_co == "112" && a.tk_no == "421")
                      || (a.tk_co == "113" && a.tk_no == "421")
                      select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn36 = 0;
                }
                else
                {
                    Candoi.tn36 = double.Parse(gt.Sum(t => t.PS).ToString());
                }
                Candoi.tn40 = Candoi.tn31 + Candoi.tn32 + Candoi.tn33 + Candoi.tn34 + Candoi.tn35 + Candoi.tn36;
                Candoi.tn50 = Candoi.tn20 + Candoi.tn30 + Candoi.tn40;
                //60
               gt2 = (from a in tktong
                           where a.tkgoc == "111" || a.tkgoc == "112" || a.tkgoc == "113" || a.tkcap3 == "12811" || a.tkcap3 == "12881"
                           select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn60 = 0;
                }
                else
                {
                    Candoi.tn60 = double.Parse(gt2.Sum(t => t.psno_nt).ToString());
                }
                //61
                gt2 = (from a in tktong
                       where a.tkgoc == "111" || a.tkgoc == "112" || a.tkgoc == "113" /*|| a.tkcap3 == "12811" || a.tkcap3 == "12881"*/
                       select a);
                 if (gt.Count() == 0)
                {
                    Candoi.tn61 = 0;
                }
                else
                {
                    Candoi.tn61 = double.Parse(gt2.Sum(t => t.psno_nn).ToString());
                }
                gt2 = (from a in tktong
                       where a.tkcap2 == "4131" 
                       select a);
                if (gt.Count() == 0)
                {
                    Candoi.tn61 = Candoi.tn61 + 0;
                }
                else
                {
                    Candoi.tn61 = Candoi.tn61 - double.Parse(gt2.Sum(t => t.psco_nn).ToString());
                }
                Candoi.tn70 = Candoi.tn50 + Candoi.tn60 + Candoi.tn61;
                Report.baocaoketquahoatdongkinhdoanh.r_bclctt xtra = new Report.baocaoketquahoatdongkinhdoanh.r_bclctt();
                //xtra.DataSource = tong;
                xtra.ShowPreviewDialog();
                //}
                //Biencucbo.title = "BẢNG KÊ PHIẾU THU TIỀN MẶT";
                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show(ex.Message);
                //}
            }
            catch { }
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
        string tkc3(string a)
        {
            string b;
            if (a.Length >= 5)
            {
                b = a.Substring(0, 5);
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
