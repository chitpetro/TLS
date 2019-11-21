using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class f_scancodech : DevExpress.XtraEditors.XtraForm
    {
        public f_scancodech()
        {
            InitializeComponent();
        }

        private void f_scancodech_Load(object sender, EventArgs e)
        {
            txtsc.Focus();
        }

        private void txtsc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    var lst = (from a in new DAL.KetNoiDBDataContext().r_giasps select a).FirstOrDefault(t => t.idsp == txtsc.Text);
                    BUS.Biencucbo.ma = lst.iddv;
                    this.Close();
                }
                catch
                {
                    BUS.Biencucbo.ma = "";
                }
            }
        }
    }
}