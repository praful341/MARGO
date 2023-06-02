using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using MARGO.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmEnquiryMaster : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.Validation Val = new BLL.Validation();
        EnquiryMaster objEnquiry = new EnquiryMaster();

        public FrmEnquiryMaster()
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
            txtEnquiryID.Text = "0";
            txtPartyName.Text = "";
            txtRefName.Text = "";
            txtDescription.Text = "";
            txtPartyEmailID.Text = "";
            txtContactPerson.Text = "";
            txtProductName.Text = "";
            txtQuatedAmt.Text = "0";           
            txtPartyContact.Text = "";
            DTPEnquiryDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPEnquiryDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPEnquiryDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPEnquiryDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPScheduleCallBack.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPScheduleCallBack.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPScheduleCallBack.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPScheduleCallBack.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPEnquiryDate.EditValue = DateTime.Now;
            DTPScheduleCallBack.EditValue = DateTime.Now;

            txtPartyName.Focus();
        }

        #region Validation

        private bool ValSave()
        {
            if (txtPartyName.Text.Length == 0)
            {
                MARGO.Class.Global.Confirm("Party Name Is Required");
                txtPartyName.Focus();
                return false;
            }
            if (!objEnquiry.ISExists(txtPartyName.Text, Val.ToInt64(txtEnquiryID.EditValue)).ToString().Trim().Equals(string.Empty))
            {
                Global.Confirm("Party Name Already Exist.");
                txtPartyName.Focus();
                txtPartyName.SelectAll();
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

            Enquiry_MasterProperty EnquiryMasterProperty = new Enquiry_MasterProperty();
            Int64 Code = Val.ToInt64(txtEnquiryID.Text);
            EnquiryMasterProperty.Enquiry_ID = Val.ToInt64(Code);
            EnquiryMasterProperty.Party_Name = Val.ToString(txtPartyName.Text);
            EnquiryMasterProperty.Enquiry_Date = Val.DBDate(DTPEnquiryDate.Text);
            EnquiryMasterProperty.Ref_Name = Val.ToString(txtRefName.Text);
            EnquiryMasterProperty.Quated_Amt = Val.ToDecimal(txtQuatedAmt.Text);
            EnquiryMasterProperty.Schedule_Call_Back = Val.DBDate(DTPScheduleCallBack.Text);
            EnquiryMasterProperty.Party_Email_ID = Val.ToString(txtPartyEmailID.Text);
            EnquiryMasterProperty.Party_Contact = Val.ToInt64(txtPartyContact.Text);
            EnquiryMasterProperty.Contact_Person = Val.ToString(txtContactPerson.Text);
            EnquiryMasterProperty.Product_Name = Val.ToString(txtProductName.Text);
            EnquiryMasterProperty.Description = Val.ToString(txtDescription.Text);

            int IntRes = objEnquiry.Save(EnquiryMasterProperty);
            if (IntRes == -1)
            {
                Global.Confirm("Error In Save Enquiry Details");
                txtPartyName.Focus();
            }
            else
            {
                if (Code == 0)
                {
                    Global.Confirm("Enquiry Details Data Save Successfully");
                }
                else
                {
                    Global.Confirm("Enquiry Details Data Update Successfully");
                }               
                GetData();
                btnClear_Click(sender, e);
            }
            EnquiryMasterProperty = null;
        }

        public void GetData()
        {
            DataTable DTab = objEnquiry.GetData_Search();
            grdEnquiryMaster.DataSource = DTab;
            dgvEnquiryMaster.BestFitColumns();
        }

        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            GetData();
            btnClear_Click(btnClear, null);
            txtPartyName.Focus();

            DTPEnquiryDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPEnquiryDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPEnquiryDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPEnquiryDate.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPScheduleCallBack.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DTPScheduleCallBack.Properties.Mask.EditMask = "dd/MMM/yyyy";
            DTPScheduleCallBack.Properties.Mask.UseMaskAsDisplayFormat = true;
            DTPScheduleCallBack.Properties.CharacterCasing = CharacterCasing.Upper;

            DTPEnquiryDate.EditValue = DateTime.Now;
            DTPScheduleCallBack.EditValue = DateTime.Now;
        }

        private void dgvEnquiryMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Clicks == 2)
                {
                    DataRow Drow = dgvEnquiryMaster.GetDataRow(e.RowHandle);
                    txtEnquiryID.Text = Val.ToString(Drow["Enquiry_ID"]);
                    txtPartyName.Text = Val.ToString(Drow["Party_Name"]);
                    DTPEnquiryDate.EditValue = Val.DBDate(Drow["Enquiry_Date"].ToString());
                    txtRefName.Text = Val.ToString(Drow["Ref_Name"]);
                    txtQuatedAmt.Text = Val.ToString(Drow["Quated_Amt"]);
                    DTPScheduleCallBack.EditValue = Val.DBDate(Drow["Schedule_Callback"].ToString());
                    txtDescription.Text = Val.ToString(Drow["Description"]);
                    txtPartyEmailID.Text = Val.ToString(Drow["Party_Email"]);
                    txtPartyContact.Text = Val.ToString(Drow["Party_Contact"]);
                    txtContactPerson.Text = Val.ToString(Drow["Contact_Person"]);
                    txtProductName.Text = Val.ToString(Drow["Product_Name"]);
                }
            }
        }
    }
}
