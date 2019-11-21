using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using DAL;
using DevExpress.Mvvm.Native;

namespace GUI
{
    public partial class f_khoaso : DevExpress.XtraEditors.XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_history hs = new t_history();
        public f_khoaso()
        {
            InitializeComponent();
        }

        private void f_khoaso_Load(object sender, EventArgs e)
        {
            dthoigian.DateTime = DateTime.Parse((from a in db.khoasos select a).Single().thoigian.ToString());
        }

        private void btnkhoa_Click(object sender, EventArgs e)
        {
            var ks = (from a in db.khoasos select a).Single();
            ks.thoigian = dthoigian.DateTime;
            db.SubmitChanges();
            hs.add(dthoigian.DateTime.ToString(),"Khóa Sổ");
            MessageBox.Show("Done!");
        }
    }
}