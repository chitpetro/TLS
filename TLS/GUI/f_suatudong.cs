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

namespace GUI
{
    public partial class f_suatudong : DevExpress.XtraEditors.XtraForm
    {
        t_tudong td = new t_tudong();

        public f_suatudong()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (txtso.Text != "")
                {
                    td.suatudong(Biencucbo.ma, int.Parse(txtso.Text));
                    MessageBox.Show("Done!");
                    this.Close();
                }

            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void btnhuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void f_suatudong_Load(object sender, EventArgs e)
        {
            try
            {

                var lst = (from a in new DAL.KetNoiDBDataContext().tudongs select a).Single(t => t.maphieu == Biencucbo.ma);
                txtso.Text = lst.so.ToString();
                lblten.Text = lst.loai;
            }
            catch
            {

            }
        }

    }
}