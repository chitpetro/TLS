using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BUS;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Security.Cryptography;
using DevExpress.XtraEditors;


namespace GUI
{
    sealed class custom
    {
        #region gridcontrol
        public static bool cal(GridControl gd, GridView gv)
        {
            SizeF _Size = gd.CreateGraphics().MeasureString("STT", gd.Font);

            Int32 _Width = Convert.ToInt32(_Size.Width) + 21;
            int stt = _Width;
            int so = gv.DataRowCount;

            _Size = gd.CreateGraphics().MeasureString(so.ToString(), gd.Font);
            _Width = Convert.ToInt32(_Size.Width) + 25;
            if (stt > _Width)
                _Width = stt;

            gv.IndicatorWidth = gv.IndicatorWidth < _Width ? _Width : gv.IndicatorWidth;

            return true;
        }
        public static void sttgv(GridView gv, RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //e.Info.DisplayText = "STT";
            SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
            Int32 _Width = Convert.ToInt32(_Size.Width) + 21;


            if (!gv.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    _Width = Convert.ToInt32(_Size.Width) + 21;
                    gv.IndicatorWidth = gv.IndicatorWidth < _Width ? _Width : gv.IndicatorWidth;


                    //Graphics gr = Graphics.FromHwnd(gv.GridControl.Handle);
                    //SizeF size = gr.MeasureString(gv.RowCount.ToString(), gv.PaintAppearance.Row.GetFont());

                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                _Width = Convert.ToInt32(_Size.Width) + 20;
                gv.IndicatorWidth = gv.IndicatorWidth < _Width ? _Width : gv.IndicatorWidth;

            }



        }


        #endregion

        #region Mess
        public static void mes_thongtinchuadaydu()
        {
            XtraMessageBox.Show("Thông Tin Chưa Đầy Đủ Vui lòng Kiểm Tra Lại", "Thông Báo");
        }

        public static void mes_trunglap()
        {
            XtraMessageBox.Show("Thông tin bị trùng vui lòng kiểm tra lại", "Thông Báo");
        }

        public static void mes_done()
        {
            XtraMessageBox.Show("Done!");
        }
        #endregion

        #region Kiemtradulieutrong
        static public bool checknulltext(TextEdit _text)
        {

            if (_text.Text.Trim() == string.Empty)
            {
                _text.Properties.ContextImage = GUI.Properties.Resources.trong;
                return true;
            }
            return false;

        }
        #endregion

        #region MD5
        public static string Encrypt(string toEncrypt)
        {
            string key = "chitchareuneco.,ltd";
            try
            {

                bool useHashing = true;
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);


            }
            catch (Exception ex) { }
            return "";
        }
        public static string Decrypt(string toDecrypt)
        {
            try
            {
                string key = "chitchareuneco.,ltd";
                bool useHashing = true;
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                }
                else

                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion

        #region mã tự tăng

        public static string matutang(string macheck, string loai)
        {
            KetNoiDBDataContext dbData = new KetNoiDBDataContext();
            t_tudong td = new t_tudong();
            var check = macheck;
            var lst1 = (from s in dbData.tudongs where s.maphieu == check select new { s.so }).ToList();

            if (lst1.Count == 0)
            {
                int so;
                so = 2;
                td.themtudong(check, so, macheck, loai);
                Biencucbo.so = 1;
                return check + "_000001";

            }
            else
            {
                int k;

                k = 0;
                k = Convert.ToInt32(lst1.Single().so);
                Biencucbo.so = k;
                var so0 = "";
                if (k < 10)
                {
                    so0 = "00000";
                }
                else if (k >= 10 & k < 100)
                {
                    so0 = "0000";
                }
                else if (k >= 100 & k < 1000)
                {
                    so0 = "000";
                }
                else if (k >= 1000 & k < 10000)
                {
                    so0 = "00";
                }
                else if (k >= 10000 & k < 100000)
                {
                    so0 = "0";
                }
                else if (k >= 100000)
                {
                    so0 = "";
                }

                
                k = k + 1;
                td.suatudong(check, k);
                k = k - 1;
                return check + "_" + so0 + k ;
            }
        }
        #endregion

        #region Lấy Key
        public static string laykey()
        {
            return Encrypt(Biencucbo.idnv + Biencucbo.hostname + Biencucbo.IPaddress + Biencucbo.donvi +
                           DateTime.Now);

        }

        #endregion

        #region tientechinh
        //public static string laytientechinh()
        //{
        //    string mc = "";
        //    try
        //    {
        //        mc = (from a in new KetNoiDBDataContext().maincurrencies select a).SingleOrDefault().tentiente;
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.ToString());
        //    }
        //    return mc;
        //}

        #endregion


    }
}
