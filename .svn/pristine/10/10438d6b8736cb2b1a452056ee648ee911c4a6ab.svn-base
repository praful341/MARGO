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
using System.Drawing;

namespace MARGO
{
    public partial class FrmRunningPosition : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        DataTable DTab = new DataTable();
        DataTable DTabStock = new DataTable();
        RoughTypeMaster ObjRough = new RoughTypeMaster();

        string mStrStockDate = "";
        int IntCount = 0;
        double DouReadyCarat = 0;
        double DouConsumeCarat = 0;
        double DouPolish = 0;
        double DouOrgCarat = 0;

        DataTable mDTabRough = new DataTable();

        public FrmRunningPosition()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            Val.frmGenSet(this);
            AttachFormEvents();
            this.Show();

            //DTab.Columns.Add(new DataColumn("PARTY_NAME", typeof(string)));
            //DTab.Columns.Add(new DataColumn("STOCK_FLAG", typeof(string)));
            DTab.Columns.Add(new DataColumn("ROUGH_NAME", typeof(string)));
            DTab.Columns.Add(new DataColumn("ORG_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("PROCESS_ISSUE_DATE", typeof(string)));
            DTab.Columns.Add(new DataColumn("CONSUME_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("POLISH_TOTAL_RECEIVE_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("POLISH_IN_HAND_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("POLISH_TO_MUMBAI_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("POLISH_RR_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("ROUGH_TO_ROUGH_TRN_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("PROCESS_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("REP_TS_OS_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("MFG_OS_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("ISSUE_DEPT_STOCK_CARAT", typeof(double)));
            DTab.Columns.Add(new DataColumn("EMPLOYEE_LOSS", typeof(double)));
            DTab.Columns.Add(new DataColumn("MFG_LOSS", typeof(double)));
            DTab.Columns.Add(new DataColumn("REP_LOSS", typeof(double)));
            DTab.Columns.Add(new DataColumn("MIXING_LOSS", typeof(double)));

            DTab.Columns.Add(new DataColumn("DIFF", typeof(double)));

            DTab.Columns.Add(new DataColumn("QC_PLUS", typeof(double)));
            DTab.Columns.Add(new DataColumn("QC_MINUS", typeof(double)));
            DTab.Columns.Add(new DataColumn("QC_LOST", typeof(double)));
            DTab.Columns.Add(new DataColumn("POLISH_CONSUME_PER", typeof(double)));
            DTab.Columns.Add(new DataColumn("POLISH_READY_PER", typeof(double)));


            DTabStock.Columns.Add(new DataColumn("PARTY_NAME", typeof(string)));
            DTabStock.Columns.Add(new DataColumn("STOCK_FLAG", typeof(string)));
            DTabStock.Columns.Add(new DataColumn("ROUGH_NAME", typeof(string)));
            DTabStock.Columns.Add(new DataColumn("ORG_CARAT", typeof(double)));
            DTabStock.Columns.Add(new DataColumn("PROCESS_ISSUE_DATE", typeof(string)));

            DTabStock.Columns.Add(new DataColumn("STOCK3_CONSUME_CARAT", typeof(double)));
            DTabStock.Columns.Add(new DataColumn("STOCK4_CONSUME_CARAT", typeof(double)));

            DTabStock.Columns.Add(new DataColumn("STOCK3_OS_CARAT", typeof(double)));
            DTabStock.Columns.Add(new DataColumn("STOCK4_OS_CARAT", typeof(double)));

            DTabStock.Columns.Add(new DataColumn("ISSUE_DEPT_STOCK_CARAT", typeof(double)));
            DTabStock.Columns.Add(new DataColumn("MAINCABIN_DEPT_RR_CARAT", typeof(double)));
            DTabStock.Columns.Add(new DataColumn("POLISH_DEPT_RR_CARAT", typeof(double)));

            DTabStock.Columns.Add(new DataColumn("STOCK3_WEIGHTLOSS", typeof(double)));
            DTabStock.Columns.Add(new DataColumn("STOCK4_WEIGHTLOSS", typeof(double)));

            DTabStock.Columns.Add(new DataColumn("QC_PLUS", typeof(double)));
            DTabStock.Columns.Add(new DataColumn("QC_MINUS", typeof(double)));
            DTabStock.Columns.Add(new DataColumn("QC_LOST", typeof(double)));
            DTabStock.Columns.Add(new DataColumn("DIFF", typeof(double)));

            MainGridDet.DataSource = DTab;
            MainGridDet.RefreshDataSource();
            GrdDet.BestFitColumns();
            DTPAtdFromDate.Text = DateTime.Now.ToShortDateString();

            MainGridStock4.DataSource = DTabStock;
            MainGridStock4.RefreshDataSource();
            GrdDetStock.BestFitColumns();
            DTPAtdFromDate.Text = DateTime.Now.ToShortDateString();

            MainGridPrint.DataSource = DTab;
            MainGridPrint.RefreshDataSource();
            GrdDetPrint.BestFitColumns();

            MainGridMIS.DataSource = DTab;
            MainGridMIS.RefreshDataSource();
            GrdDetMIS.BestFitColumns();

            RBtnStatus_SelectedIndexChanged(null, null);
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
            ChkCmbRoughName.SetEditValue(null);
            DTPAtdFromDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            ChkCmbRoughName.DeselectAll();
            ChkCmbRoughName.Focus();
            RBtnStatus.SelectedIndex = 2;
        }        

        private void FrmRunningPosition_Shown(object sender, EventArgs e)
        {
            Global.LOOKUPRough(ChkCmbRoughName);
            DTPAtdFromDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            ChkCmbRoughName.Focus();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            if (DTab != null)
            {
                DTab.Rows.Clear();
            }
            if (DTabStock != null)
            {
                DTabStock.Rows.Clear();
            }

            this.Cursor = Cursors.WaitCursor;
            BtnShow.Enabled = false;

            mDTabRough = ObjRough.GetRough(Val.Trim(ChkCmbRoughName.Properties.GetCheckedItems()), ChkCmbRoughName.Text == "" ? 1 : 0);

            this.Cursor = Cursors.Default;

            mStrStockDate = Val.DBDate(DTPAtdFromDate.Text);
            IntCount = 0;
            FillGrid();
            BtnShow.Enabled = true;
            GrdDet.BestFitColumns();
            GrdDetMIS.BestFitColumns();
            GrdDetStock.BestFitColumns();
            GrdDetPrint.BestFitColumns();
    
        }       

        private void FillGrid()
        {
            try
            {

                foreach (DataRow DRow in mDTabRough.Rows)
                {
                    IntCount++;
                    string StrRough = Val.ToString(DRow["ROUGH_NAME"]);
                    // SetControlPropertyValue(lblMessage, "Text", "[ " + IntCount.ToString() + "/" + mDTabRough.Rows.Count + " ] " + StrRough + " : Data Processing.");

                    if (RBtnStatus.EditValue.ToString() == "REGULAR")
                    {

                        // For Regular Rough

                        DataRow DRData = ObjRough.GetData(mStrStockDate, StrRough, Val.ToString(RBtnStatus.EditValue));

                        if (DRData != null)
                        {
                            DataRow DRNew = DTab.NewRow();

                            //DRNew["PARTY_NAME"] = Val.ToString(DRow["PARTY_NAME"]);
                            //DRNew["STOCK_FLAG"] = Val.ToString(DRow["STOCK_FLAG"]);
                            DRNew["ROUGH_NAME"] = StrRough;
                            DRNew["ORG_CARAT"] = Math.Round(Val.Val(DRow["ORG_CARAT"]), 3);
                            DRNew["PROCESS_ISSUE_DATE"] = Val.DBDate(DRow["PROCESS_ISSUE_DATE"].ToString());
                            DRNew["CONSUME_CARAT"] = Math.Round(Val.Val(DRData["CONSUME_CARAT"]), 3);
                            DRNew["POLISH_TOTAL_RECEIVE_CARAT"] = Math.Round(Val.Val(DRData["POLISH_TOTAL_RECEIVE_CARAT"]), 3);
                            DRNew["POLISH_IN_HAND_CARAT"] = Math.Round(Val.Val(DRData["POLISH_IN_HAND_CARAT"]), 3);
                            DRNew["POLISH_TO_MUMBAI_CARAT"] = Math.Round(Val.Val(DRData["POLISH_TO_MUMBAI_CARAT"]), 3);
                            DRNew["POLISH_RR_CARAT"] = Math.Round(Val.Val(DRData["POLISH_RR_CARAT"]), 3);
                            DRNew["ROUGH_TO_ROUGH_TRN_CARAT"] = Math.Round(Val.Val(DRData["ROUGH_TO_ROUGH_TRN_CARAT"]), 3);
                            DRNew["PROCESS_CARAT"] = Math.Round(Val.Val(DRData["PROCESS_CARAT"]), 3);
                            DRNew["REP_TS_OS_CARAT"] = Math.Round(Val.Val(DRData["REP_TS_OS_CARAT"]), 3);
                            DRNew["MFG_OS_CARAT"] = Math.Round(Val.Val(DRData["MFG_OS_CARAT"]), 3);
                            DRNew["ISSUE_DEPT_STOCK_CARAT"] = Math.Round(Val.Val(DRData["ISSUE_DEPT_STOCK_CARAT"]), 3);

                            DRNew["EMPLOYEE_LOSS"] = Math.Round(Val.Val(DRData["EMPLOYEE_LOSS"]), 3);

                            DRNew["MFG_LOSS"] = Math.Round(Val.Val(DRData["MFG_LOSS"]), 3);

                            DRNew["QC_PLUS"] = Math.Round(Val.Val(DRData["QC_PLUS"]), 3);
                            DRNew["QC_MINUS"] = Math.Round(Val.Val(DRData["QC_MINUS"]), 3);
                            DRNew["QC_LOST"] = Math.Round(Val.Val(DRData["QC_LOST"]), 3);

                            double DouDiff = Math.Round(Val.Val(DRow["ORG_CARAT"])
                                            - Val.Val(DRData["CONSUME_CARAT"])
                                            - Val.Val(DRData["POLISH_RR_CARAT"])
                                            - Val.Val(DRData["PROCESS_CARAT"])
                                            - Val.Val(DRData["ISSUE_DEPT_STOCK_CARAT"])
                                            - Val.Val(DRData["EMPLOYEE_LOSS"])
                                            - Val.Val(DRData["MFG_LOSS"])
                                            + Val.Val(DRData["ROUGH_TO_ROUGH_TRN_CARAT"])
                                            + Val.Val(DRData["QC_PLUS"])
                                            - Val.Val(DRData["QC_MINUS"])
                                            - Val.Val(DRData["QC_LOST"])
                                            - Val.Val(DRData["MFG_OS_CARAT"]), 3);

                            DRNew["DIFF"] = DouDiff;


                            if (Val.Val(DRow["ORG_CARAT"]) != 0)
                            {
                                double DouParty = Val.Val(DRData["ISSUE_DEPT_STOCK_CARAT"]) + Val.Val(DRData["MFG_OS_CARAT"]) + Val.Val(DRData["CONSUME_CARAT"]);
                                DRNew["POLISH_CONSUME_PER"] = Math.Round((DouParty / Val.Val(DRow["ORG_CARAT"])) * 100, 3);
                            }

                            if (Val.Val(DRData["CONSUME_CARAT"]) != 0)
                            {
                                DRNew["POLISH_READY_PER"] = Math.Round((Val.Val(DRData["POLISH_TOTAL_RECEIVE_CARAT"]) / Val.Val(DRData["CONSUME_CARAT"])) * 100, 3);
                            }

                            DTab.Rows.Add(DRNew);
                        }
                    }
                    else if (RBtnStatus.EditValue.ToString() == "MIS")
                    {

                        // For Regular Rough

                        DataRow DRData = ObjRough.GetData(mStrStockDate, StrRough, Val.ToString(RBtnStatus.EditValue));

                        if (DRData != null)
                        {
                            DataRow DRNew = DTab.NewRow();

                            //DRNew["PARTY_NAME"] = Val.ToString(DRow["PARTY_NAME"]);
                            //DRNew["STOCK_FLAG"] = Val.ToString(DRow["STOCK_FLAG"]);
                            DRNew["ROUGH_NAME"] = StrRough;
                            DRNew["ORG_CARAT"] = Math.Round(Val.Val(DRow["ORG_CARAT"]), 3);
                            DRNew["PROCESS_ISSUE_DATE"] = Val.DBDate(DRow["PROCESS_ISSUE_DATE"].ToString());
                            DRNew["CONSUME_CARAT"] = Math.Round(Val.Val(DRData["CONSUME_CARAT"]), 3);
                            DRNew["POLISH_TOTAL_RECEIVE_CARAT"] = Math.Round(Val.Val(DRData["POLISH_TOTAL_RECEIVE_CARAT"]), 3);
                            DRNew["POLISH_IN_HAND_CARAT"] = Math.Round(Val.Val(DRData["POLISH_IN_HAND_CARAT"]), 3);
                            DRNew["POLISH_TO_MUMBAI_CARAT"] = Math.Round(Val.Val(DRData["POLISH_TO_MUMBAI_CARAT"]), 3);
                            DRNew["POLISH_RR_CARAT"] = Math.Round(Val.Val(DRData["POLISH_RR_CARAT"]), 3);
                            DRNew["ROUGH_TO_ROUGH_TRN_CARAT"] = Math.Round(Val.Val(DRData["ROUGH_TO_ROUGH_TRN_CARAT"]), 3);
                            DRNew["PROCESS_CARAT"] = Math.Round(Val.Val(DRData["PROCESS_CARAT"]), 3);
                            DRNew["REP_TS_OS_CARAT"] = Math.Round(Val.Val(DRData["REP_TS_OS_CARAT"]), 3);
                            DRNew["MFG_OS_CARAT"] = Math.Round(Val.Val(DRData["MFG_OS_CARAT"]), 3);
                            DRNew["ISSUE_DEPT_STOCK_CARAT"] = Math.Round(Val.Val(DRData["ISSUE_DEPT_STOCK_CARAT"]), 3);

                            DRNew["EMPLOYEE_LOSS"] = Math.Round(Val.Val(DRData["EMPLOYEE_LOSS"]), 3);

                            DRNew["MFG_LOSS"] = Math.Round(Val.Val(DRData["MFG_LOSS"]), 3);
                            DRNew["REP_LOSS"] = Math.Round(Val.Val(DRData["REP_LOSS"]), 3);
                            DRNew["MIXING_LOSS"] = Math.Round(Val.Val(DRData["MIXING_LOSS"]), 3);

                            DRNew["QC_PLUS"] = Math.Round(Val.Val(DRData["QC_PLUS"]), 3);
                            DRNew["QC_MINUS"] = Math.Round(Val.Val(DRData["QC_MINUS"]), 3);
                            DRNew["QC_LOST"] = Math.Round(Val.Val(DRData["QC_LOST"]), 3);

                            double DouDiff = Math.Round(Val.Val(DRow["ORG_CARAT"])
                                            - Val.Val(DRData["CONSUME_CARAT"])
                                            - Val.Val(DRData["POLISH_RR_CARAT"])
                                            - Val.Val(DRData["PROCESS_CARAT"])
                                            - Val.Val(DRData["ISSUE_DEPT_STOCK_CARAT"])
                                            - Val.Val(DRData["EMPLOYEE_LOSS"])
                                            - Val.Val(DRData["MFG_LOSS"])
                                            + Val.Val(DRData["ROUGH_TO_ROUGH_TRN_CARAT"])
                                            + Val.Val(DRData["QC_PLUS"])
                                            - Val.Val(DRData["QC_MINUS"])
                                            - Val.Val(DRData["QC_LOST"])
                                            - Val.Val(DRData["MFG_OS_CARAT"]), 3);

                            DRNew["DIFF"] = DouDiff;


                            if (Val.Val(DRow["ORG_CARAT"]) != 0)
                            {
                                double DouParty = Val.Val(DRData["ISSUE_DEPT_STOCK_CARAT"]) + Val.Val(DRData["MFG_OS_CARAT"]) + Val.Val(DRData["CONSUME_CARAT"]);
                                DRNew["POLISH_CONSUME_PER"] = Math.Round((DouParty / Val.Val(DRow["ORG_CARAT"])) * 100, 3);
                            }

                            if (Val.Val(DRData["CONSUME_CARAT"]) != 0)
                            {
                                DRNew["POLISH_READY_PER"] = Math.Round((Val.Val(DRData["POLISH_TOTAL_RECEIVE_CARAT"]) / Val.Val(DRData["CONSUME_CARAT"])) * 100, 3);
                            }

                            DTab.Rows.Add(DRNew);
                        }
                    }
                    else
                    {

                        // For Stock4 Rough
                        DataRow DRDataStk = ObjRough.GetData(mStrStockDate, StrRough, Val.ToString(RBtnStatus.EditValue));

                        if (DRDataStk != null)
                        {
                            DataRow DRNew = DTabStock.NewRow();

                            //DRNew["PARTY_NAME"] = Val.ToString(DRow["PARTY_NAME"]);
                            //DRNew["STOCK_FLAG"] = Val.ToString(DRow["STOCK_FLAG"]);
                            DRNew["ROUGH_NAME"] = StrRough;
                            DRNew["ORG_CARAT"] = Math.Round(Val.Val(DRow["ORG_CARAT"]), 3);
                            DRNew["PROCESS_ISSUE_DATE"] = Val.DBDate(DRow["PROCESS_ISSUE_DATE"].ToString());

                            DRNew["STOCK3_CONSUME_CARAT"] = Math.Round(Val.Val(DRDataStk["STOCK3_CONSUME_CARAT"]), 3);
                            DRNew["STOCK4_CONSUME_CARAT"] = Math.Round(Val.Val(DRDataStk["STOCK4_CONSUME_CARAT"]), 3);

                            DRNew["STOCK3_OS_CARAT"] = Math.Round(Val.Val(DRDataStk["STOCK3_OS_CARAT"]), 3);
                            DRNew["STOCK4_OS_CARAT"] = Math.Round(Val.Val(DRDataStk["STOCK4_OS_CARAT"]), 3);

                            DRNew["ISSUE_DEPT_STOCK_CARAT"] = Math.Round(Val.Val(DRDataStk["ISSUE_DEPT_STOCK_CARAT"]), 3);
                            DRNew["MAINCABIN_DEPT_RR_CARAT"] = Math.Round(Val.Val(DRDataStk["MAINCABIN_DEPT_RR_CARAT"]), 3);
                            DRNew["POLISH_DEPT_RR_CARAT"] = Math.Round(Val.Val(DRDataStk["POLISH_DEPT_RR_CARAT"]), 3);

                            DRNew["STOCK3_WEIGHTLOSS"] = Math.Round(Val.Val(DRDataStk["STOCK3_WEIGHTLOSS"]), 3);
                            DRNew["STOCK4_WEIGHTLOSS"] = Math.Round(Val.Val(DRDataStk["STOCK4_WEIGHTLOSS"]), 3);

                            DRNew["QC_PLUS"] = Math.Round(Val.Val(DRDataStk["QC_PLUS"]), 3);
                            DRNew["QC_MINUS"] = Math.Round(Val.Val(DRDataStk["QC_MINUS"]), 3);

                            double DouDiff = Math.Round(Val.Val(DRow["ORG_CARAT"])
                                            - (
                                             Val.Val(DRDataStk["STOCK3_CONSUME_CARAT"])
                                            + Val.Val(DRDataStk["STOCK4_CONSUME_CARAT"])
                                            + Val.Val(DRDataStk["STOCK3_OS_CARAT"])
                                            + Val.Val(DRDataStk["STOCK4_OS_CARAT"])
                                            + Val.Val(DRDataStk["ISSUE_DEPT_STOCK_CARAT"])
                                            + Val.Val(DRDataStk["MAINCABIN_DEPT_RR_CARAT"])
                                            + Val.Val(DRDataStk["POLISH_DEPT_RR_CARAT"])
                                            + Val.Val(DRDataStk["STOCK3_WEIGHTLOSS"])
                                            + Val.Val(DRDataStk["STOCK4_WEIGHTLOSS"])
                                            - Val.Val(DRDataStk["QC_MINUS"])
                                            + Val.Val(DRDataStk["QC_PLUS"])
                                            )
                                            , 3);

                            DRNew["DIFF"] = DouDiff;
                            DTabStock.Rows.Add(DRNew);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BtnShow.Enabled = true;
                Global.Confirm(ex.Message);
            }
        }       

        private void RBtnStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBtnStatus.EditValue.ToString() == "REGULAR")
            {
                MainGridStock4.Dock = DockStyle.None;
                MainGridStock4.Visible = false;
                MainGridStock4.SendToBack();

                MainGridMIS.Dock = DockStyle.None;
                MainGridMIS.Visible = false;
                MainGridMIS.SendToBack();

                MainGridDet.Dock = DockStyle.Fill;
                MainGridDet.Visible = true;
                //BtnPrint.Visible = true;
                MainGridDet.BringToFront();
                GrpPanel.Text = "REGULAR ROUGH RUNNING POSSTION";
            }
            else if (RBtnStatus.EditValue.ToString() == "STOCK")
            {
                MainGridStock4.Dock = DockStyle.Fill;
                MainGridStock4.Visible = true;
                MainGridStock4.BringToFront();

                MainGridMIS.Dock = DockStyle.None;
                MainGridMIS.Visible = false;
                MainGridMIS.SendToBack();

                MainGridDet.Dock = DockStyle.None;
                MainGridDet.Visible = false;
                MainGridDet.SendToBack();
                //BtnPrint.Visible = true;
                GrpPanel.Text = "STOCK ROUGH RUNNING POSSITION";
            }

            else if (RBtnStatus.EditValue.ToString() == "MIS")
            {
                MainGridMIS.Dock = DockStyle.Fill;
                MainGridMIS.Visible = true;
                MainGridMIS.BringToFront();

                MainGridStock4.Dock = DockStyle.None;
                MainGridStock4.Visible = false;
                MainGridStock4.SendToBack();

                MainGridDet.Dock = DockStyle.None;
                MainGridDet.Visible = false;
                MainGridDet.SendToBack();
                //BtnPrint.Visible = false;
                GrpPanel.Text = "MIS ROUGH RUNNING POSSITION";
            }
        }

        private void GrdDet_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                DouReadyCarat = 0;
                DouConsumeCarat = 0;
                DouPolish = 0;
                DouOrgCarat = 0;
            }
            else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {

                DouPolish = DouPolish + Val.Val(GrdDet.GetRowCellValue(e.RowHandle, "ISSUE_DEPT_STOCK_CARAT"))
                                      + Val.Val(GrdDet.GetRowCellValue(e.RowHandle, "MFG_OS_CARAT"))
                                      + Val.Val(GrdDet.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                DouOrgCarat = DouOrgCarat + Val.Val(GrdDet.GetRowCellValue(e.RowHandle, "ORG_CARAT"));

                DouReadyCarat = DouReadyCarat + Val.Val(GrdDet.GetRowCellValue(e.RowHandle, "POLISH_TOTAL_RECEIVE_CARAT"));
                DouConsumeCarat = DouConsumeCarat + Val.Val(GrdDet.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
            }

            else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("POLISH_CONSUME_PER") == 0)
                {
                    if (DouOrgCarat != 0)
                    {
                        e.TotalValue = Math.Round((DouPolish / DouOrgCarat) * 100, 3);
                    }
                }
                else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("POLISH_READY_PER") == 0)
                {
                    if (DouConsumeCarat != 0)
                    {
                        e.TotalValue = Math.Round((DouReadyCarat / DouConsumeCarat) * 100, 3);
                    }
                }
            }
        }

        private void GrdDetMIS_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                DouReadyCarat = 0;
                DouConsumeCarat = 0;
                DouPolish = 0;
                DouOrgCarat = 0;
            }
            else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {

                DouPolish = DouPolish + Val.Val(GrdDetMIS.GetRowCellValue(e.RowHandle, "ISSUE_DEPT_STOCK_CARAT"))
                                      + Val.Val(GrdDetMIS.GetRowCellValue(e.RowHandle, "MFG_OS_CARAT"))
                                      + Val.Val(GrdDetMIS.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
                DouOrgCarat = DouOrgCarat + Val.Val(GrdDetMIS.GetRowCellValue(e.RowHandle, "ORG_CARAT"));

                DouReadyCarat = DouReadyCarat + Val.Val(GrdDetMIS.GetRowCellValue(e.RowHandle, "POLISH_TOTAL_RECEIVE_CARAT"));
                DouConsumeCarat = DouConsumeCarat + Val.Val(GrdDetMIS.GetRowCellValue(e.RowHandle, "CONSUME_CARAT"));
            }

            else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("POLISH_CONSUME_PER") == 0)
                {
                    if (DouOrgCarat != 0)
                    {
                        e.TotalValue = Math.Round((DouPolish / DouOrgCarat) * 100, 3);
                    }
                }
                else if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo("POLISH_READY_PER") == 0)
                {
                    if (DouConsumeCarat != 0)
                    {
                        e.TotalValue = Math.Round((DouReadyCarat / DouConsumeCarat) * 100, 3);
                    }
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            Point ptLowerLeft = new Point(0, BtnExport.Height);
            ptLowerLeft = BtnExport.PointToScreen(ptLowerLeft);
            ContextMNExport.Show(ptLowerLeft.X, ptLowerLeft.Y);
        }

        #region Opertation

        private void Export(string format, string dlgHeader, string dlgFilter)
        {

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridView GrdDetExport;

            if (RBtnStatus.EditValue.ToString() == "REGULAR")
            {
                GrdDetExport = GrdDet;
            }
            else if (RBtnStatus.EditValue.ToString() == "MIS")
            {
                GrdDetExport = GrdDet;
            }
            else
            {
                GrdDetExport = GrdDetStock;
            }


            GrdDetExport.OptionsPrint.ExpandAllDetails = true;
            //DevExpress.XtraGrid.Export.GridViewExportLink gvlink;
            try
            {
                SaveFileDialog svDialog = new SaveFileDialog();
                svDialog.DefaultExt = format;
                svDialog.Title = dlgHeader;
                svDialog.FileName = "Report";
                svDialog.Filter = dlgFilter;
                if ((svDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK))
                {
                    string Filepath = svDialog.FileName;
                    switch (format)
                    {
                        case "pdf":
                            GrdDetExport.ExportToPdf(Filepath);

                            break;
                        case "xls":
                            //GrdDet.ExportToXls(Filepath);


                           // gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GrdDetExport.CreateExportLink(new DevExpress.XtraExport.ExportXlsProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);

                            break;
                        case "xlsx":
                            //GrdDet.ExportToXlsx(Filepath);


                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GrdDetExport.CreateExportLink(new DevExpress.XtraExport.ExportXlsxProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);

                            break;
                        case "rtf":
                            GrdDet.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            GrdDetExport.ExportToText(Filepath);
                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GrdDetExport.CreateExportLink(new DevExpress.XtraExport.ExportTxtProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);
                            break;
                        case "html":
                            GrdDetExport.ExportToHtml(Filepath);
                            //gvlink = (DevExpress.XtraGrid.Export.GridViewExportLink)GrdDetExport.CreateExportLink(new DevExpress.XtraExport.ExportHtmlProvider(Filepath));

                            //gvlink.ExportAll = true;

                            //gvlink.ExpandAll = true;

                            //gvlink.ExportDetails = true;

                            //gvlink.ExportTo(true);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Confirm(ex.Message.ToString(), "Error in Export");
            }
        }

        #endregion

        #region Context Menu Events

        private void MNExportToExcel_Click(object sender, EventArgs e)
        {
            Export("xls", "Export to Excel", "Excel files 97-2003 (*.xls)|*.xls|Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }

        private void MNExportToText_Click(object sender, EventArgs e)
        {
            Export("txt", "Export to Text", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
        }

        private void MNExportToHTML_Click(object sender, EventArgs e)
        {
            Export("html", "Export to HTML", "Html files (*.html)|*.html|Htm files (*.htm)|*.htm");
        }

        private void MNExportToRTF_Click(object sender, EventArgs e)
        {
            Export("rtf", "Export to RTF", "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*");
        }

        private void MNExportToPDF_Click(object sender, EventArgs e)
        {
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }

        private void MNExportCSV_Click(object sender, EventArgs e)
        {
            Export("csv", "Export Report to CSVB", "csv (*.csv)|*.csv");
        }

        #endregion
    }
}
