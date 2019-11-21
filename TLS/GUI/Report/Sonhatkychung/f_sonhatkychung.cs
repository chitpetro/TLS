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
    public partial class f_sonhatkychung : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick1 = false;
        Boolean doubleclick2 = false;
        public f_sonhatkychung()
        {
            InitializeComponent();
            rTime.SetTime(thoigian);
        }
        private void f_chitietnhapkho_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Sổ Nhật Ký Chung").ToString();
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
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a;
                nhan.DataSource = lst;
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung",
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
            if (danhmuc.Text == "Loại thu - ປະເພດ")
            {
                try
                {
                    var lst = (from a in db.dmloaithus select new { id = a.danhmuc, name = a.danhmuc_l == null ? "---" : a.danhmuc_l, key = a.danhmuc + Biencucbo.idnv + "f_sonhatkychung" });
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
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            else if (danhmuc.Text == "Mục Chi Phí - ບັນຊີລາຍຈ່າຍ")
            {
                try
                {
                    var lst = (from a in db.muccps select new { id = a.id, name = a.muccp1, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
            {
                try
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung",
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
            else if (danhmuc.Text == "Đối Tượng - ເປົ້້າໝາຍ")
            {
                try
                {
                    var lst = (from a in db.doituongs select new { id = a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Công Việc - ໜ້າວຽກ")
            {
                try
                {
                    var lst = (from a in db.congviecs select new { id = a.id, name = a.tencongviec, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Tài Khoản")
            {
                try
                {
                    var lst = (from a in db.dmtks where a.active == true select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
                    nguon.DataSource = lst;
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView2.GetRowCellValue(j, "loai").ToString() != "Tài Khoản" && gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
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
            else if (danhmuc.Text == "Tài Khoản Đối Ứng")
            {
                try
                {
                    var lst = (from a in db.dmtks where a.active == true select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
                    nguon.DataSource = lst;
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView2.GetRowCellValue(j, "loai").ToString() != "Tài Khoản Đối Ứng" && gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
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
                dk.form = "f_sonhatkychung";
                dk.loai = danhmuc.Text;
                dk.user = Biencucbo.idnv;
                db.dk_rps.InsertOnSubmit(dk);
                db.SubmitChanges();
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a;
                nhan.DataSource = lst;
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung",
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
                    dk.form = "f_sonhatkychung";
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a;
                    nhan.DataSource = lst;
                    if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                    {
                        var list = (from a in db.donvis
                                    select new
                                    {
                                        id = a.id,
                                        name = a.tendonvi,
                                        key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung",
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
                    var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                    db.dk_rps.DeleteOnSubmit(lst);
                    db.SubmitChanges();
                    var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a;
                    nhan.DataSource = lst2;
                }
                catch
                {
                }
                if (danhmuc.Text == "Loại thu - ປະເພດ")
                {
                    try
                    {
                        var lst = (from a in db.dmloaithus select new { id = a.danhmuc, name = a.danhmuc_l == null ? "---" : a.danhmuc_l, key = a.danhmuc + Biencucbo.idnv + "f_sonhatkychung" });
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
                else if (danhmuc.Text == "Mục Chi Phí - ບັນຊີລາຍຈ່າຍ")
                {
                    try
                    {
                        var lst = (from a in db.muccps select new { id = a.id, name = a.muccp1, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
                else if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    try
                    {
                        var list = (from a in db.donvis
                                    select new
                                    {
                                        id = a.id,
                                        name = a.tendonvi,
                                        key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung",
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
                else if (danhmuc.Text == "Đối Tượng - ເປົ້້າໝາຍ")
                {
                    try
                    {
                        var lst = (from a in db.doituongs select new { id = a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
                else if (danhmuc.Text == "Công Việc - ໜ້າວຽກ")
                {
                    try
                    {
                        var lst = (from a in db.congviecs select new { id = a.id, name = a.tencongviec, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
                else if (danhmuc.Text == "Tài Khoản")
                {
                    try
                    {
                        var lst = (from a in db.dmtks where a.active == true select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
                        nguon.DataSource = lst;
                        for (int i = gridView1.RowCount - 1; i >= 0; i--)
                        {
                            for (int j = 0; j < gridView2.DataRowCount; j++)
                            {
                                if (gridView2.GetRowCellValue(j, "loai").ToString() != "Tài KKhoản" && gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
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
                else if (danhmuc.Text == "Tài Khoản Đối Ứng")
                {
                    try
                    {
                        var lst = (from a in db.dmtks where a.active == true select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
                        nguon.DataSource = lst;
                        for (int i = gridView1.RowCount - 1; i >= 0; i--)
                        {
                            for (int j = 0; j < gridView2.DataRowCount; j++)
                            {
                                if (gridView2.GetRowCellValue(j, "loai").ToString() != "Tài Khoản Đối Ứng" && gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
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
                var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a).Single(t => t.key == gridView2.GetFocusedRowCellValue("key").ToString());
                db.dk_rps.DeleteOnSubmit(lst);
                db.SubmitChanges();
                var lst2 = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a;
                nhan.DataSource = lst2;
            }
            catch
            {
            }
            if (danhmuc.Text == "Loại thu - ປະເພດ")
            {
                try
                {
                    var lst = (from a in db.dmloaithus select new { id = a.danhmuc, name = a.danhmuc_l == null ? "---" : a.danhmuc_l, key = a.danhmuc + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Mục Chi Phí - ບັນຊີລາຍຈ່າຍ")
            {
                try
                {
                    var lst = (from a in db.muccps select new { id = a.id, name = a.muccp1, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
            {
                try
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung",
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
            else if (danhmuc.Text == "Đối Tượng - ເປົ້້າໝາຍ")
            {
                try
                {
                    var lst = (from a in db.doituongs select new { id = a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Công Việc - ໜ້າວຽກ")
            {
                try
                {
                    var lst = (from a in db.congviecs select new { id = a.id, name = a.tencongviec, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Tài Khoản")
            {
                try
                {
                    var lst = (from a in db.dmtks where a.active == true select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
                    nguon.DataSource = lst;
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView2.GetRowCellValue(j, "loai").ToString() != "Tài Khoản" && gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
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
            else if (danhmuc.Text == "Tài Khoản Đối Ứng")
            {
                try
                {
                    var lst = (from a in db.dmtks where a.active == true select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
                    nguon.DataSource = lst;
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView2.GetRowCellValue(j, "loai").ToString() != "Tài Khoản Đối Ứng" && gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
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
                    dk.form = "f_sonhatkychung";
                    dk.loai = danhmuc.Text;
                    dk.user = Biencucbo.idnv;
                    db.dk_rps.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a;
                    nhan.DataSource = lst;
                }
                if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung",
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
                var lst = from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a;
                db.dk_rps.DeleteAllOnSubmit(lst);
                db.SubmitChanges();
                nhan.DataSource = lst;
            }
            catch
            {
            }
            if (danhmuc.Text == "Loại thu - ປະເພດ")
            {
                try
                {
                    var lst = (from a in db.dmloaithus select new { id = a.danhmuc, name = a.danhmuc_l == null ? "---" : a.danhmuc_l, key = a.danhmuc + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Mục Chi Phí - ບັນຊີລາຍຈ່າຍ")
            {
                try
                {
                    var lst = (from a in db.muccps select new { id = a.id, name = a.muccp1, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Đơn vị - ຫົວໜ່ວຍ")
            {
                try
                {
                    var list = (from a in db.donvis
                                select new
                                {
                                    id = a.id,
                                    name = a.tendonvi,
                                    key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung",
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
            else if (danhmuc.Text == "Đối Tượng - ເປົ້້າໝາຍ")
            {
                try
                {
                    var lst = (from a in db.doituongs select new { id = a.id, name = a.ten, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Công Việc - ໜ້າວຽກ")
            {
                try
                {
                    var lst = (from a in db.congviecs select new { id = a.id, name = a.tencongviec, key = a.id + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
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
            else if (danhmuc.Text == "Tài Khoản")
            {
                try
                {
                    var lst = (from a in db.dmtks where a.active == true select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
                    nguon.DataSource = lst;
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView2.GetRowCellValue(j, "loai").ToString() != "Tài Khoản" && gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
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
            else if (danhmuc.Text == "Tài Khoản Đối Ứng")
            {
                try
                {
                    var lst = (from a in db.dmtks where a.active == true select new { id = a.matk, name = a.tentk, key = a.matk + danhmuc.Text + Biencucbo.idnv + "f_sonhatkychung" });
                    nguon.DataSource = lst;
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < gridView2.DataRowCount; j++)
                        {
                            if (gridView2.GetRowCellValue(j, "loai").ToString() != "Tài Khoản Đối Ứng" && gridView1.GetRowCellValue(i, "key").ToString() == gridView2.GetRowCellValue(j, "key").ToString())
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
                Biencucbo.taikhoan = "";
                Biencucbo.muccp = "";
                Biencucbo.kho = "";
                int check = 0;
                int check1 = 0;
                int check2 = 0;
                int check3 = 0;
                int check4 = 0;
                int check5 = 0;
                int check6 = 0;
                for (int i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "loai").ToString() == "Đơn vị - ຫົວໜ່ວຍ")
                    {
                        check++;
                        Biencucbo.kho = Biencucbo.kho + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Loại thu - ປະເພດ")
                    {
                        check1++;
                        Biencucbo.loai = "  " + Biencucbo.loai + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Mục Chi Phí - ບັນຊີລາຍຈ່າຍ")
                    {
                        check4++;
                        Biencucbo.muccp = "  " + Biencucbo.muccp + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Đối Tượng - ເປົ້້າໝາຍ")
                    {
                        check2++;
                        Biencucbo.doituong = "  " + Biencucbo.doituong + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Công Việc - ໜ້າວຽກ")
                    {
                        check3++;
                        Biencucbo.congviec = "  " + Biencucbo.congviec + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Tài Khoản")
                    {
                        check5++;
                        Biencucbo.taikhoan = "  " + Biencucbo.taikhoan + gridView2.GetRowCellValue(i, "id").ToString() + "-" + gridView2.GetRowCellValue(i, "name").ToString() + ", ";
                    }
                    else if (gridView2.GetRowCellValue(i, "loai").ToString() == "Tài Khoản Đối Ứng")
                    {
                        check6++;
                    }
                }
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
                    if (check5 == 0)
                    {
                        Biencucbo.taikhoan = "Tất cả";
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
                var lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a);
                var lst1 = (from a in db.ct_tks
                            select a);
                if (check != 0)
                {
                    lst = (from a in db.dk_rps where a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" && a.loai == "Đơn vị - ຫົວໜ່ວຍ" select a);
                    lst1 = (from a in db.ct_tks
                            join b in lst on a.iddv equals b.id
                            where b.user == Biencucbo.idnv && b.loai == "Đơn vị - ຫົວໜ່ວຍ"
                            select a);
                }
                var tk = from b in db.dmtks where b.active == true select b;
                if (check5 != 0)
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
                    tk = tk1;
                }
                var lst2 = (from a in lst1
                            join b in tk on a.tk_no equals b.matk
                            where a.ngaychungtu >= tungay.DateTime && a.ngaychungtu <= denngay.DateTime /*&& a.tk_no != "911"*/
                            select new
                            {
                                a.ngaychungtu,
                                id = a.machungtu,
                                a.ghichu,
                                a.diengiai,
                                taikhoan = a.tk_no,
                                tkdoiung = a.tk_co,
                                a.idcv,
                                a.idmuccp,
                                a.iddv,
                                iddt = a.dt_no,
                                psno = a.PS,
                                psco = a.PS - a.PS,
                            }).Concat(from a in lst1
                                      join b in tk on a.tk_co equals b.matk
                                      where a.ngaychungtu >= tungay.DateTime && a.ngaychungtu <= denngay.DateTime /*&& a.tk_no != "911"*/
                                      select new
                                      {
                                          a.ngaychungtu,
                                          id = a.machungtu,
                                          a.ghichu,
                                          a.diengiai,
                                          taikhoan = a.tk_co,
                                          tkdoiung = a.tk_no,
                                          a.idcv,
                                          a.idmuccp,
                                          a.iddv,
                                          iddt = a.dt_co,
                                          psno = a.PS - a.PS,
                                          psco = a.PS,
                                      }).OrderBy(t => t.ngaychungtu);
                lst = (from a in db.dk_rps where a.loai == "Tài Khoản Đối Ứng" && a.user == Biencucbo.idnv && a.form == "f_sonhatkychung" select a);
                var lst3 = (from a in lst2
                            select new
                            {
                                a.ngaychungtu,
                                a.id,
                                a.ghichu,
                                a.diengiai,
                                a.taikhoan,
                                a.tkdoiung,
                                a.idcv,
                                a.idmuccp,
                                a.iddv,
                                a.iddt,
                                a.psno,
                                a.psco,
                            });
                if (check6 != 0)
                {
                    var tk1 = from b in db.dmtks where b.matk == "0" select b;
                    for (int i = 0; i < gridView2.DataRowCount; i++)
                    {
                        if (gridView2.GetRowCellValue(i, "loai").ToString() == "Tài Khoản Đối Ứng")
                        {
                            string ma = gridView2.GetRowCellValue(i, "id").ToString();
                            var tk2 = (from a in db.dmtks
                                       where a.active == true
                                       select a
                                   ).Where(t => t.matk.StartsWith(ma));
                            tk1 = tk1.Union(tk2);
                        }
                    }
                    tk = tk1;
                    lst3 = (from a in lst2
                            join b in tk on a.tkdoiung equals b.matk
                            select new
                            {
                                a.ngaychungtu,
                                a.id,
                                a.ghichu,
                                a.diengiai,
                                a.taikhoan,
                                a.tkdoiung,
                                a.idcv,
                                a.idmuccp,
                                a.iddv,
                                a.iddt,
                                a.psno,
                                a.psco,
                            });
                }
                r_sonhatkychung xtra = new r_sonhatkychung();
                xtra.DataSource = lst3;
                ReportPrintTool rpt = new ReportPrintTool(xtra);
                rpt.PreviewForm.MdiParent = Application.OpenForms[0];
                rpt.PreviewForm.Text = "BÁO CÁO SỔ NHẬT KÝ CHUNG";
                rpt.ShowPreview();
                //}
                //Biencucbo.title = "BẢNG KÊ PHIẾU THU TIỀN MẶT";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SplashScreenManager.CloseForm(false);
        }
    }
}
