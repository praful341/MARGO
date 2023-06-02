using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;
namespace BLL.FunctionClasses.Master
{
    public class PartyMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public int Save(Party_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@Party_code", pClsProperty.Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Party_Name", pClsProperty.Party_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Mobile", pClsProperty.Mobile_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_PanNo", pClsProperty.Pan_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Type", pClsProperty.Party_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Email", pClsProperty.EMail, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Address", pClsProperty.Address, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Country_Code", pClsProperty.Country_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Party_State_Code", pClsProperty.State_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Party_City_Code", pClsProperty.City_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Party_Pincode", pClsProperty.Zip_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Party_Phone", pClsProperty.Phone, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_Name", pClsProperty.Bank_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_Branch", pClsProperty.Bank_Branch, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_IFSC", pClsProperty.Bank_IFSC, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Bank_AccountNo", pClsProperty.Bank_Acc_No, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Party_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData(Party_MasterProperty Type)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", Type.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Type", Type.Party_Type, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Party_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Party_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string PartyName, Int64 PartyCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "PARTY_MASTER", "PARTY_NAME", "AND PARTY_NAME = '" + PartyName + "' AND NOT PARTY_CODE =" + PartyCode));
        }
        #endregion

    }
}

