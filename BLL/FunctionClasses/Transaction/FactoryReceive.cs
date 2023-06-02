using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DLL;

using BLL.PropertyClasses.Transaction;
using System.Collections;

namespace BLL.FunctionClasses.Transaction
{
    public class FactoryReceive
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public DataTable DTab = new DataTable();


        #region Property Settings

        private DataSet _DS = new DataSet();

        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }

        public void ClearDeptRec()
        {
            if (DS.Tables["Mix_Dept_IssRet_Detail"] != null)
            {
                DS.Tables["Mix_Dept_IssRet_Detail"].Rows.Clear();
                DS.Tables["Mix_Dept_IssRet_Detail"].Columns.Clear();
            }
        }

        #endregion
        
      #region Operation

        public int UpdatePacket(Packet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@HEIGHT_", pClsProperty.Height, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@WIDTH_", pClsProperty.Width, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@DEPTH_", pClsProperty.Depth, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@MAX_DIA_", pClsProperty.Max_Dia, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@MIN_DIA_", pClsProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@PROC_EXP_PER_", pClsProperty.Proc_Exp_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@PROC_EXP_CARAT_", pClsProperty.Proc_Exp_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@FAC_WT_PER_", pClsProperty.Fac_WT_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FACTORY_I_WT_", pClsProperty.FACTORY_I_WT, DbType.Double, ParameterDirection.Input);

            Request.CommandText = "Polish_PacketUpdate";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public void GetPolishReceiveDetail(Mix_IssRet_MasterProperty pClsProperty)
        {
            ClearDeptRec();
            Request Request = new Request();
            Request.CommandText = "Polish_Import_GetData" + "N";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@FROM_DEPARTMENT_CODE", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_DEPARTMENT_CODE", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@RETURN_JANGAD_NO", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PARTY_CODE", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE", pClsProperty.To_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_SUB_PARTY_CODE", pClsProperty.From_Sub_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_SUB_PARTY_CODE", pClsProperty.To_Sub_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@STOCK_FLAG", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "Import", Request, "");
        }

      #endregion

        //  //public void ClearDeptRec()
      //  //{
      //  //    if (DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail] != null)
      //  //    {
      //  //        DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail].Rows.Clear();
      //  //        DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail].Columns.Clear();
      //  //    }
      //  //}

      //  // Receive To Mfg(Factory Receive)

      //  public void GetMfgReceiveDetail(Mix_IssRet_MasterProperty pClsProperty)
      //  {
      //      if (DS.Tables[BLL.TPV.Table.Import] != null)
      //      {
      //          DS.Tables[BLL.TPV.Table.Import].Rows.Clear();
      //      }

      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Import_GetData;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_JANGAD_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Multi, DbType.String, ParameterDirection.Input); 
            
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);

      //      Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Import, Request, "");

      //  }

      //  public void GetPolishReceiveDetail(Mix_IssRet_MasterProperty pClsProperty)
      //  {
      //      ClearDeptRec();

      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Polish_Import_GetData + "N";
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RETURN_JANGAD_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
      //      Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Import, Request, "");

      //  }

      //  public int SaveFactoryMaster(Factory_Master_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Master_Save;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
            
      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("MAINBARCODE_", pClsProperty.MainBarcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            
      //      Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input); 
      //      Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input); 

      //      Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("EXP_PER_", pClsProperty.Exp_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("EXP_BY_", pClsProperty.Exp_By, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("DM_PER_", pClsProperty.DM_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("DM_BY_", pClsProperty.DM_By, DbType.String, ParameterDirection.Input);
            
      //      Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("ISSUE_DATE_", pClsProperty.Issue_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_TIME_", pClsProperty.Issue_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_EMPLOYEE_CODE_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_COMPUTER_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.Mfg_Clarity_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MIN_DIA_", pClsProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("MAX_DIA_", pClsProperty.Max_Dia, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("HEIGHT_", pClsProperty.Height, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("WIDTH_", pClsProperty.Width, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("DEPTH_", pClsProperty.Depth, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RETURN_JANGED_DATE_", pClsProperty.Return_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("RETURN_EMPLOYEE_CODE_", 0, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RETURN_COMPUTER_IP_", 0, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CONSUME_PCS_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CONSUME_CARAT_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("READY_PCS_", pClsProperty.Ready_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("READY_CARAT_", pClsProperty.Ready_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("RR_PCS_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("SAW_PCS_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SAW_CARAT_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("LOSS_PCS_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOSS_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("CANCEL_PCS_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CANCEL_CARAT_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_TYPE_", pClsProperty.Kapan_Type, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_DATE_", pClsProperty.Kapan_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_TIME_", pClsProperty.Kapan_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_FLAG_", pClsProperty.Half_Process_Flag, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_PCS_", pClsProperty.Half_Process_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_CARAT_", pClsProperty.Half_Process_Carat, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LAST_PROCESS_CODE_", pClsProperty.Last_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LAST_STOKIEST_CODE_", pClsProperty.Last_Stockiest_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("DM_PLAN_ID_", pClsProperty.DM_Plan_Id, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MFG_TYPE_", pClsProperty.Mfg_Type, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("INS_F_EXP_PER_", pClsProperty.Incepection_F_I_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("INS_HO_EXP_PER_", pClsProperty.Incepection_HO_I_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("INS_HO_CLARITY_CODE_", pClsProperty.Incepection_HO_Clarity, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("INS_HO_COLOR_CODE_", pClsProperty.Incepection_HO_Color, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("INS_JANGED_NO_", pClsProperty.Incepection_Janged_No, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("INS_JANGED_DATE_", pClsProperty.Incepection_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("PACKET_GRADE_CODE_", pClsProperty.Packet_Grade_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_JANGED_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("IS_EXTRA_", pClsProperty.IS_Extra, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("RATE_", pClsProperty.Rate, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("AMOUNT_", pClsProperty.Amount, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

      //      ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request,pEnum);

      //      pClsProperty.SrNo = Val.ToInt(AL[0]);
      //      AL = null;
      //      return Val.ToInt(pClsProperty.SrNo);

      //      //AL = null;

      //     //DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
      //     //if (DRow == null)
      //     //{
      //     //    return 0;
      //     //}

      //     //return Val.ToInt(DRow["SRNO"]); 
      //  }

      //  public int SaveFactoryMasterWithConn(Factory_Master_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Master_Save;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("MAINBARCODE_", pClsProperty.MainBarcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);

      //      Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("EXP_PER_", pClsProperty.Exp_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("EXP_BY_", pClsProperty.Exp_By, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("DM_PER_", pClsProperty.DM_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("DM_BY_", pClsProperty.DM_By, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("BALANCE_PCS_", pClsProperty.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BALANCE_CARAT_", pClsProperty.Balance_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("ISSUE_DATE_", pClsProperty.Issue_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_TIME_", pClsProperty.Issue_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_EMPLOYEE_CODE_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_COMPUTER_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.Mfg_Clarity_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MIN_DIA_", pClsProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("MAX_DIA_", pClsProperty.Max_Dia, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("HEIGHT_", pClsProperty.Height, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("WIDTH_", pClsProperty.Width, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("DEPTH_", pClsProperty.Depth, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RETURN_JANGED_DATE_", pClsProperty.Return_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("RETURN_EMPLOYEE_CODE_", 0, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RETURN_COMPUTER_IP_", 0, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CONSUME_PCS_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CONSUME_CARAT_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("READY_PCS_", pClsProperty.Ready_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("READY_CARAT_", pClsProperty.Ready_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("RR_PCS_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("SAW_PCS_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SAW_CARAT_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("LOSS_PCS_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOSS_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("CANCEL_PCS_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CANCEL_CARAT_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_TYPE_", pClsProperty.Kapan_Type, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_DATE_", pClsProperty.Kapan_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_TIME_", pClsProperty.Kapan_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_FLAG_", pClsProperty.Half_Process_Flag, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_PCS_", pClsProperty.Half_Process_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_CARAT_", pClsProperty.Half_Process_Carat, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LAST_PROCESS_CODE_", pClsProperty.Last_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LAST_STOKIEST_CODE_", pClsProperty.Last_Stockiest_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("DM_PLAN_ID_", pClsProperty.DM_Plan_Id, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MFG_TYPE_", pClsProperty.Mfg_Type, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("INS_F_EXP_PER_", pClsProperty.Incepection_F_I_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("INS_HO_EXP_PER_", pClsProperty.Incepection_HO_I_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("INS_HO_CLARITY_CODE_", pClsProperty.Incepection_HO_Clarity, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("INS_HO_COLOR_CODE_", pClsProperty.Incepection_HO_Color, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("INS_JANGED_NO_", pClsProperty.Incepection_Janged_No, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("INS_JANGED_DATE_", pClsProperty.Incepection_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("PACKET_GRADE_CODE_", pClsProperty.Packet_Grade_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_JANGED_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("IS_EXTRA_", pClsProperty.IS_Extra, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("RATE_", pClsProperty.Rate, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("AMOUNT_", pClsProperty.Amount, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

      //      ArrayList AL = Ope.ExecuteNonQueryWithRetunValuesWithConn(DLL.GlobalDec.ConnectionA, Request, pEnum);

      //      if (AL == null || AL.Count == 0)
      //      {
      //          pClsProperty.SrNo = 0;
      //      }
      //      else
      //      {
      //          pClsProperty.SrNo = Val.ToInt(AL[0]);
      //      }

            
      //      AL = null;
      //      return Val.ToInt(pClsProperty.SrNo);

      //  }

      //  public int DeleteFactoryMasterDetail(Factory_Master_Property pClsProperty)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Import_Delete;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_JANGED_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.String, ParameterDirection.Input);
           
      //      return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);           
      //  }

      //  public Factory_Detail_Property SaveFactoryDetail(Factory_Detail_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Detail_Save;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
            
      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("MAINBARCODE_", pClsProperty.MainBarcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            
      //      Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("FROM_EMPLOYEE_CODE_", pClsProperty.From_Employee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_EMPLOYEE_CODE_", pClsProperty.To_Employee_Code, DbType.Int32, ParameterDirection.Input);
            
      //      Request.AddParams("FROM_DESIGNATION_CODE_", pClsProperty.From_Designation_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DESIGNATION_CODE_", pClsProperty.To_Designation_Code, DbType.Int32, ParameterDirection.Input);

      //      /*ADD BY HARESH ON 28-JAN-2015*/

      //      Request.AddParams("FROM_COMPANY_CODE_", pClsProperty.From_Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_COMPANY_CODE_", pClsProperty.To_Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_BRANCH_CODE_", pClsProperty.From_Branch_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_BRANCH_CODE_", pClsProperty.To_Branch_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.Int32, ParameterDirection.Input);

      //      /*---*/

      //      Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_DATE_", pClsProperty.Issue_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_TIME_", pClsProperty.Issue_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("READY_PCS_", pClsProperty.Ready_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("READY_CARAT_", pClsProperty.Ready_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_DATE_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_TIME_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_EMPLOYEE_CODE_", 0, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_COMPUTER_IP_", 0, DbType.Int32, ParameterDirection.Input);
           
      //      Request.AddParams("REJECTION_PCS_", pClsProperty.Rejection_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("REJECTION_CARAT_", pClsProperty.Rejection_Carat, DbType.Double, ParameterDirection.Input);
            
      //      Request.AddParams("RR_PCS_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
            
      //      Request.AddParams("LOSS_PCS_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("CANCEL_PCS_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CANCEL_CARAT_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
           
      //      Request.AddParams("LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
            
      //      Request.AddParams("PREV_SRNO_", pClsProperty.Prev_SrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("PREV_CARAT_", pClsProperty.Prev_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("PREV_RRPCS_", pClsProperty.Prev_RRPcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("PREV_RRCARAT_", pClsProperty.Prev_RRCarat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("MFG_TYPE_", pClsProperty.Mfg_Type, DbType.String, ParameterDirection.Input);
            
      //      Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.Mfg_Clarity_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MIN_DIA_", pClsProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("MAX_DIA_", pClsProperty.Max_Dia, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("DEPTH_", pClsProperty.Depth, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("EXP_PER_", pClsProperty.Exp_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("EXP_BY_", pClsProperty.Exp_By, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("DM_PER_", pClsProperty.DM_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("DM_BY_", pClsProperty.DM_By, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("HEIGHT_", pClsProperty.Height, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("WIDTH_", pClsProperty.Width, DbType.Double, ParameterDirection.Input);
            
      //      Request.AddParams("CONSUME_PCS_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CONSUME_CARAT_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("PROCESS_SEQUENCE_CODE_", pClsProperty.Process_Sequence_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MSRNO_", pClsProperty.MSrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("POST_FLAG_", pClsProperty.Post_Flag, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SAW_PCS_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SAW_CARAT_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("COMP_TYPE_", pClsProperty.Comp_Type, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("IS_EXTRA_", pClsProperty.IS_Extra, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("OUT_SLIP_NO_", 0, DbType.Int32, ParameterDirection.Output);
      //      Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

      //      ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, pEnum);

      //      pClsProperty.SlipNo = Val.ToInt(AL[0]);
      //      pClsProperty.SrNo = Val.ToInt(AL[1]);
            
      //      AL = null;
      //      return pClsProperty;           
      //  }

      //  public Factory_Detail_Property SaveFactoryDetailWithConn(Factory_Detail_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Detail_Save;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("MAINBARCODE_", pClsProperty.MainBarcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("FROM_EMPLOYEE_CODE_", pClsProperty.From_Employee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_EMPLOYEE_CODE_", pClsProperty.To_Employee_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("FROM_DESIGNATION_CODE_", pClsProperty.From_Designation_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DESIGNATION_CODE_", pClsProperty.To_Designation_Code, DbType.Int32, ParameterDirection.Input);

      //      /*ADD BY HARESH ON 28-JAN-2015*/

      //      Request.AddParams("FROM_COMPANY_CODE_", pClsProperty.From_Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_COMPANY_CODE_", pClsProperty.To_Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_BRANCH_CODE_", pClsProperty.From_Branch_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_BRANCH_CODE_", pClsProperty.To_Branch_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.Int32, ParameterDirection.Input);

      //      /*---*/
      //      Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_DATE_", pClsProperty.Issue_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_TIME_", pClsProperty.Issue_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("READY_PCS_", pClsProperty.Ready_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("READY_CARAT_", pClsProperty.Ready_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_DATE_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_TIME_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_EMPLOYEE_CODE_", 0, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_COMPUTER_IP_", 0, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("REJECTION_PCS_", pClsProperty.Rejection_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("REJECTION_CARAT_", pClsProperty.Rejection_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("RR_PCS_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("LOSS_PCS_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("CANCEL_PCS_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CANCEL_CARAT_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("PREV_SRNO_", pClsProperty.Prev_SrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("PREV_CARAT_", pClsProperty.Prev_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("PREV_RRPCS_", pClsProperty.Prev_RRPcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("PREV_RRCARAT_", pClsProperty.Prev_RRCarat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("MFG_TYPE_", pClsProperty.Mfg_Type, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.Mfg_Clarity_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MIN_DIA_", pClsProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("MAX_DIA_", pClsProperty.Max_Dia, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("DEPTH_", pClsProperty.Depth, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("EXP_PER_", pClsProperty.Exp_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("EXP_BY_", pClsProperty.Exp_By, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("DM_PER_", pClsProperty.DM_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("DM_BY_", pClsProperty.DM_By, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("HEIGHT_", pClsProperty.Height, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("WIDTH_", pClsProperty.Width, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("CONSUME_PCS_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CONSUME_CARAT_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("PROCESS_SEQUENCE_CODE_", pClsProperty.Process_Sequence_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MSRNO_", pClsProperty.MSrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("POST_FLAG_", pClsProperty.Post_Flag, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SAW_PCS_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SAW_CARAT_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("COMP_TYPE_", pClsProperty.Comp_Type, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("IS_EXTRA_", pClsProperty.IS_Extra, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("OUT_SLIP_NO_", 0, DbType.Int32, ParameterDirection.Output);
      //      Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

      //      ArrayList AL = Ope.ExecuteNonQueryWithRetunValuesWithConn(DLL.GlobalDec.ConnectionA, Request, pEnum);

      //      if (AL == null || AL.Count == 0)
      //      {
      //          pClsProperty.SlipNo = 0;
      //          pClsProperty.SrNo = 0;
      //      }
      //      else
      //      {
      //          pClsProperty.SlipNo = Val.ToInt(AL[0]);
      //          pClsProperty.SrNo = Val.ToInt(AL[1]);
      //      }
            

      //      AL = null;
      //      return pClsProperty;
      //  }

      //  // ADD ; NARENDRA ; 26-MAY-2015
      //  public Factory_Detail_Property Factory_Import_Save(Factory_Detail_Property pClsProperty, Factory_Master_Property pClsPropertyMaster, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = "FACTORY_IMPORT_SAVE";// BLL.TPV.SProc.Factory_Detail_Save;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      // START OF FACTORY DETAIL SAVE PARAMETER 

      //      Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("MAINBARCODE_", pClsProperty.MainBarcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("FROM_PARTY_CODE_", pClsPropertyMaster.From_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_SUB_PARTY_CODE_", pClsPropertyMaster.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PARTY_CODE_", pClsPropertyMaster.To_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_SUB_PARTY_CODE_", pClsPropertyMaster.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("FROM_PROCESS_CODE_", pClsPropertyMaster.From_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsPropertyMaster.To_Process_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("FROM_EMPLOYEE_CODE_", pClsProperty.From_Employee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_EMPLOYEE_CODE_", pClsProperty.To_Employee_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("FROM_DESIGNATION_CODE_", pClsProperty.From_Designation_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DESIGNATION_CODE_", pClsProperty.To_Designation_Code, DbType.Int32, ParameterDirection.Input);

      //      /*ADD BY HARESH ON 28-JAN-2015*/

      //      Request.AddParams("FROM_COMPANY_CODE_", pClsProperty.From_Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_COMPANY_CODE_", pClsProperty.To_Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_BRANCH_CODE_", pClsProperty.From_Branch_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_BRANCH_CODE_", pClsProperty.To_Branch_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.Int32, ParameterDirection.Input);

      //      /*---*/
      //      Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_DATE_", pClsProperty.Issue_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_TIME_", pClsProperty.Issue_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("READY_PCS_", pClsProperty.Ready_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("READY_CARAT_", pClsProperty.Ready_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_DATE_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_TIME_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_EMPLOYEE_CODE_", 0, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_COMPUTER_IP_", 0, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("REJECTION_PCS_", pClsProperty.Rejection_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("REJECTION_CARAT_", pClsProperty.Rejection_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("RR_PCS_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("LOSS_PCS_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("CANCEL_PCS_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CANCEL_CARAT_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("PREV_SRNO_", pClsProperty.Prev_SrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("PREV_CARAT_", pClsProperty.Prev_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("PREV_RRPCS_", pClsProperty.Prev_RRPcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("PREV_RRCARAT_", pClsProperty.Prev_RRCarat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("MFG_TYPE_", pClsProperty.Mfg_Type, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.Mfg_Clarity_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MIN_DIA_", pClsProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("MAX_DIA_", pClsProperty.Max_Dia, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("DEPTH_", pClsProperty.Depth, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("EXP_PER_", pClsProperty.Exp_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("EXP_BY_", pClsProperty.Exp_By, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("DM_PER_", pClsProperty.DM_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("DM_BY_", pClsProperty.DM_By, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("HEIGHT_", pClsProperty.Height, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("WIDTH_", pClsProperty.Width, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("CONSUME_PCS_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CONSUME_CARAT_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("PROCESS_SEQUENCE_CODE_", pClsProperty.Process_Sequence_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MSRNO_", pClsProperty.MSrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("POST_FLAG_", pClsProperty.Post_Flag, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SAW_PCS_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SAW_CARAT_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("COMP_TYPE_", pClsProperty.Comp_Type, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("IS_EXTRA_", pClsProperty.IS_Extra, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

      //      //Request.AddParams("OUT_SLIP_NO_", 0, DbType.Int32, ParameterDirection.Output);
            
      //      // END OF FACTORY DETAIL SAVE PARAMETER

      //      // START OF FACTORY MASTER SAVE PARAMETER

      //      Request.AddParams("JANGED_NO_", pClsPropertyMaster.Janged_No, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("JANGED_DATE_", pClsPropertyMaster.Janged_Date, DbType.Date, ParameterDirection.Input);

      //      Request.AddParams("FROM_DEPARTMENT_CODE_", pClsPropertyMaster.From_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DEPARTMENT_CODE_", pClsPropertyMaster.To_Department_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("BALANCE_PCS_", pClsPropertyMaster.Balance_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BALANCE_CARAT_", pClsPropertyMaster.Balance_Carat, DbType.Double, ParameterDirection.Input);

      //      Request.AddParams("RETURN_JANGED_NO_", pClsPropertyMaster.Return_Janged_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RETURN_JANGED_DATE_", pClsPropertyMaster.Return_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("RETURN_EMPLOYEE_CODE_", 0, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RETURN_COMPUTER_IP_", 0, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("KAPAN_TYPE_", pClsPropertyMaster.Kapan_Type, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_DATE_", pClsPropertyMaster.Kapan_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_TIME_", pClsPropertyMaster.Kapan_Time, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("HALF_PROCESS_FLAG_", pClsPropertyMaster.Half_Process_Flag, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_PCS_", pClsPropertyMaster.Half_Process_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_CARAT_", pClsPropertyMaster.Half_Process_Carat, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("LAST_PROCESS_CODE_", pClsPropertyMaster.Last_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LAST_STOKIEST_CODE_", pClsPropertyMaster.Last_Stockiest_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("DM_PLAN_ID_", pClsPropertyMaster.DM_Plan_Id, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("INS_JANGED_NO_", pClsPropertyMaster.Incepection_Janged_No, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("INS_JANGED_DATE_", pClsPropertyMaster.Incepection_Janged_Date, DbType.Date, ParameterDirection.Input);

      //      Request.AddParams("PACKET_GRADE_CODE_", pClsPropertyMaster.Packet_Grade_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("ISSUE_JANGED_NO_", pClsPropertyMaster.Issue_Janged_No, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("RATE_", pClsPropertyMaster.Rate, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("AMOUNT_", pClsPropertyMaster.Amount, DbType.Double, ParameterDirection.Input);

      //      // END OF FACTORY MASTERP PARAMETER

      //      Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

      //      ArrayList AL = Ope.ExecuteNonQueryWithRetunValuesWithConn(DLL.GlobalDec.ConnectionA, Request, pEnum);

      //      if (AL == null || AL.Count == 0)
      //      {
      //          pClsProperty.SlipNo = 0;
      //          pClsProperty.SrNo = 0;
      //      }
      //      else
      //      {
      //          //pClsProperty.SlipNo = Val.ToInt(AL[0]);
      //          pClsProperty.SrNo = Val.ToInt(AL[0]);
      //      }


      //      AL = null;
      //      return pClsProperty;
      //  }
      //  // END ; NARENDRA ; 26-MAY-2015
      //  public int FactoryMasterDeleteWithConn(Factory_Master_Property pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Master_Delete;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);
            
      //      ArrayList AL = Ope.ExecuteNonQueryWithRetunValuesWithConn(DLL.GlobalDec.ConnectionA, Request, pEnum);

      //      if (AL == null || AL.Count == 0)
      //      {
      //          AL = null;
      //          return -1;
      //      }
      //      else
      //      {
      //          AL = null;
      //          return 1;
      //      }

      //  }


      //  public int UpdateKapanType(Factory_Master_Property pClsProperty)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Barcode_Update_Kapan;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_DATE_", pClsProperty.Kapan_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_TIME_", pClsProperty.Kapan_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("FLAG_", pClsProperty.Flag, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("CARAT_PLUS_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("RR_PCS_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);            
      //  }    
    
      //  #region Factory 
        
      //  public DataTable SelDistinctMfgType(Factory_Master_Property pClsProperty)
      //  {
      //      DataTable DTab = new DataTable(BLL.TPV.Table.Temp);
      //      Request Request = new Request();

      //      string StrSql = "SELECT PROCESS_NAME ,PROCESS_SHORTNAME FROM PROCESS_MASTER WHERE IS_MFG_TYPE = 1";
      //      Request.CommandText = StrSql;
      //      Request.CommandType = CommandType.Text;
      //      Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
      //      return DTab;
      //  }

      //  public DataTable SelIssueJangedDetail(Factory_Master_Property pClsProperty)
      //  {
      //      DataTable DTab = new DataTable(BLL.TPV.Table.Temp);
      //      Request Request = new Request();

      //      string StrSql = "Select Distinct(Issue_Janged_No),Issue_Date From " + TPV.Table.VIW_CLV_TO_OUTSIDE_SUM + " ";
      //      StrSql += " Where 1=1";

      //      if (Val.ISDate(pClsProperty.Issue_Date) == true )
      //      {
      //          StrSql += " And (Issue_Date Is Null Or Issue_Date Between '" + pClsProperty.Issue_Date + "' And '" + pClsProperty.Issue_Date + "')";    
      //      }
      //      StrSql += " Order By Issue_Date Desc";

      //      Request.CommandText = StrSql;
      //      Request.CommandType = CommandType.Text;
      //      Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
      //      return DTab;
      //  }

      //  public DataTable SelReceiveJangedDetail(Factory_Master_Property pClsProperty)
      //  {
      //      DataTable DTab = new DataTable(BLL.TPV.Table.Temp);
      //      Request Request = new Request();

      //      string StrSql = "Select Distinct(Return_Janged_No),Return_Janged_Date From " + TPV.Table.VIW_MFG_TO_HO_SUM + " ";
      //      StrSql += " Where 1=1";
            
      //      if (Val.ISDate(pClsProperty.Return_Janged_Date) == true)
      //      {
      //          StrSql += " And (Return_Janged_Date Is Null Or Return_Janged_Date Between '" + pClsProperty.Return_Janged_Date + "' And '" + pClsProperty.Return_Janged_Date + "')";
      //      }
      //      StrSql += " Order By Return_Janged_Date Desc";

      //      Request.CommandText = StrSql;
      //      Request.CommandType = CommandType.Text;
      //      Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
      //      return DTab;
      //  }

      //  #endregion

      //  #endregion

      //  #region Janged Printing

      //  public DataTable GetReceiveJabgedForPrint(Factory_Master_Property pClsProperty, string pStrType)
      //  {
      //      DataTable DTab = new DataTable(BLL.TPV.Table.Temp);
      //      Request Request = new Request();
      //      Request.CommandType = CommandType.StoredProcedure;
      //      Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("FROM_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("TO_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

      //      if (pStrType == "S")
      //      {
      //          Request.CommandText = BLL.TPV.SProc.Rp_Mix_Mfg_To_HO_Sum;
      //      }
      //      else if (pStrType == "D")
      //      {
      //          Request.CommandText = BLL.TPV.SProc.Rp_Mix_Mfg_To_HO_Det;
      //      }
      //      Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
      //      return DTab;
      //  }

      ///*  public void GetJangedView(Factory_Master_Property pClsProperty)
      //  {
      //      if (DS.Tables[BLL.TPV.Table.Factory_ViewMaster] != null)
      //      {
      //          DS.Tables[BLL.TPV.Table.Factory_ViewMaster].Rows.Clear();
      //      }
      //      if (DS.Tables[BLL.TPV.Table.Factory_ViewMaster + "1"] != null)
      //      {
      //          DS.Tables[BLL.TPV.Table.Factory_ViewMaster + "1"].Rows.Clear();
      //      }

      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_ReturnJangedView;
      //      Request.CommandType = CommandType.StoredProcedure;
      //      Request.REF_CUR_OUT = 2;

      //      Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("FROM_JANGED_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("TO_JANGED_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("JANGED_STATUS_", pClsProperty.Janged_Status, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);

      //      //Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //      //Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

      //      Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Factory_ViewMaster, Request, "");

      //      DataColumn[] MasterColumns = null;
      //      DataColumn[] DetailColumns = null;

      //      MasterColumns = new DataColumn[] {
      //      DS.Tables[BLL.TPV.Table.Factory_ViewMaster].Columns["JANGED_DATE"],
      //      DS.Tables[BLL.TPV.Table.Factory_ViewMaster].Columns["BILL_OF_ENTRY_NO"]};

      //      //Create the datacolumn array 
      //      DetailColumns = new DataColumn[] {
            
      //      DS.Tables[BLL.TPV.Table.Factory_ViewMaster+"1"].Columns["JANGED_DATE"],
      //      DS.Tables[BLL.TPV.Table.Factory_ViewMaster+"1"].Columns["BILL_OF_ENTRY_NO"]};

      //      DataRelation r = new DataRelation("Janged Detail", MasterColumns, DetailColumns, false);

      //      foreach (DataRelation Relation in DS.Relations)
      //      {
      //          if (Relation.RelationName.ToUpper() == r.RelationName.ToUpper())
      //          {
      //              DS.Relations.Remove(Relation);
      //              DS.AcceptChanges();
      //              break;
      //          }
      //      }
      //      DS.Relations.Add(r);
      //  }*/

      //  public void GetJangedViewSummry(Factory_Master_Property pClsProperty)
      //  {
      //      if (DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master] != null)
      //      {
      //          DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master].Rows.Clear();
      //      }

      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_ReturnJanged_Summary;
      //      Request.CommandType = CommandType.StoredProcedure;
      //      Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("FROM_JANGED_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("TO_JANGED_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("JANGED_STATUS_", pClsProperty.Janged_Status, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("MFG_TYPE_", pClsProperty.Mfg_Type, DbType.String, ParameterDirection.Input);

      //      Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

      //      Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_IssRet_View_Master, Request, "");
      //  }

      //  public void GetJangedViewDetail(string pStrJangedNo, string pStrJangedDate)
      //  {
      //      if (DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Detail] != null)
      //      {
      //          DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Detail].Rows.Clear();
      //      }

      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_ReturnJanged_Detail;
      //      Request.CommandType = CommandType.StoredProcedure;
      //      Request.AddParams("JANGED_DATE_", pStrJangedDate, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("JANGED_NO_", pStrJangedNo, DbType.String, ParameterDirection.Input);
            
      //      //Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //      //Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

      //      Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_IssRet_View_Detail, Request, "");
      //  }

      //  public DataTable GetJangedNo(Factory_Master_Property pClsProperty)
      //  {

      //      DataTable DTabJanged = new DataTable();

      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_ReturnJangedViewNo;
      //      Request.CommandType = CommandType.StoredProcedure;
      //      //Request.REF_CUR_OUT = 2;

      //      Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("FROM_JANGED_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("TO_JANGED_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("JANGED_STATUS_", pClsProperty.Janged_Status, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      ;
      //      Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabJanged, Request, "");
      //      return DTabJanged;
      //  }

      //  #endregion

      //  #region Mix_Split Log Transaction

      //  public int FindNewLogTrnID(string pStrMainbarCode)
      //  {
      //      return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, BLL.TPV.Table.FAC_Barcode_Split_Master_Log, "MAX(TRN_ID)", " AND MAINBARCODE='" + pStrMainbarCode + "'");
      //  }

      //  public int SaveFactoryDetailLogSave(Factory_Detail_Property pClsProperty)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Detail_Log_Save;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("TRN_ID_", pClsProperty.Trn_ID, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MAINBARCODE_", pClsProperty.MainBarcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            
      //      return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

      //  }

      //  public int SaveFactoryMasterLogSave(Factory_Master_Property pClsProperty)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Master_Log_Save;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("TRN_ID_", pClsProperty.Trn_ID, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MAINBARCODE_", pClsProperty.MainBarcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_TYPE_", pClsProperty.Kapan_Type, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_DATE_", pClsProperty.Kapan_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("KAPAN_TIME_", pClsProperty.Kapan_Time, DbType.String, ParameterDirection.Input);            
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);           
      //  }

      //  #endregion

      //  #region Update Barcode Value

      //  public void UpdateBarcodeProcessPcsAndCarat(Factory_Detail_Property pClsProperty)
      //  {
      //      Request Request = new Request();
      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

      //      // ADD ; NARENDRA : 13-MAR-2015
      //      Request.AddParams("FROM_COMPANY_CODE_", pClsProperty.From_Company_Code , DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_COMPANY_CODE_", pClsProperty.To_Company_Code   , DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_BRANCH_CODE_", pClsProperty.From_Branch_Code  , DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_BRANCH_CODE_",  pClsProperty.To_Branch_Code   , DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_LOCATION_CODE_", pClsProperty.To_Location_Code  , DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_EMPLOYEE_CODE_", pClsProperty.From_Employee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_EMPLOYEE_CODE_", pClsProperty.To_Employee_Code  , DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code , DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code   , DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name        , DbType.String, ParameterDirection.Input);
      //      Request.AddParams("FROM_ISSUE_DATE_", pClsProperty.From_Issue_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("TO_ISSUE_DATE_", pClsProperty.To_Issue_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("FROM_RECEIVE_DATE_", pClsProperty.From_Receive_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("TO_RECEIVE_DATE_", pClsProperty.To_Receive_Date, DbType.Date, ParameterDirection.Input);
 
      //      Request.CommandText = BLL.TPV.SProc.Factory_Barcode_GetData;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Factory_Detail, Request, "");
      //  }

      //  public DataRow GetOrgBarcodeDetail(Factory_Master_Property pClsProperty)
      //  {
      //      Request Request = new Request();
      //      Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.CommandText = BLL.TPV.SProc.Factory_Barcode_GetData;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

      //  }

      //  public int UpdateBarcodeValue(Factory_Detail_Property DetailProperty)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Barcode_Update;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("SRNO_", DetailProperty.SrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("MSRNO_", DetailProperty.MSrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BARCODE_", DetailProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", DetailProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      //Request.AddParams("ORG_PCS_", MastProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //      //Request.AddParams("ORG_CARAT_", MastProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_PCS_", DetailProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_CARAT_", DetailProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("CONSUME_PCS_", DetailProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CONSUME_CARAT_", DetailProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("READY_PCS_", DetailProperty.Ready_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("READY_CARAT_", DetailProperty.Ready_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("RR_PCS_", DetailProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RR_CARAT_", DetailProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("LOST_PCS_", DetailProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOST_CARAT_", DetailProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("SAW_PCS_", DetailProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SAW_CARAT_", DetailProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("PREV_CARAT_", DetailProperty.Prev_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("LOSS_CARAT_", DetailProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("CANCEL_PCS_", DetailProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("CANCEL_CARAT_", DetailProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);

      //      /* change By Haresh On 06-09-2013 For Additional Update Parameter*/

      //      Request.AddParams("FROM_EMPLOYEE_CODE_", DetailProperty.From_Employee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_EMPLOYEE_CODE_", DetailProperty.To_Employee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_PROCESS_CODE_", DetailProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PROCESS_CODE_", DetailProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_DATE_", DetailProperty.Issue_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_TIME_", DetailProperty.Issue_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_EMPLOYEE_CODE_", DetailProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_COMPUTER_IP_", DetailProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_DATE_", DetailProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_TIME_", DetailProperty.Receive_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_EMPLOYEE_CODE_", DetailProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("RECEIVE_COMPUTER_IP_", DetailProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("MANAGER_OFLAG_", DetailProperty.Manager_OFlag, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("WORKER_OFLAG_", DetailProperty.Worker_OFlag, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("POST_FLAG_", DetailProperty.Post_Flag, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("COMP_TYPE_", DetailProperty.Comp_Type, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("COMP_PROCESS_CODE_", DetailProperty.Comp_Process_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_PARTY_CODE_", DetailProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_PARTY_CODE_", DetailProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_SUB_PARTY_CODE_", DetailProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_SUB_PARTY_CODE_", DetailProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("INS_ISSUE_JANGED_NO_", DetailProperty.INS_Issue_Janged_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("INS_RETURN_JANGED_NO_", DetailProperty.INS_Return_Janged_No, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("REASON_CODE_", DetailProperty.Reason_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("POLISH_RECEIPT_DATE_", DetailProperty.Polish_Receipt_Date, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("POLISH_RECEIPT_TIME_", DetailProperty.Polish_Receipt_Time, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("INS_F_EXP_PER_", DetailProperty.Ins_F_Exp_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("INS_HO_EXP_PER_", DetailProperty.Ins_HO_Exp_Per, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("INS_HO_CLARITY_CODE_", DetailProperty.Ins_HO_Clarity_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("INS_HO_COLOR_CODE_", DetailProperty.Ins_HO_Color_Code, DbType.Int32, ParameterDirection.Input);

      //      // ADD ; NARENDRA ; 13-MAR-2015
      //      Request.AddParams("FROM_COMPANY_CODE_", DetailProperty.From_Company_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_COMPANY_CODE_", DetailProperty.To_Company_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("FROM_BRANCH_CODE_", DetailProperty.From_Branch_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_BRANCH_CODE_", DetailProperty.To_Branch_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("FROM_LOCATION_CODE_", DetailProperty.From_Location_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("TO_LOCATION_CODE_", DetailProperty.To_Location_Code, DbType.Int32, ParameterDirection.Input);

      //      Request.AddParams("PROCESS_SEQUENCE_CODE_", DetailProperty.Process_Sequence_Code, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("PREV_SRNO_", DetailProperty.Prev_SrNo, DbType.Int32, ParameterDirection.Input);
      //      /**/

      //      return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
      //  }

      //  public int UpdateBarcodePcsDetail(Factory_Master_Property MastProperty)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Barcode_Master_Update;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("BARCODE_", MastProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ISSUE_PCS_", MastProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FAC_WT_PER_", MastProperty.Fac_WT_Per, DbType.Double, ParameterDirection.Input);

      //      return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
      //  }

      //  #endregion

      //  #region Half Process

      //  public string HalfProcessValSave(string pStrBarcode)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_HalfProcess_ValSave;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("BARCODE_", pStrBarcode, DbType.String, ParameterDirection.Input);
            
      //      return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
      //  }

      //  public int HalfProcessBarcodeSave(Factory_Master_Property MastProperty)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_HalfProcess_Save;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("BARCODE_", MastProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_PCS_", MastProperty.Half_Process_Pcs, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_CARAT_", MastProperty.Half_Process_Carat, DbType.Double, ParameterDirection.Input);
      //      Request.AddParams("HALF_PROCESS_DATE_", MastProperty.Half_Process_Date, DbType.Date, ParameterDirection.Input);

      //      return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
      //  }

      //  public void HalfProcessGetData(string pStrFromDate = null,string pStrToDate = null)
      //  {
      //      DataTable DTab = new DataTable();
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_HalfProcess_GetData;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("IS_FLAG_CHECK_", 1, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

      //      Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS,BLL.TPV.Table.Factory_Master, Request);            
      //  }

      //  public DataRow HalfProcesssSingleBarcodeGetDetail(string pStrBarcode)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_HalfProcess_GetData;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("BARCODE_", pStrBarcode, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

      //      return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            
      //  }

      //  #endregion

      //  #region Broken Pcs Detail

      //  public DataTable GetDataForSearch(Factory_Detail_Property pClsProperty) // Khushbu 09/01/2014
      //  {
      //      DataTable DTab = new DataTable();
      //      Request Request = new Request();
            
      //      Request.AddParams("FROM_DATE_", pClsProperty.From_Issue_Date, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("TO_DATE_", pClsProperty.To_Issue_Date, DbType.String, ParameterDirection.Input);

      //      Request.CommandText = BLL.TPV.SProc.Factory_Broken_Pcs_Getdata;
      //      Request.CommandType = CommandType.StoredProcedure;
      //      if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
      //      {
      //          Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
      //      }
      //      else if (GlobalDec.gEmployeeProperty.Allow_Developer == 1)
      //      {
      //          Ope.GetDataTable(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, DTab, Request, "");
      //      }
      //      return DTab;
      //  }

      //  public int FindNewID()
      //  {
      //      return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, BLL.TPV.Table.Factory_Broken_Pcs_Detail, "MAX(SRNO)", "");
      //  }


      //  public int SaveBrokenPcs(Factory_Detail_Property pClsProperty) // Khushbu 09/01/2014 
      //  {
      //      int IntRes = 0;
      //      if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
      //      {
      //          Request Request = new Request();
      //          Request.CommandText = BLL.TPV.SProc.Factory_Broken_Pcs_Save;
      //          Request.CommandType = CommandType.StoredProcedure;

      //          Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("MANAGER_CODE_", pClsProperty.Manager_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("REASON_CODE_", pClsProperty.Reason_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("EMPLOYEE_CODE_", pClsProperty.To_Employee_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("CHANGE_PURITY_CODE_", pClsProperty.Change_Purity_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);

      //          Request.AddParams("PURITY_CODE_", pClsProperty.Purity_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ROUGH_SIZE_CODE_", pClsProperty.Rough_Size_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("PCS_", pClsProperty.Rejection_Pcs, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("CARAT_", pClsProperty.Rejection_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("EXP_CARAT_", pClsProperty.Proc_Exp_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("REV_EXP_CARAT_", pClsProperty.Rev_Exp_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Int32, ParameterDirection.Input);

      //          Request.AddParams("LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("ENTRY_DATE_", pClsProperty.From_Issue_Date, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("IS_RECOVER_", pClsProperty.Is_Recover, DbType.Int32, ParameterDirection.Input);

      //          Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("USER_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("BREAKAGE_TYPE_", pClsProperty.Breakage_Type, DbType.String, ParameterDirection.Input);

      //          //ADD BY HARESH ON 18-08-2015
      //          Request.AddParams("APPROVED_BY_", pClsProperty.Approved_By, DbType.Int32, ParameterDirection.Input);
      //          //END AS

      //          IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

      //          Request = new Request();
      //          Request.CommandText = BLL.TPV.SProc.Factory_Broken_Pcs_Save;
      //          Request.CommandType = CommandType.StoredProcedure;

      //          Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("MANAGER_CODE_", pClsProperty.Manager_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("REASON_CODE_", pClsProperty.Reason_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("EMPLOYEE_CODE_", pClsProperty.To_Employee_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("CHANGE_PURITY_CODE_", pClsProperty.Change_Purity_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);

      //          Request.AddParams("PURITY_CODE_", pClsProperty.Purity_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ROUGH_SIZE_CODE_", pClsProperty.Rough_Size_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("PCS_", pClsProperty.Rejection_Pcs, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("CARAT_", pClsProperty.Rejection_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("EXP_CARAT_", pClsProperty.Proc_Exp_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("REV_EXP_CARAT_", pClsProperty.Rev_Exp_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Int32, ParameterDirection.Input);

      //          Request.AddParams("LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("ENTRY_DATE_", pClsProperty.From_Issue_Date, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("IS_RECOVER_", pClsProperty.Is_Recover, DbType.Int32, ParameterDirection.Input);

      //          Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("USER_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("BREAKAGE_TYPE_", pClsProperty.Breakage_Type, DbType.String, ParameterDirection.Input);

      //          //ADD BY HARESH ON 18-08-2015
      //          Request.AddParams("APPROVED_BY_", pClsProperty.Approved_By, DbType.Int32, ParameterDirection.Input);
      //          //END AS

      //          IntRes += Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
      //      }


      //      else if (GlobalDec.gEmployeeProperty.Allow_Developer == 1)
      //      {
      //          Request Request = new Request();
      //          Request.CommandText = BLL.TPV.SProc.Factory_Broken_Pcs_Save;
      //          Request.CommandType = CommandType.StoredProcedure;

      //          Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("MANAGER_CODE_", pClsProperty.Manager_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("REASON_CODE_", pClsProperty.Reason_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("EMPLOYEE_CODE_", pClsProperty.To_Employee_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("CHANGE_PURITY_CODE_", pClsProperty.Change_Purity_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);

      //          Request.AddParams("PURITY_CODE_", pClsProperty.Purity_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("ROUGH_SIZE_CODE_", pClsProperty.Rough_Size_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("PCS_", pClsProperty.Rejection_Pcs, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("CARAT_", pClsProperty.Rejection_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("EXP_CARAT_", pClsProperty.Proc_Exp_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("REV_EXP_CARAT_", pClsProperty.Rev_Exp_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Int32, ParameterDirection.Input);

      //          Request.AddParams("LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
      //          Request.AddParams("ENTRY_DATE_", pClsProperty.From_Issue_Date, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("IS_RECOVER_", pClsProperty.Is_Recover, DbType.Int32, ParameterDirection.Input);

      //          Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
      //          Request.AddParams("USER_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
      //          Request.AddParams("BREAKAGE_TYPE_", pClsProperty.Breakage_Type, DbType.String, ParameterDirection.Input);

      //          //ADD BY HARESH ON 18-08-2015
      //          Request.AddParams("APPROVED_BY_", pClsProperty.Approved_By, DbType.Int32, ParameterDirection.Input);
      //          //END AS

      //          IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
      //      }
      //      return IntRes;  
      //  }

      //  public int DeleteBrokenPcs(Factory_Detail_Property pClsProperty) // Khushbu 10/01/2014 
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.Factory_Broken_Pcs_Delete;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);

      //      return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

      //  }

      //  #endregion

      //  public DataTable GetPolishReceiptDetail(string pStrJangedNo)
      //  {
      //      DataTable DTabPolishReceipt = new DataTable();

      //      Request Request = new Request();

      //      Request.AddParams("BILL_OF_ENTRY_NO_", pStrJangedNo, DbType.String, ParameterDirection.Input);

      //      Request.CommandText = BLL.TPV.SProc.Factory_Polish_Receipt_GetDet;
      //      Request.CommandType = CommandType.StoredProcedure;
      //      Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabPolishReceipt, Request);
      //      return DTabPolishReceipt;
      //  }

      //  public string IsPolishJangedExists(int pIntParty, int pIntSubParty, string pStrJangedNo)
      //  {
      //      Request Request = new Request();
      //      Request.AddParams("PARTY_CODE_", pIntParty, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("SUB_PARTY_CODE_", pIntSubParty, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("JANGED_NO_", pStrJangedNo, DbType.String, ParameterDirection.Input);

      //      Request.CommandText = BLL.TPV.SProc.Factory_Polish_Rec_JangedExist;
      //      Request.CommandType = CommandType.StoredProcedure;
      //      return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

      //  }

      //  public double IsPolishJangedExists(string pStrJangedNo)
      //  {
      //      Validation Val = new Validation();
      //      return Val.Val(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, BLL.TPV.Table.Factory_Master, "COUNT(1)", "AND RETURN_JANGED_NO = '" + pStrJangedNo + "'"));
      //  }


      //  public int DeleteCompleteProcess(Factory_Detail_Property MastProperty)
      //  {
      //      Request Request = new Request();
      //      Request.CommandText = BLL.TPV.SProc.factory_Comp_Process_Delete;
      //      Request.CommandType = CommandType.StoredProcedure;

      //      Request.AddParams("SRNO_", MastProperty.SrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("NEXT_SRNO_", MastProperty.Next_SrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("PREV_SRNO_", MastProperty.Prev_SrNo, DbType.Int32, ParameterDirection.Input);
      //      Request.AddParams("BARCODE_", MastProperty.Barcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("MAINBARCODE_", MastProperty.MainBarcode, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("ROUGH_NAME_", MastProperty.Rough_Name, DbType.String, ParameterDirection.Input);

      //      return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

      //  }

    }

}
