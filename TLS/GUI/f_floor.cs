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
    public partial class f_floor : DevExpress.XtraEditors.XtraForm
    {
        public f_floor()
        {
            InitializeComponent();
        }

        private void f_floor_Load(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in new DAL.KetNoiDBDataContext().donvis where a.nhomdonvi == "POS" select a);
                txtdv.Properties.DataSource = lst;
            }
            catch
            {

            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txtdv.Text == "")
                return;
            BUS.Biencucbo.donvi = txtdv.Text;
            BUS.Biencucbo.dvTen = txtdv.Text;
            this.Close();
        }
    }
}