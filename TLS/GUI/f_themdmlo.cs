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
    public partial class f_themdmlo : Form
    { 
        t_dmlo tt = new t_dmlo();
       
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_themdmlo()
        {
            InitializeComponent();
        }
 
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txttang.Text == "" )
            {
                Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hddmlo == 0)
                {
                    var Lst = (from l in db.dmlos where l.id == txtid.Text select l).ToList();
                    if (Lst.Count == 1)
                    {
                        Lotus.MsgBox.ShowWarningDialog("Số lô này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        
                        tt.moi(txtid.Text.Trim(), int.Parse(txttang.Text),txtGhiChu.Text);
                        this.Close();
                    }
                }
                //sua
                else
                {
                    tt.sua(txtid.Text,int.Parse(txttang.Text), txtGhiChu.Text);
                    this.Close();
                }
            }
        }
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void f_themtiente_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Danh Mục Số Lô").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            if (Biencucbo.hddmlo == 1)
            {
                txtid.Enabled = false;
                var Lst = (from tt in db.dmlos where tt.id == Biencucbo.ma select tt).ToList();
                txtid.DataBindings.Clear();
                txttang.DataBindings.Clear(); 
                txtGhiChu.DataBindings.Clear();
                txtid.DataBindings.Add("text", Lst, "id");
                txtid.Text.Trim();
                txttang.DataBindings.Add("text", Lst, "tang".Trim());
                txtGhiChu.DataBindings.Add("text", Lst, "ghichu".Trim());
            }
        }
    }
}
