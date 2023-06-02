using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Transaction;
using MARGO.Class;
using MARGO.Report;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmPolishAssortment : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        ClvMixDeptIssRet ObjMix = new ClvMixDeptIssRet();
        DataTable DTab = new DataTable();
        System.Data.DataTable DTabExpPerDiff = new System.Data.DataTable();

        public FrmPolishAssortment()
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
            DTPFNotingDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            LookupRoughName.EditValue = null;
            dgvPolishAsso.DataSource = null;
            PanelShow.Enabled = true;
            panelControl6.Enabled = false;
            PanelGrid.Enabled = false;
            LookupRoughName.Focus();
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

            if (Convert.ToString(DTPFNotingDate.EditValue) == "" && Val.ToString(LookupRoughName.Text.Trim()) == "")
            {
                Global.Confirm("Rough Name OR Date is required");
                LookupRoughName.Focus();
                return false;
            }
            return true;
        }

        private bool ValSave()
        {
            if (Val.ToString(LookupRoughName.Text.Trim()) == "")
            {
                Global.Confirm("Rough Name Required");
                LookupRoughName.Focus();
                return false;
            }

            if (Convert.ToString(DTPFNotingDate.EditValue) == "")
            {
                Global.Confirm("Date is required");
                DTPFNotingDate.Focus();
                return false;
            }

            if (!Global.MCheckEmpty(ColPolishSieve, GrdPolishAsso, "Polish Sieve"))
            {
                return false;
            }
            if (!Global.MCheckEmpty(ColPolishCla, GrdPolishAsso, "Polish Clarity"))
            {
                return false;
            }
            if (!Global.MCheckEmpty(ColMFGColor, GrdPolishAsso, "MFG Color"))
            {
                return false;
            }
            if (!Global.MCheckEmpty(ColCarat, GrdPolishAsso, "Carat"))
            {
                return false;
            }
            if (!Global.MCheckEmpty(ColExpReg, GrdPolishAsso, "Export Rejection Carat"))
            {
                return false;
            }
            //if (!Global.MCheckEmpty(ColRemark, GrdPolishAsso, "Remark"))
            //{
            //    return false;
            //}
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

                Mix_IssRet_MasterProperty Property = GetPClsProperty();
                Property.Noting_Date = Val.DBDate(DTPFNotingDate.Text);
                Property.Rough_Name = Val.ToString(LookupRoughName.EditValue);
                System.Data.DataTable DTabIssueDate = ObjMix.GetPolishAssortment(Property);
                dgvPolishAsso.DataSource = DTabIssueDate;
                GrdPolishAsso.BestFitColumns();
                GrdPolishAsso.Focus();
                Property = null;
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

        private void LookUpRepColor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmColorMaster frmCnt = new FrmColorMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPColorRep(LookUpRepColor);
            }
        }

        private void dgvOutSideReceipt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                
                if (Global.Confirm("Are you sure delete selected row in Polish Assortment Entry?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Int64 PolAssort_ID = Val.ToInt64(GrdPolishAsso.GetFocusedRowCellValue("PolAssotID").ToString());
                    if (PolAssort_ID > 0)
                    {
                        int IntRes = 0;
                        Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();
                        Property.P_ID = Val.ToInt64(GrdPolishAsso.GetFocusedRowCellValue("PolAssotID").ToString());

                        IntRes = ObjMix.PolAssotment_RowDate_Delete(Property);

                        GrdPolishAsso.DeleteRow(GrdPolishAsso.GetRowHandle(GrdPolishAsso.FocusedRowHandle));
                    }
                    else if (PolAssort_ID == 0)
                    {
                        GrdPolishAsso.DeleteRow(GrdPolishAsso.GetRowHandle(GrdPolishAsso.FocusedRowHandle));
                    }
                }

            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (ValSave() == false)
            {
                return;
            }

            if (Global.Confirm("Are You Sure To Polish Assortment Entry?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            int IntRes = 0;
            Mix_IssRet_MasterProperty Property = new Mix_IssRet_MasterProperty();

            DataTable DTAB = new DataTable();
            DTAB = (DataTable)dgvPolishAsso.DataSource;
            DTAB.AcceptChanges();
            if (DTAB != null)
            {
                if (DTAB.Rows.Count > 0)
                {
                    foreach (DataRow Drow in DTAB.Rows)
                    {
                        Property.PolishAss_ID = Val.ToInt64(Drow["PolAssotID"]);
                        Property.Rough_Name = Val.ToString(LookupRoughName.Text);
                        Property.Noting_Date = Val.DBDate(DTPFNotingDate.Text);
                        Property.Size_ID = Val.ToInt64(Drow["SizeID"]);
                        Property.Clarity_Code = Val.ToInt64(Drow["ClarityID"]);
                        Property.Color_Code = Val.ToInt64(Drow["ColorID"]);
                        Property.Carat = Val.ToDouble(Drow["Carats"]);
                        Property.ERCarat = Val.ToDouble(Drow["ERCarats"]);
                        Property.Remark_Name = Val.ToString(Drow["Remarks"]);

                        IntRes = ObjMix.PolishAssortment_Save(Property);
                        //if (Property != null)
                        //{
                        //    IntRes = 1;
                        //}
                    }
                    Property = null;
                }
            }

            if (IntRes != 0)
            {
                Global.Confirm("Polish Assortment Data SuccessFully Save");
                btnClear_Click(null, null);
            }
            else
            {
                Global.Confirm("Error in Save Record .. Please Check");
            }
        }

        private static Mix_IssRet_MasterProperty GetPClsProperty()
        {
            Mix_IssRet_MasterProperty pClsProperty = new Mix_IssRet_MasterProperty();
            return pClsProperty;
        }

        private void LookUpRapSieve_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmSieveMaster frmCnt = new FrmSieveMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPSieveRep(LookUpRapSieve);
            }
        }

        private void FrmPolishAssortment_Shown(object sender, EventArgs e)
        {
            btnClear_Click(btnClear, null);
            DTPFNotingDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());
            
            Global.LOOKUPRough(LookupRoughName);
            Global.LOOKUPSieveRep(LookUpRapSieve);
            Global.LOOKUPClarityRep(LookUpRapClarity);
            Global.LOOKUPRoughRep(LookUpRepRough);
            Global.LOOKUPColorRep(LookUpRepColor);
        }

        private void LookUpRapClarity_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarityRep(LookUpRapClarity);
            }
        }

        #region Operation

        private void Export1(string format, string dlgHeader, string dlgFilter)
        {
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
                            GrdPolishAsso.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            GrdPolishAsso.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            GrdPolishAsso.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            GrdPolishAsso.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            GrdPolishAsso.ExportToText(Filepath);
                            break;
                        case "html":
                            GrdPolishAsso.ExportToHtml(Filepath);
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

        private void MNExportExcel_Click(object sender, EventArgs e)
        {
            Export1("xls", "Export to Excel", "Excel files 97-2003 (*.xls)|*.xls|Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }

        private void MNExportPDF_Click(object sender, EventArgs e)
        {
            Export1("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }

        private void MNExportTEXT_Click(object sender, EventArgs e)
        {
            Export1("txt", "Export to Text", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
        }

        private void MNExportHTML_Click(object sender, EventArgs e)
        {
            Export1("html", "Export to HTML", "Html files (*.html)|*.html|Htm files (*.htm)|*.htm");
        }

        private void MNExportRTF_Click(object sender, EventArgs e)
        {
            Export1("rtf", "Export to RTF", "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*");
        }

        #endregion

        private void GrdPolishAsso_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (LookupRoughName.Text != "")
            {
                GrdPolishAsso.SetRowCellValue(e.RowHandle, ColRough, LookupRoughName.EditValue);
            }
            if (DTPFNotingDate.Text != "")
            {
                GrdPolishAsso.SetRowCellValue(e.RowHandle, ColNotingDate, DTPFNotingDate.EditValue);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.Confirm("Are You Sure To Print Record ? ", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                Mix_IssRet_MasterProperty Property = GetPClsProperty();
                Property.Noting_Date = Val.DBDate(DTPFNotingDate.Text);
                Property.Rough_Name = Val.ToString(LookupRoughName.EditValue);
                System.Data.DataTable DTabPrint = ObjMix.GetPolishAssortment(Property);

                //System.Data.DataTable DTabPrint = (System.Data.DataTable)dgvPolishAsso.DataSource;

                if (DTabPrint != null)
                {
                    if (DTabPrint.Rows.Count > 0)
                    {
                        FrmReportViewer FrmReportViewer = new FrmReportViewer();
                        FrmReportViewer.DS.Tables.Add(DTabPrint);
                        FrmReportViewer.GroupBy = "";
                        FrmReportViewer.RepName = "";
                        FrmReportViewer.RepPara = "";
                        this.Cursor = Cursors.Default;
                        FrmReportViewer.AllowSetFormula = true;
                        FrmReportViewer.ShowForm("Polish_Assortment_Report", 120, Report.FrmReportViewer.ReportFolder.JANGED);
                        DTabPrint = null;
                    }
                }
                else
                {
                    Global.Confirm("Polish Assortment Data Not Found");
                    return;
                }
               
            }
            catch (Exception Ex)
            {
                Global.Confirm(Ex.Message);
            }
        }
    }
}
