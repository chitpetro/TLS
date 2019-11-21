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
    public partial class f_tonfifo_duphong : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick1 = false;
        Boolean doubleclick2 = false;
        public f_tonfifo_duphong()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
        }
        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "BÁO CÁO TỒN KHO (TÍNH GIÁ NHẬP TRƯỚC XUẤT TRƯỚC)").ToString();
            changeFont.Translate(this);
            //translate text
            labelControl1.Text = LanguageHelper.TranslateMsgString(".reportKhoangThoiGian", "Khoảng Thời Gian").ToString();
            labelControl2.Text = LanguageHelper.TranslateMsgString(".reportTuNgay", "Từ Ngày").ToString();
            labelControl3.Text = LanguageHelper.TranslateMsgString(".reportDenNgay", "Đến Ngày").ToString();
            labelControl6.Text = LanguageHelper.TranslateMsgString(".reportDanhMuc", "Danh Mục").ToString();
            tungay.ReadOnly = true;
            denngay.ReadOnly = true;
            danhmuc.Text = "Kho - ສາງ";
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
            if (danhmuc.Text == "Hàng Hóa - ສິນຄ້າ")
            {
                try
                {
                    var lst = (from a in db.r_giasps where a.iddv == Biencucbo.donvi select new { id = a.idsp, name = a.tensp, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
            else if (danhmuc.Text == "Kho - ສາງ")
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
            else if (danhmuc.Text == "Đối Tượng")
            {
                try
                {
                    var lst = (from a in db.doituongs select new { id = a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
            else if (danhmuc.Text == "Công Việc")
            {
                try
                {
                    var lst = (from a in db.congviecs select new { id = a.id, name = a.tencongviec, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
                if (danhmuc.Text == "Kho - ສາງ")
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
                    if (danhmuc.Text == "Kho - ສາງ")
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
                    var lst = (from a in db.dk_rps where a.user==Biencucbo.idnv select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                    db.dk_rps.DeleteOnSubmit(lst);
                    db.SubmitChanges();
                    var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                    nhan.DataSource = lst2;
                }
                catch
                {
                }
                if (danhmuc.Text == "Hàng Hóa - ສິນຄ້າ")
                {
                    try
                    {
                        var lst = (from a in db.r_giasps where a.iddv == Biencucbo.donvi select new { id = a.idsp, name = a.tensp, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
                else if (danhmuc.Text == "Kho - ສາງ")
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
                else if (danhmuc.Text == "Đối Tượng")
                {
                    try
                    {
                        var lst = (from a in db.doituongs select new { id = a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
                else if (danhmuc.Text == "Công Việc")
                {
                    try
                    {
                        var lst = (from a in db.congviecs select new { id = a.id, name = a.tencongviec, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
                var lst = (from a in db.dk_rps where a.user==Biencucbo.idnv select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                db.dk_rps.DeleteOnSubmit(lst);
                db.SubmitChanges();
                var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                nhan.DataSource = lst2;
            }
            catch
            {
            }
            if (danhmuc.Text == "Hàng Hóa - ສິນຄ້າ")
            {
                try
                {
                    var lst = (from a in db.r_giasps where a.iddv == Biencucbo.donvi select new { id = a.idsp, name = a.tensp, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
            else if (danhmuc.Text == "Kho - ສາງ")
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
            else if (danhmuc.Text == "Đối Tượng")
            {
                try
                {
                    var lst = (from a in db.doituongs select new { id = a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
            else if (danhmuc.Text == "Công Việc")
            {
                try
                {
                    var lst = (from a in db.congviecs select new { id = a.id, name = a.tencongviec, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv select a;
                    nhan.DataSource = lst;
                }
                if (danhmuc.Text == "Kho - ສາງ")
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
            if (danhmuc.Text == "Hàng Hóa - ສິນຄ້າ")
            {
                try
                {
                    var lst = (from a in db.r_giasps where a.iddv == Biencucbo.donvi select new { id = a.idsp, name = a.tensp, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
            else if (danhmuc.Text == "Kho - ສາງ")
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
            else if (danhmuc.Text == "Đối Tượng")
            {
                try
                {
                    var lst = (from a in db.doituongs select new { id = a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
            else if (danhmuc.Text == "Công Việc")
            {
                try
                {
                    var lst = (from a in db.congviecs select new { id = a.id, name = a.tencongviec, key = a.id + danhmuc.Text + Biencucbo.idnv });
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
                db = new KetNoiDBDataContext();
                Biencucbo.sp = "";
                Biencucbo.doituong = "";
                Biencucbo.congviec = "";
                Biencucbo.kho = "";
                int check = 0;
                int check1 = 0;
                int check2 = 0;
                int check3 = 0;
                for (int m = 0; m < gridView2.DataRowCount; m++)
                {
                    if (gridView2.GetRowCellValue(m, "loai").ToString() == "Hàng Hóa - ສິນຄ້າ")
                    {
                        check1++;
                        Biencucbo.sp = "  " + Biencucbo.sp + gridView2.GetRowCellValue(m, "id").ToString() + "-" + gridView2.GetRowCellValue(m, "name").ToString() + ", ";
                        for (int i = 0; i < gridView2.DataRowCount; i++)
                        {
                            if (gridView2.GetRowCellValue(i, "loai").ToString() == "Kho - ສາງ")
                            {
                                check++;
                                Biencucbo.kho = Biencucbo.kho + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
                                // tính nhập trước xuất trước:
                                //xóa bản ghi cũ
                                var lst = from a in db.Fifostocks where a.iddv == gridView2.GetRowCellValue(i, "id").ToString() && a.idnv == Biencucbo.idnv && a.prdt == gridView2.GetRowCellValue(m, "id").ToString() select a;
                                if (lst != null)
                                {
                                    db.Fifostocks.DeleteAllOnSubmit(lst);
                                    db.SubmitChanges();
                                }
                                var lst1 = from a in db.Fifostock2s where a.iddv == gridView2.GetRowCellValue(i, "id").ToString() && a.idnv == Biencucbo.idnv && a.prdt == gridView2.GetRowCellValue(m, "id").ToString() select a;
                                if (lst1 != null)
                                {
                                    db.Fifostock2s.DeleteAllOnSubmit(lst1);
                                    db.SubmitChanges();
                                }
                                var nhap1 = from a in db.nhaptrongkies where a.iddv == gridView2.GetRowCellValue(i, "id").ToString() && a.idnv == Biencucbo.idnv && a.idsanpham == gridView2.GetRowCellValue(m, "id").ToString() select a;
                                if (nhap1 != null)
                                {
                                    db.nhaptrongkies.DeleteAllOnSubmit(nhap1);
                                    db.SubmitChanges();
                                }
                                var xuat1 = from a in db.xuattrongkies where a.iddv == gridView2.GetRowCellValue(i, "id").ToString() && a.idnv == Biencucbo.idnv && a.idsanpham == gridView2.GetRowCellValue(m, "id").ToString() select a;
                                if (xuat1 != null)
                                {
                                    db.xuattrongkies.DeleteAllOnSubmit(xuat1);
                                    db.SubmitChanges();
                                }
                                //fifostock:
                                var lst3 = (from a in db.hoadons
                                            join b in db.hoadoncts on a.id equals b.idhoadon into g
                                            from sub in g.DefaultIfEmpty()
                                            where a.ngayhd < tungay.DateTime && a.iddv == gridView2.GetRowCellValue(i, "id").ToString() && sub.idsanpham == gridView2.GetRowCellValue(m, "id").ToString()
                                            select new
                                            {
                                                id = sub.idsanpham,
                                                sl = sub.soluong == null ? 0 : sub.soluong
                                            }).GroupBy(t => t.id).Select(c => new { ids = c.Key, sluong = c.Sum(t => t.sl) });
                                var lst4 = from a in db.pnhaps
                                           join b in db.pnhapcts on a.id equals b.idpnhap
                                           join d in db.thues on b.loaithue equals d.id into h
                                           join c in lst3 on b.idsanpham equals c.ids into g
                                           from sub in g.DefaultIfEmpty()
                                           from sub2 in h.DefaultIfEmpty()
                                           where a.ngaynhap < tungay.DateTime && a.iddv == gridView2.GetRowCellValue(i, "id").ToString() && b.idsanpham == gridView2.GetRowCellValue(m, "id").ToString()
                                           orderby a.ngaynhap
                                           orderby b.idsanpham
                                           select new
                                           {
                                               prd = b.idsanpham,
                                               xDate = a.ngaynhap,
                                               pr = b.soluong,
                                               pp = b.thanhtien == 0 ? 0 : b.thanhtien / b.soluong,
                                               Sold = sub.sluong == null ? 0 : sub.sluong,
                                               iddv = gridView2.GetRowCellValue(i, "id").ToString(),
                                               id = b.idsanpham + a.ngaynhap + a.iddv + Biencucbo.idnv
                                           };
                                if (lst4.Count() == 0)
                                {
                                    Fifostock lst5 = new Fifostock();
                                    lst5.fdate = DateTime.Now;
                                    lst5.prdt = gridView2.GetRowCellValue(m, "id").ToString();
                                    lst5.PQty = 0;
                                    lst5.RQty = 0;
                                    lst5.AvQty = 0;
                                    lst5.Rt = 0;
                                    lst5.iddv = gridView2.GetRowCellValue(i, "id").ToString();
                                    lst5.id = gridView2.GetRowCellValue(m, "id").ToString() + DateTime.Now.ToShortDateString() + gridView2.GetRowCellValue(i, "id").ToString() + Biencucbo.idnv;
                                    lst5.idnv = Biencucbo.idnv;
                                    db.Fifostocks.InsertOnSubmit(lst5);
                                    db.SubmitChanges();
                                }
                                else
                                {
                                    gridControl1.DataSource = lst4;
                                    string Prid = "";
                                    float iTot = 0;
                                    for (int j = 0; j < gridView3.RowCount; j++)
                                    {
                                        if (gridView3.GetRowCellValue(j, "prd").ToString() == Prid)
                                        {
                                            iTot = iTot + float.Parse(gridView3.GetRowCellValue(j, "pr").ToString());
                                        }
                                        else
                                        {
                                            Prid = gridView3.GetRowCellValue(j, "prd").ToString();
                                            iTot = float.Parse(gridView3.GetRowCellValue(j, "pr").ToString());
                                        }
                                        if (iTot > float.Parse(gridView3.GetRowCellValue(j, "Sold").ToString()))
                                        {
                                            Fifostock fifo = new Fifostock();
                                            fifo.fdate = DateTime.Parse(gridView3.GetRowCellValue(j, "xDate").ToString());
                                            fifo.prdt = gridView3.GetRowCellValue(j, "prd").ToString();
                                            fifo.PQty = float.Parse(gridView3.GetRowCellValue(j, "pr").ToString());
                                            fifo.RQty = iTot;
                                            fifo.Rt = float.Parse(gridView3.GetRowCellValue(j, "pp").ToString());
                                            fifo.iddv = gridView3.GetRowCellValue(j, "iddv").ToString();
                                            fifo.id = gridView3.GetRowCellValue(j, "prd").ToString() + DateTime.Parse(gridView3.GetRowCellValue(j, "xDate").ToString()).ToShortDateString() + gridView3.GetRowCellValue(j, "iddv").ToString() + j + Biencucbo.idnv;
                                            fifo.idnv = Biencucbo.idnv;
                                            if (iTot - float.Parse(gridView3.GetRowCellValue(j, "Sold").ToString()) > float.Parse(gridView3.GetRowCellValue(j, "pr").ToString()))
                                            {
                                                fifo.AvQty = float.Parse(gridView3.GetRowCellValue(j, "pr").ToString());
                                            }
                                            else
                                            {
                                                fifo.AvQty = iTot - float.Parse(gridView3.GetRowCellValue(j, "Sold").ToString());
                                            }
                                            db.Fifostocks.InsertOnSubmit(fifo);
                                            db.SubmitChanges();
                                        }
                                    }
                                    if (iTot <= lst4.First().Sold)
                                    {
                                        Fifostock fifo = new Fifostock();
                                        fifo.fdate = DateTime.Parse(gridView3.GetRowCellValue(gridView3.RowCount - 1, "xDate").ToString());
                                        fifo.prdt = gridView2.GetRowCellValue(m, "id").ToString();
                                        fifo.PQty = float.Parse(gridView3.GetRowCellValue(gridView3.RowCount - 1, "pr").ToString());
                                        fifo.RQty = iTot;
                                        fifo.Rt = float.Parse(gridView3.GetRowCellValue(gridView3.RowCount - 1, "pp").ToString());
                                        fifo.iddv = gridView2.GetRowCellValue(i, "id").ToString();
                                        fifo.idnv = Biencucbo.idnv;
                                        fifo.id = gridView2.GetRowCellValue(m, "id").ToString() + DateTime.Now.ToShortDateString() + gridView2.GetRowCellValue(i, "id").ToString() + Biencucbo.idnv;
                                        fifo.AvQty = iTot - lst4.First().Sold;
                                        db.Fifostocks.InsertOnSubmit(fifo);
                                        db.SubmitChanges();
                                    }
                                }
                                lst3 = (from a in db.hoadons
                                        join b in db.hoadoncts on a.id equals b.idhoadon into g
                                        from sub in g.DefaultIfEmpty()
                                        where a.ngayhd <= denngay.DateTime && a.iddv == gridView2.GetRowCellValue(i, "id").ToString() && sub.idsanpham == gridView2.GetRowCellValue(m, "id").ToString()
                                        select new
                                        {
                                            id = sub.idsanpham,
                                            sl = sub.soluong == null ? 0 : sub.soluong
                                        }).GroupBy(t => t.id).Select(c => new { ids = c.Key, sluong = c.Sum(t => t.sl) });
                                lst4 = from a in db.pnhaps
                                       join b in db.pnhapcts on a.id equals b.idpnhap
                                       join d in db.thues on b.loaithue equals d.id into h
                                       join c in lst3 on b.idsanpham equals c.ids into g
                                       from sub in g.DefaultIfEmpty()
                                       from sub2 in h.DefaultIfEmpty()
                                       where a.ngaynhap <= denngay.DateTime && a.iddv == gridView2.GetRowCellValue(i, "id").ToString() && b.idsanpham == gridView2.GetRowCellValue(m, "id").ToString()
                                       orderby a.ngaynhap
                                       orderby b.idsanpham
                                       select new
                                       {
                                           prd = b.idsanpham,
                                           xDate = a.ngaynhap,
                                           pr = b.soluong,
                                           pp = b.thanhtien == 0 ? 0 : b.thanhtien / b.soluong,
                                           Sold = sub.sluong == null ? 0 : sub.sluong,
                                           iddv = a.iddv,
                                           id = b.idsanpham + a.ngaynhap + a.iddv
                                       };
                                gridControl1.DataSource = lst4;
                                if (lst4.Count() == 0)
                                {
                                    //for (int n = 0; n < gridView2.DataRowCount; n++)
                                    //{
                                    //    if (gridView2.GetRowCellValue(n, "loai").ToString() == "Hàng Hóa - ສິນຄ້າ")
                                    //    {
                                    Fifostock2 lst5 = new Fifostock2();
                                    lst5.fdate = DateTime.Now;
                                    lst5.prdt = gridView2.GetRowCellValue(m, "id").ToString();
                                    lst5.PQty = 0;
                                    lst5.RQty = 0;
                                    lst5.AvQty = 0;
                                    lst5.Rt = 0;
                                    lst5.idnv = Biencucbo.idnv;
                                    lst5.iddv = gridView2.GetRowCellValue(i, "id").ToString();
                                    lst5.id = gridView2.GetRowCellValue(m, "id").ToString() + DateTime.Now.ToShortDateString() + gridView2.GetRowCellValue(i, "id").ToString() + Biencucbo.idnv;
                                    db.Fifostock2s.InsertOnSubmit(lst5);
                                    db.SubmitChanges();
                                }
                                //    }
                                //}
                                else
                                {
                                    string Prid = "";
                                    float iTot = 0;
                                    for (int j = 0; j < gridView3.RowCount; j++)
                                    {
                                        if (gridView3.GetRowCellValue(j, "prd").ToString() == Prid)
                                        {
                                            iTot = iTot + float.Parse(gridView3.GetRowCellValue(j, "pr").ToString());
                                        }
                                        else
                                        {
                                            Prid = gridView3.GetRowCellValue(j, "prd").ToString();
                                            iTot = float.Parse(gridView3.GetRowCellValue(j, "pr").ToString());
                                        }
                                        if (iTot > float.Parse(gridView3.GetRowCellValue(j, "Sold").ToString()))
                                        {
                                            Fifostock2 fifo2 = new Fifostock2();
                                            fifo2.fdate = DateTime.Parse(gridView3.GetRowCellValue(j, "xDate").ToString());
                                            fifo2.prdt = gridView3.GetRowCellValue(j, "prd").ToString();
                                            fifo2.PQty = float.Parse(gridView3.GetRowCellValue(j, "pr").ToString());
                                            fifo2.RQty = iTot;
                                            fifo2.Rt = float.Parse(gridView3.GetRowCellValue(j, "pp").ToString());
                                            fifo2.iddv = gridView3.GetRowCellValue(j, "iddv").ToString();
                                            fifo2.idnv = Biencucbo.idnv;
                                            fifo2.id = gridView3.GetRowCellValue(j, "prd").ToString() + DateTime.Parse(gridView3.GetRowCellValue(j, "xDate").ToString()).ToShortDateString() + gridView3.GetRowCellValue(j, "iddv").ToString() + j + Biencucbo.idnv;
                                            if (iTot - float.Parse(gridView3.GetRowCellValue(j, "Sold").ToString()) > float.Parse(gridView3.GetRowCellValue(j, "pr").ToString()))
                                            {
                                                fifo2.AvQty = float.Parse(gridView3.GetRowCellValue(j, "pr").ToString());
                                            }
                                            else
                                            {
                                                fifo2.AvQty = iTot - float.Parse(gridView3.GetRowCellValue(j, "Sold").ToString());
                                            }
                                            db.Fifostock2s.InsertOnSubmit(fifo2);
                                            db.SubmitChanges();
                                        }
                                    }
                                    if (iTot <= lst4.First().Sold)
                                    {
                                        Fifostock2 fifo = new Fifostock2();
                                        fifo.fdate = DateTime.Parse(gridView3.GetRowCellValue(gridView3.RowCount - 1, "xDate").ToString());
                                        fifo.prdt = gridView2.GetRowCellValue(m, "id").ToString();
                                        fifo.PQty = float.Parse(gridView3.GetRowCellValue(gridView3.RowCount - 1, "pr").ToString());
                                        fifo.RQty = iTot;
                                        fifo.Rt = float.Parse(gridView3.GetRowCellValue(gridView3.RowCount - 1, "pp").ToString());
                                        fifo.iddv = gridView2.GetRowCellValue(i, "id").ToString();
                                        fifo.idnv = Biencucbo.idnv;
                                        fifo.id = gridView2.GetRowCellValue(m, "id").ToString() + DateTime.Now.ToShortDateString() + gridView2.GetRowCellValue(i, "id").ToString() + Biencucbo.idnv;
                                        fifo.AvQty = iTot - lst4.First().Sold;
                                        db.Fifostock2s.InsertOnSubmit(fifo);
                                        db.SubmitChanges();
                                    }
                                }
                                // nhap trong ky
                                var nhap = (from a in db.pnhaps
                                            join b in db.pnhapcts on a.id equals b.idpnhap into g
                                            from sub in g.DefaultIfEmpty()
                                            join c in db.sanphams on sub.idsanpham equals c.id
                                            where a.ngaynhap >= tungay.DateTime && a.ngaynhap <= denngay.DateTime && a.iddv == gridView2.GetRowCellValue(i, "id").ToString() && sub.idsanpham == gridView2.GetRowCellValue(m, "id").ToString()
                                            select new
                                            {
                                                idsanpham = c.id,
                                                sln = sub.soluong,
                                                gtn = sub.thanhtien,
                                            }).GroupBy(t => t.idsanpham).Select(c => new { idsp = c.Key, sl = c.Sum(t => t.sln), gt = c.Sum(t => t.gtn) });
                                if (nhap.Count() == 0)
                                {
                                    nhaptrongky n = new nhaptrongky();
                                    n.idsanpham = gridView2.GetRowCellValue(m, "id").ToString();
                                    n.sln = 0;
                                    n.gtn = 0;
                                    n.iddv = gridView2.GetRowCellValue(i, "id").ToString();
                                    n.idnv = Biencucbo.idnv;
                                    n.id = gridView2.GetRowCellValue(m, "id").ToString() + DateTime.Now.ToShortDateString() + gridView2.GetRowCellValue(i, "id").ToString() + Biencucbo.idnv;
                                    db.nhaptrongkies.InsertOnSubmit(n);
                                    db.SubmitChanges();
                                }
                                else
                                {
                                    gridControl2.DataSource = nhap;
                                    for (int j = 0; j < gridView4.RowCount; j++)
                                    {
                                        nhaptrongky n = new nhaptrongky();
                                        n.idsanpham = gridView4.GetRowCellValue(j, "idsp").ToString();
                                        n.sln = float.Parse(gridView4.GetRowCellValue(j, "sl").ToString());
                                        n.gtn = float.Parse(gridView4.GetRowCellValue(j, "gt").ToString());
                                        n.iddv = gridView2.GetRowCellValue(i, "id").ToString();
                                        n.idnv = Biencucbo.idnv;
                                        n.id = gridView4.GetRowCellValue(j, "idsp").ToString() + gridView2.GetRowCellValue(i, "id").ToString() + j + Biencucbo.idnv;
                                        db.nhaptrongkies.InsertOnSubmit(n);
                                        db.SubmitChanges();
                                    };
                                }
                                // xuất trong kỳ
                                var xuat = (from a in db.hoadons
                                            join b in db.hoadoncts on a.id equals b.idhoadon into g
                                            from sub in g.DefaultIfEmpty()
                                            join c in db.sanphams on sub.idsanpham equals c.id
                                            where a.ngayhd >= tungay.DateTime && a.ngayhd <= denngay.DateTime && a.iddv == gridView2.GetRowCellValue(i, "id").ToString() && sub.idsanpham == gridView2.GetRowCellValue(m, "id").ToString()
                                            select new
                                            {
                                                idsanpham = c.id,
                                                slx = sub.soluong,
                                                gtx = sub.thanhtien
                                            }).GroupBy(t => t.idsanpham).Select(c => new { idsp = c.Key, sl = c.Sum(t => t.slx), gt = c.Sum(t => t.gtx) });
                                if (xuat.Count() == 0)
                                {
                                    //for (int z = 0; z < gridView2.DataRowCount; z++)
                                    //{
                                    //    if (gridView2.GetRowCellValue(z, "loai").ToString() == "Hàng Hóa - ສິນຄ້າ")
                                    //    {
                                    xuattrongky x = new xuattrongky();
                                    x.idsanpham = gridView2.GetRowCellValue(m, "id").ToString();
                                    x.slx = 0;
                                    x.gtx = 0;
                                    x.idnv = Biencucbo.idnv;
                                    x.iddv = gridView2.GetRowCellValue(i, "id").ToString();
                                    x.id = gridView2.GetRowCellValue(m, "id").ToString() + DateTime.Now.ToShortDateString() + gridView2.GetRowCellValue(i, "id").ToString() + Biencucbo.idnv;
                                    db.xuattrongkies.InsertOnSubmit(x);
                                    db.SubmitChanges();
                                    //    }
                                    //}
                                }
                                else
                                {
                                    gridControl2.DataSource = xuat;
                                    for (int j = 0; j < gridView4.RowCount; j++)
                                    {
                                        xuattrongky x = new xuattrongky();
                                        x.idsanpham = gridView4.GetRowCellValue(j, "idsp").ToString();
                                        x.slx = float.Parse(gridView4.GetRowCellValue(j, "sl").ToString());
                                        x.gtx = float.Parse(gridView4.GetRowCellValue(j, "gt").ToString());
                                        x.iddv = gridView2.GetRowCellValue(i, "id").ToString();
                                        x.idnv = Biencucbo.idnv;
                                        x.id = gridView4.GetRowCellValue(j, "idsp").ToString() + gridView2.GetRowCellValue(i, "id").ToString() + j + Biencucbo.idnv;
                                        db.xuattrongkies.InsertOnSubmit(x);
                                        db.SubmitChanges();
                                    };
                                }
                            }
                        }
                    }
                }
                if (check1 == 0)
                {
                    Lotus.MsgBox.ShowWarningDialog("Cần phải chọn 1 trường dữ liệu bắt buộc: Sản Phẩm");
                    return;
                }
                if (check == 0)
                {
                    Lotus.MsgBox.ShowWarningDialog("Cần phải chọn 1 trường dữ liệu bắt buộc: Kho");
                    return;
                }
                else
                {
                    if (Biencucbo.ngonngu.ToString() == "Vietnam")
                    {
                        if (check2 == 0)
                        {
                            Biencucbo.doituong = "Tất cả";
                        }
                        if (check3 == 0)
                        {
                            Biencucbo.congviec = "Tất cả";
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
                        if (check2 == 0)
                        {
                            Biencucbo.doituong = "ທັງໝົດ";
                        }
                        if (check3 == 0)
                        {
                            Biencucbo.congviec = "ທັງໝົດ";
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
                    var lst2 = from a in db.tonfifos
                               join b in db.dk_rps on a.iddv equals b.id
                               where a.idnv == Biencucbo.idnv
                               && b.user == Biencucbo.idnv
                               select a;
                    var lst3 = from a in db.tonfifos
                               join b in db.dk_rps on a.iddv equals b.id
                               where a.idnv == Biencucbo.idnv
                               && b.user == Biencucbo.idnv
                               select a;
                    if (check1 != 0)
                    {
                        lst3 = from a in lst2
                               join b in db.dk_rps on a.id equals b.id
                               where b.user == Biencucbo.idnv
                               select a;
                    }
                    else
                    {
                        lst3 = from a in lst2 select a;
                    }
                    r_tonfifo xtra = new r_tonfifo();
                    xtra.DataSource = lst3;
                    xtra.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SplashScreenManager.CloseForm(false);
        }
    }
}
