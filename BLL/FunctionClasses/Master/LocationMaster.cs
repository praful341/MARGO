using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;
namespace BLL.FunctionClasses.Master
{
    public class LocationMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

        public int Save(Location_MasterProperty pClsProperty) 
        {
            Request Request = new Request();

            Request.AddParams("@Location_code", pClsProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Location_Name", pClsProperty.Location_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Location_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);         
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Location_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Location_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string LocationName, Int64 LocationCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "LOCATION_MASTER", "LOCATION_NAME", "AND LOCATION_NAME = '" + LocationName + "' AND NOT LOCATION_CODE =" + LocationCode));
        }  

        #endregion
    }
}
