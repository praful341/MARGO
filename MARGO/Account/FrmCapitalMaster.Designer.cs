﻿namespace MARGO
{
    partial class FrmCapitalMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCapitalMaster));
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.txtCapitalName = new DevExpress.XtraEditors.TextEdit();
            this.txtCapitalCode = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblCapitalCode = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dgvCapitalMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCapitalMaster = new DevExpress.XtraGrid.GridControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapitalName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapitalCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapitalMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCapitalMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.txtCapitalName);
            this.panelControl5.Controls.Add(this.txtCapitalCode);
            this.panelControl5.Controls.Add(this.txtRemark);
            this.panelControl5.Controls.Add(this.labelControl4);
            this.panelControl5.Controls.Add(this.panelControl6);
            this.panelControl5.Controls.Add(this.labelControl2);
            this.panelControl5.Controls.Add(this.lblCapitalCode);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(253, 22);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(520, 328);
            this.panelControl5.TabIndex = 0;
            // 
            // txtCapitalName
            // 
            this.txtCapitalName.EnterMoveNextControl = true;
            this.txtCapitalName.Location = new System.Drawing.Point(111, 45);
            this.txtCapitalName.Name = "txtCapitalName";
            this.txtCapitalName.Properties.Appearance.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapitalName.Properties.Appearance.Options.UseFont = true;
            this.txtCapitalName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCapitalName.Size = new System.Drawing.Size(250, 22);
            this.txtCapitalName.TabIndex = 1;
            // 
            // txtCapitalCode
            // 
            this.txtCapitalCode.EditValue = "0";
            this.txtCapitalCode.Enabled = false;
            this.txtCapitalCode.EnterMoveNextControl = true;
            this.txtCapitalCode.Location = new System.Drawing.Point(111, 15);
            this.txtCapitalCode.Name = "txtCapitalCode";
            this.txtCapitalCode.Properties.Appearance.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapitalCode.Properties.Appearance.Options.UseFont = true;
            this.txtCapitalCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCapitalCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCapitalCode.Size = new System.Drawing.Size(250, 22);
            this.txtCapitalCode.TabIndex = 0;
            // 
            // txtRemark
            // 
            this.txtRemark.EditValue = "";
            this.txtRemark.EnterMoveNextControl = true;
            this.txtRemark.Location = new System.Drawing.Point(111, 76);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.Appearance.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Properties.Appearance.Options.UseFont = true;
            this.txtRemark.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemark.Size = new System.Drawing.Size(250, 49);
            this.txtRemark.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 87);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 17);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Remark";
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btnExit);
            this.panelControl6.Controls.Add(this.btnClear);
            this.panelControl6.Controls.Add(this.btnSave);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(2, 282);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(516, 44);
            this.panelControl6.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.Location = new System.Drawing.Point(224, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 32);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "&Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(116, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 32);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(8, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(91, 17);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Capital Name";
            // 
            // lblCapitalCode
            // 
            this.lblCapitalCode.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapitalCode.Appearance.Options.UseFont = true;
            this.lblCapitalCode.Location = new System.Drawing.Point(12, 18);
            this.lblCapitalCode.Name = "lblCapitalCode";
            this.lblCapitalCode.Size = new System.Drawing.Size(87, 17);
            this.lblCapitalCode.TabIndex = 4;
            this.lblCapitalCode.Text = "Capital Code";
            // 
            // panelControl4
            // 
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(253, 350);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(520, 11);
            this.panelControl4.TabIndex = 12;
            // 
            // panelControl3
            // 
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(773, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(11, 361);
            this.panelControl3.TabIndex = 11;
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(242, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(11, 361);
            this.panelControl2.TabIndex = 10;
            // 
            // dgvCapitalMaster
            // 
            this.dgvCapitalMaster.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvCapitalMaster.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvCapitalMaster.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgvCapitalMaster.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgvCapitalMaster.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgvCapitalMaster.Appearance.FooterPanel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCapitalMaster.Appearance.FooterPanel.Options.UseFont = true;
            this.dgvCapitalMaster.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCapitalMaster.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvCapitalMaster.Appearance.Row.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCapitalMaster.Appearance.Row.Options.UseFont = true;
            this.dgvCapitalMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn6});
            this.dgvCapitalMaster.GridControl = this.grdCapitalMaster;
            this.dgvCapitalMaster.Name = "dgvCapitalMaster";
            this.dgvCapitalMaster.OptionsBehavior.Editable = false;
            this.dgvCapitalMaster.OptionsBehavior.ReadOnly = true;
            this.dgvCapitalMaster.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvCapitalMaster.OptionsView.ColumnAutoWidth = false;
            this.dgvCapitalMaster.OptionsView.ShowAutoFilterRow = true;
            this.dgvCapitalMaster.OptionsView.ShowFooter = true;
            this.dgvCapitalMaster.OptionsView.ShowGroupPanel = false;
            this.dgvCapitalMaster.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.dgvCountryMaster_RowClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Capital Code";
            this.gridColumn1.FieldName = "Capital_Code";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Capital";
            this.gridColumn2.FieldName = "Capital_Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Remark";
            this.gridColumn6.FieldName = "Remark";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // grdCapitalMaster
            // 
            this.grdCapitalMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCapitalMaster.Location = new System.Drawing.Point(0, 0);
            this.grdCapitalMaster.MainView = this.dgvCapitalMaster;
            this.grdCapitalMaster.Name = "grdCapitalMaster";
            this.grdCapitalMaster.Size = new System.Drawing.Size(233, 334);
            this.grdCapitalMaster.TabIndex = 0;
            this.grdCapitalMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvCapitalMaster});
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(253, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(520, 22);
            this.panelControl1.TabIndex = 13;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockPanel1.ID = new System.Guid("74102c80-f4da-4031-9a0c-9d6752ffc31e");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(242, 200);
            this.dockPanel1.Size = new System.Drawing.Size(242, 361);
            this.dockPanel1.Text = "Capital Master";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.grdCapitalMaster);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(233, 334);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // FrmCapitalMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.panelControl5);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.dockPanel1);
            this.KeyPreview = true;
            this.Name = "FrmCapitalMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capital Master";
            this.Load += new System.EventHandler(this.FrmCountryMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapitalName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCapitalCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCapitalMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCapitalMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblCapitalCode;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvCapitalMaster;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl grdCapitalMaster;
        private DevExpress.XtraEditors.TextEdit txtCapitalName;
        private DevExpress.XtraEditors.TextEdit txtCapitalCode;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}