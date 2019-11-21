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
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace GUI
{
    public partial class f_Skin : Form
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();
        t_skinabc sk = new t_skinabc();
        ImageCollection img;
        public f_Skin()
        {
            InitializeComponent();
            img = new ImageCollection();
            imageComboBoxEdit1.Properties.SmallImages = img;
            for (int i = 0; i < SkinManager.Default.Skins.Count; i++)
            {
                string skinName = SkinManager.Default.Skins[i].SkinName;
                img.AddImage(SkinCollectionHelper.GetSkinIcon(skinName, SkinIconsSize.Small), skinName);
                imageComboBoxEdit1.Properties.Items.Add(new ImageComboBoxItem(skinName, i));
                //if (skinName == Properties.Settings.Default.theme)
                //{
                //    imageComboBoxEdit1.SelectedIndex = i;
                //}
            }

            //defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Properties.Settings.Default.theme);


        }
      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (imageComboBoxEdit1.Text == "")
                return;
            sk.sua(Biencucbo.skin);
            f_main frm = new f_main();
            frm.Refresh();
            this.Close();
            
        }
        private void f_Skin_Load(object sender, EventArgs e)
        {
            var lst = (from a in new KetNoiDBDataContext().skins select a).Single(t => t.trangthai == true);
            Biencucbo.skin = lst.tenskin;
            //defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Biencucbo.skin);
            //LanguageHelper.Translate(this); 
            //Biencucbo.skin2 = Biencucbo.skin; 
        }
        private void Skinht_EditValueChanged(object sender, EventArgs e)
        {
            
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            Biencucbo.skin = Biencucbo.skin2;
            f_main frm = new f_main();
            frm.Refresh();
            this.Close();
        }

        private void imageComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Biencucbo.skin = imageComboBoxEdit1.Text;
            f_main frm = new f_main();
            frm.Refresh();
        }
    }
}
