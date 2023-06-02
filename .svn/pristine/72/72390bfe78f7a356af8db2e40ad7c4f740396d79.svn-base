using BLL.FunctionClasses.Entry;
using BLL.FunctionClasses.Master;
using System;
using System.Data;
using System.Windows.Forms;
using BLL.PropertyClasses.Transaction;
using BLL.FunctionClasses.Transaction;
using MARGO.Class;
using BLL;

namespace MARGO
{
    public partial class FrmCLVMixDeptTransfer : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        ClvMixDeptIssRet ObjMix = new ClvMixDeptIssRet();
        CompanyMaster objCompany = new CompanyMaster();
        BranchMaster objBranch = new BranchMaster();
        LocationMaster objLocation = new LocationMaster();
        DepartmentMaster objDepartment = new DepartmentMaster();
        SieveMaster objSieve = new SieveMaster();
        ClarityMaster objClarity = new ClarityMaster();
        ProcessMaster objProcess = new ProcessMaster();
        RoughMaster objRough = new RoughMaster();
        DataTable DTab = new DataTable();

        public FrmCLVMixDeptTransfer()
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
            DTPEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            LookupFromProcess.EditValue = null;
            LookupFromDept.EditValue = null;
            LookupRoughName.EditValue = null;
            LookupSieve.EditValue = null;
            LookupClarityName.EditValue = null;
            txtJangadNo.Text = "";
            txtBalance.Text = "";
            txtBarcodeNo.Text = "";
            PanelFrom.Enabled = true;
            PanelTo.Enabled = false;
            txtTransferJangedNo.Text = "";
            PanelFrom.Enabled = true;
            PanelTo.Enabled = false;
            dgvMakableIssue.DataSource = null;

            txtTotLot.Text = "";
            txtTotPcs.Text = "";
            txtTotCarat.Text = "";

            txtSelLot.Text = "";
            txtSelPcs.Text = "";
            txtSelCarat.Text = "";
            LookupToDept.EditValue = null;
            LookupToProcess.EditValue = null;
            
            LookupFromProcess.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (Val.ToString(LookupToDept.Text.Trim()) == "")
            {
                MARGO.Class.Global.Confirm("To Department Is Required");
                LookupToDept.Focus();
                return false;
            }
            if (Val.ToString(LookupToProcess.Text.Trim()) == "")
            {
                MARGO.Class.Global.Confirm("To Process Is Required");
                LookupToProcess.Focus();
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

            int IntRes = 0; Int64 mJangadNo_ = 0; Int64 MST_id = 0;
            System.Data.DataTable DTab = (System.Data.DataTable)dgvMakableIssue.DataSource;
            Mix_IssRet_MasterProperty DeptTransferProperty = new Mix_IssRet_MasterProperty();
            if (DTab != null)
            {
                if (DTab.Rows.Count > 0)
                {
                    foreach (DataRow DRow in DTab.Rows)
                    {
                        if (Val.ToString(DRow["SEL"]) == "0")
                        {
                            continue;
                        }
                        DeptTransferProperty = new Mix_IssRet_MasterProperty();
                        DeptTransferProperty.Janged_Date = Val.DBDate(DTPEntryDate.Text);
                        DeptTransferProperty.Janged_No = mJangadNo_;
                        DeptTransferProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
                        DeptTransferProperty.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);
                        DeptTransferProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);
                        DeptTransferProperty.SrNo = 0;
                        DeptTransferProperty.From_Department_Code = Val.ToInt64(LookupFromDept.EditValue);
                        DeptTransferProperty.To_Department_Code = Val.ToInt64(LookupToDept.EditValue);
                        DeptTransferProperty.Sieve_Code = Val.ToInt64(DRow["SIEVE_CODE"]);
                        DeptTransferProperty.Clarity_Code = 0;  // Val.ToInt64(DRow["CLV_CLARITY_CODE"]);
                        DeptTransferProperty.CLV_CLARITY_CODE = Val.ToInt64(DRow["CLV_CLARITY_CODE"]);
                        DeptTransferProperty.MFG_Clarity_Code = Val.ToInt64(DRow["MFG_CLARITY_CODE"]);
                        DeptTransferProperty.Barcode = Val.ToString(DRow["BARCODE"]);
                        DeptTransferProperty.Issue_Pcs = Val.ToDouble(DRow["ISSUE_PCS"]);
                        DeptTransferProperty.Issue_Carat = Val.ToDouble(DRow["ISSUE_CARAT"]);
                        DeptTransferProperty.Color_Code = Val.ToInt64(DRow["COLOR_CODE"]);
                        DeptTransferProperty.Shape_Code = Val.ToInt64(DRow["Shape_Code"]);
                        DeptTransferProperty.Rough_Type_Code = Val.ToInt64(DRow["ROUGH_TYPE_CODE"]);

                        DeptTransferProperty.Issue_Empoloyee_Code = BLL.GlobalDec.gEmployeeProperty.Employee_Code;
                        DeptTransferProperty.Issue_Computer_IP = BLL.GlobalDec.gStrComputerIP;
                        DeptTransferProperty.SFLG = 1;
                        DeptTransferProperty.Trf_Janged_No = Val.ToString(txtTransferJangedNo.Text);
                        DeptTransferProperty.From_Location_Code = Val.ToInt64(GlobalDec.gEmployeeProperty.Location_Code);
                        DeptTransferProperty.Rough_Name = Val.ToString(LookupRoughName.EditValue);
                        DeptTransferProperty.P_ID = Val.ToInt64("0");
                        DeptTransferProperty.Rough_SrNo = MST_id;

                        DeptTransferProperty = ObjMix.SaveDepartmentTransfer(DeptTransferProperty);
                        //     Int64 Newmstid = DeptTransferProperty.new_ID;
                        string lblID = DeptTransferProperty.new_ID.ToString();
                        mJangadNo_ = DeptTransferProperty.Janged_No;
                        MST_id = DeptTransferProperty.Rough_SrNo;

                        DeptTransferProperty = null;
                        IntRes = 1;
                    }
                    txtNewJangad.EditValue = mJangadNo_.ToString();
                }
            }
            if (IntRes == -1)
            {
                MARGO.Class.Global.Confirm("Error In Save Department Transfer Data");
            }
            else
            {
                MARGO.Class.Global.Confirm("Department Transfer Data Save Successfully");
                btnClear_Click(sender, e);
            }
            DeptTransferProperty = null;
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

            DTPEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            LookupFromProcess.EditValue = null;
            LookupFromDept.EditValue = null;
            LookupRoughName.EditValue = null;
            LookupSieve.EditValue = null;
            LookupClarityName.EditValue = null;

            txtBarcodeNo.Text = "";
            txtBarcodeNo.Tag = "";
            txtTransferJangedNo.Text = "";

            txtTotLot.Text = "";
            txtTotPcs.Text = "";
            txtTotCarat.Text = "";

            txtSelLot.Text = "";
            txtSelPcs.Text = "";
            txtSelCarat.Text = "";

            LookupFromProcess.Focus();
        }

        private void LookupFromDept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmDepartmentMaster frmCnt = new FrmDepartmentMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPDepartment(LookupFromDept);
            }
        }

        private void BtnDeptShow_Click(object sender, EventArgs e)
        {
            if (Val.ToString(LookupFromDept.Text.Trim()) == "")
            {
                MARGO.Class.Global.Confirm("Department Required");
                LookupFromDept.Focus();
                return;
            }
            if (Val.ToString(LookupFromProcess.Text.Trim()) == "")
            {
                MARGO.Class.Global.Confirm("From Process Required");
                LookupFromProcess.Focus();
                return;
            }
            if (Val.ToString(LookupRoughName.Text.Trim()) == "")
            {
                MARGO.Class.Global.Confirm("Rough Name Required");
                LookupRoughName.Focus();
                return;
            }
            if (Val.ToString(DTPEntryDate.Text.Trim()) == "")
            {
                MARGO.Class.Global.Confirm("Entry Date Required");
                DTPEntryDate.Focus();
                return;
            }

            Mix_IssRet_MasterProperty DeptTransferProperty = new Mix_IssRet_MasterProperty();
            DeptTransferProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            DeptTransferProperty.From_Department_Code = Val.ToInt64(LookupFromDept.EditValue);
            //  DeptTransferProperty.Sieve_Code = Val.ToInt64(LookupSieve.EditValue);
            //   DeptTransferProperty.Clarity_Code = Val.ToInt64(LookupClarityName.EditValue);
            //  DeptTransferProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);
            DeptTransferProperty.Rough_Name = Val.ToString(LookupRoughName.Text);
            //  DeptTransferProperty.To_Process_Code = 0;

            DataTable DTab = ObjMix.Dept_IssTran_GetDetail(DeptTransferProperty);

            if (DTab.Rows.Count > 0)
            {
                dgvMakableIssue.DataSource = DTab;
                GetSummary();
                PanelFrom.Enabled = false;
                PanelTo.Enabled = true;
            }
            else
            {
                Global.Confirm("Data Are Not Found");
                PanelFrom.Enabled = true;
                PanelTo.Enabled = false;
                BtnDeptShow.Focus();
            }
            txtNewJangad.EditValue = "";
        }

        private void GetSummary()
        {
            double IntTotPcs = 0; double IntSelPcs = 0; double IntTotLot = 0; double IntSelLot = 0;
            double DouTotCarat = 0; double DouSelCarat = 0;
            System.Data.DataTable DTab = (System.Data.DataTable)dgvMakableIssue.DataSource;
          //  DTab.AcceptChanges();
            if (DTab != null)
            {
                if (DTab.Rows.Count > 0)
                {
                    foreach (DataRow DRow in DTab.Rows)
                    {
                        IntTotLot = IntTotLot + 1;
                        IntTotPcs = IntTotPcs + Val.Val(DRow["ISSUE_PCS"]);
                        DouTotCarat = DouTotCarat + Val.Val(DRow["ISSUE_CARAT"]);
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
                if (Convert.ToString((GrdMakableIssue.GetRowCellValue(i, "SEL"))) == "0" && Convert.ToString((GrdMakableIssue.GetRowCellValue(i, "BARCODE"))) == Val.ToString(txtBarcodeNo.EditValue))
                {
                    GrdMakableIssue.SetRowCellValue(i, "SEL", 1);
                }
            }
            GetSummary();
            txtBarcodeNo.Text = "";
            txtBarcodeNo.Focus();
        }

        //private void ChkSel_CheckedChanged(object sender, EventArgs e)
        //{
        //    GetSummary();
        //}

        //private void GrdMakableIssue_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        //{
        //    GetSummary();
        //}

        //private void GrdMakableIssue_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        //{
        //    GetSummary();
        //}

        //private void GrdMakableIssue_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    GetSummary();
        //}

        private void GrdMakableIssue_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetSummary();
        }

        private void GrdMakableIssue_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            GetSummary();
        }

        private void FrmCLVMixDeptTransfer_Shown(object sender, EventArgs e)
        {
            btnClear_Click(btnClear, null);
            LookupFromDept.Focus();
            DTPEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            Global.LOOKUPRough(LookupRoughName);
            Global.LOOKUPProcess(LookupFromProcess);
            Global.LOOKUPProcess(LookupToProcess);
            Global.LOOKUPDepartment(LookupFromDept);
            Global.LOOKUPDepartment(LookupToDept);
            Global.LOOKUPSieveRep(repositoryItemLookUpEdit1);
            Global.LOOKUPSieve(LookupSieve);
            Global.LOOKUPDepartmentRep(repositoryItemLookUpEdit2);
            Global.LOOKUPClarityRep(LookUpClvClarityRep, "Clv");
            Global.LOOKUPClarityRep(LookUpMfgClarityRep, "Mfg");
            Global.LOOKUPClarity(LookupClarityName);
            Global.LOOKUPColorRep(LookUpColorRep);
            Global.LOOKUPShapeRep(LookUpShapeRep);
            Global.LOOKUPRoughTypeRep(LookUpRoughTypeRep);
        }

        private void LookUpClvClarityRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarityRep(LookUpClvClarityRep, "Clv");
                Global.LOOKUPClarityRep(LookUpMfgClarityRep, "Mfg");
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

        private void LookUpMfgClarityRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarityRep(LookUpMfgClarityRep, "Mfg");
                Global.LOOKUPClarityRep(LookUpClvClarityRep, "Clv");
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

    }
}
