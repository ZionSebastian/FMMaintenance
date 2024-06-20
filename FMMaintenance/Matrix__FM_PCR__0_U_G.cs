using SAPbobsCOM;
using SAPbouiCOM;
using B1WizardBase;
using System;
using SBOHelper.Utils;

namespace FMMaintenance
{
    class Matrix__FM_PCR__0_U_G:B1Item
    {
        public Matrix__FM_PCR__0_U_G()
        {
            FormType = "FM_PCR";
            ItemUID = "0_U_G";
        }
        [B1Listener(BoEventTypes.et_RIGHT_CLICK, true)]
        public virtual bool OnBeforeRightClick(ContextMenuInfo pVal)
        {
            Form form = B1Connections.theAppl.Forms.Item(pVal.FormUID);
            Item item = form.Items.Item("0_U_G");
            Matrix matrix = ((Matrix)(item.Specific));
            // ADD YOUR ACTION CODE HERE ...
            SAPbouiCOM.Form oForm = default(SAPbouiCOM.Form);

            try
            {
                oForm = B1Connections.theAppl.Forms.ActiveForm;
                switch (pVal.ColUID)
                {
                    case "#":
                        oForm.EnableMenu("1292", true);
                        oForm.EnableMenu("1293", true);

                        break;
                    default:
                        oForm.EnableMenu("1292", true);
                        oForm.EnableMenu("1293", true);
                        break;
                }

            }
            catch (Exception ex)
            {
                TNotification.StatusBarError(ex.Message);
            }
            finally
            {
                form.Freeze(false);
            }
            return true;
        }

        [B1Listener(BoEventTypes.et_VALIDATE, false)]
        public virtual void OnAfterValidate(ItemEvent pVal)
        {
            bool ActionSuccess = pVal.ActionSuccess;
            Form form = B1Connections.theAppl.Forms.Item(pVal.FormUID);
            Item item = form.Items.Item("0_U_G");
            var matrix = (Matrix)item.Specific;
            // ADD YOUR ACTION CODE HERE ...
            try
            {
                if (pVal.InnerEvent == false)
                {
                    form.Freeze(true);
                    var with = form.DataSources.DBDataSources.Item("@FM_OPCR");
                    var with1 = form.DataSources.DBDataSources.Item("@FM_PCR1");
                    SAPbouiCOM.Matrix oMat = (SAPbouiCOM.Matrix)form.Items.Item("0_U_G").Specific;
                    SAPbobsCOM.Recordset oRes = null;
                    oRes = (SAPbobsCOM.Recordset)B1Connections.diCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    if (pVal.ActionSuccess)
                    {
                        double TotalUseQty = 0;
                        switch (pVal.ColUID)
                        {
                            case "C_0_1":
                                {
                                    matrix.FlushToDataSource();
                                    string docDate = with1.GetValue("U_DocDate", pVal.Row - 1).ToString();
                                    //DateTime sqlDocDate= Convert.ToDateTime(with1.GetValue("U_DocDate", pVal.Row-1));
                                    string sqlDay = TSQL.GetSingleRecord("select DATENAME(WEEKDAY,'"+ docDate + "')");
                                    with1.SetValue("U_Day",pVal.Row-1, sqlDay);
                                    matrix.LoadFromDataSource();
                                    break;
                                }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                form.Freeze(false);
                TNotification.StatusBarError(ex.Message);
            }
            finally
            {
                form.Freeze(false);
            }
        }
    }
}
