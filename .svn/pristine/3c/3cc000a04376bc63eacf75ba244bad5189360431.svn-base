using BLL.PropertyClasses.Master;
using System.Data;
using DLL;
using System;

namespace BLL.FunctionClasses.Master
{
    public class DepartmentMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();

        Validation Val = new Validation();

        public int Save(Department_MasterProperty pClsProperty)
        {
            Request Request = new Request();

            Request.AddParams("@Department_code", pClsProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Department_Name", pClsProperty.Department_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Location_Code", pClsProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Active", pClsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Department_Master_Save"; ;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable GetData()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Department_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable GetData_Search()
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();

            Request.CommandText = "Department_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        private DataRow GetDepartmentSettings(Department_Process_SettingProperty pClsProperty)
        {
            Request Request = new Request();
            Request.AddParams("@Department_Code", pClsProperty.Department_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Process_Code", pClsProperty.Process_Code, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Dept_Proc_Settings_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public Department_Process_SettingProperty GetDepartmentSettings(Int64 pIntDepartmentCode, Int64 pIntProcessCode)
        {
            Department_Process_SettingProperty Property = new Department_Process_SettingProperty();
            Property.Department_Code = pIntDepartmentCode;
            Property.Process_Code = pIntProcessCode;
            DataRow DRow = GetDepartmentSettings(Property);
            if (DRow == null)
            {
                Property.Issue_With_Barcode = 0;
                Property.Issue_With_Shape = 0;
                Property.Issue_With_Color = 0;
                Property.Issue_With_Clarity = 0;
                Property.Issue_With_Loss = 0;
                Property.Issue_With_Lost = 0;
                Property.Issue_With_MSize = 0;
                Property.Issue_With_Machine = 0;
                Property.Issue_With_Carat_Plus = 0;
                Property.Issue_With_Remark = 0;
                Property.Issue_With_SieveCheck = 0;
                Property.Is_Emp_IssRet = 0;

                Property.Return_With_Barcode = 0;
                Property.Return_With_Shape = 0;
                Property.Return_With_Color = 0;
                Property.Return_With_Clarity = 0;
                Property.Return_With_Loss = 0;
                Property.Return_With_Lost = 0;
                Property.Return_With_MSize = 0;
                Property.Return_With_Machine = 0;
                Property.Return_With_Carat_Plus = 0;
                Property.Return_With_Remark = 0;
                Property.Return_With_SieveCheck = 0;
                Property.Return_With_Second_Pcs = 0;
                Property.Return_With_Barcode_Scrap = 0;
                Property.Return_With_RR = 0;
                Property.Return_With_Grade = 0;
                Property.Return_With_Sub_Process = 0;
                Property.IS_ADD_IN_ROUGH_STOCK = 0;
                Property.IS_JOB_WORK_AUTO_CONFIRM = 0;

                Property.Is_Shape_Compulsory = 0; 
            }
            else
            {
                Property.Issue_With_Barcode = Val.ToInt(DRow["ISSUE_WITH_BARCODE"]);
                Property.Issue_With_Shape = Val.ToInt(DRow["ISSUE_WITH_SHAPE"]);
                Property.Issue_With_Color = Val.ToInt(DRow["ISSUE_WITH_COLOR"]);
                Property.Issue_With_Clarity = Val.ToInt(DRow["ISSUE_WITH_CLARITY"]);
                Property.Issue_With_Loss = Val.ToInt(DRow["ISSUE_WITH_LOSS"]);
                Property.Issue_With_Lost = Val.ToInt(DRow["ISSUE_WITH_LOST"]);
                Property.Issue_With_MSize = Val.ToInt(DRow["ISSUE_WITH_MSIZE"]);
                Property.Issue_With_Machine = Val.ToInt(DRow["ISSUE_WITH_MACHINE"]);
                Property.Issue_With_Carat_Plus = Val.ToInt(DRow["ISSUE_WITH_CARAT_PLUS"]);
                Property.Issue_With_Remark = Val.ToInt(DRow["ISSUE_WITH_REMARK"]);
                Property.Issue_With_SieveCheck = Val.ToInt(DRow["ISSUE_WITH_SIEVECHECK"]);
                Property.Is_Emp_IssRet = Val.ToInt(DRow["IS_EMP_ISSRET"]);

                Property.Return_With_Barcode = Val.ToInt(DRow["RETURN_WITH_BARCODE"]);
                Property.Return_With_Shape = Val.ToInt(DRow["RETURN_WITH_SHAPE"]);
                Property.Return_With_Color = Val.ToInt(DRow["RETURN_WITH_COLOR"]);
                Property.Return_With_Clarity = Val.ToInt(DRow["RETURN_WITH_CLARITY"]);
                Property.Return_With_Loss = Val.ToInt(DRow["RETURN_WITH_LOSS"]);
                Property.Return_With_Lost = Val.ToInt(DRow["RETURN_WITH_LOST"]);
                Property.Return_With_MSize = Val.ToInt(DRow["RETURN_WITH_MSIZE"]);
                Property.Return_With_Machine = Val.ToInt(DRow["RETURN_WITH_MACHINE"]);
                Property.Return_With_Carat_Plus = Val.ToInt(DRow["RETURN_WITH_CARAT_PLUS"]);
                Property.Return_With_Remark = Val.ToInt(DRow["RETURN_WITH_REMARK"]);
                Property.Return_With_SieveCheck = Val.ToInt(DRow["RETURN_WITH_SIEVECHECK"]);
                Property.Return_With_Second_Pcs = Val.ToInt(DRow["RETURN_WITH_SECOND_PCS"]);
                Property.Return_With_Barcode_Scrap = Val.ToInt(DRow["RETURN_WITH_BARCODE_SCRAP"]);
                Property.Return_With_RR = Val.ToInt(DRow["RETURN_WITH_RR"]);
                Property.Return_With_Grade = Val.ToInt(DRow["RETURN_WITH_GRADE"]);
                Property.IS_ADD_IN_ROUGH_STOCK = Val.ToInt(DRow["IS_ADD_IN_ROUGH_STOCK"]);
                Property.IS_JOB_WORK_AUTO_CONFIRM = Val.ToInt(DRow["IS_JOB_WORK_AUTO_CONFIRM"]);
                Property.Return_With_Sub_Process = Val.ToInt(DRow["RETURN_WITH_SUB_PROCESS"]);

                Property.Is_Shape_Compulsory = Val.ToInt(DRow["IS_SHAPE_COMPULSORY"]); 

            }
            return Property;
        }

        public int SaveDepartmentSettings(Department_Process_SettingProperty pClsProperty) 
        {
            Request Request = new Request();
            Request.AddParams("@DEPARTMENT_CODE", pClsProperty.Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@TO_DEPARTMENT_CODE", pClsProperty.To_Department_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@PROCESS_CODE", pClsProperty.Process_Code, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_BARCODE", pClsProperty.Issue_With_Barcode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_SHAPE", pClsProperty.Issue_With_Shape, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_CLARITY", pClsProperty.Issue_With_Clarity, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_COLOR", pClsProperty.Issue_With_Color, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_LOSS", pClsProperty.Issue_With_Loss, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_LOST", pClsProperty.Issue_With_Lost, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_MSIZE", pClsProperty.Issue_With_MSize, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_MACHINE", pClsProperty.Issue_With_Machine, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_CARAT_PLUS", pClsProperty.Issue_With_Carat_Plus, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_REMARK", pClsProperty.Issue_With_Remark, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ISSUE_WITH_SIEVECHECK", pClsProperty.Issue_With_SieveCheck, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_EMP_ISSRET", pClsProperty.Is_Emp_IssRet, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_BARCODE", pClsProperty.Return_With_Barcode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_SHAPE", pClsProperty.Return_With_Shape, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_CLARITY", pClsProperty.Return_With_Clarity, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_COLOR", pClsProperty.Return_With_Color, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_LOSS", pClsProperty.Return_With_Loss, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_LOST", pClsProperty.Return_With_Lost, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_MSIZE", pClsProperty.Return_With_MSize, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_MACHINE", pClsProperty.Return_With_Machine, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_CARAT_PLUS", pClsProperty.Return_With_Carat_Plus, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_REMARK", pClsProperty.Return_With_Remark, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_SIEVECHECK", pClsProperty.Return_With_SieveCheck, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_SECOND_PCS", pClsProperty.Return_With_Second_Pcs, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_BARCODE_SCRAP", pClsProperty.Return_With_Barcode_Scrap, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_RR", pClsProperty.Return_With_RR, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_ADD_IN_ROUGH_STOCK", pClsProperty.IS_ADD_IN_ROUGH_STOCK, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_JOB_WORK_AUTO_CONFIRM", pClsProperty.IS_JOB_WORK_AUTO_CONFIRM, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_GRADE", pClsProperty.Return_With_Grade, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@RETURN_WITH_SUB_PROCESS", pClsProperty.Return_With_Sub_Process, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IS_SHAPE_COMPULSORY", pClsProperty.Is_Shape_Compulsory, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Dept_Proc_Settings_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public string ISExists(string DepartmentName, Int64 DepartmentCode)
        {
            Validation Val = new Validation();
            return Val.ToString(Ope.FindText(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, "DEPARTMENT_MASTER", "DEPARTMENT_NAME", "AND DEPARTMENT_NAME = '" + DepartmentName + "' AND NOT DEPARTMENT_CODE =" + DepartmentCode));
        }   
    }
}

