/// Create By Vipul Vankadiya
/// 13-05-2013
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLL;
using System.Data;

namespace BLL.FunctionClasses.Entry
{
    public class MaximumID
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Validation Val = new Validation();

        public string Generate(string pStrIDType,string pStrFinYear)
        {
            Request Request = new Request();

            Request.AddParams("ID_TYPE_", pStrIDType, DbType.String, ParameterDirection.Input);
            Request.AddParams("FIN_YEAR_", pStrFinYear, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Maximum_ID_Generate";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            
        }

        //public Int64 Generate(string pStrIDType)
        //{
        //    Request Request = new Request();

        //    Request.AddParams("ID_TYPE_", pStrIDType, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("ANSWER_", "", DbType.String, ParameterDirection.Output);

        //    Request.CommandText = "Maximum_ID_Generate_BVI";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    System.Collections.ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    if (AL != null && AL.Count != 0 )
        //    {
        //        return Val.ToInt64(AL[0]);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        public string GenerateClvJangedNo(string pStrDate)
        {
            Request Request = new Request();
            DataTable DTAB = new DataTable();
            Request.AddParams("@JANGED_DATE_", pStrDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@OUT_STR_", "", DbType.String, ParameterDirection.Output);

            Request.CommandText = "Maximum_ID_GenerateJangedNo";
            Request.CommandType = CommandType.StoredProcedure;

            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTAB, Request);
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    return Convert.ToString(DTAB.Rows[0][0]);
                }
            }
            return "";
            //System.Collections.ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            //if (AL != null && AL.Count != 0)
            //{
            //    return Val.ToInt64(AL[0]);
            //}
            //else
            //{
            //    return 0;
            //}
        }
    }
}
