using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlLocalizer
{
    public static class rTime
    {
        public static LanguageEnum Language
        {
            get { return LanguageHelper.Language; }
        }

        public static void SetTime(ComboBoxEdit combo)
        {
            if (Language == LanguageEnum.Vietnam)
            { 
                combo.Properties.Items.Clear();
                combo.Properties.Items.Add("Tháng 1");
                combo.Properties.Items.Add("Tháng 2");
                combo.Properties.Items.Add("Tháng 3");
                combo.Properties.Items.Add("Tháng 4");
                combo.Properties.Items.Add("Tháng 5");
                combo.Properties.Items.Add("Tháng 6");
                combo.Properties.Items.Add("Tháng 7");
                combo.Properties.Items.Add("Tháng 8");
                combo.Properties.Items.Add("Tháng 9");
                combo.Properties.Items.Add("Tháng 10");
                combo.Properties.Items.Add("Tháng 11");
                combo.Properties.Items.Add("Tháng 12");
                combo.Properties.Items.Add("Quý 1");
                combo.Properties.Items.Add("Quý 2");
                combo.Properties.Items.Add("Quý 3");
                combo.Properties.Items.Add("6 Tháng Đầu");
                combo.Properties.Items.Add("6 Tháng Cuối");
                combo.Properties.Items.Add("Cả Năm");
                combo.Properties.Items.Add("Tùy ý");
            }
            else //Lao
            { 
                combo.Properties.Items.Clear();
                combo.Properties.Items.Add("ເດືອນ 1");
                combo.Properties.Items.Add("ເດືອນ 2");
                combo.Properties.Items.Add("ເດືອນ 3");
                combo.Properties.Items.Add("ເດືອນ 4");
                combo.Properties.Items.Add("ເດືອນ 5");
                combo.Properties.Items.Add("ເດືອນ 6");
                combo.Properties.Items.Add("ເດືອນ 7");
                combo.Properties.Items.Add("ເດືອນ 8");
                combo.Properties.Items.Add("ເດືອນ 9");
                combo.Properties.Items.Add("ເດືອນ 10");
                combo.Properties.Items.Add("ເດືອນ 11");
                combo.Properties.Items.Add("ເດືອນ 12");
                combo.Properties.Items.Add("ງວດ 1");
                combo.Properties.Items.Add("ງວດ 2");
                combo.Properties.Items.Add("ງວດ 3");
                combo.Properties.Items.Add("6 ເດືອນຕົ້ນປີ");
                combo.Properties.Items.Add("6 ເດືອນທ້າຍປີ");
                combo.Properties.Items.Add("ໝົດປີ");
                combo.Properties.Items.Add("ແລ້ວແຕ່");
            }
        }

        public static void SetTime2(ComboBoxEdit combo)
        {
            if (Language == LanguageEnum.Vietnam)
            {
                combo.Text = "Tháng " + DateTime.Now.Month; 
            }
            else //Lao
            {
                combo.Text = "ເດືອນ " + DateTime.Now.Month; 
            }
        }
    }
}
