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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
namespace GUI
{
    public partial class f_dsHopDong : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick = false;
        public f_dsHopDong()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            cbotrangthai.Text = "--ALL--";
            cbotinhtrang.Text = "--ALL--";
        }
        public string laymau(DateTime? bd, DateTime? kt, int? sothang)
        {
            int nam = 0;
            int thang = 0;
            DateTime checkngay1 = new DateTime(DateTime.Parse(bd.ToString()).Year, DateTime.Parse(bd.ToString()).Month, DateTime.Parse(bd.ToString()).Day);
            DateTime checkngay2 = new DateTime(DateTime.Parse(kt.ToString()).Year, DateTime.Parse(kt.ToString()).Month, DateTime.Parse(kt.ToString()).Day);
            int cthang = new tinhthoigian(checkngay1, checkngay2).Months;
            int cnam = new tinhthoigian(checkngay1, checkngay2).Years;
            int tongthang = cthang + (cnam * 12);
            //tongthang = (DateTime.Parse("10/01/2010"),DateTime.Parse(kt.ToString()))
            int lan = (tongthang) / int.Parse(sothang.ToString());
            string s = "trắng";
            checkngay2 = checkngay1;
            var check = (from a in db.r_pxuats where a.dv == "5" && a.iddv == Biencucbo.donvi select a);
            var check2 = check;
            try
            {
                for (int i = 1; i <= lan; i++)
                {
                    nam = checkngay1.Year + ((checkngay1.Month + int.Parse(sothang.ToString())) / 12);
                    thang = checkngay1.Month + int.Parse(sothang.ToString());
                    if (thang > 12)
                        thang = thang - 12;
                    checkngay1 = checkngay2;
                    checkngay2 = new DateTime(nam, thang, checkngay1.Day);
                    check2 = (from a in check where a.ngayhd >= checkngay1 && a.ngayhd <= checkngay2 select a);
                    if (check2.Count() == 0)
                    {
                        if (checkngay2.Month == DateTime.Now.Month && checkngay2.Year == DateTime.Now.Year)
                        {
                            s = "vàng";
                        }
                        else if ((checkngay2.Month < DateTime.Now.Month && checkngay2.Year == DateTime.Now.Year) || (checkngay2.Month < DateTime.Now.Year && checkngay2.Year < DateTime.Now.Year))
                        {
                            s = "đỏ";
                        }
                        else if (DateTime.Now < new DateTime(checkngay2.Year, (checkngay2.Month - 1), checkngay2.Day))
                        {
                            s = "xanh";
                        }
                        break;
                    }
                }
            }
            catch
            {
            }
            return s;
        }

        private double thudatcocct(string id)
        {
            double b = 0;
            try
            {
                var lst = (from a in db.r_pthus where a.id == id select a).Sum(t => t.nguyente);
                b = double.Parse(lst.ToString());
            }
            catch
            {
                b = 0;
            }
            return b;
        }
        private double thudatcoc(string id)
        {
            double a = 0;

            try
            {
                var lst = (from ab in db.hopdongs select ab).Single(t => t.id == id);
                a = thudatcocct(lst.datcoc1) + thudatcocct(lst.datcoc2);
            }
            catch
            {
               
                a = 0;
            }
            return a;


        }
        public void loaddata()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));
            try
            {
                var lst1 = (from a in db.r_hopdongs
                            join d in db.donvis on a.iddv equals d.id
                            //where a.ngaylap >= tungay && a.ngaylap <= denngay
                            select new
                            {
                                id = a.idhopdong,
                                ngaylap = a.ngaylap,
                                iddt = a.iddt,
                                idnv = a.idnv,
                                iddv = a.iddv,
                                ten = a.ten,
                                sohd = a.sohd,
                                solo = a.so,
                                a.dientich,
                                diengiai = a.ghichu,
                                a.dongia,
                                a.tiente,
                                datcoc = a.datcoc == null? 0 : a.datcoc,
                                thudatcoc = thudatcoc(a.idhopdong),
                                //conlaidatcoc = (a.datcoc == null ? 0 : a.datcoc) - thudatcoc(a.idhopdong),
                                a.nguyente,
                                dv = a.dv,
                                ghichu = a.ghichu,
                                idsanpham = a.idsanpham,
                                soluong = a.soluong,
                                thanhtien = a.thanhtien,
                                ngaybatdau = a.ngaybatdau,
                                ngayketthuc = a.ngayketthuc,
                                mau = laymau(a.ngaybatdau, a.ngayketthuc, a.thoihantt),
                                pttt = a.pttt,
                                MaTim = LayMaTim(d)
                            }).ToList();
                var lst = from a in lst1
                          select new
                          {
                              a.id,
                              a.ngaylap,
                              a.iddt,
                              a.idnv,
                              a.iddv,
                              a.ten,
                              a.sohd,
                              a.solo,
                              a.dientich,
                              a.diengiai,
                              a.dongia,
                              a.tiente,
                              a.datcoc,
                              a.thudatcoc,
                              //a.conlaidatcoc,
                              a.nguyente,
                              dv = a.dv,
                              a.ghichu,
                              a.soluong,
                              a.thanhtien,
                              a.ngaybatdau,
                              a.ngayketthuc,
                              mau = a.mau == "đỏ" ? System.Drawing.Color.Red : a.mau == "xanh" ? System.Drawing.Color.GreenYellow : a.mau == "vàng" ? System.Drawing.Color.Yellow : System.Drawing.Color.White,
                              mau2 = a.mau,
                              //mau = a.mau,
                              pttt = a.pttt,
                              a.MaTim,
                          };
                var lst2a = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                var lst2 = (from b in lst2a select b).GroupBy(a => new
                {
                    a.id,
                    a.ngaylap,
                    a.iddt,
                    a.idnv,
                    a.iddv,
                    a.ten,
                    a.dientich,
                    a.diengiai,
                    a.sohd,
                    a.datcoc,
                    a.thudatcoc,
                    //a.conlaidatcoc,
                    a.solo,
                    a.tiente,
                    dv = a.dv,
                    a.ghichu,
                    a.ngaybatdau,
                    a.ngayketthuc,
                    a.mau,
                    a.mau2,
                    a.pttt
                }).Select(a => new
                {
                    id = a.Key.id,
                    ngaylap = a.Key.ngaylap,
                    a.Key.iddt,
                    a.Key.idnv,
                    a.Key.iddv,
                    a.Key.ten,
                    a.Key.dientich,
                    a.Key.diengiai,
                    a.Key.sohd,
                    a.Key.solo,
                    a.Key.datcoc,
                    a.Key.thudatcoc,
                    conlaidatcoc = a.Key.datcoc - a.Key.thudatcoc,
                    //a.Key.conlaidatcoc,
                    a.Key.tiente,
                    nguyente = a.Sum(t => t.nguyente),
                    thanhtien = a.Sum(t => t.thanhtien),
                    dv = a.Key.dv,
                    a.Key.ghichu,
                    a.Key.ngaybatdau,
                    a.Key.ngayketthuc,
                    a.Key.mau,
                    a.Key.mau2,
                    a.Key.pttt
                });
                if (cbotinhtrang.Text == "--ALL--" && cbotrangthai.Text == "--ALL--")
                {
                    gridControl1.DataSource = lst2;
                }
                else if (cbotinhtrang.Text == "--ALL--" && cbotrangthai.Text != "--ALL--")
                {
                    var l = from a in lst2 where a.mau2 == tenmau select a;
                    gridControl1.DataSource = l;
                }
                else if (cbotinhtrang.Text != "--ALL--" && cbotrangthai.Text == "--ALL--")
                {
                    //--ALL--
                    //ĐÃ HOÀN THÀNH
                    //ĐANG HIỆU LỰC
                    if (cbotinhtrang.Text == "ĐÃ HOÀN THÀNH")
                    {
                        var l2 = from a in lst2 where a.ngayketthuc < DateTime.Now select a;
                        gridControl1.DataSource = l2;
                    }
                    else //ĐANG HIỆU LỰC
                    {
                        var l2 = from a in lst2 where a.ngayketthuc >= DateTime.Now select a;
                        gridControl1.DataSource = l2;
                    }
                }
                else if (cbotinhtrang.Text != "--ALL--" && cbotrangthai.Text != "--ALL--")
                {
                    if (cbotinhtrang.Text == "ĐÃ HOÀN THÀNH")
                    {
                        var l2 = from a in lst2 where a.mau2 == tenmau && a.ngayketthuc < DateTime.Now select a;
                        gridControl1.DataSource = l2;
                    }
                    else //ĐANG HIỆU LỰC
                    {
                        var l2 = from a in lst2 where a.mau2 == tenmau && a.ngayketthuc >= DateTime.Now select a;
                        gridControl1.DataSource = l2;
                    }
                }
            }
            catch (Exception ex)
            {
                Lotus.MsgBox.ShowErrorDialog(ex.ToString());
            }
            SplashScreenManager.CloseForm();
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
        private void f_PN_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Hợp Đồng").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            //tungay.ReadOnly = true;
            //denngay.ReadOnly = true;
            loaddata();
            Biencucbo.getID = 0;
        }
        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
            //changeTime.thoigian_change3(thoigian, tungay, denngay);
            //loaddata();  
        }
        private void timkiem_Click(object sender, EventArgs e)
        {
            //loaddata();
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
        public enum ItemTypeEnum { full, miss, need, time };
        private void gridView1_ShowFilterPopupListBox(object sender, FilterPopupListBoxEventArgs e)
        {
            if (e.Column.FieldName == "mau")
            {
                int index;
                for (index = 0; index < e.ComboBox.Items.Count; index++)
                {
                    object item = e.ComboBox.Items[index];
                    if (item is FilterItem)
                    {
                        object itemValue = ((FilterItem)item).Value;
                        if (itemValue is FilterItem || itemValue is ColumnFilterInfo) continue;
                        break;
                    }
                }
                ColumnFilterInfo fInfo = new ColumnFilterInfo(getFilterString(e.Column.FieldName, ItemTypeEnum.full), getFilterDisplayText(e.Column.Caption, ItemTypeEnum.full));
                e.ComboBox.Items.Insert(index, new FilterItem("Đầy Đủ", fInfo));
                fInfo = new ColumnFilterInfo(getFilterString(e.Column.FieldName, ItemTypeEnum.miss), getFilterDisplayText(e.Column.Caption, ItemTypeEnum.miss));
                e.ComboBox.Items.Insert(index + 1, new FilterItem("Quá Hạn", fInfo));
                fInfo = new ColumnFilterInfo(getFilterString(e.Column.FieldName, ItemTypeEnum.need), getFilterDisplayText(e.Column.Caption, ItemTypeEnum.need));
                e.ComboBox.Items.Insert(index + 1, new FilterItem("Sắp Hết Hạn", fInfo));
                fInfo = new ColumnFilterInfo(getFilterString(e.Column.FieldName, ItemTypeEnum.time), getFilterDisplayText(e.Column.Caption, ItemTypeEnum.time));
                e.ComboBox.Items.Insert(index + 1, new FilterItem("Cần Xuất Hóa Đơn", fInfo));
            }
        }
        protected virtual string getFilterString(string columnName, ItemTypeEnum itemType)
        {
            string filter = "";
            //string date1, date2;
            //string date1Str, date2Str;
            switch (itemType)
            {
                // The filter expression for the TODAY item.
                case ItemTypeEnum.full:
                    filter = "Contains([" + columnName + "], 'White')";
                    break;
                // The filter expression for the THIS MONTH item.
                case ItemTypeEnum.miss:
                    filter = "Contains([" + columnName + "], 'Red')";
                    break;
                case ItemTypeEnum.time:
                    filter = "Contains([" + columnName + "], 'GreenYellow')";
                    break;
                case ItemTypeEnum.need:
                    filter = "Contains([" + columnName + "], 'Yellow')";
                    break;
            }
            return filter;
        }
        // Returns the filter display text for a custom filter item.
        protected virtual string getFilterDisplayText(string columnName, ItemTypeEnum itemType)
        {
            string displayText = "";
            switch (itemType)
            {
                case ItemTypeEnum.full:
                    displayText = "Contains (" + columnName + ", Full)";
                    break;
                case ItemTypeEnum.miss:
                    //displayText = columnName + " = THIS MONTH abc";
                    displayText = "Contains (" + columnName + ", Miss)";
                    break;
                case ItemTypeEnum.need:
                    //displayText = columnName + " = THIS MONTH abc";
                    displayText = "Contains (" + columnName + ", Need)";
                    break;
                case ItemTypeEnum.time:
                    displayText = "Contains (" + columnName + ", Time)";
                    break;
            }
            return displayText;
        }
        string tenmau = "";
        private void cbotrangthai_TextChanged(object sender, EventArgs e)
        {
            if (cbotrangthai.Text == "Đầy Đủ") tenmau = "trắng";
            if (cbotrangthai.Text == "Quá Hạn") tenmau = "đỏ";
            if (cbotrangthai.Text == "Sắp Hết Hạn") tenmau = "xanh";
            if (cbotrangthai.Text == "Cần Xuất Hóa Đơn") tenmau = "vàng";
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            loaddata();
        }
        private void btnin_Click(object sender, EventArgs e)
        {
            var lst1 = (from a in db.r_hopdongs
                        join d in db.donvis on a.iddv equals d.id
                        //where a.ngaylap >= tungay && a.ngaylap <= denngay
                        select new
                        {
                            id = a.idhopdong,
                            ngaylap = a.ngaylap,
                            iddt = a.iddt,
                            idnv = a.idnv,
                            iddv = a.iddv,
                            ten = a.ten,
                            sohd = a.sohd,
                            solo = a.so,
                            a.dientich,
                            diengiai = a.ghichu,
                            a.dongia,
                            a.tiente,
                            a.nguyente,
                            dv = a.dv,
                            ghichu = a.ghichu,
                            idsanpham = a.idsanpham,
                            soluong = a.soluong,
                            thanhtien = a.thanhtien,
                            ngaybatdau = a.ngaybatdau,
                            ngayketthuc = a.ngayketthuc,
                            mau = laymau(a.ngaybatdau, a.ngayketthuc, a.thoihantt),
                            pttt = a.pttt,
                            MaTim = LayMaTim(d)
                        }).ToList();
            var lst = from a in lst1
                      select new
                      {
                          a.id,
                          a.ngaylap,
                          a.iddt,
                          a.idnv,
                          a.iddv,
                          a.ten,
                          a.sohd,
                          a.solo,
                          a.dientich,
                          a.diengiai,
                          a.dongia,
                          a.tiente,
                          a.nguyente,
                          dv = a.dv,
                          a.ghichu,
                          a.soluong,
                          a.thanhtien,
                          a.ngaybatdau,
                          a.ngayketthuc,
                          mau = a.mau == "đỏ" ? System.Drawing.Color.Red : a.mau == "xanh" ? System.Drawing.Color.GreenYellow : a.mau == "vàng" ? System.Drawing.Color.Yellow : System.Drawing.Color.White,
                          mau2 = a.mau,
                          //mau = a.mau,
                          pttt = a.pttt,
                          a.MaTim,
                      };
            var lst2a = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
            var lst2 = (from b in lst2a select b).GroupBy(a => new
            {
                a.id,
                a.ngaylap,
                a.iddt,
                a.idnv,
                a.iddv,
                a.ten,
                a.dientich,
                a.diengiai,
                a.sohd,
                a.solo,
                a.tiente,
                dv = a.dv,
                a.ghichu,
                a.ngaybatdau,
                a.ngayketthuc,
                a.mau,
                a.mau2,
                a.pttt
            }).Select(a => new
            {
                id = a.Key.id,
                ngaylap = a.Key.ngaylap,
                a.Key.iddt,
                a.Key.idnv,
                a.Key.iddv,
                a.Key.ten,
                a.Key.dientich,
                a.Key.diengiai,
                a.Key.sohd,
                a.Key.solo,
                a.Key.tiente,
                nguyente = a.Sum(t => t.nguyente),
                thanhtien = a.Sum(t => t.thanhtien),
                dv = a.Key.dv,
                a.Key.ghichu,
                a.Key.ngaybatdau,
                a.Key.ngayketthuc,
                a.Key.mau,
                a.Key.mau2,
                a.Key.pttt
            });
            if (cbotinhtrang.Text == "--ALL--" && cbotrangthai.Text == "--ALL--")
            {
                r_dm_hopdong r = new r_dm_hopdong();
                r.DataSource = lst2;
                r.ShowPreviewDialog();
            }
            else if (cbotinhtrang.Text == "--ALL--" && cbotrangthai.Text != "--ALL--")
            {
                var l = from a in lst2 where a.mau2 == tenmau select a;
                r_dm_hopdong r = new r_dm_hopdong();
                r.DataSource = l;
                r.ShowPreviewDialog();
            }
            else if (cbotinhtrang.Text != "--ALL--" && cbotrangthai.Text == "--ALL--")
            {
                //--ALL--
                //ĐÃ HOÀN THÀNH
                //ĐANG HIỆU LỰC
                if (cbotinhtrang.Text == "ĐÃ HOÀN THÀNH")
                {
                    var l2 = from a in lst2 where a.ngayketthuc < DateTime.Now select a;
                    r_dm_hopdong r = new r_dm_hopdong();
                    r.DataSource = l2;
                    r.ShowPreviewDialog();
                }
                else //ĐANG HIỆU LỰC
                {
                    var l2 = from a in lst2 where a.ngayketthuc >= DateTime.Now select a;
                    r_dm_hopdong r = new r_dm_hopdong();
                    r.DataSource = l2;
                    r.ShowPreviewDialog();
                }
            }
            else if (cbotinhtrang.Text != "--ALL--" && cbotrangthai.Text != "--ALL--")
            {
                if (cbotinhtrang.Text == "ĐÃ HOÀN THÀNH")
                {
                    var l2 = from a in lst2 where a.mau2 == tenmau && a.ngayketthuc < DateTime.Now select a;
                    r_dm_hopdong r = new r_dm_hopdong();
                    r.DataSource = l2;
                    r.ShowPreviewDialog();
                }
                else //ĐANG HIỆU LỰC
                {
                    var l2 = from a in lst2 where a.mau2 == tenmau && a.ngayketthuc >= DateTime.Now select a;
                    r_dm_hopdong r = new r_dm_hopdong();
                    r.DataSource = l2;
                    r.ShowPreviewDialog();
                }
            }
        }
    }
}
