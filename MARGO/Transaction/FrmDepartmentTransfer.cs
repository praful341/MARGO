using BLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Transaction;
using MARGO.Class;
using MARGO.Search;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmDepartmentTransfer : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        ClvMixDeptIssRet ObjMix = new ClvMixDeptIssRet();
        DepartmentMaster objDepartment = new DepartmentMaster();
        SieveMaster objSieve = new SieveMaster();
        ClarityMaster objClarity = new ClarityMaster();
        DataTable DTab = new DataTable();
        Int64 FromDept = 0; Int64 lblID = 0;
        string mStrJangedDate;

        public FrmDepartmentTransfer()
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
            DTPEntryDate.EditValue = Val.DBDate(System.DateTime.Now.ToShortDateString());
            LookupFromProcess.Focus();
            LookupFromProcess.EditValue = null;
            LookupToProcess.EditValue = null;
            LookupRoughName.EditValue = null;
            LookupRoughType.EditValue = null;
            txtDeptBalance.EditValue = "";
            CmbSupplier.EditValue = "";
            dgvDeptTransfer.DataSource = null;
            //  lblID.Text = "0";
            panelControl7.Enabled = true;
            panelControl8.Enabled = true;
            panelControl6.Enabled = false;
            panelControl9.Enabled = false;
        }

        #region Validation

        private bool ValSave()
        {
            if (Val.ToString(LookupToProcess.Text.Trim()) == "")
            {
                MARGO.Class.Global.Confirm("To Process Required");
                LookupToProcess.Focus();
                return false;
            }
            if (Val.ToString(DTPEntryDate.Text.Trim()) == "")
            {
                MARGO.Class.Global.Confirm("Entry Date Required");
                DTPEntryDate.Focus();
                return false;
            }
            //if (txtEmployeeName.Text.Length == 0)
            if (!Global.MCheckEmpty(ColDept, GrdDeptTransfer, "To Department"))
            {
                return false;
            }
            if (!Global.MCheckEmpty(ColRetCrt, GrdDeptTransfer, "Carat"))
            {
                return false;
            }

            if (!Global.ChkAdmin())
            {
                if ((Val.ToDecimal(ColRetCrt.SummaryText) - Val.ToDecimal(ColRecWLoss.SummaryText) + Val.ToDecimal(ColRecWPlus.SummaryText)) > Val.ToDecimal(txtDeptBalance.EditValue))
                {
                    MARGO.Class.Global.Confirm("Transfer Carat Must Not Greater Than Balance Carat");
                    return false;
                }
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
           
            int IntRes = 0;
            Mix_IssRet_MasterProperty DeptTransferProperty = new Mix_IssRet_MasterProperty();
            DeptTransferProperty.Janged_Date = Val.DBDate(DTPEntryDate.Text);
            int Janged_No = 0;
            if (lblID == 0)
            {
                Janged_No = Val.ToInt(ObjMix.FindNewJangedNo(DTPEntryDate.Text));
                DeptTransferProperty.Janged_No = Janged_No;
            }
            DeptTransferProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            DeptTransferProperty.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);
            DeptTransferProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);
            DeptTransferProperty.From_Location_Code = Val.ToInt64(LookupLocation.EditValue);
            DeptTransferProperty.Through_By = Val.ToString(CmbSupplier.Text);
            DeptTransferProperty.Rough_Name = Val.ToString(LookupRoughName.EditValue);
            DeptTransferProperty.P_ID = Val.ToInt64(lblID);
            DeptTransferProperty.Issue_Janged_No = Janged_No.ToString();

            Int64 mstID = ObjMix.Master_Save(DeptTransferProperty);
            //     Int64 Newmstid = DeptTransferProperty.new_ID;
            lblID = DeptTransferProperty.new_ID;

            DeptTransferProperty = null;

            System.Data.DataTable DTab = (System.Data.DataTable)dgvDeptTransfer.DataSource;
            DTab.AcceptChanges();
            if (DTab.Rows.Count > 0)
            {
                DeptTransferProperty = new Mix_IssRet_MasterProperty();

                DeptTransferProperty.Rough_Type_Code = Val.ToInt64(LookupRoughType.EditValue);
                DeptTransferProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);
                DeptTransferProperty.new_ID = Val.ToInt64(lblID); //Newmstid);

                for (int i = 0; i < DTab.Rows.Count; i++)
                {
                    DeptTransferProperty.P_ID = Val.ToInt64(DTab.Rows[i]["DEPT_ISSRET_DTL_ID"]);
                    //    DeptTransferProperty.new_ID = Val.ToInt64(DTab.Rows[i]["DEPT_ISSRET_ID"].ToString());
                    DeptTransferProperty.To_Department_Code = Val.ToInt64(DTab.Rows[i]["TO_DEPARTMENT_CODE"]);
                    DeptTransferProperty.Barcode = Val.ToString(DTab.Rows[i]["BARCODE"]);
                    DeptTransferProperty.Sieve_Code = Val.ToInt64(DTab.Rows[i]["SIEVE_CODE"]);
                    DeptTransferProperty.Clarity_Code = Val.ToInt64(DTab.Rows[i]["CLARITY_CODE"]);
                    DeptTransferProperty.Issue_Pcs = Val.ToDouble(DTab.Rows[i]["ISSUE_PCS"]);
                    DeptTransferProperty.Issue_Carat = Val.ToDouble(DTab.Rows[i]["ISSUE_CARAT"]);

                    DeptTransferProperty.Loss_Carat = Val.ToDouble(DTab.Rows[i]["LOSS_CARAT"]);
                    DeptTransferProperty.Lost_Carat = Val.ToDouble(DTab.Rows[i]["LOST_CARAT"]);
                    DeptTransferProperty.Carat_Plus = Val.ToDouble(DTab.Rows[i]["CARAT_PLUS"]);

                    DeptTransferProperty.Janged_Date = Val.DBDate(DTPEntryDate.Text);
                    DeptTransferProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
                    DeptTransferProperty.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);
                    DeptTransferProperty.Rough_Name = Val.ToString(LookupRoughName.Text);
                    DeptTransferProperty.Janged_No = Janged_No;

                    IntRes += ObjMix.Detail_Save(DeptTransferProperty);
                }
            }
            if (IntRes == -1)
            {
                MARGO.Class.Global.Confirm("Error In Save Department Transfer Data");
            }
            else
            {
                MARGO.Class.Global.Confirm("Department Transfer Data Save Successfully");
                //  btnClear_Click(sender, e);
            }

            //BtnDeptShow.PerformClick();
            BtnDeptShow_Click(null, null);
            //  GetDeptBalance();
        }

        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            if (Global.ChkAdmin())
            {
                //  btnDelete.Visible = true;
                lblDelMsg.Visible = true;
            }
        }

        private void GetDeptBalance()
        {
            Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
            DetailProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            DetailProperty.Rough_Name = Convert.ToString(LookupRoughName.EditValue);
            DetailProperty.Rough_Type_Code = Val.ToInt64(LookupRoughType.EditValue);
            txtDeptBalance.Text = Math.Round(Val.ToDecimal(ObjMix.GetDeptBalance(DetailProperty)["BALANCE_CARAT"]), 3).ToString();

            //if (mStrStockField == "SIEVE")
            //{
            //    MNSieveWiseStock_Click(null, null);
            //}
            //else if (mStrStockField == "CLARITY")
            //{
            //    MNClarityWiseStock_Click(null, null);
            //}
            DetailProperty = null;
        }

        private void LookupCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCompanyMaster frmCnt = new FrmCompanyMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCompany(LookupCompany);
            }
        }

        private void LookupBranch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmBranchMaster frmCnt = new FrmBranchMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPBranch(LookupBranch);
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

        private void LookupRoughType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmRoughTypeMaster frmCnt = new FrmRoughTypeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPRoughTypeCode(LookupRoughType);
            }
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

        private void LookupToProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPProcess(LookupToProcess);
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
                FrmDepartmentMaster frmCnt = new FrmDepartmentMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPDepartmentRep(repositoryItemLookUpEdit2);
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

        private void LookUpClarity_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarityRep(LookUpClarity);
            }
        }

        private void BtnDeptShow_Click(object sender, EventArgs e)
        {
            if (Val.ToString(LookupRoughType.Text.Trim()) == "")
            {
                MARGO.Class.Global.Confirm("Rough Type Required");
                LookupRoughType.Focus();
                return;
            }

            Mix_IssRet_MasterProperty DeptTransferProperty = new Mix_IssRet_MasterProperty();
            DeptTransferProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            DeptTransferProperty.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);
            DeptTransferProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);
            DeptTransferProperty.From_Location_Code = Val.ToInt64(LookupLocation.EditValue);
            DeptTransferProperty.From_Company_Code = Val.ToInt64(LookupCompany.EditValue);
            DeptTransferProperty.From_Branch_Code = Val.ToInt64(LookupBranch.EditValue);
            DeptTransferProperty.Department_Code = Val.ToInt64(GlobalDec.gEmployeeProperty.Department_Code);
            //   DeptTransferProperty.Through_By = Val.ToString(CmbSupplier.Text);
            DeptTransferProperty.Rough_Name = Val.ToString(LookupRoughName.Text);
            DeptTransferProperty.Rough_Type_Code = 0;  // Val.ToInt64(LookupRoughType.EditValue);
            DeptTransferProperty.Sieve_Code = 0;
            DeptTransferProperty.Clarity_Code = 0;

            DataTable DTab = ObjMix.Dept_Transfer_GetData(DeptTransferProperty);

            if (DTab.Rows.Count > 0)
            {
                if (Global.ChkAdmin())
                {
                    dgvDeptTransfer.DataSource = DTab;
                    lblID = Convert.ToInt64(DTab.Rows[0]["DEPT_ISSRET_ID"]);
                }
                else
                {
                    dgvDeptTransfer.DataSource = DTab.Clone();
                    lblID = 0;
                }


                panelControl7.Enabled = false;
                panelControl8.Enabled = false;
                panelControl6.Enabled = true;
                panelControl9.Enabled = true;
            }
            else
            {
                //Global.Confirm("Data Are Not Found");
                dgvDeptTransfer.DataSource = DTab;
                BtnDeptShow.Focus();
                //    lblID.Text = "0";
                panelControl7.Enabled = false;
                panelControl8.Enabled = false;
                panelControl6.Enabled = true;
                panelControl9.Enabled = true;
            }
            GetDeptBalance();
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    int IntRes = 0;
        //    Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
        //    Property.P_ID = Val.ToInt64(lblID.Text);

        //    IntRes = ObjMix.Dept_Transfer_Date_Delete(Property);

        //    if (IntRes == -1)
        //    {
        //        Global.Confirm("Error In Save Department Transfer Delete Data");
        //    }
        //    else
        //    {

        //        Global.Confirm("Department Transfer Delete Data are Successfully");
        //        btnClear_Click(sender, e);
        //    }
        //    Property = null;
        //}

        private void dgvDeptTransfer_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Global.ChkAdmin())
            {
                return;
            }
            if (e.KeyCode == Keys.F9)
            {
                if (Global.Confirm("Are you sure delete selected row?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Int64 Production = Val.ToInt64(GrdDeptTransfer.GetFocusedRowCellValue("DEPT_ISSRET_DTL_ID").ToString());
                    if (Production > 0)
                    {
                        int IntRes = 0;
                        Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
                        Property.P_ID = Val.ToInt64(GrdDeptTransfer.GetFocusedRowCellValue("DEPT_ISSRET_DTL_ID").ToString());

                        IntRes = ObjMix.Dept_Transfer_RowDate_Delete(Property);

                        GrdDeptTransfer.DeleteRow(GrdDeptTransfer.GetRowHandle(GrdDeptTransfer.FocusedRowHandle));
                    }
                    else if (Production == 0)
                    {
                        GrdDeptTransfer.DeleteRow(GrdDeptTransfer.GetRowHandle(GrdDeptTransfer.FocusedRowHandle));
                    }
                }
            }
        }

        private void BtnShowJanged_Click(object sender, EventArgs e)
        {
            DataTable DtData = ObjMix.GetDeptPendingJanged(Val.ToInt64(LookupCompany.EditValue), Val.ToInt64(LookupBranch.EditValue), Val.ToInt64(LookupLocation.EditValue)); ;
            DtData.Columns["JANGED_NO"].SetOrdinal(0);

            FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            FrmDevExpPopupGrid.DTab = DtData;
            //  FrmDevExpPopupGrid.CountedColumn = "JANGED_NO";
            FrmDevExpPopupGrid.MainGridDetail.DataSource = DtData;
            FrmDevExpPopupGrid.MainGridDetail.Refresh();
            FrmDevExpPopupGrid.Size = this.Size;

            //FrmDevExpPopupGrid.GrdDet.Columns["ROUGH_NAME"].Caption = "Rough";
            //FrmDevExpPopupGrid.GrdDet.Columns["BASE_ROUGH_NAME"].Caption = "Base Rough";
            //FrmDevExpPopupGrid.GrdDet.Columns["TEAM_NAME"].Caption = "Team";

            //FrmDevExpPopupGrid.GrdDet.Columns["TEAM_CODE"].Visible = false;
            //FrmDevExpPopupGrid.GrdDet.Columns["EMPLOYEE_CODE"].Visible = false;
            //FrmDevExpPopupGrid.GrdDet.Columns["APPROVE_BY"].Visible = false;

            FrmDevExpPopupGrid.ShowDialog();

            if (FrmDevExpPopupGrid.DRow != null)
            {
                string StrIssueJangedNo = Val.ToString(FrmDevExpPopupGrid.DRow["Issue_Janged_No"]);
                string StrReceiveJangedNo = Val.ToString(FrmDevExpPopupGrid.DRow["Receive_Janged_No"]);
                string StrRoughJangedNo = Val.ToString(FrmDevExpPopupGrid.DRow["Rough_Janged_No"]);
                if (StrRoughJangedNo != "" && StrIssueJangedNo == "" && StrReceiveJangedNo == "")
                {
                    txtJanNo.Text = "";
                    Global.Confirm("This Janged Is Rough Original Issue Janged So You Can Not Accept From This Module.");
                    return;
                }
                mStrJangedDate = Val.ToString(FrmDevExpPopupGrid.DRow["Janged_Date"]);
                txtJanNo.Text = Val.ToString(FrmDevExpPopupGrid.DRow["Janged_No"]);

                Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
                DetailProperty.Janged_Date = Val.DBDate(mStrJangedDate);
                DetailProperty.Janged_No = Val.ToInt64(txtJanNo.Text);
                DataTable tdt = ObjMix.GetDeptJanged(DetailProperty);

                dgvDeptTransfer.DataSource = tdt;
                dgvDeptTransfer.Refresh();

                if (tdt.Rows.Count == 0)
                {
                    Global.Confirm("No Janged Record Found");
                    txtJanNo.Focus();
                    return;
                }
                else
                {
                    LookupFromProcess.EditValue = Val.ToInt64(Val.ToString(tdt.Rows[0]["From_Process_Code"]));
                    LookupToProcess.EditValue = Val.ToInt64(Val.ToString(tdt.Rows[0]["To_Process_Code"]));
                    CmbSupplier.EditValue = Val.ToString(tdt.Rows[0]["THROUGH_BY"]);
                    LookupRoughName.EditValue = Val.ToString(tdt.Rows[0]["Rough_Name"]);
                    LookupRoughType.EditValue = Val.ToString(tdt.Rows[0]["ROUGH_TYPE_CODE"]);
                    Int64 mIntFromDepartment = Val.ToInt64(tdt.Rows[0]["From_Department_Code"]);
                }

                DetailProperty = null;

            }
            FrmDevExpPopupGrid.Hide();
            FrmDevExpPopupGrid.Dispose();
            FrmDevExpPopupGrid = null;
        }

        private void BtnReceive_Click(object sender, EventArgs e)
        {
            Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
            DetailProperty.Janged_Date = Val.DBDate(mStrJangedDate);
            DetailProperty.Janged_No = Val.ToInt64(txtJanNo.Text);
            DetailProperty.Receive_Date = Val.DBDate(DTPEntryDate.EditValue.ToString());
            DetailProperty.Receive_Janged_No = txtJanNo.Text;

            int IntRes = ObjMix.SaveDepartmentReceive(DetailProperty);
            if (IntRes != -1)
            {
                Global.Confirm("Janged Receive Successfully");

                ClearDeptTabRec();
                txtJanNo.Focus();
            }
            mStrJangedDate = "";
            DetailProperty = null;

            CountPendingMemo();
        }

        public void CountPendingMemo()
        {
            DataTable DTab = ObjMix.GetDeptPendingJanged(Val.ToInt64(LookupCompany.EditValue), Val.ToInt64(LookupBranch.EditValue), Val.ToInt64(LookupLocation.EditValue)); ;
            BtnShowJanged.Text = "Pending Memo (" + DTab.Rows.Count.ToString() + ")";
            DTab.Rows.Clear();
        }

        private void ClearDeptTabRec()
        {
            LookupRoughType.EditValue = null;
            LookupFromProcess.EditValue = null;
            LookupToProcess.EditValue = null;
            LookupRoughName.EditValue = null;
            txtJanNo.Text = "";
            dgvDeptTransfer.DataSource = null;

        }

        private void FrmDepartmentTransfer_Shown(object sender, EventArgs e)
        {
            btnClear_Click(btnClear, null);
            LookupFromProcess.Focus();
            DTPEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            Global.LOOKUPCompany(LookupCompany);
            Global.LOOKUPBranch(LookupBranch);
            Global.LOOKUPLocation(LookupLocation);

            LookupCompany.EditValue = GlobalDec.gEmployeeProperty.Company_Code;
            LookupCompany.ClosePopup();

            LookupBranch.EditValue = GlobalDec.gEmployeeProperty.Branch_Code;
            LookupBranch.ClosePopup();

            LookupLocation.EditValue = GlobalDec.gEmployeeProperty.Location_Code;
            LookupLocation.ClosePopup();
            FromDept = GlobalDec.gEmployeeProperty.Department_Code;

            Global.LOOKUPRough(LookupRoughName);
            Global.LOOKUPRoughTypeCode(LookupRoughType);
            Global.LOOKUPProcess(LookupFromProcess);
            Global.LOOKUPProcess(LookupToProcess);
            Global.LOOKUPDepartmentRep(repositoryItemLookUpEdit2);
            Global.LOOKUPSieveRep(repositoryItemLookUpEdit1);
            Global.LOOKUPClarityRep(LookUpClarity);

            try
            {
                DataTable DTab_Supplier = ObjMix.Dept_Supplier_GetData();
                object[] Supplier = DTab_Supplier.AsEnumerable().Select(r => r.Field<string>("THROUGH_BY")).Distinct().ToArray();
                CmbSupplier.Properties.Items.AddRange(Supplier);
            }
            catch (Exception) { }
            //   BtnDeptShow.PerformClick();
            CountPendingMemo();
            GetDeptBalance();
        }
    }
}
