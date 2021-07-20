using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BloodAnalysisApplication_Client.UserInterface
{
    internal class ApplicationDataGridViewCustomer
    {
        private DataGridView dataTable;

        public ApplicationDataGridViewCustomer(DataGridView _dataTable)
        {
            dataTable = _dataTable;
            InitDataGridViewStyle();
        }

        public void AddDataGridViewColumn(DataGridViewColumn typeColumn,
            string headerText, string columnName, int columnWidth)
        {
            DataGridViewColumn newColumn = typeColumn;
            newColumn.HeaderText = headerText;
            newColumn.Name = columnName;
            newColumn.Width = columnWidth;
            newColumn.MinimumWidth = columnWidth;
            newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newColumn.ReadOnly = true;
            newColumn.Resizable = DataGridViewTriState.False;
            newColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataTable.Columns.Add(newColumn);
        }

        private void InitDataGridViewStyle()
        {
            dataTable.AllowUserToAddRows = false;
            dataTable.AllowUserToDeleteRows = false;
            dataTable.AllowUserToResizeColumns = false;
            dataTable.AllowUserToResizeRows = false;
            dataTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataTable.BackgroundColor = SystemColors.Control;
            dataTable.ColumnHeadersHeight = 25;
            dataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataTable.Enabled = false;
            dataTable.EnableHeadersVisualStyles = false;
            dataTable.MultiSelect = false;
            dataTable.ReadOnly = true;
            dataTable.RowHeadersVisible = false;
            dataTable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataTable.RowTemplate.ReadOnly = true;
            dataTable.ScrollBars = ScrollBars.None;
            dataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataTable.ShowCellToolTips = false;
            dataTable.DefaultCellStyle =
                DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter,
                                    SystemColors.ControlLightLight,
                                    new Font("Times New Roman", 9F, FontStyle.Regular,
                                        GraphicsUnit.Point, 204),
                                    SystemColors.WindowText, SystemColors.Highlight,
                                    SystemColors.HighlightText, DataGridViewTriState.True);
            dataTable.ColumnHeadersDefaultCellStyle =
                DefaultCellStyle(DataGridViewContentAlignment.MiddleCenter,
                                    SystemColors.Control,
                                    new Font("Times New Roman", 9F, FontStyle.Bold,
                                        GraphicsUnit.Point, 204),
                                    SystemColors.WindowText, SystemColors.Control,
                                    SystemColors.WindowText, DataGridViewTriState.True);
        }

        private DataGridViewCellStyle DefaultCellStyle(DataGridViewContentAlignment alignment,
            Color backColor, Font font, Color foreColor, Color selectBackColor,
            Color selectForeColor, DataGridViewTriState wrapMode)
        {
            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = alignment,
                BackColor = backColor,
                Font = font,
                ForeColor = foreColor,
                SelectionBackColor = selectBackColor,
                SelectionForeColor = selectForeColor,
                WrapMode = wrapMode
            };
            return defaultCellStyle;
        }
    }
}