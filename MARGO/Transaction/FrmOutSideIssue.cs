using BLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Transaction;
using MARGO.Class;
using MARGO.Report;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmOutSideIssue : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        ClvMixDeptIssRet ObjMix = new ClvMixDeptIssRet();
        DepartmentMaster objDepartment = new DepartmentMaster();
        SieveMaster objSieve = new SieveMaster();
        ClarityMaster objClarity = new ClarityMaster();
        DataTable DTab = new DataTable();
        PacketMaster ObjPacket = new PacketMaster();       
        string mStrProcessPrefix = "";
        int mIntIsOpenIssueToOutSide = 0;

        public FrmOutSideIssue()
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
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtJangedNo.Text = "";
            LookupFromParty.EditValue = null;
            LookupToParty.EditValue = null;
            LookupFromProcess.EditValue = null;
            LookupToProcess.EditValue = null;
            LookupFromDept.EditValue = null;
            LookupToDept.EditValue = null;
            CmbThrough.SelectedIndex = 0;
            txtStockFlag.Text = "";
            txtStockFlag.Tag = "";
            LookupFromParty.Focus();
            CmbThrough.SelectedIndex = 0;
            CmbSupplier.SelectedIndex = 0;
            CmbSupplier.Enabled = false;
            CmbSupplier.EditValue = "";
            DTPEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            PanelShow.Enabled = true;
            panelControl6.Enabled = false;
            PanelGrid.Enabled = false;
            dgvOutSideIssue.DataSource = null;
        }

        #region Validation

        private bool ValSave()
        {

            return true;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValSave() == false)
            {
                return;
            }

            if (Global.Confirm("Are You Sure For Issue To Other Party?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            Process_MasterProperty ProcessMasterProperty = new ProcessMaster().GetDataByPK(Val.ToInt64(LookupFromProcess.EditValue));
            Process_MasterProperty ToProcessProperty = new ProcessMaster().GetDataByPK(Val.ToInt64(LookupToProcess.EditValue));
            mIntIsOpenIssueToOutSide = ToProcessProperty.IS_Open_Issue_To_OutSide;
            mStrProcessPrefix = ToProcessProperty.Janged_Prefix;

            System.Data.DataTable DTab_New = (System.Data.DataTable)dgvOutSideIssue.DataSource;

            if (DTab_New == null) { return; }
            if (DTab_New.Rows.Count < 1) { return; }

            foreach (DataRow Drow in DTab_New.Rows)
            {
                if (Val.ToString(Drow["BARCODE"]) == "")
                {
                    continue;
                }
                if (Val.Val(Drow["ISSUE_CARAT"]) == 0)
                {
                    Global.Confirm("Barcode : " + Val.ToString(Drow["BARCODE"]) + " Issue Carat Is Required");
                    return;
                }
                if (Val.ToString(Drow["ROUGH_NAME"]) == "")
                {
                    Global.Confirm("Barcode : " + Val.ToString(Drow["BARCODE"]) + " Rough Name Is Required");
                    return;
                }

                if (ToProcessProperty.Is_Labour_Rate_Calculate == 1)
                {
                    Mix_IssRet_MasterProperty LabProperty = new Mix_IssRet_MasterProperty();

                    LabProperty.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);
                    LabProperty.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);

                    LabProperty.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
                    //LabProperty.To_Party_Location_Code = mIntToPartyLocationCode;
                    LabProperty.To_Sub_Party_Code = Val.ToInt(LookupToParty.EditValue);

                    LabProperty.Issue_Pcs = Val.ToInt(Drow["ISSUE_PCS"]);
                    LabProperty.Issue_Carat = Val.Val(Drow["ISSUE_CARAT"]);

                    LabProperty.Sieve_Code = Val.ToInt64(Drow["SIEVE_CODE"]);
                    LabProperty.Shape_Code = Val.ToInt64(Drow["SHAPE_CODE"]);
                    LabProperty.MFG_Clarity_Code = Val.ToInt64(Drow["MFG_CLARITY_CODE"]);

                    LabProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);

                    Labour_Rate_MasterProperty LabProperty1 = new LabourRateMaster().GetLabourRate(
                                                LabProperty.Rough_Name,
                                                Val.ToInt64(LookupToParty.EditValue),
                        // Val.ToInt64(LookupToParty.EditValue),
                                                Val.ToInt64(LookupToProcess.EditValue),
                                                LabProperty.Issue_Pcs,
                                                LabProperty.Issue_Carat,
                                                LabProperty.Sieve_Code,
                                                LabProperty.MFG_Clarity_Code,
                                                LabProperty.Shape_Code,
                                                LabProperty.Entry_Date
                                                );

                    if (LabProperty1 == null)
                    {
                        //    this.Cursor = Cursors.Default;
                        Global.Confirm(LabProperty.Barcode + " : Labour Rate Is Not Found.. Please Check");
                        return;
                    }
                    LabProperty = null;
                }

                //if (mIntIsOpenIssueToOutSide == 0)
                //{
                //    Mix_IssRet_MasterProperty ValProperty = new Mix_IssRet_MasterProperty();
                //    ValProperty.Barcode = Val.ToString(Drow["BARCODE"]);
                //    ValProperty.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);
                //    ValProperty.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
                //    ValProperty.From_Sub_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
                //    ValProperty.To_Party_Code = Val.ToInt(LookupToParty.EditValue);
                //    ValProperty.To_Sub_Party_Code = Val.ToInt(LookupToParty.EditValue);

                //    string StrRes = ObjMix.ValIssueToOutSideValsave(ValProperty);
                //    if (StrRes != "")
                //    {
                //        this.Cursor = Cursors.Default;
                //        Global.Confirm(StrRes);
                //        return;
                //    }
                //}
            }

            ToProcessProperty = null;
            //  this.Cursor = Cursors.WaitCursor;
            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
            string FinYear = "";
            int IntRes = 0;

            if (mIntIsOpenIssueToOutSide == 1)
            {
                foreach (DataRow Drow in DTab_New.Rows)
                {
                    if (Val.ToString(Drow["BARCODE"]) == "")
                    {
                        continue;
                    }
                    if (Val.Val(Drow["ISSUE_CARAT"]) == 0)
                    {
                        continue;
                    }

                    if (ObjPacket.ISExists(Val.ToString(Drow["BARCODE"])) == true)
                    {
                        continue;
                    }

                    Packet_MasterProperty PacketProperty = new Packet_MasterProperty();
                    PacketProperty.Barcode = Val.ToString(Drow["BARCODE"]);
                    PacketProperty.Process_Code = Val.ToInt64(LookupToProcess.EditValue);

                    PacketProperty.Issue_Pcs = Val.Val(Drow["ISSUE_PCS"]);
                    PacketProperty.Issue_Carat = Val.Val(Drow["ISSUE_CARAT"]);

                    PacketProperty.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);
                    PacketProperty.Rough_Type_Code = Val.ToInt64(Drow["ROUGH_TYPE_CODE"]);
                    PacketProperty.Sieve_Code = Val.ToInt64(Drow["SIEVE_CODE"]);
                    PacketProperty.Color_Code = Val.ToInt64(Drow["COLOR_CODE"]);
                    PacketProperty.Shape_Code = Val.ToInt64(Drow["SHAPE_CODE"]);
                    //PacketProperty.Cut_Code = Val.ToInt(Drow.Cells["CUT_CODE"].Value);

                    PacketProperty.Mfg_Clarity_Code = Val.ToInt64(Drow["CLARITY_CODE"]);
                    PacketProperty.Clv_Clarity_Code = Val.ToInt64(Drow["CLARITY_CODE"]);
                    //PacketProperty.Comp_No = Val.ToString(Drow.Cells["COMP_NO"].Value);
                    //PacketProperty.Kapan_No = Val.ToString(Drow.Cells["KAPAN_NO"].Value);

                    PacketProperty.EXP_Per = Val.Val(Drow["EXP_PER"]);
                    PacketProperty.EXP_By = Val.ToString(Drow["EXP_BY"]);
                    //PacketProperty.EXP_Per_Code = Val.ToString(Drow.Cells["EXP_PER_CODE"].Value);

                    PacketProperty.DM_Per = Val.Val(Drow["DM_PER"]);
                    PacketProperty.DM_By = Val.ToString(Drow["DM_BY"]);

                    PacketProperty.Min_Dia = Val.Val(Drow["MIN_DIA"]);
                    PacketProperty.Max_Dia = Val.Val(Drow["MAX_DIA"]);

                    PacketProperty.Depth = Val.Val(Drow["DEPTH"]);
                    PacketProperty.Height = Val.Val(Drow["HEIGHT"]);

                    PacketProperty.Stock_Flag = txtStockFlag.Text;

                    PacketProperty.Entry_Date = Val.DBDate(DTPEntryDate.Text);
                    PacketProperty.Entry_Time = Val.GetFullTime12();

                    Int64 n = ObjPacket.Save(PacketProperty);

                    if (n == -1)
                    {
                        IntRes++;
                        PacketProperty = null;
                        //  this.Cursor = Cursors.Default;
                        Global.Confirm("Error in Save Record .. Please Check");
                        return;
                    }
                    PacketProperty = null;
                }
            }

            if (Val.Val(txtJangedNo.Text) == 0)
            {
                txtJangedNo.Text = new BLL.FunctionClasses.Entry.MaximumID().GenerateClvJangedNo(Val.DBDate(DTPEntryDate.Text)).ToString();
            }
            if (Val.Val(txtJangedNo.Text) == 0)
            {
                Global.Confirm("Janged Number Not Created Please Check");
                return;
            }

            foreach (DataRow Drow in DTab_New.Rows)
            {
                if (Val.ToString(Drow["BARCODE"]) == "")
                {
                    continue;
                }

                if (Val.Val(Drow["ISSUE_CARAT"]) == 0)
                {
                    continue;
                }

                Property = new Mix_IssRet_MasterProperty();
                Property.From_Department_Code = Val.ToInt64(LookupFromDept.EditValue);
                Property.To_Department_Code = Val.ToInt64(LookupToDept.EditValue);
                Property.Janged_Date = Val.DBDate(DTPEntryDate.Text);
                Property.Janged_No = Val.ToInt64(txtJangedNo.Text);
                Property.Barcode = Val.ToString(Drow["BARCODE"]);

                Property.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);

                Property.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
                Property.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);

                Property.Issue_Pcs = Val.Val(Drow["ISSUE_PCS"]);
                Property.Issue_Carat = Val.ToDouble(Drow["ISSUE_CARAT"]);
                Property.Rough_Type_Code = Val.ToInt64(Drow["ROUGH_TYPE_CODE"]);
                Property.Sieve_Code = Val.ToInt64(Drow["SIEVE_CODE"]);
                Property.Color_Code = Val.ToInt64(Drow["COLOR_CODE"]);
                Property.Shape_Code = Val.ToInt64(Drow["SHAPE_CODE"]);

                Property.MFG_Clarity_Code = Val.ToInt64(Drow["MFG_CLARITY_CODE"]);
                Property.CLV_CLARITY_CODE = Val.ToInt64(Drow["CLV_CLARITY_CODE"]);

                Property.EXP_PER = Val.ToDouble(Drow["EXP_PER"]);
                Property.DM_PER = Val.ToDouble(Drow["DM_PER"]);

                Property.Entry_Date = Val.DBDate(DTPEntryDate.Text);
                //Property.Entry_Time = Val.GetFullTime12();

                Property.Issue_Empoloyee_Code = GlobalDec.gEmployeeProperty.Employee_Code;
                Property.Issue_Computer_IP = BLL.GlobalDec.gStrComputerIP;

                Property.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
                //Property.From_Party_Location_Code = mIntFromPartyLocationCode;
                //Property.From_Sub_Party_Code = Val.ToInt64(LookupFromParty.EditValue);

                Property.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
                //Property.To_Party_Location_Code = mIntToPartyLocationCode;
                //Property.To_Sub_Party_Code = Val.ToInt64(LookupToParty.EditValue);

                if (txtIssueJangedNo.Text.Length == 0)
                {
                    FinYear = Global.GetFinancialYear(DTPEntryDate.Text);
                    txtIssueJangedNo.Text = ObjMix.FindNew_IssueDept_JangedNoNew(mStrProcessPrefix, FinYear);
                }
                if (txtIssueJangedNo.Text.Length == 0)
                {
                    this.Cursor = Cursors.Default;
                    Global.Confirm("Department Janged No Not Created,, So Please Check");
                    return;
                }

                Property.Issue_Janged_No = txtIssueJangedNo.Text;
                Property.Through = Val.ToString(CmbThrough.SelectedItem);
                Property.Through_By = Val.ToString(CmbSupplier.EditValue);
                //Property.SEmployee_Code = Val.ToInt(txtSupplier.Tag);

                Property.SrNo = 0;
                Property.SFLG = 1;

                //string StrResult = ObjMix.ValSaveDeptIssue(Property);
                //if (StrResult != "")
                //{
                //    Global.Confirm(StrResult);
                //    //txtIssueJangedNo.Text = "";
                //    txtJangedNo.Text = "";
                //    break;
                //}

                Property = ObjMix.SaveDepartmentIssueNew(Property);

                Property.Type = "I";
                Property.Janged_Date = Val.DBDate(DTPEntryDate.Text);
                Property.Bill_Of_Entry_No = txtIssueJangedNo.Text;
                Property.Financial_Year = FinYear;


                Property.Receipt_Date = Val.DBDate(DTPEntryDate.Text);
                //Property.Receipt_Time = Val.GetFullTime12();
                //Property.Comp_Process_Code = Val.ToString(txtCompProcess.Tag);
                //
                IntRes += ObjMix.SaveIssRetJangedDetail(Property);

                if (Property == null)
                {
                    Property = null;
                    //     this.Cursor = Cursors.Default;
                    Global.Confirm("Error in Save Record .. Please Check");
                }

                else
                {
                    txtJangedNo.Text = Property.Janged_No.ToString();
                }
            }
            //   this.Cursor = Cursors.Default;

            if (txtIssueJangedNo.Text.Length != 0)
            {
                Mix_IssRet_MasterProperty DetailPolishProperty = new Mix_IssRet_MasterProperty();
                DetailPolishProperty.Janged_Date = Val.DBDate(DTPEntryDate.Text.ToString());
                DetailPolishProperty.Janged_No = Val.ToInt64(txtJangedNo.Text);
                DetailPolishProperty.Receive_Date = Val.DBDate(DTPEntryDate.Text.ToString());
                DetailPolishProperty.Receive_Time = Val.GetFullTime12();
                IntRes += ObjMix.SaveDepartmentReceiveManual(DetailPolishProperty);

                if (IntRes == -1)
                {
                    //   this.Cursor = Cursors.Default;
                    Global.Confirm("Error In Janged Receive");
                }

                if (Global.Confirm("Successfully Transfer [" + Convert.ToString(ColBarcode.SummaryText) + " Lot] & [" + Convert.ToString(ColIssuePCS.SummaryText) + " Pcs] & [" + Convert.ToString(ColIssueCarat.SummaryText) + " Carats]" + " To " + LookupToDept.Text + " Department\n\nYour Other Party Issue Is Successfully Done... NOTE : Department Memo No Is :" + txtJangedNo.Text + " &&  Issue Janged IS :" + txtIssueJangedNo.Text + "\n\nAre You Print Janged Now ?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    PrintDtl(txtIssueJangedNo.Text);
                }

                txtJangedNo.Text = "";
                txtIssueJangedNo.Text = "";
                LookupToParty.EditValue = null;
                dgvOutSideIssue.DataSource = null;
                PanelShow.Enabled = true;
                panelControl6.Enabled = false;
                PanelGrid.Enabled = false;
                //GetSummary();
                Global.LOOKUPJangedForPrint(LookupJangedPrint, DTPEntryDate.Text.ToString());
                LookupFromParty.Focus();
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

        private void LookupFromDept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmDepartmentMaster frmCnt = new FrmDepartmentMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPDepartment(LookupFromDept);
                Global.LOOKUPDepartment(LookupToDept);
            }
        }

        private void LookupToDept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmDepartmentMaster frmCnt = new FrmDepartmentMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPDepartment(LookupToDept);
                Global.LOOKUPDepartment(LookupFromDept);
            }
        }

        private void LookupFromProcess_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

        //private void GetSummary()
        //{
        //    int IntTotPcs = 0, IntTotLot = 0;
        //    double DouTotCarat = 0;
        //    System.Data.DataTable DTab = (System.Data.DataTable)dgvOutSideIssue.DataSource;

        //    if (DTab != null)
        //    {
        //        if (DTab.Rows.Count > 0)
        //        {
        //            foreach (DataRow DRow in DTab.Rows)
        //            {
        //                IntTotLot = IntTotLot + 1;
        //                IntTotPcs = IntTotPcs + Val.ToInt(DRow["ISSUE_PCS"]);
        //                DouTotCarat = DouTotCarat + Val.Val(DRow["ISSUE_CARAT"]);
        //            }
        //        }
        //    }

        //    txtTotLot.Text = IntTotLot.ToString();
        //    txtTotPcs.Text = IntTotPcs.ToString();
        //    txtTotCarat.Text = DouTotCarat.ToString();
        //}

        private void dgvOutSideIssue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (Global.Confirm("Are you sure delete selected row in Employee Issue Entry?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    GrdOutSideIssue.DeleteRow(GrdOutSideIssue.GetRowHandle(GrdOutSideIssue.FocusedRowHandle));
                }
            }
        }

        private void LookUpRepRough_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmRoughCreationMaster frmCnt = new FrmRoughCreationMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPRoughRep(LookUpRepRough);
            }
        }

        private void FrmOutSideIssue_Shown(object sender, EventArgs e)
        {
            btnClear_Click(btnClear, null);
            LookupFromParty.Focus();
            DTPEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            Global.LOOKUPDepartment(LookupFromDept);
            Global.LOOKUPDepartment(LookupToDept);
            Party_MasterProperty Party = new Party_MasterProperty();
            Party.Party_Type = "Self";
            Global.LOOKUPParty(LookupFromParty, Party);
            Party = null;
            Party = new Party_MasterProperty();
            Party.Party_Type = "Labour";
            Global.LOOKUPParty(LookupToParty, Party);
            Party = null;

            Global.LOOKUPProcess(LookupFromProcess);
            Global.LOOKUPProcess(LookupToProcess);
            CmbSupplier.Enabled = false;

            Global.LOOKUPRoughRep(LookUpRepRough);
            Global.LOOKUPShapeRep(LookUpRepShape);
            Global.LOOKUPColorRep(LookUpRepColor);
            Global.LOOKUPRoughTypeRep(LookUpRepRoughType);
            Global.LOOKUPSieveRep(repositoryItemLookUpEdit1);
            Global.LOOKUPClarityRep(LookUpClarity);
            Global.LOOKUPClarityRep(LookUpRepClvCla, "Clv");
            Global.LOOKUPClarityRep(LookUpMfgCla, "Mfg");

            try
            {
                DataTable DTab_Supplier = ObjMix.Dept_Supplier_GetData();
                object[] Supplier = DTab_Supplier.AsEnumerable().Select(r => r.Field<string>("THROUGH_BY")).Distinct().ToArray();
                if (DTab_Supplier.AsEnumerable().Select(r => r.Field<string>("THROUGH_BY")).Distinct().Count() > 0)
                    CmbSupplier.Properties.Items.AddRange(Supplier);
            }
            catch (Exception) { }

        }

        private void LookupToParty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmPartyMaster frmCnt = new FrmPartyMaster();
                frmCnt.ShowDialog();
                Party_MasterProperty Party = new Party_MasterProperty();
                Party.Party_Type = "Self";
                Global.LOOKUPParty(LookupFromParty, Party);
                Party = null;
                Party = new Party_MasterProperty();
                Party.Party_Type = "Labour";
                Global.LOOKUPParty(LookupToParty, Party);
                Party = null;
            }
        }

        private void LookupFromParty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmPartyMaster frmCnt = new FrmPartyMaster();
                frmCnt.ShowDialog();
                Party_MasterProperty Party = new Party_MasterProperty();
                Party.Party_Type = "Self";
                Global.LOOKUPParty(LookupFromParty, Party);
                Party = null;
                Party = new Party_MasterProperty();
                Party.Party_Type = "Labour";
                Global.LOOKUPParty(LookupToParty, Party);
                Party = null;
            }
        }

        private void LookUpRepShape_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmShapeMaster frmCnt = new FrmShapeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPShapeRep(LookUpRepShape);
            }
        }

        private void LookUpRepColor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmColorMaster frmCnt = new FrmColorMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPColorRep(LookUpRepColor);
            }
        }

        private void LookUpRepRoughType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmShapeMaster frmCnt = new FrmShapeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPRoughTypeRep(LookUpRepRoughType);
            }
        }

        private static Mix_IssRet_MasterProperty GetPClsProperty()
        {
            Mix_IssRet_MasterProperty pClsProperty = new Mix_IssRet_MasterProperty();
            return pClsProperty;
        }


        private void LookUpMfgCla_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarityRep(LookUpRepClvCla, "Clv");
                Global.LOOKUPClarityRep(LookUpMfgCla, "Mfg");
            }
        }

        private void LookUpRepClvCla_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarityRep(LookUpRepClvCla, "Clv");
                Global.LOOKUPClarityRep(LookUpMfgCla, "Mfg");
            }
        }

        private bool ValDisp()
        {
            if (Convert.ToString(LookupFromParty.EditValue) == "")
            {
                Global.Confirm("From Party is required");
                LookupFromParty.Focus();
                return false;
            }
            if (Convert.ToString(LookupToParty.EditValue) == "")
            {
                Global.Confirm("To Party is required");
                LookupToParty.Focus();
                return false;
            }
            if (Convert.ToString(LookupFromDept.EditValue) == "")
            {
                Global.Confirm("From Department is required");
                LookupFromDept.Focus();
                return false;
            }
            if (Convert.ToString(LookupToDept.EditValue) == "")
            {
                Global.Confirm("To Department is required");
                LookupToDept.Focus();
                return false;
            }
            if (Convert.ToString(LookupFromProcess.EditValue) == "")
            {
                Global.Confirm("From Process is required");
                LookupFromProcess.Focus();
                return false;
            }
            if (Convert.ToString(LookupToProcess.EditValue) == "")
            {
                Global.Confirm("To Process is required");
                LookupToProcess.Focus();
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

        private void BtnDeptShow_Click(object sender, EventArgs e)
        {
            if (ValDisp() == false)
            {
                return;
            }
            panelControl6.Enabled = true;
            PanelGrid.Enabled = true;
            PanelShow.Enabled = false;

            Mix_IssRet_MasterProperty pClsProperty = GetPClsProperty();
            pClsProperty.From_Department_Code = Val.ToInt64(LookupFromDept.EditValue);
            pClsProperty.To_Department_Code = Val.ToInt64(LookupToDept.EditValue);
            //     pClsProperty.Entry_Date = DTPEntryDate.Text;
            pClsProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            pClsProperty.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);
            pClsProperty.Barcode = "0";  // GrdOutSideIssue.GetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "BARCODE").ToString();  // GrdOutSideIssue.GetRowCellValue(rowindex, "BARCODE").ToString();
            // pClsProperty.Stock_Flag = txtStockFlag.Text;
            DataTable tdt = ObjMix.GetMfgIssueDetail(pClsProperty);
            dgvOutSideIssue.DataSource = tdt.Clone();

            Global.LOOKUPJangedForPrint(LookupJangedPrint, DTPEntryDate.Text.ToString());

            GrdOutSideIssue.Focus();

            pClsProperty = null;
        }

        private bool ValDuplicate(string Barcode_)
        {
            bool flag = true;
            for (int i = 0; i < GrdOutSideIssue.RowCount; i++)
            {
                if (GrdOutSideIssue.GetRowCellValue(i, ColBarcode) != null)
                {
                    if (GrdOutSideIssue.GetRowCellValue(i, ColBarcode).ToString() == Barcode_)
                    {
                        return false;
                    }
                    flag = true;
                }
            }
            return flag;
        }

        private void GrdOutSideIssue_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (GrdOutSideIssue.FocusedColumn != ColBarcode)
            {
                e.Valid = false;
                return;
            }
            Mix_IssRet_MasterProperty pClsProperty = GetPClsProperty();

            //if (mIntIsOpenIssueToOutSide == 1)
            //{
            if (ObjPacket.ISExists(Convert.ToString(e.Value)) == false)
            {
                Global.Confirm(e.Value.ToString() + " : Barcode Not Found");
                e.Valid = false;
                return;
            }

            if (ValDuplicate(e.Value.ToString()) == false)
            {
                Global.Confirm(e.Value.ToString() + " :    Barcode Already Exists In Previous Record");
                e.Valid = false;
                return;
            }

            pClsProperty.From_Department_Code = Val.ToInt64(LookupFromDept.EditValue);
            pClsProperty.To_Department_Code = Val.ToInt64(LookupToDept.EditValue);
            //     pClsProperty.Entry_Date = DTPEntryDate.Text;
            pClsProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            pClsProperty.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);
            pClsProperty.Barcode = Convert.ToString(e.Value);// GrdOutSideIssue.GetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "BARCODE").ToString();  // GrdOutSideIssue.GetRowCellValue(rowindex, "BARCODE").ToString();
            // pClsProperty.Stock_Flag = txtStockFlag.Text;

            DataTable DTB = ObjMix.GetMfgIssueDetail(pClsProperty);
            if (DTB == null)
            {
                Global.Confirm(pClsProperty.Barcode.ToString() + " : Barcode Not Found");
                e.Valid = false;
                return;
            }
            if (DTB.Rows.Count < 1)
            {
                Global.Confirm(pClsProperty.Barcode.ToString() + " : Barcode Not Found");
                e.Valid = false;
                return;
            }

            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "ROUGH_NAME", Convert.ToString(DTB.Rows[0]["ROUGH_NAME"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "ISSUE_PCS", Convert.ToString(DTB.Rows[0]["ISSUE_PCS"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "ISSUE_CARAT", Convert.ToString(DTB.Rows[0]["ISSUE_CARAT"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "SIEVE_CODE", Convert.ToString(DTB.Rows[0]["SIEVE_CODE"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "SHAPE_CODE", Convert.ToString(DTB.Rows[0]["SHAPE_CODE"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "ROUGH_TYPE_CODE", Convert.ToString(DTB.Rows[0]["ROUGH_TYPE_CODE"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "CLV_CLARITY_CODE", Convert.ToString(DTB.Rows[0]["CLV_CLARITY_CODE"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "MFG_CLARITY_CODE", Convert.ToString(DTB.Rows[0]["MFG_CLARITY_CODE"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "COLOR_CODE", Convert.ToString(DTB.Rows[0]["COLOR_CODE"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "EXP_PER", Convert.ToString(DTB.Rows[0]["EXP_PER"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "EXP_BY", Convert.ToString(DTB.Rows[0]["EXP_BY"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "DM_PER", Convert.ToString(DTB.Rows[0]["DM_PER"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "DM_BY", Convert.ToString(DTB.Rows[0]["DM_BY"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "MIN_DIA", Convert.ToString(DTB.Rows[0]["MIN_DIA"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "MAX_DIA", Convert.ToString(DTB.Rows[0]["MAX_DIA"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "DEPTH", Convert.ToString(DTB.Rows[0]["DEPTH"]));
            GrdOutSideIssue.SetRowCellValue(GrdOutSideIssue.FocusedRowHandle, "HEIGHT", Convert.ToString(DTB.Rows[0]["HEIGHT"]));
            //    }
            pClsProperty = null;
        }

        private void CmbThrough_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbThrough.SelectedIndex == 0)
            {
                CmbSupplier.Enabled = false;
                CmbSupplier.EditValue = "";
            }
            else
            {
                CmbSupplier.Enabled = true;
            }
        }

        private void BtnIssueJangedPrint_Click(object sender, EventArgs e)
        {
            if (LookupJangedPrint.Text.Length < 1)
            {
                Global.Confirm("Select Memo No.");
                LookupJangedPrint.Focus();
                return;
            }
            PrintDtl(Convert.ToString(LookupJangedPrint.EditValue));
        }

        public void PrintDtl(string MemoNo)
        {
            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
            Property.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
            Property.Issue_Janged_No = Val.ToString(MemoNo);
            DataTable DTab = ObjMix.GetIssueJabgedForPrint(Property, "D");

            if (DTab == null || DTab.Rows.Count == 0)
            {
                Global.Confirm("Janged Record Not Found");
                return;
            }

            Process_MasterProperty ProcessMasterProperty = new ProcessMaster().GetDataByPK(Val.ToInt64(LookupToProcess.EditValue));
            FrmReportViewer FrmReportViewer = new Report.FrmReportViewer();
            FrmReportViewer.DS.Tables.Add(DTab);

            //  FrmReportViewer.ShowForm("CLV_To_OutSide_Det_Other", 120, Report.FrmReportViewer.ReportFolder.JANGED);

            if (ProcessMasterProperty.Is_Manufacturing == 1)
            {
                //FrmReportViewer.ShowForm(BLL.TPV.RPT.CLV_To_OutSide_Det_MFG, DTab, 120, Report.FrmReportViewer.ReportFolder.JANGED);
                FrmReportViewer.ShowForm("CLV_To_OutSide_Det_MFG", DTab, 120, Report.FrmReportViewer.ReportFolder.JANGED);
            }
            else
            {
                FrmReportViewer.ShowForm("CLV_To_OutSide_Det_Other", DTab, 120, Report.FrmReportViewer.ReportFolder.JANGED);
            }

            FrmReportViewer.Focus();
            Property = null;
        }

    }
}
