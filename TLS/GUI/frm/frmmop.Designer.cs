namespace GUI.frm
{
    partial class frmmop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
        protected void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnin = new DevExpress.XtraEditors.SimpleButton();
            this.btnxls = new DevExpress.XtraEditors.SimpleButton();
            this.btnsearchall = new DevExpress.XtraEditors.SimpleButton();
            this.btnsearh = new DevExpress.XtraEditors.SimpleButton();
            this.denngay = new DevExpress.XtraEditors.DateEdit();
            this.tungay = new DevExpress.XtraEditors.DateEdit();
            this.thoigian = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gd = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnin);
            this.layoutControl1.Controls.Add(this.btnxls);
            this.layoutControl1.Controls.Add(this.btnsearchall);
            this.layoutControl1.Controls.Add(this.btnsearh);
            this.layoutControl1.Controls.Add(this.denngay);
            this.layoutControl1.Controls.Add(this.tungay);
            this.layoutControl1.Controls.Add(this.thoigian);
            this.layoutControl1.Controls.Add(this.gd);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(972, 488);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnin
            // 
            this.btnin.ImageOptions.Image = global::GUI.Properties.Resources.printpreview_16x161;
            this.btnin.Location = new System.Drawing.Point(886, 42);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(62, 22);
            this.btnin.StyleController = this.layoutControl1;
            this.btnin.TabIndex = 11;
            this.btnin.Text = "In";
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // btnxls
            // 
            this.btnxls.ImageOptions.Image = global::GUI.Properties.Resources.exporttoxls_16x161;
            this.btnxls.Location = new System.Drawing.Point(829, 42);
            this.btnxls.Name = "btnxls";
            this.btnxls.Size = new System.Drawing.Size(53, 22);
            this.btnxls.StyleController = this.layoutControl1;
            this.btnxls.TabIndex = 10;
            this.btnxls.Text = "Excel";
            this.btnxls.Click += new System.EventHandler(this.btnxls_Click);
            // 
            // btnsearchall
            // 
            this.btnsearchall.ImageOptions.Image = global::GUI.Properties.Resources.lookup_reference_16x16;
            this.btnsearchall.Location = new System.Drawing.Point(720, 42);
            this.btnsearchall.Name = "btnsearchall";
            this.btnsearchall.Size = new System.Drawing.Size(81, 22);
            this.btnsearchall.StyleController = this.layoutControl1;
            this.btnsearchall.TabIndex = 9;
            this.btnsearchall.Text = "Search ALL";
            this.btnsearchall.Click += new System.EventHandler(this.btnsearchall_Click);
            // 
            // btnsearh
            // 
            this.btnsearh.ImageOptions.Image = global::GUI.Properties.Resources.search_16x16;
            this.btnsearh.Location = new System.Drawing.Point(655, 42);
            this.btnsearh.Name = "btnsearh";
            this.btnsearh.Size = new System.Drawing.Size(61, 22);
            this.btnsearh.StyleController = this.layoutControl1;
            this.btnsearh.TabIndex = 8;
            this.btnsearh.Text = "Search";
            this.btnsearh.Click += new System.EventHandler(this.btnsearh_Click);
            // 
            // denngay
            // 
            this.denngay.EditValue = null;
            this.denngay.Location = new System.Drawing.Point(531, 42);
            this.denngay.Name = "denngay";
            this.denngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denngay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denngay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.denngay.Size = new System.Drawing.Size(120, 20);
            this.denngay.StyleController = this.layoutControl1;
            this.denngay.TabIndex = 7;
            // 
            // tungay
            // 
            this.tungay.EditValue = null;
            this.tungay.Location = new System.Drawing.Point(337, 42);
            this.tungay.Name = "tungay";
            this.tungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tungay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tungay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.tungay.Size = new System.Drawing.Size(115, 20);
            this.tungay.StyleController = this.layoutControl1;
            this.tungay.TabIndex = 6;
            // 
            // thoigian
            // 
            this.thoigian.Location = new System.Drawing.Point(99, 42);
            this.thoigian.Name = "thoigian";
            this.thoigian.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.thoigian.Properties.Items.AddRange(new object[] {
            "Tùy Ý",
            "Hôm Nay",
            "Tháng Nay",
            "Tháng 01",
            "Tháng 02",
            "Tháng 03",
            "Tháng 04",
            "Tháng 05",
            "Tháng 06",
            "Tháng 07",
            "Tháng 08",
            "Tháng 09",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12",
            "Quý 1",
            "Quý 2",
            "Quý 3",
            "Quý 4",
            "6 Tháng Đầu Năm",
            "6 Tháng Cuối Năm",
            "Cả Năm"});
            this.thoigian.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.thoigian.Size = new System.Drawing.Size(159, 20);
            this.thoigian.StyleController = this.layoutControl1;
            this.thoigian.TabIndex = 5;
            this.thoigian.SelectedIndexChanged += new System.EventHandler(this.thoigian_SelectedIndexChanged);
            // 
            // gd
            // 
            this.gd.Location = new System.Drawing.Point(12, 80);
            this.gd.MainView = this.gv;
            this.gd.Name = "gd";
            this.gd.Size = new System.Drawing.Size(958, 379);
            this.gd.TabIndex = 4;
            this.gd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.GridControl = this.gd;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.AutoExpandAllGroups = true;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gv_RowClick);
            this.gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gv_CustomDrawRowIndicator);
            this.gv.Click += new System.EventHandler(this.gv_Click);
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlGroup1,
            this.layoutControlGroup2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(982, 471);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gd;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 68);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(962, 383);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(805, 68);
            this.layoutControlGroup1.Text = "Xem Báo Cáo";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.thoigian;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(238, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(238, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(238, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Chọn Thời Gian";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.tungay;
            this.layoutControlItem3.Location = new System.Drawing.Point(238, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(194, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(194, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(194, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Từ Ngày";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.denngay;
            this.layoutControlItem4.Location = new System.Drawing.Point(432, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(199, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(199, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(199, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Đến Ngày";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnsearh;
            this.layoutControlItem5.Location = new System.Drawing.Point(631, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(65, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(65, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(65, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnsearchall;
            this.layoutControlItem6.Location = new System.Drawing.Point(696, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(85, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(85, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(85, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8,
            this.layoutControlItem7});
            this.layoutControlGroup2.Location = new System.Drawing.Point(805, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(147, 68);
            this.layoutControlGroup2.Text = "Xuất Báo Cáo";
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnin;
            this.layoutControlItem8.Location = new System.Drawing.Point(57, 0);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(66, 26);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(66, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(66, 26);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnxls;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(57, 26);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(57, 26);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(57, 26);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(952, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 68);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmmop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 488);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmmop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmmop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmmop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thoigian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraLayout.LayoutControl layoutControl1;
        protected DevExpress.XtraLayout.LayoutControlGroup Root;
        protected DevExpress.XtraGrid.GridControl gd;
        protected DevExpress.XtraGrid.Views.Grid.GridView gv;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        protected DevExpress.XtraEditors.SimpleButton btnin;
        protected DevExpress.XtraEditors.SimpleButton btnxls;
        protected DevExpress.XtraEditors.SimpleButton btnsearchall;
        protected DevExpress.XtraEditors.SimpleButton btnsearh;
        protected DevExpress.XtraEditors.DateEdit denngay;
        protected DevExpress.XtraEditors.DateEdit tungay;
        protected DevExpress.XtraEditors.ComboBoxEdit thoigian;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        protected DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        protected DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        protected DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        protected DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}