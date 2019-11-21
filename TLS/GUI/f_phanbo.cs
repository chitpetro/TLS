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
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
namespace GUI
{
    public partial class f_phanbo : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        double tongsl = 0;
        double tonggt = 0;
        double chiphia = 0;
        double giavona = 0;
        t_pnhap pn = new t_pnhap();
        t_cttk tk = new t_cttk();
        public f_phanbo()
        {
            InitializeComponent();
            //gridControl1.DataSource = new DAL.KetNoiDBDataContext().pnhaps;
            //lay quyen
            var quyen1 = db.PhanQuyen2s.FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == "PhanBo_ThucHienPhanBo");
            btnpb.Enabled = (bool)quyen1.Xem;
            txtsotienpb.ReadOnly = true;
            txttiente.Properties.DataSource = new KetNoiDBDataContext().tientes;
            txttiente.Text = "KIP";
            txttygia.Text = "1";
            txttygia.ReadOnly = true;
            //txtthue.ReadOnly = true;
            rTime.SetTime(thoigian);
            rTime.SetTime2(thoigian);
           
        }
        public void loaddata(DateTime tungay, DateTime denngay)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));
            try
            {
                var lst = from a in db.r_pnhaps
                          join d in db.donvis on a.iddv equals d.id
                          where
                          a.ngaynhap >= tungay && a.ngaynhap <= denngay && a.idsanpham != null
                          select new
                          {
                              id = a.id,
                              ngaynhap = a.ngaynhap,
                              iddt = a.iddt,
                              ten = a.ten,
                              idnv = a.idnv,
                              iddv = a.iddv,
                              idcv = a.idcv,
                              dv = a.dv,
                              a.so,
                              a.tygia,
                              ghichu = a.ghichu,
                              loainhap = a.loainhap,
                              idsanpham = a.idsanpham,
                              soluong = a.soluong == null ? 0 : a.soluong,
                              thanhtien = a.thanhtien == null ? 0 :a.thanhtien,
                              noidung = a.diengiai,
                              tiente = a.tiente,
                              nguyente = a.nguyente == null ? 0 : a.nguyente,
                              chiphi = a.chiphi == null ? 0 : a.chiphi,
                              a.giavon,
                              a.id2,
                              check = true,
                              MaTim = LayMaTim(d)
                          };
                tongsl = double.Parse(lst.Sum(t => t.soluong).ToString());
                tonggt = double.Parse(lst.Sum(t => t.thanhtien).ToString());
                var lst2 = lst.ToList().Where(t => t.MaTim.Contains("." + Biencucbo.donvi + "."));
                gridControl1.DataSource = lst2;
                if (lst2.Count() == 0)
                {
                    tongsl = 0;
                    tonggt = 0;
                }
                else
                {
                    tongsl = double.Parse(coldv.SummaryItem.SummaryValue.ToString());
                    tonggt = double.Parse(colghichu.SummaryItem.SummaryValue.ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
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
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Phân Bổ").ToString();
            txtthue.Text = "0";
            checkthue.Checked = false;
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            tungay.ReadOnly = true;
            denngay.ReadOnly = true;
            Biencucbo.getID = 0;
        }
        private void tungay_EditValueChanged(object sender, EventArgs e)
        {
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
        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
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
        }
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            //if (doubleclick == true)
            //{
            //    Biencucbo.getID = 1;
            //    Biencucbo.ma = gridView1.GetFocusedRowCellValue("id").ToString();
            //    this.Close();
            //}
        }
        private void rsgt_CheckedChanged(object sender, EventArgs e)
        {
            if (rsgt.Checked == true)
            {
                rasl.Checked = false;
            }
            else
            { rasl.Checked = true; }
        }
        private void rasl_CheckedChanged(object sender, EventArgs e)
        {
            if (rasl.Checked == true)
            {
                rsgt.Checked = false;
            }
            else
            { rsgt.Checked = true; }
        }
        private void btnpb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            double nt_thue = 0;
            if (rasl.Checked == true)
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    chiphia = double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString()) * double.Parse(txtsotienpb.Text) / tongsl;
                    giavona = double.Parse(gridView1.GetRowCellValue(i, "thanhtien").ToString()) + chiphia;
                    pn.suact(gridView1.GetRowCellValue(i, "id2").ToString(), chiphia, giavona);
                    
                    // định khoản2
                    tk.xoa2(gridView1.GetRowCellValue(i, "id2").ToString() + "3");
                    tk.xoa2(gridView1.GetRowCellValue(i, "id2").ToString() + "4");
                    tk.moi(gridView1.GetRowCellValue(i, "id2").ToString() + "3", gridView1.GetRowCellValue(i, "iddv").ToString(), "PBCP", gridView1.GetRowCellValue(i, "id").ToString(), DateTime.Parse(gridView1.GetRowCellValue(i, "ngaynhap").ToString()), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), int.Parse(gridView1.GetRowCellValue(i, "so").ToString()), gridView1.GetRowCellValue(i, "iddv").ToString(), gridView1.GetRowCellValue(i, "iddt").ToString(), gridView1.GetRowCellValue(i, "noidung").ToString(), "1562", "3311", chiphia, gridView1.GetRowCellValue(i, "tiente").ToString(), double.Parse(gridView1.GetRowCellValue(i, "tygia").ToString()), chiphia / double.Parse(gridView1.GetRowCellValue(i, "tygia").ToString()), gridView1.GetRowCellValue(i, "idsanpham").ToString(), "", Biencucbo.idnv, gridView1.GetRowCellValue(i, "loainhap").ToString(), gridView1.GetRowCellValue(i, "idcv").ToString(), "", gridView1.GetRowCellValue(i, "ten").ToString(), gridView1.GetRowCellValue(i, "ghichu").ToString(), double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString()));
                    if (checkthue.Checked == true)
                    {
                        nt_thue = double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString()) * double.Parse(txtthue.Text) / tongsl;
                        tk.moi(gridView1.GetRowCellValue(i, "id2").ToString() + "4", gridView1.GetRowCellValue(i, "iddv").ToString(), "PBCP", gridView1.GetRowCellValue(i, "id").ToString(), DateTime.Parse(gridView1.GetRowCellValue(i, "ngaynhap").ToString()), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), int.Parse(gridView1.GetRowCellValue(i, "so").ToString()), gridView1.GetRowCellValue(i, "iddv").ToString(), gridView1.GetRowCellValue(i, "iddt").ToString(), gridView1.GetRowCellValue(i, "noidung").ToString(), "133", "3311", nt_thue, gridView1.GetRowCellValue(i, "tiente").ToString(), double.Parse(gridView1.GetRowCellValue(i, "tygia").ToString()), nt_thue / double.Parse(gridView1.GetRowCellValue(i, "tygia").ToString()), gridView1.GetRowCellValue(i, "idsanpham").ToString(), "", Biencucbo.idnv, gridView1.GetRowCellValue(i, "loainhap").ToString(), gridView1.GetRowCellValue(i, "idcv").ToString(), "", gridView1.GetRowCellValue(i, "ten").ToString(), gridView1.GetRowCellValue(i, "ghichu").ToString(),0.0);
                    }
                }
            }
            else if (rsgt.Checked == true)
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    chiphia = double.Parse(gridView1.GetRowCellValue(i, "thanhtien").ToString()) * double.Parse(txtsotienpb.Text) / tonggt;
                    giavona = double.Parse(gridView1.GetRowCellValue(i, "thanhtien").ToString()) + chiphia;
                    pn.suact(gridView1.GetRowCellValue(i, "id2").ToString(), chiphia, giavona);
                    
                    tk.xoa2(gridView1.GetRowCellValue(i, "id2").ToString() + "3");
                    tk.xoa2(gridView1.GetRowCellValue(i, "id2").ToString() + "4");
                    tk.moi(gridView1.GetRowCellValue(i, "id2").ToString() + "3", gridView1.GetRowCellValue(i, "iddv").ToString(), "PBCP", gridView1.GetRowCellValue(i, "id").ToString(), DateTime.Parse(gridView1.GetRowCellValue(i, "ngaynhap").ToString()), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), int.Parse(gridView1.GetRowCellValue(i, "so").ToString()), gridView1.GetRowCellValue(i, "iddv").ToString(), gridView1.GetRowCellValue(i, "iddt").ToString(), gridView1.GetRowCellValue(i, "noidung").ToString(), "1562", "3311", chiphia, gridView1.GetRowCellValue(i, "tiente").ToString(), double.Parse(gridView1.GetRowCellValue(i, "tygia").ToString()), chiphia / double.Parse(gridView1.GetRowCellValue(i, "tygia").ToString()), gridView1.GetRowCellValue(i, "idsanpham").ToString(), "", Biencucbo.idnv, gridView1.GetRowCellValue(i, "loainhap").ToString(), gridView1.GetRowCellValue(i, "idcv").ToString(), "", gridView1.GetRowCellValue(i, "ten").ToString(), gridView1.GetRowCellValue(i, "ghichu").ToString(), double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString()));
                    if (checkthue.Checked == true)
                    {
                        nt_thue = double.Parse(gridView1.GetRowCellValue(i, "soluong").ToString()) * double.Parse(txtthue.Text) / tongsl;
                        tk.moi(gridView1.GetRowCellValue(i, "id2").ToString() + "4", gridView1.GetRowCellValue(i, "iddv").ToString(), "PBCP", gridView1.GetRowCellValue(i, "id").ToString(), DateTime.Parse(gridView1.GetRowCellValue(i, "ngaynhap").ToString()), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), int.Parse(gridView1.GetRowCellValue(i, "so").ToString()), gridView1.GetRowCellValue(i, "iddv").ToString(), gridView1.GetRowCellValue(i, "iddt").ToString(), gridView1.GetRowCellValue(i, "noidung").ToString(), "133", "3311", nt_thue, gridView1.GetRowCellValue(i, "tiente").ToString(), double.Parse(gridView1.GetRowCellValue(i, "tygia").ToString()), nt_thue / double.Parse(gridView1.GetRowCellValue(i, "tygia").ToString()), gridView1.GetRowCellValue(i, "idsanpham").ToString(), "", Biencucbo.idnv, gridView1.GetRowCellValue(i, "loainhap").ToString(), gridView1.GetRowCellValue(i, "idcv").ToString(), "", gridView1.GetRowCellValue(i, "ten").ToString(), gridView1.GetRowCellValue(i, "ghichu").ToString(), 0.0);
                    }
                }
            }
            MessageBox.Show("Done!", "THÔNG BÁO");
            loaddata(tungay.DateTime, denngay.DateTime);
        }
        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            tongsl = double.Parse(coldv.SummaryItem.SummaryValue.ToString());
            tonggt = double.Parse(colghichu.SummaryItem.SummaryValue.ToString());
        }
        private void checkthue_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkthue.Checked == true)
                {
                    txtthue.Text = (double.Parse(txtsotienpb.Text) * 10 / 100).ToString();
                }
                else
                {
                    txtthue.Text = "0";
                }
            }
            catch
            {
                txtthue.Text = "0";
            }
        }
        private void txttiente_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var lst = (from a in db.tientes select a).Single(t => t.tiente1 == txttiente.Text);
                    txttygia.Text = lst.tygia.ToString();
                }
                catch
                {
                }
                txtsotienpb.Text = (double.Parse(txtpbnguyente.Text) * double.Parse(txttygia.Text)).ToString();
                if(checkthue.Checked == true)
                {
                    txtthue.Text = (double.Parse(txtpbnguyente.Text) * 10 / 100 * double.Parse(txttygia.Text)).ToString();
                }
                else
                {
                    txtthue.Text = "0";
                }
                
            }
            catch
            {
                txtthue.Text = "0";
                txtthue.Text = "0";
            }
        }
        private void txtpbnguyente_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtsotienpb.Text = (double.Parse(txtpbnguyente.Text) * double.Parse(txttygia.Text)).ToString();
                if (checkthue.Checked == true)
                {
                    txtthue.Text = (double.Parse(txtpbnguyente.Text) * 10 / 100 * double.Parse(txttygia.Text)).ToString();
                }
                else
                {
                    txtthue.Text = "0";
                }
            }
            catch
            {
                txtthue.Text = "0";
                txtthue.Text = "0";
            }
        }
    }
}
