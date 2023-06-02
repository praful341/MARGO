using System;
using System.Data;                                                                                                                                                                                
using DLL;
using System.Collections;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Transaction;

namespace BLL.FunctionClasses.Master
{
    public class LabourRateMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Property Settings

        private DataTable _DTab = new DataTable("Party_Labour_Master");

        public DataTable DTab
        {
            get { return _DTab; }
            set { _DTab = value; }
        }

        #endregion

        public int FindNewJangedNo(string pStrDate)
        {
            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Party_Labour_Master", "MAX(LABOUR_CODE)", " And EFFECTIVE_DATE = '" + Val.DBDate(pStrDate) + "' ");
        }

        #region Other Function

        public Int64 FindNewID(int pIntLedgerCode, int pIntSubLedgerCode, string pStrEffectiveDate)
        {
            return Ope.FindNewIDInt64(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Party_Labour_Master", "MAX(LABOUR_CODE)", " And LEDGER_CODE = '" + pIntLedgerCode.ToString() + "' And SUB_LEDGER_CODE = '" + pIntSubLedgerCode.ToString() + "' And EFFECTIVE_DATE = '" + pStrEffectiveDate + "'");
        }

        //public int Save(Labour_Rate_MasterProperty pClsProperty)
        //{
        //    //pClsProperty.Record_Code = FindRecordCode(pClsProperty.Labour_Code);
        //    //pClsProperty.Record_Code = new RecordMaster().Save(pClsProperty.Record_Code);

        //    Request Request = new Request();
            
        //    Request.AddParams("LABOUR_CODE_", pClsProperty.Labour_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);            
        //    Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SUB_LEDGER_CODE_", pClsProperty.Sub_Ledger_Code, DbType.Int32, ParameterDirection.Input);            
        //    Request.AddParams("LABOUR_TYPE_", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            
        //    Request.AddParams("CRITERIA_", pClsProperty.Criteria, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FROM_CENT_", pClsProperty.From_Cent, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TO_CENT_", pClsProperty.To_Cent, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);            
        //    Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.Int32, ParameterDirection.Input); 
        //    Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);            
        //    Request.AddParams("RATE_", pClsProperty.Rate, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ACTIVE_", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("EFFECTIVE_DATE_", pClsProperty.Effective_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("RECORD_CODE_", pClsProperty.Record_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.CommandText = "Labour_Rate_Master_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //}

        public DataTable CopyAndPaster(Labour_Rate_MasterProperty pClsCopyProperty, Labour_Rate_MasterProperty pClsPasteProperty)
        {
            Request Request = new Request();

            //Request.AddParams("LEDGER_CODE_", pClsCopyProperty.Ledger_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("SUB_LEDGER_CODE_", pClsCopyProperty.Sub_Ledger_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("LABOUR_TYPE_", pClsCopyProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            //Request.AddParams("ROUGH_NAME_", pClsCopyProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            //Request.AddParams("CRITERIA_", pClsCopyProperty.Criteria, DbType.String, ParameterDirection.Input);
            //Request.AddParams("SHAPE_CODE_", pClsCopyProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("ARTICLE_CODE_", pClsCopyProperty.Article_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("EFFECTIVE_DATE_", pClsCopyProperty.Effective_Date, DbType.Date, ParameterDirection.Input);

            //Request.AddParams("CLEDGER_CODE_", pClsPasteProperty.Ledger_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("CSUB_LEDGER_CODE_", pClsPasteProperty.Sub_Ledger_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("CLABOUR_TYPE_", pClsPasteProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            //Request.AddParams("CCRITERIA_", pClsPasteProperty.Criteria, DbType.String, ParameterDirection.Input);
            //Request.AddParams("CSHAPE_CODE_", pClsPasteProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("CARTICLE_CODE_", pClsPasteProperty.Article_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("CEFFECTIVE_DATE_", pClsPasteProperty.Effective_Date, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "Labour_Rate_Master_CopyGetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;

        }

        public int Delete(Labour_Rate_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@LABOUR_CODE", pClsProperty.Labour_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@PARTY_CODE", pClsProperty.Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@EFFECTIVE_DATE", pClsProperty.Effective_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LABOUR_TYPE", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CRITERIA", pClsProperty.Criteria, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PROCESS_CODE", pClsProperty.Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@STATUS", pClsProperty.Status, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Labour_Rate_Master_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetBillData(string pStrFromSubPartyCode, string pStrToSubPartyCode, string pStrFromProcess, string pStrFromDate, string pStrToDate)
        {
            DataTable DTabBillNo = new DataTable();
            Request Request = new Request();

            Request.AddParams("@FROM_SUB_PARTY_CODE_", pStrFromSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_SUB_PARTY_CODE_", pStrToSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pStrFromProcess, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "Labour_Bill_GetBillNo";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabBillNo, Request, "");
            return DTabBillNo;
        }

        public Int64 FindNewBillNo(string pStrToSubPartyCode, string pStrProcess, string pIntMonth)
        {
            Request Request = new Request();
            Request.AddParams("@TO_PARTY_CODE_", pStrToSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pStrProcess, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TDate_", pIntMonth, DbType.Date, ParameterDirection.Input);
            Request.CommandText = "Labour_Bill_FindNewBillNo"; //"Labour_Bill_FindNew_Test";
            Request.CommandType = CommandType.StoredProcedure;

            DataTable DTAB = new DataTable();
            Int64 StrRes = 0;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request, "");
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    StrRes = Convert.ToInt64(DTAB.Rows[0][0]);
                }
            }
            return StrRes;
        }

        public Int64 UpdateJangedBill(Int64 pIntLinkCode, string pStrToSubPartyCode, string pStrFromProcessCode, string tDate, string pStrBillNo, Int64 PIntBillInt, Int64 pDouTDSAmount, string pStrFromDate, string pStrToDate, string pStrBillDate)
        {
            Request Request = new Request();
            Request.AddParams("@TO_PARTY_CODE_", pStrToSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pStrFromProcessCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LINK_CODE_", pIntLinkCode, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@MONTH_", pIntMonth, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@YEAR_", pIntYear, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@tDate_", tDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@BILL_NO_", pStrBillNo, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BILL_INT_", PIntBillInt, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BILL_USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TDS_AMOUNT_", pDouTDSAmount, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@BILL_DATE_", pStrBillDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@BILL_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Labour_Bill_UpdateBillNo";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //DataTable DTab = new DataTable();
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //return DTab;
        }

        #region Labour Bill Related

        public DataTable ViewBillData(string pStrFromSubPartyCode, string pStrToSubPartyCode, string pStrFromProcess, string pStrFromDate, string pStrToDate)
        {
            DataTable DTabBillNo = new DataTable("");
            Request Request = new Request();

            Request.AddParams("@FROM_PARTY_CODE_", pStrFromSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE_", pStrToSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pStrFromProcess, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_DATE_", pStrFromDate, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_DATE_", pStrToDate, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Labour_Bill_ViewBill";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabBillNo, Request);
            return DTabBillNo;
        }

        public DataTable LabourBillPrint(string pStrToSubPartyCode, string pStrBillNo)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
           // Request.AddParams("@FROM_PARTY_CODE_", pIntFromSubPartyCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE_", pStrToSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BILL_NO_", pStrBillNo, DbType.String, ParameterDirection.Input);
            Request.CommandText = "RP_Labour_Bill_Print";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }


        public DataTable GetPartyAddress(string pStrToPartyCode)
        {
            DataTable DTabPartyAddress = new DataTable();
            Request Request = new Request();

            Request.AddParams("@PARTY_CODE_", pStrToPartyCode, DbType.String, ParameterDirection.Input);

            Request.CommandText = "RP_LEDGER_ADDRESS";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabPartyAddress, Request);
            return DTabPartyAddress;
        }

        public DataTable LabourChargesSummary(Mix_IssRet_MasterProperty PClsProperty) //Khushbu 13/02/2014
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.AddParams("@FROM_PARTY_CODE_", PClsProperty.From_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE_", PClsProperty.To_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PROCESS_CODE_", PClsProperty.Process_Multi, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_ISSUE_DATE_", PClsProperty.From_Janged_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_ISSUE_DATE_", PClsProperty.To_Janged_Date, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Labour_Bill_Charges_Sum";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int DeleteBillData(string pStrFromSubPartyCode, string pStrToSubPartyCode, string pStrFromProcess, string pStrFromDate, string pStrToDate)
        {
            Request Request = new Request();

            Request.AddParams("@FROM_PARTY_CODE_", pStrFromSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE_", pStrToSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pStrFromProcess, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_DATE_", pStrFromDate, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_DATE_", pStrToDate, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Labour_Bill_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetLabourData(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.CommandText = "Update_LabourRate_GetData";

            Request.AddParams("@FROM_JANGED_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_JANGED_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@FROM_SUB_PARTY_MULTI_", pClsProperty.From_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_SUB_PARTY_MULTI_", pClsProperty.To_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PROCESS_CODE_", pClsProperty.Process_Multi, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE_", pClsProperty.Shape_Multi, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE_", pClsProperty.Sieve_Multi, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Multi, DbType.String, ParameterDirection.Input);
            //Request.AddParams("FROM_CHADTA_", pClsProperty.From_Chadta, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("TO_CHADTA_", pClsProperty.To_Chadta, DbType.Double, ParameterDirection.Input);

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int UpdateLabourRate(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "Update_LabourRate_Save";

            Request.AddParams("@JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@JANGED_NO_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@JANGED_SRNO_", pClsProperty.Janged_SrNo, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TRN_ID_", pClsProperty.Trn_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SRNO_", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LABOUR_TYPE_", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LABOUR_RATE_", pClsProperty.Labour_Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LABOUR_AMOUNT_", pClsProperty.Labour_Amount, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@UPDATE_USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@UPDATE_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@OUT_INT_", 0, DbType.Int32, ParameterDirection.Output);
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //ArrayList AL = Ope.ExecuteNonQueryWithRetunValuesWithConn(DLL.GlobalDec.ConnectionA, Request);
            //return 1;
        }

        #endregion

        public DataTable GetLabourMasterData()
        {
            Request Request = new Request();
            Request.CommandText = "Labour_Rate_Master_Search_GetData";
            //Request.AddParams("@LABOUR_CODE", pClsProperty.Labour_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@PARTY_CODE", pClsProperty.Party_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@PROCESS_CODE", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@SHAPE_CODE", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@LABOUR_TYPE", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@CRITERIA", pClsProperty.Criteria, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@STATUS", pClsProperty.Status, DbType.String, ParameterDirection.Input);
           // Request.AddParams("@EFFECTIVE_DATE", pClsProperty.Effective_Date, DbType.Date, ParameterDirection.Input);
            
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }       

        public DataTable GetPopUpData(Labour_Rate_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "Labour_Rate_Master_Getpopup";
           // Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SUB_LEDGER_CODE_", pClsProperty.Sub_Ledger_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CRITERIA_", pClsProperty.Criteria, DbType.String, ParameterDirection.Input);
           
            // Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            
            Request.AddParams("LABOUR_TYPE_", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("EFFECTIVE_DATE_", pClsProperty.Effective_Date, DbType.Date, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetDataForSearch()
        {
            DataTable DTabSearch = new DataTable();
            Request Request = new Request();
            Request.CommandText = "Labour_Rate_Master_GetSearch";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabSearch, Request, "");
            return DTabSearch;
        }

   
        //public Labour_Rate_MasterProperty GetLabourRate(string pStrRoughName, int pIntLedgerCode, int pIntSubLedgerCode, int pIntProcess, int pIntPcs, double pDouCarat, int pIntSieveCode, int pIntMFGClarityCode, int pIntShapeCode, string pStrDate)
        //{
        //    double DouCent = 0;

        //    if (pIntPcs != 0)
        //    {
        //        DouCent = Math.Round(Val.Val(pDouCarat) / Val.Val(pIntPcs), 2);
        //    }

        //    Request Request = new Request();

        //    Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("LEDGER_CODE_", pIntLedgerCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SUB_LEDGER_CODE_", pIntSubLedgerCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_CODE_", pIntProcess, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("CENT_", DouCent, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("SIEVE_CODE_", pIntSieveCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MFG_CLARITY_CODE_", pIntMFGClarityCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SHAPE_CODE_", pIntShapeCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DATE_", pStrDate, DbType.Date, ParameterDirection.Input);

        //    Request.CommandText = "Labour_Rate_Master_GetRate" + "N";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    DataTable DTab = new DataTable();

        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);

        //    if (DTab == null)
        //    {
        //        return null;
        //    }

        //    if (DTab.Rows.Count <= 0)
        //    {
        //        return null;
        //    }

        //    DataRow DRow = DTab.Rows[0];

        //    if (DRow == null)
        //    {
        //        return null;
        //    }

        //    Labour_Rate_MasterProperty Property = new Labour_Rate_MasterProperty();

        //    Property.Labour_Code = Val.ToInt64(DRow["LABOUR_CODE"]);
        //    Property.Process_Code = Val.ToInt64(DRow["PROCESS_CODE"]);
        //    Property.Ledger_Code = Val.ToInt(DRow["LEDGER_CODE"]);
        //    Property.Labour_Type = Val.ToString(DRow["LABOUR_TYPE"]);
        //    Property.Criteria = Val.ToString(DRow["CRITERIA"]);
            
        //    //Property.Rough_Name = Val.ToString(DRow["ROUGH_NAME"]);

        //    Property.From_Cent = Val.Val(DRow["FROM_CENT"]);
        //    Property.To_Cent = Val.Val(DRow["TO_CENT"]);
        //    Property.Sieve_Code = Val.ToInt(DRow["SIEVE_CODE"]);
        //    Property.MFG_Clarity_Code = Val.ToInt(DRow["MFG_CLARITY_CODE"]);
        //    Property.Rate = Val.Val(DRow["RATE"]);

        //    DTab.Dispose();
        //    DTab = null;
        //    DRow = null;

        //    if (Property.Labour_Type == "PCS")
        //    {
        //        Property.Amount = Val.Val(Property.Rate * pIntPcs);
        //    }
        //    else if (Property.Labour_Type == "CARAT")
        //    {
        //        Property.Amount = Val.Val(Property.Rate * pDouCarat);
        //    }

        //    return Property;

        //}

        /* Function For Exisitng Manager And Process Wise Rate*/

        public DataTable GetExistData(Labour_Rate_MasterProperty pClsProperty)
        {
            //if (DTab != null)
            //{
            //    DTab.Rows.Clear();
            //}

            DataTable Temp = new DataTable();

            Request Request = new Request();

            Request.CommandText = "Labour_Rate_Master_IsExist";
            Request.AddParams("SUB_LEDGER_CODE_", pClsProperty.Sub_Ledger_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CRITERIA_", pClsProperty.Criteria, DbType.String, ParameterDirection.Input);
            Request.AddParams("LABOUR_TYPE_", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("EFFECTIVE_DATE_", pClsProperty.Effective_Date, DbType.Date, ParameterDirection.Input);

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Temp, Request, "");
            return Temp;
        }

        /* Copy- Paste Function To Transfer Labour Rate From One Date To Another Effective Date */

        public int CopyPaste(string pStrFromDate, string pStrToDate)
        {
            //pClsProperty.Record_Code = FindRecordCode(pClsProperty.Labour_Code);
            //pClsProperty.Record_Code = new RecordMaster().Save(pClsProperty.Record_Code);

            Request Request = new Request();

            Request.AddParams("FROM_EFFECTIVE_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_EFFECTIVE_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "Labour_Rate_Master_CopyPaste";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        #endregion

        

        #region New Labour Rate Master


        public DataTable GetLabourRateDataFromNew(Labour_Rate_MasterProperty pClsProperty)
        {
            DataTable Temp = new DataTable();

            Request Request = new Request();
            Request.CommandText = "Labour_Rate_Master_GetData";

            Request.AddParams("@PROCESS_CODE", pClsProperty.Process_Code, DbType.Int64, ParameterDirection.Input);           
            Request.AddParams("@PARTY_CODE", pClsProperty.Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@EFFECTIVE_DATE", pClsProperty.Effective_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@LABOUR_TYPE", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CRITERIA", pClsProperty.Criteria, DbType.String, ParameterDirection.Input);           
            Request.AddParams("@STATUS", pClsProperty.Status, DbType.String, ParameterDirection.Input);
          
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Temp, Request, "");
            return Temp;
        }

        //public int DeleteNew(Labour_Rate_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input); 
        //    Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SUB_LEDGER_CODE_", pClsProperty.Sub_Ledger_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("EFFECTIVE_DATE_", pClsProperty.Effective_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("LABOUR_TYPE_", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("CRITERIA_", pClsProperty.Criteria, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("MSIZE_CODE_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("QUALITY_CODE_", pClsProperty.Quality_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("SUBQUALITY_CODE_", pClsProperty.Sub_Quality_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("SHAPE_SELECT_", pClsProperty.Shape_Select, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = "Labour_Rate_Master_Delete_NEW";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        public int Save(Labour_Rate_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@PROCESS_CODE", pClsProperty.Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@LABOUR_CODE", pClsProperty.Labour_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@PARTY_CODE", pClsProperty.Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@EFFECTIVE_DATE", pClsProperty.Effective_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@LABOUR_TYPE", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CRITERIA", pClsProperty.Criteria, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLARITY_CODE", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_CENT", pClsProperty.From_Cent, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_CENT", pClsProperty.To_Cent, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RATE", pClsProperty.Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SHAPE", "", DbType.String, ParameterDirection.Input);
            Request.AddParams("@STATUS", pClsProperty.Status, DbType.String, ParameterDirection.Input);
            Request.AddParams("@REMARK", "", DbType.String, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@ENTRY_BY", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ENTRY_IP", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Labour_Rate_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable SearchNew(string pStrSubPartyCode,
                            string pStrProcessCode,
                            string pStrShapeType,
                            string pStrArticleCode,
                            string pStrSieveCode,
                            string pStrCriteria,
                            string pStrLabourType,
                            string pStrFromEffectiveDate,
                            string pStrToEffectiveDate,
                            int pIntAllLabour
                    )
        {
            DataTable DTabSearch = new DataTable();
            //pClsProperty.Record_Code = FindRecordCode(pClsProperty.Labour_Code);
            //pClsProperty.Record_Code = new RecordMaster().Save(pClsProperty.Record_Code);

            Request Request = new Request();

            Request.AddParams("SUB_LEDGER_CODE_", pStrSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", pStrProcessCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_CODE_", pStrArticleCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("SHAPE_SELECT_", pStrShapeType, DbType.String, ParameterDirection.Input);
            Request.AddParams("CRITERIA_", pStrCriteria, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pStrSieveCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("LABOUR_TYPE_", pStrLabourType, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pStrFromEffectiveDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToEffectiveDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("IS_ALL_LABOUR_", pIntAllLabour, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Labour_Rate_Master_Search_New";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabSearch, Request);
            return DTabSearch;

        }
        public DataTable PrintNew(
                            string pStrYearMonth,
                            string pStrSubPartyCode,
                            string pStrProcessCode,
                            string pStrShapeType,
                            string pStrArticleCode,
                            string pStrSieveCode,
                            string pStrCriteria,
                            string pStrLabourType,
                            string pStrFromEffectiveDate,
                            string pStrToEffectiveDate,
                            int pIntAllLabour
                    )
        {
            DataTable DTabSearch = new DataTable();
            //pClsProperty.Record_Code = FindRecordCode(pClsProperty.Labour_Code);
            //pClsProperty.Record_Code = new RecordMaster().Save(pClsProperty.Record_Code);

            Request Request = new Request();

            Request.AddParams("EXPORT_YYMM_", pStrYearMonth, DbType.String, ParameterDirection.Input);
            Request.AddParams("SUB_LEDGER_CODE_", pStrSubPartyCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", pStrProcessCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("ARTICLE_CODE_", pStrArticleCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("SHAPE_SELECT_", pStrShapeType, DbType.String, ParameterDirection.Input);
            Request.AddParams("CRITERIA_", pStrCriteria, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pStrSieveCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("LABOUR_TYPE_", pStrLabourType, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_DATE_", pStrFromEffectiveDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToEffectiveDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("IS_ALL_LABOUR_", pIntAllLabour, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Labour_Rate_Master_Print_New";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabSearch, Request);
            return DTabSearch;

        }

        #endregion

        #region Labour Rate Master Simple


        public DataSet GetLabourRateData(Labour_Rate_MasterProperty pClsProperty)
        {
            DataSet DS = new DataSet();

            Request Request = new Request();
            Request.REF_CUR_OUT = 4;
            Request.CommandText = "Labour_Rate_Master_GetData";
            Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SUB_LEDGER_CODE_", pClsProperty.Sub_Ledger_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SHAPE_", pClsProperty.Shape, DbType.String, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "", Request, "");
            return DS;
        }

        public int SaveLabour(Labour_Rate_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "Labour_Rate_Master_Save";

            Request.AddParams("LABOUR_CODE_", pClsProperty.Labour_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pClsProperty.Ledger_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SUB_LEDGER_CODE_", pClsProperty.Sub_Ledger_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SHAPE_", pClsProperty.Shape, DbType.String, ParameterDirection.Input);
            Request.AddParams("LABOUR_TYPE_", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("CRITERIA_", pClsProperty.Criteria, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_CENT_", pClsProperty.From_Cent, DbType.Double, ParameterDirection.Input);
            Request.AddParams("TO_CENT_", pClsProperty.To_Cent, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("ARTICLE_GROUP_CODE_", pClsProperty.Article_Group_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("QUALITY_CODE_", pClsProperty.Quality_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("MSIZE_CODE_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("RATE_", pClsProperty.Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("ENTRY_TIME_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("ENTRY_BY_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ENTRY_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            //Request.AddParams("SHAPE_SELECT_", pClsProperty.Shape_Select, DbType.String, ParameterDirection.Input);            
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            
        }

        public int DeleteLabour(int pIntSubLedgerCode,int pIntProcessCode)
        {
            Request Request = new Request();
            Request.CommandText = "Labour_Rate_Master_Delete";

            Request.AddParams("SUB_LEDGER_CODE_", pIntSubLedgerCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("PROCESS_CODE_", pIntProcessCode, DbType.Int32, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        }

        public DataTable ExportLabour(string pStrYearMonth)
        {
            DataTable DTabSearch = new DataTable();
            
            Request Request = new Request();

            Request.AddParams("EXPORT_YYMM_", pStrYearMonth, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Labour_Rate_Master_Print";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabSearch, Request);
            return DTabSearch;
        }

        #endregion

        public Labour_Rate_MasterProperty GetLabourRate(string pStrRoughName, Int64 pIntLedgerCode, Int64 pIntProcess, double pIntPcs, double pDouCarat, Int64 pIntSieveCode, Int64 pIntMFGClarityCode, Int64 pIntShapeCode, string pStrDate)
        {
            double DouCent = 0;

            if (pIntPcs != 0)
            {
                DouCent = Math.Round(Val.Val(pDouCarat) / Val.Val(pIntPcs), 2);
            }

            Request Request = new Request();

            Request.AddParams("@ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LEDGER_CODE_", pIntLedgerCode, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@SUB_LEDGER_CODE_", pIntSubLedgerCode, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@PROCESS_CODE_", pIntProcess, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CENT_", DouCent, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE_", pIntSieveCode, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@MFG_CLARITY_CODE_", pIntMFGClarityCode, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE_", pIntShapeCode, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@DATE_", pStrDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "Labour_Rate_Master_GetRateN";
            Request.CommandType = CommandType.StoredProcedure;

            DataTable DTab = new DataTable();

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);

            if (DTab == null)
            {
                return null;
            }

            if (DTab.Rows.Count <= 0)
            {
                return null;
            }

            DataRow DRow = DTab.Rows[0];

            if (DRow == null)
            {
                return null;
            }

            Labour_Rate_MasterProperty Property = new Labour_Rate_MasterProperty();

            Property.Labour_Code = Val.ToInt64(DRow["LABOUR_CODE"]);
            Property.Process_Code = Val.ToInt64(DRow["PROCESS_CODE"]);
            //Property.Ledger_Code = Val.ToInt64(DRow["LEDGER_CODE"]);
            Property.Labour_Type = Val.ToString(DRow["LABOUR_TYPE"]);
            Property.Criteria = Val.ToString(DRow["CRITERIA"]);

            //Property.Rough_Name = Val.ToString(DRow["ROUGH_NAME"]);

            Property.From_Cent = Val.Val(DRow["FROM_CENT"]);
            Property.To_Cent = Val.Val(DRow["TO_CENT"]);
            Property.Sieve_Code = Val.ToInt64(DRow["SIEVE_CODE"]);
            Property.MFG_Clarity_Code = Val.ToInt64(DRow["CLARITY_CODE"]);
            Property.Rate = Val.Val(DRow["RATE"]);

            DTab.Dispose();
            DTab = null;
            DRow = null;

            if (Property.Labour_Type == "PCS")
            {
                Property.Amount = Val.Val(Property.Rate * pIntPcs);
            }
            else if (Property.Labour_Type == "CARAT")
            {
                Property.Amount = Val.Val(Property.Rate * pDouCarat);
            }

            return Property;
        }      
    }
}

