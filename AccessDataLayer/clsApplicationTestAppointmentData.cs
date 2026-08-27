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
    public class clsApplicationTestAppointmentData
    {
        // ---------------- INSERT TEST APPOINTMENT ----------------
        public static int InsertTestAppointment(
            int TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,
            decimal PaidFees,
            int CreatedByUserID,
            bool IsLocked)
        {
            int TestAppointmentID = -1;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_TestAppointments_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue(
                    "@LocalDrivingLicenseApplicationID",
                    LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue(
                    "@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue(
                    "@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);

                SqlParameter outputParam = new SqlParameter(
                    "@NewTestAppointmentID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    if (outputParam.Value != DBNull.Value)
                    {
                        TestAppointmentID =
                            Convert.ToInt32(outputParam.Value);
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return TestAppointmentID;
        }


        public static DataTable GetAllTestAppointments(int LDAppID)
        {
            DataTable dtTestAppointments = new DataTable();

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                   @"SELECT * FROM fn_TestAppointments_GetAll(@LocalDrivingLicenseApplicationID);",
                   connection))
            {

                command.Parameters.AddWithValue
                    ("@LocalDrivingLicenseApplicationID", LDAppID);
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtTestAppointments.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtTestAppointments;
        }


        public static DataTable GetAllWrittenTestAppointments(int LDAppID)
        {
            DataTable dtTestAppointments = new DataTable();

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                   @"SELECT * FROM dbo.fn_TestAppointments_GetAllwritten(@LocalDrivingLicenseApplicationID);",
                   connection))
            {

                command.Parameters.AddWithValue
                    ("@LocalDrivingLicenseApplicationID", LDAppID);
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtTestAppointments.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtTestAppointments;
        }


        public static DataTable GetAllStreetTestAppointments(int LDAppID)
        {
            DataTable dtTestAppointments = new DataTable();

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                   @"SELECT * FROM dbo.fn_TestAppointments_GetAllStreet(@LocalDrivingLicenseApplicationID);",
                   connection))
            {

                command.Parameters.AddWithValue
                    ("@LocalDrivingLicenseApplicationID", LDAppID);
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtTestAppointments.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtTestAppointments;
        }

        public static bool IsExistTestAppointment(int LDAppID)
        {
            bool IsExist = false;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_TestAppointments_IsExist", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDAppID);

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


        public static bool IsLockedTestAppointment(int LDAppID)
        {
            bool IsLocked = false;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_TestAppointments_IsLocked", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDAppID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int Exist))
                    {
                        IsLocked = (Exist == 1 ? true : false);
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return IsLocked;
        }

        // ---------------- FIND ----------------
        public static bool FindTestAppointment(
            int TestAppointmentID,
            ref int TestTypeID,
            ref int LocalDrivingLicenseApplicationID,
            ref DateTime AppointmentDate,
            ref decimal PaidFees,
            ref int CreatedByUserID,
            ref bool IsLocked)
        {
            bool IsFound = false;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_TestAppointments_Find", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TestTypeID = (int)reader["TestTypeID"];
                            LocalDrivingLicenseApplicationID =
                                (int)reader["LocalDrivingLicenseApplicationID"];
                            AppointmentDate = (DateTime)reader["AppointmentDate"];
                            PaidFees = (decimal)reader["PaidFees"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            IsLocked = (bool)reader["IsLocked"];

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

        // ---------------- UPDATE ----------------
        public static bool UpdateTestAppointment(
            int TestAppointmentID,
            int TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,
            decimal PaidFees,
            int CreatedByUserID,
            bool IsLocked)
        {
            int RowsAffected = 0;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_TestAppointments_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue(
                    "@LocalDrivingLicenseApplicationID",
                    LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);

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

            return (RowsAffected < 0);
        }


        public static bool UpdateIsLockedTestAppointment(int TestAppointmentID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_Appointment_EditIsLocked", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

            return (RowsAffected < 0);
        }
    }
}
