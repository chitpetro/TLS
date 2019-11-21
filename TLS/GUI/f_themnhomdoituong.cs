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
    public partial class f_themnhomdoituong : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_nhomdoituong ndt = new t_nhomdoituong();
        public f_themnhomdoituong()
        {
            InitializeComponent();
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txtten.Text == "")
            {
                Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hdndt == 0)
                {
                    //khong cho trung ID va Ten
                    var Lst = (from dt in db.nhomdoituongs where dt.id == txtid.Text || dt.ten == txtten.Text select dt).ToList();
                    if (Lst.Count == 1)
                    {
                        Lotus.MsgBox.ShowErrorDialog("Nhóm đối tượng này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        ndt.moi(txtid.Text.Trim(), txtten.Text);
                        this.Close();
                    }
                }
                else
                {
                    var Lst = (from l in db.nhomdoituongs where l.ten == txtten.Text && l.id != txtid.Text select l).ToList();
                    if (Lst.Count == 1)
                    {
                        Lotus.MsgBox.ShowErrorDialog("Nhóm đối tượng này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        ndt.sua(txtid.Text, txtten.Text);
                        this.Close();
                    }
                }
            }
        }
        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
         
        private void f_themnhomdoituong_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Nhóm Đối Tượng").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            if (Biencucbo.hdndt == 1)
            {
                txtid.Enabled = false;
                var Lst = (from dt in db.nhomdoituongs where dt.id == Biencucbo.ma select dt).ToList();
                txtid.DataBindings.Clear();
                txtten.DataBindings.Clear(); 
                txtid.DataBindings.Add("text", Lst, "id");
                txtid.Text.Trim();
                txtten.DataBindings.Add("text", Lst, "ten".Trim()); 
            }
        }
    }
}
