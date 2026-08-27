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
    public class clsApplicationTestTypeData
    {
        public static DataTable GetAllApplicationTestTypes()
        {
            DataTable dtTestTypes = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM fn_ApplicationTestType_GetAll();", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dtTestTypes.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsLogErrors.LogError(ex);
                }
            }

            return dtTestTypes;
        }


        public static bool FindApplicationTestType(
        int TestTypeID,
        ref string TestTypeTitle,
        ref string TestTypeDescription,
        ref decimal TestTypeFees)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                @"SELECT * FROM fn_ApplicationTestType_GetByID(@TestTypeID);", connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TestTypeTitle = reader["TestTypeTitle"].ToString();
                            TestTypeDescription = reader["TestTypeDescription"].ToString();
                            TestTypeFees = (decimal)reader["TestTypeFees"];

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


        public static bool UpdateApplicationTestType(
        int TestTypeID,
        string TestTypeTitle,
        string TestTypeDescription,
        decimal TestTypeFees)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand("sp_ApplicationTestType_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

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


        public static decimal GetApplicationTestTypeFees(int TestTypeID)
        {
            decimal Fees = -1;

            using (SqlConnection connection =
                   new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command = new SqlCommand(
                   @"sp_ApplicationTestType_GetFees",
                   connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
    }
}
