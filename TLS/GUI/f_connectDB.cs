using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;
using BUS;
using System.Data.Sql;
using ControlLocalizer;
using System.Xml;

namespace GUI
{
    public partial class f_connectDB : XtraForm
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        public f_connectDB()
        {
            InitializeComponent();
        }
        public bool KiemTraKetNoi()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("appconn.xml");//mở file.xml lên
            var s = xmlDoc.DocumentElement["conn"].InnerText;
            if (s == string.Empty) return false;

            // giải mã
            var conn = md5.Decrypt(s);
            var b = new SqlConnectionStringBuilder();
            b.ConnectionString = conn;
            Biencucbo.DbName = b.InitialCatalog;
            Biencucbo.ServerName = b.DataSource;
            var sqlCon = new SqlConnection(conn);

            // gán cho DAL tren bo nhớ 
            DAL.Settings.Default.ConnectionString = conn;
            try
            {
                sqlCon.Open();
                db = new KetNoiDBDataContext(sqlCon);
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
           
            if (txtDbName.Text == "")
            {
                XtraMessageBox.Show("Database name is not be empty", "Warning");
                return;
            }
            var thatluangplazaConnectionString_new = "";

            thatluangplazaConnectionString_new = "Data Source = " + txtServer.Text + "; Initial Catalog = " +
                                                 txtDbName.Text + "; Persist Security Info = True; User ID = " +
                                                 txtTen.Text + "; Password = " + txtPass.Text + "";

            var sqlCon = new SqlConnection(thatluangplazaConnectionString_new);
            try
            {
                sqlCon.Open();

                db = new KetNoiDBDataContext(sqlCon);

                XtraMessageBox.Show("Connection succeeded");
                Biencucbo.DbName = txtDbName.Text;
                Biencucbo.ServerName = txtServer.Text;
                thoat_luon = true;
                // luu connstring mã hóa vào setting
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("appconn.xml");//mở file.xml lên
                xmlDoc.DocumentElement["conn"].InnerText = md5.Encrypt(thatluangplazaConnectionString_new);
                xmlDoc.Save("appconn.xml");
                DAL.Settings.Default.ConnectionString = thatluangplazaConnectionString_new;

                //Settings.Default.Save();

                DialogResult = DialogResult.OK;
            }
            catch
            {
                XtraMessageBox.Show("Connection failed, please check again or contact Admin");
                sqlCon.Close();
            }
        }
        private void f_connectDB_Load(object sender, EventArgs e)
        { 
            LanguageHelper.Translate(this);
            this.Text = LanguageHelper.TranslateMsgString("." + Name + "_title", "CẬP NHẬT KẾT NỐI CƠ SỞ DỮ LIỆU").ToString();
            changeFont.Translate(this); 
            txtDbName.Text = Biencucbo.DbName;
            if (Biencucbo.ServerName == "192.168.0.9")
            {
                rlan.Checked = true; 
            }
            else if(Biencucbo.ServerName == "192.168.2.10")
            {
                rlan2.Checked = true;
            }
            else
            {
                rnet.Checked = true;
            }
           
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        bool thoat_luon = false;
        
        private void rlan_CheckedChanged(object sender, EventArgs e)
        {
            txtTen.ReadOnly = true;
            txtServer.Enabled = false; 
            txtPass.ReadOnly = true;
            if (rlan.Checked == true)
            {
                rnet.Checked = false;
                rlan2.Checked = false;
                txtServer.Text = "192.168.0.9,1433";
                txtDbName.Text = "TLS_2017";
                txtTen.Text = "sa";
                txtPass.Text = "2267562676a@#$%";
            }
        }
        private void rnet_CheckedChanged(object sender, EventArgs e)
        {
            txtTen.ReadOnly = true;
            txtServer.Enabled = false; 
            txtPass.ReadOnly = true;
            if (rnet.Checked == true)
            {
                rlan.Checked = false;
                rlan2.Checked = false;
                //txtServer.Text = "183.182.109.4,1433"; 
                txtServer.Text = "183.182.109.4,1433";
                txtDbName.Text = "TLS_2017";
                txtTen.Text = "sa";
                txtPass.Text = "2267562676a@#$%";
            }
        }
        //hàm mã hoá
        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            System.Security.Cryptography.MD5CryptoServiceProvider HashProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
            System.Security.Cryptography.TripleDESCryptoServiceProvider TDESAlgorithm = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = System.Security.Cryptography.CipherMode.ECB;
            TDESAlgorithm.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(Message);
            try
            {
                System.Security.Cryptography.ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }
        //hàm giải mã
        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            System.Security.Cryptography.MD5CryptoServiceProvider HashProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
            System.Security.Cryptography.TripleDESCryptoServiceProvider TDESAlgorithm = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = System.Security.Cryptography.CipherMode.ECB;
            TDESAlgorithm.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            try
            {
                byte[] DataToDecrypt = Convert.FromBase64String(Message);
                System.Security.Cryptography.ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }

        private void rlan2_CheckedChanged(object sender, EventArgs e)
        {
            txtTen.ReadOnly = true;
            txtServer.Enabled = false;
            txtPass.ReadOnly = true;
            if (rlan2.Checked == true)
            {
                rnet.Checked = false;
                rlan.Checked = false;
                txtServer.Text = "192.168.2.10,1433";
                txtDbName.Text = "TLS_2017";
                txtTen.Text = "sa";
                txtPass.Text = "2267562676a@#$%";
            }
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            if (txtDbName.Text == "")
            {
                XtraMessageBox.Show("Database name is not be empty", "Warning");
                return;
            }
            var thatluangplazaConnectionString_new = "";

            thatluangplazaConnectionString_new = "Data Source = " + txtServer.Text + "; Initial Catalog = " +
                                                 txtDbName.Text + "; Persist Security Info = True; User ID = " +
                                                 txtTen.Text + "; Password = " + txtPass.Text + "";

            var sqlCon = new SqlConnection(thatluangplazaConnectionString_new);
            try
            {
                sqlCon.Open();
                //db = new KetNoiDBDataContext(sqlCon);

                XtraMessageBox.Show("Connection succeeded");
                //Settings.Default.Save();
            }
            catch
            {
                XtraMessageBox.Show("Connection failed, please check again or contact Admin");
                sqlCon.Close();
            }
        }
    }
}
