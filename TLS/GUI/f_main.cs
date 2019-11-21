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
using DevExpress.XtraBars;
using DAL;
using BUS;
using ControlLocalizer;
using DevExpress.XtraBars.Ribbon;
using System.Reflection;
using System.Diagnostics;
using GUI.Report.Xuat;
namespace GUI
{
    public partial class f_main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_chucnang t_cn = new t_chucnang();
        
        //moi 15/10
        //public void setFontRibbon(RibbonControl ribbonControl)
        //{
        //    foreach (RibbonPage page in ribbonControl.Pages)
        //    {
        //        page.Appearance.Font = new System.Drawing.Font("Saysettha OT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        foreach (RibbonPageGroup g in page.Groups)
        //        {
        //            //ko co font 
        //            foreach (BarItemLink i in g.ItemLinks)
        //            {
        //                i.Item.ItemAppearance.Normal.Font = new System.Drawing.Font("Saysettha OT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //                if (i.Item is BarSubItem)
        //                {
        //                    var sub = i.Item as BarSubItem;
        //                    sub.Enabled = true;
        //                    foreach (BarItemLink y in sub.ItemLinks)
        //                    {
        //                        y.Item.ItemAppearance.Normal.Font = new System.Drawing.Font("Saysettha OT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        void OpenForm<T>()
        {
            var fm = MdiChildren.FirstOrDefault(f => f is T);
            if (fm == null)
            {
                fm = Activator.CreateInstance<T>() as Form;// tao đối tượng T thôi
                fm.MdiParent = this;
                fm.Show();
            }
            else
                fm.Activate();
        }
        public f_main()
        {
            InitializeComponent();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
        }
        private void f_main_Load(object sender, EventArgs e)
        {
            DangNhap();
           
        }
        private void DangNhap()
        {
            // dang xuat
            foreach (Form form in MdiChildren)
                form.Close();
            db.Dispose();
            db = new KetNoiDBDataContext();
            // dang nhap
            var f = new f_login();
            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    this.WindowState = FormWindowState.Maximized;
                    if (Biencucbo.idnv.Trim() != "AD")
                    {
                        btnskinht.Visibility = BarItemVisibility.Never;
                    }
                    var lst = (from a in db.skins select a).Single(t => t.trangthai == true);
                    Biencucbo.skin = lst.tenskin;
                    defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
                    //code moi 

                    try
                    {
                        this.Show();
                        try
                        {
                            var lsta = (from a in db.accounts select a).Single(t => t.id == Biencucbo.idnv);
                            if (lsta.phongban == "Cashier")
                            {
                                f_floor frm = new f_floor();
                                frm.ShowDialog();
                            }
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {
                        Application.Exit();
                    }
                    LanguageHelper.Language = (ControlLocalizer.LanguageEnum)Biencucbo.ngonngu;
                    changeFont.Translate(this);
                    changeFont.Translate(ribbon);
                    LanguageHelper.Active(LanguageHelper.Language);
                    LanguageHelper.Translate(this);
                    LanguageHelper.Translate(ribbon);
                    this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "PetroLao Co.,Ltd").ToString();
                    var lst2 = (from a in db.donvis where a.id == Biencucbo.donvi select a.tendonvi).FirstOrDefault();
                    Biencucbo.tendvbc = lst2.ToString();
                    btninfo_account.Caption = LanguageHelper.TranslateMsgString("." + Name + "_btn_Wellcome", "Wellcome ") + Biencucbo.ten;
                    btninfo_donvi.Caption = LanguageHelper.TranslateMsgString("." + Name + "_btn_DonVi", "Đơn vị ") + Biencucbo.donvi + "-" + Biencucbo.tendvbc;
                    btninfo_phong.Caption = LanguageHelper.TranslateMsgString("." + Name + "_btn_BoPhan", "Bộ phận ") + Biencucbo.phongban;
                    btnDb.Caption = Biencucbo.DbName;
                    btnVersion.Caption = LanguageHelper.TranslateMsgString("." + Name + "_btn_Version", "Version ") +
                    Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    // duyet ribbon
                    duyetRibbon(ribbon);
                    if (Biencucbo.ngonngu.ToString() == "Lao")
                    {
                        this.Font =
                        btninfo_account.ItemAppearance.Normal.Font =
                        btninfo_account.ItemAppearance.Disabled.Font =
                        btninfo_account.ItemAppearance.Hovered.Font =
                        btninfo_account.ItemAppearance.Pressed.Font =
                        btninfo_donvi.ItemAppearance.Normal.Font =
                        btninfo_donvi.ItemAppearance.Disabled.Font =
                        btninfo_donvi.ItemAppearance.Hovered.Font =
                        btninfo_donvi.ItemAppearance.Pressed.Font =
                        btninfo_phong.ItemAppearance.Normal.Font =
                        btninfo_phong.ItemAppearance.Disabled.Font =
                        btninfo_phong.ItemAppearance.Hovered.Font =
                        btninfo_phong.ItemAppearance.Pressed.Font =
                        btnDb.ItemAppearance.Normal.Font =
                        btnDb.ItemAppearance.Disabled.Font =
                        btnDb.ItemAppearance.Hovered.Font =
                        btnDb.ItemAppearance.Pressed.Font =
                        btnVersion.ItemAppearance.Normal.Font =
                        btnVersion.ItemAppearance.Disabled.Font =
                        btnVersion.ItemAppearance.Hovered.Font =
                        btnVersion.ItemAppearance.Pressed.Font = changeFont.FontLao;
                    }
                }
                else
                    Application.ExitThread();
            }
            catch (Exception ex)
            { Lotus.MsgBox.ShowErrorDialog(ex.ToString()); }
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_account>();
        }
        public void duyetRibbon(RibbonControl ribbonControl)
        {
            {
                foreach (RibbonPage page in ribbonControl.Pages)
                {
                    t_cn.moi(page.Name, page.Text, string.Empty);
                    foreach (RibbonPageGroup g in page.Groups)
                    {
                        t_cn.moi(g.Name, g.Text, page.Name);
                        foreach (BarItemLink i in g.ItemLinks)
                        {
                            if (i.Item == btndangxuat) continue;
                            t_cn.moi(i.Item.Name, i.Item.Caption, g.Name);
                            // lay quyen
                            //var quyen = db.PhanQuyen2s
                            //    .FirstOrDefault(p => p.TaiKhoan == Biencucbo.idnv && p.ChucNang == i.Item.Name);
                            var quyen = db.PhanQuyen2s
                               .FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == i.Item.Name);
                            // cheat tài khoản quan tri
                            //if (Biencucbo.idnv == "AD")
                            if (Biencucbo.phongban == "Admin")
                            {
                                if (quyen == null)
                                {
                                    quyen = new PhanQuyen2();
                                    quyen.TaiKhoan = Biencucbo.phongban;
                                    quyen.ChucNang = i.Item.Name;
                                    quyen.Xem = quyen.Them = quyen.Sua = quyen.Xoa = true;
                                    db.PhanQuyen2s.InsertOnSubmit(quyen);
                                    db.SubmitChanges();
                                }
                            }
                            i.Item.Enabled = quyen == null ? false : Convert.ToBoolean(quyen.Xem);
                            // luu vào tag của nút tren ribbon de xu ly sau
                            i.Item.Tag = quyen;
                            if (i.Item is BarSubItem)
                            {
                                var sub = i.Item as BarSubItem;
                                sub.Enabled = true;
                                foreach (BarItemLink y in sub.ItemLinks)
                                {
                                    t_cn.moi(y.Item.Name, y.Item.Caption, i.Item.Name);
                                    // lay quyen
                                    //quyen = db.PhanQuyen2s
                                    //    .FirstOrDefault(p => p.TaiKhoan == Biencucbo.idnv && p.ChucNang == y.Item.Name);
                                    quyen = db.PhanQuyen2s
                                       .FirstOrDefault(p => p.TaiKhoan == Biencucbo.phongban && p.ChucNang == y.Item.Name);
                                    // cheat tài khoản quan tri
                                    //if (Biencucbo.idnv == "AD")
                                    if (Biencucbo.phongban == "Admin")
                                    {
                                        if (quyen == null)
                                        {
                                            quyen = new PhanQuyen2();
                                            //quyen.TaiKhoan = Biencucbo.idnv;
                                            quyen.TaiKhoan = Biencucbo.phongban;
                                            quyen.ChucNang = y.Item.Name;
                                            quyen.Xem = quyen.Them = quyen.Sua = quyen.Xoa = true;
                                            db.PhanQuyen2s.InsertOnSubmit(quyen);
                                            db.SubmitChanges();
                                        }
                                    }
                                    y.Item.Enabled = quyen == null ? false : Convert.ToBoolean(quyen.Xem);
                                    // luu vào tag của nút tren ribbon de xu ly sau
                                    y.Item.Tag = quyen;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            string a = Biencucbo.ngonngu.ToString();
            string dlg = "";
            if (a == "Vietnam") dlg = "Bạn muốn đăng xuất?";
            if (a == "Lao") dlg = "ທ່ານຕ້ອງການລົງຊື່ອອກບໍ່?";
            if (Lotus.MsgBox.ShowYesNoDialog(dlg) == DialogResult.Yes)
            {
                this.Hide();
                DangNhap();
                try
                {
                    this.Show();
                }
                catch
                {
                    Application.Exit();
                }
            }
        }
        private void btndoidv_ItemClick(object sender, ItemClickEventArgs e)
        {
            account ac = (from a in db.accounts select a).Single(t => t.name == Biencucbo.ten);
            Biencucbo.dvTen = ac.madonvi;
            f_doidv frm = new f_doidv();
            frm.ShowDialog();
            var lst2 = (from a in db.donvis select a).Single(t => t.id == Biencucbo.donvi);
            btninfo_donvi.Caption = Biencucbo.donvi + " - " + lst2.tendonvi.ToString();
        }
        private void btndonvi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_donvi>();
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_doituong frm = new f_doituong();
            frm.ShowDialog();
        }
        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_sanpham>();
        }
        private void btnNhomDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_nhomdoituong>();
        }
        private void btnpnhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_pnhapbh>();
        }
        private void btnskinht_ItemClick(object sender, ItemClickEventArgs e)
        {
            f_Skin frm = new f_Skin();
            frm.ShowDialog();
        }
        private void btnxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_pxuat>();
        }
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_pthu>();
        }
        private void btndoidonvi1_ItemClick(object sender, ItemClickEventArgs e)
        {
            account ac = (from a in db.accounts select a).Single(t => t.name == Biencucbo.ten);
            Biencucbo.dvTen = ac.madonvi;
            f_doidv frm = new f_doidv();
            frm.ShowDialog();
            var lst2 = (from a in db.donvis select a).Single(t => t.id == Biencucbo.donvi);
            btninfo_donvi.Caption = Biencucbo.donvi + " - " + lst2.tendonvi;
        }
        private void btnpchi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_pchi>();
        }
        private void btngiasp_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_giasp form = new f_giasp();
            form.ShowDialog();
        }
        private void btnsochitietnhapkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_chitietnhapkho>();
        }
        private void btnnhaptheokho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_nhaptheokho>();
        }
        private void btnsochitietxuatkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_chitietxuatkho>();
        }
        private void btnxuattheokho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_xuattheokho>();
        }
        private void btnnhapxuatton_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void btnbcchi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_chitietchi>();
        }
        private void btnthu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_chitietpthu>();
        }
        private void btnthuchi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_thuchi>();
        }
        private void btnctcnkh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_ctcnkh>();
        }
        private void btnctcnncc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_ctcnncc>();
        }
        private void btnthcnkh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_thcnkh>();
        }
        private void btnthcnncc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_thcnncc>();
        }
        //private void btndoanhthu_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
        //    Report.Nhap.f_doanhthu frm = new Report.Nhap.f_doanhthu();
        //    frm.ShowDialog();
        //}
        private void btnnhapxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_chitietnhapxuat>();
        }
        private void btnhis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_History frm = new f_History();
            frm.ShowDialog();
        }
        private void btnngonngu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            LanguageHelper.ShowTranslateTool();
        }
        private void f_main_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
        }
        private void btnclose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Lotus.MsgBox.ShowYesNoCancelDialog("Bạn muốn thoát phần mềm?") == DialogResult.Yes)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
                db.Dispose();
                Application.Exit();
            }
        }
        private void btnmize_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btndanhmuctaikhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dmtk>();
        }
        private void btnphanquyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            //OpenForm<FrmPhanQuyen>();
            OpenForm<frmPhanQuyenChucNang>();
        }
        private void btnketquakd_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_kqkd>();
        }
        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            //OpenForm<f_banhang>();
            OpenForm<f_tiente>();
        }
        private void btnkiemke_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_banhang>();
        }
        private void btnChuyenTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_noptienCN>();
        }
        private void btnTeamviewer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Process.Start("tv.exe");
            }
            catch
            {
                XtraMessageBox.Show("Please setup Teamviewer !");
            }
        }
        private void btnHopDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_hopdong>();
        }
        private void btnhd_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_hd>();
        }
        private void btnphanbo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_phanbo>();
        }
        private void btngiavon_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_chaygiavon>();
        }
        private void btnbaoco_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_baono>();
        }
        private void btnbaono_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_baoco>();
        }
        private void btnhdmb_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.hddv = 2;
            f_dshddv frm = new f_dshddv();
            frm.ShowDialog();
        }
        private void btnpkt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_pkt>();
        }
        private void btnchinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_chitietbaoco>();
        }
        private void btnnxt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_tonkho>();
        }
        private void btnthunh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_chitietbaono>();
        }
        private void btnsocttk_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_sochitiettaikhoan>();
        }
        private void btnsonhatkychung_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_sonhatkychung>();
        }
        private void btnsocai_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_socai>();
        }
        private void btntkcongno_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_sochitiettaikhoancongno>();
        }
        private void btnbangcandoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_BangcandoiPSketoan>();
            //Report.Nhap.f_BangcandoiPSketoan frm = new Report.Nhap.f_BangcandoiPSketoan();
            //frm.ShowDialog();
        }
        private void btnbangtonghoppscongno_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_bangtonghopphatsinhcongno>();
        }
        private void btnthetscd_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_thets>();
        }
        private void btntinhkh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_tinhkhauhao frm = new f_tinhkhauhao();
            frm.ShowDialog();
        }
        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_ketchuyentk>();
        }
        private void btncandoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            //Report.Nhap.f_bangcandoiketoan frm = new Report.Nhap.f_bangcandoiketoan();
            //frm.ShowDialog();
            OpenForm<Report.Nhap.f_bangcandoiketoan>();
        }
        private void btndstscd_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.checkts = 0;
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_dsthets frm = new f_dsthets();
            frm.ShowDialog();
        }
        private void btnthongke_line_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_thongke frm = new f_thongke();
            frm.ShowDialog();
        }
        private void btnthongke_column_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_thongketong frm = new f_thongketong();
            frm.ShowDialog();
        }
        private void btnsqnganhang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_quynganhang>();
        }
        private void btnpgiam_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_pgiam>();
        }
        private void btnbclctt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_baocaolctt>();
        }
        private void btnsodubd_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dssodubd>();
        }
        private void btncttknt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_sochitiettaikhoannt>();
        }

        private void btnnhansu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_dsnhansu>();
        }

        private void btnmatutang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_tudong frm = new f_tudong();
            frm.ShowDialog();
        }

        private void btndoituongbh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_doituongbh frm = new f_doituongbh();
            frm.ShowDialog();
        }

        private void btntientebh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            //OpenForm<f_banhang>();
            OpenForm<f_tientebh>();
        }

        private void btnnhapbh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<f_pnhapbh>();
        }

        private void btndthc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_thongkecot frm = new f_thongkecot();
            frm.ShowDialog();
        }

        private void btnhinhtron_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_thongketron frm = new f_thongketron();
            frm.ShowDialog();
        }

        private void btnbcbanhang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_bcchitietbh>();
        }

        private void btnnhapquy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_thutiennhapquy frm = new f_thutiennhapquy();
            frm.ShowDialog();
        }

        private void btnnoptien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_noptienquy frm = new f_noptienquy();
            frm.ShowDialog();
        }

        private void btnquy_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_thuchibh>();
        }

        private void bcthbanhang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<Report.Nhap.f_bctonghpbh>();

        }

        private void f_main_Activated(object sender, EventArgs e)
        {
            var lst = (from a in new KetNoiDBDataContext().skins select a).Single(t => t.trangthai == true);
            Biencucbo.skin = lst.tenskin;
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
        }

        private void btnkhoaso_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            f_khoaso frm = new f_khoaso();
            frm.ShowDialog();
        }

        private void btndmvean_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<foodcourt.f_dmvean>();
        }

        private void btnxuatvean_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<foodcourt.f_pxuatvean>();
        }

        private void btnpnhapvean_ItemClick(object sender, ItemClickEventArgs e)
        {
            Biencucbo.QuyenDangChon = e.Item.Tag as PhanQuyen2;
            OpenForm<foodcourt.f_pnhapvean>();}
    }
}
