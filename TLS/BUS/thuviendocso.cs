using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BUS;

namespace BUS
{
   public class thuviendocso
    {
        public string motso(int n)
        {
            if (n == 0) return " không ";
            if (n == 1) return " một ";
            if (n == 2) return " hai ";
            if (n == 3) return " ba ";
            if (n == 4) return " bốn ";
            if (n == 5) return " năm ";
            if (n == 6) return " sáu ";
            if (n == 7) return " bảy ";
            if (n == 8) return " tám ";
            if (n == 9) return " chín ";
            return null;
        }
        public string haiso(int c, int dv)
        {
            if (c == 1)
                if (dv == 0) return " mười ";
                else if (dv == 5) return " mười lăm ";
                else return " mười " + motso(dv);
            else //chuc<>1
                if (dv == 0) return motso(c) + " mươi ";
            else if (dv == 1) return motso(c) + " mươi mốt ";
            else if (dv == 5) return motso(c) + " mươi lăm ";
            else return motso(c) + " mươi " + motso(dv);

        }
        public string baso(int t, int c, int dv)
        {
            if (t == 0 && c == 0 && dv == 0) return "";
            else
                if (c == 0 && dv == 0) return motso(t) + " trăm ";
            else
                    if (c == 0 && dv != 0) return motso(t) + " lẻ " + motso(dv);
            else
                return motso(t) + " trăm " + haiso(c, dv);

        }
        public string docso(long n)
        {
            string st1 = "", st = "";
            int i = 1;//n=12.345
            while (n != 0)
            {

                int dv = (int)(n % 10);
                int c = (int)(n / 10 % 10);
                int t = (int)(n / 100 % 10);
                if (n < 10) st1 = motso(dv);
                else
                    if (n < 100) st1 = haiso(c, dv);
                else
                    st1 = baso(t, c, dv);
                if (st1 != "")//n=123
                {
                    if (i == 1) st = st1;
                    if (i == 2) st = st1 + " nghìn" + st;
                    if (i == 3) st = st1 + "triệu " + st;
                    if (i == 4) st = st1 + "tỉ" + st; ;
                    if (i == 5) st = st1 + " nghin tỉ " + st; ;
                }
                n = n / 1000;
                i = i + 1;
            }
            return st;
        }
    }
}
