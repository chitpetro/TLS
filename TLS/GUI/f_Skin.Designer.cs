namespace GUI
{
    partial class f_Skin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Skin));
            this.ok = new DevExpress.XtraEditors.SimpleButton();
            this.cancel = new DevExpress.XtraEditors.SimpleButton();
            this.imageComboBoxEdit1 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ok.ImageOptions.Image")));
            this.ok.Location = new System.Drawing.Point(232, 10);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(30, 23);
            this.ok.TabIndex = 3;
            this.ok.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cancel
            // 
            this.cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cancel.ImageOptions.Image")));
            this.cancel.Location = new System.Drawing.Point(268, 9);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(30, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // imageComboBoxEdit1
            // 
            this.imageComboBoxEdit1.Location = new System.Drawing.Point(12, 13);
            this.imageComboBoxEdit1.Name = "imageComboBoxEdit1";
            this.imageComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEdit1.Size = new System.Drawing.Size(213, 20);
            this.imageComboBoxEdit1.TabIndex = 5;
            this.imageComboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.imageComboBoxEdit1_SelectedIndexChanged);
            // 
            // f_Skin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 45);
            this.ControlBox = false;
            this.Controls.Add(this.imageComboBoxEdit1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_Skin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skin Hệ Thống";
            this.Load += new System.EventHandler(this.f_Skin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private DevExpress.XtraEditors.SimpleButton ok;
        private DevExpress.XtraEditors.SimpleButton cancel;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit1;
    }
}
