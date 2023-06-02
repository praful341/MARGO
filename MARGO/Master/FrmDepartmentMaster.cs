using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using MARGO.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmDepartmentMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        DepartmentMaster objDepartment = new DepartmentMaster();
        ProcessMaster objProcess = new ProcessMaster();

        public FrmDepartmentMaster()
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
            txtDepartmentCode.Text = "0";
            txtDepartmentName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            LookupLocation.EditValue = null;
            LookupDept.EditValue = null;
            txtDepartmentName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtDepartmentName.Text.Length == 0)
            {
                Global.Confirm("Department Name Is Required");
                txtDepartmentName.Focus();
                return false;
            }
            if (LookupLocation.Text == "")
            {
                Global.Confirm("Location Name Is Required");
                LookupLocation.Focus();
                return false;
            }

            if (!objDepartment.ISExists(txtDepartmentName.Text, Val.ToInt64(txtDepartmentCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Department Name Already Exist.");
                txtDepartmentName.Focus();
                txtDepartmentName.SelectAll();
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

            Department_MasterProperty DepartmentMasterProperty = new Department_MasterProperty();
            Int64 Code = Val.ToInt64(txtDepartmentCode.Text);
            DepartmentMasterProperty.Department_Code = Val.ToInt64(Code);
            DepartmentMasterProperty.Department_Name = txtDepartmentName.Text;
            DepartmentMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            DepartmentMasterProperty.Remark = txtRemark.Text;
            DepartmentMasterProperty.Location_Code = Val.ToInt64(LookupLocation.EditValue);

            int IntRes = objDepartment.Save(DepartmentMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Department Details");
                txtDepartmentName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Department Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Department Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            DepartmentMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objDepartment.GetData_Search();
            grdDepartmentMaster.DataSource = DTab;
        }

        private void dgvCountryMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvDepartmentMaster.GetDataRow(e.RowHandle);
                    txtDepartmentCode.Text = Convert.ToString(Drow["DEPARTMENT_CODE"]);
                    txtDepartmentName.Text = Convert.ToString(Drow["DEPARTMENT_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);                   
                    LookupLocation.EditValue = Convert.ToInt64(Drow["LOCATION_CODE"]);
                }
            }
        }

        private void FrmDepartmentMaster_Load(object sender, EventArgs e)
        {
            GetData();

            Global.LOOKUPLocation(LookupLocation);
            Global.LOOKUPDepartment(LookupDept);

            DataTable Process = objProcess.GetData();
            MainGrdProcessMaster.DataSource = Process;
            MainGrdProcessMaster.RefreshDataSource();
            GrdProcessMaster.BestFitColumns();

            btnClear_Click(btnClear, null);
        }

        private void GrdProcessMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle != -1)
            {
                if (e.Clicks == 2)
                {
                    Department_Process_SettingProperty Property = new Department_Process_SettingProperty();
                    Property.Department_Code = Val.ToInt64(txtDepartmentCode.Text);
                    Property.Process_Code = Val.ToInt64(GrdProcessMaster.GetDataRow(e.RowHandle)["PROCESS_CODE"].ToString());

                    Department_Process_SettingProperty DepartmentProperty = objDepartment.GetDepartmentSettings(Property.Department_Code, Property.Process_Code);

                    //if (DRow != null)
                    //{
                    ChkIssBarcode.EditValue = DepartmentProperty.Issue_With_Barcode;// Val.ToInt(DRow["ISSUE_WITH_BARCODE"]);
                        ChkIssShape.EditValue =  DepartmentProperty.Issue_With_Shape;
                        ChkIssColor.EditValue = DepartmentProperty.Issue_With_Color;
                        ChkIssClarity.EditValue = DepartmentProperty.Issue_With_Clarity;
                        ChkIssLoss.EditValue = DepartmentProperty.Issue_With_Loss;
                        ChkIssLost.EditValue = DepartmentProperty.Issue_With_Lost;
                        ChkIssMsize.EditValue = DepartmentProperty.Issue_With_MSize;
                        ChkIssMachine.EditValue = DepartmentProperty.Issue_With_Machine;
                        ChkIssCaratPlus.EditValue = DepartmentProperty.Issue_With_Carat_Plus;
                        ChkIssRemark.EditValue = DepartmentProperty.Issue_With_Remark;
                        ChkIssSieveCheck.EditValue = DepartmentProperty.Issue_With_SieveCheck;
                        ChkIssEmpReturn.EditValue = DepartmentProperty.Is_Emp_IssRet;
                        ChkRetBarcode.EditValue = DepartmentProperty.Return_With_Barcode;
                        ChkRetShape.EditValue = DepartmentProperty.Return_With_Shape;
                        ChkRetColor.EditValue = DepartmentProperty.Return_With_Color;
                        ChkRetClarity.EditValue = DepartmentProperty.Return_With_Clarity;
                        ChkRetLoss.EditValue = DepartmentProperty.Return_With_Loss;
                        ChkRetLost.EditValue = DepartmentProperty.Return_With_Lost;
                        ChkRetMSize.EditValue = DepartmentProperty.Return_With_MSize;
                        ChkRetMachine.EditValue = DepartmentProperty.Return_With_Machine;
                        ChkRetCaratPlus.EditValue = DepartmentProperty.Return_With_Carat_Plus;
                        ChkRetRemark.EditValue = DepartmentProperty.Return_With_Remark;
                        ChkRetSieveCheck.EditValue = DepartmentProperty.Return_With_SieveCheck;
                        ChkRetSecondPcs.EditValue = DepartmentProperty.Return_With_Second_Pcs;
                        ChkRetBarcodeScrap.EditValue = DepartmentProperty.Return_With_Barcode_Scrap;
                        ChkRetRR.EditValue = DepartmentProperty.Return_With_RR;
                        ChkReturnWithGrade.EditValue = DepartmentProperty.Return_With_Grade;
                        ChkIsAddInRoughStock.EditValue = DepartmentProperty.IS_ADD_IN_ROUGH_STOCK;
                        ChkIsJobWorkAutoConfirm.EditValue = DepartmentProperty.IS_JOB_WORK_AUTO_CONFIRM;
                        ChkReturnSubProcess.EditValue = DepartmentProperty.Return_With_Sub_Process;
                        ChkIsShapeCompulsory.EditValue = DepartmentProperty.Is_Shape_Compulsory;
                    //}
                    //else
                    //{
                    //    ChkIssBarcode.EditValue = 0;
                    //    ChkIssShape.EditValue = 0;
                    //    ChkIssClarity.EditValue = 0;
                    //    ChkIssColor.EditValue = 0;
                    //    ChkIssLoss.EditValue = 0;
                    //    ChkIssLost.EditValue = 0;
                    //    ChkIssMsize.EditValue = 0;
                    //    ChkIssMachine.EditValue = 0;
                    //    ChkIssCaratPlus.EditValue = 0;
                    //    ChkIssRemark.EditValue = 0;
                    //    ChkIssSieveCheck.EditValue = 0;
                    //    ChkIssEmpReturn.EditValue = 0;
                    //    ChkRetBarcode.EditValue = 0;
                    //    ChkRetShape.EditValue = 0;
                    //    ChkRetClarity.EditValue = 0;
                    //    ChkRetColor.EditValue = 0;
                    //    ChkRetLoss.EditValue = 0;
                    //    ChkRetLost.EditValue = 0;
                    //    ChkRetMSize.EditValue = 0;
                    //    ChkRetMachine.EditValue = 0;
                    //    ChkRetCaratPlus.EditValue = 0;
                    //    ChkRetRemark.EditValue = 0;
                    //    ChkRetSieveCheck.EditValue = 0;
                    //    ChkRetSecondPcs.EditValue = 0;
                    //    ChkRetBarcodeScrap.EditValue = 0;
                    //    ChkRetRR.EditValue = 0;
                    //    ChkIsAddInRoughStock.EditValue = 0;
                    //    ChkIsJobWorkAutoConfirm.EditValue = 0;
                    //    ChkReturnSubProcess.EditValue = 0;
                    //    ChkIsShapeCompulsory.EditValue = 0;
                    //    ChkReturnWithGrade.EditValue = 0;
                    //}
                }
            }
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

        private void LookupDept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmDepartmentMaster frmCnt = new FrmDepartmentMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPDepartment(LookupDept);
            }
        }

        private void BtnSaveProcessSettings_Click(object sender, EventArgs e)
        {
            if (GrdProcessMaster.SelectedRowsCount == 0)
            {
                MARGO.Class.Global.Confirm("Please Select Process");
                return;
            }

            Department_Process_SettingProperty Property = new Department_Process_SettingProperty();
            Property.Department_Code = Val.ToInt64(txtDepartmentCode.Text);
            Property.To_Department_Code = Val.ToInt64(LookupDept.EditValue);

            Property.Process_Code = Val.ToInt64(GrdProcessMaster.GetRowCellValue(GrdProcessMaster.FocusedRowHandle, "PROCESS_CODE").ToString());

            Property.Issue_With_Barcode = ChkIssBarcode.Checked == true ? 1 : 0;
            Property.Issue_With_Shape = ChkIssShape.Checked == true ? 1 : 0;
            Property.Issue_With_Clarity = ChkIssClarity.Checked == true ? 1 : 0;
            Property.Issue_With_Color = ChkIssColor.Checked == true ? 1 : 0;
            Property.Issue_With_Loss = ChkIssLoss.Checked == true ? 1 : 0;
            Property.Issue_With_Lost = ChkIssLost.Checked == true ? 1 : 0;
            Property.Issue_With_MSize = ChkIssMsize.Checked == true ? 1 : 0;
            Property.Issue_With_Machine = ChkIssMachine.Checked == true ? 1 : 0;
            Property.Issue_With_Carat_Plus = ChkIssCaratPlus.Checked == true ? 1 : 0;
            Property.Issue_With_Remark = ChkIssRemark.Checked == true ? 1 : 0;
            Property.Issue_With_SieveCheck = ChkIssSieveCheck.Checked == true ? 1 : 0;
            Property.Is_Emp_IssRet = ChkIssEmpReturn.Checked == true ? 1 : 0;
            Property.Return_With_Barcode = ChkRetBarcode.Checked == true ? 1 : 0;
            Property.Return_With_Shape = ChkRetShape.Checked == true ? 1 : 0;
            Property.Return_With_Clarity = ChkRetClarity.Checked == true ? 1 : 0;
            Property.Return_With_Color = ChkRetColor.Checked == true ? 1 : 0;
            Property.Return_With_Loss = ChkRetLoss.Checked == true ? 1 : 0;
            Property.Return_With_Lost = ChkRetLost.Checked == true ? 1 : 0;
            Property.Return_With_MSize = ChkRetMSize.Checked == true ? 1 : 0;
            Property.Return_With_Machine = ChkRetMachine.Checked == true ? 1 : 0;
            Property.Return_With_Carat_Plus = ChkRetCaratPlus.Checked == true ? 1 : 0;
            Property.Return_With_Remark = ChkRetRemark.Checked == true ? 1 : 0;
            Property.Return_With_SieveCheck = ChkRetSieveCheck.Checked == true ? 1 : 0;
            Property.Return_With_Second_Pcs = ChkRetSecondPcs.Checked == true ? 1 : 0;
            Property.Return_With_Barcode_Scrap = ChkRetBarcodeScrap.Checked == true ? 1 : 0;
            Property.Return_With_RR = ChkRetRR.Checked == true ? 1 : 0;
            Property.IS_ADD_IN_ROUGH_STOCK = ChkIsAddInRoughStock.Checked == true ? 1 : 0;
            Property.IS_JOB_WORK_AUTO_CONFIRM = ChkIsJobWorkAutoConfirm.Checked == true ? 1 : 0;
            Property.Return_With_Grade = ChkReturnWithGrade.Checked == true ? 1 : 0;
            Property.Return_With_Sub_Process = ChkReturnSubProcess.Checked == true ? 1 : 0;
            Property.Is_Shape_Compulsory = Val.ToBooleanToInt(ChkIsShapeCompulsory.Checked);


            int IntRes = objDepartment.SaveDepartmentSettings(Property);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Department Settings");
                return;
            }
            Global.Confirm("Successfully Save Settings");

            LookupDept.Text = "";

            ChkIssBarcode.Checked = false;
            ChkIssShape.Checked = false;
            ChkIssClarity.Checked = false;
            ChkIssColor.Checked = false;
            ChkIssLoss.Checked = false;
            ChkIssLost.Checked = false;
            ChkIssMsize.Checked = false;
            ChkIssMachine.Checked = false;
            ChkIssCaratPlus.Checked = false;
            ChkIssRemark.Checked = false;
            ChkIssSieveCheck.Checked = false;
            ChkIssEmpReturn.Checked = false;
            ChkRetBarcode.Checked = false;
            ChkRetShape.Checked = false;
            ChkRetClarity.Checked = false;
            ChkRetColor.Checked = false;
            ChkRetMachine.Checked = false;
            ChkRetLost.Checked = false;
            ChkRetMSize.Checked = false;
            ChkRetMachine.Checked = false;
            ChkRetCaratPlus.Checked = false;
            ChkRetRemark.Checked = false;
            ChkRetSieveCheck.Checked = false;
            ChkRetSecondPcs.Checked = false;
            ChkRetBarcodeScrap.Checked = false;
            ChkRetRR.Checked = false;
            ChkIsAddInRoughStock.Checked = false;
            ChkIsJobWorkAutoConfirm.Checked = false;
            ChkReturnWithGrade.Checked = false;
            ChkReturnSubProcess.Checked = false;
            ChkIsShapeCompulsory.Checked = false; 
            Property = null;
        }

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabRegisterDetail.SelectedTabPageIndex = TabRegisterDetail.SelectedTabPageIndex + 1;
            } 
        }
    }
}
