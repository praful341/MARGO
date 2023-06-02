using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Drawing;


namespace KGKDiamond.Class
{
    public class DevExpressGrid
    {

        protected GridView _view;
        protected ArrayList selection;
        private GridColumn column;
        private RepositoryItemCheckEdit edit;
        
        const int CheckboxIndent = 4;
        public DevExpressGrid()
        {
            selection = new ArrayList();
        }


        public DevExpressGrid(GridView view__1)
            : this()
        {
            View = view__1;

        }
        public GridView View
        {
            get { return _view; }
            set
            {
                if (!object.ReferenceEquals(_view, value))
                {               
                    Detach();
                    Attach(value);
                }
            }
        }
        public GridColumn CheckMarkColumn
        {
            get { return column; }
        }


        public int SelectedCount
        {
            get { return selection.Count; }
        }

        public int GetSelectedIndex(object row)
        {
            return selection.IndexOf(row);
        }
        public void ClearSelection()
        {
            selection.Clear();
            Invalidate();
        }
        public void SelectAll()
        {
            selection.Clear();
            // fast (won't work if the grid is filtered)
            //if(_view.DataSource is ICollection)
            //	selection.AddRange(((ICollection)_view.DataSource));
            //else
            // slow:
            for (int i = 0; i <= _view.DataRowCount - 1; i++)
            {
                selection.Add(_view.GetRow(i));
            }
            Invalidate();
        }
        public void SelectGroup(int rowHandle, bool @select)
        {
            if (IsGroupRowSelected(rowHandle) && @select)
            {
                return;
            }
            for (int i = 0; i <= _view.GetChildRowCount(rowHandle) - 1; i++)
            {
                int childRowHandle = _view.GetChildRowHandle(rowHandle, i);
                if (_view.IsGroupRow(childRowHandle))
                {
                    SelectGroup(childRowHandle, @select);
                }
                else
                {
                    SelectRow(childRowHandle, @select, false);
                }
            }
            Invalidate();
        }
        public void SelectRow(int rowHandle, bool @select)
        {
            SelectRow(rowHandle, @select, true);
        }
        public void InvertRowSelection(int rowHandle)
        {
            if (View.IsDataRow(rowHandle))
            {
                SelectRow(rowHandle, !IsRowSelected(rowHandle));
            }
            if (View.IsGroupRow(rowHandle))
            {
                SelectGroup(rowHandle, !IsGroupRowSelected(rowHandle));
            }
        }
        public bool IsGroupRowSelected(int rowHandle)
        {
            for (int i = 0; i <= _view.GetChildRowCount(rowHandle) - 1; i++)
            {
                int row = _view.GetChildRowHandle(rowHandle, i);
                if (_view.IsGroupRow(row))
                {
                    if (!IsGroupRowSelected(row))
                    {
                        return false;
                    }
                }
                else if (!IsRowSelected(row))
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsRowSelected(int rowHandle)
        {
            if (_view.IsGroupRow(rowHandle))
            {
                return IsGroupRowSelected(rowHandle);
            }

            object row = _view.GetRow(rowHandle);
            return GetSelectedIndex(row) != -1;
        }
        public ArrayList GetSelectedArrayList()
        {
            return selection;
        }

        protected virtual void Attach(GridView view)
        {
            if (view == null)
            {
                return;
            }
            selection.Clear();
            this._view = view;
           
            try
            {

                view.BeginUpdate();

                //foreach (DevExpress.XtraEditors.Repository.RepositoryItem item in view.GridControl.RepositoryItems)
                //{
                //    if (item.Name == "CheckEdit")
                //    {
                //        view.EndUpdate();
                //        return;
                //    }
                //}

                edit = view.GridControl.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;

                column = view.Columns.Add();
                column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                column.Visible = true;
                column.VisibleIndex = 0;
                column.FieldName = "CheckMarkSelection";
                column.Caption = "Mark";

                column.OptionsColumn.ShowCaption = false;
                column.OptionsColumn.AllowEdit = false;
                column.OptionsColumn.AllowSize = false;
                column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
                column.Width = GetCheckBoxWidth();
                column.ColumnEdit = edit;

                view.Click += View_Click;
                view.CustomDrawColumnHeader += View_CustomDrawColumnHeader;
                view.CustomDrawGroupRow += View_CustomDrawGroupRow;
                view.CustomUnboundColumnData += view_CustomUnboundColumnData;
                view.KeyDown += view_KeyDown;
                view.RowStyle += view_RowStyle;

                //view.Click += New AddHandler(AddressOf View_Click)
                //view.CustomDrawColumnHeader += New ColumnHeaderCustomDrawEventHandler(AddressOf View_CustomDrawColumnHeader)
                //view.CustomDrawGroupRow += New RowObjectCustomDrawEventHandler(AddressOf View_CustomDrawGroupRow)
                //view.CustomUnboundColumnData += New CustomColumnDataEventHandler(AddressOf view_CustomUnboundColumnData)
                //view.KeyDown += New KeyEventHandler(AddressOf view_KeyDown)
                //view.RowStyle += New RowStyleEventHandler(AddressOf view_RowStyle)

            }
            finally
            {
                view.EndUpdate();
            }
        }
        protected virtual void Detach()
        {
            if (_view == null)
            {
                return;
            }
            if (column != null)
            {
                column.Dispose();
            }
            if (edit != null)
            {
                _view.GridControl.RepositoryItems.Remove(edit);
                edit.Dispose();
            }

            View.Click += View_Click;
            View.CustomDrawColumnHeader += View_CustomDrawColumnHeader;
            View.CustomDrawGroupRow += View_CustomDrawGroupRow;
            View.CustomUnboundColumnData += view_CustomUnboundColumnData;
            View.KeyDown += view_KeyDown;
            View.RowStyle += view_RowStyle;

            //_view.Click -= New EventHandler(AddressOf View_Click)
            //_view.CustomDrawColumnHeader -= New ColumnHeaderCustomDrawEventHandler(AddressOf View_CustomDrawColumnHeader)
            //_view.CustomDrawGroupRow -= New RowObjectCustomDrawEventHandler(AddressOf View_CustomDrawGroupRow)
            //_view.CustomUnboundColumnData -= New CustomColumnDataEventHandler(AddressOf view_CustomUnboundColumnData)
            //_view.KeyDown -= New KeyEventHandler(AddressOf view_KeyDown)
            //_view.RowStyle -= New RowStyleEventHandler(AddressOf view_RowStyle)

            _view = null;
        }
        protected int GetCheckBoxWidth()
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            int width = 0;
            GraphicsInfo.Default.AddGraphics(null);
            try
            {
                width = info.CalcBestFit(GraphicsInfo.Default.Graphics).Width;
            }
            finally
            {
                GraphicsInfo.Default.ReleaseGraphics();
            }
            return width + CheckboxIndent * 2;
        }
        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info = default(DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo);
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter = default(DevExpress.XtraEditors.Drawing.CheckEditPainter);
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args = default(DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs);
            info = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            painter = edit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }
        private void Invalidate()
        {
            _view.CloseEditor();
            _view.BeginUpdate();
            _view.EndUpdate();
        }
        private void SelectRow(int rowHandle, bool @select, bool invalidate__1)
        {
            if (IsRowSelected(rowHandle) == @select)
            {
                return;
            }
            object row = _view.GetRow(rowHandle);

            if (@select)
            {
                selection.Add(row);
            }
            else
            {
                selection.Remove(row);
            }

            if (invalidate__1)
            {
                Invalidate();
            }
        }
        private void view_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (object.ReferenceEquals(e.Column, CheckMarkColumn))
            {
                if (e.IsGetData)
                {
                    e.Value = IsRowSelected(View.GetRowHandle(e.ListSourceRowIndex));
                }
                else
                {
                    SelectRow(View.GetRowHandle(e.ListSourceRowIndex), Convert.ToBoolean(e.Value));
                }
            }
        }
        private void view_KeyDown(object sender, KeyEventArgs e)
        {
            if (!object.ReferenceEquals(View.FocusedColumn, column) || e.KeyCode != Keys.Space)
            {
                return;
            }
            InvertRowSelection(View.FocusedRowHandle);
        }
        private void View_Click(object sender, EventArgs e)
        {
            GridHitInfo info = default(GridHitInfo);
            Point pt = _view.GridControl.PointToClient(Control.MousePosition);
            info = _view.CalcHitInfo(pt);
            if (object.ReferenceEquals(info.Column, column))
            {
                if (info.InColumn)
                {
                    if (SelectedCount == _view.DataRowCount)
                    {
                        ClearSelection();
                    }
                    else
                    {
                        SelectAll();
                    }
                }
                if (info.InRowCell)
                {
                    InvertRowSelection(info.RowHandle);
                }
            }
            if (info.InRow && _view.IsGroupRow(info.RowHandle) && info.HitTest != GridHitTest.RowGroupButton)
            {
                InvertRowSelection(info.RowHandle);
            }
        }

        private void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (object.ReferenceEquals(e.Column, column))
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, SelectedCount == _view.DataRowCount);
                e.Handled = true;

            }

        }
        private void View_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info = default(DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo);
            info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;

            info.GroupText = "         " + info.GroupText.TrimStart();
            e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
            e.Painter.DrawObject(e.Info);

            Rectangle r = info.ButtonBounds;
            r.Offset(r.Width + CheckboxIndent * 2 - 1, 0);
            DrawCheckBox(e.Graphics, r, IsGroupRowSelected(e.RowHandle));
            e.Handled = true;
        }
        private void view_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (IsRowSelected(e.RowHandle))
            {
                e.Appearance.BackColor = SystemColors.Highlight;
                e.Appearance.BackColor2 = SystemColors.Highlight;
                e.Appearance.ForeColor = SystemColors.HighlightText;                
            }
        }
    }
}
