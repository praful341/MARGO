using System;
using System.Windows.Forms;
using MARGO.Class;

namespace MARGO
{
    public partial class FrmUnlock : Form
    {
        public FrmUnlock()
        {
            InitializeComponent();
        }

        private void FrmUnlock_Load(object sender, EventArgs e)
        {
            long serial = 0;
            SecurityManager sm = new SecurityManager();
            serial = sm.GetSerial();
            txtSerial.Text = serial.ToString();
           

            TxtActivKey.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnActivate_Click(object sender, EventArgs e)
        {
            SecurityManager sm = new SecurityManager();
            TxtActivKey.Text = "";

            long key = 0;
            if (!long.TryParse(TxtActivKey.Text, out key))
            {
                Global.Confirm("Invalid Activation key");
                return;
            }

            sm = new SecurityManager();
            if (sm.CheckKey(key))
            { Global.Confirm("Activation was successful"); }
            else
            {
                Global.Confirm("Activation was unsuccessful");
            }
        }

    //     long serial =0;
    //    if (!long.tryparse(txtSerial.Text, serial))
    //    {     MessageBox.show("Inavlid serial number")
    //       return; }
    //    KeyGenerator  kg = new KeyGenerator();
    //    long key  = kg.GenerateKey(serial);
      
    }
}
