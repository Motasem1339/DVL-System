using System;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    /// <summary>
    /// this class for Log Exeption in Event Log and montering the application
    /// </summary>
    public class clsLogger
    {
        private static string SourceName = "DVLD_App";

        static clsLogger()
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
        }
        /// <summary>
        /// Logs an exception to the Windows Event Log with the specified entry type
        /// the default entry type is Error if not specified.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="EnteryType">The type of entry to log ,Default type is Error.</param>
        public static void Log(Exception ex,EventLogEntryType EnteryType=EventLogEntryType.Error)
        {
            EventLog.WriteEntry(SourceName,FormatMessage(ex), EnteryType);
        }

        private static string FormatMessage(Exception ex)
        {
            return $"Timestamp:{DateTime.Now}\n"+
                   $"Message:{ex.Message}\n\n " +
                   $"Inner Exception :{(ex.InnerException != null ? ex.InnerException.Message : "N/A")}\n\n " +
                   $"Stack Trace:{ex.StackTrace}\n\n" +
                   $"Source: {ex.Source}\n";
        }

    }
}
