using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public partial class f_themdonvi : Form
    {
        t_donvi dv = new t_donvi();
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_themdonvi()
        {
            InitializeComponent();
        }
        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            f_dvql frm = new f_dvql();
            frm.ShowDialog();
            txtdvql.Text = Biencucbo.ma;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txtnhom.Text == "" || txtdvql.Text == "" || txtten.Text == "")
            {
                Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hddv == 0)
                {
                    var Lst = (from l in db.donvis where l.id == txtid.Text || l.tendonvi == txtten.Text select l).ToList();
                    if (Lst.Count == 1)
                    {
                        Lotus.MsgBox.ShowErrorDialog("Đơn vị này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        dv.moi(txtid.Text.Trim(), txtten.Text, txtnhom.Text, txtdvql.Text);
                        this.Close();
                    }
                }
                else
                {
                    var Lst = (from l in db.donvis where l.tendonvi == txtten.Text && l.id != txtid.Text select l).ToList();
                    if (Lst.Count == 1)
                    {
                        Lotus.MsgBox.ShowErrorDialog("Đơn vị này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        dv.sua(txtid.Text, txtten.Text, txtnhom.Text, txtdvql.Text);
                        this.Close();
                    }
                }
            }
        }
        private void f_themdonvi_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Đơn Vị").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            if (Biencucbo.hddv == 1)
            {
                txtid.Enabled = false;
                var Lst = (from dv in db.donvis where dv.id == Biencucbo.ma select dv).ToList();
                txtid.DataBindings.Clear();
                txtten.DataBindings.Clear();
                txtnhom.DataBindings.Clear();
                txtdvql.DataBindings.Clear();
                txtid.DataBindings.Add("text", Lst, "id");
                txtid.Text.Trim();
                txtten.DataBindings.Add("text", Lst, "tendonvi".Trim());
                txtnhom.DataBindings.Add("text", Lst, "nhomdonvi".Trim());
                txtdvql.DataBindings.Add("text", Lst, "iddv".Trim());
            }
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btntaodt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdmanhanhdt = 1;
            Biencucbo.madtnhanh = txtid.Text;
            Biencucbo.tennhanhdt = txtten.Text;
            f_themdoituong frm = new f_themdoituong();
            frm.Show();
            Biencucbo.hdmaspnhanh = 0;
        }
    }
}
