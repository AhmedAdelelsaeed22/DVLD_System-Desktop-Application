using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDataSettingLayer
{
    public class clsLogErrors
    {
        public static void LogError(Exception ex)
        {
            if (!EventLog.SourceExists(clsAccessDataSettings.sourceName))
            {
                EventLog.CreateEventSource(clsAccessDataSettings.sourceName, clsAccessDataSettings.logName);
            }

            EventLog.WriteEntry(
                clsAccessDataSettings.sourceName,
                ex.Message,
                EventLogEntryType.Error);
        }
    }
}
