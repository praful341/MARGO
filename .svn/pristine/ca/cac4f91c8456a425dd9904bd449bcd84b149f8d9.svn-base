using BLL.PropertyClasses.Transaction;
using DLL;
using System;
using System.Collections;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class ClvMixDeptIssRet
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();
        public DataTable DTabDetail = new DataTable();

        #region Property Settings

        //public DataTable DTab { get; set; }

        private DataSet _DS = new DataSet();

        public DataSet DS
        {
            get { return _DS; }
            set { _DS = value; }
        }


        #endregion

        #region Validation

        public int FindNewJangedNo(string pStrDate)
        {
            return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "DEPT_ISSRET_MASTER", "MAX(JANGED_NO)", " And JANGED_DATE = '" + Val.DBDate(pStrDate) + "' ");
        }

        //public int FindJangedNo(int pIntMonth, int pIntYear)
        //{
        //    return Ope.FindNewID(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "DEPT_ISSRET_MASTER", "MAX(JANGED_NO)", " And extract(year from JANGED_DATE) = '" + pIntYear.ToString() + "' And extract(Month from JANGED_DATE) = '" + pIntMonth.ToString() + "'");

        //}

        public Int64 Master_Save(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@id", pClsProperty.P_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@JANGED_NO", pClsProperty.Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@JANGED_DATE", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", pClsProperty.From_Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@THROUGH_BY", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@New_ID", pClsProperty.new_ID, DbType.Int64, ParameterDirection.Output);
            Request.AddParams("@ISSUE_JANGED_NO", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Department_Transfer_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;

            DataTable DTAB = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    pClsProperty.new_ID = Convert.ToInt64(DTAB.Rows[0][0]);
                }
            }

            //ArrayList OP = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //if (OP.Count > 0)
            //{ pClsProperty.new_ID = Convert.ToInt64(OP[0]); }
            //else { }

            return pClsProperty.new_ID;
        }

        public int Detail_Save(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@ID", pClsProperty.P_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@DEPT_ISSRET_ID", pClsProperty.new_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_DEPARTMENT_CODE", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_DEPARTMENT_CODE", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLARITY_CODE", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BARCODE", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ISSUE_PCS", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@ISSUE_CARAT", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@ISSUE_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@ISSUE_EMPLOYEE_CODE", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ISSUE_COMPUTER_IP", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@JANGED_DATE", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@JANGED_NO", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "Department_Transfer_Detail_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        //public int SaveDepartmentReceive1(Mix_IssRet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.CommandText = "Mix_Dept_IssRet_SaveReceive";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Janged_No_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Department_Code_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Employee_Code_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Computer_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);

        //    return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //}

        // public DataTable Dept_Detail_GetData(Mix_IssRet_MasterProperty pClsProperty)
        // {
        //     Request Request = new Request();
        //     DataTable DTab = new DataTable();

        //     Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
        //     Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
        //     Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //     Request.AddParams("@LOCATION_CODE", pClsProperty.From_Location_Code, DbType.Int64, ParameterDirection.Input);
        //     Request.AddParams("@COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
        //     Request.AddParams("@BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
        ////     Request.AddParams("@THROUGH_BY", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("@ROUGH_TYPE_CODE", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);

        //     Request.CommandText = "Department_Transfer_Det_Getdata";
        //     Request.CommandType = CommandType.StoredProcedure;
        //     Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //     return DTab;
        // }

        public DataTable Dept_Supplier_GetData()
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.CommandText = "Dept_Supplier_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int Dept_Transfer_RowDate_Delete(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@DEPT_ISSRET_DETAIL_ID", pClsProperty.P_ID, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "Department_Transfer_RowData_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int Dept_Transfer_Date_Delete(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@DEPT_ISSRET_ID", pClsProperty.P_ID, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "Department_Transfer_Data_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int Employee_IssRet_RowDate_Delete(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@EMP_ISSRET_DTL_ID", pClsProperty.P_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TYPE", pClsProperty.Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Employee_IssRet_RowData_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int PolAssotment_RowDate_Delete(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@PolAssotID", pClsProperty.P_ID, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "PolishAssortment_Delete";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }


        // Add By Praful On 25022017

        public DataTable Employee_Issue_GetData(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_EMPLOYEE_CODE", pClsProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TYPE", pClsProperty.Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Employee_IssueReturn_Getdata";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int Emp_IssRet_Save(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@ID", pClsProperty.P_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@EMPLOYEE_CODE", pClsProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TYPE", pClsProperty.Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLARITY_CODE", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BARCODE", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ISSUE_PCS", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@ISSUE_CARAT", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LOSS_CARAT", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@PLUS_CARAT", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@USER_EMPLOYEE_CODE", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ISSUE_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@COMPUTER_IP", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Employee_Issue_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        // End

        // Mix Department Transfer Data Code

        public DataTable Dept_Transfer_GetData(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_DEPARTMENT_CODE", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            //  Request.AddParams("@TO_DEPARTMENT_CODE", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLARITY_CODE", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "Department_Transfer_Getdata";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable Dept_IssTran_GetDetail(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@TO_DEPARTMENT_CODE", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            //  Request.AddParams("@SIEVE_CODE", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@CLARITY_CODE", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            // Request.AddParams("@ROUGH_TYPE_CODE", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);

            Request.CommandText = "Dept_IssTran_GetDetail";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int Department_Transfer_Save(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@DEPT_ISSRET_DTL_ID", pClsProperty.DEPT_ISSRET_DTL_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@DEPT_ISSRET_ID", pClsProperty.P_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_DEPARTMENT_CODE", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ISSUE_EMPLOYEE_CODE", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ISSUE_COMPUTER_IP", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Department_Transfer_Detail_Update";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        // End

        // Mix Lot Employee Transfer Issue Return

        public DataTable Employee_MixIssRet_GetData(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_EMPLOYEE_CODE", pClsProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLARITY_CODE", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TYPE", pClsProperty.Type, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Employee_MixIssRet_Getdata";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int Emp_IssRet_Update(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@EMP_ISSRET_DTL_ID", pClsProperty.P_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@EMPLOYEE_CODE", pClsProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TYPE", pClsProperty.Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLARITY_CODE", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BARCODE", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ISSUE_PCS", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@ISSUE_CARAT", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@USER_EMPLOYEE_CODE", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ISSUE_DATE", pClsProperty.From_Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@COMPUTER_IP", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Employee_IssRet_Master_Update";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public Mix_IssRet_MasterProperty SaveEmployeeReceive(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "Employee_Issue_Master_Save"; // "Mix_Emp_IssRet_Save";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@ID", pClsProperty.P_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@EMPLOYEE_CODE", pClsProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TYPE", "R", DbType.String, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLARITY_CODE", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BARCODE", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ISSUE_PCS", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@ISSUE_CARAT", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@USER_EMPLOYEE_CODE", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ISSUE_DATE", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@COMPUTER_IP", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);

            Request.AddParams("@SRNO", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);

            DataTable DTAB = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    pClsProperty.SrNo = Val.ToInt64(DTAB.Rows[0][0]);
                    pClsProperty.Janged_Date = pClsProperty.Janged_Date;
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

            //ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //if (AL == null || AL.Count == 0)
            //{
            //    pClsProperty.SrNo = 0;
            //}
            //else
            //{
            //    pClsProperty.SrNo = Val.ToInt64(AL[0]);
            //    pClsProperty.Janged_Date = pClsProperty.Janged_Date;
            //}
            //AL = null;

            //DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //if (DRow == null)
            //{
            //    return null;
            //}
            //pClsProperty.SrNo = Val.ToInt64(DRow["SRNO"]);

            //DRow = null;

            return pClsProperty;
        }

        public DataTable GetReceiptFromOutSideBarcodeDetail(Mix_IssRet_MasterProperty pClsProperty)
        {
            DataTable DTabReceipt = new DataTable();
            Request Request = new Request();
            Request.CommandText = "ISSReceice_GetBarcode";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);

            //Request.AddParams("@ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            //Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabReceipt, Request);
            return DTabReceipt;
        }

        // End

        public DataTable GetPolishAssortment(Mix_IssRet_MasterProperty pClsProperty)
        {
            DataTable DTabReceipt = new DataTable();
            Request Request = new Request();
            Request.CommandText = "PolishAssortment_GetDetail";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@NotingDate_", pClsProperty.Noting_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabReceipt, Request);
            return DTabReceipt;
        }

        public int SaveDepartmentReceiveManual(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "Dept_IssRet_SaveReceive";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Janged_No_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Department_Code_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Receive_Employee_Code_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Receive_Computer_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", pClsProperty.To_Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", pClsProperty.To_Branch_Code, DbType.Int64, ParameterDirection.Input);

            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetDeptPendingJanged(Int64 pIntCompanyCode, Int64 pIntBranchCode, Int64 pIntLocationCode)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = "Dept_IssRet_GetPendingJanged";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("COMPANY_CODE_", pIntCompanyCode, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pIntBranchCode, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public string FindNew_IssueDept_JangedNoNew(string pStrProcessPrefix, string pStrFinYear)
        {
            Request Request = new Request();
            Request.CommandText = "Find_Issue_Janged_No";
            Request.CommandType = CommandType.StoredProcedure;
            //   Request.AddParams("LOCATION_SHORTNAME_", GlobalDec.gEmployeeProperty.Location_Short_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PROCESS_JANGED_PREFIX_", pStrProcessPrefix, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FIN_YEAR_", pStrFinYear, DbType.String, ParameterDirection.Input);
            Request.AddParams("@OUT_STR_", "", DbType.String, ParameterDirection.Output);
            DataTable DTAB = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    return Convert.ToString(DTAB.Rows[0][0]);
                }
            }
            return "";
            //ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //string StrRes = Val.ToString(AL[0]);
            //AL = null;
            // return StrRes;
            //return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public string FindNew_ReceiveDept_JangedNo(string pStrProcessPrefix, string pStrFinYear)
        {
            Request Request = new Request();
            Request.CommandText = "Find_Receive_Janged_No";
            Request.CommandType = CommandType.StoredProcedure;
            // Request.AddParams("LOCATION_SHORTNAME_", GlobalDec.gEmployeeProperty.Location_Short_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@PROCESS_JANGED_PREFIX_", pStrProcessPrefix, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FIN_YEAR_", pStrFinYear, DbType.String, ParameterDirection.Input);
            Request.AddParams("@OUT_STR_", "", DbType.String, ParameterDirection.Output);

            DataTable DTAB = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    return Convert.ToString(DTAB.Rows[0][0]);
                }
            }
            return "";
            //ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //string StrRes = Val.ToString(AL[0]);
            //AL = null;
            //return StrRes;
            //return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        #endregion

        #region Operation

        public string ValBillOfEntryExists(string pStrBillOfEntry)
        {
            Request Request = new Request();
            Request.CommandText = "MIX_BILL_OF_ENTRY_VALSAVE";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("BILL_OF_ENTRY_NO_", pStrBillOfEntry, DbType.String, ParameterDirection.Input);
            return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public string ValSaveEmployeeIssue(Mix_IssRet_MasterProperty pClsProperty)
        {

            Request Request = new Request();
            Request.CommandText = "Mix_Emp_IssRet_ValSave";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            if (DRow == null)
            {
                return "";
            }

            string Str = Val.ToString(DRow["MSG"]);

            DRow = null;
            return Str;
        }

        public double ValSaveEmployeeLoss(Mix_IssRet_MasterProperty pClsProperty)
        {

            Request Request = new Request();
            Request.CommandText = "Mix_Emp_IssRet_ValLoss";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            if (DRow == null)
            {
                return 0;
            }

            return Val.Val(DRow["TOTAL_CARAT"]);
        }


        public DataRow ValCheckSieveWiseBalance(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.CommandText = "MIX_Dept_IssRet_Stk_BySieve";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataRow ValCheckClarityWiseBalance(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.CommandText = "MIX_Dept_IssRet_Stk_ByClarity";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataRow ValEmpRecCheckSieveWiseBalance(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.CommandText = "Mix_Emp_IssRet_Stk_BySieve";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

            return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }


        #endregion

        #region Operation

        #region Department Issue Return

        public DataTable GetDeptJanged(Mix_IssRet_MasterProperty pClsProperty)
        {
            //  ClearDeptRec();
            Request Request = new Request();
            DataTable tdt = new DataTable();
            Request.CommandText = "DEPT_ISSRET_GETJANGED";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, tdt, Request);
            return tdt;  // Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_IssRet_Detail, Request, "");
        }

        //public DataTable GetDeptJangedMaster(int pIntCompanyCode,int pIntBranchCode,int pIntLocationCode)
        //{
        //    ClearDeptRec();
        //    Request Request = new Request();
        //    Request.CommandText = "Mix_Dept_IssRet_GetJangedMast";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Request.AddParams("COMPANY_CODE_", pIntCompanyCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", pIntBranchCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);            
        //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_Janged_Master, Request, "");
        //    return DS.Tables[BLL.TPV.Table.Mix_Dept_Janged_Master];
        //}

        //public DataTable BMGetDeptJangedMaster(int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode)
        //{
        //    ClearDeptRec();
        //    Request Request = new Request();
        //    Request.CommandText = "BM_Mix_Dept_IssRet_GetJanged";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Request.AddParams("COMPANY_CODE_", pIntCompanyCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", pIntBranchCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_Janged_Master, Request, "");
        //    return DS.Tables[BLL.TPV.Table.Mix_Dept_Janged_Master];
        //}

        //public void GetDeptIssueDetail(Mix_IssRet_MasterProperty pClsProperty, string pStrIssueType)
        //{
        //    ClearDeptRec();

        //    if (pStrIssueType == "DEPARTMENT")
        //    {
        //        //Request Request = new Request();
        //        //Request.CommandText = "Mix_Dept_IssRet_GetDetail";
        //        //Request.CommandType = CommandType.StoredProcedure;
        //        //Request.REF_CUR_OUT = 2;
        //        //Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        //Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
        //        //Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);


        //        //Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_IssRet_Detail, Request, "");

        //        //foreach (DataRow DRow in DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail].Rows)
        //        //{
        //        //    string StrSql = " Department_Code = '" + DRow["DEPARTMENT_CODE"] + "' AND SIEVE_Code = '" + DRow["SIEVE_CODE"] + "' ";
        //        //    DataRow[] UDROW = DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail + "1"].Select(StrSql);

        //        //    if (UDROW.Length != 0)
        //        //    {
        //        //        DRow["ISSUE_PCS"] = UDROW[0]["ISSUE_PCS"];
        //        //        DRow["ISSUE_CARAT"] = UDROW[0]["ISSUE_CARAT"];
        //        //    }
        //        //}
        //        //DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail].AcceptChanges();

        //    }
        //    else if (pStrIssueType == "CLARITY")
        //    {
        //        //Request Request = new Request();
        //        //Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_GetDet_Clarity;            
        //        //Request.CommandType = CommandType.StoredProcedure;
        //        //Request.REF_CUR_OUT = 2;
        //        //Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        //Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
        //        //Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        //Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //        //Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_IssRet_Detail, Request, "");

        //        //foreach (DataRow DRow in DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail].Rows)
        //        //{
        //        //    string StrSql = " CLARITY_Code = '" + DRow["CLARITY_CODE"] + "' AND SIEVE_Code = '" + DRow["SIEVE_CODE"] + "' ";
        //        //    DataRow[] UDROW = DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail + "1"].Select(StrSql);

        //        //    if (UDROW.Length != 0)
        //        //    {
        //        //        DRow["ISSUE_PCS"] = UDROW[0]["ISSUE_PCS"];
        //        //        DRow["ISSUE_CARAT"] = UDROW[0]["ISSUE_CARAT"];
        //        //    }
        //        //}
        //        //DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail].AcceptChanges();
        //    }
        //}

        public DataRow GetDeptBalance(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "DEPT_ISSRET_DEPTBALANCE";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);

            return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            //string StrResult = Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //return Val.Val(StrResult);
        }

        public DataRow GetDeptBalanceOutside(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "Mix_Dept_IssRet_OutBalance";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);

            return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            //string StrResult = Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //return Val.Val(StrResult);
        }

        //public DataTable GetDeptCellDetails(Mix_IssRet_MasterProperty pClsProperty)
        //{
        //    //DataTable DTab = new DataTable(BLL.TPV.Table.Temp);

        //    //Request Request = new Request();
        //    //Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_GetCellDetail;
        //    //Request.CommandType = CommandType.StoredProcedure;
        //    //Request.AddParams("FROM_DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);

        //    //Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);

        //    //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);

        //    //Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
        //    //return DTab;
        //}

        public int UpdateDept(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "Mix_Dept_IssRet_Update";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("OPE_", pClsProperty.Ope, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("JANGED_SRNO_", pClsProperty.Janged_SrNo, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("LOSS_PCS_", pClsProperty.Loss_Pcs, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("CARAT_PLUS_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
            Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);

            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        //public DataTable GetEmpCellDetIss(Mix_IssRet_MasterProperty pClsProperty)
        //{
        //DataTable DTab = new DataTable(BLL.TPV.Table.Temp);

        //Request Request = new Request();
        //Request.CommandText = BLL.TPV.SProc.Mix_Emp_IssRet_GetCellDetIss;
        //Request.CommandType = CommandType.StoredProcedure;
        //Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);

        //Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);

        //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);

        //Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

        //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
        //    return DTab;
        //}

        //public DataTable GetEmpCellDetRec(Mix_IssRet_MasterProperty pClsProperty)
        //{
        //    //DataTable DTab = new DataTable(BLL.TPV.Table.Temp);

        //Request Request = new Request();
        //Request.CommandText = BLL.TPV.SProc.Mix_Emp_IssRet_GetCellDetRec;
        //Request.CommandType = CommandType.StoredProcedure;
        //Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);

        //Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);

        //Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //Request.AddParams("SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
        //Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
        //    return DTab;
        //}

        public DataRow GetEmpRetBalance(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "Dept_IssRet_EmpRecBalance";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@JANGED_NO_", pClsProperty.Janged_No, DbType.String, ParameterDirection.Input);

            return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public int SaveDepartmentReceive(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "DEPT_ISSRET_Pending_SAVE";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Janged_No_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Department_Code_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Receive_Employee_Code_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Receive_Computer_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Recv_Janged_No_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);

            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        }


        //public Mix_IssRet_MasterProperty SaveDepartmentIssueManual(Mix_IssRet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.CommandText = "Dept_IssRet_SaveIssue";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Janged_No_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Location_Code_", pClsProperty.From_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", pClsProperty.From_Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", pClsProperty.From_Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //    // Add By Khushbu 14/03/2014 /////////
        //    // Add By Vipul 04/04/2014

        //    Request.AddParams("MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("OUT_JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Output);
        //    Request.AddParams("OUT_SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Output);

        //    ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    //pClsProperty.Janged_No = Val.ToInt64(AL[0]);
        //    pClsProperty.SrNo = Val.ToInt64(AL[1]);
        //    pClsProperty.Janged_Date = pClsProperty.Janged_Date;



        //    return pClsProperty;
        //}
       

        public Mix_IssRet_MasterProperty SaveDepartmentTransfer(Mix_IssRet_MasterProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
        {
            Request Request = new Request();
            Request.CommandText = "Dept_Transfer_Save";  // "Dept_IssRet_SaveIssue";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Janged_No_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            //   Request.AddParams("@SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            //   Request.AddParams("@Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SrNo_", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Clarity_Code_", pClsProperty.CLV_CLARITY_CODE, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Shape_Code_", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Color_Code_", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@MSize_Code_", pClsProperty.MSize_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
            //   Request.AddParams("@Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SFlg_", pClsProperty.SFLG, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@Machine_Code_", pClsProperty.Machine_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            //    Request.AddParams("@From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int64, ParameterDirection.Input);
            //    Request.AddParams("@To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RR_Pcs_", pClsProperty.RR_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
            Request.AddParams("@THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

            Request.AddParams("@COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int64, ParameterDirection.Input);

            //Request.AddParams("@PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

            Request.AddParams("@OUT_JANGED_NO_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Output);
            Request.AddParams("@OUT_SRNO_", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Output);
            Request.AddParams("@OUT_MST_ID_", pClsProperty.Rough_SrNo, DbType.Int64, ParameterDirection.Output);
            
            DataTable DTAB = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    pClsProperty.Janged_No = Convert.ToInt64(DTAB.Rows[0][0]);
                    pClsProperty.SrNo = Convert.ToInt64(DTAB.Rows[0][1]);
                    pClsProperty.Rough_SrNo = Convert.ToInt64(DTAB.Rows[0][2]);
                    pClsProperty.Janged_Date = pClsProperty.Janged_Date;
                    //return Convert.ToString(DTAB.Rows[0][0]);
                }
            }

            //ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //pClsProperty.Janged_No = Val.ToInt64(AL[0]);
            //pClsProperty.SrNo = Val.ToInt64(AL[1]);
            //pClsProperty.Rough_SrNo = Val.ToInt64(AL[2]);
            //pClsProperty.Janged_Date = pClsProperty.Janged_Date;
            //AL = null;

            //DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //if (DRow == null)
            //{
            //    return null;
            //}
            //pClsProperty.Janged_No = Val.ToInt64(DRow["JANGED_NO"]);
            //pClsProperty.SrNo = Val.ToInt64(DRow["SRNO"]);
            //pClsProperty.Janged_Date = pClsProperty.Janged_Date;
            //DRow = null;

            return pClsProperty;
        }

        public int SaveIssueToOutsideWithTranMngt(ArrayList pALPacket, ArrayList pALIssueReturn)
        {
            //Ope = new InterfaceLayer();
            int IntJangedNo = 0;
            //int IntRecCount = 0;
            //try
            //{

            //    #region Packet Master Save Is Repairing

            //    foreach (Packet_MasterProperty PktProperty in pALPacket)
            //    {

            //        Request Request = new Request();
            //        Request.AddParams("ROUGH_NAME_", PktProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("PROCESS_CODE_", PktProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("PACKET_NO_", PktProperty.Packet_No, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("BARCODE_", PktProperty.Barcode, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("SHAPE_CODE_", PktProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("CLARITY_CODE_", PktProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);

            //        // Start Haresh On 10-12-2013
            //        Request.AddParams("DEPARTMENT_CODE_", PktProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
            //        // End Haresh

            //        Request.AddParams("COLOR_CODE_", PktProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("MSIZE_CODE_", PktProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("ISSUE_PCS_", PktProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("ISSUE_CARAT_", PktProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("ROUGH_TYPE_CODE_", PktProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("CUT_CODE_", PktProperty.Cut_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("POLISH_CODE_", PktProperty.Polish_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("SYMMETRY_CODE_", PktProperty.Symmetry_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("FLUORESCENCE_CODE_", PktProperty.Fluorescence_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("SIEVE_CODE_", PktProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("KAPAN_NO_", PktProperty.Kapan_No, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("EXP_PER_", PktProperty.EXP_Per, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("EXP_BY_", PktProperty.EXP_By, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("EXP_PER_CODE_", PktProperty.EXP_Per_Code, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("DM_PER_", PktProperty.DM_Per, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("DM_BY_", PktProperty.DM_By, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("HEIGHT_", PktProperty.Height, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("WIDTH_", PktProperty.Width, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("DEPTH_", PktProperty.Depth, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("MAX_DIA_", PktProperty.Max_Dia, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("MIN_DIA_", PktProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("JANGED_NO_", PktProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("ENTRY_DATE_", PktProperty.Entry_Date, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("ENTRY_TIME_", PktProperty.Entry_Time, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("REMARK_", PktProperty.Remark, DbType.String, ParameterDirection.Input);

            //        Request.AddParams("COMP_NO_", PktProperty.Comp_No, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("STOCK_FLAG_", PktProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("CLV_CLARITY_CODE_", PktProperty.Clv_Clarity_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("MFG_CLARITY_CODE_", PktProperty.Mfg_Clarity_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("RR_PCS_", PktProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("RR_CARAT_", PktProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("RATE_", PktProperty.Rate, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("AMOUNT_", PktProperty.Amount, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("LOCATION_CODE_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

            //        Request.AddParams("ROUGH_RATE_DATE_", PktProperty.ROUGH_RATE_DATE, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("POLISH_CP_DATE_", PktProperty.POLISH_CP_DATE, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("BANCKMARK_DATE_", PktProperty.BANCKMARK_DATE, DbType.String, ParameterDirection.Input);

            //        Request.AddParams("POINTER_", PktProperty.Pointer, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("ISSUE_TYPE_", PktProperty.Issue_Type, DbType.String, ParameterDirection.Input);

            //        Request.CommandText = BLL.TPV.SProc.Packet_Master_Save;
            //        Request.CommandType = CommandType.StoredProcedure;
            //        Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, IntRecCount == 0 ? DLL.GlobalDec.EnumTran.Start : DLL.GlobalDec.EnumTran.Continue);
            //        IntRecCount++;
            //    }

            //    #endregion

            //    foreach (Mix_IssRet_MasterProperty pClsProperty in pALIssueReturn)
            //    {

            //        #region Save In Mix Dept Issret Detail Table

            //        Request Request = new Request();
            //        Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_SaveIssue;
            //        Request.CommandType = CommandType.StoredProcedure;

            //        Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            //        Request.AddParams("Janged_No_", IntJangedNo, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            //        Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
            //        Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

            //        // Add By Khushbu 14/03/2014 /////////
            //        // Add By Vipul 04/04/2014

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

            //        Request.AddParams("FROM_MANAGER_CODE_", pClsProperty.From_Manager_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("TO_MANAGER_CODE_", pClsProperty.To_Manager_Code, DbType.Int32, ParameterDirection.Input);

            //        Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
            //        Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

            //        ArrayList AL = new ArrayList();

            //        AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, IntRecCount == 0 ? DLL.GlobalDec.EnumTran.Start : DLL.GlobalDec.EnumTran.Continue);

            //        IntJangedNo = Val.ToInt64(AL[0]);
            //        pClsProperty.Janged_No = Val.ToInt64(AL[0]);
            //        pClsProperty.SrNo = Val.ToInt64(AL[1]);
            //        pClsProperty.Janged_Date = pClsProperty.Janged_Date;

            //        AL = null;

            //        if (pClsProperty.SrNo == 0)
            //        {
            //            Ope.Rollback(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName); 
            //            break;                        
            //        }

            //        #endregion

            //        #region Save In Issrec_Janged Table

            //        // SAVE IN TRANSACTION TABLE

            //        Request = new Request();
            //        Request.CommandText = BLL.TPV.SProc.IssRec_Janged_Save;
            //        Request.CommandType = CommandType.StoredProcedure;

            //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("TRN_ID_", pClsProperty.Trn_ID, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            //        Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);

            //        Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);

            //        Request.AddParams("FINANCIAL_YEAR_", pClsProperty.Financial_Year, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);

            //        Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);

            //        Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);

            //        Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("ISSUE_PCS_", pClsProperty.Janged_Issue_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("ISSUE_CARAT_", pClsProperty.Janged_Issue_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("READY_PCS_", pClsProperty.Janged_Ready_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("READY_CARAT_", pClsProperty.Janged_Ready_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("RR_PCS_", pClsProperty.Janged_RR_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("RR_CARAT_", pClsProperty.Janged_RR_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("CONSUME_PCS_", pClsProperty.Janged_Consume_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("CONSUME_CARAT_", pClsProperty.Janged_Consume_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("CANCEL_PCS_", pClsProperty.Janged_Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("CANCEL_CARAT_", pClsProperty.Janged_Cancel_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("SAW_PCS_", pClsProperty.Janged_Saw_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("SAW_CARAT_", pClsProperty.Janged_Saw_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("LOSS_PCS_", pClsProperty.Janged_Loss_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("LOSS_CARAT_", pClsProperty.Janged_Loss_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("LOST_PCS_", pClsProperty.Janged_Lost_Pcs, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("LOST_CARAT_", pClsProperty.Janged_Lost_Carat, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

            //        Request.AddParams("LABOUR_CODE_", pClsProperty.Labour_Code, DbType.Int64, ParameterDirection.Input);
            //        Request.AddParams("LABOUR_TYPE_", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("LABOUR_CRITERIA_", pClsProperty.Labour_Criteria, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("LABOUR_RATE_", pClsProperty.Labour_Rate, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("LABOUR_AMOUNT_", pClsProperty.Labour_Amount, DbType.Double, ParameterDirection.Input);
            //        Request.AddParams("MFG_TYPE_", pClsProperty.MFG_Type, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("RECEIPT_DATE_", pClsProperty.Receipt_Date, DbType.Date, ParameterDirection.Input);
            //        Request.AddParams("RECEIPT_TIME_", pClsProperty.Receipt_Time, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("PROCESS_GROUP_CODE_", pClsProperty.Process_Group_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("COMP_PROCESS_CODE_", pClsProperty.Comp_Process_Code, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("ISSUE_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            //        Request.AddParams("ISSUE_TIME_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("JANGED_PROCESS_CODE_", pClsProperty.Janged_Process_Code, DbType.Int32, ParameterDirection.Input);
            //        Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
            //        Request.AddParams("EXP_PER_", pClsProperty.EXP_PER, DbType.Double, ParameterDirection.Input);
            //        /*ADD BY HARESH ON 24-05-2014*/

            //        Request.AddParams("DM_PER_", pClsProperty.DM_PER, DbType.Double, ParameterDirection.Input);
            //        /*--------------*/

            //        Request.AddParams("MAINBARCODE_", pClsProperty.MAINBARCODE, DbType.String, ParameterDirection.Input);

            //        /*ADD BY HARESH ON 22-08-2014 FOR FACTORY I WEIGHT FOR POLISH RECEIPT MDB FILE OF HEAD OFFICE RECEIVE*/

            //        Request.AddParams("FACTORY_I_WT_", pClsProperty.FACTORY_I_WT, DbType.Double, ParameterDirection.Input);
            //        /*-----------------*/

            //        Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, DLL.GlobalDec.EnumTran.Continue);

            //        #endregion

            //        IntRecCount++;
            //    }

            //    Ope.Commit(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
            //}
            //catch (Exception EX)
            //{
            //    Ope.Rollback(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
            //    System.Windows.Forms.MessageBox.Show(EX.Message);
            //}

            return IntJangedNo;

        }

        //public int SaveReturnToOutsideWithTranMngt(ArrayList pALIssueReturnPolish, ArrayList pALIssueReturnRR)
        //{
        //Ope = new InterfaceLayer();
        //int IntJangedNo = 0;
        //int IntRRJangedNo = 0;

        //int IntRecCount = 0;
        //try
        //{
        //    // Save Polish Data
        //    foreach (Mix_IssRet_MasterProperty pClsProperty in pALIssueReturnPolish)
        //    {
        //        #region Save In Mix Dept Issret Detail Table

        //        Request Request = new Request();
        //        Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_SaveIssue;
        //        Request.CommandType = CommandType.StoredProcedure;

        //        Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("Janged_No_", IntJangedNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //        // Add By Khushbu 14/03/2014 /////////
        //        // Add By Vipul 04/04/2014

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

        //        Request.AddParams("FROM_MANAGER_CODE_", pClsProperty.From_Manager_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TO_MANAGER_CODE_", pClsProperty.To_Manager_Code, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
        //        Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

        //        ArrayList AL = new ArrayList();

        //        AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, IntRecCount == 0 ? DLL.GlobalDec.EnumTran.Start : DLL.GlobalDec.EnumTran.Continue);

        //        IntJangedNo = Val.ToInt64(AL[0]);
        //        pClsProperty.Janged_No = Val.ToInt64(AL[0]);
        //        pClsProperty.SrNo = Val.ToInt64(AL[1]);
        //        pClsProperty.Janged_Date = pClsProperty.Janged_Date;

        //        AL = null;

        //        if (pClsProperty.SrNo == 0)
        //        {
        //            Ope.Rollback(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
        //            break;
        //        }

        //        #endregion

        //        #region Save In Issrec_Janged Table

        //        // SAVE IN TRANSACTION TABLE

        //        Request = new Request();
        //        Request.CommandText = BLL.TPV.SProc.IssRec_Janged_Save;
        //        Request.CommandType = CommandType.StoredProcedure;

        //        Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("TRN_ID_", pClsProperty.Trn_ID, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("FINANCIAL_YEAR_", pClsProperty.Financial_Year, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_PCS_", pClsProperty.Janged_Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_CARAT_", pClsProperty.Janged_Issue_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("READY_PCS_", pClsProperty.Janged_Ready_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("READY_CARAT_", pClsProperty.Janged_Ready_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("RR_PCS_", pClsProperty.Janged_RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("RR_CARAT_", pClsProperty.Janged_RR_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("CONSUME_PCS_", pClsProperty.Janged_Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("CONSUME_CARAT_", pClsProperty.Janged_Consume_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("CANCEL_PCS_", pClsProperty.Janged_Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("CANCEL_CARAT_", pClsProperty.Janged_Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("SAW_PCS_", pClsProperty.Janged_Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SAW_CARAT_", pClsProperty.Janged_Saw_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("LOSS_PCS_", pClsProperty.Janged_Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("LOSS_CARAT_", pClsProperty.Janged_Loss_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("LOST_PCS_", pClsProperty.Janged_Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("LOST_CARAT_", pClsProperty.Janged_Lost_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("LABOUR_CODE_", pClsProperty.Labour_Code, DbType.Int64, ParameterDirection.Input);
        //        Request.AddParams("LABOUR_TYPE_", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("LABOUR_CRITERIA_", pClsProperty.Labour_Criteria, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("LABOUR_RATE_", pClsProperty.Labour_Rate, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("LABOUR_AMOUNT_", pClsProperty.Labour_Amount, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("MFG_TYPE_", pClsProperty.MFG_Type, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("RECEIPT_DATE_", pClsProperty.Receipt_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("RECEIPT_TIME_", pClsProperty.Receipt_Time, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("PROCESS_GROUP_CODE_", pClsProperty.Process_Group_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMP_PROCESS_CODE_", pClsProperty.Comp_Process_Code, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("ISSUE_TIME_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("JANGED_PROCESS_CODE_", pClsProperty.Janged_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("EXP_PER_", pClsProperty.EXP_PER, DbType.Double, ParameterDirection.Input);
        //        /*ADD BY HARESH ON 24-05-2014*/

        //        Request.AddParams("DM_PER_", pClsProperty.DM_PER, DbType.Double, ParameterDirection.Input);
        //        /*--------------*/

        //        Request.AddParams("MAINBARCODE_", pClsProperty.MAINBARCODE, DbType.String, ParameterDirection.Input);

        //        /*ADD BY HARESH ON 22-08-2014 FOR FACTORY I WEIGHT FOR POLISH RECEIPT MDB FILE OF HEAD OFFICE RECEIVE*/

        //        Request.AddParams("FACTORY_I_WT_", pClsProperty.FACTORY_I_WT, DbType.Double, ParameterDirection.Input);
        //        /*-----------------*/

        //        Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, DLL.GlobalDec.EnumTran.Continue);

        //        #endregion

        //        IntRecCount++;
        //    }

        //    // Loop For RR Janged Save


        //    IntRRJangedNo = 0;
        //    foreach (Mix_IssRet_MasterProperty pClsProperty in pALIssueReturnRR)
        //    {
        //        #region Save In RR Mix Dept Issret Detail Table

        //        Request Request = new Request();
        //        Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_SaveIssue;
        //        Request.CommandType = CommandType.StoredProcedure;

        //        Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("Janged_No_", IntRRJangedNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //        // Add By Khushbu 14/03/2014 /////////
        //        // Add By Vipul 04/04/2014

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

        //        Request.AddParams("FROM_MANAGER_CODE_", pClsProperty.From_Manager_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TO_MANAGER_CODE_", pClsProperty.To_Manager_Code, DbType.Int32, ParameterDirection.Input);

        //        Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
        //        Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

        //        ArrayList AL = new ArrayList();

        //        AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, IntRecCount == 0 ? DLL.GlobalDec.EnumTran.Start : DLL.GlobalDec.EnumTran.Continue);

        //        IntRRJangedNo = Val.ToInt64(AL[0]);
        //        pClsProperty.Janged_No = Val.ToInt64(AL[0]);
        //        pClsProperty.SrNo = Val.ToInt64(AL[1]);
        //        pClsProperty.Janged_Date = pClsProperty.Janged_Date;

        //        AL = null;

        //        if (pClsProperty.SrNo == 0)
        //        {
        //            Ope.Rollback(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
        //            break;
        //        }

        //        #endregion

        //        #region Save In Issrec_Janged Table

        //        // SAVE IN TRANSACTION TABLE

        //        if (pClsProperty.Janged_Consume_Carat == 0)
        //        {
        //            Request = new Request();
        //            Request.CommandText = BLL.TPV.SProc.IssRec_Janged_Save;
        //            Request.CommandType = CommandType.StoredProcedure;

        //            Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("TRN_ID_", pClsProperty.Trn_ID, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //            Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);

        //            Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);

        //            Request.AddParams("FINANCIAL_YEAR_", pClsProperty.Financial_Year, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);

        //            Request.AddParams("FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);

        //            Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);

        //            Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("ISSUE_PCS_", pClsProperty.Janged_Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("ISSUE_CARAT_", pClsProperty.Janged_Issue_Carat, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("READY_PCS_", pClsProperty.Janged_Ready_Pcs, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("READY_CARAT_", pClsProperty.Janged_Ready_Carat, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("RR_PCS_", pClsProperty.Janged_RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("RR_CARAT_", pClsProperty.Janged_RR_Carat, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("CONSUME_PCS_", pClsProperty.Janged_Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("CONSUME_CARAT_", pClsProperty.Janged_Consume_Carat, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("CANCEL_PCS_", pClsProperty.Janged_Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("CANCEL_CARAT_", pClsProperty.Janged_Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("SAW_PCS_", pClsProperty.Janged_Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("SAW_CARAT_", pClsProperty.Janged_Saw_Carat, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("LOSS_PCS_", pClsProperty.Janged_Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("LOSS_CARAT_", pClsProperty.Janged_Loss_Carat, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("LOST_PCS_", pClsProperty.Janged_Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("LOST_CARAT_", pClsProperty.Janged_Lost_Carat, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

        //            Request.AddParams("LABOUR_CODE_", pClsProperty.Labour_Code, DbType.Int64, ParameterDirection.Input);
        //            Request.AddParams("LABOUR_TYPE_", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("LABOUR_CRITERIA_", pClsProperty.Labour_Criteria, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("LABOUR_RATE_", pClsProperty.Labour_Rate, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("LABOUR_AMOUNT_", pClsProperty.Labour_Amount, DbType.Double, ParameterDirection.Input);
        //            Request.AddParams("MFG_TYPE_", pClsProperty.MFG_Type, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("RECEIPT_DATE_", pClsProperty.Receipt_Date, DbType.Date, ParameterDirection.Input);
        //            Request.AddParams("RECEIPT_TIME_", pClsProperty.Receipt_Time, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("PROCESS_GROUP_CODE_", pClsProperty.Process_Group_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("COMP_PROCESS_CODE_", pClsProperty.Comp_Process_Code, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("ISSUE_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //            Request.AddParams("ISSUE_TIME_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("JANGED_PROCESS_CODE_", pClsProperty.Janged_Process_Code, DbType.Int32, ParameterDirection.Input);
        //            Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //            Request.AddParams("EXP_PER_", pClsProperty.EXP_PER, DbType.Double, ParameterDirection.Input);
        //            /*ADD BY HARESH ON 24-05-2014*/

        //            Request.AddParams("DM_PER_", pClsProperty.DM_PER, DbType.Double, ParameterDirection.Input);
        //            /*--------------*/

        //            Request.AddParams("MAINBARCODE_", pClsProperty.MAINBARCODE, DbType.String, ParameterDirection.Input);

        //            /*ADD BY HARESH ON 22-08-2014 FOR FACTORY I WEIGHT FOR POLISH RECEIPT MDB FILE OF HEAD OFFICE RECEIVE*/

        //            Request.AddParams("FACTORY_I_WT_", pClsProperty.FACTORY_I_WT, DbType.Double, ParameterDirection.Input);
        //            /*-----------------*/

        //            Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, DLL.GlobalDec.EnumTran.Continue);

        //        }

        //        Request = new Request();
        //        Request.CommandText = BLL.TPV.SProc.IssRec_Janged_UpdateRRJanged + "N";
        //        Request.CommandType = CommandType.StoredProcedure;

        //        Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

        //        Request.AddParams("RR_JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("RR_JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("RR_SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);

        //        Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, DLL.GlobalDec.EnumTran.Continue);

        //        #endregion

        //        IntRecCount++;
        //    }

        //    Ope.Commit(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
        //}
        //catch (Exception EX)
        //{
        //    Ope.Rollback(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName);
        //    System.Windows.Forms.MessageBox.Show(EX.Message);
        //}

        //return IntJangedNo == 0 ? IntRRJangedNo : IntJangedNo;

        // }

        public Mix_IssRet_MasterProperty SaveDepartmentIssueNew(Mix_IssRet_MasterProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
        {
            Request Request = new Request();
            Request.CommandText = "Dept_IssRet_SaveIssue";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Janged_No_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SrNo_", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Shape_Code_", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Color_Code_", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
           // Request.AddParams("@MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
           // Request.AddParams("@Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SFlg_", pClsProperty.SFLG, DbType.Int64, ParameterDirection.Input);
           // Request.AddParams("@Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int64, ParameterDirection.Input);
           // Request.AddParams("@To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
           // Request.AddParams("@To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RR_Pcs_", pClsProperty.RR_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
            Request.AddParams("@THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

            // Add By Khushbu 14/03/2014 /////////
            // Add By Vipul 04/04/2014

            //Request.AddParams("@MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
            //Request.AddParams("@TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

            //Request.AddParams("@GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

            //Request.AddParams("@PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

            //Request.AddParams("@FROM_MANAGER_CODE_", pClsProperty.From_Manager_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@TO_MANAGER_CODE_", pClsProperty.To_Manager_Code, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("@OUT_JANGED_NO_", pClsProperty.Out_Janged_No, DbType.Int64, ParameterDirection.Output);
            Request.AddParams("@OUT_SRNO_", pClsProperty.Out_SrNo, DbType.Int64, ParameterDirection.Output);

            DataTable DTAB = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    pClsProperty.SrNo = Val.ToInt64(DTAB.Rows[0][1]);
                    pClsProperty.Janged_Date = pClsProperty.Janged_Date;
                }
            }

            //ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, pEnum);

            ////pClsProperty.Janged_No = Val.ToInt64(AL[0]);
            //pClsProperty.SrNo = Val.ToInt64(AL[1]);
            //pClsProperty.Janged_Date = pClsProperty.Janged_Date;

            //AL = null;

            return pClsProperty;
        }



        //public Mix_IssRet_MasterProperty SaveDepartmentIssue(Mix_IssRet_MasterProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
        //{

        //    Request Request = new Request();
        //    Request.CommandText = "Mix_Dept_IssRet_SaveIssue";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Janged_No_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //    // Add By Khushbu 14/03/2014 /////////
        //    // Add By Vipul 04/04/2014

        //    Request.AddParams("MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("FROM_MANAGER_CODE_", pClsProperty.From_Manager_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TO_MANAGER_CODE_", pClsProperty.To_Manager_Code, DbType.Int32, ParameterDirection.Input);

        //    ////ADD BY HARESH ON 04-08-2015 FOR BORIVALI
        //    //Request.AddParams("CP_CODE_", pClsProperty.CP_Code, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("TEAM_CODE_", pClsProperty.Team_Code, DbType.Int32, ParameterDirection.Input);
        //    //Request.AddParams("GROUP_CODE_", pClsProperty.Group_Code, DbType.Int32, ParameterDirection.Input);
        //    ////END AS

        //    Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
        //    Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

        //    ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, pEnum);

        //    // pClsProperty.Janged_No = Val.ToInt64(AL[0]);
        //    pClsProperty.SrNo = Val.ToInt64(AL[1]);
        //    pClsProperty.Janged_Date = pClsProperty.Janged_Date;

        //    AL = null;


        //    // When Main Cabin Is There Then Save to B Part
        //    if (pClsProperty.From_Department_Code == 8 || pClsProperty.To_Department_Code == 8)
        //    {
        //        Request = new Request();
        //        Request.CommandText = "Mix_Dept_IssRet_SaveIssue";
        //        Request.CommandType = CommandType.StoredProcedure;

        //        Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("Janged_No_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //        Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //        Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //        Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //        // Add By Khushbu 14/03/2014 /////////
        //        // Add By Vipul 04/04/2014

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


        //        Request.AddParams("FROM_MANAGER_CODE_", pClsProperty.From_Manager_Code, DbType.Int32, ParameterDirection.Input);
        //        Request.AddParams("TO_MANAGER_CODE_", pClsProperty.To_Manager_Code, DbType.Int32, ParameterDirection.Input);


        //        Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
        //        Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

        //        Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request, pEnum);
        //    }


        //    return pClsProperty;
        //}


        //public Mix_IssRet_MasterProperty SaveDepartmentIssueForSale(Mix_IssRet_MasterProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
        //{

        //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
        //{
        //    Request Request = new Request();
        //    Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_SaveIssue;
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Janged_No_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //    // Add By Khushbu 14/03/2014 /////////
        //    // Add By Vipul 04/04/2014

        //    Request.AddParams("MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
        //    Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

        //    ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, pEnum);

        //    pClsProperty.Janged_No = Val.ToInt64(AL[0]);
        //    pClsProperty.SrNo = Val.ToInt64(AL[1]);
        //    pClsProperty.Janged_Date = pClsProperty.Janged_Date;

        //    AL = null;

        //    // When Main Cabin Is There Then Save to B Part

        //    Request = new Request();
        //    Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_SaveIssue;
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Janged_No_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //    // Add By Khushbu 14/03/2014 /////////
        //    // Add By Vipul 04/04/2014

        //    Request.AddParams("MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
        //    Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

        //    Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request, pEnum);

        //    return pClsProperty;
        //}
        //else
        //{
        //    Request Request = new Request();
        //    Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_SaveIssue + "SALE";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Janged_No_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //    // Add By Khushbu 14/03/2014 /////////
        //    // Add By Vipul 04/04/2014

        //    Request.AddParams("MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
        //    Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

        //    Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request, pEnum);

        //    return pClsProperty;
        //}

        //}

        //public Mix_IssRet_MasterProperty SaveDepartmentIssueFromTransfer(Mix_IssRet_MasterProperty pClsProperty,string pStrOpetation)
        //{
        //if (pStrOpetation == "ROUGH TO MIX")
        //{

        //    Request Request = new Request();
        //    Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_SaveIssue + "SALE";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Janged_No_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //    // Add By Khushbu 14/03/2014 /////////
        //    // Add By Vipul 04/04/2014

        //    Request.AddParams("MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
        //    Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

        //    Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);

        //    return pClsProperty;
        //}
        //else
        //{
        //    Request Request = new Request();
        //    Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_SaveIssue;
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Janged_No_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //    // Add By Khushbu 14/03/2014 /////////
        //    // Add By Vipul 04/04/2014

        //    Request.AddParams("MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
        //    Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

        //    ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    pClsProperty.Janged_No = Val.ToInt64(AL[0]);
        //    pClsProperty.SrNo = Val.ToInt64(AL[1]);
        //    pClsProperty.Janged_Date = pClsProperty.Janged_Date;

        //    AL = null;

        //    // When Main Cabin Is There Then Save to B Part
        //    if (BLL.GlobalDec.gEmployeeProperty.Location_Code !=39)
        //    {

        //    Request = new Request();
        //    Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_SaveIssue;
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("Janged_Date_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Janged_No_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SEmployee_Code_", pClsProperty.SEmployee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Entry_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Entry_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SrNo_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Department_Code_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Department_Code_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Shape_Code_", pClsProperty.Shape_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Color_Code_", pClsProperty.Color_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("MSize_Code_", pClsProperty.MSize_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Issue_Employee_Code_", pClsProperty.Issue_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Computer_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Pcs_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Carat_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Receive_Date_", pClsProperty.Receive_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("Receive_Time_", pClsProperty.Receive_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Receive_Employee_Code_", pClsProperty.Receive_Empoloyee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Receive_Computer_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("SFlg_", pClsProperty.SFLG, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Code_", pClsProperty.From_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Party_Location_Code_", pClsProperty.From_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("From_Sub_Party_Code_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Code_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Party_Location_Code_", pClsProperty.To_Party_Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("To_Sub_Party_Code_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Issue_Janged_No_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RR_Pcs_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Saw_Pcs_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Saw_Carat_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Consume_Pcs_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Consume_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Pcs_", pClsProperty.Cancel_Pcs, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("Cancel_Carat_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_", pClsProperty.Through, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ROUGH_SRNO_", pClsProperty.Rough_SrNo, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("IS_POLISH_RR_FLAG_", pClsProperty.IS_Polish_RR_Flag, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("TRF_JANGED_NO_", pClsProperty.Trf_Janged_No, DbType.String, ParameterDirection.Input);

        //    // Add By Khushbu 14/03/2014 /////////
        //    // Add By Vipul 04/04/2014

        //    Request.AddParams("MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

        //    Request.AddParams("GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("OUT_JANGED_NO_", 0, DbType.Int32, ParameterDirection.Output);
        //    Request.AddParams("OUT_SRNO_", 0, DbType.Int32, ParameterDirection.Output);

        //    Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
        //    }
        //    return pClsProperty;
        //}

        //}

        //public void ClearDeptRec()
        //{
        //    //if (DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail] != null)
        //    //{
        //    //    DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail].Rows.Clear();
        //    //    DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail].Columns.Clear();
        //    //}
        //    //if (DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail+"1"] != null)
        //    //{
        //    //    DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail + "1"].Rows.Clear();
        //    //    DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_Detail + "1"].Columns.Clear();
        //    //}
        //}

        #endregion

        // #region Employee Issue

        // public void GetEmpIssueDetail(Mix_IssRet_MasterProperty pClsProperty, string pStrIssueType)
        // {
        //     ClearEmpIss();

        //     if (pStrIssueType == "EMPLOYEE")
        //     {
        //         Request Request = new Request();
        //         Request.CommandText = BLL.TPV.SProc.Mix_Emp_IssRet_GetIssueData;
        //         Request.CommandType = CommandType.StoredProcedure;
        //         Request.REF_CUR_OUT = 2;

        //         Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //         Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //         Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

        //         Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Emp_IssRet_DetailIssue, Request, "");

        //         foreach (DataRow DRow in DS.Tables[BLL.TPV.Table.Mix_Emp_IssRet_DetailIssue].Rows)
        //         {
        //             string StrSql = " Employee_Code = '" + DRow["EMPLOYEE_CODE"] + "' AND SIEVE_Code = '" + DRow["SIEVE_CODE"] + "' ";
        //             DataRow[] UDROW = DS.Tables[BLL.TPV.Table.Mix_Emp_IssRet_DetailIssue + "1"].Select(StrSql);

        //             if (UDROW.Length != 0)
        //             {
        //                 DRow["ISSUE_PCS"] = UDROW[0]["ISSUE_PCS"];
        //                 DRow["ISSUE_CARAT"] = UDROW[0]["ISSUE_CARAT"];
        //             }
        //         }
        //         DS.Tables[BLL.TPV.Table.Mix_Emp_IssRet_DetailIssue].AcceptChanges();

        //     }
        //     else if (pStrIssueType == "CLARITY")
        //     {
        //         Request Request = new Request();
        //         Request.CommandText = BLL.TPV.SProc.Mix_Emp_IssRet_GetIss_Clarity;
        //         Request.CommandType = CommandType.StoredProcedure;
        //         Request.REF_CUR_OUT = 2;

        //         Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //         Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
        //         Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //         Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Emp_IssRet_DetailIssue, Request, "");


        //         foreach (DataRow DRow in DS.Tables[BLL.TPV.Table.Mix_Emp_IssRet_DetailIssue].Rows)
        //         {
        //             string StrSql = " Clarity_Code = '" + DRow["CLARITY_CODE"].ToString() + "' AND SIEVE_Code = '" + DRow["SIEVE_CODE"].ToString() + "' ";
        //             DataRow[] UDROW = DS.Tables[BLL.TPV.Table.Mix_Emp_IssRet_DetailIssue + "1"].Select(StrSql);

        //             if (UDROW.Length != 0)
        //             {
        //                 DRow["ISSUE_PCS"] = UDROW[0]["ISSUE_PCS"];
        //                 DRow["ISSUE_CARAT"] = UDROW[0]["ISSUE_CARAT"];
        //             }
        //         }
        //         DS.Tables[BLL.TPV.Table.Mix_Emp_IssRet_DetailIssue].AcceptChanges();

        //     }



        // }

        //public Mix_IssRet_MasterProperty SaveEmployeeIssueRecMix(Mix_IssRet_MasterProperty pClsProperty)
        //{
        //    Request Request = new Request();
        //    Request.CommandText = "Emp_IssRet_Save";
        //    Request.CommandType = CommandType.StoredProcedure;

        //    Request.AddParams("@SrNo_", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Department_Code_", pClsProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
        //    //Request.AddParams("Main_Employee_Code_", pClsProperty.Main_Employee_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Employee_Code_", pClsProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Clarity_Code_", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Shape_Code_", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Color_Code_", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@MSize_Code_", pClsProperty.MSize_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Issue_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@Issue_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@User_Employee_Code_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Computer_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@TYPE_", "I", DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Machine_Code_", pClsProperty.Machine_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@RR_Pcs_", pClsProperty.RR_Pcs, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
        //    //Request.AddParams("@HH_", pClsProperty.HH, DbType.Int64, ParameterDirection.Input);
        //    //Request.AddParams("@MM_", pClsProperty.MM, DbType.Int64, ParameterDirection.Input);
        //    //Request.AddParams("@Saw_Type_", pClsProperty.Saw_Type, DbType.String, ParameterDirection.Input);
        //    //Request.AddParams("@Shift_Code_", pClsProperty.Shift_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@IS_MIXING_", pClsProperty.IS_Mixing, DbType.Int64, ParameterDirection.Input);

        //    Request.AddParams("@OUT_SRNO_", 0, DbType.Int64, ParameterDirection.Output);

        //    ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    pClsProperty.SrNo = Val.ToInt64(AL[0]);
        //    pClsProperty.Janged_Date = pClsProperty.Janged_Date;

        //    AL = null;

        //    //DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    //if (DRow == null)
        //    //{
        //    //    return null;
        //    //}
        //    //pClsProperty.SrNo = Val.ToInt64(DRow["SRNO"]);

        //    //DRow = null;

        //    return pClsProperty;
        //}

        // public int UpdateEmp(Mix_IssRet_MasterProperty pClsProperty)
        // {
        //     Request Request = new Request();
        //     Request.CommandText = BLL.TPV.SProc.Mix_Emp_IssRet_Update;
        //     Request.CommandType = CommandType.StoredProcedure;
        //     Request.AddParams("OPE_", pClsProperty.Ope, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("LOSS_PCS_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("CARAT_PLUS_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);

        //     return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        // }

        // #endregion

        // #region Employee Reveive

        // public void GetEmpReceiveDetail(Mix_IssRet_MasterProperty pClsProperty, string pStrReceiveType)
        // {

        //     ClearEmpRec();

        //     if (pStrReceiveType == "PROCESS")
        //     {
        //         Request Request = new Request();
        //         Request.CommandText = BLL.TPV.SProc.Mix_Emp_IssRet_GetReceiveData;
        //         Request.CommandType = CommandType.StoredProcedure;
        //         Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //         Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
        //         Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //         Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Emp_IssRet_DetailReceive, Request, "");
        //     }
        //     else if (pStrReceiveType == "CLARITY")
        //     {
        //         Request Request = new Request();
        //         Request.CommandText = BLL.TPV.SProc.Mix_Emp_IssRet_GetRec_Clarity;
        //         Request.CommandType = CommandType.StoredProcedure;
        //         Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //         Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
        //         Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //         Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //         Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Emp_IssRet_DetailReceive, Request, "");
        //     }
        // }

        // public void ClearEmpRec()
        // {
        //     if (DS.Tables[BLL.TPV.Table.Mix_Emp_IssRet_DetailReceive] != null)
        //     {
        //         DS.Tables[BLL.TPV.Table.Mix_Emp_IssRet_DetailReceive].Rows.Clear();
        //         DS.Tables[BLL.TPV.Table.Mix_Emp_IssRet_DetailReceive].Columns.Clear();
        //     }
        // }

        public Mix_IssRet_MasterProperty SaveEmployeeIssueRecMix(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "Emp_IssRet_Save";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@SrNo_", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Department_Code_", pClsProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@From_Process_Code_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@To_Process_Code_", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            //       Request.AddParams("Main_Employee_Code_", pClsProperty.Main_Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Employee_Code_", pClsProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Sieve_Code_", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Clarity_Code_", pClsProperty.CLV_CLARITY_CODE, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@MFG_Clarity_Code_", pClsProperty.MFG_Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Shape_Code_", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Color_Code_", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
            //    Request.AddParams("@MSize_Code_", pClsProperty.MSize_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Issue_Pcs_", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Issue_Carat_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Loss_Pcs_", pClsProperty.Loss_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Loss_Carat_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Lost_Pcs_", pClsProperty.Lost_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Lost_Carat_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Carat_Plus_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@Issue_Date_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            //       Request.AddParams("@Issue_Time_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("@User_Employee_Code_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Computer_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            //            Request.AddParams("@TYPE_", "R", DbType.String, ParameterDirection.Input);
            Request.AddParams("@TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);

            Request.AddParams("@Rough_Type_Code_", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            //    Request.AddParams("@Machine_Code_", pClsProperty.Machine_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RR_Pcs_", pClsProperty.RR_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RR_Carat_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
            //    Request.AddParams("@HH_", pClsProperty.HH, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("@MM_", pClsProperty.MM, DbType.Int32, ParameterDirection.Input);
            //    Request.AddParams("@Saw_Type_", pClsProperty.Saw_Type, DbType.String, ParameterDirection.Input);
            //    Request.AddParams("@Shift_Code_", pClsProperty.Shift_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Location_Code_", BLL.GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            //     Request.AddParams("@Reason_OF_RR_", pClsProperty.Reason_OF_RR, DbType.String, ParameterDirection.Input);
            //      Request.AddParams("@REMARK_CODE_", pClsProperty.Remark_Code, DbType.Int32, ParameterDirection.Input);
            //      Request.AddParams("@IS_BALANCE_", pClsProperty.IS_Balance, DbType.Int32, ParameterDirection.Input);
            //     Request.AddParams("@SUB_PROCESS_CODE_", pClsProperty.Sub_Process_Code, DbType.Int32, ParameterDirection.Input);
            //      Request.AddParams("@START_TIME_", pClsProperty.Start_Time, DbType.String, ParameterDirection.Input);
            //       Request.AddParams("@END_TIME_", pClsProperty.End_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("@CONSUME_Pcs_", pClsProperty.Consume_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CONSUME_Carat_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@IS_MIXING_", pClsProperty.IS_Mixing, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@OUT_SRNO_", 0, DbType.Int64, ParameterDirection.Output);

            DataTable DTAB = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    pClsProperty.SrNo = Convert.ToInt64(DTAB.Rows[0][0]);
                    pClsProperty.Janged_Date = pClsProperty.Janged_Date;
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

            //ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //if (AL == null || AL.Count == 0)
            //{
            //    pClsProperty.SrNo = 0;
            //}
            //else
            //{
            //    pClsProperty.SrNo = Val.ToInt64(AL[0]);
            //    pClsProperty.Janged_Date = pClsProperty.Janged_Date;
            //}
            //AL = null;

            //DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //if (DRow == null)
            //{
            //    return null;
            //}
            //pClsProperty.SrNo = Val.ToInt64(DRow["SRNO"]);

            //DRow = null;

            return pClsProperty;
        }

        public int PolishAssortment_Save(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandType = CommandType.StoredProcedure;
            Request.CommandText = "PolishAssortment_Save";
            Request.AddParams("@PolAssotID_", pClsProperty.PolishAss_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@NotingDate_", pClsProperty.Noting_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Rough_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@EntryUserID_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ComputerIP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Remarks_", pClsProperty.Remark_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SizeID_", pClsProperty.Size_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ClarityID_", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ColorID_", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Carats_", pClsProperty.Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@ERCarats_", pClsProperty.ERCarat, DbType.Double, ParameterDirection.Input);
            int IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            return IntRes;
        }


        // public int UpdatePacketMasterDetail(Mix_IssRet_MasterProperty pClsProperty) // Khushbu 26/02/2014
        // {
        //     Request Request = new Request();
        //     Request.CommandText = BLL.TPV.SProc.Packet_Master_Update + "N";
        //     Request.CommandType = CommandType.StoredProcedure;

        //     Request.AddParams("Rough_Name_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("Barcode_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

        //     // Add By Vipul 04/04/2014

        //     Request.AddParams("MEASUREMENT1_", pClsProperty.MEASUREMENT1, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("MEASUREMENT2_", pClsProperty.MEASUREMENT2, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("MEASUREMENT3_", pClsProperty.MEASUREMENT3, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("GIRDLE_PER_", pClsProperty.GIRDLE_PER, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("CROWN_ANGLE_", pClsProperty.CROWN_ANGLE, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("CROWN_HEIGHT_", pClsProperty.CROWN_HEIGHT, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("PAVILION_ANGLE_", pClsProperty.PAVILION_ANGLE, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("PAVILION_HEIGHT_", pClsProperty.PAVILION_HEIGHT, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("SALE1_", pClsProperty.SALE1, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("TOTAL_SALE1_", pClsProperty.TOTAL_SALE1, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("TABLE_SIZE_", pClsProperty.TABLE_SIZE, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("STARLENGTH_", pClsProperty.STARLENGTH, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("LOWERHALF_", pClsProperty.LOWERHALF, DbType.Double, ParameterDirection.Input);
        //     Request.AddParams("TOTAL_DEPTH_", pClsProperty.TOTAL_DEPTH, DbType.Double, ParameterDirection.Input);

        //     Request.AddParams("GIRDLE_CODE_", pClsProperty.GIRDLE_CODE, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("POLISH_SHAPE_CODE_", pClsProperty.POLISH_SHAPE_CODE, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("POLISH_COLOR_CODE_", pClsProperty.POLISH_COLOR_CODE, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("POLISH_CLARITY_CODE_", pClsProperty.POLISH_CLARITY_CODE, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("POLISH_CUT_CODE_", pClsProperty.POLISH_CUT_CODE, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("POLISH_POL_CODE_", pClsProperty.POLISH_POL_CODE, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("POLISH_SYM_CODE_", pClsProperty.POLISH_SYM_CODE, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("POLISH_FL_CODE_", pClsProperty.POLISH_FL_CODE, DbType.Int32, ParameterDirection.Input);

        //     Request.AddParams("PRODUCTION_STATUS_", pClsProperty.PRODUCTION_STATUS, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FANTACY_PARCEL_NAME_", pClsProperty.FANTACY_PARCEL_NAME, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FANTACY_PARCEL_TYPE_", pClsProperty.FANTACY_PARCEL_TYPE, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FANTACY_DOC_NO_", pClsProperty.FANTACY_DOC_NO, DbType.String, ParameterDirection.Input);


        //     return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        // }

        // #endregion

        // #region Janged View

        // #region Janged View

        ///* public void GetJangedView(Mix_IssRet_MasterProperty pClsProperty)
        // {
        //     if (DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master] != null)
        //     {
        //         DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master].Rows.Clear();
        //     }
        //     if (DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master + "1"] != null)
        //     {
        //         DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master + "1"].Rows.Clear();
        //     }

        //     Request Request = new Request();
        //     Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_JangedView;
        //     Request.CommandType = CommandType.StoredProcedure;
        //     Request.REF_CUR_OUT = 2;

        //     Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FROM_JANGED_NO_", pClsProperty.From_Janged_No, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_JANGED_NO_", pClsProperty.To_Janged_No, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("FROM_JANGED_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
        //     Request.AddParams("TO_JANGED_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
        //     Request.AddParams("JANGED_STATUS_", pClsProperty.Janged_Status, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("JANGED_TYPE_", pClsProperty.Janged_Type, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //     //Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //     //Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

        //     Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_IssRet_View_Master, Request, "");

        //     DataColumn[] MasterColumns = null;
        //     DataColumn[] DetailColumns = null;

        //     MasterColumns = new DataColumn[] {
        //     DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master].Columns["JANGED_DATE"],
        //     DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master].Columns["JANGED_NO"]};

        //     //Create the datacolumn array 
        //     DetailColumns = new DataColumn[] {

        //     DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master+"1"].Columns["JANGED_DATE"],
        //     DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master+"1"].Columns["JANGED_NO"]};

        //     DataRelation r = new DataRelation("Janged Detail", MasterColumns, DetailColumns, false);

        //     foreach (DataRelation Relation in DS.Relations)
        //     {
        //         if (Relation.RelationName.ToUpper() == r.RelationName.ToUpper())
        //         {
        //             DS.Relations.Remove(Relation);
        //             DS.AcceptChanges();
        //             break;
        //         }
        //     }

        //     DS.Relations.Add(r);
        // }*/

        // public void GetJangedViewSummary(Mix_IssRet_MasterProperty pClsProperty)
        // {
        //     if (DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master] != null)
        //     {
        //         DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Master].Rows.Clear();
        //     } 

        //     if (DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Detail] != null)
        //     {
        //         DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Detail].Rows.Clear();
        //     }

        //     Request Request = new Request();
        //     Request.CommandText = BLL.TPV.SProc.IssRec_JangedView_Summary;
        //     Request.CommandType = CommandType.StoredProcedure;

        //     Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FROM_JANGED_NO_", pClsProperty.From_Janged_No, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_JANGED_NO_", pClsProperty.To_Janged_No, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("FROM_JANGED_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
        //     Request.AddParams("TO_JANGED_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
        //     Request.AddParams("JANGED_STATUS_", pClsProperty.Janged_Status, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("JANGED_TYPE_", pClsProperty.Janged_Type, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
        //     //Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //     //Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

        //     Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_IssRet_View_Master, Request, "");
        // }
        // public void GetJangedViewDetail(int pIntJangedNo,string pStrJangedDate)
        // {
        //     if (DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Detail] != null)
        //     {
        //         DS.Tables[BLL.TPV.Table.Mix_Dept_IssRet_View_Detail].Rows.Clear();
        //     }
        //     Request Request = new Request();
        //     Request.CommandText = BLL.TPV.SProc.IssRec_JangedView_Detail;
        //     Request.CommandType = CommandType.StoredProcedure;
        //     Request.AddParams("JANGED_NO_", pIntJangedNo, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("JANGED_DATE_", pStrJangedDate, DbType.Date, ParameterDirection.Input);            
        //     Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_IssRet_View_Detail, Request, "");
        // }



        // public DataTable GetJangedNo(Mix_IssRet_MasterProperty pClsProperty)
        // {

        //     DataTable DTabJanged = new DataTable();

        //     Request Request = new Request();
        //     Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_JangedNo;
        //     Request.CommandType = CommandType.StoredProcedure;
        //     //Request.REF_CUR_OUT = 2;

        //     Request.AddParams("FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Multi, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("FROM_JANGED_NO_", pClsProperty.From_Janged_No, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_JANGED_NO_", pClsProperty.To_Janged_No, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("FROM_JANGED_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
        //     Request.AddParams("TO_JANGED_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
        //     Request.AddParams("JANGED_STATUS_", pClsProperty.Janged_Status, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("JANGED_TYPE_", pClsProperty.Janged_Type, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("THROUGH_BY_", pClsProperty.Through_By, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("LOCATION_CODE_", pClsProperty.Location_Code, DbType.Int32, ParameterDirection.Input);

        //     Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabJanged, Request, "");
        //     return DTabJanged;
        // }



        // //public void GetViewDetail(Mix_IssRet_MasterProperty pClsProperty)
        // //{
        // //    Request Request = new Request();
        // //    Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_ViewDetail;
        // //    Request.CommandType = CommandType.StoredProcedure;
        // //    Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        // //    Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        // //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_IssRet_View_Detail, Request, "");
        // //}


        // #endregion


        // //public void GetViewDetail(Mix_IssRet_MasterProperty pClsProperty)
        // //{
        // //    Request Request = new Request();
        // //    Request.CommandText = BLL.TPV.SProc.Mix_Dept_IssRet_ViewDetail;
        // //    Request.CommandType = CommandType.StoredProcedure;
        // //    Request.AddParams("JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
        // //    Request.AddParams("JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
        // //    Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, BLL.TPV.Table.Mix_Dept_IssRet_View_Detail, Request, "");
        // //}


        // #endregion

        // #region Factory


        // public DataRow GetMfgIssueDetail(Mix_IssRet_MasterProperty pClsProperty)
        // {
        //     // ClearDeptRec();
        //     Request Request = new Request();
        //     Request.CommandText = BLL.TPV.SProc.Mix_Issue_Mfg_Detail;
        //     Request.CommandType = CommandType.StoredProcedure;

        //     Request.AddParams("FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int32, ParameterDirection.Input);

        //     Request.AddParams("ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //     Request.AddParams("STOCK_FLAG_", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);

        //     Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //     Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);

        //     DataRow Drow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //     return Drow;
        // }

        // #endregion

        #endregion

        public DataTable GetDeptIssueTranDetail(Mix_IssRet_MasterProperty pClsProperty)
        {
            DataTable tdt = new DataTable();
            //ClearDeptRec();
            Request Request = new Request();
            Request.CommandText = "Dept_IssTran_GetDetail";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            // Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@DEPARTMENT_CODE", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@SRNO", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);
            //   Request.AddParams("@COLOR_CODE", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
            //    Request.AddParams("@CLARITY_CODE", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            //    Request.AddParams("@SIEVE_CODE", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            //     Request.AddParams("@BARCODE", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);

            //Request.AddParams("FROM_DATE_", pClsProperty.From_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("TO_DATE_", pClsProperty.To_Date, DbType.Date, ParameterDirection.Input);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, tdt, Request);
            return tdt;
        }

        public DataTable GetEmpIssueDetail(Mix_IssRet_MasterProperty pClsProperty)
        {
            DataTable tdt = new DataTable();
            Request Request = new Request();
            Request.CommandText = "Emp_IssRet_GetDataForRec";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ENTRY_DATE_", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SRNO_", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COLOR_CODE_", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, tdt, Request);
            return tdt;
            // Ope.GetDataSet(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DS, "Dept_IssTran_GetDetail", Request, "");
        }

        public DataTable GetIssueJabgedForPrint(Mix_IssRet_MasterProperty pClsProperty, string pStrType)
        {
            DataTable DTab = new DataTable("Temp");
            Request Request = new Request();
            Request.CommandType = CommandType.StoredProcedure;

            if (pStrType == "S" || pStrType == "D" || pStrType == "LAB_RATE")
            {
                Request.AddParams("ISSUE_JANGED_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
                Request.AddParams("FROM_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
                Request.AddParams("TO_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);
                Request.AddParams("TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int64, ParameterDirection.Input);
                Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            }
            else if (pStrType == "ADD")
            {
                Request.AddParams("LEDGER_CODE_", pClsProperty.To_Party_Code, DbType.Int32, ParameterDirection.Input);
            }

            if (pStrType == "S")
            {
                Request.CommandText = "RP_Mix_Clv_To_OutSide_Sum";
            }
            else if (pStrType == "D")
            {
                Request.CommandText = "RP_Mix_Clv_To_OutSide_Det";
            }
            else if (pStrType == "LAB_RATE")
            {
                Request.CommandText = "Rp_Mix_HO_Receieve_Labour_Rate";
            }
            else if (pStrType == "ADD")
            {
                Request.CommandText = "RP_LEDGER_ADDRESS";
            }
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int SaveIssRetJangedDetail(Mix_IssRet_MasterProperty pClsProperty, DLL.GlobalDec.EnumTran pEnum = DLL.GlobalDec.EnumTran.WithCommit)
        {
            Request Request = new Request();
            Request.CommandText = "IssRec_Janged_Save";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@TRN_ID_", pClsProperty.Trn_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);           
            Request.AddParams("@JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@JANGED_NO_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@SRNO_", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@FINANCIAL_YEAR_", pClsProperty.Financial_Year, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@FROM_SUB_PARTY_CODE_", pClsProperty.From_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@TO_SUB_PARTY_CODE_", pClsProperty.To_Sub_Party_Code, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("@TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);

            Request.AddParams("@ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@READY_PCS_", pClsProperty.Receive_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@READY_CARAT_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RR_PCS_", pClsProperty.RR_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CONSUME_PCS_", pClsProperty.Consume_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CONSUME_CARAT_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CANCEL_PCS_", pClsProperty.Cancel_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CANCEL_CARAT_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SAW_PCS_", pClsProperty.Saw_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SAW_CARAT_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LOSS_PCS_", pClsProperty.Loss_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@USER_EMPLOYEE_CODE_", GlobalDec.gEmployeeProperty.Employee_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@LABOUR_CODE_", pClsProperty.Labour_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@LABOUR_TYPE_", pClsProperty.Labour_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LABOUR_CRITERIA_", pClsProperty.Labour_Criteria, DbType.String, ParameterDirection.Input);
            Request.AddParams("@LABOUR_RATE_", pClsProperty.Labour_Rate, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LABOUR_AMOUNT_", pClsProperty.Labour_Amount, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@MFG_TYPE_", pClsProperty.MFG_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RETURN_JANGED_NO_", pClsProperty.Return_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RECEIPT_DATE_", pClsProperty.Receipt_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@RECEIPT_TIME_", pClsProperty.Receipt_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE_", BLL.GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE_", BLL.GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
            //Request.AddParams("@PROCESS_GROUP_CODE_", pClsProperty.Process_Group_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@COMP_PROCESS_CODE_", pClsProperty.Comp_Process_Code, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ISSUE_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@ISSUE_TIME_", pClsProperty.Entry_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("@JANGED_PROCESS_CODE_", pClsProperty.Janged_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_JANGED_NO_", pClsProperty.Rough_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@EXP_PER_", pClsProperty.EXP_PER, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@DM_PER_", pClsProperty.DM_PER, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@MAINBARCODE_", pClsProperty.MAINBARCODE, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FACTORY_I_WT_", pClsProperty.FACTORY_I_WT, DbType.Double, ParameterDirection.Input);

            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request, pEnum);
        }

        public string ValIssueToOutSideValsave(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "MIX_Issue_To_Outside_ValSave";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@ROUGH_NAME", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_PARTY_CODE", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE", pClsProperty.To_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_SUB_PARTY_CODE", pClsProperty.From_Sub_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_SUB_PARTY_CODE", pClsProperty.To_Sub_Party_Code, DbType.Int64, ParameterDirection.Input);

            //Request.AddParams("OUT_STR_", "", DbType.String, ParameterDirection.Output);

            DataTable DTAB = new DataTable();
            string StrRes = "";
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    StrRes = Convert.ToString(DTAB.Rows[0][0]);
                }
            }

            //ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //string StrRes = Val.ToString(AL[0]);
            //AL = null;
            return StrRes;

            //return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetMfgIssueDetail(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "Issue_Mfg_Detail";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@FROM_DEPARTMENT_CODE", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_DEPARTMENT_CODE", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);

        //    Request.AddParams("@ENTRY_DATE", pClsProperty.Entry_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@STOCK_FLAG", pClsProperty.Stock_Flag, DbType.String, ParameterDirection.Input);

            Request.AddParams("@LOCATION_CODE", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COMPANY_CODE", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BRANCH_CODE", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);

            DataTable DTABT = new DataTable();
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTABT, Request);
            return DTABT;
        }

        public DataTable tGetData(string Date_)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.AddParams("@tdate", Date_, DbType.Date, ParameterDirection.Input);

            Request.CommandText = "IssRetJangedListPrint";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public int UpdateIssRetJangedRRDetail(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.CommandText = "IssRec_Janged_UpdateRRJanged";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@JANGED_NO_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SRNO_", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);

            Request.AddParams("@RR_JANGED_DATE_", pClsProperty.RR_Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@RR_JANGED_NO_", pClsProperty.RR_Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@RR_SRNO_", pClsProperty.RR_SrNo, DbType.Int64, ParameterDirection.Input);

            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetTranscationData(Mix_IssRet_MasterProperty pClsProperty)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "Update_Transcation_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@OPE_", pClsProperty.Ope, DbType.String, ParameterDirection.Input);

            Request.AddParams("@FROM_COMPANY_CODE_", pClsProperty.From_Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_COMPANY_CODE_", pClsProperty.To_Company_Code, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@FROM_BRANCH_CODE_", pClsProperty.From_Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_BRANCH_CODE_", pClsProperty.To_Branch_Code, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);

           // Request.AddParams("MAIN_EMPLOYEE_CODE_", pClsProperty.Main_Employee_Code, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("EMPLOYEE_CODE_", pClsProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@FROM_DATE_", pClsProperty.From_Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_DATE_", pClsProperty.To_Entry_Date, DbType.Date, ParameterDirection.Input);


            Request.AddParams("@FROM_MEMO_NO_", pClsProperty.From_Memo_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_MEMO_NO_", pClsProperty.To_Memo_No, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@FROM_ISSUE_PCS_", pClsProperty.From_Pcs, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_ISSUE_PCS_", pClsProperty.To_Pcs, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@FROM_ISSUE_CARAT_", pClsProperty.From_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_ISSUE_CARAT_", pClsProperty.To_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@FROM_LOSS_CARAT_", pClsProperty.From_Loss_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_LOSS_CARAT_", pClsProperty.To_Loss_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@FROM_LOST_CARAT_", pClsProperty.From_Lost_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_LOST_CARAT_", pClsProperty.To_Lost_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@FROM_CARAT_PLUS_", pClsProperty.From_Carat_Plus, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@TO_CARAT_PLUS_", pClsProperty.To_Carat_Plus, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@FROM_JANGED_NO_", pClsProperty.From_Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_JANGED_NO_", pClsProperty.To_Janged_No, DbType.Int64, ParameterDirection.Input);

            Request.AddParams("@FROM_JANGED_DATE_", pClsProperty.From_Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_JANGED_DATE_", pClsProperty.To_Janged_Date, DbType.Date, ParameterDirection.Input);

            Request.AddParams("@SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COLOR_CODE_", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLV_CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ISSUE_JANGED_NO_", pClsProperty.Issue_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RECEIVE_JANGED_NO_", pClsProperty.Receive_Janged_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            return DTab;
        }

        //#region Update Transcation

        public int UpdateTranscation(Mix_IssRet_MasterProperty pClsProperty, Packet_MasterProperty pClsPacketProperty)
        {
            int IntRes = 0;
            Request Request = new Request();
            Request.CommandText = "Update_Transcation_Save";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@OPE_", pClsProperty.Ope, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BILL_OF_ENTRY_NO_", pClsProperty.Bill_Of_Entry_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@SRNO_", pClsProperty.SrNo, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@JANGED_NO_", pClsProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@FROM_DEPARTMENT_CODE_", pClsProperty.From_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_DEPARTMENT_CODE_", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PROCESS_CODE_", pClsProperty.To_Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@NEW_BARCODE_", pClsProperty.New_Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LOSS_PCS_", pClsProperty.Loss_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CARAT_PLUS_", pClsProperty.Carat_Plus, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CONSUME_PCS_", pClsProperty.Consume_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CONSUME_CARAT_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RR_PCS_", pClsProperty.RR_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SAW_PCS_", pClsProperty.Saw_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@SAW_CARAT_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CANCEL_PCS_", pClsProperty.Cancel_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@CANCEL_CARAT_", pClsProperty.Cancel_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@PACKET_JANGED_NO_", pClsPacketProperty.Janged_No, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SHAPE_CODE_", pClsProperty.Shape_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@COLOR_CODE_", pClsProperty.Color_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SIEVE_CODE_", pClsProperty.Sieve_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@CLV_CLARITY_CODE_", pClsProperty.Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@MFG_CLARITY_CODE_", pClsProperty.MFG_Clarity_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@EXP_PER_", pClsPacketProperty.EXP_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@EXP_BY_", pClsPacketProperty.EXP_By, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@DM_PER_", pClsPacketProperty.DM_Per, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@DM_BY_", pClsPacketProperty.DM_By, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@HEIGHT_", pClsPacketProperty.Height, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@WIDTH_", pClsPacketProperty.Width, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@DEPTH_", pClsPacketProperty.Depth, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@MAX_DIA_", pClsPacketProperty.Max_Dia, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@MIN_DIA_", pClsPacketProperty.Min_Dia, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@COMP_NO_", pClsPacketProperty.Comp_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@IS_MERGE_", pClsPacketProperty.IS_Merge, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@STOCK_FLAG_", pClsPacketProperty.Stock_Flag, DbType.String, ParameterDirection.Input);
            Request.AddParams("@TYPE_", pClsProperty.Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RECEIVE_PCS_", pClsProperty.Receive_Pcs, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@RECEIVE_CARAT_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);
            Request.AddParams("@ROUGH_TYPE_CODE_", pClsProperty.Rough_Type_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@SFLG_", pClsProperty.SFLG, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ISSUE_DATE_", pClsProperty.Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@ISSUE_EMPLOYEE_CODE_", pClsProperty.Issue_Empoloyee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ISSUE_COMPUTER_IP_", pClsProperty.Issue_Computer_IP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@RECEIVE_DATE_", pClsProperty.Receipt_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@RECEIVE_EMPLOYEE_CODE_", pClsProperty.Receive_Empoloyee_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@RECEIVE_COMPUTER_IP_", pClsProperty.Receive_Computer_IP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_LOCATION_CODE_", pClsProperty.From_Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_LOCATION_CODE_", pClsProperty.To_Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_COMPANY_CODE_", pClsProperty.From_Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_COMPANY_CODE_", pClsProperty.To_Company_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_BRANCH_CODE_", pClsProperty.From_Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_BRANCH_CODE_", pClsProperty.To_Branch_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@FROM_PARTY_CODE_", pClsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_PARTY_CODE_", pClsProperty.To_Party_Code, DbType.Int64, ParameterDirection.Input);

            IntRes = Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            return IntRes;
        }

        public int UpdateRoughNameInBarcode(string pStrBarcode, string pStrRoughName)
        {
            Request Request = new Request();
            Request.CommandText = "Barcode_RoughName_Update";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("@BARCODE_", pStrBarcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pStrRoughName, DbType.String, ParameterDirection.Input);

            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetSummryData(Mix_IssRet_MasterProperty pClsProperty)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@OPE_", "SUM", DbType.String, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@FROM_DATE_", pClsProperty.From_Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_DATE_", pClsProperty.To_Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.CommandText = "Polish_Dept_Trf_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetDetailData(Mix_IssRet_MasterProperty pClsProperty)
        {
            if (DTabDetail != null)
            {
                DTabDetail.Rows.Clear();
            }
            Request Request = new Request();
            Request.AddParams("@OPE_", "DET", DbType.String, ParameterDirection.Input);
            Request.AddParams("@DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);
            //Request.AddParams("@MFG_TYPE_", pClsProperty.MFG_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@REF_NO_", pClsProperty.Ref_No, DbType.String, ParameterDirection.Input); //Add By Khushbu 22/02/2014
            Request.AddParams("@FROM_DATE_", pClsProperty.From_Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@TO_DATE_", pClsProperty.To_Entry_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.CommandText = "Polish_Dept_Trf_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTabDetail, Request, "");
            return DTabDetail;
        }

        public int Update(Mix_IssRet_MasterProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@ROUGH_NAME_", pClsProperty.Rough_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@BARCODE_", pClsProperty.Barcode, DbType.String, ParameterDirection.Input);

            Request.AddParams("@ISSUE_PCS_", pClsProperty.Issue_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_CARAT_", pClsProperty.Issue_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@READY_PCS_", pClsProperty.Receive_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@READY_CARAT_", pClsProperty.Receive_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@RR_PCS_", pClsProperty.RR_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RR_CARAT_", pClsProperty.RR_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@CONSUME_PCS_", pClsProperty.Consume_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@CONSUME_CARAT_", pClsProperty.Consume_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@SAW_PCS_", pClsProperty.Saw_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@SAW_CARAT_", pClsProperty.Saw_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@LOSS_PCS_", pClsProperty.Loss_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@LOSS_CARAT_", pClsProperty.Loss_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@LOST_PCS_", pClsProperty.Lost_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@LOST_CARAT_", pClsProperty.Lost_Carat, DbType.Double, ParameterDirection.Input);

            Request.AddParams("@JANGED_NO_", pClsProperty.Janged_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@JANGED_DATE_", pClsProperty.Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@SRNO_", pClsProperty.SrNo, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@JANGED_SRNO_", pClsProperty.Janged_SrNo, DbType.Int32, ParameterDirection.Input);

            //Request.AddParams("@RR_JANGED_NO_", pClsProperty.RR_Janged_No, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@RR_JANGED_DATE_", pClsProperty.RR_Janged_Date, DbType.Date, ParameterDirection.Input);
            //Request.AddParams("@RR_SRNO_", pClsProperty.RR_SrNo, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("@PREV_JANGED_NO_", pClsProperty.Prev_Janged_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@PREV_JANGED_DATE_", pClsProperty.Prev_Janged_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@PREV_JANGED_SRNO_", pClsProperty.Prev_Janged_SrNo, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("@FROM_PROCESS_CODE_", pClsProperty.From_Process_Code, DbType.Int32, ParameterDirection.Input);

            Request.AddParams("@POLISH_UPDATE_EMPLOYEE_CODE_", BLL.GlobalDec.gEmployeeProperty.Employee_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@POLISH_UPDATE_COMPUTER_IP_", GlobalDec.gStrComputerIP, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@LABOUR_AMOUNT_", pClsProperty.Labour_Amount, DbType.Double, ParameterDirection.Input);

            Request.CommandText = "Polish_Dept_Trf_Update";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
    }
}
