using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Transaction;
using MARGO.Class;
using MARGO.Search;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmOutSideReceipt : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        ClvMixDeptIssRet ObjMix = new ClvMixDeptIssRet();
        DepartmentMaster objDepartment = new DepartmentMaster();
        FactoryReceive ObjFactory = new FactoryReceive();
        PacketMaster ObjPacket = new PacketMaster();
        SieveMaster objSieve = new SieveMaster();
        ClarityMaster objClarity = new ClarityMaster();
        string mStrProcessPrefix = "";
        System.Data.DataTable DTabExpPerDiff = new System.Data.DataTable();

        public FrmOutSideReceipt()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            Val.frmGenSet(this);
            AttachFormEvents();
            this.Show();

            DTabExpPerDiff.Columns.Add(new DataColumn("BARCODE", typeof(string)));
            DTabExpPerDiff.Columns.Add(new DataColumn("ISSUE_PCS", typeof(int)));
            DTabExpPerDiff.Columns.Add(new DataColumn("ISSUE_CARAT", typeof(double)));
            DTabExpPerDiff.Columns.Add(new DataColumn("READY_CARAT", typeof(double)));
            DTabExpPerDiff.Columns.Add(new DataColumn("CONSUME_CARAT", typeof(double)));
            DTabExpPerDiff.Columns.Add(new DataColumn("EXP_PER", typeof(double)));
            DTabExpPerDiff.Columns.Add(new DataColumn("REC_PER", typeof(double)));
            DTabExpPerDiff.Columns.Add(new DataColumn("MSG", typeof(string)));
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
            DTPFReceiptDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            LookupFromParty.Focus();
            LookupFromParty.EditValue = null;
            LookupToParty.EditValue = null;
            dgvOutSideReceipt.DataSource = null;
            PanelShow.Enabled = true;
            panelControl6.Enabled = false;
            PanelGrid.Enabled = false;

            LookupFromDept.EditValue = null;
            LookupToProcess.EditValue = null;
            LookupFromProcess.EditValue = null;
            LookupFromDept.EditValue = null;

            LookupFromDept.EditValue = null;
            LookupFromDept.EditValue = null;
        }

        #region Validation

        private Boolean ValSave()
        {
            ((DataTable)dgvOutSideReceipt.DataSource).AcceptChanges();
            for (int i = 0; i < GrdOutSideReceipt.RowCount; i++)
            {
                if (Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) == "" || Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_CARAT")) == 0)
                {
                    continue;
                }

                //if (dgvPolishReceive.CurrentRow.Index != DRow.Index && Val.ToString(GrdOutSideReceipt.GetRowCellValue(i,"BARCODE")) == txtGridValue.Text)
                //{
                //    Global.confirm("This Barcode Is Already Entered in Previous Record .. Please Check");
                //    txtGridValue.Focus();
                //    return false;
                //}


                if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_CARAT")) == 0)
                {
                    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Issue Carat Is Required.. Please Check");
                    GrdOutSideReceipt.FocusedRowHandle = (i);
                    GrdOutSideReceipt.FocusedColumn = (ColIssueCarat);
                    GrdOutSideReceipt.ShowEditor();
                    return false;
                }

                if (
                     Math.Round((Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "CONSUME_CARAT"))
                    + Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "RR_CARAT"))
                    + Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "SAW_CARAT"))
                    + Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "LOSS_CARAT"))
                    + Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "LOST_CARAT"))), 3)
                     != Math.Round(Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_CARAT")), 3)
                    )
                {
                    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " HAS " + LookupToProcess.Text + " ISSUE CARAT IS MISMATCH WITH POLISH CARAT\n\nYOUR BARCODE IS NOT SAVE");
                    GrdOutSideReceipt.FocusedRowHandle = (i);
                    GrdOutSideReceipt.FocusedColumn = (ColIssueCarat);
                    GrdOutSideReceipt.ShowEditor();
                    return false;
                }

                if (
                          (
                            Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "CONSUME_PCS")) +
                            Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "RR_PCS")) +
                            Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "LOST_PCS")) +
                            Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "SAW_PCS")) +
                            Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "LOSS_PCS")) +
                            Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "CANCEL_PCS"))
                          )

                          != Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_PCS"))
               )
                {
                    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " HAS RETURN PCS ARE MORE THEN PREVIOUS PROCESS PCS\n\n YOUR BARCODE IS NOT SAVE");
                    return false;
                }

                if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "READY_CARAT")) > Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_CARAT")))
                {
                    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Ready Carat Is Greater Than Issue");
                    GrdOutSideReceipt.FocusedRowHandle = (i);
                    GrdOutSideReceipt.FocusedColumn = (ColRdyCrts);
                    GrdOutSideReceipt.ShowEditor();
                    return false;
                }
                if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "RR_CARAT")) > Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_CARAT")))
                {
                    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " RR Carat Is Greater Than Issue");
                    GrdOutSideReceipt.FocusedRowHandle = (i);
                    GrdOutSideReceipt.FocusedColumn = (ColRRCrts);
                    GrdOutSideReceipt.ShowEditor();
                    return false;
                }
                if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "CONSUME_CARAT")) > Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_CARAT")))
                {
                    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Consume Carat Is Greater Than Issue");
                    GrdOutSideReceipt.FocusedRowHandle = (i);
                    GrdOutSideReceipt.FocusedColumn = (ColIssueCarat);
                    GrdOutSideReceipt.ShowEditor();
                    return false;
                }

                //if (ProcessMasterProperty.Is_Manufacturing == 1)
                //{
                //    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i,"READY_PCS")) > Val.Val(GrdOutSideReceipt.GetRowCellValue(i,"CONSUME_PCS")))
                //    {
                //        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i,"BARCODE")) + " Ready Pcs Is Greater Than Consume");
                //        txtGridValue.Focus();
                //        return false;
                //    }
                //}

                if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "CONSUME_PCS")) > Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_PCS")))
                {
                    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Consume Pcs Is Greater Than Issue");
                    GrdOutSideReceipt.FocusedRowHandle = (i);
                    GrdOutSideReceipt.FocusedColumn = (ColIssuePCs);
                    GrdOutSideReceipt.ShowEditor();
                    return false;
                }

                if (Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "CONSUME_PCS")) != Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "READY_PCS")))
                {
                    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Ready Pcs Is Not Equal To Consume Pcs");
                    GrdOutSideReceipt.FocusedRowHandle = (i);
                    GrdOutSideReceipt.FocusedColumn = (ColRdyPcs);
                    GrdOutSideReceipt.ShowEditor();
                    return false;
                }
                // 
                if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "READY_CARAT")) > Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "CONSUME_CARAT")))
                {
                    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Ready Carat cannot greater than Consume Carat");
                    GrdOutSideReceipt.FocusedRowHandle = (i);
                    GrdOutSideReceipt.FocusedColumn = (ColRdyCrts);
                    GrdOutSideReceipt.ShowEditor();
                    return false;
                }
                //====sagar
                if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_PCS")) != 0)
                {
                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "READY_PCS")) > Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_PCS")))
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Ready Pcs Is Greater Than Issue");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColIssuePCs);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }
                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "RR_PCS")) > Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "ISSUE_PCS")))
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " RR Pcs Is Greater Than Issue");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColRRPcs);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "READY_CARAT")) == 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "READY_PCS")) != 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Ready Carat Is Required If Ready Pcs Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColRdyCrts);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "READY_CARAT")) != 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "READY_PCS")) == 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Ready Pcs Is Required If Ready Carat Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColRdyPcs);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "RR_CARAT")) == 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "RR_PCS")) != 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " RR Carat Is Required If RR Pcs Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColRRCrts);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "RR_CARAT")) != 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "RR_PCS")) == 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " RR Pcs Is Required If RR Carat Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColRRPcs);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "CONSUME_CARAT")) == 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "CONSUME_PCS")) != 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Consume Carat Is Required If Consume Pcs Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColConsumCrts);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "CONSUME_CARAT")) != 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "CONSUME_PCS")) == 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Consume Pcs Is Required If Consume Carat Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColConsumPcs);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }
                    //============================

                    //if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "LOSS_CARAT")) == 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "LOSS_PCS")) != 0)
                    //{
                    //    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " LOSS Carat Is Required If LOSS Pcs Is There");
                    //    GrdOutSideReceipt.FocusedRowHandle = (i);
                    //    GrdOutSideReceipt.FocusedColumn = (ColLossCrts);
                    //    GrdOutSideReceipt.ShowEditor();
                    //    return false;
                    //}

                    //if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "LOSS_CARAT")) != 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "LOSS_PCS")) == 0)
                    //{
                    //    Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " LOSS Pcs Is Required If LOSS Carat Is There");
                    //    GrdOutSideReceipt.FocusedRowHandle = (i);
                    //    GrdOutSideReceipt.FocusedColumn = (ColLossPcs);
                    //    GrdOutSideReceipt.ShowEditor();
                    //    return false;
                    //}

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "LOST_CARAT")) == 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "LOST_PCS")) != 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " LOST Carat Is Required If LOST Pcs Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColLostCrts);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "LOST_CARAT")) != 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "LOST_PCS")) == 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " LOST Pcs Is Required If LOST Carat Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColLostPcs);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "CANCEL_CARAT")) == 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "CANCEL_PCS")) != 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " CANCEL Carat Is Required If CANCEL Pcs Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColCancelCrts);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "CANCEL_CARAT")) != 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "CANCEL_PCS")) == 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " CANCEL Pcs Is Required If CANCEL Carat Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColCancelPcs);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }
                    //========================================
                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "SAW_CARAT")) == 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "SAW_PCS")) != 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Saw Carat Is Required If Saw Pcs Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColSawCrts);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }

                    if (Val.Val(GrdOutSideReceipt.GetRowCellValue(i, "SAW_CARAT")) != 0 && Val.ToInt(GrdOutSideReceipt.GetRowCellValue(i, "SAW_PCS")) == 0)
                    {
                        Global.Confirm("BARCODE :" + Val.ToString(GrdOutSideReceipt.GetRowCellValue(i, "BARCODE")) + " Saw Pcs Is Required If Saw Carat Is There");
                        GrdOutSideReceipt.FocusedRowHandle = (i);
                        GrdOutSideReceipt.FocusedColumn = (ColSawPcs);
                        GrdOutSideReceipt.ShowEditor();
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        private void LookupFromProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPProcess(LookupFromParty);
            }
        }

        private void LookupToProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPProcess(LookupToParty);
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
            }
        }

        private void LookupToDept_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmDepartmentMaster frmCnt = new FrmDepartmentMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPDepartment(LookupToDept);
            }
        }

        private void LookupFromProcess_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPProcess(LookupFromProcess);
            }
        }

        private void LookupToProcess_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPProcess(LookupToProcess);
            }
        }

        private void GetSummary()
        {
            //int IntTotPcs = 0, IntTotLot = 0;
            //double DouTotCarat = 0;
            //System.Data.DataTable DTab = (System.Data.DataTable)dgvOutSideReceipt.DataSource;

            //if (DTab != null)
            //{
            //    if (DTab.Rows.Count > 0)
            //    {
            //        foreach (DataRow DRow in DTab.Rows)
            //        {
            //            IntTotLot = IntTotLot + 1;
            //            IntTotPcs = IntTotPcs + Val.ToInt(DRow["ISSUE_PCS"]);
            //            DouTotCarat = DouTotCarat + Val.Val(DRow["ISSUE_CARAT"]);
            //        }
            //    }
            //}

            //txtTotLot.Text = IntTotLot.ToString();
            //txtTotPcs.Text = IntTotPcs.ToString();
            //txtTotCarat.Text = DouTotCarat.ToString();
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
            //if (Convert.ToString(LookupRoughName.EditValue) == "")
            //{
            //    Global.Confirm("Rough Name is required");
            //    LookupRoughName.Focus();
            //    return false;
            //}
            if (Convert.ToString(DTPFReceiptDate.EditValue) == "")
            {
                Global.Confirm("Date is required");
                DTPFReceiptDate.Focus();
                return false;
            }
            return true;
        }

        private void BtnDeptShow_Click(object sender, EventArgs e)
        {
            try
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
                pClsProperty.Entry_Date = DTPFReceiptDate.Text;
                pClsProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
                pClsProperty.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);
                pClsProperty.Barcode = "0";
                pClsProperty.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
                pClsProperty.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
                System.Data.DataTable DTabIssueDate = ObjMix.GetReceiptFromOutSideBarcodeDetail(pClsProperty);
                dgvOutSideReceipt.DataSource = DTabIssueDate;

            }
            catch (Exception Ex)
            {
                Global.Confirm(Ex.Message);
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

        private void LookUpRepRoughType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmShapeMaster frmCnt = new FrmShapeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPRoughTypeRep(LookUpRepRoughType);
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

        private void LookUpRepShape_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmShapeMaster frmCnt = new FrmShapeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPShapeRep(LookUpRepShape);
            }
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

        private void LookupFromParty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmPartyMaster frmCnt = new FrmPartyMaster();
                frmCnt.ShowDialog();
                Party_MasterProperty Party = new Party_MasterProperty();
                Party.Party_Type = "Labour";
                Global.LOOKUPParty(LookupFromParty, Party);
                Party = null;
                Party = new Party_MasterProperty();
                Party.Party_Type = "Self";
                Global.LOOKUPParty(LookupToParty, Party);
                Party = null;
            }
        }

        private void LookupToParty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmPartyMaster frmCnt = new FrmPartyMaster();
                frmCnt.ShowDialog();
                Party_MasterProperty Party = new Party_MasterProperty();
                Party.Party_Type = "Labour";
                Global.LOOKUPParty(LookupFromParty, Party);
                Party = null;
                Party = new Party_MasterProperty();
                Party.Party_Type = "Self";
                Global.LOOKUPParty(LookupToParty, Party);
                Party = null;
            }
        }

        private void dgvOutSideReceipt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (Global.Confirm("Are you sure delete selected row in Employee Receive Entry?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    GrdOutSideReceipt.DeleteRow(GrdOutSideReceipt.GetRowHandle(GrdOutSideReceipt.FocusedRowHandle));
                }
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (ValSave() == false)
            {
                return;
            }

            if (Val.ToInt(ColBarcode.SummaryText) == 0)
            {
                Global.Confirm("No Lot Found For Save");
                LookupFromParty.Focus();
                return;
            }

            if (Global.Confirm("Are You Sure To Receive Goods?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
            Labour_Rate_MasterProperty LabProperty = new Labour_Rate_MasterProperty();

            int IntRes = 0;

            this.Cursor = Cursors.WaitCursor;

            // Find Labour Rate Validation

            System.Data.DataTable DTab_New = (System.Data.DataTable)dgvOutSideReceipt.DataSource;
            try { DTab_New.AcceptChanges(); }
            catch (Exception) { }

            Process_MasterProperty ProcessMasterProperty = new ProcessMaster().GetDataByPK(Val.ToInt64(LookupFromProcess.EditValue));
            //mIntIsOpenIssueToOutSide = ProcessMasterProperty.IS_Open_Issue_To_OutSide;
            mStrProcessPrefix = ProcessMasterProperty.Janged_Prefix;

            if (ProcessMasterProperty.Is_Labour_Rate_Calculate == 1)
            {

                foreach (DataRow Drow in DTab_New.Rows)
                {
                    if (Val.ToString(Drow["BARCODE"]) == "")
                    {
                        continue;
                    }
                    if (Val.Val(Drow["CONSUME_CARAT"]) == 0)
                    {
                        continue;
                    }

                    Property = new Mix_IssRet_MasterProperty();

                    Property.Barcode = Val.ToString(Drow["BARCODE"]);
                    Property.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);

                    Property.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
                    Property.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);

                    Property.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
                    //Property.From_Party_Location_Code = mIntFromPartyLocationCode;
                    //Property.From_Sub_Party_Code = Val.ToInt64(LookupFromParty.EditValue);

                    Property.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
                    //Property.To_Party_Location_Code = mIntToPartyLocationCode;
                    //Property.To_Sub_Party_Code = Val.ToInt(LookupToParty.EditValue);

                    Property.Consume_Pcs = Val.Val(Drow["CONSUME_PCS"]);
                    Property.Consume_Carat = Val.Val(Drow["CONSUME_CARAT"]);

                    Property.Rough_Type_Code = Val.ToInt64(Drow["ROUGH_TYPE_CODE"]);
                    Property.Sieve_Code = Val.ToInt64(Drow["SIEVE_CODE"]);
                    Property.Color_Code = Val.ToInt64(Drow["COLOR_CODE"]);
                    Property.Shape_Code = Val.ToInt64(Drow["SHAPE_CODE"]);
                    Property.MFG_Clarity_Code = Val.ToInt64(Drow["MFG_CLARITY_CODE"]);
                    Property.CLV_CLARITY_CODE = Val.ToInt64(Drow["CLV_CLARITY_CODE"]);

                    Property.Entry_Date = Val.DBDate(DTPFReceiptDate.Text);

                    LabProperty = new LabourRateMaster().GetLabourRate(
                                               Property.Rough_Name,
                                               Val.ToInt64(LookupFromParty.EditValue),
                                               Val.ToInt64(LookupFromProcess.EditValue),
                                               Property.Consume_Pcs,
                                               Property.Consume_Carat,
                                               Property.Sieve_Code,
                                               Property.MFG_Clarity_Code,
                                               Property.Shape_Code,
                                               Property.Entry_Date
                                               );

                    if (LabProperty == null)
                    {
                        this.Cursor = Cursors.Default;
                        Global.Confirm(Property.Barcode + " : Labour Rate Is Not Found.. Please Check");
                        return;
                    }
                    else
                    {
                        Drow["LABOUR_CODE"] = LabProperty.Labour_Code;
                        Drow["LABOUR_TYPE"] = LabProperty.Labour_Type;
                        Drow["LABOUR_CRITERIA"] = LabProperty.Criteria;
                        Drow["LABOUR_RATE"] = LabProperty.Rate;
                        Drow["LABOUR_AMOUNT"] = LabProperty.Amount;
                    }
                }
            }
            try
            {
                DTab_New.AcceptChanges();
            }
            catch (Exception) { }
            string FinYear = "";


            if (ProcessMasterProperty.Is_Manufacturing == 0)
            {
                if (Val.Val(txtNewJangedNo.Text) == 0)
                {
                    txtNewJangedNo.Text = new BLL.FunctionClasses.Entry.MaximumID().GenerateClvJangedNo(Val.DBDate(DTPFReceiptDate.Text)).ToString();
                }
                if (Val.Val(txtNewJangedNo.Text) == 0)
                {
                    Global.Confirm("Janged Number Not Created Please Check");
                    return;
                }
                // Add BY Vipul 22/05/2016

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
                    Property.Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
                    Property.Janged_No = Val.ToInt64(txtNewJangedNo.Text);
                    Property.SrNo = Val.ToInt64(Drow["SRNO"]);
                    Property.Barcode = Val.ToString(Drow["BARCODE"]);
                    Property.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);

                    Property.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
                    Property.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);

                    Property.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
                    //Property.From_Party_Location_Code = mIntFromPartyLocationCode;
                    //Property.From_Sub_Party_Code = Val.ToInt64(LookupFromParty.EditValue);

                    Property.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
                    //Property.To_Party_Location_Code = mIntToPartyLocationCode;
                    //Property.To_Sub_Party_Code = Val.ToInt64(LookupToParty.EditValue);

                    Property.Issue_Pcs = Val.Val(Drow["ISSUE_PCS"]);
                    Property.Issue_Carat = Val.Val(Drow["ISSUE_CARAT"]);

                    Property.Receive_Pcs = Val.Val(Drow["ISSUE_PCS"]);
                    Property.Receive_Carat = Val.Val(Drow["ISSUE_CARAT"]);

                    Property.RR_Pcs = Val.Val(Drow["RR_PCS"]);
                    Property.RR_Carat = Val.Val(Drow["RR_CARAT"]);

                    Property.Consume_Pcs = Val.Val(Drow["CONSUME_PCS"]);
                    Property.Consume_Carat = Val.Val(Drow["CONSUME_CARAT"]);

                    Property.Loss_Pcs = Val.Val(Drow["LOSS_PCS"]);
                    Property.Loss_Carat = Val.Val(Drow["LOSS_CARAT"]);

                    Property.Lost_Pcs = Val.Val(Drow["LOST_PCS"]);
                    Property.Lost_Carat = Val.Val(Drow["LOST_CARAT"]);

                    Property.Cancel_Pcs = Val.Val(Drow["CANCEL_PCS"]);
                    Property.Cancel_Carat = Val.Val(Drow["CANCEL_CARAT"]);

                    Property.Saw_Pcs = Val.Val(Drow["SAW_PCS"]);
                    Property.Saw_Carat = Val.Val(Drow["SAW_CARAT"]);

                    Property.Rough_Type_Code = Val.ToInt64(Drow["ROUGH_TYPE_CODE"]);
                    Property.Sieve_Code = Val.ToInt64(Drow["SIEVE_CODE"]);
                    Property.Color_Code = Val.ToInt64(Drow["COLOR_CODE"]);
                    Property.Shape_Code = Val.ToInt64(Drow["SHAPE_CODE"]);
                    Property.MFG_Clarity_Code = Val.ToInt64(Drow["MFG_CLARITY_CODE"]);
                    Property.CLV_CLARITY_CODE = Val.ToInt64(Drow["CLV_CLARITY_CODE"]);
                    Property.EXP_PER = Val.Val(Drow["EXP_PER"]);

                    Property.Entry_Date = Val.DBDate(DTPFReceiptDate.Text);
                    //Property.Entry_Time = Val.GetFullTime12();
                    Property.Issue_Empoloyee_Code = BLL.GlobalDec.gEmployeeProperty.Employee_Code;
                    Property.Issue_Computer_IP = BLL.GlobalDec.gStrComputerIP;

                    Property.Receive_Date = Val.DBDate(DTPFReceiptDate.Text);
                    //Property.Receive_Time = Val.GetFullTime12();
                    Property.Receive_Empoloyee_Code = BLL.GlobalDec.gEmployeeProperty.Employee_Code;
                    Property.Receive_Computer_IP = BLL.GlobalDec.gStrComputerIP;

                    Property.Return_Janged_No = Val.ToString(Drow["RETURN_JANGED_NO"]);

                    // Property.Labour_Code = Val.ToInt64(LabProperty.Labour_Code);
                    // Property.Labour_Type = Val.ToString(LabProperty.Labour_Type);
                    // Property.Labour_Criteria = Val.ToString(LabProperty.Criteria);
                    // Property.Labour_Rate = Val.Val(LabProperty.Rate);
                    // Property.Labour_Amount = Val.Val(LabProperty.Amount);
                    Property.Labour_Code = Val.ToInt64(Drow["LABOUR_CODE"]);
                    Property.Labour_Type = Val.ToString(Drow["LABOUR_TYPE"]);
                    Property.Labour_Criteria = Val.ToString(Drow["LABOUR_CRITERIA"]);
                    Property.Labour_Rate = Val.Val(Drow["LABOUR_RATE"]);
                    Property.Labour_Amount = Val.Val(Drow["LABOUR_AMOUNT"]);

                    if (txtReceiveJangedNo.Text.Length == 0)
                    {
                        FinYear = Global.GetFinancialYear(DTPFReceiptDate.Text);
                        txtReceiveJangedNo.Text = ObjMix.FindNew_ReceiveDept_JangedNo(mStrProcessPrefix, FinYear);
                    }
                    if (txtReceiveJangedNo.Text.Length == 0)
                    {
                        this.Cursor = Cursors.Default;
                        Global.Confirm("Department Janged No Not Created,, So Please Check");
                        return;
                    }

                    Property.Receive_Janged_No = Val.ToString(txtReceiveJangedNo.Text);
                    Property.SrNo = 0;
                    Property.SFLG = 1;

                    //string StrResult = ObjMix.ValSaveDeptIssue(Property);

                    //if (StrResult != "")
                    //{
                    //   // txtReceiveJangedNo.Text = "";
                    //    //this.Cursor = Cursors.Default;
                    //    Global.Confirm(StrResult);
                    //    return;
                    //}

                    Property = ObjMix.SaveDepartmentIssueNew(Property);

                    Drow["JANGED_DATE"] = DTPFReceiptDate.Text;
                    Drow["JANGED_NO"] = Property.Janged_No;
                    Drow["SRNO"] = Property.SrNo;

                    Property.Trn_ID = Val.ToInt64(Drow["TRN_ID"]);
                    Property.Type = "R";
                    Property.Financial_Year = FinYear;
                    Property.Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
                    Property.Bill_Of_Entry_No = Val.ToString(txtReceiveJangedNo.Text);

                    Property.Issue_Pcs = Val.Val(Drow["ISSUE_PCS"]);
                    Property.Issue_Carat = Val.Val(Drow["ISSUE_CARAT"]);

                    Property.Receive_Pcs = Val.Val(Drow["READY_PCS"]);
                    Property.Receive_Carat = Val.Val(Drow["READY_CARAT"]);

                    Property.RR_Pcs = Val.Val(Drow["RR_PCS"]);
                    Property.RR_Carat = Val.Val(Drow["RR_CARAT"]);

                    Property.Consume_Pcs = Val.Val(Drow["CONSUME_PCS"]);
                    Property.Consume_Carat = Val.Val(Drow["CONSUME_CARAT"]);

                    // Un Comment By Vipul
                    Property.Receipt_Date = Val.DBDate(DTPFReceiptDate.Text);
                    //Property.Receipt_Time = Val.GetFullTime12();

                    // Save To Another Table In Which Issue Receipt Details Are Saved

                    IntRes = ObjMix.SaveIssRetJangedDetail(Property);

                    if (Property == null)
                    {
                        this.Cursor = Cursors.Default;
                        Property = null;
                        Global.Confirm("Error in Save Record .. Please Check");
                    }
                    else
                    {
                        txtNewJangedNo.Text = Property.Janged_No.ToString();
                    }

                    Property = null;
                }
                Department_Process_SettingProperty DepartmentProperty = objDepartment.GetDepartmentSettings(Val.ToInt64(LookupFromDept.EditValue), Val.ToInt64(LookupFromProcess.EditValue));

                if (DepartmentProperty.Return_With_Barcode_Scrap == 1 && ProcessMasterProperty.IS_Open_Issue_To_OutSide == 1)
                {
                    foreach (DataRow Drow in DTab_New.Rows)
                    {
                        if (Val.ToString(Drow["BARCODE"]) == "")
                        {
                            continue;
                        }

                        Packet_MasterProperty PacketProperty = new Packet_MasterProperty();
                        PacketProperty.Barcode = Val.ToString(Drow["BARCODE"]);
                        PacketProperty.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);

                        ObjPacket.BarcodeMerge(PacketProperty);
                        PacketProperty = null;
                    }
                }

                DepartmentProperty = null;

                if (IntRes == -1)
                {
                    this.Cursor = Cursors.Default;
                    Global.Confirm("Error In Janged Receive");
                }
            }
            else // For Factory Receive
            {

                Int64 IntUnTouchProcesCode = Val.ToInt64(new ProcessMaster().GetUnTouchProcess());

                if (IntUnTouchProcesCode == 0)
                {
                    this.Cursor = Cursors.Default;
                    Global.Confirm("Please Set RR Process As Untouch=true In Process Master");
                    return;
                }

                if (Val.Val(txtNewJangedNo.Text) == 0)
                {
                    txtNewJangedNo.Text = new BLL.FunctionClasses.Entry.MaximumID().GenerateClvJangedNo(Val.DBDate(DTPFReceiptDate.Text)).ToString();
                }
                if (Val.Val(txtNewJangedNo.Text) == 0)
                {
                    Global.Confirm("Janged Number Not Created Please Check");
                    return;
                }

                System.Data.DataTable DTab_ManRec = (System.Data.DataTable)dgvOutSideReceipt.DataSource;
                try { DTab_ManRec.AcceptChanges(); }
                catch (Exception) { }

                foreach (DataRow Drow in DTab_ManRec.Rows)
                {
                    if (Val.ToString(Drow["BARCODE"]) == "")
                    {
                        continue;
                    }

                    if (Math.Round(Val.Val(Drow["READY_CARAT"]) + Val.Val(Drow["LOST_CARAT"]), 3) == 0)
                    {
                        continue;
                    }

                    Property = new Mix_IssRet_MasterProperty();

                    Property.From_Department_Code = Val.ToInt64(LookupFromDept.EditValue);
                    Property.To_Department_Code = Val.ToInt64(LookupToDept.EditValue);
                    Property.Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
                    Property.Janged_No = Val.ToInt64(txtNewJangedNo.Text);
                    Property.SrNo = Val.ToInt64(Drow["SRNO"]);
                    Property.Barcode = Val.ToString(Drow["BARCODE"]);
                    Property.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);

                    Property.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
                    Property.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);

                    Property.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
                    //Property.From_Party_Location_Code = mIntFromPartyLocationCode;
                    //Property.From_Sub_Party_Code = Val.ToInt(txtFromSubPartyShortName.Tag);

                    Property.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
                    //Property.To_Party_Location_Code = mIntToPartyLocationCode;
                    //Property.To_Sub_Party_Code = Val.ToInt(txtToSubPartyShortName.Tag);

                    //if (txtFromProcess.Text.Contains("REPAIRING"))
                    //{
                    //    // ADD BY VIPUL Becase In Reparing Process RR Is Also Consider As A POlish

                    //    Property.Issue_Pcs = Val.Val(Drow["READY_PCS"]) + Val.Val(Drow["RR_PCS"]);
                    //    Property.Issue_Carat = Val.Val(Drow["READY_CARAT"]) + Val.Val(Drow["RR_CARAT"]);

                    //    Property.Receive_Pcs = Val.Val(Drow["READY_PCS"]) + Val.Val(Drow["RR_PCS"]);
                    //    Property.Receive_Carat = Val.Val(Drow["READY_CARAT"]) + Val.Val(Drow["RR_CARAT"]);
                    //}
                    //else
                    //{
                    Property.Issue_Pcs = Val.Val(Drow["READY_PCS"]);
                    Property.Issue_Carat = Val.Val(Drow["READY_CARAT"]);

                    Property.Receive_Pcs = Val.Val(Drow["READY_PCS"]);
                    Property.Receive_Carat = Val.Val(Drow["READY_CARAT"]);
                    //}
                    Property.RR_Pcs = 0;
                    Property.RR_Carat = 0;

                    Property.Consume_Pcs = Val.Val(Drow["CONSUME_PCS"]);
                    Property.Consume_Carat = Val.Val(Drow["CONSUME_CARAT"]);
                    Property.EXP_PER = Val.Val(Drow["EXP_PER"]);

                    //if (txtFromProcess.Text.Contains("REPAIRING"))
                    //{
                    //    Property.Loss_Pcs = Val.Val(Drow["ISSUE_PCS"]) - Val.Val(Drow["RR_PCS"]) - Val.Val(Drow["READY_PCS"]);
                    //    Property.Loss_Carat = Val.Val(Drow["ISSUE_CARAT"]) - Val.Val(Drow["RR_CARAT"]) - Val.Val(Drow["READY_CARAT"]);

                    //}
                    //else
                    //{
                    Property.Loss_Pcs = 0;
                    Property.Loss_Carat = 0;
                    //}
                    Property.Lost_Pcs = 0;
                    Property.Lost_Carat = 0;

                    Property.Cancel_Pcs = 0;
                    Property.Cancel_Carat = 0.00;

                    Property.Saw_Pcs = 0;
                    Property.Saw_Carat = 0.00;

                    Property.Rough_Type_Code = Val.ToInt64(Drow["ROUGH_TYPE_CODE"]);
                    Property.Sieve_Code = Val.ToInt64(Drow["SIEVE_CODE"]);
                    Property.Color_Code = Val.ToInt64(Drow["COLOR_CODE"]);
                    Property.Shape_Code = Val.ToInt64(Drow["SHAPE_CODE"]);
                    Property.MFG_Clarity_Code = Val.ToInt64(Drow["MFG_CLARITY_CODE"]);
                    Property.CLV_CLARITY_CODE = Val.ToInt64(Drow["CLV_CLARITY_CODE"]);

                    Property.Entry_Date = Val.DBDate(DTPFReceiptDate.Text);
                    //Property.Entry_Time = Val.GetFullTime12();

                    Property.Issue_Empoloyee_Code = BLL.GlobalDec.gEmployeeProperty.Employee_Code;
                    Property.Issue_Computer_IP = BLL.GlobalDec.gStrComputerIP;

                    Property.Receive_Date = Val.DBDate(DTPFReceiptDate.Text);
                    //Property.Receive_Time = Val.GetFullTime12();
                    Property.Receive_Empoloyee_Code = BLL.GlobalDec.gEmployeeProperty.Employee_Code;
                    Property.Receive_Computer_IP = BLL.GlobalDec.gStrComputerIP;

                    Property.Return_Janged_No = Val.ToString(Drow["RETURN_JANGED_NO"]);

                    //Property.Labour_Code = Val.ToInt64(LabProperty.Labour_Code);
                    //Property.Labour_Type = Val.ToString(LabProperty.Labour_Type);
                    //Property.Labour_Criteria = Val.ToString(LabProperty.Criteria);
                    //Property.Labour_Rate = Val.Val(LabProperty.Rate);
                    //Property.Labour_Amount = Val.Val(LabProperty.Amount);

                    Property.Labour_Code = Val.ToInt64(Drow["LABOUR_CODE"]);
                    Property.Labour_Type = Val.ToString(Drow["LABOUR_TYPE"]);
                    Property.Labour_Criteria = Val.ToString(Drow["LABOUR_CRITERIA"]);
                    Property.Labour_Rate = Val.Val(Drow["LABOUR_RATE"]);
                    Property.Labour_Amount = Val.Val(Drow["LABOUR_AMOUNT"]);

                    if (txtReceiveJangedNo.Text.Length == 0)
                    {
                        FinYear = Global.GetFinancialYear(DTPFReceiptDate.Text);
                        txtReceiveJangedNo.Text = ObjMix.FindNew_ReceiveDept_JangedNo(mStrProcessPrefix, FinYear);
                    }
                    if (txtReceiveJangedNo.Text.Length == 0)
                    {
                        this.Cursor = Cursors.Default;
                        Global.Confirm("Department Janged No Not Created, So Please Check");
                        return;
                    }

                    Property.Receive_Janged_No = Val.ToString(txtReceiveJangedNo.Text);

                    Property.IS_Polish_RR_Flag = 0;
                    Property.SrNo = 0;
                    Property.SFLG = 1;

                    //string StrResult = ObjMix.ValSaveDeptIssue(Property);

                    //if (StrResult != "")
                    //{
                    //    txtReceiveJangedNo.Text = "";
                    //    this.Cursor = Cursors.Default;
                    //    Global.Message(StrResult);
                    //    return;
                    //}

                    Property = ObjMix.SaveDepartmentIssueNew(Property);

                    Drow["JANGED_DATE"] = DTPFReceiptDate.Text;
                    Drow["JANGED_NO"] = Property.Janged_No;
                    Drow["SRNO"] = Property.SrNo;

                    Property.Type = "R";
                    Property.Financial_Year = FinYear;
                    Property.Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
                    Property.Bill_Of_Entry_No = Val.ToString(txtReceiveJangedNo.Text);

                    Property.Issue_Pcs = Val.Val(Drow["ISSUE_PCS"]);
                    Property.Issue_Carat = Val.Val(Drow["ISSUE_CARAT"]);

                    // Un Comment By Vipul
                    Property.Receipt_Date = Val.DBDate(DTPFReceiptDate.Text);
                    //Property.Receipt_Time = Val.GetFullTime12();

                    Property.Receive_Pcs = Val.Val(Drow["READY_PCS"]);
                    Property.Receive_Carat = Val.Val(Drow["READY_CARAT"]);

                    Property.RR_Pcs = Val.Val(Drow["RR_PCS"]);
                    Property.RR_Carat = Val.Val(Drow["RR_CARAT"]);

                    Property.Consume_Pcs = Val.Val(Drow["CONSUME_PCS"]);
                    Property.Consume_Carat = Val.Val(Drow["CONSUME_CARAT"]);

                    //if (txtFromProcess.Text.Contains("REPAIRING"))
                    //{
                    //    Property.Loss_Pcs = Val.ToInt(Drow.Cells["ISSUE_PCS"].Value) - Val.ToInt(Drow.Cells["RR_PCS"].Value) - Val.ToInt(Drow.Cells["READY_PCS"].Value);
                    //    Property.Loss_Carat = Val.Val(Drow.Cells["ISSUE_CARAT"].Value) - Val.Val(Drow.Cells["RR_CARAT"].Value) - Val.Val(Drow.Cells["READY_CARAT"].Value);

                    //    Property.Consume_Pcs = Val.ToInt(Drow.Cells["READY_PCS"].Value);
                    //    Property.Consume_Carat = Val.Val(Drow.Cells["READY_CARAT"].Value);
                    //}
                    //else
                    //{
                    Property.Loss_Pcs = Val.Val(Drow["LOSS_PCS"]);
                    Property.Loss_Carat = Val.Val(Drow["LOSS_CARAT"]);
                    //}

                    Property.Lost_Pcs = Val.Val(Drow["LOST_PCS"]);
                    Property.Lost_Carat = Val.Val(Drow["LOST_CARAT"]);

                    Property.Cancel_Pcs = Val.Val(Drow["CANCEL_PCS"]);
                    Property.Cancel_Carat = Val.Val(Drow["CANCEL_CARAT"]);

                    Property.Saw_Pcs = Val.Val(Drow["SAW_PCS"]);
                    Property.Saw_Carat = Val.Val(Drow["SAW_CARAT"]);

                    //Property.Comp_Process_Code = Val.ToString(txtCompProcess.Tag);
                    // Save To Another Table In Which Issue Receipt Details Are Saved
                    Property.FACTORY_I_WT = Val.Val(Drow["FACTORY_I_WT"]);

                    IntRes = ObjMix.SaveIssRetJangedDetail(Property);

                    if (Property == null)
                    {
                        this.Cursor = Cursors.Default;
                        Property = null;
                        Global.Confirm("Error in Save Record .. Please Check");
                    }

                    else
                    {
                        txtNewJangedNo.Text = Property.Janged_No.ToString();

                        Packet_MasterProperty PacketMasterProperty = new Packet_MasterProperty();
                        PacketMasterProperty.Barcode = Val.ToString(Drow["BARCODE"]);
                        PacketMasterProperty.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);
                        PacketMasterProperty.Height = Val.ToDouble(Drow["HEIGHT"]);
                        PacketMasterProperty.Width = Val.ToDouble(Drow["WIDTH"]);
                        PacketMasterProperty.Max_Dia = Val.ToDouble(Drow["MAX_DIA"]);
                        PacketMasterProperty.Min_Dia = Val.ToDouble(Drow["MIN_DIA"]);
                        PacketMasterProperty.Depth = Val.ToDouble(Drow["DEPTH"]);
                        PacketMasterProperty.Proc_Exp_Per = Val.ToDouble(Drow["PROC_EXP_PER"]);
                        PacketMasterProperty.Proc_Exp_Carat = Val.ToDouble(Drow["PROC_EXP_CARAT"]);
                        PacketMasterProperty.Fac_WT_Per = Val.Val(Drow["FAC_WT_PER"]);
                        PacketMasterProperty.FACTORY_I_WT = Val.Val(Drow["FACTORY_I_WT"]);
                        PacketMasterProperty.PRODUCTION_STATUS = Val.ToString(Drow["PRODUCTION_STATUS"]);

                        ObjFactory.UpdatePacket(PacketMasterProperty);
                        PacketMasterProperty = null;
                    }

                    double DouRecPer = Math.Round((Val.Val(Drow["READY_CARAT"]) / Val.Val(Drow["CONSUME_CARAT"])) * 100, 2);
                    double DouExpPer = Math.Round(Val.Val(Drow["EXP_PER"]), 2);

                    if (DouExpPer - DouRecPer >= 10)
                    {
                        DataRow DRDiff = DTabExpPerDiff.NewRow();

                        DRDiff["BARCODE"] = Val.ToString(Drow["BARCODE"]);
                        DRDiff["ISSUE_PCS"] = Val.Val(Drow["ISSUE_PCS"]);
                        DRDiff["ISSUE_CARAT"] = Val.Val(Drow["ISSUE_CARAT"]);
                        DRDiff["READY_CARAT"] = Val.Val(Drow["READY_CARAT"]);
                        DRDiff["CONSUME_CARAT"] = Val.Val(Drow["CONSUME_CARAT"]);
                        DRDiff["EXP_PER"] = DouExpPer;
                        DRDiff["REC_PER"] = DouRecPer;
                        DRDiff["MSG"] = "Receive % Difference Occure Due To 10% Diff Of Issue Against Receipt ";
                        DTabExpPerDiff.Rows.Add(DRDiff);
                    }
                    Property = null;
                }

                txtNewJangedNo.Text = "";
                if (Val.Val(txtNewJangedNo.Text) == 0)
                {
                    txtNewJangedNo.Text = new BLL.FunctionClasses.Entry.MaximumID().GenerateClvJangedNo(Val.DBDate(DTPFReceiptDate.Text)).ToString();
                }
                if (Val.Val(txtNewJangedNo.Text) == 0)
                {
                    Global.Confirm("Janged Number Not Created Please Check");
                    return;
                }

                foreach (DataRow Drow in DTab_ManRec.Rows)
                {
                    if (Val.ToString(Drow["BARCODE"]) == "")
                    {
                        continue;
                    }

                    if (Val.Val(Drow["RR_CARAT"]) + Val.Val(Drow["SAW_CARAT"]) == 0)
                    {
                        continue;
                    }

                    Property = new Mix_IssRet_MasterProperty();

                    Property.From_Department_Code = Val.ToInt64(LookupFromDept.EditValue);
                    Property.To_Department_Code = Val.ToInt64(LookupToDept.EditValue);
                    Property.Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
                    Property.Janged_No = Val.ToInt64(txtNewJangedNo.Text);
                    Property.SrNo = Val.ToInt64(Drow["SRNO"]);
                    Property.Barcode = Val.ToString(Drow["BARCODE"]);
                    Property.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);

                    Property.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);

                    //if (txtFromProcess.Text.Contains("REPAIRING"))
                    //{
                    //    Property.To_Process_Code = Val.ToInt(txtToProcess.Tag);
                    //}
                    //else
                    //{
                    Property.To_Process_Code = IntUnTouchProcesCode;
                    //}

                    Property.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
                    //Property.From_Party_Location_Code = mIntFromPartyLocationCode;
                    //Property.From_Sub_Party_Code = Val.ToInt(txtFromSubPartyShortName.Tag);

                    Property.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
                    //Property.To_Party_Location_Code = mIntToPartyLocationCode;
                    //Property.To_Sub_Party_Code = Val.ToInt(txtToSubPartyShortName.Tag);

                    Property.Issue_Pcs = Val.Val(Drow["RR_PCS"]) + Val.Val(Drow["SAW_PCS"]);
                    Property.Issue_Carat = Math.Round(Val.Val(Drow["RR_CARAT"]) + Val.Val(Drow["SAW_CARAT"]), 3);

                    Property.Receive_Pcs = Val.Val(Drow["RR_PCS"]) + Val.Val(Drow["SAW_PCS"]);
                    Property.Receive_Carat = Math.Round(Val.Val(Drow["RR_CARAT"]) + Val.Val(Drow["SAW_CARAT"]), 3);

                    Property.RR_Pcs = 0;
                    Property.RR_Carat = 0;

                    Property.Consume_Pcs = Val.Val(Drow["RR_PCS"]) + Val.Val(Drow["SAW_PCS"]);
                    Property.Consume_Carat = Math.Round(Val.Val(Drow["RR_CARAT"]) + Val.Val(Drow["SAW_CARAT"]), 3);

                    //if (txtFromProcess.Text.Contains("REPAIRING") && Val.Val(Drow.Cells["READY_CARAT"].Value) == 0)
                    //{
                    //    Property.Loss_Pcs = Val.ToInt(Drow.Cells["ISSUE_PCS"].Value) - Val.ToInt(Drow.Cells["RR_PCS"].Value) - Val.ToInt(Drow.Cells["READY_PCS"].Value);
                    //    Property.Loss_Carat = Val.Val(Drow.Cells["ISSUE_CARAT"].Value) - Val.Val(Drow.Cells["RR_CARAT"].Value) - Val.Val(Drow.Cells["READY_CARAT"].Value);
                    //}
                    //else
                    //{
                    Property.Loss_Pcs = 0;
                    Property.Loss_Carat = 0;
                    //}

                    Property.Lost_Pcs = 0;
                    Property.Lost_Carat = 0;

                    Property.Cancel_Pcs = 0;
                    Property.Cancel_Carat = 0;

                    Property.Saw_Pcs = 0;
                    Property.Saw_Carat = 0;

                    Property.Rough_Type_Code = Val.ToInt64(Drow["ROUGH_TYPE_CODE"]);
                    Property.Sieve_Code = Val.ToInt64(Drow["SIEVE_CODE"]);
                    Property.Color_Code = Val.ToInt64(Drow["COLOR_CODE"]);
                    Property.Shape_Code = Val.ToInt64(Drow["SHAPE_CODE"]);
                    Property.MFG_Clarity_Code = Val.ToInt64(Drow["MFG_CLARITY_CODE"]);
                    Property.CLV_CLARITY_CODE = Val.ToInt64(Drow["CLV_CLARITY_CODE"]);

                    Property.Entry_Date = Val.DBDate(DTPFReceiptDate.Text);
                    //Property.Entry_Time = Val.GetFullTime12();

                    Property.Issue_Empoloyee_Code = BLL.GlobalDec.gEmployeeProperty.Employee_Code;
                    Property.Issue_Computer_IP = BLL.GlobalDec.gStrComputerIP;

                    Property.Receive_Date = Val.DBDate(DTPFReceiptDate.Text);
                    //Property.Receive_Time = Val.GetFullTime12();
                    Property.Receive_Empoloyee_Code = BLL.GlobalDec.gEmployeeProperty.Employee_Code;
                    Property.Receive_Computer_IP = BLL.GlobalDec.gStrComputerIP;


                    Property.Return_Janged_No = Val.ToString(Drow["RETURN_JANGED_NO"]);

                    if (txtReceiveJangedNo.Text.Length == 0)
                    {
                        FinYear = Global.GetFinancialYear(DTPFReceiptDate.Text);
                        txtReceiveJangedNo.Text = ObjMix.FindNew_ReceiveDept_JangedNo(mStrProcessPrefix, FinYear);
                    }
                    if (txtReceiveJangedNo.Text.Length == 0)
                    {
                        this.Cursor = Cursors.Default;
                        Global.Confirm("Department Janged No Not Created,, So Please Check");
                        return;
                    }

                    Property.Receive_Janged_No = Val.ToString(txtReceiveJangedNo.Text);

                    Property.SFLG = 1;
                    Property.SrNo = 0;
                    Property.IS_Polish_RR_Flag = 1;

                    //string StrResult = ObjMix.ValSaveDeptIssue(Property);
                    //if (StrResult != "")
                    //{
                    //    this.Cursor = Cursors.Default;
                    //    Global.Message(StrResult);
                    //    return;
                    //}

                    Property = ObjMix.SaveDepartmentIssueNew(Property);


                    if (Property == null)
                    {
                        Property = null;
                        Global.Confirm("Error in Save Record .. Please Check");
                    }
                    else
                    {
                        txtNewJangedNo.Text = Property.Janged_No.ToString();

                        if (Val.Val(Drow["CONSUME_CARAT"]) == 0)
                        {

                            // Save To Another Table In Which Issue Receipt Details Are Saved

                            Property.Type = "R";
                            Property.Financial_Year = FinYear;
                            Property.Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
                            Property.Bill_Of_Entry_No = Val.ToString(txtReceiveJangedNo.Text);


                            Property.Issue_Pcs = Val.Val(Drow["ISSUE_PCS"]);
                            Property.Issue_Carat = Val.Val(Drow["ISSUE_CARAT"]);

                            //Property.Issue_Pcs = Val.ToInt(Drow.Cells["RR_PCS"].Value) + Val.ToInt(Drow.Cells["SAW_PCS"].Value);
                            //Property.Issue_Carat = Math.Round(Val.Val(Drow.Cells["RR_CARAT"].Value) + Val.Val(Drow.Cells["SAW_CARAT"].Value), 3);

                            Property.Receive_Pcs = Val.Val(Drow["READY_PCS"]);
                            Property.Receive_Carat = Val.Val(Drow["READY_CARAT"]);

                            Property.RR_Pcs = Val.Val(Drow["RR_PCS"]);
                            Property.RR_Carat = Val.Val(Drow["RR_CARAT"]);

                            Property.Consume_Pcs = Val.Val(Drow["CONSUME_PCS"]);
                            Property.Consume_Carat = Val.Val(Drow["CONSUME_CARAT"]);

                            //if (txtFromProcess.Text.Contains("REPAIRING"))
                            //{
                            //    Property.Loss_Pcs = Val.ToInt(Drow.Cells["ISSUE_PCS"].Value) - Val.ToInt(Drow.Cells["RR_PCS"].Value) - Val.ToInt(Drow.Cells["READY_PCS"].Value);
                            //    Property.Loss_Carat = Val.Val(Drow.Cells["ISSUE_CARAT"].Value) - Val.Val(Drow.Cells["RR_CARAT"].Value) - Val.Val(Drow.Cells["READY_CARAT"].Value);
                            //}
                            //else
                            //{
                            Property.Loss_Pcs = Val.Val(Drow["LOSS_PCS"]);
                            Property.Loss_Carat = Val.Val(Drow["LOSS_CARAT"]);
                            //}

                            Property.Lost_Pcs = Val.Val(Drow["LOST_PCS"]);
                            Property.Lost_Carat = Val.Val(Drow["LOST_CARAT"]);

                            Property.Cancel_Pcs = Val.Val(Drow["CANCEL_PCS"]);
                            Property.Cancel_Carat = Val.Val(Drow["CANCEL_CARAT"]);

                            Property.Saw_Pcs = Val.Val(Drow["SAW_PCS"]);
                            Property.Saw_Carat = Val.Val(Drow["SAW_CARAT"]);

                            //Property.Comp_Process_Code = Val.ToString(txtCompProcess.Tag);

                            /*ADD BY HARESH ON 22-08-2014 FOR FACTORY I WEIGHT OF MDB FILE OF RECEIPT*/
                            Property.FACTORY_I_WT = Val.Val(Drow["FACTORY_I_WT"]);
                            /*-------*/

                            // Un Comment By Vipul
                            Property.Receipt_Date = Val.DBDate(DTPFReceiptDate.Text);
                            //Property.Receipt_Time = Val.GetFullTime12();

                            IntRes = ObjMix.SaveIssRetJangedDetail(Property);

                            // Update RR Janged To Iss Rec Janged
                            //Mix_IssRet_MasterProperty RRProperty = new Mix_IssRet_MasterProperty();


                            //RRProperty.Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
                            //RRProperty.Janged_No = Val.ToInt64(Drow["JANGED_NO"]);
                            //RRProperty.SrNo = Val.ToInt64(Drow["SRNO"]);

                            //RRProperty.RR_Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
                            //RRProperty.RR_Janged_No = Property.Janged_No;
                            //RRProperty.RR_SrNo = Property.SrNo;

                            //ObjMix.UpdateIssRetJangedRRDetail(RRProperty);
                            //RRProperty = null;

                            Packet_MasterProperty PacketMasterProperty = new Packet_MasterProperty();
                            PacketMasterProperty.Barcode = Val.ToString(Drow["BARCODE"]);
                            PacketMasterProperty.Rough_Name = Val.ToString(Drow["ROUGH_NAME"]);
                            PacketMasterProperty.Height = Val.ToDouble(Drow["HEIGHT"]);
                            PacketMasterProperty.Width = Val.ToDouble(Drow["WIDTH"]);
                            PacketMasterProperty.Max_Dia = Val.ToDouble(Drow["MAX_DIA"]);
                            PacketMasterProperty.Min_Dia = Val.ToDouble(Drow["MIN_DIA"]);
                            PacketMasterProperty.Depth = Val.ToDouble(Drow["DEPTH"]);
                            PacketMasterProperty.Proc_Exp_Per = Val.ToDouble(Drow["PROC_EXP_PER"]);
                            PacketMasterProperty.Proc_Exp_Carat = Val.ToDouble(Drow["PROC_EXP_CARAT"]);
                            PacketMasterProperty.Fac_WT_Per = Val.Val(Drow["FAC_WT_PER"]);
                            PacketMasterProperty.FACTORY_I_WT = Val.Val(Drow["FACTORY_I_WT"]);
                            PacketMasterProperty.PRODUCTION_STATUS = Val.ToString(Drow["PRODUCTION_STATUS"]);

                            ObjFactory.UpdatePacket(PacketMasterProperty);
                            PacketMasterProperty = null;
                        }
                        //else
                        //{
                        //    // Update RR Janged To Iss Rec Janged

                        //    Mix_IssRet_MasterProperty RRProperty = new Mix_IssRet_MasterProperty();

                        //    RRProperty.Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
                        //    RRProperty.Janged_No = Val.ToInt(Drow["JANGED_NO"]);
                        //    RRProperty.SrNo = Val.ToInt(Drow["SRNO"]);

                        //    RRProperty.RR_Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
                        //    RRProperty.RR_Janged_No = Property.Janged_No;
                        //    RRProperty.RR_SrNo = Property.SrNo;

                        //    ObjMix.UpdateIssRetJangedRRDetail(RRProperty);
                        //    RRProperty = null;
                        //}

                    }
                    Property = null;
                }

                if (ProcessMasterProperty.Is_Manufacturing == 1)
                {
                    //int IntTotalRec = dgvPolishReceive.Rows.Count;
                    //int Diff = dgvPolishReceive.Rows.Count;

                    //int IntI = 0;
                    //List<string> AL = new List<string>();

                    //foreach (DataGridViewRow Drow in dgvPolishReceive.Rows)
                    //{

                    //    if (Val.ToString(Drow.Cells["BARCODE"].Value) == "")
                    //    {
                    //        continue;
                    //    }

                    //    IntI++;
                    //    StrBarcode = StrBarcode + Val.ToString(Drow.Cells["BARCODE"].Value) + ",";
                    //    if (IntTotalRec >= 300)
                    //    {
                    //        if (IntI == 300)
                    //        {
                    //            Diff = Diff - IntI;
                    //            AL.Add(StrBarcode);
                    //            IntI = 0;
                    //            StrBarcode = "";
                    //        }
                    //        else if (Diff < 300 && IntI == Diff)
                    //        {
                    //            AL.Add(StrBarcode);
                    //        }
                    //    }
                    //}

                    //if (IntTotalRec < 300)
                    //{
                    //    AL.Add(StrBarcode);
                    //}
                    //System.Data.DataTable DTabLockCheck = new System.Data.DataTable();

                    //foreach (string StrBNew in AL)
                    //{
                    //    string Str = "";
                    //    if (StrBNew.Length != 0)
                    //    {
                    //        Str = StrBNew.Substring(0, StrBNew.Length - 1);
                    //    }
                    //    System.Data.DataTable DTab = ObjClvBarcode.CheckLock(Str);
                    //    DTabLockCheck.Merge(DTab);
                    //}
                    //if (DTabLockCheck.Rows.Count != 0)
                    //{
                    //    FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
                    //    FrmDevExpPopupGrid.DTab = DTabLockCheck;
                    //    FrmDevExpPopupGrid.DialogCloseOnEscape = false;
                    //    FrmDevExpPopupGrid.CountedColumn = "BARCODE";
                    //    FrmDevExpPopupGrid.MainGridDetail.DataSource = DTabLockCheck;
                    //    FrmDevExpPopupGrid.MainGridDetail.Refresh();
                    //    FrmDevExpPopupGrid.GrdDet.Columns["BARCODE"].Caption = "Barcode";
                    //    FrmDevExpPopupGrid.GrdDet.Columns["MSG"].Caption = "Lock Message";
                    //    FrmDevExpPopupGrid.ShowDialog();
                    //}

                    // Receive % Is Greater Than Issue
                    if (DTabExpPerDiff.Rows.Count != 0)
                    {
                        FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
                        FrmDevExpPopupGrid.DialogCloseOnEscape = false;
                        FrmDevExpPopupGrid.DTab = DTabExpPerDiff;
                        FrmDevExpPopupGrid.CountedColumn = "BARCODE";
                        FrmDevExpPopupGrid.MainGridDetail.DataSource = DTabExpPerDiff;
                        FrmDevExpPopupGrid.MainGridDetail.Refresh();
                        FrmDevExpPopupGrid.GrdDet.Columns["BARCODE"].Caption = "Barcode";
                        FrmDevExpPopupGrid.GrdDet.Columns["ISSUE_PCS"].Caption = "Issue Pcs";
                        FrmDevExpPopupGrid.GrdDet.Columns["ISSUE_CARAT"].Caption = "Issue Crt";
                        FrmDevExpPopupGrid.GrdDet.Columns["READY_CARAT"].Caption = "Ready Crt";
                        FrmDevExpPopupGrid.GrdDet.Columns["CONSUME_CARAT"].Caption = "Consume Crt";
                        FrmDevExpPopupGrid.GrdDet.Columns["EXP_PER"].Caption = "Iss %";
                        FrmDevExpPopupGrid.GrdDet.Columns["REC_PER"].Caption = "Rec %";
                        FrmDevExpPopupGrid.GrdDet.Columns["MSG"].Caption = "Message";
                        FrmDevExpPopupGrid.ShowDialog();
                    }
                }

            }

            //if (Global.Confirm("Successfully Transfer [" + Convert.ToString(ColBarcode.SummaryText) + " Lot] & [" + Convert.ToString(ColIssuePCs.SummaryText) + " Pcs] & [" + Convert.ToString(ColIssueCarat.SummaryText) + " Carats]" + " To " + LookupToDept.Text + " Department\n\nAre You Sure To Print Janged ?") == System.Windows.Forms.DialogResult.Yes)
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    Property = new Mix_IssRet_MasterProperty();
            //    Property.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);
            //    Property.To_Janged_Date = Val.DBDate(DTPFReceiptDate.Text);
            //    Property.Receive_Janged_No = txtReceiveJangedNo.Text;

            //    System.Data.DataTable DTab = new ClvMixDeptIssRet().GetReceiveJabgedForPrint(Property, "D");

            //    if (DTab == null || DTab.Rows.Count == 0)
            //    {
            //        this.Cursor = Cursors.Default;
            //        Global.Confirm("Janged Record Not Found");
            //        return;
            //    }

            //    FrmReportViewer FrmReportViewer = new Report.FrmReportViewer();
            //    FrmReportViewer.ShowForm(BLL.TPV.RPT.HO_Receive_Sum, DTab, 120, Report.FrmReportViewer.ReportFolder.JANGED);
            //    Property = null;

            //}

            Global.Confirm("Successfully Transfer [" + Convert.ToString(ColBarcode.SummaryText) + " Lot] & [" + Convert.ToString(ColIssuePCs.SummaryText) + " Pcs] & [" + Convert.ToString(ColIssueCarat.SummaryText) + " Carats]" + " To " + LookupToDept.Text + " Department\n\n");

            this.Cursor = Cursors.Default;

            dgvOutSideReceipt.DataSource = null;
            txtNewJangedNo.Text = "";
            txtReceiveJangedNo.Text = "";
            LookupFromParty.EditValue = null;
            LookupFromParty.Focus();
            PanelShow.Enabled = true;
            panelControl6.Enabled = false;
            PanelGrid.Enabled = false;
        }

        private void FrmOutSideReceipt_Shown(object sender, EventArgs e)
        {
            btnClear_Click(btnClear, null);
            LookupFromParty.Focus();
            DTPFReceiptDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            Global.LOOKUPDepartment(LookupFromDept);
            Global.LOOKUPDepartment(LookupToDept);
            Party_MasterProperty Party = new Party_MasterProperty();
            Party.Party_Type = "Labour";
            Global.LOOKUPParty(LookupFromParty, Party);
            Party = null;
            Party = new Party_MasterProperty();
            Party.Party_Type = "Self";
            Global.LOOKUPParty(LookupToParty, Party);
            Party = null;

            Global.LOOKUPProcess(LookupFromProcess);
            Global.LOOKUPProcess(LookupToProcess);
            Global.LOOKUPRough(LookupRoughName);

            Global.LOOKUPRoughRep(LookUpRepRough);
            Global.LOOKUPShapeRep(LookUpRepShape);
            Global.LOOKUPColorRep(LookUpRepColor);
            Global.LOOKUPRoughTypeRep(LookUpRepRoughType);
            Global.LOOKUPSieveRep(repositoryItemLookUpEdit1);
            Global.LOOKUPClarityRep(LookUpClarity);
            Global.LOOKUPClarityRep(LookUpRepClvCla, "Clv");
            Global.LOOKUPClarityRep(LookUpMfgCla, "Mfg");
            Global.LOOKUPRoughRep(LookUpRepRough);
        }

        private static Mix_IssRet_MasterProperty GetPClsProperty()
        {
            Mix_IssRet_MasterProperty pClsProperty = new Mix_IssRet_MasterProperty();
            return pClsProperty;
        }

        private bool ValDuplicate(string Barcode_)
        {
            bool flag = true;
            for (int i = 0; i < GrdOutSideReceipt.RowCount; i++)
            {
                if (GrdOutSideReceipt.GetRowCellValue(i, ColBarcode) != null)
                {
                    if (GrdOutSideReceipt.GetRowCellValue(i, ColBarcode).ToString() == Barcode_)
                    {
                        return false;
                    }
                    flag = true;
                }
            }
            return flag;
        }

        private void GrdOutSideReceipt_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (GrdOutSideReceipt.FocusedColumn == ColBarcode)
            {

                if (ObjPacket.ISExists(Convert.ToString(e.Value)) == false)
                {
                    Global.Confirm(e.Value.ToString() + " : Barcode Not Found");
                    GrdOutSideReceipt.DeleteRow(GrdOutSideReceipt.FocusedRowHandle);
                    e.Valid = false;
                    return;
                }

                if (ValDuplicate(e.Value.ToString()) == false)
                {
                    Global.Confirm(e.Value.ToString() + " :    Barcode Already Exists In Previous Record");
                    e.Valid = false;
                    return;
                }

                Mix_IssRet_MasterProperty pClsProperty = GetPClsProperty();

                Packet_MasterProperty PacketProperty = new Packet_MasterProperty();
                PacketProperty.Barcode = Convert.ToString(e.Value);

                pClsProperty.From_Department_Code = Val.ToInt64(LookupFromDept.EditValue);
                pClsProperty.To_Department_Code = Val.ToInt64(LookupToDept.EditValue);
                pClsProperty.Entry_Date = DTPFReceiptDate.Text;
                pClsProperty.From_Process_Code = Val.ToInt64(LookupFromProcess.EditValue);
                pClsProperty.To_Process_Code = Val.ToInt64(LookupToProcess.EditValue);
                pClsProperty.Barcode = Convert.ToString(e.Value);
                pClsProperty.From_Party_Code = Val.ToInt64(LookupFromParty.EditValue);
                pClsProperty.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);

                System.Data.DataTable DTabIssueDate = ObjMix.GetReceiptFromOutSideBarcodeDetail(pClsProperty);

                if (DTabIssueDate.Rows.Count == 0)
                {
                    Global.Confirm(pClsProperty.Barcode.ToString() + " : NO ANY ISSUED DATA FOUND");
                    GrdOutSideReceipt.DeleteRow(GrdOutSideReceipt.FocusedRowHandle);
                    e.Valid = false;
                    return;
                }
                DataRow Drow = DTabIssueDate.Rows[0];
                if (Drow == null)
                {
                    Global.Confirm(pClsProperty.Barcode.ToString() + " : Barcode Not Found");
                    GrdOutSideReceipt.DeleteRow(GrdOutSideReceipt.FocusedRowHandle);
                    e.Valid = false;
                    return;
                }

                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "BARCODE", Convert.ToString(DTabIssueDate.Rows[0]["BARCODE"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "ROUGH_NAME", Convert.ToString(DTabIssueDate.Rows[0]["ROUGH_NAME"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "ISSUE_PCS", Convert.ToString(DTabIssueDate.Rows[0]["ISSUE_PCS"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "ISSUE_CARAT", Convert.ToString(DTabIssueDate.Rows[0]["ISSUE_CARAT"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "READY_PCS", Convert.ToDouble(DTabIssueDate.Rows[0]["READY_PCS"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "READY_CARAT", Convert.ToDouble(DTabIssueDate.Rows[0]["READY_CARAT"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "CONSUME_PCS", Convert.ToString(DTabIssueDate.Rows[0]["ISSUE_PCS"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "CONSUME_CARAT", Convert.ToString(DTabIssueDate.Rows[0]["ISSUE_CARAT"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "RETURN_JANGED_DATE", Convert.ToString(DTPFReceiptDate.Text));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "RR_PCS", Convert.ToDouble(DTabIssueDate.Rows[0]["RR_PCS"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "RR_CARAT", Convert.ToString(DTabIssueDate.Rows[0]["RR_CARAT"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "LOSS_PCS", Convert.ToString(DTabIssueDate.Rows[0]["LOSS_PCS"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "LOSS_CARAT", Convert.ToString(DTabIssueDate.Rows[0]["LOSS_CARAT"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "LOST_PCS", Convert.ToString(DTabIssueDate.Rows[0]["LOST_PCS"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "LOST_CARAT", Convert.ToString(DTabIssueDate.Rows[0]["LOST_CARAT"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "CANCEL_PCS", Convert.ToString(DTabIssueDate.Rows[0]["CANCEL_PCS"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "CANCEL_CARAT", Convert.ToString(DTabIssueDate.Rows[0]["CANCEL_CARAT"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "SAW_PCS", Convert.ToString(DTabIssueDate.Rows[0]["SAW_PCS"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "SAW_CARAT", Convert.ToString(DTabIssueDate.Rows[0]["SAW_CARAT"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "ROUGH_TYPE_CODE", Convert.ToString(DTabIssueDate.Rows[0]["ROUGH_TYPE_CODE"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "SIEVE_CODE", Convert.ToString(DTabIssueDate.Rows[0]["SIEVE_CODE"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "COLOR_CODE", Convert.ToString(DTabIssueDate.Rows[0]["COLOR_CODE"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "SHAPE_CODE", Convert.ToString(DTabIssueDate.Rows[0]["SHAPE_CODE"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "MFG_CLARITY_CODE", Convert.ToString(DTabIssueDate.Rows[0]["MFG_CLARITY_CODE"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "CLV_CLARITY_CODE", Convert.ToString(DTabIssueDate.Rows[0]["CLV_CLARITY_CODE"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "MAX_DIA", Convert.ToString(DTabIssueDate.Rows[0]["MAX_DIA"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "MIN_DIA", Convert.ToString(DTabIssueDate.Rows[0]["MIN_DIA"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "HEIGHT", Convert.ToString(DTabIssueDate.Rows[0]["HEIGHT"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "WIDTH", Convert.ToString(DTabIssueDate.Rows[0]["WIDTH"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "DEPTH", Convert.ToString(DTabIssueDate.Rows[0]["DEPTH"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "MFG_TYPE", Convert.ToString(DTabIssueDate.Rows[0]["MFG_TYPE"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "EXP_PER", Convert.ToString(DTabIssueDate.Rows[0]["EXP_PER"]));
                GrdOutSideReceipt.SetRowCellValue(GrdOutSideReceipt.FocusedRowHandle, "SRNO", Convert.ToString(DTabIssueDate.Rows[0]["SRNO"]));

                pClsProperty = null;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PanelShow.Enabled = true;
            panelControl6.Enabled = false;
            PanelGrid.Enabled = false;
            dgvOutSideReceipt.DataSource = null;
        }

        private void Calc()
        {
            //switch (dgvPolishReceive.Columns[dgvPolishReceive.CurrentCell.ColumnIndex].Name.ToString())
            //{
            //    case "READY_CARAT":
            //    case "RR_CARAT":
            //    case "SAW_CARAT":
            //    case "LOST_CARAT":
            if (Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("RR_CARAT")) == Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("ISSUE_CARAT")))
            {
                GrdOutSideReceipt.SetFocusedRowCellValue("CONSUME_CARAT", 0.000);
                GrdOutSideReceipt.SetFocusedRowCellValue("READY_CARAT", 0.000);
                GrdOutSideReceipt.SetFocusedRowCellValue("LOSS_CARAT", 0.000);
            }
            else
            {
                // if (LookupFromProcess.Text.Contains("REPAIRING"))
                //{
                //    GrdOutSideReceipt.SetFocusedRowCellValue("CONSUME_CARAT",GrdOutSideReceipt.GetFocusedRowCellValue("READY_CARAT"));
                //GrdOutSideReceipt.SetFocusedRowCellValue("LOSS_CARAT", Math.Round(Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("ISSUE_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("RR_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("READY_CARAT")), 3));
                //}
                //else
                //{
                if (Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("READY_CARAT")) == 0)
                {
                    GrdOutSideReceipt.SetFocusedRowCellValue("CONSUME_CARAT", 0.000);
                    if (Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("ISSUE_CARAT")) >= Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("RR_CARAT")))
                    {
                        GrdOutSideReceipt.SetFocusedRowCellValue("LOSS_CARAT", Math.Round(Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("ISSUE_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("RR_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("LOST_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("SAW_CARAT")), 3));
                    }
                }
                else
                {
                    GrdOutSideReceipt.SetFocusedRowCellValue("CONSUME_CARAT", Math.Round(Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("ISSUE_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("RR_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("SAW_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("LOST_CARAT")), 3));
                    GrdOutSideReceipt.SetFocusedRowCellValue("LOSS_CARAT", Math.Round(Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("ISSUE_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("RR_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("CONSUME_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("SAW_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("LOST_CARAT")), 3));
                }
                //}
            }

            //    break;

            //case "READY_PCS":
            //case "RR_PCS":
            //case "SAW_PCS":
            //case "LOST_PCS":
            if (Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("RR_PCS")) == Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("ISSUE_PCS")))
            {
                GrdOutSideReceipt.SetFocusedRowCellValue("CONSUME_PCS", 0);
                GrdOutSideReceipt.SetFocusedRowCellValue("READY_PCS", 0);
                GrdOutSideReceipt.SetFocusedRowCellValue("LOSS_PCS", 0);
            }
            else
            {
                //if (txtFromProcess.Text.Contains("REPAIRING"))
                //{
                //GrdOutSideReceipt.SetFocusedRowCellValue("CONSUME_PCS", GrdOutSideReceipt.GetFocusedRowCellValue("READY_PCS"));
                //}
                //else
                //{
                if (Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("READY_PCS")) == 0)
                {
                    GrdOutSideReceipt.SetFocusedRowCellValue("CONSUME_PCS", 0);
                }
                else
                {
                    GrdOutSideReceipt.SetFocusedRowCellValue("LOSS_CARAT", 0.000);
                    GrdOutSideReceipt.SetFocusedRowCellValue("CONSUME_PCS", Math.Round(Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("ISSUE_PCS")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("RR_PCS")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("SAW_PCS")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("LOST_PCS")), 0));
                }
                //}
            }
            //    break;
            //case "CONSUME_CARAT":
            GrdOutSideReceipt.SetFocusedRowCellValue("LOSS_CARAT", Math.Round(Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("ISSUE_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("RR_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("CONSUME_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("SAW_CARAT")) - Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("LOST_CARAT")), 3));
            //        break;
            //}

            //========================================================================================================================================================
            //if (Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("READY_PCS")) != 0 && Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("CONSUME_PCS")) != 0)
            //{
            //    if (Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("READY_PCS")) > Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("CONSUME_PCS")))
            //    {
            //        Global.Confirm("Invalid PCs");
            //        GrdOutSideReceipt.FocusedColumn = ColRdyPcs;
            //        GrdOutSideReceipt.ShowEditor();
            //        return;
            //    }
            //}
            //if (Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("READY_CARAT")) != 0 && Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("CONSUME_CARAT")) != 0)
            //{
            //    if (Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("READY_CARAT")) > Val.Val(GrdOutSideReceipt.GetFocusedRowCellValue("CONSUME_CARAT")))
            //    {
            //        Global.Confirm("Invalid Carat");
            //        GrdOutSideReceipt.FocusedColumn = ColRdyPcs;
            //        GrdOutSideReceipt.ShowEditor();
            //        return;
            //    }
            //}

        }

        private void GrdOutSideReceipt_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Calc();
        }

        private void GrdOutSideReceipt_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Calc();
        }

    }
}
