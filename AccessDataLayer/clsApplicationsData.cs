using AccessDataSettingLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDataLayer
{
    public class clsApplicationsData
    {
        public static int InsertNewApplication(
        int ApplicantPersonID,
        DateTime ApplicationDate,
        int ApplicationTypeID,
        byte ApplicationStatus,
        DateTime LastStatusDate,
        decimal PaidFees,
        int CreatedByUserID)
        {
            int ApplicationID = -1;

            string query = @"DECLARE @NewApplicationID INT;
                     EXEC sp_Applications_Add
                         @ApplicantPersonID = @ApplicantPersonID,
                         @ApplicationDate = @ApplicationDate,
                         @ApplicationTypeID = @ApplicationTypeID,
                         @ApplicationStatus = @ApplicationStatus,
                         @LastStatusDate = @LastStatusDate,
                         @PaidFees = @PaidFees,
                         @CreatedByUserID = @CreatedByUserID,
                         @NewAppID = @NewApplicationID OUTPUT;
                     SELECT @NewApplicationID AS NewAppID;";

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ID))
                    {
                        ApplicationID = ID;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return ApplicationID;
        }


        public static bool CancelPersonApplication(int ApplicationID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("sp_Application_CanceledApplication", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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


        public static int GetApplicationIDUsingLDAppID(int LocalDrivingLicenseID)
        {
            int ApplicationID = 0;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("sp_Application_GetApplicationID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString() , out int ID))
                    {
                        ApplicationID = ID;
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return ApplicationID;
        }


        public static bool FindApplication(
        int ApplicationID,
        ref int ApplicantPersonID,
        ref DateTime ApplicationDate,
        ref int ApplicationTypeID,
        ref byte ApplicationStatus,
        ref DateTime LastStatusDate,
        ref decimal PaidFees,
        ref int CreatedByUserID)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                   @"SELECT * 
                 FROM fn_Applications_Find(@ApplicationID);",
                   connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicantPersonID = (int)reader["ApplicantPersonID"];
                            ApplicationDate = (DateTime)reader["ApplicationDate"];
                            ApplicationTypeID = (int)reader["ApplicationTypeID"];
                            ApplicationStatus = (byte)reader["ApplicationStatus"];
                            LastStatusDate = (DateTime)reader["LastStatusDate"];
                            PaidFees = (decimal)reader["PaidFees"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];

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


        // ---------------- DELETE APPLICATION ----------------
        public static bool DeleteApplication(int ApplicationID)
        {

            int RowsAffected = 0;

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                new SqlCommand(
                "sp_Applications_Delete", connection))
            {

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue(
                "@ApplicationID",
                ApplicationID);


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
