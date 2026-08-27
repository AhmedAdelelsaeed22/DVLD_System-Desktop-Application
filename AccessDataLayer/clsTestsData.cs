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
    public class clsTestsData
    {
        public static int InsertTest(
            int TestAppointmentID,
            bool TestResult,
            string Notes,
            int CreatedByUserID)
        {
            int NewTestID = -1;

            using (SqlConnection connection = new SqlConnection(clsAccessDataSettings.connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_Tests_Add", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);
                    command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    SqlParameter outputParam = new SqlParameter("@NewTestID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);

                    connection.Open();
                    command.ExecuteNonQuery();

                    NewTestID = (int)outputParam.Value;
                }
            }

            return NewTestID;
        }


        public static bool IsPassedTest(int TestAppointmentID)
        {

            bool TestResult = false;

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            {

                string query = "SELECT TestResult FROM fn_GetTestResultByAppointmentID(@TestAppointmentID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            TestResult = Convert.ToBoolean(result);
                        }

                    }
                    catch (Exception ex)
                    {

                        clsLogErrors.LogError(ex);

                    }

                }

            }

            return TestResult;

        }
    }
}
