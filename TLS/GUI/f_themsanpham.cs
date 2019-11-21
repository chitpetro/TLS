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
    public partial class f_themsanpham : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_sanpham sp = new t_sanpham();
        public f_themsanpham()
        {
            InitializeComponent();
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtid.Text == "" || txtten.Text == "" || txtdvt.Text == "")
            {
                Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else
            {
                btntaogiaban.Enabled = true;
                btntaomatk.Enabled = true;
                if (Biencucbo.hdsp == 0)
                {
                    //khong cho trung ID va Ten
                    var Lst = (from dt in db.sanphams where dt.id == txtid.Text || dt.tensp == txtten.Text select dt).ToList();
                    if (Lst.Count == 1)
                    {
                        Lotus.MsgBox.ShowErrorDialog("Sản phẩm này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        sp.moi(txtid.Text.Trim(), txtten.Text,  txtdvt.Text, txtloai.Text, checkQLK.Checked);
                        txtid.ReadOnly = true;
                        txtdvt.ReadOnly = true;
                        txtloai.ReadOnly = true;
                        txtten.ReadOnly = true;
                        btnluu.Enabled = false;
                        
                    }
                }
                else
                {
                    var Lst = (from s in db.sanphams where s.tensp == txtten.Text && s.id!=txtid.Text select s).ToList();
                    if (Lst.Count == 1)
                    {
                        Lotus.MsgBox.ShowErrorDialog("Sản phẩm này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        sp.sua(txtid.Text, txtten.Text,  txtdvt.Text, txtloai.Text, checkQLK.Checked);
                        txtid.ReadOnly = true;
                        txtdvt.ReadOnly = true;
                        txtloai.ReadOnly = true;
                        txtten.ReadOnly = true;
                        btnluu.Enabled = false;
                    }
                }
            }
        }
        private void f_themsanpham_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Sản Phẩm").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            btntaogiaban.Enabled = false;
            btntaomatk.Enabled = false;
            if (Biencucbo.hdsp == 1)
            {
                txtid.Enabled = false;
                sanpham thucthi = (from k in db.sanphams select k).Single(t => t.id == Biencucbo.ma);
                txtid.Text = thucthi.id;
                txtten.Text = thucthi.tensp;
               
                txtdvt.Text = thucthi.dvt;
                txtloai.Text = thucthi.loai;
                if (thucthi.qlkho == true)
                {
                    checkQLK.Checked = true;
                }
                else
                {
                    checkQLK.Checked = false;
                }
                btntaogiaban.Enabled = true;
                btntaomatk.Enabled = true;
            }
       }
        private void btntaomatk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdmaspnhanh = 1;
            Biencucbo.maspnhanh = txtid.Text;
            Biencucbo.tenmaspnhanh = txtten.Text;
            f_themdmtk frm = new f_themdmtk();
            frm.Show();
            Biencucbo.hdmaspnhanh = 0;
        }
        private void btntaogiaban_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Biencucbo.hdmaspnhanh = 1;
            Biencucbo.maspnhanh = txtid.Text;
            Biencucbo.tenmaspnhanh = txtten.Text;
            f_themgiaban frm = new f_themgiaban();
            frm.Show();
            Biencucbo.hdmaspnhanh = 0;
        }
    }
}
