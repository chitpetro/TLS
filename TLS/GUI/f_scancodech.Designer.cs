namespace GUI
{
    partial class f_scancodech
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_scancodech));
            this.txtsc = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtsc
            // 
            this.txtsc.Location = new System.Drawing.Point(12, 12);
            this.txtsc.Name = "txtsc";
            this.txtsc.Size = new System.Drawing.Size(260, 20);
            this.txtsc.TabIndex = 0;
            this.txtsc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsc_KeyDown);
            // 
            // f_scancodech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 45);
            this.Controls.Add(this.txtsc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_scancodech";
            this.Load += new System.EventHandler(this.f_scancodech_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtsc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtsc;
    }
}