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
    public partial class chondoituongbh : DevExpress.XtraEditors.XtraForm
    {
        public chondoituongbh()
        {
            InitializeComponent();
        }

        private void txtiddt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in new DAL.KetNoiDBDataContext().doituongbhs select a).Single(t => t.id == txtiddt.Text);
                lblten.Text = lst.ten;
            }
            catch
            {
                lblten.Text = "";
            }
        }

        private void chondoituongbh_Load(object sender, EventArgs e)
        {
            txtiddt.Properties.DataSource = (from a in new DAL.KetNoiDBDataContext().doituongbhs select a);

        }

        private void btnreload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtiddt.Properties.DataSource = (from a in new DAL.KetNoiDBDataContext().doituongbhs select a);
        }

        private void chondoituongbh_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtiddt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                txtiddt.Properties.DataSource = (from a in new DAL.KetNoiDBDataContext().doituongbhs select a);
                MessageBox.Show("Load data!");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (txtiddt.Text == "")
                {
                    MessageBox.Show("Error!");
                    return;
                }
                else
                {
                    BUS.Biencucbo.doituong = txtiddt.Text;
                    this.Close();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                BUS.Biencucbo.doituong = "KH_01";
                this.Close();
            }

        }
    }
}