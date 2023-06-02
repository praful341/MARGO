using System;
using BLL.PropertyClasses.Master;
using System.Data;
using DLL;

namespace BLL.FunctionClasses.Master
{
    public class ProcessMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function

        public int Save(Process_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@PROCESS_CODE", pClsProperty.Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@PROCESS_NAME", pClsProperty.Process_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PROCESS_GROUP_NAME", pClsProperty.Process_Group_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MAX_LOSS", pClsProperty.MaxLoss, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@MAX_REPEAT", pClsProperty.MaxRepeat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@MAX_IDEAL_DAYS", pClsProperty.Max_Ideal_Days, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@PROCESS_TYPE", pClsProperty.ProcessType, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ALLOW_ROUGH_RETURN", pClsProperty.Allow_Rough_Return, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_SPLIT", pClsProperty.Return_With_Split, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@NEXT_PROCESS_CODE", "0", DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@MIX_WITH_PROCESS_CODE", pClsProperty.Mix_With_Process_Code, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@ISSUE_WITH_BARCODE", pClsProperty.Issue_With_Barcode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_SHAPE", pClsProperty.Issue_With_Shape, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_CLARITY", pClsProperty.Issue_With_Clarity, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_COLOR", pClsProperty.Issue_With_Color, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_SIEVE", pClsProperty.Issue_With_Sieve, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_LOSS", pClsProperty.Issue_With_Loss, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_LOST", pClsProperty.Issue_With_Lost, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_MSIZE", pClsProperty.Issue_With_MSize, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_MACHINE", pClsProperty.Issue_With_Machine, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_CARAT_PLUS", pClsProperty.Issue_With_CaratPlus, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("@RETURN_WITH_BARCODE", pClsProperty.Return_With_Barcode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_SHAPE", pClsProperty.Return_With_Shape, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_CLARITY", pClsProperty.Return_With_Clarity, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_COLOR", pClsProperty.Return_With_Color, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_SIEVE", pClsProperty.Return_With_Sieve, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_LOSS", pClsProperty.Return_With_Loss, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_LOST", pClsProperty.Return_With_Lost, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_MSIZE", pClsProperty.Return_With_MSize, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_MACHINE", pClsProperty.Return_With_Machine, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_CARAT_PLUS", pClsProperty.Return_With_CaratPlus, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("@DEFAULT_STOCK_FLAG", pClsProperty.Default_Stock_Flag, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ACTIVE", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@REMARK", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@JANGED_PREFIX", pClsProperty.Janged_Prefix, DbType.String, ParameterDirection.Input);
            Request.AddParams("@IS_THIRD_PARTY_TRANSFER", pClsProperty.IS_Third_Party_Transfer, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_UNTOUCH", pClsProperty.Is_Untouch, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_DISP_ONRETURN", pClsProperty.Is_Disp_OnReturn, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_MFG_TYPE", pClsProperty.Is_MFG_Type, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_MANUFACTURING", pClsProperty.Is_Manufacturing, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_OPEN_ISSUE_TO_OUTSIDE", pClsProperty.IS_Open_Issue_To_OutSide, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_LABOUR_RATE_CALCULATE", pClsProperty.Is_Labour_Rate_Calculate, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_FROM_PARTY_REQUIRED", pClsProperty.IS_From_Party_Required, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_TO_PARTY_REQUIRED", pClsProperty.IS_To_Party_Required, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_JW_ISSUE_EFFECT_STOCK", pClsProperty.Is_Jw_Issue_Effect_Stock, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@CLV_TO_OUTSIDE_HEADER", pClsProperty.Clv_To_OutSide_Header, DbType.String, ParameterDirection.Input);
            Request.AddParams("@MFG_TO_HO_HEADER", pClsProperty.MFG_To_HO_Header, DbType.String, ParameterDirection.Input);
            Request.AddParams("@HO_RECEIVE_HEADER", pClsProperty.HO_Receive_Header, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", pClsProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@OLD_PROCESS_CODE", "0", DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ALLOW_CHANGE_NEXT_PROCESS", pClsProperty.Allow_change_Next_Process, DbType.Int32, ParameterDirection.Input);
       
            Request.CommandText = "Process_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "Process_Master_GetData";

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@PROCESS_CODE", "0", DbType.Int64, ParameterDirection.Input);

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "Process_Master_Search_GetData";

            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string ISExists(string ProcessName, Int64 ProcessCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "PROCESS_MASTER", "PROCESS_NAME", "AND PROCESS_NAME = '" + ProcessName + "' AND NOT PROCESS_CODE =" + ProcessCode));
        }

        public Process_MasterProperty GetDataByPK(Int64 pIntProcessCode)
        {
            Request Request = new Request();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@PROCESS_CODE", pIntProcessCode, DbType.Int64, ParameterDirection.Input);
            Request.CommandText = "Process_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            if (DRow == null)
            {
                return null;
            }
            Process_MasterProperty Property = new Process_MasterProperty();
            Property.Process_Code = Val.ToInt(DRow["PROCESS_CODE"]);
            Property.Process_Name = Val.ToString(DRow["PROCESS_NAME"]);
            Property.Process_Group_Name = Val.ToString(DRow["PROCESS_GROUP_NAME"]);
            Property.MaxLoss = Val.Val(DRow["MAX_LOSS"]);
            Property.MaxRepeat = Val.ToInt(DRow["MAX_REPEAT"]);
            Property.Max_Ideal_Days = Val.ToInt(DRow["MAX_IDEAL_DAYS"]);
            Property.ProcessType = Val.ToString(DRow["PROCESS_TYPE"]);
            Property.Next_Process_Code = Val.ToString(DRow["NEXT_PROCESS_CODE"]);
            Property.Allow_change_Next_Process = Val.ToInt(DRow["ALLOW_CHANGE_NEXT_PROCESS"]);
            Property.Allow_Rough_Return = Val.ToInt(DRow["ALLOW_ROUGH_RETURN"]);
            Property.Return_With_Split = Val.ToInt(DRow["RETURN_WITH_SPLIT"]);

            Property.Issue_With_Barcode = Val.ToInt(DRow["ISSUE_WITH_BARCODE"]);
            Property.Issue_With_Shape = Val.ToInt(DRow["ISSUE_WITH_SHAPE"]);
            Property.Issue_With_Color = Val.ToInt(DRow["ISSUE_WITH_COLOR"]);
            Property.Issue_With_Clarity = Val.ToInt(DRow["ISSUE_WITH_CLARITY"]);
            Property.Issue_With_Sieve = Val.ToInt(DRow["ISSUE_WITH_SIEVE"]);
            Property.Issue_With_Loss = Val.ToInt(DRow["ISSUE_WITH_LOSS"]);
            Property.Issue_With_Lost = Val.ToInt(DRow["ISSUE_WITH_LOST"]);
            Property.Issue_With_MSize = Val.ToInt(DRow["ISSUE_WITH_MSIZE"]);
            Property.Issue_With_Machine = Val.ToInt(DRow["ISSUE_WITH_MACHINE"]);
            Property.Issue_With_CaratPlus = Val.ToInt(DRow["ISSUE_WITH_CARAT_PLUS"]);

            Property.Return_With_Barcode = Val.ToInt(DRow["RETURN_WITH_BARCODE"]);
            Property.Return_With_Shape = Val.ToInt(DRow["RETURN_WITH_SHAPE"]);
            Property.Return_With_Color = Val.ToInt(DRow["RETURN_WITH_COLOR"]);
            Property.Return_With_Clarity = Val.ToInt(DRow["RETURN_WITH_CLARITY"]);
            Property.Return_With_Sieve = Val.ToInt(DRow["RETURN_WITH_SIEVE"]);
            Property.Return_With_Loss = Val.ToInt(DRow["RETURN_WITH_LOSS"]);
            Property.Return_With_Lost = Val.ToInt(DRow["RETURN_WITH_LOST"]);
            Property.Return_With_MSize = Val.ToInt(DRow["RETURN_WITH_MSIZE"]);
            Property.Return_With_Machine = Val.ToInt(DRow["RETURN_WITH_MACHINE"]);
            Property.Return_With_CaratPlus = Val.ToInt(DRow["RETURN_WITH_CARAT_PLUS"]);
            Property.IS_Third_Party_Transfer = Val.ToInt(DRow["IS_THIRD_PARTY_TRANSFER"]);
            Property.Is_Untouch = Val.ToInt(DRow["IS_UNTOUCH"]);
            Property.Is_Disp_OnReturn = Val.ToInt(DRow["IS_DISP_ONRETURN"]);
            Property.Is_MFG_Type = Val.ToInt(DRow["IS_MFG_TYPE"]);
            Property.Janged_Prefix = Val.ToString(DRow["JANGED_PREFIX"]);

            Property.Is_Manufacturing = Val.ToInt(DRow["IS_MANUFACTURING"]);
            Property.IS_Open_Issue_To_OutSide = Val.ToInt(DRow["IS_OPEN_ISSUE_TO_OUTSIDE"]);
            Property.Is_Labour_Rate_Calculate = Val.ToInt(DRow["IS_LABOUR_RATE_CALCULATE"]);

            Property.IS_From_Party_Required = Val.ToInt(DRow["IS_FROM_PARTY_REQUIRED"]);
            Property.IS_To_Party_Required = Val.ToInt(DRow["IS_TO_PARTY_REQUIRED"]);
            Property.Is_Jw_Issue_Effect_Stock = Val.ToInt(DRow["IS_JW_ISSUE_EFFECT_STOCK"]);

            Property.Clv_To_OutSide_Header = Val.ToString(DRow["CLV_TO_OUTSIDE_HEADER"]);
            Property.MFG_To_HO_Header = Val.ToString(DRow["MFG_TO_HO_HEADER"]);
            Property.HO_Receive_Header = Val.ToString(DRow["HO_RECEIVE_HEADER"]);

            Property.Default_Stock_Flag = Val.ToInt(DRow["DEFAULT_STOCK_FLAG"]);
            Property.Active = Val.ToInt(DRow["ACTIVE"]);
            Property.Remark = Val.ToString(DRow["REMARK"]);
            return Property;
        }

        public string GetUnTouchProcess()
        {
            return Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Process_Master", "PROCESS_CODE", " And IS_UNTOUCH = 1");
        }

        #endregion


    }
}

