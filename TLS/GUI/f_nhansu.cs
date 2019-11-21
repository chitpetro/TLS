using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BUS;
using DAL;
using System.Linq;
using System.Diagnostics;
using System.Data.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI
{
    public partial class f_nhansu : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_nhansu ns = new t_nhansu();
        public f_nhansu()
        {
            InitializeComponent();
            txtphong.Properties.DataSource = new DAL.KetNoiDBDataContext().phongbans;
            txtchucvu.Properties.DataSource = new DAL.KetNoiDBDataContext().chucvus;
        }

        public byte[] file = null;
        private void btnsearchanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Chọn ảnh nhân viên";
            openfile.Filter = "jpg Files|*.jpg";
            openfile.FilterIndex = 1;
            openfile.RestoreDirectory = true;
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(openfile.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        file = reader.ReadBytes((int)stream.Length);
                        ImageConverter objfile = new ImageConverter();
                        hinhanh.Image = (Image)objfile.ConvertFrom(file);
                        hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;


                    }
                }

            }
        }

        private void btnmo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void f_nhansu_Load(object sender, EventArgs e)
        {

            if (Biencucbo.hdns == 0)
            {
                txtid.ReadOnly = true;
                try
                {
                    var lst = (from a in db.nhansus select a).Single(t => t.id == Biencucbo.ma);
                    txtid.Text = lst.id;
                    txthovaten.Text = lst.hovaten;
                    txtngaysinh.DateTime = DateTime.Parse(lst.ngaysinh.ToString());
                    txtdiachi.Text = lst.quequan;
                    txtquoctich.Text = lst.quoctich;
                    txtcmnd.Text = lst.cmnd;
                    txtngaycapcmnd.DateTime = DateTime.Parse(lst.ngaycapcmnd.ToString());
                    txtpassport.Text = lst.passport;
                    txtngayhethanpp.DateTime = DateTime.Parse(lst.ngayhethanpp.ToString());
                    txtphong.Text = lst.idphong;
                    txtchucvu.Text = lst.chucvu;
                    try
                    {
                        ImageConverter objfile = new ImageConverter();
                        hinhanh.Image = (Image)objfile.ConvertFrom(lst.hinhanh.ToArray());
                        hinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                        file = lst.hinhanh.ToArray();
                    }
                    catch
                    {

                    }
                    txtngayvaolam.DateTime = DateTime.Parse(lst.ngayvaolam.ToString());
                    txthdld.Text = lst.sohdld;
                    txtsodienthoai.Text = lst.sodienthoai;
                    txtghichu.Text = lst.ghichu;
                    txtgioitinh.Text = lst.gioitinh;
                    txtemail.Text = lst.email;
                    txttinhtrang.Text = lst.tinhtrang;
                    txtngaythuviec.DateTime = DateTime.Parse(lst.ngaythuviec.ToString());
                    gcontrol.DataSource = lst.filenhansus;
                }
                catch
                {

                }
            }
            else
            {

                txtid.Text = "";
                txthovaten.Text = "";
                txtngaysinh.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                txtdiachi.Text = "";
                txtquoctich.Text = "";
                txtcmnd.Text = "";
                txtngaycapcmnd.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                txtpassport.Text = "";
                txtngayhethanpp.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                txtphong.Text = "";
                txtchucvu.Text = "";
                txtngayvaolam.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                txthdld.Text = "";
                txtsodienthoai.Text = "";
                txtghichu.Text = "";
                txtgioitinh.Text = "";
                txtemail.Text = "";
                txttinhtrang.Text = "";
                txtngaythuviec.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                gcontrol.DataSource = db.View_nhansus;
            }
        }

        private void txtid_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtid.Text == "")
            //        return;
            //    var lst = (from a in db.nhansus where a.id == txtid.Text select a);
            //    if (lst.Count() != 0)
            //    {
            //        MessageBox.Show("Mã nhân viên này đã tồn tại - Vui lòng kiểm tra lại");
            //        txtid.Text = "";
            //        txtid.Focus();
            //    }
            //}
            //catch
            //{

            //}
        }

        private void txthovaten_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txthovaten.Text == "")
            //        return;
            //    var lst = (from a in db.nhansus where a.hovaten == txthovaten.Text select a);
            //    if (lst.Count() != 0)
            //    {
            //        MessageBox.Show("Tên nhân viên này đã tồn tại - Vui lòng kiểm tra lại");
            //        txtid.Text = "";
            //        txtid.Focus();
            //    }
            //}
            //catch
            //{

            //}
        }

        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (txtid.Text == "" || txthovaten.Text == "" /*|| txtgioitinh.Text == ""*/)
            {
                MessageBox.Show("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại", "THÔNG BÁO");
                return;
            }

            if (txtid.Text != Biencucbo.ma || txthovaten.Text != Biencucbo.tenns)
            {


                try
                {
                    if (txthovaten.Text == "")
                        return;
                    var lst = (from a in db.nhansus where a.hovaten == txthovaten.Text select a);
                    if (lst.Count() != 0)
                    {
                        MessageBox.Show("Tên nhân viên này đã tồn tại - Vui lòng kiểm tra lại");
                        txthovaten.Text = "";
                        txthovaten.Focus();
                        return;
                    }

                    if (txtid.Text == "")
                        return;
                    var lst2 = (from a in db.nhansus where a.hovaten == txthovaten.Text select a);
                    if (lst2.Count() != 0)
                    {
                        MessageBox.Show("Mã nhân viên này đã tồn tại - Vui lòng kiểm tra lại");
                        txtid.Text = "";
                        txtid.Focus();
                        return;
                    }
                }
                catch
                {

                }
            }


            try
            {
              var lst2 = (from a in db.nhansus where a.id == txtid.Text || a.hovaten == txthovaten.Text select a);
                if(lst2.Count() > 0)
                {
                    MessageBox.Show("Thông tin bị trùng lặp - Vui lòng kiểm tra lại", "THÔNG BÁO");
                    return;
                }
                
             
                if (Biencucbo.hdns == 1)
                {
                    ns.moins(txtid.Text, txthovaten.Text, txtngaysinh.DateTime, txtdiachi.Text, txtquoctich.Text, txtcmnd.Text, txtngaycapcmnd.DateTime, txtpassport.Text, txtngayhethanpp.DateTime, txtphong.Text, txtchucvu.Text, file, txtngayvaolam.DateTime, txthdld.Text, txtsodienthoai.Text, txtghichu.Text, txtgioitinh.Text, txtemail.Text, txttinhtrang.Text, txtngaythuviec.DateTime);
                    for (int i = 0; i < gview.DataRowCount; i++)
                    {

                        string tenfile = gview.GetRowCellValue(i, "name").ToString();
                        //string diengiai = gridView1.GetRowCellValue(i, "diengiai").ToString();


                        ns.moifile(txtid.Text + i, gview.GetRowCellValue(i, "idns").ToString(), tenfile, (Binary)gview.GetRowCellValue(i, "data"), gview.GetRowCellValue(i, "type").ToString(), gview.GetRowCellValue(i, "size").ToString());
                    }
                    try
                    {
                        db = new KetNoiDBDataContext();
                        var lst = (from a in db.nhansus select a).Single(t => t.id == txtid.Text);
                        gcontrol.DataSource = lst.filenhansus;
                        gridView1.UpdateCurrentRow();
                        gridView1.PostEditor();

                    }
                    catch
                    {

                    }
                    MessageBox.Show("Done.", "THÔNG BÁO");
                    Biencucbo.hdns = 2;
                    this.Close();
                }
                else
                {
                    ns.suans(txtid.Text, txthovaten.Text, txtngaysinh.DateTime, txtdiachi.Text, txtquoctich.Text, txtcmnd.Text, txtngaycapcmnd.DateTime, txtpassport.Text, txtngayhethanpp.DateTime, txtphong.Text, txtchucvu.Text, file, txtngayvaolam.DateTime, txthdld.Text, txtsodienthoai.Text, txtghichu.Text, txtgioitinh.Text, txtemail.Text, txttinhtrang.Text, txtngaythuviec.DateTime);
                    LuuPhieu();

                    MessageBox.Show("Done.", "THÔNG BÁO");
                    Biencucbo.hdns = 2;
                    this.Close();
                }
            }

           
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        bool LuuPhieu()
        {
            // kiem tra truoc khi luu
            layoutControl1.Validate();
            gview.CloseEditor();
            gview.UpdateCurrentRow();
            // if(kiem tra rang buoc)
            //  return false;
            try
            {
                var c1 = db.nhansus.Context.GetChangeSet();
                /* db.pnhaps.Context.SubmitChanges(); */// dang báo lỗi là vi không có thay đổi. kiem tra neu có thay doi hãy submit
                db.filenhansus.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private void btnhuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void txtlink_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Chọn File";

            openfile.FilterIndex = 1;//chúng ta có All files là 1,exe là 2
            openfile.RestoreDirectory = true;
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                txtlink.Text = openfile.FileName;
                txtfile.Text = openfile.FileName.Substring(openfile.FileName.LastIndexOf('\\') + 1);

                string ext = Path.GetExtension(txtfile.Text); // getting the file extension of uploaded file         
                txttype.Text = ext;
            }
        }

        private void btnxuong_Click(object sender, EventArgs e)
        {
            if (txtlink.Text == "")
                return;

            byte[] file3 = null;

            if (!string.IsNullOrEmpty(txtlink.Text))
            {
                using (var stream = new FileStream(txtlink.Text, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        file3 = reader.ReadBytes((int)stream.Length);
                    }
                }
            }


            System.Data.Linq.Binary file2 = file3;


            //Biencucbo.test = file3;
            var size = file3.Length / 1024;//kb

            //theem moi
            if (Biencucbo.hdns == 1)//them moi
            {
                gview.AddNewRow();
                gview.SetFocusedRowCellValue("name", txtfile.Text);
                gview.SetFocusedRowCellValue("type", txttype.Text);
                gview.SetFocusedRowCellValue("data", file2);
                gview.SetFocusedRowCellValue("size", size);
                gview.SetFocusedRowCellValue("idns", txtid.Text);
                gview.UpdateCurrentRow();
                gview.PostEditor();

                //test
                //byte a2 = Convert.ToByte(gridView1.GetFocusedRowCellValue("formData"));
                //System.Data.Linq.Binary a3 = a2;

            }
            else //sua
            {
                gview.AddNewRow();

                var ct = gview.GetFocusedRow() as filenhansu;
                if (ct == null) return;

                int i = 0, k = 0;
                string a;

                k = gview.DataRowCount;
                a = txtid.Text + k;

                for (i = 0; i <= gview.DataRowCount - 1;)
                {
                    if (a == gview.GetRowCellValue(i, "id").ToString())
                    {
                        k = k + 1;
                        a = txtid.Text + k;
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                ct.id = a;
                ct.name = txtfile.Text;
                ct.data = file2;
                ct.type = txttype.Text;
                ct.size = size.ToString();
                ct.idns = txtid.Text;
                gridView1.UpdateCurrentRow();
                gridView1.PostEditor();
            }

            txtfile.Text = "";
            txtlink.Text = "";
            txttype.Text = "";
        }
        bool dble ;
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
            if(dble == true)
            {
                try
                {
                    var row = gview.GetFocusedRow() as DAL.filenhansu;
                    if (row == null) return;

                    string a1 = row.id;
                    var lst = (from a in db.filenhansus select a).Single(x => x.id == a1);
                    byte[] filedata = lst.data.ToArray();

                    string tmpPath = Application.StartupPath + "\\tmp";
                    if (!Directory.Exists(tmpPath))
                        Directory.CreateDirectory(tmpPath);

                    string tmpFile = tmpPath + "\\" + a1 + lst.name;
                    File.WriteAllBytes(tmpFile, filedata);

                    Process.Start(tmpFile);
                }
                catch
                {

                }
            }
        }

        private void txthovaten_Leave(object sender, EventArgs e)
        {

        }

        private void f_nhansu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Biencucbo.ma = "";
            Biencucbo.tenns = "";
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

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                gview.DeleteRow(gview.FocusedRowHandle);
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn File chi tiết cần xóa", "Thông Báo!");
                return;
            }
        }

        private void gview_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (Biencucbo.hdpt != 1)
            {
                try
                {
                    filenhansu ct = (from c in db.filenhansus select c).Single(x => x.id == gview.GetFocusedRowCellValue("id").ToString());
                    db.filenhansus.DeleteOnSubmit(ct);
                }
                catch
                {
                }
            }
        }
        SaveFileDialog savefile = new SaveFileDialog();
        private void btntai_Click(object sender, EventArgs e)
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
    }
}
