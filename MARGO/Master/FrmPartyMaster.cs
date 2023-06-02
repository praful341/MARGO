using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using MARGO.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmPartyMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        PartyMaster objParty = new PartyMaster();

        public FrmPartyMaster()
        {
            InitializeComponent();
        }
        public void ShowForm()
        {
            Val.frmGenSet(this);
            AttachFormEvents();
            this.Show();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            //objBOFormEvents.ObjToDispose.Add(ObjGroup);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPartyCode.Text = "0";
            txtPartyName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0; 
            txtEmailID.Text = "";
            txtZipCode.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtMobileNo.Text = "";
            txtPANNo.Text = "";
            CmbPartyType.SelectedIndex = 0;
            txtBankName.Text = "";
            txtBankBranch.Text = "";
            txtBankIFSC.Text = "";
            txtBankAccNo.Text = "";           
            txtPartyName.Focus();
            LookupCity.EditValue = null;
            LookupState.EditValue = null;
            LookupCountry.EditValue = null;
        }

        #region Validation

        private bool ValSave()
        {
            if (txtPartyName.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Party Name Is Required");
                txtPartyName.Focus();
                return false;
            }
            if (!objParty.ISExists(txtPartyName.Text, Val.ToInt64(txtPartyCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Party Name Already Exist.");
                txtPartyName.Focus();
                txtPartyName.SelectAll();
                return false;
            }
            return true;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValSave() == false)
            {
                return;
            }

            Party_MasterProperty PartyMasterProperty = new Party_MasterProperty();
            Int64 Code = Val.ToInt64(txtPartyCode.Text);
            PartyMasterProperty.Party_Code = Val.ToInt64(Code);
            PartyMasterProperty.Party_Name = txtPartyName.Text;
            PartyMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            PartyMasterProperty.Remark = txtRemark.Text;
            PartyMasterProperty.Pan_No = Val.ToString(txtPANNo.Text);
            PartyMasterProperty.Party_Type = Val.ToString(CmbPartyType.EditValue);
            PartyMasterProperty.Mobile_No = Val.ToString(txtMobileNo.Text);
            PartyMasterProperty.EMail = Val.ToString(txtEmailID.Text);
            PartyMasterProperty.Address = Val.ToString(txtAddress.Text);
            PartyMasterProperty.Country_Code = Val.ToInt64(LookupCountry.EditValue);
            PartyMasterProperty.State_Code = Val.ToInt64(LookupState.EditValue);
            PartyMasterProperty.City_Code = Val.ToInt64(LookupCity.EditValue);
            PartyMasterProperty.Zip_Code = Val.ToString(txtZipCode.Text);
            PartyMasterProperty.Phone = Val.ToString(txtPhone.Text);
            PartyMasterProperty.Bank_Name = Val.ToString(txtBankName.Text);
            PartyMasterProperty.Bank_Branch = Val.ToString(txtBankBranch.Text);
            PartyMasterProperty.Bank_IFSC = Val.ToString(txtBankIFSC.Text);
            PartyMasterProperty.Bank_Acc_No = Val.ToString(txtBankAccNo.Text);


            int IntRes = objParty.Save(PartyMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Party Details");
                txtPartyName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Party Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Party Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            PartyMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objParty.GetData_Search();
            grdPartyMaster.DataSource = DTab;
            dgvPartyMaster.BestFitColumns();
        }

        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            txtPartyName.Focus();

            Global.LOOKUPCountry(LookupCountry);
            Global.LOOKUPState(LookupState);
            Global.LOOKUPCity(LookupCity);
        }

        private void LookupCountry_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCountryMaster frmCnt = new FrmCountryMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCountry(LookupCountry);
            }
        }

        private void dgvCompanyMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvPartyMaster.GetDataRow(e.RowHandle);
                    txtPartyCode.Text = Convert.ToString(Drow["Party_Code"]);
                    txtPartyName.Text = Convert.ToString(Drow["Party_Name"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["Active"]);
                    txtRemark.Text = Convert.ToString(Drow["Remarks"]);
                    txtMobileNo.Text = Convert.ToString(Drow["Party_Mobile"]);
                    txtPANNo.Text = Convert.ToString(Drow["Party_PanNo"]);
                    CmbPartyType.EditValue = Convert.ToString(Drow["Party_Type"]);
                    txtEmailID.Text = Convert.ToString(Drow["Party_Email"]);
                    txtAddress.Text = Convert.ToString(Drow["Party_Address"]);
                    LookupCountry.EditValue = Convert.ToInt64(Drow["Party_Country_Code"]);
                    LookupState.EditValue = Convert.ToInt64(Drow["Party_State_Code"]);
                    LookupCity.EditValue = Convert.ToInt64(Drow["Party_City_Code"]);
                    txtZipCode.Text = Convert.ToString(Drow["Party_Pincode"]);
                    txtPhone.Text = Convert.ToString(Drow["Party_Phone"]);
                    txtBankName.Text = Convert.ToString(Drow["Bank_Name"]);
                    txtBankBranch.Text = Convert.ToString(Drow["Bank_Branch"]);
                    txtBankIFSC.Text = Convert.ToString(Drow["Bank_IFSC"]);
                    txtBankAccNo.Text = Convert.ToString(Drow["Bank_AccountNo"]);                  
                }
            }
        }

        private void LookupState_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmStateMaster frmCnt = new FrmStateMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPState(LookupState);
            }
        }

        private void LookupCity_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCityMaster frmCnt = new FrmCityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCity(LookupCity);
            }
        }

        private void LookupCity_EditValueChanged(object sender, EventArgs e)
        {
            LookupState.EditValue = LookupCity.GetColumnValue("STATE_CODE");
            LookupCountry.EditValue = LookupCity.GetColumnValue("COUNTRY_CODE");
        }

        private void LookupState_EditValueChanged(object sender, EventArgs e)
        {
            LookupCountry.EditValue = LookupState.GetColumnValue("COUNTRY_CODE");
        }

       
    }
}
