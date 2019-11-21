using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;

namespace GUI.frm
{
    public partial class frmmop : DevExpress.XtraEditors.XtraForm
    {
        public frmmop()
        {
            InitializeComponent();
        }

        private void gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            custom.sttgv(gv, e);
            BeginInvoke(new MethodInvoker(delegate
            {
                custom.cal(gd, gv);
            }));
        }
        SaveFileDialog saveFile = new SaveFileDialog();
        private void btnxls_Click(object sender, EventArgs e)
        {
            try
            {
                saveFile.FileName = "Danh sách";
                var tmpPath = saveFile.InitialDirectory;
                saveFile.FilterIndex = 1;
                saveFile.RestoreDirectory = true;
                saveFile.DefaultExt = "xls";
                saveFile.Filter = "*.xls|";
                
                saveFile.Title = "Chọn nơi muốn xuất file";
                var file = "";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {

                    file = saveFile.FileName;
                    gv.ExportToXls(file);
                    if (
                   MessageBox.Show("Tải về Thành Công- Bạn có muốn mở file lên không?", "Thông Báo",
                       MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start(file);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool dble;
        private void gv_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void gv_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (dble)
            {
                try
                {
                    Biencucbo.key = gv.GetFocusedRowCellValue("key").ToString();
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
              
                }
            }
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            gv.ShowRibbonPrintPreview();
        }

        protected virtual void search()
        {

        }
        protected virtual void searchall()
        {

        }
        protected virtual void load()
        {

        }
        private void btnsearh_Click(object sender, EventArgs e)
        {
            search();
        }

        private void btnsearchall_Click(object sender, EventArgs e)
        {
            searchall();

        }

        private void changetime()

        {

            string time = thoigian.Text;
            int chieudai = time.Length;
            string chu = time.Substring(0, 5);
            string so = "";
            DateTime ngay;

            if (thoigian.Text == "Tùy Ý")
            {
                tungay.ReadOnly = false;
                denngay.ReadOnly = false;
            }
            else
            {
                if (chu == "Tháng") //vietnam
                {
                    if (chieudai == 7)
                    {
                        so = time.Substring(6, 1);

                    }
                    else if (chieudai == 8)
                    {
                        so = time.Substring(6, 2);
                    }
                    else
                    {
                        int month = DateTime.Now.Month;
                        if (month < 10)
                        {
                            so = "0" + month;
                        }
                        else
                        {
                            so = month.ToString();
                        }
                    }
                    ngay = new DateTime(DateTime.Now.Year, int.Parse(so), 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, int.Parse(so), DateTime.DaysInMonth(DateTime.Now.Year, int.Parse(so)));
                    denngay.DateTime = ngay;
                }

                //              
                if (thoigian.Text == "Quý 1")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 3, DateTime.DaysInMonth(DateTime.Now.Year, 3));
                    denngay.DateTime = ngay;

                }
                else if (thoigian.Text == "Quý 2")
                {
                    ngay = new DateTime(DateTime.Now.Year, 4, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "Quý 3")
                {
                    ngay = new DateTime(DateTime.Now.Year, 7, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 9, DateTime.DaysInMonth(DateTime.Now.Year, 9));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "Quý 4")
                {
                    ngay = new DateTime(DateTime.Now.Year, 10, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "6 Tháng Đầu Năm")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "6 Tháng Cuối Năm")
                {
                    ngay = new DateTime(DateTime.Now.Year, 7, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.DateTime = ngay;
                }
                else if (thoigian.Text == "Cả Năm")
                {
                    ngay = new DateTime(DateTime.Now.Year, 1, 1);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
                    denngay.DateTime = ngay;
                }

                else if (thoigian.Text == "Hôm Nay")
                {
                    ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    tungay.DateTime = ngay;
                    ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    denngay.DateTime = ngay;
                }
                search();
                tungay.ReadOnly = true;
                denngay.ReadOnly = true;
            }
        }

        private void frmmop_Load(object sender, EventArgs e)
        {
            thoigian.Text = "Tháng Này";
            changetime();
        }

        private void thoigian_SelectedIndexChanged(object sender, EventArgs e)
        {
            changetime();
        }
    }
}