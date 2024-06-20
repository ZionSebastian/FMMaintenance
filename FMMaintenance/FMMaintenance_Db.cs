using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using SAPbouiCOM;
using B1WizardBase;

namespace FMMaintenance
{
    public class FMMaintenance_Db:B1Db
    {
        public FMMaintenance_Db()
        {
            Tables = new B1DbTable[] {

                #region Zion
                
                    #region Power Consumption Reading
                new B1DbTable("@FM_OPCR", "Power Consumption Reading", BoUTBTableType.bott_Document),
                new B1DbTable("@FM_PCR1", "Power Consumption Reading Row", BoUTBTableType.bott_DocumentLines),
                    #endregion

                #endregion
            };

            Columns = new B1DbColumn[]
            {
                #region Zion
                
                    #region Power Consumption Reading
                   new B1DbColumn("@FM_PCR1", "DocDate", "Document Date", BoFieldTypes.db_Date, BoFldSubTypes.st_None, 0, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "Day", "Day", BoFieldTypes.db_Alpha, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "MainFdr", "Main Feeder", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "RollMilAx", "Rolling Mill Aux", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "FrnceC1", "Furnace C1", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "FrnceC2", "Furnace C2", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "FrnceD", "Furnace D", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "FrnceE", "Furnace E", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "ScrapYd", "Scrap Yard", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "ENDEKwh", "Ende Kwh", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "ENDEKvarh", "Ende Kvarh", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "SectnMill", "Section Mill", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                   new B1DbColumn("@FM_PCR1", "Aux30Kva", "Aux tr 30Kva", BoFieldTypes.db_Numeric, BoFldSubTypes.st_None, 10, true, new B1WizardBase.B1DbValidValue[-1 + 1], -1),
                    #endregion

                    
                    
                #endregion
            };

            Udos = new B1Udo[] {
                #region Zion
                
                    #region Power Consumption Reading
                     new B1Udo("FM_PCR","Power Consumption Reading", "FM_OPCR", new string[] {
                                     "FM_PCR1"}, BoUDOObjType.boud_Document, BoYesNoEnum.tYES, BoYesNoEnum.tNO, BoYesNoEnum.tNO, BoYesNoEnum.tNO,
                                BoYesNoEnum.tNO, BoYesNoEnum.tYES, BoYesNoEnum.tYES, null, new string[]{ "DocEntry","DocNum"}, new string[]{ "DocEntry","DocNum"}),
                    #endregion
                    
                 #endregion
                };
        }

    }
}
