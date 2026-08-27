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
    public class clsApplicationTypeData
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dtApplicationTypes = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM fn_ApplicationTypes_GetAll();", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtApplicationTypes.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtApplicationTypes;
        }


        public static bool UpdateApplicationType(
        int ApplicationTypeID,
        string ApplicationTypeTitle,
        decimal ApplicationFees)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("sp_ApplicationTypes_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

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


        public static bool FindApplicationType(
        int ApplicationTypeID,
        ref string ApplicationTypeTitle,
        ref decimal ApplicationFees)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM fn_ApplicationTypes_GetByID(@ApplicationTypeID);", connection))
            {
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationTypeTitle = reader["ApplicationTypeTitle"].ToString();
                            ApplicationFees = (decimal)reader["ApplicationFees"];

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


        public static decimal GetApplicationFees(int ApplicationID)
        {
            decimal Fees = -1;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                   @"SELECT *
                 FROM fn_GetApplicationFeesByApplicationID(@ApplicationID);",
                   connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        Fees = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return Fees;
        }


        public static string GetApplicationTypeTitle(int ApplicationTypeID)
        {
            string Title = "";

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                   new SqlCommand("sp_ApplicationTypes_GetTitleByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ApplicationTypeID",
                                                ApplicationTypeID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                        Title = result.ToString();
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return Title;
        }
    }
}
