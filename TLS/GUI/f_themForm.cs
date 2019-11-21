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
using ControlLocalizer;
using System.IO;
using System.Data.SqlClient;
using DevExpress.XtraPrinting.Export.Pdf;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.Utils.OAuth.Provider;
using System.Data.Linq;
using System.Diagnostics;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Views.Grid;
namespace GUI
{
    public partial class f_themForm : Form
    {
        
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_tudong td = new t_tudong();
        string a = "";
        public f_themForm()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            txtid.ReadOnly = true;
            txtname.ReadOnly = true;
            txtlink.ReadOnly = true;
            txtdiengiai.ReadOnly = true;
            btnluu.Enabled = false;
        }
        private void f_themaccount_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm File").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            load();
        }
        private void load()
        {
            var lst = from a in db.filehds
                      join b in db.hopdongs
                      on a.idhopdong equals b.id
                      where a.idhopdong == Biencucbo.hopdong
                      select new
                      {
                          b.sohd,
                          a.formName,
                          a.diengiai,
                          a.id,
                      };
            gridControl1.DataSource = lst;
        }
        //nút upload file
        OpenFileDialog openfile = new OpenFileDialog();
        //nut chon file
        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            openfile.Title = "Chọn File";
            //openfile.InitialDirectory = @"c:\Program Files";//Thư mục mặc định khi mở
            openfile.Filter = "Pdf Files|*.pdf";
            openfile.FilterIndex = 1;//chúng ta có All files là 1,exe là 2
            openfile.RestoreDirectory = true;
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                txtlink.Text = openfile.FileName;
                txtname.Text = openfile.FileName.Substring(openfile.FileName.LastIndexOf('\\') + 1);
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen2));
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            pdfViewer1.CloseDocument();
            string a1 = gridView1.GetFocusedRowCellValue("id").ToString();
            var lst = (from a in db.filehds select a).Single(x => x.id == a1);
            byte[] filedata = lst.formData.ToArray();
            MemoryStream str = new MemoryStream(filedata, true);
            pdfViewer1.HandTool = true;
            pdfViewer1.LoadDocument(str);
            SplashScreenManager.CloseForm();
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
        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Biencucbo.fhd == 0)
            {
                if (txtlink.Text == "")
                    return;
                db = new KetNoiDBDataContext();
                try
                {
                    string check = "FHD" + Biencucbo.donvi.Trim().ToString();
                    var lst1 = (from s in db.tudongs where s.maphieu == check select new { so = s.so, s.maphieu }).ToList();
                    if (lst1.Count == 0)
                    {
                        int so;
                        so = 2;
                        td.themtudong(check, so,"FHD","File");
                        txtid.Text = check + "_000001";
                        a = "1";
                    }
                    else
                    {
                        var lst = (from b in lst1 select b).Single(t => t.maphieu == check);
                        int k;
                        //txt1.DataBindings.Clear();
                        //txt1.DataBindings.Add("text", lst1, "so");
                        a = lst.so.ToString();
                        k = 0;
                        k = Convert.ToInt32(a);
                        string so0 = "";
                        if (k < 10)
                        {
                            so0 = "00000";
                        }
                        else if (k >= 10 & k < 100)
                        {
                            so0 = "0000";
                        }
                        else if (k >= 100 & k < 1000)
                        {
                            so0 = "000";
                        }
                        else if (k >= 1000 & k < 10000)
                        {
                            so0 = "00";
                        }
                        else if (k >= 10000 & k < 100000)
                        {
                            so0 = "0";
                        }
                        else if (k >= 100000)
                        {
                            so0 = "";
                        }
                        txtid.Text = check + "_" + so0 + k;
                        k = k + 1;
                        td.suatudong(check, k);
                    }
                    byte[] file = null;
                    if (!string.IsNullOrEmpty(txtname.Text))
                    {
                        using (var stream = new FileStream(txtlink.Text, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                file = reader.ReadBytes((int)stream.Length);
                            }
                        }
                    }
                    var filehd = new filehd()
                    {
                        id = txtid.Text,
                        formName = txtname.Text,
                        formData = file,
                        //diengiai = txtlink.Text,
                        diengiai = txtdiengiai.Text,
                        idhopdong = Biencucbo.hopdong,
                    };
                    db.filehds.InsertOnSubmit(filehd);
                    db.SubmitChanges();
                    txtlink.Text = "";
                    txtname.Text = "";
                    txtdiengiai.Text = "";
                    txtid.Text = "";
                    load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                btnthem.Enabled = true;
                btnsua.Enabled = true;
                btnxoa.Enabled = true;
                btnluu.Enabled = false;
                btnreload.Enabled = true;
            }
            // else //nut sua
            if (Biencucbo.fhd == 1)
            {
                byte[] file = null;
                if (!string.IsNullOrEmpty(txtlink.Text))
                {
                    using (var stream = new FileStream(txtlink.Text, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            file = reader.ReadBytes((int)stream.Length);
                        }
                    }
                }
                string a1 = gridView1.GetFocusedRowCellValue("id").ToString();
                var filehd = db.filehds.FirstOrDefault(x => x.id == a1);
                if (filehd != null)
                {
                    filehd.formName = txtname.Text;
                    //filehd.formData = file;
                    filehd.diengiai = txtdiengiai.Text;
                    filehd.idhopdong = Biencucbo.hopdong;
                    if (file != null)
                        filehd.formData = file;
                    db.SubmitChanges();
                    XtraMessageBox.Show("Sửa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
            }
        }
        private void btnsua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.fhd = 1;
            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnreload.Enabled = true;
            txtid.ReadOnly = false;
            txtname.ReadOnly = false;
            txtlink.ReadOnly = false;
            txtdiengiai.ReadOnly = false;
            string id = gridView1.GetFocusedRowCellValue("id").ToString();
            var Lst = (from dt in db.filehds where dt.id == id select dt).ToList();
            txtid.DataBindings.Clear();
            txtname.DataBindings.Clear();
            txtlink.DataBindings.Clear();
            txtdiengiai.DataBindings.Clear();
            txtid.DataBindings.Add("text", Lst, "id");
            txtid.Text.Trim();
            txtname.DataBindings.Add("text", Lst, "formName".Trim());
            //txtlink.DataBindings.Add("text", Lst, "idhopdong".Trim());
            txtdiengiai.DataBindings.Add("text", Lst, "diengiai".Trim());
        }
        private void btnxoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Lotus.MsgBox.ShowYesNoCancelDialog("Bạn có chắc chắn muốn xóa File này không?") == DialogResult.Yes)
            {
                string a1 = gridView1.GetFocusedRowCellValue("id").ToString();
                filehd fhd = (from tb in db.filehds select tb).Single(t => t.id == a1);
                db.filehds.DeleteOnSubmit(fhd);
                db.SubmitChanges();
                load();
            }
        }
        //nút thêm
        private void btnthem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.fhd = 0;
            txtid.ReadOnly = false;
            txtname.ReadOnly = false;
            txtlink.ReadOnly = false;
            txtdiengiai.ReadOnly = false;
            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnreload.Enabled = true;
        }
        //nut reload
        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db = new KetNoiDBDataContext();
            txtid.Text = "";
            txtname.Text = "";
            txtlink.Text = "";
            txtdiengiai.Text = "";
            txtid.ReadOnly = true;
            txtname.ReadOnly = true;
            txtlink.ReadOnly = true;
            txtdiengiai.ReadOnly = true;
            //btn
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            btnmo.Enabled = true;
            btnxoa.Enabled = true;
            btnreload.Enabled = false;
            Biencucbo.fhd = 2;
        }

        private void txtlink_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
