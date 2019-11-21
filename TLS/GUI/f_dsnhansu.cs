﻿using System;
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
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class f_dsnhansu : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_dsnhansu()
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
            grcontrol.DataSource = lst;
        }

     
        bool dble;
    

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
            grcontrol.DataSource = lst;
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
            grcontrol.DataSource = lst;
        }

    

        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Biencucbo.hdns = 0;
                Biencucbo.ma = grview.GetFocusedRowCellValue("id").ToString();
                Biencucbo.tenns = grview.GetFocusedRowCellValue("hovaten").ToString();
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
                grcontrol.DataSource = lst2;
                try
                {
                    var lst = (from a in new KetNoiDBDataContext().nhansus select a).Single(t => t.id == grview.GetFocusedRowCellValue("id").ToString());
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


     

        private void btnfile_Click(object sender, EventArgs e)
        {
            Biencucbo.ma = grview.GetFocusedRowCellValue("id").ToString();
            f_showhoso frm = new f_showhoso();
         
            frm.ShowDialog();
        }

        private void grview_GotFocus(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().nhansus select a).Single(t => t.id == grview.GetFocusedRowCellValue("id").ToString());
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

        private void grview_Click(object sender, EventArgs e)
        {
            dble = false;
        }

        private void grview_DoubleClick(object sender, EventArgs e)
        {
            dble = true;
        }

        private void grview_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().nhansus select a).Single(t => t.id == grview.GetFocusedRowCellValue("id").ToString());
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

        private void grview_RowClick(object sender, RowClickEventArgs e)
        {
            if (dble == true)
            {


                try
                {
                    Biencucbo.hdns = 0;
                    Biencucbo.ma = grview.GetFocusedRowCellValue("id").ToString();
                    Biencucbo.tenns = grview.GetFocusedRowCellValue("hovaten").ToString();

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
                    grcontrol.DataSource = lst;

                }
                catch
                {

                }
            }
            try
            {
                var lst = (from a in new KetNoiDBDataContext().nhansus select a).Single(t => t.id == grview.GetFocusedRowCellValue("id").ToString());
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

        private void grview_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {


            if (!grview.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, grview); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, grview); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        public Image hinhanhc (System.Data.Linq.Binary a)
        {
            Image b;
            ImageConverter objfile = new ImageConverter();
            b = (Image)objfile.ConvertFrom(a.ToArray());
           
            return b;
        }
        private void btnin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lst = (from a in db.nhansus select new
            {
                a.id,
                a.hovaten,
                a.ngaysinh,
                a.idphong,
                a.chucvu,
               hinhanh =  hinhanhc(a.hinhanh),

            });
            Report.nhansu.r_nhansu_m xtra = new Report.nhansu.r_nhansu_m();
            xtra.DataSource = lst;
            xtra.ShowPreviewDialog();
        }
    }
}