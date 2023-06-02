using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BLL.PropertyClasses.Transaction;
using DLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using System.Collections;

namespace BLL.FunctionClasses.Transaction
{
    public class PacketMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        #region Other Function


        public int FindNewPacketNo(string pStrRoughName, int pIntProcessCode)
        {
            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Packet_Master", "MAX(PACKET_NO)", " And Rough_Name = '" + pStrRoughName + "' And Process_Code = '" + pIntProcessCode + "' ");
        }

        public int FindNewJangedNo(string pStrDate)
        {
            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Packet_Master", "MAX(JANGED_NO)", " And ENTRY_DATE = '" + Val.DBDate(pStrDate) + "' ");
        }

        public string FindNewBarcodeNo(string pStrRoughName) // Add : Narendra : 13-08-2014
        {
            int BarcodeNo = Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "Packet_Master", "MAX(TO_NUMBER(SUBSTR(BARCODE,5)))", " And ROUGH_NAME = '" + pStrRoughName + "' ");

            return pStrRoughName + GlobalDec.GenerateBarcodeString(BarcodeNo);
        }

        #endregion

        public bool ISExists(string pStrBarcode)
        {
            if (pStrBarcode == "")
            {
                return false;
            }
            Request Request = new Request();
            Request.AddParams("@BARCODE", pStrBarcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@out", 0, DbType.Int32, ParameterDirection.Output);
            Request.CommandText = "Packet_Master_ISExists";
            Request.CommandType = CommandType.StoredProcedure;

            DataTable DTAB = new DataTable();
            Int64 IntRec = 0;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    IntRec = Convert.ToInt64(DTAB.Rows[0][0]);
                }
            }
            
            //ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            //int IntRec = Val.ToInt(AL[0]);
            //AL = null;

            if (IntRec == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Int64 Save(Packet_MasterProperty pClsProperty)
        {
            try
            {
                Request Request = new Request();

                Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
                Request.AddParams("@PROCESS_CODE", pClsProperty.Process_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@PACKET_NO", pClsProperty.Packet_No, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@BARCODE", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
                Request.AddParams("@SHAPE_CODE", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@CLARITY_CODE", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@COLOR_CODE", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@ISSUE_PCS", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@ISSUE_CARAT", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@ROUGH_TYPE_CODE", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@SIEVE_CODE", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@EXP_PER", pClsProperty.EXP_Per, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@EXP_BY", pClsProperty.EXP_By, DbType.String, ParameterDirection.Input);
                Request.AddParams("@DM_PER", pClsProperty.DM_Per, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@DM_BY", pClsProperty.DM_By, DbType.String, ParameterDirection.Input);
                Request.AddParams("@HEIGHT", pClsProperty.Height, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@WIDTH", pClsProperty.Width, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@DEPTH", pClsProperty.Depth, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@MAX_DIA", pClsProperty.Max_Dia, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@MIN_DIA", pClsProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@JANGED_NO", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
                Request.AddParams("@SYS_DATE", pClsProperty.Entry_Date, DbType.DateTime, ParameterDirection.Input);
                Request.AddParams("@USER_EMPLOYEE_CODE", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@COMPUTER_IP", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
                Request.AddParams("@REMARK", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
                Request.AddParams("@COMP_NO", pClsProperty.Comp_No, DbType.String, ParameterDirection.Input);
                Request.AddParams("@STOCK_FLAG", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
                Request.AddParams("@CLV_CLARITY_CODE", pClsProperty.Clv_Clarity_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@MFG_CLARITY_CODE", pClsProperty.Mfg_Clarity_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@STATUS", pClsProperty.Status, DbType.String, ParameterDirection.Input);
                Request.AddParams("@SRNO", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@RATE", pClsProperty.Rate, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@AMOUNT", pClsProperty.Amount, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@DEPARTMENT_CODE", pClsProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("@EXP_CARAT", pClsProperty.Exp_Carat, DbType.Double, ParameterDirection.Input);
                Request.AddParams("@ISSUE_TYPE", pClsProperty.Issue_Type, DbType.String, ParameterDirection.Input);
                Request.AddParams("@NewSrno", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Output);

                Request.CommandText = "Packet_Master_Save";
                Request.CommandType = CommandType.StoredProcedure;
                //      return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

                DataTable DTAB = new DataTable();
                Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
                if (DTAB != null)
                {
                    if (DTAB.Rows.Count > 0)
                    {
                        pClsProperty.SrNo = Convert.ToInt64(DTAB.Rows[0][0]);
                    }
                    else
                    {
                        pClsProperty.SrNo = 0;
                    }
                }
                else
                {
                    pClsProperty.SrNo = 0;
                }
                
                //ArrayList OP = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
                //if (OP.Count > 0)
                //{ pClsProperty.SrNo = Convert.ToInt64(OP[0]); }
                //else { }
                return pClsProperty.SrNo;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable GetPacketData(Mix_IssRet_MasterProperty pClsProperty)
        {
            DataTable tdt = new DataTable();
            Request Request = new Request();
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
      //      Request.AddParams("@ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@FROM_JANGED_NO_", "0", DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_JANGED_NO_", "0", DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_CARAT_", "0", DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_CARAT_", "0", DbType.Double, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", "", DbType.String, ParameterDirection.Input);
            Request.CommandText = "Packet_Master_GetDataForIss";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, tdt, Request, "");
            return tdt;
        }

        public DataTable CUT_GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "CUT_MASTER_GETDATA";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int BarcodeMerge(Packet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Packet_Master_BarcodeMerge";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData(string pStrBarcode)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "Factory_Packet_Detail_ManView";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@BARCODE_", pStrBarcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetFiltedData(Packet_MasterProperty Property)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "Factory_Packet_Barcode_GetData";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@ROUGH_NAME_", Property.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE_", Property.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE_", Property.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE_", Property.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COLOR_CODE_", Property.Color_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@MFG_CLARITY_CODE_", Property.Mfg_Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLV_CLARITY_CODE_", Property.Clv_Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PCS_", Property.From_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_PCS_", Property.To_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@FROM_CARAT_", Property.From_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_CARAT_", Property.To_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@COMP_NO_", Property.Comp_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@EXP_PER_", Property.EXP_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@DM_PER_", Property.DM_Per, DbType.Double, ParameterDirection.Input);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //public string FindNewBarcode(string pStrRoughName,int pIntProcessCode,int pIntPacketNo = 0)
        //{
        //    string DefaultString = "";

        //    if (pIntPacketNo == 0)
        //    {
        //        pIntPacketNo = FindNewPacketNo(pStrRoughName, pIntProcessCode);
        //    }
        //    DefaultString = GlobalDec.GenerateBarcodeString(pIntPacketNo);

        //    string StrProcessShortName = new ProcessMaster().GetShortName(pIntProcessCode);
        //    if (StrProcessShortName == "")
        //    {
        //        return "";
        //    }

        //    return pStrRoughName + StrProcessShortName + DefaultString;
        //}       

        //public int SaveSingleLot(Packet_MasterProperty pClsProperty)
        //{
        //    try
        //    {
        //        //int IntPacketNo = FindNewPacketNo(pClsProperty.Rough_Name);
        //        //string StrBarcode = FindNewBarcode(pClsProperty.Rough_Name, IntPacketNo);

        //        Request Request = new Request();
        //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("PACKET_NO_", pClsProperty.Packet_No, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);


        //        Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);


        //        Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("MSIZE_CODE_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("CUT_CODE_", pClsProperty.Cut_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("POLISH_CODE_", pClsProperty.Polish_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SYMMETRY_CODE_", pClsProperty.Symmetry_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("FLUORESCENCE_CODE_", pClsProperty.Fluorescence_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("KAPAN_NO_", pClsProperty.Kapan_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("EXP_PER_", pClsProperty.EXP_Per, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("EXP_BY_", pClsProperty.EXP_By, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("EXP_PER_CODE_", pClsProperty.EXP_Per_Code, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("DM_PER_", pClsProperty.DM_Per, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("DM_BY_", pClsProperty.DM_By, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("HEIGHT_", pClsProperty.Height, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("WIDTH_", pClsProperty.Width, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("DEPTH_", pClsProperty.Depth, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("MAX_DIA_", pClsProperty.Max_Dia, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("MIN_DIA_", pClsProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ENTRY_TIME_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("COMP_NO_", pClsProperty.Comp_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("CLV_CLARITY_CODE_", pClsProperty.Clv_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.Mfg_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("RR_PCS_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("RATE_", pClsProperty.Rate, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("AMOUNT_", pClsProperty.Amount, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("ROUGH_RATE_DATE_", pClsProperty.ROUGH_RATE_DATE, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("POLISH_CP_DATE_", pClsProperty.POLISH_CP_DATE, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("BANCKMARK_DATE_", pClsProperty.BANCKMARK_DATE, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("POINTER_", pClsProperty.Pointer, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_TYPE_", pClsProperty.Issue_Type, DbType.String, ParameterDirection.Input);

        //        Request.CommandText = BLL.TPV.SProc.Packet_Master_Single_Lot_Save;
        //        Request.CommandType = CommandType.StoredProcedure;
        //        return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    }
        //    catch
        //    {
        //        return -1;
        //    }


        //}
        //public int SaveStock4(Packet_MasterProperty pClsProperty)
        //{
        //    try
        //    {
        //        //int IntPacketNo = FindNewPacketNo(pClsProperty.Rough_Name);
        //        //string StrBarcode = FindNewBarcode(pClsProperty.Rough_Name, IntPacketNo);

        //        Request Request = new Request();
        //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("PROCESS_CODE_", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("PACKET_NO_", pClsProperty.Packet_No, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);

        //        // Start Haresh On 10-12-2013
        //        Request.AddParams("DEPARTMENT_CODE_", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //        // End Haresh

        //        Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("MSIZE_CODE_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("CUT_CODE_", pClsProperty.Cut_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("POLISH_CODE_", pClsProperty.Polish_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SYMMETRY_CODE_", pClsProperty.Symmetry_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("FLUORESCENCE_CODE_", pClsProperty.Fluorescence_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("KAPAN_NO_", pClsProperty.Kapan_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("EXP_PER_", pClsProperty.EXP_Per, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("EXP_BY_", pClsProperty.EXP_By, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("EXP_PER_CODE_", pClsProperty.EXP_Per_Code, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("DM_PER_", pClsProperty.DM_Per, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("DM_BY_", pClsProperty.DM_By, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("HEIGHT_", pClsProperty.Height, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("WIDTH_", pClsProperty.Width, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("DEPTH_", pClsProperty.Depth, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("MAX_DIA_", pClsProperty.Max_Dia, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("MIN_DIA_", pClsProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ENTRY_TIME_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("COMP_NO_", pClsProperty.Comp_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("CLV_CLARITY_CODE_", pClsProperty.Clv_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("MFG_CLARITY_CODE_", pClsProperty.Mfg_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("RR_PCS_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("RATE_", pClsProperty.Rate, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("AMOUNT_", pClsProperty.Amount, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("ROUGH_RATE_DATE_", pClsProperty.ROUGH_RATE_DATE, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("POLISH_CP_DATE_", pClsProperty.POLISH_CP_DATE, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("BANCKMARK_DATE_", pClsProperty.BANCKMARK_DATE, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("POINTER_", pClsProperty.Pointer, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_TYPE_", pClsProperty.Issue_Type, DbType.String, ParameterDirection.Input);


        //        // Add By Haresh 09/06/2014

        //        Request.AddParams("MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

        //        Request.AddParams("GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

        //        /*ADD BY HARESH ON 07-06-2014 FOR STOCK4 FANTACY FILE*/

        //        Request.AddParams("MAINBARCODE_", pClsProperty.MainBarcode, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("EST_CLARITY_CODE_", pClsProperty.EST_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("EST_COLOR_CODE_", pClsProperty.EST_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("EST_SHAPE_CODE_", pClsProperty.EST_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);

        //        /*----------------------*/

        //        Request.CommandText = BLL.TPV.SProc.Packet_Master_Stock4Save;
        //        Request.CommandType = CommandType.StoredProcedure;
        //        return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    }
        //    catch
        //    {
        //        return -1;
        //    }


        //}





        //public string ISExistsWithJanged(string pStrBarcode,string pStrJangedNo)
        //{
        //    if (pStrBarcode == "")
        //    {
        //        return "";
        //    }
        //    Request Request = new Request();
        //    Request.AddParams("ISSUE_JANGED_NO_", pStrJangedNo, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pStrBarcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("OUT_STR_", "", DbType.String, ParameterDirection.Output);
        //    Request.CommandText = BLL.TPV.SProc.BARCODE_EXISTS_WITH_JANGED;
        //    Request.CommandType = CommandType.StoredProcedure;

        //    ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    string StrRes = Val.ToString(AL[0]);
        //    AL = null;
        //    return StrRes;
        //}

        //public string FindExpPer(string pStrExpPerCode)
        //{

        //    Request Request = new Request();
        //    Request.AddParams("EXPPER_CODE_", pStrExpPerCode, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = BLL.TPV.SProc.ExpPerCode_FindExpPer;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    string StrResult = Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    return StrResult;
        //}

        //public bool ISJangedExists(string pStrDate, int pIntJangedNo)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("JANGED_DATE_", pStrDate, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("JANGED_NO_", pIntJangedNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("OUT_INT_", 0, DbType.Int32, ParameterDirection.Output);

        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_JangedIsExistNew;
        //    Request.CommandType = CommandType.StoredProcedure;

        //    ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    int IntRec = Val.ToInt(AL[0]);
        //    AL = null;

        //    if (IntRec == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }        
        //}

        //public int Count(string pStrJangedNo)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("JANGED_NO_", pStrJangedNo, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_Count;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    string StrResult = Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    return 1;
        //}

        //public int Delete(Packet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PACKET_NO_", pClsProperty.Packet_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_Delete;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

      

        //public void GetData(Packet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PACKET_NO_", pClsProperty.Packet_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_GetData;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //}

        ////Vipul
        //public DataTable GetBarcodeListForReport(string pStrRoughName)
        //{
        //    DataTable DTabBarcode = new DataTable();
        //    Request Request = new Request();
        //    Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_GetBarcodeList;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabBarcode, Request, "");
        //    return DTabBarcode;
        //}



        //public DataTable GetDataForSearch()
        //{
        //    Packet_MasterProperty pClsProperty = new Packet_MasterProperty();
        //    pClsProperty.Rough_Name = null;
        //    pClsProperty.Packet_No = 0;
        //    pClsProperty.Barcode = null;
        //    GetData(pClsProperty);
        //    return DTab;
        //}

        //public Packet_MasterProperty GetDataByPK(Packet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PACKET_NO_", pClsProperty.Packet_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_GetData;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    if (DRow == null)
        //    {
        //        return null;
        //    }
        //    pClsProperty.Rough_Name = Val.ToString(DRow["ROUGH_NAME"]);
        //    pClsProperty.Packet_No = Val.ToInt(DRow["PACKET_NO"]);
        //    pClsProperty.Barcode = Val.ToString(DRow["BARCODE"]);
        //    pClsProperty.Shape_Code = Val.ToInt(DRow["SHAPE_CODE"]);
        //    pClsProperty.Shape_Name = Val.ToString(DRow["SHAPE_NAME"]);
        //    pClsProperty.Clarity_Code = Val.ToInt(DRow["CLARITY_CODE"]);
        //    pClsProperty.Clarity_Name = Val.ToString(DRow["CLARITY_NAME"]);

        //    pClsProperty.Clv_Clarity_Code = Val.ToInt(DRow["CLV_CLARITY_CODE"]);
        //    pClsProperty.Clv_Clarity_Name = Val.ToString(DRow["CLV_CLARITY_NAME"]);

        //    pClsProperty.Mfg_Clarity_Code = Val.ToInt(DRow["MFG_CLARITY_CODE"]);
        //    pClsProperty.Mfg_Clarity_Name = Val.ToString(DRow["MFG_CLARITY_NAME"]);

        //    pClsProperty.Color_Code = Val.ToInt(DRow["COLOR_CODE"]);
        //    pClsProperty.Color_Name = Val.ToString(DRow["COLOR_NAME"]);
        //    pClsProperty.MSize_Code = Val.ToInt(DRow["MSIZE_CODE"]);
        //    pClsProperty.MSize_Name = Val.ToString(DRow["MSize_NAME"]);
        //    pClsProperty.Issue_Pcs = Val.ToInt(DRow["ISSUE_PCS"]);
        //    pClsProperty.Issue_Carat = Val.Val(DRow["ISSUE_CARAT"]);
        //    pClsProperty.Rough_Type_Code = Val.ToInt(DRow["ROUGH_TYPE_CODE"]);
        //    pClsProperty.Rough_Type_Name = Val.ToString(DRow["ROUGH_TYPE_NAME"]);
        //    pClsProperty.Cut_Code = Val.ToInt(DRow["CUT_CODE"]);
        //    pClsProperty.Cut_Name = Val.ToString(DRow["CUT_NAME"]);
        //    pClsProperty.Polish_Code = Val.ToInt(DRow["POLISH_CODE"]);
        //    pClsProperty.Polish_Name = Val.ToString(DRow["POLISH_NAME"]);
        //    pClsProperty.Symmetry_Code = Val.ToInt(DRow["SYMMETRY_CODE"]);
        //    pClsProperty.Symmetry_Name = Val.ToString(DRow["SYMMETRY_NAME"]);
        //    pClsProperty.Fluorescence_Code = Val.ToInt(DRow["FLUORESCENCE_CODE"]);
        //    pClsProperty.Fluorescence_Name = Val.ToString(DRow["FLUORESCENCE_Name"]);
        //    pClsProperty.Sieve_Code = Val.ToInt(DRow["SIEVE_CODE"]);
        //    pClsProperty.Sieve_Name = Val.ToString(DRow["SIEVE_NAME"]);
        //    pClsProperty.Kapan_No = Val.ToString(DRow["KAPAN_NO"]);
        //    pClsProperty.EXP_Per = Val.Val(DRow["EXP_PER"]);
        //    pClsProperty.EXP_Per_Code = Val.ToString(DRow["EXP_PER_CODE"]);

        //    pClsProperty.EXP_By = Val.ToInt(DRow["EXP_BY"]);
        //    pClsProperty.Exp_By_Name = Val.ToString(DRow["EXP_BY_NAME"]);
        //    pClsProperty.DM_Per = Val.Val(DRow["DM_PER"]);
        //    pClsProperty.DM_By = Val.ToInt(DRow["DM_BY"]);
        //    pClsProperty.DM_By_Name = Val.ToString(DRow["DM_BY_NAME"]);
        //    pClsProperty.Height = Val.Val(DRow["HEIGHT"]);
        //    pClsProperty.Width = Val.Val(DRow["WIDTH"]);
        //    pClsProperty.Depth = Val.Val(DRow["DEPTH"]);
        //    pClsProperty.Max_Dia = Val.Val(DRow["MAX_DIA"]);
        //    pClsProperty.Min_Dia = Val.Val(DRow["MIN_DIA"]);
        //    pClsProperty.Janged_No = Val.ToInt(DRow["JANGED_NO"]);
        //    pClsProperty.Entry_Date = Val.ToString(DRow["ENTRY_DATE"]);
        //    pClsProperty.Entry_Time = Val.ToString(DRow["ENTRY_TIME"]);
        //    pClsProperty.Sys_Date = Val.ToString(DRow["SYS_DATE"]);
        //    pClsProperty.Sys_Time = Val.ToString(DRow["SYS_TIME"]);
        //    pClsProperty.Remark = Val.ToString(DRow["REMARK"]);

        //    pClsProperty.Loss_Carat = Val.Val(DRow["LOSS_CARAT"]);
        //    pClsProperty.Loss_Pcs = Val.ToInt(DRow["LOSS_PCS"]);
        //    pClsProperty.Lost_Carat = Val.Val(DRow["LOST_CARAT"]);
        //    pClsProperty.Lost_Pcs = Val.ToInt(DRow["LOST_PCS"]);

        //    pClsProperty.Machine_Code = Val.ToInt(DRow["MACHINE_CODE"]);
        //    pClsProperty.Machine_Name = Val.ToString(DRow["MACHINE_NAME"]);

        //    pClsProperty.INS_By = Val.ToInt(DRow["INS_BY"]);
        //    pClsProperty.INS_By_Name = Val.ToString(DRow["INS_BY_NAME"]);

        //    pClsProperty.INS_DM_Per = Val.Val(DRow["INS_DM_PER"]);
        //    pClsProperty.INS_DM_Carat = Val.Val(DRow["INS_DM_CARAT"]);
        //    pClsProperty.INS_FAC_WT_Per = Val.Val(DRow["INS_FAC_WT_PER"]);
        //    pClsProperty.INS_FAC_WT_Carat = Val.Val(DRow["INS_FAC_WT_CARAT"]);
        //    pClsProperty.INS_Manual_Per = Val.Val(DRow["INS_MANUAL_PER"]);
        //    pClsProperty.INS_Manual_Carat = Val.Val(DRow["INS_MANUAL_CARAT"]);
        //    pClsProperty.INS_Date = Val.DBDate(Val.ToString(DRow["INS_DATE"]));
        //    pClsProperty.INS_Time = Val.DBTime(Val.ToString(DRow["INS_TIME"]));

        //    pClsProperty.Status = Val.ToString(Val.ToString(DRow["STATUS"]));
        //    pClsProperty.SrNo = Val.ToInt(Val.ToString(DRow["SRNO"]));

        //    //pClsProperty.Party_Code = Val.ToInt(DRow["PARTY_CODE"]);
        //    //pClsProperty.Party_Name = Val.ToString(DRow["PARTY_NAME"]);

        //    //pClsProperty.Sub_Party_Code = Val.ToInt(DRow["SUB_PARTY_CODE"]);
        //    //pClsProperty.Sub_Party_Name = Val.ToString(DRow["SUB_PARTY_NAME"]);

        //    return pClsProperty;
        //}

        //public Packet_MasterProperty GetDataByPK(string pStrBarcode = null)
        //{
        //    Packet_MasterProperty Property = new Packet_MasterProperty();

        //    Property.Barcode = pStrBarcode;

        //    Property = GetDataByPK(Property);
        //    return Property;

        //}

        //public Packet_MasterProperty GetDataByPK(string pStrRoughName = null, int pIntPacketNo = 0, string pStrBarcode = null)
        //{
        //    Packet_MasterProperty Property = new Packet_MasterProperty();

        //    Property.Rough_Name = pStrRoughName;
        //    Property.Packet_No = pIntPacketNo;
        //    Property.Barcode = pStrBarcode;

        //    Property = GetDataByPK(Property);
        //    return Property;

        //}

        //public DataRow GetPacketSummary(Packet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.CommandText = BLL.TPV.SProc.Packet_Summary;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Request.AddParams("JANGED_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);

        //    DataRow Drow= Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    return Drow;
        //}
        ///*
        //public int SaveInspectionEntry(Packet_MasterProperty pClsProperty)
        //{

        //    Request Request = new Request();
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("INS_PARTY_CODE_", pClsProperty.INS_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("INS_SUB_PARTY_CODE_", pClsProperty.INS_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("INS_BY_", pClsProperty.INS_By, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("INS_DM_PER_", pClsProperty.INS_DM_Per, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("INS_DM_CARAT_", pClsProperty.INS_DM_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("INS_FAC_WT_PER_", pClsProperty.INS_FAC_WT_Per, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("INS_FAC_WT_CARAT_", pClsProperty.INS_FAC_WT_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("INS_MANUAL_PER_", pClsProperty.INS_Manual_Per, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("INS_MANUAL_CARAT_", pClsProperty.INS_Manual_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("INS_DATE_", pClsProperty.INS_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("INS_USER_EMPLOYEE_CODE_", pClsProperty.User_Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("INS_COMPUTER_IP_", pClsProperty.Computer_IP, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_INS_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //}
        //*/
        //public void GetPacketData(Mix_IssRet_MasterProperty pClsProperty)
        //{
        //    if (DTab != null)
        //    {
        //        DTab.Rows.Clear();
        //    }
        //    Request Request = new Request();
        //    Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FROM_JANGED_NO_", pClsProperty.From_Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_JANGED_NO_", pClsProperty.To_Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("TO_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("FROM_CARAT_", pClsProperty.From_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TO_CARAT_", pClsProperty.To_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_GetDataForIss;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //}

        //public DataRow FindAllRateDate()
        //{
        //    Request Request = new DLL.Request();
        //    Request.CommandText = BLL.TPV.SProc.Find_All_Rate_Date;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);        
        //}


        //public Packet_MasterProperty GetStockBarcodeByPK(int pIntFromProcessCode, string pStrBarcode)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("FROM_PROCESS_CODE_", pIntFromProcessCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pStrBarcode, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_GetPacketByStock;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    if (DRow == null)
        //    {
        //        return null;
        //    }
        //    Packet_MasterProperty pClsProperty = new Packet_MasterProperty();

        //    pClsProperty.Rough_Name = Val.ToString(DRow["ROUGH_NAME"]);

        //    pClsProperty.Packet_No = Val.ToInt(DRow["PACKET_NO"]);
        //    pClsProperty.Barcode = Val.ToString(DRow["BARCODE"]);

        //    pClsProperty.Shape_Code = Val.ToInt(DRow["SHAPE_CODE"]);
        //    pClsProperty.Shape_Name = Val.ToString(DRow["SHAPE_NAME"]);

        //    pClsProperty.Clarity_Code = Val.ToInt(DRow["CLARITY_CODE"]);
        //    pClsProperty.Clarity_Name = Val.ToString(DRow["CLARITY_NAME"]);

        //    pClsProperty.Clv_Clarity_Code = Val.ToInt(DRow["CLV_CLARITY_CODE"]);
        //    pClsProperty.Clv_Clarity_Name = Val.ToString(DRow["CLV_CLARITY_NAME"]);

        //    pClsProperty.Mfg_Clarity_Code = Val.ToInt(DRow["MFG_CLARITY_CODE"]);
        //    pClsProperty.Mfg_Clarity_Name = Val.ToString(DRow["MFG_CLARITY_NAME"]);

        //    pClsProperty.Color_Code = Val.ToInt(DRow["COLOR_CODE"]);
        //    pClsProperty.Color_Name = Val.ToString(DRow["COLOR_NAME"]);

        //    pClsProperty.MSize_Code = Val.ToInt(DRow["MSIZE_CODE"]);
        //    pClsProperty.MSize_Name = Val.ToString(DRow["MSize_NAME"]);

        //    pClsProperty.Issue_Pcs = Val.ToInt(DRow["ISSUE_PCS"]);
        //    pClsProperty.Issue_Carat = Val.Val(DRow["ISSUE_CARAT"]);

        //    pClsProperty.Rough_Type_Code = Val.ToInt(DRow["ROUGH_TYPE_CODE"]);
        //    pClsProperty.Rough_Type_Name = Val.ToString(DRow["ROUGH_TYPE_NAME"]);

        //    pClsProperty.Sieve_Code = Val.ToInt(DRow["SIEVE_CODE"]);
        //    pClsProperty.Sieve_Name = Val.ToString(DRow["SIEVE_NAME"]);

        //    pClsProperty.From_Process_Code = Val.ToInt(DRow["FROM_PROCESS_CODE"]);
        //    pClsProperty.To_Process_Code = Val.ToInt(DRow["TO_PROCESS_CODE"]);

        //    pClsProperty.From_Process_Name = Val.ToString(DRow["FROM_PROCESS_NAME"]);
        //    pClsProperty.To_Process_Name = Val.ToString(DRow["TO_PROCESS_NAME"]);

        //    return pClsProperty;
        //}

        //public int DeletePacketBarcode(Packet_MasterProperty pClsProperty) // Khushbu 04/04/2014
        //{
        //    Request Request = new Request();
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_Barcode_Delete;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        //public int DeletePacketJanged(Packet_MasterProperty pClsProperty) // Khushbu 04/04/2014
        //{
        //    Request Request = new Request();
        //  //  Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_Janged_Delete;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        //public double GetRap_Disc_Rate(Packet_MasterProperty pClsProperty) // ADD : NARENDRA : 14-AUG-2014
        //{

        //    Request Request = new Request();
        //    Request.AddParams("CUT_CODE_", pClsProperty.Cut_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CODE_", pClsProperty.Polish_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SYMMENTRY_CODE_", pClsProperty.Symmetry_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FLOROSENCE_CODE_", pClsProperty.Fluorescence_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.CommandText = "RAP_PARADISC_GET_CUT_POL_SY_FL";// BLL.TPV.SProc.;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    if (DRow == null)
        //        return 0;
        //    else
        //        return Val.Val(DRow["RATE"]);

        //}
        //#endregion

        //#region Inspection Related Function

        //public int SaveInspectionEntry(Packet_MasterProperty pClsProperty)
        //{

        //    Request Request = new Request();

        //    Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("INS_BY_", pClsProperty.INS_By, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DM_PER_", pClsProperty.INS_DM_Per, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("DM_CARAT_", pClsProperty.INS_DM_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("FAC_WT_PER_", pClsProperty.INS_FAC_WT_Per, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("FAC_WT_CARAT_", pClsProperty.INS_FAC_WT_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MANUAL_PER_", pClsProperty.INS_Manual_Per, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MANUAL_CARAT_", pClsProperty.INS_Manual_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("FAC_DM_PER_", pClsProperty.INS_FAC_DM_Per, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("FAC_DM_CARAT_", pClsProperty.INS_FAC_DM_Carat, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("REMARK_", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PARTY_CODE_", pClsProperty.Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SUB_PARTY_CODE_", pClsProperty.Sub_Party_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", BLL.GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", pClsProperty.User_Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPUTER_IP_", pClsProperty.Computer_IP, DbType.String, ParameterDirection.Input);


        //    Request.CommandText = BLL.TPV.SProc.Mix_Inspection_Entry_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //}

        //public int DeleteInspectionEntry(Packet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.CommandText = BLL.TPV.SProc.Mix_Inspection_Entry_Delete;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //}

        //public DataTable Print(string pStrRoughName,string pStrSubParty,string pStrFromDate,string pStrToDate)
        //{
        //    DataTable DTabPrint = new DataTable();
        //    Request Request = new Request();
        //    Request.AddParams("ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FROM_DATE_", pStrFromDate, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("TO_DATE_", pStrToDate, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("SUB_PARTY_CODE_", pStrSubParty, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Mix_Inspection_Entry_Print;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabPrint, Request, "");
        //    return DTabPrint;
        //}

        //public DataTable GetBarCode(Packet_MasterProperty Property)
        //{
        //    DataTable DTabBarcode = new DataTable();
        //    Request Request = new Request();
        //    Request.CommandText = BLL.TPV.SProc.Mix_Inspection_Entry_Barcode;
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("ENTRY_DATE_", Property.Entry_Date, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", Property.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", BLL.GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);

        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;

        //}

        //public Packet_MasterProperty GetInsepctionData(Packet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", BLL.GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Mix_Inspection_Entry_GetData;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    if (DRow == null)
        //    {
        //        return null;
        //    }
        //    pClsProperty.Rough_Name = Val.ToString(DRow["ROUGH_NAME"]);
        //    pClsProperty.Barcode = Val.ToString(DRow["BARCODE"]);
        //    pClsProperty.Issue_Pcs = Val.ToInt(DRow["ISSUE_PCS"]);
        //    pClsProperty.Issue_Carat = Val.Val(DRow["ISSUE_CARAT"]);

        //    pClsProperty.EXP_By = Val.ToInt(DRow["EXP_BY"]);
        //    pClsProperty.Exp_By_Name = Val.ToString(DRow["EXP_BY_NAME"]);
        //    pClsProperty.EXP_Per = Val.Val(DRow["EXP_PER"]);

        //    pClsProperty.INS_By = Val.ToInt(DRow["INS_BY"]);
        //    pClsProperty.INS_By_Name = Val.ToString(DRow["INS_BY_NAME"]);

        //    pClsProperty.INS_DM_Per = Val.Val(DRow["DM_PER"]);
        //    pClsProperty.INS_DM_Carat = Val.Val(DRow["DM_CARAT"]);
        //    pClsProperty.INS_FAC_WT_Per = Val.Val(DRow["FAC_WT_PER"]);
        //    pClsProperty.INS_FAC_WT_Carat = Val.Val(DRow["FAC_WT_CARAT"]);
        //    pClsProperty.INS_FAC_DM_Per = Val.Val(DRow["FAC_DM_PER"]);
        //    pClsProperty.INS_FAC_DM_Carat = Val.Val(DRow["FAC_DM_CARAT"]);

        //    pClsProperty.INS_Manual_Per = Val.Val(DRow["MANUAL_PER"]);
        //    pClsProperty.INS_Manual_Per_Four = Val.Val(DRow["MANUAL_PER_FOUR"]);
        //    pClsProperty.INS_Manual_Carat = Val.Val(DRow["MANUAL_CARAT"]);
        //    pClsProperty.Entry_Date = Val.DBDate(Val.ToString(DRow["ENTRY_DATE"]));

        //    pClsProperty.Party_Code = Val.ToInt(DRow["PARTY_CODE"]);
        //    pClsProperty.Party_Name = Val.ToString(DRow["PARTY_NAME"]);

        //    pClsProperty.Sub_Party_Code = Val.ToInt(DRow["SUB_PARTY_CODE"]);
        //    pClsProperty.Sub_Party_Name = Val.ToString(DRow["SUB_PARTY_NAME"]);

        //    return pClsProperty;
        //}

        //#endregion

        //#region Extra Packet Import

        //public int ExtraPacketSave(Packet_MasterProperty pClsProperty) // Khushbu 03/04/2014
        //{

        //    Request Request = new Request();
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MACHINE_CODE_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("ISSUE_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("USER_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.Int32, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_Extra_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //}

        //public DataTable GetExtraPacketDetail(Packet_MasterProperty pClsProperty)  // Khushbu 03/04/2014
        //{
        //    DataTable DTab = new DataTable();
        //    Request Request = new Request();
        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.Date, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_Extra_GetData;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        //public int ExtraPacketDelete(Packet_MasterProperty pClsProperty)  // Khushbu 03/04/2014
        //{
        //    Request Request = new Request();
        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.Packet_Master_Extra_Delete;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        //public bool IsExistsInExtraPacket(string pStrBarcode)
        //{
        //    string Str = Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "PACKET_MASTER_EXTRA", "BARCODE", " And BARCODE = '" + pStrBarcode + "'");
        //    if (Str.Length != 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //#endregion

        ////Add : Narenda : 25-Aug-2014
        //#region Rapa Rate Calculator : Prediction Entry

        //public DataRow GetBarcodeDetail(string Barcode)
        //{
        //    Request Request = new Request();
        //    Request.CommandText = "SELECT ROUGH_NAME,ISSUE_CARAT FROM PACKET_MASTER WHERE BARCODE = '" + Barcode + "'";
        //    Request.CommandType = CommandType.Text;
        //    DataRow Drow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    return Drow;
        //}
        //public DataTable GetAllBarcode(string strRoughName)
        //{
        //    DataTable DtData = new DataTable();
        //    Request Request = new Request();
        //    Request.CommandText = "SELECT BARCODE,ROUGH_NAME,ISSUE_CARAT FROM PACKET_MASTER WHERE ROUGH_NAME LIKE '%" + strRoughName + "%'";
        //    Request.CommandType = CommandType.Text;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName,DtData, Request);
        //    return DtData;
        //}
        //public int SavePredictionEntry(Packet_MasterProperty pClsProperty)
        //{
        //    try
        //    {
        //        Request Request = new Request();
        //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("PLAN_NO_", pClsProperty.PlanNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("DESIGNATION_CODE_", pClsProperty.DesignationCode, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("READY_CARAT_", pClsProperty.Ready_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("CUT_CODE_", pClsProperty.Cut_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("POLISH_CODE_", pClsProperty.Polish_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SYM_CODE_", pClsProperty.Symmetry_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("FL_CODE_", pClsProperty.Fluorescence_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("RAP_VALUE_", pClsProperty.Rap_Value, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("LOCK_STATUS_", pClsProperty.LockStatus, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("ORIGIONAL_CARAT_", pClsProperty.Original_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("DISCOUNT_", pClsProperty.Discount, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("RATE_", pClsProperty.Rate, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("AMOUNT_", pClsProperty.Amount, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("COLOR_CODE_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);

        //        // ADD : NARENDRA : 29-AUG-2014
        //        Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("DEPARTMENT_CODE_", BLL.GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("USER_EMPLOYEE_CODE_", BLL.GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ENTRY_COMPUTER_IP_", BLL.GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("PREDICTION_DATE_", pClsProperty.Prediction_Date, DbType.Date, ParameterDirection.Input);

        //        Request.AddParams("PACKET_SRNO_", pClsProperty.Packet_SrNo, DbType.Int32, ParameterDirection.Input);



        //        Request.CommandText = BLL.TPV.SProc.Prediction_Entry_Save;
        //        Request.CommandType = CommandType.StoredProcedure;
        //        return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //}

        //public DataTable GetDataPredictionEntry(Packet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    DataTable DtTemp = new DataTable();
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("PACKET_SRNO_", pClsProperty.Packet_SrNo, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("DESIGNATION_CODE_", pClsProperty.DesignationCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);

        //    // ADD : NARENDRA : 29-AUG-2014
        //    Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", BLL.GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.Date, ParameterDirection.Input);
        //    //-------
        //    Request.CommandText = BLL.TPV.SProc.Prediction_Entry_GetData;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DtTemp, Request, "");

        //    return DtTemp;
        //}

        //public int FindNewSrNo(Packet_MasterProperty Property)
        //{
        //    return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, BLL.TPV.Table.Prediction_Entry, "MAX(SRNO)", " And BARCODE = '" + Property.Barcode + "' And DESIGNATION_CODE = '" + Property.DesignationCode + "' AND PLAN_NO='" + Property.PlanNo + "' AND TYPE = '" + Property.Type + "' ");
        //}

        //public int Delete_Prediction_Entry(Mix_IssRet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("PACKET_SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = BLL.TPV.SProc.Prediction_Entry_Delete;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        //#endregion

        //// Add : Narendra : 15-Apr-2016
        //public DataTable GetBarcodeDetailsForNFC(string pStrBarcode)
        //{
        //    DataTable DTabBarcode = new DataTable();
        //    Request Request = new Request();
        //    Request.AddParams("BARCODE_", pStrBarcode, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = "GET_BARCODE_DETAILS_FOR_NFC";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabBarcode, Request, "");
        //    return DTabBarcode;
        //}
        //// End : Narendra : 15-Apr-2016

        //public DataTable GetDataForInspectionForImport(Packet_MasterProperty pClsProperty)
        //{
        //    DataTable DTabBarcode = new DataTable();
        //    Request Request = new Request();
        //    Request.AddParams("COMPANY_CODE_", pClsProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", pClsProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SUB_PARTY_CODE_", pClsProperty.Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);

        //    Request.CommandText = BLL.TPV.SProc.MIX_INS_IMPORT_ENTRY_GETDATA;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabBarcode, Request, "");
        //    return DTabBarcode;
        //}
    }
}
