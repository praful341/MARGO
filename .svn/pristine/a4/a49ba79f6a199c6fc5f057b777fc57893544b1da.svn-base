using BLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Transaction;
using DevExpress.Data;
using MARGO.Class;
using MARGO.Report;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace MARGO
{
    public partial class FrmUpdateTransaction : Form
    {
        IDataObject PasteclipData = Clipboard.GetDataObject();
        String PasteData = "";

        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        //PacketMaster ObjPacket = new PacketMaster();
        //DepartmentMaster objDepartment = new DepartmentMaster();
        //SieveMaster objSieve = new SieveMaster();
        //ClarityMaster objClarity = new ClarityMaster();
        //DataTable DTab = new DataTable();
        //PacketMaster ObjPacket = new PacketMaster();
        ClvMixDeptIssRet ObjMix = new ClvMixDeptIssRet();

        public FrmUpdateTransaction()
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
            this.Dispose();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "";
            GrdUpdate.DataSource = null;
            GrdUpdate.RefreshDataSource();
            GrdUpdate.Refresh();

            txtBarcode.Focus();


            LookupFromCompany.EditValue = null;
            LookupToCompany.EditValue = null;

            LookupFromBranch.EditValue = null;
            LookupToBranch.EditValue = null;

            LookupFromLocation.EditValue = null;
            LookupToLocation.EditValue = null;

            LookupFromDept.EditValue = null;
            LookupToDept.EditValue = null;

            LookupFromProcess.EditValue = null;
            LookupToProcess.EditValue = null;           
            txtBarcode.Text = "";

            LookupRough.EditValue = null;
            LookupRoughType.EditValue = null;

            txtFromPcs.Text = "";
            txtToPcs.Text = "";
            txtFromCarat.Text = "";
            txtToCarat.Text = "";
            txtFromLoss.Text = "";
            txtToLoss.Text = "";
            txtFromLost.Text = "";
            txtToLost.Text = "";
            txtFromCaratPlus.Text = "";
            txtToCaratPlus.Text = "";

            txtIssueJangedNo.Text = "";
            txtReceiveJangedNo.Text = "";

            LookupShape.EditValue = null;
            LookupColor.EditValue = null;
            LookupSieve.EditValue = null;
            LookupMfgClarity.EditValue = null;
            LookupClvClarity.EditValue = null;

            txtOldBarcode.Text = "";
            txtNewBarcode.Text = "";

            txtFromJangedNo.Text = "";
            txtToJangedNo.Text = "";

            DTPFromEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            DTPToEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            DTPFromJangedDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            DTPToJangedDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            GrdUpdate.DataSource = null;
            GrdUpdate.RefreshDataSource();
        }

        private void FrmPacketDetail_Shown(object sender, EventArgs e)
        {
            Global.LOOKUPCompany(LookupFromCompany);
            Global.LOOKUPCompany(LookupToCompany);
            Global.LOOKUPBranch(LookupFromBranch);
            Global.LOOKUPBranch(LookupToBranch);
            Global.LOOKUPLocation(LookupFromLocation);
            Global.LOOKUPLocation(LookupToLocation);
            Global.LOOKUPDepartment(LookupFromDept);
            Global.LOOKUPDepartment(LookupToDept);
            Global.LOOKUPProcess(LookupFromProcess);
            Global.LOOKUPProcess(LookupToProcess);
            Global.LOOKUPRough(LookupRough);
            Global.LOOKUPRoughTypeCode(LookupRoughType);

            DTPFromEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            DTPToEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            DTPFromJangedDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            DTPToJangedDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            Global.LOOKUPShape(LookupShape);
            Global.LOOKUPColor(LookupColor);
            Global.LOOKUPSieve(LookupSieve);
            Global.LOOKUPClarity(LookupMfgClarity,"Mfg");
            Global.LOOKUPClarity(LookupClvClarity,"Clv");
            RbtUpdateType_SelectedIndexChanged(null, null);

            Global.LOOKUPDepartmentRep(RepFromDepartment);
            Global.LOOKUPDepartmentRep(RepToDepartment);
            Global.LOOKUPSieveRep(RepSieve);
            Global.LOOKUPClarityRep(RepClarity);
            Global.LOOKUPRoughRep(RepRough);
            Global.LOOKUPProcessRep(RepProcess);
            Global.LOOKUPProcessRep(RepFromProcess);
            Global.LOOKUPProcessRep(RepToProcess);
            Global.LOOKUPShapeRep(RepShape);
            Global.LOOKUPColorRep(RepColor);
            Global.LOOKUPRoughTypeRep(RepRoughType);
            Global.LOOKUPClarityRep(RepClarity,"");
            Global.LOOKUPClarityRep(RepMFGClarity, "Mfg");
            Global.LOOKUPClarityRep(RepCLVClarity, "Clv");
            Global.LOOKUPCompanyRep(RepFromCompany);
            Global.LOOKUPCompanyRep(RepToCompany);
            Global.LOOKUPBranchRep(RepFromBranch);
            Global.LOOKUPBranchRep(RepToBranch);
            Global.LOOKUPLocationRep(RepFromLocation);
            Global.LOOKUPLocationRep(RepToLocation);
            Party_MasterProperty Party = new Party_MasterProperty();
            Party.Party_Type = "";
            Global.LOOKUPPartyRep(RepFromParty,Party);
            Global.LOOKUPPartyRep(RepToParty, Party);     

            txtBarcode.Focus();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();

            Property.Ope = Val.ToString(RbtUpdateType.EditValue);

            Property.From_Company_Code = Val.ToInt64(LookupFromCompany.EditValue);
            Property.To_Company_Code = Val.ToInt64(LookupToCompany.EditValue);

            Property.From_Branch_Code = Val.ToInt64(LookupFromBranch.EditValue);
            Property.To_Branch_Code = Val.ToInt64(LookupToBranch.EditValue);

            Property.From_Location_Code = Val.ToInt64(LookupFromLocation.EditValue);
            Property.To_Location_Code = Val.ToInt64(LookupToLocation.EditValue);

            Property.From_Department_Code = Val.ToInt64(LookupFromDept.EditValue);
            Property.To_Department_Code = Val.ToInt64(LookupToDept.EditValue);

            Property.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
            Property.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);

            Property.Barcode = Val.ToString(txtBarcode.Text);
            Property.From_Janged_No = Val.ToInt(txtFromJangedNo.Text);
            Property.To_Janged_No = Val.ToInt(txtToJangedNo.Text);
            Property.From_Pcs = Val.ToInt(txtFromPcs.Text);
            Property.To_Pcs = Val.ToInt(txtToPcs.Text);
            Property.From_Carat = Val.Val(txtFromCarat.Text);
            Property.To_Carat = Val.Val(txtToCarat.Text);
            Property.Rough_Name = Val.ToString(LookupRough.EditValue);
            Property.Rough_Type_Code = Val.ToInt(LookupRoughType.EditValue);

            Property.From_Memo_No = Val.ToInt64(txtFromMemoNo.Text);
            Property.To_Memo_No = Val.ToInt64(txtToMemoNo.Text);
        
            Property.From_Pcs = Val.ToInt64(txtFromPcs.Text);
            Property.To_Pcs = Val.ToInt64(txtToPcs.Text);

            Property.From_Carat = Val.Val(txtFromCarat.Text);
            Property.To_Carat = Val.Val(txtToCarat.Text);

            Property.From_Loss_Carat = Val.Val(txtFromLoss.Text);
            Property.To_Loss_Carat = Val.Val(txtToLoss.Text);

            Property.From_Lost_Carat = Val.Val(txtFromLost.Text);
            Property.To_Lost_Carat = Val.Val(txtToLost.Text);

            Property.From_Carat_Plus = Val.Val(txtFromCaratPlus.Text);
            Property.To_Carat_Plus = Val.Val(txtToCaratPlus.Text);

            Property.Issue_Janged_No = txtIssueJangedNo.Text;
            Property.Receive_Janged_No = txtReceiveJangedNo.Text;

            Property.From_Entry_Date = Val.DBDate(DTPFromEntryDate.Text);
            Property.To_Entry_Date = Val.DBDate(DTPToEntryDate.Text);
            Property.From_Janged_Date = Val.DBDate(DTPFromJangedDate.Text);
            Property.To_Janged_Date = Val.DBDate(DTPToJangedDate.Text);
            Property.Shape_Code = Val.ToInt64(LookupShape.EditValue);
            Property.Color_Code = Val.ToInt64(LookupColor.EditValue);
            Property.Sieve_Code = Val.ToInt64(LookupSieve.EditValue);

            Property.MFG_Clarity_Code = Val.ToInt64(LookupMfgClarity.EditValue);
            Property.Clarity_Code = Val.ToInt64(LookupClvClarity.EditValue);


            DataTable DTab = ObjMix.GetTranscationData(Property);

            GrdUpdate.DataSource = DTab;
            GrdUpdate.RefreshDataSource();
            dgvUpdate.BestFitColumns();
            GetSummary();
        }

        private void GetSummary()
        {
            int IntRec = 0;
            double IntPcs = 0;
            double DouCarat = 0;
            System.Data.DataTable DTab = (System.Data.DataTable)GrdUpdate.DataSource;
            if (DTab != null)
            {
                if (DTab.Rows.Count > 0)
                {
                    foreach (DataRow DRow in DTab.Rows)
                    {
                        IntRec++;
                        IntPcs += Val.Val(DRow["ISSUE_PCS"]);
                        DouCarat += Val.Val(DRow["ISSUE_CARAT"]);                      
                    }
                }
            }
            lblTotalRec.Text = "Total Rec : " + IntRec.ToString();
            lblTotalPcs.Text = "Total Pcs : " + IntPcs.ToString();
            lblTotalCarat.Text = "Total Carat : " + DouCarat.ToString();
        }

        private void BtnUpdateNewBarcode_Click(object sender, EventArgs e)
        {
            if (txtOldBarcode.Text.Length == 0)
            {
                Global.Confirm("Old Barcode Is Required");
                txtOldBarcode.Focus();
                return;
            }
            if (txtNewBarcode.Text.Length == 0)
            {
                Global.Confirm("New Barcode Is Required");
                txtNewBarcode.Focus();
                return;
            }
            if (txtOldBarcode.Text == txtNewBarcode.Text)
            {
                Global.Confirm("Old And New Barcode Is Same , So Not Need To Update");
                txtOldBarcode.Focus();
                return;
            }

            string Str = txtNewBarcode.Text;

            for (int i = 0; i < Str.Length; i++)
            {
                if (!(char.IsLetter(Str[i])) && (!(char.IsNumber(Str[i]))))
                {
                    Global.Confirm("Your Barcode Contains [" + Str[i] + "] letter, Which is InValid");
                    return;
                }
            }

            if (Global.Confirm("Are You Sure to Update Barcode\n\nAfter this update you Lost Your Old Barcode Identity From Entire Database\n\nStill You Want To Continue ?","MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
            Packet_MasterProperty PacketProperty = new Packet_MasterProperty();

            Property.Ope = "BARCODE_UPDATE";
            Property.Barcode = txtOldBarcode.Text;
            Property.New_Barcode = txtNewBarcode.Text;
            Int64 IntRes = ObjMix.UpdateTranscation(Property, PacketProperty);
            this.Cursor = Cursors.Default;
            if (IntRes > 0)
            {
                Global.Confirm("New Barcode Update Successfully Done");
                txtBarcode.Text = "";
                txtNewBarcode.Text = "";
            }
            else
            {
                Global.Confirm("Error....Barcode Is Not Update");
            } 
        }

        private void BtnUpdateNewRough_Click(object sender, EventArgs e)
        {
            if (txtRoughBarcodeToBeUPdate.Text.Length == 0)
            {
                Global.Confirm("Barcode Is Required");
                txtRoughBarcodeToBeUPdate.Focus();
                return;
            }
            if (txtNewRoughToBeUpdate.Text.Length == 0)
            {
                Global.Confirm("New Rough Is Required");
                txtNewRoughToBeUpdate.Focus();
                return;
            }

            if (Global.Confirm("Are You Sure to Update Barcode\n\nAfter this update you Lost Your Old Rough Identity From Entire Database\n\nStill You Want To Continue ?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            int IntRes = ObjMix.UpdateRoughNameInBarcode(txtRoughBarcodeToBeUPdate.Text, txtNewRoughToBeUpdate.Text);
            this.Cursor = Cursors.Default;
            if (IntRes > 0)
            {

                Global.Confirm("New Rough Is Update Successfully In This Barcode");
            }
            else
            {
                Global.Confirm("Error....Barcode Is Not Update");
            }  
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Global.Confirm("Are You Sure That You Want To Update Data ? ", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            int IntRes = 0;

            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
            Packet_MasterProperty PacketProperty = new Packet_MasterProperty();

            //DataTable DTabChanges = ObjMix.DS.Tables["Mix_Dept_IssTran_GetDetail"].GetChanges();
            DataTable DTabChanges = (DataTable)GrdUpdate.DataSource;
            DTabChanges.AcceptChanges();

            if (DTabChanges == null)
            {
                Global.Confirm("Table Changes Not Effected,.. Please Leave The Grid Row Then Update");
                return;
            }
            this.Cursor = Cursors.WaitCursor;

            foreach (DataRow Drow in DTabChanges.Rows)
            {
                PacketProperty = new Packet_MasterProperty();
                Property = new Mix_IssRet_MasterProperty();

                Property.Ope = Val.ToString(RbtUpdateType.EditValue);

                Property.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);
                Property.Rough_Type_Code = Val.ToInt(Drow["ROUGH_TYPE_CODE"]);
                Property.Barcode = Val.ToString(Drow["BARCODE"]);

                Property.Issue_Pcs = Val.ToInt(Drow["ISSUE_PCS"]);
                Property.Issue_Carat = Val.Val(Drow["ISSUE_CARAT"]);
                Property.Entry_Date = Val.DBDate(Val.ToString(Drow["ISSUE_DATE"]));
                //Property.Entry_Time = Val.ToString(Drow["ISSUE_TIME"]);
                

                Property.Shape_Code = Val.ToInt(Drow["SHAPE_CODE"]);
                Property.Color_Code = Val.ToInt(Drow["COLOR_CODE"]);
                Property.Sieve_Code = Val.ToInt(Drow["SIEVE_CODE"]);
                Property.Clarity_Code = Val.ToInt(Drow["CLV_CLARITY_CODE"]);
                Property.MFG_Clarity_Code = Val.ToInt(Drow["MFG_CLARITY_CODE"]);

                Property.Rough_Type_Code = Val.ToInt(Drow["ROUGH_TYPE_CODE"]);


                if (Property.Ope == "DEPT")
                {
                    DateTime DTIssueDate = DateTime.Parse(Val.ToString(Drow["ISSUE_DATE"]));

                    if (Val.ISDate(Drow["RECEIVE_DATE"]) == true)
                    {
                        DateTime DTReceiveDate = DateTime.Parse(Val.ToString(Drow["RECEIVE_DATE"]));
                        if (DTReceiveDate < DTIssueDate)
                        {
                            Global.Confirm("Receive Date Is Less Than Issue Date");
                            return;
                        }
                    }

                    Property.SrNo = Val.ToInt(Drow["SRNO"]);
                    Property.Janged_No = Val.ToInt(Drow["JANGED_NO"]);
                    Property.Janged_Date = Val.DBDate(Val.ToString(Drow["JANGED_DATE"]));

                    Property.From_Department_Code = Val.ToInt(Drow["FROM_DEPARTMENT_CODE"]);
                    Property.To_Department_Code = Val.ToInt(Drow["TO_DEPARTMENT_CODE"]);
                    Property.From_Process_Code = Val.ToInt(Drow["FROM_PROCESS_CODE"]);
                    Property.To_Process_Code = Val.ToInt(Drow["TO_PROCESS_CODE"]);

                    Property.Bill_Of_Entry_No = Val.ToString(Drow["BILL_OF_ENTRY_NO"]);
                    Property.From_Location_Code = Val.ToInt(Drow["FROM_LOCATION_CODE"]);
                    Property.To_Location_Code = Val.ToInt(Drow["TO_LOCATION_CODE"]);
                    Property.From_Company_Code = Val.ToInt(Drow["FROM_COMPANY_CODE"]);
                    Property.To_Company_Code = Val.ToInt(Drow["TO_COMPANY_CODE"]);
                    Property.From_Branch_Code = Val.ToInt(Drow["FROM_BRANCH_CODE"]);
                    Property.To_Branch_Code = Val.ToInt(Drow["TO_BRANCH_CODE"]);
                   // Property.From_Sub_Party_Code = Val.ToInt(Drow["FROM_SUB_PARTY_CODE"]);
                    Property.From_Party_Code = Val.ToInt(Drow["FROM_PARTY_CODE"]);
                    //Property.To_Sub_Party_Code = Val.ToInt(Drow["TO_SUB_PARTY_CODE"]);
                    Property.To_Party_Code = Val.ToInt(Drow["TO_PARTY_CODE"]);

                    Property.Saw_Pcs = Val.ToInt(Drow["SAW_PCS"]);
                    Property.Saw_Carat = Val.ToInt(Drow["SAW_CARAT"]);

                    Property.Receive_Pcs = Val.ToInt(Drow["RECEIVE_PCS"]);
                    Property.Receive_Carat = Val.Val(Drow["RECEIVE_CARAT"]);
                    Property.Receipt_Date = Val.DBDate(Val.ToString(Drow["RECEIVE_DATE"]));
                    //Property.Receipt_Time = Val.ToString(Drow["RECEIVE_TIME"]);
                    //Property.Issue_Empoloyee_Code = Val.ToInt(Drow["ISSUE_EMPLOYEE_CODE"]);
                    //Property.Issue_Computer_IP = Val.ToString(Drow["ISSUE_COMPUTER_IP"]);
                    //Property.Receive_Empoloyee_Code = Val.ToInt(Drow["RECEIVE_EMPLOYEE_CODE"]);
                    //Property.Receive_Computer_IP = Val.ToString(Drow["RECEIVE_COMPUTER_IP"]);

                    Property.Janged_No = Val.ToInt(Drow["JANGED_NO"]);
                    Property.Janged_Date = Val.DBDate(Val.ToString(Drow["JANGED_DATE"]));

                    Property.Bill_Of_Entry_No = Val.ToString(Drow["BILL_OF_ENTRY_NO"]);
                    Property.SFLG = Val.ToInt(Drow["SFLG"]);

                    Property.Loss_Pcs = Val.ToInt(Drow["LOSS_PCS"]);
                    Property.Loss_Carat = Val.Val(Drow["LOSS_CARAT"]);
                    Property.Lost_Pcs = Val.ToInt(Drow["LOST_PCS"]);
                    Property.Lost_Carat = Val.Val(Drow["LOST_CARAT"]);
                    Property.RR_Pcs = Val.ToInt(Drow["RR_PCS"]);
                    Property.RR_Carat = Val.Val(Drow["RR_CARAT"]);
                    Property.Consume_Pcs = Val.ToInt(Drow["CONSUME_PCS"]);
                    Property.Consume_Carat = Val.Val(Drow["CONSUME_CARAT"]);
                    Property.Carat_Plus = Val.ToInt(Drow["CARAT_PLUS"]);
                }


                else if (Property.Ope == "EMP")
                {
                    Property.SrNo = Val.ToInt(Drow["SRNO"]);
                    Property.Type = Val.ToString(Drow["TRN_TYPE"]);

                    Property.From_Process_Code = Val.ToInt(Drow["FROM_PROCESS_CODE"]);
                    Property.To_Process_Code = Val.ToInt(Drow["TO_PROCESS_CODE"]);

                    Property.From_Department_Code = Val.ToInt(Drow["FROM_DEPARTMENT_CODE"]);
                    Property.From_Location_Code = Val.ToInt(Drow["FROM_LOCATION_CODE"]);
                    Property.From_Company_Code = Val.ToInt(Drow["FROM_COMPANY_CODE"]);
                    Property.From_Branch_Code = Val.ToInt(Drow["FROM_BRANCH_CODE"]);

                    //Property.Main_Employee_Code = Val.ToInt(Drow["MAIN_EMPLOYEE_CODE"]);
                    //Property.Employee_Code = Val.ToInt(Drow["EMPLOYEE_CODE"]);
                    //Property.HH = Val.ToInt(Drow["HH"]);
                    //Property.MM = Val.ToInt(Drow["MM"]);
                    //Property.Saw_Type = Val.ToString(Drow["SAW_TYPE"]);
                    //Property.Start_Time = Val.ToString(Drow["START_TIME"]);
                    //Property.Start_Time = Val.ToString(Drow["END_TIME"]);
                    //Property.End_Time = Val.ToString(Drow["SUB_PROCESS_CODE"]);

                    //Property.Machine_Code = Val.ToInt(Drow["MACHINE_CODE"]);
                    //Property.Shift_Code = Val.ToInt(Drow["SHIFT_CODE"]);

                    //Property.Minor_Pcs = Val.ToInt(Drow["MINOR_PCS"]);
                    //Property.Minor_Carat = Val.Val(Drow["MINOR_CARAT"]);
                    //Property.Minor_Amount = Val.Val(Drow["MINOR_AMOUNT"]);
                    //Property.Major_Pcs = Val.ToInt(Drow["MAJOR_PCS"]);
                    //Property.Major_Carat = Val.Val(Drow["MAJOR_CARAT"]);
                    //Property.Major_Amount = Val.Val(Drow["MAJOR_AMOUNT"]);
                    //Property.Issue_Empoloyee_Code = Val.ToInt(Drow["ISSUE_EMPLOYEE_CODE"]);
                    //Property.Issue_Computer_IP = Val.ToString(Drow["ISSUE_COMPUTER_IP"]);
                    Property.Loss_Pcs = Val.ToInt(Drow["LOSS_PCS"]);
                    Property.Loss_Carat = Val.Val(Drow["LOSS_CARAT"]);
                    Property.Lost_Pcs = Val.ToInt(Drow["LOST_PCS"]);
                    Property.Lost_Carat = Val.Val(Drow["LOST_CARAT"]);
                    Property.RR_Pcs = Val.ToInt(Drow["RR_PCS"]);
                    Property.RR_Carat = Val.Val(Drow["RR_CARAT"]);
                    Property.Consume_Pcs = Val.ToInt(Drow["CONSUME_PCS"]);
                    Property.Consume_Carat = Val.Val(Drow["CONSUME_CARAT"]);
                    Property.Carat_Plus = Val.ToInt(Drow["CARAT_PLUS"]);
                }

                else if (Property.Ope == "LOT")
                {

                    PacketProperty = new Packet_MasterProperty();
                    PacketProperty.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);
                    PacketProperty.Barcode = Val.ToString(Drow["BARCODE"]);

                   // PacketProperty.Kapan_No = Val.ToString(Drow["KAPAN_NO"]);
                    PacketProperty.EXP_Per = Val.Val(Drow["EXP_PER"]);

                    //if (Val.ToString(Drow["EXP_BY_NAME"]) != "")
                    //{
                    PacketProperty.EXP_By = Val.ToString(Drow["EXP_BY"]);
                    //}
                    //else
                    //{
                    //    PacketProperty.EXP_By = "0";
                    //}

                    PacketProperty.DM_Per = Val.Val(Drow["DM_PER"]);
                    //if (Val.ToString(Drow["DM_BY_NAME"]) != "")
                    //{
                    PacketProperty.DM_By = Val.ToString(Drow["DM_BY"]);
                    //}
                    //else
                    //{
                    //    PacketProperty.DM_By = "0";
                    //}
                    PacketProperty.Height = Val.Val(Drow["HEIGHT"]);
                    PacketProperty.Width = Val.Val(Drow["WIDTH"]);
                    PacketProperty.Depth = Val.Val(Drow["DEPTH"]);
                    PacketProperty.Max_Dia = Val.Val(Drow["MAX_DIA"]);
                    PacketProperty.Min_Dia = Val.Val(Drow["MIN_DIA"]);
                    PacketProperty.Janged_No = Val.ToInt(Drow["PACKET_JANGED_NO"]);
                    PacketProperty.Comp_No = Val.ToString(Drow["COMP_NO"]);
                    PacketProperty.Stock_Flag = Val.ToString(Drow["STOCK_FLAG"]);
                    //PacketProperty.EXP_Per_Code = Val.ToString(Drow["EXP_PER_CODE"]);
                    PacketProperty.Comp_No = Val.ToString(Drow["COMP_NO"]);
                    //PacketProperty.Cut_Code = Val.ToInt(Drow["CUT_CODE"]);
                    PacketProperty.IS_Merge = Val.ToInt(Drow["IS_MERGE"]);
                }

                IntRes += ObjMix.UpdateTranscation(Property,PacketProperty);

                Property = null;
                PacketProperty = null;
            }
            this.Cursor = Cursors.Default;
            if (IntRes > 0)
            {
                Global.Confirm("Transaction Update SucceeFully Done");
                BtnShow_Click(null, null);
            }
            else
            {
                Global.Confirm("Error....Transaction Is Not Update");
            } 
        }

        private void SetColumnVisible()
        {
            if (Val.ToString(RbtUpdateType.EditValue) == "LOT")
            {
                dgvUpdate.Columns["JANGED_NO"].Visible = false;
                dgvUpdate.Columns["JANGED_DATE"].Visible = false;
                dgvUpdate.Columns["SRNO"].Visible = false;
                dgvUpdate.Columns["ROUGH_NAME"].Visible = true;
                dgvUpdate.Columns["BARCODE"].Visible = true;
                dgvUpdate.Columns["TRN_TYPE"].Visible = false;
                dgvUpdate.Columns["FROM_DEPARTMENT_CODE"].Visible = false;
                dgvUpdate.Columns["TO_DEPARTMENT_CODE"].Visible = false;
                dgvUpdate.Columns["FROM_PROCESS_CODE"].Visible = false;
                dgvUpdate.Columns["TO_PROCESS_CODE"].Visible = false;
                dgvUpdate.Columns["ISSUE_PCS"].Visible = true;
                dgvUpdate.Columns["ISSUE_CARAT"].Visible = true;
                dgvUpdate.Columns["RECEIVE_PCS"].Visible = false;
                dgvUpdate.Columns["RECEIVE_CARAT"].Visible = false;
                dgvUpdate.Columns["LOSS_PCS"].Visible = false;
                dgvUpdate.Columns["LOSS_CARAT"].Visible = false;
                dgvUpdate.Columns["LOST_PCS"].Visible = false;
                dgvUpdate.Columns["LOST_CARAT"].Visible = false;
                dgvUpdate.Columns["RR_PCS"].Visible = false;
                dgvUpdate.Columns["RR_CARAT"].Visible = false;
                dgvUpdate.Columns["CONSUME_PCS"].Visible = false;
                dgvUpdate.Columns["CONSUME_CARAT"].Visible = false;
                dgvUpdate.Columns["CARAT_PLUS"].Visible = false;
                dgvUpdate.Columns["SAW_PCS"].Visible = false;
                dgvUpdate.Columns["SAW_CARAT"].Visible = false;
                dgvUpdate.Columns["CANCEL_PCS"].Visible = false;
                dgvUpdate.Columns["CANCEL_CARAT"].Visible = false;
                dgvUpdate.Columns["ROUGH_TYPE_CODE"].Visible = true;
                dgvUpdate.Columns["SHAPE_CODE"].Visible = true;
                dgvUpdate.Columns["COLOR_CODE"].Visible = true;
                dgvUpdate.Columns["SIEVE_CODE"].Visible = true;
                dgvUpdate.Columns["MFG_CLARITY_CODE"].Visible = true;
                dgvUpdate.Columns["CLV_CLARITY_CODE"].Visible = true;
                dgvUpdate.Columns["EXP_PER"].Visible = true;
                dgvUpdate.Columns["DM_PER"].Visible = true;
                dgvUpdate.Columns["EXP_BY"].Visible = true;
                dgvUpdate.Columns["DM_BY"].Visible = true;
                dgvUpdate.Columns["HEIGHT"].Visible = true;
                dgvUpdate.Columns["WIDTH"].Visible = true;
                dgvUpdate.Columns["DEPTH"].Visible = true;
                dgvUpdate.Columns["MAX_DIA"].Visible = true;
                dgvUpdate.Columns["MIN_DIA"].Visible = true;
                dgvUpdate.Columns["FROM_LOCATION_CODE"].Visible = false;
                dgvUpdate.Columns["TO_LOCATION_CODE"].Visible = false;
                dgvUpdate.Columns["FROM_COMPANY_CODE"].Visible = false;
                dgvUpdate.Columns["TO_COMPANY_CODE"].Visible = false;
                dgvUpdate.Columns["FROM_BRANCH_CODE"].Visible = false;
                dgvUpdate.Columns["TO_BRANCH_CODE"].Visible = false;
                dgvUpdate.Columns["FROM_PARTY_CODE"].Visible = false;
                dgvUpdate.Columns["TO_PARTY_CODE"].Visible = false;
                dgvUpdate.Columns["SFLG"].Visible = false;
                dgvUpdate.Columns["ISSUE_DATE"].Visible = true;
                dgvUpdate.Columns["RECEIVE_DATE"].Visible = false;
                dgvUpdate.Columns["BILL_OF_ENTRY_NO"].Visible = false;
                dgvUpdate.Columns["EMP_ISSRET_DTL_ID"].Visible = false;
                dgvUpdate.Columns["PACKET_ID"].Visible = true;
                dgvUpdate.Columns["PACKET_JANGED_NO"].Visible = true;
                dgvUpdate.Columns["PROCESS_CODE"].Visible = true;
                dgvUpdate.Columns["CLARITY_CODE"].Visible = true;
                dgvUpdate.Columns["COMP_NO"].Visible = true;
                dgvUpdate.Columns["STOCK_FLAG"].Visible = true;
                dgvUpdate.Columns["REMARK"].Visible = true;
                dgvUpdate.Columns["IS_MERGE"].Visible = true;             
            }

            else if (Val.ToString(RbtUpdateType.EditValue) == "DEPT")
            {
                dgvUpdate.Columns["JANGED_NO"].Visible = true;
                dgvUpdate.Columns["JANGED_DATE"].Visible = true;
                dgvUpdate.Columns["SRNO"].Visible = true;
                dgvUpdate.Columns["ROUGH_NAME"].Visible = true;
                dgvUpdate.Columns["BARCODE"].Visible = true;
                dgvUpdate.Columns["TRN_TYPE"].Visible = false;
                dgvUpdate.Columns["FROM_DEPARTMENT_CODE"].Visible = true;
                dgvUpdate.Columns["TO_DEPARTMENT_CODE"].Visible = true;
                dgvUpdate.Columns["FROM_PROCESS_CODE"].Visible = true;
                dgvUpdate.Columns["TO_PROCESS_CODE"].Visible = true;
                dgvUpdate.Columns["ISSUE_PCS"].Visible = true;
                dgvUpdate.Columns["ISSUE_CARAT"].Visible = true;
                dgvUpdate.Columns["RECEIVE_PCS"].Visible = true;
                dgvUpdate.Columns["RECEIVE_CARAT"].Visible = true;
                dgvUpdate.Columns["LOSS_PCS"].Visible = true;
                dgvUpdate.Columns["LOSS_CARAT"].Visible = true;
                dgvUpdate.Columns["LOST_PCS"].Visible = true;
                dgvUpdate.Columns["LOST_CARAT"].Visible = true;
                dgvUpdate.Columns["RR_PCS"].Visible = true;
                dgvUpdate.Columns["RR_CARAT"].Visible = true;
                dgvUpdate.Columns["CONSUME_PCS"].Visible = true;
                dgvUpdate.Columns["CONSUME_CARAT"].Visible = true;
                dgvUpdate.Columns["CARAT_PLUS"].Visible = true;
                dgvUpdate.Columns["SAW_PCS"].Visible = true;
                dgvUpdate.Columns["SAW_CARAT"].Visible = true;
                dgvUpdate.Columns["CANCEL_PCS"].Visible = true;
                dgvUpdate.Columns["CANCEL_CARAT"].Visible = true;
                dgvUpdate.Columns["ROUGH_TYPE_CODE"].Visible = true;
                dgvUpdate.Columns["SHAPE_CODE"].Visible = true;
                dgvUpdate.Columns["COLOR_CODE"].Visible = true;
                dgvUpdate.Columns["SIEVE_CODE"].Visible = true;
                dgvUpdate.Columns["MFG_CLARITY_CODE"].Visible = true;
                dgvUpdate.Columns["CLV_CLARITY_CODE"].Visible = true;
                dgvUpdate.Columns["EXP_PER"].Visible = false;
                dgvUpdate.Columns["DM_PER"].Visible = false;
                dgvUpdate.Columns["EXP_BY"].Visible = false;
                dgvUpdate.Columns["DM_BY"].Visible = false;
                dgvUpdate.Columns["HEIGHT"].Visible = false;
                dgvUpdate.Columns["WIDTH"].Visible = false;
                dgvUpdate.Columns["DEPTH"].Visible = false;
                dgvUpdate.Columns["MAX_DIA"].Visible = false;
                dgvUpdate.Columns["MIN_DIA"].Visible = false;
                dgvUpdate.Columns["FROM_LOCATION_CODE"].Visible = true;
                dgvUpdate.Columns["TO_LOCATION_CODE"].Visible = true;
                dgvUpdate.Columns["FROM_COMPANY_CODE"].Visible = true;
                dgvUpdate.Columns["TO_COMPANY_CODE"].Visible = true;
                dgvUpdate.Columns["FROM_BRANCH_CODE"].Visible = true;
                dgvUpdate.Columns["TO_BRANCH_CODE"].Visible = true;
                dgvUpdate.Columns["FROM_PARTY_CODE"].Visible = true;
                dgvUpdate.Columns["TO_PARTY_CODE"].Visible = true;
                dgvUpdate.Columns["SFLG"].Visible = true;
                dgvUpdate.Columns["ISSUE_DATE"].Visible = true;
                dgvUpdate.Columns["RECEIVE_DATE"].Visible = true;
                dgvUpdate.Columns["BILL_OF_ENTRY_NO"].Visible = true;
                dgvUpdate.Columns["EMP_ISSRET_DTL_ID"].Visible = false;
                dgvUpdate.Columns["PACKET_ID"].Visible = false;
                dgvUpdate.Columns["PACKET_JANGED_NO"].Visible = false;
                dgvUpdate.Columns["PROCESS_CODE"].Visible = false;
                dgvUpdate.Columns["CLARITY_CODE"].Visible = false;
                dgvUpdate.Columns["COMP_NO"].Visible = false;
                dgvUpdate.Columns["STOCK_FLAG"].Visible = false;
                dgvUpdate.Columns["REMARK"].Visible = false;
                dgvUpdate.Columns["IS_MERGE"].Visible = false;
            }
            else if (Val.ToString(RbtUpdateType.EditValue) == "EMP")
            {
                dgvUpdate.Columns["JANGED_NO"].Visible = true;
                dgvUpdate.Columns["JANGED_DATE"].Visible = false;
                dgvUpdate.Columns["SRNO"].Visible = true;
                dgvUpdate.Columns["ROUGH_NAME"].Visible = true;
                dgvUpdate.Columns["BARCODE"].Visible = true;
                dgvUpdate.Columns["TRN_TYPE"].Visible = true;
                dgvUpdate.Columns["FROM_DEPARTMENT_CODE"].Visible = true;
                dgvUpdate.Columns["TO_DEPARTMENT_CODE"].Visible = false;
                dgvUpdate.Columns["FROM_PROCESS_CODE"].Visible = true;
                dgvUpdate.Columns["TO_PROCESS_CODE"].Visible = true;
                dgvUpdate.Columns["ISSUE_PCS"].Visible = true;
                dgvUpdate.Columns["ISSUE_CARAT"].Visible = true;
                dgvUpdate.Columns["RECEIVE_PCS"].Visible = false;
                dgvUpdate.Columns["RECEIVE_CARAT"].Visible = false;
                dgvUpdate.Columns["LOSS_PCS"].Visible = true;
                dgvUpdate.Columns["LOSS_CARAT"].Visible = true;
                dgvUpdate.Columns["LOST_PCS"].Visible = true;
                dgvUpdate.Columns["LOST_CARAT"].Visible = true;
                dgvUpdate.Columns["RR_PCS"].Visible = true;
                dgvUpdate.Columns["RR_CARAT"].Visible = true;
                dgvUpdate.Columns["CONSUME_PCS"].Visible = true;
                dgvUpdate.Columns["CONSUME_CARAT"].Visible = true;
                dgvUpdate.Columns["CARAT_PLUS"].Visible = true;
                dgvUpdate.Columns["SAW_PCS"].Visible = false;
                dgvUpdate.Columns["SAW_CARAT"].Visible = false;
                dgvUpdate.Columns["CANCEL_PCS"].Visible = false;
                dgvUpdate.Columns["CANCEL_CARAT"].Visible = false;
                dgvUpdate.Columns["ROUGH_TYPE_CODE"].Visible = true;
                dgvUpdate.Columns["SHAPE_CODE"].Visible = true;
                dgvUpdate.Columns["COLOR_CODE"].Visible = true;
                dgvUpdate.Columns["SIEVE_CODE"].Visible = true;
                dgvUpdate.Columns["MFG_CLARITY_CODE"].Visible = true;
                dgvUpdate.Columns["CLV_CLARITY_CODE"].Visible = true;
                dgvUpdate.Columns["EXP_PER"].Visible = false;
                dgvUpdate.Columns["DM_PER"].Visible = false;
                dgvUpdate.Columns["EXP_BY"].Visible = false;
                dgvUpdate.Columns["DM_BY"].Visible = false;
                dgvUpdate.Columns["HEIGHT"].Visible = false;
                dgvUpdate.Columns["WIDTH"].Visible = false;
                dgvUpdate.Columns["DEPTH"].Visible = false;
                dgvUpdate.Columns["MAX_DIA"].Visible = false;
                dgvUpdate.Columns["MIN_DIA"].Visible = false;
                dgvUpdate.Columns["FROM_LOCATION_CODE"].Visible = true;
                dgvUpdate.Columns["TO_LOCATION_CODE"].Visible = false;
                dgvUpdate.Columns["FROM_COMPANY_CODE"].Visible = true;
                dgvUpdate.Columns["TO_COMPANY_CODE"].Visible = false;
                dgvUpdate.Columns["FROM_BRANCH_CODE"].Visible = true;
                dgvUpdate.Columns["TO_BRANCH_CODE"].Visible = false;
                dgvUpdate.Columns["FROM_PARTY_CODE"].Visible = false;
                dgvUpdate.Columns["TO_PARTY_CODE"].Visible = false;
                dgvUpdate.Columns["SFLG"].Visible = false;
                dgvUpdate.Columns["ISSUE_DATE"].Visible = true;
                dgvUpdate.Columns["RECEIVE_DATE"].Visible = false;
                dgvUpdate.Columns["BILL_OF_ENTRY_NO"].Visible = false;
                dgvUpdate.Columns["EMP_ISSRET_DTL_ID"].Visible = true;
                dgvUpdate.Columns["PACKET_ID"].Visible = false;
                dgvUpdate.Columns["PACKET_JANGED_NO"].Visible = false;
                dgvUpdate.Columns["PROCESS_CODE"].Visible = false;
                dgvUpdate.Columns["CLARITY_CODE"].Visible = false;
                dgvUpdate.Columns["COMP_NO"].Visible = false;
                dgvUpdate.Columns["STOCK_FLAG"].Visible = false;
                dgvUpdate.Columns["REMARK"].Visible = false;
                dgvUpdate.Columns["IS_MERGE"].Visible = false;
            }
        }

        private void RbtUpdateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Val.ToString(RbtUpdateType.EditValue) == "DEPT")
            {
                SetColumnVisible();
                GrpSlip.Enabled = false;
                DTPFromJangedDate.Text = "";
                DTPToJangedDate.Text = "";

                LookupToCompany.Enabled = true;
                LookupToBranch.Enabled = true;
                LookupToDept.Enabled = true;
                LookupToLocation.Enabled = true;
                txtFromMemoNo.Enabled = true;
                txtToMemoNo.Enabled = true;
            }
            else if (Val.ToString(RbtUpdateType.EditValue) == "EMP")
            {
                SetColumnVisible();
                GrpSlip.Enabled = false;
                DTPFromJangedDate.Text = "";
                DTPToJangedDate.Text = "";

                LookupToCompany.Enabled = false;
                LookupToBranch.Enabled = false;
                LookupToDept.Enabled = false;
                LookupToLocation.Enabled = false;
                txtFromMemoNo.Enabled = false;
                txtToMemoNo.Enabled = false;
            }
            else if (Val.ToString(RbtUpdateType.EditValue) == "LOT")
            {
                SetColumnVisible();
                GrpSlip.Enabled = true;
                DTPFromJangedDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
                DTPToJangedDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

                LookupToCompany.Enabled = false;
                LookupToBranch.Enabled = false;
                LookupToDept.Enabled = false;
                LookupToLocation.Enabled = false;
                txtFromMemoNo.Enabled = false;
                txtToMemoNo.Enabled = false;
            }
            GrdUpdate.DataSource = null;
            GrdUpdate.RefreshDataSource();
            lblTotalRec.Text = "Total Rec : " + "";
            lblTotalPcs.Text = "Total Pcs : " + "";
            lblTotalCarat.Text = "Total Carat : " + "";
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                IDataObject clipData = Clipboard.GetDataObject();
                String Data = Val.ToString(clipData.GetData(System.Windows.Forms.DataFormats.Text));
                String str1 = Data.Replace("\r\n", ",");                   //data.Replace(\n, ",");
                str1 = str1.Trim();
                str1 = str1.TrimEnd();
                str1 = str1.TrimStart();
                str1 = str1.TrimEnd(',');
                str1 = str1.TrimStart(',');
                txtBarcode.Text = str1;
            }
        }

        private void txtBarcode_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtBarcode.Focus())
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    PasteData = Val.ToString(PasteclipData.GetData(System.Windows.Forms.DataFormats.Text));
                }
            }
        }
    }
}
