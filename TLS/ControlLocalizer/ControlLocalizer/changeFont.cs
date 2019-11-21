using DevExpress.XtraBars;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
namespace ControlLocalizer
{
  

    public static class changeFont
    {
       
        public static LanguageEnum Language
        {
            get { return LanguageHelper.Language; }
        }


        public static System.Drawing.Font FontVN = new System.Drawing.Font("Tahoma", 8.25f);
        public static System.Drawing.Font FontLao = new System.Drawing.Font("Saysettha OT", 8.25f);
         
        //public static System.Drawing.Font FontVN_16 = new System.Drawing.Font("Tahoma",);
        //public static System.Drawing.Font FontLao_16 = new System.Drawing.Font("Saysettha OT", 16f);

        //public static System.Drawing.Font FontLao = new System.Drawing.Font("Saysettha Unicode", 8.25f);
        //public static System.Drawing.Font FontLao = new System.Drawing.Font("Saysettha MX Regular", 8.25f);


        //public static System.Drawing.Font FontVN = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        //public static System.Drawing.Font FontLao = new System.Drawing.Font("Saysettha OT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


        public static void Translate(object control)
        {
            if (control == null) return;

            if (control is Form)
                TranslateForm(control as Form);
            else if (control is LayoutControl)
                TranslateLayoutControl(control as LayoutControl);
            else if (control is GridControl)
                TranslateGridControl(control as GridControl);

            else if (control is XtraReport)
                TranslateReport(control as XtraReport);

            else if (control is RibbonControl)
                TranslateRibbonControl(control as RibbonControl);

            else if (control is BarManager)
                TranslateBarManagerControl(control as BarManager);

            else if (control is BaseButton)
            {
                Control c = control as BaseButton;

                if (Language == LanguageEnum.Lao)
                    c.Font = FontLao;
                else
                    c.Font = FontVN;
            }
            else if (control is TextEdit)
            {
                return;
            }
            else if (control is Control)
            {
                Control c = control as Control;
                
                if (Language == LanguageEnum.Lao)
                    c.Font = FontLao;
                else
                    c.Font = FontVN; 
            } 
        }

        private static void TranslateReport(XtraReport xtraReport)
        {
            //font size= 16pt
            var list = xtraReport.AllControls<XRControl>();
            foreach (var c in list)
            {
                if (Language == LanguageEnum.Lao)
                    c.Font = new System.Drawing.Font("Saysettha Unicode", c.Font.Size, c.Font.Style);
                else
                    c.Font = new System.Drawing.Font("Times New Roman", c.Font.Size, c.Font.Style);
            }
        }

        private static void TranslateBarManagerControl(BarManager barManager)
        {
            foreach (BarItem i in barManager.Items)
            { 
                    if (Language == LanguageEnum.Lao)
                        i.ItemAppearance.Normal.Font = FontLao;
                    else
                        i.ItemAppearance.Normal.Font = FontVN; 
            }
        }

        //static void DuyetMenuItems(BarItemLink link, BarItemLink parent)
        //{
        //    if (link is BarButtonItemLink)
        //    {
        //        var itemLink = link as BarButtonItemLink;
        //        if (itemLink.Caption != string.Empty)
        //        {
        //            string name = link.Bar.Manager.Form.Name + "." + link.Bar.BarName + "." + itemLink.Item.Name;
        //            itemLink.Caption = TranslateString(name, itemLink.Caption);
        //        }
        //    }
        //    else if (link is BarSubItemLink)
        //    {
        //        var subItem = link as BarSubItemLink;
        //        foreach (BarItemLink item in subItem.Item.ItemLinks)
        //            DuyetMenuItems(item, link);
        //    }
        //}

        private static void TranslateBarDockControl(BarDockControl barDockControl)
        {
        }

        private static void TranslateRibbonControl(RibbonControl ribbonControl)
        {
            foreach (RibbonPage page in ribbonControl.Pages)
            {
                if (Language == LanguageEnum.Lao) 
                    page.Appearance.Font = FontLao; 
                else
                    page.Appearance.Font = FontVN;

                foreach (RibbonPageGroup g in page.Groups)
                {  
                    //g.Text = TranslateString(gname, g.Text);
                   //ko co font
                   
                    foreach (BarItemLink i in g.ItemLinks)
                    {
                        if (Language == LanguageEnum.Lao)
                        {
                            i.Item.ItemAppearance.Normal.Font = FontLao;
                            i.Item.ItemAppearance.Disabled.Font = FontLao;
                            i.Item.ItemAppearance.Hovered.Font = FontLao;
                            i.Item.ItemAppearance.Pressed.Font = FontLao;
                        }
                        else
                        {
                            i.Item.ItemAppearance.Normal.Font = FontVN;
                            i.Item.ItemAppearance.Disabled.Font = FontVN;
                            i.Item.ItemAppearance.Hovered.Font = FontVN;
                            i.Item.ItemAppearance.Pressed.Font = FontVN;
                        }

                        if (i.Item is BarSubItem)
                        {
                            var sub = i.Item as BarSubItem;

                            foreach (BarItemLink y in sub.ItemLinks)
                            {
                                if (Language == LanguageEnum.Lao)
                                {
                                    y.Item.ItemAppearance.Normal.Font = FontLao;
                                    y.Item.ItemAppearance.Disabled.Font = FontLao;
                                    y.Item.ItemAppearance.Hovered.Font = FontLao;
                                    y.Item.ItemAppearance.Pressed.Font = FontLao;
                                }
                                else
                                {
                                    y.Item.ItemAppearance.Normal.Font = FontVN;
                                    y.Item.ItemAppearance.Disabled.Font = FontVN;
                                    y.Item.ItemAppearance.Hovered.Font = FontVN;
                                    y.Item.ItemAppearance.Pressed.Font = FontVN;
                                }
                            }
                        }
                    }
                }
            }
        }

     
        private static void TranslateGridControl(GridControl gridControl)
        {
            ColumnView view = gridControl.MainView as ColumnView;
            if (view == null) return;
             

            var gv = view as GridView;
            if (gv == null) return;
            if (Language == LanguageEnum.Lao)
            {
                //gv.Appearance.Row.Font =
                gv.Appearance.HeaderPanel.Font = FontLao;
            }
            else
            {
                //gv.Appearance.Row.Font =
                gv.Appearance.HeaderPanel.Font = FontVN;
            }

        }

        private static void TranslateLayoutControl(LayoutControl l)
        {
            foreach (BaseLayoutItem item in l.Items)
            {
                if (item is EmptySpaceItem) continue;
                LayoutControlItem li = item as LayoutControlItem;
                if (li != null)
                    Translate(li.Control);

                if (item.Text.Contains("layoutControlItem")) continue;

                if (Language == LanguageEnum.Lao)
                {
                    item.AppearanceItemCaption.Font = FontLao;
                }
                else
                {
                    item.AppearanceItemCaption.Font = FontVN;
                }
            }
        }

        private static string GetFullName(Control c)
        {
            return c.FindForm().Name + "." + c.Name;
        }
         

        private static void TranslateForm(Form form)
        {
            foreach (Control c in form.Controls)
                Translate(c);
        }
    }

  
}
