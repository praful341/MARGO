using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;
namespace BLL.FunctionClasses.Master
{
    public class OrderMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public int Save(Order_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@Order_ID", pClsProperty.Order_ID, DbType.Int64);
            Request.AddParams("@Order_Date", pClsProperty.Order_Date, DbType.Date);
            Request.AddParams("@Enquiry_No", pClsProperty.Enquiry_No, DbType.Int64);
            Request.AddParams("@Confirm_Date", pClsProperty.Confirm_Date, DbType.Date);
            Request.AddParams("@Duration", pClsProperty.Duration, DbType.Int64);
            Request.AddParams("@Delivery_Date", pClsProperty.Delivery_Date, DbType.Date);
            Request.AddParams("@Is_Applicable", pClsProperty.Is_Applicable, DbType.Int32);
            Request.AddParams("@AMC_Start_Date", pClsProperty.AMC_Start_Date, DbType.Date);
            Request.AddParams("@AMC_End_Date", pClsProperty.AMC_End_Date, DbType.Date);

            Request.CommandText = "Order_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Order_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string EnquiryNo, Int64 OrderID)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Order_Master", "Enquiry_No", "AND Enquiry_No = '" + EnquiryNo + "' AND NOT Order_ID =" + OrderID));
        }
        #endregion

    }
}

