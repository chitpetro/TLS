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
    public partial class f_themdmtk : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_dmtaikhoan dmtk = new t_dmtaikhoan();
        public f_themdmtk()
        {
            InitializeComponent();
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";
            a4.Text = "";
            tentk_kr.Properties.DataSource = new DAL.KetNoiDBDataContext().sanphams;
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (matk.Text == "" || tentk.Text == "" || loaitk.Text == "" || captk.Text == "" || tiente.Text == "")
            {
                Lotus.MsgBox.ShowWarningDialog("Thông tin chưa đầy đủ - Vui lòng kiểm tra lại!");
            }
            else if (deb.Checked == false && crd.Checked == false && debcrd.Checked == false)
            {
                Lotus.MsgBox.ShowWarningDialog("Bạn chưa chọn Kiểu số dư - Vui lòng kiểm tra lại!");
            }
            else
            {
                if (Biencucbo.hddmtk == 0)
                {
                    //khong cho trung ID  
                    var Lst = (from dt in db.dmtks where dt.matk == matk.Text select dt).ToList();
                    if (Lst.Count == 1)
                    {
                        Lotus.MsgBox.ShowWarningDialog("Danh mục Tài khoản này đã tồn tại, Vui Lòng Kiểm tra Lại");
                    }
                    else
                    {
                        //xu ly Kieu so du
                        string getKieuSoDu = string.Empty;
                        if (crd.Checked) getKieuSoDu = "CRD";
                        if (deb.Checked) getKieuSoDu = "DEB";
                        if (debcrd.Checked) getKieuSoDu = "DEBCRD";
                      
                        dmtk.moi(matk.Text.Trim(), tentk.Text, matk_jp.Text, tentk_jp.Text, tentk_khac.Text, tentk_kr.Text, loaitk.Text, Convert.ToInt32(captk.Text), tk_th.Checked, tkme.Text, tiente.Text, getKieuSoDu, doituong.Checked, chiphi.Checked, congviec.Checked, soluong.Checked, vat.Checked, thanhtoancongno.Checked, nganhang.Checked, tkcuahang.Checked, hanghoa.Checked, sanpham.Checked, loaikhoan.Checked, sotk_nh.Text, nganhang.Text, ma_nh.Text, active.Checked);
                        this.Close();
                    }
                }
                //sua
                else
                { 
                        //xu ly Kieu so du
                        string getKieuSoDu = string.Empty;
                    if (crd.Checked) getKieuSoDu = "CRD";
                    if (deb.Checked) getKieuSoDu = "DEB";
                    if (debcrd.Checked) getKieuSoDu = "DEBCRD";
                    dmtk.sua(matk.Text.Trim(), tentk.Text, matk_jp.Text, tentk_jp.Text, tentk_khac.Text, tentk_kr.Text, loaitk.Text, Convert.ToInt32(captk.Text), tk_th.Checked, tkme.Text, tiente.Text, getKieuSoDu, doituong.Checked, chiphi.Checked, congviec.Checked, soluong.Checked, vat.Checked, thanhtoancongno.Checked, nganhang.Checked, tkcuahang.Checked, hanghoa.Checked, sanpham.Checked, loaikhoan.Checked, sotk_nh.Text, nganhang.Text, ma_nh.Text, active.Checked);
                        this.Close(); 
                }
            }
        }
        private void f_themsanpham_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            LanguageHelper.Translate(barManager1);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "Thêm Danh Mục Tài Khoản").ToString();
            changeFont.Translate(this);
            changeFont.Translate(barManager1);
            if(Biencucbo.hdmaspnhanh == 1)
            {
                var lst = (from a in db.dmtks where a.idsp == Biencucbo.maspnhanh select a).ToList();
                if(lst.Count() == 0)
                {
                    
                    active.Checked = true;
                    tentk_kr.Text = Biencucbo.maspnhanh;
                    tentk.Text = Biencucbo.tenmaspnhanh;
                    tkme.Text = "156";
                    deb.Checked = true;
                    loaitk.Text = "HÀNG HÓA";
                    sanpham.Checked = true;
                    Biencucbo.hddmtk = 0;
                    captk.Text = "2";
                    tiente.Text = "KIP";
                }
                else
                {
                    Biencucbo.hddmtk = 1;
                    var lst2 = (from a in db.dmtks select a).FirstOrDefault(t => t.idsp == Biencucbo.maspnhanh);
                    Biencucbo.ma = lst2.matk;
                }
            }
            if (Biencucbo.hddmtk == 1)
            {
                var thucthi = (from k in db.dmtks select k).Single(t => t.matk == Biencucbo.ma);
                matk.ReadOnly = true;
                matk.Text = thucthi.matk;
                tentk.Text = thucthi.tentk;
                matk_jp.Text = thucthi.matk_jp;
                tentk_jp.Text = thucthi.tentk_jp;
                tentk_khac.Text = thucthi.tentk_khac;
                tentk_kr.Text = thucthi.idsp;
                //xu ly loai tk
                loaitk.Text = thucthi.loaitk;
                captk.Text = thucthi.captk.ToString();
                tk_th.Checked = (bool)thucthi.tk_th;
                tkme.Text = thucthi.tkme;
                tiente.Text = thucthi.tiente;
                //xu ly Kieu so du
                if (thucthi.kieusodu == "CRD") crd.Checked = true;
                if (thucthi.kieusodu == "DEB") deb.Checked = true;
                if (thucthi.kieusodu == "DEBCRD") debcrd.Checked = true;
                if (thucthi.doituong == true) doituong.Checked = true;
                if (thucthi.chiphi == true) chiphi.Checked = true;
                if (thucthi.congviec == true) congviec.Checked = true;
                if (thucthi.soluong == true) soluong.Checked = true;
                if (thucthi.thanhtoancongno == true) thanhtoancongno.Checked = true;
                if (thucthi.nganhang == true) nganhang.Checked = true;
                if (thucthi.tkcuahang == true) tkcuahang.Checked = true;
                if (thucthi.hanghoa == true) hanghoa.Checked = true;
                if (thucthi.sanpham == true) sanpham.Checked = true;
                if (thucthi.loaikhoan == true) loaikhoan.Checked = true;
                sotk_nh.Text = thucthi.sotk_nh;
                nganhang.Text = thucthi.nganhang_nh;
                ma_nh.Text = thucthi.ma_nh;
                if (thucthi.active == true) active.Checked = true;
            }
        } 
    }
}
