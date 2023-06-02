using System;
using System.Data;
using DLL;
using BLL.PropertyClasses.Entry;

namespace BLL.FunctionClasses.Entry
{
    public class RoughMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        DataTable DTabBSale = new DataTable();

        public enum EnumTypeSelection
        {
            ORG = 0,
            ISS = 1,
            RET = 2,
            ADD = 3,
            SUB = 4
        }

        public DataTable GetRoughMasterData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "Rough_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Rough_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        #region Other Function

        public int Save(Rough_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@ROUGH_CODE", pClsProperty.Rough_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ORG_PCS", pClsProperty.Org_Pcs, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ORG_CARAT", pClsProperty.Org_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@BALANCE_PCS", pClsProperty.Balance_Pcs, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BALANCE_CARAT", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RATE_$", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RATE_RS", pClsProperty.Rate_Local, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@AMOUNT_$", pClsProperty.Amount_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@AMOUNT_RS", pClsProperty.Amount_Local, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SOURCE", pClsProperty.Source_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SOURCE_COMPANY", pClsProperty.Source_Company_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ARTICLE", pClsProperty.Article_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MSIZE", pClsProperty.Msize_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@QUALITY", pClsProperty.Quality_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SUBQUALITY", pClsProperty.SubQuality_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SIGHT", pClsProperty.Sight_Type_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE", pClsProperty.Rough_Type, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE", pClsProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@COMPLETE_DATE", pClsProperty.Complete_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@COMPLETE_DAYS", pClsProperty.Complete_Days, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@STATUS", pClsProperty.Status, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@REMARK", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE", pClsProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE", pClsProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", pClsProperty.Location_Code, DbType.Int64, ParameterDirection.Input); 


            Request.CommandText = "Rough_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        //public DataTable GetOriginalLotDetail(string pStrLotID, string pStrOpe)
        //{

        //    DataTable DTab = new DataTable();

        //    Request Request = new Request();
        //    Request.AddParams("LOT_ID_", pStrLotID, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.CommandText = "Rough_Create_GetLotDetails";

        //    Request.CommandType = CommandType.StoredProcedure;
        //    if (pStrOpe == "AB")
        //    {
        //        Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

        //        // Get B Part Sale Detail
        //        Request = new Request();
        //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.CommandText = "Rough_Create_GetLotSaleDetails";
        //        Request.CommandType = CommandType.StoredProcedure;
        //        Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTabBSale, Request, "");

        //    }
        //    else
        //    {
        //        Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

        //        foreach (DataRow DRowBSale in DTabBSale.Rows)
        //        {
        //            foreach (DataRow DRowBook in DTab.Rows)
        //            {
        //                if (Val.ToInt64(DRowBook["LOT_ID"].ToString()) == Val.ToInt64(DRowBSale["LOT_ID"].ToString()))
        //                {
        //                    DRowBook["SALE_CARAT"] = DRowBSale["SALE_CARAT"];
        //                    break;
        //                }
        //            }
        //        }

        //        DTab.AcceptChanges();
        //    }

        //    return DTab;
        //}

        //public DataTable GetOriginalLotDetailNew(string pStrLotID)
        //{

        //    DataTable DTab = new DataTable();

        //    Request Request = new Request();
        //    Request.AddParams("LOT_ID_", pStrLotID, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.CommandText = "Rough_Create_GetLotDetails";

        //    Request.CommandType = CommandType.StoredProcedure;
        //    //if (GlobalDec.gEmployeeProperty.Allow_Developer == 1)
        //    //{
        //    //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");

        //    //    // Get B Part Sale Detail
        //    //    Request = new Request();
        //    //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    //    Request.CommandText = "Rough_Create_GetLotSaleDetails";
        //    //    Request.CommandType = CommandType.StoredProcedure;
        //    //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTabBSale, Request, "");

        //    //}
        //    //else if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
        //    //{
        //    //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

        //    //    foreach (DataRow DRowBSale in DTabBSale.Rows)
        //    //    {
        //    //        foreach (DataRow DRowBook in DTab.Rows)
        //    //        {
        //    //            if (Val.ToInt64(DRowBook["LOT_ID"].ToString()) == Val.ToInt64(DRowBSale["LOT_ID"].ToString()))
        //    //            {
        //    //                DRowBook["SALE_CARAT"] = DRowBSale["SALE_CARAT"];
        //    //                break;
        //    //            }
        //    //        }
        //    //    }

        //    //    DTab.AcceptChanges();
        //    //}

        //    return DTab;
        //}

        //public DataTable GoodsIssueGetData(string pStrOpe, int pIntTeamCode, int pIntFromSubPartyCode, int pIntFromPartyCode, int pIntProcessCode, string pStrRoughName)
        //{
        //    DataTable DTab = new DataTable();

        //    Request Request = new Request();

        //    Request.AddParams("OPE_", pStrOpe, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("TEAM_CODE_", pIntTeamCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_SUB_PARTY_CODE_", pIntFromSubPartyCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_PARTY_CODE_", pIntFromPartyCode, DbType.Int32, ParameterDirection.Input);

        //    // Vipul 18 Nov 2013
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", BLL.GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_CODE_", pIntProcessCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = "Goods_Issue_Lot_Rough_GetData";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        //public DataTable GetRoughFullDetail(int pIntIsConfirm, int pIntISSampleStudyApprove, string pStrRoughType, string pStrRoughName = null, bool ISRoughOwnerCheck = true)
        //{
        //    DataTable Dtab = new DataTable();
        //    return Dtab;
        //    //string Team_Multi = "";

        //    //if (ISRoughOwnerCheck == true)
        //    //{
        //    //    //bool BlnISRoughOpen = new DepartmentMaster().ISRoughOpen(GlobalDec.gEmployeeProperty.Department_Code);
        //    //    //if (BlnISRoughOpen == false)
        //    //    //{
        //    //    //  Team_Multi = Val.ToString(new TeamMaster().GetTreeTeamForWard(GlobalDec.gEmployeeProperty.Team_Code, true, BLL.ReturnTypeMode.String));    
        //    //    //}

        //    //}

        //    //Request Request = new Request();
        //    //Request.AddParams("TEAM_CODE_", Team_Multi, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("IS_APPROVE_", pIntISSampleStudyApprove, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("IS_CONFIRM_", pIntIsConfirm, DbType.Int16, ParameterDirection.Input);
        //    //Request.AddParams("ROUGH_TYPE_", pStrRoughType, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.CommandText = "Get_Rough_Detail";
        //    //Request.CommandType = CommandType.StoredProcedure;
        //    //Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableName, Request, "");
        //    //return DS.Tables[TableName];
        //}


        #endregion

        #region Estimated Price Region

        //public void GetRoughEstimation(Rough_Estimation_Property pClsProperty)
        //{
        //    //Request Request = new Request();
        //    //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("METHOD_", pClsProperty.Method, DbType.String, ParameterDirection.Input);
        //    //Request.CommandText = "Rough_Estimation_GetData";
        //    //Request.CommandType = CommandType.StoredProcedure;
        //    //Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableNameEstimation, Request, "");
        //}

        //public int SaveRoughEstimation(Rough_Estimation_Property pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("METHOD_", pClsProperty.Method, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("RATE_", pClsProperty.Rate, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = "Rough_Estimation_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        public int DeleteRoughEstimation(string pStrRoughName, string pStrMethod)
        {
            Request Request = new Request();
            Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);
            Request.AddParams("METHOD_", pStrMethod, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Rough_Estimation_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        //public void GetRoughLossRepeat(Rough_Loss_Repeat_Property pClsProperty)
        //{
        //    //Request Request = new Request();
        //    //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    //Request.CommandText = "Rough_Loss_Repeat_GetData";
        //    //Request.CommandType = CommandType.StoredProcedure;
        //    //Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableNameLossRepeat, Request, "");
        //}

        //public int SaveRoughLossRepeat(Rough_Loss_Repeat_Property pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MAX_REPEAT_", pClsProperty.Max_Repeat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MAX_LOSS_", pClsProperty.Max_Loss, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = "Rough_Loss_Repeat_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        public int DeleteRoughLossRepeat(string pStrRoughName)
        {
            Request Request = new Request();
            Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Rough_Loss_Repeat_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int UpdateRoughDetail(Rough_MasterProperty pClsProperty)
        {
            //Request Request = new Request();

            //Request.AddParams("OPE_", pClsProperty.Ope, DbType.String, ParameterDirection.Input);
            //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            //Request.AddParams("PRIORITY_", pClsProperty.Priority, DbType.String, ParameterDirection.Input);
            //Request.AddParams("ESTIMETED_COMPLETE_DATE_", pClsProperty.Estimeted_Complete_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("ESTIMETED_COMPLETE_DAYS_", pClsProperty.Estimeted_Complete_Days, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("ADDITIONAL_DAYS_", pClsProperty.Additional_Days, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("CONF_USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("CONF_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            //Request.AddParams("STOCK_SRNO_", pClsProperty.Stock_SrNo, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("STOCK_JANGED_NO_", pClsProperty.Stock_Janged_No, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("STOCK_JANGED_DATE_", pClsProperty.Stock_Janged_Date, DbType.String, ParameterDirection.Input);
            //Request.CommandText = BLL.TPV.SProc.Rough_Detail_Update;
            //Request.CommandType = CommandType.StoredProcedure;
            //return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            return 0;
        }

        #endregion

        #region Janged


        //public int SaveJangedReceive(Rough_Janged_DetailProperty pClsProperty)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOT_ID_", pClsProperty.Lot_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.CommandText = "Rough_Janged_Detail_ReturnSave";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        public DataRow FindNewJanged(string pStrProcessGroup)
        {
            Request Request = new Request();
            Request.AddParams("PROCESS_GROUP_CODE_", pStrProcessGroup, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Rough_Janged_Master_FindNew";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        //public int SaveRoughJangedMaster(Rough_Janged_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_GROUP_CODE_", pClsProperty.Process_Group_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("JNO_", pClsProperty.JNo, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);

        //    // Start vIPUL On 16-11-2013

        //    Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);

        //    // End Haresh
        //    Request.CommandText = "Rough_Janged_Master_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);



        //    // Save In B Part

        //    Request = new Request();

        //    Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_GROUP_CODE_", pClsProperty.Process_Group_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("JNO_", pClsProperty.JNo, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);

        //    // Start vIPUL On 16-11-2013

        //    Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);

        //    // End Haresh
        //    Request.CommandText = "Rough_Janged_Master_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
        //    return IntRes;
        //}

        //public int SaveRoughJangedDetail(Rough_Janged_DetailProperty pClsProperty)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("LOT_ID_", pClsProperty.Lot_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("RATE_DOLLAR_", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RATE_LOCAL_", pClsProperty.Rate_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("AMOUNT_DOLLAR_", pClsProperty.Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("AMOUNT_LOCAL_", pClsProperty.Amount_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("LOCAL_EXCHANGE_RATE_", pClsProperty.Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_BARCODE_", pClsProperty.Rough_Barcode, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("STOCK_SRNO_", pClsProperty.Stock_SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("STOCK_JANGED_NO_", pClsProperty.Stock_Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("STOCK_JANGED_DATE_", pClsProperty.Stock_Janged_Date, DbType.Date, ParameterDirection.Input);


        //    Request.CommandText = "Rough_Janged_Detail_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);


        //    // Save In B Part
        //    Request = new Request();

        //    Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("LOT_ID_", pClsProperty.Lot_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("RATE_DOLLAR_", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RATE_LOCAL_", pClsProperty.Rate_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("AMOUNT_DOLLAR_", pClsProperty.Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("AMOUNT_LOCAL_", pClsProperty.Amount_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("LOCAL_EXCHANGE_RATE_", pClsProperty.Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_BARCODE_", pClsProperty.Rough_Barcode, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("STOCK_SRNO_", pClsProperty.Stock_SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("STOCK_JANGED_NO_", pClsProperty.Stock_Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("STOCK_JANGED_DATE_", pClsProperty.Stock_Janged_Date, DbType.Date, ParameterDirection.Input);

        //    Request.CommandText = "Rough_Janged_Detail_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
        //    return IntRes;
        //}

        //public int DeleteDetail(Rough_Janged_DetailProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOT_ID_", pClsProperty.Lot_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = "Rough_Janged_Detail_Delete";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        //public int DeleteJanged(Rough_Janged_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = "Rough_Janged_Master_Delete";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    Request = new Request();
        //    Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = "Rough_Janged_Master_Delete";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = +Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
        //    return IntRes;
        //}

        public DataTable GetJangedGetData(
                                        int pIntTeamCode = 0,
                                        int pIntLocationCode = 0,
                                        int pIntArticleHead = 0,
                                        int pIntDepartmentCode = 0,
                                        int pIntFromPartyCode = 0,
                                        int pIntToPartyCode = 0,
                                        string pStrFromDate = null,
                                        string pStrToDate = null
                                        )
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("TEAM_CODE_", pIntTeamCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", pIntArticleHead, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", pIntDepartmentCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("FROM_PARTY_CODE_", pIntFromPartyCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TO_PARTY_CODE_", pIntToPartyCode, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("CREATE_COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CREATE_BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CREATE_LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("CREATE_DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "Rough_Janged_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public void GetJangedDetailGetData(string pStrJangedNo, int pIntLocationCode, string pStrArticleHead, int pIntDepartmentCode)
        {
            //Request Request = new Request();
            //Request.AddParams("JANGED_NO_", pStrJangedNo, DbType.String, ParameterDirection.Input);
            //Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("EMPLOYEE_CODE_", pStrArticleHead, DbType.String, ParameterDirection.Input);
            //Request.AddParams("DEPARTMENT_CODE_", pIntDepartmentCode, DbType.Int32, ParameterDirection.Input);
            //Request.CommandText = "Rough_Janged_Detail_GetData";
            //Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableJangedDetail, Request, "");
        }

        public DataTable GetJangedDetailGetDataForSearch(string pStrJangedNo, int pIntLocationCode, string pStrArticleHead, int pIntDepartmentCode)
        {
            DataTable DTab = new DataTable();
            return DTab;
            //GetJangedDetailGetData(pStrJangedNo, pIntLocationCode, pStrArticleHead, pIntDepartmentCode);
            //return DS.Tables[TableJangedDetail];
        }

        //public int ConfirmRoughJangedDetail(Rough_Janged_DetailProperty pClsProperty)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CONF_USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("CONF_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = "Rough_Janged_Detail_Confirm";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    //Request = new Request();
        //    //Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("ROUGH_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("ROUGH_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    //Request.AddParams("CONF_USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("CONF_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    //Request.CommandText = BLL.TPV.SProc.Rough_Janged_Detail_Confirm;
        //    //Request.CommandType = CommandType.StoredProcedure;
        //    //IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
        //    return IntRes;
        //}

        //public string ValJangedBeforeSave(Rough_Janged_DetailProperty pClsProperty)
        //{
        //    Request Request = new Request();

        //    Request.CommandText = "Rough_Janged_ValSave";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Request.AddParams("LOT_ID_", pClsProperty.Lot_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);

        //    return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        public bool ISPrintCheck(string pStrJangedNo)
        {

            string Str = "";
            Str = Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Rough_Janged_Master", "IS_PRINT", " And Janged_NO = '" + pStrJangedNo + "'");
            if (Val.Val(Str) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExists(string pStrJangedNo)
        {

            string Str = "";
            Str = Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Rough_Janged_Master", "Janged_NO", " And Janged_NO = '" + pStrJangedNo + "'");
            if (Str != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public DataTable GetRoughJangedPrint(Rough_Janged_MasterProperty pClsProperty)
        //{
        //    DataTable DTab = new DataTable();
        //    return DTab;
        //    //Request Request = new Request();
        //    //Request.CommandText = "Rp_Mix_Rough_Janged_Print";
        //    //Request.CommandType = CommandType.StoredProcedure;
        //    //Request.AddParams("JANGED_NO_", pClsProperty.Jangad_No, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("FROM_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    //Request.AddParams("TO_DATE_", pClsProperty.Janged_Date, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("TOTAL_PCS_", pClsProperty.Total_Pcs, DbType.Int32, ParameterDirection.Input);

        //    //Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableJangedPrint, Request, "");
        //    //return DS.Tables[TableJangedPrint];
        //}

        #endregion

        #region Rough Creation

        public int FindNewTranID(string pStrRoughName)
        {
            int IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Rough_Lot_Detail", "MAX(TRN_ID)", " And Rough_Name = '" + pStrRoughName + "' ");
            return IntRes;
        }

        public int FindNewTranIDForLotDetailNew(string pStrRoughName)
        {
            int IntRes = 0;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Rough_Lot_Detail", "MAX(TRN_ID)", " And Rough_Name = '" + pStrRoughName + "' ");
            //}
            //else
            //{
            //    IntRes = Ope.FindNewID(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, "Rough_Lot_Detail", "MAX(TRN_ID)", " And Rough_Name = '" + pStrRoughName + "' ");
            //}
            return IntRes;
        }

        public Request AddPara(Rough_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ORG_PCS_", pClsProperty.Org_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ORG_CARAT_", pClsProperty.Org_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ROUGH_PCS_", pClsProperty.Rough_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ROUGH_CARAT_", pClsProperty.Rough_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("SOURCE_CODE_", pClsProperty.Source_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SOURCE_COMPANY_CODE_", pClsProperty.Source_Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("MSIZE_CODE_", pClsProperty.Msize_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("QUALITY_CODE_", pClsProperty.Quality_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SUBQUALITY_CODE_", pClsProperty.SubQuality_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SIGHT_TYPE_CODE_", pClsProperty.Sight_Type_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("RATE_DOLLAR_", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("RATE_LOCAL_", pClsProperty.Rate_Local, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_DOLLAR_", pClsProperty.Amount_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_LOCAL_", pClsProperty.Amount_Local, DbType.Double, ParameterDirection.Input);

            Request.AddParams("ROUGH_TYPE_", pClsProperty.Rough_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCAL_EXCHANGE_RATE_", pClsProperty.Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParams("CREATE_DATE_", pClsProperty.Create_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.AddParams("BASE_ROUGH_NAME_", pClsProperty.Base_Rough_Name, DbType.String, ParameterDirection.Input);

            //Start Haresh On 16-11-2013

            Request.AddParams("CREATE_COMPANY_CODE_", pClsProperty.Create_Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CREATE_BRANCH_CODE_", pClsProperty.Create_Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CREATE_LOCATION_CODE_", pClsProperty.Create_Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CREATE_DEPARTMENT_CODE_", pClsProperty.Create_Department_Code, DbType.Int32, ParameterDirection.Input);

            // End Haresh

            return Request;
        }

        public Request AddParaNew(Rough_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ORG_PCS_", pClsProperty.Org_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ORG_CARAT_", pClsProperty.Org_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("ROUGH_PCS_", pClsProperty.Rough_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ROUGH_CARAT_", pClsProperty.Rough_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("SOURCE_CODE_", pClsProperty.Source_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SOURCE_COMPANY_CODE_", pClsProperty.Source_Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("MSIZE_CODE_", pClsProperty.Msize_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("QUALITY_CODE_", pClsProperty.Quality_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SUBQUALITY_CODE_", pClsProperty.SubQuality_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SIGHT_TYPE_CODE_", pClsProperty.Sight_Type_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("LABOUR_TEAM_CODE_", pClsProperty.Labour_Team_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LABOUR_GROUP_CODE_", pClsProperty.Labour_Group_Code, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);


            Request.AddParams("RATE_DOLLAR_", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("RATE_LOCAL_", pClsProperty.Rate_Local, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_DOLLAR_", pClsProperty.Amount_Dollar, DbType.Double, ParameterDirection.Input);
            Request.AddParams("AMOUNT_LOCAL_", pClsProperty.Amount_Local, DbType.Double, ParameterDirection.Input);

            Request.AddParams("ROUGH_TYPE_", pClsProperty.Rough_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCAL_EXCHANGE_RATE_", pClsProperty.Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParams("CREATE_DATE_", pClsProperty.Create_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.AddParams("BASE_ROUGH_NAME_", pClsProperty.Base_Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("STATUS_", pClsProperty.Status, DbType.String, ParameterDirection.Input);

            //Start Haresh On 16-11-2013

            Request.AddParams("CREATE_COMPANY_CODE_", pClsProperty.Create_Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CREATE_BRANCH_CODE_", pClsProperty.Create_Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CREATE_LOCATION_CODE_", pClsProperty.Create_Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CREATE_DEPARTMENT_CODE_", pClsProperty.Create_Department_Code, DbType.Int32, ParameterDirection.Input);

            // End Haresh

            return Request;
        }

        public int SaveRoughMaster(Rough_MasterProperty pClsProperty)
        {
            Request Request = AddPara(pClsProperty);
            Request.CommandText = "Rough_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            Request = AddPara(pClsProperty);
            Request.CommandText = "Rough_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

            return IntRes;

        }

        public int SaveRoughMasterFromTransferEntry(Rough_MasterProperty pClsProperty, string pStrOperation)
        {
            if (pStrOperation == "ROUGH TO MIX")
            {
                Request Request = AddPara(pClsProperty);
                Request.CommandText = "Rough_Master_Save";
                Request.CommandType = CommandType.StoredProcedure;
                int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
                return IntRes;
            }
            else
            {
                Request Request = AddPara(pClsProperty);
                Request.CommandText = "Rough_Master_Save";
                Request.CommandType = CommandType.StoredProcedure;
                int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

                Request = AddPara(pClsProperty);
                Request.CommandText = "Rough_Master_Save";
                Request.CommandType = CommandType.StoredProcedure;
                IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
                return IntRes;
            }

        }

        public int SaveRoughMasterNew(Rough_MasterProperty pClsProperty)
        {
            Request Request = AddParaNew(pClsProperty);
            Request.CommandText = "Rough_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            int IntRes = 0;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //}
            //else
            //{
            //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

            //    Request = new Request();
            //    Request.CommandText = "Rough_Master_Update";
            //    Request.CommandType = CommandType.StoredProcedure;
            //    Request.AddParams("OPE_", "PARAMETER", DbType.String, ParameterDirection.Input);
            //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            //    Request.AddParams("SOURCE_CODE_", pClsProperty.Source_Code, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("SOURCE_COMPANY_CODE_", pClsProperty.Source_Company_Code, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("MSIZE_CODE_", pClsProperty.Msize_Code, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("QUALITY_CODE_", pClsProperty.Quality_Code, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("SIGHT_TYPE_CODE_", pClsProperty.Sight_Type_Code, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("LABOUR_TEAM_CODE_", pClsProperty.Labour_Team_Code, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("LABOUR_GROUP_CODE_", pClsProperty.Labour_Group_Code, DbType.Int32, ParameterDirection.Input);
            //    IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            //}
            return IntRes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pClsProperty"></param>
        /// <param name="pStrType">For Select A-Part SP ANd B Part SP</param>
        /// <returns></returns>
        //public int SaveRoughLotDetail(Rough_Lot_DetailProperty pClsProperty, string pStrType)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PARENT_ROUGH_NAME_", pClsProperty.Parent_Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("LOT_ID_", pClsProperty.Lot_Id, DbType.Int64, ParameterDirection.Input);

        //    Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TRN_DATE_", pClsProperty.Trn_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.CommandText = "Rough_Lot_Detail_Save";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    int IntRes = 0;
        //    if (pStrType == "A")
        //    {
        //        IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    }
        //    else if (pStrType == "AB")
        //    {
        //        IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
        //    }
        //    return IntRes;
        //}


        //public int SaveRoughLotDetailFromTransfer(Rough_Lot_DetailProperty pClsProperty, string pStrOpetation)
        //{
        //    if (pStrOpetation == "ROUGH TO MIX")
        //    {
        //        Request Request = new Request();

        //        Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("PARENT_ROUGH_NAME_", pClsProperty.Parent_Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("LOT_ID_", pClsProperty.Lot_Id, DbType.Int64, ParameterDirection.Input);

        //        Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("IS_UNTOUCH_", pClsProperty.IS_Untouch, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("TRN_DATE_", pClsProperty.Trn_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);

        //        Request.CommandText = "Rough_Lot_Detail_Save";
        //        Request.CommandType = CommandType.StoredProcedure;

        //        int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //        return IntRes;
        //    }
        //    else
        //    {
        //        Request Request = new Request();
        //        Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("PARENT_ROUGH_NAME_", pClsProperty.Parent_Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("LOT_ID_", pClsProperty.Lot_Id, DbType.Int64, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("IS_UNTOUCH_", pClsProperty.IS_Untouch, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("TRN_DATE_", pClsProperty.Trn_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.CommandText = "Rough_Lot_Detail_Save";
        //        Request.CommandType = CommandType.StoredProcedure;
        //        int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //        Request = new Request();
        //        Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("PARENT_ROUGH_NAME_", pClsProperty.Parent_Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("LOT_ID_", pClsProperty.Lot_Id, DbType.Int64, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("TRN_DATE_", pClsProperty.Trn_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.CommandText = "Rough_Lot_Detail_Save";
        //        Request.CommandType = CommandType.StoredProcedure;
        //        IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
        //        return IntRes;
        //    }

        //}

        //public int UpdateISUntouch(Rough_Lot_DetailProperty pClsProperty)
        //{
        //    int IntRes = 0;
        //    //if (GlobalDec.gEmployeeProperty.Allow_Developer == 1)
        //    //{
        //    //    Request Request = new Request();
        //    //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    //    Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int32, ParameterDirection.Input);
        //    //    Request.AddParams("STATUS_", "IDLE", DbType.String, ParameterDirection.Input);

        //    //    Request.CommandText = "Rough_Lot_Detail_UpdateBalance";
        //    //    Request.CommandType = CommandType.StoredProcedure;
        //    //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    //    Request = new Request();
        //    //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    //    Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int32, ParameterDirection.Input);
        //    //    Request.AddParams("STATUS_", pClsProperty.Status, DbType.String, ParameterDirection.Input);

        //    //    Request.CommandText = "Rough_Lot_Detail_UpdateBalance";
        //    //    Request.CommandType = CommandType.StoredProcedure;
        //    //    IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

        //    //}
        //    //else if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
        //    //{
        //    //    Request Request = new Request();
        //    //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    //    Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int32, ParameterDirection.Input);
        //    //    Request.AddParams("STATUS_", "IDLE", DbType.String, ParameterDirection.Input);

        //    //    Request.CommandText = "Rough_Lot_Detail_UpdateBalance";
        //    //    Request.CommandType = CommandType.StoredProcedure;
        //    //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    //}
        //    return IntRes;
        //}

        //public int SaveRoughLotDetailNew(Rough_Lot_DetailProperty pClsProperty)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("OPE_", pClsProperty.Ope, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PARENT_ROUGH_NAME_", pClsProperty.Parent_Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("LOT_ID_", pClsProperty.Lot_Id, DbType.Int64, ParameterDirection.Input);

        //    Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TRN_DATE_", pClsProperty.Trn_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("RATE_DOLLAR_", pClsProperty.Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("AMOUNT_DOLLAR_", pClsProperty.Amount_Dollar, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("IS_UNTOUCH_", pClsProperty.IS_Untouch, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("PREM_RATE_DOLLAR_", pClsProperty.Prem_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PREM_AMOUNT_DOLLAR_", pClsProperty.Prem_Amount_Dollar, DbType.Double, ParameterDirection.Input);

        //    Request.CommandText = "Rough_Lot_Detail_Save";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    int IntRes = 0;
        //    //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
        //    //{
        //    //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    //}
        //    //else if (GlobalDec.gEmployeeProperty.Allow_Developer == 1)
        //    //{
        //    //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
        //    //}
        //    return IntRes;
        //}

        public int DeleteRoughLotDetail(string pStrRoughName)
        {
            Request Request = new Request();
            Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Rough_Lot_Detail_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            int IntRes = 0;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //}
            //else if (GlobalDec.gEmployeeProperty.Allow_Developer == 1)
            //{
            //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
            //}
            return IntRes;
        }

        public string ValRoughSave(Rough_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.CommandText = "Rough_Master_ValSave";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);

            return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public string ValRoughSaveNew(Rough_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            string str = string.Empty;

            Request.CommandText = "Rough_Master_ValSave";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);

            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //}
            //else
            //{
            //    return Ope.ExecuteScalar(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
            //}
            return str;

        }

        public DataTable GetRoughMasterData(string pStrRoughName = null, string pStrRemark = null, int pIntCompanyCode = 0, int pIntBranchCode = 0, int pIntLocationCode = 0, int pIntISSamleCheck = 1)
        {
            DataTable DTab = new DataTable();
            return DTab;
            //Request Request = new Request();
            //Request.CommandText = "Rough_Master_GetData";
            //Request.CommandType = CommandType.StoredProcedure;
            //Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);
            //Request.AddParams("REMARK_", pStrRemark, DbType.String, ParameterDirection.Input);
            //Request.AddParams("COMPANY_CODE_", pIntCompanyCode, DbType.String, ParameterDirection.Input);
            //Request.AddParams("BRANCH_CODE_", pIntBranchCode, DbType.String, ParameterDirection.Input);
            //Request.AddParams("IS_CHECK_SAMPLE_", pIntISSamleCheck, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.String, ParameterDirection.Input);
            ////if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            ////{
            ////    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableName, Request, "");
            ////}
            ////else
            ////{
            ////    Ope.GetDataSet(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DS, TableName, Request, "");
            ////}

            //return DS.Tables[TableName];
        }

        //public Rough_MasterProperty GetDataByPK(string pStrRoughName = null)
        //{
        //    Rough_MasterProperty Rough_MasterProperty = new Rough_MasterProperty();

        //    Request Request = new Request();
        //    Request.CommandText = "Rough_Master_GetData";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);

        //    DataRow Drow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    if (Drow == null)
        //    {
        //        return null;
        //    }

        //    Rough_MasterProperty.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);
        //    Rough_MasterProperty.Org_Pcs = Val.ToInt(Drow["ORG_PCS"]);
        //    Rough_MasterProperty.Org_Carat = Val.Val(Drow["ORG_CARAT"]);
        //    Rough_MasterProperty.Rate_Dollar = Val.Val(Drow["RATE_DOLLAR"]);
        //    Rough_MasterProperty.Balance_Pcs = Val.ToInt(Drow["BALANCE_PCS"]);
        //    Rough_MasterProperty.Balance_Carat = Val.Val(Drow["BALANCE_CARAT"]);
        //    Rough_MasterProperty.Rough_Pcs = Val.ToInt(Drow["ROUGH_PCS"]);
        //    Rough_MasterProperty.Rough_Carat = Val.Val(Drow["ROUGH_CARAT"]);
        //    Rough_MasterProperty.Invoice_Carat = Val.Val(Drow["INVOICE_CARAT"]);

        //    Rough_MasterProperty.Source_Code = Val.ToInt(Drow["SOURCE_CODE"]);
        //    Rough_MasterProperty.Source_Name = Val.ToString(Drow["SOURCE_NAME"]);

        //    Rough_MasterProperty.Source_Company_Code = Val.ToInt(Drow["SOURCE_COMPANY_CODE"]);
        //    Rough_MasterProperty.Source_Company_Name = Val.ToString(Drow["SOURCE_COMPANY_NAME"]);

        //    Rough_MasterProperty.Article_Code = Val.ToInt(Drow["ARTICLE_CODE"]);
        //    Rough_MasterProperty.Article_Name = Val.ToString(Drow["ARTICLE_NAME"]);

        //    Rough_MasterProperty.Msize_Code = Val.ToInt(Drow["MSIZE_CODE"]);
        //    Rough_MasterProperty.Msize_Name = Val.ToString(Drow["MSIZE_NAME"]);

        //    Rough_MasterProperty.Quality_Code = Val.ToInt(Drow["QUALITY_CODE"]);
        //    Rough_MasterProperty.Quality_Name = Val.ToString(Drow["QUALITY_NAME"]);

        //    Rough_MasterProperty.SubQuality_Code = Val.ToInt(Drow["SUBQUALITY_CODE"]);
        //    Rough_MasterProperty.SubQuality_Name = Val.ToString(Drow["SUBQUALITY_NAME"]);

        //    Rough_MasterProperty.Sight_Type_Code = Val.ToInt(Drow["SIGHT_TYPE_CODE"]);
        //    Rough_MasterProperty.Sight_Type_Name = Val.ToString(Drow["SIGHT_TYPE_NAME"]);

        //    Rough_MasterProperty.Team_Code = Val.ToInt(Drow["TEAM_CODE"]);
        //    Rough_MasterProperty.Team_Name = Val.ToString(Drow["TEAM_NAME"]);

        //    Rough_MasterProperty.Group_Code = Val.ToInt(Drow["GROUP_CODE"]);
        //    Rough_MasterProperty.Group_Name = Val.ToString(Drow["GROUP_NAME"]);

        //    /* add by khsuhbu 18/11/2014 */
        //    Rough_MasterProperty.Labour_Team_Code = Val.ToInt(Drow["LABOUR_TEAM_CODE"]);
        //    Rough_MasterProperty.Labour_Team_Name = Val.ToString(Drow["LABOUR_TEAM_NAME"]);

        //    Rough_MasterProperty.Labour_Group_Code = Val.ToInt(Drow["LABOUR_GROUP_CODE"]);
        //    Rough_MasterProperty.Labour_Group_Name = Val.ToString(Drow["LABOUR_GROUP_NAME"]);

        //    /* ---------------- */

        //    Rough_MasterProperty.Local_Exchange_Rate = Val.Val(Drow["LOCAL_EXCHANGE_RATE"]);
        //    Rough_MasterProperty.Rate_Dollar = Val.Val(Drow["RATE_DOLLAR"]);
        //    Rough_MasterProperty.Rate_Local = Val.Val(Drow["RATE_LOCAL"]);

        //    Rough_MasterProperty.Amount_Dollar = Val.Val(Drow["AMOUNT_DOLLAR"]);
        //    Rough_MasterProperty.Amount_Local = Val.Val(Drow["AMOUNT_LOCAL"]);

        //    //Rough_MasterProperty.Location_Code = Val.ToInt(Drow["LOCATION_CODE"]);

        //    Rough_MasterProperty.Rough_Type = Val.ToString(Drow["ROUGH_TYPE"]);
        //    Rough_MasterProperty.Article_Head = Val.ToString(Drow["ARTICLE_HEAD"]);

        //    Rough_MasterProperty.VAS_Per = Val.ToDouble(Drow["VAS_PER"]);
        //    Rough_MasterProperty.PRM_Per = Val.ToDouble(Drow["PREAM_PER"]);

        //    //COMMENT BY HARESH ON 07/11/2014
        //    //Rough_MasterProperty.PRM_Rate = Val.ToDouble(Drow["PREAM_AMOUNT"]);

        //    //ADD BY HARESH ON 07/11/2014 FOR PRM_RATE


        //    Rough_MasterProperty.PRM_Rate = Val.ToDouble(Drow["PREAM_RATE"]); // Commented  Narendra : 12-11-2014


        //    Rough_MasterProperty.Exp_Yield = Val.ToDouble(Drow["EXP_YIELD"]);

        //    Rough_MasterProperty.Lab_Per_Pcs = Val.Val(Drow["LABOUR_PER_PCS"]);
        //    Rough_MasterProperty.Rough_Top_Rate = Val.ToDouble(Drow["ROUGH_TOP_RATE"]);

        //    Rough_MasterProperty.Commi_Per = Val.ToDouble(Drow["COMM_PER"]);
        //    Rough_MasterProperty.HOD_EXP_RATE_PER = Val.ToDouble(Drow["HOD_EXP_RATE_PER"]);

        //    Rough_MasterProperty.HOD_EXP_RATE = Val.ToDouble(Drow["HOD_EXP_RATE"]);
        //    Rough_MasterProperty.Con_Rate = Val.ToDouble(Drow["CONS_RATE_PER"]);

        //    Rough_MasterProperty.Over_Head = Val.ToDouble(Drow["OVER_HEAD"]);
        //    Rough_MasterProperty.Is_Mark = Val.ToInt32(Drow["IS_FM_MARK"]);

        //    Rough_MasterProperty.ORSize = Val.Val(Drow["ORSIZE"]);

        //    Rough_MasterProperty.Is_Hide = Val.ToInt32(Drow["IS_HIDE"]);
        //    Rough_MasterProperty.Process_date = Val.DBDate(Val.ToString(Drow["PROCESS_DATE"]));
        //    Rough_MasterProperty.Complete_date = Val.DBDate(Val.ToString(Drow["COMPLETE_DATE"]));

        //    Rough_MasterProperty.Process_Issue_Date = Val.DBDate(Val.ToString(Drow["PROCESS_ISSUE_DATE"]));

        //    // ADD BY NIRAV MORADIYA 12/JUN/2014 

        //    Rough_MasterProperty.Rough_Org_Rate = Val.ToDouble(Drow["ROUGH_ORG_RATE"]);

        //    Rough_MasterProperty.Current_DollarRate = Val.Val(Drow["CURRENT_DOLLARRATE"]);
        //    Rough_MasterProperty.Import_DollarRate = Val.Val(Drow["IMPORT_DOLLARRATE"]);
        //    Rough_MasterProperty.Interest_Per = Val.Val(Drow["INTEREST_PER"]);
        //    Rough_MasterProperty.Other_Cost = Val.Val(Drow["OTHER_COST"]);
        //    Rough_MasterProperty.Abnormal_Cost = Val.Val(Drow["ABNORMAL_COST"]);
        //    Rough_MasterProperty.Admin_Per = Val.Val(Drow["ADMIN_PER"]);
        //    Rough_MasterProperty.Ind_CostPer = Val.Val(Drow["IND_COSTPER"]);
        //    Rough_MasterProperty.PolDept_SalePer = Val.Val(Drow["POLDEPT_SALPER"]);

        //    Rough_MasterProperty.Boiling_CostPer = Val.Val(Drow["BOILING_COSTPER"]);
        //    Rough_MasterProperty.PolInd_CostPer = Val.Val(Drow["POLIND_COSTPER"]);
        //    Rough_MasterProperty.Depth_Per = Val.Val(Drow["DEP_PER"]);
        //    Rough_MasterProperty.Selling_Per = Val.Val(Drow["SELLING_PER"]);

        //    Rough_MasterProperty.Labour = Val.ToInt(Drow["LABOUR"]);
        //    Rough_MasterProperty.Repairing_Exp = Val.ToInt(Drow["REPAIRING_EXP"]);
        //    Rough_MasterProperty.SLab_PerPcs = Val.ToInt(Drow["SLAB_PERPCS"]);
        //    Rough_MasterProperty.Grading_Cost = Val.ToInt(Drow["GRADING_COST"]);

        //    Rough_MasterProperty.Realization_Crts = Val.Val(Drow["REAUZATION_CRT"]);
        //    Rough_MasterProperty.Realization_Rate = Val.Val(Drow["REAUZATION_RATE"]);
        //    Rough_MasterProperty.SingleStone_Crts = Val.Val(Drow["SINGLESTONE_CRT"]);
        //    Rough_MasterProperty.SingleStone_Rate = Val.Val(Drow["SINGLESTONE_RATE"]);

        //    Rough_MasterProperty.Is_CostSheetCompleted = Val.ToInt(Drow["IS_COSTSHEETCOMPLETED"]);
        //    Rough_MasterProperty.Is_CostSheetLocked = Val.ToInt(Drow["IS_COSTSHEETLOCKED"]);
        //    Rough_MasterProperty.Costing_Remark = Val.ToString(Drow["COSTING_REMARK"]);

        //    Rough_MasterProperty.Create_Date = Val.DBDate(Val.ToString(Drow["CREATE_DATE"]));

        //    // ADD BY HARESH ON 26-11-2014

        //    Rough_MasterProperty.Import_Date = Val.DBDate(Val.ToString(Drow["IMPORT_DATE"]));
        //    Rough_MasterProperty.Costing_Issue_Date = Val.DBDate(Val.ToString(Drow["COSTING_ISSUE_DATE"]));
        //    Rough_MasterProperty.Costing_Complete_Date = Val.DBDate(Val.ToString(Drow["COSTING_COMPLETE_DATE"]));

        //    //
        //    Rough_MasterProperty.Polished_Date = Val.DBDate(Val.ToString(Drow["POLISHED_DATE"]));
        //    Rough_MasterProperty.Valuation_Date = Val.DBDate(Val.ToString(Drow["VALUATION_DATE"]));
        //    Rough_MasterProperty.Payment_Date = Val.DBDate(Val.ToString(Drow["PAYMENT_DATE"]));
        //    Rough_MasterProperty.Terms_Days = Val.ToInt32(Val.ToString(Drow["TERMS_DAYS"]));

        //    Drow = null;
        //    return Rough_MasterProperty;
        //}


        //public Rough_MasterProperty GetDataByPKForCosting(string pStrRoughName = null)
        //{
        //    Rough_MasterProperty Rough_MasterProperty = new Rough_MasterProperty();

        //    Request Request = new Request();
        //    Request.CommandText = "Rough_Master_GetDataCostSheet";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);

        //    DataRow Drow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    if (Drow == null)
        //    {
        //        return null;
        //    }

        //    Rough_MasterProperty.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);
        //    Rough_MasterProperty.Org_Pcs = Val.ToInt(Drow["ORG_PCS"]);
        //    Rough_MasterProperty.Org_Carat = Val.Val(Drow["ORG_CARAT"]);
        //    Rough_MasterProperty.Rate_Dollar = Val.Val(Drow["RATE_DOLLAR"]);
        //    Rough_MasterProperty.Balance_Pcs = Val.ToInt(Drow["BALANCE_PCS"]);
        //    Rough_MasterProperty.Balance_Carat = Val.Val(Drow["BALANCE_CARAT"]);
        //    Rough_MasterProperty.Rough_Pcs = Val.ToInt(Drow["ROUGH_PCS"]);
        //    Rough_MasterProperty.Rough_Carat = Val.Val(Drow["ROUGH_CARAT"]);

        //    Rough_MasterProperty.Source_Code = Val.ToInt(Drow["SOURCE_CODE"]);
        //    Rough_MasterProperty.Source_Name = Val.ToString(Drow["SOURCE_NAME"]);

        //    Rough_MasterProperty.Source_Company_Code = Val.ToInt(Drow["SOURCE_COMPANY_CODE"]);
        //    Rough_MasterProperty.Source_Company_Name = Val.ToString(Drow["SOURCE_COMPANY_NAME"]);

        //    Rough_MasterProperty.Article_Code = Val.ToInt(Drow["ARTICLE_CODE"]);
        //    Rough_MasterProperty.Article_Name = Val.ToString(Drow["ARTICLE_NAME"]);

        //    Rough_MasterProperty.Msize_Code = Val.ToInt(Drow["MSIZE_CODE"]);
        //    Rough_MasterProperty.Msize_Name = Val.ToString(Drow["MSIZE_NAME"]);

        //    Rough_MasterProperty.Quality_Code = Val.ToInt(Drow["QUALITY_CODE"]);
        //    Rough_MasterProperty.Quality_Name = Val.ToString(Drow["QUALITY_NAME"]);

        //    Rough_MasterProperty.SubQuality_Code = Val.ToInt(Drow["SUBQUALITY_CODE"]);
        //    Rough_MasterProperty.SubQuality_Name = Val.ToString(Drow["SUBQUALITY_NAME"]);

        //    Rough_MasterProperty.Sight_Type_Code = Val.ToInt(Drow["SIGHT_TYPE_CODE"]);
        //    Rough_MasterProperty.Sight_Type_Name = Val.ToString(Drow["SIGHT_TYPE_NAME"]);

        //    Rough_MasterProperty.Team_Code = Val.ToInt(Drow["TEAM_CODE"]);
        //    Rough_MasterProperty.Team_Name = Val.ToString(Drow["TEAM_NAME"]);

        //    Rough_MasterProperty.Group_Code = Val.ToInt(Drow["GROUP_CODE"]);
        //    Rough_MasterProperty.Group_Name = Val.ToString(Drow["GROUP_NAME"]);

        //    /* add by khsuhbu 18/11/2014 */
        //    Rough_MasterProperty.Labour_Team_Code = Val.ToInt(Drow["LABOUR_TEAM_CODE"]);
        //    Rough_MasterProperty.Labour_Team_Name = Val.ToString(Drow["LABOUR_TEAM_NAME"]);

        //    Rough_MasterProperty.Labour_Group_Code = Val.ToInt(Drow["LABOUR_GROUP_CODE"]);
        //    Rough_MasterProperty.Labour_Group_Name = Val.ToString(Drow["LABOUR_GROUP_NAME"]);

        //    /* ---------------- */

        //    Rough_MasterProperty.Local_Exchange_Rate = Val.Val(Drow["LOCAL_EXCHANGE_RATE"]);
        //    Rough_MasterProperty.Rate_Dollar = Val.Val(Drow["RATE_DOLLAR"]);
        //    Rough_MasterProperty.Rate_Local = Val.Val(Drow["RATE_LOCAL"]);

        //    Rough_MasterProperty.Amount_Dollar = Val.Val(Drow["AMOUNT_DOLLAR"]);
        //    Rough_MasterProperty.Amount_Local = Val.Val(Drow["AMOUNT_LOCAL"]);

        //    //Rough_MasterProperty.Location_Code = Val.ToInt(Drow["LOCATION_CODE"]);

        //    Rough_MasterProperty.Rough_Type = Val.ToString(Drow["ROUGH_TYPE"]);
        //    Rough_MasterProperty.Article_Head = Val.ToString(Drow["ARTICLE_HEAD"]);

        //    Rough_MasterProperty.VAS_Per = Val.ToDouble(Drow["VAS_PER"]);
        //    Rough_MasterProperty.PRM_Per = Val.ToDouble(Drow["PREAM_PER"]);

        //    //COMMENT BY HARESH ON 07/11/2014
        //    //Rough_MasterProperty.PRM_Rate = Val.ToDouble(Drow["PREAM_AMOUNT"]);

        //    //ADD BY HARESH ON 07/11/2014 FOR PRM_RATE


        //    Rough_MasterProperty.PRM_Rate = Val.ToDouble(Drow["PREAM_RATE"]); // Commented  Narendra : 12-11-2014


        //    Rough_MasterProperty.Exp_Yield = Val.ToDouble(Drow["EXP_YIELD"]);

        //    Rough_MasterProperty.Lab_Per_Pcs = Val.Val(Drow["LABOUR_PER_PCS"]);
        //    Rough_MasterProperty.Rough_Top_Rate = Val.ToDouble(Drow["ROUGH_TOP_RATE"]);

        //    Rough_MasterProperty.Commi_Per = Val.ToDouble(Drow["COMM_PER"]);
        //    Rough_MasterProperty.HOD_EXP_RATE_PER = Val.ToDouble(Drow["HOD_EXP_RATE_PER"]);

        //    Rough_MasterProperty.HOD_EXP_RATE = Val.ToDouble(Drow["HOD_EXP_RATE"]);
        //    Rough_MasterProperty.Con_Rate = Val.ToDouble(Drow["CONS_RATE_PER"]);

        //    Rough_MasterProperty.Over_Head = Val.ToDouble(Drow["OVER_HEAD"]);
        //    Rough_MasterProperty.Is_Mark = Val.ToInt32(Drow["IS_FM_MARK"]);

        //    Rough_MasterProperty.ORSize = Val.Val(Drow["ORSIZE"]);

        //    Rough_MasterProperty.Is_Hide = Val.ToInt32(Drow["IS_HIDE"]);
        //    Rough_MasterProperty.Process_date = Val.DBDate(Val.ToString(Drow["PROCESS_DATE"]));
        //    Rough_MasterProperty.Complete_date = Val.DBDate(Val.ToString(Drow["COMPLETE_DATE"]));

        //    Rough_MasterProperty.Process_Issue_Date = Val.DBDate(Val.ToString(Drow["PROCESS_ISSUE_DATE"]));
        //    Rough_MasterProperty.Article_Head_CostSheet = Val.ToString(Drow["ARTICLE_HEAD_COSTSHEET"]);

        //    // ADD BY NIRAV MORADIYA 12/JUN/2014 

        //    Rough_MasterProperty.Rough_Org_Rate = Val.ToDouble(Drow["ROUGH_ORG_RATE"]);

        //    Rough_MasterProperty.Current_DollarRate = Val.Val(Drow["CURRENT_DOLLARRATE"]);
        //    Rough_MasterProperty.Import_DollarRate = Val.Val(Drow["IMPORT_DOLLARRATE"]);
        //    Rough_MasterProperty.Interest_Per = Val.Val(Drow["INTEREST_PER"]);
        //    Rough_MasterProperty.Other_Cost = Val.Val(Drow["OTHER_COST"]);
        //    Rough_MasterProperty.Abnormal_Cost = Val.Val(Drow["ABNORMAL_COST"]);
        //    Rough_MasterProperty.Admin_Per = Val.Val(Drow["ADMIN_PER"]);
        //    Rough_MasterProperty.Ind_CostPer = Val.Val(Drow["IND_COSTPER"]);
        //    Rough_MasterProperty.PolDept_SalePer = Val.Val(Drow["POLDEPT_SALPER"]);

        //    Rough_MasterProperty.Boiling_CostPer = Val.Val(Drow["BOILING_COSTPER"]);
        //    Rough_MasterProperty.PolInd_CostPer = Val.Val(Drow["POLIND_COSTPER"]);
        //    Rough_MasterProperty.Depth_Per = Val.Val(Drow["DEP_PER"]);
        //    Rough_MasterProperty.Selling_Per = Val.Val(Drow["SELLING_PER"]);

        //    Rough_MasterProperty.Labour = Val.ToInt(Drow["LABOUR"]);
        //    Rough_MasterProperty.Repairing_Exp = Val.ToInt(Drow["REPAIRING_EXP"]);
        //    Rough_MasterProperty.SLab_PerPcs = Val.ToInt(Drow["SLAB_PERPCS"]);
        //    Rough_MasterProperty.Grading_Cost = Val.ToInt(Drow["GRADING_COST"]);

        //    Rough_MasterProperty.Realization_Crts = Val.Val(Drow["REAUZATION_CRT"]);
        //    Rough_MasterProperty.Realization_Rate = Val.Val(Drow["REAUZATION_RATE"]);
        //    Rough_MasterProperty.SingleStone_Crts = Val.Val(Drow["SINGLESTONE_CRT"]);
        //    Rough_MasterProperty.SingleStone_Rate = Val.Val(Drow["SINGLESTONE_RATE"]);

        //    Rough_MasterProperty.Is_CostSheetCompleted = Val.ToInt(Drow["IS_COSTSHEETCOMPLETED"]);
        //    Rough_MasterProperty.Is_CostSheetLocked = Val.ToInt(Drow["IS_COSTSHEETLOCKED"]);
        //    Rough_MasterProperty.Costing_Remark = Val.ToString(Drow["COSTING_REMARK"]);

        //    Rough_MasterProperty.Create_Date = Val.DBDate(Val.ToString(Drow["CREATE_DATE"]));

        //    // ADD BY HARESH ON 26-11-2014

        //    Rough_MasterProperty.Import_Date = Val.DBDate(Val.ToString(Drow["IMPORT_DATE"]));
        //    Rough_MasterProperty.Costing_Issue_Date = Val.DBDate(Val.ToString(Drow["COSTING_ISSUE_DATE"]));
        //    Rough_MasterProperty.Costing_Complete_Date = Val.DBDate(Val.ToString(Drow["COSTING_COMPLETE_DATE"]));

        //    //
        //    Rough_MasterProperty.Polished_Date = Val.DBDate(Val.ToString(Drow["POLISHED_DATE"]));
        //    Rough_MasterProperty.Valuation_Date = Val.DBDate(Val.ToString(Drow["VALUATION_DATE"]));
        //    Rough_MasterProperty.Payment_Date = Val.DBDate(Val.ToString(Drow["PAYMENT_DATE"]));
        //    Rough_MasterProperty.Terms_Days = Val.ToInt32(Val.ToString(Drow["TERMS_DAYS"]));

        //    Rough_MasterProperty.Abnormal_Cost_A = Val.Val(Drow["ABNORMAL_COST_A"]);
        //    Rough_MasterProperty.Abnormal_Cost_B = Val.Val(Drow["ABNORMAL_COST_B"]);
        //    Rough_MasterProperty.Abnormal_Cost_C = Val.Val(Drow["ABNORMAL_COST_C"]);

        //    Drow = null;
        //    return Rough_MasterProperty;
        //}

        public int GetPaymentAvgTermsDay(string RoughName)
        {
            Request Request = new Request();
            DataTable Data = new DataTable();
            string StrSql = "select AVG_TERMS from VIW_ROUGH_AMOUNT WHERE ROUGH_NAME = '" + RoughName + "'";
            Request.CommandText = StrSql;
            Request.CommandType = CommandType.Text;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Data, Request);

            if (Data.Rows.Count == 0 || Data == null)
            {
                return 0;
            }
            else
                return Val.ToInt32(Data.Rows[0]["AVG_TERMS"]);
        }


        //public DataTable GetRoughLotDetData(Rough_Lot_DetailProperty pClsProperty)
        //{
        //    DataTable DTab = new DataTable();
        //    return DTab;
        //    //Request Request = new Request();

        //    //Request.CommandText = "Rough_Lot_Detail_GetData";
        //    //Request.CommandType = CommandType.StoredProcedure;
        //    //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);


        //    //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
        //    //{
        //    //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, TableLotDetail, Request, "");
        //    //}
        //    //else
        //    //{
        //    //    Ope.GetDataSet(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DS, TableLotDetail, Request, "");
        //    //}


        //    //return DS.Tables[TableLotDetail];
        //}

        public DataTable GetRoughLotDetailView(string pStrRoughName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("OPE_", "LOT_DETAIL", DbType.String, ParameterDirection.Input);
            Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Rough_Lot_Detail_GetData";
            Request.CommandType = CommandType.StoredProcedure;

            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //}
            //else
            //{
            //    Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
            //}
            return DTab;
        }

        #endregion

        #region Rough Trancation Log

        public Int64 FindNewTranID()
        {
            Int64 IntRes = Ope.FindNewIDInt64(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Rough_Trn_Log", "MAX(TRN_ID)", " ");
            return IntRes;
        }

        public Int64 FindNewTranIDNew()
        {
            Int64 IntRes = 0;
            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    IntRes = Ope.FindNewIDInt64(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Rough_Trn_Log", "MAX(TRN_ID)", " ");
            //}
            //else if (GlobalDec.gEmployeeProperty.Allow_Developer == 1)
            //{
            //    IntRes = Ope.FindNewIDInt64(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, "Rough_Trn_Log", "MAX(TRN_ID)", " ");
            //}

            return IntRes;
        }

        //public int SaveRoughTransLog(Rough_Trn_LogProperty pClsProperty)
        //{
        //    int IntRes = 0;

        //    Request Request = new Request();

        //    Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("B_ORG_PCS_", pClsProperty.B_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("B_ORG_CARAT_", pClsProperty.B_Org_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_BALANCE_PCS_", pClsProperty.B_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("B_BALANCE_CARAT_", pClsProperty.B_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_RATE_DOLLAR_", pClsProperty.B_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_RATE_LOCAL_", pClsProperty.B_Rate_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_AMOUNT_DOLLAR_", pClsProperty.B_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_AMOUNT_LOCAL_", pClsProperty.B_Amount_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_LOCAL_EXCHANGE_RATE_", pClsProperty.B_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("TRN_PCS_", pClsProperty.Trn_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TRN_CARAT_", pClsProperty.Trn_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TRN_RATE_", pClsProperty.Trn_Rate, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TRN_AMOUNT_", pClsProperty.Trn_Amount, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("A_ORG_PCS_", pClsProperty.A_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("A_ORG_CARAT_", pClsProperty.A_Org_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_BALANCE_PCS_", pClsProperty.A_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("A_BALANCE_CARAT_", pClsProperty.A_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_RATE_DOLLAR_", pClsProperty.A_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_RATE_LOCAL_", pClsProperty.A_Rate_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_AMOUNT_DOLLAR_", pClsProperty.A_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_AMOUNT_LOCAL_", pClsProperty.A_Amount_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_LOCAL_EXCHANGE_RATE_", pClsProperty.A_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("TYPE_", pClsProperty.Type.ToString(), DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("TO_ROUGH_NAME_", pClsProperty.To_Rough_Name, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("STOCK_JANGED_NO_", pClsProperty.Stock_Janged_No, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("STOCK_JANGED_DATE_", pClsProperty.Stock_Janged_Date, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("STOCK_SRNO_", pClsProperty.Stock_SrNo, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", BLL.GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("OPE_", pClsProperty.Ope, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.CommandText = "Rough_Trn_Log_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);


        //    // B Part Save

        //    Request = new Request();

        //    Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("B_ORG_PCS_", pClsProperty.B_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("B_ORG_CARAT_", pClsProperty.B_Org_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_BALANCE_PCS_", pClsProperty.B_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("B_BALANCE_CARAT_", pClsProperty.B_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_RATE_DOLLAR_", pClsProperty.B_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_RATE_LOCAL_", pClsProperty.B_Rate_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_AMOUNT_DOLLAR_", pClsProperty.B_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_AMOUNT_LOCAL_", pClsProperty.B_Amount_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_LOCAL_EXCHANGE_RATE_", pClsProperty.B_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("TRN_PCS_", pClsProperty.Trn_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TRN_CARAT_", pClsProperty.Trn_Crts, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("A_ORG_PCS_", pClsProperty.A_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("A_ORG_CARAT_", pClsProperty.A_Org_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_BALANCE_PCS_", pClsProperty.A_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("A_BALANCE_CARAT_", pClsProperty.A_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_RATE_DOLLAR_", pClsProperty.A_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_RATE_LOCAL_", pClsProperty.A_Rate_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_AMOUNT_DOLLAR_", pClsProperty.A_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_AMOUNT_LOCAL_", pClsProperty.A_Amount_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_LOCAL_EXCHANGE_RATE_", pClsProperty.A_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("TYPE_", pClsProperty.Type.ToString(), DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("TO_ROUGH_NAME_", pClsProperty.To_Rough_Name, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("STOCK_JANGED_NO_", pClsProperty.Stock_Janged_No, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("STOCK_JANGED_DATE_", pClsProperty.Stock_Janged_Date, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("STOCK_SRNO_", pClsProperty.Stock_SrNo, DbType.Int32, ParameterDirection.Input);


        //    Request.CommandText = "Rough_Trn_Log_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

        //    return IntRes;
        //}

        //public int SaveRoughTransLogFromTransfer(Rough_Trn_LogProperty pClsProperty, string pStrOperation)
        //{

        //    if (pStrOperation == "ROUGH TO MIX")
        //    {
        //        // B Part Save

        //        Request Request = new Request();

        //        Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int64, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("B_ORG_PCS_", pClsProperty.B_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("B_ORG_CARAT_", pClsProperty.B_Org_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_BALANCE_PCS_", pClsProperty.B_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("B_BALANCE_CARAT_", pClsProperty.B_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_RATE_DOLLAR_", pClsProperty.B_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_RATE_LOCAL_", pClsProperty.B_Rate_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_AMOUNT_DOLLAR_", pClsProperty.B_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_AMOUNT_LOCAL_", pClsProperty.B_Amount_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_LOCAL_EXCHANGE_RATE_", pClsProperty.B_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //        Request.AddParams("TRN_PCS_", pClsProperty.Trn_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TRN_CARAT_", pClsProperty.Trn_Crts, DbType.Double, ParameterDirection.Input);

        //        Request.AddParams("A_ORG_PCS_", pClsProperty.A_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("A_ORG_CARAT_", pClsProperty.A_Org_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_BALANCE_PCS_", pClsProperty.A_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("A_BALANCE_CARAT_", pClsProperty.A_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_RATE_DOLLAR_", pClsProperty.A_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_RATE_LOCAL_", pClsProperty.A_Rate_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_AMOUNT_DOLLAR_", pClsProperty.A_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_AMOUNT_LOCAL_", pClsProperty.A_Amount_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_LOCAL_EXCHANGE_RATE_", pClsProperty.A_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //        Request.AddParams("TYPE_", pClsProperty.Type.ToString(), DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("REMARK_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("TO_ROUGH_NAME_", pClsProperty.To_Rough_Name, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("STOCK_JANGED_NO_", pClsProperty.Stock_Janged_No, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("STOCK_JANGED_DATE_", pClsProperty.Stock_Janged_Date, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("STOCK_SRNO_", pClsProperty.Stock_SrNo, DbType.Int32, ParameterDirection.Input);


        //        Request.CommandText = "Rough_Trn_Log_Save";
        //        Request.CommandType = CommandType.StoredProcedure;
        //        int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //        return IntRes;
        //    }
        //    else
        //    {


        //        Request Request = new Request();

        //        Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int64, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("B_ORG_PCS_", pClsProperty.B_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("B_ORG_CARAT_", pClsProperty.B_Org_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_BALANCE_PCS_", pClsProperty.B_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("B_BALANCE_CARAT_", pClsProperty.B_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_RATE_DOLLAR_", pClsProperty.B_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_RATE_LOCAL_", pClsProperty.B_Rate_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_AMOUNT_DOLLAR_", pClsProperty.B_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_AMOUNT_LOCAL_", pClsProperty.B_Amount_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_LOCAL_EXCHANGE_RATE_", pClsProperty.B_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //        Request.AddParams("TRN_PCS_", pClsProperty.Trn_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TRN_CARAT_", pClsProperty.Trn_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("TRN_RATE_", pClsProperty.Trn_Rate, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("TRN_AMOUNT_", pClsProperty.Trn_Amount, DbType.Double, ParameterDirection.Input);

        //        Request.AddParams("A_ORG_PCS_", pClsProperty.A_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("A_ORG_CARAT_", pClsProperty.A_Org_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_BALANCE_PCS_", pClsProperty.A_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("A_BALANCE_CARAT_", pClsProperty.A_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_RATE_DOLLAR_", pClsProperty.A_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_RATE_LOCAL_", pClsProperty.A_Rate_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_AMOUNT_DOLLAR_", pClsProperty.A_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_AMOUNT_LOCAL_", pClsProperty.A_Amount_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_LOCAL_EXCHANGE_RATE_", pClsProperty.A_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //        Request.AddParams("TYPE_", pClsProperty.Type.ToString(), DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("REMARK_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("TO_ROUGH_NAME_", pClsProperty.To_Rough_Name, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("STOCK_JANGED_NO_", pClsProperty.Stock_Janged_No, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("STOCK_JANGED_DATE_", pClsProperty.Stock_Janged_Date, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("STOCK_SRNO_", pClsProperty.Stock_SrNo, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("DEPARTMENT_CODE_", BLL.GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("OPE_", pClsProperty.Ope, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);

        //        Request.CommandText = "Rough_Trn_Log_Save";
        //        Request.CommandType = CommandType.StoredProcedure;
        //        int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);


        //        // B Part Save

        //        Request = new Request();

        //        Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int64, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("B_ORG_PCS_", pClsProperty.B_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("B_ORG_CARAT_", pClsProperty.B_Org_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_BALANCE_PCS_", pClsProperty.B_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("B_BALANCE_CARAT_", pClsProperty.B_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_RATE_DOLLAR_", pClsProperty.B_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_RATE_LOCAL_", pClsProperty.B_Rate_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_AMOUNT_DOLLAR_", pClsProperty.B_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_AMOUNT_LOCAL_", pClsProperty.B_Amount_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("B_LOCAL_EXCHANGE_RATE_", pClsProperty.B_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //        Request.AddParams("TRN_PCS_", pClsProperty.Trn_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TRN_CARAT_", pClsProperty.Trn_Crts, DbType.Double, ParameterDirection.Input);

        //        Request.AddParams("A_ORG_PCS_", pClsProperty.A_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("A_ORG_CARAT_", pClsProperty.A_Org_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_BALANCE_PCS_", pClsProperty.A_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("A_BALANCE_CARAT_", pClsProperty.A_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_RATE_DOLLAR_", pClsProperty.A_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_RATE_LOCAL_", pClsProperty.A_Rate_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_AMOUNT_DOLLAR_", pClsProperty.A_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_AMOUNT_LOCAL_", pClsProperty.A_Amount_Local, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("A_LOCAL_EXCHANGE_RATE_", pClsProperty.A_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //        Request.AddParams("TYPE_", pClsProperty.Type.ToString(), DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("REMARK_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("TO_ROUGH_NAME_", pClsProperty.To_Rough_Name, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("STOCK_JANGED_NO_", pClsProperty.Stock_Janged_No, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("STOCK_JANGED_DATE_", pClsProperty.Stock_Janged_Date, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("STOCK_SRNO_", pClsProperty.Stock_SrNo, DbType.Int32, ParameterDirection.Input);


        //        Request.CommandText = "Rough_Trn_Log_Save";
        //        Request.CommandType = CommandType.StoredProcedure;
        //        IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

        //        return IntRes;
        //    }

        //}

        //public int SaveRoughTransLogNew(Rough_Trn_LogProperty pClsProperty)
        //{
        //    int IntRes = 0;

        //    Request Request = new Request();

        //    Request.AddParams("TRN_ID_", pClsProperty.Trn_Id, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("B_ORG_PCS_", pClsProperty.B_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("B_ORG_CARAT_", pClsProperty.B_Org_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_BALANCE_PCS_", pClsProperty.B_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("B_BALANCE_CARAT_", pClsProperty.B_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_RATE_DOLLAR_", pClsProperty.B_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_RATE_LOCAL_", pClsProperty.B_Rate_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_AMOUNT_DOLLAR_", pClsProperty.B_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_AMOUNT_LOCAL_", pClsProperty.B_Amount_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("B_LOCAL_EXCHANGE_RATE_", pClsProperty.B_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("TRN_PCS_", pClsProperty.Trn_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TRN_CARAT_", pClsProperty.Trn_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TRN_RATE_", pClsProperty.Trn_Rate, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TRN_AMOUNT_", pClsProperty.Trn_Amount, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("A_ORG_PCS_", pClsProperty.A_Org_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("A_ORG_CARAT_", pClsProperty.A_Org_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_BALANCE_PCS_", pClsProperty.A_Balance_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("A_BALANCE_CARAT_", pClsProperty.A_Balance_Crts, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_RATE_DOLLAR_", pClsProperty.A_Rate_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_RATE_LOCAL_", pClsProperty.A_Rate_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_AMOUNT_DOLLAR_", pClsProperty.A_Amount_Dollar, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_AMOUNT_LOCAL_", pClsProperty.A_Amount_Local, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("A_LOCAL_EXCHANGE_RATE_", pClsProperty.A_Local_Exchange_Rate, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("TYPE_", pClsProperty.Type.ToString(), DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("TO_ROUGH_NAME_", pClsProperty.To_Rough_Name, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("STOCK_JANGED_NO_", pClsProperty.Stock_Janged_No, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("STOCK_JANGED_DATE_", pClsProperty.Stock_Janged_Date, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("STOCK_SRNO_", pClsProperty.Stock_SrNo, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", BLL.GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("OPE_", pClsProperty.Ope, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.CommandText = "Rough_Trn_Log_Save";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
        //    //{
        //    //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    //}
        //    //else
        //    //{
        //    //    IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
        //    //}

        //    return IntRes;
        //}
    }
        #endregion
}

