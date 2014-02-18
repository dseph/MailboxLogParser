using MailboxLogParser.Common.Parsing.MailboxLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailboxLogParser.Common.Reporting.BasicReport
{
    internal class BasicReportRow : ReportRowBase
    {
        protected MailboxLogEntry LogEntry { get; private set; }

        internal BasicReportRow(MailboxLogEntry logEntry) :
            base(logEntry.Name + logEntry.Identifier)
        {
            this.LogEntry = logEntry;
        }

        protected override string GetRawData()
        {
            return this.LogEntry.RawData;
        }
    }
}
