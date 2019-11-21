using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Linq;

namespace BUS
{
    public class tinhkhauhao
    {
        public string id { get; set; }
        public DateTime? ngayhieuluc { get; set; }
        public double? nguyengia { get; set; }
        public string tkkhauhao { get; set; }
        public string tkchiphi { get; set; }
        public string iddt { get; set; }
        public double? sothangkh { get; set; }
        public string iddv { get; set; }
        public double? muckhthang { get; set; }
        public double? khluyke { get; set; }
        public double? gtconlai { get; set; }
        public string idcv { get; set; }
        public string idmuccp { get; set; }
        public string idts { get; set; }
    }
}
