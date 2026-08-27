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
    public static class clsLocalDrivingLicenseApplicationsData
    {
        public static int InsertNewLocalDrivingLicenseApplication(
            int ApplicationID,
            int LicenseClassID)
        {
            int LocalDrivingLicenseID = -1;

            string query = @"DECLARE @LocalDriveLicenseID INT;
                         EXEC sp_LocalDrivingLicenseApplications_Add
                              @ApplicationID = @ApplicationID,
                              @LicenseClassID = @LicenseClassID,
                              @NewLocalDriverLicenseID = @LocalDriveLicenseID OUTPUT;
                         SELECT @LocalDriveLicenseID AS NewLocalDriverLicense;";

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ID))
                    {
                        LocalDrivingLicenseID = ID;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return LocalDrivingLicenseID;
        }


        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dtLocalDrivingLicenses = new DataTable();

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                   @"SELECT * 
                 FROM fn_LocalDrivingLicenseApplications_GetAll();",
                   connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtLocalDrivingLicenses.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtLocalDrivingLicenses;
        }


        public static bool IsExistClassApplicationWithStatusNew(string NationalNo , string ClassName)
        {
            bool IsExist = false;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_LocalDrivingLicense_IsExistClassification_StatusNew", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NationalNo", NationalNo);
                command.Parameters.AddWithValue("@ClassName", ClassName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString() , out int Exist))
                    {
                        IsExist = (Exist == 1 ? true : false);
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return IsExist;
        }


        public static bool IsExistClassApplicationWithStatusCompleted(string NationalNo, string ClassName)
        {
            bool IsExist = false;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_LocalDrivingLicense_IsExistClassification_StatusCompleted", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NationalNo", NationalNo);
                command.Parameters.AddWithValue("@ClassName", ClassName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int Exist))
                    {
                        IsExist = (Exist == 1 ? true : false);
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return IsExist;
        }


        public static bool FindLocalDrivingLicenseApplication(
           int LocalDrivingLicenseApplicationID,
           ref int ApplicationID,
           ref int LicenseClassID)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                   @"SELECT *
                 FROM fn_LocalDrivingLicenseApplications_Find
                 (@LocalDrivingLicenseApplicationID);",
                   connection))
            {
                command.Parameters.AddWithValue(
                    "@LocalDrivingLicenseApplicationID",
                    LocalDrivingLicenseApplicationID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationID = (int)reader["ApplicationID"];
                            LicenseClassID = (int)reader["LicenseClassID"];

                            IsFound = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return IsFound;
        }


        public static string GetLocalDrivingLicenseStatus(int LocalDrivingLicenseApplicationID)
        {
            string Status = "";

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_LocalDrivingLicenses_GetStatusByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID",
                                                LocalDrivingLicenseApplicationID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        Status = result.ToString();
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return Status;
        }


        public static int GetPassedTestCount(int LDAppID)
        {
            int PassedCount = -1;

            string query = @"SELECT * FROM dbo.fn_GetPassedTestCount(@LocalDrivingLicenseApplicationID);";

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDAppID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int pCount))
                    {
                        PassedCount = pCount;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return PassedCount;
        }

        // ---------------- GET NATIONAL NO BY LOCAL DRIVING LICENSE APPLICATION ID ----------------
        public static string GetNationalNo_ByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            string NationalNo = "";

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand(
                       @"SELECT * 
                 FROM dbo.fn_GetNationalNo_ByLocalDrivingLicenseApplicationID
                 (@LocalDrivingLicenseApplicationID);", connection))
            {
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        NationalNo = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return NationalNo;
        }



        // ---------------- UPDATE APPLICATION STATUS ----------------
        public static bool UpdateApplicationStatus(
        int ApplicationID,
        byte ApplicationStatus)
        {

            int RowsAffected = 0;

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                new SqlCommand("sp_Applications_UpdateStatus", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);


                try
                {

                    connection.Open();

                    RowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    clsLogErrors.LogError(ex);

                }

            }

            return (RowsAffected > 0);

        }



        // ---------------- DELETE LOCAL DRIVING LICENSE APPLICATION ----------------
        public static bool DeleteLocalDrivingLicenseApplication(
        int LocalDrivingLicenseApplicationID)
        {

            int RowsAffected = 0;

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                new SqlCommand(
                "sp_LocalDrivingLicenseApplications_Delete", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue(
                "@LocalDrivingLicenseApplicationID",
                LocalDrivingLicenseApplicationID);


                try
                {

                    connection.Open();

                    RowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    clsLogErrors.LogError(ex);

                }

            }

            return (RowsAffected > 0);

        }
    }
}
