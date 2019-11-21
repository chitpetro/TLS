using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BUS
{
    public class Biencucbo
    {


        public static int hdong;
        public static int so;
        public static string key;

        //bhdongia
       
        public static double soluong = 0;

        // Số dư ban đầu
        public static string matk = "";
        public static string info = "";
        public static int hdsdbd = 0;


        // nhập quỹ
        public static int hdnq = 0;

        // nộp quỹ
        public static int hdntq = 0;

        // ngày tháng báo cáo
        public static DateTime tungay;
        public static DateTime denngay;
        // thống kế
        public static int gtime;
        // Nhân sự
        public static int hdns = 0;
        public static string ns = "";
        public static string tenns = "";

        // đọc số
        public static string tientebc = "";
        public static string tygiabc = "";
        public static double bangchutt = 0;
        public static double bangchunt = 0;
        //pgiam
        public static int hdpg = 0;
        public static DateTime ngaynhap;
        // tk no - co
        public static double dongia = 0;
        public static string mahd = "";
        public static string tkno = "";
        public static string tkco = "";
        public static string diachi = "";
        public static int nt = 0;
        // tien te
        public static int hddmlo = 0;
        public static string tiente;
        // tạo nhanh đon vị
        public static int hdmanhanhdt = 0;
        public static string madtnhanh = "";
        public static string tennhanhdt = "";
        // tạo nhanh mã Sản phẩm

        public static string maspnhanh = "";
        public static int hdmaspnhanh = 0;
        public static string tenmaspnhanh = "";

        // hethong
        public static string ten = "admin";
        public static string idnv = "admin";
        public static string phongban = "IT";
        public static string donvi = "00";
        public static string tendvbc = "";
        public static string sohd = "";
        public static string dvTen = "";
        public static string ma = "";
        public static string tien = "";
        public static int getID = 0;
        public static string skin = "";
        public static string skin2 = "";
        public static string hostname = "";
        public static string IPaddress = "";
        public static string DbName;
        public static string ServerName;

        // account
        public static int hdaccount = 0;
        public static int hdaccount2 = 2;
        public static int soaccount = 1;
        public static string account = "";

        // donvi
        public static int hddv = 0;

        // doituong 
        public static int hddt = 0;
        public static int hddtbh = 0;

        //nhomdoituong
        public static int hdndt = 0;

        //sanpham
        public static int hdsp = 0;

        // Phiếu nhập
        public static int hdpn = 0;

        // Hoá đơn
        public static int hdhd = 0;

        // Bán Hàng

        public static int hdbh = 0;
        public static string iddt = "";

        // Phiếu xuất kho
        public static int hdpx = 0;
        // file hop dong

        public static int fhd = 0;

        //Phiếu mua hàng
        public static int hdpm = 0;

        //Hopdong
        public static int hdhddv = 0;
        public static int hdhdong = 0;
        public static int hdct = 0;
        public static string hopdong = "";

        //Phiếu thu tiền
        public static int hdpt = 0;
        public static string thanhtoan = "";
        public static int ltlc = 0;

        // phiếu chi tiền
        public static int hdpc = 0;

        // phiếu kế toán
        public static int hdkt = 0;

        // Khai báo giá
        public static int hdgia = 0;
        public static int hdkk = 0;

        // sơ đồ trụ bơm
        public static int hdsd = 0;

        // Tài sản
        public static int hdts = 0;
        public static int checkts = 0;
        //báo cáo
        public static string kho = "Tất cả";
        public static string sp = "Tất cả";
        public static string doituong = "Tất cả";
        public static string congviec = "Tất cả";
        public static string title = "";
        public static string taikhoan = "";
        public static string time = "";
        public static string loai = "";
        public static string muccp = "";

        public static double tondau = 0;
        public static double tondau2 = 0;
        public static double toncuoi = 0;
        public static double tonxuat = 0;
        public static double tonxuat2 = 0;

        //ngon ngu
        public static object ngonngu;
        // DMTK
        public static int hddmtk;

        //tiền tệ
        public static int hdtt = 0;
        public static int hdttbh = 0;

        // thuế bán le
        public static float thuebl = 10;

        // phân quyền
        public static PhanQuyen2 QuyenDangChon { get; set; }


        // Chi tiết tài khoản

        public static double tondauno = 0;
        public static double tondauco = 0;

        public static double toncuoino = 0;
        public static double toncuoico = 0;
        public static string kieusodu = "";


    }
}
