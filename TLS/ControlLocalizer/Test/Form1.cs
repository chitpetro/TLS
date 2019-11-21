using ControlLocalizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cboLang.Properties.Items.AddEnum(typeof(LanguageEnum));
            LanguageHelper.Language = LanguageEnum.Vietnam;
            cboLang.EditValue = LanguageHelper.Language;

            // DỊCH CONTROL DEVX
            LanguageHelper.Active((LanguageEnum)cboLang.EditValue);

            // DỊCH ỨNG DỤNG
            LanguageHelper.Translate(this);
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            LanguageHelper.ShowTranslateTool();
        }

        private void cboLang_EditValueChanged(object sender, EventArgs e)
        {
            LanguageHelper.Active((LanguageEnum)cboLang.EditValue);
            LanguageHelper.Translate(this);
        }
    }
}
