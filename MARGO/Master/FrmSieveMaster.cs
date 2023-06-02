using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using MARGO.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmSieveMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        SieveMaster objSieve = new SieveMaster();

        public FrmSieveMaster()
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
            txtSieveCode.Text = "0";
            txtSieveName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtFromPCS.Text = "";
            txtTOPCS.Text = "";
            txtFromCarat.Text = "";
            txtTOCarat.Text = "";
            txtFromSieve.Text = "";
            txtToSieve.Text = "";
            CmbSizeType.SelectedIndex = 0;
            RBtanIsSample.SelectedIndex = 1;
            RBtnIsMixTran.SelectedIndex = 1;
            txtRAPSizeCode.Text = "";
            txtDMPer.Text = "";
            txtManualPer.Text = "";
            ChkDefaultSieve.Checked = false;
        }                                                       

        #region Validation

        private bool ValSave()
        {
            if (txtSieveName.Text.Length == 0)
            {
                Global.Confirm("Sieve Name Is Required");
                txtSieveName.Focus();
                return false;
            }

            if (CmbSizeType.Text.ToUpper() == "SELECT")
            {
                Global.Confirm("Size Type Name Is Required");
                CmbSizeType.Focus();
                return false;
            }

            if (!objSieve.ISExists(txtSieveName.Text, Val.ToInt64(txtSieveCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Sieve Name Already Exist.");
                txtSieveName.Focus();
                txtSieveName.SelectAll();
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

            Sieve_MasterProperty SieveMasterProperty = new Sieve_MasterProperty();
            Int64 Code = Val.ToInt64(txtSieveCode.Text);
            SieveMasterProperty.Sieve_Code = Val.ToInt64(Code);
            SieveMasterProperty.Sieve_Name = txtSieveName.Text;
            SieveMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            SieveMasterProperty.Remark = txtRemark.Text;
            SieveMasterProperty.From_Sieve = Val.ToDouble(txtFromSieve.Text);
            SieveMasterProperty.To_Sieve = Val.ToDouble(txtToSieve.Text);
            SieveMasterProperty.From_Pcs = Val.ToDouble(txtFromPCS.Text);
            SieveMasterProperty.To_Pcs = Val.ToDouble(txtTOPCS.Text);
            SieveMasterProperty.From_Carat = Val.ToDouble(txtFromCarat.Text);
            SieveMasterProperty.To_Carat = Val.ToDouble(txtTOCarat.Text);
            SieveMasterProperty.Is_Sample = Val.ToInt(RBtanIsSample.EditValue);
            SieveMasterProperty.Is_MixTran = Val.ToInt(RBtnIsMixTran.EditValue);
            SieveMasterProperty.Size_Type = Val.ToString(CmbSizeType.EditValue);
            SieveMasterProperty.RAP_Size_Code = Val.ToString(txtRAPSizeCode.Text);
            SieveMasterProperty.DM_Per = Val.ToDouble(txtDMPer.Text);
            SieveMasterProperty.Manual_Per = Val.ToDouble(txtManualPer.Text);
            SieveMasterProperty.Default_Sieve_Flag = Val.ToBooleanToInt(ChkDefaultSieve.Checked);

            int IntRes = objSieve.Save(SieveMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Sieve Details");
                txtSieveName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Sieve Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Sieve Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            SieveMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objSieve.GetData_Search();
            grdSieveMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvSieveMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvSieveMaster.GetDataRow(e.RowHandle);
                    txtSieveCode.Text = Convert.ToString(Drow["SIEVE_CODE"]);
                    txtSieveName.Text = Convert.ToString(Drow["SIEVE_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);

                    txtFromSieve.Text = Convert.ToString(Drow["FROM_SIEVE"]);
                    txtToSieve.Text = Convert.ToString(Drow["TO_SIEVE"]);
                    RBtanIsSample.EditValue = Convert.ToInt32(Drow["IS_SAMPLE"]);
                    RBtnIsMixTran.EditValue = Convert.ToInt32(Drow["IS_MIXTRAN"]);
                    CmbSizeType.EditValue = Convert.ToString(Drow["SIZE_TYPE"]);
                    txtRAPSizeCode.Text = Convert.ToString(Drow["RAP_SIZE_CODE"]);
                    txtFromPCS.Text = Convert.ToString(Drow["FROM_PCS"]);
                    txtTOPCS.Text = Convert.ToString(Drow["TO_PCS"]);
                    ChkDefaultSieve.EditValue = Convert.ToInt32(Drow["DEFAULT_SIEVE_FLAG"]);
                    txtFromCarat.Text = Convert.ToString(Drow["FROM_CARAT"]);
                    txtTOCarat.Text = Convert.ToString(Drow["TO_CARAT"]);
                    txtDMPer.Text = Convert.ToString(Drow["DM_PER"]);
                    txtManualPer.Text = Convert.ToString(Drow["MANUAL_PER"]);                   
                }
            }
        }
    }
}
