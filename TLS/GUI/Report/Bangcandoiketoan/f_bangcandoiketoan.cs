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
    public partial class f_bangcandoiketoan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick1 = false;
        Boolean doubleclick2 = false;
        public f_bangcandoiketoan()
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
            try
            {
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_bangcandoiketoan" select a;
                nhan.DataSource = lst;
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_bangcandoiketoan",
                                    MaTim = LayMaTim(a.id)
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
            rTime.SetTime2(thoigian);
            //var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_bangcandoiketoan" select a;
            //db.dk_rps.DeleteAllOnSubmit(lst);
            //db.SubmitChanges();
            //nhan.DataSource = lst;
        }
        private string LayMaTim(string da)
        {
            var d = (from a in db.donvis select a).Single(t => t.id == da);
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
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_bangcandoiketoan",
                                    MaTim = LayMaTim(a.id)
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
                dk.form = "f_bangcandoiketoan";
                db.dk_rps.InsertOnSubmit(dk);
                db.SubmitChanges();
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_bangcandoiketoan" select a;
                nhan.DataSource = lst;
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_bangcandoiketoan",
                                    MaTim = LayMaTim(a.id)
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
                    dk.form = "f_bangcandoiketoan";
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_bangcandoiketoan" select a;
                    nhan.DataSource = lst;
                    if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                    {
                        var list = (from a in db.donvis
                                    select new
                                    {
                                        id = a.id,
                                        name = a.tendonvi,
                                        key = a.id + danhmuc.Text + Biencucbo.idnv + "f_bangcandoiketoan",
                                        MaTim = LayMaTim(a.id)
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
                    var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_bangcandoiketoan" select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                    db.dk_rps.DeleteOnSubmit(lst);
                    db.SubmitChanges();
                    var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_bangcandoiketoan" select a;
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
                                        key = a.id + danhmuc.Text + Biencucbo.idnv + "f_bangcandoiketoan",
                                        MaTim = LayMaTim(a.id)
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
                var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_bangcandoiketoan" select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                db.dk_rps.DeleteOnSubmit(lst);
                db.SubmitChanges();
                var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_bangcandoiketoan" select a;
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
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_bangcandoiketoan",
                                    MaTim = LayMaTim(a.id)
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
                    dk.form = "f_bangcandoiketoan";
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_bangcandoiketoan" select a;
                    nhan.DataSource = lst;
                }
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_bangcandoiketoan",
                                    MaTim = LayMaTim(a.id)
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
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_bangcandoiketoan" select a;
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
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_bangcandoiketoan",
                                    MaTim = LayMaTim(a.id)
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
                Candoi.c100 = 0;
                //110
                Candoi.c110 = 0;
                Candoi.c111 = 0;
                Candoi.c112 = 0;
                //120
                Candoi.c120 = 0;
                Candoi.c121 = 0;
                Candoi.c122 = 0;
                Candoi.c123 = 0;
                //130
                Candoi.c130 = 0;
                Candoi.c131 = 0;
                Candoi.c132 = 0;
                Candoi.c133 = 0;
                Candoi.c134 = 0;
                Candoi.c135 = 0;
                Candoi.c136 = 0;
                Candoi.c137 = 0;
                Candoi.c139 = 0;
                // 140 
                Candoi.c140 = 0;
                Candoi.c141 = 0;
                Candoi.c149 = 0;
                // 150
                Candoi.c150 = 0;
                Candoi.c151 = 0;
                Candoi.c152 = 0;
                Candoi.c153 = 0;
                Candoi.c154 = 0;
                Candoi.c155 = 0;
                //200
                Candoi.c200 = 0;
                //210
                Candoi.c210 = 0;
                Candoi.c211 = 0;
                Candoi.c212 = 0;
                Candoi.c213 = 0;
                Candoi.c214 = 0;
                Candoi.c215 = 0;
                Candoi.c216 = 0;
                Candoi.c219 = 0;
                //220
                Candoi.c220 = 0;
                Candoi.c221 = 0;
                Candoi.c222 = 0;
                Candoi.c223 = 0;
                Candoi.c224 = 0;
                Candoi.c225 = 0;
                Candoi.c226 = 0;
                Candoi.c227 = 0;
                Candoi.c228 = 0;
                Candoi.c229 = 0;
                //230
                Candoi.c230 = 0;
                Candoi.c231 = 0;
                Candoi.c232 = 0;
                //240
                Candoi.c240 = 0;
                Candoi.c241 = 0;
                Candoi.c242 = 0;
                //250
                Candoi.c250 = 0;
                Candoi.c251 = 0;
                Candoi.c252 = 0;
                Candoi.c253 = 0;
                Candoi.c254 = 0;
                Candoi.c255 = 0;
                //260
                Candoi.c260 = 0;
                Candoi.c261 = 0;
                Candoi.c262 = 0;
                Candoi.c263 = 0;
                Candoi.c268 = 0;
                //270
                Candoi.c270 = 0;
                //300
                Candoi.c300 = 0;
                //310
                Candoi.c310 = 0;
                Candoi.c311 = 0;
                Candoi.c312 = 0;
                Candoi.c313 = 0;
                Candoi.c314 = 0;
                Candoi.c315 = 0;
                Candoi.c316 = 0;
                Candoi.c317 = 0;
                Candoi.c318 = 0;
                Candoi.c319 = 0;
                Candoi.c320 = 0;
                Candoi.c321 = 0;
                Candoi.c322 = 0;
                Candoi.c323 = 0;
                Candoi.c324 = 0;
                //330
                Candoi.c330 = 0;
                Candoi.c331 = 0;
                Candoi.c332 = 0;
                Candoi.c333 = 0;
                Candoi.c334 = 0;
                Candoi.c335 = 0;
                Candoi.c336 = 0;
                Candoi.c337 = 0;
                Candoi.c338 = 0;
                Candoi.c339 = 0;
                Candoi.c340 = 0;
                Candoi.c341 = 0;
                Candoi.c342 = 0;
                Candoi.c343 = 0;
                //400
                Candoi.c400 = 0;
                //410
                Candoi.c410 = 0;
                Candoi.c411 = 0;
                Candoi.c411a = 0;
                Candoi.c411b = 0;
                Candoi.c412 = 0;
                Candoi.c413 = 0;
                Candoi.c414 = 0;
                Candoi.c415 = 0;
                Candoi.c416 = 0;
                Candoi.c417 = 0;
                Candoi.c418 = 0;
                Candoi.c419 = 0;
                Candoi.c420 = 0;
                Candoi.c421 = 0;
                Candoi.c421a = 0;
                Candoi.c421b = 0;
                Candoi.c422 = 0;
                //430
                Candoi.c430 = 0;
                Candoi.c431 = 0;
                Candoi.c432 = 0;
                //440
                Candoi.c440 = 0;
                // Năm trước
                Candoi.d100 = 0;
                //110
                Candoi.d110 = 0;
                Candoi.d111 = 0;
                Candoi.d112 = 0;
                //120
                Candoi.d120 = 0;
                Candoi.d121 = 0;
                Candoi.d122 = 0;
                Candoi.d123 = 0;
                //130
                Candoi.d130 = 0;
                Candoi.d131 = 0;
                Candoi.d132 = 0;
                Candoi.d133 = 0;
                Candoi.d134 = 0;
                Candoi.d135 = 0;
                Candoi.d136 = 0;
                Candoi.d137 = 0;
                Candoi.d139 = 0;
                // 140 
                Candoi.d140 = 0;
                Candoi.d141 = 0;
                Candoi.d149 = 0;
                // 150
                Candoi.d150 = 0;
                Candoi.d151 = 0;
                Candoi.d152 = 0;
                Candoi.d153 = 0;
                Candoi.d154 = 0;
                Candoi.d155 = 0;
                //200
                Candoi.d200 = 0;
                //210
                Candoi.d210 = 0;
                Candoi.d211 = 0;
                Candoi.d212 = 0;
                Candoi.d213 = 0;
                Candoi.d214 = 0;
                Candoi.d215 = 0;
                Candoi.d216 = 0;
                Candoi.d219 = 0;
                //220
                Candoi.d220 = 0;
                Candoi.d221 = 0;
                Candoi.d222 = 0;
                Candoi.d223 = 0;
                Candoi.d224 = 0;
                Candoi.d225 = 0;
                Candoi.d226 = 0;
                Candoi.d227 = 0;
                Candoi.d228 = 0;
                Candoi.d229 = 0;
                //230
                Candoi.d230 = 0;
                Candoi.d231 = 0;
                Candoi.d232 = 0;
                //240
                Candoi.d240 = 0;
                Candoi.d241 = 0;
                Candoi.d242 = 0;
                //250
                Candoi.d250 = 0;
                Candoi.d251 = 0;
                Candoi.d252 = 0;
                Candoi.d253 = 0;
                Candoi.d254 = 0;
                Candoi.d255 = 0;
                //260
                Candoi.d260 = 0;
                Candoi.d261 = 0;
                Candoi.d262 = 0;
                Candoi.d263 = 0;
                Candoi.d268 = 0;
                //270
                Candoi.d270 = 0;
                //300
                Candoi.d300 = 0;
                //310
                Candoi.d310 = 0;
                Candoi.d311 = 0;
                Candoi.d312 = 0;
                Candoi.d313 = 0;
                Candoi.d314 = 0;
                Candoi.d315 = 0;
                Candoi.d316 = 0;
                Candoi.d317 = 0;
                Candoi.d318 = 0;
                Candoi.d319 = 0;
                Candoi.d320 = 0;
                Candoi.d321 = 0;
                Candoi.d322 = 0;
                Candoi.d323 = 0;
                Candoi.d324 = 0;
                //330
                Candoi.d330 = 0;
                Candoi.d331 = 0;
                Candoi.d332 = 0;
                Candoi.d333 = 0;
                Candoi.d334 = 0;
                Candoi.d335 = 0;
                Candoi.d336 = 0;
                Candoi.d337 = 0;
                Candoi.d338 = 0;
                Candoi.d339 = 0;
                Candoi.d340 = 0;
                Candoi.d341 = 0;
                Candoi.d342 = 0;
                Candoi.d343 = 0;
                //400
                Candoi.d400 = 0;
                //410
                Candoi.d410 = 0;
                Candoi.d411 = 0;
                Candoi.d411a = 0;
                Candoi.d411b = 0;
                Candoi.d412 = 0;
                Candoi.d413 = 0;
                Candoi.d414 = 0;
                Candoi.d415 = 0;
                Candoi.d416 = 0;
                Candoi.d417 = 0;
                Candoi.d418 = 0;
                Candoi.d419 = 0;
                Candoi.d420 = 0;
                Candoi.d421 = 0;
                Candoi.d421a = 0;
                Candoi.d421b = 0;
                Candoi.d422 = 0;
                //430
                Candoi.d430 = 0;
                Candoi.d431 = 0;
                Candoi.d432 = 0;
                //440
                Candoi.d440 = 0;
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
                //var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv select a);
                var lst1 = (from a in db.ct_tks
                            select a);
                var lst1a = (from a in db.sodubandaus
                             select a);
                if (check != 0)
                {
                    lst1 = (from a in db.ct_tks
                            join b in db.dk_rps on a.iddv equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_bangcandoiketoan"
                            select a);
                    lst1a = (from a in db.sodubandaus
                             join b in db.dk_rps on a.iddv equals b.id
                             where b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_bangcandoiketoan"
                             select a);
                }
                var tk = from b in db.dmtks where b.active == true select b;
                var lst2 = (from a in lst1
                            join b in tk on a.tk_no equals b.matk
                            where a.ngaychungtu < tungay.DateTime
                            select new
                            {
                                taikhoan = a.tk_no,
                                iddt = a.dt_no,
                                psno = a.PS,
                                psco = a.PS - a.PS,
                            }).Concat(from a in lst1
                                      join b in tk on a.tk_co equals b.matk
                                      where a.ngaychungtu < tungay.DateTime /*&& a.ngaychungtu <= denngay.DateTime*/
                                      select new
                                      {
                                          taikhoan = a.tk_co,
                                          iddt = a.dt_co,
                                          psno = a.PS - a.PS,
                                          psco = a.PS,
                                      }).Concat(from a in lst1a
                                                join b in tk on a.matk equals b.matk
                                                select new
                                                {
                                                    taikhoan = a.matk,
                                                    iddt = a.iddt,
                                                    psno = a.psno == null ? 0 : a.psno,
                                                    psco = a.psco == null ? 0 : a.psco,
                                                });
                var lst3 = (from a in lst2
                            join b in db.dmtks on a.taikhoan equals b.matk into k
                            //where b.kieusodu == "DEBCRD"
                            from b in k.DefaultIfEmpty()
                            group a by new
                            {
                                b.kieusodu,
                                a.taikhoan,
                                b.tentk,
                                a.iddt,
                            }
                            into g
                            select new
                            {
                                g.Key.kieusodu,
                                taikhoan = g.Key.taikhoan,
                                iddt = g.Key.iddt,
                                tentk = g.Key.tentk,
                                psno = g.Sum(t => t.psno),
                                psco = g.Sum(t => t.psco),
                            }
                            );
                var lst4 = from a in lst3
                           select new
                           {
                               a.taikhoan,
                               a.tentk,
                               a.iddt,
                               //no = a.kieusodu == "CRD" ? (a.psco - a.psno < 0 ? a.psno - a.psco : 0) : (a.psno - a.psco > 0 ? a.psno - a.psco : 0),
                               //co = a.kieusodu == "CRD" ? (a.psco - a.psno > 0 ? a.psco - a.psno : 0) : (a.psno - a.psco < 0 ? a.psco - a.psno : 0),
                               no = a.kieusodu == "CRD" ? 0 : (a.kieusodu == "DEB" ? a.psno - a.psco : (a.psno - a.psco > 0 ? a.psno - a.psco : 0)),
                               co = a.kieusodu == "DEB" ? 0 : (a.kieusodu == "CRD" ? a.psco - a.psno : (a.psno - a.psco < 0 ? a.psco - a.psno : 0)),
                           };
                var ltdau = (from a in lst4
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
                             });
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
                                no = a.kieusodu == "CRD" ? 0 : (a.kieusodu == "DEB" ? a.psno - a.psco : (a.psno - a.psco > 0 ? a.psno - a.psco : 0)),
                                co = a.kieusodu == "DEB" ? 0 : (a.kieusodu == "CRD" ? a.psco - a.psno : (a.psno - a.psco < 0 ? a.psco - a.psno : 0)),
                            };
                var tkdau = from a in lst4a
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
                            taikhoan = a.tk_no,
                            iddt = a.dt_no,
                            psno = a.PS,
                            psco = a.PS - a.PS,
                        }).Concat(from a in lst1
                                  join b in tk on a.tk_co equals b.matk
                                  where a.ngaychungtu <= denngay.DateTime /*&& a.ngaychungtu <= denngay.DateTime*/
                                  select new
                                  {
                                      taikhoan = a.tk_co,
                                      iddt = a.dt_co,
                                      psno = a.PS - a.PS,
                                      psco = a.PS,
                                  }).Concat(from a in lst1a
                                            join b in tk on a.matk equals b.matk
                                            select new
                                            {
                                                taikhoan = a.matk,
                                                iddt = a.iddt,
                                                psno = a.psno == null ? 0 : a.psno,
                                                psco = a.psco == null ? 0 : a.psco,
                                            });
                lst3 = (from a in lst2
                        join b in db.dmtks on a.taikhoan equals b.matk
                        //where b.kieusodu == "DEBCRD"
                        group a by new
                        {
                            b.kieusodu,
                            a.taikhoan,
                            b.tentk,
                            a.iddt,
                        }
                       into g
                        select new
                        {
                            g.Key.kieusodu,
                            taikhoan = g.Key.taikhoan,
                            iddt = g.Key.iddt,
                            tentk = g.Key.tentk,
                            psno = g.Sum(t => t.psno),
                            psco = g.Sum(t => t.psco)
                        });
                lst4 = from a in lst3
                       select new
                       {
                           a.taikhoan,
                           a.tentk,
                           a.iddt,
                           no = a.kieusodu == "CRD" ? 0 : (a.kieusodu == "DEB" ? a.psno - a.psco : (a.psno - a.psco > 0 ? a.psno - a.psco : 0)),
                           co = a.kieusodu == "DEB" ? 0 : (a.kieusodu == "CRD" ? a.psco - a.psno : (a.psno - a.psco < 0 ? a.psco - a.psno : 0)),
                       };
                var ltcuoi = (from a in lst4
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
                              });
                lst3a = (from a in lst2
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
                lst4a = from a in lst3a
                        select new
                        {
                            a.taikhoan,
                            a.tentk,
                            no = a.kieusodu == "CRD" ? 0 : (a.kieusodu == "DEB" ? a.psno - a.psco : (a.psno - a.psco > 0 ? a.psno - a.psco : 0)),
                            co = a.kieusodu == "DEB" ? 0 : (a.kieusodu == "CRD" ? a.psco - a.psno : (a.psno - a.psco < 0 ? a.psco - a.psno : 0)),
                        };
                var tkcuoi = (from a in lst4a
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
                              });
                var lttong = (from a in db.dmtks
                              join d in ltcuoi on a.matk equals d.taikhoan into k
                              join b in ltdau on a.matk equals b.taikhoan into g
                              from cuoi in k.DefaultIfEmpty()
                              from dau in g.DefaultIfEmpty()
                                  //where dau.psno != 0 || dau.psco != 0 || cuoi.psno != 0 || cuoi.psco != 0
                              select new
                              {
                                  a.matk,
                                  a.tentk,
                                  tkgoc = catchuoi(a.matk),
                                  tkcap2 = tkc2(a.matk),
                                  tkcap3 = tkc3(a.matk),
                                  ctno_dau = dau.psno,
                                  ctco_dau = dau.psco,
                                  ctno_cuoi = cuoi.psno,
                                  ctco_cuoi = cuoi.psco,
                                  psno_dau = dau.psno - dau.psno,
                                  psco_dau = dau.psco - dau.psco,
                                  psno_cuoi = cuoi.psno - cuoi.psno,
                                  psco_cuoi = cuoi.psco - cuoi.psco,
                              });
                var tktong = (from a in db.dmtks
                              join b in tkdau on a.matk equals b.taikhoan into g
                              join d in tkcuoi on a.matk equals d.taikhoan into k
                              from dau in g.DefaultIfEmpty()
                              from cuoi in k.DefaultIfEmpty()
                              where dau.psno != 0 || dau.psco != 0 || cuoi.psno != 0 || cuoi.psco != 0
                              select new
                              {
                                  a.matk,
                                  a.tentk,
                                  tkgoc = catchuoi(a.matk),
                                  tkcap2 = tkc2(a.matk),
                                  tkcap3 = tkc3(a.matk),
                                  ctno_dau = dau.psno - dau.psno,
                                  ctco_dau = dau.psco - dau.psco,
                                  ctno_cuoi = cuoi.psno - cuoi.psno,
                                  ctco_cuoi = cuoi.psco - cuoi.psco,
                                  psno_dau = dau.psno,
                                  psco_dau = dau.psco,
                                  psno_cuoi = cuoi.psno,
                                  psco_cuoi = cuoi.psco,
                              });
                //var tong = tktong.Union(lttong).OrderBy(t => t.matk);
                var tong = tktong.Union(lttong).OrderBy(t => t.matk).ToList();
                #region Tài sản ngắn hạn (100)
                #region 110
                // 111
                var gt = (from a in tong where a.tkgoc == "111" || a.tkgoc == "112" || a.tkgoc == "113" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d111 = 0;
                    Candoi.c111 = 0;
                }
                else
                {
                    Candoi.d111 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c111 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 112
                gt = (from a in tong where a.tkcap3 == "12811" || a.tkcap3 == "12881" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d112 = 0;
                    Candoi.c112 = 0;
                }
                else
                {
                    Candoi.d112 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c112 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                Candoi.c110 = Candoi.c111 + Candoi.c112;
                Candoi.d110 = Candoi.d111 + Candoi.d112;
                #endregion
                #region 120
                // 121
                gt = (from a in tong where a.tkgoc == "121" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d121 = 0;
                    Candoi.c121 = 0;
                }
                else
                {
                    Candoi.d121 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c121 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 122
                gt = (from a in tong where a.tkcap2 == "2291" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d122 = 0;
                    Candoi.c122 = 0;
                }
                else
                {
                    Candoi.d122 = (-1) * double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c122 = (-1) * double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                //123
                gt = (from a in tong where a.tkcap3 == "12811" || a.tkcap3 == "12821" || a.tkcap3 == "12881" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d123 = 0;
                    Candoi.c123 = 0;
                }
                else
                {
                    Candoi.d123 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c123 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                Candoi.d120 = Candoi.d121 + Candoi.d122 + Candoi.d123;
                Candoi.c120 = Candoi.c121 + Candoi.c122 + Candoi.c123;
                #endregion
                #region 130
                //131
                gt = (from a in tong where a.tkcap2 == "1311" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d131 = 0;
                    Candoi.c131 = 0;
                }
                else
                {
                    Candoi.d131 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c131 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 132
                gt = (from a in tong where a.tkcap2 == "3311" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d132 = 0;
                    Candoi.c132 = 0;
                }
                else
                {
                    Candoi.d132 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c132 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 133
                gt = (from a in tong where a.tkcap3 == "13621" || a.tkcap3 == "13631" || a.tkcap3 == "13681" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d133 = 0;
                    Candoi.c133 = 0;
                }
                else
                {
                    Candoi.d133 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c133 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                //134
                gt = (from a in tong where a.tkgoc == "337" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d134 = 0;
                    Candoi.c134 = 0;
                }
                else
                {
                    Candoi.d134 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c134 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 135
                gt = (from a in tong where a.tkcap3 == "12831" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d135 = 0;
                    Candoi.c135 = 0;
                }
                else
                {
                    Candoi.d135 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c135 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 136
                gt = (from a in tong where a.tkcap3 == "13851" || a.tkcap3 == "13881" || a.tkcap2 == "3341" || a.tkcap2 == "3348" || a.tkcap2 == "3381" || a.tkcap2 == "3382" || a.tkcap2 == "3383" || a.tkcap2 == "3384" || a.tkcap2 == "3385" || a.tkcap2 == "3386" || a.tkcap3 == "33871" || a.tkcap3 == "33881" || a.tkcap2 == "1411" || a.tkcap2 == "2441" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d136 = 0;
                    Candoi.c136 = 0;
                }
                else
                {
                    Candoi.d136 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c136 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 137
                gt = (from a in tong where a.tkcap3 == "22931" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d137 = 0;
                    Candoi.c137 = 0;
                }
                else
                {
                    Candoi.d137 = (-1) * double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c137 = (-1) * double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 139
                gt = (from a in tong where a.tkcap2 == "1381" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d139 = 0;
                    Candoi.c139 = 0;
                }
                else
                {
                    Candoi.d139 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c139 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                Candoi.d130 = Candoi.d131 + Candoi.d132 + Candoi.d133 + Candoi.d134 + Candoi.d135 + Candoi.d136 + Candoi.d137 + Candoi.d139;
                Candoi.c130 = Candoi.c131 + Candoi.c132 + Candoi.c133 + Candoi.c134 + Candoi.c135 + Candoi.c136 + Candoi.c137 + Candoi.c139;
                #endregion
                #region 140
                //141
                gt = (from a in tong where a.tkgoc == "151" || a.tkgoc == "152" || a.tkgoc == "153" || a.tkgoc == "154" || a.tkgoc == "155" || a.tkgoc == "156" || a.tkgoc == "157" || a.tkgoc == "158" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d141 = 0;
                    Candoi.c141 = 0;
                }
                else
                {
                    Candoi.d141 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c141 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 149
                gt = (from a in tong where a.tkcap2 == "2294" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d149 = 0;
                    Candoi.c149 = 0;
                }
                else
                {
                    Candoi.d149 = (-1) * double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c149 = (-1) * double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                Candoi.d140 = Candoi.d141 + Candoi.d149;
                Candoi.c140 = Candoi.c141 + Candoi.c149;
                #endregion
                #region 150
                // 151
                gt = (from a in tong where a.tkcap2 == "2421" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d151 = 0;
                    Candoi.c151 = 0;
                }
                else
                {
                    Candoi.d151 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c151 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 152
                gt = (from a in tong where a.tkgoc == "133" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d152 = 0;
                    Candoi.c152 = 0;
                }
                else
                {
                    Candoi.d152 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c152 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 153
                gt = (from a in tong where a.tkgoc == "333" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d153 = 0;
                    Candoi.c153 = 0;
                }
                else
                {
                    Candoi.d153 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c153 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 154
                gt = (from a in tong where a.tkgoc == "171" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d154 = 0;
                    Candoi.c154 = 0;
                }
                else
                {
                    Candoi.d154 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c154 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 155
                gt = (from a in tong where a.tkcap3 == "22881" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d155 = 0;
                    Candoi.c155 = 0;
                }
                else
                {
                    Candoi.d155 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c155 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                Candoi.d150 = Candoi.d151 + Candoi.d152 + Candoi.d153 + Candoi.d154 + Candoi.d155;
                Candoi.c150 = Candoi.c151 + Candoi.c152 + Candoi.c153 + Candoi.c154 + Candoi.c155;
                #endregion
                Candoi.d100 = Candoi.d110 + Candoi.d120 + Candoi.d130 + Candoi.d140 + Candoi.d150;
                Candoi.c100 = Candoi.c110 + Candoi.c120 + Candoi.c130 + Candoi.c140 + Candoi.c150;
                #endregion
                #region Tài sản Dài Hạn (200)
                #region 210
                // 211
                gt = (from a in tong where a.tkcap2 == "1312" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d211 = 0;
                    Candoi.c211 = 0;
                }
                else
                {
                    Candoi.d211 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c211 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 212
                gt = (from a in tong where a.tkcap2 == "3312" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d212 = 0;
                    Candoi.c212 = 0;
                }
                else
                {
                    Candoi.d212 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c212 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 213
                gt = (from a in tong where a.tkcap2 == "1361" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d213 = 0;
                    Candoi.c213 = 0;
                }
                else
                {
                    Candoi.d213 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c213 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 214
                gt = (from a in tong where a.tkcap3 == "16322" || a.tkcap3 == "13632" || a.tkcap3 == "13682" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d214 = 0;
                    Candoi.c214 = 0;
                }
                else
                {
                    Candoi.d214 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c214 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                //215
                gt = (from a in tong where a.tkcap3 == "12832" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d215 = 0;
                    Candoi.c215 = 0;
                }
                else
                {
                    Candoi.d215 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c215 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                //216
                gt = (from a in tong where a.tkcap3 == "13852" || a.tkcap3 == "13882" || a.tkcap2 == "3342" || a.tkcap3 == "33872" || a.tkcap3 == "33882" || a.tkcap2 == "1412" || a.tkcap2 == "2242" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d216 = 0;
                    Candoi.c216 = 0;
                }
                else
                {
                    Candoi.d216 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c216 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 219
                gt = (from a in tong where a.tkcap3 == "22932" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d219 = 0;
                    Candoi.c219 = 0;
                }
                else
                {
                    Candoi.d219 = (-1) * double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c219 = (-1) * double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                Candoi.d210 = Candoi.d211 + Candoi.d212 + Candoi.d213 + Candoi.d214 + Candoi.d215 + Candoi.d216 + Candoi.d219;
                Candoi.c210 = Candoi.c211 + Candoi.c212 + Candoi.c213 + Candoi.c214 + Candoi.c215 + Candoi.c216 + Candoi.c219;
                #endregion
                #region 220
                // 221
                // 222
                gt = (from a in tong where a.tkgoc == "211" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d222 = 0;
                    Candoi.c222 = 0;
                }
                else
                {
                    Candoi.d222 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c222 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 223
                gt = (from a in tong where a.tkcap2 == "2141" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d223 = 0;
                    Candoi.c223 = 0;
                }
                else
                {
                    Candoi.d223 = (-1) * double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c223 = (-1) * double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                Candoi.d221 = Candoi.d222 + Candoi.d223;
                Candoi.c221 = Candoi.c222 + Candoi.c223;
                // 225
                gt = (from a in tong where a.tkgoc == "212" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d225 = 0;
                    Candoi.c225 = 0;
                }
                else
                {
                    Candoi.d225 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c225 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                //226
                gt = (from a in tong where a.tkcap2 == "2142" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d226 = 0;
                    Candoi.c226 = 0;
                }
                else
                {
                    Candoi.d226 = (-1) * double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c226 = (-1) * double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 224
                Candoi.d224 = Candoi.d225 + Candoi.d226;
                Candoi.c224 = Candoi.c225 + Candoi.c226;
                // 228
                gt = (from a in tong where a.tkgoc == "213" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d228 = 0;
                    Candoi.c228 = 0;
                }
                else
                {
                    Candoi.d228 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c228 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 229
                gt = (from a in tong where a.tkcap2 == "2143" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d229 = 0;
                    Candoi.c229 = 0;
                }
                else
                {
                    Candoi.d229 = (-1) * double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c229 = (-1) * double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                //227
                Candoi.d227 = Candoi.d228 + Candoi.d229;
                Candoi.c227 = Candoi.c228 + Candoi.c229;
                Candoi.d220 = Candoi.d221 + Candoi.d224 + Candoi.d227;
                Candoi.c220 = Candoi.c221 + Candoi.c224 + Candoi.c227;
                #endregion
                #region 230
                //231
                gt = (from a in tong where a.tkgoc == "217" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d231 = 0;
                    Candoi.c231 = 0;
                }
                else
                {
                    Candoi.d231 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c231 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 232
                gt = (from a in tong where a.tkcap2 == "2147" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d232 = 0;
                    Candoi.c232 = 0;
                }
                else
                {
                    Candoi.d232 = (-1) * double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c232 = (-1) * double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                Candoi.d230 = Candoi.d231 + Candoi.d232;
                Candoi.c230 = Candoi.c231 + Candoi.c232;
                #endregion
                #region 240
                //241
                gt = (from a in tong where a.tkgoc == "154" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d241 = 0;
                    Candoi.c241 = 0;
                }
                else
                {
                    Candoi.d241 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c241 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                gt = (from a in tong where a.tkcap2 == "2294" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d241 = Candoi.d241 + 0;
                    Candoi.c241 = Candoi.c241 + 0;
                }
                else
                {
                    Candoi.d241 = Candoi.d241 + double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c241 = Candoi.c241 + double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 242
                gt = (from a in tong where a.tkgoc == "241" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d242 = 0;
                    Candoi.c242 = 0;
                }
                else
                {
                    Candoi.d242 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c242 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                Candoi.d240 = Candoi.d241 + Candoi.d242;
                Candoi.c240 = Candoi.c241 + Candoi.c242;
                #endregion
                #region 250
                // 251
                gt = (from a in tong where a.tkgoc == "211" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d251 = 0;
                    Candoi.c251 = 0;
                }
                else
                {
                    Candoi.d251 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c251 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                //252
                gt = (from a in tong where a.tkgoc == "222" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d252 = 0;
                    Candoi.c252 = 0;
                }
                else
                {
                    Candoi.d252 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c252 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 253
                gt = (from a in tong where a.tkcap2 == "2281" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d253 = 0;
                    Candoi.c253 = 0;
                }
                else
                {
                    Candoi.d253 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c253 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 254
                gt = (from a in tong where a.tkcap2 == "2292" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d254 = 0;
                    Candoi.c254 = 0;
                }
                else
                {
                    Candoi.d254 = (-1) * double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c254 = (-1) * double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 255
                gt = (from a in tong where a.tkcap3 == "12812" || a.tkcap3 == "12822" || a.tkcap3 == "12882" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d255 = 0;
                    Candoi.c255 = 0;
                }
                else
                {
                    Candoi.d255 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c255 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                Candoi.d250 = Candoi.d251 + Candoi.d252 + Candoi.d253 + Candoi.d254 + Candoi.d255;
                Candoi.c250 = Candoi.c251 + Candoi.c252 + Candoi.c253 + Candoi.c254 + Candoi.c255;
                #endregion
                #region 260
                //261
                gt = (from a in tong where a.tkcap2 == "2422" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d261 = 0;
                    Candoi.c261 = 0;
                }
                else
                {
                    Candoi.d261 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c261 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                // 262
                gt = (from a in tong where a.tkgoc == "243" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d262 = 0;
                    Candoi.c262 = 0;
                }
                else
                {
                    Candoi.d262 = double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c262 = double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                //263
                gt = (from a in tong where a.tkcap2 == "1534" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d263 = 0;
                    Candoi.c263 = 0;
                }
                else
                {
                    Candoi.d263 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c263 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                gt = (from a in tong where a.tkcap2 == "2294" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d263 = Candoi.d263 + 0;
                    Candoi.c263 = Candoi.c263 + 0;
                }
                else
                {
                    Candoi.d263 = Candoi.d263 + double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c263 = Candoi.c263 + double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                //268
                gt = (from a in tong where a.tkcap3 == "22882" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d268 = 0;
                    Candoi.c268 = 0;
                }
                else
                {
                    Candoi.d268 = double.Parse(gt.Sum(t => t.ctno_dau).ToString());
                    Candoi.c268 = double.Parse(gt.Sum(t => t.ctno_cuoi).ToString());
                }
                Candoi.d260 = Candoi.d261 + Candoi.d262 + Candoi.d263 + Candoi.d268;
                Candoi.c260 = Candoi.c261 + Candoi.c262 + Candoi.c263 + Candoi.c268;
                #endregion
                Candoi.d200 = Candoi.d210 + Candoi.d220 + Candoi.d230 + Candoi.d240 + Candoi.d250 + Candoi.d260;
                Candoi.c200 = Candoi.c210 + Candoi.c220 + Candoi.c230 + Candoi.c240 + Candoi.c250 + Candoi.c260;
                #endregion
                #region 270
                Candoi.d270 = Candoi.d100 + Candoi.d200;
                Candoi.c270 = Candoi.c100 + Candoi.c200;
                #endregion
                #region Nợ Phải Trả (300)
                #region 310
                //311
                gt = (from a in tong where a.tkcap2 == "3311" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d311 = 0;
                    Candoi.c311 = 0;
                }
                else
                {
                    Candoi.d311 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c311 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 312
                gt = (from a in tong where a.tkcap2 == "1311" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d312 = 0;
                    Candoi.c312 = 0;
                }
                else
                {
                    Candoi.d312 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c312 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 313
                gt = (from a in tong where a.tkgoc == "333" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d313 = 0;
                    Candoi.c313 = 0;
                }
                else
                {
                    Candoi.d313 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c313 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 314
                gt = (from a in tong where a.tkcap2 == "3341" || a.tkcap2 == "3348" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d314 = 0;
                    Candoi.c314 = 0;
                }
                else
                {
                    Candoi.d314 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c314 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                //315
                gt = (from a in tong where a.tkcap2 == "3351" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d315 = 0;
                    Candoi.c315 = 0;
                }
                else
                {
                    Candoi.d315 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c315 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                //316
                gt = (from a in tong where a.tkcap3 == "33621" || a.tkcap3 == "33631" || a.tkcap3 == "33681" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d316 = 0;
                    Candoi.c316 = 0;
                }
                else
                {
                    Candoi.d316 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c316 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 317
                gt = (from a in tong where a.tkgoc == "337" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d317 = 0;
                    Candoi.c317 = 0;
                }
                else
                {
                    Candoi.d317 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c317 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                //318
                gt = (from a in tong where a.tkcap3 == "33871" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d318 = 0;
                    Candoi.c318 = 0;
                }
                else
                {
                    Candoi.d318 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c318 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                //319
                gt = (from a in tong where a.tkcap2 == "3381" || a.tkcap2 == "3382" || a.tkcap2 == "3383" || a.tkcap2 == "3384" || a.tkcap2 == "3385" || a.tkcap2 == "3386" || a.tkcap3 == "33871" || a.tkcap3 == "33881" || a.tkcap2 == "1381" || a.tkcap2 == "3441" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d319 = 0;
                    Candoi.c319 = 0;
                }
                else
                {
                    Candoi.d319 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c319 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 320 
                gt = (from a in tong where a.tkcap3 == "34111" || a.tkcap3 == "34121" || a.matk == "343111" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d320 = 0;
                    Candoi.c320 = 0;
                }
                else
                {
                    Candoi.d320 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c320 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 321
                gt = (from a in tong where a.tkcap3 == "35211" || a.tkcap3 == "35221" || a.tkcap3 == "35231" || a.tkcap3 == "35241" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d321 = 0;
                    Candoi.c321 = 0;
                }
                else
                {
                    Candoi.d321 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c321 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 322
                gt = (from a in tong where a.tkgoc == "353" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d322 = 0;
                    Candoi.c322 = 0;
                }
                else
                {
                    Candoi.d322 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c322 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 323
                gt = (from a in tong where a.tkgoc == "357" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d323 = 0;
                    Candoi.c323 = 0;
                }
                else
                {
                    Candoi.d323 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c323 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 324
                gt = (from a in tong where a.tkgoc == "171" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d324 = 0;
                    Candoi.c324 = 0;
                }
                else
                {
                    Candoi.d324 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c324 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                Candoi.d310 = Candoi.d311 + Candoi.d312 + Candoi.d313 + Candoi.d314 + Candoi.d315 + Candoi.d316 + Candoi.d317 + Candoi.d318 + Candoi.d319 + Candoi.d320 + Candoi.d321 + Candoi.d322 + Candoi.d323 + Candoi.d324;
                Candoi.c310 = Candoi.c311 + Candoi.c312 + Candoi.c313 + Candoi.c314 + Candoi.c315 + Candoi.c316 + Candoi.c317 + Candoi.c318 + Candoi.c319 + Candoi.c320 + Candoi.c321 + Candoi.c322 + Candoi.c323 + Candoi.c324;
                #endregion
                #region 330
                //331
                gt = (from a in tong where a.tkcap2 == "3312" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d331 = 0;
                    Candoi.c331 = 0;
                }
                else
                {
                    Candoi.d331 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c331 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                //332
                gt = (from a in tong where a.tkcap2 == "1312" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d332 = 0;
                    Candoi.c332 = 0;
                }
                else
                {
                    Candoi.d332 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c332 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                //333
                gt = (from a in tong where a.tkcap2 == "3352" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d333 = 0;
                    Candoi.c333 = 0;
                }
                else
                {
                    Candoi.d333 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c333 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 334
                gt = (from a in tong where a.tkcap3 == "3361" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d334 = 0;
                    Candoi.c334 = 0;
                }
                else
                {
                    Candoi.d334 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c334 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                //335
                gt = (from a in tong where a.tkcap3 == "33622" || a.tkcap3 == "33632" || a.tkcap3 == "33682" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d316 = 0;
                    Candoi.c316 = 0;
                }
                else
                {
                    Candoi.d316 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c316 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 336
                gt = (from a in tong where a.tkcap3 == "33872" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d336 = 0;
                    Candoi.c336 = 0;
                }
                else
                {
                    Candoi.d336 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c336 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                //337
                gt = (from a in tong where a.tkcap3 == "33882" || a.tkcap2 == "3342" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d337 = 0;
                    Candoi.c337 = 0;
                }
                else
                {
                    Candoi.d337 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c337 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 338
                gt = (from a in tong where a.tkcap3 == "34112" || a.tkcap3 == "34122" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d338 = 0;
                    Candoi.c338 = 0;
                }
                else
                {
                    Candoi.d338 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c338 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                gt = (from a in tong where a.matk == "343112" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d338 = Candoi.d338 + 0;
                    Candoi.c338 = Candoi.c338 + 0;
                }
                else
                {
                    Candoi.d338 = Candoi.d338 - double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c338 = Candoi.c338 - double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                gt = (from a in tong where a.tkcap3 == "34312" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d338 = Candoi.d338 + 0;
                    Candoi.c338 = Candoi.c338 + 0;
                }
                else
                {
                    Candoi.d338 = Candoi.d338 - double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c338 = Candoi.c338 - double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                gt = (from a in tong where a.tkcap3 == "34313" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d338 = Candoi.d338 + 0;
                    Candoi.c338 = Candoi.c338 + 0;
                }
                else
                {
                    Candoi.d311 = Candoi.d338 + double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c338 = Candoi.c338 + double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 339
                gt = (from a in tong where a.tkcap2 == "3432" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d339 = 0;
                    Candoi.c339 = 0;
                }
                else
                {
                    Candoi.d339 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c339 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 340
                gt = (from a in tong where a.tkcap3 == "41112" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d340 = 0;
                    Candoi.c340 = 0;
                }
                else
                {
                    Candoi.d340 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c340 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 341
                gt = (from a in tong where a.tkgoc == "347" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d341 = 0;
                    Candoi.c341 = 0;
                }
                else
                {
                    Candoi.d341 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c341 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 342
                gt = (from a in tong where a.tkcap3 == "35212" || a.tkcap3 == "35222" || a.tkcap3 == "35232" || a.tkcap3 == "35242" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d342 = 0;
                    Candoi.c342 = 0;
                }
                else
                {
                    Candoi.d342 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c342 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                //343
                gt = (from a in tong where a.tkgoc == "356" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d343 = 0;
                    Candoi.c343 = 0;
                }
                else
                {
                    Candoi.d343 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c343 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 330
                Candoi.d330 = Candoi.d331 + Candoi.d332 + Candoi.d333 + Candoi.d334 + Candoi.d335 + Candoi.d336 + Candoi.d337 + Candoi.d338 + Candoi.d339 + Candoi.d340 + Candoi.d341 + Candoi.d342 + Candoi.d343;
                Candoi.c330 = Candoi.c331 + Candoi.c332 + Candoi.c333 + Candoi.c334 + Candoi.c335 + Candoi.c336 + Candoi.c337 + Candoi.c338 + Candoi.c339 + Candoi.c340 + Candoi.c341 + Candoi.c342 + Candoi.c343;
                #endregion
                Candoi.d300 = Candoi.d310 + Candoi.d330;
                Candoi.c300 = Candoi.c310 + Candoi.c330;
                #endregion
                #region 400
                #region 410
                //411a
                gt = (from a in tong where a.tkcap3 == "41111" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d411a = 0;
                    Candoi.c411a = 0;
                }
                else
                {
                    Candoi.d411a = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c411a = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                //411b
                gt = (from a in tong where a.matk == "41112" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d411b = 0;
                    Candoi.c411b = 0;
                }
                else
                {
                    Candoi.d411b = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c411b = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 411
                Candoi.d411 = Candoi.d411a + Candoi.d411b;
                // 412
                gt = (from a in tong where a.tkcap2 == "4112" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d412 = 0;
                    Candoi.c412 = 0;
                }
                else
                {
                    Candoi.d412 = double.Parse(gt.Sum(t => t.psco_dau).ToString()) - double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c412 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString()) - double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 413
                gt = (from a in tong where a.tkcap2 == "4113" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d413 = 0;
                    Candoi.c413 = 0;
                }
                else
                {
                    Candoi.d413 = double.Parse(gt.Sum(t => t.ctco_dau).ToString());
                    Candoi.c413 = double.Parse(gt.Sum(t => t.ctco_cuoi).ToString());
                }
                // 414
                gt = (from a in tong where a.tkcap2 == "4118" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d414 = 0;
                    Candoi.c414 = 0;
                }
                else
                {
                    Candoi.d414 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c414 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                //415
                gt = (from a in tong where a.tkgoc == "419" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d415 = 0;
                    Candoi.c415 = 0;
                }
                else
                {
                    Candoi.d415 = (-1) * double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c415 = (-1) * double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                //416
                gt = (from a in tong where a.tkgoc == "412" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d416 = 0;
                    Candoi.c416 = 0;
                }
                else
                {
                    Candoi.d416 = double.Parse(gt.Sum(t => t.psco_dau).ToString()) - double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c416 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString()) - double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 417
                gt = (from a in tong where a.tkgoc == "413" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d417 = 0;
                    Candoi.c417 = 0;
                }
                else
                {
                    Candoi.d417 = double.Parse(gt.Sum(t => t.psco_dau).ToString()) - double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c417 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString()) - double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                //418
                gt = (from a in tong where a.tkgoc == "414" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d418 = 0;
                    Candoi.c418 = 0;
                }
                else
                {
                    Candoi.d418 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c418 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                //419
                gt = (from a in tong where a.tkgoc == "417" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d419 = 0;
                    Candoi.c419 = 0;
                }
                else
                {
                    Candoi.d419 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c419 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 420 
                gt = (from a in tong where a.tkgoc == "418" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d420 = 0;
                    Candoi.c420 = 0;
                }
                else
                {
                    Candoi.d420 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c420 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                //421a
                //gt = (from a in tong where a.tkcap2 == "4211" select a);
                var lst4212 = (from a in db.ct_tks
                               join b in db.dk_rps on a.iddv equals b.id
                               where b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_bangcandoiketoan"
                               where a.tk_no == "911" || a.tk_co == "911"
                               where a.ngaychungtu < tungay.DateTime
                               select a);
                if (lst4212.Count() == 0)
                {
                    Candoi.c421a = 0;
                }
                else
                {
                    var co = (from a in lst4212
                              select new
                              {
                                  co = a.tk_co == "911" ? a.PS : 0,
                              }).Sum(t => t.co);
                    var no = (from a in lst4212
                              select new
                              {
                                  no = a.tk_no == "911" ? a.PS : 0
                              }).Sum(t => t.no);
                    double? b = co - no;
                    Candoi.c421a = double.Parse(b.ToString());
                }
                //421b
                //gt = (from a in tong where a.tkcap2 == "4212" select a);
                lst4212 = (from a in db.ct_tks
                           join b in db.dk_rps on a.iddv equals b.id
                           where b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_bangcandoiketoan"
                           where a.tk_no == "911" || a.tk_co == "911"
                           where a.ngaychungtu < tungay.DateTime
                           select a);
                if (lst4212.Count() == 0)
                {
                    Candoi.d421b = 0;
                }
                else
                {
                    var co = (from a in lst4212
                              select new
                              {
                                  co = a.tk_co == "911" ? a.PS : 0,
                              }).Sum(t => t.co);
                    var no = (from a in lst4212
                              select new
                              {
                                  no = a.tk_no == "911" ? a.PS : 0
                              }).Sum(t => t.no);
                    double? b = co - no;
                    Candoi.d421b = double.Parse(b.ToString());
                }
                // cuoi ky
                lst4212 = (from a in db.ct_tks
                           join b in db.dk_rps on a.iddv equals b.id
                           where b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ" && b.form == "f_bangcandoiketoan"
                           where a.tk_no == "911" || a.tk_co == "911"
                           where a.ngaychungtu >= tungay.DateTime && a.ngaychungtu <= denngay.DateTime
                           select a);
                if (lst4212.Count() == 0)
                {
                    Candoi.c421b = 0;
                }
                else
                {
                    var co = (from a in lst4212
                              select new
                              {
                                  co = a.tk_co == "911" ? a.PS : 0,
                              }).Sum(t => t.co);
                    var no = (from a in lst4212
                              select new
                              {
                                  no = a.tk_no == "911" ? a.PS : 0
                              }).Sum(t => t.no);
                    double? b = co - no;
                    Candoi.c421b = double.Parse(b.ToString());
                }
                //421
                Candoi.d421 = Candoi.d421a + Candoi.d421b;
                Candoi.c421 = Candoi.c421a + Candoi.c421b;
                // 422
                gt = (from a in tong where a.tkgoc == "441" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d422 = 0;
                    Candoi.c422 = 0;
                }
                else
                {
                    Candoi.d422 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c422 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 410
                Candoi.d410 = Candoi.d411 + Candoi.d412 + Candoi.d413 + Candoi.d414 + Candoi.d415 + Candoi.d416 + Candoi.d417 + Candoi.d418 + Candoi.d419 + Candoi.d420 + Candoi.d421 + Candoi.d422;
                Candoi.c410 = Candoi.c411 + Candoi.c412 + Candoi.c413 + Candoi.c414 + Candoi.c415 + Candoi.c416 + Candoi.c417 + Candoi.c418 + Candoi.c419 + Candoi.c420 + Candoi.c421 + Candoi.c422;
                #endregion
                #region 430
                //431
                gt = (from a in tong where a.tkgoc == "461" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d431 = 0;
                    Candoi.c431 = 0;
                }
                else
                {
                    Candoi.d431 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c431 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                gt = (from a in tong where a.tkgoc == "161" select a);
                if (gt.Count() != 0)
                {
                    Candoi.d431 = Candoi.d431 - double.Parse(gt.Sum(t => t.psno_dau).ToString());
                    Candoi.c431 = Candoi.c431 - double.Parse(gt.Sum(t => t.psno_cuoi).ToString());
                }
                // 432
                gt = (from a in tong where a.tkgoc == "466" select a);
                if (gt.Count() == 0)
                {
                    Candoi.d432 = 0;
                    Candoi.c432 = 0;
                }
                else
                {
                    Candoi.d432 = double.Parse(gt.Sum(t => t.psco_dau).ToString());
                    Candoi.c432 = double.Parse(gt.Sum(t => t.psco_cuoi).ToString());
                }
                // 430
                Candoi.d430 = Candoi.d431 + Candoi.d432;
                Candoi.c430 = Candoi.c431 + Candoi.c432;
                #endregion
                // 400
                Candoi.d400 = Candoi.d410 + Candoi.d430;
                Candoi.c400 = Candoi.c410 + Candoi.c430;
                #endregion
                //440
                Candoi.d440 = Candoi.d300 + Candoi.d400;
                Candoi.c440 = Candoi.c300 + Candoi.c400;
                r_candoiketoan200 xtra = new r_candoiketoan200();
                ReportPrintTool rpt = new ReportPrintTool(xtra);
                rpt.PreviewForm.MdiParent = Application.OpenForms[0];
                rpt.PreviewForm.Text = "Báo Cáo Bảng Cân Đối Kế Toán";
                rpt.ShowPreview();
                //ReportPrintTool printTool = new ReportPrintTool(xtra);
                //printTool.PreviewRibbonForm.MdiParent = this; /*(System.Windows.Forms.Form)Application.MainWindow.Template;*/
                //printTool.ShowRibbonPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
