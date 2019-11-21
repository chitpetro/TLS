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
    public partial class f_bhdongia : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_bhdongia()
        {
            InitializeComponent();

        }

        void LoadData()
        {
            txtsoluong.Text = "1";
        }



        private void f_dvbanhang_Load(object sender, EventArgs e)
        {
            LoadData();
        }



        private void f_dvbanhang_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtgia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtsoluong.Focus();
            }
        }

        private void txtsoluong_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Biencucbo.dongia = double.Parse(txtgia.Text);
                    Biencucbo.soluong = double.Parse(txtsoluong.Text);
                    this.Close();
                }
            }
        }
    }
}