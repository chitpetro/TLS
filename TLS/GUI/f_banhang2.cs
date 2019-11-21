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
using BUS;
using DevExpress.XtraEditors;
using System.Data.Linq;
using DevExpress.XtraReports.UI;
using ControlLocalizer;
using GUI.Properties;
using DevExpress.Utils.Win;
using WMPLib;

namespace GUI
{
    public partial class f_banhang2 : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public f_banhang2()
        {
            InitializeComponent();
            //tran

            btnmasp.DataSource = (from a in new DAL.KetNoiDBDataContext().r_giasps select new { id = a.idsp, tensp = a.tensp, dvt = a.dvt });
            rsearchTenSP.DataSource = btnmasp.DataSource;
            btndvt.DataSource = btnmasp.DataSource;
            txtiddt.Properties.DataSource = new DAL.KetNoiDBDataContext().doituongbhs;
            Biencucbo.hdbh = 0;

            gcchitiet.DataSource = new DAL.KetNoiDBDataContext().View_banhangs;


            for (int i = 0; i <= gridView1.RowCount - 1; i++)
            {
                gridView1.DeleteRow(i);
            }

            gridView1.OptionsBehavior.Editable = false;
            if (Biencucbo.ngonngu.ToString() == "Vietnam")
            {
                coldiengiai.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "Tổng cộng:")});
                gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "Tổng cộng:")});
                gridColumn35.Caption = "Mã Đối Tượng";
                gridColumn36.Caption = "Tên Đối Tượng ";
                gridColumn37.Caption = "Nhóm Đối Tượng";
                gridColumn38.Caption = "Loại Đối Tượng";
                gridColumn39.Caption = "Địa Chỉ";
                gridColumn41.Caption = "Mã công việc";
                gridColumn42.Caption = "Tên công việc";
                gridColumn43.Caption = "Nhóm công việc";
                gridColumn29.Caption = "Loại thuế";
                gridColumn30.Caption = "Tên thuế";
                gridColumn31.Caption = "Thuế suất";
                gridColumn27.Caption = "Mã Sản Phẩm";
                gridColumn28.Caption = "Tên Sản Phẩm";
                gridColumn32.Caption = "ĐVT";
                gridColumn33.Caption = "Loại Sản Phẩm";
            }
            else //lao
            {
                coldiengiai.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "ລວມທັງໝົດ:")});
                gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diengiai", "ລວມທັງໝົດ:")});
                gridColumn35.Caption = "ລະຫັດ";
                gridColumn36.Caption = "ຊື່ເປົ້າໝາຍ";
                gridColumn37.Caption = "ກຸ່ມເປົ້າໝາຍ";
                gridColumn38.Caption = "ປະເພດເປົ້າໝາຍ";
                gridColumn39.Caption = "ທີ່ຢູ່";
                gridColumn41.Caption = "ລະຫັດວຽກງານ";
                gridColumn42.Caption = "ຊື່ວຽກງານ";
                gridColumn43.Caption = "ກຸ່ມໜ້າວຽກ";
                gridColumn29.Caption = "ປະເພດຂອງອາກອນ";
                gridColumn30.Caption = "ຊື່ອາກອນ";
                gridColumn31.Caption = "ອາກອນ (%)";
                gridColumn27.Caption = "ລະຫັດຜະລິດຕະພັນ";
                gridColumn28.Caption = "ຊື່ຜະລິດຕະພັນ";
                gridColumn32.Caption = "ຫົວໜ່ວຍຄິດໄລ່";
                gridColumn33.Caption = "ປະເພດ";
            }

        }


        // phân quyền 

        //load


        public void load()
        {

        }
        //Mở

        //Add new








        private void btnmasp_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                var lst = new DAL.KetNoiDBDataContext().r_giasps;
                string bc = gridView1.GetFocusedRowCellValue("idsanpham").ToString();
                var ab = (from a in lst where a.iddv == Biencucbo.donvi select a);
                var abc = (from a in lst where a.iddv == Biencucbo.donvi && a.idsp == gridView1.GetFocusedRowCellValue("idsanpham").ToString() select a);
                var lst2 = (from a in lst where a.iddv == Biencucbo.donvi select a).Single(t => t.idsp == gridView1.GetFocusedRowCellValue("idsanpham").ToString());

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridView1.UpdateCurrentRow();

            if (e.Column.FieldName == "soluong" || e.Column.FieldName == "dongia" || e.Column.FieldName == "chietkhau" || e.Column.FieldName == "loaithue" || e.Column.FieldName == "tygia")
            {
                try
                {
                    try
                    {
                        gridView1.SetFocusedRowCellValue("thue", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) * double.Parse(gridView1.GetFocusedRowCellDisplayText("loaithue").ToString()) / 100);
                    }
                    catch
                    {
                        gridView1.SetFocusedRowCellValue("nguyente", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) + double.Parse(gridView1.GetFocusedRowCellValue("thue").ToString()));
                    }
                    finally
                    {
                        gridView1.SetFocusedRowCellValue("thue", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) * double.Parse(gridView1.GetFocusedRowCellDisplayText("loaithue").ToString()) / 100);
                        gridView1.SetFocusedRowCellValue("nguyente", (((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("dongia").ToString()))) - ((double.Parse(gridView1.GetFocusedRowCellValue("soluong").ToString())) * (double.Parse(gridView1.GetFocusedRowCellValue("chietkhau").ToString())))) + double.Parse(gridView1.GetFocusedRowCellValue("thue").ToString()));
                    }
                }
                catch (Exception)
                {
                }
            }
            else if (e.Column.FieldName == "nguyente")
            {
                try
                {
                    //gridView1.SetFocusedRowCellValue("thanhtien", (double.Parse(gridView1.GetFocusedRowCellValue("nguyente").ToString())) * (double.Parse(txttygia.Text)));
                }
                catch (Exception)
                {
                }
            }



        }

        private void txtiddt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().doituongbhs select a).Single(t => t.id == txtiddt.Text);
                lbltendt.Text = lst.ten.ToString();
                txtdiachi.Text = lst.diachi.ToString();
            }
            catch (Exception)
            {
            }
        }

        //add new row



        private void btnIdSp_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }
        private void f_hd_Load(object sender, EventArgs e)
        {

            Screen[] sc;
            sc = Screen.AllScreens;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[sc.Length - 1].Bounds.Right - sc[sc.Length - 1].Bounds.Width, sc[sc.Length - 1].Bounds.Top);
            this.WindowState = FormWindowState.Normal;
            this.Size = sc[sc.Length - 1].Bounds.Size;
            txttotal.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            txtiddt.ReadOnly = true;
            //this.AutoSize = true;
            try
            {
                //vd.URL = "D:\\video\\thatluang.mp4";
                //vd.settings.setMode("loop", true);
                //int abc = int.Parse(Color.Transparent.ToString());
                //fl.BackgroundColor = int.Parse(Color.Transparent.ToString());
                var withBlock = (fl);
                withBlock.Stop();
                withBlock.Movie = "D:\\video\\thatluang.swf";
                withBlock.Play();


            }
            catch
            {
                openFileDialog1.Filter = "(mp3,wav,mp4,mov,wmv,mpg,swf)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var withBlock = (fl);
                    withBlock.Stop();
                    withBlock.Movie = openFileDialog1.FileName;
                    withBlock.Play();
                }

            }

            //this.WindowState = FormWindowState.Maximized;
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Bán hàng").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            load();
        }
        public void truyenxoaall()
        {
            //if (gridView1.RowCount == 0)
            //{
            //    txttotal.Text = "0";
            //    return;
            //}
            for (int i = gridView1.DataRowCount - 1; i >= 0; i--)
            {

                gridView1.DeleteRow(i);
            }
            gridView1.UpdateCurrentRow();
            txttotal.Text = "0";
        }
        public void truyendt(string a)
        {
            txtiddt.Text = a;
            var lst = (from ab in db.doituongbhs select ab).Single(t => t.id == a);
            lbltendt.Text = lst.ten;
            txtdiachi.Text = lst.diachi;

        }

        public void truyenxoact(int row)
        {
            gridView1.UpdateCurrentRow();
            gridView1.DeleteRow(row);
            gridView1.UpdateCurrentRow();
            txttotal.Text = colnguyente.SummaryItem.SummaryValue.ToString();
        }

        public void truyensuact(string a, double b, int row)
        {
            int abcd = gridView1.DataRowCount;
            try
            {
                gridView1.UpdateCurrentRow();
                gridView1.SetRowCellValue(gridView1.DataRowCount - 1, "idsanpham", a);
                gridView1.SetRowCellValue(gridView1.DataRowCount - 1, "soluong", b.ToString());
                gridView1.UpdateCurrentRow();

                txttotal.Text = colnguyente.SummaryItem.SummaryValue.ToString();
            }
            catch
            {

            }
        }

        public void truyensuact2(double a, double b, int row)
        {
            try
            {
                gridView1.UpdateCurrentRow();
                gridView1.SetRowCellValue(gridView1.DataRowCount - 1, "dongia", a.ToString());
                gridView1.SetRowCellValue(gridView1.DataRowCount - 1, "chietkhau", b.ToString());
                gridView1.UpdateCurrentRow();
                txttotal.Text = colnguyente.SummaryItem.SummaryValue.ToString();
            }
            catch
            {

            }
        }
        public void truyenthemct()
        {
            gridView1.AddNewRow();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView1.SetFocusedRowCellValue("diengiai", "");
            gridView1.SetFocusedRowCellValue("soluong", "0");
            gridView1.SetFocusedRowCellValue("thue", "0");
            gridView1.SetFocusedRowCellValue("tygia", "1");
            gridView1.SetFocusedRowCellValue("loaithue", "VAT");
        }

        private void vd_Enter(object sender, EventArgs e)
        {

        }

        private void vd_PlaylistChange(object sender, AxWMPLib._WMPOCXEvents_PlaylistChangeEvent e)
        {

        }

        private void vd_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //if ((WMPLib.WMPPlayState)e.newState == WMPPlayState.wmppsPlaying)
            //{
            //    vd.fullScreen = true;
            //    vd.Ctlenabled = false;
            //}
            //else if ((WMPLib.WMPPlayState)e.newState == WMPPlayState.wmppsMediaEnded)
            //{
            //    vd.Ctlcontrols.currentPosition = 0;
            //    vd.Ctlcontrols.play();
            //}
        }
    }
}
