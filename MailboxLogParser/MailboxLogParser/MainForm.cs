using MailboxLogParser.Common.Reporting;
using MailboxLogParser.Common.Reporting.BasicReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MailboxLogParser
{
    public partial class MainForm : Form
    {
        private ReportBase Report = new BasicReport();
        private List<int> HiddenGridRowIndexes = new List<int>();

        public MainForm()
        {
            InitializeComponent();
        }

        #region Event Methods

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ImportButton.Select();

            UpdateStatus("Import mailbox logs to get started.");

            foreach (ReportColumnBase col in this.Report.ReportColumns)
            {
                int colIndex = this.LogReportGrid.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn() 
                { 
                    HeaderText = col.ColumnName, 
                    Name = col.ColumnName, 
                    ValueType=col.ColumnValueType, 
                    Width = col.ColumnWidth, 
                    ReadOnly = true 
                });
            }

            this.LogReportGrid.Sort(this.LogReportGrid.Columns[this.Report.SortColumnName], ListSortDirection.Ascending);
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MailboxLogGrid_SelectionChanged(object sender, EventArgs e)
        {
            // Make sure there is a selected raow
            if (this.LogReportGrid.SelectedRows.Count == 1)
            {
                LoadReportRowData(this.LogReportGrid.SelectedRows[0].Tag as string);
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                var dialog = new OpenFileDialog();
                dialog.Title = "Pick mailbox log files to parse...";
                dialog.CheckFileExists = true;
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                        UpdateStatus("Loading...");

                        LoadLogsToGrid(dialog.FileNames);
                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }
                }

                UpdateStatus("Mailbox logs imported.");
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearLogs();

            UpdateStatus("Grid cleared.");
        }

        private void SaveReportButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.DefaultExt = "csv";
            dialog.AddExtension = true;
            dialog.AutoUpgradeEnabled = true;
            dialog.Filter = "Comma Seperated Values (*.csv)|*.csv";
            dialog.CheckPathExists = true;

            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string outputFile = dialog.FileName;

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                UpdateStatus("Saving...");
                this.Report.ExportReportToCSV(outputFile);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            Process.Start(outputFile);

            UpdateStatus("Saved grid rows and columns to CSV report.");
        }

        private void SaveLogsButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.DefaultExt = "txt";
            dialog.AddExtension = true;
            dialog.AutoUpgradeEnabled = true;
            dialog.Filter = "Text File (*.txt)|*.txt";
            dialog.CheckPathExists = true;

            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string outputFile = dialog.FileName;

            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                UpdateStatus("Saving...");
                this.Report.ExportRawLogEntries(outputFile);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            Process.Start(outputFile);

            UpdateStatus("Saved grid data to mailbox log.");
        }

        private void LogReportGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.ValueType == typeof(int))
            {
                int c1 = Int32.Parse(e.CellValue1.ToString());
                int c2 = Int32.Parse(e.CellValue2.ToString());

                if (c1 < c2)
                {
                    e.SortResult = -1;
                    e.Handled = true;
                }

                if (c1 == c2)
                {
                    e.SortResult = 0;
                    e.Handled = true;
                }

                if (c1 > c2)
                {
                    e.SortResult = 1;
                    e.Handled = true;
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                UpdateStatus("Searching...");

                ExecuteSearch(this.SearchTextBox.Text);

                UpdateStatus("Search complete. ");
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                UpdateStatus("Resetting view...");

                ClearSearch();

                UpdateStatus("Search filter cleared.");
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = this.SearchButton;
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = this.ImportButton;
        }

        #endregion

        #region Private Methods

        private void ExecuteSearch(string searchText)
        {
            Stopwatch total = new Stopwatch();
            total.Start();

            try
            {
                Stopwatch linq = new Stopwatch();
                linq.Start();

                // Query the raw data for each row in the report to see i
                // they contain the search text
                var searchHitRows = from r in this.Report.ReportRows
                                    where r.RawData.Contains(searchText)
                                    select r.RowId as string;

                // If there are no search results bail out
                if (searchHitRows.Count() == 0)
                {
                    return;
                }

                linq.Stop();
                Debug.WriteLine("ExecuteSearch: LINQ query took " + linq.ElapsedMilliseconds + " milliseconds.");

                Stopwatch loop = new Stopwatch();
                loop.Start();
                
                // Loop through each row in the grid to see if the
                // GridRow's Tag matches the ReportRow's RowId. If
                // so, that is a search hit and it should remain
                // visible. If not, it should be hidden.
                List<string> a = new List<string>(searchHitRows);
                foreach (DataGridViewRow row in this.LogReportGrid.Rows)
                {
                    if (!a.Contains(row.Tag as string))
                    {
                        // Row is not a search hit, hide it.
                        row.Visible = false;
                    }
                }

                loop.Stop();
                Debug.WriteLine("ExecuteSearch: Grid row loop took " + loop.ElapsedMilliseconds + " milliseconds.");
            }
            finally
            {
                total.Stop();
                Debug.WriteLine("ExecuteSearch: Overall took " + total.ElapsedMilliseconds + " milliseconds.");
            }
        }

        private void ClearSearch()
        {
            Stopwatch total = new Stopwatch();
            total.Start();

            try
            {
                int rowIndex = this.LogReportGrid.Rows.GetFirstRow(DataGridViewElementStates.None, DataGridViewElementStates.Visible);

                while (rowIndex > -1)
                {
                    this.LogReportGrid.Rows[rowIndex].Visible = true;
                    rowIndex = this.LogReportGrid.Rows.GetNextRow(rowIndex, DataGridViewElementStates.None, DataGridViewElementStates.Visible);
                }

                this.SearchTextBox.Text = string.Empty;
            }
            finally
            {
                total.Stop();
                Debug.WriteLine("ClearSearch: Overall took " + total.ElapsedMilliseconds + " milliseconds.");
            }
        }

        private void UpdateStatus(string statusMessage)
        {
            Debug.WriteLine("UpdateStatus called.");
            this.StatusLabel.Text = statusMessage;

            int visibleRows = this.LogReportGrid.Rows.GetRowCount(DataGridViewElementStates.Visible);
            int hiddenRows = this.LogReportGrid.Rows.Count - visibleRows;

            this.VisibleRowsLabel.Text = "Visible Rows: " + visibleRows;
            this.HiddenRowsLabel.Text = "Hidden Rows: " + hiddenRows;
            this.Refresh();
        }

        private void ClearLogs()
        {
            this.Report = new BasicReport();
            this.LogReportGrid.Rows.Clear();
            this.LogDetailText.Text = string.Empty;
            this.SearchTextBox.Text = string.Empty;
        }

        private void LoadLogsToGrid(string[] mailboxLogFiles)
        {
            Stopwatch total = new Stopwatch();
            total.Start();

            try
            {
                Stopwatch logs = new Stopwatch();
                logs.Start();

                try
                {
                    // Load the mailbox logs into the report
                    this.Report.LoadMailboxLogs(mailboxLogFiles);
                }
                finally
                {
                    logs.Stop();
                    Debug.WriteLine("LoadLogsToGrid: Report.LoadMailboxLogs took " + logs.ElapsedMilliseconds + " milliseconds.");
                }

                string selectedReportRowId = string.Empty;

                // Save the selected log item
                if (this.LogReportGrid.SelectedRows.Count != 0)
                {
                    selectedReportRowId = this.LogReportGrid.SelectedRows[0].Tag as string;
                }

                // Save sorting state
                DataGridViewColumn sortColumn = this.LogReportGrid.SortedColumn;
                SortOrder sortOrder = this.LogReportGrid.SortOrder;

                this.LogReportGrid.Rows.Clear();

                DataGridViewRow row = null;

                foreach (ReportRowBase reportRow in this.Report.ReportRows)
                {
                    int index = this.LogReportGrid.Rows.Add();

                    row = this.LogReportGrid.Rows[index];

                    foreach (string columnName in reportRow.Columns.Keys)
                    {
                        row.Cells[columnName].Value = reportRow[columnName];
                    }

                    // Reapply selection
                    if (reportRow.RowId == selectedReportRowId)
                    {
                        this.LogReportGrid.Rows[index].Selected = true;
                    }

                    // Save the item with the row for use later
                    this.LogReportGrid.Rows[index].Tag = reportRow.RowId;
                }

                // Reapply sorting..
                if (sortOrder == SortOrder.Ascending)
                {
                    this.LogReportGrid.Sort(sortColumn, ListSortDirection.Ascending);
                }
                else if (sortOrder == SortOrder.Descending)
                {
                    this.LogReportGrid.Sort(sortColumn, ListSortDirection.Descending);
                }

                // Select the first log item if none was selected before..
                if (selectedReportRowId == string.Empty && this.LogReportGrid.Rows.Count > 0)
                {
                    this.LogReportGrid.Rows[0].Selected = true;
                }

                // Reload the selected item
                MailboxLogGrid_SelectionChanged(null, null);
            }
            finally
            {
                total.Stop();
                Debug.WriteLine("LoadReportToGrid: Overall took " + total.ElapsedMilliseconds + " milliseconds.");
            }
        }

        private void LoadReportRowData(string rowId)
        {
            Stopwatch total = new Stopwatch();
            total.Start();

            try
            {
                var data = from r in this.Report.ReportRows
                           where r.RowId == rowId
                           select r.RawData as string;

                if (data.Count() > 1)
                {
                    throw new ApplicationException("More than one match in ReportRows for RowId, '" + rowId + "'");
                }

                if (data.Count() == 0)
                {
                    this.LogDetailText.Text = null;
                    return;
                }

                this.LogDetailText.Text = data.First();
            }
            finally
            {
                total.Stop();
                Debug.WriteLine("LoadReportRowData: Overall took " + total.ElapsedMilliseconds + " milliseconds.");
            }
        }

        #endregion

    }
}
