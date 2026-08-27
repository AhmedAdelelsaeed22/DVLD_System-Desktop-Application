using AccessDataSettingLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDataLayer
{
    public class clsLicenseClassData
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dtLicenseClasses = new DataTable();

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                   @"SELECT * FROM fn_LicenseClasses_GetAll();", connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtLicenseClasses.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtLicenseClasses;
        }

        public static int GetLicenseClassIDByClassName_SP(string ClassName)
        {
            int LicenseClassID = -1;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_LicenseClasses_GetIDByClassName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClassName", ClassName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        LicenseClassID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return LicenseClassID;
        }


        public static string GetLicenseClassName(int LicenseClassID)
        {
            string ClassName = "";

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_LicenseClasses_GetClassNameByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        ClassName = result.ToString();
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return ClassName;
        }


        public static byte GetDefaultValidityLength(int LicenseClassID)
        {

            byte DefaultValidityLength = 0;

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            {

                using (SqlCommand command =
                    new SqlCommand(
                    "SELECT DefaultValidityLength " +
                    "FROM fn_GetDefaultValidityLength(@LicenseClassID)",
                    connection))
                {

                    command.Parameters.AddWithValue(
                        "@LicenseClassID",
                        LicenseClassID);

                    connection.Open();

                    object result =
                        command.ExecuteScalar();

                    if (result != null)

                        DefaultValidityLength =
                        Convert.ToByte(result);

                }

            }

            return DefaultValidityLength;

        }

    }
}
