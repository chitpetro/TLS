namespace GUI.Report.Xuat
{
    partial class r_thongke
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
        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.ChartTitle chartTitle3 = new DevExpress.XtraCharts.ChartTitle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.rpxuatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.txttitle = new DevExpress.XtraReports.UI.XRLabel();
            this.txttime = new DevExpress.XtraReports.UI.XRLabel();
            this.txtdonvi = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpxuatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 439.5833F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(1145F, 688.2231F);
            this.winControlContainer1.WinControl = this.chartControl1;
            // 
            // chartControl1
            // 
            this.chartControl1.DataSource = this.bindingSource1;
            xyDiagram1.AxisX.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            xyDiagram1.AxisX.Interlaced = true;
            xyDiagram1.AxisX.Label.Staggered = true;
            xyDiagram1.AxisX.MinorCount = 31;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisX.WholeRange.SideMarginsValue = 0D;
            xyDiagram1.AxisY.Label.TextPattern = "{V:n2}";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControl1.Location = new System.Drawing.Point(12, 102);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteName = "Concourse";
            series1.ArgumentDataMember = "ngayhd";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series1.ColorDataMember = "ngayhd";
            series1.CrosshairLabelPattern = "{V:n2}";
            pointSeriesLabel1.BackColor = System.Drawing.Color.White;
            pointSeriesLabel1.Border.Color = System.Drawing.Color.Silver;
            pointSeriesLabel1.LineColor = System.Drawing.Color.Red;
            pointSeriesLabel1.Shadow.Color = System.Drawing.Color.DarkGray;
            pointSeriesLabel1.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop;
            pointSeriesLabel1.TextPattern = "{V:n2}";
            series1.Label = pointSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.LegendTextPattern = "{A:dd/MM/yyyy} : {V:n2}";
            series1.Name = "Series 1";
            series1.ValueDataMembersSerializable = "thanhtien";
            lineSeriesView1.ColorEach = true;
            series1.View = lineSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.SeriesTemplate.ArgumentDataMember = "ngayhd";
            this.chartControl1.SeriesTemplate.ValueDataMembersSerializable = "thanhtien";
            lineSeriesView2.ColorEach = true;
            this.chartControl1.SeriesTemplate.View = lineSeriesView2;
            this.chartControl1.Size = new System.Drawing.Size(1099, 661);
            this.chartControl1.TabIndex = 4;
            chartTitle1.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Left;
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 12F);
            chartTitle1.Text = "Doanh thu / ລາຍຮັບການ";
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 12F);
            chartTitle2.Text = "Thời gian / ເວລາ";
            chartTitle3.Alignment = System.Drawing.StringAlignment.Near;
            chartTitle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            chartTitle3.Text = "Kip";
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1,
            chartTitle2,
            chartTitle3});
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 14.08334F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 12F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer1});
            this.PageHeader.HeightF = 698.2231F;
            this.PageHeader.Name = "PageHeader";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txttitle,
            this.txttime,
            this.txtdonvi});
            this.ReportHeader.HeightF = 80.20834F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // txttitle
            // 
            this.txttitle.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.txttitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.txttitle.Name = "txttitle";
            this.txttitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txttitle.SizeF = new System.Drawing.SizeF(1145F, 23F);
            this.txttitle.StylePriority.UseFont = false;
            this.txttitle.StylePriority.UseTextAlignment = false;
            this.txttitle.Text = "THỐNG KÊ DOANH THU";
            this.txttitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txttime
            // 
            this.txttime.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45.99999F);
            this.txttime.Name = "txttime";
            this.txttime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txttime.SizeF = new System.Drawing.SizeF(1145F, 23F);
            this.txttime.StylePriority.UseTextAlignment = false;
            this.txttime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txtdonvi
            // 
            this.txtdonvi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.99999F);
            this.txtdonvi.Name = "txtdonvi";
            this.txtdonvi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtdonvi.SizeF = new System.Drawing.SizeF(1145F, 23F);
            this.txtdonvi.StylePriority.UseTextAlignment = false;
            this.txtdonvi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // r_thongke
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(12, 12, 14, 12);
            this.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 10, 10, 100F);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "15.1";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpxuatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
        #endregion
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.BindingSource rpxuatBindingSource;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel txttime;
        private DevExpress.XtraReports.UI.XRLabel txtdonvi;
        private DevExpress.XtraReports.UI.XRLabel txttitle;
    }
}
