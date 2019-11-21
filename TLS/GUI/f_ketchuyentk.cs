using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using ControlLocalizer;
namespace GUI
{
    public partial class f_ketchuyentk : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_cttk tk = new t_cttk();
        void load()
        {
            var lst = (from a in db.ct_tks
                       where (a.tk_no.StartsWith("5") || a.tk_no.StartsWith("6") || a.tk_no.StartsWith("7") || a.tk_no.StartsWith("8")
                       || a.tk_co.StartsWith("5") || a.tk_co.StartsWith("6") || a.tk_co.StartsWith("7") || a.tk_co.StartsWith("8")
                       )
                        && (a.kc != "Yes" || a.kc == null)
                       select new data_tk()
                       {
                           id = a.id,
                           iddv = a.iddv,
                           loaichungtu = a.loaichungtu,
                           machungtu = a.machungtu,
                           ngaychungtu = a.ngaychungtu,
                           ngaylchungtu = a.ngaylchungtu,
                           sochungtu = a.sochungtu,
                           diengiai = a.diengiai,
                           tk_no = a.tk_no,
                           tk_co = a.tk_co,
                           PS = a.PS,
                           tiente = a.tiente,
                           tygia = a.tygia,
                           PS_nt = a.PS_nt,
                           //a.idsp,
                           //a.id2,
                           idnv = a.idnv,
                           loai = a.loai,
                           idcv = a.idcv,
                           idmuccp = a.idmuccp,
                           //a.ghichu,
                           //a.tendt,
                           kc = a.kc
                       }).ToList();
            gridControl1.DataSource = lst;
        }
        public f_ketchuyentk()
        {
            InitializeComponent();
            load();
        }
        // phân quyền  
        //protected override void OnActivated(EventArgs e)
        //{
        //    base.OnActivated(e);
        //    var q = Biencucbo.QuyenDangChon;
        //    if (q == null) return;
        //    btnthem.Enabled = (bool)q.Them;
        //    btnsua.Enabled = (bool)q.Sua;
        //    btnxoa.Enabled = (bool)q.Xoa;
        //}
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Biencucbo.hddmtk = 1;
            Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
        }
        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private void f_dmtk_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Kết Chuyển Tài Khoản").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
        }
        private void btnKetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lst = (from a in db.ct_tks
                       where (a.tk_no.StartsWith("5") || a.tk_no.StartsWith("6") || a.tk_no.StartsWith("7") || a.tk_no.StartsWith("8")
                       || a.tk_co.StartsWith("5") || a.tk_co.StartsWith("6") || a.tk_co.StartsWith("7") || a.tk_co.StartsWith("8")
                       )
                        && (a.kc != "Yes" || a.kc == null)
                       select new data_tk()
                       {
                           id = a.id,
                           iddv = a.iddv,
                           loaichungtu = a.loaichungtu,
                           machungtu = a.machungtu,
                           ngaychungtu = a.ngaychungtu,
                           ngaylchungtu = a.ngaylchungtu,
                           sochungtu = a.sochungtu,
                           diengiai = a.diengiai,
                           tk_no = a.tk_no,
                           tk_co = a.tk_co,
                           PS = a.PS,
                           tiente = a.tiente,
                           tygia = a.tygia,
                           PS_nt = a.PS_nt,
                           //a.idsp,
                           //a.id2,
                           idnv = a.idnv,
                           loai = a.loai,
                           idcv = a.idcv,
                           idmuccp = a.idmuccp,
                           //a.ghichu,
                           //a.tendt,
                           kc = a.kc
                       }).ToList();
            for (int i = 0; i < lst.Count(); i++)
            {
                var row1 = lst.ElementAt(i) as data_tk;
                if (row1.tk_no.Substring(0, 1) == "5" || row1.tk_no.Substring(0, 1) == "6" || row1.tk_no.Substring(0, 1) == "7" || row1.tk_no.Substring(0, 1) == "8")
                {
                    tk.moi(row1.id + "no", row1.iddv, "KC", row1.machungtu, row1.ngaychungtu.Value, DateTime.Now, -1, "", "", row1.tk_no + "->> 911", "911", row1.tk_no, row1.PS.Value, row1.tiente, row1.tygia.Value, row1.PS_nt.Value, "", "", row1.idnv, "", row1
                    .idcv, row1.idmuccp, "", "",0.0);
                    tk.sua(row1.id, "Yes");
                    tk.sua(row1.id + "no", "Yes");
                }
                if (row1.tk_co.Substring(0, 1) == "5" || row1.tk_co.Substring(0, 1) == "6" || row1.tk_co.Substring(0, 1) == "7" || row1.tk_co.Substring(0, 1) == "8")
                {
                    tk.moi(row1.id + "co", row1.iddv, "KC", row1.machungtu, row1.ngaychungtu.Value, DateTime.Now, -1, "", "", row1.tk_co + "->> 911", row1.tk_co, "911", row1.PS.Value, row1.tiente, row1.tygia.Value, row1.PS_nt.Value, "", "", row1.idnv, "", row1
                        .idcv, row1.idmuccp, "", "",0.0);
                    tk.sua(row1.id, "Yes");
                    tk.sua(row1.id + "co", "Yes");
                }
            }
            load();
        }
        private void btnds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lst = (from a in db.ct_tks
                       where (a.tk_no.StartsWith("5") || a.tk_no.StartsWith("6") || a.tk_no.StartsWith("7") || a.tk_no.StartsWith("8")
                       || a.tk_co.StartsWith("5") || a.tk_co.StartsWith("6") || a.tk_co.StartsWith("7") || a.tk_co.StartsWith("8")
                       )
                        && a.kc == "Yes" && a.loaichungtu == "KC"
                       select a).ToList();
            gridControl1.DataSource = lst;
        }
    }
}
