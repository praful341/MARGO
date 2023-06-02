using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;

namespace BLL.FunctionClasses.Master
{
    public class ClarityMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();       

        #region Other Function       

        public int Save(Clarity_MasterProperty pClsProperty) // Add : Narendra : 02-Sep-2014
        {
            Request Request = new Request();

            Request.AddParams("@Clarity_Code", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Clarity_Name", pClsProperty.Clarity_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_CLARITY_CODE", pClsProperty.Rap_Clarity_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_BACK_CLARITY_NAME", pClsProperty.Rap_Back_Clarity_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_CLARITY_NAME", pClsProperty.Rap_Clarity_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LAB_CLARITY_NAME", pClsProperty.LAB_CLARITY_NAME, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TYPE", pClsProperty.Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Mapping_Code", pClsProperty.Mapping_Code, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "Clarity_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;

            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Clarity_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Clarity_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public string ISExists(string ClarityName, Int64 ClarityCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "CLARITY_MASTER", "CLARITY_NAME", "AND CLARITY_NAME = '" + ClarityName + "' AND NOT CLARITY_CODE =" + ClarityCode));
        }

        #endregion
    }
}



