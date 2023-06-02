using KGKDiamond.Class;
using System;
using System.Windows.Forms;

namespace MARGO.Search
{
    public partial class FrmSearch : Form
    {
        public FrmSearchProperty _FrmSearchProperty;
        BLL.Validation Val = new BLL.Validation();
        BLL.FormEvents objBOFormEvents = new BLL.FormEvents();

        #region Property Seeting

        /// <summary>
        /// true for Displat Addnew Link Button
        /// </summary>
        private bool _AllowAddNew = false;

        public bool AllowAddNew
        {
            get { return _AllowAddNew; }
            set { _AllowAddNew = value; }
        }

        // Add : 21-05-2014 : Narendra
        public Form FormObjToBeOpen;
        public string SearchFieldControlName = "";

        private bool _AddNewRecord = false;
        public bool AddNewRecord
        {
            get { return _AddNewRecord; }
            set { _AddNewRecord = value; }
        }
        //End : 21-05-2014 : Narendra-------
        private bool _ISPostBack = false;

        public bool ISPostBack
        {
            get { return _ISPostBack; }
            set { _ISPostBack = value; }
        }


        /// <summary>
        /// true for display Picture Box 
        /// </summary>
        private bool _AllowPictureBox = false;

        public bool AllowPictureBox
        {
            get { return _AllowPictureBox; }
            set { _AllowPictureBox = value; }
        }


        private string _Photo_Field_Name;

        public string Photo_Field_Name
        {
            get { return _Photo_Field_Name; }
            set { _Photo_Field_Name = value; }
        }

        /// <summary>
        /// By Default First Column is hide.
        /// toi Unhide first Column then Set it to false
        /// </summary>
        private bool _AllowFirstColumnHide = true;

        public bool AllowFirstColumnHide
        {
            get { return _AllowFirstColumnHide; }
            set { _AllowFirstColumnHide = value; }
        }

        /// <summary>
        /// If want to Hide Specific Column Then Pass it
        /// If Multiple Columns Is There Then Pass Like "Column1,Column2.." Like That
        /// </summary>
        private string _ColumnsToHide = "";

        public string ColumnsToHide
        {
            get { return _ColumnsToHide; }
            set { _ColumnsToHide = value; }
        }


        #endregion

        #region Conunstructor

        public FrmSearch()
        {
            InitializeComponent();
        }

        //public FrmSearch(FrmSearchProperty pFrmSearchProperty)
        //{
        //    InitializeComponent();
        //    _FrmSearchProperty = pFrmSearchProperty;
        //}

        #endregion

        #region Form Events

        private void FrmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    _FrmSearchProperty.FlagEsc = false;
            //    this.Close();
            //}

            //try
            //{
            //    if ((e.KeyCode == Keys.Up))
            //    {
            //        if ((dgvSearch.RowCount > 0))
            //        {
            //            int i = dgvSearch.SelectedRows[0].Index;
            //            if ((i > 0))
            //            {
            //                dgvSearch.Rows[(i - 1)].Selected = true;
            //                dgvSearch.FirstDisplayedScrollingRowIndex = (i - 1);
            //                txtSearch.Focus();
            //            }
            //        }
            //    }
            //    else if ((e.KeyCode == Keys.Down))
            //    {
            //        dgvSearch.Select();
            //        if ((dgvSearch.RowCount > 0))
            //        {
            //            int i = dgvSearch.SelectedRows[0].Index;
            //            int total = (dgvSearch.Rows.Count - 1);
            //            if ((i < total))
            //            {
            //                dgvSearch.Rows[(i + 1)].Selected = true;
            //                dgvSearch.FirstDisplayedScrollingRowIndex = (i + 1);
            //                txtSearch.Focus();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    KGKDiamond.Class.Global.Confirm(ex.Message.ToString());                
            //}

        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            //if (AllowAddNew == true)
            //{
            //    lblAddNew.Visible = true;
            //}
            //else
            //{
            //    lblAddNew.Visible = false;
            //}

            //if (AllowPictureBox == true)
            //{
            //    PanelImage.Visible = true;                
            //}
            //else
            //{
            //    PanelImage.Visible = false;                
            //}   

            //GridFill();
            //if (AllowFirstColumnHide == true)
            //{
            //    dgvSearch.Columns[0].Visible = false;
            //}
            
            //BarCodeInVisible();            
            //ChangeData();
            //txtSearch.Focus();            
            
            //txtSearch.SelectionStart = txtSearch.Text.Length;
            //txtSearch.SelectionLength = 0;
            //txtSearch.DeselectAll();

            //foreach (DataGridViewColumn Column in this.dgvSearch.Columns)
            //{
            //    if ( _ColumnsToHide.Contains(Column.Name.ToString()) ==  true)
            //    {
            //        Column.Visible = false;
            //    }
            //    if (Column.HeaderText != "")
            //    {
            //        Column.HeaderText = Column.HeaderText.Replace("_", " ");
            //        Column.HeaderText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Column.HeaderText.ToLower());
            //    }
            //}
        }

        #endregion

        #region Events

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ChangeData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectRow();
            }
        }

        #endregion

        #region Grid Events

        private void dgvSearch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectRow();
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow();
        }

        private void dgvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectRow();
            }
        }

        
        
        #endregion

        #region User Fuinction


        public void GridFill()
        {   
            //dgvSearch.DataSource = null;
            //dgvSearch.SetDataBinding(_FrmSearchProperty.dtTable, true);

            //DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            //checkColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //checkColumn.CellTemplate = new DataGridViewCheckBoxCell();
            //checkColumn.FalseValue = true;
            //checkColumn.HeaderText = "SelectCompany";
            //checkColumn.Name = "CheckBoxes";
            //checkColumn.TrueValue = true;
            //checkColumn.FalseValue = false;
            //checkColumn.ReadOnly = false;
            //dgvSearch.Columns.Add(checkColumn);
        }

        private void SelectRow()
        {
            //try
            //{
            //        if ((dgvSearch.SelectedRows.Count > 0))
            //        {
            //            _FrmSearchProperty.dtrow = dgvSearch.SelectedRows[0];
            //            _FrmSearchProperty.FlagEsc = true;
            //            this.Close();
            //        }
            //        else
            //        {
            //            //Add : 21-05-2014 : Narendra
            //            if (AddNewRecord == true)
            //            {
            //                if (Global.Confirm("No One Item Selected.\n\nYou Want To Create : [  " + txtSearch.Text + "  ] ?") == System.Windows.Forms.DialogResult.Yes)
            //                {
                               
            //                    if (!SearchFieldControlName.Equals(string.Empty))
            //                    {
            //                        FormObjToBeOpen.Controls.Find(SearchFieldControlName, true)[0].Text = txtSearch.Text;
            //                        FormObjToBeOpen.StartPosition = FormStartPosition.CenterParent;
            //                        FormObjToBeOpen.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            //                        FormObjToBeOpen.Text = " ADD : " + FormObjToBeOpen.Text;
            //                        this.Hide();
            //                        if (FormObjToBeOpen.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //                        {
            //                            txtSearch.Text = Global.gFrmSearchProperty.SearchText;
            //                            _FrmSearchProperty.dtTable = Global.gFrmSearchProperty.dtTable;
            //                            ChangeData();
            //                            _FrmSearchProperty.dtrow = dgvSearch.SelectedRows[0];
            //                            _FrmSearchProperty.FlagEsc = true;
            //                            this.Close();

            //                        }
                                    
            //                    }
            //                    else
            //                        Global.Confirm("Search Field Control Name Property Not Set.");
            //                }
            //                else
            //                {
                                
            //                    _FrmSearchProperty.FlagEsc = false;
            //                    this.Close();
            //                    return;
            //                }
            //            }//End : 21-05-2014 : Narendra --------------------------
            //            else if (ISPostBack == true)
            //            {
            //                if (Global.Confirm("No One item selected.\n\nYou Want To Post Back [ " + txtSearch.Text + " ] value ?") == System.Windows.Forms.DialogResult.Yes)
            //                {
            //                    _FrmSearchProperty.FlagEsc = false;
            //                    this.Close();
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                KGKDiamond.Class.Global.Confirm("No One item selected.");
            //            }

            //            _FrmSearchProperty.FlagEsc = false;
            //            this.Close();
            //        }
                
            //}
            //catch (Exception ex)
            //{
            //   // KGKDiamond.Class.Global.Confirm(ex.Message.ToString());                
            //}
        }

        private void ChangeData()
        {
            //try
            //{
            //    DataView myDataView = new DataView(_FrmSearchProperty.dtTable);

            //    string[] StrSplit = _FrmSearchProperty.SearchField.Split(',');

            //    string RowFilter = "";
            //    for (int IntI = 0; IntI < StrSplit.Length; IntI++)
            //    {
            //        RowFilter += " Convert(" + StrSplit[IntI] + ",'System.String')" + " Like " + "'" + txtSearch.Text + "%' ";

            //        if (IntI  != StrSplit.Length -1 )
            //        {
            //            RowFilter += " Or ";
            //        }
            //    }

            //    myDataView.RowFilter = RowFilter;

            //    //myDataView.RowFilter = "Convert(" + _FrmSearchProperty.SearchField + ",'System.String')" + " Like " + "'" + txtSearch.Text + "%'";
                
            //    //myDataView.Sort = _FrmSearchProperty.SearchField;
            //    dgvSearch.DataSource = myDataView;
            //    //dgvSearch.Sort(dgvSearch.Columns[_FrmSearchProperty.SearchField], _FrmSearchProperty.SearchOrder);
            //}
            //catch (Exception ex)
            //{
            //  //  KGKDiamond.Class.Global.Confirm(ex.ToString());
            //}
        }

        private void BarCodeInVisible()
        {
            //int i;
            //for (i = 0; (i<= (dgvSearch.Columns.Count - 1)); i++)
            //{
            //    if ((dgvSearch.Columns[i].HeaderText == "Barcode"))
            //    {
            //        dgvSearch.Columns[i].Visible = false;
            //    }
            //}
        }

        #endregion

        private void dgvSearch_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //     if (dgvSearch.CurrentRow == null)
            //{
            //    return;
            //}
            //if (_AllowPictureBox == true)
            //{
            //    bool BoolFind = false;
            //    foreach (DataGridViewColumn Col in dgvSearch.Columns)
            //    {
            //        if (Col.Name == _Photo_Field_Name)
            //        {
            //            BoolFind = true;
            //            break;
            //        }
            //    }
            //    if (BoolFind)
            //    {
            //        if (Val.ToString(dgvSearch.CurrentRow.Cells[Photo_Field_Name].Value) == "")
            //        {
            //            return;
            //        }
            //        if (PictBox.Image != null)
            //        {
            //            PictBox.Image.Dispose();
            //            PictBox.Image = null;
            //        }

            //        string StrSourceFile = BLL.GlobalDec.WebServiceDownloadUrl + Val.ToString(dgvSearch.CurrentRow.Cells[Photo_Field_Name].Value);
            //        string StrDestinationFile = Application.StartupPath + "\\" + "Download.jpeg";

            //        if (File.Exists(StrDestinationFile) == true)
            //        {
            //            File.Delete(StrDestinationFile);
            //        }

            //        Microsoft.VisualBasic.Devices.Network m = new Microsoft.VisualBasic.Devices.Network();
            //        m.DownloadFile(StrSourceFile, StrDestinationFile, "", "", false, 100, true);

            //        PictBox.Image = Image.FromFile(StrDestinationFile);

            //        m = null;                    
            //    }
            //}
            //}
            //catch (Exception ex)
            //{
            //  //  Global.Confirm(ex.Message.ToString());
            //}
           
        }

        private void FrmSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void lblClose_Click_1(object sender, EventArgs e)
        {

        }

        

    
    }
}
