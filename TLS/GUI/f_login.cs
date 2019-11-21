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
using System.Data.Linq;
using System.Net;
using System.Globalization;
using System.Resources;
using DevExpress.Xpo;
using ControlLocalizer;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraSplashScreen;
using System.Xml;

namespace GUI
{
    public partial class f_login : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_account ac = new t_account();
        t_history hs = new t_history();
        public f_login()
        {
            InitializeComponent();
            var lst = (from a in db.skins select a).Single(t => t.trangthai == true);
            Biencucbo.skin = lst.tenskin;
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
           
            //txtname.ForeColor = Color.LightGray;
            //txtname.Text = "Please Enter Name";
            //txtpass1.ForeColor = Color.LightGray;
            //txtpass1.Text = "*********";
            imageComboBoxEdit1.Properties.Items.AddEnum(typeof(LanguageEnum));
            LanguageHelper.Language = LanguageEnum.Vietnam;
            imageComboBoxEdit1.EditValue = LanguageHelper.Language;
            txtuser1.Focus();
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string dlg = "";
            if (Biencucbo.ngonngu.ToString() == "Vietnam") dlg = "Bạn muốn thoát phần mềm?";
            else dlg = "ທ່ານຕ້ອງການອອກຈາກລະບົບບໍ່?";
            if (Lotus.MsgBox.ShowYesNoDialog(dlg) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnlogin_Click(sender, e);
                
            }
        }
        private void txtuser_Leave(object sender, EventArgs e)
        {
            //if (txtname.Text == "")
            //{
            //    txtname.Text = "Please Enter Name";
            //    txtname.ForeColor = Color.Gray;
            //}
        }
        private void txtuser_Enter(object sender, EventArgs e)
        {
            //if (txtname.Text == "Please Enter Name")
            //{
            //    txtname.Text = "";
            //    txtname.ForeColor = Color.Black;
            //}
        }
        private void txtpass_Leave(object sender, EventArgs e)
        {
            //    if (txtpass1.Text == "")
            //    {
            //        txtpass1.Text = "*********";
            //        txtpass1.ForeColor = Color.Gray;
            //    }
        }
        private void txtpass_Enter(object sender, EventArgs e)
        {
            //if (txtpass1.Text == "*********")
            //{
            //    txtpass1.Text = "";
            //    txtpass1.ForeColor = Color.Black;
            //}
        }
        //language
        private void btnLangVI_Click(object sender, EventArgs e)
        {
            btnLangVI.Enabled = false;
            btnLangLA.Enabled = true;
            imageComboBoxEdit1_EditValueChanged(sender, e);
            LanguageHelper.Active((LanguageEnum)LanguageEnum.Vietnam);
            Biencucbo.ngonngu = LanguageEnum.Vietnam;
        }
        private void btnLangLA_Click(object sender, EventArgs e)
        {
            btnLangVI.Enabled = true;
            btnLangLA.Enabled = false;
            imageComboBoxEdit1_EditValueChanged(sender, e);
            LanguageHelper.Active((LanguageEnum)LanguageEnum.Lao);
            Biencucbo.ngonngu = LanguageEnum.Lao;
        }
        private void imageComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            LanguageHelper.Active((LanguageEnum)imageComboBoxEdit1.EditValue);
        }
        private void f_login_Load(object sender, EventArgs e)
        {

            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.TransparencyKey = Color.Peru;
            this.BackColor = Color.Peru;
            btnLangVI_Click(sender, e);
            lbldb.Text = "Data: " + Biencucbo.DbName;
            //btnLangVI.Enabled = true;
            //btnLangLA.Enabled = false;
            imageComboBoxEdit1_EditValueChanged(sender, e);
            
            
            txtuser1.Focus();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                try
                {
                    xmlDoc.Load("appconfig.xml");
                }
                catch
                {
                    try
                    {

                        string filepath = "appconfig.xml";
                        WebClient webClient = new WebClient();
                        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                        webClient.DownloadFileAsync(new Uri("http://www.petrolao.com.la/config/CCS/appconfig.xml"), filepath);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
                int Remember = Convert.ToInt32(xmlDoc.DocumentElement["Remember"].InnerText);//gán giá trị cho biến Remmber từ file.xml
                //if (Remember == 1)//xét xem nó bằng 0 hay bằng 1, như mình nói ở trên: 1 là ghi nhớ, 0 là không ghi nhớ
                //{
                //    checkremem.Checked = true;
                //    if (xmlDoc.DocumentElement["lang"].InnerText == "lao")
                //    {
                //        btnLangLA.Enabled = false;
                //        btnLangVI.Enabled = true;
                //    }
                //    else
                //    {
                //        btnLangLA.Enabled = true;
                //        btnLangVI.Enabled = false;
                //    }
                //    txtuser1.Text = xmlDoc.DocumentElement["UserLogin"].InnerText;
                //    txtpass1.Text = (xmlDoc.DocumentElement["PassLogin"].InnerText);
                //    txtpass1.Focus();
                //}
                //else if (Remember == 0)
                //{
                //    checkremem.Checked = false;
                    txtuser1.Text = xmlDoc.DocumentElement["UserLogin"].InnerText;
                    if (xmlDoc.DocumentElement["lang"].InnerText == "lao")
                    {
                        btnLangLA.Enabled = false;
                        btnLangVI.Enabled = true;
                    }
                    else
                    {
                        btnLangLA.Enabled = true;
                        btnLangVI.Enabled = false;
                    }
                    txtuser1.Focus();
                    
                //}
                if (btnLangLA.Enabled== false)
                {
                    LanguageHelper.Active((LanguageEnum)LanguageEnum.Lao);
                    Biencucbo.ngonngu = LanguageEnum.Lao;
                }
                else
                {
                    LanguageHelper.Active((LanguageEnum)LanguageEnum.Vietnam);
                    Biencucbo.ngonngu = LanguageEnum.Vietnam;
                }
            }
            catch
            {


            }

        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }
        private void btnconnect_Click(object sender, EventArgs e)
        {
            f_connectDB frm = new f_connectDB();
            frm.ShowDialog();
            lbldb.Text = "Data: " + Biencucbo.DbName;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void txtidnv_TextChanged(object sender, EventArgs e)
        {
        }
        private void btnlgin_Click(object sender, EventArgs e)
        {
            //Kiểm tra Tên và Pass có tồn tại hay không 
            if (ac.dangnhap(txtuser1.Text, txtpass1.Text).Count == 0)
            {
                Lotus.MsgBox.ShowErrorDialog("Tài khoản hoặc mật khẩu không đúng! Vui lòng kiểm tra lại!");
                txtpass1.Text = "";
            }
            else
            {
                //kiểm tra Tài khoản có đang hoạt động không 
                if (ac.dangnhap2(txtuser1.Text, txtpass1.Text).Count == 0)
                {
                    Lotus.MsgBox.ShowWarningDialog("Tài khoản của bạn đang bị khoá! Vui lòng liên hệ Admin!");
                }
                else
                {
                    var Lst = (from s in db.accounts where s.uname == txtuser1.Text && s.pass == txtpass1.Text select s).Single();
                    dataGridView1.DataSource = Lst;
                    txtname.DataBindings.Clear();
                    txtphongban.DataBindings.Clear();
                    txtmadonvi.DataBindings.Clear();
                    txtidnv.DataBindings.Clear();
                    txtname.DataBindings.Add("text", Lst, "name");
                    txtphongban.DataBindings.Add("text", Lst, "phongban");
                    txtmadonvi.DataBindings.Add("text", Lst, "madonvi");
                    txtidnv.DataBindings.Add("text", Lst, "id");
                    // lấy thông tin máy
                    string hostname = "";
                    System.Net.IPHostEntry ip = new IPHostEntry();
                    hostname = System.Net.Dns.GetHostName();
                    ip = System.Net.Dns.GetHostByName(hostname);
                    Biencucbo.hostname = ip.HostName;
                    foreach (System.Net.IPAddress listip in ip.AddressList)
                    {
                        Biencucbo.IPaddress = listip.ToString();
                    }
                    Biencucbo.ten = Lst.name;
                    Biencucbo.dvTen = Lst.madonvi;
                    Biencucbo.phongban = Lst.phongban;
                    Biencucbo.donvi = Lst.madonvi;
                    Biencucbo.idnv = Lst.id;
                    hs.add("Login", "Đăng nhập - ລົງຊື່ເຂົ້າ");
                    try
                    {
                        //if (checkremem.Checked == true)//Nếu checkbox ghi nhớ được check
                        //{
                        //    XmlDocument xmlDoc = new XmlDocument();
                        //    xmlDoc.Load("appconfig.xml");//mở file.xml lên
                        //    xmlDoc.DocumentElement["UserLogin"].InnerText = txtuser1.Text.Trim();//lưu username
                        //    xmlDoc.DocumentElement["PassLogin"].InnerText = txtpass1.Text.Trim();//lưu mật khẩu
                        //    xmlDoc.DocumentElement["Remember"].InnerText = "1";//đánh dấu = 1 nghĩa là ghi nhớ
                        //    if (btnLangLA.Enabled == false)
                        //    {
                        //        xmlDoc.DocumentElement["lang"].InnerText = "lao";
                        //    }
                        //    else
                        //    {
                        //        xmlDoc.DocumentElement["lang"].InnerText = "viet";
                        //    }
                        //    xmlDoc.Save("appconfig.xml");//save file.xml lại
                        //}
                        //else
                        //{
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load("appconfig.xml");
                            xmlDoc.DocumentElement["UserLogin"].InnerText = txtuser1.Text.Trim();
                            xmlDoc.DocumentElement["PassLogin"].InnerText = "";
                            xmlDoc.DocumentElement["Remember"].InnerText = "0";//đánh dấu = 0 nghĩa là không ghi nhớ
                            if (btnLangLA.Enabled == false)
                            {
                                xmlDoc.DocumentElement["lang"].InnerText = "lao";
                            }
                            else
                            {
                                xmlDoc.DocumentElement["lang"].InnerText = "viet";
                            }
                            xmlDoc.Save("appconfig.xml");
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());

                    }
                    DialogResult = DialogResult.OK;
                }
            }
        }
        private void txtpass1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnlgin_Click(sender, e);
            }
        }

        private void btnLangLA_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLangVI_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
