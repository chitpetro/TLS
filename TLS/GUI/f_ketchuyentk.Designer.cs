namespace GUI
{
    partial class f_ketchuyentk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_ketchuyentk));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnthem = new DevExpress.XtraBars.BarButtonItem();
            this.btnsua = new DevExpress.XtraBars.BarButtonItem();
            this.btnxoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnKetChuyen = new DevExpress.XtraBars.BarButtonItem();
            this.btnds = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iddv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loaichungtu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.machungtu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ngaychungtu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ngaylchungtu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sochungtu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.diengiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tk_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tk_co = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tiente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tygia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PS_nt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idnv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idcv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idmuccp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnthem,
            this.btnsua,
            this.btnxoa,
            this.barButtonItem4,
            this.btnRefresh,
            this.btnKetChuyen,
            this.btnds});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnthem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnsua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnxoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnKetChuyen),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnds)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnthem
            // 
            this.btnthem.Caption = "Thêm";
            this.btnthem.Glyph = global::GUI.Properties.Resources.icons8_Add_File_16;
            this.btnthem.Id = 0;
            this.btnthem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnthem.LargeGlyph")));
            this.btnthem.Name = "btnthem";
            this.btnthem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnthem_ItemClick);
            // 
            // btnsua
            // 
            this.btnsua.Caption = "Sửa";
            this.btnsua.Glyph = ((System.Drawing.Image)(resources.GetObject("btnsua.Glyph")));
            this.btnsua.Id = 1;
            this.btnsua.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnsua.LargeGlyph")));
            this.btnsua.Name = "btnsua";
            this.btnsua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnsua_ItemClick);
            // 
            // btnxoa
            // 
            this.btnxoa.Caption = "Xóa ";
            this.btnxoa.Glyph = ((System.Drawing.Image)(resources.GetObject("btnxoa.Glyph")));
            this.btnxoa.Id = 2;
            this.btnxoa.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnxoa.LargeGlyph")));
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnxoa_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 4;
            this.btnRefresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.LargeGlyph")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnKetChuyen
            // 
            this.btnKetChuyen.Caption = "Kết chuyển";
            this.btnKetChuyen.Id = 5;
            this.btnKetChuyen.Name = "btnKetChuyen";
            this.btnKetChuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKetChuyen_ItemClick);
            // 
            // btnds
            // 
            this.btnds.Caption = "Danh sách KC";
            this.btnds.Id = 6;
            this.btnds.Name = "btnds";
            this.btnds.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnds_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1372, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 356);
            this.barDockControlBottom.Size = new System.Drawing.Size(1372, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 328);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1372, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 328);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Đóng";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1372, 328);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.iddv,
            this.loaichungtu,
            this.machungtu,
            this.ngaychungtu,
            this.ngaylchungtu,
            this.sochungtu,
            this.diengiai,
            this.tk_no,
            this.tk_co,
            this.PS,
            this.tiente,
            this.tygia,
            this.PS_nt,
            this.idnv,
            this.loai,
            this.idcv,
            this.idmuccp,
            this.kc});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // id
            // 
            this.id.Caption = "ID";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            // 
            // iddv
            // 
            this.iddv.Caption = "Mã Đơn Vị";
            this.iddv.FieldName = "iddv";
            this.iddv.Name = "iddv";
            this.iddv.Visible = true;
            this.iddv.VisibleIndex = 1;
            // 
            // loaichungtu
            // 
            this.loaichungtu.Caption = "Loại Chứng Từ";
            this.loaichungtu.FieldName = "loaichungtu";
            this.loaichungtu.Name = "loaichungtu";
            this.loaichungtu.Visible = true;
            this.loaichungtu.VisibleIndex = 2;
            // 
            // machungtu
            // 
            this.machungtu.Caption = "Mã Chứng Từ";
            this.machungtu.FieldName = "machungtu";
            this.machungtu.Name = "machungtu";
            this.machungtu.Visible = true;
            this.machungtu.VisibleIndex = 3;
            // 
            // ngaychungtu
            // 
            this.ngaychungtu.Caption = "Ngày Chứng Từ";
            this.ngaychungtu.FieldName = "ngaychungtu";
            this.ngaychungtu.Name = "ngaychungtu";
            this.ngaychungtu.Visible = true;
            this.ngaychungtu.VisibleIndex = 4;
            // 
            // ngaylchungtu
            // 
            this.ngaylchungtu.Caption = "Ngày Lập CT";
            this.ngaylchungtu.FieldName = "ngaylchungtu";
            this.ngaylchungtu.Name = "ngaylchungtu";
            this.ngaylchungtu.Visible = true;
            this.ngaylchungtu.VisibleIndex = 5;
            // 
            // sochungtu
            // 
            this.sochungtu.Caption = "Số Chứng Từ";
            this.sochungtu.FieldName = "sochungtu";
            this.sochungtu.Name = "sochungtu";
            this.sochungtu.Visible = true;
            this.sochungtu.VisibleIndex = 6;
            // 
            // diengiai
            // 
            this.diengiai.Caption = "Diễn Giải";
            this.diengiai.FieldName = "diengiai";
            this.diengiai.Name = "diengiai";
            this.diengiai.Visible = true;
            this.diengiai.VisibleIndex = 7;
            // 
            // tk_no
            // 
            this.tk_no.Caption = "TK Nợ";
            this.tk_no.FieldName = "tk_no";
            this.tk_no.Name = "tk_no";
            this.tk_no.Visible = true;
            this.tk_no.VisibleIndex = 8;
            // 
            // tk_co
            // 
            this.tk_co.Caption = "TK Có";
            this.tk_co.FieldName = "tk_co";
            this.tk_co.Name = "tk_co";
            this.tk_co.Visible = true;
            this.tk_co.VisibleIndex = 9;
            // 
            // PS
            // 
            this.PS.Caption = "Phát Sinh";
            this.PS.DisplayFormat.FormatString = "{0:n2}";
            this.PS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PS.FieldName = "PS";
            this.PS.Name = "PS";
            this.PS.Visible = true;
            this.PS.VisibleIndex = 10;
            // 
            // tiente
            // 
            this.tiente.Caption = "Tiền Tệ";
            this.tiente.FieldName = "tiente";
            this.tiente.Name = "tiente";
            this.tiente.Visible = true;
            this.tiente.VisibleIndex = 11;
            // 
            // tygia
            // 
            this.tygia.Caption = "Tỷ Giá";
            this.tygia.FieldName = "tygia";
            this.tygia.Name = "tygia";
            this.tygia.Visible = true;
            this.tygia.VisibleIndex = 12;
            // 
            // PS_nt
            // 
            this.PS_nt.Caption = "PS Nguyên Tệ";
            this.PS_nt.DisplayFormat.FormatString = "{0:n2}";
            this.PS_nt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PS_nt.FieldName = "PS_nt";
            this.PS_nt.Name = "PS_nt";
            this.PS_nt.Visible = true;
            this.PS_nt.VisibleIndex = 13;
            // 
            // idnv
            // 
            this.idnv.Caption = "Mã Nhân Viên";
            this.idnv.FieldName = "idnv";
            this.idnv.Name = "idnv";
            this.idnv.Visible = true;
            this.idnv.VisibleIndex = 14;
            // 
            // loai
            // 
            this.loai.Caption = "Loại";
            this.loai.FieldName = "loai";
            this.loai.Name = "loai";
            this.loai.Visible = true;
            this.loai.VisibleIndex = 15;
            // 
            // idcv
            // 
            this.idcv.Caption = "Mã Công Việc";
            this.idcv.FieldName = "idcv";
            this.idcv.Name = "idcv";
            this.idcv.Visible = true;
            this.idcv.VisibleIndex = 16;
            // 
            // idmuccp
            // 
            this.idmuccp.Caption = "Mục Chi Phí";
            this.idmuccp.FieldName = "idmuccp";
            this.idmuccp.Name = "idmuccp";
            this.idmuccp.Visible = true;
            this.idmuccp.VisibleIndex = 17;
            // 
            // kc
            // 
            this.kc.Caption = "Kết Chuyển";
            this.kc.FieldName = "kc";
            this.kc.Name = "kc";
            this.kc.Visible = true;
            this.kc.VisibleIndex = 18;
            // 
            // f_ketchuyentk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 378);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_ketchuyentk";
            this.Text = "Danh Mục Tài Khoản";
            this.Load += new System.EventHandler(this.f_dmtk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnthem;
        private DevExpress.XtraBars.BarButtonItem btnsua;
        private DevExpress.XtraBars.BarButtonItem btnxoa;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnKetChuyen;
        private DevExpress.XtraBars.BarButtonItem btnds;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn iddv;
        private DevExpress.XtraGrid.Columns.GridColumn loaichungtu;
        private DevExpress.XtraGrid.Columns.GridColumn machungtu;
        private DevExpress.XtraGrid.Columns.GridColumn ngaychungtu;
        private DevExpress.XtraGrid.Columns.GridColumn ngaylchungtu;
        private DevExpress.XtraGrid.Columns.GridColumn sochungtu;
        private DevExpress.XtraGrid.Columns.GridColumn diengiai;
        private DevExpress.XtraGrid.Columns.GridColumn tk_no;
        private DevExpress.XtraGrid.Columns.GridColumn tk_co;
        private DevExpress.XtraGrid.Columns.GridColumn PS;
        private DevExpress.XtraGrid.Columns.GridColumn tiente;
        private DevExpress.XtraGrid.Columns.GridColumn tygia;
        private DevExpress.XtraGrid.Columns.GridColumn PS_nt;
        private DevExpress.XtraGrid.Columns.GridColumn idnv;
        private DevExpress.XtraGrid.Columns.GridColumn loai;
        private DevExpress.XtraGrid.Columns.GridColumn idcv;
        private DevExpress.XtraGrid.Columns.GridColumn idmuccp;
        private DevExpress.XtraGrid.Columns.GridColumn kc;
    }
}
