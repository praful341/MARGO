using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using MARGO.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmColorMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        ColorMaster objColor = new ColorMaster();

        public FrmColorMaster()
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
            txtColorCode.Text = "0";
            txtColorName.Text = "";
            txtRemark.Text = "";
            RBtnStatus.SelectedIndex = 0;
            txtLabColorName.Text = "";
            txtPolishColorCode.Text = "";
            txtRapColorCode.Text = "";
            txtRapBackColorName.Text = "";
            txtRapColorName.Text = "";
            txtColorName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtColorName.Text.Length == 0)
            {
                Global.Confirm("Color Name Is Required");
                txtColorName.Focus();
                return false;
            }

            if (!objColor.ISExists(txtColorName.Text, Val.ToInt64(txtColorCode.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Color Name Already Exist.");
                txtColorName.Focus();
                txtColorName.SelectAll();
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

            Color_MasterProperty ColorMasterProperty = new Color_MasterProperty();
            Int64 Code = Val.ToInt64(txtColorCode.Text);
            ColorMasterProperty.Color_Code = Val.ToInt64(Code);
            ColorMasterProperty.Color_Name = txtColorName.Text;
            ColorMasterProperty.Active = Val.ToInt(RBtnStatus.Text);
            ColorMasterProperty.Remark = txtRemark.Text;
            ColorMasterProperty.Rap_Color_Code = Val.ToString(txtRapColorCode.Text);
            ColorMasterProperty.Rap_Color_Name = Val.ToString(txtRapColorName.Text);
            ColorMasterProperty.Polish_Color_Code = Val.ToString(txtPolishColorCode.Text);
            ColorMasterProperty.Rap_Back_Color_Name = Val.ToString(txtRapBackColorName.Text);
            ColorMasterProperty.LAB_Color_Name = Val.ToString(txtLabColorName.Text);


            int IntRes = objColor.Save(ColorMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Color Details");
                txtColorName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Color Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Color Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            ColorMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objColor.GetData_Search();
            grdColorMaster.DataSource = DTab;
        }

        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
        }

        private void dgvColorMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvColorMaster.GetDataRow(e.RowHandle);
                    txtColorCode.Text = Convert.ToString(Drow["COLOR_CODE"]);
                    txtColorName.Text = Convert.ToString(Drow["COLOR_NAME"]);
                    RBtnStatus.EditValue = Convert.ToInt32(Drow["ACTIVE"]);
                    txtRemark.Text = Convert.ToString(Drow["REMARK"]);
                    txtRapColorCode.Text = Convert.ToString(Drow["RAP_COLOR_CODE"]);
                    txtRapColorName.Text = Convert.ToString(Drow["RAP_COLOR_NAME"]);
                    txtPolishColorCode.Text = Convert.ToString(Drow["POLISH_COLOR_CODE"]);
                    txtRapBackColorName.Text = Convert.ToString(Drow["RAP_BACK_COLOR_CODE"]);
                    txtLabColorName.Text = Convert.ToString(Drow["LAB_COLOR_NAME"]);
                }
            }
        }
    }
}
