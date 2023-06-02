using BLL;
using BLL.FunctionClasses.Utility;
using System;
using System.IO;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            string appPath = Application.StartupPath.ToString();
            ClassINI iniCl = new ClassINI(appPath + "\\margo.CONFIG");
            if (!File.Exists(appPath + "\\margo.CONFIG"))
            {
                //iniCl.IniWriteValue("LOGIN", "ServerHostName", GlobalDec.Encrypt("192.168.2.217", true));
                iniCl.IniWriteValue("LOGIN", "ServerHostName", GlobalDec.Encrypt("LENOVO-PC", true));
                //iniCl.IniWriteValue("LOGIN", "ServerHostName", GlobalDec.Encrypt("192.168.2.218", true));
                //iniCl.IniWriteValue("LOGIN", "ServerHostName", GlobalDec.Encrypt(".", true));
                iniCl.IniWriteValue("LOGIN", "DBName", GlobalDec.Encrypt("MARGO", true));
                iniCl.IniWriteValue("LOGIN", "ServerUserName", GlobalDec.Encrypt("sa", true));
                iniCl.IniWriteValue("LOGIN", "ServerPassWord", GlobalDec.Encrypt("admin@123", true));
            }

            //string gStrHostName = GlobalDec.Decrypt(iniCl.IniReadValue("LOGIN", "ServerHostName"), true);
            //string gStrDBName = GlobalDec.Decrypt(iniCl.IniReadValue("LOGIN", "DBName"), true);
            //string gStrUserName = GlobalDec.Decrypt(iniCl.IniReadValue("LOGIN", "ServerUserName"), true);
            //string gStrPasssword = GlobalDec.Decrypt(iniCl.IniReadValue("LOGIN", "ServerPassWord"), true);

            string gStrHostName = iniCl.IniReadValue("LOGIN", "ServerHostName");
            string gStrDBName = iniCl.IniReadValue("LOGIN", "DBName");
            string gStrUserName = iniCl.IniReadValue("LOGIN", "ServerUserName");
            string gStrPasssword = iniCl.IniReadValue("LOGIN", "ServerPassWord");

            //  BLL.DBConnections.ConnectionString = @"Data Source=SOFT-IT;Initial Catalog=MARGO;Integrated Security=True";

            BLL.DBConnections.ConnectionString = "Data Source=" + gStrHostName + ";Initial Catalog=" + gStrDBName + ";User ID=" + gStrUserName + ";Password=" + gStrPasssword + ";";
            BLL.DBConnections.ProviderName = "System.Data.SqlClient";

            //txtUserName.Text = "CHIRAG";
            //txtPassword.Text = "123";
            //  btnLogin_Click(null, null);

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Please Enter UserName");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Please Enter Password");
                txtPassword.Focus();
                return;
            }

            //if (txtUserName.Text == GlobalDec.gEmployeeProperty.UserName)
            //{
            //    MARGO.Class.Global.Confirm("Your are already Loged In");
            //    txtUserName.Focus();
            //    return;
            //}

            this.Cursor = Cursors.WaitCursor;

            Login objLogin = new Login();
            int IntRes = objLogin.CheckLogin(txtUserName.Text, GlobalDec.Encrypt(txtPassword.Text, true));

            this.Cursor = Cursors.Default;
            if (IntRes == -1)
            {
                MARGO.Class.Global.Confirm("Enter Valid UserName And Password");
                txtUserName.Focus();
                //panelControl1.Enabled = false;
                return;
            }
            else
            {
                this.Close();
                //txtUserName.Text = "";
                //txtPassword.Text = "";
                //panelControl1.Enabled = true;
                //FrmLogin Log = new FrmLogin();
                //Log.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}
