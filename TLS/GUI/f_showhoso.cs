using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL;
using BUS;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI
{
    public partial class f_showhoso : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_showhoso()
        {
            InitializeComponent();
            this.CenterToScreen();
            var lst = (from a in db.filenhansus where a.idns == Biencucbo.ma select a);
            gcontrol.DataSource = lst;
        }

        private void f_showhoso_Load(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in db.nhansus select a).Single(t => t.id == Biencucbo.ma);

                lbltt.Text = "<b>- Mã NV: </b>" + lst.id + ".";
                lbtt2.Text = "<b>- Họ Và Tên: </b>" + lst.hovaten + ".";
                lbtt3.Text = "<b>- Phòng Ban :</b>" + lst.idphong + ".";
                lbtt4.Text = "<b>- Chức Vụ: </b>" + lst.chucvu + ".";

                ImageConverter objfile = new ImageConverter();
                hinhanh.Image = (Image)objfile.ConvertFrom(lst.hinhanh.ToArray());
                hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {

            }

        }
        bool dble;
        private void gview_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void gview_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void gview_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (dble == true)
            {
                try

                {
                    var lst = (from a in db.filenhansus select a).Single(t => t.id == gview.GetFocusedRowCellValue("id").ToString());
                    byte[] file = lst.data.ToArray();
                    string tmpPath = Application.StartupPath + "\\tmp";
                    if (!Directory.Exists(tmpPath))
                        Directory.CreateDirectory(tmpPath);

                    string tmpFile = tmpPath + "\\" + lst.id + lst.name;
                    File.WriteAllBytes(tmpFile, file);

                    Process.Start(tmpFile);
                }
                catch
                {

                }
            }
        }
        SaveFileDialog savefile = new SaveFileDialog();
        private void btntai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var row = gview.GetFocusedRow() as DAL.filenhansu;
                if (row == null) return;

                string a1 = row.id;
                var lst = (from a in db.filenhansus select a).Single(x => x.id == a1);
                byte[] filedata = lst.data.ToArray();

                //savefile.Title = lst.formName;
                savefile.FileName = lst.name;
                string tmpPath = savefile.InitialDirectory;
                savefile.FilterIndex = 1;
                savefile.RestoreDirectory = true;
                string file3 = "";
                savefile.Filter = "Files|*" + lst.type;
                if (savefile.ShowDialog() == DialogResult.OK)
                {


                    File.WriteAllBytes(savefile.FileName /*+ lst.diengiai*/, filedata);
                    file3 = savefile.FileName;
                }
                else
                    return;
                MessageBox.Show("Tải về Thành Công", "Thông Báo");
                if (MessageBox.Show("Bạn Có Muốn Mở File Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                var row2 = gview.GetFocusedRow() as DAL.filenhansu;
                if (row2 == null) return;

                string a2 = row2.id;
                var lst2 = (from a in db.filenhansus select a).Single(x => x.id == a2);
                byte[] filedata2 = lst2.data.ToArray();

                string tmpPath2 = Application.StartupPath + "\\tmp";
                if (!Directory.Exists(tmpPath2))
                    Directory.CreateDirectory(tmpPath2);

                //string tmpFile = tmpPath2 + "\\" + a2 + lst2.diengiai;
                //File.WriteAllBytes(tmpFile, filedata);

                Process.Start(file3);
            }
            catch
            {

            }
        }

        private void gview_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            if (!gview.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gview); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gview); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
    }
}