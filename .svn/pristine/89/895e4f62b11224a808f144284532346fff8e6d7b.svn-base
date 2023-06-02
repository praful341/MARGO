using System.Windows.Forms;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Transaction;
using System;
using System.Data;
using MARGO.Class;
using BLL;

namespace MARGO
{
    public partial class FrmPacket_LOTprep : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        PacketMaster ObjPacket = new PacketMaster();
        ClvMixDeptIssRet ObjMix = new ClvMixDeptIssRet();
        Int64 srno_ = 0;

        public FrmPacket_LOTprep()
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
        public void GetData()
        {
            //DataTable DTab = objCity.GetData_Search();
            //grdCityMaster.DataSource = DTab;
        }
        #region Validation

        private bool ValSave()
        {
            if (txtJangadNo.Text == "")
            {
                MARGO.Class.Global.Confirm("Jangad No is Required");
                txtJangadNo.Focus();
                return false;
            }
            if (txtBarcode.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Barcode is Required");
                txtBarcode.Focus();
                return false;
            }
            txtBarcode_Validated(null, null);
            if (lookUpShape.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Shape is Required");
                lookUpShape.Focus();
                return false;
            }
            if (lookUpmfgClrty.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("MFG Clarity is Required");
                lookUpmfgClrty.Focus();
                return false;
            }
            if (lookUpColor.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Color is Required");
                lookUpColor.Focus();
                return false;
            }
            if (lookUpRoughType.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Rough Type is Required");
                lookUpRoughType.Focus();
                return false;
            }
            if (lookUpSize.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Size is Required");
                lookUpSize.Focus();
                return false;
            }
            if (lookUpClvClarity.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("CLV Clarity is Required");
                lookUpClvClarity.Focus();
                return false;
            }
            if (lookUpSize.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Size is Required");
                lookUpSize.Focus();
                return false;
            }
            if (txtIssPcs.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Issue Pcs is Required");
                txtIssPcs.Focus();
                return false;
            }
            if (txtIssCrt.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Issue Carat is Required");
                txtIssCrt.Focus();
                return false;
            }
            if (Convert.ToDouble(txtIssPcs.EditValue) <= 0)
            {
                MARGO.Class.Global.Confirm("Issue Pcs Must Greater than Zero");
                txtIssPcs.Focus();
                return false;
            }
            if (Convert.ToDouble(txtIssCrt.EditValue) <= 0)
            {
                MARGO.Class.Global.Confirm("Issue Carat Must Greater than Zero");
                txtIssCrt.Focus();
                return false;
            }
            if (Val.Val(txtIssCrt.EditValue) > Val.Val(txtOutStandCrt.EditValue))
            {
                MARGO.Class.Global.Confirm("Issue Carat Must Not Greater than OutStanding Carat");
                txtIssCrt.Focus();
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

            try
            {
                if (Val.Val(txtJangadNo.Text) == 0)
                {
                    txtJangadNo.Text = Val.ToString(ObjPacket.FindNewJangedNo(DTPEntryDate.Text.ToString()));
                    if (Val.Val(txtJangadNo.Text) == 0)
                    {
                        Global.Confirm("Error In Jangad No");
                        return;
                    }
                }

                if (Val.ToInt(txtJangadNo.Text) == 0)
                {
                    Global.Confirm("Janged Not Generate Error Please Check");
                    return;
                }

                Packet_MasterProperty PacketMasterProperty = new Packet_MasterProperty();

                PacketMasterProperty.Janged_No = Val.ToInt64(txtJangadNo.EditValue);
                PacketMasterProperty.Rough_Name = Val.ToString(LookupRoughName.EditValue);
                PacketMasterProperty.Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
                PacketMasterProperty.Packet_No = 0;
                PacketMasterProperty.Barcode = Val.ToString(txtBarcode.EditValue);

                //if (lblMode.Text == "Edit Mode")
                //{
                //    PacketMasterProperty.Process_Code = Val.Int64(LookupFromProcess.EditValue);
                //    PacketMasterProperty.Packet_No = Val.ToInt64(txtPacketNo.Text);
                //}

                PacketMasterProperty.Rough_Type_Code = Val.ToInt64(lookUpRoughType.EditValue);
                PacketMasterProperty.Shape_Code = Val.ToInt64(lookUpShape.EditValue);
                PacketMasterProperty.Color_Code = Val.ToInt64(lookUpColor.EditValue);
                PacketMasterProperty.Clarity_Code = 0; // Val.ToInt64(lookUpClvClarity.EditValue);
                PacketMasterProperty.Clv_Clarity_Code = Val.ToInt64(lookUpClvClarity.EditValue);
                PacketMasterProperty.Department_Code = GlobalDec.gEmployeeProperty.Department_Code;  // Val.ToInt64(LookupDept.EditValue);
                PacketMasterProperty.Mfg_Clarity_Code = Val.ToInt64(lookUpmfgClrty.EditValue);
                PacketMasterProperty.Issue_Pcs = Val.Val(txtIssPcs.EditValue);
                PacketMasterProperty.Issue_Carat = Val.ToDouble(txtIssCrt.EditValue);
                PacketMasterProperty.Sieve_Code = Val.ToInt64(lookUpSize.EditValue);
                //PacketMasterProperty.Cut_Code = Val.ToInt64(txtCutType.Tag);
                PacketMasterProperty.Comp_No = Val.ToString(CmbCompType.SelectedItem);
                //PacketMasterProperty.Kapan_No = txtKapanNo.Text;
                PacketMasterProperty.EXP_Per = Val.ToDouble(txtExpWtPer.EditValue);
                PacketMasterProperty.EXP_By = Val.ToString(txtExpBy.EditValue);
                PacketMasterProperty.EXP_Per_Code = Val.ToString("");
                PacketMasterProperty.DM_Per = Val.ToDouble(txtDMPer.EditValue);
                PacketMasterProperty.DM_By = Val.ToString(txtDMBy.EditValue);
                PacketMasterProperty.Height = Val.ToDouble(txtHeight.EditValue);
                PacketMasterProperty.Max_Dia = Val.ToDouble(txtMaxDim.EditValue);
                PacketMasterProperty.Min_Dia = Val.ToDouble(txtMinDim.EditValue);
                PacketMasterProperty.Depth = Val.ToDouble(txtDepth.EditValue);
                PacketMasterProperty.Width = Val.ToDouble(0);
                PacketMasterProperty.Remark = Val.ToString(txtRemark.EditValue);
                PacketMasterProperty.MSize_Code = Val.ToInt64(0);
                PacketMasterProperty.Pointer = "";  // txtPointer.Text;
                //  PacketMasterProperty.Cut_Code = Val.ToInt64(0);
                PacketMasterProperty.Polish_Code = Val.ToInt64(0);
                PacketMasterProperty.Symmetry_Code = Val.ToInt64(0);
                PacketMasterProperty.Fluorescence_Code = Val.ToInt64(0);

                PacketMasterProperty.Issue_Type = Val.ToString(CmbIssueType.SelectedItem);
                PacketMasterProperty.Rate = Val.Val(txtRate.Text);
                PacketMasterProperty.Amount = Val.Val(txtAmount.Text);
                PacketMasterProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);
                PacketMasterProperty.Entry_Time = Val.GetFullTime12();
                PacketMasterProperty.Status = Val.ToString("EMP");
                PacketMasterProperty.Exp_Carat = Math.Round((Val.ToDouble(txtIssCrt.Text) * Val.ToDouble(txtExpWtPer.Text)) / 100, 3);

                PacketMasterProperty.SrNo = Val.ToInt64(0);

                //if (mStrROUGH_RATE_DATE != null)
                //{
                //    PacketMasterProperty.ROUGH_RATE_DATE = Val.DBDate(mStrROUGH_RATE_DATE);
                //}
                //if (mStrBANCKMARK_DATE != null)
                //{
                //    PacketMasterProperty.BANCKMARK_DATE = Val.DBDate(mStrBANCKMARK_DATE);
                //}
                //if (mStrPOLISH_CP_DATE != null)
                //{
                //    PacketMasterProperty.POLISH_CP_DATE = Val.DBDate(mStrPOLISH_CP_DATE);
                //}

                Int64 IntRes = ObjPacket.Save(PacketMasterProperty);
                srno_ = PacketMasterProperty.SrNo;

                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Packet Details....Please Contact To Administrator");
                }
                else
                {
                    Mix_IssRet_MasterProperty EmpProperty = SaveDetail();

                    //if (EmpProperty == null || EmpProperty.SrNo == 0)
                    //{
                    //ObjPacket.Delete(PacketMasterProperty);
                    // Global.Confirm("Error In Save Packet Details");
                    //LookupRoughName.Focus();
                    // }

                    //else
                    //{
                    //if (ChkBarcodePrint.Checked == true)
                    //{
                    //    Global.BarcodePrint(txtBarcodeNo.Text);
                    //}

                    txtIssPcs.EditValue = "";
                    txtIssCrt.EditValue = "";
                    txtBarcode.EditValue = "";
                    txtRate.EditValue = "";
                    txtAmount.EditValue = "";
                    txtRemark.EditValue = "";
                    //       txtPointer.EditValue = "";
                    txtExpWtPer.EditValue = "";
                    txtDMPer.EditValue = "";
                    //     txtExpCDPer.EditValue = "";
                    txtMaxDim.EditValue = "";
                    txtMinDim.EditValue = "";
                    txtHeight.EditValue = "";
                    txtDepth.EditValue = "";
                    CmbIssueType.SelectedIndex = 0;
                    CmbCompType.SelectedIndex = 0;
                    txtBarcode.Enabled = true;
                    BtnShowBalance_Click(null, null);
                    txtBarcode.Focus();
                    //}
                    PacketMasterProperty = null;
                    EmpProperty = null;
                    srno_ = 0;
                    BtnEmpIssShow_Click(null, null);

                }

            }
            catch (Exception ex)
            {
                Global.Confirm(ex.ToString());
                //Packet_MasterProperty PacketMasterProperty = new Packet_MasterProperty();
                //PacketMasterProperty.Barcode = txtBarcodeNo.Text;
                //ObjPacket.Delete(PacketMasterProperty);
                //PacketMasterProperty = null;
            }
        }

        private Mix_IssRet_MasterProperty SaveDetail()
        {

            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
            //if (lblMode.Text == "Edit Mode")
            //{
            //    Property.SrNo = Val.ToInt64(txtSrno.Text);
            //}
            //else
            //{
            //    Property.SrNo = 0;
            //}

            Property.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            Property.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);

            Property.Employee_Code = Val.ToInt64(LookupEmployee.EditValue);
            Property.Rough_Name = Val.ToString(LookupRoughName.Text);
            Property.Rough_Type_Code = Val.ToInt64(lookUpRoughType.EditValue);
            Property.Barcode = Val.ToString(txtBarcode.Text);

            Property.Entry_Date = Val.DBDate(DTPEntryDate.Text);
            //Property.Entry_Time = Val.GetFullTime12();

            Property.Sieve_Code = Val.ToInt64(lookUpSize.EditValue);
            Property.Clarity_Code = Val.ToInt64(lookUpClvClarity.EditValue);
            //Property.MFG_Clarity_Code = Val.ToInt64(lookUpmfgClrty.EditValue);

            Property.Shape_Code = Val.ToInt64(lookUpShape.EditValue);
            Property.Color_Code = Val.ToInt64(lookUpColor.EditValue);

            Property.Issue_Pcs = Val.Val(txtIssPcs.Text);
            Property.Issue_Carat = Val.Val(txtIssCrt.Text);
            Property.SrNo = srno_;

            Property = ObjMix.SaveEmployeeReceive(Property);
            return Property;

        }

        private void FrmPacket_LOTprep_Load(object sender, EventArgs e)
        {

        }

        private void BtnEmpIssShow_Click(object sender, EventArgs e)
        {
            if (LookupToProcess.Text == "")
            {
                Global.Confirm("To Process Require");
                return;
            }
            if (DTPEntryDate.Text == "")
            {
                Global.Confirm("Entry Date Require");
                return;
            }

            PanelShow.Enabled = false;

            BtnShowBalance_Click(null, null);

            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
            Property.Rough_Name = Convert.ToString(LookupRoughName.EditValue);
            //  Property.Stock_Flag = txtStockFlag.Text;
            // Property.Entry_Date = Val.DBDate(DTPEntryDate.Text);
            Property.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            Property.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);
            Property.Employee_Code = Val.ToInt64(LookupEmployee.EditValue);
            //Property.From_Janged_No = Val.ToInt64(txtJangadNo.Text);
            //Property.To_Janged_No = Val.ToInt64(txtToJangedNO.Text);

            //Property.From_Carat = Val.Val(txtFromCarat.Text);
            //Property.To_Carat = Val.Val(txtSToCarat.Text);

            Property.Barcode = txtBarcode.Text;

            Property.From_Janged_Date = Val.DBDate(dtSrchFrom.EditValue.ToString());
            Property.To_Janged_Date = Val.DBDate(dtSrchTo.EditValue.ToString());

            Property.Employee_Code = Val.ToInt64(LookupEmployee.EditValue);
            DataTable TDT = ObjPacket.GetPacketData(Property);

            GrdLotPrepation.DataSource = TDT;
            GrdLotPrepation.Refresh();

            //            txtBarcodeNo.Focus();
            panelControl6.Enabled = true;
            xtraTabControl1.Enabled = true;
            CountTotal();
            txtBarcode.Focus();

        }

        public void CountTotal()
        {
            //int IntLot = 0;
            //double DouCarat = 0;
            //int IntPcs = 0;

            //foreach (DataGridViewRow DRow in dgvLotPrepation.Rows)
            //{
            //    if (Val.ToString(DRow.Cells["BARCODE"].Value) == "")
            //    {
            //        continue;
            //    }
            //    IntLot++;
            //    IntPcs = IntPcs + Val.val(DRow.Cells["ISSUE_PCS"].Value);
            //    DouCarat = DouCarat + Val.Val(DRow.Cells["ISSUE_CARAT"].Value);

            //}
            //txtTotalLot.Text = IntLot.ToString();
            //txtTotalPcs.Text = IntPcs.ToString();
            //txtTotalCarat.Text = DouCarat.ToString();
        }

        private void txtBarcode_Validated(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length == 0)
            {
                txtBarcode.Focus();
            }

            btnSave.Enabled = true;
            if (ObjPacket.ISExists(txtBarcode.Text) == true)
            {
                Global.Confirm("Barode No is already Exists... Please Check");
                txtBarcode.Text = "";
                btnSave.Enabled = false;
                txtBarcode.Focus();
                return;
            }
        }

        private void BtnShowBalance_Click(object sender, EventArgs e)
        {

            Mix_IssRet_MasterProperty DetailProperty = new Mix_IssRet_MasterProperty();
            DetailProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            DetailProperty.Rough_Name = Convert.ToString(LookupRoughName.EditValue);
            DetailProperty.Employee_Code = Convert.ToInt64(LookupEmployee.EditValue);
            DetailProperty.Janged_Date = Val.DBDate(DTPEntryDate.Text);
            DetailProperty.Janged_No = Val.ToInt64(txtJangadNo.Text);

            DataRow DRow = ObjMix.GetEmpRetBalance(DetailProperty);

            txtOutStandPcs.Text = "0";
            txtOutStandCrt.Text = "";

            txtJangadPcs.Text = "";
            txtJangadCrt.Text = "";
            txtLotsPcs.Text = "";

            if (DRow != null)
            {
                txtOutStandPcs.Text = "0";
                txtOutStandCrt.Text = Math.Round(Val.ToDecimal(DRow["BALANCE_CARAT"]), 3).ToString();

                txtJangadPcs.Text = Val.ToString(DRow["JANGED_PCS"]);
                txtJangadCrt.Text = Math.Round(Val.ToDecimal(DRow["JANGED_CARAT"]), 3).ToString();
                txtLotsPcs.Text = Val.ToString(DRow["JANGED_LOTS"]);
            }
            DetailProperty = null;
        }

        private void txtJangadNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtJangadPcs.Text = "0";
            txtJangadCrt.Text = "0";
            txtLotsPcs.Text = "0";

            txtJangadNo.Text = ObjPacket.FindNewJangedNo(DTPEntryDate.EditValue.ToString()).ToString();
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

        private void LookupEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmEmployeeMaster frmCnt = new FrmEmployeeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPEmployee(LookupEmployee);
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

        private void LookupRoughName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmRoughCreationMaster frmCnt = new FrmRoughCreationMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPRough(LookupRoughName);
            }
        }

        private void lookUpRoughType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmRoughTypeMaster frmCnt = new FrmRoughTypeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPRoughTypeCode(lookUpRoughType);
            }
        }

        private void lookUpShape_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmShapeMaster frmCnt = new FrmShapeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPShape(lookUpShape);
            }
        }

        private void lookUpColor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmColorMaster frmCnt = new FrmColorMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPColor(lookUpColor);
            }
        }

        private void lookUpClvClarity_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarity(lookUpClvClarity, "Clv");
                Global.LOOKUPClarity(lookUpmfgClrty, "Mfg");
            }
        }

        private void lookUpmfgClrty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarity(lookUpmfgClrty, "Mfg");
                Global.LOOKUPClarity(lookUpClvClarity, "Clv");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PanelShow.Enabled = true;
            LookupFromProcess.EditValue = null;
            LookupToProcess.EditValue = null;
            DTPEntryDate.EditValue = DateTime.Today.Date.ToShortDateString();
            LookupEmployee.EditValue = null;
            LookupDept.EditValue = null;
            LookupRoughName.EditValue = null;
            panelControl6.Enabled = false;
            txtJangadNo.EditValue = "";
            txtIssPcs.EditValue = "";
            txtIssCrt.EditValue = "";
            txtBarcode.EditValue = "";
            txtRate.EditValue = "";
            txtAmount.EditValue = "";
            txtRemark.EditValue = "";
            txtPointer.EditValue = "";
            txtExpWtPer.EditValue = "";
            //      txtExpCDPer.EditValue = "";
            txtMaxDim.EditValue = "";
            txtMinDim.EditValue = "";
            txtHeight.EditValue = "";
            txtDepth.EditValue = "";
            CmbIssueType.SelectedIndex = 0;
            CmbCompType.SelectedIndex = 0;
            lookUpRoughType.EditValue = null;
            lookUpSize.EditValue = null;
            lookUpClvClarity.EditValue = null;
            txtExpWtPer.EditValue = "";
            txtDMPer.EditValue = "";
            lookUpShape.EditValue = null;
            lookUpmfgClrty.EditValue = null;
            lookUpColor.EditValue = null;
            txtExpBy.EditValue = "";
            txtDMBy.EditValue = "";
            //    txtExpCDPer.EditValue = "";
            //     comboBoxCut.EditValue = "";
            CmbIssueType.EditValue = "";
            txtMaxDim.EditValue = "";
            txtMinDim.EditValue = "";
            txtHeight.EditValue = "";
            txtDepth.EditValue = "";
            txtPointer.EditValue = "";
            txtRemark.EditValue = "";
            txtRate.EditValue = "";
            txtAmount.EditValue = "";
            txtLotsPcs.EditValue = "";
            txtOutStandPcs.EditValue = "";
            txtOutStandCrt.EditValue = "";
            txtJangadPcs.EditValue = "";
            txtJangadCrt.EditValue = "";
            txtBarcode.Enabled = true;
            GrdLotPrepation.DataSource = null;
            GrdLotPrepation.Refresh();
            xtraTabControl1.Enabled = false;
            srno_ = 0;
            btnSave.Enabled = true;
        }

        private void FrmPacket_LOTprep_Shown(object sender, EventArgs e)
        {
            Global.LOOKUPProcess(LookupFromProcess);
            Global.LOOKUPProcess(LookupToProcess);
            Global.LOOKUPDepartment(LookupDept);
            Global.LOOKUPEmployee(LookupEmployee);
            Global.LOOKUPRough(LookupRoughName);
            Global.LOOKUPRoughTypeCode(lookUpRoughType);
            Global.LOOKUPShape(lookUpShape);
            Global.LOOKUPColor(lookUpColor);
            Global.LOOKUPClarity(lookUpClvClarity, "Clv");
            Global.LOOKUPClarity(lookUpmfgClrty, "Mfg");
            Global.LOOKUPSieve(lookUpSize);

            DTPEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            dtSrchFrom.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            dtSrchTo.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            //DataTable dtcut = ObjPacket.CUT_GetData();
            //if(dtcut.Rows.Count>0)
            //{
            //    foreach (DataRow dr in dtcut.Rows)
            //    {
            //        comboBoxCut.Properties.Items.Add("");                    
            //    }
            //}

            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvLotPrepation_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvLotPrepation.GetDataRow(e.RowHandle);
                    txtJangadNo.EditValue = Convert.ToString(Drow["Janged_No"]);
                    txtBarcode.EditValue = Convert.ToString(Drow["Barcode"]);
                    lookUpRoughType.EditValue = Convert.ToInt64(Drow["Rough_Type_Code"]);
                    lookUpSize.EditValue = Convert.ToInt64(Drow["Sieve_Code"]);
                    lookUpClvClarity.EditValue = Convert.ToInt64(Drow["Clv_Clarity_Code"]);
                    txtExpWtPer.EditValue = Convert.ToString(Drow["Exp_Per"]);
                    txtDMPer.EditValue = Convert.ToString(Drow["Dm_Per"]);
                    lookUpShape.EditValue = Convert.ToInt64(Drow["Shape_Code"]);
                    lookUpmfgClrty.EditValue = Convert.ToInt64(Drow["Mfg_Clarity_Code"]);
                    lookUpColor.EditValue = Convert.ToInt64(Drow["Color_Code"]);
                    CmbCompType.EditValue = Convert.ToString(Drow["Comp_No"]);
                    txtExpBy.EditValue = Convert.ToString(Drow["Exp_By"]);
                    txtDMBy.EditValue = Convert.ToString(Drow["Dm_By"]);
                    txtIssPcs.EditValue = Convert.ToString(Drow["Issue_Pcs"]);
                    txtIssCrt.EditValue = Convert.ToString(Drow["Issue_Carat"]);
                    CmbIssueType.EditValue = Convert.ToString(Drow["Issue_Type"]);
                    txtMaxDim.EditValue = Convert.ToString(Drow["Max_Dia"]);
                    txtMinDim.EditValue = Convert.ToString(Drow["Min_Dia"]);
                    txtHeight.EditValue = Convert.ToString(Drow["Height"]);
                    txtDepth.EditValue = Convert.ToString(Drow["Depth"]);
                    txtRate.EditValue = Convert.ToString(Drow["Rate"]);
                    txtAmount.EditValue = Convert.ToString(Drow["Amount"]);
                    txtRemark.Text = Convert.ToString(Drow["Remark"]);
                    xtraTabControl1.Enabled = false;
                    //    panelControl6.Enabled = false;
                    srno_ = Convert.ToInt64(Drow["SRNO"]);
                    btnSave.Enabled = false;
                }
            }
        }

        private void lookUpClvClarity_EditValueChanged(object sender, EventArgs e)
        {
            lookUpmfgClrty.EditValue = Val.ToInt64(lookUpClvClarity.GetColumnValue("MAPPING_CODE"));
        }

        private void lookUpmfgClrty_EditValueChanged(object sender, EventArgs e)
        {
            lookUpClvClarity.EditValue = Val.ToInt64(lookUpmfgClrty.GetColumnValue("MAPPING_CODE"));
        }
    }
}
