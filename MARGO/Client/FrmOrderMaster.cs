using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using MARGO.Class;
using MARGO.Search;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmOrderMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        OrderMaster objOrder = new OrderMaster();
        FrmSearchNew FrmSearchNew;
        EnquiryMaster objEnquiry = new EnquiryMaster();

        public FrmOrderMaster()
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
            txtOrderID.Text = "0";        
                   
            txtEnquiryNo.Text = "";
            txtDuration.Text = "0";
            chkIsApplicable.Checked = false;
            DTPOrderDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPOrderDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPOrderDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPOrderDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPConfirmDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPConfirmDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPConfirmDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPConfirmDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPOrderDate.EditValue = DateTime.Now;
            DTPConfirmDate.EditValue = DateTime.Now;

            DTPDeliveryDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPDeliveryDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPDeliveryDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPDeliveryDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPAMCStartDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPAMCStartDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPAMCStartDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPAMCStartDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPDeliveryDate.EditValue = DateTime.Now;
            DTPAMCStartDate.EditValue = DateTime.Now;

            DTPAMCEndDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPAMCEndDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPAMCEndDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPAMCEndDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPAMCEndDate.EditValue = DateTime.Now;

            DTPOrderDate.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtEnquiryNo.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Enquiry No Is Required");
                txtEnquiryNo.Focus();
                return false;
            }
            if (!objOrder.ISExists(txtEnquiryNo.Text, Val.ToInt64(txtOrderID.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Enquiry No Already Exist.");
                txtEnquiryNo.Focus();
                txtEnquiryNo.SelectAll();
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

            Order_MasterProperty OrderMasterProperty = new Order_MasterProperty();
            Int64 Code = Val.ToInt64(txtOrderID.Text);
            OrderMasterProperty.Order_ID = Val.ToInt64(Code);
            OrderMasterProperty.Order_Date = Val.DBDate(DTPOrderDate.Text);
            OrderMasterProperty.Enquiry_No = Val.ToInt64(txtEnquiryNo.Text);
            OrderMasterProperty.Confirm_Date = Val.DBDate(DTPConfirmDate.Text);
            OrderMasterProperty.Duration = Val.ToInt64(txtDuration.Text);
            OrderMasterProperty.Delivery_Date = Val.DBDate(DTPDeliveryDate.Text);
            OrderMasterProperty.Is_Applicable = Val.ToBooleanToInt(chkIsApplicable.Checked);
            OrderMasterProperty.AMC_Start_Date = Val.DBDate(DTPAMCStartDate.Text);
            OrderMasterProperty.AMC_End_Date = Val.DBDate(DTPAMCEndDate.Text);

            int IntRes = objOrder.Save(OrderMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Order Details");
                DTPOrderDate.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Order Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Order Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            OrderMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objOrder.GetData_Search();
            grdOrderMaster.DataSource = DTab;
            dgvOrderMaster.BestFitColumns();
        }

        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            DTPOrderDate.Focus();

            //DTPOrderDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            //DTPOrderDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            //DTPOrderDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            //DTPOrderDate.Properties.CharacterCasing = CharacterCasing.Upper;

            //DTPConfirmDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            //DTPConfirmDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            //DTPConfirmDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            //DTPConfirmDate.Properties.CharacterCasing = CharacterCasing.Upper;

            //DTPOrderDate.EditValue = DateTime.Now;
            //DTPConfirmDate.EditValue = DateTime.Now;
        }   

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            if (txtDuration.Text != "0")
            {
                DateTime d = Convert.ToDateTime(DTPConfirmDate.Text.ToString());
                DateTime c = new DateTime();
                int du = Val.ToInt(txtDuration.Text);
                c = d.AddDays(du);
                DTPDeliveryDate.EditValue = Val.DBDate(c.ToShortDateString());
            }
        }

        private void dgvOrderMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvOrderMaster.GetDataRow(e.RowHandle);
                    txtOrderID.Text = Val.ToString(Drow["Order_ID"]);
                    DTPOrderDate.EditValue = Val.DBDate(Drow["Order_Date"].ToString());
                    DTPConfirmDate.EditValue = Val.DBDate(Drow["Confirm_Date"].ToString());
                    txtEnquiryNo.Text = Val.ToString(Drow["Enquiry_No"]);
                    txtDuration.Text = Val.ToString(Drow["Duration"]);
                    DTPDeliveryDate.EditValue = Val.DBDate(Drow["Delivery_Date"].ToString());
                    chkIsApplicable.Checked = Val.ToInt(Drow["Is_Applicable"]).Equals(1) ? true : false;
                    DTPAMCStartDate.EditValue = Val.DBDate(Drow["AMC_Start_Date"].ToString());
                    DTPAMCEndDate.EditValue = Val.DBDate(Drow["AMC_End_Date"].ToString());
                    DTPOrderDate.Focus();
                }
            }
        }

        private void txtEnquiryNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Global.OnKeyPressToOpenPopup(e))
            {
                FrmSearchNew = new Search.FrmSearchNew();

                FrmSearchNew.SearchText = e.KeyChar.ToString();

                //Enquiry_MasterProperty EnquiryMasterProperty = new Enquiry_MasterProperty();
                //EnquiryMasterProperty.Party_Contact = Val.ToInt64(txtEnquiryNo.Text);

                FrmSearchNew.DTab = objEnquiry.GetData();
                FrmSearchNew.SearchField = "Party_Contact";
                //FrmSearchNew.ColumnHeaderCaptions = "COMPANY_CODE=Code,COMPANY_NAME=Name";
                //FrmSearchNew.ColumnsToHide = "";
                FrmSearchNew.ShowDialog();
                e.Handled = true;
                if (FrmSearchNew.DRow != null)
                {
                    txtEnquiryNo.Text = Val.ToInt64(FrmSearchNew.DRow["Party_Contact"]).ToString();
                }
                FrmSearchNew.Hide();
                FrmSearchNew.Dispose();
                FrmSearchNew = null;
            }
        }
    }
}
