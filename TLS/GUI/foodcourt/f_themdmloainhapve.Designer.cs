namespace GUI.foodcourt
{
    partial class f_themdmloainhapve
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dmloainhapveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.idTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForid = new DevExpress.XtraLayout.LayoutControlItem();
            this.loainhap_VNTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForloainhap_VN = new DevExpress.XtraLayout.LayoutControlItem();
            this.loainhap_LaoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForloainhap_Lao = new DevExpress.XtraLayout.LayoutControlItem();
            this.PChiCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ItemForPChi = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmloainhapveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loainhap_VNTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloainhap_VN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loainhap_LaoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloainhap_Lao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PChiCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPChi)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.idTextEdit);
            this.dataLayoutControl1.Controls.Add(this.loainhap_VNTextEdit);
            this.dataLayoutControl1.Controls.Add(this.loainhap_LaoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PChiCheckEdit);
            this.dataLayoutControl1.DataSource = this.dmloainhapveBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 24);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(290, 221);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(290, 221);
            this.Root.TextVisible = false;
            // 
            // dmloainhapveBindingSource
            // 
            this.dmloainhapveBindingSource.DataSource = typeof(DAL.dmloainhapve);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForid,
            this.ItemForloainhap_VN,
            this.ItemForloainhap_Lao,
            this.ItemForPChi});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(270, 201);
            // 
            // idTextEdit
            // 
            this.idTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloainhapveBindingSource, "id", true));
            this.idTextEdit.Location = new System.Drawing.Point(78, 12);
            this.idTextEdit.Name = "idTextEdit";
            this.idTextEdit.Size = new System.Drawing.Size(65, 20);
            this.idTextEdit.StyleController = this.dataLayoutControl1;
            this.idTextEdit.TabIndex = 4;
            // 
            // ItemForid
            // 
            this.ItemForid.Control = this.idTextEdit;
            this.ItemForid.Location = new System.Drawing.Point(0, 0);
            this.ItemForid.Name = "ItemForid";
            this.ItemForid.Size = new System.Drawing.Size(135, 24);
            this.ItemForid.Text = "id";
            this.ItemForid.TextSize = new System.Drawing.Size(63, 13);
            // 
            // loainhap_VNTextEdit
            // 
            this.loainhap_VNTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloainhapveBindingSource, "loainhap_VN", true));
            this.loainhap_VNTextEdit.Location = new System.Drawing.Point(78, 36);
            this.loainhap_VNTextEdit.Name = "loainhap_VNTextEdit";
            this.loainhap_VNTextEdit.Size = new System.Drawing.Size(200, 20);
            this.loainhap_VNTextEdit.StyleController = this.dataLayoutControl1;
            this.loainhap_VNTextEdit.TabIndex = 5;
            // 
            // ItemForloainhap_VN
            // 
            this.ItemForloainhap_VN.Control = this.loainhap_VNTextEdit;
            this.ItemForloainhap_VN.Location = new System.Drawing.Point(0, 24);
            this.ItemForloainhap_VN.Name = "ItemForloainhap_VN";
            this.ItemForloainhap_VN.Size = new System.Drawing.Size(270, 24);
            this.ItemForloainhap_VN.Text = "loainhap_VN";
            this.ItemForloainhap_VN.TextSize = new System.Drawing.Size(63, 13);
            // 
            // loainhap_LaoTextEdit
            // 
            this.loainhap_LaoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloainhapveBindingSource, "loainhap_Lao", true));
            this.loainhap_LaoTextEdit.Location = new System.Drawing.Point(78, 60);
            this.loainhap_LaoTextEdit.Name = "loainhap_LaoTextEdit";
            this.loainhap_LaoTextEdit.Size = new System.Drawing.Size(200, 20);
            this.loainhap_LaoTextEdit.StyleController = this.dataLayoutControl1;
            this.loainhap_LaoTextEdit.TabIndex = 6;
            // 
            // ItemForloainhap_Lao
            // 
            this.ItemForloainhap_Lao.Control = this.loainhap_LaoTextEdit;
            this.ItemForloainhap_Lao.Location = new System.Drawing.Point(0, 48);
            this.ItemForloainhap_Lao.Name = "ItemForloainhap_Lao";
            this.ItemForloainhap_Lao.Size = new System.Drawing.Size(270, 153);
            this.ItemForloainhap_Lao.Text = "loainhap_Lao";
            this.ItemForloainhap_Lao.TextSize = new System.Drawing.Size(63, 13);
            // 
            // PChiCheckEdit
            // 
            this.PChiCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dmloainhapveBindingSource, "PChi", true));
            this.PChiCheckEdit.Location = new System.Drawing.Point(147, 12);
            this.PChiCheckEdit.Name = "PChiCheckEdit";
            this.PChiCheckEdit.Properties.Caption = "PChi";
            this.PChiCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.PChiCheckEdit.Size = new System.Drawing.Size(131, 19);
            this.PChiCheckEdit.StyleController = this.dataLayoutControl1;
            this.PChiCheckEdit.TabIndex = 7;
            // 
            // ItemForPChi
            // 
            this.ItemForPChi.Control = this.PChiCheckEdit;
            this.ItemForPChi.Location = new System.Drawing.Point(135, 0);
            this.ItemForPChi.Name = "ItemForPChi";
            this.ItemForPChi.Size = new System.Drawing.Size(135, 24);
            this.ItemForPChi.Text = "PChi";
            this.ItemForPChi.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForPChi.TextVisible = false;
            // 
            // f_themdmloainhapve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 268);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "f_themdmloainhapve";
            this.Text = "Danh Mục Loại Nhập Vé";
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmloainhapveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loainhap_VNTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloainhap_VN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loainhap_LaoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForloainhap_Lao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PChiCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPChi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit idTextEdit;
        private System.Windows.Forms.BindingSource dmloainhapveBindingSource;
        private DevExpress.XtraEditors.TextEdit loainhap_VNTextEdit;
        private DevExpress.XtraEditors.TextEdit loainhap_LaoTextEdit;
        private DevExpress.XtraEditors.CheckEdit PChiCheckEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForid;
        private DevExpress.XtraLayout.LayoutControlItem ItemForloainhap_VN;
        private DevExpress.XtraLayout.LayoutControlItem ItemForloainhap_Lao;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPChi;
    }
}