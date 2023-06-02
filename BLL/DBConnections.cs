using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DLL;
using System.Security.Cryptography;
using System.Net;
using System.Data.OleDb;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Collections;
using System.Reflection;

namespace BLL
{
    public enum ReturnTypeMode
    {
        DataTable = 0,
        DataRow = 1,
        String = 2
    }

    public class DBConnections
    {

        private static string _ConnectionString;

        public static string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        private static string _ProviderName;

        public static string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }

        private static string _ConnectionDeveloper;

        public static string ConnectionDeveloper
        {
            get { return _ConnectionDeveloper; }
            set { _ConnectionDeveloper = value; }
        }

        private static string _ConnectionStringWeb;

        public static string ConnectionStringWeb
        {
            get { return _ConnectionStringWeb; }
            set { _ConnectionStringWeb = value; }
        }

        private static string _ProviderDeveloper;

        public static string ProviderDeveloper
        {
            get { return _ProviderDeveloper; }
            set { _ProviderDeveloper = value; }
        }

        private static string _ProviderNameWeb;

        public static string ProviderNameWeb
        {
            get { return _ProviderNameWeb; }
            set { _ProviderNameWeb = value; }
        }


        public enum LOCKTYPE
        {
            LOGIN_USER = 1,
            PARCEL_SYSTEM = 2,
            PARCEL_MANUAL = 3,
            ROUGH_SYSTEM = 4
        }

        public static string SecurityKey
        {
            get { return "MARGO"; }
        }



        private static string _gStrDBName;

        public static string gStrDBName
        {
            get { return _gStrDBName; }
            set { _gStrDBName = value; }
        }

        private static string _gStrDBDataSource;

        public static string gStrDBDataSource
        {
            get { return _gStrDBDataSource; }
            set { _gStrDBDataSource = value; }
        }


        private static string _gStrUserName;

        public static string gStrUserName
        {
            get { return _gStrUserName; }
            set { _gStrUserName = value; }
        }

        private static string _gStrPasssword;

        public static string gStrPasssword
        {
            get { return _gStrPasssword; }
            set { _gStrPasssword = value; }
        }

        public static string MailPagesURL
        {
            get
            {
                //return "Data Source=GKC;User ID=DNK;Password=dnk123;"; 
                return System.Configuration.ConfigurationManager.AppSettings["MailPagesURL"].ToString();
            }
        }

        //public static void ConnectionDeveloperifurcation(string pStrConnectionString,string pStrProvider)
        //{
        //        InterfaceLayer Ope = new InterfaceLayer();
        //        Ope.ConnectionBifercation(pStrConnectionString, pStrProvider);
        //        _gStrDBDataSource = Ope.gStrDBDataSource;
        //        _gStrDBName = Ope.gStrDBName;
        //        _gStrDBUserName = Ope.gStrDBUserName;
        //        _gStrDBPassWord = Ope.gStrDBPassWord;
        //}

    }

    public class GlobalDec
    {


        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);


        public static System.Drawing.Color ABColor = System.Drawing.Color.Red;

        public enum SERVERTYPE
        {
            A = 0,
            B = 1
        }
        public enum LEDGEROPENING
        {
            OPENING = 0,
            CLOSING = 1
        }

        private static string _gStrUserName;

        public static string gStrUserName
        {
            get { return _gStrUserName; }
            set { _gStrUserName = value; }
        }



        public static string gStrComputerIP
        {
            get
            {
                string strHostName = "";
                strHostName = System.Net.Dns.GetHostName();

                //IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
                //IPAddress[] addr = ipEntry.AddressList;

                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                foreach (IPAddress a in localIPs)
                {
                    if (a.AddressFamily == AddressFamily.InterNetwork)
                    {
                        strHostName = a.ToString();
                    }
                }
                if (localIPs.Length == 0)
                {
                    return System.Environment.MachineName.ToString();
                }
                else
                {
                    return strHostName;
                }
            }
        }

        private static PropertyClasses.Master.Employee_MasterProperty _gEmployeeProperty = new PropertyClasses.Master.Employee_MasterProperty();

        public static PropertyClasses.Master.Employee_MasterProperty gEmployeeProperty
        {
            get { return _gEmployeeProperty; }
            set { _gEmployeeProperty = value; }
        }

        public static string WebServiceDownloadUrl
        {
            get
            {
                //return "http://192.168.1.55:8081/FileUpload/Storage/";
                return System.Configuration.ConfigurationManager.AppSettings["DownloadURL"].ToString();
            }
        }


        private static string _gFinancialYear;

        public static string gFinancialYear
        {
            get { return _gFinancialYear; }
            set { _gFinancialYear = value; }
        }

        // Add ; Narendra : 01-Apr-2015
        private static string _gFinancialYear_StartDate;

        public static string gFinancialYear_StartDate
        {
            get { return _gFinancialYear_StartDate; }
            set { _gFinancialYear_StartDate = value; }
        }
        private static string _gFinancialYear_EndDate;

        public static string gFinancialYear_EndDate
        {
            get { return _gFinancialYear_EndDate; }
            set { _gFinancialYear_EndDate = value; }
        }
        // End : Narendra : 01-Apr-2015


        public static string gStrMsgTitle
        {
            get { return "MARGO"; }
        }

        public static string gStrPermissionViwMsg
        {
            get { return "You are not authorized to do View operation"; }
        }

        public static string gStrPermissionInsUpdMsg
        {
            get { return "You are not authorized to do Save (Insert-Update) operation"; }
        }

        public static string gStrPermissionDelMsg
        {
            get { return "You are not authorized to do Delete operation"; }
        }

        public static string gStrPermissionPrintMsg
        {
            get { return "You are not authorized to do Print operation"; }
        }

        public static string gStrPermissionEMailMsg
        {
            get { return "You are not authorized to do EMail operation"; }
        }

        public static string gStrPermissionExpMsg
        {
            get { return "You are not authorized to do Export operation"; }
        }

        public static string gStrServerDate
        {
            get
            {

                InterfaceLayer Ope = new InterfaceLayer();

                DataRow DRow = Ope.GetDataRow(DBConnections.ConnectionString, DBConnections.ProviderName, "Dual", "SysDate", "");
                string StrDate = "";
                if (DRow != null)
                {
                    StrDate = DRow[0].ToString();
                }

                Ope = null;
                DRow = null;
                return StrDate;
            }
        }

        public static string gStrServerDate2Days
        {
            get
            {

                InterfaceLayer Ope = new InterfaceLayer();

                DataRow DRow = Ope.GetDataRow(DBConnections.ConnectionString, DBConnections.ProviderName, "Dual", "SysDate -2", "");
                string StrDate = "";
                if (DRow != null)
                {
                    StrDate = DRow[0].ToString();
                }

                Ope = null;
                DRow = null;
                return StrDate;
            }
        }

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist) // Khushbu 16/07/2014
        {
            DataTable dtReturn = new DataTable();
            // column names 
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
        public static string CheckLockIsOpenOrNot(string pStrEntryDate, string pStrEntryTime)
        {
            InterfaceLayer Ope = new InterfaceLayer();
            Validation Val = new Validation();

            DataTable DTab = new DataTable();

            Request Request = new Request();
            Request.CommandText = "Transaction_OpenLock_ValSave" + "N";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("ENTRY_DATE_", pStrEntryDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            if (DRow == null)
            {
                return "Your Transaction Lock Is Not Open , For Make Entry On Different Date,  Please Contact To System Administrator";
            }

            DateTime? EntryINTime;
            DateTime? DBINTime;

            DateTime EntryDate = DateTime.Parse(pStrEntryDate);
            DateTime DBDate = DateTime.Parse(Val.ToString(DRow["FROM_DATE"]));

            EntryINTime = EntryDate.Add(DateTime.Parse(pStrEntryTime).TimeOfDay);
            DBINTime = DBDate.Add(DateTime.Parse(Val.ToString(DRow["ENTRY_TIME"])).TimeOfDay).AddMinutes(Val.Val(DRow["MINUTE"]));

            if (EntryINTime > DBINTime)
            {
                return "Your are Cross Your Open Lock Limit Please Contact To System Administrator";
            }
            return "YES";
        }

        //public static string CheckIsLock(string pStrEntryDate)
        //{
        //    InterfaceLayer Ope = new InterfaceLayer();
        //    Validation Val = new Validation();

        //    Request Request = new Request();
        //    Request.CommandText = "Transaction_Lock_ValSave";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Request.AddParams("ENTRY_DATE_", pStrEntryDate, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("DEPARTMENT_CODE_", GlobalDec.gEmployeeProperty.Department_Code, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("OUT_STR_", "", DbType.String, ParameterDirection.Output);

        //    ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    string StrRes = Val.ToString(AL[0]);
        //    AL = null;
        //    return StrRes;
        //}

        //public static string CheckLedgerLockIsOpenOrNot(string pStrEntryDate, int pIntLedger, int pIntSubLedger, int pIntProcess)
        //{
        //    InterfaceLayer Ope = new InterfaceLayer();
        //    Validation Val = new Validation();

        //    Request Request = new Request();
        //    Request.CommandText = "TRANSACTION_LED_LOCK_VALSAVE";

        //    Request.CommandType = CommandType.StoredProcedure;
        //    Request.AddParams("ENTRY_DATE_", pStrEntryDate, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("COMPANY_CODE_", GlobalDec.gEmployeeProperty.Company_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("BRANCH_CODE_", GlobalDec.gEmployeeProperty.Branch_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("LOCATION_CODE_", GlobalDec.gEmployeeProperty.Location_Code, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("PROCESS_CODE_", pIntProcess, DbType.Int32, ParameterDirection.Input);

        //    Request.AddParams("LEDGER_CODE_", pIntLedger, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("SUB_LEDGER_CODE_", pIntSubLedger, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("OUT_STR_", "", DbType.String, ParameterDirection.Output);

        //    ArrayList AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    string StrRes = Val.ToString(AL[0]);
        //    AL = null;
        //    return StrRes;

        //}

        public static string GenerateBarcodeString(int pIntPacketNo)
        {
            string DefaultString = "";
            if (pIntPacketNo < 10)
            {
                DefaultString = "0000" + pIntPacketNo.ToString();
            }
            else if (pIntPacketNo < 100)
            {
                DefaultString = "000" + pIntPacketNo.ToString();
            }
            else if (pIntPacketNo < 1000)
            {
                DefaultString = "00" + pIntPacketNo.ToString();
            }
            else if (pIntPacketNo < 10000)
            {
                DefaultString = "0" + pIntPacketNo.ToString();
            }
            else if (pIntPacketNo < 100000)
            {
                DefaultString = "" + pIntPacketNo.ToString();
            }
            return DefaultString;
        }

        // Add ; Narendra : 05-Jan-2017
        public static bool CheckLedgerForExpenseOrIncome(string StrLedgerCode)
        {
            InterfaceLayer Ope = new InterfaceLayer();
            Request Request = new Request();
            Request.CommandText = "SELECT * FROM LEDGER_LEVEL_MASTER WHERE LEDGER_CODE = " + StrLedgerCode + " AND ACCOUNT_TYPE_CODE IN (12,13,14,15)";
            Request.CommandType = CommandType.Text;

            DataRow DRow = Ope.GetDataRow(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);

            if (DRow == null)
            {
                return true;
            }
            return false;
        }
        // End : Narendra : 05-Jan-2016

        // Add : Narendra : 09-Jan-2017
        public static double FindLedgerOpeningClosingForExpenseIncome(LEDGEROPENING pEnum, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, int pIntLedgerCode, string pStrEntryDate)
        {
            double DouAmount = 0;
            Validation Val = new Validation();
            InterfaceLayer Ope = new InterfaceLayer();

            Request Request = new Request();
            Request.CommandText = "FIND_LEDGER_OPENINGCLOSING_EXP";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("OPE_", Val.Left(pEnum.ToString(), 1), DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pIntCompanyCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pIntBranchCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pIntLedgerCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ENTRY_DATE_", pStrEntryDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("START_DATE_", Val.DBDate(GlobalDec.gFinancialYear_StartDate), DbType.Date, ParameterDirection.Input);
            Request.AddParams("NEW_AMOUNT", DouAmount, DbType.Double, ParameterDirection.Output);

            ArrayList AL = new ArrayList();

            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //}
            //else
            //{
            //    AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
            //}
            string StrRes = "";
            if (AL != null && AL.Count != 0)
            {
                StrRes = Val.ToString(AL[0]);
            }
            AL = null;
            return Val.Val(StrRes);
        }
        // End : Narendra : 09-Jan-2017OK

        public static double FindLedgerOpeningClosing(LEDGEROPENING pEnum, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, int pIntLedgerCode, string pStrEntryDate)
        {
            double DouAmount = 0;
            Validation Val = new Validation();
            InterfaceLayer Ope = new InterfaceLayer();

            Request Request = new Request();
            Request.CommandText = "FIND_LEDGER_OPENINGCLOSING";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("OPE_", Val.Left(pEnum.ToString(), 1), DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pIntCompanyCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pIntBranchCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", pIntLedgerCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("ENTRY_DATE_", pStrEntryDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("NEW_AMOUNT", DouAmount, DbType.Double, ParameterDirection.Output);

            ArrayList AL = new ArrayList();

            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //}
            //else
            //{
            //    AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
            //}
            string StrRes = "";
            if (AL != null && AL.Count != 0)
            {
                StrRes = Val.ToString(AL[0]);
            }
            AL = null;
            return Val.Val(StrRes);
        }

        public static double FindLedgerOpeningClosing(LEDGEROPENING pEnum, int pIntCompanyCode, int pIntBranchCode, int pIntLocationCode, string StrLedgerCode, string pStrEntryDate)
        {
            double DouAmount = 0;
            Validation Val = new Validation();
            InterfaceLayer Ope = new InterfaceLayer();

            Request Request = new Request();
            Request.CommandText = "FIND_LEDGER_OPENINGCLOSING";
            Request.CommandType = CommandType.StoredProcedure;

            Request.AddParams("OPE_", Val.Left(pEnum.ToString(), 1), DbType.String, ParameterDirection.Input);
            Request.AddParams("COMPANY_CODE_", pIntCompanyCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("BRANCH_CODE_", pIntBranchCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LOCATION_CODE_", pIntLocationCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("LEDGER_CODE_", StrLedgerCode, DbType.String, ParameterDirection.Input);
            Request.AddParams("ENTRY_DATE_", pStrEntryDate, DbType.Date, ParameterDirection.Input);
            Request.AddParams("NEW_AMOUNT", DouAmount, DbType.Double, ParameterDirection.Output);

            ArrayList AL = new ArrayList();

            //if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
            //{
            //    AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
            //}
            //else
            //{
            //    AL = Ope.ExecuteNonQueryWithRetunValues(BLL.DBConnections.ConnectionDeveloper, BLL.DBConnections.ProviderDeveloper, Request);
            //}
            string StrRes = "";
            if (AL != null && AL.Count != 0)
            {
                StrRes = Val.ToString(AL[0]);
            }
            AL = null;
            return Val.Val(StrRes);
        }


        public static string gStrBPartPermissionInsertMsg
        {
            get { return "SORRY....You are not authorized to do (Insert) operation, In [B-PART]"; }
        }

        public static string gStrBPartPermissionDeleteMsg
        {
            get { return "SORRY....You are not authorized to do (Delete) operation, In [B-PART]"; }
        }


        //public static DataTable GetDataForSearch(string pStrTableName,string pStrColumns, string pStrCritria,string pStrPrimaryKey="")
        //{
        //    InterfaceLayer Ope = new InterfaceLayer();
        //    DataTable DataTableSearch = new DataTable("SearchTable");
        //    Ope.GetDataForCombo(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DataTableSearch, pStrTableName, pStrColumns, pStrCritria, pStrPrimaryKey);
        //    Ope = null;
        //    return DataTableSearch;
        //}

        public static string Decrypt(string cipherString, bool useHashing)
        {
            if (cipherString == "")
            {
                return "";
            }
            byte[] keyArray = null;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = DBConnections.SecurityKey;

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //keyArray = hashmd5.ComputeHash(UTF32Encoding.UTF32.GetBytes(key))
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
                //keyArray = UTF32Encoding.UTF32.GetBytes(key)
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return (UTF8Encoding.UTF8.GetString(resultArray));
            //Return (UTF32Encoding.UTF32.GetString(resultArray))
        }
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            if (toEncrypt == "")
            {
                return "";
            }
            byte[] keyArray = null;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            // Dim toEncryptArray As Byte() = UTF32Encoding.UTF32.GetBytes(toEncrypt)

            string key = DBConnections.SecurityKey;
            //key = "AdeF5ty6Fr456Mw###"
            //System.Windows.Forms.MessageBox.Show(key)
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //keyArray = hashmd5.ComputeHash(UTF32Encoding.UTF32.GetBytes(key))
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
                //keyArray = UTF32Encoding.UTF32.GetBytes(key)
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return (Convert.ToBase64String(resultArray, 0, resultArray.Length));
        }


        public static DataTable GetDataFromCsvFile(string SourceFilePath, string Sheetname)
        {
            string excelConnectionString = "";

            if (Environment.Is64BitOperatingSystem)
            {
                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.4.0;Data Source=" + SourceFilePath + ";Extended Properties='text;HDR=No;FMT=Delimited";
            }
            else
            {
                excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SourceFilePath + ";Extended Properties='text;Mode=Read;ReadOnly=true;HDR=No;FMT=Delimited'";
            }
            DataTable DTab = new DataTable(Sheetname);

            try
            {

                OleDbConnection cn = new OleDbConnection();
                cn.ConnectionString = excelConnectionString;
                cn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [" + Sheetname + "]", cn);
                da.Fill(DTab);

                da.Dispose();
                da = null;

                cn.Close();
                cn.Dispose();
                cn = null;

            }
            catch
            {
                return null;
            }

            return DTab;

        }

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
    }
}
