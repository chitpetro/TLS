namespace GUI.foodcourt
{
    partial class f_dmvean
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_dmvean));
            this.dmveanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spn = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colghichu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmveanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnthem
            // 
            this.btnthem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnthem.ImageOptions.Image")));
            this.btnthem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnthem.ImageOptions.LargeImage")));
            // 
            // btnsua
            // 
            this.btnsua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.Image")));
            this.btnsua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnsua.ImageOptions.LargeImage")));
            // 
            // btnxoa
            // 
            this.btnxoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.Image")));
            this.btnxoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnxoa.ImageOptions.LargeImage")));
            // 
            // btnprint
            // 
            this.btnprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.Image")));
            this.btnprint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.LargeImage")));
            // 
            // btnxls
            // 
            this.btnxls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnxls.ImageOptions.Image")));
            this.btnxls.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnxls.ImageOptions.LargeImage")));
            // 
            // btnreload
            // 
            this.btnreload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnreload.ImageOptions.Image")));
            this.btnreload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnreload.ImageOptions.LargeImage")));
            // 
            // btnsaochep
            // 
            this.btnsaochep.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsaochep.ImageOptions.Image")));
            this.btnsaochep.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnsaochep.ImageOptions.LargeImage")));
            // 
            // layoutControl1
            // 
            this.layoutControl1.Location = new System.Drawing.Point(0, 26);
            this.layoutControl1.Size = new System.Drawing.Size(851, 338);
            this.layoutControl1.Controls.SetChildIndex(this.gd, 0);
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(851, 338);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Size = new System.Drawing.Size(831, 318);
            // 
            // gd
            // 
            this.gd.DataSource = this.dmveanBindingSource;
            this.gd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.spn});
            this.gd.Size = new System.Drawing.Size(827, 314);
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colve,
            this.colghichu});
            this.gv.IndicatorWidth = 44;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsPrint.RtfReportHeader = resources.GetString("gv.OptionsPrint.RtfReportHeader");
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colve, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // dmveanBindingSource
            // 
            this.dmveanBindingSource.DataSource = typeof(DAL.dmvean);
            // 
            // colve
            // 
            this.colve.Caption = "Loại Vé";
            this.colve.ColumnEdit = this.spn;
            this.colve.FieldName = "idve";
            this.colve.Name = "colve";
            this.colve.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colve.Visible = true;
            this.colve.VisibleIndex = 0;
            this.colve.Width = 278;
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
            // colghichu
            // 
            this.colghichu.Caption = "Ghi Chú";
            this.colghichu.FieldName = "ghichu";
            this.colghichu.Name = "colghichu";
            this.colghichu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colghichu.Visible = true;
            this.colghichu.VisibleIndex = 1;
            this.colghichu.Width = 388;
            // 
            // f_dmvean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 388);
            this.Name = "f_dmvean";
            this.Text = "Danh Mục Vé Ăn";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmveanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dmveanBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spn;
        private DevExpress.XtraGrid.Columns.GridColumn colve;
        private DevExpress.XtraGrid.Columns.GridColumn colghichu;
    }
}