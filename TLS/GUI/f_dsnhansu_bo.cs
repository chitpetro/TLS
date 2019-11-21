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
using GUI.Properties;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI
{
    public partial class f_dsnhansu_bo : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_dsnhansu_bo()
        {
            InitializeComponent();
            var lst = (from a in new KetNoiDBDataContext().nhansus
                       select new
                       {
                           a.id,
                           a.chucvu,
                           a.cmnd,
                           a.email,
                           a.ghichu,
                           a.gioitinh,
                           a.hinhanh,
                           a.hovaten,
                           a.idphong,
                           a.ngaycapcmnd,
                           a.ngayhethanpp,
                           a.ngaysinh,
                           a.ngaythuviec,
                           a.ngayvaolam,
                           a.passport,
                           a.quequan,
                           a.quoctich,
                           a.sodienthoai,
                           a.sohdld,
                           a.tinhtrang,

                       });
            gcontrol.DataSource = lst;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        bool dble;
        private void gview_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void f_dsnhansu_Load(object sender, EventArgs e)
        {
            var lst = (from a in new KetNoiDBDataContext().nhansus
                       select new
                       {
                           a.id,
                           a.chucvu,
                           a.cmnd,
                           a.email,
                           a.ghichu,
                           a.gioitinh,
                           a.hinhanh,
                           a.hovaten,
                           a.idphong,
                           a.ngaycapcmnd,
                           a.ngayhethanpp,
                           a.ngaysinh,
                           a.ngaythuviec,
                           a.ngayvaolam,
                           a.passport,
                           a.quequan,
                           a.quoctich,
                           a.sodienthoai,
                           a.sohdld,
                           a.tinhtrang,

                       });
            gcontrol.DataSource = lst;
        }

        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdns = 1;
            f_nhansu frm = new f_nhansu();
            frm.ShowDialog();
            Biencucbo.hdns = 2;
            var lst = (from a in new KetNoiDBDataContext().nhansus
                       select new
                       {
                           a.id,
                           a.chucvu,
                           a.cmnd,
                           a.email,
                           a.ghichu,
                           a.gioitinh,
                           a.hinhanh,
                           a.hovaten,
                           a.idphong,
                           a.ngaycapcmnd,
                           a.ngayhethanpp,
                           a.ngaysinh,
                           a.ngaythuviec,
                           a.ngayvaolam,
                           a.passport,
                           a.quequan,
                           a.quoctich,
                           a.sodienthoai,
                           a.sohdld,
                           a.tinhtrang,

                       });
            gcontrol.DataSource = lst;
        }

        private void gview_RowClick(object sender, RowClickEventArgs e)
        {
            if (dble == true)
            {


                try
                {
                    Biencucbo.hdns = 0;
                    Biencucbo.ma = gview.GetFocusedRowCellValue("id").ToString();
                    Biencucbo.tenns = gview.GetFocusedRowCellValue("hovaten").ToString();

                    f_nhansu frm = new f_nhansu();
                    frm.ShowDialog();
                    Biencucbo.hdns = 2;
                    var lst = (from a in new KetNoiDBDataContext().nhansus
                               select new
                               {
                                   a.id,
                                   a.chucvu,
                                   a.cmnd,
                                   a.email,
                                   a.ghichu,
                                   a.gioitinh,
                                   a.hinhanh,
                                   a.hovaten,
                                   a.idphong,
                                   a.ngaycapcmnd,
                                   a.ngayhethanpp,
                                   a.ngaysinh,
                                   a.ngaythuviec,
                                   a.ngayvaolam,
                                   a.passport,
                                   a.quequan,
                                   a.quoctich,
                                   a.sodienthoai,
                                   a.sohdld,
                                   a.tinhtrang,

                               });
                    gcontrol.DataSource = lst;

                }
                catch
                {

                }
            }
            try
            {
                var lst = (from a in new KetNoiDBDataContext().nhansus select a).Single(t => t.id == gview.GetFocusedRowCellValue("id").ToString());
                try
                {
                    ImageConverter objfile = new ImageConverter();
                    hinhanh.Image = (Image)objfile.ConvertFrom(lst.hinhanh.ToArray());
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {

                    hinhanh.Image = Resources.Personnel_icon;
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                }


                id.Text = "<b>Id: </b>" + lst.id;

                hovaten.Text = "<b>Name: </b>" + lst.hovaten;
                ngaysinh.Text = "<b>Birthday: </b>" + lst.ngaysinh;
                gioitinh.Text = "<b>Sex: </b>" + lst.gioitinh;
                phongban.Text = "<b>Department: </b>" + lst.idphong;
                chucvu.Text = "<b>Position: </b>" + lst.chucvu;
                email.Text = "<b>Email: </b>" + lst.email;
                dienthoai.Text = "<b>Phone: </b>" + lst.sodienthoai;
                quoctich.Text = "<b>Nationality: </b>" + lst.quoctich;
            }
            catch
            {
                hinhanh.Image = Resources.Personnel_icon;
                hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;

                id.Text = "<b>Id: </b>";
                hovaten.Text = "<b>Name: </b>";
                ngaysinh.Text = "<b>Birthday: </b>";
                gioitinh.Text = "<b>Sex: </b>";
                phongban.Text = "<b>Department: </b>";
                chucvu.Text = "<b>Position: </b>";
                email.Text = "<b>Email: </b>";
                dienthoai.Text = "<b>Phone: </b>";
                quoctich.Text = "<b>Nationality: </b>";
            }

        }

        private void gview_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Biencucbo.hdns = 0;
                Biencucbo.ma = gview.GetFocusedRowCellValue("id").ToString();
                Biencucbo.tenns = gview.GetFocusedRowCellValue("hovaten").ToString();
                f_nhansu frm = new f_nhansu();
                frm.ShowDialog();
                Biencucbo.hdns = 2;
                var lst2 = (from a in new KetNoiDBDataContext().nhansus
                           select new
                           {
                               a.id,
                               a.chucvu,
                               a.cmnd,
                               a.email,
                               a.ghichu,
                               a.gioitinh,
                               a.hinhanh,
                               a.hovaten,
                               a.idphong,
                               a.ngaycapcmnd,
                               a.ngayhethanpp,
                               a.ngaysinh,
                               a.ngaythuviec,
                               a.ngayvaolam,
                               a.passport,
                               a.quequan,
                               a.quoctich,
                               a.sodienthoai,
                               a.sohdld,
                               a.tinhtrang,

                           });
                gcontrol.DataSource = lst2;
                try
                {
                    var lst = (from a in new KetNoiDBDataContext().nhansus select a).Single(t => t.id == gview.GetFocusedRowCellValue("id").ToString());
                    try
                    {
                        ImageConverter objfile = new ImageConverter();
                        hinhanh.Image = (Image)objfile.ConvertFrom(lst.hinhanh.ToArray());
                        hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch
                    {

                        hinhanh.Image = Resources.Personnel_icon;
                        hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }


                    id.Text = "<b>Id: </b>" + lst.id;

                    hovaten.Text = "<b>Name: </b>" + lst.hovaten;
                    ngaysinh.Text = "<b>Birthday: </b>" + lst.ngaysinh;
                    gioitinh.Text = "<b>Sex: </b>" + lst.gioitinh;
                    phongban.Text = "<b>Department: </b>" + lst.idphong;
                    chucvu.Text = "<b>Position: </b>" + lst.chucvu;
                    email.Text = "<b>Email: </b>" + lst.email;
                    dienthoai.Text = "<b>Phone: </b>" + lst.sodienthoai;
                    quoctich.Text = "<b>Nationality: </b>" + lst.quoctich;
                }
                catch
                {
                    hinhanh.Image = Resources.Personnel_icon;
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;

                    id.Text = "<b>Id: </b>";
                    hovaten.Text = "<b>Name: </b>";
                    ngaysinh.Text = "<b>Birthday: </b>";
                    gioitinh.Text = "<b>Sex: </b>";
                    phongban.Text = "<b>Department: </b>";
                    chucvu.Text = "<b>Position: </b>";
                    email.Text = "<b>Email: </b>";
                    dienthoai.Text = "<b>Phone: </b>";
                    quoctich.Text = "<b>Nationality: </b>";
                }

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

        private void gview_GotFocus(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().nhansus select a).Single(t => t.id == gview.GetFocusedRowCellValue("id").ToString());
                try
                {
                    ImageConverter objfile = new ImageConverter();
                    hinhanh.Image = (Image)objfile.ConvertFrom(lst.hinhanh.ToArray());
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {

                    hinhanh.Image = Resources.Personnel_icon;
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                }


                id.Text = "<b>Id: </b>" + lst.id;

                hovaten.Text = "<b>Name: </b>" + lst.hovaten;
                ngaysinh.Text = "<b>Birthday: </b>" + lst.ngaysinh;
                gioitinh.Text = "<b>Sex: </b>" + lst.gioitinh;
                phongban.Text = "<b>Department: </b>" + lst.idphong;
                chucvu.Text = "<b>Position: </b>" + lst.chucvu;
                email.Text = "<b>Email: </b>" + lst.email;
                dienthoai.Text = "<b>Phone: </b>" + lst.sodienthoai;
                quoctich.Text = "<b>Nationality: </b>" + lst.quoctich;
            }
            catch
            {
                hinhanh.Image = Resources.Personnel_icon;
                hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;

                id.Text = "<b>Id: </b>";
                hovaten.Text = "<b>Name: </b>";
                ngaysinh.Text = "<b>Birthday: </b>";
                gioitinh.Text = "<b>Sex: </b>";
                phongban.Text = "<b>Department: </b>";
                chucvu.Text = "<b>Position: </b>";
                email.Text = "<b>Email: </b>";
                dienthoai.Text = "<b>Phone: </b>";
                quoctich.Text = "<b>Nationality: </b>";
            }
        }

        private void gview_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gview_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().nhansus select a).Single(t => t.id == gview.GetFocusedRowCellValue("id").ToString());
                try
                {
                    ImageConverter objfile = new ImageConverter();
                    hinhanh.Image = (Image)objfile.ConvertFrom(lst.hinhanh.ToArray());
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {

                    hinhanh.Image = Resources.Personnel_icon;
                    hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                }


                id.Text = "<b>Id: </b>" + lst.id;

                hovaten.Text = "<b>Name: </b>" + lst.hovaten;
                ngaysinh.Text = "<b>Birthday: </b>" + lst.ngaysinh;
                gioitinh.Text = "<b>Sex: </b>" + lst.gioitinh;
                phongban.Text = "<b>Department: </b>" + lst.idphong;
                chucvu.Text = "<b>Position: </b>" + lst.chucvu;
                email.Text = "<b>Email: </b>" + lst.email;
                dienthoai.Text = "<b>Phone: </b>" + lst.sodienthoai;
                quoctich.Text = "<b>Nationality: </b>" + lst.quoctich;
            }
            catch
            {
                hinhanh.Image = Resources.Personnel_icon;
                hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;

                id.Text = "<b>Id: </b>";
                hovaten.Text = "<b>Name: </b>";
                ngaysinh.Text = "<b>Birthday: </b>";
                gioitinh.Text = "<b>Sex: </b>";
                phongban.Text = "<b>Department: </b>";
                chucvu.Text = "<b>Position: </b>";
                email.Text = "<b>Email: </b>";
                dienthoai.Text = "<b>Phone: </b>";
                quoctich.Text = "<b>Nationality: </b>";
            }
        }

        private void gview_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void btnfile_Click(object sender, EventArgs e)
        {
            Biencucbo.ma = gview.GetFocusedRowCellValue("id").ToString();
            f_showhoso frm = new f_showhoso();
         
            frm.ShowDialog();
        }
    }
}