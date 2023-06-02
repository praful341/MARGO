using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using MARGO.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmProcessMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        LocationMaster objLocation = new LocationMaster();
        ProcessMaster objProcess = new ProcessMaster();

        public FrmProcessMaster()
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
            txtProcessCode.Text = "0";
            txtProcessName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            CmbProcessGrp.SelectedIndex = 0;
            CmbProcessType.SelectedIndex = 0;
            txtMaxLoss.Text = "";
            txtMaxRepeat.Text = "";
            txtMaxIdealDays.Text = "";
            RbtnIssSieve.SelectedIndex = 1;
            RbtnIssClarity.SelectedIndex = 1;
            RbtnIssBarcode.SelectedIndex = 1;
            RbtnIssColor.SelectedIndex = 1;
            RbtnIssLoss.SelectedIndex = 1;
            RbtnIssLost.SelectedIndex = 1;
            RbtnIssMSize.SelectedIndex = 1;
            RbtnIssMachine.SelectedIndex = 1;
            RbtnIssCrtsPlus.SelectedIndex = 1;
            RbtnIssShape.SelectedIndex = 1;
            RbtnRetSieve.SelectedIndex = 1;
            RbtnRetClarity.SelectedIndex = 1;
            RbtnRetLoss.SelectedIndex = 1;
            RbtnRetSplit.SelectedIndex = 1;
            RbtnRetBarcode.SelectedIndex = 1;
            RbtnRetShape.SelectedIndex = 1;
            RbtnRetColor.SelectedIndex = 1;
            RbtnRetLost.SelectedIndex = 1;
            RbtnRetMSize.SelectedIndex = 1;
            RbtnRetMachine.SelectedIndex = 1;
            RbtnRetCrtsplus.SelectedIndex = 1;
            RbtnRetRoughRet.SelectedIndex = 1;
            ChkDefaultStock.Checked = false;
            RbtIsThirdParty.SelectedIndex = 1;
            RbtIsUnTouch.SelectedIndex = 1;
            RbtIsDispOnRet.SelectedIndex = 1;
            RbtIsMFGType.SelectedIndex = 1;
            RbtISManufacturing.SelectedIndex = 1;
            RbtOpenIssueToOutSide.SelectedIndex = 1;
            RbtIsLabourRateCalculate.SelectedIndex = 1;
            RbtFromPartyRequired.SelectedIndex = 1;
            RbtToPartyRequired.SelectedIndex = 1;
            RbtIsJWIssueEffectStock.SelectedIndex = 1;
            txtHOReceiveHeader.Text = "";
            txtIssueToOutSideHeader.Text = "";
            txtMFGToHOHeader.Text = "";
            txtJangedPrefix.Text = "";
            LookupProcess.EditValue = null;
            LookupLocation.EditValue = null;           
            TabRegisterDetail.SelectedTabPageIndex = 0;
            txtProcessName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtProcessName.Text.Length == 0)
            {
                Global.Confirm("Process Name Is Required");
                TabRegisterDetail.SelectedTabPageIndex = 0;
                txtProcessName.Focus();
                return false;
            }
            if (CmbProcessGrp.Text.ToUpper() == "SELECT")
            {
                Global.Confirm("Process Group Name Is Required");
                TabRegisterDetail.SelectedTabPageIndex = 0;
                CmbProcessGrp.Focus();
                return false;
            }
            if (CmbProcessType.Text.ToUpper() == "SELECT")
            {
                Global.Confirm("Process Type Name Is Required");
                TabRegisterDetail.SelectedTabPageIndex = 0;
                CmbProcessType.Focus();
                return false;
            }
            if (!objProcess.ISExists(txtProcessName.Text, Val.ToInt64(txtProcessCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Process Name Already Exist.");
                txtProcessName.Focus();
                txtProcessName.SelectAll();
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

            Process_MasterProperty ProcessMasterProperty = new Process_MasterProperty();
            Int64 Code = Val.ToInt64(txtProcessCode.Text);
            ProcessMasterProperty.Process_Code = Val.ToInt64(Code);
            ProcessMasterProperty.Process_Name = txtProcessName.Text;
            ProcessMasterProperty.Process_Group_Name = Val.ToString(CmbProcessGrp.Text);
            ProcessMasterProperty.MaxLoss = Val.Val(txtMaxLoss.Text);
            ProcessMasterProperty.MaxRepeat = Val.Val(txtMaxRepeat.Text);
            ProcessMasterProperty.Max_Ideal_Days = Val.Val(txtMaxIdealDays.Text);
            ProcessMasterProperty.ProcessType = Val.ToString(CmbProcessType.Text);
            ProcessMasterProperty.Mix_With_Process_Code = Val.ToInt64(LookupProcess.EditValue);                   
            ProcessMasterProperty.Allow_Rough_Return = Val.ToInt(RbtnRetRoughRet.EditValue);
            ProcessMasterProperty.Return_With_Split = Val.ToInt(RbtnRetSplit.EditValue);
            ProcessMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            ProcessMasterProperty.Remark = txtRemark.Text;

            ProcessMasterProperty.Issue_With_Barcode = Val.ToInt(RbtnIssBarcode.EditValue);
            ProcessMasterProperty.Issue_With_Shape = Val.ToInt(RbtnIssShape.EditValue);
            ProcessMasterProperty.Issue_With_Clarity = Val.ToInt(RbtnIssClarity.EditValue);
            ProcessMasterProperty.Issue_With_Color = Val.ToInt(RbtnIssColor.EditValue);
            ProcessMasterProperty.Issue_With_Sieve = Val.ToInt(RbtnIssSieve.EditValue);
            ProcessMasterProperty.Issue_With_Loss = Val.ToInt(RbtnIssLoss.EditValue);
            ProcessMasterProperty.Issue_With_Lost = Val.ToInt(RbtnIssLost.EditValue);
            ProcessMasterProperty.Issue_With_MSize = Val.ToInt(RbtnIssMSize.EditValue);
            ProcessMasterProperty.Issue_With_Machine = Val.ToInt(RbtnIssMachine.EditValue);
            ProcessMasterProperty.Issue_With_CaratPlus = Val.ToInt(RbtnIssCrtsPlus.EditValue);

            ProcessMasterProperty.Return_With_Barcode = Val.ToInt(RbtnRetBarcode.EditValue);
            ProcessMasterProperty.Return_With_Shape = Val.ToInt(RbtnRetShape.EditValue);
            ProcessMasterProperty.Return_With_Clarity = Val.ToInt(RbtnRetClarity.EditValue);
            ProcessMasterProperty.Return_With_Color = Val.ToInt(RbtnRetColor.EditValue);
            ProcessMasterProperty.Return_With_Sieve = Val.ToInt(RbtnRetSieve.EditValue);
            ProcessMasterProperty.Return_With_Loss = Val.ToInt(RbtnRetLoss.EditValue);
            ProcessMasterProperty.Return_With_Lost = Val.ToInt(RbtnRetLost.EditValue);
            ProcessMasterProperty.Return_With_MSize = Val.ToInt(RbtnRetMSize.EditValue);
            ProcessMasterProperty.Return_With_Machine = Val.ToInt(RbtnRetMachine.EditValue);
            ProcessMasterProperty.Return_With_CaratPlus = Val.ToInt(RbtnRetCrtsplus.EditValue);

            ProcessMasterProperty.IS_Third_Party_Transfer = Val.ToInt(RbtIsThirdParty.EditValue);
            ProcessMasterProperty.Is_Untouch = Val.ToInt(RbtIsUnTouch.EditValue);
            ProcessMasterProperty.Is_Disp_OnReturn = Val.ToInt(RbtIsDispOnRet.EditValue);
            ProcessMasterProperty.Is_MFG_Type = Val.ToInt(RbtIsMFGType.EditValue);
            ProcessMasterProperty.Is_Manufacturing = Val.ToInt(RbtISManufacturing.EditValue);
            ProcessMasterProperty.IS_Open_Issue_To_OutSide = Val.ToInt(RbtOpenIssueToOutSide.EditValue);

            ProcessMasterProperty.IS_From_Party_Required = Val.ToInt(RbtFromPartyRequired.EditValue);
            ProcessMasterProperty.IS_To_Party_Required = Val.ToInt(RbtToPartyRequired.EditValue);
            ProcessMasterProperty.Is_Labour_Rate_Calculate = Val.ToInt(RbtIsLabourRateCalculate.EditValue);
            ProcessMasterProperty.Is_Jw_Issue_Effect_Stock = Val.ToInt(RbtIsJWIssueEffectStock.EditValue);
            ProcessMasterProperty.Default_Stock_Flag = Val.ToBooleanToInt(ChkDefaultStock.Checked);
            ProcessMasterProperty.Janged_Prefix = Val.ToString(txtJangedPrefix.Text);
            ProcessMasterProperty.Clv_To_OutSide_Header = txtIssueToOutSideHeader.Text;
            ProcessMasterProperty.MFG_To_HO_Header = txtMFGToHOHeader.Text;
            ProcessMasterProperty.HO_Receive_Header = txtHOReceiveHeader.Text;

            ProcessMasterProperty.Location_Code = Val.ToInt64(LookupLocation.EditValue);

            int IntRes = objProcess.Save(ProcessMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Process Details");
                TabRegisterDetail.SelectedTabPageIndex = 0;
                txtProcessName.Focus();
            }
            else
            {              
                if (Code == 0)
                {
                    Global.Confirm("Process Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Process Details Data Update Successfully");
                }
                GetData();
                btnClear_Click(sender, e);
            }
            ProcessMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objProcess.GetData_Search();
            grdProcessMaster.DataSource = DTab;
            dgvProcessMaster.BestFitColumns();
        }      

        private void FrmProcessMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            txtProcessName.Focus();

            Global.LOOKUPLocation(LookupLocation);
            Global.LOOKUPProcess(LookupProcess);
        }

        private void LookupLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmLocationMaster frmCnt = new FrmLocationMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPLocation(LookupLocation);
            }
        }

        private void LookupProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPProcess(LookupProcess);
            }
        }

        private void dgvProcessMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvProcessMaster.GetDataRow(e.RowHandle);
                    txtProcessCode.Text = Convert.ToString(Drow["PROCESS_CODE"]);
                    txtProcessName.Text = Convert.ToString(Drow["PROCESS_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                    LookupLocation.EditValue = Convert.ToInt64(Drow["LOCATION_CODE"]);
                    CmbProcessGrp.EditValue = Convert.ToString(Drow["PROCESS_GROUP_NAME"]);
                    CmbProcessType.EditValue = Convert.ToString(Drow["PROCESS_TYPE"]);
                    txtMaxLoss.Text = Convert.ToString(Drow["MAX_LOSS"]);
                    txtMaxRepeat.Text = Convert.ToString(Drow["MAX_REPEAT"]);
                    txtMaxIdealDays.Text = Convert.ToString(Drow["MAX_IDEAL_DAYS"]);
                    RbtnIssSieve.EditValue = Convert.ToInt32(Drow["ISSUE_WITH_SIEVE"]);
                    RbtnIssClarity.EditValue = Convert.ToInt32(Drow["ISSUE_WITH_CLARITY"]);
                    RbtnIssBarcode.EditValue = Convert.ToInt32(Drow["ISSUE_WITH_BARCODE"]);
                    RbtnIssColor.EditValue = Convert.ToInt32(Drow["ISSUE_WITH_COLOR"]);
                    RbtnIssLoss.EditValue = Convert.ToInt32(Drow["ISSUE_WITH_LOSS"]);
                    RbtnIssLost.EditValue = Convert.ToInt32(Drow["ISSUE_WITH_LOST"]);
                    RbtnIssMSize.EditValue = Convert.ToInt32(Drow["ISSUE_WITH_MSIZE"]);
                    RbtnIssMachine.EditValue = Convert.ToInt32(Drow["ISSUE_WITH_MACHINE"]);
                    RbtnIssCrtsPlus.EditValue = Convert.ToInt32(Drow["ISSUE_WITH_CARAT_PLUS"]);
                    RbtnIssShape.EditValue = Convert.ToInt32(Drow["ISSUE_WITH_SHAPE"]);
                    RbtnRetSieve.EditValue = Convert.ToInt32(Drow["RETURN_WITH_SIEVE"]);
                    RbtnRetClarity.EditValue = Convert.ToInt32(Drow["RETURN_WITH_CLARITY"]);
                    RbtnRetLoss.EditValue = Convert.ToInt32(Drow["RETURN_WITH_LOSS"]);
                    RbtnRetSplit.EditValue = Convert.ToInt32(Drow["RETURN_WITH_SPLIT"]);
                    RbtnRetBarcode.EditValue = Convert.ToInt32(Drow["RETURN_WITH_BARCODE"]);
                    RbtnRetShape.EditValue = Convert.ToInt32(Drow["RETURN_WITH_SHAPE"]);
                    RbtnRetColor.EditValue = Convert.ToInt32(Drow["RETURN_WITH_COLOR"]);
                    RbtnRetLost.EditValue = Convert.ToInt32(Drow["RETURN_WITH_LOST"]);
                    RbtnRetMSize.EditValue = Convert.ToInt32(Drow["RETURN_WITH_MSIZE"]);
                    RbtnRetMachine.EditValue = Convert.ToInt32(Drow["RETURN_WITH_MACHINE"]);
                    RbtnRetCrtsplus.EditValue = Convert.ToInt32(Drow["RETURN_WITH_CARAT_PLUS"]);
                    RbtnRetRoughRet.EditValue = Convert.ToInt32(Drow["ALLOW_ROUGH_RETURN"]);
                    ChkDefaultStock.EditValue = Convert.ToInt32(Drow["DEFAULT_STOCK_FLAG"]);
                    RbtIsThirdParty.EditValue = Convert.ToInt32(Drow["IS_THIRD_PARTY_TRANSFER"]);
                    RbtIsUnTouch.EditValue = Convert.ToInt32(Drow["IS_UNTOUCH"]);
                    RbtIsDispOnRet.EditValue = Convert.ToInt32(Drow["IS_DISP_ONRETURN"]);
                    RbtIsMFGType.EditValue = Convert.ToInt32(Drow["IS_MFG_TYPE"]);
                    RbtISManufacturing.EditValue = Convert.ToInt32(Drow["IS_MANUFACTURING"]);
                    RbtOpenIssueToOutSide.EditValue = Convert.ToInt32(Drow["IS_OPEN_ISSUE_TO_OUTSIDE"]);
                    RbtIsLabourRateCalculate.EditValue = Convert.ToInt32(Drow["IS_LABOUR_RATE_CALCULATE"]);
                    RbtFromPartyRequired.EditValue = Convert.ToInt32(Drow["IS_FROM_PARTY_REQUIRED"]);
                    RbtToPartyRequired.EditValue = Convert.ToInt32(Drow["IS_TO_PARTY_REQUIRED"]);
                    RbtIsJWIssueEffectStock.EditValue = Convert.ToInt32(Drow["IS_JW_ISSUE_EFFECT_STOCK"]);
                    txtHOReceiveHeader.Text = Convert.ToString(Drow["HO_RECEIVE_HEADER"]);
                    txtIssueToOutSideHeader.Text = Convert.ToString(Drow["CLV_TO_OUTSIDE_HEADER"]);
                    txtMFGToHOHeader.Text = Convert.ToString(Drow["MFG_TO_HO_HEADER"]);
                    LookupProcess.EditValue = Convert.ToInt64(Drow["MIX_WITH_PROCESS_CODE"]);
                    txtJangedPrefix.Text = Convert.ToString(Drow["JANGED_PREFIX"]);
                }
            }
        }

        private void txtHOReceiveHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabRegisterDetail.SelectedTabPageIndex = TabRegisterDetail.SelectedTabPageIndex + 1;
            }       
        }
    }
}
