namespace GUI.frm
{
    partial class frmp
    {

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
            this.components = new System.ComponentModel.Container();
            this.bm = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnmo = new DevExpress.XtraBars.BarButtonItem();
            this.btnthem = new DevExpress.XtraBars.BarButtonItem();
            this.btnluu = new DevExpress.XtraBars.BarButtonItem();
            this.btnsua = new DevExpress.XtraBars.BarButtonItem();
            this.btnxoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnreload = new DevExpress.XtraBars.BarButtonItem();
            this.btnin = new DevExpress.XtraBars.BarButtonItem();
            this.btnfirst = new DevExpress.XtraBars.BarButtonItem();
            this.btnprev = new DevExpress.XtraBars.BarButtonItem();
            this.btnnext = new DevExpress.XtraBars.BarButtonItem();
            this.btnlast = new DevExpress.XtraBars.BarButtonItem();
            this.btnsaochep = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            this.SuspendLayout();
            // 
            // bm
            // 
            this.bm.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.bm.DockControls.Add(this.barDockControlTop);
            this.bm.DockControls.Add(this.barDockControlBottom);
            this.bm.DockControls.Add(this.barDockControlLeft);
            this.bm.DockControls.Add(this.barDockControlRight);
            this.bm.Form = this;
            this.bm.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnmo,
            this.btnthem,
            this.btnluu,
            this.btnsua,
            this.btnxoa,
            this.btnreload,
            this.btnin,
            this.btnfirst,
            this.btnprev,
            this.btnnext,
            this.btnlast,
            this.btnsaochep});
            this.bm.MainMenu = this.bar2;
            this.bm.MaxItemId = 12;
            this.bm.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnmo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnthem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnsaochep, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnluu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnsua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnxoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnreload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnin, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnfirst, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnprev, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnnext, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnlast, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnmo
            // 
            this.btnmo.Caption = "Mở";
            this.btnmo.Id = 0;
            this.btnmo.ImageOptions.Image = global::GUI.Properties.Resources.open_16x16;
            this.btnmo.ImageOptions.LargeImage = global::GUI.Properties.Resources.open_32x32;
            this.btnmo.Name = "btnmo";
            this.btnmo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnmo_ItemClick);
            // 
            // btnthem
            // 
            this.btnthem.Caption = "Thêm";
            this.btnthem.Id = 1;
            this.btnthem.ImageOptions.Image = global::GUI.Properties.Resources.additem_16x161;
            this.btnthem.ImageOptions.LargeImage = global::GUI.Properties.Resources.additem_32x321;
            this.btnthem.Name = "btnthem";
            this.btnthem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnthem_ItemClick);
            // 
            // btnluu
            // 
            this.btnluu.Caption = "Lưu";
            this.btnluu.Id = 2;
            this.btnluu.ImageOptions.Image = global::GUI.Properties.Resources.save_16x16;
            this.btnluu.ImageOptions.LargeImage = global::GUI.Properties.Resources.save_32x32;
            this.btnluu.Name = "btnluu";
            this.btnluu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnluu_ItemClick);
            // 
            // btnsua
            // 
            this.btnsua.Caption = "Sửa";
            this.btnsua.Id = 3;
            this.btnsua.ImageOptions.Image = global::GUI.Properties.Resources.edit_16x161;
            this.btnsua.ImageOptions.LargeImage = global::GUI.Properties.Resources.edit_32x321;
            this.btnsua.Name = "btnsua";
            this.btnsua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnsua_ItemClick);
            // 
            // btnxoa
            // 
            this.btnxoa.Caption = "Xóa";
            this.btnxoa.Id = 4;
            this.btnxoa.ImageOptions.Image = global::GUI.Properties.Resources.deletelist_16x161;
            this.btnxoa.ImageOptions.LargeImage = global::GUI.Properties.Resources.deletelist_32x321;
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnxoa_ItemClick);
            // 
            // btnreload
            // 
            this.btnreload.Caption = "Reload";
            this.btnreload.Id = 5;
            this.btnreload.ImageOptions.Image = global::GUI.Properties.Resources.refresh_16x161;
            this.btnreload.ImageOptions.LargeImage = global::GUI.Properties.Resources.refresh_32x321;
            this.btnreload.Name = "btnreload";
            this.btnreload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnreload_ItemClick);
            // 
            // btnin
            // 
            this.btnin.Caption = "In";
            this.btnin.Id = 6;
            this.btnin.ImageOptions.Image = global::GUI.Properties.Resources.preview_16x161;
            this.btnin.ImageOptions.LargeImage = global::GUI.Properties.Resources.preview_32x321;
            this.btnin.Name = "btnin";
            this.btnin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnin_ItemClick);
            // 
            // btnfirst
            // 
            this.btnfirst.Caption = "First";
            this.btnfirst.Id = 7;
            this.btnfirst.ImageOptions.Image = global::GUI.Properties.Resources.doublefirst_16x16;
            this.btnfirst.ImageOptions.LargeImage = global::GUI.Properties.Resources.doublefirst_32x32;
            this.btnfirst.Name = "btnfirst";
            this.btnfirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnfirst_ItemClick);
            // 
            // btnprev
            // 
            this.btnprev.Caption = "Prev";
            this.btnprev.Id = 8;
            this.btnprev.ImageOptions.Image = global::GUI.Properties.Resources.prev_16x16;
            this.btnprev.ImageOptions.LargeImage = global::GUI.Properties.Resources.prev_32x32;
            this.btnprev.Name = "btnprev";
            this.btnprev.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnprev_ItemClick);
            // 
            // btnnext
            // 
            this.btnnext.Caption = "Next";
            this.btnnext.Id = 9;
            this.btnnext.ImageOptions.Image = global::GUI.Properties.Resources.next_16x16;
            this.btnnext.ImageOptions.LargeImage = global::GUI.Properties.Resources.next_32x32;
            this.btnnext.Name = "btnnext";
            this.btnnext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnnext_ItemClick);
            // 
            // btnlast
            // 
            this.btnlast.Caption = "Last";
            this.btnlast.Id = 10;
            this.btnlast.ImageOptions.Image = global::GUI.Properties.Resources.doublelast_16x16;
            this.btnlast.ImageOptions.LargeImage = global::GUI.Properties.Resources.doublelast_32x32;
            this.btnlast.Name = "btnlast";
            this.btnlast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnlast_ItemClick);
            // 
            // btnsaochep
            // 
            this.btnsaochep.Caption = "Sao Chép";
            this.btnsaochep.Id = 11;
            this.btnsaochep.ImageOptions.Image = global::GUI.Properties.Resources.copymodeldifferences_16x161;
            this.btnsaochep.ImageOptions.LargeImage = global::GUI.Properties.Resources.copymodeldifferences_32x321;
            this.btnsaochep.Name = "btnsaochep";
            this.btnsaochep.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnsaochep_ItemClick);
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
            this.barDockControlTop.Manager = this.bm;
            this.barDockControlTop.Size = new System.Drawing.Size(758, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 245);
            this.barDockControlBottom.Manager = this.bm;
            this.barDockControlBottom.Size = new System.Drawing.Size(758, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.bm;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 221);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(758, 24);
            this.barDockControlRight.Manager = this.bm;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 221);
            // 
            // frmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 268);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Name = "frmp";
            this.Text = "frmp";
            this.Load += new System.EventHandler(this.frmp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraBars.BarManager bm;
        protected DevExpress.XtraBars.Bar bar2;
        protected DevExpress.XtraBars.Bar bar3;
        protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.BarButtonItem btnmo;
        protected DevExpress.XtraBars.BarButtonItem btnthem;
        protected DevExpress.XtraBars.BarButtonItem btnluu;
        protected DevExpress.XtraBars.BarButtonItem btnsua;
        protected DevExpress.XtraBars.BarButtonItem btnxoa;
        protected DevExpress.XtraBars.BarButtonItem btnreload;
        protected DevExpress.XtraBars.BarButtonItem btnin;
        protected DevExpress.XtraBars.BarButtonItem btnfirst;
        protected DevExpress.XtraBars.BarButtonItem btnprev;
        protected DevExpress.XtraBars.BarButtonItem btnnext;
        protected DevExpress.XtraBars.BarButtonItem btnlast;
        protected System.ComponentModel.IContainer components;
        protected DevExpress.XtraBars.BarButtonItem btnsaochep;
    }
}