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
    public class clsLicenseData
    {
        public static int InsertLicense(
        int ApplicationID,
        int DriverID,
        int LicenseClass,
        DateTime IssueDate,
        DateTime ExpirationDate,
        string Notes,
        decimal PaidFees,
        bool IsActive,
        byte IssueReason,
        int CreatedByUserID)
        {

            int LicenseID = -1;

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            {

                using (SqlCommand command =
                    new SqlCommand("sp_InsertLicense", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    SqlParameter outputId =
                    new SqlParameter("@LicenseID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputId);

                    connection.Open();

                    command.ExecuteNonQuery();

                    LicenseID = (int)outputId.Value;
                }
            }

            return LicenseID;
        }


        public static bool FindLicenseByID(
        int LicenseID,
        ref int ApplicationID,
        ref int DriverID,
        ref int LicenseClass,
        ref DateTime IssueDate,
        ref DateTime ExpirationDate,
        ref string Notes,
        ref decimal PaidFees,
        ref bool IsActive,
        ref byte IssueReason,
        ref int CreatedByUserID)
        {

            bool IsFound = false;

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            {

                using (SqlCommand command =
                    new SqlCommand("sp_FindLicenseByLicenseID", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;

                        ApplicationID = (int)reader["ApplicationID"];
                        DriverID = (int)reader["DriverID"];
                        LicenseClass = (int)reader["LicenseClass"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                        Notes = reader["Notes"].ToString();
                        PaidFees = (decimal)reader["PaidFees"];
                        IsActive = (bool)reader["IsActive"];
                        IssueReason = (byte)reader["IssueReason"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];

                    }

                }
            }

            return IsFound;
        }




        // ---------------- FIND LICENSE BY APPLICATION ID ----------------
        public static bool FindLicenseByApplicationID(
        int ApplicationID,
        ref int LicenseID,
        ref int DriverID,
        ref int LicenseClass,
        ref DateTime IssueDate,
        ref DateTime ExpirationDate,
        ref string Notes,
        ref decimal PaidFees,
        ref bool IsActive,
        ref byte IssueReason,
        ref int CreatedByUserID)
        {

            bool IsFound = false;

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            {

                using (SqlCommand command =
                    new SqlCommand(
                    @"SELECT *
              FROM dbo.fn_FindLicenseByApplicationID(@ApplicationID);", connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    try
                    {

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {

                            IsFound = true;

                            LicenseID = (int)reader["LicenseID"];
                            DriverID = (int)reader["DriverID"];
                            LicenseClass = (int)reader["LicenseClass"];
                            IssueDate = (DateTime)reader["IssueDate"];
                            ExpirationDate = (DateTime)reader["ExpirationDate"];

                            if (reader["Notes"] != DBNull.Value)
                                Notes = reader["Notes"].ToString();
                            else
                                Notes = "";

                            PaidFees = (decimal)reader["PaidFees"];
                            IsActive = (bool)reader["IsActive"];
                            IssueReason = (byte)reader["IssueReason"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];

                        }

                    }
                    catch (Exception ex)
                    {
                        clsLogErrors.LogError(ex);
                    }

                }

            }

            return IsFound;
        }


        // ---------------- IS LICENSE EXISTS BY APPLICATION ID ----------------
        public static bool IsLicenseExists_ByApplicationID(int ApplicationID)
        {
            bool IsExists = false;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand(
                       @"SELECT Exist 
                 FROM dbo.fn_IsLicenseExists_ByApplicationID(@ApplicationID);", connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int value))
                    {
                        IsExists = (value == 1);
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return IsExists;
        }


        // ---------------- GET LICENSES BY APPLICATION ID ----------------
        public static DataTable GetLicenses_ByApplicationID(
        int ApplicationID)
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                new SqlCommand(
                @"SELECT *
          FROM dbo.fn_GetLicenses_ByApplicationID
          (@ApplicationID);", connection))
            {

                command.Parameters.AddWithValue(
                    "@ApplicationID",
                    ApplicationID);

                try
                {

                    connection.Open();

                    SqlDataReader reader =
                        command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        dt.Load(reader);

                    }

                }
                catch (Exception ex)
                {

                    clsLogErrors.LogError(ex);

                }

            }

            return dt;

        }
    }
}
