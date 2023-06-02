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
    public partial class FrmPolishCaratUpdate : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        ClvMixDeptIssRet ObjPolish = new ClvMixDeptIssRet();

        public FrmPolishCaratUpdate()
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            DTPFromEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            DTPToDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());            
            LookupRoughName.EditValue = null;
            MainGridDetail.DataSource = null;
            MainGridSummry.DataSource = null;
        }        
        
        public bool ValShow()
        {
            if (Convert.ToString(DTPFromEntryDate.EditValue) == "")
            {
                Global.Confirm("Entry Date Is Required");
                DTPFromEntryDate.Focus();
                return false;
            }           
            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            MainGridSummry.DataSource = null;
            MainGridSummry.Refresh();
            if (ValShow() == false)
            {
                return;
            }

            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
            Property.Barcode = txtBarcode.Text;
            Property.Rough_Name = Val.ToString(LookupRoughName.EditValue);
            Property.From_Entry_Date = Val.DBDate(DTPFromEntryDate.Text);
            Property.To_Entry_Date = Val.DBDate(DTPToDate.Text);

            DataTable DTab = ObjPolish.GetSummryData(Property);

            MainGridSummry.DataSource = DTab;
            MainGridSummry.Refresh();
            GrdDetSum.Columns["MFG_PROCESS_NAME"].Group();
            GrdDetSum.BestFitColumns();
            Property = null;

            GrdDetSum.ExpandAllGroups();
            GrdDetSum.BestFitColumns();
        }

        private void GrdDetSum_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (e.RowHandle != -1)
                {
                    MainGridDetail.DataSource = null;
                    MainGridDetail.Refresh();

                    if (ObjPolish.DTabDetail != null)
                    {
                        ObjPolish.DTabDetail.Rows.Clear();
                    }

                    if (ValShow() == false)
                    {
                        return;
                    }

                    //string StrMFGType = Val.ToString(GrdDetSum.GetRowCellValue(e.RowHandle, "MFG_TYPE"));
                    MainGridDetail.DataSource = null;
                    MainGridDetail.Refresh();

                    Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
                    //Property.MFG_Type = StrMFGType;
                    Property.Rough_Name = Val.DBDate(Val.ToString(GrdDetSum.GetRowCellValue(e.RowHandle, "ROUGH_NAME")));// Val.ToString(LookupRoughName.EditValue);
                    Property.Barcode = txtBarcode.Text;
                    Property.From_Entry_Date = Val.DBDate(Val.ToString(GrdDetSum.GetRowCellValue(e.RowHandle, "JANGED_DATE"))); //Val.DBDate(DTPFromEntryDate.Text);
                    Property.To_Entry_Date = Val.DBDate(Val.ToString(GrdDetSum.GetRowCellValue(e.RowHandle, "JANGED_DATE")));// Val.DBDate(DTPToDate.Text);
                    Property.Ref_No = Val.ToString(GrdDetSum.GetRowCellValue(e.RowHandle, "REF_NO"));
                    ObjPolish.GetDetailData(Property);
                    DataRow dr = ObjPolish.DTabDetail.NewRow();
                    ObjPolish.DTabDetail.Rows.Add(dr);
                    MainGridDetail.DataSource = ObjPolish.DTabDetail;
                    MainGridDetail.Refresh();
                    GrdDetDetail.BestFitColumns();
                    Property = null;
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (Global.Confirm("Are You Sure To Update Records ? ","MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) 
            {
                return;
            }

            DataTable DTab = ObjPolish.DTabDetail.GetChanges();

            foreach (DataRow DRow in DTab.Rows)
            {
                if (Val.ToString(DRow["BILL_NO"]) != "")
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + "  : LABOUR BILL GENERATED , SO YOU CAN NOT UPDATE.");
                    return;
                }

                if (Val.Val(DRow["JANGED_PROCESS_CODE"]) == 0)
                {
                    if (
                           Math.Round(Val.Val(DRow["ISSUE_CARAT"]), 3) !=
                            (
                                Math.Round(Val.Val(DRow["CONSUME_CARAT"]) +
                                Val.Val(DRow["RR_CARAT"]) +
                                Val.Val(DRow["SAW_CARAT"]) +
                                Val.Val(DRow["LOST_CARAT"]) +
                                Val.Val(DRow["LOSS_CARAT"]), 3)

                            )
                        )
                    {
                        Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Issue Carat Is Not Match With Other Carats Please Check");
                        return;
                    }
                    if (
                            Val.ToInt(DRow["ISSUE_PCS"]) !=
                            (
                                Val.ToInt(DRow["CONSUME_PCS"]) +
                                Val.ToInt(DRow["RR_PCS"]) +
                                Val.ToInt(DRow["SAW_PCS"]) +
                                Val.ToInt(DRow["CANCEL_PCS"]) +
                                Val.ToInt(DRow["LOST_PCS"]) +
                                Val.ToInt(DRow["LOSS_PCS"])
                            )
                        )
                    {
                        Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Issue Pcs Is Not Match With Other Pcs Please Check");
                        return;
                    }
                }

                if (Val.Val(DRow["JANGED_PROCESS_CODE"]) == 0)
                {
                    if (Val.Val(DRow["RR_CARAT"]) != 0 && Val.ToInt(DRow["RR_PCS"]) == 0)
                    {
                        Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " RR Pcs Is Required When RR Carat Is There");
                        return;
                    }

                    if (Val.ToInt(DRow["RR_PCS"]) != 0 && Val.Val(DRow["RR_CARAT"]) == 0)
                    {
                        Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " RR Carat Is Required When RR Pcs Is There");
                        return;
                    }

                    if (Val.ToInt(DRow["SAW_PCS"]) != 0 && Val.Val(DRow["SAW_CARAT"]) == 0)
                    {
                        Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Sawing Carat Is Required When Saw Pcs Is There");
                        return;
                    }

                    if (Val.Val(DRow["SAW_CARAT"]) != 0 && Val.ToInt(DRow["SAW_PCS"]) == 0)
                    {
                        Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Sawing Pcs Is Required When Saw Carat Is There");
                        return;
                    }
                }

                if (Val.Val(DRow["SAW_PCS"]) != 0 && Val.Val(DRow["SAW_CARAT"]) == 0)
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Sawing Carat Is Required When Saw Pcs Is There");
                    return;
                }

                if (Val.Val(DRow["SAW_CARAT"]) != 0 && Val.Val(DRow["SAW_PCS"]) == 0)
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Sawing Pcs Is Required When Saw Carat Is There");
                    return;
                }

                if (Val.ToInt(DRow["CONSUME_PCS"]) != 0 && Val.Val(DRow["CONSUME_CARAT"]) == 0)
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Consume Carat Is Required When Consume Pcs Is There");
                    return;
                }

                if (Val.ToInt(DRow["CONSUME_PCS"]) != 0 && Val.Val(DRow["CONSUME_CARAT"]) == 0)
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Consume Pcs Is Required When Consume Carat Is There");
                    return;
                }

                if (Val.ToInt(DRow["LOST_PCS"]) != 0 && Val.Val(DRow["LOST_CARAT"]) == 0)
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Lost Carat Is Required When Lost Pcs Is There");
                    return;
                }

                if (Val.ToInt(DRow["LOST_PCS"]) != 0 && Val.Val(DRow["LOST_CARAT"]) == 0)
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Lost Pcs Is Required When Lost Carat Is There");
                    return;
                }

                if (Val.ToInt(DRow["READY_PCS"]) != 0 && Val.Val(DRow["READY_CARAT"]) == 0)
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Ready Carat Is Required When Ready Pcs Is There");
                    return;
                }
                if (Val.ToInt(DRow["READY_PCS"]) != 0 && Val.Val(DRow["READY_CARAT"]) == 0)
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Ready Pcs Is Required When Ready Carat Is There");
                    return;
                }

                if (Val.ToInt(DRow["READY_PCS"]) > Val.ToInt(DRow["ISSUE_PCS"]))
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Ready Pcs Is Greater Than Issue");
                    return;
                }

                if (Val.ToInt(DRow["READY_PCS"]) > Val.ToInt(DRow["CONSUME_PCS"]))
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Ready Pcs Is Greater Than Consume");
                    return;
                }

                if (Val.Val(DRow["READY_CARAT"]) > Val.Val(DRow["ISSUE_CARAT"]))
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Ready Carat Is Greater Than Issue");
                    return;
                }

                if (Val.Val(DRow["READY_CARAT"]) > Val.Val(DRow["CONSUME_CARAT"]))
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Ready Carat Is Greater Than Consume");
                    return;
                }
                if (Val.Val(DRow["RR_CARAT"]) > Val.Val(DRow["ISSUE_CARAT"]))
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " RR Carat Is Greater Than Issue");
                    return;
                }

                if (Val.ToInt(DRow["READY_PCS"]) != Val.ToInt(DRow["CONSUME_PCS"]))
                {
                    Global.Confirm("Barcode : " + Val.ToString(DRow["BARCODE"]) + " Ready Pcs Is Not Equal To Consume");
                    return;
                }
            }

            int IntRes = 0;

            foreach (DataRow DRow in DTab.Rows)
            {
                if (Val.Val(DRow["READY_CARAT"]) == 0)
                {
                    DRow["CONSUME_CARAT"] = 0.000;

                    if (Val.Val(DRow["ISSUE_CARAT"]) >= Val.Val(DRow["RR_CARAT"]))
                    {
                        DRow["LOSS_CARAT"] = Math.Round(Val.Val(DRow["ISSUE_CARAT"]) - Val.Val(DRow["RR_CARAT"]) - Val.Val(DRow["LOST_CARAT"]) - Val.Val(DRow["SAW_CARAT"]), 3);
                    }
                }

                if (Val.ToInt(DRow["JANGED_PROCESS_CODE"]) != 0)
                {
                    DRow["ISSUE_CARAT"] = Math.Round(Val.Val(DRow["CONSUME_CARAT"]) +
                                          Val.Val(DRow["RR_CARAT"]) +
                                          Val.Val(DRow["SAW_CARAT"]) +
                                          Val.Val(DRow["LOST_CARAT"]) +
                                          Val.Val(DRow["LOSS_CARAT"]), 3);
                }

                if (Val.ToInt(DRow["JANGED_PROCESS_CODE"]) == 49 || Val.ToInt(DRow["FROM_PROCESS_CODE"]) == 33)
                {
                    if (Val.ToString(DRow["LABOUR_TYPE"]) == "PCS")
                    {
                        DRow["LABOUR_AMOUNT"] = Math.Round((Val.Val(DRow["CONSUME_PCS"]) + Val.Val(DRow["LOSS_PCS"])) * Val.Val(DRow["LABOUR_RATE"]), 2);
                    }
                    else if (Val.ToString(DRow["LABOUR_TYPE"]) == "CARAT")
                    {
                        DRow["LABOUR_AMOUNT"] = Math.Round((Val.Val(DRow["CONSUME_CARAT"]) + Val.Val(DRow["LOSS_CARAT"])) * Val.Val(DRow["LABOUR_RATE"]), 2);
                    }
                }
                else
                {
                    if (Val.ToString(DRow["LABOUR_TYPE"]) == "PCS")
                    {
                        DRow["LABOUR_AMOUNT"] = Math.Round(Val.Val(DRow["CONSUME_PCS"]) * Val.Val(DRow["LABOUR_RATE"]), 2);
                    }
                    else if (Val.ToString(DRow["LABOUR_TYPE"]) == "CARAT")
                    {
                        DRow["LABOUR_AMOUNT"] = Math.Round(Val.Val(DRow["CONSUME_CARAT"]) * Val.Val(DRow["LABOUR_RATE"]), 2);
                    }
                }
            }

            foreach (DataRow DRow in DTab.Rows)
            {

                Mix_IssRet_MasterProperty RRProperty = new Mix_IssRet_MasterProperty();

                Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();


                if (
                       Val.Val(DRow["READY_CARAT"]) != 0
                       &&
                       (Val.Val(DRow["RR_CARAT"]) + Val.Val(DRow["SAW_CARAT"])) != 0
                    //   && Val.Val(DRow["RR_SRNO"]) == 0
                    //   && Val.ToInt(DRow["RR_JANGED_NO"]) == 0
                   )
                {
                    RRProperty = new Mix_IssRet_MasterProperty();

                    RRProperty.Rough_Name = Val.ToString(DRow["ROUGH_NAME"]);
                    RRProperty.Barcode = Val.ToString(DRow["BARCODE"]);

                    RRProperty.Janged_Date = Val.DBDate(Val.ToString(DRow["JANGED_DATE"]));// Val.DBDate(DTPFromEntryDate.Text);
                    RRProperty.Janged_No = 0;
                    RRProperty.SrNo = 0;

                    RRProperty.From_Party_Code = Val.ToInt(DRow["FROM_PARTY_CODE"]);
                    RRProperty.To_Party_Code = Val.ToInt(DRow["TO_PARTY_CODE"]);
                    //RRProperty.From_Sub_Party_Code = Val.ToInt(DRow["FROM_SUB_PARTY_CODE"]);
                    //RRProperty.To_Sub_Party_Code = Val.ToInt(DRow["TO_SUB_PARTY_CODE"]);
                    RRProperty.From_Company_Code = Val.ToInt(DRow["FROM_COMPANY_CODE"]);
                    RRProperty.To_Company_Code = Val.ToInt(DRow["TO_COMPANY_CODE"]);
                    RRProperty.From_Branch_Code = Val.ToInt(DRow["FROM_BRANCH_CODE"]);
                    RRProperty.To_Branch_Code = Val.ToInt(DRow["TO_BRANCH_CODE"]);
                    RRProperty.From_Location_Code = Val.ToInt(DRow["FROM_LOCATION_CODE"]);
                    RRProperty.To_Location_Code = Val.ToInt(DRow["TO_LOCATION_CODE"]);
                    RRProperty.From_Department_Code = Val.ToInt(DRow["FROM_DEPARTMENT_CODE"]);
                    RRProperty.To_Department_Code = Val.ToInt(DRow["TO_DEPARTMENT_CODE"]);
                    RRProperty.From_Process_Code = Val.ToInt(DRow["FROM_PROCESS_CODE"]);
                    RRProperty.To_Process_Code = Val.ToInt(new ProcessMaster().GetUnTouchProcess());

                    RRProperty.Entry_Date = Val.DBDate(Val.ToString(DRow["JANGED_DATE"]));
                    //RRProperty.Entry_Time = Val.DBTime(DTPFromEntryDate.Value.ToShortTimeString());
                    RRProperty.Issue_Computer_IP = BLL.GlobalDec.gStrComputerIP;
                    RRProperty.Issue_Empoloyee_Code = BLL.GlobalDec.gEmployeeProperty.Employee_Code;

                    RRProperty.Receive_Date = Val.DBDate(Val.ToString(DRow["JANGED_DATE"]));
                   // RRProperty.Receive_Time = Val.DBTime(DTPFromEntryDate.Text);
                    RRProperty.Receive_Computer_IP = BLL.GlobalDec.gStrComputerIP;
                    RRProperty.Receive_Empoloyee_Code = BLL.GlobalDec.gEmployeeProperty.Employee_Code;

                    RRProperty.Receive_Janged_No = Val.ToString(Val.ToString(DRow["BILL_OF_ENTRY_NO"]));

                    //RRProperty.RR_Janged_Date = Val.DBDate(Val.ToString(DRow["RR_JANGED_DATE"]));
                    //RRProperty.RR_Janged_No = Val.ToInt(DRow["RR_JANGED_NO"]);
                    //RRProperty.RR_SrNo = Val.ToInt(DRow["RR_SRNO"]);

                    RRProperty.IS_Polish_RR_Flag = 1;

                    RRProperty.Issue_Pcs = Val.ToInt(DRow["RR_PCS"]) + Val.ToInt(DRow["SAW_PCS"]);
                    RRProperty.Issue_Carat = Math.Round(Val.Val(DRow["RR_CARAT"]) + Val.Val(DRow["SAW_CARAT"]), 3);

                    RRProperty = ObjPolish.SaveDepartmentIssueNew(RRProperty);

                    if (RRProperty != null)
                    {
                        //DRow["RR_JANGED_NO"] = RRProperty.Janged_No;
                        //DRow["RR_SRNO"] = RRProperty.SrNo;
                        //DRow["RR_JANGED_DATE"] = RRProperty.Janged_Date;// Val.DBDate(DTPFromEntryDate.Text);

                        Mix_IssRet_MasterProperty DetailRRProperty = new Mix_IssRet_MasterProperty();
                        DetailRRProperty.Janged_Date = Val.DBDate(Val.ToString(DRow["JANGED_DATE"])); //Val.DBDate(DTPFromEntryDate.Text);
                        DetailRRProperty.Janged_No = Val.ToInt(RRProperty.Janged_No);

                        DetailRRProperty.Receive_Date = Val.DBDate(Val.ToString(DRow["JANGED_DATE"])); // Val.DBDate(DTPFromEntryDate.Text);
                        //DetailRRProperty.Receive_Time = Val.GetFullTime12();
                        IntRes += ObjPolish.SaveDepartmentReceiveManual(DetailRRProperty);

                        DetailRRProperty = null;
                    }
                    RRProperty = null;
                }

                Property = new Mix_IssRet_MasterProperty();
                Property.Rough_Name = Val.ToString(DRow["ROUGH_NAME"]);
                Property.Barcode = Val.ToString(DRow["BARCODE"]);

                Property.Janged_Date = Val.DBDate(Val.ToString(DRow["JANGED_DATE"]));
                Property.Janged_No = Val.ToInt(DRow["JANGED_NO"]);
                Property.SrNo = Val.ToInt(DRow["SRNO"]);
                Property.Janged_SrNo = Val.ToInt(DRow["JANGED_SRNO"]);

                //Property.RR_Janged_Date = Val.DBDate(Val.ToString(DRow["RR_JANGED_DATE"]));
                //Property.RR_Janged_No = Val.ToInt(DRow["RR_JANGED_NO"]);
                //Property.RR_SrNo = Val.ToInt(DRow["RR_SRNO"]);

                Property.Issue_Pcs = Val.ToInt(DRow["ISSUE_PCS"]);
                Property.Issue_Carat = Math.Round(Val.Val(DRow["ISSUE_CARAT"]), 3);

                Property.Receive_Pcs = Val.ToInt(DRow["READY_PCS"]);
                Property.Receive_Carat = Val.Val(DRow["READY_CARAT"]);

                Property.RR_Pcs = Val.ToInt(DRow["RR_PCS"]);
                Property.RR_Carat = Val.Val(DRow["RR_CARAT"]);

                Property.Consume_Pcs = Val.ToInt(DRow["CONSUME_PCS"]);
                Property.Consume_Carat = Val.Val(DRow["CONSUME_CARAT"]);

                Property.Saw_Pcs = Val.ToInt(DRow["SAW_PCS"]);
                Property.Saw_Carat = Val.Val(DRow["SAW_CARAT"]);

                Property.Loss_Pcs = Val.ToInt(DRow["LOSS_PCS"]);
                Property.Loss_Carat = Val.Val(DRow["LOSS_CARAT"]);

                Property.Lost_Pcs = Val.ToInt(DRow["LOST_PCS"]);
                Property.Lost_Carat = Val.Val(DRow["LOST_CARAT"]);

                Property.Prev_Janged_Date = Val.DBDate(Val.ToString(DRow["PREV_JANGED_DATE"]));
                Property.Prev_Janged_No = Val.ToInt(DRow["PREV_JANGED_NO"]);
                Property.Prev_Janged_SrNo = Val.ToInt(DRow["PREV_JANGED_SRNO"]);
                Property.From_Process_Code = Val.ToInt(DRow["FROM_PROCESS_CODE"]);

                // Add By Vipul On 05/Sep/2014
                Property.Labour_Amount = Val.Val(DRow["LABOUR_AMOUNT"]);

                IntRes += ObjPolish.Update(Property);
                Property = null;

            }
            ObjPolish.DTabDetail.AcceptChanges();
            if (IntRes != 0)
            {
                Global.Confirm("Update Successfully Done");
                BtnShow_Click(null, null);
            }
        }

        private void FrmOutSideIssue_Shown(object sender, EventArgs e)
        {
            btnClear_Click(btnClear, null);
            DTPFromEntryDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            DTPToDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            Global.LOOKUPRough(LookupRoughName);

            Global.LOOKUPProcessRep(RepProcess);
            Global.LOOKUPCompanyRep(RepFromCompany);
            Global.LOOKUPCompanyRep(RepToCompany);
            Global.LOOKUPBranchRep(RepFromBranch);
            Global.LOOKUPBranchRep(RepToBranch);
            Global.LOOKUPLocationRep(RepFromLocation);
            Global.LOOKUPLocationRep(RepToLocation);
            Global.LOOKUPDepartmentRep(RepFromDept);
            Global.LOOKUPDepartmentRep(RepToDept);
            Party_MasterProperty Party = new Party_MasterProperty();
            Party.Party_Type = "";
            Global.LOOKUPPartyRep(RepFromParty, Party);
            Party = null;
            Party = new Party_MasterProperty();
            Party.Party_Type = "";
            Global.LOOKUPPartyRep(RepToParty, Party);
            Party = null;
        }

        private void RepProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPProcessRep(RepProcess);
            }
        }

        private void RepFromCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCompanyMaster frmCnt = new FrmCompanyMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCompanyRep(RepFromCompany);
            }
        }

        private void RepToCompany_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmCompanyMaster frmCnt = new FrmCompanyMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPCompanyRep(RepToCompany);
            }
        }

        private void RepFromBranch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmBranchMaster frmCnt = new FrmBranchMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPBranchRep(RepFromBranch);
            }
        }

        private void RepToBranch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmBranchMaster frmCnt = new FrmBranchMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPBranchRep(RepToBranch);
            }
        }

        private void RepFromLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmLocationMaster frmCnt = new FrmLocationMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPLocationRep(RepFromLocation);
            }
        }

        private void RepToLocation_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmLocationMaster frmCnt = new FrmLocationMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPLocationRep(RepToLocation);
            }
        }

        private void RepFromDept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmDepartmentMaster frmCnt = new FrmDepartmentMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPDepartmentRep(RepFromDept);
            }
        }

        private void RepToDept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmDepartmentMaster frmCnt = new FrmDepartmentMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPDepartmentRep(RepToDept);
            }
        }

        private void RepFromParty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                Party_MasterProperty Party = new Party_MasterProperty();
                Party.Party_Type = "";
                Global.LOOKUPPartyRep(RepFromParty, Party);
                Party = null;
            }
        }

        private void RepToParty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                Party_MasterProperty Party = new Party_MasterProperty();
                Party.Party_Type = "";
                Global.LOOKUPPartyRep(RepToParty, Party);
                Party = null;
            }
        }

        private void GrdDetDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int IntRRPcs = Val.ToInt(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_PCS").ToString());
                switch (e.Column.FieldName.ToUpper())
                {
                    case "CONSUME_CARAT":
                        double DouIssueCarat = Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "ISSUE_CARAT").ToString());
                        double DouConsumeCarat = Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "CONSUME_CARAT").ToString());
                        double DouRRCarat = Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_CARAT").ToString());
                        double DouSawCarat = Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "SAW_CARAT").ToString());

                        GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "LOSS_CARAT", Math.Round(DouIssueCarat - DouConsumeCarat - DouRRCarat - DouSawCarat, 3));
                        break;

                    case "RR_PCS":
                    case "SAW_PCS":
                        if (Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "ISSUE_PCS")) != 0)
                        {
                            int IntOrgPcs = Val.ToInt(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "ISSUE_PCS").ToString());
                            double DouOrgCarat = Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "ISSUE_CARAT").ToString());
                            IntRRPcs = Val.ToInt(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_PCS").ToString()) + Val.ToInt(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "SAW_PCS").ToString());

                            DouRRCarat = Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_CARAT").ToString()) + Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "SAW_CARAT").ToString());

                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_CARAT", Math.Round(DouRRCarat, 3));
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "CONSUME_PCS", IntOrgPcs - IntRRPcs);
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "CONSUME_CARAT", Math.Round(DouOrgCarat - DouRRCarat, 3));
                        }
                        else
                        {
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_PCS", Val.Format(0, "#########0"));
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_CARAT", Val.Format(0.000, "#########0.000"));
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "CONSUME_PCS", Val.Format(0, "#########0"));
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "CONSUME_CARAT", Val.Format(0.000, "#########0.000"));
                        }

                        if (Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "CONSUME_CARAT")) == 0)
                        {
                            if (Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "ISSUE_CARAT")) > Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_CARAT")))
                            {
                                double DouCarat = Math.Round(Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "ISSUE_CARAT")) - Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_CARAT")) - Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "LOST_CARAT")) - Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "SAW_CARAT")), 3);
                                GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "LOSS_CARAT", Val.Format(DouCarat, "#########0.000"));
                            }
                            else
                            {
                                GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "LOSS_CARAT", Val.Format(0.000, "#########0.000"));
                            }
                        }
                        else
                        {
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "LOSS_CARAT", Val.Format(0.000, "#########0.000"));
                        }
                        break;
                    case "RR_CARAT":
                    case "SAW_CARAT":
                    case "LOST_CARAT":
                        if (Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "ISSUE_CARAT")) != 0)
                        {
                            double DouOrgCarat = Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "ISSUE_CARAT").ToString());
                            DouRRCarat = Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_CARAT").ToString()) + Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "SAW_CARAT").ToString());
                            double DouLostCarat = Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "LOST_CARAT").ToString());

                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "CONSUME_CARAT", Val.Format(DouOrgCarat - (DouRRCarat + DouLostCarat), "#########0.000"));
                        }
                        else
                        {
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_PCS", Val.Format(0, "#########0"));
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_CARAT", Val.Format(0.000, "#########0.000"));
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "CONSUME_PCS", Val.Format(0, "#########0"));
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "CONSUME_CARAT", Val.Format(0.000, "#########0.000"));
                        }

                        if (Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "CONSUME_CARAT")) == 0)
                        {
                            if (Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "ISSUE_CARAT")) > Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_CARAT")))
                            {
                                double DouCarat = Math.Round(Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "ISSUE_CARAT")) - Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "RR_CARAT")) - Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "LOSS_CARAT")) - Val.Val(GrdDetDetail.GetRowCellValue(GrdDetDetail.FocusedRowHandle, "SAW_CARAT")), 3);
                                GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "LOSS_CARAT", Val.Format(DouCarat, "#########0.000"));
                            }
                            else
                            {
                                GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "LOSS_CARAT", Val.Format(0.000, "#########0.000"));
                            }
                        }
                        else
                        {
                            GrdDetDetail.SetRowCellValue(GrdDetDetail.FocusedRowHandle, "LOSS_CARAT", Val.Format(0.000, "#########0.000"));
                        }
                        break;

                    default:
                        break;
                }

            }
            catch (Exception)
            {

            }
        }       
    }
}
