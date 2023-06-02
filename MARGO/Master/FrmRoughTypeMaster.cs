using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using MARGO.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmRoughTypeMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        RoughTypeMaster objRoughType = new RoughTypeMaster();

        public FrmRoughTypeMaster()
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
            txtRoughTypeCode.Text = "0";
            txtRoughTypeName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtRoughTypeName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtRoughTypeName.Text.Length == 0)
            {
                Global.Confirm("Rough Type Name Is Required");
                txtRoughTypeName.Focus();
                return false;
            }
            if (!objRoughType.ISExists(txtRoughTypeName.Text, Val.ToInt64(txtRoughTypeCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Rough Type Name Already Exist.");
                txtRoughTypeName.Focus();
                txtRoughTypeName.SelectAll();
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

            RoughType_MasterProperty RoughTypeMasterProperty = new RoughType_MasterProperty();
            Int64  Code = Val.ToInt64(txtRoughTypeCode.Text);
            RoughTypeMasterProperty.Rough_Type_Code = Val.ToInt64(Code);
            RoughTypeMasterProperty.Rough_Type_Name = txtRoughTypeName.Text;
            RoughTypeMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            RoughTypeMasterProperty.Remark = txtRemark.Text;

            int IntRes = objRoughType.Save(RoughTypeMasterProperty);
            if (IntRes == -1)
            {
                MARGO.Class.Global.Confirm("Error In Save Rough Type Details");
                txtRoughTypeName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    MARGO.Class.Global.Confirm("Rough Type Details Data Save Successfully");
                }
                else
                {
                    MARGO.Class.Global.Confirm("Rough Type Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            RoughTypeMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objRoughType.GetData_Search();
            grdRoughTypeMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvRoughTypeMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvRoughTypeMaster.GetDataRow(e.RowHandle);
                    txtRoughTypeCode.Text = Convert.ToString(Drow["ROUGH_TYPE_CODE"]);
                    txtRoughTypeName.Text = Convert.ToString(Drow["ROUGH_TYPE_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                    txtRoughTypeName.Focus();
                }
            }
        }
    }
}
