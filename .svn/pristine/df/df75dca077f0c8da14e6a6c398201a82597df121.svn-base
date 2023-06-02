using BLL.FunctionClasses.Entry;
using BLL.FunctionClasses.Master;
using System;
using System.Data;
using System.Windows.Forms;
using BLL.PropertyClasses.Transaction;
using BLL.FunctionClasses.Transaction;
using MARGO.Class;

namespace MARGO
{
    public partial class FrmEmployeeIssRet : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        ClvMixDeptIssRet ObjMix = new ClvMixDeptIssRet();
        DepartmentMaster objDepartment = new DepartmentMaster();
        RoughTypeMaster objRoughType = new RoughTypeMaster();
        SieveMaster objSieve = new SieveMaster();
        ShapeMaster objShape = new ShapeMaster();
        EmployeeMaster objEmployee = new EmployeeMaster();
        ClarityMaster objClarity = new ClarityMaster();
        ProcessMaster objProcess = new ProcessMaster();
        RoughMaster objRough = new RoughMaster();
        DataTable DTab = new DataTable();

        public FrmEmployeeIssRet()
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
            DTPEntryIssDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            LookupFromIssProcess.EditValue = null;
            LookupIssToProcess.EditValue = null;
            LookupIssRoughName.EditValue = null;
            LookupIssRoughType.EditValue = null;
            LookupIssShapeName.EditValue = null;
            DTPEntryRetDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            LookupFromRecProcess.EditValue = null;
            LookupFromRecRoughName.EditValue = null;
            LookupFromRecRoughType.EditValue = null;
            LookupFromRecShape.EditValue = null;
            LookUpToEmployee.EditValue = null;
            txtEmpRecBalance.Text = "";
            txtSubEmpIssuedCarat.Text = "";
            dgvEmpIssue.DataSource = null;
            dgvEmpReturn.DataSource = null;
            panelControl7.Enabled = true;
            dgvEmpIssue.Enabled = false;
            panelControl6.Enabled = false;
            dgvEmpIssue.DataSource = null;
            panelControl8.Enabled = true;
            dgvEmpReturn.Enabled = false;
            dgvEmpReturn.DataSource = null;
        }

        #region Validation

        private bool ValSave(string Typ)
        {
            if (Typ == "I")
            {
                if (!Global.MCheckEmpty(ColIssEmp, GrdEmpIssue, "To Employee"))
                {
                    return false;
                }
                if (!Global.MCheckEmpty(ColIssSieve, GrdEmpIssue, "Sieve"))
                {
                    return false;
                }
                if (!Global.MCheckEmpty(ColIssCrt, GrdEmpIssue, "Carat"))
                {
                    return false;
                }
                if (!Global.ChkAdmin())
                {
                    if (Val.ToDecimal(ColIssCrt.SummaryText) > Val.ToDecimal(txtEmpIssBalance.EditValue))
                    {
                        MARGO.Class.Global.Confirm("Issue Carat Must Not Greater Than Balance Carat");
                        return false;
                    }
                }
            }
            else if (Typ == "R")
            {
                if (!Global.MCheckEmpty(ColRetToprocess, GrdEmpReturn, "To Process"))
                {
                    return false;
                }
                if (!Global.MCheckEmpty(ColRetSieve, GrdEmpReturn, "Sieve"))
                {
                    return false;
                }
                if (!Global.MCheckEmpty(ColRetCrt, GrdEmpReturn, "Carat"))
                {
                    return false;
                }
                if (!Global.ChkAdmin())
                {
                    if ((Val.ToDecimal(ColRetCrt.SummaryText) - Val.ToDecimal(ColRecWLoss.SummaryText) + Val.ToDecimal(ColRecWPlus.SummaryText)) > Val.ToDecimal(txtEmpRecBalance.EditValue))
                    {
                        MARGO.Class.Global.Confirm("Return Carat Must Not Greater Than Balance Carat");
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {           
            int IntRes = 0;
            Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
            if (TabEmpIssue.SelectedTabPageIndex == 0)
            {
                if (ValSave("I") == false)
                {
                    return;
                }
                DetailProperty.From_Process_Code = Val.ToInt64(LookupFromIssProcess.EditValue);
                DetailProperty.Entry_Date = Val.DBDate(DTPEntryIssDate.Text);
                DetailProperty.Rough_Name = Val.ToString(LookupIssRoughName.EditValue);
                DetailProperty.Rough_Type_Code = Val.ToInt64(LookupIssRoughType.EditValue);
                DetailProperty.Shape_Code = Val.ToInt64(LookupIssShapeName.EditValue);
                DetailProperty.To_Process_Code = Val.ToInt64(LookupIssToProcess.EditValue);
                DetailProperty.Type = Val.ToString("I");

                System.Data.DataTable DTab = (System.Data.DataTable)dgvEmpIssue.DataSource;
                DTab.AcceptChanges();
                if (DTab.Rows.Count > 0)
                {
                    for (int i = 0; i < DTab.Rows.Count; i++)
                    {
                        DetailProperty.P_ID = Val.ToInt64(DTab.Rows[i]["EMP_ISSRET_DTL_ID"]);
                        DetailProperty.Employee_Code = Val.ToInt64(DTab.Rows[i]["EMPLOYEE_CODE"]);
                        DetailProperty.Barcode = Val.ToString(DTab.Rows[i]["BARCODE"]);
                        DetailProperty.Sieve_Code = Val.ToInt64(DTab.Rows[i]["SIEVE_CODE"]);
                        DetailProperty.Clarity_Code = Val.ToInt64(DTab.Rows[i]["CLARITY_CODE"]);
                        DetailProperty.Issue_Pcs = Val.ToDouble(DTab.Rows[i]["PCS"]);
                        DetailProperty.Issue_Carat = Val.ToDouble(DTab.Rows[i]["CARAT"]);
                        DetailProperty.Loss_Carat = Val.ToDouble(DTab.Rows[i]["LOSS_CARAT"]);
                        DetailProperty.Carat_Plus = Val.ToDouble(DTab.Rows[i]["CARAT_PLUS"]);

                        IntRes += ObjMix.Emp_IssRet_Save(DetailProperty);
                    }

                    if (IntRes == -1)
                    {
                        MARGO.Class.Global.Confirm("Error In Save Employee Issue Return Data");
                    }
                    else
                    {
                        MARGO.Class.Global.Confirm("Employee Issue Return Data Save Successfully");
                        //  btnClear_Click(sender, e);
                    }
                    DetailProperty = null;
                }
                //BtnEmpIssShow.PerformClick();
                BtnEmpIssShow_Click(null, null);
                //GetEmpIssBalance();
            }
            else if (TabEmpIssue.SelectedTabPageIndex == 1)
            {
                if (ValSave("R") == false)
                {
                    return;
                }
                DetailProperty.From_Process_Code = Val.ToInt64(LookupFromRecProcess.EditValue);
                DetailProperty.Entry_Date = Val.DBDate(DTPEntryRetDate.Text);
                DetailProperty.Rough_Name = Val.ToString(LookupFromRecRoughName.EditValue);
                DetailProperty.Rough_Type_Code = Val.ToInt64(LookupFromRecRoughType.EditValue);
                DetailProperty.Shape_Code = Val.ToInt64(LookupFromRecShape.EditValue);
                DetailProperty.Employee_Code = Val.ToInt64(LookUpToEmployee.EditValue);
                DetailProperty.Type = Val.ToString("R");

                System.Data.DataTable DTab = (System.Data.DataTable)dgvEmpReturn.DataSource;
                DTab.AcceptChanges();
                if (DTab.Rows.Count > 0)
                {
                    for (int i = 0; i < DTab.Rows.Count; i++)
                    {
                        DetailProperty.P_ID = Val.ToInt64(DTab.Rows[i]["EMP_ISSRET_DTL_ID"]);
                        DetailProperty.To_Process_Code = Val.ToInt64(DTab.Rows[i]["PROCESS_CODE"]);
                        DetailProperty.Barcode = Val.ToString(DTab.Rows[i]["BARCODE"]);
                        DetailProperty.Sieve_Code = Val.ToInt64(DTab.Rows[i]["SIEVE_CODE"]);
                        DetailProperty.Clarity_Code = Val.ToInt64(DTab.Rows[i]["CLARITY_CODE"]);
                        DetailProperty.Issue_Pcs = Val.ToDouble(DTab.Rows[i]["PCS"]);
                        DetailProperty.Issue_Carat = Val.ToDouble(DTab.Rows[i]["CARAT"]);
                        DetailProperty.Loss_Carat = Val.ToDouble(DTab.Rows[i]["LOSS_CARAT"]);
                        DetailProperty.Carat_Plus = Val.ToDouble(DTab.Rows[i]["CARAT_PLUS"]);

                        IntRes += ObjMix.Emp_IssRet_Save(DetailProperty);
                    }

                    if (IntRes == -1)
                    {
                        MARGO.Class.Global.Confirm("Error In Save Employee Issue Return Data");
                    }
                    else
                    {
                        MARGO.Class.Global.Confirm("Employee Issue Return Data Save Successfully");
                        //  btnClear_Click(sender, e);
                    }
                    DetailProperty = null;
                }
                //BtnEmpRecShow.PerformClick();
                BtnEmpIssShow_Click(null, null);
                //  GetEmpRecBalance();
            }
        }

        private void GetEmpIssBalance()
        {
            Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
            DetailProperty.From_Process_Code = Val.ToInt64(LookupFromIssProcess.EditValue);
            DetailProperty.Rough_Name = Val.ToString(LookupIssRoughName.EditValue);
            DetailProperty.Rough_Type_Code = Val.ToInt64(LookupIssRoughType.EditValue);
            DetailProperty.Entry_Date = Val.ToString(DTPEntryIssDate.EditValue);

            txtEmpIssBalance.Text = Math.Round(Val.ToDecimal(ObjMix.GetDeptBalance(DetailProperty)["BALANCE_CARAT"]), 3).ToString();

            DetailProperty = null;
        }

        private void GetEmpRecBalance()
        {
            txtEmpRecBalance.Text = "";
            Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
            DetailProperty.From_Process_Code = Val.ToInt64(LookupFromRecProcess.EditValue);
            DetailProperty.Rough_Name = Val.ToString(LookupFromRecRoughName.EditValue);
            DetailProperty.Employee_Code = Val.ToInt64(LookUpToEmployee.EditValue);
            DataRow DRow = ObjMix.GetEmpRetBalance(DetailProperty);
            if (DRow != null)
            {
                txtEmpRecBalance.Text = Math.Round(Val.ToDecimal(DRow["BALANCE_CARAT"]), 3).ToString();
            }

            //dgvEmpRecSieveWise.DataSource = null;
            //dgvEmpRecSieveWise.RefreshDataSource();


            //if (SplitContainerEmpRec.Panel2Collapsed == false)
            //{
            //    ObjMix.GetEmployeeStock_By_Sieve_Clarity_Process(DetailProperty, mStrStockField);


            //    dgvEmpRecSieveWise.DataSource = ObjMix.DS.Tables[BLL.TPV.Table.MixStockDetailWiseEmpRec];
            //    dgvEmpRecSieveWise.RefreshDataSource();

            //    GridEmpRecSieveSum.Columns["SIEVE"].VisibleIndex = 0;
            //    GridEmpRecSieveSum.Columns["BALANCE"].VisibleIndex = 1;

            //    GridEmpRecSieveSum.Columns["SIEVE"].Visible = true;

            //    foreach (DevExpress.XtraGrid.Columns.GridColumn Column in GridEmpRecSieveSum.Columns)
            //    {
            //        Column.Caption = Column.FieldName;
            //        Column.Caption = Column.Caption.Replace("_", " ");
            //        Column.Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Column.Caption.ToLower());
            //    }

            //    GridEmpRecSieveSum.Columns["BALANCE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            //    GridEmpRecSieveSum.Columns["BALANCE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //    GridEmpRecSieveSum.Columns["BALANCE"].SummaryItem.DisplayFormat = "{0:N2}";

            //    GridEmpRecSieveSum.BestFitColumns();
            //}
            DetailProperty = null;
            DRow = null;
        }

        private void LookupRoughType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmRoughTypeMaster frmCnt = new FrmRoughTypeMaster();
                frmCnt.ShowDialog();
            }
        }

        private void LookupFromProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
            }
        }

        private void LookupRoughName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmRoughCreationMaster frmCnt = new FrmRoughCreationMaster();
                frmCnt.ShowDialog();
            }
        }

        private void LookupShapeName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmShapeMaster frmCnt = new FrmShapeMaster();
                frmCnt.ShowDialog();
            }
        }

        private void LookUpClarity_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmSieveMaster frmCnt = new FrmSieveMaster();
                frmCnt.ShowDialog();
            }
        }

        private void repositoryItemLookUpEdit5_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
            }
        }

        private void LookUpToEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmEmployeeMaster frmCnt = new FrmEmployeeMaster();
                frmCnt.ShowDialog();
            }
        }

        private void BtnEmpIssShow_Click(object sender, EventArgs e)
        {
           
            Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
            DataTable DTab = new DataTable();
            if (TabEmpIssue.SelectedTabPageIndex == 0)
            {
                if (Val.ToString(LookupIssToProcess.Text.Trim()) == "")
                {
                    MARGO.Class.Global.Confirm("To Process Required");
                    LookupIssToProcess.Focus();
                    return;
                }
                if (Val.ToString(LookupIssRoughType.Text.Trim()) == "")
                {
                    MARGO.Class.Global.Confirm("Rough Type Required");
                    LookupIssRoughType.Focus();
                    return;
                }
                if (Val.ToString(DTPEntryIssDate.Text.Trim()) == "")
                {
                    MARGO.Class.Global.Confirm("Entry Date Required");
                    DTPEntryIssDate.Focus();
                    return;
                }
                                
                DetailProperty.From_Process_Code = Val.ToInt64(LookupFromIssProcess.EditValue);
                DetailProperty.Entry_Date = Val.DBDate(DTPEntryIssDate.Text);
                DetailProperty.Rough_Name = Val.ToString(LookupIssRoughName.EditValue);
                DetailProperty.Rough_Type_Code = 0; // Val.ToInt64(LookupIssRoughType.EditValue);
                DetailProperty.Shape_Code = Val.ToInt64(LookupIssShapeName.EditValue);
                DetailProperty.To_Process_Code = Val.ToInt64(LookupIssToProcess.EditValue);
                DetailProperty.Type = Val.ToString("I");
                DTab = ObjMix.Employee_Issue_GetData(DetailProperty);
                if (Global.ChkAdmin())
                { dgvEmpIssue.DataSource = DTab; }
                else
                { dgvEmpIssue.DataSource = DTab.Clone(); }
                panelControl7.Enabled = false;
                dgvEmpIssue.Enabled = true;
                panelControl6.Enabled = true;

                GetEmpIssBalance();
            }
            else if (TabEmpIssue.SelectedTabPageIndex == 1)
            {
                if (Val.ToString(LookUpToEmployee.Text.Trim()) == "")
                {
                    MARGO.Class.Global.Confirm("To Employee Required");
                    LookUpToEmployee.Focus();
                    return;
                }
                if (Val.ToString(LookupFromRecRoughType.Text.Trim()) == "")
                {
                    MARGO.Class.Global.Confirm("Rough Type Required");
                    LookupFromRecRoughType.Focus();
                    return;
                }
                if (Val.ToString(DTPEntryRetDate.Text.Trim()) == "")
                {
                    MARGO.Class.Global.Confirm("Entry Date Required");
                    DTPEntryRetDate.Focus();
                    return;
                }

                DetailProperty.From_Process_Code = Val.ToInt64(LookupFromRecProcess.EditValue);
                DetailProperty.Entry_Date = Val.DBDate(DTPEntryRetDate.Text);
                DetailProperty.Rough_Name = Val.ToString(LookupFromRecRoughName.EditValue);
                DetailProperty.Rough_Type_Code = 0;  // Val.ToInt64(LookupFromRecRoughType.EditValue);
                DetailProperty.Shape_Code = Val.ToInt64(LookupFromRecShape.EditValue);
                DetailProperty.Type = Val.ToString("R");
                DetailProperty.Employee_Code = Val.ToInt64(LookUpToEmployee.EditValue);
                DTab = ObjMix.Employee_Issue_GetData(DetailProperty);
                if (Global.ChkAdmin())
                { dgvEmpReturn.DataSource = DTab; }
                else
                { dgvEmpReturn.DataSource = DTab.Clone(); }

                panelControl8.Enabled = false;
                dgvEmpReturn.Enabled = true;
                panelControl6.Enabled = true;
                GetEmpRecBalance();
            }
        }

        private void dgvEmpIssue_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Global.ChkAdmin())
            {
                return;
            }
            if (e.KeyCode == Keys.F9)
            {
                if (TabEmpIssue.SelectedTabPageIndex == 0)
                {
                    if (Global.Confirm("Are you sure delete selected row in Employee Issue Entry?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Int64 Production = Val.ToInt64(GrdEmpIssue.GetFocusedRowCellValue("EMP_ISSRET_DTL_ID"));
                        if (Production > 0)
                        {
                            int IntRes = 0;
                            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
                            Property.P_ID = Val.ToInt64(GrdEmpIssue.GetFocusedRowCellValue("EMP_ISSRET_DTL_ID"));
                            Property.Type = Val.ToString("I");

                            IntRes = ObjMix.Employee_IssRet_RowDate_Delete(Property);

                            GrdEmpIssue.DeleteRow(GrdEmpIssue.GetRowHandle(GrdEmpIssue.FocusedRowHandle));
                        }
                        else if (Production == 0)
                        {
                            GrdEmpIssue.DeleteRow(GrdEmpIssue.GetRowHandle(GrdEmpIssue.FocusedRowHandle));
                        }
                    }
                }
                else if (TabEmpIssue.SelectedTabPageIndex == 1)
                {
                    if (Global.Confirm("Are you sure delete selected row in Employee Return Entry?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Int64 Production = Val.ToInt64(GrdEmpReturn.GetFocusedRowCellValue("EMP_ISSRET_DTL_ID"));
                        if (Production > 0)
                        {
                            int IntRes = 0;
                            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
                            Property.P_ID = Val.ToInt64(GrdEmpReturn.GetFocusedRowCellValue("EMP_ISSRET_DTL_ID"));
                            Property.Type = Val.ToString("R");

                            IntRes = ObjMix.Employee_IssRet_RowDate_Delete(Property);

                            GrdEmpReturn.DeleteRow(GrdEmpReturn.GetRowHandle(GrdEmpReturn.FocusedRowHandle));
                        }
                        else if (Production == 0)
                        {
                            GrdEmpReturn.DeleteRow(GrdEmpReturn.GetRowHandle(GrdEmpReturn.FocusedRowHandle));
                        }
                    }
                }
            }
        }

        private void TabRegisterDetail_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "TabEmpReturn")
            {
                BtnMngWight.Visible = true;
            }
            else
            {
                BtnMngWight.Visible = false;
            }
            panelControl6.Enabled = false;
            panelControl7.Enabled = true;
            panelControl8.Enabled = true;
            dgvEmpIssue.Enabled = false;
            dgvEmpReturn.Enabled = false;
        }

        private void BtnMngWight_Click(object sender, EventArgs e)
        {
            if ((Val.ToDecimal(txtEmpRecBalance.Text) - Val.ToDecimal(ColRetCrt.SummaryText) - Val.ToDecimal(ColRecWLoss.SummaryText) - Val.ToDecimal(ColRecWPlus.SummaryText)) < 0)
            {
                //GrdEmpReturn.AddNewRow();
                //GrdEmpReturn.SetRowCellValue(GrdEmpReturn.RowCount, "EMP_ISSRET_DTL_ID", 0);
                //GrdEmpReturn.SetRowCellValue(GrdEmpReturn.RowCount, "PROCESS_CODE", LookupFromRecProcess.EditValue);
                //GrdEmpReturn.SetRowCellValue(GrdEmpReturn.RowCount, "SIEVE_CODE", 1);
                //GrdEmpReturn.SetRowCellValue(GrdEmpReturn.RowCount, "CARAT", 0);
                //GrdEmpReturn.SetRowCellValue(GrdEmpReturn.RowCount, "PCS", 0);
                //GrdEmpReturn.SetRowCellValue(GrdEmpReturn.RowCount, "ColRecWLoss", 0);
                //GrdEmpReturn.SetRowCellValue(GrdEmpReturn.RowCount, "CARAT_PLUS", (Val.ToDecimal(txtEmpRecBalance.Text) - Val.ToDecimal(ColRetCrt.SummaryText) - Val.ToDecimal(ColRecWLoss.SummaryText) - Val.ToDecimal(ColRecWPlus.SummaryText)));
                DataTable tdt = (DataTable)dgvEmpReturn.DataSource;
                tdt.AcceptChanges();
                tdt.Rows.Add();
                tdt.Rows[tdt.Rows.Count - 1]["EMP_ISSRET_DTL_ID"] = 0;
                tdt.Rows[tdt.Rows.Count - 1]["PROCESS_CODE"] = LookupFromRecProcess.EditValue;
                tdt.Rows[tdt.Rows.Count - 1]["SIEVE_CODE"] = 1;
                tdt.Rows[tdt.Rows.Count - 1]["CARAT"] = 0;
                tdt.Rows[tdt.Rows.Count - 1]["PCS"] = 0;
                tdt.Rows[tdt.Rows.Count - 1]["LOSS_CARAT"] = 0;
                tdt.Rows[tdt.Rows.Count - 1]["CARAT_PLUS"] = Math.Abs((Val.ToDecimal(txtEmpRecBalance.Text) - Val.ToDecimal(ColRetCrt.SummaryText) - Val.ToDecimal(ColRecWLoss.SummaryText) + Val.ToDecimal(ColRecWPlus.SummaryText)));
                tdt.AcceptChanges();
                dgvEmpReturn.DataSource = tdt;
            }
            else
            {
                DataTable tdt = (DataTable)dgvEmpReturn.DataSource;
                tdt.AcceptChanges();
                tdt.Rows.Add();
                tdt.Rows[tdt.Rows.Count - 1]["EMP_ISSRET_DTL_ID"] = 0;
                tdt.Rows[tdt.Rows.Count - 1]["PROCESS_CODE"] = LookupFromRecProcess.EditValue;
                tdt.Rows[tdt.Rows.Count - 1]["SIEVE_CODE"] = 1;
                tdt.Rows[tdt.Rows.Count - 1]["CARAT"] = 0;
                tdt.Rows[tdt.Rows.Count - 1]["PCS"] = 0;
                tdt.Rows[tdt.Rows.Count - 1]["LOSS_CARAT"] = Math.Abs((Val.ToDecimal(txtEmpRecBalance.Text) - Val.ToDecimal(ColRetCrt.SummaryText) - Val.ToDecimal(ColRecWLoss.SummaryText) + Val.ToDecimal(ColRecWPlus.SummaryText)));
                tdt.Rows[tdt.Rows.Count - 1]["CARAT_PLUS"] = 0;
                tdt.AcceptChanges();
                dgvEmpReturn.DataSource = tdt;
            }
        }

        private void FrmEmployeeIssRet_Shown(object sender, EventArgs e)
        {
            Global.LOOKUPRough(LookupIssRoughName);
            Global.LOOKUPRoughTypeCode(LookupIssRoughType);
            Global.LOOKUPShape(LookupIssShapeName);
            Global.LOOKUPEmployee(LookupEmployee);
            Global.LOOKUPProcess(LookupFromIssProcess);
            Global.LOOKUPProcess(LookupIssToProcess);
            Global.LOOKUPSieveRep(repositoryItemLookUpEdit1);
            Global.LOOKUPEmployeeRep(repositoryItemLookUpEdit2);
            Global.LOOKUPEmployee(LookUpToEmployee);
            Global.LOOKUPClarityRep(LookUpClarity);
            Global.LOOKUPSieveRep(repositoryItemLookUpEdit3);
            Global.LOOKUPClarityRep(repositoryItemLookUpEdit5);
            Global.LOOKUPProcessRep(repositoryItemLookUpEdit4);
            Global.LOOKUPProcess(LookupFromRecProcess);
            Global.LOOKUPRough(LookupFromRecRoughName);
            Global.LOOKUPRoughTypeCode(LookupFromRecRoughType);
            Global.LOOKUPShape(LookupFromRecShape);
            btnClear_Click(btnClear, null);
            DTPEntryIssDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            LookupFromIssProcess.Focus();
        }

        private void FrmEmployeeIssRet_Load(object sender, EventArgs e)
        {
            if (Global.ChkAdmin())
            {
                lblDelMsg.Visible = true;
            }
        }


    }
}
