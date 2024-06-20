using B1WizardBase;
using SAPbouiCOM;
using SBOHelper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMMaintenance
{
    public class Menu__1292: B1Menu
    {
        public Menu__1292()
        {
            MenuUID = "1292";
        }
        [B1Listener(BoEventTypes.et_MENU_CLICK, true)]
        public virtual bool OnBeforeMenuClick(MenuEvent pVal)
        {
            // ADD YOUR ACTION CODE HERE ...
            SAPbouiCOM.Form oForm = default(SAPbouiCOM.Form);
            SAPbouiCOM.Matrix oMatrix = default(SAPbouiCOM.Matrix);
            SAPbouiCOM.ComboBox oCombo = default(SAPbouiCOM.ComboBox);

            bool retVale = true;
            string sSQL = string.Empty;
            SAPbobsCOM.Recordset rs = null;

            try
            {
                oForm = B1Connections.theAppl.Forms.ActiveForm;

                switch (oForm.TypeEx)
                {

                    #region Zion


                    case "FM_PCR":
                        oForm.Freeze(true);
                        if (oForm.PaneLevel == 1)
                        {
                            TMatrix.addRow(oForm, "0_U_G", "#", "@FM_PCR1");
                            TMatrix.RefreshRowNo(oForm, "0_U_G", "#");
                            
                        }
                        oForm.Freeze(false);
                        return false;
                        break;

                    #endregion

                }
                return false;
            }
            catch (Exception ex)
            {
                TNotification.StatusBarError(ex.Message);
            }
            finally
            {

            }
            return true;
        }
    }
}
