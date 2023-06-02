using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;

namespace BLL.FunctionClasses.Master
{
    public class SieveMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        Validation Val = new Validation();

        #region Other Function

        public int Save(Sieve_MasterProperty pClsProperty) // Add : Narendra : 03-Sep-2014
        {
            Request Request = new Request();
            Request.AddParams("@Sieve_code", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Sieve_Name", pClsProperty.Sieve_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_SIEVE", pClsProperty.From_Sieve, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_SIEVE", pClsProperty.To_Sieve, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@IS_SAMPLE", pClsProperty.Is_Sample, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_MIXTRAN", pClsProperty.Is_MixTran, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@SIZE_TYPE", pClsProperty.Size_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_SIZE_CODE", pClsProperty.RAP_Size_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PCS", pClsProperty.From_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_PCS", pClsProperty.To_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@DEFAULT_SIEVE_FLAG", pClsProperty.Default_Sieve_Flag, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@FROM_CARAT", pClsProperty.From_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_CARAT", pClsProperty.To_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@DM_PER", pClsProperty.DM_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@MANUAL_PER", pClsProperty.Manual_Per, DbType.Double, ParameterDirection.Input);

            Request.CommandText = "Sieve_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }       

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Sieve_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        
        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();            

            Request.CommandText = "Sieve_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string SieveName, Int64 SieveCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "SIEVE_MASTER", "SIEVE_NAME", "AND SIEVE_NAME = '" + SieveName + "' AND NOT SIEVE_CODE =" + SieveCode));
        } 

        #endregion
    }
}

