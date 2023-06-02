using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using MARGO.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmShapeMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        ShapeMaster objShape = new ShapeMaster();

        public FrmShapeMaster()
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
            txtShapeCode.Text = "0";
            txtShapeName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtLabShapeName.Text = "";
            txtRAPBackShapeCode.Text = "";
            txtRapShapeCode.Text = "";
            txtRapBackShapeName.Text = "";
            txtRapShapeName.Text = "";
            txtRoughRateShapeCode.Text = "";
            txtRoughRateShapeName.Text = "";            
            txtFCPShapeCode.Text = "";
            txtFCPShapeName.Text = "";
            txtMIXCPShape.Text = "";
            txtBackShapeCode.Text = "";
            txtBackShapeName.Text = "";
            txtLabShapeCode.Text = "";
            txtShapeName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtShapeName.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Shape Name Is Required");
                txtShapeName.Focus();
                return false;
            }
            if (!objShape.ISExists(txtShapeName.Text, Val.ToInt64(txtShapeCode.Text)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Shape Name Already Exist.");
                txtShapeName.Focus();
                txtShapeName.SelectAll();
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

            Shape_MasterProperty ShapeMasterProperty = new Shape_MasterProperty();
            Int64 Code = Val.ToInt64(txtShapeCode.Text);
            ShapeMasterProperty.Shape_Code = Val.ToInt64(Code);
            ShapeMasterProperty.Shape_Name = txtShapeName.Text;
            ShapeMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            ShapeMasterProperty.Remark = txtRemark.Text;
            ShapeMasterProperty.Rap_Shape_Code = Val.ToString(txtRapShapeCode.Text);
            ShapeMasterProperty.Rap_Shape_Name = Val.ToString(txtRapShapeName.Text);
            ShapeMasterProperty.Rap_Back_Shape_Code = Val.ToString(txtRAPBackShapeCode.Text);
            ShapeMasterProperty.Rough_Rate_Shape_Name = Val.ToString(txtRoughRateShapeName.Text);
            ShapeMasterProperty.LAB_Shape_Name = Val.ToString(txtLabShapeName.Text);
            ShapeMasterProperty.FCP_Shape_Name = Val.ToString(txtFCPShapeName.Text);
            ShapeMasterProperty.MIX_CP_SHAPE = Val.ToString(txtMIXCPShape.Text);
            ShapeMasterProperty.BACK_SHAPE_NAME = Val.ToString(txtBackShapeName.Text);
            ShapeMasterProperty.ROUGH_RATE_SHAPE_CODE = Val.ToString(txtRoughRateShapeCode.Text);
            ShapeMasterProperty.RAP_BACK_SHAPE_NAME = Val.ToString(txtRapBackShapeName.Text);
            ShapeMasterProperty.FCP_SHAPE_CODE = Val.ToString(txtFCPShapeCode.Text);
            ShapeMasterProperty.LAB_SHAPE_CODE = Val.ToString(txtLabShapeCode.Text);
            ShapeMasterProperty.BACK_SHAPE_CODE = Val.ToString(txtBackShapeCode.Text);

            int IntRes = objShape.Save(ShapeMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Shape Details");
                txtShapeName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Shape Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Shape Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            ShapeMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objShape.GetData();
           grdShapeMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvShapeMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvShapeMaster.GetDataRow(e.RowHandle);
                    txtShapeCode.Text = Convert.ToString(Drow["SHAPE_CODE"]);
                    txtShapeName.Text = Convert.ToString(Drow["SHAPE_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                    txtRapShapeCode.Text = Convert.ToString(Drow["RAP_SHAPE_CODE"]);
                    txtRapShapeName.Text = Convert.ToString(Drow["RAP_SHAPE_NAME"]);
                    txtRAPBackShapeCode.Text = Convert.ToString(Drow["RAP_BACK_SHAPE_CODE"]);
                    txtRapBackShapeName.Text = Convert.ToString(Drow["RAP_BACK_SHAPE_NAME"]);
                    txtLabShapeName.Text = Convert.ToString(Drow["LAB_SHAPE_NAME"]);
                    txtRoughRateShapeName.Text = Convert.ToString(Drow["ROUGH_RATE_SHAPE_NAME"]);
                    txtFCPShapeName.Text = Convert.ToString(Drow["FCP_SHAPE_NAME"]);
                    txtMIXCPShape.Text = Convert.ToString(Drow["MIX_CP_SHAPE"]);
                    txtBackShapeName.Text = Convert.ToString(Drow["BACK_SHAPE_NAME"]);
                    txtRoughRateShapeCode.Text = Convert.ToString(Drow["ROUGH_RATE_SHAPE_CODE"]);
                    txtFCPShapeCode.Text = Convert.ToString(Drow["FCP_SHAPE_CODE"]);
                    txtLabShapeCode.Text = Convert.ToString(Drow["LAB_SHAPE_CODE"]);
                    txtBackShapeCode.Text = Convert.ToString(Drow["BACK_SHAPE_CODE"]);
                }
            }
        }
    }
}
