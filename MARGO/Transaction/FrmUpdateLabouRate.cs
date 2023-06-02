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
using System.Collections;
using KGKDiamond.Class;

namespace MARGO
{
    public partial class FrmUpdateLabouRate : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        LabourRateMaster ObjLabour = new LabourRateMaster();
        DevExpressGrid selection;
        DataTable DTabLabour = new DataTable();

        public FrmUpdateLabouRate()
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

        private void FrmPacketDetail_Shown(object sender, EventArgs e)
        {
            Global.LOOKUPRough(LookupRoughName);
            Global.LOOKUPShape(LookupShapeName);
            Global.LOOKUPSieve(LookupSieve);
            Global.LOOKUPClarity(LookUpClarity, "Mfg");
            Global.LOOKUPProcess(ChkCmbFromProcess);
            //Global.LOOKUPParty(ChkCmbFromParty);
            //Global.LOOKUPParty(ChkCmbToParty);
            Party_MasterProperty Party = new Party_MasterProperty();
            Party.Party_Type = "Labour";
            Global.LOOKUPParty(ChkCmbFromParty, Party);
            Party = null;
            Party = new Party_MasterProperty();
            Party.Party_Type = "Self";
            Global.LOOKUPParty(ChkCmbToParty, Party);
            Party = null;

            DTPFromDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            DTPToDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            dtpBillDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            CmbLabourType.SelectedIndex = 0;
            MainGridLabourBill.Visible = false;
            MainGridLabourBill.Dock = DockStyle.None;
            MainGridLabourUpdate.Visible = true;
            MainGridLabourUpdate.Dock = DockStyle.Fill;

            ChkCmbFromProcess.Focus();
        }

        private void BtnGenerateLabouurBill_Click(object sender, EventArgs e)
        {
            if (Val.Trim(ChkCmbToParty.Properties.GetCheckedItems()) == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select Any One To Party");
                return;
            }

            if (DTPFromDate.Text == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select From Receive Date");
                DTPFromDate.Focus();
                return;
            }
            if (DTPToDate.Text == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select To Receive Date");
                DTPToDate.Focus();
                return;
            }

            if (Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems()) == "")
            {
                Global.Confirm("Please Select at least One Process To Generate Labour Bill");
                ChkCmbFromProcess.Focus();
                return;
            }

            if (Global.Confirm("Are You Sure To Generate Bill\n\nFrom?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            DataTable DTabBillData = ObjLabour.GetBillData(
                                                                Val.ToString(Val.Trim(ChkCmbFromParty.Properties.GetCheckedItems())),
                                                                Val.ToString(Val.Trim(ChkCmbToParty.Properties.GetCheckedItems())),
                                                                Val.ToString(Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems())),
                                                                Val.DBDate(DTPFromDate.Text),
                                                                Val.DBDate(DTPToDate.Text)
                                                                );

            if (DTabBillData.Rows.Count == 0)
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("No Data Found For Billing");
                return;
            }
            //string StrParty = "";
            DataTable DTabPartyAddress = new DataTable();
            foreach (DataRow Drow in DTabBillData.Rows)
            {

                //StrParty += Val.ToString(Drow["LINK_CODE"]) + ",";

                string StrBillNo = "";
                Int64 IntBillInt = 0;
                Int64 TDS_Amount = 0;
                if (Val.ToString(Drow["BILL_NO"]) == "")
                {
                    IntBillInt = ObjLabour.FindNewBillNo(Val.ToString(Val.Trim(ChkCmbToParty.Properties.GetCheckedItems())), Val.ToString(Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems())), Val.DBDate("01" + "/" + Val.ToString(Drow["MM"]) + "/" + Val.ToString(Drow["YY"])));

                    string DefaultString = "";

                    if (IntBillInt < 10)
                    {
                        DefaultString = "000" + IntBillInt.ToString();
                    }
                    else if (IntBillInt < 100)
                    {
                        DefaultString = "00" + IntBillInt.ToString();
                    }
                    else if (IntBillInt < 1000)
                    {
                        DefaultString = "0" + IntBillInt.ToString();
                    }
                    else if (IntBillInt < 10000)
                    {
                        DefaultString = IntBillInt.ToString();
                    }

                    int IntProcessCode = Val.ToInt(Drow["FROM_PROCESS_CODE"]);

                    Process_MasterProperty Property = new ProcessMaster().GetDataByPK(IntProcessCode);
                    string pStrBillPrefix = "";

                    if (Property == null || Val.ToString(Property.Janged_Prefix) == "")
                    {
                        Property.Process_ShortName = "";
                        this.Cursor = Cursors.Default;
                        Global.Confirm("Bill Prefix Not Found Please Check");
                        return;
                    }
                    else
                    {
                        pStrBillPrefix = Property.Janged_Prefix;
                    }

                    //string StrMonth =  Val.ToString(Drow["YY"]) + (Val.ToInt(Drow["MM"]) < 10 ? "0" + Val.ToString(Drow["MM"]) : Val.ToString(Drow["MM"]));
                    string StrMonth = Global.GetMonthName(Val.ToInt(Drow["MM"])) + "-" + Val.ToString(Drow["YY"]);

                    StrBillNo = pStrBillPrefix + DefaultString + "/" + StrMonth;
                }
                else
                {
                    StrBillNo = Val.ToString(Drow["BILL_NO"].ToString());
                    IntBillInt = Val.ToInt(Drow["BILL_INT"].ToString());
                }

                Int64 IntRes = ObjLabour.UpdateJangedBill(Val.ToInt64(Drow["LINK_CODE"]), 
                                                          Val.ToString(Val.Trim(ChkCmbToParty.Properties.GetCheckedItems())),
                                                       Val.ToString(Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems())),
                                                       Val.DBDate(DTPFromDate.Text),
                                                       //Val.ToInt(Drow["MM"]),
                                                       //Val.ToInt(Drow["YY"]),
                                                       StrBillNo,
                                                       IntBillInt,
                                                       TDS_Amount,
                                                       Val.DBDate(DTPFromDate.Text),
                                                       Val.DBDate(DTPToDate.Text),
                                                       Val.DBDate(dtpBillDate.Text)
                                                       );

                Drow["BILL_NO"] = StrBillNo;
                Drow["BILL_INT"] = IntBillInt;
            }
            DTabBillData.AcceptChanges();

            this.Cursor = Cursors.Default;
            if (DTabBillData.Rows.Count != 0)
            {
                Global.Confirm("1. CREATE BILLS OPERATION SUCCESSFULLY DONE.\n\nNOW\n\n2. VIEW BILL : VERIFY YOUR BILL AMOUNT & NET PAYABLE\n\nTHEN\n\n3. PRINT BILLS ");
            }
        }

        private void BtnViewBills_Click(object sender, EventArgs e)
        {
            if (Val.Trim(ChkCmbToParty.Properties.GetCheckedItems()) == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select Any One To Sub Party");
                return;
            }

            if (DTPFromDate.Text == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select From Receive Date");
                return;
            }
            if (DTPToDate.Text == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select To Receive Date");
                return;
            }

            if (Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems()) == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select at least One Process To Generate Labour Bill");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            DataTable DTabBillData = ObjLabour.ViewBillData(
                                                                Val.ToString(Val.Trim(ChkCmbFromParty.Properties.GetCheckedItems())),
                                                                Val.ToString(Val.Trim(ChkCmbToParty.Properties.GetCheckedItems())),
                                                                Val.ToString(Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems())),
                                                                Val.DBDate(DTPFromDate.Text),
                                                                Val.DBDate(DTPToDate.Text)
                                                                );
            this.Cursor = Cursors.Default;
            MainGridLabourBill.DataSource = DTabBillData;
            MainGridLabourBill.Refresh();



            MainGridLabourUpdate.Visible = false;
            MainGridLabourUpdate.Dock = DockStyle.None;
            MainGridLabourBill.Visible = true;
            MainGridLabourBill.Dock = DockStyle.Fill;

            GrdLabourBill.BestFitColumns();

            if (MainGridLabourBill.RepositoryItems.Count == 0)
            {
                selection = new DevExpressGrid();
                selection.View = GrdLabourBill;
                selection.ClearSelection();
                selection.CheckMarkColumn.VisibleIndex = 0;
            }
            else
            {
                selection.ClearSelection();
            }

            GrdLabourBill.Columns["CheckMarkSelection"].OwnerBand = GrdLabourBill.Bands["BANDBILL"];
            GrdLabourBill.Columns["CheckMarkSelection"].ColVIndex = 0;
        }

        private void BtnPrintBills_Click(object sender, EventArgs e)
        {
            if (selection == null)
            {
                Global.Confirm("No Selection Found");
                return;
            }

            ArrayList AL = selection.GetSelectedArrayList();

            if (AL.Count == 0)
            {
                Global.Confirm("Please Select at lease One Record");
                return;
            }

            if (Global.Confirm("Are You Sure To Print Bill ? ", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            DataTable DTabPrint = new DataTable();
            
            DataTable DTabPartyAddress = new DataTable();

            for (int i = 0; i < AL.Count; i++)
            {
                DataRowView oDataRowViewI = AL[i] as DataRowView;

               // StrParty += Val.ToString(oDataRowViewI.Row["LINK_CODE"].ToString()) + ",";
                DataTable DTab = ObjLabour.LabourBillPrint(//Val.ToString(Val.Trim(ChkCmbFromParty.Properties.GetCheckedItems())),
                                                           Val.ToString(Val.Trim(ChkCmbToParty.Properties.GetCheckedItems())),
                                                           Val.ToString(oDataRowViewI.Row["BILL_NO"].ToString())
                                                              );
                DTabPrint.Merge(DTab);
            }
            DTabPrint.DefaultView.Sort = "BILL_NO DESC";
            DTabPrint = DTabPrint.DefaultView.ToTable();

            if (DTabPrint.Rows.Count == 0)
            {
                Global.Confirm("Printing Data Not Found");
                return;
            }

            //if (StrParty != "")
            //{
            //    StrParty = StrParty.Substring(0, StrParty.Length - 1);
            //    DTabPartyAddress = ObjLabour.GetPartyAddress(StrParty);
            //}

            //Mix_IssRet_MasterProperty pClsProperty = new Mix_IssRet_MasterProperty();
            //pClsProperty.From_Sub_Party_Multi = Val.ToString(Val.Trim(ChkCmbFromParty.Properties.GetCheckedItems()));
            //pClsProperty.To_Sub_Party_Multi = Val.ToString(Val.Trim(ChkCmbToParty.Properties.GetCheckedItems()));
            //pClsProperty.Process_Multi = Val.ToString(Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems()));
            //pClsProperty.From_Janged_Date = Val.DBDate(DTPFromDate.Text);
            //pClsProperty.To_Janged_Date = Val.DBDate(DTPToDate.Text);

            //DataTable DTabLabourCharge = ObjLabour.LabourChargesSummary(pClsProperty);

            FrmReportViewer FrmReportViewer = new FrmReportViewer();
            FrmReportViewer.DS.Tables.Add(DTabPrint);
            FrmReportViewer.FromDate = DTPFromDate.Text;
            FrmReportViewer.ToDate = DTPToDate.Text;
            FrmReportViewer.GroupBy = "";
            FrmReportViewer.RepName = "";
            FrmReportViewer.RepPara = "";
            this.Cursor = Cursors.Default;
            FrmReportViewer.AllowSetFormula = true;
            FrmReportViewer.ShowForm("Labour_Bill", 120, Report.FrmReportViewer.ReportFolder.JANGED);

            //FrmReportViewer FrmReportViewer1 = new FrmReportViewer();
            //FrmReportViewer1.FromDate = DTPFromDate.Text;
            //FrmReportViewer1.ToDate = DTPToDate.Text;
            //FrmReportViewer1.GroupBy = "";
            //FrmReportViewer1.RepName = "";
            //FrmReportViewer1.PROCESS = Val.ToString(Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems()));
            //FrmReportViewer1.RepPara = "";
            //FrmReportViewer1.AllowSetFormula = true;
            //FrmReportViewer1.ShowForm("Labour_Charges_summary", DTabLabourCharge, 120, Report.FrmReportViewer.ReportFolder.JANGED);
            //FrmReportViewer1 = null;

            //FrmReportViewer FrmReportViewer2 = new FrmReportViewer();
            //FrmReportViewer2.ShowForm("CLV_To_OutSide_Address", DTabPartyAddress, 120, Report.FrmReportViewer.ReportFolder.JANGED);
            //FrmReportViewer2 = null;
        }

        private void BtnDeleteBill_Click(object sender, EventArgs e)
        {
            if (Val.Trim(ChkCmbToParty.Properties.GetCheckedItems()) == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select Any One To Party");
                return;
            }

            if (DTPFromDate.Text == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select From Receive Date");
                return;
            }
            if (DTPToDate.Text == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select To Receive Date");
                return;
            }

            if (Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems()) == "")
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Please Select at least One Process To Generate Labour Bill");
                return;
            }

            if (Global.Confirm("Are You Sure To Delete Bill ", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            int IntRes = ObjLabour.DeleteBillData(
                                                                Val.ToString(Val.Trim(ChkCmbFromParty.Properties.GetCheckedItems())),
                                                                Val.ToString(Val.Trim(ChkCmbToParty.Properties.GetCheckedItems())),
                                                                Val.ToString(Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems())),
                                                                Val.DBDate(DTPFromDate.Text),
                                                                Val.DBDate(DTPToDate.Text)
                                                                );

            this.Cursor = Cursors.Default;
            if (IntRes != 0)
            {
                this.Cursor = Cursors.Default;
                Global.Confirm("Your Bill Data Successfully Erased.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
            Property.From_Sub_Party_Multi = Val.ToString(Val.Trim(ChkCmbFromParty.Properties.GetCheckedItems()));
            Property.To_Sub_Party_Multi = Val.ToString(Val.Trim(ChkCmbToParty.Properties.GetCheckedItems()));
            Property.Process_Multi = Val.ToString(Val.Trim(ChkCmbFromProcess.Properties.GetCheckedItems()));

            Property.Shape_Code = Val.ToInt64(LookupShapeName.EditValue);
            Property.Sieve_Code = Val.ToInt64(LookupSieve.EditValue);
            Property.MFG_Clarity_Code = Val.ToInt64(LookUpClarity.EditValue);
            Property.Rough_Name = Val.ToString(LookupRoughName.EditValue);

            Property.Labour_Type = Val.ToString(CmbLabourType.SelectedItem);
            Property.From_Janged_Date = Val.DBDate(DTPFromDate.Text);
            Property.To_Janged_Date = Val.DBDate(DTPToDate.Text);

            Property.From_Janged_Date = Val.DBDate(DTPFromDate.Text);
            Property.To_Janged_Date = Val.DBDate(DTPToDate.Text);

            //Property.From_Chadta = Val.Val(txtFromChadta.Text);
            //Property.To_Chadta = Val.Val(txtToChadta.Text);

            DTabLabour = ObjLabour.GetLabourData(Property);
            MainGridLabourUpdate.DataSource = DTabLabour;
            MainGridLabourUpdate.RefreshDataSource();
            GrdLabourUpdate.BestFitColumns();

            MainGridLabourBill.Visible = false;
            MainGridLabourBill.Dock = DockStyle.None;
            MainGridLabourUpdate.Visible = true;
            MainGridLabourUpdate.Dock = DockStyle.Fill;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string StrCalcType = Val.ToString(CmbLabourType.SelectedItem);
            double DouRate = Val.Val(txtRate.Text);

            foreach (DataRow DRow in DTabLabour.Rows)
            {

                DRow["LABOUR_TYPE"] = Val.ToString(CmbLabourType.SelectedItem);
                DRow["LABOUR_RATE"] = Val.Val(txtRate.Text);

                Int64 ConsumePcs = Val.ToInt64(DRow["CONSUME_PCS"]);
                Int64 LossPcs = Val.ToInt64(DRow["LOSS_PCS"]);

                double ConsumeCarat = Val.Val(DRow["CONSUME_CARAT"]);
                double LossCarat = Val.Val(DRow["LOSS_CARAT"]);
                Int64 IntFromPRocessCode = Val.ToInt64(DRow["FROM_PROCESS_CODE"]);

                if (StrCalcType == "PCS")
                {
                    if (IntFromPRocessCode == 49 || IntFromPRocessCode == 33)
                    {
                        DRow["LABOUR_AMOUNT"] = Val.Round(DouRate * (ConsumePcs + LossPcs), 2);
                    }
                    else
                    {
                        DRow["LABOUR_AMOUNT"] = Val.Round(DouRate * ConsumePcs, 2);
                    }

                }
                else if (StrCalcType == "CARAT")
                {
                    if (IntFromPRocessCode == 49 || IntFromPRocessCode == 33)
                    {
                        DRow["LABOUR_AMOUNT"] = Val.Round(DouRate * (ConsumeCarat + LossCarat), 2);
                    }
                    else
                    {
                        DRow["LABOUR_AMOUNT"] = Val.Round(DouRate * ConsumeCarat, 2);
                    }
                }
            }
            DTabLabour.AcceptChanges();

            GrdLabourUpdate.BestFitColumns();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (Global.Confirm("Are You Sure to Save New Labour Rate ? ", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            int IntRes = 0;
            foreach (DataRow DRow in DTabLabour.Rows)
            {
                Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
                Property.Janged_Date = Val.DBDate(Val.ToString(DRow["JANGED_DATE"]));
                Property.Janged_No = Val.ToInt64(DRow["JANGED_NO"]);
                Property.Janged_SrNo = Val.ToInt64(DRow["JANGED_SRNO"]);
                Property.Bill_Of_Entry_No = Val.ToString(DRow["BILL_OF_ENTRY_NO"]);
                Property.SrNo = Val.ToInt64(DRow["SRNO"]);
                Property.Trn_ID = Val.ToInt64(DRow["TRN_ID"]);
                Property.Rough_Name = Val.ToString(DRow["ROUGH_NAME"]);
                Property.Barcode = Val.ToString(DRow["BARCODE"]);
                Property.Labour_Rate = Val.Val(DRow["LABOUR_RATE"]);
                Property.Labour_Type = Val.ToString(DRow["LABOUR_TYPE"]);
                Property.Labour_Amount = Val.Val(DRow["LABOUR_AMOUNT"]);

                IntRes += ObjLabour.UpdateLabourRate(Property);
                Property = null;
            }

            this.Cursor = Cursors.Default;
            if (IntRes != 0)
            {
                Global.Confirm("Labour Rate Successfully Updated");
            }
        }
    }
}
