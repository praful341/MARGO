using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;

namespace BLL.FunctionClasses.Master
{
    public class ColorMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function
        
        public int Save(Color_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@Color_code", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Color_Name", pClsProperty.Color_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_COLOR_CODE", pClsProperty.Rap_Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_BACK_COLOR_CODE", pClsProperty.Rap_Back_Color_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@POLISH_COLOR_CODE", pClsProperty.Polish_Color_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_COLOR_NAME", pClsProperty.Rap_Color_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LAB_COLOR_NAME", pClsProperty.LAB_Color_Name, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Color_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);     
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "Color_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Color_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");

            return DTab;
        }

        public string ISExists(string ColorName, Int64 ColorCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "COLOR_MASTER", "COLOR_NAME", "AND COLOR_NAME = '" + ColorName + "' AND NOT COLOR_CODE =" + ColorCode));
        }

        #endregion
    }

}
