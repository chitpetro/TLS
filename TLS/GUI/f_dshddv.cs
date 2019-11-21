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
    public partial class f_dshddv : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        Boolean doubleclick = false;
        public f_dshddv()
        {
            InitializeComponent();
            //lay quyen
            var quyen1 = db.PhanQuyen2s.FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "DSHDDV_TaoMoiHD");
            btnthem.Enabled = (bool)quyen1.Xem;
        }
        public string timloai(string loaixuat)
        {
            string s = "";
            try
            {
                var lst = (from a in db.hopdongcts select a).Single(t => t.id == loaixuat);
                s = lst.diengiai;
            }
            catch
            {
            }
            return s;
        }
        public void loaddata()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));
            try
            {
                if (Biencucbo.hddv == 1)
                {
                    var lst = from a in db.r_pxuats
                              join d in db.donvis on a.iddv equals d.id
                              where
                             a.link == Biencucbo.hopdong
                              select new
                              {
                                  id = a.id,
                                  ngayhd = a.ngayhd,
                                  iddt = a.iddt,
                                  idnv = a.idnv,
                                  iddv = a.iddv,
                                  idcv = a.idcv,
                                  ten = a.ten,
                                  noidung = a.diengiai,
                                  dv = a.dv,
                                  tt = checktt(a.id),
                                  ghichu = a.ghichu,
                                  loaixuat = timloai(a.loaixuat),
                                  idsanpham = a.idsanpham,
                                  soluong = a.soluong,
                                  thanhtien = a.thanhtien,
                                  tiente = a.tiente,
                                  nguyente = a.nguyente,
                                  sohd = a.link,
                              };
                    var lst2 = lst.ToList();
                    gridControl1.DataSource = lst2;
                    gridView1.ClearGrouping();
                    gridView1.Columns["loaixuat"].GroupIndex = 1;
                    gridView1.ExpandAllGroups();
                }
                else if (Biencucbo.hddv == 2)
                {
                    btnthem.Enabled = false;
                    var lst = from a in db.r_pxuats
                              join d in db.donvis on a.iddv equals d.id
                              where
                            a.dv == "5" && a.iddv == Biencucbo.donvi
                              select new
                              {
                                  id = a.id,
                                  ngayhd = a.ngayhd,
                                  iddt = a.iddt,
                                  idnv = a.idnv,
                                  iddv = a.iddv,
                                  idcv = a.idcv,
                                  ten = a.ten,
                                  noidung = a.diengiai,
                                  dv = a.dv,
                                  tt = checktt(a.id),
                                  ghichu = a.ghichu,
                                  loaixuat = a.loaixuat,
                                  idsanpham = a.idsanpham,
                                  soluong = a.soluong,
                                  thanhtien = a.thanhtien,
                                  tiente = a.tiente,
                                  nguyente = a.nguyente,
                                  sohd = a.link,
                                  MaTim = LayMaTim(d),
                              };
                    var lst2 = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + ".")); ;
                    gridControl1.DataSource = lst2;
                    gridView1.Columns["loaixuat"].Visible = false;
                    
                }
            }
            catch (Exception ex)
            {
                Lotus.MsgBox.ShowErrorDialog(ex.ToString());
            }
            SplashScreenManager.CloseForm();
        }
        private bool checktt(string id)
        {
            var lst = (from a in db.pthus where a.link == id select a).ToList();
            if (lst.Count() == 0)
                return false;
            else
                return true;
        }
        private void f_PN_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Danh Sách Hoá Đơn").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            loaddata();
        }
        private void thoigian_EditValueChanged(object sender, EventArgs e)
        {
        }
        private void timkiem_Click(object sender, EventArgs e)
        {
            loaddata();
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
                Biencucbo.hdhd = 2;
                Biencucbo.getID = 1;
                Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
                f_hddv2 frm = new f_hddv2();
                frm.ShowDialog();
                loaddata();
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            doubleclick = true;
        }
        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdhd = 0;
            Biencucbo.getID = 0;
            f_hddv2 frm = new f_hddv2();
            frm.ShowDialog();
            loaddata();
        }
    }
}
