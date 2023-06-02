using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Report;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Report;
using System.Data;
using DLL;
namespace BLL.FunctionClasses.Report
{
    public class ReportParams
    {
        public enum ReportGroup
        {
            PURCHASE = 0,
            MIXTRANSACTION = 1
        }

        public struct CrystalParameter
        {
        }

        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public DataTable Get_MIX_Prepolishing_Stock_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_COMPANY_CODE_", pClsProperty.From_Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_COMPANY_CODE_", pClsProperty.To_Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_BRANCH_CODE_", pClsProperty.From_Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_BRANCH_CODE_", pClsProperty.To_Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ARTICLE_HEAD_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CLV_CLARITY_CODE_", pClsProperty.CLV_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@FROM_RECEIVE_DATE_", pClsProperty.From_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_RECEIVE_DATE_", pClsProperty.To_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ISSUE_JANGED_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
           
            return DTab;
        }

        public DataTable Get_MIX_EMP_Stock_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FROM_COMPANY_CODE_", pClsProperty.From_Company_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@TO_COMPANY_CODE_", pClsProperty.To_Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FROM_BRANCH_CODE_", pClsProperty.From_Branch_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@TO_BRANCH_CODE_", pClsProperty.To_Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@ARTICLE_HEAD_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CLV_CLARITY_CODE_", pClsProperty.CLV_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@FROM_RECEIVE_DATE_", pClsProperty.From_Receive_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@TO_RECEIVE_DATE_", pClsProperty.To_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@ISSUE_JANGED_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }


        public DataTable Get_Transaction_View_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_ISSUE_DATE_", pClsProperty.From_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_ISSUE_DATE_", pClsProperty.To_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@CASH_TYPE_", pClsProperty.Cash_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PARTY_CODE_", pClsProperty.Party_Code, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_MIX_Party_Stock_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PROCESS_CODE_", pClsProperty.Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@CITY_", pClsProperty.City, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input); 
            Request.AddParams("@ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);    
            Request.AddParams("@SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);           
            Request.AddParams("@MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CLV_CLARITY_CODE_", pClsProperty.CLV_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@FROM_RECEIVE_DATE_", pClsProperty.From_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_RECEIVE_DATE_", pClsProperty.To_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public DataTable Get_MIX_Prepolishing_OutSide_Stock_Report(ReportParams_Property pClsProperty, string pStrSPName)
        {
            DataTable DTab = new DataTable();

            Request Request = new Request();

            Request.AddParams("@GROUP_BY_", pClsProperty.Group_By_Tag, DbType.String, ParameterDirection.Input);

            //Request.AddParams("@COMPANY_CODE_", pClsProperty.Company_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@BRANCH_CODE_", pClsProperty.Branch_Code, DbType.String, ParameterDirection.Input);

            //Request.AddParams("PROCESS_GROUP_CODE_", pClsProperty.Process_Group_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PROCESS_CODE_", pClsProperty.Process_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("@FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.String, ParameterDirection.Input);
            // Request.AddParams("@FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.String, ParameterDirection.Input);

            //Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("ARTICLE_CODE_", pClsProperty.Article_Code, DbType.String, ParameterDirection.Input);

            //Request.AddParams("@LOCATION_CODE_", pClsProperty.Location_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("MAIN_LOCATION_CODE_", pClsProperty.Main_Location_Code, DbType.String, ParameterDirection.Input);
           // Request.AddParams("@CITY_", pClsProperty.City, DbType.String, ParameterDirection.Input);

            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

            Request.AddParams("@SHAPE_CODE_", pClsProperty.Shape_Code, DbType.String, ParameterDirection.Input);            
            Request.AddParams("@COLOR_CODE_", pClsProperty.Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CLV_CLARITY_CODE_", pClsProperty.CLV_Clarity_Code, DbType.String, ParameterDirection.Input);
            //Request.AddParams("POINTER_CODE_", pClsProperty.Pointer_Code, DbType.String, ParameterDirection.Input);

            Request.AddParams("@FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("@FROM_RECEIVE_DATE_", pClsProperty.From_Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_RECEIVE_DATE_", pClsProperty.To_Receive_Date, DbType.Date, ParameterDirection.Input);

            //Request.AddParams("FROM_CONF_DATE_", pClsProperty.From_Conf_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("TO_CONF_DATE_", pClsProperty.To_Conf_Date, DbType.Date, ParameterDirection.Input);

            //Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            //Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.String, ParameterDirection.Input);

            //Request.AddParams("IS_SHOW_LABOUR_", pClsProperty.ISShowLabour, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("RECEIPT_DAYS_", pClsProperty.ReceiptDays, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = pStrSPName;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        #endregion
    }
}
