using BLL;
using BLL.FunctionClasses.Master;
using DevExpress.XtraBars;
using MARGO.Class;
using MARGO.Report;
using MARGO.Search;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MARGO
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Validation Val = new Validation();
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();
        EmployeeMaster Emp = new EmployeeMaster();

        public FrmMain()
        {
            InitializeComponent();

            if (!ISActive())
            {
                if (Global.Confirm("Licence Expire...\n Do You Want To Register Product?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    Application.Exit();
                }
                else
                {
                    FrmUnlock frmlock = new FrmUnlock();
                    frmlock.ShowDialog();
                }
            }

            FrmLogin frmlg = new FrmLogin();
            frmlg.ShowDialog();
            if (BLL.GlobalDec.gEmployeeProperty.Employee_Code == 0)
            {
                Application.Exit();
            }
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = false;
            //objBOFormEvents.FormClosing = false;            
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        private void barbtnComp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmCompanyMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmCompanyMaster frmcomp = new FrmCompanyMaster();
                frmcomp.MdiParent = this;
                frmcomp.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }
        private bool ISActive()
        {

            return true;
        }
        private void FrmMain_Activated(object sender, EventArgs e)
        {
            AttachFormEvents();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Global.gMainFormRef = this;
            DevExpress.UserSkins.BonusSkins.Register();
            //    DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.XtraBars.Ribbon.GalleryDropDown skins = new DevExpress.XtraBars.Ribbon.GalleryDropDown();
            skins.Ribbon = ribbonControl1;
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGalleryDropDown(skins);
            barBtnTheme.DropDownControl = skins;
            //this.defaultLookAndFeel1.LookAndFeel.SkinName = "The Asphalt World";  // "Money Twins";
            //this.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins";
            skins.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(gallery_GalleryItemClick);

            Global.Gwidth = this.Width;
            Global.Gheight = this.Height;


            Ribbon.AllowMinimizeRibbon = true;

            //Ribbon.Minimized = true;
            //ribbonControl1.SelectedPage = ribbonPage2;
            barComp.Caption = "Company : " + BLL.GlobalDec.gEmployeeProperty.Company_Name;
            BarBranch.Caption = "Branch : " + BLL.GlobalDec.gEmployeeProperty.Branch_Name;
            barLocation.Caption = "Location : " + BLL.GlobalDec.gEmployeeProperty.Location_Name;
            barDept.Caption = "Department : " + BLL.GlobalDec.gEmployeeProperty.Department_Name;
            barUser.Caption = "User : " + BLL.GlobalDec.gEmployeeProperty.UserName;

            DataTable DTabThemes = Emp.Get_Theme_Master();

            if (DTabThemes.Rows.Count > 0)
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Val.ToString(DTabThemes.Rows[0]["Theme_Name"]);
            }
            else
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Caramel";
            }

            AttachFormEvents();

            if (Global.ChkAdmin())
            { rbnPageSetting.Visible = true; }
            else
            { rbnPageSetting.Visible = false; }

        }

        void gallery_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {

            try

            {
                // MessageBox.Show(e.Item.Tag.ToString());
                Int32 Res = Emp.SaveThemes(e.Item.Tag.ToString());

                if (Res != 0)
                {

                }
            }
            catch (Exception)
            { }
            //using (ConfigManager cfgMgr = new ConfigManager())
            //{
            //    cfgMgr.SetLocalConfigData(Config.LocalConfigValue.SkinName, e.Item.Tag.ToString());
            //}
        }

        private void barbtnBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmBranchMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmBranchMaster frmbranch = new FrmBranchMaster();
                frmbranch.MdiParent = this;
                frmbranch.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnDept_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmDepartmentMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmDepartmentMaster frmDept = new FrmDepartmentMaster();
                frmDept.MdiParent = this;
                frmDept.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmLocationMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmLocationMaster frmLoc = new FrmLocationMaster();
                frmLoc.MdiParent = this;
                frmLoc.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnColor_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmColorMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmColorMaster frmcolor = new FrmColorMaster();
                frmcolor.MdiParent = this;
                frmcolor.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnClarity_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmClarityMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmClarityMaster frmclari = new FrmClarityMaster();
                frmclari.MdiParent = this;
                frmclari.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnShape_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmShapeMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmShapeMaster frmshape = new FrmShapeMaster();
                frmshape.MdiParent = this;
                frmshape.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnSieve_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmSieveMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmSieveMaster frmsieve = new FrmSieveMaster();
                frmsieve.MdiParent = this;
                frmsieve.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmEmployeeMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmEmployeeMaster frmemp = new FrmEmployeeMaster();
                frmemp.MdiParent = this;
                frmemp.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnParty_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmPartyMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmPartyMaster frmParty = new FrmPartyMaster();
                frmParty.MdiParent = this;
                frmParty.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnProcess_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmProcessMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmProcessMaster frmProcess = new FrmProcessMaster();
                frmProcess.MdiParent = this;
                frmProcess.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnCountry_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmCountryMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmCountryMaster frmcountry = new FrmCountryMaster();
                frmcountry.MdiParent = this;
                frmcountry.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnState_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmStateMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmStateMaster frmState = new FrmStateMaster();
                frmState.MdiParent = this;
                frmState.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnCity_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmCityMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmCityMaster frmCity = new FrmCityMaster();
                frmCity.MdiParent = this;
                frmCity.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barmenubtnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Backup();
            //Thread.SpinWait(5000);
            this.Close(); // Application.Exit();
        }

        private void barbtnPartyRate_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmLabourRateMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmLabourRateMaster frmPartyRate = new FrmLabourRateMaster();
                frmPartyRate.MdiParent = this;
                frmPartyRate.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnRough_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmRoughCreationMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmRoughCreationMaster frmRoughCreation = new FrmRoughCreationMaster();
                frmRoughCreation.MdiParent = this;
                frmRoughCreation.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnRoughType_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmRoughTypeMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmRoughTypeMaster frmRoughType = new FrmRoughTypeMaster();
                frmRoughType.MdiParent = this;
                frmRoughType.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnDeptTran_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmDepartmentTransfer)).FirstOrDefault();
            if (k == null)
            {
                FrmDepartmentTransfer frmDeptTransfer = new FrmDepartmentTransfer();
                frmDeptTransfer.MdiParent = this;
                frmDeptTransfer.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnEmpTran_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmEmployeeIssRet)).FirstOrDefault();
            if (k == null)
            {
                FrmEmployeeIssRet frmEmpIssRetTransfer = new FrmEmployeeIssRet();
                frmEmpIssRetTransfer.MdiParent = this;
                frmEmpIssRetTransfer.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmPacket_LOTprep)).FirstOrDefault();
            if (k == null)
            {
                FrmPacket_LOTprep frmDeptTransfer = new FrmPacket_LOTprep();
                frmDeptTransfer.MdiParent = this;
                frmDeptTransfer.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnLotwiseDeptTran_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmCLVMixDeptTransfer)).FirstOrDefault();
            if (k == null)
            {
                FrmCLVMixDeptTransfer frmLotwiseDeptTransfer = new FrmCLVMixDeptTransfer();
                frmLotwiseDeptTransfer.MdiParent = this;
                frmLotwiseDeptTransfer.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnEmployeeIssRet_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmMixLotEmployeeIssRet)).FirstOrDefault();
            if (k == null)
            {
                FrmMixLotEmployeeIssRet frmEmployeeIssRet = new FrmMixLotEmployeeIssRet();
                frmEmployeeIssRet.MdiParent = this;
                frmEmployeeIssRet.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barDept_ItemClick(object sender, ItemClickEventArgs e)
        {
            DepartmentMaster Objdpt = new DepartmentMaster();
            FrmDevExpPopupGrid FrmDevExpPopupGrid = new FrmDevExpPopupGrid();
            DataTable tdt = Objdpt.GetData();
            FrmDevExpPopupGrid.DTab = tdt;
            FrmDevExpPopupGrid.MainGridDetail.DataSource = tdt;
            FrmDevExpPopupGrid.MainGridDetail.Refresh();
            FrmDevExpPopupGrid.Size = new Size(500, 300);
            FrmDevExpPopupGrid.GrdDet.Columns["DEPARTMENT_CODE"].Visible = true;
            FrmDevExpPopupGrid.GrdDet.Columns["LOCATION_NAME"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["ACTIVE"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["REMARK"].Visible = false;
            FrmDevExpPopupGrid.GrdDet.Columns["Location_code"].Visible = false;


            FrmDevExpPopupGrid.ShowDialog();

            if (FrmDevExpPopupGrid.DRow != null)
            {
                foreach (System.Windows.Forms.Form Frm in this.MdiChildren)
                {
                    Frm.Focus();
                    Frm.Hide();
                    Frm.Close();
                    Frm.Dispose();
                }
                GlobalDec.gEmployeeProperty.Department_Code = Val.ToInt64(Val.ToString(FrmDevExpPopupGrid.DRow["Department_Code"]));
                barDept.Caption = "Department : " + Val.ToString(FrmDevExpPopupGrid.DRow["Department_Name"]);
            }
            FrmDevExpPopupGrid.Hide();
            FrmDevExpPopupGrid.Dispose();
            FrmDevExpPopupGrid = null;
        }

        private void barbtnOutsideIssue_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmOutSideIssue)).FirstOrDefault();
            if (k == null)
            {
                FrmOutSideIssue frmOutSideIssue = new FrmOutSideIssue();
                frmOutSideIssue.MdiParent = this;
                frmOutSideIssue.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnOutsideReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmOutSideReceipt)).FirstOrDefault();
            if (k == null)
            {
                FrmOutSideReceipt frmOutSideReceipt = new FrmOutSideReceipt();
                frmOutSideReceipt.MdiParent = this;
                frmOutSideReceipt.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }


        private void BarDeptReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportList frmDeptIssReport = new FrmReportList();
            frmDeptIssReport.MdiParent = Global.gMainFormRef;
            frmDeptIssReport.ShowForm("Department Transfer");

            //var k = MdiChildren.Where(c => c.GetType() == typeof(FrmReportList)).FirstOrDefault();
            //if (k == null)
            //{
            //    FrmReportList frmDeptIssReport = new FrmReportList();
            //    frmDeptIssReport.MdiParent = this;
            //    frmDeptIssReport.ShowForm("Department Transfer");
            //}
            //else
            //{
            //    k.Activate();
            //}
        }

        private void barBtnRptLabrPer_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportList frmDeptIssReport = new FrmReportList();
            frmDeptIssReport.MdiParent = Global.gMainFormRef;
            frmDeptIssReport.ShowForm("Party Transfer");

            //var k = MdiChildren.Where(c => c.GetType() == typeof(FrmReportList)).FirstOrDefault();
            //if (k == null)
            //{
            //    FrmReportList frmDeptIssReport = new FrmReportList();
            //    frmDeptIssReport.MdiParent = this;
            //    frmDeptIssReport.ShowForm("Party Transfer");
            //}
            //else
            //{
            //    k.Activate();
            //}
        }

        private void barBtnPacketDetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmPacketDetail)).FirstOrDefault();
            if (k == null)
            {
                FrmPacketDetail frmPacketDetail = new FrmPacketDetail();
                frmPacketDetail.MdiParent = this;
                frmPacketDetail.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnUpdateLabourRate_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmUpdateLabouRate)).FirstOrDefault();
            if (k == null)
            {
                FrmUpdateLabouRate frmUpdateLabourRate = new FrmUpdateLabouRate();
                frmUpdateLabourRate.MdiParent = this;
                frmUpdateLabourRate.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnPartyOutstanding_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportList frmDeptIssReport = new FrmReportList();
            frmDeptIssReport.MdiParent = Global.gMainFormRef;
            frmDeptIssReport.ShowForm("Party OutStanding");
        }

        private void barBtnRoughTransfer_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportList frmDeptIssReport = new FrmReportList();
            frmDeptIssReport.MdiParent = Global.gMainFormRef;
            frmDeptIssReport.ShowForm("Rough Transfer");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Backup();
        }

        public void Backup()
        {
            try
            {
                ClassINI iniCl = new ClassINI(Application.StartupPath.ToString() + "\\margo.CONFIG");
                string gStrHostName = GlobalDec.Decrypt(iniCl.IniReadValue("LOGIN", "ServerHostName"), true);
                if (gStrHostName == GlobalDec.gStrComputerIP)
                {
                    string Bnm = "Backup_MARGO_" + DateTime.Now.Date.ToShortDateString().Replace("/", "");
                    if ((File.Exists(Application.StartupPath + "\\BackUp\\" + Bnm + ".bak") == false))
                    {
                        if (MessageBox.Show("Do you want to take Backup?", "MARGO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (Directory.Exists(Application.StartupPath + "\\BackUp") == false)
                                Directory.CreateDirectory(Application.StartupPath + "\\BackUp");

                            //      MCSLibrary.ModConnection.MExecuteStr("backup database MARGO  to disk='" + Txtpath.Text + "\\MFull.bak'");
                            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(BLL.DBConnections.ConnectionString);
                            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
                            comm.Connection = conn;
                            if (conn.State == ConnectionState.Closed) { conn.Open(); }
                            comm.CommandText = "backup database  MARGO  to disk = '" + Application.StartupPath + "\\BackUp\\" + Bnm + ".bak'";
                            int i = comm.ExecuteNonQuery();
                            conn.Close();
                            //DataTable tdt = new DataTable();
                            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, tdt, Request);

                            //Process sc = new Process();
                            //sc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            //sc.StartInfo.FileName = Application.StartupPath + "\\7z.exe";
                            //sc.StartInfo.Arguments = " a " + Application.StartupPath.ToString() + "\\" + Bnm + ".MAR" + " " + Application.StartupPath.ToString() + "\\MarFull.bak";
                            //sc.Start();
                            //sc.WaitForExit();

                            //if (File.Exists( Application.StartupPath.ToString() + "\\MarFull.bak"))
                            //    File.Delete( Application.StartupPath.ToString() + "\\MarFull.bak");

                            MessageBox.Show("Backup Successfully Completed.", "MARGO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch { }
        }

        private void barbtnPolishAssortment_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmPolishAssortment)).FirstOrDefault();
            if (k == null)
            {
                FrmPolishAssortment frmPolishAssortment = new FrmPolishAssortment();
                frmPolishAssortment.MdiParent = this;
                frmPolishAssortment.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnRoughRunningPos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmRunningPosition)).FirstOrDefault();
            if (k == null)
            {
                FrmRunningPosition frmRunningPosition = new FrmRunningPosition();
                frmRunningPosition.MdiParent = this;
                frmRunningPosition.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnTransactionUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmUpdateTransaction)).FirstOrDefault();
            if (k == null)
            {
                FrmUpdateTransaction frmUpdateTransaction = new FrmUpdateTransaction();
                frmUpdateTransaction.MdiParent = this;
                frmUpdateTransaction.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barbtnUpdtIssRet_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmPolishCaratUpdate)).FirstOrDefault();
            if (k == null)
            {
                FrmPolishCaratUpdate frmUpdatePolishCarat = new FrmPolishCaratUpdate();
                frmUpdatePolishCarat.MdiParent = this;
                frmUpdatePolishCarat.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnCapital_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmCapitalMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmCapitalMaster FrmCapitalMaster = new FrmCapitalMaster();
                FrmCapitalMaster.MdiParent = this;
                FrmCapitalMaster.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void berBtnCapitalEntry_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmCapitalEntryMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmCapitalEntryMaster FrmCapitalEntryMaster = new FrmCapitalEntryMaster();
                FrmCapitalEntryMaster.MdiParent = this;
                FrmCapitalEntryMaster.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnIncomeEntry_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmIncomeEntry)).FirstOrDefault();
            if (k == null)
            {
                FrmIncomeEntry FrmIncomeEntryMaster = new FrmIncomeEntry();
                FrmIncomeEntryMaster.MdiParent = this;
                FrmIncomeEntryMaster.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void berBtnExpenceEntry_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmExpenseEntry)).FirstOrDefault();
            if (k == null)
            {
                FrmExpenseEntry FrmExpenseEntry = new FrmExpenseEntry();
                FrmExpenseEntry.MdiParent = this;
                FrmExpenseEntry.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnTransactionView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmTransaction_View)).FirstOrDefault();
            if (k == null)
            {
                FrmTransaction_View FrmTransaction_View = new FrmTransaction_View();
                FrmTransaction_View.MdiParent = this;
                FrmTransaction_View.ShowForm("Transaction View");
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnEmployeeIssueReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportList frmDeptIssReport = new FrmReportList();
            frmDeptIssReport.MdiParent = Global.gMainFormRef;
            frmDeptIssReport.ShowForm("Employee Issue Return");
        }

        private void barBtnEnquiry_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmEnquiryMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmEnquiryMaster FrmEnquiryMaster = new FrmEnquiryMaster();
                FrmEnquiryMaster.MdiParent = this;
                FrmEnquiryMaster.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }

        private void barBtnOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            var k = MdiChildren.Where(c => c.GetType() == typeof(FrmOrderMaster)).FirstOrDefault();
            if (k == null)
            {
                FrmOrderMaster FrmOrderMaster = new FrmOrderMaster();
                FrmOrderMaster.MdiParent = this;
                FrmOrderMaster.ShowForm();
            }
            else
            {
                k.Activate();
            }
        }
    }
}
