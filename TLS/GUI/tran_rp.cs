using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BUS;
using ControlLocalizer;
namespace GUI
{
    public static class tran_rp
    {
        public static LanguageEnum Language
        {
            get { return LanguageHelper.Language; }
        }
        //r_pchi, r_pnhap, r_pthu, r_pxuat
        public static void tran_ngay(XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                ngay2.Text = "ວັນທີ່ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        //r_bangcandoiPSketoan, r_socai, r_sonhatkychung
        public static void tran1(XRLabel txtdv, XRLabel txttaikhoan, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                txtdv.Text = "Đơn vị: " + Biencucbo.kho;
                txttaikhoan.Text = "Tài khoản: " + Biencucbo.taikhoan;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                txtdv.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;
                txttaikhoan.Text = "ບັນຊີ: " + Biencucbo.taikhoan;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        //r_doanhthu, r_sothuchi
        public static void tran2(XRLabel txtkho, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                txtkho.Text = "Đơn vị: " + Biencucbo.kho;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                txtkho.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        //r_ctcnkh/ncc, r_thcnkh/ncc
        public static void tran3(XRLabel txtkho, XRLabel txtdoituong, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                txtkho.Text = "Đơn vị: " + Biencucbo.kho;
                txtdoituong.Text = "Đối tượng: " + Biencucbo.doituong;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                txtkho.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;
                txtdoituong.Text = "ເປົ້້າໝາຍ: " + Biencucbo.doituong;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ່ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        //r_chitietnhapxuat
        public static void tran4(XRLabel txtkho, XRLabel txtsp, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                txtkho.Text = "Đơn vị: " + Biencucbo.kho;
                txtsp.Text = "Sản phẩm: " + Biencucbo.sp;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                txtkho.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;
                txtsp.Text = "ຜະລິດຕະພັນ: " + Biencucbo.sp;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        // r_tonfifo, r_tonfifo_duphong
        public static void tran5(XRLabel txtkho, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {

                txtkho.Text = "Đơn vị: " + Biencucbo.kho;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {

                txtkho.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        public static void tran6(XRLabel txtkho, XRLabel txtloai, XRLabel txtdoituong, XRLabel txtcongviec, XRLabel txtmuccp, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                txtkho.Text = "Đơn vị: " + Biencucbo.kho;
                txtloai.Text = "Loại thu: " + Biencucbo.loai;
                txtdoituong.Text = "Đối tượng: " + Biencucbo.doituong;
                txtcongviec.Text = "Công việc: " + Biencucbo.congviec;
                txtmuccp.Text = "Mục Chi phí: " + Biencucbo.muccp;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                txtkho.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;
                txtloai.Text = "ປະເພດ: " + Biencucbo.loai;
                txtdoituong.Text = "ເປົ້້າໝາຍ: " + Biencucbo.doituong;
                txtcongviec.Text = "ໜ້າວຽກ: " + Biencucbo.congviec;
                txtmuccp.Text = "ບັນຊີລາຍຈ່າຍ: " + Biencucbo.muccp;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        public static void tran7(XRLabel txtkho, XRLabel txtloai, XRLabel txtdoituong, XRLabel txtcongviec, XRLabel txtmuccp, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                txtkho.Text = "Đơn vị: " + Biencucbo.kho;
                txtloai.Text = "Loại chi: " + Biencucbo.loai;
                txtdoituong.Text = "Đối tượng: " + Biencucbo.doituong;
                txtcongviec.Text = "Công việc: " + Biencucbo.congviec;
                txtmuccp.Text = "Mục Chi phí: " + Biencucbo.muccp;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                //change text
                txtkho.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;
                txtloai.Text = "ປະເພດ: " + Biencucbo.loai;
                txtdoituong.Text = "ເປົ້້າໝາຍ: " + Biencucbo.doituong;
                txtcongviec.Text = "ໜ້າວຽກ: " + Biencucbo.congviec;
                txtmuccp.Text = "ບັນຊີລາຍຈ່າຍ: " + Biencucbo.muccp;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        //r_chitietnhapkho, r_nhaptheokho
        public static void tran8(XRLabel txtsp, XRLabel txtkho, XRLabel txtdoituong, XRLabel txtcongviec, XRLabel txtloainhap, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                txtsp.Text = "Nhóm hàng hóa: " + Biencucbo.sp;
                txtkho.Text = "Kho: " + Biencucbo.kho;
                txtdoituong.Text = "Đối tượng: " + Biencucbo.doituong;
                txtcongviec.Text = "Công việc: " + Biencucbo.congviec;
                txtloainhap.Text = "Loại Nhập: " + Biencucbo.loai;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                txtsp.Text = "ກຸ່ມສິນຄ້າ: " + Biencucbo.sp;
                txtkho.Text = "ສາງ: " + Biencucbo.kho;
                txtdoituong.Text = "ເປົ້້າໝາຍ: " + Biencucbo.doituong;
                txtcongviec.Text = "ໜ້າວຽກ: " + Biencucbo.congviec;
                txtloainhap.Text = "ປະເພດການນຳເຂົ້າ: " + Biencucbo.loai;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        //r_chitietxuatkho, r_xuattheokho
        public static void tran9(XRLabel txtsp, XRLabel txtkho, XRLabel txtdoituong, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                txtsp.Text = "Nhóm hàng hóa: " + Biencucbo.sp;
                txtkho.Text = "Đơn vị: " + Biencucbo.kho;
                txtdoituong.Text = "Đối tượng: " + Biencucbo.doituong;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                //change text
                txtsp.Text = "ກຸ່ມສິນຄ້າ: " + Biencucbo.sp;
                txtkho.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;
                txtdoituong.Text = "ເປົ້າໝາຍ: " + Biencucbo.doituong;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        public static void tran9_new(XRLabel txtkho, XRLabel txtdoituong, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {

                txtkho.Text = "Đơn vị: " + Biencucbo.kho;
                txtdoituong.Text = "Đối tượng: " + Biencucbo.doituong;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                //change text
                txtkho.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;
                txtdoituong.Text = "ເປົ້າໝາຍ: " + Biencucbo.doituong;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        //r_chitietpchi , r_chitietpthu
        public static void tran10(XRLabel txtkho, XRLabel txtloai, XRLabel txtdoituong, XRLabel txtcongviec, XRLabel txtmuccp, XRLabel txttitle, XRTableCell txttktl, XRLabel txttaikhoan, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                txtkho.Text = "Đơn vị: " + Biencucbo.kho;
                txtloai.Text = "Loại chi: " + Biencucbo.loai;
                txtdoituong.Text = "Đối tượng: " + Biencucbo.doituong;
                txtcongviec.Text = "Công việc: " + Biencucbo.congviec;
                txtmuccp.Text = "Mục Chi phí: " + Biencucbo.muccp;
                txttitle.Text = Biencucbo.title;
                txttktl.Text = "Tài Khoản";
                txttaikhoan.Text = "Tài Khoản: " + Biencucbo.taikhoan;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                //change text
                txtkho.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;
                txtloai.Text = "ປະເພດ: " + Biencucbo.loai;
                txtdoituong.Text = "ເປົ້້າໝາຍ: " + Biencucbo.doituong;
                txtcongviec.Text = "ໜ້າວຽກ: " + Biencucbo.congviec;
                txtmuccp.Text = "ບັນຊີລາຍຈ່າຍ: " + Biencucbo.muccp;
                txttitle.Text = Biencucbo.title;
                txttktl.Text = "ບັນຊີ";
                txttaikhoan.Text = "ບັນຊີ: " + Biencucbo.taikhoan;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
        //r_chitiettaikhoan
        public static void tran11(XRLabel txtdv, XRLabel txttaikhoan, XRLabel txtdoituong, XRLabel txtcongviec, XRLabel txtmuccp, XRLabel txttime, XRTableCell ngay2, XRPageInfo xrPageInfo2)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                txtdv.Text = "Đơn vị: " + Biencucbo.kho;

                txtdoituong.Text = "Đối tượng: " + Biencucbo.doituong;
                txtcongviec.Text = "Công việc: " + Biencucbo.congviec;
                txtmuccp.Text = "Mục Chi phí: " + Biencucbo.muccp;

                txttaikhoan.Text = "Tài Khoản: " + Biencucbo.taikhoan;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "Ngày " + DateTime.Now.Day + ", Tháng " + DateTime.Now.Month + ", Năm " + DateTime.Now.Year;
                xrPageInfo2.Format = "Trang {0}/{1}";
            }
            else
            {
                //change text
                txtdv.Text = "ຫົວໜ່ວຍ: " + Biencucbo.kho;

                txtdoituong.Text = "ເປົ້້າໝາຍ: " + Biencucbo.doituong;
                txtcongviec.Text = "ໜ້າວຽກ: " + Biencucbo.congviec;
                txtmuccp.Text = "ບັນຊີລາຍຈ່າຍ: " + Biencucbo.muccp;

                txttaikhoan.Text = "ບັນຊີ: " + Biencucbo.taikhoan;
                txttime.Text = Biencucbo.time;
                ngay2.Text = "ວັນທີ " + DateTime.Now.Day + ", ເດືອນ " + DateTime.Now.Month + ", ປີ " + DateTime.Now.Year;
                xrPageInfo2.Format = "ໜ້າທີ {0}/{1}";
            }
        }
    }
}

