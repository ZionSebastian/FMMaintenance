using B1WizardBase;
using SAPbouiCOM;
using SBOHelper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMMaintenance.Class_Files;

namespace FMMaintenance
{
    public class Menu__mnuPCR : B1XmlFormMenu
    {
        public Menu__mnuPCR()
        {
            MenuUID = "mnuPCR";
            LoadXml("FM_PCRForm.srf");

            MenuItem oMenuItem = (MenuItem)B1Connections.theAppl.Menus.Item("mnuPC");
            string dir = System.Environment.CurrentDirectory + @"\PowerIcons.jpg";
            oMenuItem.Image = System.Environment.CurrentDirectory + @"\PowerIcons.jpg";
        }

        [B1Listener(BoEventTypes.et_MENU_CLICK, false)]
        public virtual void OnAfterMenuClick(MenuEvent pVal)
        {
            // ADD YOUR ACTION CODE HERE ...

            this.LoadForm();
            SAPbouiCOM.Form oForm = B1Connections.theAppl.Forms.ActiveForm;
            try
            {
                //string test = System.Windows.Forms.Application.StartupPath ;
                oForm.Freeze(true);
                oForm.Mode = BoFormMode.fm_ADD_MODE;
                clsFMMaintenance.AddMode(oForm);
                oForm.Freeze(false);

                
            }
            catch (Exception ex)
            {
                oForm.Freeze(false);
                TNotification.StatusBarError(ex.Message);
            }


        }
    }
}
