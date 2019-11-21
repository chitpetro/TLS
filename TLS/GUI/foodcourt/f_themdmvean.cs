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
using DAL;
using BUS;
using DevExpress.ClipboardSource.SpreadsheetML;
using GUI.Properties;

namespace GUI.foodcourt
{
    public partial class f_themdmvean : frm.frmthemds
    {
        public f_themdmvean()
        {
            InitializeComponent();

        }


        private int _hdong = 0;
        private string _key = "";
        c_dmvean v = new c_dmvean();
        t_history hs = new t_history();

        protected override void load()
        {
            _hdong = Biencucbo.hdong;
            if (_hdong == 2)
            {
                _key = Biencucbo.key;
                idveSpinEdit.ReadOnly = true;
                var lst = (from a in new KetNoiDBDataContext().dmveans select a).Single(t => t.idve == double.Parse(_key));

                dataLayoutControl1.DataSource = lst;
            }
            if (_hdong == 3)
            {
                _key = Biencucbo.key;
                var lst = (from a in new KetNoiDBDataContext().dmveans select a).Single(t => t.idve == double.Parse(_key));
                dataLayoutControl1.DataSource = lst;
                idveSpinEdit.Text = string.Empty;
                _hdong = 1;

            }

        }

        protected override void luu()
        {
            if (kiemtra())
            {
                if (_hdong == 1)
                {
                    v.them(double.Parse(idveSpinEdit.Text),ghichuTextEdit.Text);
                    hs.add(idveSpinEdit.Text, "Thêm Danh Mục Vé Ăn");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
                if (_hdong == 2)
                {
                    v.sua(double.Parse(idveSpinEdit.Text),ghichuTextEdit.Text);
                    hs.add(idveSpinEdit.Text, "Sửa Danh Mục Vé Ăn");
                    custom.mes_done();
                    DialogResult = DialogResult.OK;
                }
            }
        }       

        private bool kiemtra()
        {
            int checknull = 0;
            int checdup = 0;
            idveSpinEdit.Properties.ContextImage = null;

            if (custom.checknulltext(idveSpinEdit))
                checknull++;

            if (checknull > 0)
            {
                custom.mes_thongtinchuadaydu();
            }
            var lst = (from a in new KetNoiDBDataContext().dmveans select a);
            if (_hdong == 1)
            {
                if (lst.Where(t => t.idve == double.Parse(idveSpinEdit.Text)).Count() > 0)
                {
                    idveSpinEdit.Properties.ContextImage = Resources.trung;
                    checdup++;
                }
            }

            if (checdup > 0)
                custom.mes_trunglap();
            if (checdup > 0 || checknull > 0)
                return false;
            return true;
        }


    }
}