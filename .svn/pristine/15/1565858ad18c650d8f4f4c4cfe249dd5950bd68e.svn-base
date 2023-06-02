using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;
namespace BLL.FunctionClasses.Master
{
    public class EnquiryMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public int Save(Enquiry_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@Enquiry_ID", pClsProperty.Enquiry_ID, DbType.Int64);
            Request.AddParams("@Enquiry_Date", pClsProperty.Enquiry_Date, DbType.Date);
            Request.AddParams("@Party_Name", pClsProperty.Party_Name, DbType.String);
            Request.AddParams("@Ref_Name", pClsProperty.Ref_Name, DbType.String);
            Request.AddParams("@Quated_Amt", pClsProperty.Quated_Amt, DbType.Decimal);
            Request.AddParams("@Schedule_Callback", pClsProperty.Schedule_Call_Back, DbType.Date);
            Request.AddParams("@Party_Contact", pClsProperty.Party_Contact, DbType.Int64);
            Request.AddParams("@Description", pClsProperty.Description, DbType.String);
            Request.AddParams("@Contact_Person", pClsProperty.Contact_Person, DbType.String);
            Request.AddParams("@Product_Name", pClsProperty.Product_Name, DbType.String);
            Request.AddParams("@Party_Email", pClsProperty.Party_Email_ID, DbType.String);

            Request.CommandText = "Enquiry_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();          

            Request.CommandText = "Enquiry_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Enquiry_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string PartyName, Int64 EnquiryID)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Enquiry_Master", "Party_Name", "AND Party_Name = '" + PartyName + "' AND NOT Enquiry_ID =" + EnquiryID));
        }
        #endregion

    }
}

