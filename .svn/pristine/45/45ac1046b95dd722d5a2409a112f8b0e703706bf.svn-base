using System.Data;
using DLL;
using BLL.PropertyClasses.Master;
using System;
namespace BLL.FunctionClasses.Master
{
    public class RoughTypeMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

        public int Save(RoughType_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@ROUGH_TYPE_CODE", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_NAME", pClsProperty.Rough_Type_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Rough_Type_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Rough_Type_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Rough_Type_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string RoughTypeName, Int64 RoughTypeCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "ROUGH_TYPE_MASTER", "ROUGH_TYPE_NAME", "AND ROUGH_TYPE_NAME = '" + RoughTypeName + "' AND NOT ROUGH_TYPE_CODE =" + RoughTypeCode));
        } 

        #endregion

        #region Operation

        public DataRow GetData(string pStrStockDate, string pStrRoughName, string pStrOperation)
        {
            Request Request = new Request();
            Request.CommandText = "Rep_Stock_Running_Possition";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@OPE_", pStrOperation, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);
            Request.AddParams("@STOCK_DATE_", pStrStockDate, DbType.Date, ParameterDirection.Input);

            return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetRough(string pStrRoughName,int pIntAll)
        {
            DataTable DTabRough = new DataTable();
            Request Request = new Request();
            Request.CommandText = "Rpt_Stock_Running_GetRough";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);
            //Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ALL_", pIntAll, DbType.Int32, ParameterDirection.Input);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabRough, Request);
            return DTabRough;
        }

        #endregion
    }
}
