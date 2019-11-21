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
using BUS;
using DAL;

namespace GUI
{
    public partial class f_dvbanhang : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_dvbanhang()
        {
            InitializeComponent();
            txtdv.Properties.DataSource = db.donvis;
        }

        void LoadData()
        {
            var list = (from d in db.donvis
                        where d.nhomdonvi == "Cửa Hàng"
                        select new
                        {
                            d.id,
                            d.tendonvi,
                            d.iddv,
                            d.chbh,
                        });
            txtdv.Properties.DataSource = list;
            txtdv.Focus();
        }
        private string LayMaTim(donvi d)
        {
            string s = "." + d.id + "." + d.iddv + ".";
            var find = db.donvis.FirstOrDefault(t => t.id == d.iddv);
            if (find != null)
            {
                string iddv = find.iddv;
                if (d.id != find.iddv)
                {
                    if (!s.Contains(iddv))
                        s += iddv + ".";
                }
                while (iddv != find.id)
                {
                    if (!s.Contains(find.id))
                        s += find.id + ".";
                    find = db.donvis.FirstOrDefault(t => t.id == find.iddv);
                }
            }
            return s;
        }
        private void txtdv_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var lst = (from a in new DAL.KetNoiDBDataContext().donvis select a).Single(t => t.id == txtdv.Text);
                lbldv.Text = lst.tendonvi;


            }
            catch
            {
                lbldv.Text = "";
            }
        }

        private void f_dvbanhang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void f_dvbanhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtdv.Text != "")
                {
                    Biencucbo.donvi = txtdv.Text;
                    this.Close();
                }
            }
        }

        private void f_dvbanhang_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtdv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtdv.Text != "")
                {
                    Biencucbo.donvi = txtdv.Text;
                    this.Close();
                }
            }
        }

        private void btnscan_Click(object sender, EventArgs e)
        {
            try
            {
                f_scancodech frm = new f_scancodech();
                frm.ShowDialog();
                txtdv.Text = Biencucbo.ma;
                txtdv.Focus();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}