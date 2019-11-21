using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace GUI
{
    sealed class ks
    {

        public static bool check(DateTime date)
        {
            KetNoiDBDataContext dbData = new KetNoiDBDataContext();
            try
            {
                if (date.ToString() == string.Empty)
                {
                    MessageBox.Show("Thời gian chưa được lựa chọn, vui lòng kiểm tra lại");
                    return true;
                }

                if (date <= (from a in dbData.khoasos select a).Single().thoigian)
                {
                    MessageBox.Show("Đã Khóa Sổ, không thể thao tác");
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {

                return true;
            }
        }
    }
}
