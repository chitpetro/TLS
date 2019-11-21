namespace GUI.foodcourt
{
    partial class f_dspxuatvean
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_dspxuatvean));
            this.layDsVeAnResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colkey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngayxuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colloaixuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldiengiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliddt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colteniddt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidnv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenidnv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenphongban = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coliddv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colteniddv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spn = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colsoluong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colthanhtien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colghichu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstt = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDsVeAnResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Size = new System.Drawing.Size(1148, 436);
            this.layoutControl1.Controls.SetChildIndex(this.gd, 0);
            this.layoutControl1.Controls.SetChildIndex(this.thoigian, 0);
            this.layoutControl1.Controls.SetChildIndex(this.tungay, 0);
            this.layoutControl1.Controls.SetChildIndex(this.denngay, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnsearh, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnsearchall, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnxls, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnin, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(1148, 436);
            // 
            // gd
            // 
            this.gd.DataSource = this.layDsVeAnResultBindingSource;
            this.gd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.spn});
            this.gd.Size = new System.Drawing.Size(1124, 344);
            this.gd.TabIndex = 8;
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colkey,
            this.colid,
            this.colngayxuat,
            this.colso,
            this.colloaixuat,
            this.coldiengiai,
            this.coliddt,
            this.colteniddt,
            this.colidnv,
            this.coltenidnv,
            this.coltenphongban,
            this.coliddv,
            this.colteniddv,
            this.colidve,
            this.colsoluong,
            this.colthanhtien,
            this.colghichu,
            this.colstt});
            this.gv.GroupCount = 2;
            this.gv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "thanhtien", this.colthanhtien, "{0:n0}")});
            this.gv.IndicatorWidth = 44;
            this.gv.OptionsBehavior.AutoExpandAllGroups = true;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsPrint.RtfReportHeader = resources.GetString("gv.OptionsPrint.RtfReportHeader");
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colngayxuat, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colid, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Size = new System.Drawing.Size(1128, 348);
            // 
            // btnin
            // 
            this.btnin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnin.ImageOptions.Image")));
            this.btnin.TabIndex = 7;
            // 
            // btnxls
            // 
            this.btnxls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxls.ImageOptions.Image")));
            this.btnxls.TabIndex = 6;
            // 
            // btnsearchall
            // 
            this.btnsearchall.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsearchall.ImageOptions.Image")));
            this.btnsearchall.TabIndex = 5;
            // 
            // btnsearh
            // 
            this.btnsearh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsearh.ImageOptions.Image")));
            this.btnsearh.TabIndex = 4;
            // 
            // denngay
            // 
            this.denngay.EditValue = new System.DateTime(2019, 6, 30, 0, 0, 0, 0);
            this.denngay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.denngay.TabIndex = 3;
            // 
            // tungay
            // 
            this.tungay.EditValue = new System.DateTime(2019, 6, 1, 0, 0, 0, 0);
            this.tungay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tungay.TabIndex = 2;
            // 
            // thoigian
            // 
            this.thoigian.EditValue = "Tháng Này";
            this.thoigian.TabIndex = 0;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Size = new System.Drawing.Size(176, 68);
            // 
            // layDsVeAnResultBindingSource
            // 
            this.layDsVeAnResultBindingSource.DataSource = typeof(DAL.LayDsVeAnResult);
            // 
            // colkey
            // 
            this.colkey.FieldName = "key";
            this.colkey.Name = "colkey";
            // 
            // colid
            // 
            this.colid.Caption = "ID";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 2;
            // 
            // colngayxuat
            // 
            this.colngayxuat.Caption = "Ngày Xuất";
            this.colngayxuat.FieldName = "ngayxuat";
            this.colngayxuat.Name = "colngayxuat";
            this.colngayxuat.Visible = true;
            this.colngayxuat.VisibleIndex = 1;
            // 
            // colso
            // 
            this.colso.FieldName = "so";
            this.colso.Name = "colso";
            // 
            // colloaixuat
            // 
            this.colloaixuat.Caption = "Loại Xuất";
            this.colloaixuat.FieldName = "loaixuat";
            this.colloaixuat.Name = "colloaixuat";
            this.colloaixuat.Visible = true;
            this.colloaixuat.VisibleIndex = 0;
            // 
            // coldiengiai
            // 
            this.coldiengiai.Caption = "Diễn Giải";
            this.coldiengiai.FieldName = "diengiai";
            this.coldiengiai.Name = "coldiengiai";
            this.coldiengiai.Visible = true;
            this.coldiengiai.VisibleIndex = 1;
            this.coldiengiai.Width = 83;
            // 
            // coliddt
            // 
            this.coliddt.FieldName = "iddt";
            this.coliddt.Name = "coliddt";
            // 
            // colteniddt
            // 
            this.colteniddt.Caption = "Đối Tượng";
            this.colteniddt.FieldName = "teniddt";
            this.colteniddt.Name = "colteniddt";
            this.colteniddt.Visible = true;
            this.colteniddt.VisibleIndex = 2;
            // 
            // colidnv
            // 
            this.colidnv.FieldName = "idnv";
            this.colidnv.Name = "colidnv";
            // 
            // coltenidnv
            // 
            this.coltenidnv.Caption = "Người Lập";
            this.coltenidnv.FieldName = "tenidnv";
            this.coltenidnv.Name = "coltenidnv";
            this.coltenidnv.Visible = true;
            this.coltenidnv.VisibleIndex = 3;
            // 
            // coltenphongban
            // 
            this.coltenphongban.Caption = "Phòng Ban";
            this.coltenphongban.FieldName = "tenphongban";
            this.coltenphongban.Name = "coltenphongban";
            this.coltenphongban.Visible = true;
            this.coltenphongban.VisibleIndex = 4;
            // 
            // coliddv
            // 
            this.coliddv.FieldName = "iddv";
            this.coliddv.Name = "coliddv";
            // 
            // colteniddv
            // 
            this.colteniddv.Caption = "Đơn Vị";
            this.colteniddv.FieldName = "teniddv";
            this.colteniddv.Name = "colteniddv";
            this.colteniddv.Visible = true;
            this.colteniddv.VisibleIndex = 9;
            // 
            // colidve
            // 
            this.colidve.Caption = "Loại Vé";
            this.colidve.ColumnEdit = this.spn;
            this.colidve.FieldName = "idve";
            this.colidve.Name = "colidve";
            this.colidve.Visible = true;
            this.colidve.VisibleIndex = 5;
            // 
            // spn
            // 
            this.spn.AutoHeight = false;
            this.spn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spn.Mask.EditMask = "n0";
            this.spn.Mask.UseMaskAsDisplayFormat = true;
            this.spn.Name = "spn";
            // 
            // colsoluong
            // 
            this.colsoluong.Caption = "Số Lượng";
            this.colsoluong.ColumnEdit = this.spn;
            this.colsoluong.FieldName = "soluong";
            this.colsoluong.Name = "colsoluong";
            this.colsoluong.Visible = true;
            this.colsoluong.VisibleIndex = 6;
            // 
            // colthanhtien
            // 
            this.colthanhtien.Caption = "Thành Tiền";
            this.colthanhtien.ColumnEdit = this.spn;
            this.colthanhtien.FieldName = "thanhtien";
            this.colthanhtien.Name = "colthanhtien";
            this.colthanhtien.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "thanhtien", "{0:n0}")});
            this.colthanhtien.Visible = true;
            this.colthanhtien.VisibleIndex = 7;
            // 
            // colghichu
            // 
            this.colghichu.Caption = "Ghi Chú";
            this.colghichu.FieldName = "ghichu";
            this.colghichu.Name = "colghichu";
            this.colghichu.Visible = true;
            this.colghichu.VisibleIndex = 8;
            // 
            // colstt
            // 
            this.colstt.FieldName = "stt";
            this.colstt.Name = "colstt";
            // 
            // f_dspxuatvean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 436);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "f_dspxuatvean";
            this.Text = "Danh Sách Phiếu Xuất Vé Ăn";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDsVeAnResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource layDsVeAnResultBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spn;
        private DevExpress.XtraGrid.Columns.GridColumn colkey;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colngayxuat;
        private DevExpress.XtraGrid.Columns.GridColumn colso;
        private DevExpress.XtraGrid.Columns.GridColumn colloaixuat;
        private DevExpress.XtraGrid.Columns.GridColumn coldiengiai;
        private DevExpress.XtraGrid.Columns.GridColumn coliddt;
        private DevExpress.XtraGrid.Columns.GridColumn colteniddt;
        private DevExpress.XtraGrid.Columns.GridColumn colidnv;
        private DevExpress.XtraGrid.Columns.GridColumn coltenidnv;
        private DevExpress.XtraGrid.Columns.GridColumn coltenphongban;
        private DevExpress.XtraGrid.Columns.GridColumn coliddv;
        private DevExpress.XtraGrid.Columns.GridColumn colteniddv;
        private DevExpress.XtraGrid.Columns.GridColumn colidve;
        private DevExpress.XtraGrid.Columns.GridColumn colsoluong;
        private DevExpress.XtraGrid.Columns.GridColumn colthanhtien;
        private DevExpress.XtraGrid.Columns.GridColumn colghichu;
        private DevExpress.XtraGrid.Columns.GridColumn colstt;
    }
}