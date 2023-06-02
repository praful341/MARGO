using BLL.FunctionClasses.Entry;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Transaction;
using MARGO.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmMixLotEmployeeIssRet : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        ClvMixDeptIssRet ObjMix = new ClvMixDeptIssRet();
        CompanyMaster objCompany = new CompanyMaster();
        BranchMaster objBranch = new BranchMaster();
        LocationMaster objLocation = new LocationMaster();
        DepartmentMaster objDepartment = new DepartmentMaster();
        EmployeeMaster objEmployee = new EmployeeMaster();
        SieveMaster objSieve = new SieveMaster();
        ClarityMaster objClarity = new ClarityMaster();
        ProcessMaster objProcess = new ProcessMaster();
        RoughMaster objRough = new RoughMaster();
        DataTable DTab = new DataTable();

        public FrmMixLotEmployeeIssRet()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            Val.frmGenSet(this);
            AttachFormEvents();
            this.Show();
            RBtnStatus_SelectedIndexChanged(null, null);
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
            DTPEntryDate.EditValue = Val.DBDate(System.DateTime.Now.ToShortDateString());
            LookupFromProcess.EditValue = null;
            LookupToProcess.EditValue = null;
            LookupRoughName.EditValue = null;
            LookupEmployee.EditValue = null;
            LookupSieve.EditValue = null;
            LookupClarityName.EditValue = null;
            dgvMakableIssue.DataSource = null;
            //RBtnStatus.SelectedIndex = 0;
            //RBtnStatus_SelectedIndexChanged(null, null);
            PanelFrom.Enabled = true;
            PanelTo.Enabled = false;

            txtBarcodeNo.EditValue = "";
            txtBalance.EditValue = "";
            txtTotLot.EditValue = "";
            txtTotPcs.EditValue = "";
            txtTotCarat.EditValue = "";
            txtSelLot.EditValue = "";
            txtSelPcs.EditValue = "";
            txtSelCarat.EditValue = "";
            LookupFromProcess.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            //if (txtEmployeeName.Text.Length == 0)
            //{
            //    MARGO.Class.Global.Confirm("Employee Name Is Required");
            //    txtEmployeeName.Focus();
            //    return false;
            //}
            return true;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValSave() == false)
            {
                return;
            }

            int IntRes = 0;
            DataTable tdt = new DataTable();
            tdt = (DataTable)dgvMakableIssue.DataSource;
            if (tdt != null)
            {
                if (tdt.Rows.Count > 0)
                {
                    foreach (DataRow Drow in tdt.Rows)
                    {
                        if (Val.ToString(Drow["SEL"]) == "0")
                        {
                            continue;
                        }
                        Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
                        Property.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
                        Property.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);
                        //     Property.Main_Employee_Code = Val.ToInt(txtMainEmployee.Tag);
                        Property.Department_Code = BLL.GlobalDec.gEmployeeProperty.Department_Code;
                        Property.Employee_Code = Val.ToInt64(LookupEmployee.EditValue);
                        if (RBtnStatus.SelectedIndex == 0)
                        { 

                        }
                        else if (RBtnStatus.SelectedIndex == 1)
                        { 
                            //     Property.Consume_Pcs = Val.ToInt(Drow.Cells["ISSUE_PCS"].Value);
                            //     Property.Consume_Carat = Val.ToDouble(Drow.Cells["ISSUE_CARAT"].Value);
                        }

                        Property.Rough_Name = Val.ToString(LookupRoughName.EditValue);

                        Property.Entry_Date = Val.DBDate(DTPEntryDate.Text);
                     //   Property.Entry_Time = Val.GetFullTime12();
                        Property.Rough_Type_Code = Val.ToInt64(Drow["ROUGH_TYPE_CODE"]);

                        Property.SrNo = 0;
                        Property.Sieve_Code = Val.ToInt64(Drow["SIEVE_CODE"]);
                        Property.CLV_CLARITY_CODE = Val.ToInt64(Drow["CLV_CLARITY_CODE"]);
                        Property.MFG_Clarity_Code = Val.ToInt64(Drow["MFG_CLARITY_CODE"]);

                        Property.Shape_Code = Val.ToInt64(Drow["SHAPE_CODE"]);
                        Property.Color_Code = Val.ToInt64(Drow["COLOR_CODE"]);
                        // Property.MSize_Code = Val.ToInt64(Drow.Cells["MSIZE_CODE"].Value);
                        Property.Barcode = Val.ToString(Drow["BARCODE"]);
                        Property.Issue_Pcs = Val.ToDouble(Drow["ISSUE_PCS"]);
                        Property.Issue_Carat = Val.ToDouble(Drow["ISSUE_CARAT"]);
                        Property.IS_Mixing = 0;


                        if (RBtnStatus.SelectedIndex == 0)
                        {
                            Property.Type = "I";
                            Property = ObjMix.SaveEmployeeIssueRecMix(Property);
                            if (Property != null)
                            {
                                IntRes = 1;
                            }
                        }
                        else if (RBtnStatus.SelectedIndex == 1)
                        {
                            Property.Type = "R";
                            //Property.Issue_Pcs = Val.ToInt(Drow.Cells["READY_PCS"].Value);
                            //Property.Issue_Carat = Val.ToDouble(Drow.Cells["READY_CARAT"].Value);

                            //if (Val.Val(Drow.Cells["READY_CARAT"].Value) == Val.Val(Drow.Cells["ISSUE_CARAT"].Value))
                            //{
                            //    Property.Issue_Carat = Val.ToDouble(Drow.Cells["READY_CARAT"].Value);
                            //}
                            //else if (Val.Val(Drow.Cells["READY_CARAT"].Value) > Val.Val(Drow.Cells["ISSUE_CARAT"].Value))
                            //{
                            //    Property.Carat_Plus = Math.Round(Val.Val(Drow.Cells["READY_CARAT"].Value) - Val.Val(Drow.Cells["ISSUE_CARAT"].Value), 2);
                            //}
                            //else if (Val.Val(Drow.Cells["READY_CARAT"].Value) < Val.Val(Drow.Cells["ISSUE_CARAT"].Value))
                            //{
                            //    Property.Loss_Carat = Math.Round(Val.Val(Drow.Cells["ISSUE_CARAT"].Value) - Val.Val(Drow.Cells["READY_CARAT"].Value), 2);
                            //}

                            Property = ObjMix.SaveEmployeeIssueRecMix(Property);
                            if (Property != null)
                            {
                                IntRes = 1;
                            }
                        }
                        Property = null;
                    }
                }
            }

            if (IntRes != 0)
            {
                //  this.Cursor = Cursors.Default;
                Global.Confirm("Employee Data SuccessFully Save");
                btnClear_Click(null, null);
            }
            else
            {
                //  this.Cursor = Cursors.Default;
                Global.Confirm("Error in Save Record .. Please Check");
            }

        }

        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {

        }

        private void LookupFromProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPProcess(LookupFromProcess);
                Global.LOOKUPProcess(LookupToProcess);
            }
        }

        private void LookupToProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPProcess(LookupToProcess);
                Global.LOOKUPProcess(LookupFromProcess);
            }
        }

        private void LookupRoughName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmRoughCreationMaster frmCnt = new FrmRoughCreationMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPRough(LookupRoughName);
            }
        }

        private void repositoryItemLookUpEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmEmployeeMaster frmCnt = new FrmEmployeeMaster();
                frmCnt.ShowDialog();
            }
        }

        private void repositoryItemLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmSieveMaster frmCnt = new FrmSieveMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPSieveRep(repositoryItemLookUpEdit1);
            }
        }

        private void LookupSieve_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmSieveMaster frmCnt = new FrmSieveMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPSieve(LookupSieve);
            }
        }

        private void LookupEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmEmployeeMaster frmCnt = new FrmEmployeeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPEmployee(LookupEmployee);
            }
        }

        private void LookupClarityName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarity(LookupClarityName);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PanelFrom.Enabled = true;
            PanelTo.Enabled = false;

            //PEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            //LookupFromProcess.EditValue = null;
            //LookupToProcess.EditValue = null;
            //LookupRoughName.EditValue = null;
            //LookupEmployee.EditValue = null;
            //LookupSieve.EditValue = null;
            //LookupClarityName.EditValue = null;
            dgvMakableIssue.DataSource = null;
            RBtnStatus.SelectedIndex = 0;
            RBtnStatus_SelectedIndexChanged(null, null);

            txtBarcodeNo.Text = "";
            txtBarcodeNo.Tag = "";
            txtBalance.Text = "";

            txtTotLot.Text = "";
            txtTotPcs.Text = "";
            txtTotCarat.Text = "";

            txtSelLot.Text = "";
            txtSelPcs.Text = "";
            txtSelCarat.Text = "";

            LookupFromProcess.Focus();
        }

        private void RBtnStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClear_Click(null,null);
            if (Val.ToString(RBtnStatus.EditValue) == "I")
            {
                btnSave.Text = "  Issue  ";
            }
            else
            {
                btnSave.Text = "  Receipt ";
            }
        }

        private bool ValDisp()
        {
            if (Convert.ToString(LookupToProcess.EditValue) == "")
            {
                Global.Confirm("To Process is required");
                LookupToProcess.Focus();
                return false;
            }
            if (Convert.ToString(LookupEmployee.EditValue) == "")
            {
                Global.Confirm("Employee Name is required");
                LookupEmployee.Focus();
                return false;
            }
            if (Convert.ToString(DTPEntryDate.EditValue) == "")
            {
                Global.Confirm("Date is required");
                DTPEntryDate.Focus();
                return false;
            }
            return true;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            //if (IntSetValue == 0)
            //{
            if (ValDisp() == false)
            {
                return;
            }

            //if (txtSize.Text.Length == 0)
            //{
            //    txtSize.Tag = "";
            //}
            //if (txtClvClarity.Text.Length == 0)
            //{
            //    txtClvClarity.Tag = "";
            //}

            //       this.Cursor = Cursors.WaitCursor;

            Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
            DetailProperty.From_Department_Code = BLL.GlobalDec.gEmployeeProperty.Department_Code;
            DetailProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            DetailProperty.Rough_Name = Val.ToString(LookupRoughName.Text);
            //    DetailProperty.Sieve_Code = Val.ToInt64(LookupSieve.EditValue);
            //    DetailProperty.Clarity_Code = Val.ToInt64(LookupClarityName.EditValue);

            if (RBtnStatus.SelectedIndex == 0)
            {
                GetEmpIssBalance();
            }
            else
            {
                GetEmpRecBalance();
            }

            DetailProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);

            DataTable tdt = new DataTable();

            if (RBtnStatus.SelectedIndex == 0)
            {
                tdt = ObjMix.GetDeptIssueTranDetail(DetailProperty);
            }
            else
            {
                DetailProperty.Employee_Code = Val.ToInt64(LookupEmployee.EditValue);
                tdt = ObjMix.GetEmpIssueDetail(DetailProperty);
            }
            dgvMakableIssue.DataSource = tdt;

            GetSummary();
            dgvMakableIssue.Focus();
            DetailProperty = null;

            //PanelFrom.Enabled = true;
            //PanelTo.Enabled = false;
            if (tdt.Rows.Count != 0)
            {
                PanelFrom.Enabled = false;
                PanelTo.Enabled = true;
            }
            //       this.Cursor = Cursors.Default;
            //}
            //else
            //{
            //    txtBarcodeNo.Focus();
            //}


        }

        private void GetEmpIssBalance()
        {
            Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
            DetailProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            DetailProperty.Rough_Name = Val.ToString(LookupRoughName.EditValue);
            DetailProperty.Rough_Type_Code = 1;
            DetailProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);

            txtBalance.Text = Math.Round(Val.ToDecimal(ObjMix.GetDeptBalance(DetailProperty)["BALANCE_CARAT"]), 3).ToString();

            DetailProperty = null;
        }

        private void GetEmpRecBalance()
        {
            txtBalance.Text = "";
            Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
            DetailProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            DetailProperty.Rough_Name = Val.ToString(LookupRoughName.EditValue);
            DetailProperty.Employee_Code = Val.ToInt64(LookupEmployee.EditValue);
            DataRow DRow = ObjMix.GetEmpRetBalance(DetailProperty);
            if (DRow != null)
            {
                txtBalance.Text =  Math.Round(Val.ToDecimal(DRow["BALANCE_CARAT"]),3).ToString();
            }
            DetailProperty = null;
            DRow = null;
        }

        private void GetSummary()
        {
            double IntTotPcs = 0; double IntSelPcs = 0; double IntTotLot = 0; double IntSelLot = 0;
            double DouTotCarat = 0; double DouSelCarat = 0;
            System.Data.DataTable DTab = (System.Data.DataTable)dgvMakableIssue.DataSource;

            if (DTab != null)
            {
                if (DTab.Rows.Count > 0)
                {
                    foreach (DataRow DRow in DTab.Rows)
                    {
                        IntTotLot = IntTotLot + 1;
                        IntTotPcs = IntTotPcs + Val.Val(DRow["ISSUE_PCS"]);
                        DouTotCarat = DouTotCarat + Val.Val(DRow["ISSUE_CARAT"]);

                        //IntSelLot = IntSelLot + 1;
                        //IntSelPcs = IntSelPcs + Val.Val(DRow["ISSUE_PCS"]);
                        //DouSelCarat = DouSelCarat + Val.Val(DRow["ISSUE_CARAT"]);
                        if (Val.ToString(DRow["SEL"]) == "1")
                        {
                            IntSelLot = IntSelLot + 1;
                            IntSelPcs = IntSelPcs + Val.Val(DRow["ISSUE_PCS"]);
                            DouSelCarat = DouSelCarat + Val.Val(DRow["ISSUE_CARAT"]);
                        }
                    }
                }
            }
            txtTotLot.Text = IntTotLot.ToString();
            txtTotPcs.Text = IntTotPcs.ToString();
            txtTotCarat.Text = DouTotCarat.ToString();

            txtSelLot.Text = IntSelLot.ToString();
            txtSelPcs.Text = IntSelPcs.ToString();
            txtSelCarat.Text = DouSelCarat.ToString();
        }

        private void txtBarcodeNo_Validated(object sender, EventArgs e)
        {
            if (txtBarcodeNo.Text.Length == 0)
            {
                return;
            }

            for (int i = 0; i <= GrdMakableIssue.RowCount; i++)
            {
                if (Convert.ToString((GrdMakableIssue.GetRowCellValue(i, "SEL"))) == "0" && Convert.ToString((GrdMakableIssue.GetRowCellValue(i, "BARCODE"))) == Convert.ToString(txtBarcodeNo.EditValue))
                {
                    GrdMakableIssue.SetRowCellValue(i, "SEL", 1);
                }
            }
            GetSummary();
            txtBarcodeNo.Text = "";
            txtBarcodeNo.Focus();
        }

        private void FrmMixLotEmployeeIssRet_Shown(object sender, EventArgs e)
        {
            btnClear_Click(btnClear, null);
            LookupFromProcess.Focus();
            DTPEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            Global.LOOKUPRough(LookupRoughName);
            Global.LOOKUPProcess(LookupFromProcess);
            Global.LOOKUPProcess(LookupToProcess);
            Global.LOOKUPSieveRep(repositoryItemLookUpEdit1);
            Global.LOOKUPSieve(LookupSieve);
            Global.LOOKUPDepartmentRep(repositoryItemLookUpEdit2);
            Global.LOOKUPClarity(LookupClarityName);
            Global.LOOKUPEmployee(LookupEmployee);

            Global.LOOKUPClarityRep(LookUpClVClarityRep, "Clv");
            Global.LOOKUPClarityRep(LookUpMFGClarityRep, "Mfg");
            Global.LOOKUPColorRep(LookUpColorRep);
            Global.LOOKUPShapeRep(LookUpShapeRep);
            Global.LOOKUPRoughTypeRep(LookUpRoughTypeRep);
        }

        private void LookUpClVClarityRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarityRep(LookUpClVClarityRep, "Clv");
                Global.LOOKUPClarityRep(LookUpMFGClarityRep, "Mfg");
            }
        }

        private void LookUpMFGClarityRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarityRep(LookUpClVClarityRep, "Clv");
                Global.LOOKUPClarityRep(LookUpMFGClarityRep, "Mfg");
            }
        }

        private void LookUpColorRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmColorMaster frmCnt = new FrmColorMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPColorRep(LookUpColorRep);
            }
        }

        private void LookUpShapeRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmShapeMaster frmCnt = new FrmShapeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPShapeRep(LookUpShapeRep);
            }
        }

        private void LookUpRoughTypeRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmRoughTypeMaster frmCnt = new FrmRoughTypeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPRoughTypeRep(LookUpRoughTypeRep);
            }
        }

        private void GrdMakableIssue_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetSummary();
        }

        private void GrdMakableIssue_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            GetSummary();
        }

    }
}
