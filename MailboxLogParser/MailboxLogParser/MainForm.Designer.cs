namespace MailboxLogParser
{
    partial class MainForm
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
            this.MailboxLogSplit = new System.Windows.Forms.SplitContainer();
            this.LogReportGrid = new System.Windows.Forms.DataGridView();
            this.LogDetailText = new System.Windows.Forms.TextBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.SeperatorGroupBox = new System.Windows.Forms.GroupBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.ClearSearchButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SaveLogsButton = new System.Windows.Forms.Button();
            this.SaveReportButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.VisibleRowsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.HiddenRowsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.MailboxLogSplit)).BeginInit();
            this.MailboxLogSplit.Panel1.SuspendLayout();
            this.MailboxLogSplit.Panel2.SuspendLayout();
            this.MailboxLogSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogReportGrid)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MailboxLogSplit
            // 
            this.MailboxLogSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MailboxLogSplit.Location = new System.Drawing.Point(0, 52);
            this.MailboxLogSplit.Name = "MailboxLogSplit";
            // 
            // MailboxLogSplit.Panel1
            // 
            this.MailboxLogSplit.Panel1.Controls.Add(this.LogReportGrid);
            // 
            // MailboxLogSplit.Panel2
            // 
            this.MailboxLogSplit.Panel2.Controls.Add(this.LogDetailText);
            this.MailboxLogSplit.Size = new System.Drawing.Size(821, 458);
            this.MailboxLogSplit.SplitterDistance = 516;
            this.MailboxLogSplit.SplitterWidth = 10;
            this.MailboxLogSplit.TabIndex = 11;
            // 
            // LogReportGrid
            // 
            this.LogReportGrid.AllowUserToAddRows = false;
            this.LogReportGrid.AllowUserToDeleteRows = false;
            this.LogReportGrid.AllowUserToOrderColumns = true;
            this.LogReportGrid.AllowUserToResizeRows = false;
            this.LogReportGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogReportGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogReportGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogReportGrid.Location = new System.Drawing.Point(0, 0);
            this.LogReportGrid.MultiSelect = false;
            this.LogReportGrid.Name = "LogReportGrid";
            this.LogReportGrid.ReadOnly = true;
            this.LogReportGrid.RowHeadersVisible = false;
            this.LogReportGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LogReportGrid.Size = new System.Drawing.Size(516, 458);
            this.LogReportGrid.TabIndex = 0;
            this.LogReportGrid.SelectionChanged += new System.EventHandler(this.MailboxLogGrid_SelectionChanged);
            this.LogReportGrid.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.LogReportGrid_SortCompare);
            // 
            // LogDetailText
            // 
            this.LogDetailText.BackColor = System.Drawing.SystemColors.Window;
            this.LogDetailText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogDetailText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogDetailText.Location = new System.Drawing.Point(0, 0);
            this.LogDetailText.Multiline = true;
            this.LogDetailText.Name = "LogDetailText";
            this.LogDetailText.ReadOnly = true;
            this.LogDetailText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogDetailText.Size = new System.Drawing.Size(295, 458);
            this.LogDetailText.TabIndex = 0;
            this.LogDetailText.WordWrap = false;
            // 
            // StatusStrip
            // 
            this.StatusStrip.AutoSize = false;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.VisibleRowsLabel,
            this.HiddenRowsLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 510);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(821, 22);
            this.StatusStrip.TabIndex = 12;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = false;
            this.StatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(300, 17);
            this.StatusLabel.Text = "Import a mailbox log...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.SeperatorGroupBox);
            this.MenuPanel.Controls.Add(this.SearchLabel);
            this.MenuPanel.Controls.Add(this.ClearSearchButton);
            this.MenuPanel.Controls.Add(this.SearchButton);
            this.MenuPanel.Controls.Add(this.SearchTextBox);
            this.MenuPanel.Controls.Add(this.SaveLogsButton);
            this.MenuPanel.Controls.Add(this.SaveReportButton);
            this.MenuPanel.Controls.Add(this.ClearButton);
            this.MenuPanel.Controls.Add(this.ImportButton);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(821, 52);
            this.MenuPanel.TabIndex = 13;
            // 
            // SeperatorGroupBox
            // 
            this.SeperatorGroupBox.Location = new System.Drawing.Point(396, 3);
            this.SeperatorGroupBox.Name = "SeperatorGroupBox";
            this.SeperatorGroupBox.Size = new System.Drawing.Size(10, 45);
            this.SeperatorGroupBox.TabIndex = 9;
            this.SeperatorGroupBox.TabStop = false;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(412, 9);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(159, 13);
            this.SearchLabel.TabIndex = 8;
            this.SearchLabel.Text = "Search raw log data for strings...";
            // 
            // ClearSearchButton
            // 
            this.ClearSearchButton.Location = new System.Drawing.Point(748, 29);
            this.ClearSearchButton.Name = "ClearSearchButton";
            this.ClearSearchButton.Size = new System.Drawing.Size(68, 20);
            this.ClearSearchButton.TabIndex = 6;
            this.ClearSearchButton.Text = "Clear";
            this.ClearSearchButton.UseVisualStyleBackColor = true;
            this.ClearSearchButton.Click += new System.EventHandler(this.ClearSearchButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(748, 5);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(68, 20);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(415, 27);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(327, 20);
            this.SearchTextBox.TabIndex = 4;
            this.SearchTextBox.Enter += new System.EventHandler(this.SearchTextBox_Enter);
            this.SearchTextBox.Leave += new System.EventHandler(this.SearchTextBox_Leave);
            // 
            // SaveLogsButton
            // 
            this.SaveLogsButton.Location = new System.Drawing.Point(204, 3);
            this.SaveLogsButton.Name = "SaveLogsButton";
            this.SaveLogsButton.Size = new System.Drawing.Size(90, 45);
            this.SaveLogsButton.TabIndex = 2;
            this.SaveLogsButton.Text = "Export Merged Mailbox Logs...";
            this.SaveLogsButton.UseVisualStyleBackColor = true;
            this.SaveLogsButton.Click += new System.EventHandler(this.SaveLogsButton_Click);
            // 
            // SaveReportButton
            // 
            this.SaveReportButton.Location = new System.Drawing.Point(300, 4);
            this.SaveReportButton.Name = "SaveReportButton";
            this.SaveReportButton.Size = new System.Drawing.Size(90, 45);
            this.SaveReportButton.TabIndex = 3;
            this.SaveReportButton.Text = "Export Grid to CSV...";
            this.SaveReportButton.UseVisualStyleBackColor = true;
            this.SaveReportButton.Click += new System.EventHandler(this.SaveReportButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(108, 3);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(90, 45);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Clear Grid";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(12, 3);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(90, 45);
            this.ImportButton.TabIndex = 0;
            this.ImportButton.Text = "Import Mailbox Logs to Grid...";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // VisibleRowsLabel
            // 
            this.VisibleRowsLabel.AutoSize = false;
            this.VisibleRowsLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.VisibleRowsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.VisibleRowsLabel.Name = "VisibleRowsLabel";
            this.VisibleRowsLabel.Size = new System.Drawing.Size(150, 17);
            this.VisibleRowsLabel.Text = "Visible Rows: ";
            this.VisibleRowsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HiddenRowsLabel
            // 
            this.HiddenRowsLabel.AutoSize = false;
            this.HiddenRowsLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.HiddenRowsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.HiddenRowsLabel.Name = "HiddenRowsLabel";
            this.HiddenRowsLabel.Size = new System.Drawing.Size(150, 17);
            this.HiddenRowsLabel.Text = "Hidden Rows: ";
            this.HiddenRowsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AcceptButton = this.ImportButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 532);
            this.Controls.Add(this.MailboxLogSplit);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.StatusStrip);
            this.MinimumSize = new System.Drawing.Size(837, 571);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mailbox Log Parser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MailboxLogSplit.Panel1.ResumeLayout(false);
            this.MailboxLogSplit.Panel2.ResumeLayout(false);
            this.MailboxLogSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MailboxLogSplit)).EndInit();
            this.MailboxLogSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogReportGrid)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MailboxLogSplit;
        private System.Windows.Forms.DataGridView LogReportGrid;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.TextBox LogDetailText;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button SaveLogsButton;
        private System.Windows.Forms.Button SaveReportButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button ClearSearchButton;
        private System.Windows.Forms.GroupBox SeperatorGroupBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.ToolStripStatusLabel VisibleRowsLabel;
        private System.Windows.Forms.ToolStripStatusLabel HiddenRowsLabel;

    }
}

