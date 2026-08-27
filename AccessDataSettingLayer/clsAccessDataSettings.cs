using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDataSettingLayer
{
    public class clsAccessDataSettings
    {

        public static string connectionString =
            ConfigurationManager.ConnectionStrings["DVLDConnection"].ConnectionString;
        public static string sourceName = ConfigurationManager.AppSettings["EventLogSource"];
        public static string logName = ConfigurationManager.AppSettings["EventLogName"];

    }
}
