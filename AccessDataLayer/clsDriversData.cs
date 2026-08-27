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
    public class clsDriversData
    {
        public static int InsertDriver(
          int PersonID,
          int CreatedByUserID,
          DateTime CreatedDate)
        {

            int DriverID = -1;

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            {

                using (SqlCommand command =
                    new SqlCommand("sp_InsertDriver", connection))
                {

                    command.CommandType =
                        CommandType.StoredProcedure;


                    command.Parameters.AddWithValue(
                        "@PersonID", PersonID);

                    command.Parameters.AddWithValue(
                        "@CreatedByUserID", CreatedByUserID);

                    command.Parameters.AddWithValue(
                        "@CreatedDate", CreatedDate);


                    SqlParameter outputParameter =
                        new SqlParameter(
                            "@DriverID", SqlDbType.Int);

                    outputParameter.Direction =
                        ParameterDirection.Output;

                    command.Parameters.Add(outputParameter);


                    connection.Open();

                    command.ExecuteNonQuery();


                    DriverID =(int)outputParameter.Value;

                }

            }

            return DriverID;

        }


        // ---------------- GET ALL DRIVERS ----------------
        public static DataTable GetAllDrivers()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection =
                new SqlConnection(clsAccessDataSettings.connectionString))
            using (SqlCommand command =
                new SqlCommand(
                @"SELECT *
          FROM dbo.fn_GetAllDrivers();", connection))
            {

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
