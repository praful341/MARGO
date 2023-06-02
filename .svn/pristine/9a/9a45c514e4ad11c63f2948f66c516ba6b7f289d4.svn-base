using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using MARGO.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmClarityMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        ClarityMaster objClarity = new ClarityMaster();

        public FrmClarityMaster()
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
            txtClarityCode.Text = "0";
            txtClarityName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtLabClarityName.Text = "";
            txtRapClarityCode.Text = "";
            txtRapBackClarityName.Text = "";
            txtRapClarityName.Text = "";
            txtClarityName.Focus();
            CmbType.SelectedIndex = 0;
            LookupMapping.EditValue = null;
            LookupMapping.Visible = true;
            labelControl1.Visible = true;
        }

        #region Validation

        private bool ValSave()
        {
            if (txtClarityName.Text.Length == 0)
            {
                Global.Confirm("Clarity Name Is Required");
                txtClarityName.Focus();
                return false;
            }

            if (CmbType.Text.ToUpper() == "SELECT")
            {
                Global.Confirm("Type Name Is Required");
                CmbType.Focus();
                return false;
            }

            if (!objClarity.ISExists(txtClarityName.Text, Val.ToInt64(txtClarityCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Clarity Name Already Exist.");
                txtClarityName.Focus();
                txtClarityName.SelectAll();
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

            Clarity_MasterProperty ClarityMasterProperty = new Clarity_MasterProperty();
            Int64 Code = Val.ToInt64(txtClarityCode.Text);
            ClarityMasterProperty.Clarity_Code = Val.ToInt64(Code);
            ClarityMasterProperty.Clarity_Name = txtClarityName.Text;
            ClarityMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            ClarityMasterProperty.Remark = txtRemark.Text;
            ClarityMasterProperty.Rap_Clarity_Code = Val.ToString(txtRapClarityCode.Text);
            ClarityMasterProperty.Rap_Clarity_Name = Val.ToString(txtRapClarityName.Text);
            ClarityMasterProperty.Rap_Back_Clarity_Name = Val.ToString(txtRapBackClarityName.Text);
            ClarityMasterProperty.LAB_CLARITY_NAME = Val.ToString(txtLabClarityName.Text);
            ClarityMasterProperty.Type = Val.ToString(CmbType.EditValue);
            ClarityMasterProperty.Mapping_Code = Val.ToInt64(LookupMapping.EditValue);

            int IntRes = objClarity.Save(ClarityMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Clarity Details");
                txtClarityName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Clarity Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Clarity Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            ClarityMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objClarity.GetData_Search();
            grdClarityMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();            
            btnClear_Click(btnClear, null);
        }

        private void dgvCountryMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvClarityMaster.GetDataRow(e.RowHandle);
                    txtClarityCode.Text = Convert.ToString(Drow["CLARITY_CODE"]);
                    txtClarityName.Text = Convert.ToString(Drow["CLARITY_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                    txtRapClarityCode.Text = Convert.ToString(Drow["RAP_CLARITY_CODE"]);
                    txtRapClarityName.Text = Convert.ToString(Drow["RAP_CLARITY_NAME"]);
                    txtRapBackClarityName.Text = Convert.ToString(Drow["RAP_BACK_CLARITY_CODE"]);
                    txtLabClarityName.Text = Convert.ToString(Drow["LAB_CLARITY_NAME"]);
                    CmbType.EditValue = Convert.ToString(Drow["TYPE"].ToString());
                    LookupMapping.EditValue = Convert.ToInt64(Drow["MAPPING_CODE"]);
                    CmbType_SelectedIndexChanged(null, null);
                }
            }
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbType.Text == "Select")
            {
                LookupMapping.EditValue = null;
                LookupMapping.Visible = true;
                labelControl1.Visible = true;
            }
            else if (CmbType.Text == "CLV")
            {
                Global.LOOKUPClarity(LookupMapping, "Mfg");
                LookupMapping.Visible = true;
                labelControl1.Visible = true;
            }
            else if (CmbType.Text == "MFG")
            {
                Global.LOOKUPClarity(LookupMapping, "Clv");
                LookupMapping.Visible = true;
                labelControl1.Visible = true;
            }
            else if (CmbType.Text == "POLISH")
            {
                LookupMapping.EditValue = null;
                LookupMapping.Visible = false;
                labelControl1.Visible = false;
            }
        }
    }
}
