using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBOHelper.Utils;
using System.Collections;
using B1WizardBase;
using SAPbobsCOM;
using SAPbouiCOM;
using System.IO;

namespace FMMaintenance.Class_Files
{
    public class clsFMMaintenance
    {
        private static bool bMaxMin;
        private static bool bFlagItemPress;
        private static string sReEntrys;
        private static string sErrorMsg;
        private static int iLineNo;
        private static bool iDoc_SalesEmpSelect;
        private static bool bDOPrint;
        private static bool bPrintPartNo;
        public static bool bCopy_To = false;

        public static void AddMode(SAPbouiCOM.Form _form)
        {

            SAPbouiCOM.Matrix oMatrix = default(SAPbouiCOM.Matrix);
            SAPbouiCOM.ComboBox oCombo = default(SAPbouiCOM.ComboBox);

            string sDateNow = string.Empty;
            string sSQL = string.Empty;
            SAPbouiCOM.Matrix oMatrx;
            SAPbouiCOM.Matrix oMatrx1;

            SAPbouiCOM.Column oColType = default(SAPbouiCOM.Column);
            try
            {
                switch (_form.TypeEx)
                {
                    #region Zion
                    #region Power Consumption Reading
                    case "FM_PCR":
                        var _withPCR = _form.DataSources.DBDataSources.Item("@FM_OPCR");
                        var _withPCR1 = _form.DataSources.DBDataSources.Item("@FM_PCR1");

                        oMatrx = (SAPbouiCOM.Matrix)_form.Items.Item("0_U_G").Specific;
                        EditText txtEdit = (EditText)_form.Items.Item("Item_0").Specific;

                        int new_Window = Convert.ToInt16(TSQL.GetSingleRecord("select Count(DocNum) [Count] from [@FM_OPCR]"));
                        string sql_DocNum = TSQL.GetSingleRecord("select DocNum from [@FM_OPCR]").ToString().Trim();
                        if (new_Window>0)
                        {
                            _form.Mode = BoFormMode.fm_FIND_MODE;
                            txtEdit.Value = sql_DocNum;
                            _form.Items.Item("1").Click(BoCellClickType.ct_Regular);
                        }
                        else
                        {
                            TComboBox.LoadSeries(_form, "Item_2", "FM_PCR");
                            //@TABLE is the name of the DBDataSource the form's connect to 
                            //_withBER.SetValue("Series", 0, TUser.GetDefaultSeriesBranch("FM_BER"));
                            string series1 = TUser.GetDefaultSeries("FM_PCR", SeriesReturnType.Series);
                            _withPCR.SetValue("Series", 0, TUser.GetDefaultSeries("FM_PCR", SeriesReturnType.Series));
                            _withPCR.SetValue("DocNum", 0, Convert.ToString(TDocument.GetNextDocNo(_form, TUser.GetDefaultSeriesBranch("_withPCR"))));
                        }


                        DateTime sql_DocDate = Convert.ToDateTime(TSQL.GetSingleRecord("select TOP 1 U_DocDate from [@FM_PCR1] ORDER BY U_DocDate DESC ").ToString().Trim());
                        if (sql_DocDate != System.DateTime.Now.Date)
                        {
                            oMatrx = (SAPbouiCOM.Matrix)_form.Items.Item("0_U_G").Specific;

                            for (int i = 1; i < 2; i++)
                            {
                                oMatrx.FlushToDataSource();
                                TMatrix.addRow(_form, "0_U_G", "#", "@FM_PCR1");
                                TMatrix.RefreshRowNo(_form, "0_U_G", "#");
                                _withPCR1.SetValue("U_DocDate", oMatrx.RowCount - 1, System.DateTime.Today.ToString("yyyyMMdd"));
                                _withPCR1.SetValue("U_Day", oMatrx.RowCount - 1, TSQL.GetSingleRecord("select DATENAME(WEEKDAY, DocDate) from OINV").ToString().Trim());
                                oMatrx.LoadFromDataSource();
                                oMatrx.SelectRow(oMatrx.RowCount , true, true);
                                EditText oEditDate = oMatrx.Columns.Item("C_0_1").Cells.Item(oMatrx.RowCount).Specific;
                                EditText oEditDay = oMatrx.Columns.Item("C_0_2").Cells.Item(oMatrx.RowCount).Specific;
                                oEditDate.ForeColor = System.Drawing.Color.Green.ToArgb();
                                oEditDay.ForeColor = System.Drawing.Color.Green.ToArgb();
                            }
                        }



                        break;
                    #endregion

                    

                        #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void FindMode(SAPbouiCOM.Form oForm)
        {
            switch (oForm.TypeEx)
            {
                #region zion
                
                #endregion


            }
        }

    }
}
