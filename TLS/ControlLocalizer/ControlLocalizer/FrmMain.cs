using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLocalizer
{
    public partial class FrmMain : XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
            cboLang.Properties.Items.AddEnum(typeof(LanguageEnum));
        }

        private void FrmMain_Load(object sender, EventArgs e)
        { 
            LanguageHelper.Active(LanguageHelper.Language);
            LanguageHelper.Translate(this);
            cboLang.EditValue = LanguageHelper.Language;
        }
        void InitGrid()
        {
            if (gridControl1.DataSource == null) return;
            gridView1.PopulateColumns();
            gridView1.Columns["name"].VisibleIndex = 0;
            gridView1.Columns["name"].OptionsColumn.AllowEdit =
            gridView1.Columns["value"].OptionsColumn.AllowEdit = false;
            foreach (GridColumn c in gridView1.Columns)
                c.ColumnEdit = rMemoEdit;
        }
     
        private void txtPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (LanguageHelper.DSLang.GetChanges() != null)
            {
                var msg = XtraMessageBox.Show("Bạn có muốn lưu thay đổi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(msg == System.Windows.Forms.DialogResult.Yes)
                    LanguageHelper.SaveXML();
            }

            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = Application.StartupPath;
            op.Filter = "XML files|*.xml";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = op.FileName;
                string tbName = op.SafeFileName.Replace(".xml", string.Empty);
                txtPath.Tag = tbName;
                gridControl1.DataSource = LanguageHelper.GetTableByName(tbName);
                InitGrid();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LanguageHelper.SaveXML();
            XtraMessageBox.Show("Đã lưu");
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            if (cboLang.EditValue == null) return;
            LanguageHelper.Active((LanguageEnum)cboLang.EditValue);
            if (txtPath.Tag != null)
            {
                gridControl1.DataSource = LanguageHelper.GetTableByName(txtPath.Tag.ToString());
                InitGrid();
            }
             
            cboLang.EditValue = LanguageHelper.Language;
        } 
    }
}
