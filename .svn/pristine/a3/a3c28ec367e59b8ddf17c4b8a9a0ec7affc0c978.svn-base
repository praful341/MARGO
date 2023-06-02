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

namespace MARGO
{
    public partial class FrmPacketDetail : Form
    {
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        BLL.FormPer ObjPer = new BLL.FormPer();
        BLL.Validation Val = new BLL.Validation();
        PacketMaster ObjPacket = new PacketMaster();
        //DepartmentMaster objDepartment = new DepartmentMaster();
        //SieveMaster objSieve = new SieveMaster();
        //ClarityMaster objClarity = new ClarityMaster();
        //DataTable DTab = new DataTable();
        //PacketMaster ObjPacket = new PacketMaster();

        public FrmPacketDetail()
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
            this.Dispose();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ListBarcode.Items.Clear();
            txtBarcode.Text = "";
            GridViewPacketDetail.DataSource = null;
            GridViewPacketDetail.RefreshDataSource();
            GridViewPacketDetail.Refresh();

            while (GrdDet.GroupedColumns.Count != 0)
            {
                GrdDet.GroupedColumns[GrdDet.GroupedColumns.Count - 1].UnGroup();
            }

            txtBarcode.Focus();
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAll.Checked == true)
            {
                for (int i = 0; i < ListBarcode.Items.Count; i++)
                    ListBarcode.Items[i].CheckState = CheckState.Checked;
            }
            else
            {
                for (int i = 0; i < ListBarcode.Items.Count; i++)
                    ListBarcode.Items[i].CheckState = CheckState.Unchecked;
            }
        }

        private void FrmPacketDetail_Shown(object sender, EventArgs e)
        {
            Global.LOOKUPRough(LookupRoughName);
            Global.LOOKUPRoughTypeCode(LookupRoughType);
            Global.LOOKUPShape(LookupShapeName);
            Global.LOOKUPSieve(LookupSieve);
            Global.LOOKUPColor(LookupColor);
            Global.LOOKUPClarity(LookUpClvClarity, "Clv");
            Global.LOOKUPClarity(LookUpMfgClarity, "Mfg");
            txtBarcode.Focus();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            DataTable DTabBarcode = new DataTable();

            this.Cursor = Cursors.WaitCursor;
            foreach (CheckedListBoxItem itemRow in this.ListBarcode.Items)
            {
                if (itemRow.CheckState == CheckState.Checked)
                {
                    DataTable DTabBarcode2 = ObjPacket.GetData(itemRow.Value.ToString());
                    DTabBarcode.Merge(DTabBarcode2);
                }
            }
            this.Cursor = Cursors.Default;

            if (DTabBarcode.Rows.Count == 0)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            GridViewPacketDetail.DataSource = DTabBarcode;
            GridViewPacketDetail.RefreshDataSource();
            GridViewPacketDetail.Refresh();

            GrdDet.Columns["BARCODE"].Group();

            GrdDet.BestFitColumns();
            GrdDet.ExpandAllGroups();

            GrdDet.Columns["NO"].SortOrder = ColumnSortOrder.Ascending;


            for (int IntI = 0; IntI < GrdDet.DataRowCount; IntI++)
            {
                GrdDet.SetMasterRowExpanded(IntI, true);
            }

            this.Cursor = Cursors.Default;
        }

        private void txtBarcode_Validated(object sender, EventArgs e)
        {
            if (txtBarcode.Text == "")
            {
                return;
            }

            if (new BLL.FunctionClasses.Transaction.PacketMaster().ISExists(txtBarcode.Text) == false)
            {
                //if (new BLL.FunctionClasses.Transaction.MfgMixFactoryPacketMaster().ISExists(txtBarcode.Text) == false)
                //{
                txtBarcode.Text = "";
                txtBarcode.Focus();
                return;
                // }
            }


            Boolean ISExists = false;
            foreach (CheckedListBoxItem iTem in ListBarcode.Items)
            {
                if (iTem.Value.ToString() == txtBarcode.Text.ToString())
                {
                    ISExists = true;
                    break;
                }
            }
            if (ISExists == false)
            {
                CheckedListBoxItem itm = new CheckedListBoxItem(txtBarcode.Text, true);
                itm.Value = txtBarcode.Text;
                ListBarcode.Items.Add(itm);

            }
            txtBarcode.Text = "";
            txtBarcode.Focus();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
           
            Packet_MasterProperty Property = new Packet_MasterProperty();

            Property.Rough_Name = Val.ToString(LookupRoughName.EditValue);
            Property.Rough_Type_Code = Val.ToInt64(LookupRoughType.EditValue);
            Property.Sieve_Code = Val.ToInt64(LookupSieve.EditValue);
            Property.Shape_Code = Val.ToInt64(LookupShapeName.EditValue);
            Property.Color_Code = Val.ToInt64(LookupColor.EditValue);
            Property.Mfg_Clarity_Code = Val.ToInt64(LookUpMfgClarity.EditValue);
            Property.Clv_Clarity_Code = Val.ToInt64(LookUpClvClarity.EditValue);
            Property.Comp_No = Val.ToString(txtCompanyNo.EditValue);
            Property.From_Pcs = Val.Val(txtFromIssuePcs.EditValue);
            Property.To_Pcs = Val.Val(txtToIssuePcs.EditValue);
            Property.From_Carat = Val.Val(txtFromIssueCarat.EditValue);
            Property.To_Carat = Val.Val(txtToIssueCarat.EditValue);
            Property.EXP_Per = Val.Val(txtExpPer.EditValue);
            Property.DM_Per = Val.Val(txtDmPer.EditValue);
            //Property.To_Party_Code = Val.ToInt64(LookupToParty.EditValue);

            DataTable DTabBarcode = ObjPacket.GetFiltedData(Property);

            ListBarcode.Items.Clear();
            foreach (DataRow Dr in DTabBarcode.Rows)
            {
                CheckedListBoxItem iTem = new CheckedListBoxItem();
                iTem.Value = Val.ToString(Dr["BARCODE"]);
                ListBarcode.Items.Add(iTem);
            }
        }
    }
}
