using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;
namespace BLL.FunctionClasses.Master
{
    public class ShapeMaster
    {
        Validation Val = new Validation();
        InterfaceLayer Ope = new InterfaceLayer();

        #region Other Function

        public int Save(Shape_MasterProperty pClsProperty) // Add : Narendra : 02-Sep-2014
        {
            Request Request = new Request();

            Request.AddParams("@Shape_code", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@SHAPE_NAME", pClsProperty.Shape_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_SHAPE_CODE", pClsProperty.Rap_Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_SHAPE_NAME", pClsProperty.Rap_Shape_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_RATE_SHAPE_NAME", pClsProperty.Rough_Rate_Shape_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_BACK_SHAPE_CODE", pClsProperty.Rap_Back_Shape_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FCP_SHAPE_NAME", pClsProperty.FCP_Shape_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LAB_SHAPE_NAME", pClsProperty.LAB_Shape_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MIX_CP_SHAPE", pClsProperty.MIX_CP_SHAPE, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BACK_SHAPE_NAME", pClsProperty.BACK_SHAPE_NAME, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_RATE_SHAPE_CODE", pClsProperty.ROUGH_RATE_SHAPE_CODE, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RAP_BACK_SHAPE_NAME", pClsProperty.RAP_BACK_SHAPE_NAME, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FCP_SHAPE_CODE", pClsProperty.FCP_SHAPE_CODE, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LAB_SHAPE_CODE", pClsProperty.LAB_SHAPE_CODE, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BACK_SHAPE_CODE", pClsProperty.BACK_SHAPE_CODE, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Shape_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);  
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Shape_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetDataForSearch()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Shape_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string ShapeName, Int64 ShapeCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "SHAPE_MASTER", "SHAPE_NAME", "AND SHAPE_NAME = '" + ShapeName + "' AND NOT SHAPE_CODE =" + ShapeCode));
        } 

        #endregion
    }
}
