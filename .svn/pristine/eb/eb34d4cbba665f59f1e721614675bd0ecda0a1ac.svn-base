using BLL;
using BLL.FunctionClasses.Entry;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using MARGO.Class;

namespace MARGO
{
    public partial class FrmLabourRateMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();       
        SieveMaster objSieve = new SieveMaster();
        ClarityMaster objClarity = new ClarityMaster();
        RoughMaster objRough = new RoughMaster();
        LabourRateMaster objLabourRate = new LabourRateMaster();
        DataTable DTabMainData = new DataTable();

        public enum EnumLabourCriteria
        {
            ONE_RATE = 0,
            ROUGH_RATE = 1,
            CENT_WISE = 2,
            SIEVE_WISE = 3,
            SIEVE_CLARITY = 4
        }

        EnumLabourCriteria mEnumLabourCriteria = EnumLabourCriteria.ONE_RATE;

        public FrmLabourRateMaster()
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
            txtLabourCode.Text = "0";
            txtOneRate.Text = "";
            PanelShow.Enabled = true;
            CmbStatus.SelectedIndex = 0;
            LookupProcess.Focus();
            CmbLabourType.SelectedIndex = 0;
            CmbCriteria.SelectedIndex = 0;
            LookupParty.EditValue = null;
            LookupProcess.EditValue = null;
            LookupShape.EditValue = null;
            DTPEffectiveDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            GrpPanelCentWise.Visible = false;
            GrpPanelOneRate.Visible = false;
            GrpPanelSieveWise.Visible = false;
            GrpPanelSieveClarity.Visible = false;
        }

        #region Validation

        private bool ValSave()
        {
            if (LookupProcess.Text == "")
            {
                Global.Confirm("Process Name Is Required");
                LookupProcess.Focus();
                return false;
            }
            if (LookupParty.Text == "")
            {
                Global.Confirm("Party Name Is Required");
                LookupParty.Focus();
                return false;
            }
            if (LookupShape.Text == "")
            {
                Global.Confirm("Shape Name Is Required");
                LookupShape.Focus();
                return false;
            }
            if (CmbCriteria.Text == "")
            {
                MARGO.Class.Global.Confirm("Criteria Name Is Required");
                CmbCriteria.Focus();
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

            if (Global.Confirm("Are You Sure That You Want To Save Labour Rate Entry ? ", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            int IntRes = 0;

            this.Cursor = Cursors.WaitCursor;

            Labour_Rate_MasterProperty PropertyDelete = new Labour_Rate_MasterProperty();

            PropertyDelete.Labour_Code = Val.ToInt64(txtLabourCode.Text);
            PropertyDelete.Party_Code = Val.ToInt64(LookupParty.EditValue);
            PropertyDelete.Process_Code = Val.ToInt64(LookupProcess.EditValue);
            PropertyDelete.Shape_Code = Val.ToInt64(LookupShape.EditValue);
            PropertyDelete.Effective_Date = Val.DBDate(DTPEffectiveDate.Text);
            PropertyDelete.Labour_Type = Val.ToString(CmbLabourType.SelectedItem);
            PropertyDelete.Criteria = Val.ToString(CmbCriteria.SelectedItem);
            PropertyDelete.Status = Val.ToString(CmbStatus.SelectedItem);

            objLabourRate.Delete(PropertyDelete);

            if (mEnumLabourCriteria == EnumLabourCriteria.ONE_RATE)
            {
                Labour_Rate_MasterProperty Property = new Labour_Rate_MasterProperty();

                if (txtLabourCode.Text == "0")
                {
                    txtLabourCode.Text = objLabourRate.FindNewJangedNo(DTPEffectiveDate.Text).ToString();
                    Property.Labour_Code = Val.ToInt64(txtLabourCode.Text);
                }
                else
                {
                    Property.Labour_Code = Val.ToInt64(txtLabourCode.Text);
                }
                Property.Party_Code = Val.ToInt64(LookupParty.EditValue);
                Property.Process_Code = Val.ToInt64(LookupProcess.EditValue);
                Property.Shape_Code = Val.ToInt64(LookupShape.EditValue);
                Property.Effective_Date = Val.DBDate(DTPEffectiveDate.Text);
                Property.Labour_Type = Val.ToString(CmbLabourType.SelectedItem);
                Property.Rate = Val.Val(txtOneRate.Text);
                Property.Criteria = Val.ToString(CmbCriteria.SelectedItem);
                Property.Status = Val.ToString(CmbStatus.SelectedItem);
                Property.From_Cent = 0;
                Property.To_Cent = 0;
                Property.Rate = Val.Val(txtOneRate.Text);
                Property.Clarity_Code = 0;
                Property.Sieve_Code = 0;
                Property.Entry_Date = Val.DBDate(System.DateTime.Now.ToString());

                IntRes += objLabourRate.Save(Property);
                Property = null;
            }

            else if (mEnumLabourCriteria == EnumLabourCriteria.CENT_WISE)
            {
                Labour_Rate_MasterProperty Property = new Labour_Rate_MasterProperty();

                System.Data.DataTable DTab = (System.Data.DataTable)dgvCentWise.DataSource;

                if (txtLabourCode.Text == "0")
                {
                    txtLabourCode.Text = objLabourRate.FindNewJangedNo(DTPEffectiveDate.Text).ToString();
                    Property.Labour_Code = Val.ToInt64(txtLabourCode.Text);
                }
                else
                {
                    Property.Labour_Code = Val.ToInt64(txtLabourCode.Text);
                }

                if (DTab.Rows.Count > 0)
                {
                    for (int i = 0; i < DTab.Rows.Count; i++)
                    {
                        if (Val.Val(DTab.Rows[i]["RATE"].ToString()) == 0)
                        {
                            continue;
                        }

                        Property.Party_Code = Val.ToInt64(LookupParty.EditValue);
                        Property.Process_Code = Val.ToInt64(LookupProcess.EditValue);
                        Property.Shape_Code = Val.ToInt64(LookupShape.EditValue);
                        Property.Effective_Date = Val.DBDate(DTPEffectiveDate.Text);
                        Property.Labour_Type = Val.ToString(CmbLabourType.SelectedItem);
                        Property.Rate = Val.Val(DTab.Rows[i]["RATE"].ToString());
                        Property.Criteria = Val.ToString(CmbCriteria.SelectedItem);
                        Property.Status = Val.ToString(CmbStatus.SelectedItem);
                        Property.From_Cent = Val.Val(DTab.Rows[i]["FROM_CENT"].ToString());
                        Property.To_Cent = Val.Val(DTab.Rows[i]["TO_CENT"].ToString());
                        Property.Clarity_Code = 0;
                        Property.Sieve_Code = 0;
                        Property.Entry_Date = Val.DBDate(System.DateTime.Now.ToString());

                        IntRes += objLabourRate.Save(Property);
                    }
                    Property = null;
                }
            }

            else if (mEnumLabourCriteria == EnumLabourCriteria.SIEVE_WISE)
            {
                Labour_Rate_MasterProperty Property = new Labour_Rate_MasterProperty();

                System.Data.DataTable DTab = (System.Data.DataTable)dgvSieveWise.DataSource;

                if (txtLabourCode.Text == "0")
                {
                    txtLabourCode.Text = objLabourRate.FindNewJangedNo(DTPEffectiveDate.Text).ToString();
                    Property.Labour_Code = Val.ToInt64(txtLabourCode.Text);
                }
                else
                {
                    Property.Labour_Code = Val.ToInt64(txtLabourCode.Text);
                }

                if (DTab.Rows.Count > 0)
                {
                    for (int i = 0; i < DTab.Rows.Count; i++)
                    {
                        if (Val.Val(DTab.Rows[i]["RATE"].ToString()) == 0)
                        {
                            continue;
                        }

                        Property.Party_Code = Val.ToInt64(LookupParty.EditValue);
                        Property.Process_Code = Val.ToInt64(LookupProcess.EditValue);
                        Property.Shape_Code = Val.ToInt64(LookupShape.EditValue);
                        Property.Effective_Date = Val.DBDate(DTPEffectiveDate.Text);
                        Property.Labour_Type = Val.ToString(CmbLabourType.SelectedItem);
                        Property.Rate = Val.Val(DTab.Rows[i]["RATE"].ToString());
                        Property.Criteria = Val.ToString(CmbCriteria.SelectedItem);
                        Property.Status = Val.ToString(CmbStatus.SelectedItem);
                        Property.From_Cent = 0;
                        Property.To_Cent = 0;
                        Property.Clarity_Code = 0;
                        Property.Sieve_Code = Val.ToInt64(DTab.Rows[i]["SIEVE_CODE"].ToString());
                        Property.Entry_Date = Val.DBDate(System.DateTime.Now.ToString());

                        IntRes += objLabourRate.Save(Property);
                    }
                    Property = null;
                }
            }

            else if (mEnumLabourCriteria == EnumLabourCriteria.SIEVE_CLARITY)
            {
                Labour_Rate_MasterProperty Property = new Labour_Rate_MasterProperty();

                System.Data.DataTable DTab = (System.Data.DataTable)dgvSieveClarity.DataSource;

                if (txtLabourCode.Text == "0")
                {
                    txtLabourCode.Text = objLabourRate.FindNewJangedNo(DTPEffectiveDate.Text).ToString();
                    Property.Labour_Code = Val.ToInt64(txtLabourCode.Text);
                }
                else
                {
                    Property.Labour_Code = Val.ToInt64(txtLabourCode.Text);
                }

                if (DTab.Rows.Count > 0)
                {
                    for (int i = 0; i < DTab.Rows.Count; i++)
                    {
                        Property.Party_Code = Val.ToInt64(LookupParty.EditValue);
                        Property.Process_Code = Val.ToInt64(LookupProcess.EditValue);
                        Property.Shape_Code = Val.ToInt64(LookupShape.EditValue);
                        Property.Effective_Date = Val.DBDate(DTPEffectiveDate.Text);
                        Property.Labour_Type = Val.ToString(CmbLabourType.SelectedItem);
                        Property.Rate = Val.Val(DTab.Rows[i]["RATE"].ToString());
                        Property.Criteria = Val.ToString(CmbCriteria.SelectedItem);
                        Property.Status = Val.ToString(CmbStatus.SelectedItem);
                        Property.From_Cent = 0;
                        Property.To_Cent = 0;
                        Property.Clarity_Code = Val.ToInt64(DTab.Rows[i]["CLARITY_CODE"].ToString());
                        Property.Sieve_Code = Val.ToInt64(DTab.Rows[i]["SIEVE_CODE"].ToString());
                        Property.Entry_Date = Val.DBDate(System.DateTime.Now.ToString());
                        IntRes += objLabourRate.Save(Property);
                    }
                    Property = null;
                }
            }

            if (IntRes != 0)
            {
                Global.Confirm("Labour Rate Successfully Saved");
                btnClear_Click(btnClear, null);
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;
        }

        public void GetData()
        {
            //Labour_Rate_MasterProperty Property = new Labour_Rate_MasterProperty();
            //Property.Party_Code = Val.ToInt64(LookupParty.EditValue);
            //Property.Process_Code = Val.ToInt64(LookupProcess.EditValue);

            //Property.Shape_Code = Val.ToInt64(LookupShape.EditValue);

            //Property.Effective_Date = Val.DBDate(DTPEffectiveDate.Text);
            //Property.Labour_Type = Val.ToString(CmbLabourType.SelectedItem);
            //Property.Criteria = Val.ToString(CmbCriteria.SelectedItem);
            //Property.Status = Val.ToString(CmbStatus.SelectedItem);

            DataTable DTab = objLabourRate.GetLabourMasterData();
            grdLabourRateMaster.DataSource = DTab;   // .DefaultView.ToTable(true, "LABOUR_CODE", "EFFECTIVE_DATE", "PROCESS_NAME", "PROCESS_CODE", "SHAPE_NAME", "SHAPE_CODE", "CRITERIA", "STATUS", "LABOUR_TYPE", "PARTY_NAME", "PARTY_CODE");
           
            dgvLabourRateMaster.BestFitColumns();
        }

        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            //GetData();
            //btnClear_Click(btnClear, null);
            //LookupProcess.Focus();
            //DTPEffectiveDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            //Global.LOOKUPParty(LookupParty);
            //Global.LOOKUPProcess(LookupProcess);
            //Global.LOOKUPShape(LookupShape);
            //Global.LOOKUPSieveRep(repositoryItemLookUpEdit1);
            //Global.LOOKUPClarityRep(repositoryItemLookUpEdit2);

            //GrpPanelCentWise.Visible = false;
            //GrpPanelOneRate.Visible = false;
            //GrpPanelSieveWise.Visible = false;
            //GrpPanelSieveClarity.Visible = false;
        }

        private void LookupShape_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmShapeMaster frmCnt = new FrmShapeMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPShape(LookupShape); 
            }
        }

        private void LookupProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmCnt = new FrmProcessMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPProcess(LookupProcess);
            }
        }

        private void LookupParty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmPartyMaster frmCnt = new FrmPartyMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPParty(LookupParty);
            }
        }

        private void dgvLabourRateMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {

                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvLabourRateMaster.GetDataRow(e.RowHandle);
                    txtLabourCode.Text = Convert.ToString(Drow["LABOUR_CODE"]);
                    DTPEffectiveDate.Text = Val.DBDate(Drow["EFFECTIVE_DATE"].ToString());
                    LookupProcess.EditValue = Val.ToInt64(Drow["PROCESS_CODE"]);
                    LookupParty.EditValue = Val.ToInt64(Drow["PARTY_CODE"]);
                    LookupShape.EditValue = Val.ToInt64(Drow["SHAPE_CODE"]);
                    CmbCriteria.Text = Val.ToString(Drow["CRITERIA"]);
                    CmbStatus.Text = Val.ToString(Drow["STATUS"]);
                    CmbLabourType.Text = Val.ToString(Drow["LABOUR_TYPE"]);

                    BtnShow_Click(null, null);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PanelShow.Enabled = true;
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

        private void repositoryItemLookUpEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmClarityMaster frmCnt = new FrmClarityMaster();
                frmCnt.ShowDialog();
                Global.LOOKUPClarityRep(repositoryItemLookUpEdit2, "Mfg");
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            if (ValSave() == false)
            {
                return;
            }

            Labour_Rate_MasterProperty Property = new Labour_Rate_MasterProperty();
            Property.Party_Code = Val.ToInt64(LookupParty.EditValue);
            Property.Process_Code = Val.ToInt64(LookupProcess.EditValue);

            Property.Shape_Code = Val.ToInt64(LookupShape.EditValue);

            Property.Effective_Date = Val.DBDate(DTPEffectiveDate.Text);
            Property.Labour_Type = Val.ToString(CmbLabourType.SelectedItem);
            Property.Criteria = Val.ToString(CmbCriteria.SelectedItem);
            Property.Status = Val.ToString(CmbStatus.SelectedItem);

            DTabMainData = objLabourRate.GetLabourRateDataFromNew(Property);

            if (Val.ToString(CmbCriteria.SelectedItem) == "ONE-RATE")
            {
                GrpPanelOneRate.Visible = true;
                GrpPanelCentWise.Visible = false;
                GrpPanelSieveWise.Visible = false;
                GrpPanelSieveClarity.Visible = false;


                mEnumLabourCriteria = EnumLabourCriteria.ONE_RATE;
                GrpPanelOneRate.Dock = DockStyle.Left;
                if (DTabMainData.Rows.Count > 0)
                {
                    txtOneRate.Text = Val.ToString(DTabMainData.Rows[0]["RATE"]);
                    Int64  Code = Val.ToInt64(DTabMainData.Rows[0]["LABOUR_CODE"]);
                    txtLabourCode.Text = Code.ToString();
                    txtOneRate.Focus();
                }
                else
                {
                    Global.Confirm("No Labour Rate Data Found");
                    txtOneRate.Text = "0";
                    txtLabourCode.Text = "0";
                    txtOneRate.Focus();

                }
            }
            else if (Val.ToString(CmbCriteria.SelectedItem) == "CENT-WISE")
            {
                GrpPanelOneRate.Visible = false;
                GrpPanelCentWise.Visible = true;
                GrpPanelSieveWise.Visible = false;
                GrpPanelSieveClarity.Visible = false;

                mEnumLabourCriteria = EnumLabourCriteria.CENT_WISE;
                GrpPanelCentWise.Dock = DockStyle.Left;

                if (DTabMainData.Rows.Count > 0)
                {
                    dgvCentWise.DataSource = DTabMainData;
                    dgvCentWise.Focus();
                    Int64 Code = Val.ToInt64(DTabMainData.Rows[0]["LABOUR_CODE"]);
                    txtLabourCode.Text = Code.ToString();
                }
                else
                {
                    Global.Confirm("No Labour Rate Data Found");
                    DataTable dt = new DataTable();
                    dt.Columns.Add("FROM_CENT", typeof(double));
                    dt.Columns.Add("TO_CENT", typeof(double));
                    dt.Columns.Add("RATE", typeof(double));
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    dgvCentWise.DataSource = dt;
                    txtLabourCode.Text = "0";
                }
            }
            else if (Val.ToString(CmbCriteria.SelectedItem) == "SIEVE-WISE")
            {
                GrpPanelOneRate.Visible = false;
                GrpPanelCentWise.Visible = false;
                GrpPanelSieveWise.Visible = true;
                GrpPanelSieveClarity.Visible = false;

                mEnumLabourCriteria = EnumLabourCriteria.SIEVE_WISE;
                GrpPanelSieveWise.Dock = DockStyle.Left;

                dgvSieveWise.DataSource = DTabMainData;
                dgvSieveWise.Focus();
                Int64 Code = 0;
                if (DTabMainData.Rows.Count > 0)
                {
                    if (DTabMainData.Select("LABOUR_CODE > 0").Count() > 0)
                    {
                        Code = Val.ToInt64((DTabMainData.Select("LABOUR_CODE > 0").CopyToDataTable().AsEnumerable().Select(r => r.Field<Int64>("LABOUR_CODE")).Distinct().FirstOrDefault()));
                    }
                }
                if (Code == 0)
                {
                    txtLabourCode.Text = "0";
                }
                else
                {
                    txtLabourCode.Text = Code.ToString();
                }
            }
            else if (Val.ToString(CmbCriteria.SelectedItem) == "SIEVE-CLARITY")
            {
                GrpPanelOneRate.Visible = false;
                GrpPanelCentWise.Visible = false;
                GrpPanelSieveWise.Visible = false;
                GrpPanelSieveClarity.Visible = true;

                mEnumLabourCriteria = EnumLabourCriteria.SIEVE_CLARITY;
                GrpPanelSieveClarity.Dock = DockStyle.Fill;

                dgvSieveClarity.DataSource = DTabMainData;
                dgvSieveClarity.Refresh();
                dgvSieveClarity.Focus();

                Int64 Code = Val.ToInt64(DTabMainData.Rows[0]["LABOUR_CODE"]);
                txtLabourCode.Text = Code.ToString();
            }
            PanelShow.Enabled = false;
        }

        private void FrmLabourRateMaster_Shown(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            LookupProcess.Focus();
            DTPEffectiveDate.Text = Val.DBDate(System.DateTime.Now.ToShortDateString());

            Global.LOOKUPParty(LookupParty);
            Global.LOOKUPProcess(LookupProcess);
            Global.LOOKUPShape(LookupShape);
            Global.LOOKUPSieveRep(repositoryItemLookUpEdit1);
            Global.LOOKUPClarityRep(repositoryItemLookUpEdit2, "Mfg");

            GrpPanelCentWise.Visible = false;
            GrpPanelOneRate.Visible = false;
            GrpPanelSieveWise.Visible = false;
            GrpPanelSieveClarity.Visible = false;
        }
    }
}
