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
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using GUI.Properties;
using DevExpress.Utils;
using DevExpress.XtraBars;

namespace GUI.foodcourt
{
    public partial class f_pxuatvean : frm.frmp
    {

        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        c_pxuatvean px = new c_pxuatvean();
        t_history hs = new t_history();
        /// <summary>
        /// 0: default
        /// 1: add
        /// 2: edit
        /// 3: coppy
        /// </summary>
        private int _hdong;

        private int _so;
        private string _key;
        private string _keytemp;
        private string _donvi = string.Empty;
        public f_pxuatvean()
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

        private bool kiemtra()
        {
            int checknull = 0;
            int checkve = 0;
            ngayxuatDateEdit.Properties.ContextImage = null;
            if (custom.checknulltext(ngayxuatDateEdit))
                checknull++;
            loaixuatComboBoxEdit.Properties.ContextImage = null;
            if (custom.checknulltext(loaixuatComboBoxEdit))
                checknull++;

            iddtSearchLookUpEdit.Properties.ContextImage = null;
            if (custom.checknulltext(iddtSearchLookUpEdit))
                checknull++;


            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }

            for (int i = 0; i < gv.DataRowCount; i++)
            {
                if (gv.GetRowCellValue(i, "idve").ToString() == string.Empty)
                {
                    checkve++;
                }
            }

            if (checkve > 0)
            {
                XtraMessageBox.Show("Không được để trống loại vé - Vui lòng kiểm tra lại", "THÔNG BÁO");
            }


            if (checkve > 0 || checknull > 0)
                return false;
            return true;
        }

        #region Lay du lieu tu searchlookup and textedit

        //don vi
        private void layttlblteniddv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().donvis select a).Single(t => t.id == id);
                lblteniddv.Text = lst.tendonvi;
            }
            catch (Exception ex)
            {
                lblteniddv.Text = "";
            }
        }

        // doi tuong
        private void layttlblteniddt(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().doituongbhs select a).Single(t => t.id == id);
                lblteniddt.Text = lst.ten;
            }
            catch (Exception ex)
            {
                lblteniddt.Text = "";
            }
        }

        // nhan vien

        private void layttlbltenidnv(string id)
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().accounts select a).Single(t => t.id == id);
                lbltenidnv.Text = lst.name;

                var lst2 = (from a in new KetNoiDBDataContext().phongbans select a).Single(t => t.id == lst.phongban);
                tenphongbanTextEdit.Text = lst2.ten;
            }
            catch (Exception ex)
            {
                lbltenidnv.Text = "";
                tenphongbanTextEdit.Text = string.Empty;
            }
        }





        #endregion

        #region Searchlookup_popup

        // Doi tuong
        private void iddtSearchLookUpEdit_Popup(object sender, EventArgs e)
        {
            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem)popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

            //btn edit
            var btnadd = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnadd.Click += btnadd_Click;

            // BTN load
            var btnreload = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreload.Click += btnreload_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;
            if (checkbtn)
            {
                myLCI.Control = btnadd;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreload;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtn = false;
            }
        }

        private bool checkbtn = true;

        private void loadsluiddtSearchLookUpEdit()
        {
            iddtSearchLookUpEdit.Properties.DataSource = (from a in new KetNoiDBDataContext().doituongbhs select a);
        }

        public void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban && t.ChucNang == "btndoituongbh");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_doituongbh();
            frm.ShowDialog();
            loadsluiddtSearchLookUpEdit();
            iddtSearchLookUpEdit.ShowPopup();
        }

        public void btnreload_Click(object sender, EventArgs e)
        {
            loadsluiddtSearchLookUpEdit();
            iddtSearchLookUpEdit.ShowPopup();
        }

        private static void txt_KeyUp(object sender, KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == Keys.Enter)
            {
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }
        // Loại Vé
        private void sidve_Popup(object sender, EventArgs e)
        {

            var form = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            var pop = form.Controls.OfType<SearchEditLookUpPopup>().FirstOrDefault();
            LayoutControl popupControl = pop.Controls.OfType<LayoutControl>().FirstOrDefault();
            Control clearBtn =
                popupControl.Controls.OfType<Control>().Where(ct => ct.Name == "btClear").FirstOrDefault();
            LayoutControlItem clearLCI = (LayoutControlItem)popupControl.GetItemByControl(clearBtn);
            LayoutControlItem myLCI = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);
            LayoutControlItem myrefresh = (LayoutControlItem)clearLCI.Owner.CreateLayoutItem(clearLCI.Parent);

            //btn edit
            var btnaddsidve = new SimpleButton
            {
                Image = Resources.edit_16x16,
                Text = "Add/Edit",
                BorderStyle = BorderStyles.Default
            };
            btnaddsidve.Click += btnaddsidve_Click;

            // BTN load
            var btnreloadsidve = new SimpleButton
            {
                Image = Resources.refresh_16x16,
                Text = "Refresh",
                BorderStyle = BorderStyles.Default
            };
            btnreloadsidve.Click += btnreloadsidve_Click;
            var edit = sender as SearchLookUpEdit;
            var popupForm = edit.GetPopupEditForm();
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= txt_KeyUp;
            popupForm.KeyUp += txt_KeyUp;


            if (checkbtnsidve)
            {
                myLCI.Control = btnaddsidve;
                myLCI.Move(clearLCI, InsertType.Left);
                myrefresh.Control = btnreloadsidve;
                myrefresh.Move(myLCI, InsertType.Left);

                checkbtnsidve = false;
            }
        }

        private bool checkbtnsidve = true;

        private void loadslusidve()
        {
            sidve.DataSource = (from a in new KetNoiDBDataContext().dmveans select a);
        }

        public void btnaddsidve_Click(object sender, EventArgs e)
        {
            try
            {
                Biencucbo.QuyenDangChon =
                    (from a in new KetNoiDBDataContext().PhanQuyen2s select a).Single(t => t.TaiKhoan == Biencucbo.phongban &&   t.ChucNang == "btndmvean");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            var frm = new f_dmvean();
            frm.ShowDialog();
            loadslusidve();

        }

        public void btnreloadsidve_Click(object sender, EventArgs e)
        {
            loadslusidve();
        }



        #endregion

        #region override

        protected override void load()
        {
            btnin.Visibility = BarItemVisibility.Never;
            btnsaochep.Visibility = BarItemVisibility.Never;
            if (_donvi == string.Empty)
            {
                _donvi = Biencucbo.donvi;
            }
            // Load dữ liệu searchlookup 
            loadsluiddtSearchLookUpEdit();
            loadslusidve();

                dongedit 
            ()
            ;
            try
            {
                var so = (from a in new KetNoiDBDataContext().pxuatveans where a.iddv == _donvi select a.so).Max();
                if (so == null)
                    return;
                var lst = (from a in new KetNoiDBDataContext().pxuatveans where a.iddv == _donvi select a).Single(t => t.so == so);
                loadinfo(lst.key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void mo()
        {
            f_dspxuatvean frm = new f_dspxuatvean();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _key = Biencucbo.key;
                loadinfo(_key);
            }
        }

        protected override void them()
        {
            themtxt();
        }

        /// <summary>
        /// không dùng sao chép
        /// </summary>
        protected override void saochep()
        {

            //if (idTextEdit.Text != string.Empty)
            //{
            //    var frm = new f_ngaysaochep();
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        _hdong = 3;
            //        dbData = new KetNoiDBDataContext();
            //        _keytemp = _key;
            //        _key = custom.laykey();

            //        dataLayoutControl1.DataSource = (from a in new KetNoiDBDataContext().pxuatveans where a.key == _key select a);
            //        ngaynhapDateEdit.DateTime = Biencucbo.ngaysaochep;
            //        idTextEdit.Text = "YYYY";
            //        int dong = gv.DataRowCount;
            //        DataTable dt = new DataTable();
            //        /// <summary>
            //        /// dt.Columns.Add("idsp", typeof(string));
            //        /// dt.Columns.Add("soluong", typeof(double));
            //        /// dt.Columns.Add("dongia", typeof(double));
            //        /// dt.Columns.Add("ghichu", typeof(string));
            //        /// </summary>

            //        dt.Columns.Add("idve", typeof (string));
            //        dt.Columns.Add("ghichu", typeof (string));
            //        dt.Columns.Add("soluong", typeof (double));

            //        DataRow row;
            //        for (int i = 0; i < dong; i++)
            //        {
            //            /// <summary>
            //            ///  var ct = gv.GetRow(i) as pnhap_ct;
            //            ///  row = dt.NewRow();
            //            ///  row["idsp"] = ct.idsp;
            //            /// row["soluong"] = ct.soluong;
            //            ///   row["dongia"] = ct.dongia;
            //            ///  row["ghichu"] = ct.ghichu;
            //            ///  dt.Rows.Add(row);
            //            /// </summary>

            //            var ct = gv.GetRow(i) as pxuatveanct;
            //            row = dt.NewRow();
            //            row["idve"] = ct.idve;
            //            row["ghichu"] = ct.ghichu;
            //            row["soluong"] = ct.soluong;
            //        }

            //        gd.DataSource = (from a in dbData.pxuatveancts where a.keyxva == _key select a);

            //        foreach (DataRow item in dt.Rows)
            //        {
            //            /// <summary>
            //            ///   _idsp = item[0].ToString();
            //            /// _soluong = double.Parse(item[1].ToString());
            //            ///   _dongia = double.Parse(item[2].ToString());
            //            ///   _ghichu = item[3].ToString();
            //            ///   gv.AddNewRow();
            //            /// </summary>

            //            _idve = item[0].ToString();
            //            _ghichu = item[1].ToString();
            //            _soluong = double.Parse(item[2].ToString());
            //        }
            //        _hdong = 1;
            //        moedit();

            //}
            //}
        }

        private bool LuuPhieu()
        {
            dataLayoutControl1.Validate();
            gv.CloseEditor();
            gv.PostEditor();
            gv.UpdateCurrentRow();

            try
            {
                var c1 = dbData.pxuatveancts.Context.GetChangeSet();
                dbData.pxuatveancts.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        protected override bool luu()
        {
            try
            {
                gv.PostEditor();
                gv.UpdateCurrentRow();
                if (kiemtra())
                {
                    if (_hdong == 1)
                    {
                        idTextEdit.Text = custom.matutang("PXVA" + _donvi, "Phiếu Xuất Vé ăn");
                        _so = Biencucbo.so;
                        px.them(_key,idTextEdit.Text,ngayxuatDateEdit.DateTime,_so,loaixuatComboBoxEdit.Text,diengiaiTextEdit.Text,iddtSearchLookUpEdit.Text,idnvTextEdit.Text,iddvTextEdit.Text);
                        LuuPhieu();
                        hs.add(idTextEdit.Text, "Thêm Phiếu Xuất Vé Ăn");
                        XtraMessageBox.Show("Done");
                        dongedit();
                        return true;

                    }
                    if (_hdong == 2)
                    {
                        px.sua(_key,ngayxuatDateEdit.DateTime,loaixuatComboBoxEdit.Text,diengiaiTextEdit.Text,iddtSearchLookUpEdit.Text);
                        LuuPhieu();
                        hs.add(idTextEdit.Text,"Sửa Phiếu Xuất Vé Ăn")
                        ;
                        XtraMessageBox.Show("Done");
                        dongedit();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override void sua()
        {
            if (idTextEdit.Text !=string.Empty)
            {
                dbData = new KetNoiDBDataContext();
                _hdong = 2;
                gd.DataSource = (from a in dbData.pxuatveancts where a.keyxva == _key select a);
                moedit();
            }
        }

        protected override bool xoa()
        {
            if (idTextEdit.Text == string.Empty)
            {
                XtraMessageBox.Show("Không có thông tin để xóa");
                return false;
            }
            try
            {

                for (var i = gv.DataRowCount - 1; i >= 0; i--)
                {
                    var ct = gv.GetRow(i) as pxuatveanct;
                    px.xoact(ct.key);
                    gv.DeleteRow(i);
                }
                px.xoa(_key);
                hs.add(idTextEdit.Text, "Xóa Phiếu Xuất Vé Ăn");
                XtraMessageBox.Show("Done");
                dongedit();
                xoatxt();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        protected override void reload()
        {
            if (_hdong == 1)
            {
                _key = _keytemp;
            }
            loadinfo(_key);
            dongedit();
        }

        protected override void print()
        {

        }

        protected override void first()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().pxuatveans where a.iddv == _donvi select a.so).Min();
                if (lst == null)
                    return;
                var lst1 =
                    (from a in new KetNoiDBDataContext().pxuatveans where a.iddv == _donvi select a).Single(t => t.so == lst);
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void prev()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().pxuatveans where a.iddv == _donvi && a.so < _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu đầu tiên");
                    return;
                }
                var lst1 =
                    (from a in new KetNoiDBDataContext().pxuatveans where a.iddv == _donvi && a.so == lst select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void next()
        {
            try
            {
                var lst = (from a in new KetNoiDBDataContext().pxuatveans where a.iddv == _donvi && a.so > _so select a.so).Max();
                if (lst == null)
                {
                    XtraMessageBox.Show("Đây là phiếu cuối cùng");
                    return;
                }
                var lst1 =
                    (from a in new KetNoiDBDataContext().pxuatveans where a.iddv == _donvi && a.so == lst select a).Single();
                loadinfo(lst1.key);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        protected override void last()
        {
            load();
        }


        #endregion  

        #region Method

        private void dongedit()
        {
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.True;
            gv.OptionsBehavior.Editable = false;
            _hdong = 0;
        }

        private void moedit()
        {
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.False;
            dataLayoutControl1.OptionsView.IsReadOnly = DefaultBoolean.Default;
            // Textbox readonly = true
            iddvTextEdit.ReadOnly = true;
            idTextEdit.ReadOnly = true;
            idnvTextEdit.ReadOnly = true;
            tenphongbanTextEdit.ReadOnly = true;

            gv.OptionsBehavior.Editable = true;
        }

        private void themtxt()
        {
            _keytemp = _key;
            _key = custom.laykey();
            xoatxt();
            _hdong = 1;


            try
            {
                gd.DataSource = (from a in dbData.pxuatveancts where a.keyxva == _key select a);

            }
            catch (Exception ex)
            {

            }

            gv.AddNewRow();
            iddvTextEdit.Text = _donvi;
            idTextEdit.Text = "YYYY";
            ngayxuatDateEdit.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            idnvTextEdit.Text = Biencucbo.idnv;
            iddtSearchLookUpEdit.Text = "KH_01";
            loaixuatComboBoxEdit.Text = "Xuất Bán";
            moedit();

        }

        private void xoatxt()
        {
            dataLayoutControl1.DataSource = (from a in dbData.pxuatveans where a.key == _key select a);
            //Textbox.text = string.empty
            iddvTextEdit.Text = string.Empty;
            idTextEdit.Text = string.Empty;
            ngayxuatDateEdit.Text = string.Empty;
            loaixuatComboBoxEdit.Text = string.Empty;
            idnvTextEdit.Text = string.Empty;
            iddtSearchLookUpEdit.Text = string.Empty;
            diengiaiTextEdit.Text = string.Empty;

            dongedit();

        }

        private void loadinfo(string key)
        {
            loadsluiddtSearchLookUpEdit();
            loadslusidve();
            dongedit();
            try
            {
                var lst = (from a in new KetNoiDBDataContext().v_pxuatveans where a.iddv == _donvi select a).Single(t => t.key == key);
                dataLayoutControl1.DataSource = lst;
                var lst2 = (from a in new KetNoiDBDataContext().pxuatveans where a.iddv == _donvi select a).Single(t => t.key == key);
                gd.DataSource = lst2.pxuatveancts;
                _key = lst.key;
                _so = Convert.ToInt32(lst.so);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }







        #endregion

        private void iddvTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlblteniddv(iddvTextEdit.Text);
        }

        private void idnvTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlbltenidnv(idnvTextEdit.Text);
        }

        private void iddtSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            layttlblteniddt(iddtSearchLookUpEdit.Text);
        }

        private void f_pxuatvean_KeyDown(object sender, KeyEventArgs e)
        {
            if (_hdong != 0)
            {
                if (e.Control)
                {
                    if (e.KeyCode == Keys.Insert)
                    {
                        gv.AddNewRow();
                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        try
                        {
                            var ct = gv.GetFocusedRow() as pxuatveanct;

                            dbData.pxuatveancts.DeleteOnSubmit(ct);
                            gv.DeleteRow(gv.FocusedRowHandle);
                        }
                        catch
                        {
                            gv.DeleteRow(gv.FocusedRowHandle);
                        }
                    }
                }
            }
        }

        private void gv_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var ct = gv.GetFocusedRow() as pxuatveanct;
            if (ct == null)
                return;
            int i = 0, k = 0;
            string a;

            try
            {
                k = Convert.ToInt32(gv.GetRowCellValue(gv.DataRowCount - 1, "stt").ToString());
                k = k + 1;
            }
            catch (Exception ex)
            {

            }

            for (i = 0; i <= gv.DataRowCount - 1;)
            {
                if (k.ToString() == gv.GetRowCellValue(i, "stt").ToString())
                {
                    k = k + 1;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            ct.key = custom.laykey();
            ct.keyxva = _key;
            ct.idve = string.Empty;
            ct.soluong = 0.00;
            ct.ghichu = string.Empty;
            ct.stt = k;
            ct.thanhtien = 0.00;
            if (_hdong == 3)
            {
                ct.idve = _idve;
                ct.soluong = _soluong;
                ct.ghichu = _ghichu;
            }
        }

        private string _idve, _ghichu;
        private double _soluong;
        private void gv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gv.PostEditor();
            gv.UpdateCurrentRow();

            var ct = gv.GetFocusedRow() as pxuatveanct;
            if (ct == null)
                return;

            try
            {
                ct.thanhtien = ct.soluong * double.Parse(ct.idve);
              
            }
            catch (Exception ex)
            {
                ct.thanhtien = 0.00;
            }
        }

    }
}