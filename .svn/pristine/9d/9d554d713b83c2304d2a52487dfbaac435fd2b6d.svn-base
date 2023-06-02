using BLL.FunctionClasses.Entry;
using BLL.PropertyClasses.Transaction;
using BLL.FunctionClasses.Transaction;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using BLL.PropertyClasses.Entry;
using MARGO.Class;

namespace MARGO
{
    public partial class FrmRoughCreationMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        RoughMaster objRough = new RoughMaster();
        DataTable DTab = new DataTable();

        public FrmRoughCreationMaster()
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
            txtRoughCode.Text = "0";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtAmountDollar.Text = "";
            txtAmountLocal.Text = "";
            txtPcs.Text = "";
            txtCarat.Text = "";
            txtRateDollar.Text = "";
            txtRateLocal.Text = "";
            CmbRough.Text = "";
            CmbSource.Text = "";
            CmbSrcCompany.Text = "";
            CmbArticle.Text = "";
            CmbMSize.Text = "";
            CmbQuality.Text = "";
            CmbSubQuality.Text = "";
            CmbSight.Text = "";
            txtCompleteDays.Text = "";
            DTCompleteDate.Text = "";
            LookupCompany.Focus();
            DTPEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            LookupCompany.EditValue = null;
            LookupBranch.EditValue = null;
            LookupLocation.EditValue = null;
            LookupDepartment.EditValue = null;
            LookupRoughType.EditValue = null;

            CmbRough.Properties.Items.Clear();
            CmbSource.Properties.Items.Clear();
            CmbSrcCompany.Properties.Items.Clear();
            CmbArticle.Properties.Items.Clear();
            CmbMSize.Properties.Items.Clear();
            CmbQuality.Properties.Items.Clear();
            CmbSubQuality.Properties.Items.Clear();
            CmbSight.Properties.Items.Clear();

            object[] Rough = DTab.AsEnumerable().Select(r => r.Field<string>("ROUGH_NAME")).Distinct().ToArray();
            CmbRough.Properties.Items.AddRange(Rough);
            object[] SOURCE = DTab.AsEnumerable().Select(r => r.Field<string>("SOURCE")).Distinct().ToArray();
            CmbSource.Properties.Items.AddRange(SOURCE);
            object[] SOURCE_COMPANY = DTab.AsEnumerable().Select(r => r.Field<string>("SOURCE_COMPANY")).Distinct().ToArray();
            CmbSrcCompany.Properties.Items.AddRange(SOURCE_COMPANY);
            object[] Article = DTab.AsEnumerable().Select(r => r.Field<string>("ARTICLE")).Distinct().ToArray();
            CmbArticle.Properties.Items.AddRange(Article);
            object[] MSIZE = DTab.AsEnumerable().Select(r => r.Field<string>("MSIZE")).Distinct().ToArray();
            CmbMSize.Properties.Items.AddRange(MSIZE);
            object[] QUALITY = DTab.AsEnumerable().Select(r => r.Field<string>("QUALITY")).Distinct().ToArray();
            CmbQuality.Properties.Items.AddRange(QUALITY);
            object[] SUBQUALITY = DTab.AsEnumerable().Select(r => r.Field<string>("SUBQUALITY")).Distinct().ToArray();
            CmbSubQuality.Properties.Items.AddRange(SUBQUALITY);
            object[] SIGHT = DTab.AsEnumerable().Select(r => r.Field<string>("SIGHT")).Distinct().ToArray();
            CmbSight.Properties.Items.AddRange(SIGHT);
        }

        #region Validation

        private bool ValSave()
        {
            if (Convert.ToString(LookupCompany.EditValue) == "")
            {
                Global.Confirm("Company is required");
                LookupCompany.Focus();
                return false;
            }
            if (Convert.ToString(LookupBranch.EditValue) == "")
            {
                Global.Confirm("Branch is required");
                LookupBranch.Focus();
                return false;
            }
            if (Convert.ToString(LookupLocation.EditValue) == "")
            {
                Global.Confirm("Location is required");
                LookupLocation.Focus();
                return false;
            }
            if (Convert.ToString(LookupDepartment.EditValue) == "")
            {
                Global.Confirm("Department is required");
                LookupDepartment.Focus();
                return false;
            }
            if (Convert.ToString(CmbRough.EditValue) == "")
            {
                Global.Confirm("Rough Name is required");
                CmbRough.Focus();
                return false;
            }
            if (txtCarat.Text.Length == 0)
            {
                Global.Confirm("Carat is Required");
                txtCarat.Focus();
                return false;
            }
            if (Convert.ToDouble(txtCarat.EditValue) <= 0)
            {
                MARGO.Class.Global.Confirm("Carat Must Greater than Zero");
                txtCarat.Focus();
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

            Rough_MasterProperty RoughMasterProperty = new Rough_MasterProperty();
            Int64 Code = Val.ToInt64(txtRoughCode.Text);
            RoughMasterProperty.Rough_Code = Val.ToInt64(Code);
            RoughMasterProperty.Rough_Name = Val.ToString(CmbRough.Text);
            RoughMasterProperty.Company_Code = Val.ToInt64(LookupCompany.EditValue);
            RoughMasterProperty.Branch_Code = Val.ToInt64(LookupBranch.EditValue);
            RoughMasterProperty.Location_Code = Val.ToInt64(LookupLocation.EditValue);
            RoughMasterProperty.Department_Code = Val.ToInt64(LookupDepartment.EditValue);
            RoughMasterProperty.Status = Val.ToInt(RBtnStatus.Text);
            RoughMasterProperty.Remark = txtRemark.Text;

            RoughMasterProperty.Org_Pcs = Val.Val(txtPcs.Text);
            RoughMasterProperty.Org_Carat = Val.Val(txtCarat.Text);
            RoughMasterProperty.Balance_Pcs = Val.ToDecimal(txtPcs.Text);
            RoughMasterProperty.Balance_Carat = Val.ToDecimal(txtCarat.Text);

            RoughMasterProperty.Rate_Dollar = Val.Val(txtRateDollar.Text);
            RoughMasterProperty.Rate_Local = Val.Val(txtRateLocal.Text);

            RoughMasterProperty.Amount_Dollar = Val.Val(txtAmountDollar.Text);
            RoughMasterProperty.Amount_Local = Val.Val(txtAmountLocal.Text);

            RoughMasterProperty.Source_Name = Val.ToString(CmbSource.Text);
            RoughMasterProperty.Source_Company_Name = Val.ToString(CmbSrcCompany.Text);
            RoughMasterProperty.Article_Name = Val.ToString(CmbArticle.Text);
            RoughMasterProperty.Msize_Name = Val.ToString(CmbMSize.Text);
            RoughMasterProperty.Quality_Name = Val.ToString(CmbQuality.Text);
            RoughMasterProperty.SubQuality_Name = Val.ToString(CmbSubQuality.Text);
            RoughMasterProperty.Sight_Type_Name = Val.ToString(CmbSight.Text);
            RoughMasterProperty.Rough_Type = Val.ToInt64(LookupRoughType.EditValue);
            RoughMasterProperty.Complete_Date = Val.DBDate(DTCompleteDate.Text);
            RoughMasterProperty.Complete_Days = Val.ToDouble(txtCompleteDays.Text);
            RoughMasterProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);

            int IntRes = objRough.Save(RoughMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Rough Master Details");
            }
            else
            {
                DeptSave(Val.ToInt(txtRoughCode.Text));

                if (Code == 0)
                {
                    Global.Confirm("Rough Master Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Rough Master Details Data Update Successfully");
                }
                GetData();
                btnClear_Click(sender, e);
            }
            RoughMasterProperty = null;
        }

        private void DeptSave(Int64 rID)
        {
            ClvMixDeptIssRet ObjMix = new ClvMixDeptIssRet();
            Mix_IssRet_MasterProperty DeptTransferProperty = new Mix_IssRet_MasterProperty();
            Int64 Janged_No = 0; int IntRes = 0; Int64 DtlID = 0;
            if (rID != 0)
            {
                DeptTransferProperty.From_Process_Code = 1;
                DeptTransferProperty.To_Process_Code = 1;
                DeptTransferProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);
                DeptTransferProperty.From_Location_Code = Val.ToInt64(LookupLocation.EditValue);
                DeptTransferProperty.From_Company_Code = Val.ToInt64(LookupCompany.EditValue);
                DeptTransferProperty.From_Branch_Code = Val.ToInt64(LookupBranch.EditValue);
                //    DeptTransferProperty.Through_By = Val.ToString(CmbSupplier.Text);
                DeptTransferProperty.Rough_Name = Val.ToString(CmbRough.Text);
                DeptTransferProperty.Rough_Type_Code = Val.ToInt64(LookupRoughType.EditValue);
                DeptTransferProperty.Sieve_Code = 0;
                DeptTransferProperty.Clarity_Code = 0;

                DataTable DTab = ObjMix.Dept_Transfer_GetData(DeptTransferProperty);

                if (DTab.Rows.Count > 0)
                {
                    rID = Convert.ToInt64(Convert.ToString(DTab.Rows[0]["DEPT_ISSRET_ID"]));
                    Janged_No = Convert.ToInt64(Convert.ToString(DTab.Rows[0]["JANGED_NO"]));
                    DtlID = Convert.ToInt64(Convert.ToString(DTab.Rows[0]["DEPT_ISSRET_DTL_ID"]));
                }
            }


            DeptTransferProperty.Janged_Date = Val.DBDate(DTPEntryDate.Text);

            if (rID == 0)
            {
                Janged_No = Val.ToInt64(ObjMix.FindNewJangedNo(DTPEntryDate.Text));
                DeptTransferProperty.Janged_No = Janged_No;
            }
            DeptTransferProperty.From_Process_Code = 1;
            DeptTransferProperty.To_Process_Code = 1;
            DeptTransferProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);
            DeptTransferProperty.From_Location_Code = Val.ToInt64(LookupLocation.EditValue);
            DeptTransferProperty.Through_By = Val.ToString("");
            DeptTransferProperty.Rough_Name = Val.ToString(CmbRough.Text);
            DeptTransferProperty.P_ID = rID;
            DeptTransferProperty.Issue_Janged_No = Janged_No.ToString();

            Int64 mstID = ObjMix.Master_Save(DeptTransferProperty);
            Int64 Newmstid = Val.ToInt64(DeptTransferProperty.new_ID.ToString());
            //lblID.Text = DeptTransferProperty.new_ID.ToString();

            DeptTransferProperty = null;

            DeptTransferProperty = new Mix_IssRet_MasterProperty();

            DeptTransferProperty.Rough_Type_Code = Val.ToInt64(LookupRoughType.EditValue);
            DeptTransferProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);
            DeptTransferProperty.new_ID = Newmstid; //Newmstid);

            DeptTransferProperty.P_ID = DtlID;
            // DeptTransferProperty.DEPT_ISSRET_DTL_ID = DeptTransferProperty.new_ID;
            DeptTransferProperty.To_Department_Code = 1;
            DeptTransferProperty.Barcode = Val.ToString("");
            DeptTransferProperty.Sieve_Code = 1;
            DeptTransferProperty.Clarity_Code = 1;
            DeptTransferProperty.Issue_Pcs = Val.ToDouble(txtPcs.Text);
            DeptTransferProperty.Issue_Carat = Val.ToDouble(txtCarat.Text);

            DeptTransferProperty.Janged_Date = Val.DBDate(DTPEntryDate.Text);
            DeptTransferProperty.From_Process_Code = 1;
            DeptTransferProperty.To_Process_Code = 1;
            DeptTransferProperty.Rough_Name = Val.ToString(CmbRough.Text);
            DeptTransferProperty.Janged_No = Janged_No;
            IntRes += ObjMix.Detail_Save(DeptTransferProperty);


            DeptTransferProperty.Janged_No = Janged_No;  // DeptTransferProperty.Janged_No;
            DeptTransferProperty.Janged_Date = Val.DBDate(DTPEntryDate.EditValue.ToString());
            DeptTransferProperty.Receive_Date = Val.DBDate(DTPEntryDate.EditValue.ToString());
            DeptTransferProperty.Receive_Janged_No = Janged_No.ToString();  // DeptTransferProperty.Janged_No;
          
            IntRes += new ClvMixDeptIssRet().SaveDepartmentReceive(DeptTransferProperty);
        }

        public void GetData()
        {
            DTab = objRough.GetRoughMasterData();
            grdRoughMaster.DataSource = DTab;
            dgvRoughMaster.BestFitColumns();
        }

        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            LookupCompany.Focus();
            DTPEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            Global.LOOKUPCompany(LookupCompany);
            Global.LOOKUPBranch(LookupBranch);
            Global.LOOKUPLocation(LookupLocation);
            Global.LOOKUPDepartment(LookupDepartment);
            Global.LOOKUPRoughTypeCode(LookupRoughType);

            CmbRough.Properties.Items.Clear();
            CmbSource.Properties.Items.Clear();
            CmbSrcCompany.Properties.Items.Clear();
            CmbArticle.Properties.Items.Clear();
            CmbMSize.Properties.Items.Clear();
            CmbQuality.Properties.Items.Clear();
            CmbSubQuality.Properties.Items.Clear();
            CmbSight.Properties.Items.Clear();

            object[] Rough = DTab.AsEnumerable().Select(r => r.Field<string>("ROUGH_NAME")).Distinct().ToArray();
            CmbRough.Properties.Items.AddRange(Rough);
            object[] SOURCE = DTab.AsEnumerable().Select(r => r.Field<string>("SOURCE")).Distinct().ToArray();
            CmbSource.Properties.Items.AddRange(SOURCE);
            object[] SOURCE_COMPANY = DTab.AsEnumerable().Select(r => r.Field<string>("SOURCE_COMPANY")).Distinct().ToArray();
            CmbSrcCompany.Properties.Items.AddRange(SOURCE_COMPANY);
            object[] Article = DTab.AsEnumerable().Select(r => r.Field<string>("ARTICLE")).Distinct().ToArray();
            CmbArticle.Properties.Items.AddRange(Article);
            object[] MSIZE = DTab.AsEnumerable().Select(r => r.Field<string>("MSIZE")).Distinct().ToArray();
            CmbMSize.Properties.Items.AddRange(MSIZE);
            object[] QUALITY = DTab.AsEnumerable().Select(r => r.Field<string>("QUALITY")).Distinct().ToArray();
            CmbQuality.Properties.Items.AddRange(QUALITY);
            object[] SUBQUALITY = DTab.AsEnumerable().Select(r => r.Field<string>("SUBQUALITY")).Distinct().ToArray();
            CmbSubQuality.Properties.Items.AddRange(SUBQUALITY);
            object[] SIGHT = DTab.AsEnumerable().Select(r => r.Field<string>("SIGHT")).Distinct().ToArray();
            CmbSight.Properties.Items.AddRange(SIGHT);
        }

        private void LookupDepartment_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmDepartmentMaster frmCnt = new FrmDepartmentMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPDepartment(LookupDepartment);
            }
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

        private void dgvRoughMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvRoughMaster.GetDataRow(e.RowHandle);
                    txtRoughCode.Text = Convert.ToString(Drow["ROUGH_CODE"]);
                    CmbRough.Text = Convert.ToString(Drow["ROUGH_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["STATUS"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                    LookupCompany.EditValue = Convert.ToInt64(Drow["COMPANY_CODE"]);
                    LookupLocation.EditValue = Convert.ToInt64(Drow["LOCATION_CODE"]);
                    LookupDepartment.EditValue = Convert.ToInt64(Drow["DEPARTMENT_CODE"]);
                    LookupBranch.EditValue = Convert.ToInt64(Drow["BRANCH_CODE"]);
                    txtPcs.Text = Convert.ToString(Drow["ORG_PCS"]);
                    txtCarat.Text = Convert.ToString(Drow["ORG_CARAT"]);
                    txtAmountDollar.Text = Convert.ToString(Drow["AMOUNT_$"]);
                    txtAmountLocal.Text = Convert.ToString(Drow["AMOUNT_RS"]);
                    txtRateDollar.Text = Convert.ToString(Drow["RATE_$"]);
                    txtRateLocal.Text = Convert.ToString(Drow["RATE_RS"]);
                    CmbSource.Text = Convert.ToString(Drow["SOURCE"]);
                    CmbSrcCompany.Text = Convert.ToString(Drow["SOURCE_COMPANY"]);
                    CmbArticle.Text = Convert.ToString(Drow["ARTICLE"]);
                    CmbMSize.Text = Convert.ToString(Drow["MSIZE"]);
                    CmbQuality.Text = Convert.ToString(Drow["QUALITY"]);
                    CmbSubQuality.Text = Convert.ToString(Drow["SUBQUALITY"]);
                    CmbSight.Text = Convert.ToString(Drow["SIGHT"]);
                    LookupRoughType.EditValue = Convert.ToInt64(Drow["ROUGH_TYPE_CODE"]);
                    DTPEntryDate.Text = Val.DBDate(Drow["ENTRY_DATE"].ToString());
                    DTCompleteDate.Text = Val.DBDate(Drow["COMPLETE_DATE"].ToString());
                    txtCompleteDays.Text = Convert.ToString(Drow["COMPLETE_DAYS"]);
                }
            }
        }

        private void txtRateDollar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double Crts = Val.ToDouble(txtCarat.Text);
                double Rate_Dollor = Val.ToDouble(txtRateDollar.Text);
                double AmtDollor = Math.Round(Val.ToDouble(Crts * Rate_Dollor),2);
                txtAmountDollar.Text = AmtDollor.ToString();
            }  
        }

        private void txtRateLocal_KeyDown(object sender, KeyEventArgs e)
        {
            double Crts = Val.ToDouble(txtCarat.Text);
            double Rate_Local = Val.ToDouble(txtRateLocal.Text);
            double AmtLocal = Math.Round(Val.ToDouble(Crts * Rate_Local), 2);
            txtAmountLocal.Text = AmtLocal.ToString();
        }
    }
}
